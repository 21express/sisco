using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Reports.CustomerService.Forms
{
    public partial class ShipmentStatusSummaryReport : XtraReport
    {
        public ShipmentStatusSummaryReport()
        {
            InitializeComponent();
        }

        public class ShipmentStatusSummary
        {
            public DateTime date_process { get; set; }
            public string branch_name { get; set; }
            public string branch_code { get; set; }
            public string messenger_code { get; set; }
            public int total_shipments_count { get; set; }
            public int in_progress_count { get; set; }
            public int received_count { get; set; }
            public int loss_count { get; set; }
            public int return_count { get; set; }
        }
    }
}
