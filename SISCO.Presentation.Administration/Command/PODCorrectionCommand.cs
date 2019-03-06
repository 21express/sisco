using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SISCO.Presentation.Common;
using System.Windows.Forms;
using SISCO.Presentation.Administration.Forms;

namespace SISCO.Presentation.Administration.Command
{
    public class PODCorrectionCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new PODCorrectionForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
