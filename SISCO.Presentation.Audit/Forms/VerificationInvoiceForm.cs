using System;
using System.Collections.Generic;
using System.Globalization;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.XtraGrid.Views.Base;
using SISCO.App.Billing;
using SISCO.App.Finance;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.MasterData.Popup;
using System.Linq;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;
using System.Windows.Forms;

namespace SISCO.Presentation.Audit.Forms
{
    public partial class VerificationInvoiceForm : BaseCrudForm<PaymentInModel, PaymentInDataManager>//BaseToolbarForm//
    {
        private string Code { get; set; }
        public VerificationInvoiceForm()
        {
            InitializeComponent();

            form = this;
            btnVerify.Click += btnVerify_Click;

            tbxCustomer.LookupPopup = new CustomerPopup(new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) });
            tbxCustomer.AutoCompleteDataManager = new CustomerDataManager();
            tbxCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            tbxCustomer.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);

            tbxPayment.LookupPopup = new PaymentTypePopup();
            tbxPayment.AutoCompleteDataManager = new PaymentTypeDataManager();
            tbxPayment.AutoCompleteDisplayFormater = model => ((PaymentTypeModel)model).Name;
            tbxPayment.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
        }

        void btnVerify_Click(object sender, EventArgs e)
        {
            var dialog = MessageForm.Ask(form, "Verifikasi", "Anda yakin untuk memverifikasi data pembayaran invoice?");
            if (dialog == DialogResult.Yes)
            {
                var model = CurrentModel as PaymentInModel;
                model.Verified = true;
                model.VerifiedBy = BaseControl.UserLogin;
                model.VerifiedDate = DateTime.Now;
                model.Modifiedby = BaseControl.UserLogin;
                model.Modifieddate = DateTime.Now;
                model.ModifiedPc = Environment.MachineName;

                new PaymentInDataManager().Update<PaymentInModel>(model);
                DataManager = new PaymentInDataManager();
                PerformFind();
            }
        }

        protected override bool ValidateForm()
        {
            throw new NotImplementedException();
        }

        protected override void PopulateForm(PaymentInModel model)
        {
            tbxDate.Text = model.DateProcess.ToString(CultureInfo.InvariantCulture);
            tbxCustomer.DefaultValue = new IListParameter[] { WhereTerm.Default(model.CustomerId, "id", EnumSqlOperator.Equals) };
            if (model.PaymentTypeId != null)
                tbxPayment.DefaultValue = new IListParameter[] { WhereTerm.Default((int)model.PaymentTypeId, "id", EnumSqlOperator.Equals) };

            tbxAmount.SetValue(model.Amount.ToString(CultureInfo.InvariantCulture));
            tbxDescription.Text = model.Description;
            tbxRcPercent.SetValue(model.RcPercent.ToString(CultureInfo.InvariantCulture));
            tbxRcFixed.SetValue(model.RcFixed.ToString(CultureInfo.InvariantCulture));
            tbxRcTotal.SetValue(model.RcTotal.ToString(CultureInfo.InvariantCulture));
            tbxRcPayment.SetValue(model.TotalPaymentRc.ToString(CultureInfo.InvariantCulture));
            tbxMcPercent.SetValue(model.McPercent.ToString(CultureInfo.InvariantCulture));
            tbxMcFixed.SetValue(model.McFixed.ToString(CultureInfo.InvariantCulture));
            tbxMcTotal.SetValue(model.McTotal.ToString(CultureInfo.InvariantCulture));
            tbxMcPayment.SetValue(model.TotalPaymentMc.ToString(CultureInfo.InvariantCulture));
            tbxTotalInvoice.SetValue(model.TotalInvoice.ToString(CultureInfo.InvariantCulture));
            tbxAdjustment.SetValue(model.Adjustment.ToString(CultureInfo.InvariantCulture));
            tbxTotal.SetValue(model.Total.ToString(CultureInfo.InvariantCulture));

            tbxRcPercent.ReadOnly = true;
            tbxMcPercent.ReadOnly = true;
            tbxRcTotal.ReadOnly = true;
            tbxMcTotal.ReadOnly = true;
            tbxRcPayment.ReadOnly = true;
            tbxMcPayment.ReadOnly = true;
            tbxTotal.ReadOnly = true;
            tbxTotalInvoice.ReadOnly = true;
            tbxTotalPph.ReadOnly = true;

            ToolbarCode = model.Code;

            var detail = new PaymentInDetailDataManager().Get<PaymentInDetailModel>(WhereTerm.Default(model.Id, "payment_in_id", EnumSqlOperator.Equals));
            GridPayment.DataSource = detail;
            PaymentView.RefreshData();

            decimal pph = 0;
            detail.ToList().ForEach(d =>
            {
                d.StateChange2 = EnumStateChange.Select.ToString();
                if (d.UsePph23) pph += (decimal)d.TotalPph23;
            });

            tbxTotalPph.SetValue(pph);

            if (!string.IsNullOrEmpty(model.VerifiedBy)) lblVerifiedBy.Text = model.VerifiedBy;
            else lblVerifiedBy.Text = "N/A";

            if (model.VerifiedDate != null) lblVerifiedDate.Text = ((DateTime)model.VerifiedDate).ToShortDateString();
            else lblVerifiedDate.Text = "N/A";

            ucVerified.Icon = model.Verified;
            if (model.Verified) btnVerify.Enabled = false;
            else btnVerify.Enabled = true;

            tbxTotal.ReadOnly = true;
            tbxTotalPph.ReadOnly = true;
        }

        protected override PaymentInModel PopulateModel(PaymentInModel model)
        {
            model.Code = Code;
            model.DateProcess = tbxDate.Value;
            model.BranchId = BaseControl.BranchId;
            model.PaymentTypeId = tbxPayment.Value;
            model.Description = tbxDescription.Text;

            if (tbxCustomer.Value != null) model.CustomerId = (int)tbxCustomer.Value;
            model.CustomerName = tbxCustomer.Text.Split(new[] { " - " }, StringSplitOptions.None)[1];
            model.Amount = tbxAmount.Value;
            model.TotalInvoice = tbxTotalInvoice.Value;
            model.Total = tbxTotal.Value;
            model.Adjustment = tbxAdjustment.Value;
            model.RcPercent = tbxRcPercent.Value;
            model.RcFixed = tbxRcFixed.Value;
            model.RcTotal = tbxRcTotal.Value;
            model.TotalPaymentRc = tbxRcPayment.Value;
            model.McPercent = tbxMcPercent.Value;
            model.McFixed = tbxMcFixed.Value;
            model.McTotal = tbxMcTotal.Value;
            model.TotalPaymentMc = tbxMcPayment.Value;

            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override PaymentInModel Find(string searchTerm)
        {
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<PaymentInModel>(param);
            PopulateForm(obj);

            return obj;
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            EnabledForm(false);
        }
    }
}