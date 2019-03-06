using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Reports.CustomerService.Forms
{
    public partial class PickupVehicleReport : XtraReport
    {
        private Decimal _carGroup;
        private Decimal _carAll;
        private Decimal _bikeGroup;
        private Decimal _bikeAll;
        private Decimal _totalGroup;
        private Decimal _totalAll;

        public PickupVehicleReport()
        {
            InitializeComponent();
        }

        private void xrLabel27_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = _totalGroup == 0 ? 0 : _carGroup/_totalGroup;
            e.Handled = true;
        }

        private void xrLabel27_SummaryReset(object sender, EventArgs e)
        {
            _totalGroup = 0;
            _bikeGroup = 0;
            _carGroup = 0;
        }

        private void xrLabel27_SummaryRowChanged(object sender, EventArgs e)
        {
            var carCount = Convert.ToDecimal(GetCurrentColumnValue("car_pu_count"));
            _carGroup += carCount;
            _carAll += carCount;

            var bikeCount = Convert.ToDecimal(GetCurrentColumnValue("bike_pu_count"));
            _bikeGroup += bikeCount;
            _bikeAll += bikeCount;

            var totalCount = Convert.ToDecimal(GetCurrentColumnValue("pu_order_count"));
            _totalGroup += totalCount;
            _totalAll += totalCount;
        }

        private void xrLabel28_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = _totalGroup == 0 ? 0 : _bikeGroup / _totalGroup;
            e.Handled = true;
        }

        private void xrLabel33_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = _totalAll == 0 ? 0 : _carAll / _totalAll;
            e.Handled = true;
        }

        private void xrLabel34_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = _totalAll == 0 ? 0 : _bikeAll / _totalAll;
            e.Handled = true;
        }

        public class PickupVehicleSummary
        {
            public DateTime date_process { get; set; }
            public string branch { get; set; }
            public string messenger_code { get; set; }
            public string customer_name { get; set; }
            public int pu_order_count { get; set; }
            public int car_pu_count { get; set; }
            public int bike_pu_count { get; set; }
            public decimal car_pu_percent { get; set; }
            public decimal bike_pu_percent { get; set; }
        }

    }
}
