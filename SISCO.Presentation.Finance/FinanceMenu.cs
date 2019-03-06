using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SISCO.Presentation.Common;
using SISCO.Presentation.Finance.Command;
using System.Windows.Forms;

namespace SISCO.Presentation.Finance
{
    public class FinanceMenu
    {
        public static List<ToolStripItem> GetMenus()
        {
            return new List<ToolStripItem>
            {
                new MenuCommand("Input Rekening Koran", new InputTransactionalAccountCommand()),
                new MenuCommand("Lihat Rekening Koran", new TransactionalAccountCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Tutup Transaksi Buku Bank", new ClosingBankTransactionCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Payment &In", new PaymentInCommand()),
                new MenuCommand("Pengembalian PPh 23", new RefundPph23Command()),
                new ToolStripSeparator(),
                new MenuCommand("Payment In &Counter", new PaymentInCounterCommand()),
                new MenuCommand("Counter Cash List", new PaymentCounterListCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Pembayaran Invoice Agent Franchise", new FranchiseCreditPaymentCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Pembayaran Counter Cash Agent &Franchise", new FranchisePaymentInCommand()),
                new MenuCommand("Transfer Pembayaran Agent Franchise", new FranchiseFundTransferCommand()),
                new MenuCommand("Verifikasi Terima Transfer Agent", new FranchiseFundTransferVerificationCommand()),
                new MenuCommand("Franchise Outstanding", new FranchiseOutstandingShipmentCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Pembayaran COD", new CodPaymentInCommand()),
                new MenuCommand("Transfer Pembayaran COD", new CodFundTransferCommand()),
                new MenuCommand("Verifikasi Terima Transfer COD", new CodFundTransferVerificationCommand()),
                new MenuCommand("COD Outstanding", new CodOutstandingCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Collect In &List", new CollectInListCommand()),
                new MenuCommand("&Payment In Collect In", new PaymentInCollectInCommand()),
                new MenuCommand("P&ayment Out Collect In", new PaymentOutCollectInCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Collect &Out List", new CollectOutListCommand()),
                new MenuCommand("Pa&yment In Collect Out", new PaymentInCollectOutCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Payment Out &Delivery", new PaymentOutDeliveryCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Payment Out &RC", new PaymentOutRCCommand()),
                new MenuCommand("Payment Out &MC", new PaymentOutMCCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Petty Cash", new PettyCashCommand()),
                new MenuCommand("Cost", new CostCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Invoice Acceptance", new SalesInvoiceAcceptanceCommand()),
                new MenuCommand("Invoice Distribution", new InvoiceDistributionResultCommand()),
                new MenuCommand("Kirim Invoice Transfer", new InvoiceTransferCommand()),
                new MenuCommand("Terima Invoice Transfer", new InvoiceTransferAcceptanceCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Laporan Distribusi Invoice", new InvoiceDistributionReportCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Titip In&voice", new TitipInvoiceCommand()),
                new MenuCommand("Kirim Titip Invoice", new SendTitipInvoiceCommand()),
                new MenuCommand("Payment Titip Invoice View", new TitipInvoiceViewCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Te&rima Titip Invoice", new TitipInvoiceAcceptanceCommand()),
                new MenuCommand("Titip Invoice List", new TitipInvoiceListCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Pay&ment In Titip Invoice", new PaymentInTitipInvoiceCommand()),
                new MenuCommand("Paym&ent Out Titip Invoice", new PaymentOutTitipInvoiceCommand())
            };
        }
    }
}