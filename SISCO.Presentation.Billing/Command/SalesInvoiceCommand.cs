using System;
using SISCO.Presentation.Common;
using System.Windows.Forms;
using SISCO.Presentation.Billing.Forms;

namespace SISCO.Presentation.Billing.Command
{
    public class SalesInvoiceCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new SalesInvoiceForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
