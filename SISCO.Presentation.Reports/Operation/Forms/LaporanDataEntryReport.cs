using System;
using System.Drawing.Printing;

namespace SISCO.Presentation.Reports.Operation.Forms
{
    public partial class LaporanDataEntryReport : DevExpress.XtraReports.UI.XtraReport
    {
        DateTime? GroupFirstEntry;
        DateTime? GroupLastEntry;
        int GroupDaysSpan;
        int GroupTotalStt;

        public LaporanDataEntryReport()
        {
            InitializeComponent();

            Detail.BeforePrint += SummaryVisible;
        }

        private void SummaryVisible(object sender, PrintEventArgs e)
        {
            e.Cancel = !Convert.ToBoolean(xrSummary.Text);
        }

        private void xrTableCell15_SummaryGetResult(object sender, DevExpress.XtraReports.UI.SummaryGetResultEventArgs e)
        {
            if (GroupFirstEntry != null && GroupLastEntry != null)
            {
                GroupDaysSpan = ((DateTime)GroupLastEntry).Subtract((DateTime)GroupFirstEntry).Days;
            }

            e.Result = Math.Max(1, GroupDaysSpan);
            e.Handled = true;
        }

        private void xrTableCell15_SummaryReset(object sender, EventArgs e)
        {
            GroupFirstEntry = null;
            GroupLastEntry = null;
            GroupDaysSpan = 0;
            GroupTotalStt = 0;
        }

        private void xrTableCell15_SummaryRowChanged(object sender, EventArgs e)
        {
            if (GroupFirstEntry == null) GroupFirstEntry = GetCurrentColumnValue<DateTime>("Createddate");

            GroupLastEntry = GetCurrentColumnValue<DateTime?>("Modifieddate") ?? GetCurrentColumnValue<DateTime>("Createddate");

            GroupTotalStt++;
        }

        private void xrTableCell16_SummaryGetResult(object sender, DevExpress.XtraReports.UI.SummaryGetResultEventArgs e)
        {
            e.Result = GroupTotalStt > 0 ? (decimal)GroupTotalStt / (decimal)Math.Max(1, GroupDaysSpan) : 0;
            e.Handled = true;
        }
    }
}
