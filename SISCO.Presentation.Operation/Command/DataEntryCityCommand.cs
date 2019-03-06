using System;

using SISCO.Presentation.Common;
using SISCO.Presentation.Operation.Forms;
using System.Windows.Forms;

namespace SISCO.Presentation.Operation.Command
{
    public class DataEntryCityCommand : IMenuInvoker
    {
        public string _moduleName { get; set; }
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var a = new DataEntryCityForm { MdiParent = parent };
            BaseControl.OpenForm(a, GetType(), _moduleName);
        }
    }
}
