using System;
using System.Globalization;
using System.Windows.Forms;
using Corporate.Presentation.Common;
using Corporate.Presentation.Common.Forms;
using Corporate.Presentation.MasterData.Popup;
using Devenlab.Common;
using Corporate.Presentation.Common.Component;
using Franchise.Presentation.Common.Component;
using SISCO.App.Corporate;
using SISCO.Models;

namespace Corporate.Presentation.MasterData.Forms
{
    public partial class ConsigneeForm : BaseCrudForm<ConsigneeModel, ConsigneeDataManager>//BaseToolbarForm //
    {
        public ConsigneeForm()
        {
            InitializeComponent();

            form = this;
        }

        protected override void BindDataSource<T>()
        {
            CurrentModel = LoadModel<T>(WhereTerm.Default(BaseControl.CorporateId, "corporate_id"));
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            EnableBtnSearch = true;
            SearchPopup = new ConsigneeFilterPopup();

            tbxName.FieldLabel = "Name";
            tbxName.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            tbxAddress.FieldLabel = "Address";
            tbxAddress.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            tbxPhone.FieldLabel = "Phone";
            tbxPhone.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            EnabledForm(false);
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            var errors = ComponentValidationHelper.Validate(tbxName, tbxAddress, tbxPhone);

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors));
                return false;
            }

            var duplicate = DataManager.GetFirst<ConsigneeModel>(WhereTerm.Default(tbxName.Text, "name"));
            if (duplicate != null && duplicate.Id != CurrentModel.Id)
            {
                MessageBox.Show(@"Nama consignee ini tidak dapat digunakan!");
                return false;
            }

            return true;
        }

        protected override void PopulateForm(ConsigneeModel model)
        {
            tbxName.Text = model.Name;

            tbxAddress.Text = model.Address;
            tbxPhone.Text = model.Phone;

            tbxSearch_Code.Text = model.Id.ToString();
        }

        protected override ConsigneeModel PopulateModel(ConsigneeModel model)
        {
            model.Name = tbxName.Text;

            model.Address = tbxAddress.Text;
            model.Phone = tbxPhone.Text;

            model.CorporateId = BaseControl.CorporateId;
            if (CurrentModel.Id == 0)
            {
                model.CreatedPc = Environment.MachineName;
            }
            else
            {
                model.ModifiedPc = Environment.MachineName;
            }

            return model;
        }

        protected override ConsigneeModel Find(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm)) return new ConsigneeModel();
            return DataManager.GetFirst<ConsigneeModel>(WhereTerm.Default(Convert.ToInt32(searchTerm), "id"), WhereTerm.Default(BaseControl.CorporateId, "corporate_id"));
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();

            ClearForm();
            tbxSearch_Code.Text = "";

            tbxName.Focus();
        }

        protected override void AfterSave()
        {
            base.AfterSave();

            tbxSearch_Code.Text = CurrentModel.Id.ToString(CultureInfo.InvariantCulture);
        }
    }
}
