using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraGrid.Views.Base;
using SISCO.App.Finance;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.Finance.Popup;
using System.Text.RegularExpressions;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class PaymentInCounterForm : BaseCrudForm<PaymentInCounterModel, PaymentInCounterDataManager>//BaseToolbarForm//
    {
        private string Code { get; set; }
        private decimal MaxAmount { get; set; }
        private TransactionalAccountPopup transactionPopup;

        public PaymentInCounterForm()
        {
            InitializeComponent();

            form = this;
            PaymentView.CustomColumnDisplayText += NumberGrid;

            Load += PaymentInCounterCashLoad;
            PaymentView.CellValueChanged += Changed;
            tbxAdjustment.Leave += (sender, args) => tbxTotal.SetValue((tbxTotalSales.Value - tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));
            btnTambah.Click += Pay;

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)
            };

            tbxBarcode.KeyDown += (sender, args) =>
            {
                FocusBarcode = false;
                switch (args.KeyCode)
                {
                    case Keys.Enter:
                        if (!args.Shift)
                        {
                            FocusBarcode = true;
                        }
                        break;
                }

                base.OnKeyDown(args);
            };

            btnTambah.GotFocus += (sender, args) =>
            {
                if (FocusBarcode)
                {
                    FocusBarcode = false;
                    Pay(sender, args);
                }
            };
        }

        private bool FocusBarcode { get; set; }

        private void Pay(object sender, EventArgs e)
        {
            if (tbxBarcode.Text == "")
            {
                tbxBarcode.Focus();
                return;
            }

            var total = 0;
            for (var i = 0; i < PaymentView.RowCount; i++)
            {
                if (PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceCode"]).ToString() == tbxBarcode.Text)
                {
                    var balance =
                        (decimal)PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceBalance"]);

                    PaymentView.SetRowCellValue(i, PaymentView.Columns["Payment"], balance);
                    PaymentView.SetRowCellValue(i, PaymentView.Columns["Balance"], 0);
                    PaymentView.SetRowCellValue(i, PaymentView.Columns["Paid"], true);
                    PaymentView.SetRowCellValue(i, PaymentView.Columns["Checked"], true);
                }

                total += Convert.ToInt32(PaymentView.GetRowCellValue(i, PaymentView.Columns["Payment"]));
            }

            tbxBarcode.Clear();
            tbxBarcode.Focus();

            tbxTotalSales.SetValue(total.ToString(CultureInfo.InvariantCulture));
            tbxTotal.SetValue(((Int64)tbxTotalSales.Value - (Int64)tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));
        }

        private void Changed(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "clState" && e.Column.Name == "clChecked")
            {
                if (PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["StateChange2"]).ToString() != EnumStateChange.Insert.ToString())
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["StateChange2"], EnumStateChange.Update);

                var balance =
                        (decimal)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["InvoiceBalance"]);
                if ((bool) PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["Checked"]))
                {
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Payment"], balance);
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Balance"], 0);
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Paid"], true);
                }
                else
                {
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Payment"], 0);
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Balance"], balance);
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Paid"], false);
                }

                var total = 0;
                for (var i = 0; i < PaymentView.RowCount; i++)
                {
                    total += Convert.ToInt32(PaymentView.GetRowCellValue(i, PaymentView.Columns["Payment"]));
                }

                tbxTotalSales.SetValue(total.ToString(CultureInfo.InvariantCulture));
                tbxTotal.SetValue(((Int64)tbxTotalSales.Value - (Int64)tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));
            }
        }

        private void PaymentInCounterCashLoad(object sender, EventArgs e)
        {
            ClearForm();
            EnabledForm(false);
            EnableBtnSearch = true;
            SearchPopup = new PaymentInCounterFilterPopup();

            transactionPopup = new TransactionalAccountPopup(lkpAccount, true);

            MaxAmount = 0;

            PaymentView.CellValueChanging += Changing;
            tbxAdjustment.IsNumber = true;
            tbxTotal.IsNumber = true;
            tbxTotalSales.IsNumber = true;

            lkpAccount.LookupPopup = new BankAccountPopup(true);
            lkpAccount.AutoCompleteDataManager = new BankAccountDataManager();
            lkpAccount.AutoCompleteDisplayFormater = model => ((BankAccountModel)model).AccountNo + " " + ((BankAccountModel)model).BankName;
            lkpAccount.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("account_no.StartsWith(@0) and branch_id = @1", s, BaseControl.BranchId);

            lkpAccount.TextChanged += (s, ar) =>
            {
                lkpTransactional.Value = null;
                lkpTransactional.Text = string.Empty;
                MaxAmount = 0;
            };

            lkpTransactional.LookupPopup = transactionPopup;
            lkpTransactional.AutoCompleteDataManager = new TransactionalAccountDataManager();
            lkpTransactional.AutoCompleteDisplayFormater = model => ((TransactionalAccountModel)model).Description + " Rp " + ((TransactionalAccountModel)model).CreditTotalAmount.ToString("#,#");
            lkpTransactional.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression(string.Format("(description.StartsWith(@0){0}) and debit_total_amount = 0 and closed_date = null", Regex.IsMatch(s, "^[0-9]+$") ? " or credit_total_amount = " + s : ""), s);

            lkpTransactional.Leave += lkpTransactional_Leave;

            tbxDate.EditValueChanged += tbxDate_EditValueChanged;
        }

        void tbxDate_EditValueChanged(object sender, EventArgs e)
        {
            transactionPopup.paymentDate = tbxDate.DateTime;
        }

        void lkpTransactional_Leave(object sender, EventArgs e)
        {
            if (lkpTransactional.Value != null)
            {
                //MaxAmount = new TransactionalAccountDataManager().GetTransactionBalanceAgaintsPayment((int)lkpTransactional.Value, null, CurrentModel.Id > 0 ? (int?)CurrentModel.Id : null);
            }
        }

        private void Changing(object sender, CellValueChangedEventArgs e)
        {
            var balance =
                        (decimal)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["InvoiceBalance"]);
            if (!(bool)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["Checked"]))
            {
                PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Payment"], balance);
                PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Balance"], 0);
                PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Paid"], true);
                PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Checked"], true);
            }
            else
            {
                PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Payment"], 0);
                PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Balance"], balance);
                PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Paid"], false);
                PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Checked"], false);
            }
        }

        private void GetUnpaid()
        {
            var payment = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default("CASH", "name", EnumSqlOperator.Equals));
            var shipmentCash = new ShipmentDataManager().Get<ShipmentModel>(new IListParameter[]
            {
                WhereTerm.Default(5, "sales_type_id", EnumSqlOperator.NotEqual),
                WhereTerm.Default(payment.Id, "payment_method_id", EnumSqlOperator.Equals),
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                WhereTerm.Default(false, "paid"),
                WhereTerm.Default(false, "voided")
            });

            /*var counters = shipmentCash.Select(obj => new PaymentInCounterDetailModel
            {
                PaymentInCounterId = 0,
                InvoiceId = obj.Id,
                InvoiceDate = obj.DateProcess,
                InvoiceCode = obj.Code,
                InvoiceTotal = obj.CurrencyId != null ? obj.Total * (new CurrencyDataManager().GetFirst<CurrencyModel>(WhereTerm.Default((int) obj.CurrencyId, "id", EnumSqlOperator.Equals)).Rate) : obj.Total,
                InvoiceBalance = obj.Total,
                Payment = 0,
                Balance = obj.Total,
                Checked = false,
                Paid = false,
                StateChange2 = EnumStateChange.Insert.ToString()
            }).ToList().OrderBy(p => p.DateProcess);*/

            //var counters = (from obj in shipmentCash
            //    let total = obj.CurrencyId != null ? obj.Total*(new CurrencyDataManager().GetFirst<CurrencyModel>(WhereTerm.Default((int) obj.CurrencyId, "id", EnumSqlOperator.Equals)).Rate) : obj.Total
            //    select new PaymentInCounterDetailModel
            //    {
            //        PaymentInCounterId = 0, InvoiceId = obj.Id, InvoiceDate = obj.DateProcess, InvoiceCode = obj.Code, InvoiceTotal = total, InvoiceBalance = total, Payment = 0, Balance = total, Checked = false, Paid = false, StateChange2 = EnumStateChange.Insert.ToString()
            //    }).ToList().OrderBy(p => p.DateProcess);

            var counters = (from obj in shipmentCash
                            let total = obj.Total
                            select new PaymentInCounterDetailModel
                            {
                                PaymentInCounterId = 0,
                                InvoiceId = obj.Id,
                                InvoiceDate = obj.DateProcess,
                                InvoiceCode = obj.Code,
                                InvoiceTotal = total,
                                InvoiceBalance = total,
                                Payment = 0,
                                Balance = total,
                                Checked = false,
                                Paid = false,
                                StateChange2 = EnumStateChange.Insert.ToString()
                            }).OrderBy(p => p.DateProcess).ToList();

            GridPayment.DataSource = counters;
            PaymentView.RefreshData();
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();

            ClearForm();
            EnabledForm(true);

            tbxDate.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            tbxDate.Focus();

            tbxTotal.ReadOnly = true;
            tbxTotalSales.ReadOnly = true;

            MaxAmount = 0;
            GetUnpaid();
        }

        public override void Save()
        {
            //var obj = (List<PaymentInCounterDetailModel>)GridPayment.DataSource;
            //var obj = ((IOrderedEnumerable<PaymentInCounterDetailModel>)GridPayment.DataSource).ToList<PaymentInCounterDetailModel>();
            var obj = GridPayment.DataSource as List<PaymentInCounterDetailModel>;
            if (obj != null)
                //if (tbxTotal.Value > MaxAmount)
                //{
                //    MessageBox.Show(string.Format("Batas total pembayaran tidak bisa melebihi Rp {0}", MaxAmount.ToString("#,#")));
                //    return;
                //}

                if (obj.FirstOrDefault(b => b.Paid) != null)
                {
                    Code = CurrentModel.Id > 0 ? ((PaymentInCounterModel)CurrentModel).Code : (tbxDate.Text != "" ? GetCode("counter", tbxDate.Value) : "");

                    base.Save();
                    return;
                }

            MessageBox.Show(Resources.data_empty, Resources.information, MessageBoxButtons.OK);
        }

        protected override void  SaveDetail(bool isUpdate = false)
        {
            Enabled = false;
            var dm = new PaymentInCounterDetailDataManager();
            var sdm = new ShipmentDataManager();
            for (var i = 0; i < PaymentView.RowCount; i++)
            {
                var state = PaymentView.GetRowCellValue(i, PaymentView.Columns["StateChange2"]).ToString();
                var detail = new PaymentInCounterDetailModel();

                if (state == EnumStateChange.Insert.ToString())
                {
                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.PaymentInCounterId = CurrentModel.Id;
                    detail.DateProcess = DateTime.Now;
                    detail.InvoiceId = (int) PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceId"]);
                    detail.InvoiceDate = (DateTime) PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceDate"]);
                    detail.InvoiceCode = PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceCode"]).ToString();
                    detail.InvoiceTotal = (decimal) PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceTotal"]);
                    detail.InvoiceBalance = (decimal)PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceBalance"]);
                    detail.Payment = (decimal) PaymentView.GetRowCellValue(i, PaymentView.Columns["Payment"]);
                    detail.Balance = (decimal) PaymentView.GetRowCellValue(i, PaymentView.Columns["Balance"]);
                    detail.Checked = (bool) PaymentView.GetRowCellValue(i, PaymentView.Columns["Checked"]);
                    detail.Paid = (bool) PaymentView.GetRowCellValue(i, PaymentView.Columns["Paid"]);

                    detail.Createdby = BaseControl.UserLogin;
                    detail.Createddate = DateTime.Now;

                    if (detail.Payment > 0)
                    {
                        dm.Save<PaymentInCounterDetailModel>(detail);

                        var shipment =
                            sdm.GetFirst<ShipmentModel>(WhereTerm.Default((int) detail.InvoiceId, "id",
                                EnumSqlOperator.Equals));
                        shipment.TotalPayment = detail.Payment;
                        shipment.Paid = detail.Paid;

                        sdm.Update<ShipmentModel>(shipment);
                    }
                }

                if (state == EnumStateChange.Update.ToString())
                {
                    var id = (int) PaymentView.GetRowCellValue(i, PaymentView.Columns["Id"]);
                    detail = dm.GetFirst<PaymentInCounterDetailModel>(WhereTerm.Default(id, "id", EnumSqlOperator.Equals));

                    detail.Payment = (decimal)PaymentView.GetRowCellValue(i, PaymentView.Columns["Payment"]);
                    detail.Balance = (decimal)PaymentView.GetRowCellValue(i, PaymentView.Columns["Balance"]);
                    detail.Checked = (bool)PaymentView.GetRowCellValue(i, PaymentView.Columns["Checked"]);
                    detail.Paid = (bool)PaymentView.GetRowCellValue(i, PaymentView.Columns["Paid"]);

                    detail.Modifiedby = BaseControl.UserLogin;
                    detail.Modifieddate = DateTime.Now;

                    if (detail.Payment == 0)
                    {
                        dm.DeActive(detail.Id, BaseControl.UserLogin, DateTime.Now);
                    }
                    else
                        dm.Update<PaymentInCounterDetailModel>(detail);

                    // ReSharper disable once PossibleInvalidOperationException
                    var shipment = sdm.GetFirst<ShipmentModel>(WhereTerm.Default((int) detail.InvoiceId, "id", EnumSqlOperator.Equals));
                    if (shipment != null)
                    {
                        shipment.TotalPayment = detail.Payment;
                        shipment.Paid = detail.Paid;

                        sdm.Update<ShipmentModel>(shipment);
                    }
                }
            }

            Enabled = true;
        }

        protected override void AfterSave()
        {
            ToolbarCode = ((PaymentInCounterModel)CurrentModel).Code;
            OpenData(ToolbarCode);
        }

        public override void AfterDelete()
        {
            var detail = new PaymentInCounterDetailDataManager().Get<PaymentInCounterDetailModel>(WhereTerm.Default(CurrentModel.Id, "payment_in_counter_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new PaymentInCounterDetailDataManager();
                var r = new ShipmentDataManager();
                foreach (PaymentInCounterDetailModel obj in detail)
                {
                    if (obj.InvoiceId != null)
                    {
                        var d = r.GetFirst<ShipmentModel>(WhereTerm.Default((int)obj.InvoiceId, "id", EnumSqlOperator.Equals));
                        d.TotalPayment = 0;
                        d.Paid = false;

                        r.Update<ShipmentModel>(d);
                    }

                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);

                }
            }

            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text != "") return true;
            if (lkpAccount.Value == null)
            {
                lkpAccount.Focus();
                return false;
            }

            //if (lkpTransactional.Value == null)
            //{
            //    lkpTransactional.Focus();
            //    return false;
            //}

            return false;
        }

        protected override void PopulateForm(PaymentInCounterModel model)
        {
            ClearForm();
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

            tbxTotal.ReadOnly = true;
            tbxTotalSales.ReadOnly = true;

            MaxAmount = 0;

            if (model.TransactionalAccountId > 0)
            {
                var transactionanl = new TransactionalAccountDataManager().GetFirst<TransactionalAccountModel>(WhereTerm.Default(model.TransactionalAccountId, "id"));
                lkpAccount.DefaultValue = new IListParameter[] { WhereTerm.Default(transactionanl.BankAccountId, "id") };
                lkpTransactional.DefaultValue = new IListParameter[] { WhereTerm.Default(transactionanl.Id, "id") };

                MaxAmount = new TransactionalAccountDataManager().GetTransactionBalanceAgaintsPayment(transactionanl.Id, null, model.Id);
            }
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
            if (lkpTransactional.Value != null)
                model.TransactionalAccountId = (int)lkpTransactional.Value;
            else model.TransactionalAccountId = 0;

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

        protected override void SetPagingState()
        {
            base.SetPagingState();

            if (CurrentModel == null)
            {
                ClearForm();
                EnabledForm(false);

                GridPayment.DataSource = null;
                PaymentView.RefreshData();
            }
            else
            {
                var model = CurrentModel as PaymentInCounterModel;
                if (model.Verified)
                {
                    EnabledForm(false);
                }
            }
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            var model = CurrentModel as PaymentInCounterModel;
            if (model != null && model.Id > 0 && model.Verified)
            {
                EnabledForm(false);
                tsBaseBtn_Delete.Enabled = false;
                tsBaseBtn_Save.Enabled = false;

                AutoClosingMessageBox.Show("Pembayaran sudah di verifikasi Audit");
            }
        }

        public override void Info()
        {
            var model = CurrentModel as PaymentInCounterModel;

            if (model != null)
            {
                info.CreatedPc = model.CreatedPc;
                info.ModifiedPc = model.ModifiedPc;
            }

            base.Info();
        }
    }
}