using System;
using System.Drawing.Printing;
using DevExpress.XtraReports.UI;
using SISCO.Models;

namespace SISCO.Presentation.Reports.Delivery.Forms
{
    public partial class DeliveryReport : XtraReport
    {
        private Decimal TotalAmount { get; set; }
        private Decimal TotalPayment { get; set; }
        private Decimal TotalBalance { get; set; }

        private Decimal GlobalAmount { get; set; }
        private Decimal GlobalPayment { get; set; }
        private Decimal GlobalBalance { get; set; }

        public DeliveryReport()
        {
            InitializeComponent();

            TotalAmount = 0;
            TotalPayment = 0;
            TotalBalance = 0;

            GlobalAmount = 0;
            GlobalPayment = 0;
            GlobalBalance = 0;

            xrAmount.BeforePrint += CalculateAmount;
            xrPayment.BeforePrint += CalculatePayment;
            xrBalance.BeforePrint += CalculateBalance;

            xrsAmout.BeforePrint += SumAmount;
            xrsPayment.BeforePrint += SumPayment;
            xrsBalance.BeforePrint += SumBalance;

            xrgAmount.BeforePrint += Amount;
            xrgPayment.BeforePrint += Payment;
            xrgBalance.BeforePrint += Balance;
        }

        private void Balance(object sender, PrintEventArgs e)
        {
            ((XRTableCell)sender).Text = GlobalBalance.ToString("#,#0");
            GlobalBalance = 0;
        }

        private void Payment(object sender, PrintEventArgs e)
        {
            ((XRTableCell)sender).Text = GlobalPayment.ToString("#,#0");
            GlobalPayment = 0;
        }

        private void Amount(object sender, PrintEventArgs e)
        {
            ((XRTableCell)sender).Text = GlobalAmount.ToString("#,#0");
            GlobalAmount = 0;
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
            var row = GetCurrentRow() as ReportDeliveryJournal;
            if (row != null) TotalBalance += row.balance;

            GlobalBalance += TotalBalance;
        }

        private void CalculatePayment(object sender, PrintEventArgs e)
        {
            var row = GetCurrentRow() as ReportDeliveryJournal;
            if (row != null) TotalPayment += row.payment;

            GlobalPayment += TotalPayment;
        }

        private void CalculateAmount(object sender, PrintEventArgs e)
        {
            var row = GetCurrentRow() as ReportDeliveryJournal;
            if (row != null) TotalAmount += row.delivery_fee_total;

            GlobalAmount += TotalAmount;
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as ReportDeliveryJournal;
            if (row != null && row.report_code == "") e.Cancel = true;
            else e.Cancel = !Convert.ToBoolean(xrDetail.Text);
        }
    }
}
