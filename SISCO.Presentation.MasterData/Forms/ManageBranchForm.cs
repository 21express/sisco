using System;
using System.Globalization;
using System.Windows.Forms;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.App.MasterData;
using Devenlab.Common;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManageBranchForm : BaseCrudForm<BranchModel, BranchDataManager> //BaseToolbarForm //
    {
        public ManageBranchForm()
        {
            InitializeComponent();

            form = this;

            EnableBtnSearch = true;
            SearchPopup = new BranchPopup();

            lkpCity.LookupPopup = new CityPopup();
            lkpCity.AutoCompleteDataManager = new CityDataManager();
            lkpCity.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpCity.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("name.StartsWith(@0)", s);

            using (var branchTypeDataManager = new BranchTypeDataManager())
            {
                cmbBranchType.DataSource = branchTypeDataManager.Get<BranchTypeModel>();
                cmbBranchType.ValueMember = "Id";
                cmbBranchType.DisplayMember = "Name";
            }

            txtCode.FieldLabel = "Code";
            txtCode.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtName.FieldLabel = "Name";
            txtName.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpCity.FieldLabel = "Code";
            lkpCity.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            cmbBranchType.FieldLabel = "Name";
            cmbBranchType.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtMaxDiscount.EditMask = "##0.0%";
            txtRaFee.EditMask = "#,###,##0.00";
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            var errors = ComponentValidationHelper.Validate(txtCode, txtName, lkpCity, cmbBranchType);

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors));
                return false;
            }

            if (txtMaxDiscount.Value > 1)
            {
                MessageBox.Show(@"Maximum discount tidak boleh lebih dari 100%!");
                return false;
            }

            var duplicate = DataManager.GetFirst<BranchModel>(WhereTerm.Default(txtCode.Text, "code"), WhereTerm.Default(true, "rowstatus"));
            if (duplicate != null && duplicate.Id != CurrentModel.Id)
            {
                MessageBox.Show(@"Kode branch sudah dipakai untuk branch lain!");
                return false;
            }

            return true;
        }

        protected override void PopulateForm(BranchModel model)
        {
            txtCode.Text = model.Code;
            txtName.Text = model.Name;
            txtAddress.Text = model.Address;

            lkpCity.DefaultValue = new IListParameter[] { WhereTerm.Default(model.CityId, "id") };

            txtPhone.Text = model.Phone;

            txtContactPerson.Text = model.Contact;
            txtContactEmail.Text = model.ContactEmail;
            txtContactPhone.Text = model.ContactPhone;

            txtMaxDiscount.Value = model.MaxDiscount / 100;
            txtRaFee.Value = model.RaFee;

            cmbBranchType.SelectedValue = model.BranchTypeId;

            txtShipmentNoPrefix.Text = model.PrefixCode;
            txtPodHeader.Text = model.HeaderShipment;

            txtInvoiceHeader1.Text = model.InvoiceHeader1;
            txtInvoiceHeader2.Text = model.InvoiceHeader2;
            txtInvoiceHeader3.Text = model.InvoiceHeader3;
            txtInvoiceFooter1.Text = model.InvoiceFooter1;
            txtInvoiceFooter2.Text = model.InvoiceFooter2;

            txtBankName.Text = model.BankName;
            txtBankAccountName.Text = model.BankAccountName;
            txtBankAccountNumber.Text = model.BankAccountNumber;

            txtShipmentPrefix1.Text = model.PrefixCode1;
            txtShipmentPrefix2.Text = model.PrefixCode2;
            txtShipmentPrefixOnlineCode1.Text = model.PrefixOnlineCode1;

            tsBaseTxt_Code.Text = model.Code;
        }

        protected override BranchModel PopulateModel(BranchModel model)
        {
            model.Code = txtCode.Text;
            model.Name = txtName.Text;
            model.Address = txtAddress.Text;

            if (lkpCity.Value != null) model.CityId = (int) lkpCity.Value;

            model.Phone = txtPhone.Text;

            model.Contact = txtContactPerson.Text;
            model.ContactEmail = txtContactEmail.Text;
            model.ContactPhone = txtContactPhone.Text;

            model.MaxDiscount = txtMaxDiscount.Value * 100;
            model.RaFee = txtRaFee.Value;

            model.BranchTypeId = (int)cmbBranchType.SelectedValue;

            model.PrefixCode = txtShipmentNoPrefix.Text;
            model.HeaderShipment = txtPodHeader.Text;

            model.InvoiceHeader1 = txtInvoiceHeader1.Text;
            model.InvoiceHeader2 = txtInvoiceHeader2.Text;
            model.InvoiceHeader3 = txtInvoiceHeader3.Text;
            model.InvoiceFooter1 = txtInvoiceFooter1.Text;
            model.InvoiceFooter2 = txtInvoiceFooter2.Text;

            model.BankName = txtBankName.Text;
            model.BankAccountName = txtBankAccountName.Text;
            model.BankAccountNumber = txtBankAccountNumber.Text;

            model.PrefixCode1 = txtShipmentPrefix1.Text;
            model.PrefixCode2 = txtShipmentPrefix2.Text;
            model.PrefixOnlineCode1 = txtShipmentPrefixOnlineCode1.Text;

            return model;
        }

        protected override BranchModel Find(string searchTerm)
        {
            return DataManager.GetFirst<BranchModel>(WhereTerm.Default(searchTerm, "Code"));
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();

            ClearForm();
            txtCode.Text = "";
            tsBaseTxt_Code.Text = "";

            txtCode.Focus();
        }

        protected override void AfterSave()
        {
            base.AfterSave();

            tsBaseTxt_Code.Text = txtCode.Text;
        }
    }
}
