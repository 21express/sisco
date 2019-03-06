using Devenlab.Common;
using Devenlab.Common.WinControl.MessageBox;
using SISCO.App.Billing;
using SISCO.App.Finance;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.Finance.Popup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class InvoiceTransferAcceptanceForm : BaseCrudForm<InvoiceTransferAcceptanceModel, InvoiceTransferAcceptanceDataManager>//BaseToolbarForm//
    {
        private List<int> DeletedRows { get; set; }
        public InvoiceTransferAcceptanceForm()
        {
            InitializeComponent();
            form = this;

            Load += InvoiceTransferAcceptanceForm_Load;
            Shown += InvoiceTransferAcceptanceForm_Shown;
        }

        void InvoiceTransferAcceptanceForm_Shown(object sender, EventArgs e)
        {
            GridUnaccepted.DataSource = new InvoiceTransferAcceptanceDetailDataManager().GetUnAcceptedTransfer(BaseControl.BranchId);
            UnacceptedView.RefreshData();
        }

        void InvoiceTransferAcceptanceForm_Load(object sender, EventArgs e)
        {
            EnableBtnSearch = true;
            SearchPopup = new InvoiceTransferAcceptanceFilterPopup();

            AcceptanceView.CustomColumnDisplayText += NumberGrid;
            UnacceptedView.CustomColumnDisplayText += NumberGrid;

            tbxKwitansi.Enabled = false;
            btnAdd.Enabled = false;

            tbxKwitansi.KeyDown += tbxKwitansi_KeyDown;
            btnAdd.Click += btnAdd_Click;
            btnDelete.Click += btnDelete_Click;

            btnExport.Click += (a, s) => ExportExcel(GridAcceptance);
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            var dialog = MessageForm.Ask(form, Resources.delete_confirm, Resources.delete_confirm_msg);
            if (dialog == DialogResult.Yes)
            {
                var rowHandle = AcceptanceView.FocusedRowHandle;
                if ((int)AcceptanceView.GetRowCellValue(rowHandle, AcceptanceView.Columns["Id"]) > 0) DeletedRows.Add((int)AcceptanceView.GetRowCellValue(rowHandle, AcceptanceView.Columns["Id"]));
                AcceptanceView.DeleteSelectedRows();
            }
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxKwitansi.Text))
            {
                var invoice = new SalesInvoiceDataManager().GetFirst<SalesInvoiceModel>(WhereTerm.Default(tbxKwitansi.Text, "ref_number"));
                if (invoice != null)
                {
                    if (invoice.Cancelled) MessageBox.Show("No kwitansi sudah dibatalkan.");
                    else if (!invoice.Printed) MessageBox.Show("No kwitansi belum dicetak.");
                    else
                    {
                        if (!new InvoiceTransferAcceptanceDetailDataManager().IsAccepted(tbxKwitansi.Text))
                        {
                            if (new InvoiceDistributionResultDetailDataManager().IsInvoiceTransfered(tbxKwitansi.Text))
                            {
                                var details = GridAcceptance.DataSource as List<TransferAcceptanceDetailModel>;
                                if (details.Where(p => p.RefNumber == tbxKwitansi.Text).FirstOrDefault() == null)
                                {
                                    details.Add(new TransferAcceptanceDetailModel
                                    {
                                        Id = 0,
                                        SalesInvoiceId = invoice.Id,
                                        RefNumber = invoice.RefNumber,
                                        CustomerName = invoice.CompanyInvoicedTo,
                                        Period = invoice.Period,
                                        StateChange = EnumStateChange.Insert.ToString()
                                    });

                                    GridAcceptance.DataSource = details;
                                    AcceptanceView.RefreshData();

                                    AcceptanceView.FocusedRowHandle = AcceptanceView.RowCount - 1;
                                }
                            }
                            else MessageBox.Show("No kwitansi bukan dengan pembayaran Transfer");
                        }
                        else MessageBox.Show("No kwitansi sudah diterima.");
                    }
                }
                else MessageBox.Show("No Kwitansi tidak dikenali");
            }

            tbxKwitansi.Clear();
            tbxKwitansi.Focus();
        }

        void tbxKwitansi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnAdd_Click(sender, e);
        }

        public override void New()
        {
            base.New();

            ClearForm();

            DeletedRows = new List<int>();
            GridAcceptance.DataSource = new List<TransferAcceptanceDetailModel>();

            tbxDate.DateTime = DateTime.Now;
            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;

            GridUnaccepted.DataSource = new InvoiceTransferAcceptanceDetailDataManager().GetUnAcceptedTransfer(BaseControl.BranchId);
            UnacceptedView.RefreshData();

            tbxKwitansi.Enabled = true;
            btnAdd.Enabled = true;

            tbxKwitansi.Focus();
            btnExport.Enabled = false;
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            for (int i = 0; i < AcceptanceView.RowCount; i++)
            {
                int rowHandle = AcceptanceView.GetVisibleRowHandle(i);
                if (AcceptanceView.IsDataRow(rowHandle))
                {
                    var state = AcceptanceView.GetRowCellValue(rowHandle, AcceptanceView.Columns["StateChange"]);
                    if (state.ToString().Equals(EnumStateChange.Insert.ToString()))
                    {
                        var detail = new InvoiceTransferAcceptanceDetailModel();
                        detail.Rowstatus = true;
                        detail.Rowversion = DateTime.Now;
                        detail.InvoiceTransferAcceptanceId = CurrentModel.Id;
                        detail.SalesInvoiceId = (int)AcceptanceView.GetRowCellValue(rowHandle, AcceptanceView.Columns["SalesInvoiceId"]);

                        detail.Createddate = DateTime.Now;
                        detail.Createdby = BaseControl.UserLogin;

                        new InvoiceTransferAcceptanceDetailDataManager().Save<InvoiceTransferAcceptanceDetailModel>(detail);
                    }
                }
            }

            foreach (int o in DeletedRows)
            {
                new InvoiceTransferAcceptanceDetailDataManager().DeActive(o, BaseControl.UserLogin, DateTime.Now);
            }

            ToolbarCode = CurrentModel.Id.ToString();
        }

        protected override void AfterSave()
        {
            OpenData(ToolbarCode);
            tsBaseTxt_Code.Focus();
        }

        public override void AfterDelete()
        {
            var detail = new InvoiceTransferAcceptanceDetailDataManager().Get<InvoiceTransferAcceptanceDetailModel>(WhereTerm.Default(CurrentModel.Id, "invoice_transfer_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new InvoiceTransferAcceptanceDetailDataManager();
                foreach (InvoiceTransferAcceptanceDetailModel obj in detail)
                {
                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
                }
            }

            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            if (AcceptanceView.RowCount == 0)
            {
                tbxKwitansi.Focus();
                return false;
            }

            return true;
        }

        protected override void PopulateForm(InvoiceTransferAcceptanceModel model)
        {
            ClearForm();
            if (model == null) return;

            btnExport.Enabled = true;
            tbxKwitansi.Enabled = false;
            btnAdd.Enabled = false;
            if (model == null) return;

            DeletedRows = new List<int>();
            tbxKwitansi.Enabled = true;
            btnAdd.Enabled = true;

            ToolbarCode = model.Id.ToString();
            tbxDate.DateTime = model.DateProcess;
            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;

            GridUnaccepted.DataSource = new InvoiceTransferAcceptanceDetailDataManager().GetUnAcceptedTransfer(BaseControl.BranchId);
            UnacceptedView.RefreshData();

            GridAcceptance.DataSource = new InvoiceTransferAcceptanceDetailDataManager().GetDetails(model.Id);
            AcceptanceView.RefreshData();
        }

        protected override InvoiceTransferAcceptanceModel PopulateModel(InvoiceTransferAcceptanceModel model)
        {
            model.BranchId = BaseControl.BranchId;
            model.DateProcess = tbxDate.DateTime;

            return model;
        }

        protected override InvoiceTransferAcceptanceModel Find(string searchTerm)
        {
            return DataManager.GetFirst<InvoiceTransferAcceptanceModel>(WhereTerm.Default(Convert.ToInt32(searchTerm), "id"));
        }
    }
}