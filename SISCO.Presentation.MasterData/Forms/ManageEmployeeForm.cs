using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManageEmployeeForm : BaseCrudForm<EmployeeModel, EmployeeDataManager>//BaseToolbarForm//
    {
        public ManageEmployeeForm()
        {
            InitializeComponent();

            form = this;
        }

        protected override void BindDataSource<T>()
        {
            var param = new List<IListParameter>();

            if (BaseControl.RoleId != 2)
            {
                param.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            }

            CurrentModel = LoadModel<T>(param.ToArray());
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            EnableBtnSearch = true;
            if (BaseControl.RoleId != 2)
            {
                SearchPopup = new EmployeePopup(EmployeeModel.EmployeeType.All, WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            }
            else
            {
                SearchPopup = new EmployeePopup();
            }

            lkpBranch.LookupPopup = new BranchPopup();
            lkpBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            lkpBranch.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);
            lkpBranch.FieldLabel = "Branch";
            lkpBranch.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpDepartment.LookupPopup = new DepartmentPopup();
            lkpDepartment.AutoCompleteDataManager = new DepartmentDataManager();
            lkpDepartment.AutoCompleteDisplayFormater = model => ((DepartmentModel)model).Name;
            lkpDepartment.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            lkpAssociatedUser.LookupPopup = new UserPopup();
            lkpAssociatedUser.AutoCompleteDataManager = new UsersDataManager();
            lkpAssociatedUser.AutoCompleteDisplayFormater = model => ((UsersModel)model).Username;
            lkpAssociatedUser.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "username", EnumSqlOperator.BeginWith)
            };


            btnGetID.Click += btnGetID_Click;

            txtCode.FieldLabel = "Code";
            txtCode.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtName.FieldLabel = "Name";
            txtName.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
        }

        void btnGetID_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter the employee name first");
                return;
            }

            if (lkpBranch.Value == null)
            {
                MessageBox.Show(@"Please enter the employee branch first");
                return;
            }

            txtCode.Text = ((EmployeeDataManager)DataManager).GenerateCode(new EmployeeModel
            {
                Name = txtName.Text,
                BranchId = (int)lkpBranch.Value
            });
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            var errors = ComponentValidationHelper.Validate(txtCode, txtName, lkpBranch);

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors));
                return false;
            }

            var duplicate = DataManager.GetFirst<EmployeeModel>(WhereTerm.Default(txtCode.Text, "code"), WhereTerm.Default(true, "rowstatus"));
            if (duplicate != null && duplicate.Id != CurrentModel.Id)
            {
                MessageBox.Show(@"Kode Employee sudah dipakai untuk employee lain!");
                return false;
            }

            return true;
        }

        protected override void PopulateForm(EmployeeModel model)
        {
            txtCode.Text = model.Code;
            txtName.Text = model.Name;

            txtAddress.Text = model.Address;
            txtPhone.Text = model.Phone;
            txtEmail.Text = model.Email;

            chkAsMessenger.Checked = model.AsMessenger;
            chkAsMarketing.Checked = model.AsMarketing;
            chkAsCustomerService.Checked = model.AsCustomerService;
            chkAsCollector.Checked = model.AsCollector;

            lkpBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(model.BranchId, "id") };
            lkpDepartment.DefaultValue = new IListParameter[] { WhereTerm.Default(model.DepartmentId, "id") };

            //cmbRole.SelectedValue = model.EmployeeRoleId;

            lkpAssociatedUser.DefaultValue = new IListParameter[] { WhereTerm.Default(model.UserId ?? 0, "id") };

            tsBaseTxt_Code.Text = model.Code;

            lkpBranch.Enabled = BaseControl.UserRole.Equals("ADMIN");
            btnGetID.Enabled = false;
        }

        protected override EmployeeModel PopulateModel(EmployeeModel model)
        {
            if (txtCode.Text == string.Empty)
            {
                btnGetID.PerformClick();
            }

            model.Code = txtCode.Text;
            model.Name = txtName.Text;

            model.Address = txtAddress.Text;
            model.Phone = txtPhone.Text;
            model.Email = txtEmail.Text;

            model.BranchId = lkpBranch.Value ?? 0;
            model.DepartmentId = lkpDepartment.Value ?? 0;
            model.EmployeeRoleId = 0;

            model.AsMessenger = chkAsMessenger.Checked;
            model.AsMarketing = chkAsMarketing.Checked;
            model.AsCustomerService = chkAsCustomerService.Checked;
            model.AsCollector = chkAsCollector.Checked;

            model.UserId = lkpAssociatedUser.Value;

            return model;
        }

        protected override EmployeeModel Find(string searchTerm)
        {
            var param = new List<IListParameter>
            {
                WhereTerm.Default(searchTerm, "Code")
            };

            if (BaseControl.RoleId != 2)
            {
                param.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            }

            return DataManager.GetFirst<EmployeeModel>(param.ToArray());
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();

            ClearForm();
            txtCode.Text = "";
            tsBaseTxt_Code.Text = "";

            chkAsMessenger.Checked = false;
            chkAsMarketing.Checked = false;
            chkAsCustomerService.Checked = false;

            if (!BaseControl.UserRole.Equals("ADMIN"))
            {
                lkpBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "id") };
                lkpBranch.Enabled = false;
            }
            btnGetID.Enabled = true;

            txtCode.Focus();
        }

        protected override void AfterSave()
        {
            base.AfterSave();

            tsBaseTxt_Code.Text = txtCode.Text;
        }
    }
}
