using SISCO.Presentation.Audit.Forms;
using SISCO.Presentation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Audit.Command
{
    public class OutstandingVerificationInvoiceCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new OutstandingVerificationInvoiceForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
