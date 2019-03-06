using SISCO.Presentation.Common;
using SISCO.Presentation.Franchise.Forms;
using System;
using System.Windows.Forms;

namespace SISCO.Presentation.Franchise.Command
{
    public class CorrectionDataEntryCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new CorrectionDataEntryForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}