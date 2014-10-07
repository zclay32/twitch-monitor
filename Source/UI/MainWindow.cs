using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using System.Xml;
using System.Diagnostics;
using TwitchMonitor.Core;
using TwitchMonitor.Core.Interfaces;
using TwitchMonitor.Core.Types;
using System.Reflection;
using TwitchMonitor.UI;
using TwitchMonitor.Controls;
using TwitchMonitor.Properties;

namespace TwitchMonitor
{
    public partial class MainWindow : Form, IView
    {
        //======================================================================
        //  Private Members
        //======================================================================
        private DataTable subscriberTable;
        private DataTable followersTable;
        private BindingSource subscribersBindingSource;
        private BindingSource followersBindingSource;
        private static readonly string columnId = "Id";
        private static readonly string columnName = "Name";
        private static readonly string columnStatus = "Status";
        private static readonly string columnNotes = "Notes";
        private static readonly string columnDateFollowed = "Date Followed";
        private MiniWindow miniWindow;
        private WaitingDialog waitingDialog;
        private Color defaultBackColor;
        private Dictionary<ToolStripMenuItem, UserProfile> menuItems;
        private string previousAdTimeRemaining;
        private NewSubscriberDialog notificationDialog;
        private IrcDialog ircDialog;
        private KeyCommanderDialog keyCommanderDialog;

        public Updater Updater { get; private set; }
        public Engine Engine { get; private set; }

