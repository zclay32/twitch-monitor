using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace TwitchMonitor.UI
{
    public partial class WaitingDialog : Form
    {
        private MainWindow parentView;
        private BackgroundWorker worker;
        private bool newUpdateAvailable;
        private bool windowClosing;

        public WaitingDialog()
        {
            InitializeComponent();
        }
        public WaitingDialog(MainWindow parent) : this()
        {
            this.parentView = parent;
            this.windowClosing = false;

            this.worker = new BackgroundWorker();
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Hide();
            if (!e.Cancelled && !this.windowClosing)
            {
                this.parentView.PromptUserForNewUpdate(this.newUpdateAvailable);
            }
            this.Close();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(5000);
            this.newUpdateAvailable = this.parentView.Updater.IsUpdateAvailable(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!this.windowClosing)
            {
                this.windowClosing = true;
                if (this.worker.IsBusy)
                {
                    this.worker.CancelAsync();
                }
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!this.worker.IsBusy)
            {
                this.worker.RunWorkerAsync();
            }
        }
    }
}
