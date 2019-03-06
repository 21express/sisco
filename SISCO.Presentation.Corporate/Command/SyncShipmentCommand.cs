using SISCO.Presentation.Common;
using SISCO.Presentation.Corporate.Forms;
using System;
using System.Windows.Forms;

namespace SISCO.Presentation.Corporate.Command
{
    public class SyncShipmentCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new SyncShipmentForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
