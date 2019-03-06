using System;
using SISCO.Presentation.Common;
using System.Windows.Forms;
using SISCO.Presentation.Finance.Forms;

namespace SISCO.Presentation.Finance.Command
{
    public class ClosingBankTransactionCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new ClosingBankTransactionForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
