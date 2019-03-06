using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Common.Reports
{
    public partial class CnBarcodeCard : BarcodePrintOut
    {
        public CnBarcodeCard()
        {
            InitializeComponent();
        }

        private void xrLabel2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = DateTime.Now.ToString("d-M-yyyy");
        }

        private void xrLabel13_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = string.Format("Printed on {0}", DateTime.Now.ToString("d-M-yyyy HH:mm"));
        }
    }
}
