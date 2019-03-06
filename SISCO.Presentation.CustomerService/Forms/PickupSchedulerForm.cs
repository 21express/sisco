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
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.CustomerService.Popup;

namespace SISCO.Presentation.CustomerService.Forms
{
    public partial class PickupSchedulerForm : BaseCrudForm<PickupSchedulerModel, PickupSchedulerDataManager>//BaseToolbarForm//
    {
        private bool EditCustomer { get; set; }

        public PickupSchedulerForm()
        {
            InitializeComponent();
            
            form = this;
            Load += LoadPickupScheduler;
            tbxCustomer.Leave += AutopopulateShipper;
            tbxCustomer.TextChanged += (sender, args) =>
            {
                EditCustomer = true;
            };

            EditCustomer = false;
            CrudState = EnumStateChange.Idle;
            TotalRecord = 0;
            TotalPage = 0;
            PageLimit = 10;
            CurrentIndexPage = 0;
            NavigationState = "";
            ObjectName = "";

            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };
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

        private void LoadPickupScheduler(object sender, EventArgs e)
        {
            EnableBtnSearch = true;
            SearchPopup = new SchedulerPopup();
            
            tbxCustomer.LookupPopup = new CustomerPopup(new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) });
            tbxCustomer.AutoCompleteDataManager = new CustomerDataManager();
            //tbxCustomer.AutoCompleteText = model => ((CustomerModel)model).Name;
            tbxCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            tbxCustomer.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);
            tbxCustomer.FieldLabel = "Customer";
            tbxCustomer.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

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

            tsBaseTxt_Code.Focus();
            tbxPiece.IsNumber = true;
            tbxGrandTotal.IsNumber = true;

            cbxNew.Click += (s, args) =>
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
        }

        public override void New()
        {
            ClearForm();

            ToolbarCode = string.Empty;

            base.New();

            tbxVehicle.DefaultValue = new IListParameter[] { WhereTerm.Default("MOTOR", "name", EnumSqlOperator.Equals) };
            tbxPackage.DefaultValue = new IListParameter[] { WhereTerm.Default("PARCEL", "name", EnumSqlOperator.Equals) };
            tbxService.DefaultValue = new IListParameter[] { WhereTerm.Default("REGULAR", "name", EnumSqlOperator.Equals) };
            tbxPayment.DefaultValue = new IListParameter[] { WhereTerm.Default("CREDIT", "name", EnumSqlOperator.Equals) };

            tbxStartDate.Focus();

            tbxPiece.SetValue(Resources.default_number);
            tbxWeight.SetValue(Resources.default_number);
            tbxGrandTotal.SetValue("0");
        }

        protected override bool ValidateForm()
        {
            if (tbxStartDate.Text != "" && tbxCustomer.Text != "" && tbxAddress.Text != "" && tbxPhone.Text != "" && tbxContact.Text != ""
                && tbxVehicle.Text != "" && tbxPackage.Text != "" && tbxService.Text != "" && tbxPayment.Text != "")
                return true;

            if (!cbxMon.Checked && !cbxTue.Checked && !cbxWed.Checked && !cbxThu.Checked && !cbxFri.Checked && !cbxSat.Checked && !cbxSun.Checked)
            {
                cbxMon.Focus();
                return false;
            }

            if (tbxStartDate.Text == "")
            {
                tbxStartDate.Focus();
                return false;
            }

            if (tbxCustomer.Text == "")
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

        protected override void PopulateForm(PickupSchedulerModel model)
        {
            ClearForm();

            if (model == null) return;
            
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            ToolbarCode = model.Id.ToString();

            cbxActive.Checked = model.Active;
            cbxMon.Checked = model.Mon;
            cbxTue.Checked = model.Tue;
            cbxWed.Checked = model.Wed;
            cbxThu.Checked = model.Thu;
            cbxFri.Checked = model.Fri;
            cbxSat.Checked = model.Sat;
            cbxSun.Checked = model.Sun;

            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxStartDate.DateTime = model.StartDate;

            if (model.CustomerId != null)
            {
                cbxNew.Checked = false;
                tbxCustomer.DefaultValue = new IListParameter[] { WhereTerm.Default((int)model.CustomerId, "id", EnumSqlOperator.Equals) };
            }
            else
            {
                cbxNew.Checked = true;
                tbxCustomer.Text = " ";
                tbxCustomer.Text = model.CustomerName;
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

            tbxAddress.Focus();
        }

        protected override PickupSchedulerModel PopulateModel(PickupSchedulerModel model)
        {
            model.Active = cbxActive.Checked;
            model.Mon = cbxMon.Checked;
            model.Tue = cbxTue.Checked;
            model.Wed = cbxWed.Checked;
            model.Thu = cbxThu.Checked;
            model.Fri = cbxFri.Checked;
            model.Sat = cbxSat.Checked;
            model.Sun = cbxSun.Checked;
            model.StartDate = tbxStartDate.Value;
            model.EmployeeId = BaseControl.EmployeeId;
            if (tbxCustomer.Value != null) model.CustomerId = tbxCustomer.Value;
            model.CustomerName = tbxCustomer.Text;
            model.CustomerAddress = tbxAddress.Text;
            model.CustomerPhone = tbxPhone.Text;
            model.CustomerContact = tbxContact.Text;
            model.Note = tbxNote.Text;
            if (tbxVehicle.Value != null) model.VehicleTypeId = (int)tbxVehicle.Value;
            if (tbxMessenger.Value != null) model.MessengerId = (int)tbxMessenger.Value;
            if (tbxPackage.Value != null) model.PackageTypeId = (int)tbxPackage.Value;
            if (tbxService.Value != null) model.ServiceTypeId = (int)tbxService.Value;
            if (tbxPayment.Value != null) model.PaymentMethodId = (int)tbxPayment.Value;
            model.TtlPiece = (sbyte) tbxPiece.Value;
            model.TtlGrossWeight = (decimal) tbxWeight.Value;
            model.Dimension = tbxDimensi.Text;
            model.NatureOfGoods = tbxIsi.Text;
            model.Total = (int) tbxGrandTotal.Value;
            model.BranchId = BaseControl.BranchId;

            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override PickupSchedulerModel Find(string searchTerm)
        {
            int value;
            int.TryParse(tsBaseTxt_Code.Text, out value);
            var param = new IListParameter[]
                {
                    WhereTerm.Default(value, "id", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<PickupSchedulerModel>(param);
            PopulateForm(obj);

            return obj;
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();
        }

        public override void Info()
        {
            var model = CurrentModel as PickupSchedulerModel;
            Debug.Assert(model != null, "model != null");
            info.CreatedPc = model.CreatedPc;
            info.ModifiedPc = model.ModifiedPc;

            base.Info();
        }
    }
}