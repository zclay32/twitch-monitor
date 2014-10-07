//==============================================================================
//
//  File:    AlarmClock.cs
//  Author:  Jason Ziaja
//  Created: February, 14, 2014
//  Description: 
//
//==============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace TwitchMonitor.Core
{
    /// <summary>
    /// Event arguments used by the <see cref="AlarmClock">AlarmClock</see> class when broadcasting events.
    /// </summary>
    public class AlarmClockEventArgs : EventArgs
    {
        /// <summary>
        /// Time in milliseconds remaining until the alarm triggers.
        /// </summary>
        public int TimeRemaining { get; set; }

        /// <summary>
        /// Total time in milliseconds for when the alarm will be triggered.
        /// </summary>
        public int TotalTime { get; set; }

        /// <summary>
        /// Gets or sets whether or not the alarm should keep going after an alarm event is triggered.
        /// </summary>
        public bool Snooze { get; set; }
    }

    /// <summary>
    /// Event handler delegate used by the <see cref="AlarmClock">AlarmClock</see> class.
    /// </summary>
    /// <param name="sender">Object reference to the AlarmClock broadcasting the event.</param>
    /// <param name="e">Event arguments for the event.</param>
    public delegate void AlarmClockEventHandler(object sender, AlarmClockEventArgs e);

    /// <summary>
    /// Defines a class that can be used to trigger an event at a specified time duration.
    /// </summary>
    public class AlarmClock
    {
        //======================================================================
        //  Private Members
        //======================================================================
        private Timer timer;
        private DateTime startTime;
        private int duration;

        //======================================================================
        //  Public Events
        //======================================================================
        public event AlarmClockEventHandler OnTick;
        public event AlarmClockEventHandler OnAlarm;

        public bool Running { get; private set; }

        //======================================================================
        //  Constructors
        //======================================================================
        /// <summary>
        /// Default constructor that initializes all the members.
        /// </summary>
        public AlarmClock()
        {
            this.timer = new Timer();
            this.timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }

        //======================================================================
        //  Public Methods
        //======================================================================
        /// <summary>
        /// Starts the timer.
        /// </summary>
        public void Start(int duration, int interval = 500)
        {
            this.startTime = DateTime.Now;
            this.duration = duration;
            this.timer.Interval = interval;
            this.timer.Start();
            this.Running = true;
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        public void Stop()
        {
            this.timer.Stop();
            this.Running = false;
        }

        /// <summary>
        /// Triggers the alarm.
        /// </summary>
        public void Trigger()
        {
            this.ActivateAlarm(new AlarmClockEventArgs());
        }

        //======================================================================
        //  Private Methods
        //======================================================================
        /// <summary>
        /// Activates the alarm using the specified event arguments
        /// </summary>
        /// <param name="e">The event arguments to use when activating the alarm.</param>
        private void ActivateAlarm(AlarmClockEventArgs e)
        {
            this.startTime = DateTime.Now;
            e.TimeRemaining = 0;
            e.Snooze = true;

            if (this.OnAlarm != null)
            {
                this.OnAlarm(this, e);

                //--------------------------------------------------------------
                //  If the caller has chosen not to snooze, then stop the alarm.
                //--------------------------------------------------------------
                if (!e.Snooze)
                {
                    this.Stop();
                }
            }
        }

        /// <summary>
        /// Event handler for when the timer elapses.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            AlarmClockEventArgs alarmEventArgs = new AlarmClockEventArgs();
            alarmEventArgs.TotalTime = this.duration;

            TimeSpan elapsedTime = e.SignalTime - this.startTime;
            alarmEventArgs.TimeRemaining = this.duration - Convert.ToInt32(elapsedTime.TotalMilliseconds);

            //------------------------------------------------------------------
            //  Check to see if we need to trigger the alarm.
            //------------------------------------------------------------------
            if (alarmEventArgs.TimeRemaining <= 0)
            {
                this.ActivateAlarm(alarmEventArgs);
            }

            //------------------------------------------------------------------
            //  Always invoke the tick event.
            //------------------------------------------------------------------
            if (this.OnTick != null)
            {
                this.OnTick(this, alarmEventArgs);
            }
        }
    }
}
