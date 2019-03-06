using System.Collections.Generic;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Common.Reports
{
    public abstract class BarcodePrintOut : XtraReport
    {
        public void Print()
        {
            RequestParameters = false;

            CreateDocument();

            using (var printTool = new ReportPrintTool(this))
            {
                if (string.IsNullOrEmpty(BaseControl.PrinterSetting.Barcode)) printTool.PrintDialog();
                else printTool.Print(BaseControl.PrinterSetting.Barcode);
            }
        }
    }
}
