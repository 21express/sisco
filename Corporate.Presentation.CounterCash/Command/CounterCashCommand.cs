using System.Windows.Forms;
using Corporate.Presentation.Common;
using Corporate.Presentation.CounterCash.Forms;

namespace Corporate.Presentation.CounterCash.Command
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
