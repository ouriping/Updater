using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace Updater
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool mutexWasCreated;
            Mutex m = new Mutex(true, "Mutex_TLW.ZPG.UPDATE", out mutexWasCreated);
            if (mutexWasCreated)
            {
                Application.Run(new MainForm(args));
                m.ReleaseMutex();
            }
        }
    }
}
