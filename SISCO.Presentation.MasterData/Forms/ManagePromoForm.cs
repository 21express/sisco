using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManagePromoForm : BaseCrudForm<PromoModel, PromoDataManager>//BaseToolbarForm//
    {
        private string Code { get;set;}
        public ManagePromoForm()
        {
            InitializeComponent();
            form = this;
            Load += ManagePromoLoad;
        }

        private void ManagePromoLoad(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            EnableBtnSearch = true;
            SearchPopup = new PromoPopup();

            tbxExpired.FieldLabel = "Expired Date";
            tbxExpired.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpOrigin.LookupPopup = new CityPopup();
            lkpOrigin.AutoCompleteDataManager = new CityDataManager();
            lkpOrigin.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpOrigin.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("name.StartsWith(@0)", s);

            lkpDestination.LookupPopup = new CityPopup();
            lkpDestination.AutoCompleteDataManager = new CityDataManager();
            lkpDestination.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpDestination.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("name.StartsWith(@0)", s);

            lkpPackage.LookupPopup = new PackageTypePopup();
            lkpPackage.AutoCompleteDataManager = new PackageTypeDataManager();
            lkpPackage.AutoCompleteDisplayFormater = model => ((PackageTypeModel)model).Name;
            lkpPackage.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            lkpService.LookupPopup = new ServiceTypePopup();
            lkpService.AutoCompleteDataManager = new ServiceTypeDataManager();
            lkpService.AutoCompleteDisplayFormater = model => ((ServiceTypeModel)model).Name;
            lkpService.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            tbxDiscount.EditMask = "##0.0%";
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            var result = true;
            var param = new List<WhereTerm>();

            if (lkpOrigin.Value != null) param.Add(WhereTerm.Default((int) lkpOrigin.Value, "city_orig_id"));
            else param.Add(WhereTerm.Default("city_orig_id"));

            if (lkpDestination.Value != null) param.Add(WhereTerm.Default((int)lkpDestination.Value, "city_dest_id"));
            else param.Add(WhereTerm.Default("city_dest_id"));

            if (lkpPackage.Value != null) param.Add(WhereTerm.Default((int)lkpPackage.Value, "package_type_id"));
            else param.Add(WhereTerm.Default("package_type_id"));

            if (lkpService.Value != null) param.Add(WhereTerm.Default((int)lkpService.Value, "service_type_id"));
            else param.Add(WhereTerm.Default("service_type_id"));

            if (tbxMinWeight.Value > 0) param.Add(WhereTerm.Default(tbxMinWeight.Value, "min_weight", EnumSqlOperator.Equals));

            var date = tbxExpired.Value;
            param.Add(WhereTerm.Default(new DateTime(date.Year, date.Month, date.Day, 23, 59, 59), "expired_date", EnumSqlOperator.LesThanEqual));

            param.Add(WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.NotEqual));
            var promo = DataManager.GetFirst<PromoModel>(param.ToArray());
            if (promo != null)
            {
                MessageForm.Info(form, "Duplicate Data", "Promo is already exists.");
                return false;
            }

            if (lkpOrigin.Value == null && lkpDestination.Value == null && lkpPackage.Value == null && lkpService.Value == null && tbxMinWeight.Value < 1)
            {
                var dialog = MessageForm.Ask(form, "Confirmation", "Apa anda yakin akan menyimpan data promo ini tanpa memasukkan parameter promo?");
                result = dialog == DialogResult.Yes;
            }

            if (tbxTariff.Value < 1 && tbxDiscount.Value < 1)
            {
                MessageForm.Info(form, "Information", "Nilai tariff atau discount harus diisi.");
                tbxTariff.Focus();
                result = false;
            }

            return result;
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();

            ClearForm();
            panel2.Enabled = true;
            panel4.Enabled = true;
            panel3.Enabled = true;
        }

        protected override void PopulateForm(PromoModel model)
        {
            ClearForm();

            tsBaseTxt_Code.Text = model.Code;
            tbxExpired.DateTime = model.ExpiredDate;
            tbxDescription.Text = model.PromoDesc;
            cbxActive.Checked = model.Active;

            if (model.CityOrigId != null)
                lkpOrigin.DefaultValue = new IListParameter[] { WhereTerm.Default((int) model.CityOrigId, "id") };

            if (model.CityDestId != null)
                lkpDestination.DefaultValue = new IListParameter[] { WhereTerm.Default((int) model.CityDestId, "id") };

            if (model.PackageTypeId != null)
                lkpPackage.DefaultValue = new IListParameter[] { WhereTerm.Default((int) model.PackageTypeId, "id") };

            if (model.ServiceTypeId != null)
                lkpService.DefaultValue = new IListParameter[] { WhereTerm.Default((int) model.ServiceTypeId, "id") };

            if (model.MinWeight != null) tbxMinWeight.SetValue((decimal) model.MinWeight);
            if (model.Tariff != null) tbxTariff.SetValue((decimal) model.Tariff);
            if (model.Discount != null) tbxDiscount.SetValue((decimal) model.Discount);

            panel2.Enabled = false;
            panel4.Enabled = false;
            panel3.Enabled = false;
        }

        protected override void AfterSave()
        {
            ToolbarCode = Code;
            OpenData(ToolbarCode);
            tsBaseTxt_Code.Focus();
        }

        protected override PromoModel PopulateModel(PromoModel model)
        {
            model.ExpiredDate = tbxExpired.DateTime;
            model.PromoDesc = tbxDescription.Text;
            model.Active = cbxActive.Checked;

            model.CityOrigId = lkpOrigin.Value;
            model.CityDestId = lkpDestination.Value;
            model.PackageTypeId = lkpPackage.Value;
            model.ServiceTypeId = lkpService.Value;
            if (tbxMinWeight.Value > 0) model.MinWeight = tbxMinWeight.Value;
            if (tbxTariff.Value > 0) model.Tariff = tbxTariff.Value;
            if (tbxDiscount.Value > 0) model.Discount = tbxDiscount.Value;

            if (model.Id == 0) model.Code = new PromoDataManager().GenerateCode();
            Code = model.Code;

            return model;
        }

        protected override PromoModel Find(string searchTerm)
        {
            return DataManager.GetFirst<PromoModel>(
                WhereTerm.Default(searchTerm, "code"));
        }
    }
}
