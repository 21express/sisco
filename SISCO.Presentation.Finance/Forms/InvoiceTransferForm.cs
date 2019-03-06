using Devenlab.Common;
using SISCO.App.Billing;
using SISCO.App.Finance;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using Devenlab.Common.WinControl.MessageBox;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.Finance.Popup;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class InvoiceTransferForm : BaseCrudForm<InvoiceTransferModel, InvoiceTransferDataManager>//BaseToolbarForm//
    {
        private List<int> DeletedRows { get; set; }
        public InvoiceTransferForm()
        {
            InitializeComponent();
            form = this;

            Load += InvoiceTransferForm_Load;
            Shown += InvoiceTransferForm_Shown;
        }

        void InvoiceTransferForm_Shown(object sender, EventArgs e)
        {
            GridUntransfer.DataSource = new InvoiceTransferDetailDataManager().GetUntransfer(BaseControl.BranchId);
            UntransferView.RefreshData();
        }

        void InvoiceTransferForm_Load(object sender, EventArgs e)
        {
            EnableBtnSearch = true;
            SearchPopup = new InvoiceTransferFilterPopup();

            TransferView.CustomColumnDisplayText += NumberGrid;
            UntransferView.CustomColumnDisplayText += NumberGrid;

            tbxKwitansi.Enabled = false;
            btnAdd.Enabled = false;

            tbxKwitansi.KeyDown += tbxKwitansi_KeyDown;
            btnAdd.Click += btnAdd_Click;
            btnDelete.Click += btnDelete_Click;
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            var dialog = MessageForm.Ask(form, Resources.delete_confirm, Resources.delete_confirm_msg);
            if (dialog == DialogResult.Yes)
            {
                var rowHandle = TransferView.FocusedRowHandle;
                if ((int)TransferView.GetRowCellValue(rowHandle, TransferView.Columns["Id"]) > 0) DeletedRows.Add((int)TransferView.GetRowCellValue(rowHandle, TransferView.Columns["Id"]));
                TransferView.DeleteSelectedRows();
            }
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxKwitansi.Text))
            {
                var invoice = new SalesInvoiceDataManager().GetFirst<SalesInvoiceModel>(WhereTerm.Default(tbxKwitansi.Text, "ref_number"));
                if (invoice != null)
                {
                    if (invoice.Cancelled) MessageBox.Show("No Kwitansi sudah dibatalkan.");
                    else if (!invoice.Printed) MessageBox.Show("No Kwitansi belum dicetak.");
                    else
                    {
                        if (!new InvoiceTransferDetailDataManager().IsTransfered(tbxKwitansi.Text))
                        {
                            if (new InvoiceDistributionResultDetailDataManager().IsInvoiceTransfered(tbxKwitansi.Text))
                            {
                                var details = GridTransfer.DataSource as List<TransferDetailModel>;
                                if (details.Where(p => p.RefNumber == tbxKwitansi.Text).FirstOrDefault() == null)
                                {
                                    details.Add(new TransferDetailModel
                                    {
                                        Id = 0,
                                        SalesInvoiceId = invoice.Id,
                                        RefNumber = invoice.RefNumber,
                                        CustomerName = invoice.CompanyInvoicedTo,
                                        Period = invoice.Period,
                                        StateChange = EnumStateChange.Insert.ToString()
                                    });

                                    GridTransfer.DataSource = details;
                                    TransferView.RefreshData();

                                    TransferView.FocusedRowHandle = TransferView.RowCount - 1;
                                }
                            }
                            else MessageBox.Show("No Kwitansi bukan dengan pembayaran Transfer.");
                        }
                        else MessageBox.Show("No kwitansi sudah dikirim.");
                    }
                }
                else MessageBox.Show("No Kwitansi tidak dikenali.");
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

            tbxDate.DateTime = DateTime.Now;
            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;

            GridTransfer.DataSource = new List<TransferDetailModel>();
            TransferView.RefreshData();

            GridUntransfer.DataSource = new InvoiceTransferDetailDataManager().GetUntransfer(BaseControl.BranchId);
            UntransferView.RefreshData();

            tbxKwitansi.Enabled = true;
            btnAdd.Enabled = true;

            tbxKwitansi.Focus();
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            for (int i = 0; i < TransferView.RowCount; i++)
            {
                int rowHandle = TransferView.GetVisibleRowHandle(i);
                if (TransferView.IsDataRow(rowHandle))
                {
                    var state = TransferView.GetRowCellValue(rowHandle, TransferView.Columns["StateChange"]);
                    if (state.ToString().Equals(EnumStateChange.Insert.ToString()))
                    {
                        var detail = new InvoiceTransferDetailModel();
                        detail.Rowstatus = true;
                        detail.Rowversion = DateTime.Now;
                        detail.InvoiceTransferId = CurrentModel.Id;
                        detail.SalesInvoiceId = (int)TransferView.GetRowCellValue(rowHandle, TransferView.Columns["SalesInvoiceId"]);

                        detail.Createddate = DateTime.Now;
                        detail.Createdby = BaseControl.UserLogin;

                        new InvoiceTransferDetailDataManager().Save<InvoiceTransferDetailModel>(detail);
                    }
                }
            }

            foreach (int o in DeletedRows)
            {
                new InvoiceTransferDetailDataManager().DeActive(o, BaseControl.UserLogin, DateTime.Now);
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
            var detail = new InvoiceTransferDetailDataManager().Get<InvoiceTransferDetailModel>(WhereTerm.Default(CurrentModel.Id, "invoice_transfer_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new InvoiceTransferDetailDataManager();
                foreach (InvoiceTransferDetailModel obj in detail)
                {
                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
                }
            }

            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            if (TransferView.RowCount == 0)
            {
                tbxKwitansi.Focus();
                return false;
            }

            return true;
        }

        protected override void PopulateForm(InvoiceTransferModel model)
        {
            ClearForm();
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

            GridTransfer.DataSource = new InvoiceTransferDetailDataManager().GetDetails(model.Id);
            TransferView.RefreshData();

            GridUntransfer.DataSource = new InvoiceTransferDetailDataManager().GetUntransfer(BaseControl.BranchId);
            UntransferView.RefreshData();
        }

        protected override InvoiceTransferModel PopulateModel(InvoiceTransferModel model)
        {
            model.DateProcess = tbxDate.DateTime;
            model.BranchId = BaseControl.BranchId;

            return model;
        }

        protected override InvoiceTransferModel Find(string searchTerm)
        {
            return DataManager.GetFirst<InvoiceTransferModel>(WhereTerm.Default(Convert.ToInt32(searchTerm), "id"));
        }
    }
}