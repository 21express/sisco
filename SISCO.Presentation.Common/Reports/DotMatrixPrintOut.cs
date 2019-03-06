using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using Devenlab.Common.Helpers;
using DevExpress.XtraReports.Parameters;

namespace SISCO.Presentation.Common.Reports
{
    public abstract class DotMatrixPrintOut<T>
    {
        public IEnumerable<T> DataSource { get; set; }
        public ParameterCollection Parameters { get; set; }
        public string Layout;

        public DotMatrixPrintOut()
        {
            Parameters = new ParameterCollection();
        }

        public void Print()
        {
            if (string.IsNullOrEmpty(Layout))
            {
                if (!string.IsNullOrEmpty(GetLayoutFile()))
                {
                    try
                    {
                        Layout = File.ReadAllText(GetLayoutFile());
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Could not load print out template file", e);
                    }
                }
            }

            var printDialog = new PrintDialog
            {
                PrinterSettings = new PrinterSettings
                {
                    PrinterName = BaseControl.PrinterSetting.DotMatrix
                }
            };

            RawPrinterHelper.SendStringToPrinter(printDialog.PrinterSettings.PrinterName, GetRawText());
        }

        protected abstract string GetRawText();
        protected abstract string GetLayoutFile();

        protected string TruncateString(string text, int maxLength)
        {
            return text.Substring(0, Math.Min(text.Length, maxLength));
        }
    }
}
