using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SISCO.Presentation.Common;
using SISCO.Presentation.Marketing.Command;
using System.Windows.Forms;

namespace SISCO.Presentation.Marketing
{
    public class MarketingMenu
    {
        public static List<ToolStripItem> GetMenus()
        {
            return new List<ToolStripItem>
            {
                new MenuCommand("Manage &Contacts", new ManageContactsCommand()),
                new MenuCommand("Manage &Leads", new ManageLeadsCommand())
            };
        }
    }
}
