using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using SISCO.Models.MasterData;
using SISCO.Presentation.Common.Interfaces;

namespace SISCO.Presentation.MasterData.Popup
{
    public partial class UserPopup : BaseForm, IPopup
    {
        public List<IListParameter> Parameters { get; set; }

        public UserPopup()
        {
            InitializeComponent();

            Parameters = new List<IListParameter>();

            Load += LoadGrid;
            btnClear.Click += Clear;
            btnView.Click += FilterData;

            UserView.RowClick += SelectRow;
            BtnSelect.Click += SelectValue;
        }

        private void LoadGrid(object sender, EventArgs e)
        {
            UserGrid.DataSource = new UsersDataManager().Get<UsersModel>(Parameters.ToArray());
        }

        protected void Clear(object sender, EventArgs e)
        {
            tbxCode.Text = string.Empty;
        }

        protected void FilterData(object sender, EventArgs e)
        {
            Parameters.Clear();

            if (!string.IsNullOrEmpty(tbxCode.Text)) Parameters.Add(WhereTerm.Default(tbxCode.Text, "username", EnumSqlOperator.Like));

            LoadGrid(sender, e);
        }

        public int SelectedValue { get; set; }
        public string SelectedCode { get; set; }

        public string SelectedText { get; set; }

        public void SelectRow(object sender, EventArgs e)
        {
            BtnSelect.PerformClick();
        }

        public void SelectValue(object sender, EventArgs e)
        {
            int[] rows = UserView.GetSelectedRows();

            SelectedValue = Convert.ToInt32(UserView.GetRowCellValue(rows[0], "Id"));
            SelectedCode = UserView.GetRowCellValue(rows[0], "Username").ToString();
            SelectedText = UserView.GetRowCellValue(rows[0], "Username").ToString();

            this.Hide();
        }
    }
}
