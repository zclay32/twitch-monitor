//==============================================================================
//
//  File:      Engine.cs
//  Author:    Jason Ziaja
//  Copyright: 2013 Jason Ziaja
//
//==============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using TwitchMonitor.Core.Interfaces;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.Drawing;
using TwitchMonitor.Core.Types;
using System.Reflection;
using TwitchMonitor.Core.Apis.MissileLauncher;
using TwitchMonitor.Core.Apis.KeyboardCommands;

namespace TwitchMonitor.Core
{
    public class Engine : IDisposable
    {
        //======================================================================
        //  Public Static Variables
        //======================================================================
        public static readonly string CacheDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TwitchMonitor");

        //======================================================================
        //  Private Members
        //======================================================================
        private static readonly string SubscriberCacheFileName = "subscribers.xml";
        private static readonly string FollowerCacheFileName = "followers.xml";
        private static readonly string UserProfileFileName = "profile.xml";
        private static readonly string SettingsFileName = "settings.xml";
        private static readonly string StatusLogFileName = "status.log";
        private static readonly int BackupFileCount = 10;

        private string subscriberListCacheFile;
        private string followerCacheFile;
        private string settingsFile;
        private string currentProfile;
        private BackgroundWorker worker;
        private List<string> responses;
        private long previousFollowerCount;
        private long previousSubscribersCount;
        private List<string> recentSubscribernames;
        private List<string> recentFollowerNames;
        private string previousProfileLogoUri;
        private PartneredStatus partneredStatus;
        private AdRunner adRunner;
        private FileBackup fileBackup;

        //======================================================================
        //  Public Properties
        //======================================================================
        /// <summary>
        /// Gets or sets the interface to the view for the engine and any child objects to use.
        /// </summary>
        public IView View { get; set; }

        /// <summary>
        /// Gets or sets the interface to the loading view for the engine to relay messages while loading.
        /// </summary>
        public ILoadingView LoadingView { get; set; }

        /// <summary>
        /// Gets the object that performs any upgrade tasks.
        /// </summary>
        public UpgradeTasks UpgradeTasks { get; private set; }

        /// <summary>
        /// Gets the settings for this application.
        /// </summary>
        public Settings Settings { get; private set; }

        /// <summary>
        /// Gets or sets the currently-selected profile.
        /// </summary>
        public UserProfile SelectedProfile { get; set; }

        /// <summary>
        /// Gets or sets the list of user profiles.
        /// </summary>
        public List<UserProfile> UserProfiles { get; set; }

        /// <summary>
        /// Gets the cache of subscribers.
        /// </summary>
        public SubscriberCache SubscriberCache { get; private set; }

        /// <summary>
        /// Gets the cache of followers. Due to the volume of potential subscribers, only the IDs are stored.
        /// </summary>
        public FollowerCache FollowerCache { get; private set; }

        /// <summary>
        /// Gets the sound player for playing custom sounds.
        /// </summary>
        public SoundPlayer SoundPlayer { get; private set; }

        /// <summary>
        /// Gets whether or not the monitor worker is currently running.
        /// </summary>
        public bool IsBusy { get { return this.worker.IsBusy; } }

        /// <summary>
        /// Gets or sets the list of recent subscriber activity.
        /// </summary>
        public Dictionary<string, SubscriberActivity> SubscriberActivity { get; set; }

        /// <summary>
        /// Gets or sets the list of recent follower activity.
        /// </summary>
        public Dictionary<string, FollowerActivity> FollowerActivity { get; set; }

        /// <summary>
        /// Gets the list of recent followers.
        /// </summary>
        public List<Follower> RecentFollowers { get; set; }

        /// <summary>
        /// Gets whether or not the channel is currenly live and a stream is online.
        /// </summary>
        public bool IsStreamOnline { get; private set; }

        /// <summary>
        /// Gets the number of current viewers watching the stream.
        /// </summary>
        public long ViewerCount { get; private set; }

        /// <summary>
        /// Gets the ping times for all the Twitch.tv ingest servers.
        /// </summary>
        public ServerPings ServerPings { get; private set; }

        /// <summary>
        /// Gets whether or not a cancellation is currently pending. All actions should be stopped if this is set to true.
        /// </summary>
        public static bool CancellationPending { get; private set; }

        /// <summary>
        /// Gets whether or not this user is partnered with Twitch.
        /// </summary>
        public bool IsPartnered { get { return this.partneredStatus == PartneredStatus.Partnered; } }

        /// <summary>
        /// Gets the path to the status log file.
        /// </summary>
        public string StatusLogFile { get; private set; }

        /// <summary>
        /// Gets the loaded Missile Launcher API.
        /// </summary>
        public MissileLauncherApi MissileLauncherApi { get; private set; }

        /// <summary>
        /// Gets the API to send keyboard commands to another application.
        /// </summary>
        public KeyboardCommandsApi KeyboardCommandsApi { get; private set; }

        /// <summary>
        /// Private enum that determines whether or not the user is partnered.
        /// </summary>
        private enum PartneredStatus
        {
            Unknown,
            Partnered,
            NotPartnered
        }

        //======================================================================
        //  Constructors
        //======================================================================
        /// <summary>
        /// Default constructor that initializes all the members.
        /// </summary>
        public Engine()
        {
            //------------------------------------------------------------------
            //  Initialize all members and properties.
            //------------------------------------------------------------------
            this.responses = new List<string>();
            this.RecentFollowers = new List<Follower>();
            this.FollowerActivity = new Dictionary<string, FollowerActivity>();
            this.recentSubscribernames = new List<string>();
            this.recentFollowerNames = new List<string>();
            this.ServerPings = new ServerPings(this);
            this.SubscriberActivity = new Dictionary<string, SubscriberActivity>();
            this.adRunner = new AdRunner(this);
            this.UpgradeTasks = new UpgradeTasks(this);
            this.UserProfiles = new List<UserProfile>();
            this.fileBackup = new FileBackup(this);
            this.MissileLauncherApi = new MissileLauncherApi(this);
            this.KeyboardCommandsApi = new KeyboardCommandsApi(this);

            this.previousProfileLogoUri = "";
            this.partneredStatus = PartneredStatus.Unknown;

            this.settingsFile = Path.Combine(Engine.CacheDirectory, Engine.SettingsFileName);
            this.StatusLogFile = Path.Combine(Engine.CacheDirectory, Engine.StatusLogFileName);
            this.SoundPlayer = new SoundPlayer();

            this.worker = new BackgroundWorker();
            this.worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            this.worker.WorkerSupportsCancellation = true;
            this.worker.WorkerReportsProgress = true;
            this.worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);

            //------------------------------------------------------------------
            //  Initialize the log file.
            //------------------------------------------------------------------
            this.InitializeLogFile();

            //------------------------------------------------------------------
            // Perform any upgrade task here.
            //------------------------------------------------------------------
            this.PerformPreLoadUpgradeTasks();

            //------------------------------------------------------------------
            //  Load the settings and subscriber list.
            //------------------------------------------------------------------
            if (this.Settings == null)
            {
                this.LoadSettings();
                this.LoadAllUserProfileSettings();
            }
            else if (this.UserProfiles.Count == 0)
            {
                this.LoadAllUserProfileSettings();
            }

            //------------------------------------------------------------------
            //  Backup the files.
            //------------------------------------------------------------------
            this.BackupFiles();
        }

        //======================================================================
        //  Public Methods
        //======================================================================
        /// <summary>
        /// Starts the monitor background worker.
        /// </summary>
        public void StartMonitoring()
        {
            Engine.CancellationPending = false;
            if (!this.worker.IsBusy)
            {
                this.WriteStatusLogMessage("Now monitoring activity for Twitch.tv channel " + this.Settings.DefaultProfile + ".");
                this.worker.RunWorkerAsync();
            }

            if (this.Settings.Ads.Enabled)
            {
                this.WriteStatusLogMessage("  Ad runner enabled.");
                this.adRunner.Start();
            }

            this.MissileLauncherApi.Start();
        }

        /// <summary>
        /// Stops the monitor background worker.
        /// </summary>
        public void StopMonitoring()
        {
            Engine.CancellationPending = true;
            if (this.worker.IsBusy)
            {
                this.WriteStatusLogMessage("Stopping monitor.");
                this.worker.CancelAsync();
            }

            this.adRunner.Stop();
            this.MissileLauncherApi.Stop();
        }

