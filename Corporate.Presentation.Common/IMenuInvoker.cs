using System.Windows.Forms;

namespace Corporate.Presentation.Common
{
    public interface IMenuInvoker
    {
        void open();
        void open(Form parent);
    }
}
