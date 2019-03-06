using System;
using System.Collections.Generic;
using Devenlab.Common;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Interfaces;

namespace SISCO.Presentation.MasterData.Popup
{
    public partial class VendorPopup : BaseForm, IPopup
    {
        public VendorPopup()
        {
            InitializeComponent();

            Load += LoadGrid;
            btnClear.Click += Clear;
            btnView.Click += FilterData;
            BtnSelect.Click += SelectValue;

            VendorView.DoubleClick += SelectRow;
            VendorView.KeyPress += (sender, args) =>
            {
                if (args.KeyChar == 13) SelectRow(sender, args);
            };

            Shown += (sender, args) => tbxName.Focus();
        }

        private void LoadGrid(object sender, EventArgs e)
        {
            VendorGrid.DataSource = new VendorDataManager().Get<VendorModel>();
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
            VendorGrid.DataSource = new VendorDataManager().Get<VendorModel>(param.ToArray());
            VendorGrid.Focus();
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
            int[] rows = VendorView.GetSelectedRows();

            SelectedValue = Convert.ToInt32(VendorView.GetRowCellValue(rows[0], "Id"));
            SelectedCode = VendorView.GetRowCellValue(rows[0], "Name").ToString();
            SelectedText = VendorView.GetRowCellValue(rows[0], "Name").ToString();

            Hide();
        }
    }
}
