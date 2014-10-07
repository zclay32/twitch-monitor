using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using TwitchMonitor.Core.Interfaces;
using System.Text.RegularExpressions;
using TwitchMonitor.IRC.Interfaces;
using TwitchMonitor.IRC;
using TwitchMonitor.Core;
using TwitchMonitor.IRC.Types;
using TwitchMonitor.Properties;
using System.Runtime.InteropServices;

namespace TwitchMonitor.Controls
{
    public partial class IrcControl : UserControl, IMessageRelay
    {
        private BackgroundWorker worker;
        private BackgroundWorker connectionWorker;
        private Dictionary<string, NameSettings> nameLookup;
        private bool isClosing;
        private Engine engine;
        private StringBuilder chatMessages;
        private List<string> outputMessages;
        private static Regex commandRegex = new Regex(@"(?<command>!(\w+))(\s+((?<text>(.+))?))?");
        private bool botEnabled;

        public Queue MessageQueue { get; set; }
        public TwitchIrc IrcClient { get; set; }
        public Dictionary<string, string> BotCommands { get; set; }
        public int MaxLineCount { get; set; }

        #region urlmon.dll
        private const int FEATURE_DISABLE_NAVIGATION_SOUNDS = 21;
        private const int SET_FEATURE_ON_THREAD = 0x00000001;
        private const int SET_FEATURE_ON_PROCESS = 0x00000002;
        private const int SET_FEATURE_IN_REGISTRY = 0x00000004;
        private const int SET_FEATURE_ON_THREAD_LOCALMACHINE = 0x00000008;
        private const int SET_FEATURE_ON_THREAD_INTRANET = 0x00000010;
        private const int SET_FEATURE_ON_THREAD_TRUSTED = 0x00000020;
        private const int SET_FEATURE_ON_THREAD_INTERNET = 0x00000040;
        private const int SET_FEATURE_ON_THREAD_RESTRICTED = 0x00000080;

        [DllImport("urlmon.dll")]
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        static extern int CoInternetSetFeatureEnabled(int FeatureEntry, [MarshalAs(UnmanagedType.U4)] int dwFlags, bool fEnable);
        #endregion

        /// <summary>
        /// Default constructor that initializes all the members.
        /// </summary>
        public IrcControl()
        {
            InitializeComponent();

            //  Create the queue in a thread-safe manner.
            this.MessageQueue = Queue.Synchronized(new Queue());
            this.nameLookup = new Dictionary<string, NameSettings>();
            this.BotCommands = new Dictionary<string, string>();

            this.worker = new BackgroundWorker();
            this.worker.WorkerReportsProgress = true;
            this.worker.WorkerSupportsCancellation = true;
            this.worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            this.worker.DoWork += new DoWorkEventHandler(worker_DoWork);

            this.connectionWorker = new BackgroundWorker();
            this.connectionWorker.DoWork += new DoWorkEventHandler(connectionWorker_DoWork);
            this.connectionWorker.WorkerSupportsCancellation = true;

            this.isClosing = false;

            this.worker.RunWorkerAsync();

            this.chatMessages = new StringBuilder();
            this.outputMessages = new List<string>();

            this.MaxLineCount = 50;

            //int feature = FEATURE_DISABLE_NAVIGATION_SOUNDS;
            CoInternetSetFeatureEnabled(FEATURE_DISABLE_NAVIGATION_SOUNDS, SET_FEATURE_ON_PROCESS, true);

            this.webBrowser1.DocumentText = "<html><body></body></html>";
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
        }

        /// <summary>
        /// Event handler for when the web browser control'd document finishes loading. It is at this point that we need to scroll the
        /// document to the bottom-most DIV element.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument doc = webBrowser1.Document;

            HtmlElement lastElement = null;
            foreach (HtmlElement element in doc.All)
            {
                if (element.TagName == "DIV")
                {
                    lastElement = element;
                }
            }

