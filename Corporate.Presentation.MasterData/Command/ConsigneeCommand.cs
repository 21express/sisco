using System;
using System.Windows.Forms;
using Corporate.Presentation.Common;
using Corporate.Presentation.MasterData.Forms;

namespace Corporate.Presentation.MasterData.Command
{
    public class ConsigneeCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new ConsigneeForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
