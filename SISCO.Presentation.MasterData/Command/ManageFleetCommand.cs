using System;
using System.Collections.Generic;

using SISCO.Presentation.Common;
using SISCO.Presentation.MasterData.Forms;
using System.Windows.Forms;

namespace SISCO.Presentation.MasterData.Command
{
    public class ManageFleetCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new ManageFleetForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
