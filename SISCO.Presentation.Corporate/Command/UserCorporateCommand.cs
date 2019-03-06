using System;
using SISCO.Presentation.Common;
using System.Windows.Forms;
using SISCO.Presentation.Corporate.Forms;

namespace SISCO.Presentation.Corporate.Command
{
    public class UserCorporateCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new UserCorporateForm{ MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
