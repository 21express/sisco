using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.App.Franchise;
using SISCO.Presentation.MasterData.Popup;
using System.Collections.Generic;
using SISCO.Presentation.Franchise.Popup;
using System.Windows.Forms;
using SISCO.Presentation.Franchise.Print;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;
using SISCO.Presentation.Common;

namespace SISCO.Presentation.Franchise.Forms
{
    public partial class MasterDataFranchiseForm : BaseCrudForm<FranchiseModel, FranchiseDataManager>//BaseToolbarForm//
    {
        private string _code { get; set; }
        public MasterDataFranchiseForm()
        {
            InitializeComponent();
            form = this;

            tsBaseBtn_Print.Click += Print;
            tsBaseBtn_PrintPreview.Click += PrintPreview;
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            EnableBtnSearch = true;
            SearchPopup = new FranchiseFilterPopup();

            lkpBranch.LookupPopup = new BranchPopup();
            lkpBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpBranch.AutoCompleteDisplayFormater =
                model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            lkpBranch.AutoCompleteWhereExpression =
                (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);
            lkpBranch.FieldLabel = "Branch";
            lkpBranch.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpCity.LookupPopup = new CityPopup();
            lkpCity.AutoCompleteDataManager = new CityDataManager();
            lkpCity.AutoCompleteDisplayFormater = model => ((CityModel) model).Name;
            lkpCity.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("name.StartsWith(@0)", s);
            lkpCity.FieldLabel = "City";
            lkpCity.ValidationRules = new[] {new ComponentValidationRule(EnumComponentValidationRule.Mandatory)};

            txtName.FieldLabel = "Name";
            txtName.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtAddress.FieldLabel = "Address";
            txtAddress.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtPhone.FieldLabel = "Phone";
            txtPhone.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtEmail.FieldLabel = "Email";
            txtEmail.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtCommission.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            tbxUsername.FieldLabel = "Username";
            tbxUsername.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            tbxPassword.FieldLabel = "Password";
            tbxPassword.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            var types = new FranchiseTypeDataManager().Get<FranchiseTypeModel>();

            cbxOrgType.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxOrgType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxOrgType.DataSource = types;
            cbxOrgType.DisplayMember = "Name";
            cbxOrgType.ValueMember = "Id";

            lkpPayment.LookupPopup = new PaymentMethodPopup("(name.Equals(@0) OR name.Equals(@1))", "CASH", "CREDIT");
            lkpPayment.AutoCompleteDataManager = new PaymentMethodDataManager();
            lkpPayment.AutoCompleteDisplayFormater = model => ((PaymentMethodModel)model).Name;
            lkpPayment.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("name.StartsWith(@0) AND (name.Equals(@1) OR name.Equals(@2))", s, "CASH", "CREDIT");
            lkpPayment.FieldLabel = "Payment Method";
            lkpPayment.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();
            lkpBranch.Enabled = true;
            lkpBranch.Properties.Buttons[0].Enabled = true;
            lkpCity.Enabled = true;
            lkpCity.Properties.Buttons[0].Enabled = true;
            lkpPayment.Enabled = true;
            lkpPayment.Properties.Buttons[0].Enabled = true;
            cbxOrgType.Enabled = true;
        }

