using System.Collections.Generic;
using System.Windows.Forms;
using Franchise.Presentation.Common;
using Franchise.Presentation.Reports.Command;

namespace Franchise.Presentation.Reports
{
    public class ReportMenu
    {
        public static List<ToolStripItem> GetMenus()
        {
            return new List<ToolStripItem>
            {
                new MenuCommand("Laporan &Penjualan", new SalesCommand()),
                new MenuCommand("Laporan &Status Pembayaran", new PaymentCommand())
            };
        }
    }
}
