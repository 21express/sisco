using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraGrid.Views.Grid;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Annotations;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManageFleetForm : BaseMasterForm<FleetModel, ManageFleetForm.FleetDataRow, FleetDataManager>
    {
        public class FleetDataRow : FleetModel, INotifyPropertyChanged
        {
            public VehicleTypeDataManager VehicleTypeDataManager { get; set; }
            public BranchDataManager BranchDataManager { get; set; }

            private string _baseBranch;
            public string BaseBranch
            {
                get
                {
                    if (string.IsNullOrEmpty(_baseBranch) && BranchId != 0)
                    {
                        var model = BranchDataManager.GetFirst<BranchModel>(WhereTerm.Default(BranchId, "id"));
                        _baseBranch = string.Format("{0}", model.Code);
                    }
                    return _baseBranch;
                }
                set { _baseBranch = value; }
            }

            private string _vehicleType;
            public new string VehicleType
            {
                get
                {
                    if (string.IsNullOrEmpty(_vehicleType) && VehicleTypeId != 0)
                    {
                        var model = VehicleTypeDataManager.GetFirst<VehicleTypeModel>(WhereTerm.Default(VehicleTypeId, "id"));
                        if (model != null)
                            _vehicleType = string.Format("{0}", model.Name);
                    }
                    return _vehicleType;
                }
                set { _vehicleType = value; }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }

            internal void NotifyUpdate(string propertyName)
            {
                OnPropertyChanged(propertyName);

                switch (propertyName)
                {
                    case "BranchId":
                        BaseBranch = null;
                        NotifyUpdate("BaseBranch");
                        break;
                    case "VehicleTypeId":
                        VehicleType = null;
                        NotifyUpdate("VehicleType");
                        break;
                }
            }
        }

        public VehicleTypeDataManager VehicleTypeDataManager { get; set; }
        public BranchDataManager BranchDataManager { get; set; }

        public ManageFleetForm()
        {
            InitializeComponent();
            form = this;

            BranchDataManager = new BranchDataManager();
            VehicleTypeDataManager = new VehicleTypeDataManager();

            MainModelTransformFunc = model =>
            {
                var row = ConvertModel<FleetModel, FleetDataRow>(model);

                row.BranchDataManager = BranchDataManager;
                row.VehicleTypeDataManager = VehicleTypeDataManager;

                return row;
            };

            tbxVehicleType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbxVehicleType.DataSource = VehicleTypeDataManager.Get<VehicleTypeModel>();
            tbxVehicleType.DisplayMember = "Name";
            tbxVehicleType.ValueMember = "Id";
            tbxVehicleType.SelectedIndex = -1;
            tbxVehicleType.KeyPress += (sender, args) => tbxBrand.Focus();

            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            Init();
        }

        public override void Init()
        {
            CtlClearButton = null;
            CtlDeleteButton = btnDelete;
            CtlGridControl = grid;
            CtlGridView = gridView;
            CtlNewButton = btnNew;
            CtlPanelDetail = grpDetail;
            CtlSaveButton = btnSave;

            base.Init();
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            lkpBaseBranch.LookupPopup = new BranchPopup();
            lkpBaseBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpBaseBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            lkpBaseBranch.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            cmbVehicleType.DataSource = VehicleTypeDataManager.Get<VehicleTypeModel>();
            cmbVehicleType.ValueMember = "Id";
            cmbVehicleType.DisplayMember = "Name";

            txtPlateNumber.FieldLabel = "Plate Number";
            txtPlateNumber.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpBaseBranch.FieldLabel = "Plate Number";
            lkpBaseBranch.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            cmbVehicleType.FieldLabel = "Plate Number";
            cmbVehicleType.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtBrand.FieldLabel = "Brand";
            txtBrand.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtModel.FieldLabel = "Model";
            txtModel.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtYear.FieldLabel = "Year";
            txtYear.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory), new ComponentValidationRule(EnumComponentValidationRule.Number) };

            txtNote.FieldLabel = "Note";

            txtNextExpiryDate.FieldLabel = "Next Registration Expiry Date";
            txtNextExpiryDate.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            gridView.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.Appearance.FocusedCell.Options.UseForeColor = false;
            gridView.OptionsNavigation.UseTabKey = false;
            gridView.OptionsBehavior.FocusLeaveOnTab = true;

            gridView.RowCellStyle += (o, args) =>
            {
                if (args.RowHandle < 0) return;

                if (((DateTime)gridView.GetRowCellValue(args.RowHandle, "NextExpirationDate")) < DateTime.Now.AddMonths(1))
                {
                    args.Appearance.ForeColor = Color.Red;
                }
            };

            PageLimit = 99999;

            form.Enabled = false;
            UseWaitCursor = true;

            var fleets = LoadGrid(GridLoadDirection.First);

            form.Enabled = true;
            UseWaitCursor = false;

            SetDataSource(fleets);
            NavigatorPagingState = PagingState;

            btnFind.Click += FindFleet;
            btnClear.Click += ClearSearch;
        }

        private void ClearSearch(object sender, EventArgs e)
        {
            tbxPlate.Clear();
            tbxVehicleType.SelectedIndex = -1;
            tbxModel.Clear();
            tbxBrand.Clear();

            FindFleet(sender, e);
        }

        private void FindFleet(object sender, EventArgs e)
        {
            DataManager.DefaultParameters = null;
            var param = new List<WhereTerm>();
            if (tbxPlate.Text != "") param.Add(WhereTerm.Default(tbxPlate.Text, "plate_number", EnumSqlOperator.Like));
            if (tbxVehicleType.SelectedValue != null) param.Add(WhereTerm.Default((int)tbxVehicleType.SelectedValue, "vehicle_type_id", EnumSqlOperator.Equals));
            if (tbxBrand.Text != "") param.Add(WhereTerm.Default(tbxBrand.Text, "brand", EnumSqlOperator.Like));
            if (tbxModel.Text != "") param.Add(WhereTerm.Default(tbxModel.Text, "model", EnumSqlOperator.Like));

            if (param.Count > 0) DataManager.DefaultParameters = param.ToArray();

            var fleets = LoadGrid(GridLoadDirection.First);

            SetDataSource(fleets);
            NavigatorPagingState = PagingState;
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            var errors = ComponentValidationHelper.Validate(txtPlateNumber, lkpBaseBranch, cmbVehicleType, txtBrand, txtModel, txtYear, txtNextExpiryDate);

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors));
                return false;
            }

            using (var fleetDm = new FleetDataManager())
            {
                var fleet = fleetDm.GetFirst<FleetModel>(WhereTerm.Default(txtPlateNumber.Text, "plate_number"));
                if (fleet != null && fleet.Id != CurrentModel.Id)
                {
                    MessageBox.Show(@"Plat nomor sudah terdaftar!");
                    return false;
                }
            }

            return true;
        }

        protected override void PopulateForm(FleetModel model)
        {
            txtPlateNumber.Text = model.PlateNumber;
            lkpBaseBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(model.BranchId, "id") };
            cmbVehicleType.SelectedValue = model.VehicleTypeId;
            txtBrand.Text = model.Brand;
            txtModel.Text = model.Model;
            txtYear.Text = model.Year.ToString(CultureInfo.InvariantCulture);
            txtNote.Text = model.Note;
            txtNextExpiryDate.DateTime = model.NextExpirationDate;

            btnDelete.Enabled = true;
        }

        protected override FleetModel PopulateModel(FleetModel model)
        {
            model.PlateNumber = txtPlateNumber.Text;
            model.BranchId = lkpBaseBranch.Value ?? 0;
            model.VehicleTypeId = (int) cmbVehicleType.SelectedValue;
            model.Brand = txtBrand.Text;
            model.Model = txtModel.Text;
            model.Year = Convert.ToInt32(txtYear.Text.Substring(0, 4));
            model.Note = txtNote.Text;
            model.NextExpirationDate = txtNextExpiryDate.DateTime;

            return model;
        }

        protected override IListParameter[] Filter()
        {
            var p = new List<IListParameter>();

            if (lkpBaseBranch.Value != null) p.Add(WhereTerm.Default((int)lkpBaseBranch.Value, "branch_id"));
    
            return p.ToArray();
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();

            txtPlateNumber.Focus();

            btnDelete.Enabled = false;

            lkpBaseBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "id") };

            PageLimit = 99999;
        }
    }
}