using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SISCO.Presentation.Common;
using SISCO.Presentation.CounterCash.Command;
using System.Windows.Forms;

namespace SISCO.Presentation.CounterCash
{
    public class CounterCashMenu
    {
        public static List<ToolStripItem> GetMenus()
        {
            return new List<ToolStripItem>
            {
                new MenuCommand("&Counter Cash", new CreateCashOrderCommand()),
                new MenuCommand("Counter Cash (Sprinter)", new CounterCashSprinterCommand()),
                new MenuCommand("&Retail", new DataEntryRetailCommand()),
                new ToolStripSeparator(),
                new MenuCommand("&Franchise Acceptance", new FranchiseAcceptanceCommand())
            };
        }
    }
}
