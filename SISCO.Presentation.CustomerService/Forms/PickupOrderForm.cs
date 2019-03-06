using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using Devenlab.Common.Interfaces;
using DevExpress.XtraGrid.Views.Grid;
using SISCO.App.CustomerService;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.MasterData.Popup;
using Devenlab.Common;
using SISCO.App.Franchise;
using SISCO.Presentation.CustomerService.Popup;

namespace SISCO.Presentation.CustomerService.Forms
{
    public partial class PickupOrderForm : BaseCrudForm<PickupOrderModel, PickupOrderDataManager>//BaseToolbarForm//
    {
        private bool EditCustomer { get; set; }

        public PickupOrderForm()
        {
            InitializeComponent();
            
            form = this;
            Load += LoadPickupOrder;
            btnRefresh.Click += FilterList;
            PickupOrderView.CustomColumnDisplayText += NumberGrid;
            PickupOrderView.RowStyle += ChangeColor;
            PickupOrderGrid.DoubleClick += GenerateFormData;
            btnExport.Click += (sender, args) => ExportExcel(PickupOrderGrid);
            tbxCustomer.Leave += AutopopulateShipper;
            tbxCustomer.TextChanged += (sender, args) =>
            {
                EditCustomer = true;
            };

            //Shown += (sender, args) => Bottom();

            cbxNew.CheckedChanged += (sender, args) =>
            {
                if (cbxNew.Checked) tbxCustomer.ClearOnLeave = false;
                else tbxCustomer.ClearOnLeave = true;

                tbxCustomer.Text = @" ";
                cbxNew.Focus();
                tbxCustomer.Value = null;
                tbxCustomer.Text = "";
                tbxAddress.Clear();
                tbxPhone.Clear();
                tbxContact.Clear();

                tbxCustomer.Focus();
            };

            EditCustomer = false;
            CrudState = EnumStateChange.Idle;
            TotalRecord = 0;
            TotalPage = 0;
            PageLimit = 10;
            CurrentIndexPage = 0;
            NavigationState = "";
            ObjectName = "";

            VisibleBtnSearch = false;
            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };

            rbCustomer.CheckedChanged += (xs, o) => RadioChanged();
            rbFranchise.CheckedChanged += (xs, o) => RadioChanged();
            rbDropPoint.CheckedChanged += (xs, o) => RadioChanged();
        }

        private void RadioChanged()
        {
            tbxCustomer.Text = string.Empty;
            tbxCustomer.Value = null;
            lkpFranchise.Text = string.Empty;
            lkpFranchise.Value = null;
            lkpDropPoint.Text = string.Empty;
            lkpDropPoint.Value = null;

            if (rbCustomer.Checked)
            {
                tbxCustomer.Enabled = true;
                tbxCustomer.Properties.Buttons[0].Enabled = true;
                cbxNew.Enabled = true;
                cbxNew.Checked = false;
                if (!_isPopulatingForm) tbxCustomer.Focus();
                lkpFranchise.Enabled = false;
                lkpFranchise.Properties.Buttons[0].Enabled = false;
                lkpDropPoint.Enabled = false;
                lkpDropPoint.Properties.Buttons[0].Enabled = false;
            }

            if (rbFranchise.Checked)
            {
                tbxCustomer.Enabled = false;
                tbxCustomer.Properties.Buttons[0].Enabled = false;
                cbxNew.Enabled = false;
                cbxNew.Checked = false;
                lkpFranchise.Enabled = true;
                lkpFranchise.Properties.Buttons[0].Enabled = true;
                if (!_isPopulatingForm) lkpFranchise.Focus();
                lkpDropPoint.Enabled = false;
                lkpDropPoint.Properties.Buttons[0].Enabled = false;
            }

            if (rbDropPoint.Checked)
            {
                tbxCustomer.Enabled = false;
                tbxCustomer.Properties.Buttons[0].Enabled = false;
                cbxNew.Enabled = false;
                cbxNew.Checked = false;
                lkpFranchise.Enabled = false;
                lkpFranchise.Properties.Buttons[0].Enabled = false;
                lkpDropPoint.Enabled = true;
                lkpDropPoint.Properties.Buttons[0].Enabled = true;
                if (!_isPopulatingForm) lkpDropPoint.Focus();
            }
        }

