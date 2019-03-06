using System;
using SISCO.Presentation.Common;
using System.Windows.Forms;
using SISCO.Presentation.Billing.Forms;

namespace SISCO.Presentation.Billing.Command
{
    public class InvoiceTrackingViewCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new InvoiceTrackingViewForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
