using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TwitchMonitor.Controls
{
    public partial class QuickViewControl : UserControl
    {
        /// <summary>
        /// Gets or sets the number of activity messages to keep displayed.
        /// </summary>
        public int ActivityHistoryCount { get; set; }

        /// <summary>
        /// Default constructor that initializes the view.
        /// </summary>
        public QuickViewControl()
        {
            InitializeComponent();

            //------------------------------------------------------------------
            //  Set default values for properties.
            //------------------------------------------------------------------
            this.ActivityHistoryCount = 10;
            this.uiSubscriberCountMiniViewTextLabel.Text = string.Empty;
            this.uiFollowersCountMiniViewTextLabel.Text = string.Empty;
            this.uiViewerCountMiniViewTextLabel.Text = string.Empty;
        }

        /// <summary>
        /// Updates the number of subscribers.
        /// </summary>
        /// <param name="totalSubscribers"></param>
        /// <param name="newSubscribers"></param>
        public void UpdateSubscribers(long totalSubscribers, long newSubscribers)
        {
            this.uiSubscriberCountMiniViewTextLabel.Text = this.GetCountString(totalSubscribers, newSubscribers);
        }

        /// <summary>
        /// Updates the number of followers.
        /// </summary>
        /// <param name="totalFollowers"></param>
        /// <param name="newFollowers"></param>
        public void UpdateFollowers(long totalFollowers, long newFollowers)
        {
            this.uiFollowersCountMiniViewTextLabel.Text = this.GetCountString(totalFollowers, newFollowers);
        }

        /// <summary>
        /// Updates the number of viewers.
        /// </summary>
        /// <param name="totalViewers"></param>
        public void UpdateViewers(long totalViewers)
        {
            this.uiViewerCountMiniViewTextLabel.Text = this.GetCountString(totalViewers, 0);
        }

        /// <summary>
        /// Updates 
        /// </summary>
        /// <param name="enable"></param>
        public void EnableSubscriberCount(bool enable)
        {
            this.uiSubscribersMiniViewCaptionLabel.Enabled = enable;
            this.uiSubscriberCountMiniViewTextLabel.Enabled = enable;
        }

        /// <summary>
        /// Adds a new activity message to the list.
        /// </summary>
        /// <param name="message"></param>
        public void AddActivityMessage(string message)
        {
            //------------------------------------------------------------------
            //  If the item count is greater than the max, remove the last one.
            //------------------------------------------------------------------
            if (this.uiRecentActivityListBox.Items.Count > this.ActivityHistoryCount)
            {
                this.uiRecentActivityListBox.Items.RemoveAt(this.uiRecentActivityListBox.Items.Count - 1);
            }

            //------------------------------------------------------------------
            //  Add the new text at the beginning of the list.
            //------------------------------------------------------------------
            this.uiRecentActivityListBox.Items.Insert(0, message);
        }

        /// <summary>
        /// Clears all the activity messages.
        /// </summary>
        public void ClearMessages()
        {
            this.uiRecentActivityListBox.Items.Clear();
        }

        /// <summary>
        /// Gets a string representation of the specified values to be displayed.
        /// </summary>
        /// <param name="total">The total number of items.</param>
        /// <param name="newCount">The new number of items.</param>
        /// <returns>A string representation of the specified values to be displayed.</returns>
        private string GetCountString(long total, long newCount)
        {
            if (newCount > 0)
            {
                return string.Format("{0} ({1} New)", total, newCount);
            }
            return total.ToString();
        }
    }
}
