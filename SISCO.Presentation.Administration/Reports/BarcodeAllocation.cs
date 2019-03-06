using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Administration.Reports
{
    public partial class BarcodeAllocation : XtraReport
    {
        public BarcodeAllocation()
        {
            InitializeComponent();
        }

        private void xrLabel13_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = string.Format("{0}", DateTime.Now.ToString("d-M-yyyy HH:mm"));
        }
    }
}
