using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;

namespace Corporate.Presentation.Common.ComponentRepositories
{
    public class TextEditCRepo : RepositoryItemTextEdit
    {
        static TextEditCRepo() { }

        // ReSharper disable once EmptyConstructor
        // ReSharper disable once RedundantBaseConstructorCall
        public TextEditCRepo() : base()
        {

            AllowMouseWheel = false;

            KeyDown += (sender, args) =>
            {
                if (args.KeyCode == Keys.Enter)
                {
                    args.Handled = true;
                    SendKeys.Send("{TAB}");
                }
            };
        }
    }
}
