using SISCO.Presentation.Administration.Forms;
using SISCO.Presentation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Administration.Command
{
    public class BookingPodCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new BookingNumberAllocationForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
