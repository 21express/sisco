using System;
using DevExpress.XtraReports.UI;
using SISCO.Presentation.Common;

namespace SISCO.Presentation.Reports.Cost.Forms
{
    public partial class CostJournalReport : XtraReport
    {
        public CostJournalReport()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (Convert.ToBoolean(xrSummary.Text)) e.Cancel = true;
        }

        private void xrBranch_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel) sender).Text = BaseControl.BranchCode;
        }
    }
}
