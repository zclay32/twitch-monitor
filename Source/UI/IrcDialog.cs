using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwitchMonitor.Controls;
using TwitchMonitor.Core.Interfaces;

namespace TwitchMonitor.UI
{
    public partial class IrcDialog : Form
    {
        private MainWindow parentWindow;
        private IrcControl ircControl;

        public IrcDialog()
        {
            InitializeComponent();
        }

        public IrcDialog(MainWindow parentWindow) : this()
        {
            this.parentWindow = parentWindow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelName"></param>
        public void SetChannelName(string channelName)
        {
            this.Text = "Twitch Monitor - IRC";
            if (!string.IsNullOrEmpty(channelName))
            {
                this.Text += string.Format(" ({0})", channelName);
            }
        }

        public void SetIrcControl(IrcControl ircControl)
        {
            this.Controls.Add(ircControl);
            this.ircControl = ircControl;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.parentWindow.SetIrcControl(this.ircControl);
            this.Controls.Remove(this.ircControl);
            base.OnClosing(e);
        }
    }
}
