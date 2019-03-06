using System.Windows.Forms;
using Franchise.Presentation.Common;
using Franchise.Presentation.CounterCash.Forms;

namespace Franchise.Presentation.CounterCash.Command
{
    public class CounterCashCommand : IMenuInvoker
    {
        public void open()
        {
            throw new System.NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new CounterCashForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
