using System.Collections.Generic;
using System.Windows.Forms;
using Corporate.Presentation.Common;
using Corporate.Presentation.CounterCash.Command;

namespace Corporate.Presentation.CounterCash
{
    public class CounterCashMenu
    {
        public static List<ToolStripItem> GetMenus()
        {
            return new List<ToolStripItem>
            {
                new MenuCommand("&Counter Cash", new CounterCashCommand())
            };
        }
    }
}
