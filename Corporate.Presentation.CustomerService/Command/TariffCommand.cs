using System;
using System.Windows.Forms;
using Corporate.Presentation.Common;
using Corporate.Presentation.CustomerService.Forms;

namespace Corporate.Presentation.CustomerService.Command
{
    public class TariffCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new TariffForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
