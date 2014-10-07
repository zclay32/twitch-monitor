using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using TwitchMonitor.Core.Types;
using TwitchMonitor.Properties;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;
using TwitchMonitor.Core.Interfaces;

namespace TwitchMonitor
{
    public class Updater
    {
        private string downloadUrl;
        private BackgroundWorker worker;
        private bool isUpdateAvailable;
        private IView view;

        public Updater(IView view)
        {
            this.view = view;
            this.worker = new BackgroundWorker();
            this.worker.WorkerReportsProgress = true;
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            this.worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.isUpdateAvailable)
            {
                this.view.ShowUpdateAvailableMessage();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.isUpdateAvailable = this.IsUpdateAvailable((bool)e.Argument);
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartCheckForUpdate(bool newCheck)
        {
            if (!this.worker.IsBusy)
            {
                this.isUpdateAvailable = false;
                this.worker.RunWorkerAsync(newCheck);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void StopCheckForUpdate()
        {
            if (this.worker.IsBusy)
            {
                this.worker.CancelAsync();
            }
        }

        /// <summary>
        /// Checks to see if an update is available.
        /// </summary>
        /// <returns>True if a newer version is available; false otherwise.</returns>
        public bool IsUpdateAvailable(bool newCheck)
        {
            //------------------------------------------------------------------
            //  If we're not running a new check, return the cached response.
            //------------------------------------------------------------------
            if (!newCheck)
            {
                return this.isUpdateAvailable;
            }

            WebRequest request = WebRequest.Create("https://raw.githubusercontent.com/zclay32/twitch-monitor/master/Installer/latest.json");
            bool newerVersionAvailable = false;

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    LatestVersionJson responseJson = Newtonsoft.Json.JsonConvert.DeserializeObject<LatestVersionJson>(reader.ReadToEnd());

                    //----------------------------------------------------------
                    //  Get the version of this application and see if the
                    // latest is newer.
                    //----------------------------------------------------------
                    Assembly currentApp = Assembly.GetExecutingAssembly();
                    FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(currentApp.Location);
                    Version currentAppVersion = new Version(fvi.FileVersion);
                    Version latestVersion = new Version(responseJson.Version);
                    if (latestVersion > currentAppVersion)
                    {
                        newerVersionAvailable = true;
                        this.downloadUrl = responseJson.DownloadUrl;
                    }
                }
            }
            catch (Exception) { }
            return newerVersionAvailable;
        }

        /// <summary>
        /// Updates the Twitch Monitor to the latest version.
        /// </summary>
        public void PerformUpdate()
        {
            //------------------------------------------------------------------
            // Download the update.
            //------------------------------------------------------------------
            try
            {
                string tempFile = Path.GetTempFileName();
                string updateFile = Path.Combine(Path.GetTempPath(), "twitchMonitorSetup.exe");
                WebClient client = new WebClient();
                client.DownloadFile(this.downloadUrl, tempFile);
                if (File.Exists(updateFile))
                {
                    File.Delete(updateFile);
                }
                File.Move(tempFile, updateFile);
                File.Delete(tempFile);

                //------------------------------------------------------------------
                // Launch the installer.
                //------------------------------------------------------------------
                ProcessStartInfo startInfo = new ProcessStartInfo(updateFile);
                startInfo.Verb = "runas";
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                Process process = Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Failed to update:{0}{1}", Environment.NewLine, ex.Message));
            }
        }
    }
}
