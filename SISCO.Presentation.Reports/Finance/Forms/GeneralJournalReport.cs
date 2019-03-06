using System;
using DevExpress.XtraReports.UI;
using SISCO.Models;

namespace SISCO.Presentation.Reports.Finance.Forms
{
    public partial class GeneralJournalReport : XtraReport
    {
        private decimal amount { get; set; }
        public GeneralJournalReport()
        {
            InitializeComponent();
            amount = 0;
        }

        private void GroupHeader3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as TransactionJournalReport;
            if (row == null) return;
            if (string.IsNullOrEmpty(row.TransactionCode)) e.Cancel = true;
        }

        private void xrTableCell21_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRTableCell)sender).Text = amount.ToString("n2");
            amount = 0;
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as TransactionJournalReport;
            if (row == null) return;
            if (string.IsNullOrEmpty(row.TransactionDescription)) e.Cancel = true;
        }

        private void GroupFooter2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as TransactionJournalReport;
            if (row == null) return;
            if (string.IsNullOrEmpty(row.TransactionCode)) e.Cancel = true;
        }

        private void xrTableCell14_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as TransactionJournalReport;
            amount += row.Debit;
        }

        private void xrTableCell15_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as TransactionJournalReport;
            if (row == null) return;
            ((XRTableCell)sender).Text = (row.Debit + row.Credit).ToString("n2");
            amount += row.Credit + row.Debit;
        }
    }
}