        //======================================================================
        //  Constructors
        //======================================================================
        /// <summary>
        /// Default constructor that initializes the UI. This should only be used during design time and should not be
        /// used at runtime. Use the constructor that takes an engine object instead.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Main constructor for creating the MainWindow. This constructor should be called by the program so the view
        /// gets properly setup with the engine.
        /// </summary>
        /// <param name="engine"></param>
        public MainWindow(Engine engine) : this()
        {
            Program.UiThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;

            this.Engine = engine;
            this.Engine.View = this;
            this.menuItems = new Dictionary<ToolStripMenuItem, UserProfile>();

            this.miniWindow = new MiniWindow(this);
            this.waitingDialog = new WaitingDialog(this);
            this.Updater = new Updater(this);
            this.notificationDialog = new NewSubscriberDialog();

            this.subscribersBindingSource = new BindingSource();
            this.subscriberTable = new DataTable();
            this.subscribersBindingSource.DataSource = this.subscriberTable.DefaultView;
            this.subscriberTable.Columns.Add(columnId, typeof(int));
            this.subscriberTable.Columns.Add(columnName);
            this.subscriberTable.Columns.Add(columnStatus);
            this.subscriberTable.Columns.Add(columnNotes);

            this.uiSubscriberDataGridView.DataSource = this.subscribersBindingSource;

            this.followersBindingSource = new BindingSource();
            this.followersTable = new DataTable();
            this.followersBindingSource.DataSource = this.followersTable.DefaultView;
            this.followersTable.Columns.Add(columnId, typeof(int));
            this.followersTable.Columns.Add(columnName);
            this.followersTable.Columns.Add(columnDateFollowed, typeof(DateTime));

            this.uiIrcControl.Initialize(this.Engine);
            this.uiServerListControl.Initialize(this.Engine);
            this.uiTimerUserControl1.Initialize(this.Engine);

            this.RefreshCurrentProfile();
            this.UpdateProfileMenu(true);

            //------------------------------------------------------------------
            // Set the version number.
            //------------------------------------------------------------------
            this.uiVersionLabel.Text = string.Format("Version {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            this.uiUpdateAvailableLabel.Text = "";

            //------------------------------------------------------------------
            //  Check for newer version and notify the user if one is available.
            //------------------------------------------------------------------
            this.Updater.StartCheckForUpdate(true);

            this.Load += new EventHandler(MainWindow_Load);

            this.defaultBackColor = this.BackColor;

            this.ShowNotificationsDialog(true);

            //------------------------------------------------------------------
            //  Disabled Menu Options
            //------------------------------------------------------------------
            this.keyCommanderToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Refreshes the currently-loaded profile.
        /// </summary>
        private void RefreshCurrentProfile()
        {
            
            this.followersTable.Clear();
            this.uiStatusLabel.Text = string.Empty;

            this.VerifySettings();
            this.ToggleControls(false);
            this.ClearSubscriberActivity();

            this.RefreshSubscriberTable();
            
            this.UpdateStatusLabelString();
            this.UpdateViewerCount();
            this.UpdateUserIcon();
            this.UpdateFollowers();
            
            this.ShowNoAds();
        }

        /// <summary>
        /// Refreshes the data table of subscribers.
        /// </summary>
        private void RefreshSubscriberTable()
        {
            this.subscriberTable.Clear();
            this.InitializeSubscriberTable();
            this.UpdateTotalSubscriberCountLabel(this.Engine.GetTotalActiveSubscribers(), this.Engine.GetNewSubscriberCount());
        }

        /// <summary>
        /// Event handler for when the UI is first loaded. This is where we should initialize
        /// the width of the columns.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (this.Engine.Settings.WindowSize.Width >= this.MinimumSize.Width)
            {
                this.Width = this.Engine.Settings.WindowSize.Width;
            }
            if (this.Engine.Settings.WindowSize.Height >= this.MinimumSize.Height)
            {
                this.Height = this.Engine.Settings.WindowSize.Height;
            }

            int x = this.Engine.Settings.WindowSize.X;
            int y = this.Engine.Settings.WindowSize.Y;
            if (x < 0 || x >= SystemInformation.VirtualScreen.Width)
            {
                x = this.Engine.Settings.WindowSize.X = 0;
            }
            if (y < 0 || y >= SystemInformation.VirtualScreen.Height)
            {
                y = this.Engine.Settings.WindowSize.Y = 0;
            }

            this.Location = new Point(x, y);

            //------------------------------------------------------------------
            //  Set the width of the Subscribers columns.
            //------------------------------------------------------------------
            try
            {
                /*
                if (this.uiSubscriberDataGridView.Columns.Count > 0)
                {
                    this.uiSubscriberDataGridView.Columns[columnId].Width = 50;
                    this.uiSubscriberDataGridView.Columns[columnName].Width = 200;
                    this.uiSubscriberDataGridView.Columns[columnStatus].Width = 125;
                }*/
            }
            catch (Exception) { /* Ignore any exception thrown here. */ }
        }

        //======================================================================
        //  Public Methods
        //======================================================================
        public void ShowUpdateAvailableMessage()
        {
            this.uiUpdateAvailableLabel.Text = "New version is available! Go to Help > Check for Updates... to get it!";
        }

        /// <summary>
        /// 
        /// </summary>
        public void ToggleMonitoring()
        {
            if (this.Engine.IsBusy)
            {
                this.uiRunButton.Text = "Stopping...";
                this.uiRunButton.BackColor = Color.Transparent;
                this.uiRunButton.Enabled = false;
                this.miniWindow.RunButtonEnabled = false;
                this.Engine.StopMonitoring();
                this.Text = "Twitch Monitor";
            }
            else if (this.Engine.SelectedProfile == null || string.IsNullOrEmpty(this.Engine.SelectedProfile.ChannelName))
            {
                //--------------------------------------------------------------
                //  The monitor isn't setup yet, so let the user know.
                //--------------------------------------------------------------
                MessageBox.Show("Twitch Monitor must be configured with a Twitch.tv channel name. Select the menu option File > Settings... to set your channel name.", "Twitch Monitor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.ToggleControls(true);
                this.Engine.StartMonitoring();
                this.Text = string.Format("Twitch Monitor ({0})", this.Engine.SelectedProfile.ChannelName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ShowMainWindow()
        {
            this.Show();
        }

        /// <summary>
        /// Tells the view the engine has finished monitoring.
        /// </summary>
        public void FinishedMonitoring()
        {
            this.uiRunButton.Enabled = true;
            this.miniWindow.RunButtonEnabled = true;
            this.ToggleControls(false);
        }

        /// <summary>
        /// Updates the displayed lists of subscribers.
        /// </summary>
        public void UpdateSubscriberLists()
        {
            this.UpdateTotalSubscribers();
        }

        /// <summary>
        /// Updates the list of followers.
        /// </summary>
        public void UpdateFollowersList()
        {
            this.UpdateFollowers();
        }

        /// <summary>
        /// Updates the profile information about the user.
        /// </summary>
        public void UpdateProfileInfo()
        {
            this.UpdateStatusLabelString();
        }

        /// <summary>
        /// Adds the specified message to the status log.
        /// </summary>
        /// <param name="message"></param>
        public void DisplayStatusMessage(string message)
        {
            this.uiStatusLogTextBox.Text += Engine.ConvertToLogMessage(message);

            //------------------------------------------------------------------
            //  Trim the lines so we're only showing a certain number at a time.
            //------------------------------------------------------------------
            int limit = 50;
            int count = this.uiStatusLogTextBox.Lines.Count();
            if (count > limit)
            {
                string[] temp = new string[limit];
                Array.Copy(this.uiStatusLogTextBox.Lines, count - limit, temp, 0, limit);
                this.uiStatusLogTextBox.Lines = temp;
            }

            //------------------------------------------------------------------
            //  Scroll to the bottom.
            //------------------------------------------------------------------
            this.uiStatusLogTextBox.SelectionStart = this.uiStatusLogTextBox.Text.Length;
            this.uiStatusLogTextBox.ScrollToCaret();
        }

        /// <summary>
        /// Updates the user icon image in the UI.
        /// </summary>
        public void UpdateUserIcon()
        {
            if (this.Engine.SelectedProfile == null)
            {
                this.uiUserIconPictureBox.Image = null;
            }
            else
            {
                if (!string.IsNullOrEmpty(this.Engine.SelectedProfile.Icon) && File.Exists(this.Engine.SelectedProfile.Icon))
                {
                    FileStream stream = new FileStream(this.Engine.SelectedProfile.Icon, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    this.uiUserIconPictureBox.Image = Image.FromStream(stream);
                    stream.Close();
                }
                else
                {
                    this.uiUserIconPictureBox.Image = Resources.no_user_image;
                }
            }
        }

        /// <summary>
        /// Pass-through to the ServerPings control to update the information it's displaying.
        /// </summary>
        /// <param name="table">The table containing the updated information to display.</param>
        public void UpdateServerPings()
        {
            this.uiServerListControl.UpdateDataSource();
        }

        /// <summary>
        /// In preparation for closing, we need to cleanup any disposable objects.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            this.Hide();
            this.uiIrcControl.Cleanup();
            this.uiTimerUserControl1.Cleanup();
            this.Engine.Dispose();
            base.OnClosed(e);
        }

        /// <summary>
        /// Forces the application to process events
        /// </summary>
        public void DoEvents()
        {
            Application.DoEvents();
        }

        /// <summary>
        /// Shows a custom message in the IRC chat concerning an ad break that is about to occur.
        /// </summary>
        public void ShowAdBreakMessage()
        {
            if (!this.Engine.Settings.Irc.CustomMessages.ShowAdBreakMessageBeforeAdBreak)
            {
                this.SendIrcMessage(IrcMessageType.RunningAd);
            }
        }

        /// <summary>
        /// Displays a message to the user letting them know the monitor is about to take an ad break.
        /// </summary>
        public void ShowAboutToTakeAdBreakMessage()
        {
            if (!Program.IsUiThread())
            {
                this.Invoke((Action)this.ShowAboutToTakeAdBreakMessage);
                return;
            }

            if (this.Engine.Settings.Irc.CustomMessages.ShowAdBreakMessageBeforeAdBreak)
            {
                this.SendIrcMessage(IrcMessageType.RunningAd);
            }
            this.BackColor = this.miniWindow.BackColor = Color.Red;
        }

        /// <summary>
        /// Hides the message that the monitor is about to take an ad break.
        /// </summary>
        public void HideAboutToTakeAdBreakMessage()
        {
            if (!Program.IsUiThread())
            {
                this.Invoke((Action)this.HideAboutToTakeAdBreakMessage);
                return;
            }

            this.BackColor = this.miniWindow.BackColor = this.defaultBackColor;
        }

        /// <summary>
        /// Shows a custom message to the suer.
        /// </summary>
        /// <param name="message"></param>
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Twitch Monitor", MessageBoxButtons.OK);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adTimeRemaining"></param>
        public void UpdateAdTimeRemaining(AdTimeRemaining adTimeRemaining)
        {
            if (!Program.IsUiThread())
            {
                this.Invoke((Action<AdTimeRemaining>)this.UpdateAdTimeRemaining, adTimeRemaining);
                return;
            }

            string timeRemaining = string.Format("{0:mm\\:ss}", adTimeRemaining.TimeRemaining);
            this.ToggleAdControls(true);
            this.uiNextAdProgressBar.Value = adTimeRemaining.Percent;

            if (string.IsNullOrEmpty(this.previousAdTimeRemaining) || !this.previousAdTimeRemaining.Equals(timeRemaining))
            {
                this.previousAdTimeRemaining = timeRemaining;
                this.uiNextAdLabel.Text = string.Format("Time to next ad: {0}", timeRemaining);

                //--------------------------------------------------------------
                //  Check to see if we need to write the ad time remaining out
                //  to a file.
                //--------------------------------------------------------------
                if (adTimeRemaining.TimeRemaining.Seconds <= this.Engine.Settings.Ads.WarningTimeDuration)
                {
                    this.Engine.UpdateOutputFile(this.Engine.Settings.FileOutput.AdWarningOutput.FilePath, adTimeRemaining.TimeRemaining.Seconds == 0 ? "" : adTimeRemaining.TimeRemaining.Seconds.ToString());
                }
            }

            this.miniWindow.SetAdTimeText(timeRemaining);
            this.miniWindow.SetAdTimeProgress(adTimeRemaining.Percent);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ShowNoAds()
        {
            if (!Program.IsUiThread())
            {
                this.Invoke((Action)this.ShowNoAds);
                return;
            }

            this.ToggleAdControls(false);

            this.uiNextAdLabel.Text = "";
            this.uiNextAdProgressBar.Value = 0;

            this.miniWindow.SetAdTimeText("");
            this.miniWindow.SetAdTimeProgress(0);
        }

        //======================================================================
        //  Private Methods
        //======================================================================
        /// <summary>
        /// Toggles the visibility of the ad controls.
        /// </summary>
        /// <param name="visible"></param>
        private void ToggleAdControls(bool visible)
        {
            this.uiNextAdLabel.Visible = visible;
            this.uiNextAdProgressBar.Visible = visible;
            this.uiRunAdButton.Visible = visible;
            this.miniWindow.ToggleAdControls(visible);
        }

        /// <summary>
        /// Only enable the Start button if all the necessary data is present. If not, disable the button and show the user the Settings tab.
        /// </summary>
        private void VerifySettings()
        {
            if (this.Engine.SelectedProfile == null || string.IsNullOrEmpty(this.Engine.SelectedProfile.ChannelName) || string.IsNullOrEmpty(this.Engine.SelectedProfile.AuthenticationKey))
            {
                this.uiTabControl.SelectTab(this.uiFollowersTabPage);
                this.uiSubscriberDataGridView.Enabled = false;
                this.uiTotalSubscribersLabel.Enabled = false;
                this.uiTotalSubscriberCountLabel.Enabled = false;
                this.uiTotalSubscriberCountLabel.Text = "0";
            }
            else
            {
                this.uiSubscriberDataGridView.Enabled = true;
                this.uiTabControl.SelectTab(this.uiSubscribersTabPage);
            }
        }

        /// <summary>
        /// Toggles the display of various controls based on whether or not the engine is currently monitoring.
        /// </summary>
        private void ToggleControls(bool running)
        {
            this.profilesToolStripMenuItem.Enabled = this.Engine.SelectedProfile != null && !running;
            this.uiRunButton.Text = running ? "Stop" : "Start";
            this.uiRunButton.BackColor = running ? Color.Red : Color.Transparent;
            this.uiRunButton.ForeColor = running ? Color.White : Color.Black;
            this.miniWindow.SetIsRunning(running);
        }

        /// <summary>
        /// Updates the status label string in the UI.
        /// </summary>
        private void UpdateStatusLabelString()
        {
            this.uiStatusLabel.Enabled = this.Engine.IsStreamOnline;
            this.uiStatusTitleLabel.Enabled = this.Engine.IsStreamOnline;

            if (this.Engine.SelectedProfile == null)
            {
                this.uiStatusLabel.Text = "";
                this.uiEditStreamTitleButton.Visible = false;
            }
            else
            {
                this.uiStatusLabel.Text = this.Engine.SelectedProfile.StreamTitle;
                this.uiEditStreamTitleButton.Visible = !string.IsNullOrEmpty(this.Engine.SelectedProfile.AuthenticationKey);
            }
        }

        /// <summary>
        /// Updates the list of followers in the UI.
        /// </summary>
        private void UpdateFollowers()
        {
            try
            {
                this.uiFollowersCountTitleLabel.Enabled = this.Engine.FollowerCache != null;
                this.uiTotalFollowersCountLabel.Enabled = this.Engine.FollowerCache != null;

                int newFollowerCount = 0;
                if (this.Engine.FollowerCache == null)
                {
                    this.uiTotalFollowersCountLabel.Text = "0";
                    this.miniWindow.SetFollowerCountText("0");
                }
                else
                {
                    this.uiTotalFollowersCountLabel.Text = string.Format("{0}", this.Engine.FollowerCache.FollowersCount);
                    newFollowerCount = this.Engine.GetNewFollowerCount();
                    if (newFollowerCount > 0)
                    {
                        this.uiTotalFollowersCountLabel.Text += string.Format(" ({0} New)", newFollowerCount);

                        //------------------------------------------------------
                        //  Process the new followers.
                        //------------------------------------------------------
                        List<string> newFollowers = new List<string>();
                        foreach (FollowerActivity follower in this.Engine.GetFollowerActivityToProcess())
                        {
                            switch (follower.State)
                            {
                                case FollowerActivityState.New:
                                    if (this.Engine.Settings.MiniCast.ShowNewFollowerMessages)
                                    {
                                        this.DisplayActivity(string.Format("NEW FOLLOWER: {0}", follower.User.display_name));
                                    }
                                    //this.AddSubscriberToTable(subActivity.Subscriber, this.subscriberTable.Rows.Count + 1);
                                    if (this.Engine.Settings.FollowerSounds.PlaySoundType != PlaySoundType.None)
                                    {
                                        this.Engine.WriteStatusLogMessage("Playing sound for new follower: " + follower.User.display_name);
                                    }
                                    //this.ShowNotificationsDialog(false);
                                    //this.notificationDialog.SubscriberName = subActivity.Subscriber.Name;
                                    //this.notificationDialog.Start();
                                    newFollowers.Add(follower.User.display_name);
                                    break;
                            }

                            this.Engine.FireMissileForFollower(follower.State);
                            //this.UpdateSubscriberStatusText(subActivity.Subscriber.Name, subActivity.State);
                            follower.Processed = true;
                            //subActivity.Processed = true;
                        }

                        if (newFollowers.Count > 0)
                        {
                            this.Engine.SoundPlayer.ScheduleSound(newFollowers.Count, this.Engine.Settings.FollowerSounds);
                            this.SendIrcMessage(IrcMessageType.NewFollower, string.Join(", ", newFollowers));
                        }
                    }

                    this.miniWindow.SetFollowerCountText(this.uiTotalFollowersCountLabel.Text);
                }

                this.followersTable.BeginLoadData();
                this.followersTable.Rows.Clear();
                int id = this.Engine.RecentFollowers.Count;
                foreach (Follower follower in this.Engine.RecentFollowers)
                {
                    DataRow row = this.followersTable.NewRow();
                    row[columnId] = id;
                    row[columnName] = follower.Name;
                    row[columnDateFollowed] = follower.TimeFollowed;

                    this.followersTable.Rows.Add(row);
                    id--;
                }
                this.followersTable.EndLoadData();

                this.uiFollowersDataGridView.DataSource = this.followersBindingSource;
                this.Engine.RecentFollowers.Clear();
            }
            catch (Exception ex)
            {
                this.Engine.WriteStatusLogMessage("Error updating the list of followers: " + ex.Message + Environment.NewLine + "Stack Trace: " + ex.StackTrace);
            }
        }

        /// <summary>
        /// Initializes the table of subscribers displayed to the user.
        /// </summary>
        private void InitializeSubscriberTable()
        {
            if (this.Engine.SubscriberCache == null)
            {
                return;
            }

            for (int i = this.Engine.SubscriberCache.Subscribers.Count - 1; i >= 0; i--)
            {
                Subscriber sub = this.Engine.SubscriberCache.Subscribers[i];
                this.AddSubscriberToTable(sub, i + 1);
            }
            this.uiSubscriberDataGridView.Sort(this.uiSubscriberDataGridView.Columns[0], ListSortDirection.Descending);

            this.UpdateTotalSubscriberCountLabel(this.Engine.GetTotalActiveSubscribers(), this.Engine.GetNewSubscriberCount());
        }

        /// <summary>
        /// Adds the specified subscriber to the table of subs for displaying to the user.
        /// </summary>
        /// <param name="sub"></param>
        private void AddSubscriberToTable(Subscriber sub, int id)
        {
            DataRow row = this.subscriberTable.NewRow();
            row[columnId] = id;
            row[columnName] = sub.Name;
            row[columnNotes] = sub.Notes;
            row[columnStatus] = sub.Active ? "Subscribed" : "Unsubscribed";

            this.subscriberTable.Rows.Add(row);
        }

        /// <summary>
        /// Updates the list of total subscribers.
        /// </summary>
        private void UpdateTotalSubscribers()
        {
            try
            {
                if (this.Engine.GetSubscriberActivityToProcess().Count() > 0)
                {
                    //------------------------------------------------------------------
                    //  Process any subscriber activity that has not yet been processed.
                    //------------------------------------------------------------------
                    //int newSubscriberSoundCount = 0;
                    //int reSubscriberSoundCount = 0;
                    List<string> newSubscribers = new List<string>();
                    List<string> reSubscribers = new List<string>();
                    foreach (SubscriberActivity subActivity in this.Engine.GetSubscriberActivityToProcess())
                    {
                        //------------------------------------------------------------------
                        //  Ignore subs we've already processed.
                        //------------------------------------------------------------------
                        switch (subActivity.State)
                        {
                            case SubscriberActivityState.New:
                                this.DisplayActivity(string.Format("NEW SUB: {0}", subActivity.Subscriber.Name));
                                this.AddSubscriberToTable(subActivity.Subscriber, this.subscriberTable.Rows.Count + 1);
                                if (this.Engine.Settings.SubscriberSounds.PlaySoundType != PlaySoundType.None)
                                {
                                    this.Engine.WriteStatusLogMessage("Playing sound for new subscriber: " + subActivity.Subscriber.Name);
                                }
                                this.ShowNotificationsDialog(false);
                                this.notificationDialog.SubscriberName = subActivity.Subscriber.Name;
                                this.notificationDialog.Start();
                                //this.SendIrcMessage(IrcMessageType.NewSubscriber, subActivity.Subscriber.Name);
                                //newSubscriberSoundCount++;
                                newSubscribers.Add(subActivity.Subscriber.Name);
                                break;

                            case SubscriberActivityState.Resubscribed:
                                this.DisplayActivity(string.Format("RE-SUBBED: {0}", subActivity.Subscriber.Name));
                                if (this.Engine.Settings.ReSubscriberSounds.PlaySoundType != PlaySoundType.None)
                                {
                                    this.Engine.WriteStatusLogMessage("Playing sound for re-subscriber: " + subActivity.Subscriber.Name);
                                }
                                //this.SendIrcMessage(IrcMessageType.ReSubscriber, subActivity.Subscriber.Name);
                                //newSubscriberSoundCount++;
                                //reSubscriberSoundCount++;
                                reSubscribers.Add(subActivity.Subscriber.Name);
                                break;

                            case SubscriberActivityState.Unsubscribed:
                                this.DisplayActivity(string.Format("Unsubbed: {0}", subActivity.Subscriber.Name), Color.DarkRed, false);
                                this.Engine.WriteStatusLogMessage("No sound being played for unsubscriber: " + subActivity.Subscriber.Name);
                                break;
                        }

                        this.Engine.FireMissileForSubscriber(subActivity.State);
                        this.UpdateSubscriberStatusText(subActivity.Subscriber.Name, subActivity.State);
                        subActivity.Processed = true;
                    }

                    this.UpdateTotalSubscriberCountLabel(this.Engine.GetTotalActiveSubscribers(), this.Engine.GetNewSubscriberCount());

                    if (newSubscribers.Any())
                    {
                        this.Engine.SoundPlayer.ScheduleSound(newSubscribers.Count, this.Engine.Settings.SubscriberSounds);
                        this.SendIrcMessage(IrcMessageType.NewSubscriber, string.Join(", ", newSubscribers));
                    }

                    if (reSubscribers.Any())
                    {
                        this.Engine.SoundPlayer.ScheduleSound(reSubscribers.Count, this.Engine.Settings.ReSubscriberSounds);
                        this.SendIrcMessage(IrcMessageType.ReSubscriber, string.Join(", ", reSubscribers));
                    }

                    this.Engine.SaveSubscriberList();

                    this.subscribersBindingSource.DataSource = this.subscriberTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                this.Engine.WriteStatusLogMessage("Error updating the subscriber list: " + ex.Message + Environment.NewLine + "Stack Trace: " + ex.StackTrace);
            }
        }

        /// <summary>
        /// Updates the status column in the DataTable for the specified subscriber.
        /// </summary>
        /// <param name="subName"></param>
        /// <param name="state"></param>
        private void UpdateSubscriberStatusText(string subName, SubscriberActivityState state)
        {
            foreach (DataRow row in this.subscriberTable.Rows)
            {
                if (row[columnName].Equals(subName))
                {
                    switch (state)
                    {
                        case SubscriberActivityState.New:
                            row[columnStatus] = "Subscribed (NEW)";
                            break;

                        case SubscriberActivityState.Resubscribed:
                            row[columnStatus] = "Resubscribed";
                            break;

                        case SubscriberActivityState.Unsubscribed:
                            row[columnStatus] = "Unsubscribed";
                            break;
                    }

                    break;
                }
            }
        }

        /// <summary>
        /// Updates the display labels showing the total number of subscribers and new subscribers.
        /// </summary>
        /// <param name="totalSubs"></param>
        /// <param name="newSubs"></param>
        private void UpdateTotalSubscriberCountLabel(int totalSubs, int newSubs)
        {
            if (totalSubs > 0)
            {
                this.uiTotalFollowersCountLabel.Enabled = true;
                this.uiTotalSubscribersLabel.Enabled = true;
                this.uiTotalSubscriberCountLabel.Enabled = true;
            }

            StringBuilder titleMessage = new StringBuilder();
            titleMessage.AppendFormat("{0}", totalSubs);

            if (newSubs > 0)
            {
                titleMessage.AppendFormat(" ({0} New)", newSubs);
            }

            this.uiTotalSubscriberCountLabel.Text = titleMessage.ToString();
            this.miniWindow.SetSubscriberCountText(titleMessage.ToString());
            this.diceRollToolStripMenuItem.Enabled = totalSubs > 0;
        }

        /// <summary>
        /// Updates the number of viewers currently watching the stream.
        /// </summary>
        public void UpdateViewerCount()
        {
            this.uiViewersCountTitleLabel.Enabled = this.Engine.IsStreamOnline;
            this.uiViewersCountLabel.Enabled = this.Engine.IsStreamOnline;

            if (this.Engine.IsStreamOnline)
            {
                this.uiViewersCountLabel.Text = this.Engine.ViewerCount.ToString();
            }
            else
            {
                this.uiViewersCountLabel.Text = "Offline";
            }

            this.miniWindow.SetViewerCountText(this.Engine.ViewerCount, this.Engine.IsStreamOnline);
        }

        /// <summary>
        /// Displays a message in the activity window.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        private void DisplayActivity(string message)
        {
            this.DisplayActivity(message, Color.Black);
        }
        private void DisplayActivity(string message, Color color, bool showInMiniMonitor = true)
        {
            if (!this.uiActivityRichTextBox.Text.Contains(message))
            {
                this.uiActivityRichTextBox.Text = message + Environment.NewLine + this.uiActivityRichTextBox.Text;

                //------------------------------------------------------------------
                // Set the text color.
                //------------------------------------------------------------------
                uiActivityRichTextBox.SelectionStart = 0;
                uiActivityRichTextBox.SelectionLength = message.Length;
                uiActivityRichTextBox.SelectionColor = color;

                //------------------------------------------------------------------
                //  Relay the message to the mini monitor.
                //------------------------------------------------------------------
                if (showInMiniMonitor)
                {
                    this.miniWindow.AddActivityMessage(message);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiRunButton_Click(object sender, EventArgs e)
        {
            this.ToggleMonitoring();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiClearNewSubcribersButton_Click(object sender, EventArgs e)
        {
            this.uiActivityRichTextBox.Text = string.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        private void ClearSubscriberActivity()
        {
            this.Engine.SubscriberActivity.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutTwitchMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox aboutBox = new AboutBox())
            {
                aboutBox.ShowDialog();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Shows the settings dialog to the user.
        /// </summary>
        private void ShowSettingsDialog()
        {
            using (SettingsDialog dialog = new SettingsDialog())
            {
                dialog.LoadSettings(this.Engine);
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    dialog.SaveSettings();
                    this.UpdateProfileMenu(false);
                    this.VerifySettings();
                    this.uiIrcControl.ApplyDisplaySettings();

                    this.ShowNotificationsDialog(true);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowNotificationsDialog(bool closeIfVisible)
        {
            //------------------------------------------------------------------
            //  Only show the dialog if the user has chosen to do so.
            //------------------------------------------------------------------
            if (this.Engine.Settings.Notifications.ShowNewSubscriberNotification)
            {
                //--------------------------------------------------------------
                //  If the dialog is currently visible and we've been told to
                //  close the dialog, then do so.
                //--------------------------------------------------------------
                if (closeIfVisible && this.notificationDialog.Visible)
                {
                    this.notificationDialog.Close();
                }

                //--------------------------------------------------------------
                //  Recreate the dialog if it's been disposed already.
                //--------------------------------------------------------------
                if (this.notificationDialog.IsDisposed)
                {
                    this.notificationDialog = new NewSubscriberDialog();
                }

                //--------------------------------------------------------------
                //  Refresh the settings and show the dialog.
                //--------------------------------------------------------------
                this.notificationDialog.RefreshDisplay(this.Engine.Settings);
                this.notificationDialog.Show();
            }
            else
            {
                this.notificationDialog.Hide();
            }
        }

        private void UpdateProfileMenu(bool checkDefault)
        {
            //  Remove all the current menu items.
            this.profilesToolStripMenuItem.DropDownItems.Clear();
            this.menuItems.Clear();
            this.profilesToolStripMenuItem.Enabled = false;
            ToolStripMenuItem itemToCheck = null;
            foreach (UserProfile userProfile in this.Engine.UserProfiles)
            {
                this.profilesToolStripMenuItem.Enabled = true;
                ToolStripMenuItem item = new ToolStripMenuItem(userProfile.ChannelName);
                item.CheckOnClick = true;
                if (this.Engine.UserProfiles.Count == 1 || (checkDefault && this.Engine.Settings.DefaultProfile.ToLower().Equals(userProfile.ChannelName.ToLower())))
                {
                    itemToCheck = item;
                }
                item.CheckedChanged += new EventHandler(profileItem_CheckedChanged);
                this.menuItems[item] = userProfile;
            }

            this.profilesToolStripMenuItem.DropDownItems.AddRange(this.menuItems.Keys.ToArray());

            //------------------------------------------------------------------
            //  If we have an item we need to check, check it now since the menu
            //  is done being populated.
            //------------------------------------------------------------------
            if (itemToCheck != null)
            {
                itemToCheck.Checked = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void profileItem_CheckedChanged(object sender, EventArgs e)
        {
            var checkedMenuItem = sender as ToolStripMenuItem;
            if (checkedMenuItem.Checked)
            {
                this.Engine.SetCurrentUserProfile(this.menuItems[checkedMenuItem].ChannelName);
                if (this.ircDialog != null && !this.ircDialog.IsDisposed)
                {
                    this.ircDialog.SetChannelName(this.Engine.SelectedProfile.ChannelName);
                }
                foreach (ToolStripMenuItem menuItem in this.menuItems.Keys)
                {
                    if (!ReferenceEquals(menuItem, checkedMenuItem))
                    {
                        menuItem.Checked = false;
                    }
                }
                this.RefreshCurrentProfile();
            }
        }

        /// <summary>
        /// Event handler for when the 'Settings...' menu option is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowSettingsDialog();
        }

        //======================================================================
        //  Protected Override Methods
        //======================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            this.Engine.StopMonitoring();
            this.CloseIrcDialog();
            this.SaveSizeSettings();
            base.OnClosing(e);
        }

        /// <summary>
        /// Saves the size settings for the main window.
        /// </summary>
        private void SaveSizeSettings()
        {
            this.Engine.Settings.WindowSize.Width = this.Width;
            this.Engine.Settings.WindowSize.Height = this.Height;
            this.Engine.Settings.WindowSize.X = this.Location.X;
            this.Engine.Settings.WindowSize.Y = this.Location.Y;
            this.Engine.SaveSettings();
        }

        /// <summary>
        /// Closes the IRC dialog and saves its window settings.
        /// </summary>
        private void CloseIrcDialog()
        {
            this.SaveIrcSettings();

            if (this.ircDialog != null && this.ircDialog.Visible)
            {
                this.ircDialog.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void SaveIrcSettings()
        {
            if (this.ircDialog != null && this.ircDialog.Visible)
            {
                this.Engine.Settings.Irc.WindowSize.Width = this.ircDialog.Width;
                this.Engine.Settings.Irc.WindowSize.Height = this.ircDialog.Height;
                this.Engine.Settings.Irc.WindowSize.X = this.ircDialog.Location.X;
                this.Engine.Settings.Irc.WindowSize.Y = this.ircDialog.Location.Y;
            }

            this.Engine.Settings.Irc.BotCommands.Clear();
            foreach (string key in this.uiIrcControl.BotCommands.Keys)
            {
                this.Engine.Settings.Irc.BotCommands.Add(new IrcBotCommand() { Command = key, Message = this.uiIrcControl.BotCommands[key] });
            }

            this.Engine.SaveSettings();
        }

        /// <summary>
        /// Event handler for when a cell in the DataGridView needs to be painted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e != null && e.ColumnIndex == 2 && e.Value != null)
            {
                if (e.Value.ToString().Contains("Unsubscribed"))
                {
                    e.CellStyle.BackColor = Color.Pink;
                }
                else if (e.Value.ToString().Contains("Resubscribed"))
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                }
                else if(e.Value.ToString().EndsWith("(NEW)"))
                {
                    e.CellStyle.BackColor = Color.LightBlue;
                }
            }
        }

        /// <summary>
        /// Event handler for when an editor is about to be invoked on a cell. Use this to cancel editing
        /// if we shouldn't allow editing for that cell.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            e.Cancel = e.ColumnIndex != 3;
        }

        /// <summary>
        /// Event handler for when a user has finished editing a cell.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string subscriberName = uiSubscriberDataGridView.Rows[e.RowIndex].Cells[columnName].Value as string;
            string notes = uiSubscriberDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value as string;
            this.Engine.SetSubscriberNotes(subscriberName, notes);
            this.Engine.SaveSubscriberList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataRow[] rows = this.subscriberTable.Select (columnName + " Like '" + this.uiSearchTextBox.Text + "%'", columnName);

            if(rows.GetUpperBound(0) >= 0)
            {
                this.subscriberTable.DefaultView.Sort = columnName;
                this.subscribersBindingSource.Position = this.subscriberTable.DefaultView.Find(rows[0][columnName].ToString());
            }
        }

        private void showMinicastMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.miniWindow.ProcessSettings();
            this.miniWindow.Show();
            this.Hide();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //------------------------------------------------------------------
            //  Perform the check for updates.
            //------------------------------------------------------------------
            if (this.Updater.IsUpdateAvailable(false))
            {
                this.PromptUserForNewUpdate(true);
            }
            else
            {
                using (WaitingDialog dialog = new WaitingDialog(this))
                {
                    dialog.ShowDialog();
                }
            }
        }

        public void PromptUserForNewUpdate(bool updateAvailable)
        {
            if (updateAvailable)
            {
                if (MessageBox.Show("An update is available for Twitch Monitor. Would you like to get it?", "Twitch Monitor", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Hide();
                    this.Updater.PerformUpdate();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("No update available. You are running the current version of Twitch Monitor.", "Twitch Monitor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Event handler for when a row is added to the Followers DataGridView control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiFollowersDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                if (e.RowCount > 1)
                {
                    this.uiFollowersDataGridView.Columns[0].Width = 50;
                }
            }
            catch (Exception)
            {
                //this.ReportStatusMessage("Error updating followers gridview: " + ex.Message);
            }
        }

        private void uiRunAdButton_Click(object sender, EventArgs e)
        {
            this.RunAdBreak();
        }

        public void RunAdBreak()
        {
            this.Engine.RunAdBreak(true);
        }

        /// <summary>
        /// Event handler for when the user wants to view the log file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiViewLogButton_Click(object sender, EventArgs e)
        {
            this.Engine.ViewStatusLog();
        }

        private void diceRollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (DiceRollDialog dialog = new DiceRollDialog(this.Engine))
            {
                dialog.ShowDialog();
            }
        }

        /// <summary>
        /// Event handler for when the 'Edit' button is click next to the stream title label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiEditStreamTitleButton_Click(object sender, EventArgs e)
        {
            //------------------------------------------------------------------
            //  If there's no profile selected, return.
            //------------------------------------------------------------------
            if (this.Engine.SelectedProfile == null) { return; }

            //------------------------------------------------------------------
            //  Prompt the user and let them change the title and game.
            //------------------------------------------------------------------
            using (EditStreamTitleDialog dialog = new EditStreamTitleDialog())
            {
                dialog.StreamTitle = this.Engine.SelectedProfile.StreamTitle;
                dialog.CurrentGame = this.Engine.SelectedProfile.CurrentGame;

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.Engine.SetStreamTitleText(dialog.StreamTitle, dialog.CurrentGame);
                }
            }
        }

        private void SimulateNewFollower()
        {
            UserJson simulatedFollower = new UserJson();
            simulatedFollower._id = 0;
            simulatedFollower.display_name = "NewFollower_" + DateTime.Now.Ticks.ToString();
            simulatedFollower.created_at = DateTime.Now.ToString("u");
            this.Engine.RegisterFollowerActivity(simulatedFollower, FollowerActivityState.New);
        }

        private void SimulateNewSubscriber()
        {
            Subscriber simulatedSub = new Subscriber();
            simulatedSub.Active = true;
            simulatedSub.Id = 0;
            simulatedSub.Name = "NewSub_" + DateTime.Now.Ticks.ToString();
            this.Engine.RegisterSubscriberActivity(simulatedSub, SubscriberActivityState.New);
        }

        private void SimulateResubscriber()
        {
            Subscriber simulatedSub = new Subscriber();
            simulatedSub.Active = true;
            simulatedSub.Id = 0;
            simulatedSub.Name = "ReSub_" + DateTime.Now.Ticks.ToString();
            this.Engine.RegisterSubscriberActivity(simulatedSub, SubscriberActivityState.Resubscribed);
        }

        private void SimulateUnsubscriber()
        {
            Subscriber simulatedSub = new Subscriber();
            simulatedSub.Active = false;
            simulatedSub.Id = 0;
            simulatedSub.Name = "UnSub_" + DateTime.Now.Ticks.ToString();
            this.Engine.RegisterSubscriberActivity(simulatedSub, SubscriberActivityState.Unsubscribed);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newSubscriberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SimulateNewSubscriber();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reSubscriberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SimulateResubscriber();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void unsubscriberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SimulateUnsubscriber();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiPopOutIrcButton_Click(object sender, EventArgs e)
        {
            this.PopOutIrcWindow();
        }

        /// <summary>
        /// Pops out the IRC window into its own window if it's not already being shown. Otherwise, it pops it back in.
        /// </summary>
        private void PopOutIrcWindow()
        {
            if (this.ircDialog == null || this.ircDialog.IsDisposed)
            {
                this.ircDialog = new IrcDialog(this);

                //--------------------------------------------------------------
                //  Set the dialog size settings.
                //--------------------------------------------------------------
                this.ircDialog.Width = this.Engine.Settings.Irc.WindowSize.Width;
                this.ircDialog.Height = this.Engine.Settings.Irc.WindowSize.Height;
                this.ircDialog.Location = new Point(this.Engine.Settings.Irc.WindowSize.X, this.Engine.Settings.Irc.WindowSize.Y);

                if (this.Engine.SelectedProfile == null)
                {
                    this.ircDialog.SetChannelName("");
                }
                else
                {
                    this.ircDialog.SetChannelName(this.Engine.SelectedProfile.ChannelName);
                }
                this.uiIrcTabPage.Controls.Remove(this.uiIrcControl);
                this.ircDialog.SetIrcControl(this.uiIrcControl);
                this.ircDialog.Show();
                this.uiPopOutIrcButton.Text = "<< Pop In";
            }
            else
            {
                this.CloseIrcDialog();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ircControl"></param>
        public void SetIrcControl(IrcControl ircControl)
        {
            this.SaveIrcSettings();
            this.uiIrcControl = ircControl;
            this.uiIrcContainerPanel.Controls.Add(this.uiIrcControl);
            this.uiPopOutIrcButton.Text = "Pop Out >>";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void SendIrcMessage(string message)
        {
            this.uiIrcControl.SendAndDisplayChatMessage(message, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="parameter"></param>
        public void SendIrcMessage(IrcMessageType messageType, string parameter = "")
        {
            switch (messageType)
            {
                case IrcMessageType.RunningAd:
                    this.SendIrcMessage(FormattedIrcMessages.GetDisplayMessage(messageType, this.Engine.Settings.Irc.CustomMessages.AdBreakMessage, parameter));
                    break;

                case IrcMessageType.NewSubscriber:
                    this.SendIrcMessage(FormattedIrcMessages.GetDisplayMessage(messageType, this.Engine.Settings.Irc.CustomMessages.NewSubscriberMessage, parameter));
                    break;

                case IrcMessageType.ReSubscriber:
                    if (this.Engine.Settings.Irc.CustomMessages.UseNewSubscriberMessageForReSubscribers)
                    {
                        this.SendIrcMessage(FormattedIrcMessages.GetDisplayMessage(messageType, this.Engine.Settings.Irc.CustomMessages.NewSubscriberMessage, parameter));
                    }
                    else
                    {
                        this.SendIrcMessage(FormattedIrcMessages.GetDisplayMessage(messageType, this.Engine.Settings.Irc.CustomMessages.ReSubscriberMessage, parameter));
                    }
                    break;

                case IrcMessageType.NewFollower:
                    this.SendIrcMessage(FormattedIrcMessages.GetDisplayMessage(messageType, this.Engine.Settings.Irc.CustomMessages.NewFollowerMessage, parameter));
                    break;
            }
        }

        /// <summary>
        /// Event handler for the 'Clear' button on the Status Log tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiClearLogButton_Click(object sender, EventArgs e)
        {
            this.uiStatusLogTextBox.Text = string.Empty;
        }

        /// <summary>
        /// Event handler for when the 'Remove Unsubscribers' button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiRemoveUnsubscribersButton_Click(object sender, EventArgs e)
        {
            this.RemoveUnsubscribers();
        }

        /// <summary>
        /// Removes all unsubscribers from the list of subscribers.
        /// </summary>
        private void RemoveUnsubscribers()
        {
            if (MessageBox.Show("Are you sure you want to remove all unsubscribers from the subscriber cache?", "Twitch Monitor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Engine.RemoveUnsubscribers();
                this.Engine.SaveSubscriberList();
                this.RefreshSubscriberTable();
            }
        }

        private void keyCommanderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.keyCommanderDialog == null || this.keyCommanderDialog.IsDisposed)
            {
                this.keyCommanderDialog = new KeyCommanderDialog();
            }
            this.keyCommanderDialog.Show();
        }

        private void newFollowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SimulateNewFollower();
        }
    }
}
