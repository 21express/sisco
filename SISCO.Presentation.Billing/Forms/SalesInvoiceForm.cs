using System;
using SISCO.App.Billing;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Billing.Popup;
using SISCO.Presentation.Common.Component;
using System.Windows.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.App.MasterData;
using Devenlab.Common.Interfaces;
using Devenlab.Common;
using SISCO.Presentation.Common;

namespace SISCO.Presentation.Billing.Forms
{
    public partial class SalesInvoiceForm : BaseCrudForm<SalesInvoiceModel, SalesInvoiceDataManager>//BaseToolbarForm//
    {
        public SalesInvoiceForm()
        {
            InitializeComponent();
            form = this;

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id"),
                WhereTerm.Default(true, "printed")
            };
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            base.LoadForm(sender, e);

            EnableBtnSearch = true;
            SearchPopup = new SalesInvoicePopup();

            txtDate.FieldLabel = "Date";
            txtDate.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            txtReceiptNo.FieldLabel = "Nomor Kwitansi";
            txtReceiptNo.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            txtInvoicedTo.FieldLabel = "Invoiced To";
            txtInvoicedTo.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            txtDueDate.FieldLabel = "Due Date";
            txtDueDate.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtReceiptNo.CharacterCasing = CharacterCasing.Upper;
            txtInvoicedTo.CharacterCasing = CharacterCasing.Upper;
            txtDescription1.CharacterCasing = CharacterCasing.Upper;
            txtDescription2.CharacterCasing = CharacterCasing.Upper;
            txtDescription3.CharacterCasing = CharacterCasing.Upper;

            lkpCustomer.LookupPopup = new CustomerPopup();
            lkpCustomer.AutoCompleteDataManager = new CustomerDataManager();
            lkpCustomer.AutoCompleteDisplayFormater =
                model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            lkpCustomer.AutoCompleteWhereExpression = (s, param) => param.SetWhereExpression("(code = @0 or name.StartsWith(@0)) and branch_id = @1", s, BaseControl.BranchId);
            lkpCustomer.FieldLabel = "Customer";
            lkpCustomer.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            using (var taxInvoiceDm = new TaxInvoiceDataManager())
            {
                cmbTaxInvoice.DataSource = taxInvoiceDm.Get<TaxInvoiceModel>();
            }
            cmbTaxInvoice.DisplayMember = "Name";
            cmbTaxInvoice.ValueMember = "Id";
            cmbTaxInvoice.SelectedIndex = -1;
        }

        protected override void PopulateForm(SalesInvoiceModel model)
        {
            tsBaseTxt_Code.Text = model.Code;

            txtDate.DateTime = model.Vdate;
            txtReceiptNo.Text = model.RefNumber;

            lkpCustomer.DefaultValue = new IListParameter[] { WhereTerm.Default(model.CompanyId, "id") };

            txtInvoicedTo.Text = model.CompanyInvoicedTo;
            txtDueDate.DateTime = model.DueDate;

            if (model.TaxInvoiceId != null) cmbTaxInvoice.SelectedValue = model.TaxInvoiceId;
            else cmbTaxInvoice.SelectedIndex = -1;

            txtDescription1.Text = model.Description1;
            txtDescription2.Text = model.Description2;
            txtDescription3.Text = model.Description3;
        }

        protected override SalesInvoiceModel PopulateModel(SalesInvoiceModel model)
        {
            model.BranchId = BaseControl.BranchId;
            model.Code = tsBaseTxt_Code.Text;

            model.Vdate = txtDate.DateTime;
            model.RefNumber = txtReceiptNo.Text;
            model.TaxInvoiceId = (int)cmbTaxInvoice.SelectedValue;

            model.CompanyName = lkpCustomer.Text;
            if (lkpCustomer.Value != null) model.CompanyId = (int)lkpCustomer.Value;

            model.CompanyInvoicedTo = txtInvoicedTo.Text;
            model.DueDate = txtDueDate.DateTime;

            model.Description = txtDescription1.Text;
            model.Description1 = txtDescription1.Text;
            model.Description2 = txtDescription2.Text;
            model.Description3 = txtDescription3.Text;

            return model;
        }

        protected override SalesInvoiceModel Find(string searchTerm)
        {
            return DataManager.GetFirst<SalesInvoiceModel>(WhereTerm.Default(searchTerm, "code"), WhereTerm.Default(BaseControl.BranchId, "branch_id"));
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            // ReSharper disable LocalizableElement
            if (txtDate.DateTime == DateTime.MinValue)
            {
                MessageBox.Show("Please enter the invoice date!");
                txtDate.Focus();
                return false;
            }
            if (txtReceiptNo.Text == "")
            {
                MessageBox.Show("Please enter the receipt number!");
                txtReceiptNo.Focus();
                return false;
            }
            if (lkpCustomer.Value == null)
            {
                MessageBox.Show("Please select a customer!");
                lkpCustomer.Focus();
                return false;
            }
            if (txtInvoicedTo.Text == "")
            {
                MessageBox.Show("Please enter the invoice recipient (Invoiced To)!");
                txtInvoicedTo.Focus();
                return false;
            }
            if (txtDate.DateTime == DateTime.MinValue)
            {
                MessageBox.Show("Please enter the invoice due date!");
                txtDate.Focus();
                return false;
            }

            if (cmbTaxInvoice.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter the invoice tax!");
                cmbTaxInvoice.Focus();
                return false;
            }

            return true;
        }
    }
}