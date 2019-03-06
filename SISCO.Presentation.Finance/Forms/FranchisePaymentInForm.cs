using System;
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
using SISCO.Presentation.CustomerService.Forms;
using System.Collections.Generic;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class FranchisePaymentInForm : BaseCrudForm<FranchisePaymentInModel, FranchisePaymentInDataManager>//BaseToolbarForm//
    {
        private string Code { get; set; }

        public FranchisePaymentInForm()
        {
            InitializeComponent();

            form = this;
            PaymentView.CustomColumnDisplayText += NumberGrid;

            Load += FranchisePaymentInLoad;
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
            if (e.Column.Name != "clState" && e.Column.Name == "clPayment")
            {
                if (PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["StateChange2"]).ToString() != EnumStateChange.Insert.ToString())
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["StateChange2"], EnumStateChange.Update);

                var balance = (decimal)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["InvoiceBalance"]);
                var payment = (decimal)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["Payment"]);

                PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Paid"], (bool)(payment > 0));
                PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Checked"], (bool)(payment > 0));
                PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Balance"], (balance - payment));

                var total = 0;
                for (var i = 0; i < PaymentView.RowCount; i++)
                {
                    total += Convert.ToInt32(PaymentView.GetRowCellValue(i, PaymentView.Columns["Payment"]));
                }

                tbxTotalSales.SetValue(total.ToString(CultureInfo.InvariantCulture));
                tbxTotal.SetValue(((Int64)tbxTotalSales.Value - (Int64)tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));
            }
        }

        private void FranchisePaymentInLoad(object sender, EventArgs e)
        {
            ClearForm();
            EnabledForm(false);
            EnableBtnSearch = true;
            SearchPopup = new FranchisePaymentInFilterPopup();
            GridPayment.DoubleClick += (s, args) => OpenRelatedForm(PaymentView, new TrackingViewForm(), "InvoiceCode");

            PaymentView.CellValueChanging += Changing;
            tbxAdjustment.IsNumber = true;
            tbxTotal.IsNumber = true;
            tbxTotalSales.IsNumber = true;
        }

        private void Changing(object sender, CellValueChangedEventArgs e)
        {
            var balance = (decimal)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["InvoiceBalance"]);

            if (e.Column.Name == "clChecked")
            {
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
        }

        private void GetUnpaid()
        {
            var payment = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default("CASH", "name", EnumSqlOperator.Equals));
            var shipmentCash = new ShipmentDataManager().PaymentShipmentJoinCommission(BaseControl.BranchId, payment.Id);

            var counters = (from obj in shipmentCash
                select new FranchisePaymentInDetailModel
                {
                    FranchisePaymentInId = 0, InvoiceId = obj.Id, InvoiceDate = obj.DateProcess, InvoiceCode = obj.Code, InvoiceTotal = obj.Total, InvoiceBalance = obj.Total - obj.TotalPayment, Payment = 0, Balance = obj.Total - obj.TotalPayment, Checked = false, Paid = false, StateChange2 = EnumStateChange.Insert.ToString()
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

            GetUnpaid();
        }

        public override void Save()
        {
            //var obj = (List<PaymentInCounterDetailModel>)GridPayment.DataSource;
            //var obj = ((IOrderedEnumerable<FranchisePaymentInDetailModel>)GridPayment.DataSource).ToList<FranchisePaymentInDetailModel>();
            var obj = GridPayment.DataSource as List<FranchisePaymentInDetailModel>;
            if (obj != null)
                if (obj.FirstOrDefault(b => b.Paid) != null)
                {
                    Code = CurrentModel.Id > 0 ? ((FranchisePaymentInModel)CurrentModel).Code : (tbxDate.Text != "" ? GetCode("franchisepayment", tbxDate.Value) : "");

                    base.Save();
                    return;
                }

            MessageBox.Show(Resources.data_empty, Resources.information, MessageBoxButtons.OK);
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            Enabled = false;
            var dm = new FranchisePaymentInDetailDataManager();
            var sdm = new ShipmentDataManager();
            for (var i = 0; i < PaymentView.RowCount; i++)
            {
                var state = PaymentView.GetRowCellValue(i, PaymentView.Columns["StateChange2"]).ToString();
                var detail = new FranchisePaymentInDetailModel();

                if (state == EnumStateChange.Insert.ToString())
                {
                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.FranchisePaymentInId = CurrentModel.Id;
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
                    detail = dm.GetFirst<FranchisePaymentInDetailModel>(WhereTerm.Default(id, "id", EnumSqlOperator.Equals));

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
                        dm.Update<FranchisePaymentInDetailModel>(detail);

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
            ToolbarCode = ((FranchisePaymentInModel)CurrentModel).Code;
            OpenData(ToolbarCode);
        }

        public override void AfterDelete()
        {
            var detail = new FranchisePaymentInDetailDataManager().Get<FranchisePaymentInDetailModel>(WhereTerm.Default(CurrentModel.Id, "franchise_payment_in_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new FranchisePaymentInDetailDataManager();
                var r = new ShipmentDataManager();
                foreach (FranchisePaymentInDetailModel obj in detail)
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
            return false;
        }

        protected override void PopulateForm(FranchisePaymentInModel model)
        {
            if (model == null) return;
            EnabledForm(true);

            tbxDate.Text = model.DateProcess.ToString(CultureInfo.InvariantCulture);
            ToolbarCode = model.Code;
            tbxTotalSales.SetValue(model.TotalInvoice.ToString(CultureInfo.InvariantCulture));
            tbxAdjustment.SetValue(model.Adjustment.ToString(CultureInfo.InvariantCulture));
            tbxTotal.SetValue(model.Total.ToString(CultureInfo.InvariantCulture));

            var counters = new FranchisePaymentInDetailDataManager().Get<FranchisePaymentInDetailModel>(WhereTerm.Default(model.Id, "franchise_payment_in_id", EnumSqlOperator.Equals)).ToList();
            GridPayment.DataSource = counters;
            PaymentView.RefreshData();

            tbxTotal.ReadOnly = true;
            tbxTotalSales.ReadOnly = true;

            if (model.FundTransfer)
            {
                EnabledForm(false);
            }
        }

        protected override FranchisePaymentInModel PopulateModel(FranchisePaymentInModel model)
        {
            model.DateProcess = tbxDate.Value;
            model.Code = Code;
            model.BranchId = BaseControl.BranchId;
            model.TotalInvoice = tbxTotalSales.Value;
            model.Adjustment = tbxAdjustment.Value;
            model.Total = model.TotalInvoice - model.Adjustment;

            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override FranchisePaymentInModel Find(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm)) tsBaseTxt_Code.Text = searchTerm;
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<FranchisePaymentInModel>(param);
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
                return;
            }
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();
            var model = CurrentModel as FranchisePaymentInModel;
            if (model == null) return;
            if (model.FundTransfer)
            {
                tsBaseBtn_Save.Enabled = false;
                tsBaseBtn_Delete.Enabled = false;
                NavigationMenu.SaveStrip.Enabled = tsBaseBtn_Save.Enabled;
                NavigationMenu.DeleteStrip.Enabled = tsBaseBtn_Delete.Enabled;
            }
        }

        public override void Info()
        {
            var model = CurrentModel as FranchisePaymentInModel;

            if (model != null)
            {
                info.CreatedPc = model.CreatedPc;
                info.ModifiedPc = model.ModifiedPc;
            }

            base.Info();
        }
    }
}
