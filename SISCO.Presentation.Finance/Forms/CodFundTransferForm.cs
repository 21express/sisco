using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraGrid.Views.Base;
using SISCO.App.Finance;
using SISCO.App.Franchise;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.Finance.Popup;
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
    public partial class CodFundTransferForm : BaseCrudForm<CodFundTransferModel, CodFundTransferDataManager>//BaseToolbarForm//
    {
        public CodFundTransferForm()
        {
            InitializeComponent();
            form = this;

            PaymentView.CustomColumnDisplayText += NumberGrid;

            Load += CodFundTransferLoad;
            PaymentView.CellValueChanged += Changed;
            tbxAdjustment.TextChanged += (sender, args) => tbxTotal.SetValue((tbxTotalPayment.Value - tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)
            };

            GridPayment.DoubleClick += (sender, args) => OpenRelatedForm(PaymentView, new FranchisePaymentInForm(), "InvoiceCode");
        }

        private void CodFundTransferLoad(object sender, EventArgs e)
        {
            ClearForm();
            EnabledForm(false);
            EnableBtnSearch = true;
            SearchPopup = new CodFundTransferFilterPopup();

            PaymentView.CellValueChanging += Changing;
            tbxAdjustment.IsNumber = true;
            tbxTotal.IsNumber = true;
            tbxTotalPayment.IsNumber = true;

            lkpBranch.LookupPopup = new BranchPopup();
            lkpBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            lkpBranch.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0))", s);
        }

        private void Changed(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "clState")
            {
                if (PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["StateChange2"]).ToString() != EnumStateChange.Insert.ToString())
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["StateChange2"], EnumStateChange.Update);

                var total = 0;
                for (var i = 0; i < PaymentView.RowCount; i++)
                {
                    if ((bool)PaymentView.GetRowCellValue(i, PaymentView.Columns["Checked"]))
                        total += Convert.ToInt32(PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceTotal"]));
                }

                tbxTotalPayment.SetValue(total.ToString(CultureInfo.InvariantCulture));
                tbxTotal.SetValue(((Int64)tbxTotalPayment.Value - (Int64)tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));
            }
        }

        private void Changing(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "clChecked")
            {
                if (!(bool)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["Checked"]))
                {
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Checked"], true);
                }
                else
                {
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Checked"], false);
                }
            }
        }

        private void GetUnpaid()
        {
            var unpaid= new CodPaymentInDataManager().GetUnpaidCodPayment(BaseControl.BranchId);

            GridPayment.DataSource = unpaid;
            PaymentView.RefreshData();
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();

            ClearForm();
            EnabledForm(true);

            tbxDate.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            tbxDate.Focus();

            lkpBranch.Enabled = false;
            lkpBranch.Properties.Buttons[0].Enabled = false;

            tbxTotal.ReadOnly = true;
            tbxTotalPayment.ReadOnly = true;
            tbxAmount.SetValue((decimal)0);
            tbxTotal.SetValue((decimal)0);
            tbxAdjustment.SetValue((decimal)0);
            tbxTotalPayment.SetValue((decimal)0);

            lkpBranch.DefaultValue = new IListParameter[] { WhereTerm.Default("JKT", "code", EnumSqlOperator.Equals) };

            GetUnpaid();
        }

        public override void Save()
        {
            var obj = GridPayment.DataSource as List<CodFundTransferDetailModel>;
            if (obj != null)
                if (obj.FirstOrDefault(b => b.Checked) != null)
                {
                    if (tbxAmount.Value != tbxTotal.Value)
                    {
                        MessageBox.Show("Total amount dan total pembayaran tidak sama.", "Validasi");
                        tbxAmount.Focus();
                        return;
                    }

                    base.Save();
                    return;
                }

            MessageBox.Show(Resources.data_empty, Resources.information, MessageBoxButtons.OK);
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            Enabled = false;
            var dm = new CodFundTransferDetailDataManager();
            var fpi = new CodPaymentInDataManager();
            for (var i = 0; i < PaymentView.RowCount; i++)
            {
                var state = PaymentView.GetRowCellValue(i, PaymentView.Columns["StateChange2"]).ToString();
                var detail = new CodFundTransferDetailModel();

                if (state == EnumStateChange.Insert.ToString() && (bool)PaymentView.GetRowCellValue(i, PaymentView.Columns["Checked"]))
                {
                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.CodFundTransferId = CurrentModel.Id;
                    detail.DateProcess = DateTime.Now;
                    detail.InvoiceId = (int)PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceId"]);
                    detail.InvoiceDate = (DateTime)PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceDate"]);
                    detail.InvoiceCode = PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceCode"]).ToString();
                    detail.InvoiceTotal = (decimal)PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceTotal"]);

                    detail.Createdby = BaseControl.UserLogin;
                    detail.Createddate = DateTime.Now;

                    var p = fpi.GetFirst<CodPaymentInModel>(WhereTerm.Default(detail.InvoiceId, "id"));
                    if (p != null)
                    {
                        p.FundTransfer = true;
                        p.Modifiedby = BaseControl.UserLogin;
                        p.Modifieddate = DateTime.Now;
                        p.ModifiedPc = Environment.MachineName;

                        fpi.Update<CodPaymentInModel>(p);
                    }

                    dm.Save<CodFundTransferDetailModel>(detail);
                }

                if (state == EnumStateChange.Update.ToString() && !(bool)PaymentView.GetRowCellValue(i, PaymentView.Columns["Checked"]))
                {
                    var id = (int)PaymentView.GetRowCellValue(i, PaymentView.Columns["Id"]);
                    dm.DeActive(id, BaseControl.UserLogin, DateTime.Now);

                    var p = fpi.GetFirst<CodPaymentInModel>(WhereTerm.Default((int)PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceId"]), "id"));
                    if (p != null)
                    {
                        p.FundTransfer = false;
                        p.Modifiedby = BaseControl.UserLogin;
                        p.Modifieddate = DateTime.Now;
                        p.ModifiedPc = Environment.MachineName;

                        fpi.Update<CodPaymentInModel>(p);
                    }
                }
            }

            Enabled = true;
        }

        protected override void AfterSave()
        {
            ToolbarCode = ((CodFundTransferModel)CurrentModel).Code;
            OpenData(ToolbarCode);
        }

        public override void AfterDelete()
        {
            var detail = new CodFundTransferDetailDataManager().Get<CodFundTransferDetailModel>(WhereTerm.Default(CurrentModel.Id, "cod_fund_transfer_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new CodFundTransferDetailDataManager();
                var r = new CodPaymentInDataManager();
                foreach (CodFundTransferDetailModel obj in detail)
                {
                    var d = r.GetFirst<CodPaymentInModel>(WhereTerm.Default((int)obj.InvoiceId, "id", EnumSqlOperator.Equals));
                    d.FundTransfer = false;
                    d.Modifiedby = BaseControl.UserLogin;
                    d.Modifieddate = DateTime.Now;
                    d.ModifiedPc = Environment.MachineName;

                    r.Update<CodPaymentInModel>(d);
                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);

                }
            }

            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            if (string.IsNullOrEmpty(tbxDate.Text))
            {
                tbxDate.Focus();
                return false;
            }

            if (tbxAmount.Value == 0)
            {
                tbxAmount.Focus();
                return false;
            }

            return true;
        }

        protected override void PopulateForm(CodFundTransferModel model)
        {
            ClearForm();
            if (model == null)
            {
                EnabledForm(false);
                return;
            }

            EnabledForm(true);

            ToolbarCode = model.Code;
            tbxDate.DateTime = model.DateProcess;
            tbxAmount.SetValue(model.Amount);
            tbxDescription.Text = model.Description;
            lkpBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(model.DestBranchId, "id", EnumSqlOperator.Equals) };
            lkpBranch.Enabled = false;
            lkpBranch.Properties.Buttons[0].Enabled = false;
            tbxTotalPayment.SetValue(model.TotalPayment);
            tbxAdjustment.SetValue(model.Adjustment);
            tbxTotal.SetValue(model.Total);

            GridPayment.DataSource = new CodFundTransferDetailDataManager().Get<CodFundTransferDetailModel>(WhereTerm.Default(model.Id, "cod_fund_transfer_id"));
            PaymentView.RefreshData();

            if (model.ConfirmAdmin)
            {
                EnabledForm(false);
            }
        }

        protected override CodFundTransferModel PopulateModel(CodFundTransferModel model)
        {
            model.DateProcess = tbxDate.DateTime;
            model.Code = CurrentModel.Id > 0 ? ((CodFundTransferModel)CurrentModel).Code : GetCode("codfundtransfer", tbxDate.DateTime);
            model.BranchId = BaseControl.BranchId;
            model.DestBranchId = (int) lkpBranch.Value;
            model.Amount = tbxAmount.Value;
            model.Description = tbxDescription.Text;
            model.TotalPayment = tbxTotalPayment.Value;
            model.Adjustment = tbxAdjustment.Value;
            model.Total = tbxTotal.Value;

            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override CodFundTransferModel Find(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm)) tsBaseTxt_Code.Text = searchTerm;
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<CodFundTransferModel>(param);
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
            var model = CurrentModel as CodFundTransferModel;
            if (model == null) return;
            if (model.ConfirmAdmin)
            {
                tsBaseBtn_Save.Enabled = false;
                tsBaseBtn_Delete.Enabled = false;
                NavigationMenu.SaveStrip.Enabled = tsBaseBtn_Save.Enabled;
                NavigationMenu.DeleteStrip.Enabled = tsBaseBtn_Delete.Enabled;
            }
        }
    }
}