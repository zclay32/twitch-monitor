using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwitchMonitor.Core.Interfaces;
using TwitchMonitor.UI;
using TwitchMonitor.Core.Types;
using TwitchMonitor.Core;

namespace TwitchMonitor.Controls
{
    public partial class TwitchChannelSettings : BaseSettingsControl
    {
        //======================================================================
        //  Private Members
        //======================================================================
        private List<UserProfile> userProfiles;
        private UserProfile selectedProfile;
        private UserProfile defaultProfile;
        private bool ignoreProfileSelection;

        //======================================================================
        //  Constructors
        //======================================================================
        /// <summary>
        /// Default constructor necessary for using the Visual Studio designer.
        /// </summary>
        public TwitchChannelSettings() : base() { InitializeComponent(); }
        /// <summary>
        /// Constructor that initializes the view and sets up this settings control to talk back to the parent view.
        /// </summary>
        /// <param name="parent">Parent view that will house this settings control.</param>
        public TwitchChannelSettings(ISettingsView parent) : base(parent)
        {
            InitializeComponent();

            this.userProfiles = new List<UserProfile>();
            this.uiAuthenticationStatusLabel.Text = "";

            this.uiChannelsListView.Focus();
        }

        //======================================================================
        //  Public Methods
        //======================================================================
        /// <summary>
        /// Loads the settings from the engine.
        /// </summary>
        public override void LoadSettings()
        {
            this.userProfiles.Clear();
            this.uiChannelsListView.Items.Clear();
            foreach (UserProfile userProfile in this.ParentView.Engine.UserProfiles)
            {
                UserProfile copy = UserProfile.MakeCopy(userProfile);
                this.userProfiles.Add(copy);
                ListViewItem item = this.uiChannelsListView.Items.Add(copy.ChannelName);
                item.Tag = copy;

                if (userProfile.ChannelName.ToLower().Equals((this.ParentView.Engine.Settings.DefaultProfile.ToLower())))
                {
                    this.defaultProfile = userProfile;
                }

                if (userProfile.Equals(this.ParentView.Engine.SelectedProfile))
                {
                    item.Selected = true;
                    item.Focused = true;
                }
            }
        }

        /// <summary>
        /// Saves the settings to the engine.
        /// </summary>
        public override void SaveSettings()
        {
            this.ParentView.Engine.UserProfiles.Clear();
            this.ParentView.Engine.Settings.ChannelProfiles.Clear();
            this.ParentView.Engine.Settings.DefaultProfile = this.defaultProfile == null ? string.Empty : this.defaultProfile.ChannelName;

            foreach (UserProfile userProfile in this.userProfiles)
            {
                this.ParentView.Engine.UserProfiles.Add(userProfile);
                this.ParentView.Engine.Settings.ChannelProfiles.Add(new ChannelProfile() { Path = userProfile.ChannelName });

                if (this.ParentView.Engine.SelectedProfile == null)
                {
                    this.ParentView.Engine.Settings.DefaultProfile = userProfile.ChannelName;
                    this.ParentView.Engine.SelectedProfile = userProfile;
                }
            }

            if (this.ParentView.Engine.SelectedProfile != null && !string.IsNullOrEmpty(this.ParentView.Engine.SelectedProfile.AuthenticationKey))
            {
                this.ParentView.Engine.ResetPartneredStatus();
            }
        }

        //======================================================================
        //  Private Methods
        //======================================================================
        /// <summary>
        /// Event handler for when the 'Authenticate' button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                form.Register();
                while (!form.IsFinished && form.DialogResult == DialogResult.None)
                {
                    Application.DoEvents();
                }
                form.Hide();

