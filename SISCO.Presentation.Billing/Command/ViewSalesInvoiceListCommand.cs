using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SISCO.Presentation.Common;
using System.Windows.Forms;
using SISCO.Presentation.Billing.Forms;

namespace SISCO.Presentation.Billing.Command
{
    public class ViewSalesInvoiceListCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new ViewSalesInvoiceListForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
