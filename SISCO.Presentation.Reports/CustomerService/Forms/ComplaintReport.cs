using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Reports.CustomerService.Forms
{
    public partial class ComplaintReport : XtraReport
    {
        private Decimal _openGroup;
        private Decimal _openAll;
        private Decimal _closedGroup;
        private Decimal _closedAll;
        private Decimal _totalGroup;
        private Decimal _totalAll;

        public ComplaintReport()
        {
            InitializeComponent();
        }

        private void xrLabel27_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = _totalGroup == 0 ? 0 : _openGroup/_totalGroup;
            e.Handled = true;
        }

        private void xrLabel27_SummaryReset(object sender, EventArgs e)
        {
            _totalGroup = 0;
            _closedGroup = 0;
            _openGroup = 0;
        }

        private void xrLabel27_SummaryRowChanged(object sender, EventArgs e)
        {
            var openCount = Convert.ToDecimal(GetCurrentColumnValue("open_complaint_count"));
            _openGroup += openCount;
            _openAll += openCount;

            var closedCount = Convert.ToDecimal(GetCurrentColumnValue("closed_complaint_count"));
            _closedGroup += closedCount;
            _closedAll += closedCount;

            var totalCount = Convert.ToDecimal(GetCurrentColumnValue("total_complaint_count"));
            _totalGroup += totalCount;
            _totalAll += totalCount;
        }

        private void xrLabel28_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = _totalGroup == 0 ? 0 : _closedGroup / _totalGroup;
            e.Handled = true;
        }

        private void xrLabel33_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = _totalAll == 0 ? 0 : _openAll / _totalAll;
            e.Handled = true;
        }

        private void xrLabel34_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = _totalAll == 0 ? 0 : _closedAll / _totalAll;
            e.Handled = true;
        }

        public class ComplaintSummary
        {
            public DateTime date_process { get; set; }
            public string branch { get; set; }
            public string origin_city { get; set; }
            public string destination_city { get; set; }
            public int total_complaint_count { get; set; }
            public int open_complaint_count { get; set; }
            public int closed_complaint_count { get; set; }
            public decimal open_complaint_percent { get; set; }
            public decimal closed_complaint_percent { get; set; }
        }
    }
}