                if (!string.IsNullOrEmpty(form.AuthenticationKey))
                {
                    this.uiAuthenticationStatusLabel.Text = "Access token received. Please click 'OK' to save the new key.";
                    this.uiAuthenticationStatusLabel.ForeColor = Color.Blue;
                    this.uiAuthenticationKeyTextBox.Text = form.AuthenticationKey;
                }
                else
                {
                    this.uiAuthenticationStatusLabel.Text = "Unable to get access token.";
                    this.uiAuthenticationStatusLabel.ForeColor = Color.DarkRed;
                }
            }
        }

        /// <summary>
        /// Checks the Client ID field and only enables the 'Authenticate' button if it's set to something.
        /// </summary>
        private void CheckClientIdField()
        {
            this.uiAuthenticationStatusLabel.Visible = this.uiAuthenticationKeyLabel.Enabled = !string.IsNullOrEmpty(this.uiChannelNameTextBox.Text);// this.uiAuthenticationKeyTextBox.Enabled = this.uiAuthenticateButton.Enabled = !string.IsNullOrEmpty(this.uiClientIdTextBox.Text);
        }

        /// <summary>
        /// Event handler for when the Client ID text field changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiClientIdTextBox_TextChanged(object sender, EventArgs e)
        {
            /*
            if (this.selectedProfile != null)
            {
                this.selectedProfile.ClientId = this.uiClientIdTextBox.Text;
            }
            this.CheckClientIdField();*/
        }

        private void uiAddProfileButton_Click(object sender, EventArgs e)
        {
            using (AddChannelProfileDialog dialog = new AddChannelProfileDialog(this.ParentView.Engine))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.AddChannel(dialog.ProfileJsonPacket);
                }
            }
        }

        /// <summary>
        /// Adds a new channel profile to the list of profiles.
        /// </summary>
        /// <param name="packet">A profile packet describing the profile to be added.</param>
        private void AddChannel(ProfileJsonPacket packet)
        {
            //------------------------------------------------------------------
            //  Don't add the channel if it's already in the tree.
            //------------------------------------------------------------------
            foreach (ListViewItem item in this.uiChannelsListView.Items)
            {
                if (item.Text.Equals(packet.name))
                {
                    return;
                }
            }

            UserProfile userProfile = new UserProfile();
            userProfile.ChannelName = packet.name;
            this.userProfiles.Add(userProfile);
            ListViewItem newItem = this.uiChannelsListView.Items.Add(userProfile.ChannelName);
            newItem.Tag = userProfile;
            newItem.Selected = true;
            this.ApplyNewChannelSelection();
            this.uiChannelsListView.Select();
        }

        /// <summary>
        /// Gets the currently selected UserProfile object.
        /// </summary>
        /// <returns></returns>
        private UserProfile GetSelectedProfile()
        {
            if (this.uiChannelsListView.SelectedItems.Count > 0)
            {
                return this.uiChannelsListView.SelectedItems[0].Tag as UserProfile;
            }
            return null;
        }

        private void uiChannelsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ApplyNewChannelSelection();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ApplyNewChannelSelection()
        {
            this.ignoreProfileSelection = true;
            this.UpdateFields();
            this.ignoreProfileSelection = false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateFields()
        {
            if (this.uiChannelsListView.SelectedItems.Count > 0)
            {
                this.selectedProfile = this.GetSelectedProfile();

                //--------------------------------------------------------------
                //  Return if we have no profile selected.
                //--------------------------------------------------------------
                if (this.selectedProfile == null)
                {
                    return;
                }

                //--------------------------------------------------------------
                //  Set the default profile if it's not already set. Otherwise,
                //  update the checkbox to reflect whether or not the selected
                //  profile is the default profile.
                //--------------------------------------------------------------
                if (this.defaultProfile == null)
                {
                    this.SuspendLayout();
                    this.uiDefaultCheckBox.Checked = true;
                    this.defaultProfile = this.selectedProfile;
                    this.ResumeLayout();
                }
                else
                {
                    this.SuspendLayout();
                    this.uiDefaultCheckBox.Checked = this.defaultProfile.ChannelName.ToLower().Equals(selectedProfile.ChannelName.ToLower());
                    this.ResumeLayout();
                }

                //--------------------------------------------------------------
                //  Update the UI controls to reflect the state of the profile.
                //--------------------------------------------------------------
                this.uiChannelNameTextBox.Text = this.selectedProfile.ChannelName;
                this.uiAuthenticationKeyTextBox.Text = this.selectedProfile.AuthenticationKey;
                this.uiAuthenticateButton.Enabled = this.uiAuthenticationKeyTextBox.Enabled = !string.IsNullOrEmpty(this.uiChannelNameTextBox.Text);

                if (this.selectedProfile.PollWaitTime < this.uiPollWaitTimeNumericUpDown.Minimum)
                {
                    this.uiPollWaitTimeNumericUpDown.Value = this.uiPollWaitTimeNumericUpDown.Minimum;
                }
                else if (selectedProfile.PollWaitTime > this.uiPollWaitTimeNumericUpDown.Maximum)
                {
                    this.uiPollWaitTimeNumericUpDown.Value = this.uiPollWaitTimeNumericUpDown.Maximum;
                }
                else
                {
                    this.uiPollWaitTimeNumericUpDown.Value = this.selectedProfile.PollWaitTime;
                }

                if (selectedProfile == null || string.IsNullOrEmpty(this.selectedProfile.AuthenticationKey))
                {
                    this.uiAuthenticationStatusLabel.Text = "Authorize Twitch Monitor if you would like edit the stream title or track subscribers and run ads (partnered accounts only).";
                    this.uiAuthenticationStatusLabel.ForeColor = Color.Black;
                }
                else
                {
                    this.uiAuthenticationStatusLabel.Text = "Twitch Monitor is authorized.";
                    this.uiAuthenticationStatusLabel.ForeColor = Color.DarkGreen;
                }

                this.CheckClientIdField();
            }
        }

        private void uiAuthenticationKeyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.selectedProfile != null)
            {
                this.selectedProfile.AuthenticationKey = this.uiAuthenticationKeyTextBox.Text;
            }
        }

        private void uiPollWaitTimeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (this.selectedProfile != null)
            {
                this.selectedProfile.PollWaitTime = Convert.ToInt32(this.uiPollWaitTimeNumericUpDown.Value);
            }
        }

        private void uiRemoveProfileButton_Click(object sender, EventArgs e)
        {
            if (this.uiChannelsListView.SelectedItems.Count > 0)
            {
                this.userProfiles.Remove((UserProfile)this.uiChannelsListView.SelectedItems[0].Tag);
                this.selectedProfile = null;
                this.uiChannelsListView.Items.Remove(this.uiChannelsListView.SelectedItems[0]);
                foreach (ListViewItem item in this.uiChannelsListView.Items)
                {
                    if (this.selectedProfile == null)
                    {
                        this.selectedProfile = item.Tag as UserProfile;
                    }
                    item.Selected = true;
                    item.Focused = true;
                    break;
                }
            }
        }

        private void uiDefaultCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.SetDefaultProfile(((CheckBox)sender).Checked);
        }

        private void SetDefaultProfile(bool isChecked)
        {
            if (!this.ignoreProfileSelection)
            {
                this.defaultProfile = isChecked ? this.selectedProfile : null;
            }
        }
    }
}
