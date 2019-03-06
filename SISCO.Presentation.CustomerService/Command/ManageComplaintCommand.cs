using System;

using SISCO.Presentation.Common;
using SISCO.Presentation.CustomerService.Forms;
using System.Windows.Forms;

namespace SISCO.Presentation.CustomerService.Command
{
    public class ManageComplaintCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var a = new ComplaintForm { MdiParent = parent };
            BaseControl.OpenForm(a, GetType());
        }
    }
}
