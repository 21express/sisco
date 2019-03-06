using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SISCO.Presentation.Common;
using System.Windows.Forms;
using SISCO.Presentation.Marketing.Forms;

namespace SISCO.Presentation.Marketing.Command
{
    public class ManageContactsCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new ManageContactsForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
