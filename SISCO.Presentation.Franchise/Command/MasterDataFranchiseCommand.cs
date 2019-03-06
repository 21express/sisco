using System;
using SISCO.Presentation.Common;
using System.Windows.Forms;
using SISCO.Presentation.Franchise.Forms;

namespace SISCO.Presentation.Franchise.Command
{
    public class MasterDataFranchiseCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new MasterDataFranchiseForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
