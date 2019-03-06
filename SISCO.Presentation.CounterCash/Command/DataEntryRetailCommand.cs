using System;

using SISCO.Presentation.Common;
using System.Windows.Forms;
using SISCO.Presentation.CounterCash.Forms;

namespace SISCO.Presentation.CounterCash.Command
{
    public class DataEntryRetailCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new CounterRetailForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}