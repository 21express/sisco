using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Reports.CounterCash.Forms
{
    public partial class DropPointCommissionReport : DevExpress.XtraReports.UI.XtraReport
    {
        public DropPointCommissionReport()
        {
            InitializeComponent();
        }

        private void xrTableRow2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if ((bool)Parameters["Rekap"].Value) e.Cancel = true;
        }
    }
}
