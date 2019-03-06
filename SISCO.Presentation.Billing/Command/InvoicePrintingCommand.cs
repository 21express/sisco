using SISCO.Presentation.Common;
using SISCO.Presentation.Billing.Forms;
using System;
using System.Windows.Forms;

namespace SISCO.Presentation.Billing.Command
{
    public class InvoicePrintingCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new InvoicePrintingForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}