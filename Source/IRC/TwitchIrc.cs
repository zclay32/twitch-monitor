using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using TwitchMonitor.IRC.Interfaces;
using TwitchMonitor.Core;
using TwitchMonitor.IRC.Types;
using Meebey.SmartIrc4net;
using System.Collections;
using System.ComponentModel;

namespace TwitchMonitor.IRC
{
    #region Event Declarations
    /// <summary>
    /// Event arguments for user-related events from the IRC channel.
    /// </summary>
    public class UserEventArgs : EventArgs
    {
        public TwitchIrcUser User { get; set; }
    }

    /// <summary>
    /// Event arguments for user message events.
    /// </summary>
    public class UserMessageEventArgs : UserEventArgs
    {
        public string Message { get; set; }
    }

    /// <summary>
    /// Delegate for handling user-relateed events from the IRC channel.
    /// </summary>
    /// <param name="sender">Object raising the event.</param>
    /// <param name="e">Event arguments that tell which user caused the event to be raised.</param>
    public delegate void UserEventHandler(object sender, UserEventArgs e);

    /// <summary>
    /// Delegate for handling user message events.
    /// </summary>
    /// <param name="sender">Object raising the event.</param>
    /// <param name="e">Event arguments that describe the message and user that sent the message.</param>
    public delegate void UserMessageEventHandler(object sender, UserMessageEventArgs e);
    #endregion

    /// <summary>
    /// 
    /// </summary>
    public class TwitchIrc : IDisposable
    {
        //======================================================================
        //  Private Members
        //======================================================================
        private BackgroundWorker ircClientListener;
        private IrcClient client;
        private Engine engine;
        private IMessageRelay messenger;
        private AlarmClock whoAlarm;
        private bool namesListReceived;
        private string username;
        private string password;

        //======================================================================
        //  Public Properties
        //======================================================================
        /// <summary>
        /// Gets or sets whether or not an IRC connection is established.
        /// </summary>
        public bool IsConnected { get { return this.client != null && this.client.IsConnected; } }

        /// <summary>
        /// Gets or sets the cancellation token to be used for canceling the connection attempt.
        /// </summary>
        public CancellationTokenSource CancellationToken { get; set; }

        /// <summary>
        /// Gets the list of users currently in the chat.
        /// </summary>
        public Dictionary<string, TwitchIrcUser> Users { get; private set; }

        //======================================================================
        //  Public Events
        //======================================================================
        public event EventHandler OnNameListLoaded;
        public event UserEventHandler OnUserJoin;
        public event UserEventHandler OnUserLeave;
        public event UserEventHandler OnUserModeChanged;
        public event UserMessageEventHandler OnUserMessage;

        //======================================================================
        //  Constructors
        //======================================================================
        /// <summary>
        /// Constructor that initializes the Twitch IRC object.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="messenger"></param>
        public TwitchIrc(Engine engine, IMessageRelay messenger)
        {
            this.engine = engine;
            this.messenger = messenger;
            this.CancellationToken = new CancellationTokenSource();
            this.Users = new Dictionary<string, TwitchIrcUser>();

            this.ircClientListener = new BackgroundWorker();
            this.ircClientListener.DoWork += new DoWorkEventHandler(ircClientListener_DoWork);
            this.ircClientListener.WorkerSupportsCancellation = true;

            //------------------------------------------------------------------
            //  Setup the WHO alarm. If the name list isn't loaded in a timely
            //  manner, then a WHO command will be sent to get the full list of
            //  users connected to the chat room.  
            //
            //  We don't always want to do this because for chat rooms with lots
            //  of users, this can create significant lag since WHO responses
            //  are much lengthier.
            //------------------------------------------------------------------
            this.whoAlarm = new AlarmClock();
            this.whoAlarm.OnAlarm += (sender, e) => 
            {
                if (!this.namesListReceived)
                {
                    this.RequestUserList();
                }
                e.Snooze = false;
            };
        }

        //======================================================================
        //  Public Methods
        //======================================================================
        /// <summary>
        /// Disposes this object, disconnecting the underlying IRC client connection in the process.
        /// </summary>
        public void Dispose()
        {
            this.Disconnect();
        }

        /// <summary>
        /// Disconnects the current connection.
        /// </summary>
        public void Disconnect()
        {
            if (this.client != null && this.ircClientListener.IsBusy)
            {
                this.ircClientListener.CancelAsync();
            }
        }

        /// <summary>
        /// Attempts to connect to the IRC chatroom of the currently loaded channel.
        /// </summary>
        /// <param name="username">The username to connect with.</param>
        /// <param name="password">The password to use when connecting.</param>
        public void Connect(string username, string password)
        {
            //------------------------------------------------------------------
            //  Check to make sure we have a username and password to connect
            //  with and that the worker isn't already running.
            //------------------------------------------------------------------
            if (string.IsNullOrEmpty(username)
                || string.IsNullOrEmpty(password)
                || this.ircClientListener.IsBusy)
            {
                return;
            }

            this.username = username;
            this.password = password;

            this.Users.Clear();
            this.CreateClient();
            this.ircClientListener.RunWorkerAsync();

            this.namesListReceived = false;
            this.whoAlarm.Start(30000);
        }

