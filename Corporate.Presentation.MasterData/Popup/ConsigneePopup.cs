using System;
using System.Collections.Generic;
using Corporate.Presentation.Common;
using Devenlab.Common;
using SISCO.App.Corporate;
using SISCO.Models;
using Corporate.Presentation.Common.Forms;
using Corporate.Presentation.Common.Interfaces;

namespace Corporate.Presentation.MasterData.Popup
{
    public partial class ConsigneePopup : BaseForm, IPopup
    {
        public ConsigneePopup()
        {
            InitializeComponent();

            Load += LoadGrid;
            btnClear.Click += Clear;
            btnView.Click += FilterData;

            BtnSelect.Click += SelectValue;

            ConsigneeView.DoubleClick += SelectRow;
            ConsigneeView.KeyPress += (sender, args) =>
            {
                if (args.KeyChar == 13) SelectRow(sender, args);
            };

            Shown += (sender, args) => tbxName.Focus();
        }

        private void LoadGrid(object sender, EventArgs e)
        {
            ConsigneeGrid.DataSource = new ConsigneeDataManager().Get<ConsigneeModel>();
        }

        protected void Clear(object sender, EventArgs e)
        {
            tbxName.Text = string.Empty;
        }

        protected void FilterData(object sender, EventArgs e)
        {
            var param = new List<WhereTerm>();
            param.Add(WhereTerm.Default(BaseControl.CorporateId, "corporate_id", EnumSqlOperator.Like));

            if (tbxName.Text != "") param.Add(WhereTerm.Default(tbxName.Text, "name", EnumSqlOperator.Like));
            if (tbxAddress.Text != "") param.Add(WhereTerm.Default(tbxAddress.Text, "address", EnumSqlOperator.Like));
            if (tbxPhone.Text != "") param.Add(WhereTerm.Default(tbxPhone.Text, "phone", EnumSqlOperator.Like));

            // ReSharper disable once CoVariantArrayConversion
            ConsigneeGrid.DataSource = new ConsigneeDataManager().Get<ConsigneeModel>(param.ToArray());
            ConsigneeGrid.Focus();
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
            int[] rows = ConsigneeView.GetSelectedRows();

            SelectedValue = Convert.ToInt32(ConsigneeView.GetRowCellValue(rows[0], "Id"));
            SelectedCode = ConsigneeView.GetRowCellValue(rows[0], "Name").ToString();
            SelectedText = ConsigneeView.GetRowCellValue(rows[0], "Name").ToString();

            Hide();
        }
    }
}
