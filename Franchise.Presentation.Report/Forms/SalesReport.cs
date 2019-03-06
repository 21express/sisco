using DevExpress.XtraReports.UI;
using SISCO.Models;

namespace Franchise.Presentation.Reports.Forms
{
    // ReSharper disable once InconsistentNaming
    public partial class SalesReport : XtraReport
    {
        public SalesReport()
        {
            InitializeComponent();
        }

        private void xrLabel28_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as FranchiseCommissionModel;
            if (model != null)
                if (model.IsDropPoint) ((XRLabel)sender).Text = string.Format("[DP] {0}", model.ShipmentCode);
                else ((XRLabel)sender).Text = model.ShipmentCode;
        }
    }
}