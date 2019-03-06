using DevExpress.XtraReports.UI;

namespace Franchise.Presentation.Common.Reports
{
    public abstract class InkJetPrintOut<T> : XtraReport
    {
        public void Print()
        {
            RequestParameters = false;

            CreateDocument();

            using (var printTool = new ReportPrintTool(this))
            {
                if (string.IsNullOrEmpty(BaseControl.PrinterSetting.InkJet)) printTool.PrintDialog();
                else printTool.Print(BaseControl.PrinterSetting.InkJet);
            }
        }

        public void PrintDialog()
        {
            RequestParameters = false;

            CreateDocument();

            using (var printTool = new ReportPrintTool(this))
            {
                printTool.PrintDialog();
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
