using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using TwitchMonitor.Core.Types;
using System.Drawing;
using TwitchMonitor.Core.Apis.KeyboardCommands;

namespace TwitchMonitor.Core
{
    public class KeyCommandEntry
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("command")]
        public KeyCommandType Command { get; set; }
        [XmlAttribute("ircCommand")]
        public string IrcCommand { get; set; }
        [XmlText()]
        public string CustomValue { get; set; }
    }

    public class KeyCommandSettings
    {
        [XmlElement("windowName")]
        public string WindowName { get; set; }
        [XmlElement("className")]
        public string ClassName { get; set; }
        [XmlElement("customKeyCommand")]
        public List<KeyCommandEntry> Commands { get; set; }
        [XmlElement("windowX")]
        public string WindowX { get; set; }
        [XmlElement("windowY")]
        public string WindowY { get; set; }

        public KeyCommandSettings()
        {
            this.Commands = new List<KeyCommandEntry>();
        }
    }

    public class MissileLauncherSettings
    {
        [XmlElement("usbLibPath")]
        public string DreamCheekyUsbLibPath { get; set; }

        [XmlElement("fireOnNewSubscriber")]
        public bool FireOnNewSubscriber { get; set; }

        [XmlElement("fireOnReSubscriber")]
        public bool FireOnReSubscriber { get; set; }

        [XmlElement("fireOnNewFollower")]
        public bool FireOnNewFollower { get; set; }
    }

    public class WindowSize
    {
        [XmlElement("width")]
        public int Width { get; set; }
        [XmlElement("height")]
        public int Height { get; set; }
        [XmlElement("x")]
        public int X { get; set; }
        [XmlElement("y")]
        public int Y { get; set; }
    }

    public class NotificationSettings
    {
        [XmlElement("showNewSubscriberNotification")]
        public bool ShowNewSubscriberNotification { get; set; }

        [XmlElement("imagePath")]
        public string ImagePath { get; set; }

        [XmlElement("windowSize")]
        public WindowSize WindowSize { get; set; }

        public NotificationSettings()
        {
            this.WindowSize = new WindowSize();
        }
    }

    public class MiniCastSettings
    {
        [XmlElement("showViewerCount")]
        public bool ShowViewerCount { get; set; }
        [XmlElement("showNewFollowers")]
        public bool ShowNewFollowerMessages { get; set; }

        public MiniCastSettings()
        {
            this.ShowViewerCount = true;
        }
    }

    public class FileOutputSetting
    {
        [XmlAttribute("enabled")]
        public bool Enabled { get; set; }

        [XmlText()]
        public string FilePath { get; set; }

        [XmlAttribute("count")]
        public int ItemCount { get; set; }

        [XmlAttribute("clearListOnStartup")]
        public bool ClearListOnStartup { get; set; }

        [XmlIgnore()]
        public bool ItemCountSpecified { get { return this.ItemCount > 0; } }

        public FileOutputSetting()
        {
            this.ItemCount = 0;
        }
    }

    public class FileOutputSettings
    {
        [XmlElement("outputFollowersToFile")]
        public FileOutputSetting Followers { get; set; }
        [XmlElement("outputSubscribersToFile")]
        public FileOutputSetting Subscribers { get; set; }
        [XmlElement("outputViewerCountToFile")]
        public FileOutputSetting ViewerCount { get; set; }
        [XmlElement("diceRollOutput")]
        public FileOutputSetting DiceRollOutput { get; set; }
        [XmlElement("outputAdWarningToFile")]
        public FileOutputSetting AdWarningOutput { get; set; }

        public FileOutputSettings()
        {
            this.Followers = new FileOutputSetting();
            this.Subscribers = new FileOutputSetting();
            this.ViewerCount = new FileOutputSetting();
            this.DiceRollOutput = new FileOutputSetting();
            this.AdWarningOutput = new FileOutputSetting();

            this.Followers.ItemCount = 1;
            this.Subscribers.ItemCount = 1;
        }
    }

    public enum PlaySoundType
    {
        None,
        FromFile,
        FromDirectory
    }

    public enum AdBreakType
    {
        Manual,
        Automated
    }

    public class IrcBotCommand
    {
        [XmlAttribute("command")]
        public string Command { get; set; }
        [XmlText()]
        public string Message { get; set; }
    }

    public class IrcCustomMessages
    {
        [XmlElement("newFollowerMessage")]
        public string NewFollowerMessage { get; set; }
        [XmlElement("newSubscriberMessage")]
        public string NewSubscriberMessage { get; set; }
        [XmlElement("reSubscriberMessage")]
        public string ReSubscriberMessage { get; set; }
        [XmlElement("useNewSubscriberMessageForReSubscribers")]
        public bool UseNewSubscriberMessageForReSubscribers { get; set; }
        [XmlElement("adBreakMessage")]
        public string AdBreakMessage { get; set; }
        [XmlElement("showAdBreakMessageBeforeAdBreak")]
        public bool ShowAdBreakMessageBeforeAdBreak { get; set; }

        #region Deprecated Settings
        [XmlElement("adBreakMessageDelay")]
        public int AdBreakMessageDelay { get; set; }

        [XmlIgnore()]
        public bool AdBreakMessageDelaySpecified { get { return false; } }
        #endregion
    }

    public class IrcSettings
    {
        [XmlElement("username")]
        public string Username { get; set; }
        [XmlElement("password")]
        public string Password { get; set; }
        [XmlElement("textColor")]
        public string TextColor { get; set; }
        [XmlElement("backColor")]
        public string BackColor { get; set; }
        [XmlElement("windowSize")]
        public WindowSize WindowSize { get; set; }
        [XmlElement("modColor")]
        public string ModColor { get; set; }
        [XmlElement("statusColor")]
        public string StatusColor { get; set; }
        [XmlElement("errorColor")]
        public string ErrorColor { get; set; }
        [XmlElement("timestampColor")]
        public string TimestampColor { get; set; }
        [XmlElement("maxLineCount")]
        public int MaxLineCount { get; set; }
        [XmlElement("showAllMessages")]
        public bool ShowAllMessages { get; set; }
        [XmlElement("showTimestamp")]
        public bool ShowTimestamp { get; set; }
        [XmlElement("showNotificationsInChat")]
        public bool ShowNotificationsInChat { get; set; }
        [XmlElement("customMessages")]
        public IrcCustomMessages CustomMessages { get; set; }
        [XmlElement("botCommand")]
        public List<IrcBotCommand> BotCommands { get; set; }
        [XmlElement("enableBotOnStartup")]
        public bool EnableBotOnStartup { get; set; }
        [XmlElement("botCommandAccess")]
        public BotCommandsAccess BotCommandAccess { get; set; }

        public IrcSettings()
        {
            this.WindowSize = new WindowSize();
            this.WindowSize.Width = 200;
            this.WindowSize.Height = 400;
            this.TextColor = ColorTranslator.ToHtml(Color.Black);
            this.BackColor = ColorTranslator.ToHtml(Color.White);
            this.ModColor = ColorTranslator.ToHtml(Color.DarkGreen);
            this.StatusColor = ColorTranslator.ToHtml(Color.DarkGray);
            this.ErrorColor = ColorTranslator.ToHtml(Color.DarkRed);
            this.TimestampColor = ColorTranslator.ToHtml(Color.Blue);
            this.ShowAllMessages = false;
            this.ShowTimestamp = true;
            this.ShowNotificationsInChat = false;
            this.CustomMessages = new IrcCustomMessages();
            this.BotCommands = new List<IrcBotCommand>();
            this.BotCommandAccess = BotCommandsAccess.ChannelOwnerOnly;
        }
    }

    public class AdSettings
    {
        [XmlAttribute("enabled")]
        public bool Enabled { get; set; }
        [XmlElement("breakType")]
        public AdBreakType BreakType { get; set; }
        [XmlElement("length")]
        public int Length { get; set; }
        [XmlElement("frequency")]
        public int Frequency { get; set; }
        [XmlElement("warningTimeDuration")]
        public long WarningTimeDuration { get; set; }

        public AdSettings()
        {
            this.Enabled = false;
            this.Length = 240;
            this.BreakType = AdBreakType.Automated;
            this.Frequency = 30;
        }
    }

    public class TimerSettings
    {
        [XmlElement("mode")]
        public TimerMode Mode { get; set; }
        [XmlElement("offset")]
        public TimeSpan Offset { get; set; }
        [XmlElement("countdown")]
        public DateTime Countdown { get; set; }
        [XmlElement("format")]
        public string Format { get; set; }

        public TimerSettings()
        {
            this.Mode = TimerMode.Countdown;
            this.Countdown = DateTime.Now;
            this.Offset = TimeSpan.MinValue;
        }
    }

    public class UserProfile
    {
        [XmlElement("channelName")]
        public string ChannelName { get; set; }

        [XmlElement("authenticationKey")]
        public string AuthenticationKey { get; set; }

        [XmlElement("pollWaitTime")]
        public int PollWaitTime { get; set; }

        [XmlElement("icon")]
        public string Icon { get; set; }

        [XmlElement("streamTitle")]
        public string StreamTitle { get; set; }

        [XmlElement("currentGame")]
        public string CurrentGame { get; set; }

        #region Deprecated Fields
        [XmlElement("clientId")]
        public string ClientId { get; set; }

        [XmlIgnore()]
        public bool ClientIdSpecified { get { return false; } }
        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public UserProfile()
        {
            this.PollWaitTime = 15000; // Default is 15 seconds.
        }

        /// <summary>
        /// Static copy method for convenience.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public static UserProfile MakeCopy(UserProfile other)
        {
            UserProfile copy = new UserProfile();
            copy.ChannelName = other.ChannelName;
            copy.AuthenticationKey = other.AuthenticationKey;
            copy.ClientId = other.ClientId;
            copy.PollWaitTime = other.PollWaitTime;
            copy.Icon = other.Icon;
            return copy;
        }
    }

    public class ChannelProfile
    {
        [XmlText()]
        public string Path { get; set; }
    }

    public class SoundPlaySettings
    {
        [XmlElement("soundFile")]
        public string SoundFile { get; set; }

        [XmlElement("soundDirectory")]
        public string SoundDirectory { get; set; }

        [XmlElement("soundVolume")]
        public int SoundVolume { get; set; }

        [XmlElement("playSoundType")]
        public PlaySoundType PlaySoundType { get; set; }
    }

    [XmlRoot("twitchMonitor")]
    public class Settings
    {
        #region Deprecated Fields
        //----------------------------------------------------------------------
        //  DEPRECATED
        //----------------------------------------------------------------------
        [XmlElement("channelName")]       public string ChannelName { get; set; }
        [XmlElement("authenticationKey")] public string AuthenticationKey { get; set; }
        [XmlElement("clientId")]          public string ClientId { get; set; }
        [XmlElement("pollWaitTime")]      public int PollWaitTime { get; set; }
        [XmlElement("profile")]           public List<UserProfile> Profiles { get; set; }
        
        [XmlElement("soundFile")]
        public string SoundFile 
        {
            get { return this.SubscriberSounds.SoundFile; }
            set 
            {
                if (this.SubscriberSounds == null) { this.SubscriberSounds = new SoundPlaySettings(); }
                this.SubscriberSounds.SoundFile = value; 
            }
        }
        
        [XmlElement("soundDirectory")]
        public string SoundDirectory
        {
            get { return this.SubscriberSounds.SoundDirectory; }
            set 
            {
                if (this.SubscriberSounds == null) { this.SubscriberSounds = new SoundPlaySettings(); }
                this.SubscriberSounds.SoundDirectory = value; 
            }
        }
        
        [XmlElement("soundVolume")]
        public int SoundVolume 
        {
            get { return this.SubscriberSounds.SoundVolume; }
            set 
            {
                if (this.SubscriberSounds == null) { this.SubscriberSounds = new SoundPlaySettings(); }
                this.SubscriberSounds.SoundVolume = value; 
            }
        }
        [XmlElement("playSoundType")]
        public PlaySoundType PlaySoundType
        {
            get { return this.SubscriberSounds.PlaySoundType; }
            set 
            {
                if (this.SubscriberSounds == null) { this.SubscriberSounds = new SoundPlaySettings(); }
                this.SubscriberSounds.PlaySoundType = value; 
            }
        }

        [XmlIgnore()] public bool ChannelNameSpecified { get { return false; } }
        [XmlIgnore()] public bool AuthenticationKeySpecified { get { return false; } }
        [XmlIgnore()] public bool ClientIdSpecified { get { return false; } }
        [XmlIgnore()] public bool PollWaitTimeSpecified { get { return false; } }
        [XmlIgnore()] public bool ProfilesSpecified { get { return false; } }
        [XmlIgnore()] public bool SoundFileSpecified { get { return false; } }
        [XmlIgnore()] public bool SoundDirectorySpecified { get { return false; } }
        [XmlIgnore()] public bool SoundVolumeSpecified { get { return false; } }
        [XmlIgnore()] public bool PlaySoundTypeSpecified { get { return false; } }
        //----------------------------------------------------------------------
        #endregion

        [XmlElement("channelProfile")]
        public List<ChannelProfile> ChannelProfiles { get; set; }

        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlElement("defaultProfile")]
        public string DefaultProfile { get; set; }

        [XmlElement("subscriberSounds")]
        public SoundPlaySettings SubscriberSounds { get; set; }

        [XmlElement("reSubscriberSounds")]
        public SoundPlaySettings ReSubscriberSounds { get; set; }

        [XmlElement("followerSounds")]
        public SoundPlaySettings FollowerSounds { get; set; }

        [XmlElement("irc")]
        public IrcSettings Irc { get; set; }

        [XmlElement("timerOutputFile")]
        public string TimerOutputFile { get; set; }

        [XmlElement("timerSettings")]
        public TimerSettings Timer { get; set; }

        [XmlElement("adSettings")]
        public AdSettings Ads { get; set; }

        [XmlElement("fileOutput")]
        public FileOutputSettings FileOutput { get; set; }

        [XmlElement("miniCast")]
        public MiniCastSettings MiniCast { get; set; }

        [XmlElement("notifications")]
        public NotificationSettings Notifications { get; set; }

        [XmlElement("windowSize")]
        public WindowSize WindowSize { get; set; }

        [XmlElement("missileLauncher")]
        public MissileLauncherSettings MissileLauncher { get; set; }

        [XmlElement("keyCommandSettings")]
        public KeyCommandSettings KeyCommands { get; set; }

        [XmlIgnore()]
        public bool MissileLauncherSpecified { get { return (this.MissileLauncher != null && !string.IsNullOrEmpty(this.MissileLauncher.DreamCheekyUsbLibPath)); } }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Settings()
        {
            this.PlaySoundType = PlaySoundType.None;
            this.PollWaitTime = 15000; // Default is 15 seconds.
            this.SoundVolume = 5; // Default is 5 (out of 10).
            this.Irc = new IrcSettings();
            this.Timer = new TimerSettings();
            this.Ads = new AdSettings();
            this.Profiles = new List<UserProfile>();
            this.ChannelProfiles = new List<ChannelProfile>();
            this.FileOutput = new FileOutputSettings();
            this.MiniCast = new MiniCastSettings();
            this.Notifications = new NotificationSettings();
            this.WindowSize = new WindowSize();
            this.SubscriberSounds = new SoundPlaySettings();
            this.ReSubscriberSounds = new SoundPlaySettings();
            this.FollowerSounds = new SoundPlaySettings();
            this.MissileLauncher = new MissileLauncherSettings();
            this.KeyCommands = new KeyCommandSettings();

            this.ClientId = string.Empty;
            this.AuthenticationKey = string.Empty;
            this.SoundDirectory = string.Empty;
            this.ChannelName = string.Empty;
        }
    }
}
