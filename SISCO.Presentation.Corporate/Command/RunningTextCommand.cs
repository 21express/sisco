using System;
using System.Windows.Forms;
using SISCO.Presentation.Common;
using SISCO.Presentation.Corporate.Forms;

namespace SISCO.Presentation.Corporate.Command
{
    public class RunningTextCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new RunningTextForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
