using System;
using System.Drawing.Printing;
using DevExpress.XtraReports.UI;
using SISCO.Models;

namespace SISCO.Presentation.Reports.CollectIn.Forms
{
    public sealed partial class PaidCollectInReport : DevExpress.XtraReports.UI.XtraReport
    {
        private Decimal TotalAmount { get; set; }
        private Decimal TotalPayment { get; set; }
        private Decimal TotalBalance { get; set; }
        private Decimal GrandAmount { get; set; }
        private Decimal GrandPayment { get; set; }
        private Decimal GrandBalance { get; set; }

        public PaidCollectInReport()
        {
            InitializeComponent();
            BeforePrint += InitReport;
        }

        private void InitReport(object sender, PrintEventArgs e)
        {
            TotalAmount = 0;
            TotalPayment = 0;
            TotalBalance = 0;

            GrandAmount = 0;
            GrandPayment = 0;
            GrandBalance = 0;

            xrAmount.BeforePrint += CalculateAmount;
            xrPayment.BeforePrint += CalculatePayment;
            xrBalance.BeforePrint += CalculateBalance;

            xrsAmount.BeforePrint += SumAmount;
            xrsPayment.BeforePrint += SumPayment;
            xrsBalance.BeforePrint += SumBalance;

            xrgAmount.BeforePrint += GAmount;
            xrgPayment.BeforePrint += GPayment;
            xrgBalance.BeforePrint += GBalance;
        }

        private void GBalance(object sender, PrintEventArgs e)
        {
            ((XRTableCell)sender).Text = GrandBalance.ToString("#,#0");
            GrandBalance = 0;
        }

        private void GPayment(object sender, PrintEventArgs e)
        {
            ((XRTableCell)sender).Text = GrandPayment.ToString("#,#0");
            GrandPayment = 0;
        }

        private void GAmount(object sender, PrintEventArgs e)
        {
            ((XRTableCell)sender).Text = GrandAmount.ToString("#,#0");
            GrandAmount = 0;
        }

        private void SumBalance(object sender, PrintEventArgs e)
        {
            ((XRTableCell)sender).Text = TotalBalance.ToString("#,#0");
            TotalBalance = 0;
        }

        private void SumPayment(object sender, PrintEventArgs e)
        {
            ((XRTableCell)sender).Text = TotalPayment.ToString("#,#0");
            TotalPayment = 0;
        }

        private void SumAmount(object sender, PrintEventArgs e)
        {
            ((XRTableCell) sender).Text = TotalAmount.ToString("#,#0");
            TotalAmount = 0;
        }

        private void CalculateBalance(object sender, PrintEventArgs e)
        {
            var row = GetCurrentRow() as PaymentInCollectInDetailModel;
            if (row != null)
            {
                TotalBalance += row.Balance;
                GrandBalance += row.Balance;
            }
        }

        private void CalculatePayment(object sender, PrintEventArgs e)
        {
            var row = GetCurrentRow() as PaymentInCollectInDetailModel;
            if (row != null)
            {
                TotalPayment += row.Payment;
                GrandPayment += row.Payment;
            }
        }

        private void CalculateAmount(object sender, PrintEventArgs e)
        {
            var row = GetCurrentRow() as PaymentInCollectInDetailModel;
            if (row != null)
            {
                TotalAmount += row.InvoiceTotal;
                GrandAmount += row.InvoiceTotal;
            }
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = !Convert.ToBoolean(xrLabel25.Text);
        }
    }
}
