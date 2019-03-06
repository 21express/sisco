using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors;

using Franchise.Presentation.Common.Component;
using Franchise.Presentation.Common.Properties;

namespace Franchise.Presentation.Common.ComponentRepositories
{
    public class TextEditFRepo : RepositoryItemTextEdit
    {
        static TextEditFRepo() { }

        // ReSharper disable once EmptyConstructor
        // ReSharper disable once RedundantBaseConstructorCall
        public TextEditFRepo() : base()
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
