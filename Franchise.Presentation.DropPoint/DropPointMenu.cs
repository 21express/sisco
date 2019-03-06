using Franchise.Presentation.DropPoint.Command;
using System.Collections.Generic;
using System.Windows.Forms;
using Franchise.Presentation.Common;

namespace Franchise.Presentation.DropPoint
{
    public class DropPointMenu
    {
        public static List<ToolStripItem> GetMenus()
        {
            return new List<ToolStripItem>
            {
                new MenuCommand("Pickup", new FranchiseDropPointCommand())
            };
        }
    }
}
