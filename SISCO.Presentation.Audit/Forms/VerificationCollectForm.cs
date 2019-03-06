using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using SISCO.App.Finance;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace SISCO.Presentation.Audit.Forms
{
    public partial class VerificationCollectForm : BaseCrudForm<PaymentOutCollectInModel, PaymentOutCollectInDataManager>//BaseToolbarForm//
    {
        public VerificationCollectForm()
        {
            InitializeComponent();
            form = this;
            btnVerify.Click += btnVerify_Click;

            tbxOrigin.LookupPopup = new BranchPopup();
            tbxOrigin.AutoCompleteDataManager = new BranchDataManager();
            tbxOrigin.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            tbxOrigin.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0))", s);

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
            var dialog = MessageForm.Ask(form, "Verifikasi", "Anda yakin untuk memverifikasi data collect?");
            if (dialog == DialogResult.Yes)
            {
                var model = CurrentModel as PaymentOutCollectInModel;
                model.Verified = true;
                model.VerifiedBy = BaseControl.UserLogin;
                model.VerifiedDate = DateTime.Now;
                model.Modifiedby = BaseControl.UserLogin;
                model.Modifieddate = DateTime.Now;
                model.ModifiedPc = Environment.MachineName;

                new PaymentOutCollectInDataManager().Update<PaymentOutCollectInModel>(model);
                DataManager = new PaymentOutCollectInDataManager();
                PerformFind();
            }
        }

        protected override bool ValidateForm()
        {
            throw new NotImplementedException();
        }

        protected override void PopulateForm(PaymentOutCollectInModel model)
        {
            if (model == null) return;

            tbxDate.Text = model.DateProcess.ToString(CultureInfo.InvariantCulture);
            ToolbarCode = model.Code;
            tbxOrigin.DefaultValue = new IListParameter[] { WhereTerm.Default(model.BranchId, "id", EnumSqlOperator.Equals) };
            tbxAmount.SetValue(model.Amount.ToString(CultureInfo.InvariantCulture));
            tbxPayment.DefaultValue = new IListParameter[] { WhereTerm.Default((int)model.PaymentTypeId, "id", EnumSqlOperator.Equals) };
            tbxDescription.Text = model.Description;

            tbxTotalSales.SetValue(model.TotalInvoice);
            tbxAdjustment.SetValue(model.Adjustment);
            tbxTotal.SetValue(model.Total);

            var detail = new PaymentOutCollectInDetailDataManager().Get<PaymentOutCollectInDetailModel>(WhereTerm.Default(model.Id, "payment_out_collect_in_id", EnumSqlOperator.Equals));
            GridCollectOut.DataSource = detail;
            CollectOutView.RefreshData();

            if (!string.IsNullOrEmpty(model.VerifiedBy)) lblVerifiedBy.Text = model.VerifiedBy;
            else lblVerifiedBy.Text = "N/A";

            if (model.VerifiedDate != null) lblVerifiedDate.Text = ((DateTime)model.VerifiedDate).ToShortDateString();
            else lblVerifiedDate.Text = "N/A";

            ucVerified.Icon = model.Verified;
            if (model.Verified) btnVerify.Enabled = false;
            else btnVerify.Enabled = true;

            tbxTotal.ReadOnly = true;
            tbxTotalSales.ReadOnly = true;
        }

        protected override PaymentOutCollectInModel PopulateModel(PaymentOutCollectInModel model)
        {
            throw new NotImplementedException();
        }

        protected override PaymentOutCollectInModel Find(string searchTerm)
        {
            var param = new IListParameter[]
            {
                WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
            };
            var obj = DataManager.GetFirst<PaymentOutCollectInModel>(param);
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
