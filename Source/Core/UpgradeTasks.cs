using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;

namespace TwitchMonitor.Core
{
    public class UpgradeTasks
    {
        private Engine engine;
        private BackgroundWorker worker;

        /// <summary>
        /// Gets whether or not the upgrade tasks are still working.
        /// </summary>
        public bool IsBusy { get { return this.worker.IsBusy; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="engine"></param>
        public UpgradeTasks(Engine engine)
        {
            this.engine = engine;
            this.worker = new BackgroundWorker();
            this.worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            this.worker.WorkerReportsProgress = true;
            this.worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                this.engine.LoadingView.DisplayMessage(e.UserState as string);
            }
            else
            {
                this.engine.LoadingView.SetProgress(e.ProgressPercentage);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.engine.SubscriberCache != null)
            {
                this.worker.ReportProgress(0, "Updating subscriber cache. Please wait...");
                List<Subscriber> subsToRemove = new List<Subscriber>();
                int count = 1;
                foreach (Subscriber sub in this.engine.SubscriberCache.Subscribers)
                {
                    sub.Id = this.engine.GetUserId(sub.Name);

                    float percent = ((float)count / (float)this.engine.SubscriberCache.Subscribers.Count) * 100.0f;
                    this.worker.ReportProgress(Convert.ToInt32(percent));
                    count++;

                    if (sub.Id == 0)
                    {
                        subsToRemove.Add(sub);
                    }
                    Thread.Sleep(50);
                }

                this.engine.RemoveSubscribers(subsToRemove);
                this.engine.SaveSubscriberList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            if (!this.worker.IsBusy)
            {
                this.worker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Stop()
        {
            this.worker.CancelAsync();
        }
    }
}
