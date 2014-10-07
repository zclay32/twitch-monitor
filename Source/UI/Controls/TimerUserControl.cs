using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using TwitchMonitor.Core;
using System.Diagnostics;
using TwitchMonitor.Core.Types;
using System.Collections;

namespace TwitchMonitor.UI.Controls
{
    public partial class TimerUserControl : UserControl
    {
        private BackgroundWorker worker;
        private BackgroundWorker uiUpdateWorker;
        private Engine engine;
        private Stopwatch stopwatch;
        private Queue timeValues;
        private string previousOutput;

        /// <summary>
        /// 
        /// </summary>
        public TimerUserControl()
        {
            InitializeComponent();
            this.previousOutput = "";

            this.worker = new BackgroundWorker();
            this.worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            this.worker.WorkerSupportsCancellation = true;

            this.stopwatch = new Stopwatch();

            this.timeValues = Queue.Synchronized(new Queue());
            this.uiUpdateWorker = new BackgroundWorker();
            this.uiUpdateWorker.DoWork += new DoWorkEventHandler(uiUpdateWorker_DoWork);
            this.uiUpdateWorker.ProgressChanged += new ProgressChangedEventHandler(uiUpdateWorker_ProgressChanged);
            this.uiUpdateWorker.WorkerSupportsCancellation = true;
            this.uiUpdateWorker.WorkerReportsProgress = true;

            this.uiCountdownDateTimePicker.Value = DateTime.Now;
            this.uiOutputLabel.Text = "";

            this.uiUpdateWorker.RunWorkerAsync();
        }

        public void Cleanup()
        {
            if (this.uiUpdateWorker.IsBusy)
            {
                this.uiUpdateWorker.CancelAsync();
            }
        }

        void uiUpdateWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int count = this.timeValues.Count;
            if (count > 0)
            {
                while (count > 1)
                {
                    this.timeValues.Dequeue();
                    count--;
                }
                this.uiOutputLabel.Text = this.timeValues.Dequeue() as string;
            }
        }

