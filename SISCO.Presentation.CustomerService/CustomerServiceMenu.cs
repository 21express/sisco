using System.Collections.Generic;
using System.Windows.Forms;
using SISCO.Presentation.Common;
using SISCO.Presentation.CustomerService.Command;

namespace SISCO.Presentation.CustomerService
{
    public class CustomerServiceMenu
    {
        public static List<ToolStripItem> GetMenus()
        {
            return new List<ToolStripItem>
            {
                new MenuCommand("Claimed", new ClaimedCommand()),
                new MenuCommand("Pickup &Scheduler", new PickupSchedulerCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Pickup &Order", new PickupOrderCommand()),
                new MenuCommand("&Complaint", new ManageComplaintCommand()),
                new ToolStripSeparator(),
                new MenuCommand("&Tracking By Shipment", new TrackingByShipmentCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Tracking &View", new TrackingViewCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Shipment Delivery &List", new ViewShipmentDeliveryListCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Undelivered List", new UnReceivedListCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Terima Uang Cash Pickup Order", new PickupCashCommand()),
                new ToolStripSeparator(),
                new MenuCommand("&Branch", new ManageBranchCommand()),
                new MenuCommand("&Published Tariff", new ManagePublishedTariffCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Pod Retur", new PodReturnCommand()),
                new MenuCommand("Insurance", new InsuranceCommand())
            };
        }
    }
}