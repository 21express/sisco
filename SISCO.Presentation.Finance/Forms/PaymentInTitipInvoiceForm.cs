using System;
using System.Collections.Generic;
using System.Globalization;
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
using SISCO.App.Billing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class PaymentInTitipInvoiceForm : BaseCrudForm<OtherInvoicePaymentInModel, OtherInvoicePaymentInDataManager>//BaseToolbarForm//
    {
        private OtherInvoicePaymentInDetailDataManager _detailDm = new OtherInvoicePaymentInDetailDataManager();
        private string Code { get; set; }
        private decimal MaxAmount { get; set; }
        private TransactionalAccountPopup transactionPopup;

        public PaymentInTitipInvoiceForm()
        {
            InitializeComponent();

            form = this;
            Load += InvoiceInLoad;
            
            InvoiceInView.CustomColumnDisplayText += NumberGrid;
            InvoiceInView.CellValueChanged += Changed;
            InvoiceInView.CellValueChanging += Changing;
            tbxAdjustment.Leave += CalculateTotal;

            btnAdd.Click += Pay;

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)
            };
        }

        private void Pay(object sender, EventArgs e)
        {
            if (tbxCode.Text == "")
            {
                tbxCode.Focus();
                return;
            }

            var total = 0;
            for (var i = 0; i < InvoiceInView.RowCount; i++)
            {
                if (InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["InvoiceRefNumber"]).ToString() == tbxCode.Text)
                {
                    var balance =
                        (decimal)InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["InvoiceBalance"]);

                    InvoiceInView.SetRowCellValue(i, InvoiceInView.Columns["Payment"], balance);
                    InvoiceInView.SetRowCellValue(i, InvoiceInView.Columns["Balance"], 0);
                    InvoiceInView.SetRowCellValue(i, InvoiceInView.Columns["Paid"], true);
                    InvoiceInView.SetRowCellValue(i, InvoiceInView.Columns["Checked"], true);
                }

                total += Convert.ToInt32(InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["Payment"]));
            }

            tbxCode.Clear();
            tbxCode.Focus();

            tbxTotalInvoice.SetValue(total.ToString(CultureInfo.InvariantCulture));
            tbxTotal.SetValue(((Int64)tbxTotalInvoice.Value - (decimal)tbxTotalPph.Value - (Int64)tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));
        }

        private void Changing(object sender, CellValueChangedEventArgs e)
        {
            var due = Convert.ToInt32(InvoiceInView.GetRowCellValue(e.RowHandle, InvoiceInView.Columns["InvoiceBalance"]));

            if (e.Column.Name == "clChecked")
            {
                if (!(bool)InvoiceInView.GetRowCellValue(e.RowHandle, InvoiceInView.Columns["Checked"]))
                {
                    InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["Balance"], 0);
                    InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["Payment"], due);
                    InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["Checked"], true);
                }
                else
                {
                    if ((bool)InvoiceInView.GetRowCellValue(e.RowHandle, InvoiceInView.Columns["UsePph23"]))
                    {
                        MessageForm.Info(this, "Information", "Tidak bisa mengubah pembayaran jika invoice sudah menggunakan Pph23.");
                        InvoiceInView.CancelUpdateCurrentRow();
                        return;
                    }

                    InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["Balance"], due);
                    InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["Payment"], 0);
                    InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["Checked"], false);
                }
            }

            if (e.Column.Name == "clPayment")
            {
                if ((bool)InvoiceInView.GetRowCellValue(e.RowHandle, InvoiceInView.Columns["UsePph23"]))
                {
                    InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["Payment"], InvoiceInView.GetRowCellValue(e.RowHandle, InvoiceInView.Columns["Payment"]));
                    MessageForm.Info(this, "Information", "Tidak bisa mengubah pembayaran jika invoice sudah menggunakan Pph23.");
                    InvoiceInView.CancelUpdateCurrentRow();
                    return;
                }
            }

            if (e.Column.Name == "clUsePph23")
            {
                if (!(bool)InvoiceInView.GetRowCellValue(e.RowHandle, InvoiceInView.Columns["IsReturn"]) && (decimal)InvoiceInView.GetRowCellValue(e.RowHandle, InvoiceInView.Columns["Balance"]) == 0)
                {
                    if ((bool)InvoiceInView.GetRowCellValue(e.RowHandle, InvoiceInView.Columns["UsePph23"]))
                    {
                        InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["TotalPph23"], 0);
                        InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["UsePph23"], false);
                    }
                    else
                    {
                        var refNumber = InvoiceInView.GetRowCellValue(e.RowHandle, InvoiceInView.Columns["InvoiceRefNumber"]).ToString();
                        var invoice = new SalesInvoiceDataManager().GetFirst<SalesInvoiceModel>(WhereTerm.Default(refNumber, "ref_number", EnumSqlOperator.Equals));
                        decimal beforeTax = 0;
                        decimal totalPph = 0;
                        if (invoice != null)
                        {
                            var shipment = new SalesInvoiceListDataManager().Get<SalesInvoiceListModel>(WhereTerm.Default(invoice.Id, "sales_invoice_id", EnumSqlOperator.Equals));
                            if (shipment.Count() > 0)
                            {
                                var cost = new SalesInvoiceCostDataManager().Get<SalesInvoiceCostModel>(WhereTerm.Default(invoice.Id, "sales_invoice_id", EnumSqlOperator.Equals));
                                if (cost.Count() > 0) beforeTax += (from a in cost select a.Total).Sum();
                                beforeTax = (from a in shipment select (!string.IsNullOrEmpty(a.Currency) ? a.TotalTariff * a.CurrencyRate : a.TotalTariff)).Sum();
                                beforeTax -= (from a in shipment select a.Discount).Sum();
                                beforeTax += (from a in shipment select a.PackingFee).Sum();
                                beforeTax += (from a in shipment select a.OtherFee).Sum();
                                beforeTax += (from a in shipment select a.InsuranceFee).Sum();
                            }

                            if (invoice.TaxTotal > 0)
                            {
                                totalPph = beforeTax * (decimal)(0.02);
                            }
                            else
                            {
                                totalPph = (beforeTax / 101) * (decimal)(2);
                            }

                            InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["TotalPph23"], totalPph);
                            InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["UsePph23"], true);
                        }
                        else InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["TotalPph23"], 0);
                    }
                }
                else
                {
                    MessageForm.Info(this, "Information", "Sudah ada pengembalian Pph23 atau invoice belum lunas.");
                    InvoiceInView.CancelUpdateCurrentRow();
                    return;
                }
            }

            if (e.Column.Name == "clMaterai")
            {
                if (!(bool)InvoiceInView.GetRowCellValue(e.RowHandle, InvoiceInView.Columns["UseMaterai"]))
                {
                    if ((decimal)InvoiceInView.GetRowCellValue(e.RowHandle, InvoiceInView.Columns["InvoiceTotal"]) > 1000000)
                        InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["MateraiFee"], 6000);
                    else if ((decimal)InvoiceInView.GetRowCellValue(e.RowHandle, InvoiceInView.Columns["InvoiceTotal"]) > 250000)
                        InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["MateraiFee"], 3000);
                    else InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["MateraiFee"], 0);

                    InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["UseMaterai"], true);
                }
                else
                {
                    InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["MateraiFee"], 0);
                    InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["UseMaterai"], false);
                }
            }
        }

        private void CalculateTotal(object sender, EventArgs e)
        {
            tbxTotal.SetValue(((Int64)tbxTotalInvoice.Value - (decimal)tbxTotalPph.Value - (decimal)tbxMaterai.Value - (Int64)tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));
        }

        private void Changed(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "clState" && e.Column.Name != "clBalance")
            {
                var due = Convert.ToInt32(InvoiceInView.GetRowCellValue(e.RowHandle, InvoiceInView.Columns["InvoiceBalance"]));

                if (e.Column.Name == "clChecked")
                {
                    if ((bool)InvoiceInView.GetRowCellValue(e.RowHandle, InvoiceInView.Columns["Checked"]))
                    {
                        InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["Balance"], 0);
                        InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["Payment"], due);
                    }
                    else
                    {
                        InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["Balance"], due);
                        InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["Payment"], 0);
                    }
                }

                var payment = Convert.ToInt32(InvoiceInView.GetRowCellValue(e.RowHandle, InvoiceInView.Columns["Payment"]));

                if (e.Column.Name == "clPayment")
                {
                    InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["Balance"], (due - payment));
                }

                var total = 0;
                for (var i = 0; i < InvoiceInView.RowCount; i++)
                {
                    total += Convert.ToInt32(InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["Payment"]));
                }

                decimal pph = 0;
                decimal materai = 0;
                var detail = GridInvoinceIn.DataSource as List<OtherInvoicePaymentInDetailModel>;
                detail.ForEach(d =>
                {
                    if (d.UsePph23) pph += (decimal)d.TotalPph23;
                    if (d.UseMaterai) materai += (decimal)d.MateraiFee;
                });

                tbxTotalInvoice.SetValue(total.ToString(CultureInfo.InvariantCulture));
                tbxTotalPph.SetValue(pph);
                tbxMaterai.SetValue(materai);
                tbxTotal.SetValue(((Int64)tbxTotalInvoice.Value - (decimal)tbxTotalPph.Value - (decimal)tbxMaterai.Value - (Int64)tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));

                if (InvoiceInView.GetRowCellValue(e.RowHandle, InvoiceInView.Columns["StateChange2"]).ToString() ==
                    EnumStateChange.Select.ToString())
                {
                    InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["StateChange2"], EnumStateChange.Update);
                }

                if (InvoiceInView.GetRowCellValue(e.RowHandle, InvoiceInView.Columns["StateChange2"]).ToString() ==
                    EnumStateChange.Idle.ToString())
                {
                    InvoiceInView.SetRowCellValue(e.RowHandle, InvoiceInView.Columns["StateChange2"], EnumStateChange.Insert);
                }
            }
        }

        private void GetInvoice()
        {
            GridInvoinceIn.DataSource = null;
            InvoiceInView.RefreshData();

            var invoices =
                new OtherInvoiceDataManager().Get<OtherInvoiceModel>(WhereTerm.Default(BaseControl.BranchId,
                    "branch_id", EnumSqlOperator.Equals));
            var ds = _detailDm.GetPaymentInvoice(BaseControl.BranchId);

            GridInvoinceIn.DataSource = ds;
            InvoiceInView.RefreshData();
        }

        private void InvoiceInLoad(object sender, EventArgs e)
        {
            ClearForm();

            MaxAmount = 0;

            EnableBtnSearch = true;
            SearchPopup = new PaymentInTitipInvoiceFilterPopup();

            transactionPopup = new TransactionalAccountPopup(lkpAccount, true);

            tbxPayment.LookupPopup = new PaymentTypePopup();
            tbxPayment.AutoCompleteDataManager = new PaymentTypeDataManager();
            tbxPayment.AutoCompleteDisplayFormater = model => ((PaymentTypeModel)model).Name;
            tbxPayment.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

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

            tbxAmount.IsNumber = true;
            tbxAdjustment.IsNumber = true;
            tbxTotal.IsNumber = true;
            tbxTotalInvoice.IsNumber = true;

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
                //MaxAmount = new TransactionalAccountDataManager().GetTransactionBalanceAgaintsPayment((int)lkpTransactional.Value, null, null, null, CurrentModel.Id > 0 ? (int?)CurrentModel.Id : null);
            }
        }

        public override void New()
        {
            base.New();

            ClearForm();
            ToolbarCode = string.Empty;
            tbxDate.Focus();
            GridInvoinceIn.DataSource = null;
            InvoiceInView.RefreshData();

            GetInvoice();

            tbxTotal.ReadOnly = true;
            tbxTotalInvoice.ReadOnly = true;
            tbxTotalPph.ReadOnly = true;
            tbxMaterai.ReadOnly = true;

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
            if (tbxAmount.Value != Math.Truncate(tbxTotal.Value))
            {
                MessageForm.Info(this, Resources.information, Resources.total_invoice);
                tbxAmount.Focus();
                return;
            }

            base.Save();
        }

        protected override void  SaveDetail(bool isUpdate = false)
        {
            Enabled = false;

            // ReSharper disable once InconsistentNaming
            var DetailRepo = new OtherInvoicePaymentInDetailDataManager();
            for (int i = 0; i < InvoiceInView.RowCount; i++)
            {
                var state = InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["StateChange2"]);

                var detail = new OtherInvoicePaymentInDetailModel();

                if (state.ToString().Equals(EnumStateChange.Insert.ToString()))
                {
                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.DateProcess = DateTime.Now;
                    detail.OtherInvoicePaymentInId = CurrentModel.Id;
                    detail.InvoiceId =
                            (int)InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["InvoiceId"]);
                    detail.InvoiceDate =
                            (DateTime)InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["InvoiceDate"]);
                    detail.InvoiceCode =
                            InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["InvoiceCode"]).ToString();
                    detail.InvoiceTotal =
                            (decimal)InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["InvoiceTotal"]);
                    detail.InvoiceBalance =
                            (decimal)InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["InvoiceBalance"]);
                    detail.Payment =
                            (decimal)InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["Payment"]);
                    detail.Balance =
                            (decimal)InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["Balance"]);
                    detail.Checked =
                            (bool)InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["Checked"]);
                    detail.Paid = detail.Balance == 0;
                    detail.UsePph23 = (bool)InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["UsePph23"]);
                    detail.TotalPph23 = (decimal)InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["TotalPph23"]);
                    detail.UseMaterai = (bool)InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["UseMaterai"]);

                    if (InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["MateraiFee"]) != null)
                        detail.MateraiFee = (decimal)InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["MateraiFee"]);
                    else detail.MateraiFee = null;

                    if (InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["InvoiceRefNumber"]) != null)
                        detail.InvoiceRefNumber =
                            InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["InvoiceRefNumber"]).ToString();

                    detail.Createdby = BaseControl.UserLogin;
                    detail.Createddate = DateTime.Now;

                    if (detail.Payment > 0) DetailRepo.Save<OtherInvoicePaymentInDetailModel>(detail);
                }

                if (state.ToString().Equals(EnumStateChange.Update.ToString()))
                {
                    detail = DetailRepo.GetFirst<OtherInvoicePaymentInDetailModel>(WhereTerm.Default((int)InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["Id"]), "id", EnumSqlOperator.Equals));
                    detail.Payment =
                            (decimal)InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["Payment"]);
                    detail.Balance =
                            (decimal)InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["Balance"]);
                    detail.Checked =
                            (bool)InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["Checked"]);
                    detail.Paid = detail.Balance == 0;
                    detail.UsePph23 = (bool)InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["UsePph23"]);
                    detail.TotalPph23 = (decimal)InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["TotalPph23"]);
                    detail.UseMaterai = (bool)InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["UseMaterai"]);

                    if (InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["MateraiFee"]) != null)
                        detail.MateraiFee = (decimal)InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["MateraiFee"]);
                    else detail.MateraiFee = null;

                    detail.Modifiedby = BaseControl.UserLogin;
                    detail.Modifieddate = DateTime.Now;

                    if (detail.Payment == 0)
                    {
                        DetailRepo.DeActive(detail.Id, BaseControl.UserLogin, DateTime.Now);
                    }
                    else
                        DetailRepo.Update<OtherInvoicePaymentInDetailModel>(detail);
                }

                if (state.ToString().Equals(EnumStateChange.Insert.ToString()) || state.ToString().Equals(EnumStateChange.Update.ToString()))
                {
                    var invoiceId = (int)InvoiceInView.GetRowCellValue(i, InvoiceInView.Columns["InvoiceId"]);
                    var otherInvoice =
                        new OtherInvoiceDataManager().GetFirst<OtherInvoiceModel>(WhereTerm.Default(invoiceId, "id",
                            EnumSqlOperator.Equals));

                    if (otherInvoice != null)
                    {
                        var payment = _detailDm.GetTotalPayment(otherInvoice.Id);
                        otherInvoice.InTotalPayment = payment;
                        if (payment == otherInvoice.Total) otherInvoice.InPaid = true;
                        otherInvoice.Modifiedby = BaseControl.UserLogin;
                        otherInvoice.Modifieddate = DateTime.Now;

                        new OtherInvoiceDataManager().Update<OtherInvoiceModel>(otherInvoice);
                    }
                }
            }

            Enabled = true;
        }

        protected override void AfterSave()
        {
            ToolbarCode = ((OtherInvoicePaymentInModel)CurrentModel).Code;
            OpenData(ToolbarCode);
        }

        public override void AfterDelete()
        {
            var detail = new OtherInvoicePaymentInDetailDataManager().Get<OtherInvoicePaymentInDetailModel>(WhereTerm.Default(CurrentModel.Id, "other_invoice_payment_in_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new OtherInvoicePaymentInDetailDataManager();
                foreach (OtherInvoicePaymentInDetailModel obj in detail)
                {
                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
                }
            }

            ClearForm();
            GridInvoinceIn.DataSource = null;
            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text != "" && tbxPayment.Text != "")
            {
                if (CurrentModel.Id > 0) Code = ((OtherInvoicePaymentInModel) CurrentModel).Code;
                else
                {
                    if (tbxDate.Text != "") 
                        Code = GetCode("invoicein", tbxDate.Value);
                }
                return true;
            }

            if (tbxDate.Text == "")
            {
                tbxDate.Focus();
                return false;
            }

            if (tbxPayment.Text == "")
            {
                tbxPayment.Focus();
                return false;
            }

            //if (lkpAccount.Value == null)
            //{
            //    lkpAccount.Focus();
            //    return false;
            //}

            //if (lkpTransactional.Value == null)
            //{
            //    lkpTransactional.Focus();
            //    return false;
            //}

            return false;
        }

        protected override void PopulateForm(OtherInvoicePaymentInModel model)
        {
            ClearForm();
            if (model == null) return;

            MaxAmount = 0;

            tbxDate.Text = model.DateProcess.ToString(CultureInfo.InvariantCulture);
            if (model.PaymentTypeId != null)
                tbxPayment.DefaultValue = new IListParameter[] { WhereTerm.Default((int)model.PaymentTypeId, "id", EnumSqlOperator.Equals) };

            if (model.TransactionalAccountId > 0)
            {
                var transactionanl = new TransactionalAccountDataManager().GetFirst<TransactionalAccountModel>(WhereTerm.Default(model.TransactionalAccountId, "id"));
                lkpAccount.DefaultValue = new IListParameter[] { WhereTerm.Default(transactionanl.BankAccountId, "id") };
                lkpTransactional.DefaultValue = new IListParameter[] { WhereTerm.Default(transactionanl.Id, "id") };

                MaxAmount = new TransactionalAccountDataManager().GetTransactionBalanceAgaintsPayment(transactionanl.Id, null, null, null, model.Id);
            }
            
            tbxAmount.SetValue(model.Amount.ToString(CultureInfo.InvariantCulture));
            tbxDescription.Text = model.Description;

            tbxTotalInvoice.SetValue(model.TotalInvoice.ToString(CultureInfo.InvariantCulture));
            tbxAdjustment.SetValue(model.Adjustment.ToString(CultureInfo.InvariantCulture));
            tbxTotal.SetValue(model.Total.ToString(CultureInfo.InvariantCulture));

            ToolbarCode = model.Code;

            var detail = new OtherInvoicePaymentInDetailDataManager().Get<OtherInvoicePaymentInDetailModel>(WhereTerm.Default(model.Id, "other_invoice_payment_in_id", EnumSqlOperator.Equals));
            GridInvoinceIn.DataSource = detail;
            InvoiceInView.RefreshData();

            decimal pph = 0;
            detail.ToList().ForEach(d =>
            {
                d.StateChange2 = EnumStateChange.Select.ToString();
                if (d.UsePph23) pph += (decimal)d.TotalPph23;
            });

            tbxTotalPph.SetValue(pph);
            tbxMaterai.SetValue((decimal)detail.Sum(p => p.MateraiFee));

            tbxTotal.ReadOnly = true;
            tbxTotalInvoice.ReadOnly = true;
            tbxTotalPph.ReadOnly = true;
            tbxMaterai.ReadOnly = true;
        }

        protected override OtherInvoicePaymentInModel PopulateModel(OtherInvoicePaymentInModel model)
        {
            model.Code = Code;
            model.DateProcess = tbxDate.Value;
            model.BranchId = BaseControl.BranchId;
            model.PaymentTypeId = tbxPayment.Value;
            model.Description = tbxDescription.Text;
            model.Amount = tbxAmount.Value;
            model.TotalInvoice = tbxTotalInvoice.Value;
            model.Total = tbxTotal.Value;
            model.Adjustment = tbxAdjustment.Value;

            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            if (lkpTransactional.Value != null)
                model.TransactionalAccountId = (int)lkpTransactional.Value;
            else model.TransactionalAccountId = 0;

            return model;
        }

        protected override OtherInvoicePaymentInModel Find(string searchTerm)
        {
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<OtherInvoicePaymentInModel>(param);
            PopulateForm(obj);

            return obj;
        }

        public override void Info()
        {
            var model = CurrentModel as OtherInvoicePaymentInModel;
            if (model != null)
            {
                info.CreatedPc = model.CreatedPc;
                info.ModifiedPc = model.ModifiedPc;
            }

            base.Info();
        }
    }
}
