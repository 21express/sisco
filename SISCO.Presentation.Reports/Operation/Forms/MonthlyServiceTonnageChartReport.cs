using System;
using DevExpress.Utils;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Reports.Operation.Forms
{
    public partial class MonthlyServiceTonnageChartReport : XtraReport
    {
        public MonthlyServiceTonnageChartReport()
        {
            InitializeComponent();
        }

        protected override void BeforeReportPrint()
        {
            base.BeforeReportPrint();

            xrChart1.DataSource = DataSource;
        }

        public class MonthlyServiceTonnageChartReportDataRow
        {
            public DateTime DateProcess { get; set; }
            public string ServiceType { get; set; }
            public string DisplayDate { get; set; }
            public int ServiceTypeId { get; set; }
            public decimal TtlChargeableWeight { get; set; }
            public string BranchName { get; set; }
        }

        internal void SetLabelVisibility(bool p)
        {
            xrChart1.SeriesTemplate.LabelsVisibility = p ? DefaultBoolean.True : DefaultBoolean.False;
        }
    }
}
