using System;
using System.Globalization;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using SISCO.App.Billing;
using SISCO.App.Finance;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.Finance.Popup;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class TitipInvoiceForm : BaseCrudForm<OtherInvoiceModel, OtherInvoiceDataManager>//BaseToolbarForm//
    {
        private string Code { get; set; }
        public TitipInvoiceForm()
        {
            InitializeComponent();

            form = this;
            Load += OtherInvoiceLoad;
            tbxNumber.Leave += (sender, args) => CheckInvoice();

            tbxBranch.Leave += (sender, args) => CustomerBranch();

            //Shown += (sender, args) => Top();
            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "owner_branch_id", EnumSqlOperator.Equals)
            };
        }

        private void CustomerBranch()
        {
            /*if (tbxBranch.Value != null)
            {
                tbxCustomer.LookupPopup =
                    new CustomerPopup(new IListParameter[] { WhereTerm.Default((int)tbxBranch.Value, "branch_id", EnumSqlOperator.Equals) });
                tbxCustomer.AutoCompleteDataManager = new CustomerDataManager();
                tbxCustomer.AutoCompleteDisplayFormater =
                    model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
                tbxCustomer.AutoCompleteWhereExpression = (s, p) =>
                    p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s,
                        tbxBranch.Value);

                tbxCustomer.Enabled = true;
                tbxCustomer.Properties.Buttons[0].Enabled = true;
            }
            else
            {*/
                //tbxCustomer.Value = null;
                //tbxCustomer.Text = "";

                tbxCustomer.Enabled = false;
                tbxCustomer.Properties.Buttons[0].Enabled = false;
            //}
        }

        private bool CheckInvoice()
        {
            if (tbxNumber.Text == "") return false;
            var invoice = new SalesInvoiceDataManager().GetFirst<SalesInvoiceModel>(new IListParameter[]
            {
                WhereTerm.Default(tbxNumber.Text, "ref_number", EnumSqlOperator.Equals),
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)
            });

            if (invoice == null)
            {
                tbxNumber.Clear();
                tbxNumber.Focus();

                MessageForm.Info(form, Resources.information, @"No Invoice tidak diketahui");
                return false;
            }
            else
            {
                var titipInvoice = new OtherInvoiceDataManager().GetFirst<OtherInvoiceModel>(WhereTerm.Default(tbxNumber.Text, "ref_number", EnumSqlOperator.Equals));
                if (titipInvoice == null)
                {
                    tbxGrandTotal.SetValue(invoice.Total.ToString(CultureInfo.InvariantCulture));
                    if (invoice.CompanyId > 0)
                    {
                        tbxCustomer.DefaultValue = new IListParameter[]
                        {WhereTerm.Default(invoice.CompanyId, "id", EnumSqlOperator.Equals)};
                    }
                }
                else
                {
                    if (CurrentModel.Id != titipInvoice.Id)
                    {
                        MessageForm.Info(form, Resources.information, @"No Invoice sudah pernah di proses titip invoice");
                        tbxNumber.Clear();
                        tbxNumber.Focus();
                        return false;
                    }
                }
            }

            return true;
        }

        private void OtherInvoiceLoad(object sender, EventArgs e)
        {
            ClearForm();

            EnableBtnSearch = true;
            SearchPopup = new TitipInvoiceFilterPopup();

            tbxCustomer.LookupPopup =
                    new CustomerPopup(new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) });
            tbxCustomer.AutoCompleteDataManager = new CustomerDataManager();
            tbxCustomer.AutoCompleteDisplayFormater =
                model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            tbxCustomer.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s,
                    BaseControl.BranchId);

            tbxBranch.LookupPopup = new BranchPopup();
            tbxBranch.AutoCompleteDataManager = new BranchDataManager();
            tbxBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            tbxBranch.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            tbxGrandTotal.IsNumber = true;
            tbxPaymentIn.IsNumber = true;
            tbxPaymentOut.IsNumber = true;
        }

        public override void New()
        {
            base.New();

            ClearForm();
            ToolbarCode = string.Empty;

            tbxDate.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            tbxDate.Focus();

            tbxCustomer.Enabled = false;
            tbxCustomer.Properties.Buttons[0].Enabled = false;

            tbxGrandTotal.ReadOnly = true;
            tbxPaymentIn.ReadOnly = true;
            tbxPaymentOut.ReadOnly = true;
        }

        public override void Save()
        {
            if (CheckInvoice()) base.Save();
        }

        protected override void AfterSave()
        {
            ToolbarCode = ((OtherInvoiceModel)CurrentModel).Code;
            OpenData(ToolbarCode);
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text != "" && tbxNumber.Text != "" && tbxDueDate.Text != "" &&
                tbxBranch.Text != "")
            {
                if (CurrentModel.Id > 0) Code = ((OtherInvoiceModel) CurrentModel).Code;
                else
                {
                    if (tbxDate.Text != "")
                        Code = GetCode("otherinvoice", tbxDate.Value);
                }

                return true;
            }

            if (tbxDate.Text == "")
            {
                tbxDate.Focus();
                return false;
            }

            if (tbxNumber.Text == "")
            {
                tbxNumber.Focus();
                return false;
            }

            if (tbxDueDate.Text == "")
            {
                tbxDueDate.Focus();
                return false;
            }

            if (tbxBranch.Text == "")
            {
                tbxBranch.Focus();
                return false;
            }

            return false;
        }

        protected override void PopulateForm(OtherInvoiceModel model)
        {
            ClearForm();
            if (model == null)
            {
                tsBaseTxt_Code.Focus();
                return;
            }

            tbxDate.Text = model.DateProcess.ToString(CultureInfo.InvariantCulture);
            tbxNumber.Text = model.RefNumber;

            tbxBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(model.BranchId, "id", EnumSqlOperator.Equals) };
            if (model.CustomerId != null)
            {
                tbxCustomer.DefaultValue = new IListParameter[] { WhereTerm.Default((int)model.CustomerId, "id", EnumSqlOperator.Equals) };
            }

            tbxCustomer.Enabled = false;
            tbxCustomer.Properties.Buttons[0].Enabled = false;

            CustomerBranch();
            tbxDueDate.Text = model.DueDate.ToString(CultureInfo.InvariantCulture);
            tbxGrandTotal.SetValue(model.Total.ToString(CultureInfo.InvariantCulture));
            tbxPaymentIn.SetValue(model.InTotalPayment.ToString(CultureInfo.InvariantCulture));
            tbxPaymentOut.SetValue(model.OutTotalPayment.ToString(CultureInfo.InvariantCulture));
            tbxDescription.Text = model.Description;

            tbxGrandTotal.ReadOnly = true;
            tbxPaymentIn.ReadOnly = true;
            tbxPaymentOut.ReadOnly = true;

            tbxPaymentIn.ReadOnly = true;
            tbxPaymentOut.ReadOnly = true;

            ucLunas.Label = @"Lunas?";
            ucLunas.Icon = (tbxGrandTotal.Value == tbxPaymentOut.Value);

            var invoice = new SalesInvoiceDataManager().GetFirst<SalesInvoiceModel>(WhereTerm.Default(model.RefNumber, "ref_number"));

            ucCancel.Label = @"Batal?";
            ucCancel.Icon = invoice == null ? false : invoice.Cancelled;

            var desc = new OtherInvoiceDataManager().GetPaymentDescription(model.Id);
            if (desc != null)
            {
                tbxDesc1.Text = desc.PaymentInDescription;
                tbxDesc2.Text = desc.PaymentOutDescription;
            }

            ToolbarCode = model.Code;
        }

        protected override OtherInvoiceModel PopulateModel(OtherInvoiceModel model)
        {
            model.Code = Code;
            model.DateProcess = tbxDate.Value;
            model.RefNumber = tbxNumber.Text;
            if (tbxBranch.Value != null) model.BranchId = (int) tbxBranch.Value;
            model.OwnerBranchId = BaseControl.BranchId;
            model.DueDate = tbxDueDate.Value;
            model.DateFrom = tbxDate.Value;
            model.DateTo = tbxDueDate.Value;
            if (tbxCustomer.Value != null)
            {
                model.CustomerId = tbxCustomer.Value;
                var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int) tbxCustomer.Value, "id", EnumSqlOperator.Equals));
                model.CustomerName = customer.Name;
            }

            model.Total = tbxGrandTotal.Value;
            model.Description = tbxDescription.Text;
            
            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override OtherInvoiceModel Find(string searchTerm)
        {
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<OtherInvoiceModel>(param);
            PopulateForm(obj);

            return obj;
        }

        public override void Info()
        {
            var model = CurrentModel as OtherInvoiceModel;
            if (model != null)
            {
                info.CreatedPc = model.CreatedPc;
                info.ModifiedPc = model.ModifiedPc;
            }

            base.Info();
        }
    }
}