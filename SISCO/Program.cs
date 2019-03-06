using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading;
using System.Windows.Forms;
using Devenlab.Common.Fault;
using Devenlab.Common.WinControl.MessageBox;
using NLog;

namespace SISCO
{
    static class Program
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        private static string appGuid = "c0a76b5a-12ab-45c5-b9d9-d693faa6e7b9";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageForm.Warning(null, @"Peringatan", "Aplikasi sudah dibuka");
                    return;
                }


                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                _currentMainForm = new MainForm();
                //Application.ThreadException += Application_ThreadException;
                AppDomain.CurrentDomain.UnhandledException +=
                    new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

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

                Application.Run(new SplashScreenForm());
                Application.Run(_currentMainForm);
            }
        }

        private static MainForm _currentMainForm;
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is BusinessException)
            {
                var businessException = e.ExceptionObject as BusinessException;
                switch (businessException.Severity)
                {
                    case Severity.Info:
                        log.Info(businessException);
                        MessageForm.Info(_currentMainForm, @"Informasi", businessException.Message);
                        break;
                    case Severity.Warning:
                        log.Warn(businessException);
                        MessageForm.Warning(_currentMainForm, @"Peringatan", businessException.Message);
                        break;
                    case Severity.Mandatory:
                        log.Info(businessException);
                        MessageForm.Warning(_currentMainForm, @"Peringatan - Mandatory Attribute", businessException.Message);
                        break;
                    case Severity.Error:
                        log.Error(businessException);
                        MessageForm.Error(_currentMainForm, @"Error", businessException.Message);
                        break;
                    case Severity.Fatal:
                        log.Fatal(businessException);
                        MessageForm.Error(_currentMainForm, @"Fatal", businessException.Message);
                        break;
                    default:
                        MessageForm.Error(_currentMainForm, @"Fatal - UNKNOW", businessException.Message);
                        break;
                }
            }
            else if (e.ExceptionObject is DataNotFoundException)
            {
                log.Info(e.ExceptionObject);
                MessageForm.Warning(_currentMainForm, @"Peringatan - Data Tidak Ditemukan", (e.ExceptionObject as Exception).Message);
            }
            else if (e.ExceptionObject is ModelNullException)
            {
                log.Info(e.ExceptionObject);
                MessageForm.Warning(_currentMainForm, @"Peringatan - Model NULL", (e.ExceptionObject as Exception).Message);
            }
            else if (e.ExceptionObject is SecurityException)
            {
                log.Error(e.ExceptionObject);
                MessageForm.Warning(_currentMainForm, @"Peringatan Keamanan", (e.ExceptionObject as Exception).Message);
            }
            else
            {
                log.Error(e.ExceptionObject);
                MessageForm.Warning(_currentMainForm, @"Peringatan", (e.ExceptionObject as Exception).Message);
            }
            //MessageBox.Show(currentMainForm, )
        }
    }
}
