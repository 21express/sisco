using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Common.Reports
{
    public abstract class InkJetPrintOut<T> : XtraReport
    {
        public void Print(string printerName = null)
        {
            RequestParameters = false;

            CreateDocument();

            if (string.IsNullOrEmpty(printerName))
            {
                using (var printTool = new ReportPrintTool(this))
                {
                    if (string.IsNullOrEmpty(BaseControl.PrinterSetting.InkJet)) printTool.PrintDialog();
                    else printTool.Print(BaseControl.PrinterSetting.InkJet);
                }
            }
            else
            {
                using (var printTool = new ReportPrintTool(this))
                {
                    printTool.Print(printerName);
                }
            }
        }

        public bool PrintDialog()
        {
            RequestParameters = false;

            CreateDocument();

            using (var printTool = new ReportPrintTool(this))
            {
                printTool.Print(BaseControl.PrinterSetting.InkJet);
                return true;
            }
        }

        public void PrintPreview()
        {
            RequestParameters = false;

            foreach (var t in Parameters)
            {
                t.Visible = false;
            }

            CreateDocument();
            
            using (var printTool = new ReportPrintTool(this))
            {
                printTool.ShowPreviewDialog();
            }
        }
    }
}
