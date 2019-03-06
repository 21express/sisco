using System;
using System.Windows.Forms;
using Franchise.Presentation.Common;
using Franchise.Presentation.CustomerService.Forms;

namespace Franchise.Presentation.CustomerService.Command
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
