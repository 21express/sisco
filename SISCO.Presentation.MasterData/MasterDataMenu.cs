using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SISCO.Presentation.Common;
using SISCO.Presentation.MasterData.Command;
using System.Windows.Forms;

namespace SISCO.Presentation.MasterData
{
    public class MasterDataMenu
    {
        public static List<ToolStripItem> GetMenus()
        {
            return new List<ToolStripItem>
            {
                new MenuCommand("Airline", new ManageAirlineCommand()),
                new MenuCommand("Airport", new ManageAirportCommand()),
                new MenuCommand("Flight Schedule", new ManageFlightScheduleCommand()),
                new MenuCommand("Fleet", new ManageFleetCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Country", new ManageCountryCommand()),
                new MenuCommand("City", new ManageCityCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Branch", new ManageBranchCommand()),
                new MenuCommand("Route", new ManageRouteCommand()),
                new MenuCommand("Branch City Mapping", new ManageBranchCityMappingCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Employee", new ManageEmployeeCommand()),
                new MenuCommand("Customer", new ManageCustomerCommand()),
                new MenuCommand("Drop Point", new ManageDropPointCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Currency", new ManageCurrencyCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Airline Tariff", new ManageAirlineTariffCommand()),
                new MenuCommand("Delivery Tariff", new ManageDeliveryTariffCommand()),
                new MenuCommand("Published Tariff", new ManagePublishedTariffCommand()),
                new MenuCommand("Customer Tariff", new ManageCustomerTariffCommand()),
                new MenuCommand("Published International Tariff", new ManagePublishedInternationalTariffCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Announcement", new ManageAnnouncementCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Division", new ManageDivisionCommand()),
                new MenuCommand("Department", new ManageDepartmentCommand()),
                new MenuCommand("&User Adminstration", new UsersCommand()),
                new MenuCommand("&Role", new RolesCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Payment Type", new ManagePaymentTypeCommand()),
                new MenuCommand("Service Type", new ManageServiceTypeCommand()),
                new MenuCommand("Status Type", new ManageStatusTypeCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Account Reference", new ManageAccountReferenceCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Cost Type", new ManageCostTypeCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Promo", new ManagePromoCommand()),
                new MenuCommand("Notification", new NotificationCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Vendor", new ManageVendorCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Rekening Bank", new ManageBankAccountCommand()),
                new MenuCommand("Rekening Bank Akses Cabang", new ManageBankAccountBranchCommand())
            };
        }
    }
}