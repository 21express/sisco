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

namespace SISCO.Presentation.Finance.Forms
{
    public partial class PaymentOutDeliveryForm : BaseCrudForm<PaymentDeliveryModel, PaymentDeliveryDataManager>
    {
        private PaymentDeliveryDetailDataManager _detailDm = new PaymentDeliveryDetailDataManager();
        private bool DeleteOld { get; set; }
        private string Code { get; set; }

        public PaymentOutDeliveryForm()
        {
            InitializeComponent();

            form = this;
            Load += PaymentDeliveryLoad;
            tbxBranch.Leave += GetInvoice;
            DeliveryView.CustomColumnDisplayText += NumberGrid;
            DeliveryView.CellValueChanged += Changed;
            DeliveryView.CellValueChanging += Changing;
            tbxAdjustment.Leave += CalculateTotal;

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "owner_branch_id", EnumSqlOperator.Equals)
            };

            btnTambah.Click += (sender, args) => Add();
        }

        private void Changing(object sender, CellValueChangedEventArgs e)
        {
            var due = Convert.ToInt32(DeliveryView.GetRowCellValue(e.RowHandle, DeliveryView.Columns["InvoiceBalance"]));

            if (e.Column.Name == "clChecked")
            {
                if (!(bool)DeliveryView.GetRowCellValue(e.RowHandle, DeliveryView.Columns["Checked"]))
                {
                    DeliveryView.SetRowCellValue(e.RowHandle, DeliveryView.Columns["Balance"], 0);
                    DeliveryView.SetRowCellValue(e.RowHandle, DeliveryView.Columns["Payment"], due);
                    DeliveryView.SetRowCellValue(e.RowHandle, DeliveryView.Columns["Checked"], true);
                }
                else
                {
                    DeliveryView.SetRowCellValue(e.RowHandle, DeliveryView.Columns["Balance"], due);
                    DeliveryView.SetRowCellValue(e.RowHandle, DeliveryView.Columns["Payment"], 0);
                    DeliveryView.SetRowCellValue(e.RowHandle, DeliveryView.Columns["Checked"], false);
                }
            }
        }

        private void Add()
        {
            if (tbxBarcode.Text == "")
            {
                tbxBarcode.Focus();
                return;
            }

            for (var i = 0; i < DeliveryView.RowCount; i++)
            {
                var code = DeliveryView.GetRowCellValue(i, DeliveryView.Columns["InvoiceCode"]).ToString();
                if (code == tbxBarcode.Text)
                {
                    var balance = DeliveryView.GetRowCellValue(i, DeliveryView.Columns["InvoiceBalance"]);
                    DeliveryView.SetRowCellValue(i, DeliveryView.Columns["Payment"], balance);
                    DeliveryView.SetRowCellValue(i, DeliveryView.Columns["Checked"], true);
                    DeliveryView.SetRowCellValue(i, DeliveryView.Columns["Balance"], 0);
                }
            }

            var total = 0;
            for (var i = 0; i < DeliveryView.RowCount; i++)
            {
                total += Convert.ToInt32(DeliveryView.GetRowCellValue(i, DeliveryView.Columns["Payment"]));
            }

            tbxTotalInvoice.SetValue(total.ToString(CultureInfo.InvariantCulture));
            tbxTotal.SetValue(((Int64)tbxTotalInvoice.Value - (Int64)tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));

            tbxBarcode.Clear();
            tbxBarcode.Focus();
        }

        private void Changed(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "clState" && e.Column.Name != "clBalance")
            {
                var due = Convert.ToInt32(DeliveryView.GetRowCellValue(e.RowHandle, DeliveryView.Columns["InvoiceBalance"]));

                if (e.Column.Name == "clChecked")
                {
                    if ((bool)DeliveryView.GetRowCellValue(e.RowHandle, DeliveryView.Columns["Checked"]))
                    {
                        DeliveryView.SetRowCellValue(e.RowHandle, DeliveryView.Columns["Balance"], 0);
                        DeliveryView.SetRowCellValue(e.RowHandle, DeliveryView.Columns["Payment"], due);
                    }
                    else
                    {
                        DeliveryView.SetRowCellValue(e.RowHandle, DeliveryView.Columns["Balance"], due);
                        DeliveryView.SetRowCellValue(e.RowHandle, DeliveryView.Columns["Payment"], 0);
                    }
                }

                if (e.Column.Name == "clPayment")
                {
                    var payment = Convert.ToInt32(DeliveryView.GetRowCellValue(e.RowHandle, DeliveryView.Columns["Payment"]));
                    DeliveryView.SetRowCellValue(e.RowHandle, DeliveryView.Columns["Balance"], (due - payment));
                }

                var total = 0;
                for (var i = 0; i < DeliveryView.RowCount; i++)
                {
                    total += Convert.ToInt32(DeliveryView.GetRowCellValue(i, DeliveryView.Columns["Payment"]));
                }

                tbxTotalInvoice.SetValue(total.ToString(CultureInfo.InvariantCulture));
                tbxTotal.SetValue(((Int64)tbxTotalInvoice.Value - (Int64)tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));

                if (DeliveryView.GetRowCellValue(e.RowHandle, DeliveryView.Columns["StateChange2"]).ToString() ==
                    EnumStateChange.Select.ToString())
                {
                    DeliveryView.SetRowCellValue(e.RowHandle, DeliveryView.Columns["StateChange2"], EnumStateChange.Update);
                }

                if (DeliveryView.GetRowCellValue(e.RowHandle, DeliveryView.Columns["StateChange2"]).ToString() ==
                    EnumStateChange.Idle.ToString())
                {
                    DeliveryView.SetRowCellValue(e.RowHandle, DeliveryView.Columns["StateChange2"], EnumStateChange.Insert);
                }
            }
        }

        private void CalculateTotal(object sender, EventArgs e)
        {
            tbxTotal.SetValue(((Int64)tbxTotalInvoice.Value - (Int64)tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));
        }

        private void GetInvoice(object sender, EventArgs e)
        {
            base.OnLeave(e);

            GridDelivery.DataSource = null;
            DeliveryView.RefreshData();

            if (tbxBranch.Value != null)
            {
                var invoices = new ShipmentDataManager().Get<ShipmentModel>(new IListParameter[]
                {
                    WhereTerm.Default((int)tbxBranch.Value, "dest_branch_id", EnumSqlOperator.Equals),
                    WhereTerm.Default(0, "delivery_fee", EnumSqlOperator.GreatThan)
                });

                var ds = new List<PaymentDeliveryDetailModel>();

                foreach (ShipmentModel invoice in invoices)
                {
                    var payment = _detailDm.GetPaymentDelivery(invoice.Id);
                    var balance = invoice.DeliveryFeeTotal - payment;

                    if (balance > 0)
                    {
                        ds.Add(new PaymentDeliveryDetailModel
                        {
                            InvoiceId = invoice.Id,
                            InvoiceCode = invoice.Code,
                            InvoiceDate = invoice.DateProcess,
                            InvoiceTotal = invoice.DeliveryFeeTotal,
                            InvoiceBalance = balance,
                            Payment = 0,
                            Balance = balance,
                            Checked = false,
                            StateChange2 = EnumStateChange.Idle.ToString()
                        });
                    }
                }

                GridDelivery.DataSource = ds;
                DeliveryView.RefreshData();
            }
        }

        private void PaymentDeliveryLoad(object sender, EventArgs e)
        {
            ClearForm();

            EnableBtnSearch = true;
            SearchPopup = new PaymentOutDeliveryFilterPopup();

            tbxBranch.LookupPopup = new BranchPopup();
            tbxBranch.AutoCompleteDataManager = new BranchDataManager();
            tbxBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            tbxBranch.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            tbxPayment.LookupPopup = new PaymentTypePopup();
            tbxPayment.AutoCompleteDataManager = new PaymentTypeDataManager();
            tbxPayment.AutoCompleteDisplayFormater = model => ((PaymentTypeModel)model).Name;
            tbxPayment.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            tbxAmount.IsNumber = true;
            tbxTotal.IsNumber = true;
            tbxAdjustment.IsNumber = true;
            tbxTotalInvoice.IsNumber = true;
        }

        public override void New()
        {
            base.New();
            ClearForm();
            ToolbarCode = string.Empty;
            tbxDate.Focus();
            GridDelivery.DataSource = null;
            DeliveryView.RefreshData();

            tbxTotal.ReadOnly = true;
            tbxTotalInvoice.ReadOnly = true;
        }

        public override void Save()
        {
            if (tbxAmount.Value != tbxTotal.Value)
            {
                MessageForm.Info(this, Resources.information, Resources.total_invoice);
                tbxAmount.Focus();
                return;
            }

            DeleteOld = false;

            if (CurrentModel.Id > 0)
            {
                if (((PaymentDeliveryModel) CurrentModel).BranchId != tbxBranch.Value) DeleteOld = true;
                Code = ((PaymentDeliveryModel) CurrentModel).Code;
            }
            else
            {
                if (tbxDate.Text != "") 
                    Code = GetCode("deliveryout", tbxDate.Value);
            }

            base.Save();
        }

        protected override void  SaveDetail(bool isUpdate = false)
        {
            Enabled = false;
            if (DeleteOld)
            {
                new PaymentDeliveryDetailDataManager().DeActiveRows(new IListParameter[]
                {
                    WhereTerm.Default(CurrentModel.Id, "payment_delivery_id", EnumSqlOperator.Equals)
                }, BaseControl.UserLogin);
            }

            // ReSharper disable once InconsistentNaming
            var DetailRepo = new PaymentDeliveryDetailDataManager();
            var shipmentRepo = new ShipmentDataManager();
            for (int i = 0; i < DeliveryView.RowCount; i++)
            {
                var state = DeliveryView.GetRowCellValue(i, DeliveryView.Columns["StateChange2"]);

                var detail = new PaymentDeliveryDetailModel();

                if (state.ToString().Equals(EnumStateChange.Insert.ToString()))
                {
                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.DateProcess = DateTime.Now;
                    detail.PaymentDeliveryId = CurrentModel.Id;
                    detail.InvoiceId =
                            (int)DeliveryView.GetRowCellValue(i, DeliveryView.Columns["InvoiceId"]);
                    detail.InvoiceDate =
                            (DateTime)DeliveryView.GetRowCellValue(i, DeliveryView.Columns["InvoiceDate"]);
                    detail.InvoiceCode =
                            DeliveryView.GetRowCellValue(i, DeliveryView.Columns["InvoiceCode"]).ToString();
                    detail.InvoiceTotal =
                            (decimal)DeliveryView.GetRowCellValue(i, DeliveryView.Columns["InvoiceTotal"]);
                    detail.InvoiceBalance =
                            (decimal)DeliveryView.GetRowCellValue(i, DeliveryView.Columns["InvoiceBalance"]);
                    detail.Payment =
                            (decimal)DeliveryView.GetRowCellValue(i, DeliveryView.Columns["Payment"]);
                    detail.Balance =
                            (decimal)DeliveryView.GetRowCellValue(i, DeliveryView.Columns["Balance"]);
                    detail.Checked =
                            (bool)DeliveryView.GetRowCellValue(i, DeliveryView.Columns["Checked"]);

                    detail.Createdby = BaseControl.UserLogin;
                    detail.Createddate = DateTime.Now;

                    if (detail.Payment > 0) DetailRepo.Save<PaymentDeliveryDetailModel>(detail);
                }

                if (state.ToString().Equals(EnumStateChange.Update.ToString()))
                {
                    detail = DetailRepo.GetFirst<PaymentDeliveryDetailModel>(WhereTerm.Default((int)DeliveryView.GetRowCellValue(i, DeliveryView.Columns["Id"]), "id", EnumSqlOperator.Equals));
                    detail.Payment =
                            (decimal)DeliveryView.GetRowCellValue(i, DeliveryView.Columns["Payment"]);
                    detail.Balance =
                            (decimal)DeliveryView.GetRowCellValue(i, DeliveryView.Columns["Balance"]);
                    detail.Checked =
                            (bool)DeliveryView.GetRowCellValue(i, DeliveryView.Columns["Checked"]);
                    detail.Modifiedby = BaseControl.UserLogin;
                    detail.Modifieddate = DateTime.Now;

                    if (detail.Payment == 0)
                        DetailRepo.DeActive(detail.Id, BaseControl.UserLogin, DateTime.Now);
                    else
                        DetailRepo.Update<PaymentDeliveryDetailModel>(detail);
                }

                var shipment = shipmentRepo.GetFirst<ShipmentModel>(WhereTerm.Default(detail.InvoiceId, "id", EnumSqlOperator.Equals));
                if (shipment != null)
                {
                    shipment.TotalPaymentDelivery = _detailDm.GetPaymentDelivery(shipment.Id);
                    if (shipment.TotalPaymentDelivery == shipment.DeliveryFeeTotal) shipment.PaidDelivery = true;
                    else shipment.PaidDelivery = false;

                    shipmentRepo.Update<ShipmentModel>(shipment);
                }
            }

            Enabled = true;
        }

        protected override void AfterSave()
        {
            ToolbarCode = ((PaymentDeliveryModel)CurrentModel).Code;
            OpenData(ToolbarCode);
        }

        public override void AfterDelete()
        {
            var detail = new PaymentDeliveryDetailDataManager().Get<PaymentDeliveryDetailModel>(WhereTerm.Default(CurrentModel.Id, "payment_delivery_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new PaymentDeliveryDetailDataManager();
                foreach (PaymentDeliveryDetailModel obj in detail)
                {
                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
                }
            }

            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text != "" && tbxBranch.Text != "" && tbxPayment.Text != "") return true;

            if (tbxDate.Text == "")
            {
                tbxDate.Focus();
                return false;
            }

            if (tbxBranch.Value == null)
            {
                tbxBranch.Focus();
                return false;
            }

            if (tbxPayment.Value == null)
            {
                tbxPayment.Focus();
                return false;
            }

            return false;
        }

        protected override void PopulateForm(PaymentDeliveryModel model)
        {
            tbxDate.Text = model.DateProcess.ToString(CultureInfo.InvariantCulture);
            tbxBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(model.BranchId, "id", EnumSqlOperator.Equals) };
            tbxPayment.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PaymentTypeId, "id", EnumSqlOperator.Equals) };

            tbxAmount.SetValue(model.Amount.ToString(CultureInfo.InvariantCulture));
            tbxDescription.Text = model.Description;

            tbxTotalInvoice.SetValue(model.TotalInvoice.ToString(CultureInfo.InvariantCulture));
            tbxAdjustment.SetValue(model.Adjustment.ToString(CultureInfo.InvariantCulture));
            tbxTotal.SetValue(model.Total.ToString(CultureInfo.InvariantCulture));

            ToolbarCode = model.Code;

            var detail = new PaymentDeliveryDetailDataManager().Get<PaymentDeliveryDetailModel>(WhereTerm.Default(model.Id, "payment_delivery_id", EnumSqlOperator.Equals));
            GridDelivery.DataSource = detail;
            DeliveryView.RefreshData();

            tbxTotal.ReadOnly = true;
            tbxTotalInvoice.ReadOnly = true;
        }

        protected override PaymentDeliveryModel PopulateModel(PaymentDeliveryModel model)
        {
            model.Code = Code;
            model.DateProcess = tbxDate.Value;
            if (tbxBranch.Value != null) model.BranchId = (int)tbxBranch.Value;
            model.OwnerBranchId = BaseControl.BranchId;
            if (tbxPayment.Value != null) model.PaymentTypeId = (int) tbxPayment.Value;

            model.Description = tbxDescription.Text;
            model.Amount = tbxAmount.Value;
            model.TotalInvoice = tbxTotalInvoice.Value;
            model.Total = tbxTotal.Value;
            model.Adjustment = tbxAdjustment.Value;

            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override PaymentDeliveryModel Find(string searchTerm)
        {
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<PaymentDeliveryModel>(param);
            PopulateForm(obj);

            return obj;
        }

        public override void Info()
        {
            var model = CurrentModel as PaymentDeliveryModel;
            if (model != null)
            {
                info.CreatedPc = model.CreatedPc;
                info.ModifiedPc = model.ModifiedPc;
            }

            base.Info();
        }
    }
}