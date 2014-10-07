using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using TwitchMonitor.Core;
using System.IO;

namespace TwitchMonitor.UI
{
    public partial class NewSubscriberDialog : Form
    {
        private BackgroundWorker worker;

        public string SubscriberName 
        {
            get { return this.label1.Text; }
            set { this.label1.Text = value; }
        }

        public NewSubscriberDialog()
        {
            InitializeComponent();

            this.worker = new BackgroundWorker();
            this.worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);

            this.ToggleVisibility(false);
        }

        /// <summary>
        /// Refreshses the display of the notification dialog to match the information specified in the settings.
        /// </summary>
        /// <param name="settings"></param>
        public void RefreshDisplay(Settings settings)
        {
            try
            {
                //--------------------------------------------------------------
                //  Set the image to display.
                //--------------------------------------------------------------
                if (File.Exists(settings.Notifications.ImagePath))
                {
                    FileStream stream = new FileStream(settings.Notifications.ImagePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    this.pictureBox1.Image = Image.FromStream(stream);
                    stream.Close();
                }

                //--------------------------------------------------------------
                //  Set the size and position.
                //--------------------------------------------------------------
                this.Width = settings.Notifications.WindowSize.Width;
                this.Height = settings.Notifications.WindowSize.Height;
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(settings.Notifications.WindowSize.X, settings.Notifications.WindowSize.Y);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Starts the notification dialog's worker so it can begin processing messages from the engine.
        /// </summary>
        public void Start()
        {
            this.ToggleVisibility(true);
            if (!this.worker.IsBusy)
            {
                this.worker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Toggles the visibility of the controls in the dialog.
        /// </summary>
        /// <param name="show"></param>
        private void ToggleVisibility(bool show)
        {
            if (show)
            {
                this.tableLayoutPanel1.Show();
            }
            else
            {
                this.tableLayoutPanel1.Hide();
            }

            this.Update();
        }

        /// <summary>
        /// The worker has finished running
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.ToggleVisibility(false);
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (timer.ElapsedMilliseconds <= 15000)
            {
                Thread.Sleep(100);
            }
        }
    }
}
