using SISCO.Presentation.Common;
using SISCO.Presentation.Operation.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Operation.Command
{
    public class ManifestVendorCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var a = new ManifestVendorForm { MdiParent = parent };
            BaseControl.OpenForm(a, GetType());
        }
    }
}