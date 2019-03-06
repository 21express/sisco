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
    public partial class ManageAirportForm : BaseCrudForm<AirportModel, AirportDataManager>
    {
        public ManageAirportForm()
        {
            InitializeComponent();

            form = this;
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            EnableBtnSearch = true;
            SearchPopup = new AirportPopup();

            lkpCity.LookupPopup = new CityPopup();
            lkpCity.AutoCompleteDataManager = new CityDataManager();
            lkpCity.AutoCompleteDisplayFormater = model => ((CityModel) model).Name;
            lkpCity.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

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

            var duplicate = DataManager.GetFirst<AirportModel>(WhereTerm.Default(txtCode.Text, "code"), WhereTerm.Default(true, "rowstatus"));
            if (duplicate != null && duplicate.Id != CurrentModel.Id)
            {
                MessageBox.Show(@"Kode airport sudah dipakai untuk airport lain!");
                return false;
            }
            
            return true;
        }

        protected override void PopulateForm(AirportModel model)
        {
            txtCode.Text = model.Code;
            txtName.Text = model.Name;
            lkpCity.DefaultValue = new IListParameter[] { WhereTerm.Default(model.CityId, "id") };
            txtContactPerson.Text = model.ContactPerson;
            txtContactPhone.Text = model.ContactPhone;

            tsBaseTxt_Code.Text = model.Code;
        }

        protected override AirportModel PopulateModel(AirportModel model)
        {
            model.Code = txtCode.Text;
            model.Name = txtName.Text;
            model.CityId = lkpCity.Value ?? 0;
            model.ContactPerson = txtContactPerson.Text;
            model.ContactPhone = txtContactPhone.Text;

            return model;
        }

        protected override AirportModel Find(string searchTerm)
        {
            return DataManager.GetFirst<AirportModel>(WhereTerm.Default(searchTerm, "Code"));
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
