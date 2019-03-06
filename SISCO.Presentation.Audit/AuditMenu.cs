using SISCO.Presentation.Audit.Command;
using SISCO.Presentation.Common;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SISCO.Presentation.Audit
{
    public class AuditMenu
    {
        public static List<ToolStripItem> GetMenus()
        {
            return new List<ToolStripItem>
            {
                new MenuCommand("Verifikasi Counter Cash", new VerificationCashCommand()),
                new MenuCommand("Verifikasi Collect", new VerificationCollectCommand()),
                new MenuCommand("Verifikasi Invoice", new VerificationInvoiceCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Outstanding Verifikasi Cash", new OutstandingVerificationCashCommand()),
                new MenuCommand("Outstanding Verifikasi Collect", new OutstandingVerificationCollectCommand()),
                new MenuCommand("Outstanding Verifikasi Invoice", new OutstandingVerificationInvoiceCommand())
            };
        }
    }
}