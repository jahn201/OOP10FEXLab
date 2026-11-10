using System;
using System.Windows.Forms;

namespace OOP10FEXLab
{
    /// <summary>
    /// Starts the queue monitor and the kiosk side by side.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Application entry point.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            QueueMonitorForm monitor = new QueueMonitorForm();
            if (Screen.AllScreens.Length > 1)
            {
                monitor.StartPosition = FormStartPosition.Manual;
                monitor.Location = Screen.AllScreens[1].WorkingArea.Location;
                monitor.WindowState = FormWindowState.Maximized;
            }
            monitor.Show();

            Application.Run(new KioskForm());
        }
    }
}
