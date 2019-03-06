using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Reports.Operation.Forms
{
    public partial class FleetUtilizationPerVehicleReport : XtraReport
    {
        public FleetUtilizationPerVehicleReport()
        {
            InitializeComponent();
        }

        public void SetDetailVisibility(bool state)
        {
            Detail.Visible = state;
        }

        public class FleetUtilizationPerVehicleReportDataRow
        {
            public string Code { get; set; }
            public DateTime DateProcess { get; set; }
            public string PlateNumber { get; set; }
            public string VehicleType { get; set; }
            public string Brand { get; set; }
            public string Model { get; set; }
            public int TtlPiece { get; set; }
            public int TtlGrossWeight { get; set; }
            public int TtlChargeableWeight { get; set; }
        }
    }
}
