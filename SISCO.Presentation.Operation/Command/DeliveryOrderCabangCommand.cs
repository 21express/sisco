using System;

using SISCO.Presentation.Common;
using SISCO.Presentation.Operation.Forms;
using System.Windows.Forms;

namespace SISCO.Presentation.Operation.Command
{
    public class DeliveryOrderCabangCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var a = new DeliveryOrderCabangForm { MdiParent = parent };
            BaseControl.OpenForm(a, GetType());
        }
    }
}
