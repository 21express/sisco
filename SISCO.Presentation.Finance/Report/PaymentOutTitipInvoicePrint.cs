using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Finance.Report
{
    public partial class PaymentOutTitipInvoicePrint : DevExpress.XtraReports.UI.XtraReport
    {
        private int _no { get; set; }
        public PaymentOutTitipInvoicePrint()
        {
            InitializeComponent();
            _no = 1;
        }

        private void xrTableCell6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRTableCell)sender).Text = _no.ToString();
            _no++;
        }

    }
}
