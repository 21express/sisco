using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraGrid.Columns;
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
    public partial class FranchiseFundTransferVerificationForm : BaseCrudForm<FranchiseFundTransferVerificationModel, FranchiseFundTransferVerificationDataManager>//BaseToolbarForm//
    {
        public FranchiseFundTransferVerificationForm()
        {
            InitializeComponent();
            form = this;

            VerifyView.CustomColumnDisplayText += NumberGrid;

            Load += FranchiseFundTransferVerificationLoad;
            VerifyView.CellValueChanged += Changed;

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)
            };

            GridVerify.DoubleClick += (sender, args) => OpenRelatedForm(VerifyView, new FranchiseFundTransferForm(), "InvoiceCode");
        }

        private void FranchiseFundTransferVerificationLoad(object sender, EventArgs e)
        {
            ClearForm();
            EnabledForm(false);
            EnableBtnSearch = true;
            SearchPopup = new FranchiseFundTransferVerificationFilterPopup();

            VerifyView.CellValueChanging += Changing;

            var branchType = new BranchTypeDataManager().GetFirst<BranchTypeModel>(WhereTerm.Default("BRANCH", "name", EnumSqlOperator.Equals));
            lkpBranch.LookupPopup = new BranchPopup(WhereTerm.Default(branchType.Id, "branch_type_id", EnumSqlOperator.Equals));
            lkpBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpBranch.AutoCompleteDisplayFormater = model => string.Format("{0} - {1}", ((BranchModel)model).Code, ((BranchModel)model).Name);
            lkpBranch.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_type_id = @1", s, branchType.Id);

            btnFilter.Click += (s, args) =>
            {
                if (lkpBranch.Value != null)
                    VerifyView.Columns["DestBranchId"].FilterInfo = new ColumnFilterInfo("[DestBranchId] = " + lkpBranch.Value);

                if (tbxTotalPayment.Value > 0)
                    VerifyView.Columns["InvoiceTotal"].FilterInfo = new ColumnFilterInfo("[InvoiceTotal] = " + tbxTotalPayment.Value);
            };
        }

        private void Changed(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "clState")
            {
                if (VerifyView.GetRowCellValue(e.RowHandle, VerifyView.Columns["StateChange"]).ToString() != EnumStateChange.Insert.ToString())
                    VerifyView.SetRowCellValue(e.RowHandle, VerifyView.Columns["StateChange"], EnumStateChange.Update);
            }
        }

        private void Changing(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "gridColumn5")
            {
                if (!(bool)VerifyView.GetRowCellValue(e.RowHandle, VerifyView.Columns["Verified"]))
                {
                    VerifyView.SetRowCellValue(e.RowHandle, VerifyView.Columns["Verified"], true);
                }
                else
                {
                    VerifyView.SetRowCellValue(e.RowHandle, VerifyView.Columns["Verified"], false);
                }
            }
        }

        private void GetUnpaid()
        {
            var unpaid = new FranchiseFundTransferDataManager().GetUnverified(BaseControl.BranchId);

            GridVerify.DataSource = unpaid;
            VerifyView.RefreshData();
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();

            ClearForm();
            EnabledForm(true);

            tbxDate.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            tbxDate.Focus();

            GetUnpaid();
        }

        public override void Save()
        {
            var obj = GridVerify.DataSource as List<FranchiseFundTransferVerificationDetailModel>;
            if (obj != null)
                if (obj.FirstOrDefault(b => b.Verified) != null)
                {
                    base.Save();
                    return;
                }

            MessageBox.Show(Resources.data_empty, Resources.information, MessageBoxButtons.OK);
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            Enabled = false;
            var dm = new FranchiseFundTransferVerificationDetailDataManager();
            var fpi = new FranchiseFundTransferDataManager();
            for (var i = 0; i < VerifyView.RowCount; i++)
            {
                var state = VerifyView.GetRowCellValue(i, VerifyView.Columns["StateChange"]).ToString();
                var detail = new FranchiseFundTransferVerificationDetailModel();

                if (state == EnumStateChange.Insert.ToString() && (bool)VerifyView.GetRowCellValue(i, VerifyView.Columns["Verified"]))
                {
                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.FranchiseFundTransferVerificationId = CurrentModel.Id;
                    detail.DateProcess = DateTime.Now;
                    detail.InvoiceId = (int)VerifyView.GetRowCellValue(i, VerifyView.Columns["InvoiceId"]);
                    detail.InvoiceDate = (DateTime)VerifyView.GetRowCellValue(i, VerifyView.Columns["InvoiceDate"]);
                    detail.InvoiceCode = VerifyView.GetRowCellValue(i, VerifyView.Columns["InvoiceCode"]).ToString();
                    detail.InvoiceTotal = (decimal)VerifyView.GetRowCellValue(i, VerifyView.Columns["InvoiceTotal"]);

                    detail.Createdby = BaseControl.UserLogin;
                    detail.Createddate = DateTime.Now;

                    var p = fpi.GetFirst<FranchiseFundTransferModel>(WhereTerm.Default(detail.InvoiceId, "id"));
                    if (p != null)
                    {
                        p.ConfirmAdmin = true;
                        p.Modifiedby = BaseControl.UserLogin;
                        p.Modifieddate = DateTime.Now;
                        p.ModifiedPc = Environment.MachineName;

                        fpi.Update<FranchiseFundTransferModel>(p);
                    }

                    dm.Save<FranchiseFundTransferVerificationDetailModel>(detail);
                }

                if (state == EnumStateChange.Update.ToString() && !(bool)VerifyView.GetRowCellValue(i, VerifyView.Columns["Verified"]))
                {
                    var id = (int)VerifyView.GetRowCellValue(i, VerifyView.Columns["Id"]);
                    dm.DeActive(id, BaseControl.UserLogin, DateTime.Now);

                    var p = fpi.GetFirst<FranchiseFundTransferModel>(WhereTerm.Default((int)VerifyView.GetRowCellValue(i, VerifyView.Columns["InvoiceId"]), "id"));
                    if (p != null)
                    {
                        p.ConfirmAdmin = false;
                        p.Modifiedby = BaseControl.UserLogin;
                        p.Modifieddate = DateTime.Now;
                        p.ModifiedPc = Environment.MachineName;

                        fpi.Update<FranchiseFundTransferDetailModel>(p);
                    }
                }
            }

            Enabled = true;
        }

        protected override void AfterSave()
        {
            ToolbarCode = ((FranchiseFundTransferVerificationModel)CurrentModel).Code;
            OpenData(ToolbarCode);
        }

        public override void AfterDelete()
        {
            var detail = new FranchiseFundTransferVerificationDetailDataManager().Get<FranchiseFundTransferVerificationDetailModel>(WhereTerm.Default(CurrentModel.Id, "franchise_fund_transfer_verification_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new FranchiseFundTransferVerificationDetailDataManager();
                var r = new FranchiseFundTransferDataManager();
                foreach (FranchiseFundTransferVerificationDetailModel obj in detail)
                {
                    var d = r.GetFirst<FranchiseFundTransferModel>(WhereTerm.Default((int)obj.InvoiceId, "id", EnumSqlOperator.Equals));
                    d.ConfirmAdmin = false;
                    d.Modifiedby = BaseControl.UserLogin;
                    d.Modifieddate = DateTime.Now;
                    d.ModifiedPc = Environment.MachineName;

                    r.Update<ShipmentModel>(d);
                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);

                }
            }

            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override void PopulateForm(FranchiseFundTransferVerificationModel model)
        {
            ClearForm();
            if (model == null)
            {
                EnabledForm(false);
                return;
            }

            EnabledForm(true);
            tbxDate.DateTime = model.DateProcess;
            ToolbarCode = model.Code;

            GridVerify.DataSource = new FranchiseFundTransferVerificationDetailDataManager().Get<FranchiseFundTransferVerificationDetailModel>(WhereTerm.Default(model.Id, "franchise_fund_transfer_verification_id"));
            VerifyView.RefreshData();
        }

        protected override FranchiseFundTransferVerificationModel PopulateModel(FranchiseFundTransferVerificationModel model)
        {
            model.DateProcess = tbxDate.DateTime;
            model.BranchId = BaseControl.BranchId;
            model.Code = CurrentModel.Id > 0 ? model.Code : GetCode("fundtransferverification", tbxDate.DateTime);
            if (CurrentModel.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override FranchiseFundTransferVerificationModel Find(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm)) tsBaseTxt_Code.Text = searchTerm;
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<FranchiseFundTransferVerificationModel>(param);
            PopulateForm(obj);

            return obj;
        }
    }
}