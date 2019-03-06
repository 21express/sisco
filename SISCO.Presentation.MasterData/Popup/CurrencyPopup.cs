using System;
using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Interfaces;

namespace SISCO.Presentation.MasterData.Popup
{
    public partial class CurrencyPopup : BaseForm, IPopup
    {
        public CurrencyPopup()
        {
            InitializeComponent();

            Load += LoadGrid;
            btnClear.Click += Clear;
            btnView.Click += FilterData;

            CurrencyView.RowClick += SelectRow;
            BtnSelect.Click += SelectValue;
        }

        private void LoadGrid(object sender, EventArgs e)
        {
            btnView.PerformClick();
        }

        protected void Clear(object sender, EventArgs e)
        {
            tbxName.Text = string.Empty;
            tbxCode.Text = string.Empty;
        }

        protected void FilterData(object sender, EventArgs e)
        {
            var parameters = new List<IListParameter>();

            if (!string.IsNullOrEmpty(tbxCode.Text)) parameters.Add(WhereTerm.Default(tbxName.Text, "code", EnumSqlOperator.BeginWith));
            if (!string.IsNullOrEmpty(tbxName.Text)) parameters.Add(WhereTerm.Default(tbxName.Text, "name", EnumSqlOperator.BeginWith));

            CurrencyGrid.DataSource = new CurrencyDataManager().Get<CurrencyModel>(parameters.ToArray());
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
            int[] rows = CurrencyView.GetSelectedRows();

            SelectedValue = Convert.ToInt32(CurrencyView.GetRowCellValue(rows[0], "Id"));
            SelectedCode = CurrencyView.GetRowCellValue(rows[0], "Code").ToString();
            SelectedText = CurrencyView.GetRowCellValue(rows[0], "Code").ToString();

            Hide();
        }
    }
}
