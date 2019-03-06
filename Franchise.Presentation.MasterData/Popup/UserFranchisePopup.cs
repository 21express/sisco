using Devenlab.Common;
using Franchise.Presentation.Common;
using Franchise.Presentation.Common.Forms;
using Franchise.Presentation.Common.Interfaces;
using SISCO.App.Franchise;
using SISCO.App.MasterData;
using SISCO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Franchise.Presentation.MasterData.Popup
{
    public partial class UserFranchisePopup : BaseForm, IPopup
    {
        public UserFranchisePopup()
        {
            InitializeComponent();

            Load += LoadGrid;
            btnClear.Click += Clear;
            btnView.Click += FilterData;

            BtnSelect.Click += SelectValue;

            UserView.DoubleClick += SelectRow;
            UserView.KeyPress += (sender, args) =>
            {
                if (args.KeyChar == 13) SelectRow(sender, args);
            };

            Shown += (sender, args) => tbxName.Focus();
        }

        private void SelectValue(object sender, EventArgs e)
        {
            int[] rows = UserView.GetSelectedRows();

            SelectedValue = Convert.ToInt32(UserView.GetRowCellValue(rows[0], "Id"));
            SelectedCode = UserView.GetRowCellValue(rows[0], "UserName").ToString();
            SelectedText = UserView.GetRowCellValue(rows[0], "UserName").ToString();

            Hide();
        }

        private void FilterData(object sender, EventArgs e)
        {
            var param = new List<WhereTerm>();
            if (tbxName.Text != "") param.Add(WhereTerm.Default(tbxName.Text, "username", EnumSqlOperator.Like));
            param.Add(WhereTerm.Default(BaseControl.FranchiseId, "franchise_id"));

            // ReSharper disable once CoVariantArrayConversion
            GridUser.DataSource = new UserFranchiseDataManager().Get<UserFranchiseModel>(param.ToArray());
            GridUser.Focus();
        }

        private void Clear(object sender, EventArgs e)
        {
            tbxName.Text = string.Empty;
        }

        private void LoadGrid(object sender, EventArgs e)
        {
            GridUser.DataSource = new UserFranchiseDataManager().Get<UserFranchiseModel>(WhereTerm.Default(BaseControl.FranchiseId, "franchise_id"));
        }

        public int SelectedValue { get; set; }
        public string SelectedCode { get; set; }
        public string SelectedText { get; set; }

        public void SelectRow(object sender, EventArgs e)
        {
            BtnSelect.PerformClick();
        }
    }
}
