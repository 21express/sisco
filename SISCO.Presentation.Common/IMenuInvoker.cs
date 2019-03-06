using System.Windows.Forms;

namespace SISCO.Presentation.Common
{
    public interface IMenuInvoker
    {
        void open();
        void open(Form parent);
    }
}
