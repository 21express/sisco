using System;
using System.Globalization;
using System.Windows.Forms;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.App.MasterData;
using Devenlab.Common;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.CustomerService.Forms
{
    public partial class ManageBranchForm : BaseCrudForm<BranchModel, BranchDataManager>
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
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            var errors = ComponentValidationHelper.Validate(txtCode, txtName);

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors));
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

            txtMaxDiscount.Text = model.MaxDiscount.ToString(CultureInfo.InvariantCulture);
            txtRaFee.Text = model.RaFee.ToString(CultureInfo.InvariantCulture);

            cmbBranchType.SelectedValue = model.BranchTypeId;

            tsBaseTxt_Code.Text = model.Code;

            _SetControlEnableState(form, false);
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

            model.MaxDiscount = Decimal.Parse(txtMaxDiscount.Text);
            model.RaFee = Decimal.Parse(txtRaFee.Text);

            model.BranchTypeId = (int)cmbBranchType.SelectedValue;


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

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            tsBaseBtn_Delete.Enabled = false;
            tsBaseBtn_Save.Enabled = false;
            tsBaseBtn_New.Enabled = false;

            NavigationMenu.DeleteStrip.Enabled = false;
            NavigationMenu.SaveStrip.Enabled = false;
            NavigationMenu.NewStrip.Enabled = false;
        }
    }
}