            if (lastElement != null)
            {
                lastElement.ScrollIntoView(false);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Cleanup()
        {
            try
            {
                this.worker.CancelAsync();

                //--------------------------------------------------------------
                //  Wait for the worker to finish.  Call Application.DoEvents()
                //  since this is running on the main UI thread.
                //--------------------------------------------------------------
                while (this.worker.IsBusy)
                {
                    Application.DoEvents();
                }

                //--------------------------------------------------------------
                //  Dispose the IRC client object.
                //--------------------------------------------------------------
                if (this.IrcClient != null)
                {
                    this.IrcClient.Dispose();
                }
            }
            catch (Exception) { /* Ignore any exceptions thrown while cleaning up. */}
        }

        /// <summary>
        /// Applies the display settings specified by the user.
        /// </summary>
        public void ApplyDisplaySettings()
        {
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                while (true)
                {
                    //  If we canceled, handle it.
                    if (this.worker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }

                    Thread.Sleep(10);

                    if (this.MessageQueue.Count > 0)
                    {
                        worker.ReportProgress(0);
                    }
                }
            }
            catch (Exception) { /* Ignore any exceptions for now. */ }
        }

        /// <summary>
        /// Handles connecting to the IRC chat room.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void connectionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.IrcClient.Connect(this.engine.Settings.Irc.Username, this.engine.Settings.Irc.Password);
        }

        /// <summary>
        /// Processes the message queue to see if we have anything new that needs to be displayed or reflected in the UI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (this.isClosing)
            {
                return;
            }

