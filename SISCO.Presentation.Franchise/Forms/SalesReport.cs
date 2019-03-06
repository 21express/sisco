using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Reports.Forms
{
    // ReSharper disable once InconsistentNaming
    public partial class SalesReport : XtraReport
    {
        public SalesReport()
        {
            InitializeComponent();
        }

        private void xrTableRow1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if ((bool)Parameters["Rekap"].Value) e.Cancel = true;
        }
    }
}