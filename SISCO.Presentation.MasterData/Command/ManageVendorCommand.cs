using SISCO.Presentation.Common;
using SISCO.Presentation.MasterData.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.MasterData.Command
{
    public class ManageVendorCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new ManageVendorForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}