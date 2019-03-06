using SISCO.Presentation.Common;
using SISCO.Presentation.CounterCash.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.CounterCash.Command
{
    public class CounterCashSprinterCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new CounterCashSprinterForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}