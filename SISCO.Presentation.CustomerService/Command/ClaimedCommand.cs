using SISCO.Presentation.Common;
using SISCO.Presentation.CustomerService.Forms;
using System;
using System.Windows.Forms;

namespace SISCO.Presentation.CustomerService.Command
{
    public class ClaimedCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var a = new ClaimedForm { MdiParent = parent };

            BaseControl.OpenForm(a, GetType());
        }
    }
}