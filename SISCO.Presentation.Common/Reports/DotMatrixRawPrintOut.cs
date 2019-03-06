using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevExpress.XtraReports.Parameters;

namespace SISCO.Presentation.Common.Reports
{
    // adapted from: http://stackoverflow.com/questions/2837786/send-esc-commands-to-a-printer-in-c-sharp
    public class NativePrintMethods
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        // ReSharper disable once InconsistentNaming
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi,
            ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter,
            out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi,
            ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level,
            [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount,
            out Int32 dwWritten);
    }

    public abstract class DotMatrixRawPrintOut<T>
    {
        public IEnumerable<T> DataSource { get; set; }
        public ParameterCollection Parameters { get; set; }
        public string Layout;

        public DotMatrixRawPrintOut()
        {
            Parameters = new ParameterCollection();
        }

        public bool Print(string printerName = null)
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

            var printDialog = new PrintDialog();

            if (string.IsNullOrEmpty(printerName))
            {
                printDialog = new PrintDialog
                {
                    PrinterSettings = new PrinterSettings
                    {
                        PrinterName = string.IsNullOrEmpty(BaseControl.PrinterRangkapSetting.DotMatrix) ? BaseControl.PrinterSetting.DotMatrix : BaseControl.PrinterRangkapSetting.DotMatrix
                    }
                };
            }
            else
            {
                printDialog = new PrintDialog
                {
                    PrinterSettings = new PrinterSettings
                    {
                        PrinterName = printerName
                    }
                };
            }

            // ReSharper disable once RedundantAssignment
            var printerHandle = new IntPtr(0);
            var documentInfo = new NativePrintMethods.DOCINFOA
            {
                pDocName = AppDomain.CurrentDomain.FriendlyName,
                pDataType = "RAW"
            };

            try
            {
                // Open the printer.
                if (NativePrintMethods.OpenPrinter(printDialog.PrinterSettings.PrinterName.Normalize(),
                    out printerHandle, IntPtr.Zero))
                {
                    PrinterHandle = printerHandle;
                    // Start a document.
                    if (NativePrintMethods.StartDocPrinter(printerHandle, 1, documentInfo))
                    {
                        // Start a page.
                        if (NativePrintMethods.StartPagePrinter(printerHandle))
                        {
                            ProcessPrint();

                            NativePrintMethods.EndPagePrinter(printerHandle);
                        }
                        NativePrintMethods.EndDocPrinter(printerHandle);
                    }
                    NativePrintMethods.ClosePrinter(printerHandle);
                }
                else
                {
                    throw new Exception(string.Format("Printer {0} not found. Please check your printer settings (File -> User Preferences.)", printDialog.PrinterSettings.PrinterName.Normalize()));
                }
            }
            catch (Win32Exception e)
            {
                throw new Exception("Error communicating with printer. Error code: " + Marshal.GetLastWin32Error(), e);
            }

            return true;
        }

        public IntPtr PrinterHandle { get; set; }

        protected abstract void ProcessPrint();
        protected abstract string GetLayoutFile();

        protected void Reset()
        {
            Write(27, 64); // Esc @	Initialize printer
        }

        protected string TruncateString(string text, int maxLength)
        {
            return !string.IsNullOrEmpty(text) ? text.Substring(0, Math.Min(text.Length, maxLength)) : string.Empty;
        }

        protected void Write(string text, params object[] parameters)
        {
            Write(GetBytes(DotMatrixRawPrintOut<object>.TransformTags(string.Format(text, parameters))));
        }

        protected void Write(params byte[] document)
        {
            int bytesWritten;

            var managedData = document;
            var unmanagedData = Marshal.AllocCoTaskMem(managedData.Length);
            Marshal.Copy(managedData, 0, unmanagedData, managedData.Length);

            if (PrinterHandle == null)
            {
                throw new Exception("Printer handle not yet instantiated");
            }

            if (!NativePrintMethods.WritePrinter(PrinterHandle, unmanagedData, managedData.Length, out bytesWritten))
            {
                throw new Exception("Failed to send byte data to printer");
            }

            Marshal.FreeCoTaskMem(unmanagedData);
        }

        protected void PageBreak(bool resetPrinter = false)
        {
            Reset();
            Write(12); // Form feed

            if (!NativePrintMethods.EndPagePrinter(PrinterHandle)) throw new Exception("Failed to send page end command to printer");
            if (!NativePrintMethods.StartPagePrinter(PrinterHandle)) throw new Exception("Failed to send page start command to printer");
        }

        static byte[] GetBytes(string str)
        {
            var bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string TransformTags(string text)
        {
            // References: http://www.lprng.com/DISTRIB/RESOURCES/PPD/epson.htm
            // http://whitefiles.org/b1_s/1_free_guides/fg2cd/pgs/c03c_prntr_cds.htm
            text = text.Replace("<condensed>", string.Format("{0}", (char)15)); // SI 	Select condensed mode
            text = text.Replace("</condensed>", string.Format("{0}", (char)18)); // DC2 Cancel condensed mode


            text = text.Replace("\r", string.Empty); // remove CR

            return text;
        }

        protected void SetLeftMargin(int space)
        {
            Write(27, 108, (byte)space);
        }

        protected void SetLineSpacing(LineSpacing lineSpacing)
        {
            Write(27, (byte)lineSpacing);
        }

        protected void SetFontStyle(FontStyle fontStyle)
        {
            var f = (byte) fontStyle;
            Write(27, 33, f);
        }

        public enum LineSpacing
        {
            Narrow = 0,
            Normal = 2,
        }

        public enum FontStyle
        {
            Pica = 0,
            Elite = 1,
            Proportional = 2,
            Condensed = 4,
            Emphasised = 8,
            Enhanced = 16,
            Enlarged = 32,
            Italic = 64,
            Underline = 128,
        }
    }
}
