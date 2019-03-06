using System;
using System.Linq;
using System.Windows.Forms;
using SISCO.Presentation.Common.Interfaces;
using SISCO.Presentation.Common.Properties;
using TextBox = System.Windows.Forms.TextBox;

namespace SISCO.Presentation.Common.Forms
{
    public partial class BaseSearchPopup : BasePage, IPopup
    {
        public string CodeColumn { get; set; }

        public BaseSearchPopup()
        {
            InitializeComponent();

            CodeColumn = "Code";

            Load += SearchLoad;
            btnClear.Click += Clear;
            btnSelect.Click += SelectRow;
            GridSearch.DoubleClick += SelectRow;
            SearchView.KeyPress += (sender, args) =>
            {
                if (args.KeyChar == 13) SelectRow(sender, args);
            };
            SearchView.CustomColumnDisplayText += NumberGrid;
            clNo.Width = 30;

            Shown += (sender, args) => tbxCode.Focus();
        }

        private void SearchLoad(object sender, EventArgs e)
        {
            SelectedValue = 0;
            SelectedText = string.Empty;
            AutoCompleteWheretermFormater = null;
            
            tbxCode.Focus();
        }

        protected virtual void Clear(object sender, EventArgs e)
        {
            foreach (Control ctlr in Controls)
            {
                if (ctlr is TextBox) ctlr.Text = string.Empty;
            }

            AutoCompleteWheretermFormater = null;
            _ClearForm(MainContainer.Panel1);
        }

        public int SelectedValue { get; set; }
        public string SelectedCode { get; set; }
        public string SelectedText { get; set; }

        public void SelectRow(object sender, EventArgs e)
        {
            var rows = SearchView.GetSelectedRows();

            if (rows.Count() > 0)
            {
                SelectedValue = Convert.ToInt32(SearchView.GetRowCellValue(rows[0], "Id"));
                SelectedCode = SearchView.GetRowCellValue(rows[0], CodeColumn).ToString();
                SelectedText = SearchView.GetRowCellValue(rows[0], CodeColumn).ToString();

                Hide();
            }
            else MessageBox.Show(Resources.alert_choose_data, Resources.information);
        }

        public string NavigatorPagingState
        {
            set
            {
                GridSearch.EmbeddedNavigator.Enabled = true;
                GridSearch.EmbeddedNavigator.TextStringFormat = value ?? "";
                if (CurrentIndexPage == 1)
                {
                    GridSearch.EmbeddedNavigator.Buttons.CustomButtons[0].Enabled = false;
                    GridSearch.EmbeddedNavigator.Buttons.CustomButtons[1].Enabled = false;
                    GridSearch.EmbeddedNavigator.Buttons.CustomButtons[2].Enabled = true;
                    GridSearch.EmbeddedNavigator.Buttons.CustomButtons[3].Enabled = true;
                }

                if (CurrentIndexPage > 1)
                {
                    GridSearch.EmbeddedNavigator.Buttons.CustomButtons[0].Enabled = true;
                    GridSearch.EmbeddedNavigator.Buttons.CustomButtons[1].Enabled = true;
                    GridSearch.EmbeddedNavigator.Buttons.CustomButtons[2].Enabled = true;
                    GridSearch.EmbeddedNavigator.Buttons.CustomButtons[3].Enabled = true;
                }

                if (CurrentIndexPage == TotalPage)
                {
                    GridSearch.EmbeddedNavigator.Buttons.CustomButtons[0].Enabled = true;
                    GridSearch.EmbeddedNavigator.Buttons.CustomButtons[1].Enabled = true;
                    GridSearch.EmbeddedNavigator.Buttons.CustomButtons[2].Enabled = false;
                    GridSearch.EmbeddedNavigator.Buttons.CustomButtons[3].Enabled = false;
                }

                if (TotalPage == 0 || TotalPage == 1)
                {
                    GridSearch.EmbeddedNavigator.Buttons.CustomButtons[0].Enabled = false;
                    GridSearch.EmbeddedNavigator.Buttons.CustomButtons[1].Enabled = false;
                    GridSearch.EmbeddedNavigator.Buttons.CustomButtons[2].Enabled = false;
                    GridSearch.EmbeddedNavigator.Buttons.CustomButtons[3].Enabled = false;
                }
            }
        }
    }
}
