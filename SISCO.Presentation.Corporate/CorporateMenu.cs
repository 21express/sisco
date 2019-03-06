using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SISCO.Presentation.Common;
using SISCO.Presentation.Corporate.Command;
using System.Windows.Forms;

namespace SISCO.Presentation.Corporate
{
    public class CorporateMenu
    {
        public static List<ToolStripItem> GetMenus()
        {
            var masterdata = new ToolStripMenuItem { Text = @"&Master Data" };
            masterdata.DropDownItems.AddRange(new ToolStripItem[]
            {
                new MenuCommand("&User Corporate", new UserCorporateCommand()),
                new MenuCommand("&Announcement", new RunningTextCommand())
            });

            return new List<ToolStripItem>
            {
                masterdata,
                new ToolStripSeparator(),
                new MenuCommand("&Bulk Data Entry", new BulkDataEntryCommand()),
                new MenuCommand("&Syncronous Data Entry", new SyncShipmentCommand())
            };
        }
    }
}
