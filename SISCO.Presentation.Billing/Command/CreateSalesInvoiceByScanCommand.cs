using System;
using SISCO.Presentation.Common;
using System.Windows.Forms;
using SISCO.Presentation.Billing.Forms;

namespace SISCO.Presentation.Billing.Command
{
    public class CreateSalesInvoiceByScanCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new CreateSalesInvoiceByScanForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
