using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Operation.Reports
{
    public partial class ManifestPrint : XtraReport
    {
        public int Numbering { get; set; }

        public ManifestPrint()
        {
            InitializeComponent();
            Numbering = 1;
        }

        private void xrLabel25_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = string.Format("{0}.", Numbering);
            Numbering++;
        }
    }
}
