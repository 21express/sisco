using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Reports.MarketingCommission.Forms
{
    public partial class MCJournalReport : XtraReport
    {
        public MCJournalReport()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = Convert.ToBoolean(xrLabel23.Text);
        }
    }
}