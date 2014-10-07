using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwitchMonitor.Controls;
using TwitchMonitor.Core.Interfaces;

namespace TwitchMonitor.UI.Controls
{
    public partial class IrcChatNotificationsSettingsControl : BaseSettingsControl
    {
        public IrcChatNotificationsSettingsControl() : base() { InitializeComponent(); }
        public IrcChatNotificationsSettingsControl(ISettingsView parent)
            : base(parent)
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void LoadSettings()
        {
            this.uiShowNotificationsInChatCheckBox.Checked = this.ParentView.Engine.Settings.Irc.ShowNotificationsInChat;
            this.uiNewFollowerTextBox.Text = this.ParentView.Engine.Settings.Irc.CustomMessages.NewFollowerMessage;
            this.uiNewSubscriberTextBox.Text = this.ParentView.Engine.Settings.Irc.CustomMessages.NewSubscriberMessage;
            this.uiReSubscriberTextBox.Text = this.ParentView.Engine.Settings.Irc.CustomMessages.ReSubscriberMessage;
            this.uiUseNewSubscriberMessageCheckBox.Checked = this.ParentView.Engine.Settings.Irc.CustomMessages.UseNewSubscriberMessageForReSubscribers;
            this.uiAdBreakTextBox.Text = this.ParentView.Engine.Settings.Irc.CustomMessages.AdBreakMessage;
            this.uiShowAdBreakMessageAtWarningCheckBox.Checked = this.ParentView.Engine.Settings.Irc.CustomMessages.ShowAdBreakMessageBeforeAdBreak;

            this.ToggleControls();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SaveSettings()
        {
            try
            {
                this.ParentView.Engine.Settings.Irc.ShowNotificationsInChat = this.uiShowNotificationsInChatCheckBox.Checked;
                this.ParentView.Engine.Settings.Irc.CustomMessages.NewFollowerMessage = this.uiNewFollowerTextBox.Text;
                this.ParentView.Engine.Settings.Irc.CustomMessages.NewSubscriberMessage = this.uiNewSubscriberTextBox.Text;
                this.ParentView.Engine.Settings.Irc.CustomMessages.AdBreakMessage = this.uiAdBreakTextBox.Text;
                this.ParentView.Engine.Settings.Irc.CustomMessages.ReSubscriberMessage = this.uiReSubscriberTextBox.Text;
                this.ParentView.Engine.Settings.Irc.CustomMessages.UseNewSubscriberMessageForReSubscribers = this.uiUseNewSubscriberMessageCheckBox.Checked;
                this.ParentView.Engine.Settings.Irc.CustomMessages.ShowAdBreakMessageBeforeAdBreak = this.uiShowAdBreakMessageAtWarningCheckBox.Checked;
            }
            catch (Exception ex)
            {
                this.ParentView.Engine.WriteStatusLogMessage("[ERROR] Failed to store the IRC display settings: " + ex.Message);
            }
        }

        private void uiShowNotificationsInChatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.ToggleControls();
        }

        private void uiUseNewSubscriberMessageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.ToggleReSubscriberMessageControl();
        }

        private void ToggleControls()
        {
            this.uiNewFollowerTextBox.Enabled = this.uiShowNotificationsInChatCheckBox.Checked;
            this.uiNewSubscriberTextBox.Enabled = this.uiShowNotificationsInChatCheckBox.Checked;
            this.uiUseNewSubscriberMessageCheckBox.Enabled = this.uiShowNotificationsInChatCheckBox.Checked;
            this.uiAdBreakTextBox.Enabled = this.uiShowNotificationsInChatCheckBox.Checked;
            this.uiShowAdBreakMessageAtWarningCheckBox.Enabled = this.uiShowNotificationsInChatCheckBox.Checked;

            this.ToggleReSubscriberMessageControl();
        }

        private void ToggleReSubscriberMessageControl()
        {
            this.uiReSubscriberTextBox.Enabled = this.uiShowNotificationsInChatCheckBox.Checked && !this.uiUseNewSubscriberMessageCheckBox.Checked;
        }
    }
}
