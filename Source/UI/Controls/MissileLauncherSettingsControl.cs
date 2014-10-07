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
    public partial class MissileLauncherSettingsControl : BaseSettingsControl
    {
        private string originalUsbLibraryPath;

        public MissileLauncherSettingsControl() : base()
        {
            InitializeComponent();
        }

        public MissileLauncherSettingsControl(ISettingsView parent) : base(parent)
        {
            InitializeComponent();
        }

        public override void LoadSettings()
        {
            this.uiUsbLibraryTextBox.Text = this.ParentView.Engine.Settings.MissileLauncher.DreamCheekyUsbLibPath;
            this.uiFireOnNewSubCheckBox.Checked = this.ParentView.Engine.Settings.MissileLauncher.FireOnNewSubscriber;
            this.uiFireOnReSubscriberCheckBox.Checked = this.ParentView.Engine.Settings.MissileLauncher.FireOnReSubscriber;
            this.uiFireOnNewFollowerCheckBox.Checked = this.ParentView.Engine.Settings.MissileLauncher.FireOnNewFollower;

            this.originalUsbLibraryPath = this.ParentView.Engine.Settings.MissileLauncher.DreamCheekyUsbLibPath;
        }

        public override void SaveSettings()
        {
            this.ParentView.Engine.Settings.MissileLauncher.DreamCheekyUsbLibPath = this.uiUsbLibraryTextBox.Text;
            this.ParentView.Engine.Settings.MissileLauncher.FireOnNewSubscriber = this.uiFireOnNewSubCheckBox.Checked;
            this.ParentView.Engine.Settings.MissileLauncher.FireOnReSubscriber = this.uiFireOnReSubscriberCheckBox.Checked;
            this.ParentView.Engine.Settings.MissileLauncher.FireOnNewFollower = this.uiFireOnNewFollowerCheckBox.Checked;

            if (!string.IsNullOrEmpty(this.ParentView.Engine.Settings.MissileLauncher.DreamCheekyUsbLibPath) && this.ParentView.Engine.Settings.MissileLauncher.DreamCheekyUsbLibPath != this.originalUsbLibraryPath)
            {
                this.ParentView.Engine.LoadMissileLauncherApi();
            }
        }

        private void uiBrowseButton_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.uiUsbLibraryTextBox.Text = this.openFileDialog.FileName;
            }
        }

        private void uiTestFireButton_Click(object sender, EventArgs e)
        {
            this.ParentView.Engine.TestFireMissile(this.uiUsbLibraryTextBox.Text);
        }
    }
}
