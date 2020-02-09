using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTest
{
    static class Program
    {
        public static string txtLangPath = @"C:\Users\Fran\source\repos\WinFormsTest\lang.txt";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            setLang();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form_Lang jezikApp = new Form_Lang();
            if(File.Exists(txtLangPath))
            {
                Application.Run(new Form2(jezikApp.txtJezik));
            }
            Application.Run(new Form_Lang());
        }

        private static void setLang()
        {
            var lang = ConfigurationManager.AppSettings["language"];
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
        }
    }
}