        /// <summary>
        /// Loads the settings for this application from a file on disk.
        /// </summary>
        public void LoadSettings()
        {
            this.WriteStatusLogMessage("Loading settings...");
            try
            {
                if (File.Exists(this.settingsFile))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                    using (FileStream fs = new FileStream(this.settingsFile, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        this.Settings = (Settings)serializer.Deserialize(fs);
                    }
                }
            }
            catch (Exception)
            {
                //--------------------------------------------------------------
                //  Ignore any exceptions trying to load the properties file.
                //--------------------------------------------------------------
            }

            //------------------------------------------------------------------
            //  If we weren't able to process the properties file, then start
            //  with a fresh object.
            //------------------------------------------------------------------
            if (null == this.Settings)
            {
                this.WriteStatusLogMessage("No previous settings file found. Creating a new file to store the application settings.");
                this.Settings = new Settings();
                this.Settings.Version = this.GetAppVersion();
            }
            else
            {
                this.WriteStatusLogMessage("Successfully loaded settings file.");
            }

            this.SetCurrentUserProfile(this.Settings.DefaultProfile);

            //------------------------------------------------------------------
            //  Load the Missile Launcher API.
            //------------------------------------------------------------------
            this.LoadMissileLauncherApi();

            //------------------------------------------------------------------
            //  Load the previous output file lists if the user chose to not
            //  clear the list on startup.
            //------------------------------------------------------------------
            if (   !this.Settings.FileOutput.Followers.ClearListOnStartup 
                && !string.IsNullOrEmpty(this.Settings.FileOutput.Followers.FilePath)
                && File.Exists(this.Settings.FileOutput.Followers.FilePath))
            {
                string contents = File.ReadAllText(this.Settings.FileOutput.Followers.FilePath).Replace(" ", string.Empty);
                this.recentFollowerNames = contents.Split(',').ToList();
            }

            if (   !this.Settings.FileOutput.Subscribers.ClearListOnStartup
                && !string.IsNullOrEmpty(this.Settings.FileOutput.Subscribers.FilePath)
                && File.Exists(this.Settings.FileOutput.Subscribers.FilePath))
            {
                string contents = File.ReadAllText(this.Settings.FileOutput.Subscribers.FilePath).Replace(" ", string.Empty);
                this.recentSubscribernames = contents.Split(',').ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadAllUserProfileSettings()
        {
            if (string.IsNullOrEmpty(this.currentProfile))
            {
                return;
            }

            foreach (ChannelProfile channelProfile in this.Settings.ChannelProfiles)
            {
                this.WriteStatusLogMessage(string.Format("Loading profile settings for channel \"{0}\"...", channelProfile.Path));
                string userProfileFile = Path.Combine(this.GetUserProfileDir(channelProfile.Path), Engine.UserProfileFileName);
                try
                {
                    if (File.Exists(userProfileFile))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(UserProfile));
                        using (FileStream fs = new FileStream(userProfileFile, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                        {
                            UserProfile userProfile = (UserProfile)serializer.Deserialize(fs);
                            this.UserProfiles.Add(userProfile);

                            if (userProfile.ChannelName.ToLower().Equals(this.Settings.DefaultProfile.ToLower()))
                            {
                                this.SetCurrentUserProfile(userProfile.ChannelName);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    //--------------------------------------------------------------
                    //  Ignore any exceptions trying to load the properties file.
                    //--------------------------------------------------------------
                }
            }
        }

        /// <summary>
        /// Saves the settings for this application to disk.
        /// </summary>
        public void SaveSettings()
        {
            this.WriteStatusLogMessage("Saving settings...");
            this.Settings.Version = this.GetAppVersion();
            this.WriteXmlFile(this.Settings, typeof(Settings), this.settingsFile);
            this.SaveAllUserProfileSettings();
        }

        /// <summary>
        /// Saves the settings for every channel profile.
        /// </summary>
        public void SaveAllUserProfileSettings()
        {
            foreach (UserProfile userProfile in this.UserProfiles)
            {
                this.SaveUserProfileSettings(userProfile);
            }
        }

        /// <summary>
        /// Saves the currently selected user profile settings.
        /// </summary>
        private void SaveCurrentUserProfileSettings()
        {
            this.SaveUserProfileSettings(this.SelectedProfile);
        }

        /// <summary>
        /// Saves the user profile settings for the specified user profile.
        /// </summary>
        /// <param name="profile">The user profile for which settings will be saved.</param>
        private void SaveUserProfileSettings(UserProfile profile)
        {
            if (profile != null)
            {
                this.WriteStatusLogMessage("Saving channel profile settings for " + profile.ChannelName);
                string profileDir = this.GetUserProfileDir(profile.ChannelName);
                if (!Directory.Exists(profileDir))
                {
                    Directory.CreateDirectory(profileDir);
                }
                this.WriteXmlFile(profile, typeof(UserProfile), Path.Combine(profileDir, Engine.UserProfileFileName));
            }
        }

        /// <summary>
        /// Helper method for writing out XML content to a file.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="contentType"></param>
        /// <param name="file"></param>
        private void WriteXmlFile(object content, Type contentType, string file)
        {
            XmlSerializer serializer = new XmlSerializer(contentType);
            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.Indent = true;
            using (XmlWriter w = XmlWriter.Create(file, writerSettings))
            {
                w.WriteStartDocument();
                serializer.Serialize(w, content);
                w.WriteEndDocument();
            }
        }

        /// <summary>
        /// Gets the version number for the monitor.
        /// </summary>
        /// <returns></returns>
        public string GetAppVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        /// <summary>
        /// Saves the list of subscribers to disk.
        /// </summary>
        public void SaveSubscriberList()
        {
            this.WriteStatusLogMessage("Saving subscriber list...");

            this.SubscriberCache.Version = this.GetAppVersion();

            try
            {
                //this.WriteXmlFile(this.SubscriberCache, typeof(SubscriberCache), this.subscriberListCacheFile);
                XmlSerializer serializer = new XmlSerializer(typeof(SubscriberCache));
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                using (XmlWriter w = XmlWriter.Create(this.subscriberListCacheFile, settings))
                {
                    w.WriteStartDocument();
                    serializer.Serialize(w, this.SubscriberCache);
                    w.WriteEndDocument();
                }
            }
            catch (Exception)
            {
                // TODO: Report an error.
            }
        }

        /// <summary>
        /// Saves the cache of followers to disk.
        /// </summary>
        public void SaveFollowerCache()
        {
            this.WriteStatusLogMessage("Saving follower cache...");

            this.FollowerCache.Version = this.GetAppVersion();

            try
            {
                //this.WriteXmlFile(this.FollowerCache, typeof(FollowerCache), this.followerCacheFile);
                XmlSerializer serializer = new XmlSerializer(typeof(FollowerCache));
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                using (XmlWriter w = XmlWriter.Create(this.followerCacheFile, settings))
                {
                    w.WriteStartDocument();
                    serializer.Serialize(w, this.FollowerCache);
                    w.WriteEndDocument();
                }
            }
            catch (Exception)
            {
                // TODO: Report an error.
            }
        }

        /// <summary>
        /// Loads the subscriber list from disk.
        /// </summary>
        public void LoadSubscriberList()
        {
            this.WriteStatusLogMessage("Loading subscriber list...");
            this.SubscriberActivity.Clear();

            try
            {
                if (File.Exists(this.subscriberListCacheFile))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SubscriberCache));
                    using (FileStream fs = new FileStream(this.subscriberListCacheFile, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        this.SubscriberCache = (SubscriberCache)serializer.Deserialize(fs);
                    }
                    this.UpgradeSubscriberCache();
                }
                else if(this.SubscriberCache != null)
                {
                    this.SubscriberCache.Subscribers.Clear();
                    this.SubscriberCache = null;
                }
            }
            catch (Exception)
            {
                //--------------------------------------------------------------
                //  Ignore any exceptions trying to load the properties file.
                //--------------------------------------------------------------
            }

            //------------------------------------------------------------------
            //  If we weren't able to process the properties file, then start
            //  with a fresh object.
            //------------------------------------------------------------------
            if (null == this.SubscriberCache)
            {
                this.WriteStatusLogMessage("No previous subscriber list found. Creating a new list.");
                this.SubscriberCache = new SubscriberCache();
                this.SubscriberCache.Version = this.GetAppVersion();
            }
            else
            {
                this.WriteStatusLogMessage("Successfully loaded subscriber list.");
            }

            //------------------------------------------------------------------
            //  Cache the follower count for future checks.
            //------------------------------------------------------------------
            this.previousSubscribersCount = this.SubscriberCache.Subscribers.Count;
        }

        /// <summary>
        /// Upgrades the cache of subscribers.
        /// </summary>
        public void UpgradeSubscriberCache()
        {
            if (this.SubscriberCache == null) { return; }

            try
            {
                Version cacheVersion = new Version(this.SubscriberCache.Version);
                Version appVersion = new Version(this.GetAppVersion());
                if (cacheVersion < appVersion)
                {
                    //----------------------------------------------------------
                    //  Convert Minecraft usernames to Notes fields.
                    //----------------------------------------------------------
                    foreach (Subscriber sub in this.SubscriberCache.Subscribers.Where((x) => { return !string.IsNullOrEmpty(x.MinecraftUserName); }))
                    {
                        if (string.IsNullOrEmpty(sub.Notes))
                        {
                            sub.Notes = sub.MinecraftUserName;
                        }
                    }
                    this.SaveSubscriberList();
                }
            }
            catch (Exception ex)
            {
                this.WriteStatusLogMessage("[ERROR] Failed to upgrade subscriber cache: " + ex.Message);
            }
        }

        /// <summary>
        /// Loads the cache of followers from disk.
        /// </summary>
        public void LoadFollowerCache()
        {
            this.WriteStatusLogMessage("Loading follower cache...");
            this.FollowerActivity.Clear();

            try
            {
                if (File.Exists(this.followerCacheFile))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(FollowerCache));
                    using (FileStream fs = new FileStream(this.followerCacheFile, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        this.FollowerCache = (FollowerCache)serializer.Deserialize(fs);
                    }
                }
                else if(this.FollowerCache != null)
                {
                    this.FollowerCache.Ids.Clear();
                    this.FollowerCache = null;
                }
            }
            catch (Exception)
            {
                //--------------------------------------------------------------
                //  Ignore any exceptions trying to load the properties file.
                //--------------------------------------------------------------
            }

            //------------------------------------------------------------------
            //  If we weren't able to process the properties file, then start
            //  with a fresh object.
            //------------------------------------------------------------------
            if (null == this.FollowerCache)
            {
                this.WriteStatusLogMessage("No previous follower cache found. Creating a new cache.");
                this.FollowerCache = new FollowerCache();
                this.FollowerCache.Version = this.GetAppVersion();
                this.FollowerCache.FollowersCount = this.SubscriberCache.FollowersCount;
            }
            else
            {
                this.WriteStatusLogMessage("Successfully loaded follower cache.");
            }

            //------------------------------------------------------------------
            //  Cache the follower count for future checks.
            //------------------------------------------------------------------
            this.previousFollowerCount = this.FollowerCache.FollowersCount;
        }

        /// <summary>
        /// Sets the notes for the specified subscriber.
        /// </summary>
        /// <param name="subscriberName">The name of the subscriber to search for.</param>
        /// <param name="notes">User-defined information about this subscriber.</param>
        public void SetSubscriberNotes(string subscriberName, string notes)
        {
            foreach (Subscriber subscriber in this.SubscriberCache.Subscribers)
            {
                if (subscriber.Name.Equals(subscriberName))
                {
                    subscriber.Notes = notes;
                    break;
                }
            }
        }

        /// <summary>
        /// Cleans up all the engine resources.
        /// </summary>
        public void Dispose()
        {
            this.SoundPlayer.Stop();

            if (this.worker.IsBusy)
            {
                this.worker.CancelAsync();

                while (this.worker.IsBusy)
                {
                    this.View.DoEvents();
                }
            }
        }

        /// <summary>
        /// Gets whether or not the Twitch Monitor is authorized to get subscription information.
        /// </summary>
        /// <returns></returns>
        public bool ClientAuthorized()
        {
            return this.SelectedProfile != null && !string.IsNullOrEmpty(this.SelectedProfile.AuthenticationKey);
        }

        /// <summary>
        /// Gets the subscriber activity that needs to be processed.
        /// </summary>
        /// <returns>An enumerated list of subscriber activity that has not yet been processed.</returns>
        public IEnumerable<SubscriberActivity> GetSubscriberActivityToProcess()
        {
            return  from sub in this.SubscriberActivity.Values
                    where sub.Processed == false
                    select sub;
        }

        /// <summary>
        /// Gets the follower activity that needs to be processed.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FollowerActivity> GetFollowerActivityToProcess()
        {
            return from follower in this.FollowerActivity.Values
                   where follower.Processed == false
                   select follower;
        }

        /// <summary>
        /// Gets the total number of active subscribers.
        /// </summary>
        /// <returns></returns>
        public int GetTotalActiveSubscribers()
        {
            return (this.SubscriberCache == null ? 0 : this.SubscriberCache.Subscribers.Where(sub => sub.Active).Count());
        }

        /// <summary>
        /// Gets the number of new subscribers (including resubscribers).
        /// </summary>
        /// <returns></returns>
        public int GetNewSubscriberCount()
        {
            return this.SubscriberActivity.Values.Where(subActivity => subActivity.State == SubscriberActivityState.New || subActivity.State == SubscriberActivityState.Resubscribed).Count();
        }

        /// <summary>
        /// Gets the number of new followers.
        /// </summary>
        /// <returns></returns>
        public int GetNewFollowerCount()
        {
            return this.FollowerActivity.Values.Where(activity => activity.State == FollowerActivityState.New).Count();
        }

        /// <summary>
        /// Runs an ad break.
        /// </summary>
        public void RunAdBreak(bool async = false)
        {
            //------------------------------------------------------------------
            //  Check to see if the ad should be run asynchronously (if called
            //  from the UI thread).
            //------------------------------------------------------------------
            if (async)
            {
                this.adRunner.RunAdNow();
                return;
            }

            //------------------------------------------------------------------
            //  Only run ads if client is authorized and the account is
            //  partnered.
            //------------------------------------------------------------------
            if (!this.ClientAuthorized() || this.partneredStatus == PartneredStatus.NotPartnered || this.SelectedProfile == null)
            {
                return;
            }

            //this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.RunAdBreak } );

            string connectionUri = string.Format("https://api.twitch.tv/kraken/channels/{0}/commercial", this.SelectedProfile.ChannelName);

            string response;
            HttpStatusCode statusCode;
            string postData = string.Format("length={0}", this.Settings.Ads.Length);
            ThreadMessage threadMessage = new ThreadMessage();

            if (this.SendWebRequest(connectionUri, out response, out statusCode, true, postData, contentType: WebRequestContentType.None))
            {
                threadMessage.Status = ThreadMessageStatus.Informational;
                threadMessage.Message = string.Format("Successfully ran ad break. ({0} seconds)", this.Settings.Ads.Length);

            }
            else
            {
                threadMessage.Status = ThreadMessageStatus.Error;
                switch (statusCode)
                {
                    /*
                    case (HttpStatusCode)422:
                        this.partneredStatus = PartneredStatus.NotPartnered;
                        threadMessage.Message = "Unable to run ads. Channel is not partnered with Twitch.tv.";
                        break;
                    */

                    default:
                        threadMessage.Message = "Unable to run ad break. Error: " + statusCode.ToString();
                        break;
                }
            }
            this.worker.ReportProgress(0, threadMessage);
        }

        /// <summary>
        /// Sets the title of the stream to the specified text.
        /// </summary>
        /// <param name="text"></param>
        public void SetStreamTitleText(string title, string game)
        {
            if (!this.ClientAuthorized())
            {
                return;
            }

            this.WriteStatusLogMessage("Updating stream title to: \"" + title + "\", \"" + game + "\"...");

            string connectionUri = string.Format("https://api.twitch.tv/kraken/channels/{0}", this.SelectedProfile.ChannelName);

            string response;
            HttpStatusCode statusCode;

            StreamChannelUpdateJson statusUpdateJson = new StreamChannelUpdateJson();
            statusUpdateJson.channel.game = game;
            statusUpdateJson.channel.status = title;
            string data = Newtonsoft.Json.JsonConvert.SerializeObject(statusUpdateJson);

            if (this.SendWebRequest(connectionUri, out response, out statusCode, true, data, "PUT"))
            {
                this.WriteStatusLogMessage("[INFO] Successfully update stream title.");
            }
            else
            {
                this.WriteStatusLogMessage("[ERROR] Failed to update stream title. Error " + statusCode.ToString());
            }
        }

        /// <summary>
        /// Resets the partnered status to an unknown state.
        /// </summary>
        public void ResetPartneredStatus()
        {
            this.partneredStatus = PartneredStatus.Unknown;
        }

        /// <summary>
        /// Writes the specified message to the status log file.
        /// </summary>
        /// <param name="message">The message to be written to the log file.</param>
        public void WriteStatusLogMessage(string message)
        {
            try
            {
                //--------------------------------------------------------------
                //  Write the message to the logfile.
                //--------------------------------------------------------------
                using (FileStream stream = File.Open(this.StatusLogFile, FileMode.Append))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(Engine.ConvertToLogMessage(message));
                    stream.Write(info, 0, info.Length);
                }

                //--------------------------------------------------------------
                //  Display the message in the UI.
                //--------------------------------------------------------------
                if (this.View != null)
                {
                    this.View.DisplayStatusMessage(message);
                }
            }
            catch (Exception) { /* Do nothing if we encounter an error writing to the status log. */ }
        }

        /// <summary>
        /// Converts the specified message to a new message with a timestamp and newline character.
        /// </summary>
        /// <param name="message">The message to be converted.</param>
        /// <returns>A string representing the new message that is formatted for a log file.</returns>
        public static string ConvertToLogMessage(string message)
        {
            DateTime currentTime = DateTime.Now;
            return string.Format("[{0} {1}] {2}{3}", currentTime.ToShortDateString(), currentTime.ToString("T"), message, Environment.NewLine);
        }

        /// <summary>
        /// Opens the status log file in the default text editor.
        /// </summary>
        public void ViewStatusLog()
        {
            Process.Start(this.StatusLogFile);
        }

        /// <summary>
        /// Removes all unsubscribers from the subscriber cache.
        /// </summary>
        public void RemoveUnsubscribers()
        {
            this.SubscriberCache.Subscribers.RemoveAll(s => { return !s.Active; });
        }

        //======================================================================
        //  Private Methods
        //======================================================================
        /// <summary>
        /// Initializes the log file to indicate we are starting a new run of the Twitch Monitor.
        /// </summary>
        private void InitializeLogFile()
        {
            try
            {
                if (File.Exists(this.StatusLogFile))
                {
                    using (FileStream stream = File.Open(this.StatusLogFile, FileMode.Create))
                    {
                        StringBuilder message = new StringBuilder();
                        message.Append("-------------------------------------------------------").Append(Environment.NewLine);
                        message.Append("                Twitch Monitor Log").Append(Environment.NewLine);
                        message.Append("-------------------------------------------------------").Append(Environment.NewLine);
                        message.Append("Version: " + this.GetAppVersion()).Append(Environment.NewLine);

                        Byte[] info = new UTF8Encoding(true).GetBytes(message.ToString());
                        stream.Write(info, 0, info.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                this.WriteStatusLogMessage("[ERROR] Unable to create status logfile: " + ex.Message);
            }
        }

        /// <summary>
        /// Gets the total number of subscribers from the cache.
        /// </summary>
        /// <returns></returns>
        private int GetTotalSubscribersCount()
        {
            return this.SubscriberCache.Subscribers.Where(s => s.Active).Count();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.WriteStatusLogMessage("Finished monitoring.");
            this.View.FinishedMonitoring();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            bool performFirstCheck = true;

            //------------------------------------------------------------------
            //  Check for new subscribers
            //------------------------------------------------------------------
            while (!this.worker.CancellationPending)
            {
                if (performFirstCheck || timer.ElapsedMilliseconds >= this.Settings.PollWaitTime)
                {
                    performFirstCheck = false;
                    timer.Stop();

                    //----------------------------------------------------------
                    //  Check to see if we need to cancel.
                    //----------------------------------------------------------
                    if (this.worker.CancellationPending) { break; }

                    //----------------------------------------------------------
                    //  Go through and query for all the information.
                    //----------------------------------------------------------
                    try
                    {
                        this.GetViewerInfo();
                        this.GetProfileInfo();
                        this.GetSubscriberList();
                        this.GetRecentFollowers();
                        this.GetServerPings();
                    }
                    catch (Exception ex)
                    {
                        this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Error, Message = "Twitch Monitor encountered a problem when requesting current account information: " + ex.Message });
                    }

                    //----------------------------------------------------------
                    //  Update the follower count if it changed.
                    //----------------------------------------------------------
                    this.previousFollowerCount = this.FollowerCache.FollowersCount;
                    this.previousSubscribersCount = this.GetTotalSubscribersCount();

                    timer.Restart();
                }

                if (this.worker.CancellationPending)
                {
                    this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Informational, Message = "Cancellation requested. Stopping monitor..." });
                    timer.Stop();
                    break;
                }

                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Gets the list of ping times to all the Twitch servers.
        /// </summary>
        private void GetServerPings()
        {
            if (this.worker.CancellationPending) { return; }

            try
            {
                if (this.ServerPings.ServerListTable.Rows.Count > 0)
                {
                    this.ServerPings.RefreshPingTimes(this.worker);
                }
                else
                {
                    this.ServerPings.InitializeServerList(this.worker);
                }
                this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.UpdateServerPings });
            }
            catch (Exception ex)
            {
                this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Error, Message = "Unable to ping Twitch.tv servers: " + ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetSubscriberList()
        {
            if (this.worker.CancellationPending) { return; }

            //------------------------------------------------------------------
            //  Only continue if the client is authorized and user is partnered.
            //------------------------------------------------------------------
            if (!this.ClientAuthorized() || this.partneredStatus == PartneredStatus.NotPartnered || this.SelectedProfile == null)
            {
                return;
            }

            this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Debug, Message = "Getting subscriber list from Twitch.tv..." });

            this.responses.Clear();
            bool moreResponsesNeeded = true;
            string connectionUri = string.Format("https://api.twitch.tv/kraken/channels/{0}/subscriptions?limit=50", this.SelectedProfile.ChannelName);
            var subscribers = new List<UserJson>();
            long totalSubs = 0;

            this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Debug, Message = "Querying for subscribers..." });
            while (moreResponsesNeeded && !this.worker.CancellationPending)
            {
                string response;
                HttpStatusCode statusCode;
                moreResponsesNeeded = false;
                if (this.SendWebRequest(connectionUri, out response, out statusCode, true))
                {
                    SubscribersJsonPacket responseJson = null;
                    try
                    {
                        responseJson = Newtonsoft.Json.JsonConvert.DeserializeObject<SubscribersJsonPacket>(response);
                    }
                    catch (Exception ex)
                    {
                        this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Error, Message = "Unable to parse subscriber response: " + ex.Message });
                        Thread.Sleep(1000);
                        moreResponsesNeeded = true;
                        continue;
                    }

                    if (responseJson == null)
                    {
                        this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Error, Message = "Unable to parse subscriber response: No response received." });
                        Thread.Sleep(1000);
                        moreResponsesNeeded = true;
                    }

                    totalSubs = responseJson._total;

                    if (this.worker.CancellationPending) { return; }

                    foreach (SubscriberJson subscription in responseJson.subscriptions)
                    {
                        subscribers.Add(subscription.user);
                        moreResponsesNeeded = true;
                    }

                    if (moreResponsesNeeded)
                    {
                        connectionUri = responseJson._links.next;
                        Thread.Sleep(500);
                    }

                    this.partneredStatus = PartneredStatus.Partnered;
                }
                else
                {
                    switch (statusCode)
                    {
                        case (HttpStatusCode)422:
                        case (HttpStatusCode)401:
                            this.partneredStatus = PartneredStatus.NotPartnered;
                            this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Error, Message = "Unable to get subscription information. Channel is not partnered with Twitch.tv." });
                            return;

                        case (HttpStatusCode)502:
                            this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Error, Message = "Encountered 502 server error (" + statusCode.ToString() + ") when getting subscriber list. Retrying again in 1 second... " });
                            moreResponsesNeeded = true;
                            Thread.Sleep(1000);
                            continue;

                        case (HttpStatusCode)503:
                            this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Error, Message = "Encountered 503 server error (" + statusCode.ToString() + ") when getting subscriber list. Retrying again in 1 second... " });
                            moreResponsesNeeded = true;
                            Thread.Sleep(1000);
                            break;

                        default:
                            this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Error, Message = "Unable to get subscription information: " + statusCode.ToString() });
                            return;
                    }
                }
            }

            this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Debug, Message = "Finished getting the list of subscribers." });

            //------------------------------------------------------------------
            //  If we need to cancel, then break out of the loop.
            //------------------------------------------------------------------
            if (this.worker.CancellationPending) { return; }

            //------------------------------------------------------------------
            //  Compare the two and record how many new subscribers there are
            //------------------------------------------------------------------
            this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Debug, Message = "Checking returned list of subscribers for new subscribers..." });
            foreach (UserJson returnedSub in subscribers)
            {
                bool found = false;
                foreach (Subscriber cachedSub in this.SubscriberCache.Subscribers)
                {
                    if (cachedSub.Id == returnedSub._id)
                    {
                        //------------------------------------------------------
                        //  If the user was previously not subscribed, then it
                        //  means we need to flag them as a resubscriber.
                        //------------------------------------------------------
                        if (!cachedSub.Active)
                        {
                            this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Debug, Message = string.Format("User '{0}' [ID:{1}] has re-subscribed.", cachedSub.Name, cachedSub.Id) });
                            cachedSub.Active = true;
                            this.RegisterSubscriberActivity(cachedSub, SubscriberActivityState.Resubscribed);
                        }
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Debug, Message = "New subscriber: " + returnedSub.display_name });

                    Subscriber newSub = new Subscriber();
                    newSub.Name = returnedSub.display_name;
                    newSub.Id = returnedSub._id;
                    newSub.Active = true;
                    this.SubscriberCache.Subscribers.Add(newSub);
                    this.RegisterSubscriberActivity(newSub, SubscriberActivityState.New);
                }
            }

            //------------------------------------------------------------------
            //  If we need to cancel, then break out of the loop.
            //------------------------------------------------------------------
            if (this.worker.CancellationPending) { return; }

            //------------------------------------------------------------------
            //  Compare the cache with the returned list and mark which ones are
            //  active and which are unsubscribed.
            //------------------------------------------------------------------
            this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Debug, Message = "Checking cached list of subscribers for unsubs..." });
            foreach (Subscriber cachedSub in this.SubscriberCache.Subscribers)
            {
                if (cachedSub.Active && !this.IsNameInList(subscribers, cachedSub.Id))
                {
                    this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Debug, Message = string.Format("User '{0}' [ID:{1}] has unsubscribed.", cachedSub.Name, cachedSub.Id) });
                    cachedSub.Active = false;
                    this.RegisterSubscriberActivity(cachedSub, SubscriberActivityState.Unsubscribed);
                }
            }

            //------------------------------------------------------------------
            //  Update the subscribers output file.
            //------------------------------------------------------------------
            if (this.Settings.FileOutput.Subscribers.Enabled)
            {
                int count = this.Settings.FileOutput.Subscribers.ItemCount;
                int startIndex = this.recentSubscribernames.Count - count;

                if (startIndex < 0) { startIndex = 0; }
                if (count > this.recentSubscribernames.Count) { count = this.recentSubscribernames.Count; }

                string outputText = string.Join(", ", this.recentSubscribernames.ToArray(), startIndex, count);

                this.UpdateOutputFile(this.Settings.FileOutput.Subscribers.FilePath, outputText);
            }

            this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.UpdateSubscribers });
        }

        /// <summary>
        /// Gets whether or not the specified name is in the list.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="name"></param>
        private bool IsNameInList(List<UserJson> list, long id)
        {
            /*
            if (list != null)
            {
                return list.Where(i => i._id == id).Any();
            }
            return false;*/

            foreach (UserJson listName in list)
            {
                if (listName._id == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets the Twitch ID for the specified username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public long GetUserId(string username)
        {
            string connectionUri = string.Format("https://api.twitch.tv/kraken/users/{0}", username);
            string response;
            HttpStatusCode statusCode;
            if (this.SendWebRequest(connectionUri, out response, out statusCode))
            {
                try
                {
                    UserJson responseJson = Newtonsoft.Json.JsonConvert.DeserializeObject<UserJson>(response);
                    return responseJson._id;
                }
                catch (Exception ex)
                {
                    this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Error, Message = "Unable to parse out ID information for user " + username + ": " + ex.Message });
                }
            }
            else
            {
                ThreadMessage threadMessage = new ThreadMessage() { Status = ThreadMessageStatus.Error };
                switch (statusCode)
                {
                    case (HttpStatusCode)404:
                        threadMessage.Message = "User " + username + " no longer has a Twitch account.";
                        break;

                    case (HttpStatusCode)422:
                    default:
                        threadMessage.Message = "Unable to find ID information for user " + username + ".";
                        break;
                }
                this.worker.ReportProgress(0, threadMessage);
            }
            return 0;
        }

        /// <summary>
        /// Registers the specified subscriber with the specified state. Handles creating a new activity object if one is not
        /// already present in the dictionary.
        /// </summary>
        /// <param name="sub">The subscriber to register.</param>
        /// <param name="state">The state of the activity.</param>
        public void RegisterSubscriberActivity(Subscriber sub, SubscriberActivityState state)
        {
            if (state == SubscriberActivityState.New || state == SubscriberActivityState.Resubscribed)
            {
                this.recentSubscribernames.Add(sub.Name);
            }

            if (!this.SubscriberActivity.ContainsKey(sub.Name))
            {
                this.SubscriberActivity[sub.Name] = new SubscriberActivity();
            }
            this.SubscriberActivity[sub.Name].Subscriber = sub;
            this.SubscriberActivity[sub.Name].State = state;
        }

        /// <summary>
        /// Registers the specified follower with the specified state. Handles creating a new activity object if one is not
        /// already present in the dictionary.
        /// </summary>
        /// <param name="user">The user to register.</param>
        /// <param name="state">The state of the activity.</param>
        public void RegisterFollowerActivity(UserJson user, FollowerActivityState state)
        {
            string name = user.display_name;

            if (state == FollowerActivityState.New)
            {
                this.recentFollowerNames.Add(name);
            }

            if (!this.FollowerActivity.ContainsKey(name))
            {
                this.FollowerActivity[name] = new FollowerActivity();
            }
            this.FollowerActivity[name].User = user;
            this.FollowerActivity[name].State = state;
        }

        /// <summary>
        /// Sends a web request to the specified URL.
        /// </summary>
        /// <param name="url">The target URL to send the HTTP web request.</param>
        /// <param name="response">The body of the HTTP response.</param>
        /// <param name="statusCode">The status code of the HTTP response.</param>
        /// <param name="requiresAuthentication">(optional) Set to true if the request requires authentication; false otherwise.</param>
        /// <param name="postData">(optional) The data to post with the request.</param>
        /// <param name="requestVerb">(optional) The type of request to make.</param>
        /// <returns>True if the request was successfully sent; false otherwise.</returns>
        private bool SendWebRequest(string url, out string response, out HttpStatusCode statusCode, bool requiresAuthentication = false, string postData = "", string requestVerb = "", WebRequestContentType contentType = WebRequestContentType.JSON)
        {
            bool success = false;
            response = string.Empty;
            statusCode = HttpStatusCode.OK;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "application/vnd.twitchtv.v2+json";

            switch (contentType)
            {
                case WebRequestContentType.JSON:
                    request.ContentType = "application/json";
                    break;
            }

            //------------------------------------------------------------------
            //  If the requrest requires authentication, then set the OAuth
            //  token in the request header.
            //------------------------------------------------------------------
            if (requiresAuthentication)
            {
                request.Headers.Add(name: "Authorization", value: "OAuth " + this.SelectedProfile.AuthenticationKey);
            }

            //------------------------------------------------------------------
            //  Set the request verb if we've been told to do so.
            //------------------------------------------------------------------
            if (!string.IsNullOrEmpty(requestVerb))
            {
                request.Method = requestVerb;
            }
            else if (!string.IsNullOrEmpty(postData))
            {
                request.Method = "POST";
            }

            //------------------------------------------------------------------
            //  If we need to send data, then change the request type to POST
            //  and set the body of the request.
            //------------------------------------------------------------------
            if (!string.IsNullOrEmpty(postData))
            {
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] utfBytes = encoding.GetBytes(postData);

                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(utfBytes, 0, utfBytes.Length);
                }
            }

            //------------------------------------------------------------------
            //  Send the request!
            //------------------------------------------------------------------
            try
            {
                using (HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                {                    
                    response = reader.ReadToEnd();
                    statusCode = webResponse.StatusCode;
                    success = true;
                }
            }
            catch (WebException ex)
            {
                if(ex.Response == null)
                {
                    this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Error, Message = ex.Message });
                }
                else
                {
                    HttpWebResponse webResponse = ex.Response as HttpWebResponse;
                    statusCode = webResponse.StatusCode;
                }
            }
            catch (Exception ex)
            {
                this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Error, Message = ex.Message });
            }

            return success;
        }

        /// <summary>
        /// Gets the list of recent followers.
        /// </summary>
        private void GetRecentFollowers()
        {
            //------------------------------------------------------------------
            //  If we need to cancel, then break out of the loop.
            //------------------------------------------------------------------
            if (this.worker.CancellationPending || this.SelectedProfile == null) { return; }

            string connectionUri = string.Format("https://api.twitch.tv/kraken/channels/{0}/follows", this.SelectedProfile.ChannelName);
            string response;
            HttpStatusCode statusCode;
            if (this.SendWebRequest(connectionUri, out response, out statusCode))
            {
                FollowersJsonPacket responseJson = null;
                try
                {
                    responseJson = Newtonsoft.Json.JsonConvert.DeserializeObject<FollowersJsonPacket>(response);
                }
                catch (Exception ex)
                {
                    this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Error, Message = "Unable to parse follower response: " + ex.Message });
                    return;
                }

                if (responseJson == null)
                {
                    this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Error, Message = "Unable to parse follower response: No response received." });
                    return;
                }

                //----------------------------------------------------------
                //  If we need to cancel, then break out of the loop.
                //----------------------------------------------------------
                if (this.worker.CancellationPending) { return; }

                this.FollowerCache.FollowersCount = Convert.ToInt64(responseJson._total);
                bool needToSaveFollowerCache = false;

                foreach (FollowsJson follow in responseJson.follows)
                {
                    Follower follower = new Follower();
                    follower.Name = follow.user.display_name;
                    follower.TimeFollowed = Convert.ToDateTime(follow.created_at);
                    this.RecentFollowers.Add(follower);

                    if (!this.FollowerCache.Ids.Contains(follow.user._id))
                    {
                        this.FollowerCache.Ids.Add(follow.user._id);
                        
                        //------------------------------------------------------
                        //  Register the new follower activity!
                        //------------------------------------------------------
                        this.RegisterFollowerActivity(follow.user, FollowerActivityState.New);
                    }

                    //----------------------------------------------------------
                    //  Check to see if we need to record new follower
                    //  information to the cache.
                    //----------------------------------------------------------
                    if (follower.TimeFollowed > this.FollowerCache.MostRecentFollowerDate)
                    {
                        this.FollowerCache.MostRecentFollowerDate = follower.TimeFollowed;
                        needToSaveFollowerCache = true;
                    }
                }

                //------------------------------------------------------------------
                //  Update the followers output file.
                //------------------------------------------------------------------
                if (this.Settings.FileOutput.Followers.Enabled)
                {
                    int count = this.Settings.FileOutput.Followers.ItemCount;
                    int startIndex = this.recentFollowerNames.Count - count;

                    if (startIndex < 0) { startIndex = 0; }
                    if (count > this.recentFollowerNames.Count) { count = this.recentFollowerNames.Count; }

                    string temp = string.Join(", ", this.recentFollowerNames.ToArray(), startIndex, count);

                    this.UpdateOutputFile(this.Settings.FileOutput.Followers.FilePath, string.Join(", ", this.recentFollowerNames.ToArray(), startIndex, count));
                }

                this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.UpdateFollowers });

                if (needToSaveFollowerCache)
                {
                    this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.SaveFollowersCache });
                }
            }
        }

        /// <summary>
        /// Gets the current viewer information.
        /// </summary>
        private void GetViewerInfo()
        {
            //------------------------------------------------------------------
            //  If we need to cancel, then break out of the loop.
            //------------------------------------------------------------------
            if (this.worker.CancellationPending || this.SelectedProfile == null) { return; }

            string connectionUri = string.Format("https://api.twitch.tv/kraken/streams/{0}", this.SelectedProfile.ChannelName);
            string response;
            HttpStatusCode statusCode;

            bool retryRequest;
            do
            {
                retryRequest = false;
                if (this.SendWebRequest(connectionUri, out response, out statusCode))
                {
                    //----------------------------------------------------------
                    //  If we need to cancel, then break out of the loop.
                    //----------------------------------------------------------
                    if (this.worker.CancellationPending) { return; }

                    StreamJsonPacket responseJson = null;
                    try
                    {
                        responseJson = Newtonsoft.Json.JsonConvert.DeserializeObject<StreamJsonPacket>(response);
                    }
                    catch (Exception ex)
                    {
                        this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Error, Message = "Unable to get viewer information: " + ex.Message });
                        Thread.Sleep(1000);
                        retryRequest = true;
                        continue;
                    }

                    if (responseJson == null)
                    {
                        this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Error, Message = "Unable to get viewer information: No response received." });
                        Thread.Sleep(1000);
                        retryRequest = true;
                        continue;
                    }

                    //----------------------------------------------------------
                    //  If we need to cancel, then break out of the loop.
                    //----------------------------------------------------------
                    if (this.worker.CancellationPending) { return; }

                    if (responseJson.stream == null)
                    {
                        this.IsStreamOnline = false;
                        this.ViewerCount = 0;
                    }
                    else
                    {
                        this.IsStreamOnline = true;
                        this.ViewerCount = responseJson.stream.viewers;
                    }

                    //----------------------------------------------------------
                    //  Check to see if we need to write the viewer count
                    //  out to a file.
                    //----------------------------------------------------------
                    if (this.Settings.FileOutput.ViewerCount.Enabled)
                    {
                        this.UpdateOutputFile(this.Settings.FileOutput.ViewerCount.FilePath, this.ViewerCount.ToString());
                    }

                    this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.UpdateViewers });
                }
                else
                {
                    switch (statusCode)
                    {
                        case (HttpStatusCode)503:
                            retryRequest = true;
                            this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Error, Message = "Encountered 503 server error (" + statusCode.ToString() + ") when getting viewer info. Retrying again in 1 second... " });
                            Thread.Sleep(1000);
                            break;
                    }
                }
            } while (retryRequest);
        }

        /// <summary>
        /// Gets the JSON packet for the specified channel that gives information about that channel.
        /// </summary>
        /// <param name="channelName">The name of the channel to look up.</param>
        /// <returns>A JSON packet containing information about that channel; NULL if the channel was not found.</returns>
        public ProfileJsonPacket GetProfileJsonInfo(string channelName)
        {
            ProfileJsonPacket responseJson = null;
            string connectionUri = string.Format("https://api.twitch.tv/kraken/channels/{0}", channelName);
            string response;
            HttpStatusCode statusCode;
            if (this.SendWebRequest(connectionUri, out response, out statusCode))
            {
                responseJson = Newtonsoft.Json.JsonConvert.DeserializeObject<ProfileJsonPacket>(response);
            }
            return responseJson;
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetProfileInfo()
        {
            //------------------------------------------------------------------
            //  If we need to cancel, then break out of the loop.
            //------------------------------------------------------------------
            if (this.worker.CancellationPending || this.SelectedProfile == null) { return; }

            ProfileJsonPacket responseJson = null;
            try
            {
                responseJson = this.GetProfileJsonInfo(this.SelectedProfile.ChannelName);
            }
            catch (Exception ex)
            {
                this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Error, Message = "Unable to get profile information for user " + this.SelectedProfile.ChannelName + ": " + ex.Message });
                return;
            }

            //----------------------------------------------------------
            //  Check to see if the channel name was not found.
            //----------------------------------------------------------
            if (responseJson == null)
            {
                this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Error, Message = "Unable to get profile information for user " + this.SelectedProfile.ChannelName + ": No response received." });
                return;
            }

            //----------------------------------------------------------
            //  If we need to cancel, then break out of the loop.
            //----------------------------------------------------------
            if (this.worker.CancellationPending) { return; }

            //----------------------------------------------------------
            //  Get the user icon if it has changed.
            //----------------------------------------------------------
            bool changesDetected = false;
            if (string.Compare(this.previousProfileLogoUri, responseJson.logo) != 0 || !File.Exists(this.SelectedProfile.Icon))
            {
                this.previousProfileLogoUri = responseJson.logo;
                if (string.IsNullOrEmpty(this.previousProfileLogoUri))
                {
                    this.SelectedProfile.Icon = string.Empty;
                }
                else
                {
                    Uri uri = new Uri(this.previousProfileLogoUri);
                    this.SelectedProfile.Icon = Path.Combine(this.GetCurrentProfileDir(), uri.Segments[uri.Segments.Length - 1]);
                    WebClient client = new WebClient();
                    client.DownloadFile(uri.AbsoluteUri, this.SelectedProfile.Icon);
                }

                changesDetected = true;
                this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.UpdateIcon });
            }

            if (this.SelectedProfile != null)
            {
                if (this.SelectedProfile.StreamTitle != responseJson.status)
                {
                    changesDetected = true;
                    this.SelectedProfile.StreamTitle = responseJson.status;
                }

                if (this.SelectedProfile.CurrentGame != responseJson.game)
                {
                    changesDetected = true;
                    this.SelectedProfile.CurrentGame = responseJson.game;
                }
            }

            if (changesDetected)
            {
                this.worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.UpdateProfile });
            }
        }

        public string GetCurrentProfileDir()
        {
            return this.GetUserProfileDir(this.currentProfile);
        }

        public string GetUserProfileDir(string channelName)
        {
            return Path.Combine(Engine.CacheDirectory, channelName);
        }

        /// <summary>
        /// Event handler for the worker when reporting progress. This means the worker is ready to update the list of subscribers if
        /// no error was detected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (this.View == null) { return; }

            ThreadMessage threadMessage = e.UserState as ThreadMessage;

            switch (threadMessage.Status)
            {
                case ThreadMessageStatus.Debug:
                    this.WriteStatusLogMessage(threadMessage.Message);
                    break;

                case ThreadMessageStatus.RunAdBreak:
                    this.View.ShowAdBreakMessage();
                    this.WriteStatusLogMessage("[INFO]" + threadMessage.Message);
                    break;

                case ThreadMessageStatus.Informational:
                    this.WriteStatusLogMessage("[INFO] " + threadMessage.Message);
                    break;

                case ThreadMessageStatus.Error:
                    this.WriteStatusLogMessage("[ERROR] " + threadMessage.Message);
                    break;

                case ThreadMessageStatus.UpdateIcon:
                    this.View.UpdateUserIcon();
                    break;

                case ThreadMessageStatus.UpdateServerPings:
                    this.View.UpdateServerPings();
                    
                    break;

                case ThreadMessageStatus.UpdateProfile:
                    this.View.UpdateProfileInfo();
                    this.SaveCurrentUserProfileSettings();
                    break;

                case ThreadMessageStatus.UpdateFollowers:
                    this.View.UpdateFollowersList();
                    break;

                case ThreadMessageStatus.SaveFollowersCache:
                    this.SaveFollowerCache();
                    break;

                case ThreadMessageStatus.UpdateSubscribers:
                    this.View.UpdateSubscriberLists();
                    this.SaveSubscriberList();
                    break;

                case ThreadMessageStatus.UpdateViewers:
                    this.View.UpdateViewerCount();
                    break;
            }
        }

        /// <summary>
        /// Performs any upgrade tasks to help make it easier when upgrading.
        /// </summary>
        private void PerformPreLoadUpgradeTasks()
        {
            //------------------------------------------------------------------
            //  Check to see if AppData folder is empty and ProgramData folder
            //  has files.
            //------------------------------------------------------------------
            if (!Directory.Exists(Engine.CacheDirectory))
            {
                Directory.CreateDirectory(Engine.CacheDirectory);

                string programDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "TwitchMonitor");
                if (Directory.Exists(programDataFolder))
                {
                    foreach (string file in Directory.EnumerateFiles(programDataFolder, "*.xml"))
                    {
                        FileInfo info = new FileInfo(file);
                        string newFile = Path.Combine(Engine.CacheDirectory, info.Name);
                        File.Copy(file, newFile);
                    }
                }
            }

            //------------------------------------------------------------------
            //  Check to see if AppData folder has a subscribers.xml & followers.xml
            //  file each.  If so, we need to copy them to a sub-folder for
            //  the current channel.
            //------------------------------------------------------------------
            this.LoadSettings();
            if (!string.IsNullOrEmpty(this.Settings.DefaultProfile))
            {
                string profileDir = Path.Combine(Engine.CacheDirectory, this.Settings.DefaultProfile);
                if (!Directory.Exists(profileDir))
                {
                    Directory.CreateDirectory(profileDir);
                    string subscriberFile = Path.Combine(Engine.CacheDirectory, Engine.SubscriberCacheFileName);
                    string followerFile = Path.Combine(Engine.CacheDirectory, Engine.FollowerCacheFileName);

                    this.fileBackup.BackupFile(subscriberFile, 1);
                    this.fileBackup.BackupFile(followerFile, 1);

                    //----------------------------------------------------------
                    //  Move the subscribers.xml file if it's there.
                    //----------------------------------------------------------
                    if (File.Exists(subscriberFile))
                    {
                        string newFile = Path.Combine(profileDir, Engine.SubscriberCacheFileName);
                        File.Move(subscriberFile, newFile);
                        this.LoadSubscriberList();
                    }

                    //----------------------------------------------------------
                    //  Move the followers.xml file if it's there. Otherwise,
                    //  create a new one and copy the follower count over.
                    //----------------------------------------------------------
                    if (File.Exists(followerFile))
                    {
                        File.Move(followerFile, Path.Combine(profileDir, Engine.FollowerCacheFileName));
                    }
                    else
                    {
                        this.LoadFollowerCache();
                        if (this.SubscriberCache != null)
                        {
                            this.FollowerCache.FollowersCount = this.SubscriberCache.FollowersCount;
                        }
                    }
                }
            }

            //------------------------------------------------------------------
            //  If we have legacy profiles then we need to upgrade the profiles
            //  to the new channel profiles format.
            //------------------------------------------------------------------
            if (this.Settings.Profiles.Count > 0)
            {
                this.Settings.ChannelProfiles.Clear();
                foreach (UserProfile legacyProfile in this.Settings.Profiles)
                {
                    UserProfile copy = UserProfile.MakeCopy(legacyProfile);
                    if (this.SelectedProfile == null || legacyProfile.Equals(this.SelectedProfile))
                    {
                        this.SelectedProfile = copy;
                    }
                    this.UserProfiles.Add(copy);
                    ChannelProfile channelProfile = new ChannelProfile();
                    channelProfile.Path = legacyProfile.ChannelName;
                    this.Settings.ChannelProfiles.Add(channelProfile);
                    string channelProfileDir = Path.Combine(Engine.CacheDirectory, channelProfile.Path);
                    this.WriteXmlFile(legacyProfile, typeof(UserProfile), Path.Combine(channelProfileDir, Engine.UserProfileFileName));
                }
                this.Settings.Profiles.Clear();
                this.SaveSettings();
            }
        }

        /// <summary>
        /// Backs up the files for each profile.
        /// </summary>
        private void BackupFiles()
        {
            foreach (UserProfile userProfile in this.UserProfiles)
            {
                string profileDir = this.GetUserProfileDir(userProfile.ChannelName);
                this.fileBackup.BackupFile(Path.Combine(profileDir, Engine.SubscriberCacheFileName), Engine.BackupFileCount, userProfile.ChannelName);
                this.fileBackup.BackupFile(Path.Combine(profileDir, Engine.FollowerCacheFileName), Engine.BackupFileCount, userProfile.ChannelName);
            }
        }

        /// <summary>
        /// Loads the profile settings for the currently-selected profile.
        /// </summary>
        public void LoadProfileSettings()
        {
            this.partneredStatus = PartneredStatus.Unknown;
            this.ViewerCount = 0;
            this.SelectedProfile = this.GetUserProfile(this.currentProfile);
            string profileDir = this.GetCurrentProfileDir();
            this.subscriberListCacheFile = Path.Combine(profileDir, Engine.SubscriberCacheFileName);
            this.followerCacheFile = Path.Combine(profileDir, Engine.FollowerCacheFileName);
            this.LoadSubscriberList();
            this.LoadFollowerCache();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool PerformPostLoadUpgradeTasks()
        {
            //------------------------------------------------------------------
            //  Make sure we have a subscriber cache to look for.
            //------------------------------------------------------------------
            if (this.SubscriberCache == null)
            {
                return true;
            }

            bool saveSubscriberList = false;
            bool showWaitingDialog = false;

            //------------------------------------------------------------------
            //  Remove duplicate subscribers from the cache. Only remove
            //  duplicates that aren't subbed to avoid triggering a resub
            //  notification.
            //------------------------------------------------------------------
            List<Subscriber> subsToRemove = new List<Subscriber>();
            List<Subscriber> processedSub = new List<Subscriber>();

            foreach (Subscriber sub in this.SubscriberCache.Subscribers)
            {
                //--------------------------------------------------------------
                //  If we haven't processed this sub yet, then do so now.
                //--------------------------------------------------------------
                if (!processedSub.Contains(sub))
                {
                    List<Subscriber> localDuplicates = new List<Subscriber>();
                    localDuplicates.Add(sub);
                    processedSub.Add(sub);

                    //----------------------------------------------------------
                    //  Get ths list of duplicates.
                    //----------------------------------------------------------
                    foreach (Subscriber otherSub in this.SubscriberCache.Subscribers)
                    {
                        if (!ReferenceEquals(sub, otherSub) && sub.Name.ToLower().Equals(otherSub.Name.ToLower()))
                        {
                            localDuplicates.Add(otherSub);
                            processedSub.Add(otherSub);
                        }
                    }

                    //----------------------------------------------------------
                    //  Out of the list of duplicates, keep the best one.
                    //----------------------------------------------------------
                    while (localDuplicates.Count > 1)
                    {
                        if (localDuplicates[0].Active)
                        {
                            subsToRemove.Add(localDuplicates[1]);
                            localDuplicates.Remove(localDuplicates[1]);
                        }
                        else
                        {
                            subsToRemove.Add(localDuplicates[0]);
                            localDuplicates.Remove(localDuplicates[0]);
                        }
                    }
                }
            }

            if (this.RemoveSubscribers(subsToRemove))
            {
                subsToRemove.Clear();
            }

            //------------------------------------------------------------------
            //  If the version is 1.0, then update all the subs with their
            //  ID values.
            //------------------------------------------------------------------
            if (string.IsNullOrEmpty(this.SubscriberCache.Version))
            {
                saveSubscriberList = false;
                showWaitingDialog = true;
            }

            //------------------------------------------------------------------
            //  Save the subscriber list if we made any changes or updates.
            //------------------------------------------------------------------
            if (saveSubscriberList)
            {
                this.SaveSubscriberList();
            }

            //------------------------------------------------------------------
            //  Update the settings file if necessary.
            //------------------------------------------------------------------
            bool needToSave = false;
            if (string.IsNullOrEmpty(this.Settings.Version))
            {
                UserProfile profile = this.CreateNewUserProfile(this.Settings.ChannelName, true);
                profile.ClientId = this.Settings.ClientId;
                profile.AuthenticationKey = this.Settings.AuthenticationKey;
                profile.PollWaitTime = this.Settings.PollWaitTime;

                needToSave = true;
            }
            else
            {
                if (this.Settings.SubscriberSounds == null)
                {
                    this.Settings.SubscriberSounds = new SoundPlaySettings();
                    this.Settings.SubscriberSounds.PlaySoundType = this.Settings.PlaySoundType;
                    this.Settings.SubscriberSounds.SoundDirectory = this.Settings.SoundDirectory;
                    this.Settings.SubscriberSounds.SoundFile = this.Settings.SoundFile;
                    this.Settings.SubscriberSounds.SoundVolume = this.Settings.SoundVolume;

                    needToSave = true;
                }

                if (this.Settings.FollowerSounds == null)
                {
                    this.Settings.FollowerSounds = new SoundPlaySettings();

                    needToSave = true;
                }
            }

            if (needToSave)
            {
                this.SaveSettings();
            }

            return showWaitingDialog;
        }

        /// <summary>
        /// Loads the Missile Launcher API if the settings are set to use it.
        /// </summary>
        public void LoadMissileLauncherApi()
        {
            if (this.Settings != null && this.Settings.MissileLauncherSpecified)
            {
                try
                {
                    this.MissileLauncherApi.Initialize(this.Settings.MissileLauncher.DreamCheekyUsbLibPath);
                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public void FireMissileForSubscriber(SubscriberActivityState state)
        {
            //------------------------------------------------------------------
            //  Return immediately if there's no Missile Launcher API settings
            //  loaded.
            //------------------------------------------------------------------
            if (this.Settings.MissileLauncher == null)
            {
                return;
            }

            //------------------------------------------------------------------
            //  Fire the missile!
            //------------------------------------------------------------------
            bool fireMissile = false;
            switch (state)
            {
                case SubscriberActivityState.New:
                    fireMissile = this.Settings.MissileLauncher.FireOnNewSubscriber;
                    break;

                case SubscriberActivityState.Resubscribed:
                    fireMissile = this.Settings.MissileLauncher.FireOnReSubscriber;
                    break;
            }

            if (fireMissile)
            {
                this.MissileLauncherApi.ScheduleMissileFire();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public void FireMissileForFollower(FollowerActivityState state)
        {
            //------------------------------------------------------------------
            //  Return immediately if there's no Missile Launcher API settings
            //  loaded.
            //------------------------------------------------------------------
            if (this.Settings.MissileLauncher == null)
            {
                return;
            }

            //------------------------------------------------------------------
            //  Fire the missile!
            //------------------------------------------------------------------
            bool fireMissile = false;
            switch (state)
            {
                case FollowerActivityState.New:
                    fireMissile = this.Settings.MissileLauncher.FireOnNewFollower;
                    break;
            }

            if (fireMissile)
            {
                this.MissileLauncherApi.ScheduleMissileFire();
            }
        }

        /// <summary>
        /// Test fires a missile now using the specified USB library path.  DUCK!!
        /// </summary>
        public void TestFireMissile(string usbLibPath)
        {
            MissileLauncherApi api = new MissileLauncherApi(this);
            if (api.Initialize(usbLibPath))
            {
                api.Start();
                api.ScheduleMissileFire();
                Thread.Sleep(100);
                api.Stop();
            }
        }

        /// <summary>
        /// Sets the current user profile to the specified channel name.
        /// </summary>
        /// <param name="channelName"></param>
        public void SetCurrentUserProfile(string channelName)
        {
            if (!string.IsNullOrEmpty(channelName))
            {
                this.currentProfile = channelName;
                this.LoadProfileSettings();
            }
        }

        /// <summary>
        /// Creates a new user profilfe.
        /// </summary>
        /// <param name="channelName"></param>
        /// <param name="setDefault"></param>
        public UserProfile CreateNewUserProfile(string channelName, bool setDefault)
        {
            //------------------------------------------------------------------
            //  If the profile already exists for this channel, just return it.
            //------------------------------------------------------------------
            foreach (UserProfile userProfile in this.UserProfiles)
            {
                if (userProfile.ChannelName.ToLower().Equals(channelName.ToLower()))
                {
                    return userProfile;
                }
            }

            //------------------------------------------------------------------
            //  Otherwise create a new profile and return it.
            //------------------------------------------------------------------
            UserProfile profile = new UserProfile();
            profile.ChannelName = channelName;
            this.UserProfiles.Add(profile);
            if (setDefault)
            {
                this.Settings.DefaultProfile = profile.ChannelName;
                this.SelectedProfile = profile;
            }
            return profile;
        }

        /// <summary>
        /// Gets the profile for the specified user.
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns></returns>
        public UserProfile GetUserProfile(string channelName)
        {
            string channelProfileDir = Path.Combine(Engine.CacheDirectory, channelName);
            if (Directory.Exists(channelProfileDir))
            {
                foreach (UserProfile profile in this.UserProfiles)
                {
                    if (profile.ChannelName.ToLower().Equals(channelName.ToLower()))
                    {
                        return profile;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Removes the specified subscribers from the subscriber cache.
        /// </summary>
        /// <param name="subsToRemove"></param>
        public bool RemoveSubscribers(List<Subscriber> subsToRemove)
        {
            if (subsToRemove.Count > 0)
            {
                foreach (Subscriber subToRemove in subsToRemove)
                {
                    this.SubscriberCache.Subscribers.Remove(subToRemove);
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Outputs the specified text to a file.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="text"></param>
        public void UpdateOutputFile(string file, string text)
        {
            if (!string.IsNullOrEmpty(file))
            {
                try
                {
                    File.WriteAllText(file, text);
                }
                catch (Exception) { }
            }
        }
    }
}
