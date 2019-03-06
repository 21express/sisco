using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Operation.Reports
{
    public partial class ManifestVendorPrint : XtraReport
    {
        public int Numbering { get; set; }

        public ManifestVendorPrint()
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
