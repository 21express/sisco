using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Reports.Marketing.Forms
{
    public partial class CustomerReport : XtraReport
    {
        public CustomerReport()
        {
            InitializeComponent();
        }

        public class CustomerReportDataRow
        {
            public string code { get; set; }
            public string name { get; set; }
            public string address { get; set; }
            public string branch_code { get; set; }
            public string phone { get; set; }
            public DateTime? last_order { get; set; }
        }
    }
}
