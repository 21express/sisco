using System;
using System.Collections.Generic;
using Devenlab.Common;
using SISCO.App.MasterData;
using SISCO.Models;
using Franchise.Presentation.Common.Forms;
using Franchise.Presentation.Common.Interfaces;

namespace Franchise.Presentation.MasterData.Popup
{
    public partial class CityPopup : BaseForm, IPopup
    {
        public CityPopup()
        {
            InitializeComponent();

            Load += LoadGrid;
            btnClear.Click += Clear;
            btnView.Click += FilterData;

            BtnSelect.Click += SelectValue;

            CityView.DoubleClick += SelectRow;
            CityView.KeyPress += (sender, args) =>
            {
                if (args.KeyChar == 13) SelectRow(sender, args);
            };

            Shown += (sender, args) => tbxName.Focus();
        }

        private void LoadGrid(object sender, EventArgs e)
        {
            CityGrid.DataSource = new CityDataManager().Get<CityModel>();
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
            CityGrid.DataSource = new CityDataManager().Get<CityModel>(param.ToArray());
            CityGrid.Focus();
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
            int[] rows = CityView.GetSelectedRows();

            SelectedValue = Convert.ToInt32(CityView.GetRowCellValue(rows[0], "Id"));
            SelectedCode = CityView.GetRowCellValue(rows[0], "Name").ToString();
            SelectedText = CityView.GetRowCellValue(rows[0], "Name").ToString();

            Hide();
        }
    }
}
