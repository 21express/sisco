using System;
using System.Globalization;
using System.Windows.Forms;
using Devenlab.Common;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManageCurrencyForm : BaseCrudForm<CurrencyModel, CurrencyDataManager>//BaseToolbarForm
    {
        public ManageCurrencyForm()
        {
            InitializeComponent();

            form = this;
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            EnableBtnSearch = true;
            SearchPopup = new CurrencyPopup();

            txtCode.FieldLabel = "Code";
            txtCode.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtName.FieldLabel = "Name";
            txtName.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtRate.EditMask = "###,###,##0.00";
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

            var duplicate = DataManager.GetFirst<CurrencyModel>(WhereTerm.Default(txtCode.Text, "code"), WhereTerm.Default(true, "rowstatus"));
            if (duplicate != null && duplicate.Id != CurrentModel.Id)
            {
                MessageBox.Show(@"Kode currency sudah dipakai untuk currency lain!");
                return false;
            }

            return true;
        }

        protected override void PopulateForm(CurrencyModel model)
        {
            txtCode.Text = model.Code;
            txtName.Text = model.Name;
            txtRate.Value = model.Rate;

            tsBaseTxt_Code.Text = model.Code;
        }

        protected override CurrencyModel PopulateModel(CurrencyModel model)
        {
            model.Code = txtCode.Text;
            model.Name = txtName.Text;
            model.Rate = txtRate.Value;

            return model;
        }

        protected override CurrencyModel Find(string searchTerm)
        {
            return DataManager.GetFirst<CurrencyModel>(WhereTerm.Default(searchTerm, "Code"));
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
