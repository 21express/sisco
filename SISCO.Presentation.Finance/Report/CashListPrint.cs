using DevExpress.XtraReports.UI;
using SISCO.Models;
using System.Drawing;

namespace SISCO.Presentation.Finance.Report
{
    public partial class CashListPrint : XtraReport
    {
        public CashListPrint()
        {
            InitializeComponent();
        }

        private void xrTable2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as ShipmentModel;
            if (row.Voided)
            {
                ((XRTable)sender).BackColor = Color.Red;
                ((XRTable)sender).ForeColor = Color.White;
            }
            else
            {
                ((XRTable)sender).BackColor = Color.White;
                ((XRTable)sender).ForeColor = Color.Black;
            }
        }
    }
}
