using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwitchMonitor.Core;
using TwitchMonitor.Core.Interfaces;

namespace TwitchMonitor.UI
{
    public partial class UpgradeTasksDialog : Form, ILoadingView
    {
        public Engine Engine { get; set; }

        public UpgradeTasksDialog()
        {
            InitializeComponent();
        }

        public void DisplayMessage(string message)
        {
            this.uiStatusLabel.Text = message;
        }

        public void SetProgress(int percent)
        {
            this.uiStatusProgressBar.Style = ProgressBarStyle.Continuous;
            this.uiStatusProgressBar.Value = percent;
        }

        protected override void OnShown(EventArgs e)
        {
            if (this.Engine != null)
            {
                this.Engine.UpgradeTasks.Start();

                while (this.Engine.UpgradeTasks.IsBusy)
                {
                    Application.DoEvents();
                }
            }
            this.Close();
        }
    }
}
