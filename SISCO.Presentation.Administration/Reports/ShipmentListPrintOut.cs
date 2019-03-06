using System.Globalization;
using DevExpress.XtraReports.UI;
using SISCO.Models;
using SISCO.Presentation.Common.Reports;

namespace SISCO.Presentation.Administration.Reports
{
    public partial class ShipmentListPrintOut : InkJetPrintOut<ShipmentModel>
    {
        private int i = 0;

        public ShipmentListPrintOut()
        {
            InitializeComponent();
        }

        private void xrLabel9_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            i++;
            ((XRLabel)sender).Text = i.ToString(CultureInfo.InvariantCulture);
        }
    }
}
