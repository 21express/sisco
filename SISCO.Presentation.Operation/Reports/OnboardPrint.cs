using System;
using DevExpress.XtraReports.UI;
using SISCO.Models;

namespace SISCO.Presentation.Operation.Reports
{
    public partial class OnboardPrint : XtraReport
    {
        public int Numbering { get; set; }

        public OnboardPrint()
        {
            InitializeComponent();
            Numbering = 1;
        }

        private void xrLabel4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = DateTime.Now.ToString("d-M-yyyy");
        }

        private void xrLabel6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = string.Format("{0}.", Numbering);
            Numbering++;
        }
    }
}
