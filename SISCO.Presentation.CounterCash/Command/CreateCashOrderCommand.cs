using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SISCO.Presentation.Common;
using System.Windows.Forms;
using SISCO.Presentation.CounterCash.Forms;

namespace SISCO.Presentation.CounterCash.Command
{
    public class CreateCashOrderCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new CounterCashForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
