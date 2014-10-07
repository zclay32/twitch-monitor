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
using System.IO;

namespace TwitchMonitor.UI.Controls
{
    public partial class FileOutputSettingsControl : BaseSettingsControl
    {
        /// <summary>
        /// 
        /// </summary>
        public FileOutputSettingsControl() : base()
        {
            this.InitializeComponent();
            this.Initialize();
        }

        public FileOutputSettingsControl(ISettingsView parent) : base(parent)
        {
            this.InitializeComponent();
            this.Initialize();
        }

        private void Initialize()
        {
            this.uiFollowersCheckBox.CheckedChanged += (sender, e) => { this.ToggleControls(); };
            this.uiSubscribersCheckBox.CheckedChanged += (sender, e) => { this.ToggleControls(); };
            this.uiViewersCheckBox.CheckedChanged += (sender, e) => { this.ToggleControls(); };
            this.uiAdWarningCheckBox.CheckedChanged += (sender, e) => { this.ToggleControls(); };

            this.uiFollowersFileBrowseButton.Click += (sender, e) => { this.BrowseForFile(this.uiFollowersFilePathTextBox); };
            this.uiSubscribersFileBrowseButton.Click += (sender, e) => { this.BrowseForFile(this.uiSubscribersFilePathTextBox); };
            this.uiViewerCountFileBrowseButton.Click += (sender, e) => { this.BrowseForFile(this.uiViewerCountFilePathTextBox); };
            this.uiDiceRollButton.Click += (sender, e) => { this.BrowseForFile(this.uiDiceRollTextBox); };
            this.uiAdWarningButton.Click += (sender, e) => { this.BrowseForFile(this.uiAdWarningTextBox); };
        }

        private void ToggleControls()
        {
            this.uiFollowersCountNumericUpDown.Enabled = this.uiFollowersCheckBox.Checked;
            this.uiFollowersFilePathTextBox.Enabled = this.uiFollowersCheckBox.Checked;
            this.uiFollowersFileBrowseButton.Enabled = this.uiFollowersCheckBox.Checked;
            this.uiClearFollowersOnStartupCheckBox.Enabled = this.uiFollowersCheckBox.Checked;

            this.uiSubscribersCountNumericUpDown.Enabled = this.uiSubscribersCheckBox.Checked;
            this.uiSubscribersFilePathTextBox.Enabled = this.uiSubscribersCheckBox.Checked;
            this.uiSubscribersFileBrowseButton.Enabled = this.uiSubscribersCheckBox.Checked;
            this.uiClearSubscribersOnStartupCheckBox.Enabled = this.uiSubscribersCheckBox.Checked;

            this.uiViewerCountFilePathTextBox.Enabled = this.uiViewersCheckBox.Checked;
            this.uiViewerCountFileBrowseButton.Enabled = this.uiViewersCheckBox.Checked;

            this.uiAdWarningTextBox.Enabled = this.uiAdWarningCheckBox.Checked;
            this.uiAdWarningButton.Enabled = this.uiAdWarningCheckBox.Checked;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void LoadSettings()
        {
            this.uiFollowersCheckBox.Checked = this.ParentView.Engine.Settings.FileOutput.Followers.Enabled;
            this.uiSubscribersCheckBox.Checked = this.ParentView.Engine.Settings.FileOutput.Subscribers.Enabled;
            this.uiViewersCheckBox.Checked = this.ParentView.Engine.Settings.FileOutput.ViewerCount.Enabled;
            this.uiAdWarningCheckBox.Checked = this.ParentView.Engine.Settings.FileOutput.AdWarningOutput.Enabled;

            this.uiFollowersCountNumericUpDown.Value = this.ParentView.Engine.Settings.FileOutput.Followers.ItemCount;
            this.uiSubscribersCountNumericUpDown.Value = this.ParentView.Engine.Settings.FileOutput.Subscribers.ItemCount;

            this.uiClearFollowersOnStartupCheckBox.Checked = this.ParentView.Engine.Settings.FileOutput.Followers.ClearListOnStartup;
            this.uiClearSubscribersOnStartupCheckBox.Checked = this.ParentView.Engine.Settings.FileOutput.Subscribers.ClearListOnStartup;

            this.uiFollowersFilePathTextBox.Text = this.ParentView.Engine.Settings.FileOutput.Followers.FilePath;
            this.uiSubscribersFilePathTextBox.Text = this.ParentView.Engine.Settings.FileOutput.Subscribers.FilePath;
            this.uiViewerCountFilePathTextBox.Text = this.ParentView.Engine.Settings.FileOutput.ViewerCount.FilePath;
            this.uiDiceRollTextBox.Text = this.ParentView.Engine.Settings.FileOutput.DiceRollOutput.FilePath;
            this.uiAdWarningTextBox.Text = this.ParentView.Engine.Settings.FileOutput.AdWarningOutput.FilePath;

            this.ToggleControls();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SaveSettings()
        {
            this.ParentView.Engine.Settings.FileOutput.Followers.Enabled = this.uiFollowersCheckBox.Checked;
            this.ParentView.Engine.Settings.FileOutput.Subscribers.Enabled = this.uiSubscribersCheckBox.Checked;
            this.ParentView.Engine.Settings.FileOutput.ViewerCount.Enabled = this.uiViewersCheckBox.Checked;
            this.ParentView.Engine.Settings.FileOutput.AdWarningOutput.Enabled = this.uiAdWarningCheckBox.Checked;

            this.ParentView.Engine.Settings.FileOutput.Followers.ItemCount = Convert.ToInt32(this.uiFollowersCountNumericUpDown.Value);
            this.ParentView.Engine.Settings.FileOutput.Subscribers.ItemCount = Convert.ToInt32(this.uiSubscribersCountNumericUpDown.Value);

            this.ParentView.Engine.Settings.FileOutput.Followers.ClearListOnStartup = this.uiClearFollowersOnStartupCheckBox.Checked;
            this.ParentView.Engine.Settings.FileOutput.Subscribers.ClearListOnStartup = this.uiClearSubscribersOnStartupCheckBox.Checked;

            this.ParentView.Engine.Settings.FileOutput.Followers.FilePath = this.uiFollowersFilePathTextBox.Text;
            this.ParentView.Engine.Settings.FileOutput.Subscribers.FilePath = this.uiSubscribersFilePathTextBox.Text;
            this.ParentView.Engine.Settings.FileOutput.ViewerCount.FilePath = this.uiViewerCountFilePathTextBox.Text;
            this.ParentView.Engine.Settings.FileOutput.DiceRollOutput.FilePath = this.uiDiceRollTextBox.Text;
            this.ParentView.Engine.Settings.FileOutput.AdWarningOutput.FilePath = this.uiAdWarningTextBox.Text;
        }

        /// <summary>
        /// Helper method for browsing for an output file.
        /// </summary>
        /// <param name="currentFilePath"></param>
        /// <returns></returns>
        private void BrowseForFile(TextBox textBox)
        {
            string currentFilePath = textBox.Text;
            try
            {
                if (File.Exists(currentFilePath))
                {
                    this.uiSaveFileDialog.FileName = currentFilePath;
                }
            }
            catch (Exception) { /* Ignore any exception thrown. */}

            if (this.uiSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = this.uiSaveFileDialog.FileName;
            }
        }
    }
}
