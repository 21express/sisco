using DevExpress.Charts.Native;
using DevExpress.XtraReports.UI;

namespace ExpBarcodePrinting
{
    public partial class XtraReportTabular : XtraReport
    {
        public XtraReportTabular()
        {
            InitializeComponent();
            //DataSource = ReportDataSource.GetDataSource();
            //bindingSource1.DataSource = ReportDataSource.GetDataSource();
            BeforePrint += XtraReportTabular_BeforePrint;
        }

        void XtraReportTabular_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }


    }
}
