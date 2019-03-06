using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SISCO.Presentation.Common;
using SISCO.Presentation.Administration.Command;
using System.Windows.Forms;

namespace SISCO.Presentation.Administration
{
    public class AdministrationMenu
    {
        public static List<ToolStripItem> GetMenus()
        {
            return new List<ToolStripItem>
            {
                new MenuCommand("&Alokasi CN", new ManageShipmentNumberAllocationCommand()),
                new MenuCommand("&Booking POD", new BookingPodCommand()),
                new ToolStripSeparator(),
                new MenuCommand("&Kirim POD Cabang", new ManageOutgoingPodCommand()),
                //new MenuCommand("Detail Kirim POD Cabang", new ViewOutgoingPODDetailCommand()),
                new MenuCommand("POD Kembali Dari &Cabang", new ManageIncomingPODCommand()),
                //new MenuCommand("Detail POD Kembali Dari Cabang", new ViewIncomingPODDetailCommand()),
                new MenuCommand("POD C&ustomer", new EntryPODReceivedByCustomerCommand()),
                new ToolStripSeparator(),
                new MenuCommand("POD Incoming List", new ViewShipmentIncomingListCommand()),
                new MenuCommand("POD &List", new ViewShipmentListCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Print POD", new PodPrintCommand()),
                new ToolStripSeparator(),
                new MenuCommand("Ko&reksi POD", new PODCorrectionCommand())
            };
        }
    }
}
