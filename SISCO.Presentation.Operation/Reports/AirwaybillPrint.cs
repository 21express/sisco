﻿using System;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Operation.Reports
{
    public partial class AirwaybillPrint : DevExpress.XtraReports.UI.XtraReport
    {
        public int Numbering { get; set; }

        public AirwaybillPrint()
        {
            InitializeComponent();
            Numbering = 1;
        }

        private void xrLabel5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel) sender).Text = DateTime.Now.ToString("dddd");
        }

        private void xrLabel4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = DateTime.Now.ToString("d-M-yyyy");
        }

        private void xrTableCell9_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = string.Format("{0}.", Numbering);
            Numbering++;
        }
    }
}
