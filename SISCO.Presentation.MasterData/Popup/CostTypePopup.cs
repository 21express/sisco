using System;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Interfaces;
using Devenlab.Common;

namespace SISCO.Presentation.MasterData.Popup
{
    public partial class CostTypePopup : BaseForm, IPopup
    {
        public CostTypePopup()
        {
            InitializeComponent();

            Load += LoadGrid;
            btnClear.Click += Clear;
            btnView.Click += FilterData;

            CostTypeView.RowClick += SelectRow;
            BtnSelect.Click += SelectValue;
        }

        private void LoadGrid(object sender, EventArgs e)
        {
            CostTypeGrid.DataSource = new CostTypeDataManager().Get<CostTypeModel>();
        }

        protected void Clear(object sender, EventArgs e)
        {
            tbxName.Text = string.Empty;
            LoadGrid(sender, e);
        }

        protected void FilterData(object sender, EventArgs e)
        {
            if (tbxName.Text != "")
                CostTypeGrid.DataSource = new CostTypeDataManager().Get<CostTypeModel>(WhereTerm.Default(tbxName.Text, "name", EnumSqlOperator.Like));
            else LoadGrid(sender, e);
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
            int[] rows = CostTypeView.GetSelectedRows();

            SelectedValue = Convert.ToInt32(CostTypeView.GetRowCellValue(rows[0], "Id"));
            SelectedText = CostTypeView.GetRowCellValue(rows[0], "Name").ToString();

            Hide();
        }
    }
}
