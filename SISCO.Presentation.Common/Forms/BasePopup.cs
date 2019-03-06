using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using SISCO.Presentation.Common.Interfaces;
using SISCO.Presentation.Common.Properties;

namespace SISCO.Presentation.Common.Forms
{
    public partial class BasePopup : BasePage, IPopup
    {
        public GridControl objGrid
        {
            get { return grid; }
        }

        public ControlNavigator ObjNavigator
        {
            get { return grid.EmbeddedNavigator; }
        }

        public GridView objGridView
        {
            get { return gridView; }
        }

        public List<IListParameter> Parameters { get; set; }

        public string NavigatorPagingState
        {
            set
            {
                grid.EmbeddedNavigator.Enabled = true;
                grid.EmbeddedNavigator.TextStringFormat = value;
                if (CurrentIndexPage == 1)
                {
                    grid.EmbeddedNavigator.Buttons.CustomButtons[0].Enabled = false;
                    grid.EmbeddedNavigator.Buttons.CustomButtons[1].Enabled = false;
                    grid.EmbeddedNavigator.Buttons.CustomButtons[2].Enabled = true;
                    grid.EmbeddedNavigator.Buttons.CustomButtons[3].Enabled = true;
                }

                if (CurrentIndexPage > 1)
                {
                    grid.EmbeddedNavigator.Buttons.CustomButtons[0].Enabled = true;
                    grid.EmbeddedNavigator.Buttons.CustomButtons[1].Enabled = true;
                    grid.EmbeddedNavigator.Buttons.CustomButtons[2].Enabled = true;
                    grid.EmbeddedNavigator.Buttons.CustomButtons[3].Enabled = true;
                }

                if (CurrentIndexPage == TotalPage)
                {
                    grid.EmbeddedNavigator.Buttons.CustomButtons[0].Enabled = true;
                    grid.EmbeddedNavigator.Buttons.CustomButtons[1].Enabled = true;
                    grid.EmbeddedNavigator.Buttons.CustomButtons[2].Enabled = false;
                    grid.EmbeddedNavigator.Buttons.CustomButtons[3].Enabled = false;
                }

                if (TotalPage == 0 || TotalPage == 1)
                {
                    grid.EmbeddedNavigator.Buttons.CustomButtons[0].Enabled = false;
                    grid.EmbeddedNavigator.Buttons.CustomButtons[1].Enabled = false;
                    grid.EmbeddedNavigator.Buttons.CustomButtons[2].Enabled = false;
                    grid.EmbeddedNavigator.Buttons.CustomButtons[3].Enabled = false;
                }
            }
        }

        public BasePopup()
        {
            InitializeComponent();

            btnSelect.Click += SelectRow;
            gridView.DoubleClick += SelectRow;

            /*tbxFilterId.KeyPress += (sender, args) =>
            {
                if (args.KeyChar == 13) Filter(sender, args);
            };

            tbxFilterName.KeyPress += (sender, args) =>
            {
                if (args.KeyChar == 13) Filter(sender, args);
            };*/

            gridView.KeyPress += (sender, args) =>
            {
                if (args.KeyChar == 13) SelectRow(sender, args);
            };

            Load += LoadPopup;
            btnClear.Click += ClearFilter;
            btnSearch.Click += Filter;

            Parameters = new List<IListParameter>();
            Shown += (sender, args) =>
            {
                // ReSharper disable once ConvertToLambdaExpression
                tbxFilterId.Focus();
            };
        }

        protected virtual void Filter(object sender, EventArgs e)
        {
            bool removeParam = true;
            var p = Parameters;
            if (p.Any()) removeParam = false;

            if (tbxFilterId.Text != "") p.Add(new WhereTerm { Value = tbxFilterId.Text, TableName = "", ColumnName = "code", Operator = EnumSqlOperator.Like, ParamDataType = EnumParameterDataTypes.Character });
            if (tbxFilterName.Text != "") p.Add(new WhereTerm { Value = tbxFilterName.Text, TableName = "", ColumnName = "name", Operator = EnumSqlOperator.Like, ParamDataType = EnumParameterDataTypes.Character });

            AutoCompleteWheretermFormater = p.ToArray();

            if (removeParam) Parameters = new List<IListParameter>();
            gridView.Focus();
        }

        protected virtual void ClearFilter(object sender, EventArgs e)
        {
            tbxFilterId.Text = "";
            tbxFilterName.Text = "";

            Filter(sender, e);
            //AutoCompleteWheretermFormater = null;
        }

        public virtual void LoadPopup(object sender, EventArgs e)
        {
            SelectedText = string.Empty;
            SelectedValue = 0;
            CurrentIndexPage = 0;
            PageLimit = 10;
        }

        public int SelectedValue { get; set; }
        public string SelectedCode { get; set; }
        public string SelectedText { get; set; }

        public virtual void SelectRow(object sender, EventArgs e)
        {
            var rows = gridView.GetSelectedRows();

            if (rows.Count() > 0)
            {
                SelectedValue = Convert.ToInt32(gridView.GetRowCellValue(rows[0], "Id"));
                SelectedCode = gridView.GetRowCellValue(rows[0], "Code").ToString();
                SelectedText = gridView.GetRowCellValue(rows[0], "Name").ToString();

                Hide();
            }
            else MessageBox.Show(Resources.alert_choose_data, Resources.information);
        }
    }
}
