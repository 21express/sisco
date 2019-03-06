using System;
using System.Collections.Generic;

using SISCO.Presentation.Common;
using System.Windows.Forms;
using SISCO.Presentation.MasterData.Forms;

namespace SISCO.Presentation.MasterData.Command
{
    public class ManageBranchCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new ManageBranchForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
