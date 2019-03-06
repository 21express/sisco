using System;
using System.Windows.Forms;
using SISCO.Presentation.Common;
using SISCO.Presentation.CounterCash.Forms;

namespace SISCO.Presentation.CounterCash.Command
{
    public class FranchiseAcceptanceCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new FranchiseAcceptanceForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
