using System;
using System.Globalization;
using System.Windows.Forms;
using Devenlab.Common.Interfaces;
using SISCO.App;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.App.MasterData;
using Devenlab.Common;
using SISCO.Presentation.MasterData.Popup;
using Devenlab.Common.WinControl.MessageBox;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManageCustomerForm : BaseCrudForm<CustomerModel, CustomerDataManager>//BaseToolbarForm//
    {
        public ManageCustomerForm()
        {
            InitializeComponent();

            tbxUsername.CharacterCasing = CharacterCasing.Normal;
            tbxPassword.CharacterCasing = CharacterCasing.Normal;
            tbxProductKey.CharacterCasing = CharacterCasing.Normal;
            form = this;
        }

        protected override void BindDataSource<T>()
        {
            CurrentModel = LoadModel<T>(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            EnableBtnSearch = true;
            SearchPopup = new CustomerPopup(WhereTerm.Default(BaseControl.BranchId, "branch_id"));

            lkpBranch.LookupPopup = new BranchPopup();
            lkpBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpBranch.AutoCompleteDisplayFormater =
                model => ((BranchModel) model).Code + " - " + ((BranchModel) model).Name;
            lkpBranch.AutoCompleteWhereExpression =
                (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);
            lkpBranch.FieldLabel = "Branch";
            lkpBranch.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpMarketing.LookupPopup = new EmployeePopup(EmployeeModel.EmployeeType.Marketing);
            lkpMarketing.AutoCompleteDataManager = new EmployeeDataManager();
            lkpMarketing.AutoCompleteDisplayFormater =
                model => ((EmployeeModel) model).Code + " - " + ((EmployeeModel) model).Name;
            lkpMarketing.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND as_marketing AND branch_id = @1", s, BaseControl.BranchId);

            btnGetID.Click += btnGetID_Click;

            txtCode.FieldLabel = "Code";
            txtCode.ValidationRules = new[] {new ComponentValidationRule(EnumComponentValidationRule.Mandatory)};

            txtName.FieldLabel = "Name";
            txtName.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtAddress.FieldLabel = "Address";
            txtAddress.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtPhone.FieldLabel = "Phone";
            txtPhone.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtCreditCollectionTime.EditMask = "#,0";
            txtDiscount.EditMask = "##0.0%";
            txtReturnCommissionPercent.EditMask = "##0.0%";
            txtReturnCommissionFixed.EditMask = "#,0";
            txtMarketingCommissionPercent.EditMask = "##0.0%";

            lkpService.LookupPopup = new ServicePopup();
            lkpService.AutoCompleteDataManager = new ServiceDataManager();
            lkpService.AutoCompleteDisplayFormater = model => ((ServiceTypeModel)model).Name;
            lkpService.AutoCompleteWheretermFormater = s => new IListParameter[]
                {
                    WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
                };

            btnEnable.Click += GenerateAPICommerce;

            using (var taxInvoiceDm = new TaxInvoiceDataManager())
            {
                cmbTaxInvoice.DataSource = taxInvoiceDm.Get<TaxInvoiceModel>();
            }
            cmbTaxInvoice.DisplayMember = "Name";
            cmbTaxInvoice.ValueMember = "Id";
        }

        private void GenerateAPICommerce(object sender, EventArgs e)
        {
            if (!ValidateFormWithAlert()) return;
            if (string.IsNullOrEmpty(tbxCorporate_key.Text)) tbxCorporate_key.Text = SymmetricCryptor.Encrypt(string.Format("{0}{1}", txtName.Text.Substring(0, 4), DateTime.Now.ToString("ddMMyyyyhhmmss")));
            else
            {
                var dialog = MessageForm.Ask(form, "Generate New Key", "Corporate Key sudah terdaftar. Apa akan dibuatkan key yang baru?");
                if (dialog == DialogResult.Yes)
                {
                    tbxCorporate_key.Text = SymmetricCryptor.Encrypt(string.Format("{0}{1}", txtName.Text.Substring(0, 4), DateTime.Now.ToString("ddMMyyyyhhmmss")));
                }
            }
        }

        private void btnGetID_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter the customer name first");
                return;
            }

            if (lkpBranch.Value == null)
            {
                MessageBox.Show(@"Please enter the customer branch first");
                return;
            }

            txtCode.Text = ((CustomerDataManager) DataManager).GenerateCode(new CustomerModel
            {
                Name = txtName.Text,
                BranchId = (int) lkpBranch.Value
            });
        }

        protected override bool ValidateForm()
        {
            if (tbxUsername.Text != string.Empty || tbxPassword.Text != String.Empty ||
                tbxProductKey.Text != string.Empty)
            {
                if (tbxUsername.Text == string.Empty)
                {
                    MessageBox.Show(@"Please SQL username");
                    tbxUsername.Focus();
                    return false;
                }

                if (tbxPassword.Text == string.Empty)
                {
                    MessageBox.Show(@"Please SQL password");
                    tbxPassword.Focus();
                    return false;
                }
            }

            if (cmbTaxInvoice.SelectedValue == null)
            {
                MessageBox.Show(@"Masukkan faktur pajak.");
                cmbTaxInvoice.Focus();
                return false;
            }

            if (tbxCorporate_key.Text != "" && tbxIp.Text == "")
            {
                tbxIp.Focus();
                return false;
            }

            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            var errors = ComponentValidationHelper.Validate(txtCode, txtName, lkpBranch, txtAddress, txtPhone);

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors));
                return false;
            }

            var duplicate = DataManager.GetFirst<CustomerModel>(WhereTerm.Default(txtCode.Text, "code"));
            if (duplicate != null && duplicate.Id != CurrentModel.Id)
            {
                MessageBox.Show(@"Kode customer sudah dipakai untuk customer lain!");
                return false;
            }

            if (txtDiscount.Value > 1)
            {
                MessageBox.Show(@"Discount tidak bisa lebih dari 100%!");
                return false;
            }

            if (txtReturnCommissionPercent.Value > 1)
            {
                MessageBox.Show(@"RC tidak bisa lebih dari 100%!");
                return false;
            }

            return true;
        }

        protected override void PopulateForm(CustomerModel model)
        {
            ClearForm();
            EnabledForm(true);

            if (model == null) return;

            txtCode.Text = model.Code;
            txtName.Text = model.Name;

            txtAddress.Text = model.Address;
            txtPhone.Text = model.Phone;
            txtNote.Text = model.Note;
            txtContactPerson.Text = model.Contact;
            txtContactEmail.Text = model.ContactEmail;
            txtContactPhone.Text = model.ContactPhone;

            txtStartDate.DateTime = model.StartDate;
            chkAccountDisabled.Checked = model.Disabled == "1";

            lkpBranch.DefaultValue = new IListParameter[] {WhereTerm.Default(model.BranchId, "id")};
            if (model.ServiceTypeId != null)
            {
                lkpService.DefaultValue = new IListParameter[] { WhereTerm.Default((int)model.ServiceTypeId, "id") };
            }

            txtCreditCollectionTime.Value = model.Credit;
            txtDiscount.Value = model.Discount / 100;
            txtReturnCommissionPercent.Value = model.RcPercent / 100;
            txtReturnCommissionFixed.Value = model.RcFixed;

            lkpMarketing.DefaultValue = new IListParameter[] { WhereTerm.Default(model.MarketingEmployeeId ?? 0, "id") };

            txtMarketingCommissionPercent.Value = model.McPercent / 100;

            txtBankName.Text = model.BankName;
            txtBankAccountName.Text = model.BankAccountName;
            txtBankAccountNumber.Text = model.BankAccountNumber;
            txtFooter1.Text = model.Footer1;

            lkpBranch.Enabled = BaseControl.UserRole.Equals("ADMIN");

            tsBaseTxt_Code.Text = model.Code;

            btnGetID.Enabled = false;
            cbxActiveFlag.Checked = model.ActiveFlag != null && (bool)model.ActiveFlag;
            tbxProductKey.Text = model.ProductKey;
            tbxProductKey.Enabled = false;

            tbxUsername.Text = string.Empty;
            tbxPassword.Text = string.Empty;

            if (!string.IsNullOrEmpty((model.ProductKey)))
            {
                var decrypt = SymmetricCryptor.Decrypt(model.ProductKey.Replace(model.Code, ""));
                var split = decrypt.Split('|');

                tbxUsername.Text = split[0];
                tbxPassword.Text = split[1];
            }

            tbxCorporate_key.Text = model.CorporateKey;
            tbxIp.Text = model.IPStatic;
            if (model.CorporateFlag != null) cbxCorporateFlag.Checked = (bool) model.CorporateFlag;
            tbxCorporate_key.Enabled = false;

            cmbTaxInvoice.SelectedValue = model.TaxInvoiceId != null ? model.TaxInvoiceId : -1;
        }

        protected override CustomerModel PopulateModel(CustomerModel model)
        {
            if (txtCode.Text == string.Empty)
            {
                btnGetID.PerformClick();
            }

            model.Code = txtCode.Text;
            model.Name = txtName.Text;

            model.Address = txtAddress.Text;
            model.Phone = txtPhone.Text;
            model.Note = txtNote.Text;
            model.Contact = txtContactPerson.Text;
            model.ContactEmail = txtContactEmail.Text;
            model.ContactPhone = txtContactPhone.Text;

            model.StartDate = txtStartDate.DateTime;
            model.Disabled = chkAccountDisabled.Checked ? "1" : "0";

            model.BranchId = lkpBranch.Value ?? 0;
            model.Credit = Convert.ToDecimal(txtCreditCollectionTime.Value);
            model.Discount = txtDiscount.Value * 100;
            model.RcPercent = txtReturnCommissionPercent.Value * 100;
            model.RcFixed = txtReturnCommissionFixed.Value;

            model.MarketingEmployeeId = lkpMarketing.Value;
            model.McPercent = txtMarketingCommissionPercent.Value * 100;

            model.BankName = txtBankName.Text;
            model.BankAccountName = txtBankAccountName.Text;
            model.BankAccountNumber = txtBankAccountNumber.Text;
            model.Footer1 = txtFooter1.Text;

            model.PodNeeded = model.PodNeeded ?? "0";
            model.ActiveFlag = cbxActiveFlag.Checked;

            if (tbxUsername.Text != "" && tbxPassword.Text != "")
            {
                var productKey = string.Format("{0}|{1}", tbxUsername.Text, tbxPassword.Text);
                model.ProductKey = string.Format("{0}{1}", SymmetricCryptor.Encrypt(productKey), model.Code);
            }

            model.CorporateKey = tbxCorporate_key.Text;
            model.IPStatic = tbxIp.Text;
            model.CorporateFlag = cbxCorporateFlag.Checked;

            model.TaxInvoiceId = (int)cmbTaxInvoice.SelectedValue;
            model.ServiceTypeId = lkpService.Value;

            var branch = new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(model.BranchId, "id"));
            if (branch != null) model.CityId = branch.CityId;

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
            txtCode.Text = "";
            tsBaseTxt_Code.Text = "";

            btnGetID.Enabled = true;

            txtCreditCollectionTime.Text = "14";

            if (!BaseControl.UserRole.Equals("ADMIN"))
            {
                lkpBranch.DefaultValue = new IListParameter[] {WhereTerm.Default(BaseControl.BranchId, "id")};
                lkpBranch.Enabled = false;
            }

            txtCode.Focus();
            tbxProductKey.Enabled = false;
            tbxCorporate_key.Enabled = false;
            cmbTaxInvoice.SelectedIndex = -1;
        }

        protected override void AfterSave()
        {
            base.AfterSave();
            tsBaseTxt_Code.Text = txtCode.Text;
            OpenData(tsBaseTxt_Code.Text);
        }
    }
}