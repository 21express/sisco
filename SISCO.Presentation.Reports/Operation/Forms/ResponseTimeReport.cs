using System;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Windows.Forms.VisualStyles;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Reports.Operation.Forms
{
    public partial class ResponseTimeReport : XtraReport
    {
        public ResponseTimeReport()
        {
            InitializeComponent();
        }

        public void SetDetailVisibility(bool state)
        {
            Detail.Visible = state;
        }

        public class ResponseTimeReportDataRow
        {
            public int OrigBranchId { get; set; }
            public string OrigBranchCode { get; set; }
            public string OrigBranch { get; set; }
            public int? TrackingStatusId { get; set; }
            public string TrackingStatus { get; set; }
            public int? EmployeeId { get; set; }
            public string EmployeeCode { get; set; }
            public string EmployeeName { get; set; }
            public TimeSpan? ResponseTimeSum { get; set; }
            public TimeSpan? ResponseTimeMin { get; set; }
            public TimeSpan? ResponseTimeMax { get; set; }
            public long TransactionsCount { get; set; }
        }

        private void xrLabel12_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            long rem;
            var transCount = GetCurrentColumnValue<long>("TransactionsCount");
            var sum = GetCurrentColumnValue<TimeSpan>("ResponseTimeSum").Ticks;
            if (transCount > 0)
            {
                ((XRLabel) sender).Text =
                    TimeSpan.FromTicks(Math.DivRem(sum, transCount,
                        out rem)).ToString(@"dd\.hh\:mm\:ss");
            }
        }

        private void xrLabel26_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            long rem;
            var transCount = Convert.ToInt64(xrLabel14.Summary.GetResult());
            if (e.Value is TimeSpan && transCount > 0)
            {
                var sum = ((TimeSpan) e.Value).Ticks;
                e.Text =
                    TimeSpan.FromTicks(Math.DivRem(sum, transCount,
                        out rem)).ToString(@"dd\.hh\:mm\:ss");
            }
        }

        private void xrLabel27_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            long rem;
            var transCount = Convert.ToInt64(xrLabel22.Summary.GetResult());
            if (e.Value is TimeSpan && transCount > 0)
            {
                var sum = ((TimeSpan)e.Value).Ticks;
                e.Text =
                    TimeSpan.FromTicks(Math.DivRem(sum, transCount,
                        out rem)).ToString(@"dd\.hh\:mm\:ss");
            }
        }
    }
}
