using System.Windows.Forms;

namespace SISCO.Presentation.Common
{
    public partial class MenuCommand : ToolStripMenuItem
    {
        public MenuCommand(string text, IMenuInvoker menuInvoker)
        {
            Text = text;
            MenuInvoker = menuInvoker;
        }

        public MenuCommand(string text)
        {
            Text = text;
        }

        public IMenuInvoker MenuInvoker { get; set; }
    }
}
