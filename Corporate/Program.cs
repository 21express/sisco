using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Corporate
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var cultureInfo = new System.Globalization.CultureInfo("en-US");
            var dateTimeInfo = new System.Globalization.DateTimeFormatInfo();
            dateTimeInfo.DateSeparator = "/";
            dateTimeInfo.LongDatePattern = "MM-dd-yyyy";
            dateTimeInfo.ShortDatePattern = "MM-dd-yyyy";
            dateTimeInfo.LongTimePattern = "hh:mm:ss tt";
            dateTimeInfo.ShortTimePattern = "hh:mm tt";
            cultureInfo.DateTimeFormat = dateTimeInfo;
            Application.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            Application.Run(new SplashScreen());
            Application.Run(new MainForm());
        }
    }
}
