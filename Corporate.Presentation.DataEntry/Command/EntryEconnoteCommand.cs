using System.Windows.Forms;
using Corporate.Presentation.Common;
using Corporate.Presentation.DataEntry.Forms;

namespace Corporate.Presentation.DataEntry.Command
{
    public class EntryEconnoteCommand : IMenuInvoker
    {
        public void open()
        {
            throw new System.NotImplementedException();
        }

        public void open(Form parent)
        {
            var form = new EntryEconnoteForm { MdiParent = parent };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
