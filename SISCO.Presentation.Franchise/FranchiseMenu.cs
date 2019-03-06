using System.Collections.Generic;
using SISCO.Presentation.Common;
using SISCO.Presentation.Franchise.Command;
using System.Windows.Forms;

namespace SISCO.Presentation.Franchise
{
    public class FranchiseMenu
    {
        public static List<ToolStripItem> GetMenus()
        {
            var masterdata = new ToolStripMenuItem { Text = @"&Master Data" };
            masterdata.DropDownItems.AddRange(new ToolStripItem[]
            {
                new MenuCommand("&Data Franchise", new MasterDataFranchiseCommand()),
                new MenuCommand("&User Franchise", new UserFranchiseCommand()),
                new ToolStripSeparator(),
                new MenuCommand("&Announcement", new AnnouncementCommand())
            });

            var report = new ToolStripMenuItem { Text = @"&Report" };
            report.DropDownItems.AddRange(new ToolStripItem[]
            {
                new MenuCommand("Laporan &PPh 23 / PPh 21", new Pph23Command()),
                new MenuCommand("Laporan Penjualan Agent Franchise", new FranchiseSalesCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Laporan &PPh 23 / PPh 21 (Cabang)", new Pph23BranchCommand()),
                new MenuCommand("Laporan Penjualan Agent Franchise (Cabang)", new FranchiseSalesBranchCommand())
            });

            return new List<ToolStripItem>
            {
                masterdata,
                report,
                new ToolStripSeparator(),
                new MenuCommand("Shipment &Delivery List", new ShipmentDeliveryCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Koreksi Data Entry", new CorrectionDataEntryCommand())
            };
        }
    }
}