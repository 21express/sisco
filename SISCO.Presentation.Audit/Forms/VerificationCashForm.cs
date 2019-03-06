using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using SISCO.App.Finance;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Audit.Forms
{
    public partial class VerificationCashForm : BaseCrudForm<PaymentInCounterModel, PaymentInCounterDataManager>//BaseToolbarForm//
    {
        private string Code { get; set; }
        public VerificationCashForm()
        {
            InitializeComponent();
            form = this;
            btnVerify.Click += btnVerify_Click;
        }

        void btnVerify_Click(object sender, EventArgs e)
        {
            var dialog = MessageForm.Ask(form, "Verifikasi", "Anda yakin untuk memverifikasi data counter cash?");
            if (dialog == DialogResult.Yes)
            {
                var model = CurrentModel as PaymentInCounterModel;
                model.Verified = true;
                model.VerifiedBy = BaseControl.UserLogin;
                model.VerifiedDate = DateTime.Now;
                model.Modifiedby = BaseControl.UserLogin;
                model.Modifieddate = DateTime.Now;
                model.ModifiedPc = Environment.MachineName;

                new PaymentInCounterDataManager().Update<PaymentInCounterModel>(model);
                DataManager = new PaymentInCounterDataManager();
                PerformFind();
            }
        }

        protected override bool ValidateForm()
        {
            throw new NotImplementedException();
        }

        protected override void PopulateForm(PaymentInCounterModel model)
        {
            if (model == null) return;

            tbxDate.Text = model.DateProcess.ToString(CultureInfo.InvariantCulture);
            tbxDescription.Text = model.Description;
            ToolbarCode = model.Code;
            tbxTotalSales.SetValue(model.TotalInvoice.ToString(CultureInfo.InvariantCulture));
            tbxAdjustment.SetValue(model.Adjustment.ToString(CultureInfo.InvariantCulture));
            tbxTotal.SetValue(model.Total.ToString(CultureInfo.InvariantCulture));

            var counters = new PaymentInCounterDetailDataManager().Get<PaymentInCounterDetailModel>(WhereTerm.Default(model.Id, "payment_in_counter_id", EnumSqlOperator.Equals)).ToList();
            GridPayment.DataSource = counters;
            PaymentView.RefreshData();

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

        protected override PaymentInCounterModel PopulateModel(PaymentInCounterModel model)
        {
            model.DateProcess = tbxDate.Value;
            model.Description = tbxDescription.Text;
            model.Code = Code;
            model.BranchId = BaseControl.BranchId;
            model.TotalInvoice = tbxTotalSales.Value;
            model.Adjustment = tbxAdjustment.Value;
            model.Total = model.TotalInvoice - model.Adjustment;

            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override PaymentInCounterModel Find(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm)) tsBaseTxt_Code.Text = searchTerm;
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<PaymentInCounterModel>(param);
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
