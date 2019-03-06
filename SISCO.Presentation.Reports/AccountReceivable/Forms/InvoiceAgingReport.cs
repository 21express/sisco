using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Reports.AccountReceivable.Forms
{
    public partial class InvoiceAgingReport : XtraReport
    {
        public InvoiceAgingReport()
        {
            InitializeComponent();
        }

        private void cf0to15_GetValue(object sender, GetValueEventArgs e)
        {
            var dueDateBy = Convert.ToDateTime(Parameters["DueDateBy"].Value).Date;
            var dueDate = GetCurrentColumnValue<DateTime>("DueDate").Date;

            e.Value = dueDate >= dueDateBy.AddDays(-15) && dueDate <= dueDateBy ? GetCurrentColumnValue<Decimal>("Total") - GetCurrentColumnValue<Decimal>("TotalPayment") : 0;
        }

        private void cf16to30_GetValue(object sender, GetValueEventArgs e)
        {
            var dueDateBy = Convert.ToDateTime(Parameters["DueDateBy"].Value).Date;
            var dueDate = GetCurrentColumnValue<DateTime>("DueDate").Date;

            e.Value = dueDate >= dueDateBy.AddDays(-30) && dueDate < dueDateBy.AddDays(-15) ? GetCurrentColumnValue<Decimal>("Total") - GetCurrentColumnValue<Decimal>("TotalPayment") : 0;
        }

        private void cf31to45_GetValue(object sender, GetValueEventArgs e)
        {
            var dueDateBy = Convert.ToDateTime(Parameters["DueDateBy"].Value).Date;
            var dueDate = GetCurrentColumnValue<DateTime>("DueDate").Date;

            e.Value = dueDate >= dueDateBy.AddDays(-45) && dueDate < dueDateBy.AddDays(-30) ? GetCurrentColumnValue<Decimal>("Total") - GetCurrentColumnValue<Decimal>("TotalPayment") : 0;
        }

        private void cf46to60_GetValue(object sender, GetValueEventArgs e)
        {
            var dueDateBy = Convert.ToDateTime(Parameters["DueDateBy"].Value).Date;
            var dueDate = GetCurrentColumnValue<DateTime>("DueDate").Date;

            e.Value = dueDate >= dueDateBy.AddDays(-60) && dueDate < dueDateBy.AddDays(-45) ? GetCurrentColumnValue<Decimal>("Total") - GetCurrentColumnValue<Decimal>("TotalPayment") : 0;
        }

        private void cf60more_GetValue(object sender, GetValueEventArgs e)
        {
            var dueDateBy = Convert.ToDateTime(Parameters["DueDateBy"].Value).Date;
            var dueDate = GetCurrentColumnValue<DateTime>("DueDate").Date;

            e.Value = dueDate < dueDateBy.AddDays(-60) ? GetCurrentColumnValue<Decimal>("Total") - GetCurrentColumnValue<Decimal>("TotalPayment") : 0;
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = Convert.ToBoolean(xrLabel6.Text);
        }
    }
}
