using System;
using System.Drawing.Printing;
using DevExpress.XtraReports.UI;
using SISCO.Models;
using SISCO.Repositories.Context;

namespace SISCO.Presentation.Reports.CollectIn.Forms
{
    public partial class CollectInBrReport : XtraReport
    {
        private decimal TotalAmount { get; set; }
        private decimal TotalPayment { get; set; }
        private decimal TotalBalance { get; set; }
        private decimal GlobalAmount { get; set; }
        private decimal GlobalPayment { get; set; }
        private decimal GlobalBalance { get; set; }

        public CollectInBrReport()
        {
            InitializeComponent();

            TotalAmount = 0;
            TotalPayment = 0;
            TotalBalance = 0;

            GlobalAmount = 0;
            GlobalPayment = 0;
            GlobalBalance = 0;

            Detail.BeforePrint += DetailPrint;
        }

        private void DetailPrint(object sender, PrintEventArgs e)
        {
            var row = GetCurrentRow() as PaymentInCollectInDetailModel;
            if (row != null && row.ReportPaymentOutCode == "") e.Cancel = true;
            else e.Cancel = !Convert.ToBoolean(xrDetail.Text);
        }

        private void GOutstanding(object sender, PrintEventArgs e)
        {
            ((XRLabel)sender).Text = GlobalBalance.ToString("#,#0");
            GlobalBalance = 0;
        }

        private void GPayment(object sender, PrintEventArgs e)
        {
            ((XRLabel)sender).Text = GlobalPayment.ToString("#,#0");
            GlobalPayment = 0;
        }

        private void GAmount(object sender, PrintEventArgs e)
        {
            ((XRLabel)sender).Text = GlobalAmount.ToString("#,#0");
            GlobalAmount = 0;
        }

        private void SumOutstanding(object sender, PrintEventArgs e)
        {
            ((XRLabel)sender).Text = TotalBalance.ToString("#,#0");
            TotalBalance = 0;
        }

        private void SumPayment(object sender, PrintEventArgs e)
        {
            ((XRLabel)sender).Text = TotalPayment.ToString("#,#0");
            TotalPayment = 0;
        }

        private void SumAmount(object sender, PrintEventArgs e)
        {
            ((XRLabel) sender).Text = TotalAmount.ToString("#,#0");
            TotalAmount = 0;
        }

        private void CalculateBalance(object sender, PrintEventArgs e)
        {
            var row = GetCurrentRow() as PaymentInCollectInDetailModel;
            if (row != null) TotalBalance += row.Payment;

            GlobalBalance += TotalBalance;
        }

        private void CalculatePayment(object sender, PrintEventArgs e)
        {
            var row = GetCurrentRow() as PaymentInCollectInDetailModel;
            if (row != null) TotalPayment += row.Payment;

            GlobalPayment += TotalPayment;
        }

        private void CalculateAmount(object sender, PrintEventArgs e)
        {
            var row = GetCurrentRow() as PaymentInCollectInDetailModel;
            if (row != null) TotalAmount += row.InvoiceTotal;

            GlobalAmount += TotalAmount;
        }
    }
}
