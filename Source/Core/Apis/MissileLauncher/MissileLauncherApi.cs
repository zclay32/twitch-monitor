using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Threading;
using System.Collections;
using System.ComponentModel;
using TwitchMonitor.Core.Types;

namespace TwitchMonitor.Core.Apis.MissileLauncher
{
    public delegate void ErrorEvent(string message, Exception ex);

    public class MissileLauncherApi
    {
        private bool isLoaded;
        private MissileLauncherDll missileLauncherDll;
        private Queue launchQueue;
        private BackgroundWorker launchWorker;
        private Engine engine;

        public ErrorEvent OnError { get; set; }

        public MissileLauncherApi(Engine engine)
        {
            this.engine = engine;
            this.isLoaded = false;
            this.missileLauncherDll = new MissileLauncherDll(this);
            this.launchQueue = Queue.Synchronized(new Queue());

            this.launchWorker = new BackgroundWorker();
            this.launchWorker.DoWork += new DoWorkEventHandler(launchWorker_DoWork);
            this.launchWorker.ProgressChanged += new ProgressChangedEventHandler(launchWorker_ProgressChanged);
            this.launchWorker.WorkerReportsProgress = true;
            this.launchWorker.WorkerSupportsCancellation = true;
        }

        void launchWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ThreadMessage message = e.UserState as ThreadMessage;
            this.engine.WriteStatusLogMessage(message.Message);
        }

