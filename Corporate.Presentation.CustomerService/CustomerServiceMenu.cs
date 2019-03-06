using System.Collections.Generic;
using System.Windows.Forms;
using Corporate.Presentation.Common;
using Corporate.Presentation.CustomerService.Command;

namespace Corporate.Presentation.CustomerService
{
    public class CustomerServiceMenu
    {
        public static List<ToolStripItem> GetMenus()
        {
            return new List<ToolStripItem>
            {
                new MenuCommand("Pick&up / Cut Off", new PickupCommand()),
                new MenuCommand("Tracking &View", new TrackingViewCommand()),
                new ToolStripSeparator(),
                new MenuCommand("&Shipment List", new ShipmentListCommand()),
                new ToolStripSeparator(),
                new MenuCommand("&Tariff", new TariffCommand())
            };
        }
    }
}
