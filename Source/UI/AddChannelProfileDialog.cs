using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwitchMonitor.Core;
using TwitchMonitor.Core.Types;

namespace TwitchMonitor.UI
{
    public partial class AddChannelProfileDialog : Form
    {
        private BackgroundWorker worker;
        private Engine engine;

        public ProfileJsonPacket ProfileJsonPacket { get; private set; }

        public AddChannelProfileDialog()
        {
            InitializeComponent();
        }
        public AddChannelProfileDialog(Engine engine) : this()
        {
            this.engine = engine;
            this.worker = new BackgroundWorker();
            this.worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);

            this.uiChannelNameTextBox.TextChanged += (sender, e) => { this.uiOkButton.Enabled = !string.IsNullOrEmpty(this.uiChannelNameTextBox.Text); };
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.uiOkButton.Enabled = true;
            this.uiChannelNameTextBox.Enabled = true;

            if (this.ProfileJsonPacket != null)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                this.uiVerifyingLabel.Text = string.Format("Channel not found: {0}", this.uiChannelNameTextBox.Text);
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.ProfileJsonPacket = this.engine.GetProfileJsonInfo(this.uiChannelNameTextBox.Text);
            }
            catch (Exception)
            {
                this.ProfileJsonPacket = null; 
            }
        }

        private void uiOkButton_Click(object sender, EventArgs e)
        {
            this.uiOkButton.Enabled = false;
            this.uiChannelNameTextBox.Enabled = false;
            this.ProfileJsonPacket = null;
            this.uiVerifyingLabel.Text = "Verifying...";
            this.worker.RunWorkerAsync();
        }
    }
}
