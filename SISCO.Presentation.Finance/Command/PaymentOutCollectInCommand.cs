using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using SISCO.Presentation.Finance.Forms;
using SISCO.Presentation.Common;

namespace SISCO.Presentation.Finance.Command
{
    public class PaymentOutCollectInCommand: IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new PaymentOutCollectInForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
