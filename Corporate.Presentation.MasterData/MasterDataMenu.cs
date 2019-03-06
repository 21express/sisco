using System.Collections.Generic;
using System.Windows.Forms;
using Corporate.Presentation.Common;
using Corporate.Presentation.MasterData.Command;

namespace Corporate.Presentation.MasterData
{
    public class MasterDataMenu
    {
        public static List<ToolStripItem> GetMenus()
        {
            return new List<ToolStripItem>
            {
                new MenuCommand("Consignee", new ConsigneeCommand()),
            };
        }
    }
}
