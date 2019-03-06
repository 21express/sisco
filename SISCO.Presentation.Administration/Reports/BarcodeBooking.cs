using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Administration.Reports
{
    public partial class BarcodeBooking : XtraReport
    {
        public BarcodeBooking()
        {
            InitializeComponent();
        }

        private void xrLabel13_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = string.Format("Printed On {0}", DateTime.Now.ToString("d-M-yyyy HH:mm"));
        }

        private void xrLabel16_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = string.Format("Printed On {0}", DateTime.Now.ToString("d-M-yyyy HH:mm"));
        }
    }
}
