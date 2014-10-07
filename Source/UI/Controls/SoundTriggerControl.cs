using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwitchMonitor.Core;
using TwitchMonitor.Controls;
using TwitchMonitor.Core.Interfaces;
using System.IO;

namespace TwitchMonitor.UI.Controls
{
    public partial class SoundTriggerControl : BaseSettingsControl
    {
        public SoundTriggerControl() : base()
        {
            this.InitializeComponent();
            this.Initialize(null);
        }

        public SoundTriggerControl(ISettingsView parent) : base(parent)
        {
            this.InitializeComponent();
            this.Initialize(parent);            
        }

        public void Initialize(ISettingsView parent)
        {
            this.ParentView = parent;

            this.uiPlaySoundFileRadioButton.CheckedChanged += (sender, e) => { this.ToggleRadioButtonControls(); };
            this.uiPlaySoundDirectoryRadioButton.CheckedChanged += (sender, e) => { this.ToggleRadioButtonControls(); };
            this.uiNoSoundRadioButton.CheckedChanged += (sender, e) => { this.ToggleRadioButtonControls(); };

            this.uiSoundDirectoryTextBox.TextChanged += (sender, e) => { this.ParentView.ChangeDetected(); };
            this.uiSoundFileTextBox.TextChanged += (sender, e) => { this.ParentView.ChangeDetected(); };
            this.uiVolumeTrackBar.ValueChanged += (sender, e) => { this.ParentView.ChangeDetected(); };

            this.ToggleRadioButtonControls();
        }

        //  Public Properties
        public PlaySoundType SoundType
        {
            get
            {
                if (this.uiPlaySoundDirectoryRadioButton.Checked)
                {
                    return PlaySoundType.FromDirectory;
                }
                else if (this.uiPlaySoundFileRadioButton.Checked)
                {
                    return PlaySoundType.FromFile;
                }
                return PlaySoundType.None;
            }
            set
            {
                switch (value)
                {
                    case PlaySoundType.FromDirectory:
                        this.uiPlaySoundDirectoryRadioButton.Checked = true;
                        break;

                    case PlaySoundType.FromFile:
                        this.uiPlaySoundFileRadioButton.Checked = true;
                        break;

                    case PlaySoundType.None:
                    default:
                        this.uiNoSoundRadioButton.Checked = true;
                        break;
                }
            }
        }

        public string SoundFilePath
        {
            get { return this.uiSoundFileTextBox.Text; }
            set { this.uiSoundFileTextBox.Text = value; }
        }

        public string SoundDirectoryPath
        {
            get { return this.uiSoundDirectoryTextBox.Text; }
            set { this.uiSoundDirectoryTextBox.Text = value; }
        }

        public int VolumeLevel
        {
            get { return this.uiVolumeTrackBar.Value; }
            set { this.uiVolumeTrackBar.Value = value; }
        }

        public string Title
        {
            get { return this.uiGroupBox.Text; }
            set { this.uiGroupBox.Text = value; }
        }

        public void RefreshFields()
        {
            this.ToggleRadioButtonControls();
            this.UpdateVolumeStatusLabel();
        }

        /// <summary>
        /// Toggles the UI controls based on which radio button is currently selected.
        /// </summary>
        private void ToggleRadioButtonControls()
        {
            this.uiSoundDirectoryTextBox.Enabled = this.uiPlaySoundDirectoryRadioButton.Checked;
            this.uiSoundDirectorySearchButton.Enabled = this.uiPlaySoundDirectoryRadioButton.Checked;
            this.uiTestSoundDirButton.Enabled = this.uiPlaySoundDirectoryRadioButton.Checked;

            this.uiSoundFileTextBox.Enabled = this.uiPlaySoundFileRadioButton.Checked;
            this.uiSoundFileSearchButton.Enabled = this.uiPlaySoundFileRadioButton.Checked;
            this.uiTestSoundFileButton.Enabled = this.uiPlaySoundFileRadioButton.Checked;

            this.uiVolumeLabel.Enabled = this.uiPlaySoundDirectoryRadioButton.Checked || this.uiPlaySoundFileRadioButton.Checked;
            this.uiVolumeTrackBar.Enabled = this.uiPlaySoundDirectoryRadioButton.Checked || this.uiPlaySoundFileRadioButton.Checked;
            this.uiVolumeValueLabel.Enabled = this.uiPlaySoundDirectoryRadioButton.Checked || this.uiPlaySoundFileRadioButton.Checked;
        }

        /// <summary>
        /// Updates the volume label status indicating the currently selected volume level.
        /// </summary>
        private void UpdateVolumeStatusLabel()
        {
            if (this.uiVolumeTrackBar.Value == 0)
            {
                this.uiVolumeValueLabel.Text = "Off";
            }
            else
            {
                this.uiVolumeValueLabel.Text = string.Format("{0} out of 10", this.uiVolumeTrackBar.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiVolumeTrackBar_Scroll(object sender, EventArgs e)
        {
            this.UpdateVolumeStatusLabel();
        }

        private void uiVolumeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (!this.ParentView.IsLoading)
            {
                this.ParentView.Engine.SoundPlayer.PlaySample(this.uiVolumeTrackBar.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiSoundDirectorySearchButton_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.uiSoundDirectoryTextBox.Text = this.folderBrowserDialog.SelectedPath;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiSoundFileSearchButton_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.uiSoundFileTextBox.Text = this.openFileDialog.FileName;
            }
        }

        /// <summary>
        /// Event handler for when the button is clicked to test playing a sound for a directory of sound files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiTestSoundDirButton_Click(object sender, EventArgs e)
        {
            string path = this.uiSoundDirectoryTextBox.Text;
            if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
            {
                this.PlayTestSound(PlaySoundType.FromDirectory, path);
            }
        }

        /// <summary>
        /// Event handler for when the button is clicked to test playing a sound for a single file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiTestSoundFileButton_Click(object sender, EventArgs e)
        {
            string path = this.uiSoundFileTextBox.Text;
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                this.PlayTestSound(PlaySoundType.FromFile, path);
            }
        }

        /// <summary>
        /// Plays a test sound for a specific file or from a directory of sound files.
        /// </summary>
        /// <param name="soundType"></param>
        /// <param name="path"></param>
        private void PlayTestSound(PlaySoundType soundType, string path)
        {
            SoundPlaySettings tempSettings = new SoundPlaySettings();
            tempSettings.PlaySoundType = soundType;
            switch (soundType)
            {
                case PlaySoundType.FromDirectory:
                    tempSettings.SoundDirectory = path;
                    break;

                case PlaySoundType.FromFile:
                    tempSettings.SoundFile = path;
                    break;

                default:
                    return;
            }
            
            tempSettings.SoundVolume = this.uiVolumeTrackBar.Value;
            this.ParentView.Engine.SoundPlayer.ScheduleSound(1, tempSettings);
        }
    }
}
