using System;
using SISCO.Presentation.Common;
using System.Windows.Forms;
using SISCO.Presentation.MasterData.Forms;

namespace SISCO.Presentation.MasterData.Command
{
    public class ManageCostTypeCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new ManageCostTypeForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
