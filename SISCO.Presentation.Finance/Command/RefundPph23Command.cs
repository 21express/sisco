using System;
using SISCO.Presentation.Common;
using System.Windows.Forms;
using SISCO.Presentation.Finance.Forms;

namespace SISCO.Presentation.Finance.Command
{
    public class RefundPph23Command : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new RefundPph23Form { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
