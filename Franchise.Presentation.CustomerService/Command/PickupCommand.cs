using System;
using System.Windows.Forms;
using Franchise.Presentation.Common;
using Franchise.Presentation.CustomerService.Forms;

namespace Franchise.Presentation.CustomerService.Command
{
    public class PickupCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new PickupForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
