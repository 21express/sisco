using System;
using System.Windows.Forms;
using SISCO.Presentation.Finance.Forms;
using SISCO.Presentation.Common;

namespace SISCO.Presentation.Finance.Command
{
    public class PaymentInTitipInvoiceCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new PaymentInTitipInvoiceForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
