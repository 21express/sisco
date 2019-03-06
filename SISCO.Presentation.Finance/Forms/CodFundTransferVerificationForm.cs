using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using SISCO.App.Finance;
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
    public partial class CodFundTransferVerificationForm : BaseCrudForm<CodFundTransferVerificationModel, CodFundTransferVerificationDataManager>//BaseToolbarForm//
    {
        public CodFundTransferVerificationForm()
        {
            InitializeComponent();
            form = this;

            VerifyView.CustomColumnDisplayText += NumberGrid;

            Load += CodFundTransferVerificationLoad;
            VerifyView.CellValueChanged += Changed;

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)
            };

            GridVerify.DoubleClick += (sender, args) => OpenRelatedForm(VerifyView, new FranchiseFundTransferForm(), "InvoiceCode");
        }

        private void CodFundTransferVerificationLoad(object sender, EventArgs e)
        {
            ClearForm();
            EnabledForm(false);
            EnableBtnSearch = true;
            SearchPopup = new CodFundTransferVerificationFilterPopup();

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
                if (VerifyView.GetRowCellValue(e.RowHandle, VerifyView.Columns["StateChange2"]).ToString() != EnumStateChange.Insert.ToString())
                    VerifyView.SetRowCellValue(e.RowHandle, VerifyView.Columns["StateChange2"], EnumStateChange.Update);
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
            var unpaid = new CodFundTransferDataManager().GetUnverified(BaseControl.BranchId);

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
            var dm = new CodFundTransferVerificationDetailDataManager();
            var fpi = new CodFundTransferDataManager();
            for (var i = 0; i < VerifyView.RowCount; i++)
            {
                var state = VerifyView.GetRowCellValue(i, VerifyView.Columns["StateChange2"]).ToString();
                var detail = new CodFundTransferVerificationDetailModel();

                if (state == EnumStateChange.Insert.ToString() && (bool)VerifyView.GetRowCellValue(i, VerifyView.Columns["Verified"]))
                {
                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.CodFundTransferVerificationId = CurrentModel.Id;
                    detail.DateProcess = DateTime.Now;
                    detail.InvoiceId = (int)VerifyView.GetRowCellValue(i, VerifyView.Columns["InvoiceId"]);
                    detail.InvoiceDate = (DateTime)VerifyView.GetRowCellValue(i, VerifyView.Columns["InvoiceDate"]);
                    detail.InvoiceCode = VerifyView.GetRowCellValue(i, VerifyView.Columns["InvoiceCode"]).ToString();
                    detail.InvoiceTotal = (decimal)VerifyView.GetRowCellValue(i, VerifyView.Columns["InvoiceTotal"]);

                    detail.Createdby = BaseControl.UserLogin;
                    detail.Createddate = DateTime.Now;

                    var p = fpi.GetFirst<CodFundTransferModel>(WhereTerm.Default(detail.InvoiceId, "id"));
                    if (p != null)
                    {
                        p.ConfirmAdmin = true;
                        p.Modifiedby = BaseControl.UserLogin;
                        p.Modifieddate = DateTime.Now;
                        p.ModifiedPc = Environment.MachineName;

                        fpi.Update<CodFundTransferModel>(p);
                    }

                    dm.Save<CodFundTransferVerificationDetailModel>(detail);
                }

                if (state == EnumStateChange.Update.ToString() && !(bool)VerifyView.GetRowCellValue(i, VerifyView.Columns["Verified"]))
                {
                    var id = (int)VerifyView.GetRowCellValue(i, VerifyView.Columns["Id"]);
                    dm.DeActive(id, BaseControl.UserLogin, DateTime.Now);

                    var p = fpi.GetFirst<CodFundTransferModel>(WhereTerm.Default((int)VerifyView.GetRowCellValue(i, VerifyView.Columns["InvoiceId"]), "id"));
                    if (p != null)
                    {
                        p.ConfirmAdmin = false;
                        p.Modifiedby = BaseControl.UserLogin;
                        p.Modifieddate = DateTime.Now;
                        p.ModifiedPc = Environment.MachineName;

                        fpi.Update<CodFundTransferDetailModel>(p);
                    }
                }
            }

            Enabled = true;
        }

        protected override void AfterSave()
        {
            ToolbarCode = ((CodFundTransferVerificationModel)CurrentModel).Code;
            OpenData(ToolbarCode);
        }

        public override void AfterDelete()
        {
            var detail = new CodFundTransferVerificationDetailDataManager().Get<CodFundTransferVerificationDetailModel>(WhereTerm.Default(CurrentModel.Id, "Cod_fund_transfer_verification_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new CodFundTransferVerificationDetailDataManager();
                var r = new CodFundTransferDataManager();
                foreach (CodFundTransferVerificationDetailModel obj in detail)
                {
                    var d = r.GetFirst<CodFundTransferModel>(WhereTerm.Default((int)obj.InvoiceId, "id", EnumSqlOperator.Equals));
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

        protected override void PopulateForm(CodFundTransferVerificationModel model)
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

            GridVerify.DataSource = new CodFundTransferVerificationDetailDataManager().Get<CodFundTransferVerificationDetailModel>(WhereTerm.Default(model.Id, "Cod_fund_transfer_verification_id"));
            VerifyView.RefreshData();
        }

        protected override CodFundTransferVerificationModel PopulateModel(CodFundTransferVerificationModel model)
        {
            model.DateProcess = tbxDate.DateTime;
            model.BranchId = BaseControl.BranchId;
            model.Code = CurrentModel.Id > 0 ? model.Code : GetCode("codfundtransferverification", tbxDate.DateTime);
            if (CurrentModel.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override CodFundTransferVerificationModel Find(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm)) tsBaseTxt_Code.Text = searchTerm;
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<CodFundTransferVerificationModel>(param);
            PopulateForm(obj);

            return obj;
        }
    }
}