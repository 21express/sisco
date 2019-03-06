using System;
using DevExpress.XtraReports.UI;

namespace Franchise.Presentation.CustomerService.Reports
{
    public partial class PickupPrint : XtraReport
    {
        public int Numbering { get; set; }

        public PickupPrint()
        {
            InitializeComponent();
            Numbering = 1;
        }

        private void xrTableCell9_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = string.Format("{0}.", Numbering);
            Numbering++;
        }
    }
}
