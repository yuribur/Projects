using System;
using System.Threading;
using System.Windows.Forms;

namespace Preparator
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createNew = false;
            Mutex mutex = new Mutex(true, "Preparator_start", out createNew);

            if (createNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
            {
              //  MessageBox.Show("Программа Preparator уже запущена");
            }
        }
    }
}
