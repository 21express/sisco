using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using SISCO.Models;

namespace SISCO.Presentation.Reports.Operation.Forms
{
    public partial class DeliveryPickupReport : DevExpress.XtraReports.UI.XtraReport
    {
        public DeliveryPickupReport()
        {
            InitializeComponent();
        }

        private void xrTableCell2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as DeliveryPickupModel;
            if (row != null)
            {
                if (row.Status == "Pickup") ((XRTableCell)sender).Text = "Customer";
                if (row.Status == "Delivery") ((XRTableCell)sender).Text = "Consignee";
            }
        }

        private void xrTableCell3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as DeliveryPickupModel;
            if (row != null)
            {
                if (row.Status == "Pickup") ((XRTableCell)sender).Text = "Pickup Date";
                if (row.Status == "Delivery") ((XRTableCell)sender).Text = "Received Date";
            }
        }

        private void xrTableCell7_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as DeliveryPickupModel;
            if (row != null)
            {
                if (row.Status == "Pickup") ((XRTableCell)sender).Text = "Note";
                if (row.Status == "Delivery") ((XRTableCell)sender).Text = "Received By";
            }
        }
    }
}
