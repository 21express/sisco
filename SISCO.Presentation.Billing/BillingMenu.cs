using System.Collections.Generic;
using SISCO.Presentation.Common;
using SISCO.Presentation.Billing.Command;
using System.Windows.Forms;
using SISCO.Presentation.Operation.Command;

namespace SISCO.Presentation.Billing
{
    public class BillingMenu
    {
        public static List<ToolStripItem> GetMenus()
        {
            return new List<ToolStripItem>
            {
                new MenuCommand("&Validate POD", new ValidateShipmentOrderCommand()),
                new MenuCommand("&Pra-Invoice", new ViewShipmentListCommand()),
                new ToolStripSeparator(),
                new MenuCommand("&Create Sales Invoice", new CreateSalesInvoiceCommand()),
                new MenuCommand("&Create Sales Invoice By Scan", new CreateSalesInvoiceByScanCommand()),
                new MenuCommand("Create Tax Invoice", new FakturBillingCommand()),
                new MenuCommand("View Tax Invoice", new ViewTaxInvoiceCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Create &Franchise Sales Invoice", new CreateFranchiseSalesInvoiceCommand()),
                new ToolStripSeparator(),
                new MenuCommand("View Receipt No.", new InvoiceTrackingViewCommand()),
                new MenuCommand("Sales Invoice", new SalesInvoiceCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Sales &Invoice List", new ViewSalesInvoiceListCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Data &Entry", new DataEntryOperationCommand{_moduleName = "Billing" }),
                new MenuCommand ("Data En&try City", new DataEntryCityCommand{_moduleName = "Billing" }),
                new MenuCommand ("Data Ent&ry Cabang", new DataEntryCabangCommand{_moduleName = "Billing" }),
                new MenuCommand ("Data Entry Agent", new DataEntryAgentCommand{_moduleName = "Billing" }),
                new ToolStripSeparator(),
                new MenuCommand("E&xport Shipment List", new ExportShipmentListCommand()),
                new MenuCommand("I&mport Shipment List", new ImportShipmentListCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Kirim Invoice", new InvoiceToFinanceCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Cetak Invoice", new InvoicePrintingCommand())
            };
        }
    }
}