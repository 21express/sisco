using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Franchise.Forms
{
    public partial class PphReport : DevExpress.XtraReports.UI.XtraReport
    {
        public PphReport()
        {
            InitializeComponent();
        }

        private void xrTableRow2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if ((bool)Parameters["Rekap"].Value) e.Cancel = true;
        }

        private void xrTableCell1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if ((bool)Parameters["Rekap"].Value) e.Cancel = true;
        }
    }
}
