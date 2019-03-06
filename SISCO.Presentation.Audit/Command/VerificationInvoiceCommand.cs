using SISCO.Presentation.Audit.Forms;
using SISCO.Presentation.Common;
using System;
using System.Windows.Forms;

namespace SISCO.Presentation.Audit.Command
{
    public class VerificationInvoiceCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new VerificationInvoiceForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}