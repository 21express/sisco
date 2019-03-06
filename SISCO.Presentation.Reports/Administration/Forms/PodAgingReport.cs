using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Reports.Administration.Forms
{
    public partial class PodAgingReport : XtraReport
    {
        public PodAgingReport()
        {
            InitializeComponent();
        }

        public class AgingReportDataRow
        {
            public DateTime date_process { get; set; }
            public string code { get; set; }
            public string branch_code { get; set; }
            public string dest_city { get; set; }
            public int ttl_piece { get; set; }
            public decimal ttl_chargeable_weight { get; set; }
            public decimal tariff_total { get; set; }
            public DateTime? delivery_date { get; set; }
            public int age { get; set; }
        }
    }
}
