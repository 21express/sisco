using System;
using DevExpress.XtraReports.UI;
using SISCO.Models;

namespace SISCO.Presentation.Reports.TitipInvoice.Forms
{
    // ReSharper disable once InconsistentNaming
    public partial class OutstandingTitipInvoiceCustomerReport : XtraReport
    {
        private Decimal TotalOutstandingCustomer { get; set; }

        public OutstandingTitipInvoiceCustomerReport()
        {
            InitializeComponent();
            TotalOutstandingCustomer = 0;
        }

        private void xrLabel22_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = TotalOutstandingCustomer > 0 ? TotalOutstandingCustomer.ToString("#,#") : "0";
            TotalOutstandingCustomer = 0;
        }

        private void xrTableCell3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as OtherInvoiceModel;
            if (row != null)
            {
                ((XRTableCell)sender).Text = string.Format("{0} - {1}", row.RefNumber, row.CustomerName);
            }
        }

        private void xrTableCell7_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as OtherInvoiceModel;
            if (row != null)
            {
                var outstanding = row.Total - row.InTotalPayment;
                ((XRTableCell)sender).Text = outstanding > 0 ? outstanding.ToString("#,#") : "0";
                TotalOutstandingCustomer += outstanding;
            }
        }
    }
}