using System;
using System.Windows.Forms;
using SISCO.Models;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.App.MasterData;
using Devenlab.Common;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManageCountryForm : BaseCrudForm<CountryModel, CountryDataManager>
    {
        public ManageCountryForm()
        {
            InitializeComponent();

            form = this;
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            EnableBtnSearch = true;
            SearchPopup = new CountryPopup();

            cmbPricingPlan.DataSource = new PricingPlanDataManager().Get<PricingPlanModel>();
            cmbPricingPlan.ValueMember = "Id";
            cmbPricingPlan.DisplayMember = "Zone";
            cmbPricingPlan.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbPricingPlan.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

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
            if (cmbPricingPlan.SelectedValue == null)
            {
                MessageBox.Show(@"Please select a pricing plan!");
                return false;
            }

            var duplicate = DataManager.GetFirst<CountryModel>(WhereTerm.Default(txtCode.Text, "code"), WhereTerm.Default(true, "rowstatus"));
            if (duplicate != null && duplicate.Id != CurrentModel.Id)
            {
                MessageBox.Show(@"Kode Country sudah dipakai untuk Country lain!");
                return false;
            }

            return true;
        }

        protected override void PopulateForm(CountryModel model)
        {
            txtCode.Text = model.Code;
            txtName.Text = model.Name;
            cmbPricingPlan.SelectedValue = model.PricingPlanId;

            tsBaseTxt_Code.Text = model.Code;
        }

        protected override CountryModel PopulateModel(CountryModel model)
        {
            model.Code = txtCode.Text;
            model.Name = txtName.Text;
            model.PricingPlanId = Convert.ToInt32(cmbPricingPlan.SelectedValue);

            return model;
        }

        protected override CountryModel Find(string searchTerm)
        {
            return DataManager.GetFirst<CountryModel>(WhereTerm.Default(searchTerm, "Code"));
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
