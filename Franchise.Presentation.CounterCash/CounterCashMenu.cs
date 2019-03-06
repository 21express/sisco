using System.Collections.Generic;
using System.Windows.Forms;
using Franchise.Presentation.Common;
using Franchise.Presentation.CounterCash.Command;

namespace Franchise.Presentation.CounterCash
{
    public class CounterCashMenu
    {
        public static List<ToolStripItem> GetMenus()
        {
            return new List<ToolStripItem>
            {
                new MenuCommand("&Counter Cash", new CounterCashCommand()),
                new MenuCommand("&Data Entry", new DataEntryCommand()),
            };
        }
    }
}
