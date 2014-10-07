using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using TwitchMonitor.Core;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace TwitchMonitor.UI
{
    public partial class DiceRollDialog : Form
    {
        private BackgroundWorker worker;
        private BackgroundWorker messageWorker;
        private BackgroundWorker flashWorker;
        private Queue messageQueue;
        private Engine engine;
        private Random random;
        private string cachedOutput;
        private bool processingMessages;
        private Stopwatch flashTimer;

        public DiceRollDialog()
        {
            InitializeComponent();
        }

        public DiceRollDialog(Engine engine) : this()
        {
            this.engine = engine;
            this.messageQueue = Queue.Synchronized(new Queue());
            this.random = new Random();
            this.flashTimer = new Stopwatch();

            this.worker = new BackgroundWorker();
            this.worker.WorkerSupportsCancellation = true;
            this.worker.WorkerReportsProgress = true;
            this.worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            this.worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);

            this.messageWorker = new BackgroundWorker();
            this.messageWorker.WorkerReportsProgress = true;
            this.messageWorker.WorkerSupportsCancellation = true;
            this.messageWorker.DoWork += new DoWorkEventHandler(messageWorker_DoWork);
            this.messageWorker.ProgressChanged += new ProgressChangedEventHandler(messageWorker_ProgressChanged);
            this.messageWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(messageWorker_RunWorkerCompleted);

            this.flashWorker = new BackgroundWorker();
            this.flashWorker.WorkerReportsProgress = true;
            this.flashWorker.WorkerSupportsCancellation = true;
            this.flashWorker.DoWork += new DoWorkEventHandler(flashWorker_DoWork);
            this.flashWorker.ProgressChanged += new ProgressChangedEventHandler(flashWorker_ProgressChanged);
            this.flashWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(flashWorker_RunWorkerCompleted);

            this.messageWorker.RunWorkerAsync();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.messageWorker.CancelAsync();
            this.Stop();

            base.OnClosing(e);
        }

        void flashWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DisplayOutput(this.cachedOutput);
        }

        void flashWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.uiOutputLabel.Text))
            {
                this.DisplayOutput(this.cachedOutput);
            }
            else
            {
                this.DisplayOutput(string.Empty);
            }
        }

        void flashWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.flashTimer.Start();
            //bool showing = true;
            while (!this.flashWorker.CancellationPending && this.flashTimer.ElapsedMilliseconds <= 5000)
            {
                this.flashWorker.ReportProgress(0);
                Thread.Sleep(500);
                /*
                if (showing)
                {
                    Thread.Sleep(300);
                }
                else
                {
                    Thread.Sleep(500);
                }
                showing = !showing;*/
            }
        }

        private void DisplayOutput(string text)
        {
            this.uiOutputLabel.Text = text;
            if (!string.IsNullOrEmpty(this.engine.Settings.FileOutput.DiceRollOutput.FilePath))
            {
                File.WriteAllText(this.engine.Settings.FileOutput.DiceRollOutput.FilePath, text);
            }
        }

        void messageWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        void messageWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!this.processingMessages)
            {
                this.processingMessages = true;
                if (this.messageQueue.Count > 0)
                {
                    int count = this.messageQueue.Count;
                    while (count > 1)
                    {
                        count--;
                        this.messageQueue.Dequeue();
                    }
                    this.DisplayOutput(this.messageQueue.Dequeue() as string);
                }
                this.processingMessages = false;
            }
        }

        void messageWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!this.messageWorker.CancellationPending)
            {
                this.messageWorker.ReportProgress(0);
                Thread.Sleep(10);
            }
        }

        private void FlashOutput()
        {
            this.cachedOutput = this.uiOutputLabel.Text;
            if (this.flashWorker.IsBusy)
            {
                this.flashTimer.Reset();
                this.flashTimer.Start();
            }
            else
            {
                this.flashWorker.RunWorkerAsync();
            }
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.ToggleControls(false);
            this.FlashOutput();
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            int sleepIncrement = 10;
            int sleepAmount = 10;
            timer.Start();
            while (!this.worker.CancellationPending && timer.ElapsedMilliseconds <= 10000)
            {
                this.messageQueue.Enqueue(this.GetRandomName());
                Thread.Sleep(sleepAmount);
                sleepAmount += sleepIncrement;
            }
        }

        private void Start()
        {
            if (!this.worker.IsBusy)
            {
                this.ToggleControls(true);
                this.worker.RunWorkerAsync();
            }
        }

        private void Stop(bool resetFlashWorker = true)
        {
            if (this.worker.IsBusy)
            {
                this.worker.CancelAsync();
            }

            if (resetFlashWorker && this.flashWorker.IsBusy)
            {
                this.flashWorker.CancelAsync();
            }
        }

        /// <summary>
        /// Gets a random subscriber name from the list of subscribers.
        /// </summary>
        /// <returns></returns>
        private string GetRandomName()
        {
            int randomIndex = this.random.Next(0, this.engine.SubscriberCache.Subscribers.Count);
            if (randomIndex < this.engine.SubscriberCache.Subscribers.Count)
            {
                return this.engine.SubscriberCache.Subscribers[randomIndex].Name;
            }
            return string.Empty;
        }

        private void uiRollButton_Click(object sender, EventArgs e)
        {
            this.Stop(false);
            this.DisplayOutput(this.GetRandomName());
            this.FlashOutput();
        }

        private void uiWheelSpinButton_Click(object sender, EventArgs e)
        {
            this.Stop();
            this.Start();
        }

        private void ToggleControls(bool running)
        {
            this.uiInstantRollButton.Enabled = !running;
            this.uiWheelSpinButton.Enabled = !running;
        }
    }
}
