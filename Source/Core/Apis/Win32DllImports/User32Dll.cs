using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace TwitchMonitor.Core.Apis.Win32DllImports
{
    public class User32Dll
    {
        public static int WM_KEYDOWN = 0x0100;
        public static int WM_KEYUP = 0x0101;
        public static int WM_CHAR = 0x0102;

        public static int VK_ESCAPE = 0x1B;
        public static int KEY_W = 0x57;
        public static int KEY_A = 0x41;
        public static int KEY_S = 0x53;
        public static int KEY_D = 0x44;

        public static uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        public static uint MOUSEEVENTF_LEFTUP = 0x0004;
        public static uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        public static uint MOUSEEVENTF_RIGHTUP = 0x0010;

        public static int SW_SHOW = 5;

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);
        [DllImport("User32.dll")]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lp1, string lp2);
        [DllImport("User32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);
        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);
    }
}
