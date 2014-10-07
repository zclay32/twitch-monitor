using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwitchMonitor.Controls;
using TwitchMonitor.Core.Types;
using TwitchMonitor.Core;
using TwitchMonitor.Core.Interfaces;

namespace TwitchMonitor.UI.Controls
{
    public partial class NewSubcriberSettingsControl : BaseSettingsControl
    {
        //private WindowSize previewWindowSize;

        public NewSubcriberSettingsControl() : base() { InitializeComponent(); }
        /// <summary>
        /// Constructor that initializes the view and sets up this settings control to talk back to the parent view.
        /// </summary>
        /// <param name="parent">Parent view that will house this settings control.</param>
        public NewSubcriberSettingsControl(ISettingsView parent) : base(parent)
        {
            InitializeComponent();
            //this.previewWindowSize = new WindowSize();
        }

        /// <summary>
        /// Loads the settings from the engine.
        /// </summary>
        public override void LoadSettings()
        {
            this.uiShowNewSubDialogCheckBox.Checked = this.ParentView.Engine.Settings.Notifications.ShowNewSubscriberNotification;
            this.uiImagePathTextBox.Text = this.ParentView.Engine.Settings.Notifications.ImagePath;
            //this.previewWindowSize = this.ParentView.Engine.Settings.Notifications.WindowSize;
            this.uiWidthNumericUpDown.Value = this.ParentView.Engine.Settings.Notifications.WindowSize.Width;
            this.uiHeightNumericUpDown.Value = this.ParentView.Engine.Settings.Notifications.WindowSize.Height;
            this.uiXNumericUpDown.Value = this.ParentView.Engine.Settings.Notifications.WindowSize.X;
            this.uiYNumericUpDown.Value = this.ParentView.Engine.Settings.Notifications.WindowSize.Y;
        }

        /// <summary>
        /// Saves the settings to the engine.
        /// </summary>
        public override void SaveSettings()
        {
            this.ParentView.Engine.Settings.Notifications.ShowNewSubscriberNotification = this.uiShowNewSubDialogCheckBox.Checked;
            this.ParentView.Engine.Settings.Notifications.ImagePath = this.uiImagePathTextBox.Text;
            //this.ParentView.Engine.Settings.Notifications.WindowSize = this.previewWindowSize;
            this.ParentView.Engine.Settings.Notifications.WindowSize.Width = Convert.ToInt32(this.uiWidthNumericUpDown.Value);
            this.ParentView.Engine.Settings.Notifications.WindowSize.Height = Convert.ToInt32(this.uiHeightNumericUpDown.Value);
            this.ParentView.Engine.Settings.Notifications.WindowSize.X = Convert.ToInt32(this.uiXNumericUpDown.Value);
            this.ParentView.Engine.Settings.Notifications.WindowSize.Y = Convert.ToInt32(this.uiYNumericUpDown.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiImagePathButton_Click(object sender, EventArgs e)
        {
            if (this.uiOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.uiImagePathTextBox.Text = this.uiOpenFileDialog.FileName;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiPreviewButton_Click(object sender, EventArgs e)
        {
            using (NewSubscriberDialog dialog = new NewSubscriberDialog())
            {
                //--------------------------------------------------------------
                //  
                //--------------------------------------------------------------
                Settings settings = new Settings();
                settings.Notifications.WindowSize.Width = Convert.ToInt32(this.uiWidthNumericUpDown.Value);
                settings.Notifications.WindowSize.Height = Convert.ToInt32(this.uiHeightNumericUpDown.Value);
                settings.Notifications.WindowSize.X = Convert.ToInt32(this.uiXNumericUpDown.Value);
                settings.Notifications.WindowSize.Y = Convert.ToInt32(this.uiYNumericUpDown.Value);
                settings.Notifications.ImagePath = this.uiImagePathTextBox.Text;
                dialog.SubscriberName = "[New Subscriber Name Here]";
                dialog.RefreshDisplay(settings);
                dialog.Start();
                dialog.ShowDialog();

                //--------------------------------------------------------------
                //  Store the size of the preview dialog.
                //--------------------------------------------------------------
                this.uiWidthNumericUpDown.Value = dialog.Width;
                this.uiHeightNumericUpDown.Value = dialog.Height;
                this.uiXNumericUpDown.Value = dialog.Location.X;
                this.uiYNumericUpDown.Value = dialog.Location.Y;
            }
        }
    }
}
