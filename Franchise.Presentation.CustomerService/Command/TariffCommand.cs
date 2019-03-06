using System;
using System.Windows.Forms;
using Franchise.Presentation.Common;
using Franchise.Presentation.CustomerService.Forms;

namespace Franchise.Presentation.CustomerService.Command
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
