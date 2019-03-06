using System;
using System.Windows.Forms;
using Corporate.Presentation.Common;
using Corporate.Presentation.CustomerService.Forms;

namespace Corporate.Presentation.CustomerService.Command
{
    public class TrackingViewCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new TrackingViewForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
