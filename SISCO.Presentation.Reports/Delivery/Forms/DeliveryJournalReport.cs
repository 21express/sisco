using System;
using System.Drawing.Printing;

namespace SISCO.Presentation.Reports.Delivery.Forms
{
    public partial class DeliveryJournalReport : DevExpress.XtraReports.UI.XtraReport
    {
        public DeliveryJournalReport()
        {
            InitializeComponent();

            Detail.BeforePrint += Summary;
        }

        private void Summary(object sender, PrintEventArgs e)
        {
            e.Cancel = !(Convert.ToBoolean(xrSummary.Text));
        }
    }
}
