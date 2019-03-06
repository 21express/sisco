using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Reports.Marketing.Forms
{
    public partial class LeadsReport : XtraReport
    {
        public LeadsReport()
        {
            InitializeComponent();
        }

        public class LeadsReportDataRow
        {
            public int id { get; set; }
            public int marketing_id { get; set; }
            public string marketing_name { get; set; }
            public DateTime vdate { get; set; }
            public string contact_name { get; set; }
            public string last_lead_status { get; set; }
            public int follow_ups_count { get; set; }
            public DateTime? last_follow_up_date { get; set; }

            public int is_open { get; set; }
            public int is_success { get; set; }
            public int is_failed { get; set; }
        }
    }
}
