using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwitchMonitor.Core.Interfaces;
using TwitchMonitor.Core;

namespace TwitchMonitor.Controls
{
    public partial class SubscriberSettingsControl : BaseSettingsControl
    {
        //======================================================================
        //  Constructors
        //======================================================================
        public SubscriberSettingsControl() : base() { InitializeComponent(); }
        /// <summary>
        /// Constructor that initializes the view and sets up this settings control to talk back to the parent view.
        /// </summary>
        /// <param name="parent">Parent view that will house this settings control.</param>
        public SubscriberSettingsControl(ISettingsView parent) : base(parent)
        {
            InitializeComponent();

            this.uiEnableAdsCheckBox.CheckedChanged += (sender, e) => { this.ParentView.ChangeDetected(); };
            this.uiBreakLengthComboBox.SelectedIndexChanged += (sender, e) => { this.ParentView.ChangeDetected(); };
            this.uiBreakTypeComboBox.SelectedIndexChanged += (sender, e) => { this.ParentView.ChangeDetected(); };
            this.uiAutoComboBox.SelectedIndexChanged += (sender, e) => { this.ParentView.ChangeDetected(); };
            this.uiWarningTimeNumericUpDown.ValueChanged += (sender, e) => { this.ParentView.ChangeDetected(); };
        }

        //======================================================================
        //  Public Methods
        //======================================================================
        /// <summary>
        /// 
        /// </summary>
        public override void LoadSettings()
        {
            this.uiEnableAdsCheckBox.Checked = this.ParentView.Engine.Settings.Ads.Enabled;
            switch(this.ParentView.Engine.Settings.Ads.Length)
            {
                case 30:  this.uiBreakLengthComboBox.SelectedIndex = 0; break;
                case 60:  this.uiBreakLengthComboBox.SelectedIndex = 1; break;
                case 90:  this.uiBreakLengthComboBox.SelectedIndex = 2; break;
                case 120: this.uiBreakLengthComboBox.SelectedIndex = 3; break;
                case 150: this.uiBreakLengthComboBox.SelectedIndex = 4; break;
                case 180:
                default:  this.uiBreakLengthComboBox.SelectedIndex = 5; break;
            }

            switch(this.ParentView.Engine.Settings.Ads.BreakType)
            {
                case AdBreakType.Manual: this.uiBreakTypeComboBox.SelectedIndex = 0; break;
                case AdBreakType.Automated: this.uiBreakTypeComboBox.SelectedIndex = 1; break;
            }
            switch(this.ParentView.Engine.Settings.Ads.Frequency)
            {
                case 10: this.uiAutoComboBox.SelectedIndex = 0; break;
                case 15: this.uiAutoComboBox.SelectedIndex = 1; break;
                case 20: this.uiAutoComboBox.SelectedIndex = 2; break;
                case 25: this.uiAutoComboBox.SelectedIndex = 3; break;
                case 30: this.uiAutoComboBox.SelectedIndex = 4; break;
                case 35: this.uiAutoComboBox.SelectedIndex = 5; break;
                case 40: this.uiAutoComboBox.SelectedIndex = 6; break;
                case 45: this.uiAutoComboBox.SelectedIndex = 7; break;
                case 50: this.uiAutoComboBox.SelectedIndex = 8; break;
                case 55: this.uiAutoComboBox.SelectedIndex = 9; break;
                case 60: 
                default: this.uiAutoComboBox.SelectedIndex = 10; break;
            }

            this.uiWarningTimeNumericUpDown.Value = this.ParentView.Engine.Settings.Ads.WarningTimeDuration;
            this.ToggleAdControls();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SaveSettings()
        {
            this.ParentView.Engine.Settings.Ads.Enabled = this.uiEnableAdsCheckBox.Checked;
            this.ParentView.Engine.Settings.Ads.Length = (this.uiBreakLengthComboBox.SelectedIndex + 1) * 30;

            switch (this.uiBreakTypeComboBox.SelectedIndex)
            {
                case 0: this.ParentView.Engine.Settings.Ads.BreakType = AdBreakType.Manual; break;
                case 1: this.ParentView.Engine.Settings.Ads.BreakType = AdBreakType.Automated; break;
            }
            switch(this.uiAutoComboBox.SelectedIndex)
            {
                case 0: this.ParentView.Engine.Settings.Ads.Frequency = 10; break;
                case 1: this.ParentView.Engine.Settings.Ads.Frequency = 15; break;
                case 2: this.ParentView.Engine.Settings.Ads.Frequency = 20; break;
                case 3: this.ParentView.Engine.Settings.Ads.Frequency = 25; break;
                case 4: this.ParentView.Engine.Settings.Ads.Frequency = 30; break;
                case 5: this.ParentView.Engine.Settings.Ads.Frequency = 35; break;
                case 6: this.ParentView.Engine.Settings.Ads.Frequency = 40; break;
                case 7: this.ParentView.Engine.Settings.Ads.Frequency = 45; break;
                case 8: this.ParentView.Engine.Settings.Ads.Frequency = 50; break;
                case 9: this.ParentView.Engine.Settings.Ads.Frequency = 55; break;
                case 10:
                default:
                    this.ParentView.Engine.Settings.Ads.Frequency = 60; break;
            }

            this.ParentView.Engine.Settings.Ads.WarningTimeDuration = Convert.ToInt64(this.uiWarningTimeNumericUpDown.Value);
        }

        //======================================================================
        //  Private Methods
        //======================================================================
        /// <summary>
        /// Event handler for when the enabled checkbox is checked or unchecked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiEnableAdsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.ToggleAdControls();
        }

        /// <summary>
        /// Enables or disables the ad controls based on whether or not the enabled checkbox is checked.
        /// </summary>
        private void ToggleAdControls()
        {
            this.uiWarningTimeNumericUpDown.Enabled =
            this.uiBreakTypeComboBox.Enabled =
            this.uiBreakLengthComboBox.Enabled =
            this.uiAutoComboBox.Enabled =
            this.uiAdWarningSecondsLabel.Enabled =
            this.uiAdLengthLabel.Enabled =
            this.uiAdWarningLabel.Enabled =
            this.uiAdTypeLabel.Enabled = this.uiEnableAdsCheckBox.Checked;
        }
    }
}
