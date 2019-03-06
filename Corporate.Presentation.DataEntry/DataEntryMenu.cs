using System.Collections.Generic;
using System.Windows.Forms;
using Corporate.Presentation.Common;
using Corporate.Presentation.DataEntry.Command;

namespace Corporate.Presentation.DataEntry
{
    public class DataEntryMenu
    {
        public static List<ToolStripItem> GetMenus()
        {
            return new List<ToolStripItem>
            {
                new MenuCommand("&Entry Econnote", new EntryEconnoteCommand())
            };
        }
    }
}
