using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.XtraGrid.Views.Base;
using SISCO.App.Finance;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.Finance.Popup;
using SISCO.Presentation.MasterData.Popup;
using System.Text.RegularExpressions;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class PaymentInCollectOutForm : BaseCrudForm<PaymentInCollectOutModel, PaymentInCollectOutDataManager>//BaseToolbarForm//
    {
        private PaymentInCollectOutDetailDataManager _detailDm = new PaymentInCollectOutDetailDataManager();
        private string Code { get; set; }
        private bool DeleteOld { get; set; }
        private decimal MaxAmount { get; set; }
        private TransactionalAccountPopup transactionPopup;

        public PaymentInCollectOutForm()
        {
            InitializeComponent();

            form = this;
            Load += PaymentInCollectOutLoad;
            tbxOrigin.Leave += GetInvoice;

            btnTambah.Click += BayarStt;

            CollectOutView.CustomColumnDisplayText += NumberGrid;
            CollectOutView.CellValueChanged += Changed;
            tbxAdjustment.Leave += CalculateTotal;

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "owner_branch_id", EnumSqlOperator.Equals)
            };
        }

        private void CalculateTotal(object sender, EventArgs e)
        {
            tbxTotal.SetValue(((Int64)tbxTotalSales.Value - (Int64)tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));
        }

        private void BayarStt(object sender, EventArgs e)
        {
            tbxBarcode.Focus();

            if (tbxBarcode.Text == "") return;
            for (var i = 0; i < CollectOutView.RowCount; i++)
            {
                var stt = CollectOutView.GetRowCellValue(i, CollectOutView.Columns["InvoiceCode"]).ToString();
                if (stt == tbxBarcode.Text)
                {
                    CollectOutView.SetRowCellValue(i, CollectOutView.Columns["Checked"], true);
                }
            }

            tbxBarcode.Clear();
        }

        private void Changed(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "clState" && e.Column.Name != "clBalance")
            {
                var due =
                    Convert.ToInt32(CollectOutView.GetRowCellValue(e.RowHandle, CollectOutView.Columns["InvoiceBalance"]));

                if (e.Column.Name == "clChecked")
                {
                    if ((bool)CollectOutView.GetRowCellValue(e.RowHandle, CollectOutView.Columns["Checked"]))
                    {
                        CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["Balance"], 0);
                        CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["Payment"], due);
                    }
                    else
                    {
                        CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["Balance"], due);
                        CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["Payment"], 0);
                    }
                }

                if (e.Column.Name == "clPayment")
                {
                    var payment =
                        Convert.ToInt32(CollectOutView.GetRowCellValue(e.RowHandle, CollectOutView.Columns["Payment"]));
                    CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["Balance"], (due - payment));
                }

                var total = 0;
                for (var i = 0; i < CollectOutView.RowCount; i++)
                {
                    total += Convert.ToInt32(CollectOutView.GetRowCellValue(i, CollectOutView.Columns["Payment"]));
                }

                // ReSharper disable once SpecifyACultureInStringConversionExplicitly
                tbxTotalSales.SetValue(total.ToString());
                // ReSharper disable once SpecifyACultureInStringConversionExplicitly
                tbxTotal.SetValue(((Int64) tbxTotalSales.Value - (Int64) tbxAdjustment.Value).ToString());

                if (CollectOutView.GetRowCellValue(e.RowHandle, CollectOutView.Columns["StateChange2"]).ToString() ==
                    EnumStateChange.Idle.ToString())
                {
                    CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["StateChange2"],
                        EnumStateChange.Insert);
                }

                if (CollectOutView.GetRowCellValue(e.RowHandle, CollectOutView.Columns["StateChange2"]).ToString() ==
                    EnumStateChange.Select.ToString())
                {
                    CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["StateChange2"],
                        EnumStateChange.Update);
                }
            }
        }

        private void GetInvoice(object sender, EventArgs e)
        {
            base.OnLeave(e);

            GridCollectOut.DataSource = null;
            CollectOutView.RefreshData();

            if (tbxOrigin.Value != null)
            {
                /*var inv =
                    new PaymentInCollectInDetailDataManager().Get<PaymentInCollectInDetailModel>(new IListParameter[]
                    {
                        WhereTerm.Default(false, "paid")
                    });

                var mst = new PaymentInCollectInDataManager().Get<PaymentInCollectInModel>(WhereTerm.Default((int) tbxOrigin.Value, "branch_id", EnumSqlOperator.Equals));
                var invoices = mst.SelectMany(x => inv.Where(y => y.PaymentInCollectInId == x.Id)).ToList();

                var ds = new List<PaymentOutCollectInDetailModel>();

                // ReSharper disable once LoopCanBeConvertedToQuery
                foreach (PaymentInCollectInDetailModel invoice in invoices)
                {
                    var payment = _detailDm.GetPaymentOutCollectIn(invoice.Id);
                    var balance = invoice.InvoiceTotal - payment;

                    ds.Add(new PaymentOutCollectInDetailModel
                    {
                        PaymentInCollectInCode = invoice.PaymentInCollectInCode,
                        InvoiceId = invoice.Id,
                        InvoiceCode = invoice.InvoiceCode,
                        // ReSharper disable once PossibleInvalidOperationException
                        InvoiceDate = (DateTime)invoice.InvoiceDate,
                        InvoiceTotal = invoice.InvoiceTotal,
                        InvoiceBalance = balance,
                        Payment = 0,
                        Balance = balance,
                        Checked = false,
                        Paid = false,
                        CollectPaymentMethod = invoice.CollectPaymentMethod,
                        StateChange = EnumStateChange.Insert
                    });
                }

                GridCollectOut.DataSource = ds;
                CollectOutView.RefreshData();*/

                //var param = new List<WhereTerm>();
                //param.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));

                //var collect = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default("COLLECT", "name", EnumSqlOperator.Equals));
                //param.Add(WhereTerm.Default(collect.Id, "payment_method_id", EnumSqlOperator.Equals));

                //if (tbxOrigin.Value != null)
                //{
                //    param.Add(WhereTerm.Default((int)tbxOrigin.Value, "dest_branch_id", EnumSqlOperator.Equals));
                //}

                //IListParameter[] p = null;
                //if (param.Any())
                //{
                //    // ReSharper disable once CoVariantArrayConversion
                //    p = param.ToArray();
                //}

                //var detail = new ShipmentDataManager().ShipmentList(p);
                //var ds = new List<PaymentInCollectOutDetailModel>();

                // ReSharper disable once LoopCanBeConvertedToQuery
                //foreach (SISCO.Models.ShipmentModel.ShipmentReportRow invoice in detail)
                //{
                //    var payment = _detailDm.GetPaymentOutCollectIn(invoice.Id);
                //    var balance = invoice.Total - payment;

                //    if (balance > 0)
                //    {
                //        ds.Add(new PaymentInCollectOutDetailModel
                //        {
                //            InvoiceId = invoice.Id,
                //            InvoiceCode = invoice.Code,
                //            InvoiceDate = invoice.DateProcess,
                //            InvoiceTotal = invoice.Total,
                //            InvoiceBalance = balance,
                //            Payment = 0,
                //            Balance = balance,
                //            Checked = false,
                //            Paid = false,
                //            CollectPaymentMethod = invoice.CollectPaymentMethod,
                //            StateChange2 = EnumStateChange.Idle.ToString()
                //        });
                //    }
                //}

                var ds = _detailDm.GetPaymentOutCollectIn(BaseControl.BranchId, (int)tbxOrigin.Value);

                GridCollectOut.DataSource = ds;
                CollectOutView.RefreshData();
            }
        }

        private void PaymentInCollectOutLoad(object sender, EventArgs e)
        {
            ClearForm();

            transactionPopup = new TransactionalAccountPopup(lkpAccount, true);

            MaxAmount = 0;
            EnabledForm(false);
            EnableBtnSearch = true;

            SearchPopup = new PaymentInCollectOutFilterPopup();

            tbxOrigin.LookupPopup = new BranchPopup();
            tbxOrigin.AutoCompleteDataManager = new BranchDataManager();
            tbxOrigin.AutoCompleteDisplayFormater = model => ((BranchModel)model).Name;
            tbxOrigin.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            
            tbxPayment.LookupPopup = new PaymentTypePopup();
            tbxPayment.AutoCompleteDataManager = new PaymentTypeDataManager();
            tbxPayment.AutoCompleteDisplayFormater = model => ((PaymentTypeModel)model).Name;
            tbxPayment.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            lkpAccount.LookupPopup = new BankAccountPopup();
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

            tbxAmount.IsNumber = true;
            tbxTotal.IsNumber = true;
            tbxTotalSales.IsNumber = true;
            tbxAdjustment.IsNumber = true;

            CollectOutView.CellValueChanging += Changing;
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
                //MaxAmount = new TransactionalAccountDataManager().GetTransactionBalanceAgaintsPayment((int)lkpTransactional.Value, CurrentModel.Id > 0 ? (int?)CurrentModel.Id : null);
            }
        }

        private void Changing(object sender, CellValueChangedEventArgs e)
        {
            var due =
                    Convert.ToInt32(CollectOutView.GetRowCellValue(e.RowHandle, CollectOutView.Columns["InvoiceBalance"]));

            if (e.Column.Name == "clChecked")
            {
                if (!(bool)CollectOutView.GetRowCellValue(e.RowHandle, CollectOutView.Columns["Checked"]))
                {
                    CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["Balance"], 0);
                    CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["Payment"], due);
                    CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["Checked"], true);
                }
                else
                {
                    CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["Balance"], due);
                    CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["Payment"], 0);
                    CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["Checked"], false);
                }
            }
        }

        public override void New()
        {
            ClearForm();
            EnabledForm(true);

            base.New();

            tbxDate.Focus();
            GridCollectOut.DataSource = null;
            CollectOutView.RefreshData();

            MaxAmount = 0;
        }

        public override void Save()
        {
            //if (tbxAmount.Value > MaxAmount)
            //{
            //    MessageBox.Show("Batas total transaksi buku bank adalah Rp " + MaxAmount.ToString("#,#"));
            //    tbxAmount.Focus();
            //    return;
            //}

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (tbxAmount.Value != tbxTotal.Value)
            {
                MessageForm.Info(this, Resources.information, Resources.total_invoice);
                tbxAmount.Focus();
                return;
            }

            DeleteOld = false;

            if (CurrentModel.Id > 0)
            {
                if (((PaymentInCollectOutModel) CurrentModel).BranchId != tbxOrigin.Value) DeleteOld = true;
                Code = ((PaymentInCollectOutModel) CurrentModel).Code;
            }
            else
            {
                if (tbxDate.Text != "") 
                    Code = GetCode("paymentout", tbxDate.Value);
            }
            base.Save();
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            Enabled = false;
            if (DeleteOld)
            {
                new PaymentInCollectOutDetailDataManager().DeActiveRows(new IListParameter[]
                {
                    WhereTerm.Default(CurrentModel.Id, "payment_in_collect_out_id", EnumSqlOperator.Equals)
                }, BaseControl.UserLogin);
            }

            // ReSharper disable once InconsistentNaming
            var DetailRepo = new PaymentInCollectOutDetailDataManager();
            for (int i = 0; i < CollectOutView.RowCount; i++)
            {
                var state = CollectOutView.GetRowCellValue(i, CollectOutView.Columns["StateChange2"]);
                var payment = (decimal)CollectOutView.GetRowCellValue(i, CollectOutView.Columns["Payment"]);
                var detail = new PaymentInCollectOutDetailModel();

                if (state.ToString().Equals(EnumStateChange.Insert.ToString()) && payment > 0)
                {
                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.DateProcess = DateTime.Now;
                    detail.PaymentInCollectOutId = CurrentModel.Id;
                    detail.InvoiceId =
                            (int)CollectOutView.GetRowCellValue(i, CollectOutView.Columns["InvoiceId"]);
                    detail.InvoiceDate =
                            (DateTime)CollectOutView.GetRowCellValue(i, CollectOutView.Columns["InvoiceDate"]);
                    detail.InvoiceCode =
                            CollectOutView.GetRowCellValue(i, CollectOutView.Columns["InvoiceCode"]).ToString();
                    detail.InvoiceTotal =
                            (decimal)CollectOutView.GetRowCellValue(i, CollectOutView.Columns["InvoiceTotal"]);
                    detail.InvoiceBalance =
                            (decimal)CollectOutView.GetRowCellValue(i, CollectOutView.Columns["InvoiceBalance"]);
                    detail.Payment = payment;
                    detail.Balance =
                            (decimal)CollectOutView.GetRowCellValue(i, CollectOutView.Columns["Balance"]);
                    detail.Checked =
                            (bool)CollectOutView.GetRowCellValue(i, CollectOutView.Columns["Checked"]);
                    detail.Paid = false;
                    detail.CollectPaymentMethod = CollectOutView.GetRowCellValue(i, CollectOutView.Columns["CollectPaymentMethod"]) != null ? CollectOutView.GetRowCellValue(i, CollectOutView.Columns["CollectPaymentMethod"]).ToString() : "";

                    detail.Createdby = BaseControl.UserLogin;
                    detail.Createddate = DateTime.Now;

                    if (detail.Payment > 0) DetailRepo.Save<PaymentInCollectOutDetailModel>(detail);
                }

                if (state.ToString().Equals(EnumStateChange.Update.ToString()))
                {
                    detail = DetailRepo.GetFirst<PaymentInCollectOutDetailModel>(WhereTerm.Default((int)CollectOutView.GetRowCellValue(i, CollectOutView.Columns["Id"]), "id", EnumSqlOperator.Equals));
                    detail.Payment =
                            (decimal)CollectOutView.GetRowCellValue(i, CollectOutView.Columns["Payment"]);
                    detail.Balance =
                            (decimal)CollectOutView.GetRowCellValue(i, CollectOutView.Columns["Balance"]);
                    detail.Checked =
                            (bool)CollectOutView.GetRowCellValue(i, CollectOutView.Columns["Checked"]);
                    detail.Modifiedby = BaseControl.UserLogin;
                    detail.Modifieddate = DateTime.Now;

                    if (detail.Payment == 0)
                    {
                        DetailRepo.DeActive(detail.Id, BaseControl.UserLogin, DateTime.Now);
                    }
                    else 
                        DetailRepo.Update<PaymentInCollectOutDetailModel>(detail);
                }
            }

            Enabled = true;
        }

        protected override void AfterSave()
        {
            ToolbarCode = ((PaymentInCollectOutModel)CurrentModel).Code;
            OpenData(ToolbarCode);
        }

        public override void AfterDelete()
        {
            var detail = new PaymentInCollectOutDetailDataManager().Get<PaymentInCollectOutDetailModel>(WhereTerm.Default(CurrentModel.Id, "payment_in_collect_out_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new PaymentInCollectOutDetailDataManager();
                foreach (PaymentInCollectOutDetailModel obj in detail)
                {
                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
                }
            }

            ClearForm();
            GridCollectOut.DataSource = null;

            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text != "" && tbxOrigin.Text != "" && tbxPayment.Text != "") return true;
            return false;
        }

        protected override void PopulateForm(PaymentInCollectOutModel model)
        {
            ClearForm();

            if (model == null) return;

            MaxAmount = 0;
            ToolbarCode = model.Code;
            tbxDate.Text = model.DateProcess.ToString(CultureInfo.InvariantCulture);
            tbxOrigin.DefaultValue = new IListParameter[] { WhereTerm.Default(model.BranchId, "id", EnumSqlOperator.Equals) };
            
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxAmount.SetValue(model.Amount.ToString());

            tbxPayment.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PaymentTypeId, "id", EnumSqlOperator.Equals) };
            tbxDescription.Text = model.Description;

            tbxTotalSales.SetValue(model.TotalInvoice.ToString(CultureInfo.InvariantCulture));
            tbxAdjustment.SetValue(model.Adjustment.ToString(CultureInfo.InvariantCulture));
            tbxTotal.SetValue(model.Total.ToString(CultureInfo.InvariantCulture));

            if (model.TransactionalAccountId > 0)
            {
                var transactionanl = new TransactionalAccountDataManager().GetFirst<TransactionalAccountModel>(WhereTerm.Default(model.TransactionalAccountId, "id"));
                lkpAccount.DefaultValue = new IListParameter[] { WhereTerm.Default(transactionanl.BankAccountId, "id") };
                lkpTransactional.DefaultValue = new IListParameter[] { WhereTerm.Default(transactionanl.Id, "id") };

                MaxAmount = new TransactionalAccountDataManager().GetTransactionBalanceAgaintsPayment(transactionanl.Id, model.Id);
            }

            GridCollectOut.DataSource = new PaymentInCollectOutDetailDataManager().Get<PaymentInCollectOutDetailModel>(WhereTerm.Default(model.Id, "payment_in_collect_out_id", EnumSqlOperator.Equals));
            CollectOutView.RefreshData();
        }

        protected override PaymentInCollectOutModel PopulateModel(PaymentInCollectOutModel model)
        {
            model.Code = Code;
            model.DateProcess = tbxDate.Value;
            if (tbxOrigin.Value != null) model.BranchId = (int) tbxOrigin.Value;
            model.OwnerBranchId = BaseControl.BranchId;
            if (tbxPayment.Value != null) model.PaymentTypeId = (int)tbxPayment.Value;
            model.Description = tbxDescription.Text;
            model.Amount = tbxAmount.Value;

            model.TotalInvoice = tbxTotalSales.Value;
            model.Adjustment = tbxAdjustment.Value;
            model.Total = tbxTotal.Value;

            if (lkpTransactional.Value != null)
                model.TransactionalAccountId = (int)lkpTransactional.Value;
            else model.TransactionalAccountId = 0;

            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override PaymentInCollectOutModel Find(string searchTerm)
        {
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<PaymentInCollectOutModel>(param);
            PopulateForm(obj);

            return obj;
        }

        public override void Info()
        {
            var model = CurrentModel as PaymentInCollectOutModel;

            if (model != null)
            {
                info.CreatedPc = model.CreatedPc;
                info.ModifiedPc = model.ModifiedPc;
            }

            base.Info();
        }
    }
}