            //------------------------------------------------------------------
            //  Cache the number of items to dequeue. We do this so we don't get
            //  stuck constantly dequeuing for a constant stream of messages.
            //------------------------------------------------------------------
            int count = this.MessageQueue.Count;
            for (int i = 0; i < count; i++)
            {
                try
                {
                    IrcMessage message = (IrcMessage)this.MessageQueue.Dequeue();

                    if (message.MessageType == IrcMessageType.Custom)
                    {
                        this.DisplayMessage(message.Message, this.engine.Settings.Irc.StatusColor, true);
                    }
                    else if (message.MessageType == IrcMessageType.Error)
                    {
                        this.DisplayMessage(message.Message, this.engine.Settings.Irc.ErrorColor, false);
                    }
                    else
                    {
                        string[] matches = Regex.Split(message.Message, @"^(?:[:](\S+) )?(\S+)(?: (?!:)(.+?))?(?: [:](.+))?$");

                        this.AddUserMessage("RAWMESSAGE", string.Join("|", matches));

                        if (matches.Count() >= 3)
                        {
                            string user = this.GetUser(matches[1]);

                            switch (matches[2])
                            {
                                case "MODE":
                                    /*
                                    if (matches[3].Contains(" +o "))
                                    {
                                        this.AddOp(matches[3]);
                                    }
                                    else if (matches[3].Contains(" -o "))
                                    {
                                        this.RemoveOp(matches[3]);
                                    }*/
                                    break;

                                case "PRIVMSG":
                                    if (matches.Count() >= 5)
                                    {
                                        string username = matches[1].Split(new char[] { '!' })[0];

                                        //if (username != "jtv")
                                        //{
                                            string userMessage = matches[4];
                                            this.AddUserMessage(username, userMessage);

                                            //----------------------------------
                                            //  Check to see if we need to
                                            //  process a user command.
                                            //----------------------------------
                                            if (this.botEnabled && userMessage.StartsWith("!"))
                                            {
                                                this.ProcessCommand(user, userMessage);
                                            }
                                        //}
                                    }
                                    break;

                                case "JOIN":
                                    /*
                                    this.DisplayMessage(string.Format("{0} joined.", user), this.engine.Settings.Irc.StatusColor, false);
                                    this.AddUser(user);*/
                                    break;

                                case "PART":
                                    /*
                                    this.DisplayMessage(string.Format("{0} left.", user), this.engine.Settings.Irc.StatusColor, false);
                                    this.RemoveUser(user);*/
                                    break;

                                // User list
                                case "352":
                                    //this.AddUser(matches[4].Split(' ')[1]);
                                    break;

                                case "353":
                                    //this.AddUserList(matches[4]);
                                    break;

                                default:
                                    this.DisplayMessage(message.Message, this.engine.Settings.Irc.StatusColor, false);
                                    break;
                            }
                        }
                        else
                        {
                            this.DisplayMessage(message.Message, this.engine.Settings.Irc.StatusColor, false);
                        }
                    }
                }
                catch (Exception) { /* Ignore any exceptions for now. */ }
            }
        }

        /// <summary>
        /// Gets whether or not the specified user is currently opped.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private bool IsOp(string user)
        {
            return this.IrcClient.Users.ContainsKey(user) && this.IrcClient.Users[user].Op;
        }

        /// <summary>
        /// Processes a raw command message sent by a user. The command will only be processed if the user is currently opped.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="rawCommand"></param>
        private void ProcessCommand(string user, string rawCommand)
        {
            if ((this.IsOp(user) && this.engine.Settings.Irc.BotCommandAccess == Core.Types.BotCommandsAccess.AllModerators) || (this.engine.Settings.Irc.Username.Equals(user)))
            {
                //--------------------------------------------------------------
                //  Acceptable commands:
                //    !tmadd <command> <text>
                //    !tmdel <command>
                //    !tmlist
                //    !<command> (<param1> <param2> ...)
                //--------------------------------------------------------------
                Match match = commandRegex.Match(rawCommand);
                if (match.Success)
                {
                    string commandText = match.Groups["text"].Value;
                    switch (match.Groups["command"].Value.ToLower())
                    {
                        case "!tmadd":
                            this.UpdateCommand(commandText);
                            break;

                        case "!tmdel":
                            this.DeleteCommand(commandText);
                            break;

                        case "!tmlist":
                            this.ShowCommandList();
                            break;

                        case "!tmtest":
                            this.SendAndDisplayChatMessage("Twitch Monitor IRC bot is online.", true);
                            break;

                        default:
                            this.ProcessCustomCommand(user, rawCommand);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Refreshes the displayed list of commands.
        /// </summary>
        private void RefreshCommandList()
        {
            this.uiBotCommandListView.Items.Clear();
            foreach (string command in this.BotCommands.Keys)
            {
                this.uiBotCommandListView.Items.Add(command);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="rawCommand"></param>
        private void ProcessCustomCommand(string user, string rawCommand)
        {
            Match match = commandRegex.Match(rawCommand);
            if (match.Success)
            {
                string customCommand = match.Groups["command"].Value.ToLower();
                if (this.BotCommands.ContainsKey(customCommand))
                {
                    string chatMessage = this.BotCommands[customCommand];

                    if (chatMessage.Contains("{{who}}"))
                    {
                        chatMessage = chatMessage.Replace("{{who}}", match.Groups["text"].Value);
                    }

                    if (chatMessage.Contains("{{user}}"))
                    {
                        chatMessage = chatMessage.Replace("{{user}}", user);
                    }

                    this.SendAndDisplayChatMessage(chatMessage, true);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowCommandList()
        {
            string message = String.Join(", ", this.BotCommands.Keys);
            if (!string.IsNullOrEmpty(message))
            {
                message += ", ";
            }
            message += "!tmadd, !tmdel, !tmlist, !tmtest";
            this.SendAndDisplayChatMessage(message, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        private void DeleteCommand(string command)
        {
            //------------------------------------------------------------------
            //  Ignore the command if it's reserved.
            //------------------------------------------------------------------
            if (string.IsNullOrEmpty(command) || this.IsCommandReserved(command)) { return; }

            //------------------------------------------------------------------
            //  Remove the command.
            //------------------------------------------------------------------
            this.BotCommands.Remove(command);
            this.RefreshCommandList();
        }

        /// <summary>
        /// Checks whether or not the specified command is a reserved command or not.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private bool IsCommandReserved(string command)
        {
            string[] reservedCommands = { "!tmadd", "!tmdel", "!tmlist", "!tmtest" };
            return reservedCommands.Contains(command);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawCommand"></param>
        private void UpdateCommand(string rawCommand)
        {
            Match match = commandRegex.Match(rawCommand);
            if (match.Success)
            {
                string customCommand = match.Groups["command"].Value.ToLower();
                this.UpdateCommand(customCommand, match.Groups["text"].Value);
            }
        }

        /// <summary>
        /// Updates a bot command. If the command is not found, it is added to the list of commands.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="message"></param>
        private void UpdateCommand(string command, string message)
        {
            //------------------------------------------------------------------
            //  Ignore the command if it's reserved.
            //------------------------------------------------------------------
            if (string.IsNullOrEmpty(command) || this.IsCommandReserved(command)) { return; }

            //------------------------------------------------------------------
            //  Add the command.
            //------------------------------------------------------------------
            bool isCommandPresent = this.BotCommands.ContainsKey(command);
            this.BotCommands[command] = message;
            this.SendAndDisplayChatMessage(string.Format("Successfully {0} {1}.", (isCommandPresent ? "updated" : "added"), command), true);
            this.RefreshCommandList();
        }

        /// <summary>
        /// Displays a message in the chat window.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        private void DisplayMessage(string message, string color, bool alwaysShow)
        {
            if (alwaysShow || this.engine.Settings.Irc.ShowAllMessages)
            {
                StringBuilder displayMessage = this.OpenNewMessage("status");
                this.PrintTimestamp(displayMessage);
                displayMessage.Append(string.Format("<i><font color=\"{0}\">{1}</font></i>", color, message));
                this.CloseAndDisplayNewMessage(displayMessage);
            }
        }

        /// <summary>
        /// Adds a user as an op for the channel.
        /// </summary>
        /// <param name="text">The text containing the op command with username.</param>
        private void AddOp(string user)
        {
            if (!Program.IsUiThread())
            {
                this.Invoke((Action<string>)this.AddOp, user);
                return;
            }

            try
            {
                //string[] temp = text.Split(' ');
                //string user = temp[temp.Length - 1];

                if (nameLookup.Keys.Contains(user))
                {
                    nameLookup[user].Item.Group = this.uiUsersListView.Groups["Ops"];
                    //nameLookup[user].Op = true;
                }
            }
            catch (Exception) { /* Ignore any exceptions for now. */ }
        }

        /// <summary>
        /// Removes op status from a user.
        /// </summary>
        /// <param name="text">The text containing the op command with username.</param>
        private void RemoveOp(string user)
        {
            if (!Program.IsUiThread())
            {
                this.Invoke((Action<string>)this.RemoveOp, user);
                return;
            }

            try
            {
                //string[] temp = text.Split(' ');
                //string user = temp[temp.Length - 1];

                if (nameLookup.Keys.Contains(user))
                {
                    nameLookup[user].Item.Group = this.uiUsersListView.Groups["Users"];
                    //nameLookup[user].Op = false;
                }
            }
            catch (Exception) { /* Ignore any exceptions for now. */ }
        }

        /// <summary>
        /// Removes a user from the list. This occurs when the user leaves the channel.
        /// </summary>
        /// <param name="user">Name of the user to remove.</param>
        private void RemoveUser(string user)
        {
            if (!Program.IsUiThread())
            {
                this.Invoke((Action<string>)this.RemoveUser, user);
                return;
            }

            try
            {
                if (nameLookup.Keys.Contains(user))
                {
                    this.uiUsersListView.Items.Remove(nameLookup[user].Item);
                    nameLookup.Remove(user);
                }
            }
            catch (Exception) { /* Ignore any exceptions for now. */ }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        private void AddUser(string user)
        {
            if (!Program.IsUiThread())
            {
                this.Invoke((Action<string>)this.AddUser, user);
                return;
            }

            try
            {
                if (!nameLookup.Keys.Contains(user))
                {
                    nameLookup[user] = new NameSettings();
                    nameLookup[user].Color = Color.FromArgb(new Random().Next(0, 0xFFFFFF));
                    nameLookup[user].Item = new ListViewItem(user);
                    nameLookup[user].Item.Group = this.uiUsersListView.Groups["Users"];
                    this.uiUsersListView.Items.Add(nameLookup[user].Item);
                }
            }
            catch (Exception) { /* Ignore any exceptions for now. */ }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="users"></param>
        private void AddUserList(string users)
        {
            try
            {
                string[] userList = users.Split(' ');
                foreach (string user in userList)
                {
                    this.AddUser(user);
                }
            }
            catch (Exception) { /* Ignore any exceptions for now. */ }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userString"></param>
        /// <returns></returns>
        private string GetUser(string userString)
        {
            try
            {
                if (userString.Contains('!'))
                {
                    return userString.Split('!')[0];
                }
            }
            catch (Exception) { /* Ignore any exceptions for now. */ }
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="engine"></param>
        public void Initialize(Engine engine)
        {
            this.engine = engine;
            this.IrcClient = new TwitchIrc(engine, this);
            this.IrcClient.OnNameListLoaded += new EventHandler(IrcClient_OnNameListLoaded);
            this.IrcClient.OnUserJoin += new UserEventHandler(IrcClient_OnUserJoin);
            this.IrcClient.OnUserLeave += new UserEventHandler(IrcClient_OnUserLeave);
            this.IrcClient.OnUserModeChanged += new UserEventHandler(IrcClient_OnUserModeChanged);
            this.IrcClient.OnUserMessage += new UserMessageEventHandler(IrcClient_OnUserMessage);

            this.ApplyDisplaySettings();

            this.BotCommands.Clear();
            foreach (IrcBotCommand command in engine.Settings.Irc.BotCommands)
            {
                this.BotCommands[command.Command] = command.Message;
            }
            this.RefreshCommandList();

            this.botEnabled = this.uiEnableBotCheckBox.Checked = this.engine.Settings.Irc.EnableBotOnStartup;
        }

        /// <summary>
        /// Event handler for when there is a new user message to process.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void IrcClient_OnUserMessage(object sender, UserMessageEventArgs e)
        {
            this.AddUserMessage(e.User.Name, e.Message);

            //------------------------------------------------------------------
            //  Check and see if we have a command to process.
            //------------------------------------------------------------------
            if (this.botEnabled && e.Message.StartsWith("!"))
            {
                this.ProcessCommand(e.User.Name, e.Message);
            }
        }

        void IrcClient_OnUserModeChanged(object sender, UserEventArgs e)
        {
            this.AddUser(e.User.Name);

            if (e.User.Op)
            {
                this.AddOp(e.User.Name);
            }
            else
            {
                this.RemoveOp(e.User.Name);
            }
        }

        void IrcClient_OnUserLeave(object sender, UserEventArgs e)
        {
            this.RemoveUser(e.User.Name);
        }

        void IrcClient_OnUserJoin(object sender, UserEventArgs e)
        {
            this.AddUser(e.User.Name);
        }

        void IrcClient_OnNameListLoaded(object sender, EventArgs e)
        {
            foreach (string user in this.IrcClient.Users.Keys)
            {
                this.AddUser(user);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Stop()
        {
            this.worker.CancelAsync();
        }

        /// <summary>
        /// Sends a message to be displayed.
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message, IrcMessageType type)
        {
            this.MessageQueue.Enqueue(new IrcMessage() { Message = message, MessageType = type });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiConnectButton_Click(object sender, EventArgs e)
        {
            //------------------------------------------------------------------
            //  Only connect to the chatroom if a profile is selected.
            //------------------------------------------------------------------
            if (this.engine.SelectedProfile == null)
            {
                return;
            }

            //------------------------------------------------------------------
            //  Connect or disconnect depending on our current state.
            //------------------------------------------------------------------
            if (this.IrcClient.IsConnected)
            {
                this.Disconnect();
            }
            else
            {
                this.Connect();
            }
        }

        /// <summary>
        /// Disconnects from the IRC client.
        /// </summary>
        private void Disconnect()
        {
            this.uiConnectButton.Enabled = false;
            this.IrcClient.Disconnect();
            this.IrcClient.CancellationToken.Cancel();
            this.connectionWorker.CancelAsync();

            while (this.connectionWorker.IsBusy)
            {
                Application.DoEvents();
            }

            this.uiUsersListView.Items.Clear();
            this.nameLookup.Clear();
            this.uiChatTextBox.Enabled = false;
            this.uiConnectButton.Text = "Connect";
            this.uiConnectButton.Enabled = true;
        }

        /// <summary>
        /// Connects to the IRC client.
        /// </summary>
        private void Connect()
        {
            this.IrcClient.CancellationToken = new CancellationTokenSource();
            this.connectionWorker.RunWorkerAsync();
            this.uiChatTextBox.Enabled = true;
            this.uiConnectButton.Text = "Disconnect";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiChatButton_Click(object sender, EventArgs e)
        {
            this.SendChatMessage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiChatTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SendChatMessage();
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void SendAndDisplayChatMessage(string message, bool forceShow)
        {
            if (forceShow || this.engine.Settings.Irc.ShowNotificationsInChat)
            {
                try
                {
                    if (this.IrcClient.SendChatMessage(message))
                    {
                        this.AddUserMessage(this.engine.Settings.Irc.Username, message);
                    }
                }
                catch (Exception ex)
                {
                    this.engine.WriteStatusLogMessage("[ERROR] Failed to send chat message: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Opens a new chat message.
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        private StringBuilder OpenNewMessage(string className)
        {
            StringBuilder message = new StringBuilder();
            message.Append("<div class=\"user_message\">");
            return message;
        }

        /// <summary>
        /// Closes a message and adds it to the list of messages to display.
        /// </summary>
        /// <param name="message"></param>
        private void CloseAndDisplayNewMessage(StringBuilder message)
        {
            message.Append("</div>");
            this.outputMessages.Add(message.ToString());

            //------------------------------------------------------------------
            //  Remove lines from the top if we've reach the limit to the number
            //  of lines.
            //------------------------------------------------------------------
            if (this.outputMessages.Count > this.MaxLineCount)
            {
                this.outputMessages.RemoveAt(0);
            }

            this.webBrowser1.DocumentText = string.Format(Resources.ircTemplate, this.engine.Settings.Irc.BackColor, string.Join("", this.outputMessages.ToArray()));

            this.ScrollToBottom();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SendChatMessage()
        {
            this.SendAndDisplayChatMessage(this.uiChatTextBox.Text, true);
            this.uiChatTextBox.Text = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        private void PrintTimestamp(StringBuilder message)
        {
            if (this.engine.Settings.Irc.ShowTimestamp)
            {
                try
                {
                    message.AppendFormat("<span class=\"small\" style=\"color:{0}\">", this.engine.Settings.Irc.TimestampColor);
                    message.AppendFormat("[{0}] ", DateTime.Now.ToString("HH:mm:ss"));
                    message.Append("</span>");
                }
                catch (Exception) { /* Ignore any exceptions for now. */ }
            }
        }

        /// <summary>
        /// Adds a user message to the richtext control.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="text"></param>
        private void AddUserMessage(string user, string text)
        {
            if (!Program.IsUiThread())
            {
                this.Invoke((Action<string, string>)this.AddUserMessage, user, text);
                return;
            }

            try
            {
                //------------------------------------------------------------------
                //  Add the timestamp.
                //------------------------------------------------------------------
                StringBuilder message = this.OpenNewMessage("chat");
                this.PrintTimestamp(message);

                if (!nameLookup.ContainsKey(user))
                {
                    this.AddUser(user);
                }

                //------------------------------------------------------------------
                //  Add an OP indicator if the user is an op.
                //------------------------------------------------------------------
                if (this.IrcClient.Users[user].Op)
                {
                    //message.Append(string.Format("<strong><font color=\"{0}\">[M] </font></strong>", this.engine.Settings.Irc.ModColor));
                    message.AppendFormat("<span class=\"mod\" style=\"color:{0}\">[M] </span>", this.engine.Settings.Irc.ModColor);
                }
                if (this.IrcClient.Users[user].Subscriber)
                {
                    message.Append("<span class=\"sub\">[S] </span>");
                }
                if (this.IrcClient.Users[user].Turbo)
                {
                    message.Append("<span class=\"turbo\">[T] </span>");
                }

                //------------------------------------------------------------------
                //  Add the username.
                //------------------------------------------------------------------
                message.AppendFormat("<span class=\"chat_user\" style=\"color:{0}\">{1}: </span>", this.IrcClient.Users[user].ChatColor, user);
                message.AppendFormat("<span class=\"chat_message\" style=\"color:{0}\">{1}</span>", this.engine.Settings.Irc.TextColor, text);
                //message.Append(string.Format("<strong><font color=\"{0}\">{1}: </font></strong><font color=\"{2}\">{3}</font>", this.IrcClient.Users[user].ChatColor, user, this.engine.Settings.Irc.TextColor, text));
                this.CloseAndDisplayNewMessage(message);
            }
            catch (Exception) { /* Ignore any exceptions for now. */ }
        }

        /// <summary>
        /// Scrolls the web browser window to the very bottom.
        /// </summary>
        private void ScrollToBottom()
        {
            
            /*
            HtmlElement lastElement = null;
            foreach (HtmlElement element in doc.All)
            {
                if (element.TagName == "DIV")
                {
                    lastElement = element;
                }
            }

            if (lastElement != null)
            {
                lastElement.ScrollIntoView(false);
            }*/

            
        }

        private void AddNewCommand()
        {
            using (TwitchMonitor.UI.EditIrcCommandDialog dialog = new UI.EditIrcCommandDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.UpdateCommand(dialog.Command, dialog.Message);
                }
            }
        }

        private void EditSelectedCommand()
        {
            if (this.uiBotCommandListView.SelectedItems.Count > 0)
            {
                using (TwitchMonitor.UI.EditIrcCommandDialog dialog = new UI.EditIrcCommandDialog())
                {
                    string selectedCommand = this.uiBotCommandListView.SelectedItems[0].Text;
                    dialog.Command = selectedCommand;
                    dialog.Message = this.BotCommands[selectedCommand];
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        this.UpdateCommand(dialog.Command, dialog.Message);
                    }
                }
            }
        }

        private void DeleteSelectedCommand()
        {
            if (this.uiBotCommandListView.SelectedItems.Count > 0)
            {
                this.DeleteCommand(this.uiBotCommandListView.SelectedItems[0].Text);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AddNewCommand();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DeleteSelectedCommand();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.EditSelectedCommand();
        }

        private void uiBotCommandListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.uiBotCommandListView.SelectedItems.Count > 0 && this.BotCommands.ContainsKey(this.uiBotCommandListView.SelectedItems[0].Text))
            {
                this.uiCommandMessageTextBox.Text = this.BotCommands[this.uiBotCommandListView.SelectedItems[0].Text];
            }
            else
            {
                this.uiCommandMessageTextBox.Text = string.Empty;
            }
        }

        private void uiCommandContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            this.removeToolStripMenuItem.Enabled = this.editToolStripMenuItem.Enabled = this.uiBotCommandListView.SelectedItems.Count > 0;
        }

        private void uiEnableBotCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.botEnabled = this.uiEnableBotCheckBox.Checked;
            this.ToggleBotSettingsControls();
        }

        private void ToggleBotSettingsControls()
        {
            this.uiBotCommandListView.Enabled = this.botEnabled;
            this.uiCommandMessageTextBox.Enabled = this.botEnabled;
        }
    }

    public class NameSettings
    {
        public ListViewItem Item { get; set; }
        public Color Color { get; set; }
        public bool Op { get; set; }
        public bool Subscriber { get; set; }

        public NameSettings()
        {
            this.Item = null;
            this.Color = Color.Black;
            this.Op = false;
        }
    }

    public class IrcMessage
    {
        public string Message { get; set; }
        public IrcMessageType MessageType { get; set; }
    }
}
