using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SISCO.Presentation.Common;
using System.Windows.Forms;
using SISCO.Presentation.Marketing.Forms;

namespace SISCO.Presentation.Marketing.Command
{
    public class ManageLeadsCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new ManageLeadsForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
