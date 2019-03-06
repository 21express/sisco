using System.Collections.Generic;
using System.Windows.Forms;
using SISCO.Presentation.Common;
using SISCO.Presentation.Operation.Command;

namespace SISCO.Presentation.Operation
{
    public class OperationMenu
    {
        public static List<ToolStripItem> GetMenus()
        {
            return new List<ToolStripItem>
            {
                new MenuCommand ("&Pickup Arrangement", new PickupArrangementCommand()),
                new MenuCommand ("Pic&kup Result", new PickupResultCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("&Acceptance", new AcceptanceCommand()),
                new MenuCommand ("Data &Entry Acceptance", new DataEntryAcceptanceCommand()),
                new MenuCommand ("Data Entry Operation", new DataEntryOperationCommand{_moduleName = "Operation" }),
                new MenuCommand ("Data En&try City", new DataEntryCityCommand{_moduleName = "Operation" }),
                new MenuCommand ("Data Ent&ry Cabang", new DataEntryCabangCommand{_moduleName = "Operation" }),
                new MenuCommand ("Data Entry Agent", new DataEntryAgentCommand{_moduleName = "Operation" }),
                new ToolStripSeparator(),
                new MenuCommand ("Serah Terima POD", new PodHandoverCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Data Entry Franchice", new DataEntryFranchiseCommand{_moduleName = "Operation" }),
                new ToolStripSeparator(),
                new MenuCommand ("Data Entry Ecommerce", new DataEntryEcommerceCommand{_moduleName = "Operation" }),
                new ToolStripSeparator(),
                new MenuCommand ("&Shipment List", new ShipmentListCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("&Consolidation", new ConsolidationCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("&Manifest", new ManifestCommand()),
                new MenuCommand ("Manifest &List", new ManifestListCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Manifest Vendor", new ManifestVendorCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Lap &Outbound Bandara", new OutboundBandaraCommand()),
                new MenuCommand ("On&board Report", new OnboardCommand()),
                new MenuCommand ("Onboard Report View", new OnboardReportViewCommand()),
                new MenuCommand ("Inbound Bandara View", new InboundBandaraViewCommand()),
                new MenuCommand ("Lap I&nbound Bandara", new InboundBandaraCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Audit Kilo SMU", new HeavyDifferenceAirwaybillCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Lap Outbound Darat", new OutboundDaratCommand()),
                new MenuCommand ("Lap Inbound Darat View", new InboundDaratViewCommand()),
                new MenuCommand ("Lap Inbound Darat", new InboundDaratCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Incoming List", new IncomingListCommand()),
                new MenuCommand ("Manifest In Vie&w", new ManifestInViewCommand()),
                new MenuCommand ("&Inbound", new InboundCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("&Delivery Order", new DeliveryOrderCommand()),
                new MenuCommand ("Delivery Order Cabang", new DeliveryOrderCabangCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Delivery Order List", new DeliveryOrderListCommand()),
                new MenuCommand ("Deli&very Result", new DeliveryResultCommand())
            };
        }
    }
}