using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Reports.Operation.Forms
{
    public partial class DeliveryOrderReport : XtraReport
    {
        public DeliveryOrderReport()
        {
            InitializeComponent();
        }

        public void SetDetailVisibility(bool state)
        {
            Detail.Visible = state;
        }

        public class DeliveryOrderReportDataRow
        {
            public DateTime DateProcess { get; set; }
            public string MessengerId { get; set; }
            public string MessengerCode { get; set; }
            public string MessengerName { get; set; }
            public string VehicleType { get; set; }
            public string Brand { get; set; }
            public string Model { get; set; }
            public string PlateNumber { get; set; }
            public int TtlPiece { get; set; }
            public int TtlGrossWeight { get; set; }
            public int TotalDocuments { get; set; }
            public int TotalPackages { get; set; }
        }
    }
}
