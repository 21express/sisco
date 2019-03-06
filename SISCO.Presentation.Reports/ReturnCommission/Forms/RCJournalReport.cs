using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Reports.ReturnCommission.Forms
{
    // ReSharper disable once InconsistentNaming
    public partial class RCJournalReport : XtraReport
    {
        public RCJournalReport()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = Convert.ToBoolean(xrLabel23.Text);
        }
    }
}