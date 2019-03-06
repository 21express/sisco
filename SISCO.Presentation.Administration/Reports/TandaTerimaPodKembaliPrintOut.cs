using System.Globalization;
using DevExpress.XtraReports.UI;
using SISCO.Presentation.Administration.Forms;
using SISCO.Presentation.Common.Reports;

namespace SISCO.Presentation.Administration.Reports
{
    public partial class TandaTerimaPodKembaliPrintOut : InkJetPrintOut<ManageIncomingPodForm.PodInShipmentDataRow>
    {
        private int i = 0;

        public TandaTerimaPodKembaliPrintOut()
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