        private void AutopopulateShipper(object sender, EventArgs e)
        {
            if (EditCustomer)
            {
                if (tbxCustomer.Value != null)
                {
                    var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int)tbxCustomer.Value, "id", EnumSqlOperator.Equals));

                    if (customer != null)
                    {
                        tbxContact.Text = @"-";
                        tbxAddress.Text = customer.Address;
                        tbxPhone.Text = @"-";
                    }
                }

                EditCustomer = false;
            }
        }

        private void GenerateFormData(object sender, EventArgs e)
        {
            var rows = PickupOrderView.GetSelectedRows();

            if (rows.Count() > 0) OpenData(PickupOrderView.GetRowCellValue(rows[0], "Id").ToString());
        }

        private void ChangeColor(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                Debug.Assert(view != null, "view != null");

                e.Appearance.ForeColor = Color.Red;
                if ((bool) view.GetRowCellValue(e.RowHandle, view.Columns["Confirmed"]))
                    e.Appearance.ForeColor = Color.Green;

                if ((bool)view.GetRowCellValue(e.RowHandle, view.Columns["PickedUp"]))
                    e.Appearance.ForeColor = Color.Blue;
            }
        }

        private void LoadPickupOrder(object sender, EventArgs e)
        {
            ucConfirmed.Label = "Confirmed";
            ucConfirmed.Icon = false;

            ucPickedup.Label = "Picked Up";
            ucPickedup.Icon = false;

            _SetControlEnableState(pnlSearch, true);
            cbxFilterShow.SelectedIndex = 1;
            
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxFilterDate.DateTime = DateTime.Now;

            var objModel = new PickupOrderDataManager().Grid(cbxFilterShow.SelectedIndex, tbxFilterDate.Value,
                tbxFilterMessenger.Value);
            PickupOrderGrid.DataSource = objModel;

            tbxCustomer.LookupPopup = new CustomerPopup(new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) });
            tbxCustomer.AutoCompleteDataManager = new CustomerDataManager();
            //tbxCustomer.AutoCompleteText = model => ((CustomerModel)model).Name;
            tbxCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            tbxCustomer.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);
            tbxCustomer.TextChanged += (o, args) =>
            {
                if (tbxCustomer.Value != null)
                {
                    tbxAddress.Text = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int)tbxCustomer.Value, "id")).Address;
                }
            };

            lkpFranchise.LookupPopup = new FranchisePopup(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            lkpFranchise.AutoCompleteDataManager = new FranchiseDataManager();
            lkpFranchise.AutoCompleteDisplayFormater = model => ((FranchiseModel)model).Code + " - " + ((FranchiseModel)model).Name;
            lkpFranchise.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);

            lkpFranchise.TextChanged += (o, args) =>
            {
                if (lkpFranchise.Value != null)
                {
                    tbxAddress.Text = new FranchiseDataManager().GetFirst<FranchiseModel>(WhereTerm.Default((int)lkpFranchise.Value, "id")).Address;
                }
            };

            lkpDropPoint.LookupPopup = new DropPointPopup(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            lkpDropPoint.AutoCompleteDataManager = new DropPointDataManager();
            lkpDropPoint.AutoCompleteDisplayFormater = model => ((DropPointModel)model).Code + " - " + ((DropPointModel)model).Name;
            lkpDropPoint.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);

            lkpDropPoint.TextChanged += (o, args) =>
            {
                if (lkpDropPoint.Value != null)
                {
                    tbxAddress.Text = new DropPointDataManager().GetFirst<DropPointModel>(WhereTerm.Default((int)lkpDropPoint.Value, "id")).Address;
                }
            };

            tbxEmployee.LookupPopup = new EmployeePopup(EmployeeModel.EmployeeType.CustomerService);
            tbxEmployee.AutoCompleteDataManager = new EmployeeDataManager();
            //tbxEmployee.AutoCompleteText = model => ((EmployeeModel)model).Name;
            tbxEmployee.AutoCompleteDisplayFormater = model => ((EmployeeModel) model).Code;
            tbxEmployee.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            tbxMessenger.LookupPopup = new MessengerPopup();
            tbxMessenger.AutoCompleteDataManager = new EmployeeDataManager();
            tbxMessenger.AutoCompleteText = model => ((EmployeeModel)model).Name;
            tbxMessenger.AutoCompleteDisplayFormater =
                model => ((EmployeeModel) model).Code + " - " + ((EmployeeModel) model).Name;
            tbxMessenger.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND as_messenger AND branch_id = @1", s, BaseControl.BranchId);
            
            tbxVehicle.LookupPopup = new VehiclePopup();
            tbxVehicle.AutoCompleteDataManager = new VehicleTypeDataManager();
            tbxVehicle.AutoCompleteDisplayFormater = model => ((VehicleTypeModel) model).Name;
            tbxVehicle.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            tbxPackage.LookupPopup = new PackagePopup();
            tbxPackage.AutoCompleteDataManager = new PackageDataManager();
            tbxPackage.AutoCompleteDisplayFormater = model => ((PackageTypeModel) model).Name;
            tbxPackage.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            tbxService.LookupPopup = new ServicePopup();
            tbxService.AutoCompleteDataManager = new ServiceDataManager();
            tbxService.AutoCompleteDisplayFormater = model => ((ServiceTypeModel) model).Name;
            tbxService.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            tbxPayment.LookupPopup = new PaymentMethodPopup();
            tbxPayment.AutoCompleteDataManager = new PaymentMethodDataManager();
            tbxPayment.AutoCompleteDisplayFormater = model => ((PaymentMethodModel) model).Name;
            tbxPayment.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            tbxFilterMessenger.LookupPopup = new MessengerPopup();
            tbxFilterMessenger.AutoCompleteDataManager = new EmployeeDataManager();
            tbxFilterMessenger.AutoCompleteText = model => ((EmployeeModel)model).Name;
            tbxFilterMessenger.AutoCompleteDisplayFormater =
                model => ((EmployeeModel) model).Code + " - " + ((EmployeeModel) model).Name;
            tbxFilterMessenger.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("code = @0 OR name.StartsWith(@0) AND as_messenger", s);

            tsBaseTxt_Code.Focus();
            tbxPiece.IsNumber = true;
            tbxGrandTotal.IsNumber = true;
        }

        private void FilterList(object sender, EventArgs e)
        {
            var objModel = tbxFilterDate.Text != "" ? new PickupOrderDataManager().Grid(cbxFilterShow.SelectedIndex, tbxFilterDate.Value, tbxFilterMessenger.Value) : new PickupOrderDataManager().Grid(cbxFilterShow.SelectedIndex, null, tbxFilterMessenger.Value);
            PickupOrderGrid.DataSource = objModel;
        }

        protected override void AfterSave()
        {
            base.AfterSave();
            
            tbxCustomer.TextChanged += (sender, args) =>
            {
                EditCustomer = true;
            };
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            ToolbarCode = CurrentModel.Id.ToString();
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            OpenData(CurrentModel.Id.ToString());
            StateChange = EnumStateChange.Select;

            var objModel = tbxFilterDate.Text != "" ? new PickupOrderDataManager().Grid(cbxFilterShow.SelectedIndex, tbxFilterDate.Value, tbxFilterMessenger.Value) : new PickupOrderDataManager().Grid(cbxFilterShow.SelectedIndex, null, tbxFilterMessenger.Value);
            PickupOrderGrid.DataSource = objModel;
        }

        public override void New()
        {
            base.New();

            _ClearForm(pnlBlue);
            _ClearForm(pnlGreen);
            _ClearForm(pnlPink);
            rbCustomer.Checked = true;
            rbFranchise.Checked = false;
            rbDropPoint.Checked = false;
            RadioChanged();

            ToolbarCode = string.Empty;

            tbxEmployee.DefaultValue = new IListParameter[] { WhereTerm.Default(BaseControl.EmployeeId, "id", EnumSqlOperator.Equals) };
            tbxVehicle.DefaultValue = new IListParameter[] { WhereTerm.Default("MOTOR", "name", EnumSqlOperator.Equals) };
            tbxPackage.DefaultValue = new IListParameter[] { WhereTerm.Default("PARCEL", "name", EnumSqlOperator.Equals) };
            tbxService.DefaultValue = new IListParameter[] { WhereTerm.Default("REGULAR", "name", EnumSqlOperator.Equals) };
            tbxPayment.DefaultValue = new IListParameter[] { WhereTerm.Default("CREDIT", "name", EnumSqlOperator.Equals) };
            
            // ReSharper disable SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = DateTime.Now.ToString();
            tbxPickupDate.Text = DateTime.Now.ToString();
            // ReSharper restore SpecifyACultureInStringConversionExplicitly

            tbxCustomer.Focus();

            tbxPiece.SetValue(Resources.default_number);
            tbxWeight.SetValue(Resources.default_number);
            tbxPickupTime.Text = @"00:00";
            tbxGrandTotal.SetValue("0");
            
            ucConfirmed.Icon = false;
            ucPickedup.Icon = false;
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text != "" && tbxPickupDate.Text != "" && tbxEmployee.Text != ""
                && tbxAddress.Text != "" && tbxPhone.Text != "" && tbxContact.Text != "" && tbxVehicle.Text != ""
                && tbxPackage.Text != "" && tbxService.Text != "" && tbxPayment.Text != "")
                return true;

            if (tbxDate.Text == "")
            {
                tbxDate.Focus();
                return false;
            }

            if (tbxPickupDate.Text == "")
            {
                tbxPickupDate.Focus();
                return false;
            }

            if (tbxEmployee.Text == "")
            {
                tbxEmployee.Focus();
                return false;
            }

            if (tbxCustomer.Text == "" && lkpFranchise.Value == null && lkpDropPoint.Value == null)
            {
                tbxCustomer.Focus();
                return false;
            }

            if (tbxAddress.Text == "")
            {
                tbxAddress.Focus();
                return false;
            }

            if (tbxPhone.Text == "")
            {
                tbxPhone.Focus();
                return false;
            }

            if (tbxContact.Text == "")
            {
                tbxContact.Focus();
                return false;
            }

            if (tbxVehicle.Text == "")
            {
                tbxVehicle.Focus();
                return false;
            }

            if (tbxPackage.Text == "")
            {
                tbxPackage.Focus();
                return false;
            }

            if (tbxService.Text == "")
            {
                tbxService.Focus();
                return false;
            }

            if (tbxPayment.Text == "")
            {
                tbxPayment.Focus();
                return false;
            }

            return false;
        }

        protected override void PopulateForm(PickupOrderModel model)
        {
            _isPopulatingForm = true;
            _ClearForm(pnlBlue);
            _ClearForm(pnlGreen);
            _ClearForm(pnlPink);
            rbCustomer.Checked = false;
            rbFranchise.Checked = false;
            rbDropPoint.Checked = false;

            if (model == null) return;
            
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            ToolbarCode = model.Id.ToString();

            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.DateTime = model.DateProcess;
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxPickupDate.DateTime = model.PickupDate;
            tbxPickupTime.Text = model.PickupDate.ToString("HH:mm");

            tbxEmployee.DefaultValue = new IListParameter[] { WhereTerm.Default(model.EmployeeId, "id", EnumSqlOperator.Equals) };

            cbxNew.Checked = false;
            if (model.NewCustomer)
            {
                rbCustomer.Checked = true;
                RadioChanged();
                cbxNew.Checked = true;
                tbxCustomer.Text = model.CustomerName;
            }
            else if (model.CustomerId != null)
            {
                rbCustomer.Checked = true;
                RadioChanged();
                tbxCustomer.DefaultValue = new IListParameter[] { WhereTerm.Default((int)model.CustomerId, "id", EnumSqlOperator.Equals) };
            }
            else if (model.FranchiseId != null)
            {
                rbFranchise.Checked = true;
                RadioChanged();
                lkpFranchise.DefaultValue = new IListParameter[] { WhereTerm.Default((int)model.FranchiseId, "id", EnumSqlOperator.Equals) };
            }
            else if (model.DropPointId != null)
            {
                rbDropPoint.Checked = true;
                RadioChanged();
                lkpDropPoint.DefaultValue = new IListParameter[] { WhereTerm.Default((int)model.DropPointId, "id", EnumSqlOperator.Equals) };
            }

            tbxAddress.Text = model.CustomerAddress;
            tbxPhone.Text = model.CustomerPhone;
            tbxContact.Text = model.CustomerContact;
            tbxNote.Text = model.Note;
            tbxVehicle.DefaultValue = new IListParameter[] { WhereTerm.Default(model.VehicleTypeId, "id", EnumSqlOperator.Equals) };
            tbxMessenger.DefaultValue = new IListParameter[] { WhereTerm.Default(model.MessengerId, "id", EnumSqlOperator.Equals) };
            tbxPackage.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PackageTypeId, "id", EnumSqlOperator.Equals) };
            tbxService.DefaultValue = new IListParameter[] { WhereTerm.Default(model.ServiceTypeId, "id", EnumSqlOperator.Equals) };
            tbxPayment.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PaymentMethodId, "id", EnumSqlOperator.Equals) };
            
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxPiece.SetValue(model.TtlPiece.ToString());
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxWeight.SetValue(model.TtlGrossWeight.ToString());

            tbxDimensi.Text = model.Dimension;
            tbxIsi.Text = model.NatureOfGoods;
            tbxGrandTotal.SetValue(model.Total.ToString(BaseControl.culture));
            cbxCancelled.Checked = model.Cancelled;

            ucConfirmed.Icon = model.Confirmed;
            ucPickedup.Icon = model.PickedUp;

            tbxAddress.Focus();
            tbxCustomer.Focus();
            _isPopulatingForm = false;
        }

        protected override PickupOrderModel PopulateModel(PickupOrderModel model)
        {
            model.DateProcess = tbxDate.Value;
            model.PickupDate = Convert.ToDateTime((string.Format("{0} {1}", tbxPickupDate.Value.ToString("MM/dd/yyyy"), tbxPickupTime.Text)));
            if (tbxEmployee.Value != null) model.EmployeeId = (int)tbxEmployee.Value;
            if (tbxCustomer.Value != null)
            {
                model.CustomerId = tbxCustomer.Value;
                model.CustomerName = tbxCustomer.Text;
            }
            if (lkpFranchise.Value != null)
            {
                model.FranchiseId = lkpFranchise.Value;
                model.CustomerName = lkpFranchise.Text;
            }
            if (lkpDropPoint.Value != null)
            {
                model.DropPointId = lkpDropPoint.Value;
                model.CustomerName = lkpDropPoint.Text;
            }

            if (cbxNew.Checked) model.CustomerName = tbxCustomer.Text;
            model.CustomerAddress = tbxAddress.Text;
            model.CustomerPhone = tbxPhone.Text;
            model.CustomerContact = tbxContact.Text;
            model.NewCustomer = cbxNew.Checked;
            model.Note = tbxNote.Text;
            model.PickupNote = "";
            model.ReceivedCash = null;
            if (tbxVehicle.Value != null) model.VehicleTypeId = (int)tbxVehicle.Value;
            if (tbxMessenger.Value != null) model.MessengerId = (int)tbxMessenger.Value;
            if (tbxPackage.Value != null) model.PackageTypeId = (int)tbxPackage.Value;
            if (tbxService.Value != null) model.ServiceTypeId = (int)tbxService.Value;
            if (tbxPayment.Value != null) model.PaymentMethodId = (int)tbxPayment.Value;
            if (tbxPayment.Value == 1) model.ReceivedCash = false;
            model.TtlPiece = (sbyte) tbxPiece.Value;
            model.TtlGrossWeight = (decimal) tbxWeight.Value;
            model.Dimension = tbxDimensi.Text;
            model.NatureOfGoods = tbxIsi.Text;
            model.Total = (int) tbxGrandTotal.Value;
            model.BranchId = BaseControl.BranchId;

            model.Cancelled = cbxCancelled.Checked;

            model.Confirmed = ucConfirmed.Icon;
            model.PickedUp = ucPickedup.Icon;

            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override PickupOrderModel Find(string searchTerm)
        {
            int value;
            int.TryParse(tsBaseTxt_Code.Text, out value);
            var param = new IListParameter[]
                {
                    WhereTerm.Default(value, "id", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<PickupOrderModel>(param);
            PopulateForm(obj);

            return obj;
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();
            EditCustomer = false;

            var model = CurrentModel as PickupOrderModel;
            if (model != null && model.Id > 0)
            {
                if (model.Confirmed || model.PickedUp)
                {
                    _SetControlEnableState(pnlBlue, false);
                    _SetControlEnableState(pnlGreen, false);
                    _SetControlEnableState(pnlPink, false);
                }

                if (model.Confirmed && !model.PickedUp && model.ReceivedCash != null && !(bool)model.ReceivedCash)
                {
                    tbxPayment.Enabled = true;
                }

                if (model.Confirmed && model.PickedUp && model.ReceivedCash == null)
                {
                    tbxPayment.Enabled = false;
                }
            }
        }

        public override void Info()
        {
            var model = CurrentModel as PickupOrderModel;
            Debug.Assert(model != null, "model != null");
            info.CreatedPc = model.CreatedPc;
            info.ModifiedPc = model.ModifiedPc;

            base.Info();
        }
    }
}