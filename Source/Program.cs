using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.IO;
using TwitchMonitor.Core;
using TwitchMonitor.UI;
using System.Text;
using System.Reflection;
using TwitchMonitor.Core.Apis.KeyboardCommands;

namespace TwitchMonitor
{
    static class Program
    {
        public static int UiThreadId;
        public static bool InsideUnhandledExceptionHandler;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            Engine engine = new Engine();
            if (engine.PerformPostLoadUpgradeTasks())
            {
                using (UpgradeTasksDialog dialog = new UpgradeTasksDialog())
                {
                    engine.LoadingView = dialog;
                    dialog.Engine = engine;
                    dialog.ShowDialog();
                }
            }

            Application.Run(new MainWindow(engine));
        }

        /// <summary>
        /// Returns whether or not the currently-running code is being called from the main UI thread.
        /// </summary>
        /// <returns></returns>
        public static bool IsUiThread()
        {
            return System.Threading.Thread.CurrentThread.ManagedThreadId == Program.UiThreadId;
        }

        /// <summary>
        /// Exception handler for any unhandled exceptions from the main thread.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            DisplayErrorMessage(e.ExceptionObject as Exception);
            Application.Exit();
        }

        /// <summary>
        /// Exception handler for any unhandled thread exceptions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            DisplayErrorMessage(e.Exception);
            Application.Exit();
        }

        /// <summary>
        /// Displays an error message to the user.
        /// </summary>
        /// <param name="e"></param>
        static void DisplayErrorMessage(Exception e)
        {
            if (InsideUnhandledExceptionHandler)
            {
                return;
            }
            InsideUnhandledExceptionHandler = true;

            string crashLog = DumpErrorLog(e);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Twitch Monitor was apparently working too hard and has to take a quick breather.{0}{0}", Environment.NewLine);
            sb.AppendFormat("A crash log of the error has been generated at the following location:{0}{1}{0}{0}", Environment.NewLine, crashLog);
            sb.Append("Please email the crash log to zclaycreationz@gmail.com.");
            MessageBox.Show(sb.ToString(), "Twitch Monitor - Critical Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        static string DumpErrorLog(Exception e)
        {
            //------------------------------------------------------------------
            //  Check to see if crash directory exists.
            //------------------------------------------------------------------
            string directory = Path.Combine(Engine.CacheDirectory, "crash_logs");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            //------------------------------------------------------------------
            //  Build the string to write to the file.
            //------------------------------------------------------------------
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Twitch Monitor Crash Report{0}", Environment.NewLine);
            sb.AppendFormat("Version: {0}{1}", Assembly.GetExecutingAssembly().GetName().Version.ToString(), Environment.NewLine);
            sb.AppendFormat("Date: {0}{1}", DateTime.Now.ToString("G"), Environment.NewLine);
            sb.AppendFormat("--------------------------------------{0}", Environment.NewLine);
            sb.AppendFormat("Exception Information:{0}{1}{0}", Environment.NewLine, e.ToString());

            //------------------------------------------------------------------
            //  Write the file.
            //------------------------------------------------------------------
            string filename = Path.Combine(directory, string.Format("{0}.log", DateTime.Now.ToString("yyyy_MM_dd-hh_mm_ss")));
            File.WriteAllText(filename, sb.ToString());
            return filename;
        }
    }
}
