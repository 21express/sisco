using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using SISCO.Models;

namespace SISCO.Presentation.Reports.Sales.Forms
{
    public partial class SalesInvoiceReport : DevExpress.XtraReports.UI.XtraReport
    {
        public SalesInvoiceReport()
        {
            InitializeComponent();
        }

        private void xrTableCell12_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as ReportInvoice;
            if (model == null) return;
            ((XRTableCell)sender).Text = string.Empty;
            ((XRTableCell)sender).Visible = true;

            if (model.Cancelled)
            {
                ((XRTableCell)sender).Visible = false;
            }
            else
                if ((bool)Parameters["ViewDatePaid"].Value) if (model.DatePaid != null) ((XRTableCell)sender).Text = ((DateTime)model.DatePaid).ToString("dd-MMM-yyyy");
        }

        private void xrTableCell13_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as ReportInvoice;
            if (model == null) return;
            ((XRTableCell)sender).Text = string.Empty;
            ((XRTableCell)sender).Visible = true;

            if (model.Cancelled)
            {
                ((XRTableCell)sender).Visible = false;
            }
            else
                if ((bool)Parameters["ViewAdjustment"].Value) if (model.Adjustment != null) ((XRTableCell)sender).Text = ((decimal)model.Adjustment).ToString("#,#0");
        }

        private void xrTableCell14_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as ReportInvoice;
            if (model == null) return;
            ((XRTableCell)sender).Text = string.Empty;
            ((XRTableCell)sender).Visible = true;

            if (model.Cancelled)
            {
                ((XRTableCell)sender).Visible = false;
            }
            else
                if ((bool)Parameters["ViewPayment"].Value) if (model.Payment != null) ((XRTableCell)sender).Text = ((decimal)model.Payment).ToString("#,#0");
        }

        private void xrTableCell15_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as ReportInvoice;
            if (model == null) return;
            ((XRTableCell)sender).Text = string.Empty;
            ((XRTableCell)sender).Visible = true;

            if (model.Cancelled)
            {
                ((XRTableCell)sender).Visible = false;
            }
            else
                if ((bool)Parameters["ViewPaymentType"].Value) ((XRTableCell)sender).Text = model.PaymentType;
        }

        private void xrTableCell20_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as ReportInvoice;
            if (model == null) return;
            ((XRTableCell)sender).Text = string.Empty;
            ((XRTableCell)sender).Visible = true;

            if (model.Cancelled)
            {
                ((XRTableCell)sender).Visible = false;
            }
            else
                if ((bool)Parameters["ViewOther"].Value) ((XRTableCell)sender).Text = model.OtherInvoice ? "Yes" : "No";
        }

        private void xrTableRow2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as ReportInvoice;
            if (model == null) return;
            if (model.Cancelled)
            {
                ((XRTableRow)sender).ForeColor = Color.Red;
            }
            else ((XRTableRow)sender).ForeColor = Color.Black;
        }

        private void xrTableCell16_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as ReportInvoice;
            if (model == null) return;

            ((XRTableCell)sender).Visible = true;

            if (model.Cancelled)
            {
                ((XRTableCell)sender).Visible = false;
            }
            else ((XRTableCell)sender).Text = model.Period.Substring(0, 3);
        }
    }
}
