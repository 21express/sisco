using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using SISCO.Presentation.Common;

namespace SISCO.Presentation.Reports.Sales.Forms
{
    public partial class UnvalidatedShipmentReport : DevExpress.XtraReports.UI.XtraReport
    {
        public UnvalidatedShipmentReport()
        {
            InitializeComponent();
        }

        private void xrLabel4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = string.Format("Printed On: {0}", DateTime.Now.ToString("d/M/yyyy"));
        }

        private void xrLabel3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = string.Format("Printed By: {0}", BaseControl.UserLogin);
        }
    }
}