        /// <summary>
        /// Sends a chat message to the IRC chatroom of the current channel profile.
        /// </summary>
        /// <param name="message">The message to be sent to the chat room.</param>
        /// <returns>True if the message was successfully sent. False otherwise.</returns>
        public bool SendChatMessage(string message)
        {
            if (this.engine.SelectedProfile == null
                || this.client == null
                || string.IsNullOrWhiteSpace(message))
            {
                return false;
            }

            this.client.SendMessage(SendType.Message, this.GetIrcChannelName(), message);
            return true;
        }

        /// <summary>
        /// Requests the full user list by issuing a WHO command.
        /// </summary>
        public void RequestUserList()
        {
            this.Users.Clear();
            this.client.WriteLine("WHO " + this.GetIrcChannelName());
        }

        //======================================================================
        //  Private Methods
        //======================================================================
        private void AddUser(string user)
        {
            if (!this.Users.ContainsKey(user))
            {
                this.Users[user] = new TwitchIrcUser();
                this.Users[user].Name = user;
                this.Users[user].ChatColor = string.Format("#{0}", new Random().Next(0, 0xFFFFFF).ToString("X6"));
            }
        }

        /// <summary>
        /// Listen to the IRC stuff in a background thread.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ircClientListener_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                IrcUser info = (IrcUser)e.Argument;
                string server = "irc.twitch.tv";
                int port = 6667;

                this.client.Connect(server, port);
                this.client.Login(this.username, this.username, 1, this.username, this.password);

                //------------------------------------------------------------------
                //  Main listening loop. Do this as long as we're still connected
                //  and not canceled.
                //------------------------------------------------------------------
                while (!this.ircClientListener.CancellationPending && this.client.IsConnected)
                {
                    //--------------------------------------------------------------
                    //  Read all the new chat lines
                    //--------------------------------------------------------------
                    while (this.client.ReadLine(false).Length > 0) { }

                    //--------------------------------------------------------------
                    //  Sleep for just a bit before continuing.
                    //--------------------------------------------------------------
                    Thread.Sleep(10);
                }

