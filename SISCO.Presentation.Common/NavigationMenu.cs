using System.Collections.Generic;
using System.Windows.Forms;
using SISCO.Presentation.Common.Properties;

namespace SISCO.Presentation.Common
{
    public class NavigationMenu
    {
        public static ToolStripMenuItem NewStrip { get; set; }
        public static ToolStripMenuItem SaveStrip { get; set; }
        public static ToolStripMenuItem DeleteStrip { get; set; }
        public static ToolStripMenuItem TopStrip { get; set; }
        public static ToolStripMenuItem PreviousStrip { get; set; }
        public static ToolStripMenuItem NextStrip { get; set; }
        public static ToolStripMenuItem BottomStrip { get; set; }
        public static ToolStripMenuItem FindStrip { get; set; }
        public static ToolStripMenuItem RefreshStrip { get; set; }
        public static ToolStripSeparator Separator1 { get; set; }
        public static ToolStripMenuItem DetailNewStrip { get; set; }
        public static ToolStripMenuItem DetailDeleteStrip { get; set; }
        public static ToolStripSeparator DetailSeparator1 { get; set; }
        public static ToolStripMenuItem CloseStrip { get; set; }
        public static ToolStripMenuItem PrintStrip { get; set; }

        public static void EnableButtons(bool enabled)
        {
            NewStrip.Enabled = enabled;
            SaveStrip.Enabled = enabled;
            DeleteStrip.Enabled = enabled;
            TopStrip.Enabled = enabled;
            PreviousStrip.Enabled = enabled;
            NextStrip.Enabled = enabled;
            BottomStrip.Enabled = enabled;
            FindStrip.Enabled = enabled;
            RefreshStrip.Enabled = enabled;
            CloseStrip.Enabled = enabled;
            PrintStrip.Enabled = enabled;
        }

        public static List<ToolStripItem> GetMenus()
        {
            NewStrip = new ToolStripMenuItem
            {
                Text = @"&New",
                ShortcutKeys = ((Keys.Control | Keys.N)),
                Enabled = false,
                Image = Resources.icon_new
            };

            SaveStrip = new ToolStripMenuItem
            {
                Text = @"&Save",
                ShortcutKeys = ((Keys.Control | Keys.S)),
                Enabled = false,
                Image = Resources.icon_save
            };

            DeleteStrip = new ToolStripMenuItem
            {
                Text = @"&Delete",
                ShortcutKeys = ((Keys.Control | Keys.D)),
                Enabled = false,
                Image = Resources.icon_delete
            };

            TopStrip = new ToolStripMenuItem
            {
                Text = @"Top",
                ShortcutKeys = ((Keys.Control | Keys.PageUp)),
                Enabled = false,
                Image = Resources.go_first
            };

            TopStrip = new ToolStripMenuItem
            {
                Text = @"Top",
                ShortcutKeys = ((Keys.Control | Keys.PageUp)),
                Enabled = false,
                Image = Resources.go_first
            };

            PreviousStrip = new ToolStripMenuItem
            {
                Text = @"Previous",
                ShortcutKeys = ((Keys.Control | Keys.Up)),
                Enabled = false,
                Image = Resources.go_previous
            };

            NextStrip = new ToolStripMenuItem
            {
                Text = @"Next",
                ShortcutKeys = ((Keys.Control | Keys.Down)),
                Enabled = false,
                Image = Resources.go_next
            };

            BottomStrip = new ToolStripMenuItem
            {
                Text = @"Bottom",
                ShortcutKeys = ((Keys.Control | Keys.PageDown)),
                Enabled = false,
                Image = Resources.go_last
            };

            FindStrip = new ToolStripMenuItem
            {
                Text = @"&Find",
                ShortcutKeys = ((Keys.Control | Keys.F)),
                Enabled = false,
                Image = Resources.system_search
            };

            RefreshStrip = new ToolStripMenuItem
            {
                Text = @"&Refresh",
                ShortcutKeys = ((Keys.Control | Keys.R)),
                Enabled = false,
                Image = Resources.view_refresh
            };

            DetailNewStrip = new ToolStripMenuItem
            {
                Text = @"Detail New",
                ShortcutKeys = ((Keys.F2)),
                Enabled = true,
                Visible = false,
            };

            DetailDeleteStrip = new ToolStripMenuItem
            {
                Text = @"Detail Delete",
                ShortcutKeys = ((Keys.F3)),
                Enabled = true,
                Visible = false,
            };

            CloseStrip = new ToolStripMenuItem
            {
                Text = @"Close",
                ShortcutKeys = ((Keys.Control | Keys.W)),
                Enabled = true,
                Visible = true
            };

            PrintStrip = new ToolStripMenuItem
            {
                Text = @"Print",
                ShortcutKeys = ((Keys.Control | Keys.P)),
                Enabled = true,
                Visible = true
            };

            CloseStrip.Click += (sender, args) => BaseControl.Close();
            NewStrip.Click += (sender, args) => BaseControl.New();
            SaveStrip.Click += (sender, args) => BaseControl.Save();
            DeleteStrip.Click += (sender, args) => BaseControl.Delete();
            TopStrip.Click += (sender, args) => BaseControl.Top();
            PreviousStrip.Click += (sender, args) => BaseControl.Previous();
            NextStrip.Click += (sender, args) => BaseControl.Next();
            BottomStrip.Click += (sender, args) => BaseControl.Bottom();
            FindStrip.Click += (sender, args) => BaseControl.Find();
            RefreshStrip.Click += (sender, args) => BaseControl.Refresh();

            DetailNewStrip.Click += (sender, args) => BaseControl.DetailNew();
            DetailDeleteStrip.Click += (sender, args) => BaseControl.DetailDelete();
            PrintStrip.Click += (sender, args) => BaseControl.Print();

            Separator1 = new ToolStripSeparator {Name = "Navigation_Separator1"};
            DetailSeparator1 = new ToolStripSeparator { Name = "Navigation_detail_separator_1" };

            return new List<ToolStripItem>
            {
                CloseStrip,
                NewStrip,
                Separator1,
                SaveStrip,
                DeleteStrip,
                new ToolStripSeparator(),
                TopStrip,
                PreviousStrip,
                NextStrip,
                BottomStrip,
                new ToolStripSeparator(),
                FindStrip,
                new ToolStripSeparator(),
                RefreshStrip,
                new ToolStripSeparator(),
                DetailNewStrip,
                DetailDeleteStrip,
                DetailSeparator1,
                PrintStrip
            };
        }
    }
}
