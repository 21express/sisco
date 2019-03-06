using System;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManageCityForm : BaseCrudForm<CityModel, CityDataManager>//BaseToolbarForm//
    {
        public ManageCityForm()
        {
            InitializeComponent();

            form = this;
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            EnableBtnSearch = true;
            SearchPopup = new CityPopup();


            lkpCountry.LookupPopup = new CountryPopup();
            lkpCountry.AutoCompleteDataManager = new CountryDataManager();
            lkpCountry.AutoCompleteDisplayFormater = model => ((CountryModel)model).Code + " - " + ((CountryModel)model).Name;
            lkpCountry.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);
            lkpCountry.FieldLabel = "Country";
            lkpCountry.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpBranch.LookupPopup = new BranchPopup();
            lkpBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpBranch.AutoCompleteDisplayFormater =
                model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            lkpBranch.AutoCompleteWhereExpression =
                (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);
            lkpBranch.FieldLabel = "Branch";
            lkpBranch.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtCode.FieldLabel = "Code";
            txtCode.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            var errors = ComponentValidationHelper.Validate(txtCode, lkpCountry, lkpBranch);

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors));
                return false;
            }

            var duplicate = DataManager.GetFirst<CityModel>(WhereTerm.Default(txtCode.Text, "name"), WhereTerm.Default(true, "rowstatus"));
            if (duplicate != null && duplicate.Id != CurrentModel.Id)
            {
                MessageBox.Show(@"Kode city sudah dipakai untuk city lain!");
                return false;
            }

            return true;
        }

        protected override void PopulateForm(CityModel model)
        {
            txtCode.Text = model.Name;
            lkpCountry.DefaultValue = new IListParameter[] { WhereTerm.Default(model.CountryId, "id") };
            lkpBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(model.BranchId, "id") };

            tsBaseTxt_Code.Text = model.Name;
            txtZipcode.Text = model.ZipCode;
            cbxCod.Checked = model.Cod;
            cbxOutArea.Checked = model.IsOutArea;
        }

        protected override CityModel PopulateModel(CityModel model)
        {
            model.Name = txtCode.Text;
            model.CountryId = lkpCountry.Value ?? 0;
            model.BranchId = lkpBranch.Value ?? 0;
            model.ZipCode = txtZipcode.Text;
            model.Cod = cbxCod.Checked;
            model.IsOutArea = cbxOutArea.Checked;

            return model;
        }

        protected override CityModel Find(string searchTerm)
        {
            return DataManager.GetFirst<CityModel>(WhereTerm.Default(searchTerm, "name"));
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