                //--------------------------------------------------------------
                //  At this point we're done. If we're still connected then
                //  issue a disconnect signal to the IRC client.
                //--------------------------------------------------------------
                if (this.client.IsConnected)
                {
                    this.client.Disconnect();
                }
            }
            catch (ConnectionException)
            {
                // TODO: Record this error in the status log.
                return;
            }
            catch (Exception)
            {
                // TODO: Record this error in the status log.
                return;
            }
        }

        /// <summary>
        /// Creates the client object and connects its events to this object's event handlers.
        /// </summary>
        private void CreateClient()
        {
            //------------------------------------------------------------------
            //  Start by disconnecting any currently-open connection.
            //------------------------------------------------------------------
            this.Disconnect();

            this.client = new IrcClient();

            this.client.OnConnected         += (sender, e) => { this.messenger.SendMessage("Connected.", IrcMessageType.Custom); };
            this.client.OnDisconnected      += (sender, e) => { this.messenger.SendMessage("Disconnected.", IrcMessageType.Custom); };
            this.client.OnDisconnecting     += (sender, e) => { this.messenger.SendMessage("Disconnecting from channel...", IrcMessageType.Custom); };
            //this.client.OnRawMessage        += (sender, e) => { this.messenger.SendMessage(e.Data.RawMessage, IrcMessageType.Custom); };
            this.client.OnError             += (sender, e) => { this.messenger.SendMessage(e.ErrorMessage, IrcMessageType.Error); };
            this.client.OnDeop              += (sender, e) => { this.UpdateOpStatus(e.Whom, false); };
            this.client.OnOp                += (sender, e) => { this.UpdateOpStatus(e.Whom, true); };

            this.client.OnJoin           += new JoinEventHandler(client_OnJoin);
            this.client.OnPart           += new PartEventHandler(client_OnPart);
            this.client.OnRegistered     += new EventHandler(client_OnRegistered);
            this.client.OnNames          += new NamesEventHandler(client_OnNames);
            this.client.OnWho            += new WhoEventHandler(client_OnWho);
            this.client.OnQueryMessage   += new IrcEventHandler(client_OnQueryMessage);
            this.client.OnChannelMessage += new IrcEventHandler(client_OnChannelMessage);
        }

        /// <summary>
        /// Event handler for when a user leaves the channel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void client_OnPart(object sender, PartEventArgs e)
        {
            string user = e.Who;
            if (this.Users.ContainsKey(user))
            {
                this.Users.Remove(user);
            }
            if (this.OnUserLeave != null)
            {
                this.OnUserLeave(this, new UserEventArgs() { User = new TwitchIrcUser() { Name = user } });
            }
        }

        /// <summary>
        /// Event handler for when a user joins the channel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void client_OnJoin(object sender, JoinEventArgs e)
        {
            string user = e.Who;
            this.AddUser(e.Who);
            if (this.OnUserJoin != null)
            {
                this.OnUserJoin(this, new UserEventArgs() { User = this.Users[user] });
            }
        }

        /// <summary>
        /// Event handler for when a new channel message is received. This occurs when a user sends a chat message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void client_OnChannelMessage(object sender, IrcEventArgs e)
        {
            string user = e.Data.Nick;
            this.AddUser(user);

            if (this.OnUserMessage != null)
            {
                this.OnUserMessage(this, new UserMessageEventArgs() { User = this.Users[user], Message = e.Data.Message });
            }
        }

        /// <summary>
        /// Event handler for new non-chat IRC messages. These messages usually define display information and status pertaining to specific users.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void client_OnQueryMessage(object sender, IrcEventArgs e)
        {
            if (e.Data.Nick.Equals("jtv"))
            {
                string user = e.Data.MessageArray[1];
                this.AddUser(user);

                switch (e.Data.MessageArray[0])
                {
                    case "USERCOLOR":
                        this.Users[user].ChatColor = e.Data.MessageArray[2];
                        break;

                    case "SPECIALUSER":
                        switch (e.Data.MessageArray[2])
                        {
                            case "turbo":
                                this.Users[user].Turbo = true;
                                break;

                            case "subscriber":
                                this.Users[user].Subscriber = true;
                                break;
                        }
                        break;

                    default:
                        //this.messenger.SendMessage(e.Data.RawMessage, IrcMessageType.Custom);
                        break;
                }
            }
        }

        /// <summary>
        /// Event handler for WHO response messages.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void client_OnWho(object sender, WhoEventArgs e)
        {
            this.AddUser(e.WhoInfo.Nick);
            this.Users[e.WhoInfo.Nick].Op = e.WhoInfo.IsOp;
        }

        /// <summary>
        /// Event handler for the list of names being received.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void client_OnNames(object sender, NamesEventArgs e)
        {
            //------------------------------------------------------------------
            //  Add all the users.
            //------------------------------------------------------------------
            this.namesListReceived = true;
            foreach (string user in e.UserList)
            {
                this.AddUser(user);
            }

            //------------------------------------------------------------------
            //  Raise the event that the names list has now been loaded.
            //------------------------------------------------------------------
            if (this.OnNameListLoaded != null)
            {
                this.OnNameListLoaded(this, EventArgs.Empty);
            }

            this.messenger.SendMessage("Names list received.", IrcMessageType.Custom);
        }

        /// <summary>
        /// Updates the op status for the specified user and raises an event for any listeners.
        /// </summary>
        /// <param name="user">The user whose op status has changed.</param>
        /// <param name="opped">True if the user is now opped; false otherwise.</param>
        private void UpdateOpStatus(string user, bool opped)
        {
            if (!this.Users.ContainsKey(user))
            {
                this.AddUser(user);
            }
            this.Users[user].Op = opped;

            //------------------------------------------------------------------
            //  Raise the event to anyone else who is listening.
            //------------------------------------------------------------------
            if (this.OnUserModeChanged != null)
            {
                this.OnUserModeChanged(this, new UserEventArgs() { User = this.Users[user] });
            }
        }

        /// <summary>
        /// Event handler for when the client is registered with the IRC server. This means we're ready to join the channel of the stream we're monitoring.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void client_OnRegistered(object sender, EventArgs e)
        {
            if (this.engine.SelectedProfile == null) { return; }
            this.messenger.SendMessage("Client registered.", IrcMessageType.Custom);
            this.client.RfcJoin(this.GetIrcChannelName());

            //------------------------------------------------------------------
            //  Per Twitch API's requirement, clients need to know more
            //  information about each user (chat colors, subscriber status,
            //  etc.) need to issue the following command in order to receive
            //  that information.
            //
            //  For now this is disabled due to this server mode not sending
            //  channel join/part information.
            //------------------------------------------------------------------
            //this.client.WriteLine("TWITCHCLIENT 2");
        }

        /// <summary>
        /// Gets the Twitch.tv IRC channel name for the selected profile.
        /// </summary>
        /// <returns></returns>
        private string GetIrcChannelName()
        {
            if (this.engine.SelectedProfile != null)
            {
                return "#" + this.engine.SelectedProfile.ChannelName.ToLower();
            }
            return string.Empty;
        }
    }
}
