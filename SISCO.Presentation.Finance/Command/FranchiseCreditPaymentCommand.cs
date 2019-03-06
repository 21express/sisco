using System;
using SISCO.Presentation.Common;
using System.Windows.Forms;
using SISCO.Presentation.Finance.Forms;

namespace SISCO.Presentation.Finance.Command
{
    public class FranchiseCreditPaymentCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new FranchiseCreditPaymentForm{ MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
