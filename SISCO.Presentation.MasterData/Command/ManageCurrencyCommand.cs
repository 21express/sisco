using System;
using System.Collections.Generic;

using SISCO.Presentation.Common;
using SISCO.Presentation.MasterData.Forms;
using System.Windows.Forms;

namespace SISCO.Presentation.MasterData.Command
{
    public class ManageCurrencyCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new ManageCurrencyForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
