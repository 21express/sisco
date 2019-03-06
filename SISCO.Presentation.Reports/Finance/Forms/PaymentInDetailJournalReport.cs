using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Reports.Finance.Forms
{
    public partial class PaymentInDetailJournalReport : XtraReport
    {
        public PaymentInDetailJournalReport()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = Convert.ToBoolean(xrLabel23.Text);
        }
    }
}