using System;
using SISCO.Presentation.Common;
using System.Windows.Forms;
using SISCO.Presentation.Finance.Forms;

namespace SISCO.Presentation.Finance.Command
{
    class PaymentOutDeliveryCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new PaymentOutDeliveryForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}   