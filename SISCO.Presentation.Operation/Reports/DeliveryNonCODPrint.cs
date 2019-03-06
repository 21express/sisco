using System;
using DevExpress.XtraReports.UI;
using SISCO.Models;

namespace SISCO.Presentation.Operation.Reports
{
    public partial class DeliveryNonCODPrint : XtraReport
    {
        public int Numbering { get; set; }

        public DeliveryNonCODPrint()
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

        private void xrLabel26_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //var model = GetCurrentRow() as DeliveryOrderDetailModel;
            //if (model.TotalCod > 0) ((XRLabel)sender).Text = string.Format("COD Rp {0}", ((decimal)model.TotalCod).ToString("#,#0"));
            //else ((XRLabel)sender).Text = string.Empty;
        }
    }
}
