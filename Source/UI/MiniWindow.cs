using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwitchMonitor.Core.Interfaces;
using TwitchMonitor.Properties;
using TwitchMonitor.Core;

namespace TwitchMonitor
{
    public partial class MiniWindow : Form
    {
        private static readonly int activityItemCount = 10;
        private IView parent;

        /// <summary>
        /// Gets or sets whether or not the run button should be enabled.
        /// </summary>
        public bool RunButtonEnabled
        {
            get { return this.uiStartButton.Enabled; }
            set { this.uiStartButton.Enabled = value; }
        }

        /// <summary>
        /// Constructor that initializes this form and provides a link back to the parent form. The primary goal for this form is
        /// to mirror the information presented on the main window, just in a smaller format.
        /// </summary>
        /// <param name="parent"></param>
        public MiniWindow(IView parent)
        {
            this.parent = parent;
            InitializeComponent();

            this.uiViewersMiniViewCaptionLabel.Enabled = false;
            this.uiViewerCountMiniViewTextLabel.Text = string.Empty;

            this.uiAdTimeLabel.Text = "";
            this.uiAdTimeProgressBar.Value = 0;

            this.ToggleAdControls(false);
        }

        /// <summary>
        /// Sets whether or not the monitor is currently running.
        /// </summary>
        /// <param name="isRunning"></param>
        public void SetIsRunning(bool isRunning)
        {
            if (isRunning)
            {
                this.uiStartButton.BackgroundImage = Resources.stop;
                this.uiStatusPictureBox.BackgroundImage = Resources.on;
            }
            else
            {
                this.uiStartButton.BackgroundImage = Resources.play;
                this.uiStatusPictureBox.BackgroundImage = Resources.off;
            }
        }
        public void SetSubscriberCountText(string text) { this.uiSubscriberCountMiniViewTextLabel.Text = text; }
        public void SetFollowerCountText(string text) { this.uiFollowersCountMiniViewTextLabel.Text = text; }
        public void SetViewerCountText(long viewers, bool isOnline)
        {
            this.uiViewersMiniViewCaptionLabel.Enabled = isOnline;
            this.uiViewerCountMiniViewTextLabel.Enabled = isOnline;

            if (isOnline)
            {
                this.uiViewerCountMiniViewTextLabel.Text = viewers.ToString();
            }
            else
            {
                this.uiViewerCountMiniViewTextLabel.Text = "Offline";
            }
        }
        public void AddActivityMessage(string text)
        {
            //  If the item count is greater than the max, remove the last one.
            if (this.uiRecentActivityListBox.Items.Count > activityItemCount)
            {
                this.uiRecentActivityListBox.Items.RemoveAt(this.uiRecentActivityListBox.Items.Count - 1);
            }

            //  Add the new text at the beginning of the list.
            this.uiRecentActivityListBox.Items.Insert(0, text);
        }
        public void SetAdTimeText(string text) { this.uiAdTimeLabel.Text = text; }
        public void SetAdTimeProgress(int percent) { this.uiAdTimeProgressBar.Value = percent; }

        /// <summary>
        /// Clears the activity box of all activity.
        /// </summary>
        public void ClearActivity()
        {
            this.uiRecentActivityListBox.Items.Clear();
        }

        private void uiStartButton_Click(object sender, EventArgs e) 
        {
            this.parent.ToggleMonitoring();
        }

        private void uiMaximizeButton_Click(object sender, EventArgs e) 
        {
            this.HideWindow();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.HideWindow();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }

        public void ProcessSettings()
        {
            this.uiViewerCountMiniViewTextLabel.Visible = this.parent.Engine.Settings.MiniCast.ShowViewerCount;
            this.uiViewersMiniViewCaptionLabel.Visible = this.parent.Engine.Settings.MiniCast.ShowViewerCount;
        }

        private void HideWindow()
        {
            this.parent.ShowMainWindow();
            this.Hide();
        }

        /// <summary>
        /// Runs an ad break.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiRunAdButton_Click(object sender, EventArgs e)
        {
            this.parent.RunAdBreak();
        }

        /// <summary>
        /// Toggles the visibility of the ad controls.
        /// </summary>
        /// <param name="visible"></param>
        public void ToggleAdControls(bool visible)
        {
            this.uiAdTimeLabel.Visible = visible;
            this.uiAdTimeProgressBar.Visible = visible;
            this.uiRunAdButton.Visible = visible;
        }
    }
}
