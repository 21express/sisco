using System;
using System.Drawing.Printing;
using DevExpress.XtraReports.UI;
using SISCO.Models;

namespace SISCO.Presentation.Reports.Delivery.Forms
{
    public partial class OutstandingDeliveryReport : XtraReport
    {
        private Decimal TotalAmount { get; set; }
        private Decimal TotalPayment { get; set; }
        private Decimal TotalBalance { get; set; }
        private Decimal GrandBalance { get; set; }

        public OutstandingDeliveryReport()
        {
            InitializeComponent();

            TotalAmount = 0;
            TotalPayment = 0;
            TotalBalance = 0;
            GrandBalance = 0;

            xrAmount.BeforePrint += CalculateAmount;
            xrPayment.BeforePrint += CalculatePayment;
            xrBalance.BeforePrint += CalculateBalance;

            xrsAmount.BeforePrint += SumAmount;
            xrsPayment.BeforePrint += SumPayment;
            xrsBalance.BeforePrint += SumBalance;
            xrgPayment.BeforePrint += Balance;

            Detail.BeforePrint += Details;
        }

        private void Details(object sender, PrintEventArgs e)
        {
            if (GetCurrentColumnValue<string>("report_code") == "") e.Cancel = true; 
            else e.Cancel = !Convert.ToBoolean(xrDetail.Text);
        }

        private void Balance(object sender, PrintEventArgs e)
        {
            ((XRTableCell)sender).Text = GrandBalance.ToString("#,#0");
            GrandBalance = 0;
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
            ((XRTableCell)sender).Text = TotalAmount.ToString("#,#0");
            TotalAmount = 0;
        }

        private void CalculateBalance(object sender, PrintEventArgs e)
        {
            var row = GetCurrentRow() as ReportDeliveryJournal;
            if (row != null) TotalBalance += row.balance;

            GrandBalance += TotalBalance;
        }

        private void CalculatePayment(object sender, PrintEventArgs e)
        {
            var row = GetCurrentRow() as ReportDeliveryJournal;
            if (row != null) TotalPayment += row.totalpayment;
        }

        private void CalculateAmount(object sender, PrintEventArgs e)
        {
            var row = GetCurrentRow() as ReportDeliveryJournal;
            if (row != null) TotalAmount += row.delivery_fee_total;
        }
    }
}
