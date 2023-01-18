using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace KUNCEVO
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
   
    }
    }
}
