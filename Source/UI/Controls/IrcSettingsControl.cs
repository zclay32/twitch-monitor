using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwitchMonitor.Core.Interfaces;
using TwitchMonitor.IRC;

namespace TwitchMonitor.Controls
{
    public partial class IrcSettingsControl : BaseSettingsControl
    {
        public IrcSettingsControl() : base() { InitializeComponent(); }
        public IrcSettingsControl(ISettingsView parent)
            : base(parent)
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void LoadSettings()
        {
            this.uiUsernameTextBox.Text = this.ParentView.Engine.Settings.Irc.Username;
            this.uiPasswordTextBox.Text = this.ParentView.Engine.Settings.Irc.Password;
            this.uiEnabledOnStartupCheckBox.Checked = this.ParentView.Engine.Settings.Irc.EnableBotOnStartup;

            switch (this.ParentView.Engine.Settings.Irc.BotCommandAccess)
            {
                case Core.Types.BotCommandsAccess.AllModerators:
                    this.uiAnyModeratorRadioButton.Checked = true;
                    break;

                case Core.Types.BotCommandsAccess.ChannelOwnerOnly:
                case Core.Types.BotCommandsAccess.SelectModerators:
                case Core.Types.BotCommandsAccess.SelectUsers:
                default:
                    this.uiChannelOwnerOnlyRadioButton.Checked = true;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SaveSettings()
        {
            this.ParentView.Engine.Settings.Irc.Username = this.uiUsernameTextBox.Text;
            this.ParentView.Engine.Settings.Irc.Password = this.uiPasswordTextBox.Text;

            if (this.uiAnyModeratorRadioButton.Checked)
            {
                this.ParentView.Engine.Settings.Irc.BotCommandAccess = Core.Types.BotCommandsAccess.AllModerators;
            }
            else
            {
                this.ParentView.Engine.Settings.Irc.BotCommandAccess = Core.Types.BotCommandsAccess.ChannelOwnerOnly;
            }
        }

        private void uiAuthorizeButton_Click(object sender, EventArgs e)
        {
            this.Authorize();
        }

        /// <summary>
        /// Authenticates the application.
        /// </summary>
        private void Authorize()
        {
            using (ClientRegistrationForm form = new ClientRegistrationForm())
            {
                form.Register(RegistrationMode.IRC);
                while (!form.IsFinished && form.DialogResult == DialogResult.None)
                {
                    Application.DoEvents();
                }
                form.Hide();

                if (!string.IsNullOrEmpty(form.AuthenticationKey))
                {
                    this.uiPasswordTextBox.Text = form.AuthenticationKey;
                }
            }
        }
    }
}
