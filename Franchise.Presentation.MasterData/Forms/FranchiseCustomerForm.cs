using System;
using System.Windows.Forms;
using Devenlab.Common;
using Franchise.Presentation.Common;
using Franchise.Presentation.Common.Component;
using Franchise.Presentation.Common.Forms;
using SISCO.App.MasterData;
using SISCO.Models;
using Franchise.Presentation.MasterData.Popup;
using Devenlab.Common.Interfaces;
using SISCO.App.Franchise;

namespace Franchise.Presentation.MasterData.Forms
{
    public partial class FranchiseCustomerForm : BaseCrudForm<CustomerModel, CustomerDataManager>//BaseToolbarForm//
    {
        public FranchiseCustomerForm()
        {
            InitializeComponent();

            form = this;
        }

        protected override void BindDataSource<T>()
        {
            CurrentModel = LoadModel<T>(WhereTerm.Default(BaseControl.FranchiseId, "franchise_id"));
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            EnableBtnSearch = true;
            SearchPopup = new CustomerPopup(new IListParameter[]
                {
                    WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                    WhereTerm.Default("0", "disabled", EnumSqlOperator.Equals),
                    WhereTerm.Default(BaseControl.FranchiseId, "franchise_id", EnumSqlOperator.Equals)
                });

            btnGetId.Click += btnGetID_Click;

            tbxId.FieldLabel = "Code";
            tbxId.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            tbxName.FieldLabel = "Name";
            tbxName.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            tbxAddress.FieldLabel = "Address";
            tbxAddress.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            tbxPhone.FieldLabel = "Phone";
            tbxPhone.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            tbxDiscount.EditValueChanged += tbxDiscount_EditValueChanged;
            EnabledForm(false);
        }

        private void tbxDiscount_EditValueChanged(object sender, EventArgs e)
        {
            if (tbxDiscount.Value > 15) tbxDiscount.Value = 15;
        }

        private void btnGetID_Click(object sender, EventArgs e)
        {
            if (tbxName.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter the customer name first");
                return;
            }

            tbxId.Text = ((CustomerDataManager)DataManager).GenerateFranchiseCode(new CustomerModel
            {
                Name = tbxName.Text,
                BranchId = BaseControl.BranchId
            });
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            var errors = ComponentValidationHelper.Validate(tbxId, tbxName, tbxAddress, tbxPhone);

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors));
                return false;
            }

            var duplicate = DataManager.GetFirst<CustomerModel>(WhereTerm.Default(tbxId.Text, "code"));
            if (duplicate != null && duplicate.Id != CurrentModel.Id)
            {
                MessageBox.Show(@"Kode customer sudah dipakai untuk customer lain!");
                return false;
            }

            if (tbxDiscount.Value > 0)
            {
                var franchise = new FranchiseDataManager().GetFirst<FranchiseModel>(WhereTerm.Default(BaseControl.FranchiseId, "id"));
                if (tbxDiscount.Value > franchise.Commission)
                {
                    MessageBox.Show(string.Format("Discount tidak bisa lebih dari {0}%!", franchise.Commission));
                    return false;
                }
            }

            return true;
        }

        protected override void PopulateForm(CustomerModel model)
        {
            tbxId.Text = model.Code;
            tbxName.Text = model.Name;

            tbxAddress.Text = model.Address;
            tbxPhone.Text = model.Phone;
            
            tbxContactPerson.Text = model.Contact;
            tbxContactEmail.Text = model.ContactEmail;
            tbxContactPhone.Text = model.ContactPhone;
            tbxNote.Text = model.Note;

            cbxActive.Checked = model.Disabled == "1";

            tbxDiscount.Value = model.Discount;

            tbxSearch_Code.Text = model.Code;

            btnGetId.Enabled = false;
        }

        protected override CustomerModel PopulateModel(CustomerModel model)
        {
            if (tbxId.Text == string.Empty)
            {
                btnGetId.PerformClick();
            }

            model.Code = tbxId.Text;
            model.Name = tbxName.Text;

            model.Address = tbxAddress.Text;
            model.Phone = tbxPhone.Text;

            model.Contact = tbxContactPerson.Text;
            model.ContactEmail = tbxContactEmail.Text;
            model.ContactPhone = tbxContactPhone.Text;

            model.Disabled = cbxActive.Checked ? "1" : "0";

            model.BranchId = BaseControl.BranchId;
            model.Discount = tbxDiscount.Value;

            model.Note = string.Empty;
            model.Footer1 = string.Empty;

            model.PodNeeded = model.PodNeeded ?? "0";
            model.FranchiseId = BaseControl.FranchiseId;
            model.Note = tbxNote.Text;

            return model;
        }

        protected override CustomerModel Find(string searchTerm)
        {
            return DataManager.GetFirst<CustomerModel>(WhereTerm.Default(searchTerm, "Code"), WhereTerm.Default(BaseControl.BranchId, "branch_id"));
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();

            ClearForm();
            tbxId.Text = "";
            tbxSearch_Code.Text = "";

            btnGetId.Enabled = true;

            tbxId.Focus();
        }

        protected override void AfterSave()
        {
            tbxSearch_Code.Focus();
            tbxSearch_Code.Text = tbxId.Text;

            MessageBox.Show("Data sudah berhasil disimpan. Lakukan sign out dan sign in kembali untuk proses perubahan data customer.");
        }
    }
}
