using System.Collections.Generic;
using System.Windows.Forms;
using SISCO.Presentation.Reports.AccountReceivable.Command;
using SISCO.Presentation.Reports.Administration.Command;
using SISCO.Presentation.Reports.CollectIn.Command;
using SISCO.Presentation.Reports.CollectOut.Command;
using SISCO.Presentation.Reports.Cost.Command;
using SISCO.Presentation.Reports.CustomerService.Command;
using SISCO.Presentation.Reports.Delivery.Command;
using SISCO.Presentation.Reports.Finance.Command;
using SISCO.Presentation.Reports.Marketing.Command;
using SISCO.Presentation.Reports.MarketingCommission.Command;
using SISCO.Presentation.Reports.Operation.Command;
using SISCO.Presentation.Reports.ReturnCommission.Command;
using SISCO.Presentation.Reports.Sales.Command;
using SISCO.Presentation.Reports.TitipInvoice.Command;
using MenuCommand = SISCO.Presentation.Common.MenuCommand;
using SISCO.Presentation.Reports.CounterCash.Command;

namespace SISCO.Presentation.Reports
{
    public class ReportMenu
    {
        public static List<ToolStripItem> GetMenus()
        {
            var customerService = new ToolStripMenuItem { Text = @"&Customer Service" };
            customerService.DropDownItems.AddRange(new ToolStripItem[]
            {
                new MenuCommand("Laporan &Pickup Order", new PickupOrderReportCommand()),
                new MenuCommand("Laporan Miss &Delivery Out", new MissDeliveryOutReportCommand()),
                new MenuCommand("Laporan &Missed Pickup", new MissedPickupReportCommand()),
                new MenuCommand("Laporan Pickup &Vehicle", new PickupVehicleReportCommand()),
                new MenuCommand("Laporan &Shipment Status Summary", new ShipmentStatusSummaryReportCommand()),
                new MenuCommand("Laporan &Unmanifest", new UnmanifestReportCommand()),
                new MenuCommand("Laporan &Complaint", new ComplaintReportCommand())
            });

            var operation = new ToolStripMenuItem { Text = @"Operation" };
            operation.DropDownItems.AddRange(new ToolStripItem[]
            {
                new MenuCommand ("Laporan Barang Via Udara", new OperationAirwaybillCommand()),
                new MenuCommand ("Laporan Barang Via Darat", new OperationWaybillCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Laporan Miss Delivery", new OperationMissDeliveryCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Laporan Data Entry", new OperationLaporanDataEntryCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Laporan Handling Fee", new HandlingFeeReportCommand()),
                new MenuCommand ("Laporan Penggunaan Armada", new FleetUtilizationPerVehicleReportCommand()),
                new MenuCommand ("Laporan Penggunaan Armada Harian", new DailyFleetUtilizationReportCommand()),
                new MenuCommand ("Laporan Delivery Order", new DeliveryOrderReportCommand()),
                new MenuCommand ("Laporan Delivery &Pickup Kurir", new DeliveryPickupCommand()),
                new MenuCommand ("Laporan Selisih Berat Waybill", new OutboundWeightDiffReportCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Laporan Response Time", new ResponseTimeReportCommand()),
            });

            var sales = new ToolStripMenuItem { Text = @"Sales" };
            sales.DropDownItems.AddRange(new ToolStripItem[]
            {
                new MenuCommand ("Sales Invoice", new SalesInvoiceCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Sales Journal (Branch)", new SalesJournalBranchCommand()),
                new MenuCommand ("Sales Journal (Marketing)", new SalesJournalMarketingCommand()),
                new MenuCommand ("Sales Journal (Customer)", new SalesJournalCustomerReportCommand()),
                new MenuCommand ("Sales Journal (Dest)", new SalesJournalDestinationReportCommand()),
                new MenuCommand ("Sales Journal (Service)", new SalesJournalServiceTypeReportCommand()),
                new MenuCommand ("Sales Journal (Dest-Cust)", new SalesJournalDestinationCustomerReportCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Sales Journal (Employee)", new SalesJournalEmployeeReportCommand()),
                new MenuCommand ("In-Process Sales Counter", new InProcessSalesCounterReportCommand()),
                new MenuCommand ("Un-Invoiced Sales", new UninvoicedSalesReportCommand()),
                new MenuCommand ("Un-Invoiced Sales Credit", new UninvoicedSalesCreditReportCommand()),
                new MenuCommand ("Un-Validated Shipment", new UnvalidatedShipmentReportCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Laporan Tonase Per Service", new MonthlyServiceTonnageChartReportCommand()),
                new MenuCommand ("Laporan Sales Per Service", new MonthlyServiceSalesChartReportCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Mobile Point", new MobilePointCommand())
            });

            var counterCash = new ToolStripMenuItem { Text = @"Counter Cash" };
            counterCash.DropDownItems.AddRange(new ToolStripItem[]
            {
                new MenuCommand ("Komisi Drop Point", new DropPointCommissionCommand()),
            });

            var accountReceivable = new ToolStripMenuItem { Text = @"Account Receivable" };
            accountReceivable.DropDownItems.AddRange(new ToolStripItem[]
            {
                new MenuCommand ("Invoices", new InvoicesReportCommand()),
                new MenuCommand ("Paid Invoices", new PaidInvoicesReportCommand()),
                new MenuCommand ("Outstanding Invoices", new OutstandingInvoicesReportCommand()),
                new MenuCommand ("Overdue Invoices", new OverdueInvoicesReportCommand()),
                new MenuCommand ("Due Invoices", new DueInvoicesReportCommand()),
                new MenuCommand ("Aging Report", new InvoiceAgingReportCommand()),
                //new MenuCommand ("Statement of Account", new InvoicesReportCommand()),
            });

            var collectin = new ToolStripMenuItem { Text = @"Collect In" };
            collectin.DropDownItems.AddRange(new ToolStripItem[]
            {
                new MenuCommand ("In-Process (Branch)", new CollectInProcessCommand()),
                new MenuCommand ("Un-Invoiced (Customer)", new CollectInUnInvoiceCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Collect In (Branch)", new CollectInBrCommand()),
                new MenuCommand ("Paid Collect In (Branch)", new PaidCollectInCommand()),
                new MenuCommand ("Outstanding Collect In (Branch)", new OutstandingCollectInCommand())
            });

            var collectout = new ToolStripMenuItem { Text = @"Collect Out" };
            collectout.DropDownItems.AddRange(new ToolStripItem[]
            {
                new MenuCommand ("Collect Out (Branch)", new CollectOutCommand()),
                new MenuCommand ("Paid Collect Out (Branch)", new PaidCollectOutCommand()),
                new MenuCommand ("Outstanding Collect Out (Branch)", new OutstandingCollectOutCommand())
            });

            var finance = new ToolStripMenuItem { Text = @"Finance" };
            finance.DropDownItems.AddRange(new ToolStripItem[]
            {
                new MenuCommand("Claim", new ClaimCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Payment In Journal", new PaymentInJournalCommand()),
                new MenuCommand ("Payment In Detail Journal", new PaymentInDetailJournalCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Outstanding Payment In", new PaymentInOutstandingCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Payment Out Journal", new PaymentOutJournalCommand()),
                new MenuCommand ("Payment Out Detail Journal", new PaymentOutDetailJournalCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Outstanding PPh 23", new OutstandingPphCommand()),
                new MenuCommand ("Retur PPh 23", new ReturnPphCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Pembayaran COD", new CodPaymentCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Buku Bank", new GeneralJournalCommand()),
                new MenuCommand("Buku Bank Belum Posting", new GeneralJournalUnpostedCommand()),
                new MenuCommand ("Laporan Petty Cash", new PettyCashCommand()),
            });

            var cost = new ToolStripMenuItem { Text = @"Cost" };
            cost.DropDownItems.AddRange(new ToolStripItem[]
            {
                new MenuCommand ("Cost Journal per Type", new CostJournalReportCommand()),
                new MenuCommand ("Cost Pivot", new CostPivotCommand())
            });

            var administration = new ToolStripMenuItem { Text = @"Administration" };
            administration.DropDownItems.AddRange(new ToolStripItem[]
            {
                new MenuCommand ("Laporan Aging POD", new PodAgingReportCommand()),
                new MenuCommand ("Laporan Void Cash", new VoidShipmentReportCommand())
            });

            var marketing = new ToolStripMenuItem { Text = @"Marketing" };
            marketing.DropDownItems.AddRange(new ToolStripItem[]
            {
                new MenuCommand ("Laporan Daftar Customer", new CustomerReportCommand()),
                new MenuCommand ("Laporan Sales Lead", new LeadsReportCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Sales Journal (Customer)", new MarketingSalesJournalCustomerReportCommand()),
            });

            var delivery = new ToolStripMenuItem { Text = @"Delivery" };
            delivery.DropDownItems.AddRange(new ToolStripItem[]
            {
                new MenuCommand ("Delivery Journal (Branch)", new DeliveryJournalCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Delivery", new DeliveryCommand()),
                new MenuCommand ("Paid Delivery", new PaidDeliveryCommand()),
                new MenuCommand ("Outstanding Delivery", new OutstandingDeliveryCommand())
            });

            var rc = new ToolStripMenuItem { Text = @"Return Commission" };
            rc.DropDownItems.AddRange(new ToolStripItem[]
            {
                new MenuCommand ("RC Journal (Customer)", new RCJournalCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("RC", new RCCommand()),
                new MenuCommand ("Paid RC", new PaidRCCommand()),
                new MenuCommand ("Outstanding RC", new OutstandingRCCommand())
            });

            var mc = new ToolStripMenuItem { Text = @"Marketing Commission" };
            mc.DropDownItems.AddRange(new ToolStripItem[]
            {
                new MenuCommand ("MC Journal (Customer)", new MCJournalCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("MC", new MCCommand()),
                new MenuCommand ("Paid MC", new PaidMCCommand()),
                new MenuCommand ("Outstanding MC", new OutstandingMCCommand())
            });

            var titip = new ToolStripMenuItem { Text = @"Titip Invoice" };
            titip.DropDownItems.AddRange(new ToolStripItem[]
            {
                new MenuCommand ("Titip Invoice (Customer)", new TitipInvoiceCustomerCommand()),
                new MenuCommand ("Paid Titip Invoice (Customer)", new PaidTitipInvoiceCustomerCommand()),
                new MenuCommand ("Outstanding Titip Invoice (Customer)", new OutstandingTitipInvoiceCustomerCommand()),
                new ToolStripSeparator(),
                new MenuCommand ("Titip Invoice (Branch)", new TitipInvoiceBranchCommand()),
                new MenuCommand ("Paid Titip Invoice (Branch)", new PaidTitipInvoiceBranchCommand()),
                new MenuCommand ("Outstanding Titip Invoice (Branch)", new OutstandingTitipInvoiceBranchCommand())
            });
            
            return new List<ToolStripItem>
            {
                customerService,
                operation,
                sales,
                counterCash,
                accountReceivable,
                collectin,
                collectout,
                finance,
                cost,
                administration,
                marketing,
                new ToolStripSeparator(),
                delivery,
                rc,
                mc,
                titip
            };
        }
    }
}