using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Reports.Operation.Forms
{
    public partial class OutboundWeightDiffReport : XtraReport
    {
        public OutboundWeightDiffReport()
        {
            InitializeComponent();
        }

        public void SetDetailVisibility(bool state)
        {
            Detail.Visible = state;
        }

        public class OutboundWeightDiffReportDataRow
        {
            public DateTime DateProcess { get; set; }
            public string Code { get; set; }
            public string OrigBranch { get; set; }
            public string DestBranch { get; set; }
            public string CustomerName { get; set; }
            public string WaybillType { get; set; }
            public int TtlGrossWeight { get; set; }
            public int? WaybillWeight { get; set; }
        }
    }
}
