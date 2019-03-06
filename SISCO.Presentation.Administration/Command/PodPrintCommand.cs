using SISCO.Presentation.Administration.Forms;
using SISCO.Presentation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Administration.Command
{
    public class PodPrintCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new PODPrintForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
