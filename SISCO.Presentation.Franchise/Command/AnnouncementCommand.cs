using System;
using SISCO.Presentation.Common;
using System.Windows.Forms;
using SISCO.Presentation.Franchise.Forms;

namespace SISCO.Presentation.Franchise.Command
{
    public class AnnouncementCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new AnnouncementForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