        void launchWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!this.launchWorker.CancellationPending)
            {
                while (launchQueue.Count > 0)
                {
                    launchQueue.Dequeue();
                    this.launchWorker.ReportProgress(0, new ThreadMessage() { Message = "Launching missile..." });
                    this.FireMissile();
                }
                Thread.Sleep(500);
            }
        }

        public void Start()
        {
            if (!this.launchWorker.IsBusy)
            {
                this.launchWorker.RunWorkerAsync();
            }
        }

        public void Stop()
        {
            if (this.launchWorker.IsBusy)
            {
                this.launchWorker.CancelAsync();
            }
        }

        /// <summary>
        /// Schedules a missile to be fired.
        /// </summary>
        public void ScheduleMissileFire()
        {
            this.launchQueue.Enqueue(0);
        }

        /// <summary>
        /// Initializes the MissileLauncher API by loading all the dependencies.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>True if initialization was successful; false otherwise.</returns>
        public bool Initialize(string path)
        {
            //------------------------------------------------------------------
            //  Quit early if we have bad data for the path.
            //------------------------------------------------------------------
            this.isLoaded = false;
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
            {
                return this.isLoaded;
            }

            //------------------------------------------------------------------
            //  Load the Dream Cheeky USB library.  We'll need this library to
            //  help us talk to the missile launcher.
            //------------------------------------------------------------------
            Assembly assembly = null;
            try
            {
                assembly = Assembly.LoadFile(path);
            }
            catch (Exception ex)
            {
                this.ReportError("Failed to load the Missile Launcher API.", ex);
                return this.isLoaded;
            }

            if (assembly == null)
            {
                this.ReportError("Failed to load the Missile Launcher API.", new Exception("Unable to load the Dream Cheeky library."));
                return this.isLoaded;
            }

            //------------------------------------------------------------------
            //  If we've successfully loaded the USB library, then load the
            //  local Missile Launcher API library.
            //------------------------------------------------------------------
            this.missileLauncherDll.Reset(assembly);

            //------------------------------------------------------------------
            //  If we've gotten this far, then it means we've successfully
            //  loaded the Missile Launcher API.
            //------------------------------------------------------------------
            this.isLoaded = true;
            return this.isLoaded;
        }

        /// <summary>
        /// Sends a command to fire a missile.
        /// </summary>
        private void FireMissile()
        {
            if (this.isLoaded && this.missileLauncherDll != null)
            {
                try
                {
                    this.missileLauncherDll.command_Fire();
                }
                catch (Exception ex)
                {
                    this.ReportError("Failed to fire a missile.", ex);
                }
            }
        }

        public void ResetPosition()
        {
            if (this.isLoaded && this.missileLauncherDll != null)
            {
                try
                {
                    this.missileLauncherDll.command_reset();
                }
                catch (Exception ex)
                {
                    this.ReportError("Failed to reset the missile launcher position.", ex);
                }
            }
        }

        /// <summary>
        /// Reports an error for another object to handle.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        protected void ReportError(string message, Exception ex)
        {
            if (this.launchWorker.IsBusy)
            {
                this.launchWorker.ReportProgress(0, new ThreadMessage() { Message = "[ERROR] " + message + " - Exception: " + ex.Message + "\nStack Trace: " + ex.StackTrace});
            }

            if (this.OnError != null)
            {
                this.OnError(message, ex);
            }
        }

        #region Dream Cheeky USB API
        /// <summary>
        /// MissileLauncherDll class that talks directly to the Dream Cheeky USB library.
        /// </summary>
        private class MissileLauncherDll
        {
            private bool DevicePresent;

            //Bytes used in command
            private byte[] UP;
            private byte[] RIGHT;
            private byte[] LEFT;
            private byte[] DOWN;

            private byte[] FIRE;
            private byte[] STOP;
            private byte[] LED_OFF;
            private byte[] LED_ON;

            private Object USB;
            private MissileLauncherApi parent;

            public MissileLauncherDll(MissileLauncherApi parent)
            {
                this.parent = parent;

                this.UP = new byte[10];
                this.UP[1] = 2;
                this.UP[2] = 2;

                this.DOWN = new byte[10];
                this.DOWN[1] = 2;
                this.DOWN[2] = 1;

                this.LEFT = new byte[10];
                this.LEFT[1] = 2;
                this.LEFT[2] = 4;

                this.RIGHT = new byte[10];
                this.RIGHT[1] = 2;
                this.RIGHT[2] = 8;

                this.FIRE = new byte[10];
                this.FIRE[1] = 2;
                this.FIRE[2] = 0x10;

                this.STOP = new byte[10];
                this.STOP[1] = 2;
                this.STOP[2] = 0x20;

                this.LED_ON = new byte[9];
                this.LED_ON[1] = 3;
                this.LED_ON[2] = 1;

                this.LED_OFF = new byte[9];
                this.LED_OFF[1] = 3;
            }

            /// <summary>
            /// Resets the loaded DLL and initializes the Missile Launcher.
            /// </summary>
            /// <param name="missileLauncherDll"></param>
            /// <returns></returns>
            public bool Reset(Assembly missileLauncherDll)
            {
                if (missileLauncherDll == null)
                {
                    return false;
                }

                try
                {
                    Type usbHidPortType = missileLauncherDll.GetType("UsbLibrary.UsbHidPort");
                    if (usbHidPortType != null)
                    {
                        this.USB = Activator.CreateInstance(usbHidPortType);
                    }

                    if (this.USB != null)
                    {
                        this.SetProperty(this.USB, "ProductId", value: 0);
                        this.SetProperty(this.USB, "SpecifiedDevice", value: null);
                        this.SetProperty(this.USB, "VendorId", value: 0);

                        this.SetEventHandler(this.USB, "OnSpecifiedDeviceRemoved", "USB_OnSpecifiedDeviceRemoved");
                        this.SetEventHandler(this.USB, "OnDataRecieved", "USB_OnDataRecieved");
                        this.SetEventHandler(this.USB, "OnSpecifiedDeviceArrived", "USB_OnSpecifiedDeviceArrived");

                        this.SetField(this.USB, "VID_List", new Int32[] { 0xa81, 0x2123 });
                        this.SetField(this.USB, "PID_List", new Int32[] { 0x701, 0x1010 });
                        this.SetField(this.USB, "ID_List_Cnt", 2);

                        
                        IntPtr handle = new IntPtr();
                        this.RunMethod(this.USB, "RegisterHandle", new object[] { handle });
                    }
                }
                catch (Exception ex)
                {
                    this.parent.ReportError("Failed to load the Missile Launcher DLL", ex);
                    return false;
                }
                return true;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="obj"></param>
            /// <param name="name"></param>
            /// <param name="value"></param>
            /// <param name="values"></param>
            private void SetProperty(Object obj, string name, object value = null, object[] values = null)
            {
                PropertyInfo p = obj.GetType().GetProperty(name);
                if (p != null)
                {
                    p.SetValue(obj, value, values);
                }
            }

            private void SetField(Object obj, string name, object value)
            {
                FieldInfo f = obj.GetType().GetField(name);
                if (f != null)
                {
                    f.SetValue(obj, value);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="obj"></param>
            /// <param name="name"></param>
            /// <returns></returns>
            private object GetProperty(Object obj, string name)
            {
                PropertyInfo p = obj.GetType().GetProperty(name);
                if (p != null)
                {
                    return p.GetValue(obj, null);
                }
                return null;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="obj"></param>
            /// <param name="methodName"></param>
            /// <param name="parameters"></param>
            private void RunMethod(Object obj, string methodName, object[] parameters)
            {
                MethodInfo m = obj.GetType().GetMethod(methodName);
                if (m != null)
                {
                    m.Invoke(obj, parameters);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="obj"></param>
            /// <param name="eventName"></param>
            /// <param name="eventHandler"></param>
            private void SetEventHandler(Object obj, string eventName, string eventHandler)
            {
                EventInfo e = obj.GetType().GetEvent(eventName);
                Type tDelegate = e.EventHandlerType;
                MethodInfo miEventHandler = typeof(MissileLauncherDll).GetMethod(eventHandler, BindingFlags.NonPublic | BindingFlags.Instance);
                Delegate d = Delegate.CreateDelegate(tDelegate, this, miEventHandler);
                MethodInfo addHandler = e.GetAddMethod();
                Object[] addHandlerArgs = { d };
                addHandler.Invoke(obj, addHandlerArgs);
            }

            public void command_Stop()
            {
                this.SendUSBData(this.STOP);
            }

            public void command_Right(int degrees)
            {
                this.moveMissileLauncher(this.RIGHT, degrees);
            }

            public void command_Left(int degrees)
            {
                this.moveMissileLauncher(this.LEFT, degrees);
            }

            public void command_Up(int degrees)
            {
                this.moveMissileLauncher(this.UP, degrees);
            }

            public void command_Down(int degrees)
            {
                this.moveMissileLauncher(this.DOWN, degrees);
            }

            public void command_Fire()
            {
                this.moveMissileLauncher(this.FIRE, 5000);
            }

            /// <summary>
            /// Turns the LED on or off on the missile launcher.
            /// </summary>
            /// <param name="turnOn">Set to true to turn the LED on; false to turn the LED off.</param>
            public void command_switchLED(Boolean turnOn)
            {
                if (DevicePresent)
                {
                    if (turnOn)
                    {
                        this.SendUSBData(this.LED_ON);
                    }
                    else
                    {
                        this.SendUSBData(this.LED_OFF);
                    }
                    this.SendUSBData(this.STOP);
                }
            }

            /// <summary>
            /// Resets the position of the device.
            /// </summary>
            public void command_reset()
            {
                if (DevicePresent)
                {
                    this.moveMissileLauncher(this.LEFT, 5500);
                    this.moveMissileLauncher(this.RIGHT, 2750);
                    this.moveMissileLauncher(this.UP, 2000);
                    this.moveMissileLauncher(this.DOWN, 500);
                }
            }

            private void moveMissileLauncher(byte[] Data, int interval)
            {
                if (DevicePresent)
                {
                    this.command_switchLED(true);
                    this.SendUSBData(Data);
                    Thread.Sleep(interval);
                    this.SendUSBData(this.STOP);
                    this.command_switchLED(false);
                }
            }

            private void SendUSBData(byte[] Data)
            {
                object device = this.GetProperty(this.USB, "SpecifiedDevice");
                if (device != null)
                {
                    this.RunMethod(device, "SendData", new object[] { Data });
                }
            }

            private void USB_OnDataRecieved(object sender, EventArgs args)
            {

            }

            private void USB_OnSpecifiedDeviceArrived(object sender, EventArgs e)
            {
                this.DevicePresent = true;
                object productId = this.GetProperty(this.USB, "ProductId");
                if (productId != null && Convert.ToInt32(productId) == 0x1010)
                {
                    this.command_switchLED(true);
                }
            }

            private void USB_OnSpecifiedDeviceRemoved(object sender, EventArgs e)
            {
                this.DevicePresent = false;
            }
        }
        #endregion
    }
}
