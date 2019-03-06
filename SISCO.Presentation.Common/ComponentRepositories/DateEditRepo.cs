using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors;

using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Properties;

namespace SISCO.Presentation.Common.ComponentRepositories
{
    public class TextEditRepo : RepositoryItemTextEdit
    {
        static TextEditRepo() { }

        // ReSharper disable once EmptyConstructor
        // ReSharper disable once RedundantBaseConstructorCall
        public TextEditRepo() : base()
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
