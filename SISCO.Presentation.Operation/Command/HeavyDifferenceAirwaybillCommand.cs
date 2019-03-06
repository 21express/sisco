using System;

using SISCO.Presentation.Common;
using SISCO.Presentation.Operation.Forms;
using System.Windows.Forms;

namespace SISCO.Presentation.Operation.Command
{
    public class HeavyDifferenceAirwaybillCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var a = new DifferenceWeightAirwaybillForm { MdiParent = parent };
            BaseControl.OpenForm(a, GetType());
        }
    }
}