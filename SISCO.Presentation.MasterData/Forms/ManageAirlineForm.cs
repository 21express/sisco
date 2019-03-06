using System;
using System.Globalization;
using System.Windows.Forms;
using SISCO.Models;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.App.MasterData;
using Devenlab.Common;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManageAirlineForm : BaseCrudForm<AirlineModel, AirlineDataManager>//BaseToolbarForm//
    {
        public ManageAirlineForm()
        {
            InitializeComponent();

            form = this;
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            EnableBtnSearch = true;
            SearchPopup = new AirlinePopup();

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

            var duplicate = DataManager.GetFirst<AirlineModel>(WhereTerm.Default(txtCode.Text, "code"), WhereTerm.Default(true, "rowstatus"));
            if (duplicate != null && duplicate.Id != CurrentModel.Id)
            {
                MessageBox.Show(@"Kode airline sudah dipakai untuk airline lain!");
                return false;
            }
            
            return true;
        }

        protected override void PopulateForm(AirlineModel model)
        {
            txtCode.Text = model.Code;
            txtName.Text = model.Name;
            chkShowAsAgreed.Checked = model.ShowAsAgreed;
            txtAdminFee.Text = model.AdminFee.ToString(CultureInfo.InvariantCulture);
            chkIncludePPn.Checked = model.AdminIncludeTax;
            txtAdminFeeVia.Text = model.AdminFeeVia.ToString(CultureInfo.InvariantCulture);
            txtRefundFee.Text = model.RefundFee.ToString(CultureInfo.InvariantCulture);
            txtVoidFee.Text = model.VoidFee.ToString(CultureInfo.InvariantCulture);
            txtSCFee.Text = model.ScFee.ToString(CultureInfo.InvariantCulture);
            txtSCMinimumFee.Text = model.ScFeeMin.ToString(CultureInfo.InvariantCulture);
            txtSCMinimumWeight.Text = model.ScFeeMinWeight.ToString(CultureInfo.InvariantCulture);
            txtSOFee.Text = model.SoFee.ToString(CultureInfo.InvariantCulture);
            txtFEFee.Text = model.FeFee.ToString(CultureInfo.InvariantCulture);
            txtMinimumWeight.Text = model.MinWeight.ToString(CultureInfo.InvariantCulture);
            txtCustomerAdminFee.Text = model.AdminFeeCustomer.ToString(CultureInfo.InvariantCulture);
            txtCustomerVoidFee.Text = model.VoidFeeCustomer.ToString(CultureInfo.InvariantCulture);

            tsBaseTxt_Code.Text = model.Code;
        }

        protected override AirlineModel PopulateModel(AirlineModel model)
        {
            model.Code = txtCode.Text;
            model.Name = txtName.Text;
            model.ShowAsAgreed = chkShowAsAgreed.Checked;
            model.AdminFee = (decimal) txtAdminFee.Value;
            model.AdminIncludeTax = chkIncludePPn.Checked;
            model.AdminFeeVia = (decimal) txtAdminFeeVia.Value;
            model.RefundFee = (decimal) txtRefundFee.Value;
            model.VoidFee = (decimal) txtVoidFee.Value;
            model.ScFee = (decimal) txtSCFee.Value;
            model.ScFeeMin = (decimal) txtSCMinimumFee.Value;
            model.ScFeeMinWeight = (decimal) txtSCMinimumWeight.Value;
            model.SoFee = (decimal) txtSOFee.Value;
            model.FeFee = (decimal) txtFEFee.Value;
            model.MinWeight = (decimal) txtMinimumWeight.Value;
            model.AdminFeeCustomer = (decimal) txtCustomerAdminFee.Value;
            model.VoidFeeCustomer = (decimal)txtCustomerVoidFee.Value;

            return model;
        }

        protected override AirlineModel Find(string searchTerm)
        {
            return DataManager.GetFirst<AirlineModel>(WhereTerm.Default(searchTerm, "Code"));
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();

            ClearForm();
            txtCode.Text = "";
            tsBaseTxt_Code.Text = "";

            txtAdminFee.Value = 0;
            txtAdminFeeVia.Value = 0;
            txtRefundFee.Value = 0;
            txtVoidFee.Value = 0;
            txtSCFee.Value = 0;
            txtSCMinimumFee.Value = 0;
            txtSCMinimumWeight.Value = 0;
            txtSOFee.Value = 0;
            txtFEFee.Value = 0;
            txtMinimumWeight.Value = 0;
            txtCustomerAdminFee.Value = 0;
            txtCustomerVoidFee.Value = 0;

            txtCode.Focus();
        }

        protected override void AfterSave()
        {
            base.AfterSave();

            tsBaseTxt_Code.Text = txtCode.Text;
        }
    }
}
