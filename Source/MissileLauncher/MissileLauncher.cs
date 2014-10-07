using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Threading;
//using LibUsbDotNet.LibUsb;
using UsbLibrary;

namespace BuildDefender
{
    public class MissileLauncher
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

        private UsbHidPort USB;

        public MissileLauncher()
        {

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

            this.USB = new UsbHidPort();
            this.USB.ProductId = 0;
            this.USB.SpecifiedDevice = null;
            this.USB.VendorId = 0;
            this.USB.OnSpecifiedDeviceRemoved += new EventHandler(this.USB_OnSpecifiedDeviceRemoved);
            this.USB.OnDataRecieved += new DataRecievedEventHandler(this.USB_OnDataRecieved);
            this.USB.OnSpecifiedDeviceArrived += new EventHandler(this.USB_OnSpecifiedDeviceArrived);

            this.USB.VID_List[0] = 0xa81;
            this.USB.PID_List[0] = 0x701;
            this.USB.VID_List[1] = 0x2123;
            this.USB.PID_List[1] = 0x1010;
            this.USB.ID_List_Cnt = 2;

            IntPtr handle = new IntPtr();
            this.USB.RegisterHandle(handle);
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
            if (this.USB.SpecifiedDevice != null)
            {
                this.USB.SpecifiedDevice.SendData(Data);
            }
        }


        private void USB_OnDataRecieved(object sender, DataRecievedEventArgs args)
        {

        }

        private void USB_OnSpecifiedDeviceArrived(object sender, EventArgs e)
        {
            this.DevicePresent = true;
            if (this.USB.ProductId == 0x1010)
            {
                this.command_switchLED(true);
            }
        }

        private void USB_OnSpecifiedDeviceRemoved(object sender, EventArgs e)
        {
            this.DevicePresent = false;
        }

    }

}


