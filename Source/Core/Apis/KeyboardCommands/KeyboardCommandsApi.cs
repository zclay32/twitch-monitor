using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using TwitchMonitor.Core.Apis.Win32DllImports;

namespace TwitchMonitor.Core.Apis.KeyboardCommands
{
    public class KeyboardCommandsApi
    {
        private static AlarmClock alarm;
        private static IntPtr hWnd = IntPtr.Zero;
        private Dictionary<string, string> customCommands;

        /// <summary>
        /// Constructor that initializes the members and loads the custom commands.
        /// </summary>
        /// <param name="engine"></param>
        public KeyboardCommandsApi(Engine engine)
        {
            this.customCommands = new Dictionary<string, string>();
            this.RefreshCustomCommands();
        }

        public void RefreshCustomCommands()
        {
        }

        public void RefreshWindowHandle(string windowName)
        {
            hWnd = User32Dll.FindWindow(null, windowName);
        }

        public void Start()
        {
            alarm = new AlarmClock();
            alarm.OnAlarm += new AlarmClockEventHandler(alarm_OnAlarm);
            alarm.Start(1000);
        }

        public void Stop()
        {
            alarm.Stop();
        }

        public void ProcessKeyCommand(KeyCommandType command, string customCommand = "")
        {
            User32Dll.ShowWindowAsync(hWnd, User32Dll.SW_SHOW);
            switch (command)
            {
                case KeyCommandType.Escape:
                    SendKeys.SendWait("{ESC}");
                    break;

                case KeyCommandType.Key_W:
                    SendKeys.SendWait("wwwwwwwwww");
                    break;

                case KeyCommandType.Key_A:
                    SendKeys.SendWait("aaaaaaaaaa");
                    break;

                case KeyCommandType.Key_S:
                    SendKeys.SendWait("ssssssssss");
                    break;

                case KeyCommandType.Key_D:
                    SendKeys.SendWait("dddddddddd");
                    break;

                case KeyCommandType.LeftClick:
                    break;

                case KeyCommandType.RightClick:
                    break;

                case KeyCommandType.LookUp:
                    break;

                case KeyCommandType.LookDown:
                    break;

                case KeyCommandType.LookLeft:
                    break;

                case KeyCommandType.LookRight:
                    break;

                case KeyCommandType.Custom:
                    break;
            }
        }

        static void alarm_OnAlarm(object sender, AlarmClockEventArgs e)
        {
            /*
            int returnCode = SendMessage(hWnd, WM_CHAR, KEY_W, null);
            if (returnCode != 0)
            {
                e.Snooze = false;
            }*/

            SendKeyCommand();
        }

        private static void SendKeyCommand()
        {
            User32Dll.ShowWindowAsync(hWnd, User32Dll.SW_SHOW);
            //SendKeys.SendWait("{ESC}");

            //ClickOnPoint(hWnd, new Point(640, 360));
        }

        private static void ClickOnPoint(IntPtr wndHandle, Point clientPoint, KeyCommandType command)
        {
            uint buttonDown, buttonUp = 0;
            if (command == KeyCommandType.LeftClick)
            {
                buttonDown = User32Dll.MOUSEEVENTF_LEFTDOWN;
                buttonUp = User32Dll.MOUSEEVENTF_LEFTUP;
            }
            else if (command == KeyCommandType.RightClick)
            {
                buttonDown = User32Dll.MOUSEEVENTF_RIGHTDOWN;
                buttonUp = User32Dll.MOUSEEVENTF_RIGHTUP;
            }
            else
            {
                return;
            }

            var oldPos = Cursor.Position;

            /// get screen coordinates
            User32Dll.ClientToScreen(wndHandle, ref clientPoint);

            /// set cursor on coords, and press mouse
            Cursor.Position = new Point(clientPoint.X, clientPoint.Y);
            User32Dll.mouse_event(buttonDown, 0, 0, 0, UIntPtr.Zero);
            User32Dll.mouse_event(buttonUp, 0, 0, 0, UIntPtr.Zero);

            /// return mouse 
            Cursor.Position = oldPos;
        }
    }
}