        void uiUpdateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!this.uiUpdateWorker.CancellationPending)
            {
                this.uiUpdateWorker.ReportProgress(0);
                Thread.Sleep(10);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="engine"></param>
        public void Initialize(Engine engine)
        {
            this.engine = engine;
            this.uiOutputFileTextBox.Text = this.engine.Settings.TimerOutputFile;
            this.uiOutputFormatTextBox.Text = this.engine.Settings.Timer.Format;
            this.uiModeComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.ToggleControls(false);
            this.uiRunButton.Enabled = true;
            this.uiRunButton.Text = "Start";
            this.stopwatch.Stop();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            TimeSpan previousTime = new TimeSpan(-1,-1,-1,-1);

            switch(this.engine.Settings.Timer.Mode)
            {
                case TimerMode.CountdownFrom:
                case TimerMode.Stopwatch:
                    stopwatch.Reset();
                    stopwatch.Start();
                    break;
            }

            StringBuilder output = new StringBuilder();

            try
            {
                while (!this.worker.CancellationPending)
                {
                    if (!string.IsNullOrEmpty(this.engine.Settings.TimerOutputFile))
                    {
                        switch(this.engine.Settings.Timer.Mode)
                        {
                            case TimerMode.Countdown:
                            case TimerMode.CountdownTo:
                                this.ProcessCountdownTo(output, previousTime);
                                break;

                            case TimerMode.CountdownFrom:
                                this.ProcessCountdownFrom(output, previousTime);
                                break;

                            case TimerMode.Stopwatch:
                                this.ProcessStopwatch(output, previousTime);
                                break;
                        }
                    }
                    Thread.Sleep(1);
                }
            }
            catch (Exception) { }
        }

        private void AppendTimespan(StringBuilder sb, TimeSpan ts)
        {
            sb.AppendFormat("{0:" + this.engine.Settings.Timer.Format + "}", ts);
        }

        /// <summary>
        /// Processes the timer in context of counting down to a certain time.  Once the time is reached, it will stay at 0.
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="previousTime"></param>
        private void ProcessCountdownTo(StringBuilder sb, TimeSpan previousTime)
        {
            if (this.engine.Settings.Timer.Countdown >= DateTime.Now)
            {
                bool writeToFile = false;
                TimeSpan temp = this.uiCountdownDateTimePicker.Value - DateTime.Now;

                if (previousTime.Hours != temp.Hours || previousTime.Minutes != temp.Minutes || previousTime.Seconds != temp.Seconds)
                {
                    sb.Clear();
                    this.AppendTimespan(sb, temp);
                    writeToFile = true;
                }

                if (writeToFile)
                {
                    this.WriteToFile(sb);
                    previousTime = temp;
                }
            }
            else
            {
                sb.Clear();
                this.AppendTimespan(sb, new TimeSpan(0,0,0,0,0));
                this.WriteToFile(sb);
                this.worker.CancelAsync();
            }
        }

        /// <summary>
        /// Processes the value of the timer in context of counting down from a specified time.  Once the timer hits 0, it will stay at 0.
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="previousTime"></param>
        private void ProcessCountdownFrom(StringBuilder sb, TimeSpan previousTime)
        {
            if (this.engine.Settings.Timer.Offset >= stopwatch.Elapsed)
            {
                TimeSpan temp = this.engine.Settings.Timer.Offset - stopwatch.Elapsed;
                if (previousTime.Hours != temp.Hours || previousTime.Minutes != temp.Minutes || previousTime.Seconds != temp.Seconds)
                {
                    sb.Clear();
                    this.AppendTimespan(sb, temp);
                    this.WriteToFile(sb);
                    previousTime = temp;
                }
            }
            else
            {
                sb.Clear();
                this.AppendTimespan(sb, new TimeSpan(0,0,0,0,0));
                this.WriteToFile(sb);
                this.worker.CancelAsync();
            }
        }

        /// <summary>
        /// Processes the value of the timer in context of a stopwatch.
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="previousTime"></param>
        private void ProcessStopwatch(StringBuilder sb, TimeSpan previousTime)
        {
            TimeSpan temp = stopwatch.Elapsed + this.engine.Settings.Timer.Offset;
            if (previousTime.Hours != temp.Hours || previousTime.Minutes != temp.Minutes || previousTime.Seconds != temp.Seconds)
            {
                sb.Clear();
                this.AppendTimespan(sb, temp);
                this.WriteToFile(sb);
                previousTime = temp;
            }
        }

        /// <summary>
        /// Writes the specified StringBuilder value to disk.
        /// </summary>
        /// <param name="sb"></param>
        private void WriteToFile(StringBuilder sb)
        {
            string newOutput = sb.ToString();
            if (!previousOutput.Equals(newOutput))
            {
                this.previousOutput = newOutput;
                File.WriteAllText(this.engine.Settings.TimerOutputFile, newOutput);
                this.timeValues.Enqueue(sb.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiRunButton_Click(object sender, EventArgs e)
        {
            if (this.worker.IsBusy)
            {
                this.uiRunButton.Enabled = false;
                this.worker.CancelAsync();
            }
            else
            {
                this.ToggleControls(true);
                this.SaveSettings();
                this.worker.RunWorkerAsync();
                this.uiRunButton.Text = "Stop";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="running"></param>
        private void ToggleControls(bool running)
        {
            this.uiFileBrowseButton.Enabled = !running;
            this.uiOutputFileTextBox.Enabled = !running;
            this.uiOutputFormatTextBox.Enabled = !running;
            this.uiCountdownDateTimePicker.Enabled = !running;
            this.uiModeComboBox.Enabled = !running;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiFileBrowseButton_Click(object sender, EventArgs e)
        {
            if (this.uiSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.uiOutputFileTextBox.Text = this.uiSaveFileDialog.FileName;
                this.engine.Settings.TimerOutputFile = this.uiSaveFileDialog.FileName;
                this.engine.SaveSettings();
            }
        }

        /// <summary>
        /// Event handler for when the mode changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ModeChanged();
        }

        /// <summary>
        /// Called whenever the timer mode is changed.
        /// </summary>
        private void ModeChanged()
        {
            switch (this.uiModeComboBox.SelectedIndex)
            {
                case 0:
                    this.uiResetButton.Enabled = false;
                    this.engine.Settings.Timer.Mode = TimerMode.CountdownTo;
                    this.uiCountdownDateTimePicker.CustomFormat = "MM/dd/yy h:mm:ss tt";
                    this.uiCountdownDateTimePicker.Value = this.engine.Settings.Timer.Countdown;
                    break;

                case 1:
                    this.uiResetButton.Enabled = false;
                    this.engine.Settings.Timer.Mode = TimerMode.CountdownFrom;
                    this.uiCountdownDateTimePicker.CustomFormat = "HH:mm:ss";
                    this.uiCountdownDateTimePicker.Value = new DateTime(Math.Max(this.engine.Settings.Timer.Offset.Ticks, this.uiCountdownDateTimePicker.MinDate.Ticks));
                    break;

                case 2:
                    this.uiResetButton.Enabled = true;
                    this.engine.Settings.Timer.Mode = TimerMode.Stopwatch;
                    this.uiCountdownDateTimePicker.CustomFormat = "HH:mm:ss";
                    this.uiCountdownDateTimePicker.Value = new DateTime(Math.Max(this.engine.Settings.Timer.Offset.Ticks, this.uiCountdownDateTimePicker.MinDate.Ticks));
                    break;
            }
            //this.engine.SaveSettings();
        }

        /// <summary>
        /// Saves the settings to the engine.
        /// </summary>
        private void SaveSettings()
        {
            this.engine.Settings.Timer.Format = this.uiOutputFormatTextBox.Text;
            switch (this.engine.Settings.Timer.Mode)
            {
                case TimerMode.Countdown:
                case TimerMode.CountdownTo:
                    this.engine.Settings.Timer.Countdown = this.uiCountdownDateTimePicker.Value;
                    break;

                case TimerMode.CountdownFrom:
                case TimerMode.Stopwatch:
                    this.engine.Settings.Timer.Offset = new TimeSpan(0, this.uiCountdownDateTimePicker.Value.Hour, this.uiCountdownDateTimePicker.Value.Minute, this.uiCountdownDateTimePicker.Value.Second, 0);
                    break;
            }
            this.engine.SaveSettings();
        }

        /// <summary>
        /// Event handler for when the Rest button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiResetButton_Click(object sender, EventArgs e)
        {
            this.stopwatch.Reset();
        }
    }
}
