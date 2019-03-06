using System;
using System.Windows.Forms;
using SISCO.Presentation.Common;
using SISCO.Presentation.Franchise.Forms;

namespace SISCO.Presentation.Franchise.Command
{
    public class ShipmentDeliveryCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new ShipmentDeliveryListForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
