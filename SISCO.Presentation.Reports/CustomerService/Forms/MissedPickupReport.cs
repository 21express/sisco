using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Reports.CustomerService.Forms
{
    public partial class MissedPickupReport : XtraReport
    {
        private Decimal _missedGroup;
        private Decimal _missedAll;
        private Decimal _pickedUpGroup;
        private Decimal _pickedUpAll;
        private Decimal _totalGroup;
        private Decimal _totalAll;

        public MissedPickupReport()
        {
            InitializeComponent();
        }

        private void xrLabel27_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = _totalGroup == 0 ? 0 : _pickedUpGroup/_totalGroup;
            e.Handled = true;
        }

        private void xrLabel27_SummaryReset(object sender, EventArgs e)
        {
            _totalGroup = 0;
            _missedGroup = 0;
            _pickedUpGroup = 0;
        }

        private void xrLabel27_SummaryRowChanged(object sender, EventArgs e)
        {
            var pickupCount = Convert.ToDecimal(GetCurrentColumnValue("pu_count"));
            _pickedUpGroup += pickupCount;
            _pickedUpAll += pickupCount;

            var missedCount = Convert.ToDecimal(GetCurrentColumnValue("missed_count"));
            _missedGroup += missedCount;
            _missedAll += missedCount;

            var totalCount = Convert.ToDecimal(GetCurrentColumnValue("pu_order_count"));
            _totalGroup += totalCount;
            _totalAll += totalCount;
        }

        private void xrLabel28_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = _totalGroup == 0 ? 0 : _missedGroup / _totalGroup;
            e.Handled = true;
        }

        private void xrLabel33_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = _totalAll == 0 ? 0 : _pickedUpAll / _totalAll;
            e.Handled = true;
        }

        private void xrLabel34_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = _totalAll == 0 ? 0 : _missedAll / _totalAll;
            e.Handled = true;
        }

    }
}
