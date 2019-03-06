using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Operation.Reports
{
    public partial class PickupOrderPrint : XtraReport
    {
        public int Numbering { get; set; }

        public PickupOrderPrint()
        {
            InitializeComponent();
            Numbering = 1;
        }

        private void xrLabel4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = DateTime.Now.ToString("d-M-yyyy");
        }

        private void xrLabel16_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = string.Format("{0}.", Numbering);
            Numbering++;
        }
    }
}
