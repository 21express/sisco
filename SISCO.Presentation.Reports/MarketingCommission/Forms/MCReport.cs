using System;
using DevExpress.XtraReports.UI;
using SISCO.Models;
using SISCO.Repositories.Context;

namespace SISCO.Presentation.Reports.MarketingCommission.Forms
{
    // ReSharper disable once InconsistentNaming
    public partial class MCReport : XtraReport
    {
        private Decimal TotalOutstandingCustomer { get; set; }
        private Decimal GroupOutStanding { get; set; }

        public MCReport()
        {
            InitializeComponent();
            GroupOutStanding = 0;
            TotalOutstandingCustomer = 0;
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = !Convert.ToBoolean(xrLabel23.Text);
        }

        private void xrLabel30_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as PaymentInModel;
            var total = row == null ? 0 : row.McTotal - row.TotalPaymentMc;
            ((XRLabel)sender).Text = total > 0 ? total.ToString("#,#") : "0";
            TotalOutstandingCustomer += total;
        }

        private void xrLabel37_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = TotalOutstandingCustomer > 0 ? TotalOutstandingCustomer.ToString("#,#") : "0";
            GroupOutStanding += TotalOutstandingCustomer;
            TotalOutstandingCustomer = 0;
        }

        private void xrLabel22_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = GroupOutStanding > 0 ? GroupOutStanding.ToString("#,#") : "0";
            GroupOutStanding = 0;
        }
    }
}