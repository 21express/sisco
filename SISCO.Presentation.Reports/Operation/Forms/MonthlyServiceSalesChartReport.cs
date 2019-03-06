using System;
using System.Collections.Generic;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Reports.Operation.Forms
{
    public partial class MonthlyServiceSalesChartReport : XtraReport
    {
        public MonthlyServiceSalesChartReport()
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
            public decimal Total { get; set; }
        }

        public class CostDataRow
        {
            public string DisplayDate { get; set; }
            public decimal Total { get; set; }
        }

        internal void SetLabelVisibility(bool p)
        {
            xrChart1.SeriesTemplate.LabelsVisibility = p ? DefaultBoolean.True : DefaultBoolean.False;
        }

        internal void SetCostDataSource(object ds)
        {
            foreach (Series s in xrChart1.Series)
            {
                if (s.Name == "Cost")
                {
                    xrChart1.Series.Remove(s);
                    break;
                }
            }

            var series1 = new Series("Cost", ViewType.Line);

            series1.DataSource = ds;
            series1.ArgumentScaleType = ScaleType.Auto;
            series1.ArgumentDataMember = "DisplayDate";
            series1.ValueScaleType = ScaleType.Numerical;
            series1.ValueDataMembers.AddRange(new string[] { "Total" });
            series1.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;

            xrChart1.Series.Add(series1);
        }
    }
}
