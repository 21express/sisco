using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SISCO.Presentation.Common;
using SISCO.Presentation.CustomerService.Forms;
using System.Windows.Forms;

namespace SISCO.Presentation.CustomerService.Command
{
    public class PickupCashCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var a = new PickupCashForm { MdiParent = parent };
            BaseControl.OpenForm(a, GetType());
        }
    }
}
