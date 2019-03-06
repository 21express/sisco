using System.Collections.Generic;
using System.Windows.Forms;
using Franchise.Presentation.Common;
using Franchise.Presentation.MasterData.Command;

namespace Franchise.Presentation.MasterData
{
    public class MasterDataMenu
    {
        public static List<ToolStripItem> GetMenus()
        {
            return new List<ToolStripItem>
            {
                new MenuCommand("Customer", new FranchiseCustomerCommand()),
            };
        }
    }
}
