using Devenlab.Common;
using Devenlab.Common.WinControl.MessageBox;
using SISCO.App.Finance;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Finance.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class TitipInvoiceAccceptanceForm : BaseCrudForm<OtherInvoiceAcceptanceModel, OtherInvoiceAcceptanceDataManager>//BaseToolbarForm//
    {
        public TitipInvoiceAccceptanceForm()
        {
            InitializeComponent();
            form = this;

            EnableBtnSearch = true;
            SearchPopup = new TitipInvoiceAcceptanceFilterPopup();
            btnAdd.Click += AddRow;
        }

        private void AddRow(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxRefNumber.Text))
            {
                tbxRefNumber.Clear();
                tbxRefNumber.Focus();

                return;
            }

            var titip = gridTitip.DataSource as List<OtherInvoiceAcceptanceDetail>;
            if (titip == null) titip = new List<OtherInvoiceAcceptanceDetail>();
            var data = new OtherInvoiceAcceptanceDetailDataManager().GetInvoice(tbxRefNumber.Text);

            if (data == null)
            {
                MessageForm.Info(this, "Information", "No. kwitansi tidak dikenali.");
                return;
            }

            if (data.Accepted)
            {
                MessageForm.Info(this, "Information", "No. kwitansi sudah pernah diterima.");
                return;
            }

            if (data.DestBranchId != BaseControl.BranchId)
            {
                MessageForm.Info(this, "Information", "No. kwitansi ini bukan dititipkan ke cabang lain.");
                return;
            }

            data.StateChange2 = EnumStateChange.Insert.ToString();
            titip.Add(data);
            gridTitip.DataSource = titip;
            TitipView.RefreshData();

            tbxRefNumber.Clear();
            tbxRefNumber.Focus();
        }

        protected override bool ValidateForm()
        {
            if (TitipView.RowCount == 0) return false;

            return true;
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();

            tbxDate.Enabled = true;
            tbxDate.Properties.Buttons[0].Enabled = true;

            tbxDate.DateTime = DateTime.Now;

            gridTitip.DataSource = null;
            TitipView.RefreshData();
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            var detailDm = new OtherInvoiceAcceptanceDetailDataManager();
            for (int i = 0; i < TitipView.RowCount; i++)
            {
                var state = TitipView.GetRowCellValue(i, TitipView.Columns["StateChange2"]);

                var detail = new OtherInvoiceAcceptanceDetailModel();

                if (state.ToString().Equals(EnumStateChange.Insert.ToString()))
                {
                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.OtherInvoiceAcceptanceId = CurrentModel.Id;
                    detail.OtherInvoiceId =
                            (int)TitipView.GetRowCellValue(i, TitipView.Columns["OtherInvoiceId"]);

                    detail.Createdby = BaseControl.UserLogin;
                    detail.Createddate = DateTime.Now;

                    detailDm.Save<OtherInvoiceAcceptanceDetailModel>(detail);

                    var otherInvoice =
                        new OtherInvoiceDataManager().GetFirst<OtherInvoiceModel>(WhereTerm.Default(detail.OtherInvoiceId, "id",
                            EnumSqlOperator.Equals));

                    if (otherInvoice != null)
                    {
                        otherInvoice.Accept = true;
                        otherInvoice.AcceptAt = DateTime.Now;
                        otherInvoice.Modifiedby = BaseControl.UserLogin;
                        otherInvoice.Modifieddate = DateTime.Now;

                        new OtherInvoiceDataManager().Update<OtherInvoiceModel>(otherInvoice);
                    }
                }
            }
        }

        protected override void AfterSave()
        {
            ToolbarCode = ((OtherInvoiceAcceptanceModel)CurrentModel).Code;
            OpenData(ToolbarCode);
        }

        protected override void PopulateForm(OtherInvoiceAcceptanceModel model)
        {
            ClearForm();

            tsBaseTxt_Code.Text = model.Code;
            tbxDate.DateTime = model.DateProcess;
            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;

            var data = new OtherInvoiceAcceptanceDetailDataManager().GetInvoices(model.Id);
            gridTitip.DataSource = data;
            TitipView.RefreshData();
        }

        protected override OtherInvoiceAcceptanceModel PopulateModel(OtherInvoiceAcceptanceModel model)
        {
            model.DateProcess = tbxDate.DateTime;
            if (CurrentModel.Id == 0)
            {
                model.Code = GetCode("titip-acceptance", tbxDate.DateTime);
            }

            return model;
        }

        protected override OtherInvoiceAcceptanceModel Find(string searchTerm)
        {
            var obj = DataManager.GetFirst<OtherInvoiceAcceptanceModel>(WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals));
            PopulateForm(obj);

            return obj;
        }
    }
}