        protected override void PopulateForm(FranchiseModel model)
        {
            ClearForm();

            if (model == null) return;
            EnabledForm(true);

            EnableBtnPrint = true;
            EnableBtnPrintPreview = true;
            
            ToolbarCode = model.Code;
            lkpBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(model.BranchId, "id", EnumSqlOperator.Equals) };
            lkpBranch.Enabled = false;
            lkpBranch.Properties.Buttons[0].Enabled = false;
            txtName.Text = model.Name;
            txtAddress.Text = model.Address;
            lkpCity.DefaultValue = new IListParameter[] { WhereTerm.Default(model.CityId, "id", EnumSqlOperator.Equals) };
            lkpCity.Enabled = false;
            lkpCity.Properties.Buttons[0].Enabled = false;
            txtZip.Text = model.ZipCode;
            txtEmail.Text = model.Email;
            txtPhone.Text = model.Phone;
            txtContactPerson.Text = model.ContactPerson;
            txtContactPhone.Text = model.ContactPhone;
            txtContactEmail.Text = model.ContactEmail;
            txtCommission.SetValue(model.Commission);
            cbxActive.Checked = model.ActiveFlag;
            tbxProductKey.Text = model.ProductKey;
            cbxOrgType.SelectedValue = (int) model.OrgType;
            cbxOrgType.Enabled = false;
            lkpPayment.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PaymentMethodId, "id", EnumSqlOperator.Equals) };
            lkpPayment.Enabled = false;
            lkpPayment.Properties.Buttons[0].Enabled = false;
            tbxCredit.SetValue((decimal) model.Credit);
            tbxNpwp.Text = model.NPWP;
            tbxNpwpName.Text = model.NPWPName;

            if (!string.IsNullOrEmpty((model.ProductKey)))
            {
                var decrypt = SymmetricCryptor.Decrypt(model.ProductKey.Replace(model.Code, ""));
                var split = decrypt.Split('|');

                tbxUsername.Text = split[0];
                tbxPassword.Text = split[1];
            }
        }

        protected override FranchiseModel PopulateModel(FranchiseModel model)
        {
            if (lkpBranch.Value != null)
            {
                model.BranchId = (int) lkpBranch.Value;

                if (model.Id == 0)
                    model.Code = ((FranchiseDataManager) DataManager).GenerateCode(new FranchiseModel
                    {
                        Name = txtName.Text,
                        BranchId = (int) lkpBranch.Value
                    });

                _code = model.Code;
            }

            model.Name = txtName.Text;
            model.Address = txtAddress.Text;
            if (lkpCity.Value != null) model.CityId = (int) lkpCity.Value;
            model.ZipCode = txtZip.Text;
            model.Email = txtEmail.Text;
            model.Phone = txtPhone.Text;
            model.ContactPerson = txtContactPerson.Text;
            model.ContactPhone = txtContactPhone.Text;
            model.ContactEmail = txtContactEmail.Text;
            model.Commission = txtCommission.Value;
            model.ActiveFlag = cbxActive.Checked;
            model.OrgType = Convert.ToInt16(cbxOrgType.SelectedValue);
            model.NPWP = tbxNpwp.Text;
            model.NPWPName = tbxNpwpName.Text;
            model.PaymentMethodId = (int) lkpPayment.Value;
            model.Credit = (int) tbxCredit.Value;

            if (tbxUsername.Text != "" && tbxPassword.Text != "")
            {
                var productKey = string.Format("{0}|{1}", tbxUsername.Text, tbxPassword.Text);
                model.ProductKey = string.Format("{0}{1}", SymmetricCryptor.Encrypt(productKey), model.Code);
            }

            return model;
        }

        protected override FranchiseModel Find(string searchTerm)
        {
            var param = new IListParameter[]
            {
                WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
            };
            var obj = DataManager.GetFirst<FranchiseModel>(param);

            return obj;
        }

        public override void New()
        {
            base.New();
            ClearForm();
        }

        protected override void AfterSave()
        {
            base.AfterSave();

            tsBaseTxt_Code.Text = _code;
            tsBaseBtn_Refresh.PerformClick();
        }

        private void PrintPreview(object sender, EventArgs e)
        {
            var print = new SuratJalan();
            using (var printTool = new ReportPrintTool(print))
            {
                var curmodel = CurrentModel as FranchiseModel;

                print.DataSource = new List<FranchiseModel> { curmodel };
                if (curmodel == null) return;
                var city = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(curmodel.CityId, "id"));

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "CityName",
                    Value = city.Name,
                    Visible = false
                });

                var payment = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default(curmodel.PaymentMethodId, "id"));
                print.Parameters.Add(new Parameter
                {
                    Name = "PaymentMethod",
                    Value = payment.Name,
                    Visible = false
                });

                var user = new UserFranchiseDataManager().GetFirst<UserFranchiseModel>(WhereTerm.Default(curmodel.Id, "franchise_id"));
                print.Parameters.Add(new Parameter
                {
                    Name = "Username",
                    Value = user.UserName,
                    Visible = false
                });

                print.CreateDocument();
                printTool.PrintingSystem.StartPrint += (o, args) =>
                {
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.InkJet;
                };
                printTool.ShowPreviewDialog();
            }
        }

        private void Print(object sender, EventArgs e)
        {
            var print = new SuratJalan();
            using (var printTool = new ReportPrintTool(print))
            {
                var curmodel = CurrentModel as FranchiseModel;
                if (curmodel == null) return;

                print.DataSource = curmodel;
                var city = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(curmodel.CityId, "id"));

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "CityName",
                    Value = city.Name,
                    Visible = false
                });

                var payment = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default(curmodel.PaymentMethodId, "id"));
                print.Parameters.Add(new Parameter
                {
                    Name = "PaymentMethod",
                    Value = payment.Name,
                    Visible = false
                });

                print.CreateDocument();
                printTool.PrintingSystem.StartPrint += (o, args) =>
                {
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.InkJet;
                };
                printTool.Print();
            }
        }
    }
}
