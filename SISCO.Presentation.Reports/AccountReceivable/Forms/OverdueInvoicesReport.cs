using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Reports.AccountReceivable.Forms
{
    public partial class OverdueInvoicesReport : XtraReport
    {
        public OverdueInvoicesReport()
        {
            InitializeComponent();
        }

        public void SetDetailVisibility(bool state)
        {
            Detail.Visible = state;
        }

        private void cfTotalOutstanding_GetValue(object sender, GetValueEventArgs e)
        {
            e.Value = GetCurrentColumnValue<Decimal>("Total") - GetCurrentColumnValue<Decimal>("TotalPayment");
        }
    }
}
