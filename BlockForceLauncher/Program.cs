using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockForceLauncher
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += new EventHandler(OnApplicationClosed);
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnApplicationClosed);
            Application.Run(new MainForm());
        }

        static void OnApplicationClosed(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("BlockForceBeta").Length > 0 || Process.GetProcessesByName("BlockForceRelease").Length > 0 || Process.GetProcessesByName("BFR (DEBUG)").Length > 0 || Process.GetProcessesByName("BFR").Length > 0)
            {
                KillProcessesByName("BlockForceBeta");
                KillProcessesByName("BlockForceRelease");
                KillProcessesByName("BFR (DEBUG)");
                KillProcessesByName("BFR");
            }
        }


        public static void KillProcessesByName(string name)
        {
            Process[] workers = Process.GetProcessesByName(name);
            foreach (Process worker in workers)
            {
                worker.Kill();
                worker.WaitForExit();
                worker.Dispose();
            }
        }
    }
}
