using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using TwitchMonitor.Core.Types;

namespace TwitchMonitor.Core
{
    public class AdRunner
    {
        private Engine engine;
        private AlarmClock alarm;
        private bool promptedAdWarning;

        private enum AdMessageType
        {
            NoAds,
            ShowBreak,
            ShowAboutToTakeBreak,
            HideAboutToTakeBreak
        }

        public AdRunner(Engine engine)
        {
            this.engine = engine;
            this.alarm = new AlarmClock();
            this.alarm.OnTick += new AlarmClockEventHandler(alarm_OnTick);
            this.alarm.OnAlarm += new AlarmClockEventHandler(alarm_OnAlarm);
        }

        /// <summary>
        /// Event handler for when the alarm clock triggers an alarm event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void alarm_OnAlarm(object sender, AlarmClockEventArgs e)
        {
            if (this.promptedAdWarning)
            {
                this.engine.View.HideAboutToTakeAdBreakMessage();
                this.promptedAdWarning = false;
            }
            this.engine.View.ShowAdBreakMessage();
            this.engine.RunAdBreak();
        }

        /// <summary>
        /// Event handler for when the alarm clock's timer ticks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void alarm_OnTick(object sender, AlarmClockEventArgs e)
        {
            AdTimeRemaining adTime = new AdTimeRemaining();
            adTime.TimeRemaining = new TimeSpan(0, 0, 0, 0, e.TimeRemaining);
            double progress = ((double)e.TimeRemaining / (double)e.TotalTime * 100.0);
            adTime.Percent = Convert.ToInt32(progress);
            this.engine.View.UpdateAdTimeRemaining(adTime);

            if (!this.promptedAdWarning && this.engine.Settings.Ads.WarningTimeDuration > 0 && e.TimeRemaining > 0 && e.TimeRemaining < (int)this.engine.Settings.Ads.WarningTimeDuration * 1000)
            {
                this.promptedAdWarning = true;
                this.engine.View.ShowAboutToTakeAdBreakMessage();
            }
        }

        /*
        /// <summary>
        /// Event handler for processing thread messages that need to display something in the UI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            AdMessageType messageType = (AdMessageType)e.UserState;

            if (messageType == AdMessageType.NoAds)
            {
                this.engine.View.ShowNoAds();
            }
            else
            {
                switch (messageType)
                {
                    case AdMessageType.ShowAboutToTakeBreak:
                        this.engine.View.ShowAboutToTakeAdBreakMessage();
                        break;

                    case AdMessageType.HideAboutToTakeBreak:
                        this.engine.View.HideAboutToTakeAdBreakMessage();
                        break;
                }
            }
        }*/

        /// <summary>
        /// Runs an ad immediately.
        /// </summary>
        public void RunAdNow()
        {
            if (this.alarm.Running)
            {
                this.alarm.Trigger();
            }
        }

        /*
        /// <summary>
        /// Event handler for when the worker finishes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        /// <summary>
        /// Main worker thread that checks to see if ads should be run.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool promptedWarning = false;
            bool promptedIrcMessage = false;

            this.timer.Start();
            while (!this.worker.CancellationPending)
            {
                if (this.engine.IsStreamOnline && this.engine.IsPartnered)
                {
                    long frequencyMilliseconds = this.engine.Settings.Ads.Frequency * 60 * 1000;
                    long ellapsedMilliseconds = this.timer.IsRunning ? this.timer.ElapsedMilliseconds : frequencyMilliseconds;
                    long promptWarningMilliseconds = frequencyMilliseconds - (this.engine.Settings.Ads.WarningTimeDuration * 1000);
                    bool needToWarnUser = this.engine.Settings.Ads.WarningTimeDuration > 0;

                    AdTimeRemaining adTimeRemaining = new AdTimeRemaining();
                    double percent = 100.0f * (double)(frequencyMilliseconds - ellapsedMilliseconds) / (double)frequencyMilliseconds;
                    adTimeRemaining.Percent = Convert.ToInt32(percent);
                    adTimeRemaining.TimeRemaining = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(frequencyMilliseconds - ellapsedMilliseconds));

                    //----------------------------------------------------------
                    //  Check to see if we need to send the IRC chat message
                    //  that we're taking a break.
                    //----------------------------------------------------------
                    if (this.engine.Settings.Irc.ShowNotificationsInChat && !promptedIrcMessage)
                    {

                    }

                    //--------------------------------------------------------------
                    //  Check to see if we need to run an ad.
                    //--------------------------------------------------------------
                    if (ellapsedMilliseconds >= frequencyMilliseconds)
                    {
                        this.timeValues.Enqueue(new AdTimeRemaining() { Percent = 0, TimeRemaining = new TimeSpan(0) });

                        promptedWarning = false;

                        this.timer.Stop();

                        //------------------------------------------------------
                        //  If we're running ads manuall, wait here until the
                        //  user is ready to run the ad.
                        //------------------------------------------------------
                        if (this.engine.Settings.Ads.BreakType == AdBreakType.Manual)
                        {
                            this.waitingToRunAd = true;
                            while (!this.worker.CancellationPending && !this.readyToRunAd)
                            {
                                Thread.Sleep(100);
                            }

                            this.readyToRunAd = false;
                            this.waitingToRunAd = false;
                        }

                        //------------------------------------------------------
                        //  Reset the timer so if we run the ad or cancel we'll
                        //  start fresh with a new timer after the ad finishes
                        //  or when we start the ad runner again.
                        //------------------------------------------------------
                        this.timer.Reset();

                        //------------------------------------------------------
                        //  If we warned the user, then clear the warning.
                        //------------------------------------------------------
                        if (needToWarnUser)
                        {
                            this.worker.ReportProgress(0, AdMessageType.HideAboutToTakeBreak);
                        }

                        //------------------------------------------------------
                        //  Handle any pending cancellation event.
                        //------------------------------------------------------
                        if (this.worker.CancellationPending)
                        {
                            return;
                        }

                        //------------------------------------------------------
                        //  Run the ad break!
                        //------------------------------------------------------
                        this.engine.RunAdBreak();
                        this.timer.Start();
                    }
                    else
                    {
                        //----------------------------------------------------------
                        //  Update the time remaining.
                        //----------------------------------------------------------
                        this.timeValues.Enqueue(adTimeRemaining);

                        //----------------------------------------------------------
                        //  Otherwise check to see if we need to warn the user we're
                        //  about to run ads.
                        //----------------------------------------------------------
                        if (!promptedWarning && needToWarnUser && ellapsedMilliseconds >= promptWarningMilliseconds)
                        {
                            promptedWarning = true;
                            this.worker.ReportProgress(0, AdMessageType.ShowAboutToTakeBreak);
                        }
                    }
                }
                else
                {
                    this.worker.ReportProgress(0, AdMessageType.NoAds);
                }

                Thread.Sleep(100);
            }
        }*/

        /// <summary>
        /// Starts the ad runner.
        /// </summary>
        public void Start()
        {

            if (!this.alarm.Running)
            {
                this.engine.WriteStatusLogMessage("Starting ad runner.");

                this.promptedAdWarning = false;
                int duration = this.engine.Settings.Ads.Frequency * 60 * 1000;
                this.alarm.Start(duration);
            }
        }

        /// <summary>
        /// Stops the ad runner.
        /// </summary>
        public void Stop()
        {
            if (this.alarm.Running)
            {
                this.engine.WriteStatusLogMessage("Stopping ad runner.");
                this.alarm.Stop();
            }

            this.engine.View.HideAboutToTakeAdBreakMessage();
            this.engine.View.ShowNoAds();
        }
    }
}
