using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Windows.Forms;
using Devenlab.Common.Fault;

namespace SISCO
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
            _currentMainForm = new MainForm();
            Application.ThreadException += Application_ThreadException;
            Application.Run(new SplashScreenForm());
            Application.Run(_currentMainForm);
            
        }

        private static MainForm _currentMainForm;
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (e.Exception is BusinessException)
            {
                var businessException = e.Exception as BusinessException;
                switch (businessException.Severity)
                {
                    case Severity.Info:
                        MessageBox.Show(_currentMainForm, businessException.Message, @"Informasi", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        break;
                    case Severity.Warning:
                        MessageBox.Show(_currentMainForm, businessException.Message, @"Warning", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        break;
                    case Severity.Mandatory:
                        MessageBox.Show(_currentMainForm, businessException.Message, @"Warning", MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
                        break;
                    case Severity.Error:
                        MessageBox.Show(_currentMainForm, businessException.Message, @"Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    case Severity.Fatal:
                        MessageBox.Show(_currentMainForm, businessException.Message, @"Fatal", MessageBoxButtons.OK,
                            MessageBoxIcon.Stop);
                        break;
                    default:
                        MessageBox.Show(_currentMainForm, businessException.Message, @"Fatal", MessageBoxButtons.OK,
                            MessageBoxIcon.Stop);
                        break;
                }
            }
            else if (e.Exception is DataNotFoundException)
            {
                MessageBox.Show(_currentMainForm, e.Exception.Message, @"Warning", MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
            }
            else if (e.Exception is ModelNullException)
            {
                MessageBox.Show(_currentMainForm, e.Exception.Message, @"Warning", MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
            }
            else if (e.Exception is SecurityException)
            {
                MessageBox.Show(_currentMainForm, e.Exception.Message, @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show(_currentMainForm, e.Exception.Message, @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
            }
            //MessageBox.Show(currentMainForm, )
        }
    }
}
