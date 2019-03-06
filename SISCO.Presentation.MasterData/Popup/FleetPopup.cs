using System;
using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraEditors;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Interfaces;
using BaseControl = SISCO.Presentation.Common.BaseControl;

namespace SISCO.Presentation.MasterData.Popup
{
    public partial class FleetPopup : BaseForm, IPopup
    {
        public List<IListParameter> Parameters { get; set; }

        public FleetPopup()
        {
            InitializeComponent();

            Parameters = new List<IListParameter>();

            Load += (sender, args) =>
            {
                lkpBranch.LookupPopup = new BranchPopup();
                lkpBranch.AutoCompleteDataManager = new BranchDataManager();
                lkpBranch.AutoCompleteDisplayFormater =
                    model => ((BranchModel) model).Code + " - " + ((BranchModel) model).Name;
                lkpBranch.AutoCompleteWhereExpression =
                    (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

                lkpBranch.Enabled = false;
                lkpBranch.Properties.Buttons[0].Enabled = false;

                var branch =
                    new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(BaseControl.BranchId, "id",
                        EnumSqlOperator.Equals));
                lkpBranch.Value = branch.Id;
                lkpBranch.Text = string.Format("{0} - {1}", branch.Code, branch.Name);

                Parameters.Add(WhereTerm.Default((int)lkpBranch.Value, "branch_id"));

                lkpVehicleType.LookupPopup = new VehiclePopup();
                lkpVehicleType.AutoCompleteDataManager = new VehicleTypeDataManager();
                lkpVehicleType.AutoCompleteDisplayFormater =
                    model => ((VehicleTypeModel)model).Name;
                lkpVehicleType.AutoCompleteWhereExpression =
                    (s, p) => p.SetWhereExpression("name.StartsWith(@0)", s);

                LoadGrid();
            };

            btnClear.Click += Clear;
            btnView.Click += FilterData;

            GridView.RowClick += SelectRow;
            BtnSelect.Click += SelectValue;
        }

        private void LoadGrid()
        {
            Grid.DataSource = new FleetDataManager().Get<FleetModel>(Parameters.ToArray());
        }

        protected void Clear(object sender, EventArgs e)
        {
            lkpBranch.Text = string.Empty;
            lkpVehicleType.Text = string.Empty;
            txtPlateNumber.Text = string.Empty;
            txtBrand.Text = string.Empty;
            txtModel.Text = string.Empty;
        }

        protected void FilterData(object sender, EventArgs e)
        {
            Parameters.Clear();

            if (lkpBranch.Value != null) Parameters.Add(WhereTerm.Default((int)lkpBranch.Value, "branch_id"));
            if (lkpVehicleType.Value != null) Parameters.Add(WhereTerm.Default((int)lkpVehicleType.Value, "vehicle_type_id"));
            if (!string.IsNullOrEmpty(txtPlateNumber.Text)) Parameters.Add(WhereTerm.Default(txtPlateNumber.Text, "plate_number", EnumSqlOperator.Like));
            if (!string.IsNullOrEmpty(txtBrand.Text)) Parameters.Add(WhereTerm.Default(txtBrand.Text, "brand", EnumSqlOperator.Like));
            if (!string.IsNullOrEmpty(txtModel.Text)) Parameters.Add(WhereTerm.Default(txtModel.Text, "model", EnumSqlOperator.Like));

            LoadGrid();
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
            int[] rows = GridView.GetSelectedRows();

            SelectedValue = Convert.ToInt32(GridView.GetRowCellValue(rows[0], "Id"));
            SelectedCode = GridView.GetRowCellValue(rows[0], "PlateNumber").ToString();
            SelectedText = GridView.GetRowCellValue(rows[0], "PlateNumber").ToString();

            Hide();
        }
    }
}
