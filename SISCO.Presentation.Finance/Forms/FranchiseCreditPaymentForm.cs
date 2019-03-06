using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.Franchise;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Franchise.Popup;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class FranchiseCreditPaymentForm : BaseCrudForm<FranchiseCreditPaymentModel, FranchiseCreditPaymentDataManager>//BaseToolbarForm//
    {
        public FranchiseCreditPaymentForm()
        {
            InitializeComponent();
            form = this;

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)
            };
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            var payment = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default("CREDIT", "name"));

            lkpFranchise.LookupPopup = new FranchisePopup(new IListParameter[] { WhereTerm.Default(payment.Id, "payment_method_id") });
            lkpFranchise.AutoCompleteDataManager = new FranchiseDataManager();
            lkpFranchise.AutoCompleteDisplayFormater = model => ((FranchiseModel)model).Code + " - " + ((FranchiseModel)model).Name;
            lkpFranchise.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND payment_method_id = @1", s, payment.Id);

            lkpPaymentType.LookupPopup = new PaymentTypePopup();
            lkpPaymentType.AutoCompleteDataManager = new PaymentTypeDataManager();
            lkpPaymentType.AutoCompleteDisplayFormater = model => ((PaymentTypeModel)model).Name;
            lkpPaymentType.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            PaymentView.CustomColumnDisplayText += NumberGrid;
            lkpFranchise.Leave += GetFranchiseInvoices;
            PaymentView.CellValueChanging += Paying;
            PaymentView.CellValueChanged += Paid;

            tbxAdjustment.Leave += AdjusmentTotal;
        }

        private void AdjusmentTotal(object sender, EventArgs e)
        {
            if (tbxAdjustment.Value < 0) tbxAdjustment.SetValue((decimal)0);
            if (tbxTotalInvoice.Value == 0) tbxTotal.SetValue((decimal)0);
            else
            {
                tbxTotal.SetValue(tbxTotalInvoice.Value - tbxAdjustment.Value);
            }
        }

        private void Paid(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "clState" && e.Column.Name == "clPayment")
            {
                if (PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["StateChange"]).ToString() != EnumStateChange.Insert.ToString())
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["StateChange"], EnumStateChange.Update);

                var balance = (decimal)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["InvoiceBalance"]);
                var payment = (decimal)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["Payment"]);

                PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Checked"], (bool)(payment > 0));
                PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Balance"], (balance - payment));

                var total = 0;
                for (var i = 0; i < PaymentView.RowCount; i++)
                {
                    total += Convert.ToInt32(PaymentView.GetRowCellValue(i, PaymentView.Columns["Payment"]));
                }

                tbxTotalInvoice.SetValue(total.ToString(CultureInfo.InvariantCulture));
                tbxTotal.SetValue(((Int64)tbxTotalInvoice.Value - (Int64)tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));
            }
        }

        private void Paying(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var balance = (decimal)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["InvoiceBalance"]);
            if (e.Column.Name == "clChecked")
            {
                if (!(bool)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["Checked"]))
                {
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Balance"], 0);
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Checked"], true);
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Payment"], balance);
                }
                else
                {
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Balance"], balance);
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Checked"], false);
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Payment"], 0);
                }
            }
        }

        private void GetFranchiseInvoices(object sender, EventArgs e)
        {
            if (lkpFranchise.Value == null) return;
            var invoices = new FranchiseCreditPaymentDetailDataManager().GetInvoices((int) lkpFranchise.Value);

            var details = (from obj in invoices
                            select new FranchiseCreditPaymentDetailModel
                            {
                                Id = 0,
                                FranchiseCreditPaymentId = 0,
                                InvoiceId = obj.InvoiceId,
                                InvoiceDate = obj.InvoiceDate,
                                InvoiceCode = obj.InvoiceCode,
                                InvoiceTotal = obj.InvoiceTotal,
                                InvoiceBalance = obj.InvoiceTotal - obj.Payment,
                                Payment = 0,
                                Balance = (obj.InvoiceTotal - obj.Payment),
                                Checked = false,
                                StateChange = EnumStateChange.Insert
                            }).ToList().OrderBy(p => p.InvoiceDate);

            GridPayment.DataSource = details;
            PaymentView.RefreshData();
        }

        protected override void BeforeNew()
        {
            ClearForm();
            EnabledForm(true);
            tbxTotalInvoice.Enabled = false;
            tbxTotal.Enabled = false;

            tbxDate.DateTime = DateTime.Now;
            lkpFranchise.Focus();

            tbxTotalInvoice.SetValue((decimal)0);
            tbxAdjustment.SetValue((decimal)0);
            tbxTotal.SetValue((decimal)0);

            GridPayment.DataSource = null;
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text == "")
            {
                tbxDate.Focus();
                return false;
            }

            if (lkpFranchise.Value == null)
            {
                lkpFranchise.Focus();
                return false;
            }

            if (lkpPaymentType.Value == null)
            {
                lkpPaymentType.Focus();
                return false;
            }

            if (PaymentView.RowCount == 0)
            {
                lkpFranchise.Focus();
                return false;
            }

            if (tbxTotalInvoice.Value == 0)
            {
                GridPayment.Focus();
                return false;
            }

            return true;
        }

        protected override void PopulateForm(FranchiseCreditPaymentModel model)
        {
            ClearForm();
            if (model == null) return;

            EnabledForm(true);
            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;
            lkpFranchise.Enabled = false;
            lkpFranchise.Properties.Buttons[0].Enabled = false;
            tbxTotalInvoice.Enabled = false;
            tbxTotal.Enabled = false;

            tbxDate.DateTime = model.DateProcess;
            tsBaseTxt_Code.Text = model.Code;
            lkpFranchise.DefaultValue = new IListParameter[] { WhereTerm.Default(model.FranchiseId, "id") };
            lkpPaymentType.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PaymentTypeId, "id") };
            tbxDescription.Text = model.Description;
            tbxTotalInvoice.SetValue(model.TotalInvoice);
            tbxAdjustment.SetValue(model.Adjustment);
            tbxTotal.SetValue(model.Total);

            GridPayment.DataSource = new FranchiseCreditPaymentDetailDataManager().Get<FranchiseCreditPaymentDetailModel>(WhereTerm.Default(model.Id, "franchise_credit_payment_id"));
            PaymentView.RefreshData();
        }

        protected override FranchiseCreditPaymentModel PopulateModel(FranchiseCreditPaymentModel model)
        {
            model.DateProcess = tbxDate.DateTime;
            model.BranchId = BaseControl.BranchId;
            model.FranchiseId = (int)lkpFranchise.Value;
            model.FranchiseName = lkpFranchise.Text;
            model.PaymentTypeId = (int)lkpPaymentType.Value;
            model.Description = tbxDescription.Text;
            model.TotalInvoice = tbxTotalInvoice.Value;
            model.Adjustment = tbxAdjustment.Value;
            model.Total = tbxTotal.Value;

            if (model.Id == 0)
            {
                model.Code = new FranchiseCreditPaymentDataManager().GenerateCode(BaseControl.BranchId);
                model.CreatedPc = Environment.MachineName;
            }
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            var creditDetailDm = new FranchiseCreditPaymentDetailDataManager();
            for (var i = 0; i < PaymentView.RowCount; i++)
            {
                var state = PaymentView.GetRowCellValue(i, PaymentView.Columns["StateChange"]).ToString();
                var detail = new FranchiseCreditPaymentDetailModel();

                if (state == EnumStateChange.Insert.ToString())
                {
                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.FranchiseCreditPaymentId = CurrentModel.Id;
                    detail.InvoiceId = (int)PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceId"]);
                    detail.InvoiceDate = (DateTime)PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceDate"]);
                    detail.InvoiceCode = PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceCode"]).ToString();
                    detail.InvoiceTotal = (decimal)PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceTotal"]);
                    detail.InvoiceBalance = (decimal)PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceBalance"]);
                    detail.Payment = (decimal)PaymentView.GetRowCellValue(i, PaymentView.Columns["Payment"]);
                    detail.Balance = (decimal)PaymentView.GetRowCellValue(i, PaymentView.Columns["Balance"]);

                    detail.Createdby = BaseControl.UserLogin;
                    detail.Createddate = DateTime.Now;

                    if (detail.Payment > 0)
                    {
                        creditDetailDm.Save<FranchiseCreditPaymentDetailModel>(detail);

                        if (detail.Balance == 0)
                        {
                            var invoices = new FranchiseInvoiceListDataManager().Get<FranchiseInvoiceListModel>(WhereTerm.Default(detail.InvoiceId, "franchise_invoice_id"))
                                .Select(d => d.ShipmentId.ToString()).ToArray();
                            new FranchiseCreditPaymentDetailDataManager().PaidShipmentStatus(invoices, 1, BaseControl.UserLogin);
                        }
                    }
                }

                if (state == EnumStateChange.Update.ToString())
                {
                    var id = (int)PaymentView.GetRowCellValue(i, PaymentView.Columns["Id"]);
                    detail = creditDetailDm.GetFirst<FranchiseCreditPaymentDetailModel>(WhereTerm.Default(id, "id"));

                    detail.Payment = (decimal)PaymentView.GetRowCellValue(i, PaymentView.Columns["Payment"]);
                    detail.Balance = (decimal)PaymentView.GetRowCellValue(i, PaymentView.Columns["Balance"]);

                    detail.Modifiedby = BaseControl.UserLogin;
                    detail.Modifieddate = DateTime.Now;

                    if (detail.Payment == 0)
                    {
                        creditDetailDm.DeActive(detail.Id, BaseControl.UserLogin, DateTime.Now);
                    }
                    else
                        creditDetailDm.Update<FranchisePaymentInDetailModel>(detail);

                    var invoices = new FranchiseInvoiceListDataManager().Get<FranchiseInvoiceListModel>(WhereTerm.Default(detail.InvoiceId, "franchise_invoice_id"))
                            .Select(d => d.ShipmentId.ToString()).ToArray();
                    if (detail.Balance == 0)
                        new FranchiseCreditPaymentDetailDataManager().PaidShipmentStatus(invoices, 1, BaseControl.UserLogin);
                    else new FranchiseCreditPaymentDetailDataManager().PaidShipmentStatus(invoices, 0, BaseControl.UserLogin);
                }
            }
        }

        protected override void AfterSave()
        {
            base.AfterSave();

            ToolbarCode = ((FranchiseCreditPaymentModel)CurrentModel).Code;
            OpenData(ToolbarCode);
        }

        public override void AfterDelete()
        {
            var detail = new FranchiseCreditPaymentDetailDataManager().Get<FranchiseCreditPaymentDetailModel>(WhereTerm.Default(CurrentModel.Id, "franchise_credit_payment_id"));
            if (detail != null)
            {
                var creditListDm = new FranchiseCreditPaymentDetailDataManager();
                foreach (FranchiseCreditPaymentDetailModel obj in detail)
                {
                    var invoices = new FranchiseInvoiceListDataManager().Get<FranchiseInvoiceListModel>(WhereTerm.Default(obj.InvoiceId, "franchise_invoice_id"))
                            .Select(d => d.ShipmentId.ToString()).ToArray();
                    new FranchiseCreditPaymentDetailDataManager().PaidShipmentStatus(invoices, 0, BaseControl.UserLogin);

                    creditListDm.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
                }
            }
            base.AfterDelete();
        }

        protected override FranchiseCreditPaymentModel Find(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm)) tsBaseTxt_Code.Text = searchTerm;
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<FranchiseCreditPaymentModel>(param);
            PopulateForm(obj);

            return obj;
        }
    }
}
