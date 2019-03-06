using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using SISCO.Models;

namespace SISCO.Presentation.Reports.Finance.Forms
{
    public partial class CodReport : DevExpress.XtraReports.UI.XtraReport
    {
        private decimal _totalCash { get; set; }
        public CodReport()
        {
            InitializeComponent();
            _totalCash = 0;
        }

        private void xrTableCell9_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as CodPaymentReport;
            _totalCash += row.TotalCash;
        }

        private void xrLabel10_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            ((XRLabel)sender).Text = _totalCash.ToString("#,#0");
            _totalCash = 0;
        }
    }
}