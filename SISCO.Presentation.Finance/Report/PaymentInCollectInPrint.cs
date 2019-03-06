using DevExpress.XtraReports.UI;
using SISCO.Models;

namespace SISCO.Presentation.Finance.Report
{
    public partial class PaymentInCollectInPrint : DevExpress.XtraReports.UI.XtraReport
    {
        private int NumberCash { get; set; }
        private int NumberCredit { get; set; }
        public PaymentInCollectInPrint()
        {
            InitializeComponent();
            NumberCash = 1;
            NumberCredit = 1;
        }

        private void xrTableCell5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as PaymentInCollectInDetailModel;
            if (row != null)
                if (row.CollectPaymentMethod == "CASH") ((XRLabel) sender).Text = "";
        }

        private void xrTableCell10_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as PaymentInCollectInDetailModel;
            if (row != null)
                if (row.CollectPaymentMethod == "CASH") ((XRLabel)sender).Text = "";
        }

        private void xrTableCell6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as PaymentInCollectInDetailModel;
            if (row != null)
            {
                if (row.CollectPaymentMethod == "CREDIT")
                {
                    ((XRLabel)sender).Text = NumberCredit.ToString("#");
                    NumberCredit++;
                }
                else
                {
                    ((XRLabel)sender).Text = NumberCash.ToString("#");
                    NumberCash++;
                }
            }
        }
    }
}
