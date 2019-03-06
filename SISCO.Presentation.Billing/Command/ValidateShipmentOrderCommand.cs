using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SISCO.Presentation.Common;
using System.Windows.Forms;
using SISCO.Presentation.Billing.Forms;

namespace SISCO.Presentation.Billing.Command
{
    public class ValidateShipmentOrderCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new ValidateShipmentOrderForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
