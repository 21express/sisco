using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Reports.CustomerService.Forms
{
    public partial class UnmanifestReport : XtraReport
    {
        public UnmanifestReport()
        {
            InitializeComponent();
        }

        public class UnmanifestDataRow
        {
            public DateTime date_process { get; set; }
            public string code { get; set; }
            public string dest_city { get; set; }
            public string payment_method_name { get; set; }
            public int ttl_piece { get; set; }
            public decimal ttl_chargeable_weight { get; set; }
        }
    }
}
