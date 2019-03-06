using Franchise.Presentation.Common;
using Franchise.Presentation.DropPoint.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Franchise.Presentation.DropPoint.Command
{
    public class FranchiseDropPointCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new PickupDropPointForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
