using System;
using Franchise.Presentation.Common;
using System.Windows.Forms;
using Franchise.Presentation.MasterData.Forms;

namespace Franchise.Presentation.MasterData.Command
{
    public class FranchiseCustomerCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new FranchiseCustomerForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
