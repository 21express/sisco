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
    public partial class DepartmentPopup : BaseForm, IPopup
    {
        public DepartmentPopup()
        {
            InitializeComponent();

            Load += LoadGrid;
            btnClear.Click += Clear;
            btnView.Click += FilterData;

            DepartmentView.RowClick += SelectRow;
            BtnSelect.Click += SelectValue;
        }

        private void LoadGrid(object sender, EventArgs e)
        {
            btnView.PerformClick();
        }

        protected void Clear(object sender, EventArgs e)
        {
            tbxName.Text = string.Empty;
        }

        protected void FilterData(object sender, EventArgs e)
        {
            var parameters = new List<IListParameter>();

            if (!string.IsNullOrEmpty(tbxName.Text)) parameters.Add(WhereTerm.Default(tbxName.Text, "name", EnumSqlOperator.BeginWith));

            DepartmentGrid.DataSource = new DepartmentDataManager().Get<DepartmentModel>(parameters.ToArray());
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
            int[] rows = DepartmentView.GetSelectedRows();

            SelectedValue = Convert.ToInt32(DepartmentView.GetRowCellValue(rows[0], "Id"));
            SelectedCode = DepartmentView.GetRowCellValue(rows[0], "Name").ToString();
            SelectedText = DepartmentView.GetRowCellValue(rows[0], "Name").ToString();

            this.Hide();
        }
    }
}
