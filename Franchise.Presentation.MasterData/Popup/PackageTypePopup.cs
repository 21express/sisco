using System;
using System.Collections.Generic;
using Devenlab.Common;
using SISCO.App.MasterData;
using SISCO.Models;
using Franchise.Presentation.Common.Forms;
using Franchise.Presentation.Common.Interfaces;

namespace Franchise.Presentation.MasterData.Popup
{
    public partial class PackageTypePopup : BaseForm, IPopup
    {
        public PackageTypePopup()
        {
            InitializeComponent();

            Load += LoadGrid;
            btnClear.Click += Clear;
            btnView.Click += FilterData;
            BtnSelect.Click += SelectValue;

            PackageTypeView.DoubleClick += SelectRow;
            PackageTypeView.KeyPress += (sender, args) =>
            {
                if (args.KeyChar == 13) SelectRow(sender, args);
            };

            Shown += (sender, args) => tbxName.Focus();
        }

        private void LoadGrid(object sender, EventArgs e)
        {
            PackageTypeGrid.DataSource = new PackageTypeDataManager().Get<PackageTypeModel>();
        }

        protected void Clear(object sender, EventArgs e)
        {
            tbxName.Text = string.Empty;
        }

        protected void FilterData(object sender, EventArgs e)
        {
            var param = new List<WhereTerm>();
            if (tbxName.Text != "") param.Add(WhereTerm.Default(tbxName.Text, "name", EnumSqlOperator.Like));

            // ReSharper disable once CoVariantArrayConversion
            PackageTypeGrid.DataSource = new PackageTypeDataManager().Get<PackageTypeModel>(param.ToArray());
            PackageTypeGrid.Focus();
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
            int[] rows = PackageTypeView.GetSelectedRows();

            SelectedValue = Convert.ToInt32(PackageTypeView.GetRowCellValue(rows[0], "Id"));
            SelectedCode = PackageTypeView.GetRowCellValue(rows[0], "Name").ToString();
            SelectedText = PackageTypeView.GetRowCellValue(rows[0], "Name").ToString();

            Hide();
        }
    }
}
