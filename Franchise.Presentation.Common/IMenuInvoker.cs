using System.Windows.Forms;

namespace Franchise.Presentation.Common
{
    public interface IMenuInvoker
    {
        void open();
        void open(Form parent);
    }
}
