using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using SISCO.App.Billing;
using SISCO.App.Finance;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using SISCO.Presentation.Finance.Popup;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class InvoiceDistributionResultForm : BaseCrudForm<InvoiceDistributionResultModel, InvoiceDistributionResultDataManager>//BaseToolbarForm//
    {
        private List<int> DeletedRows { get; set; }

        public InvoiceDistributionResultForm()
        {
            InitializeComponent();
            form = this;

            Shown += InvoiceDistributionResultForm_Shown;
            Load += InvoiceDistributionResultForm_Load;
        }

        void InvoiceDistributionResultForm_Load(object sender, EventArgs e)
        {
            EnableBtnSearch = true;
            SearchPopup = new InvoiceDistributionFilterPopup();

            GridDistributed.DoubleClick += UpdateDistribution;
            UndistributedView.CustomColumnDisplayText += NumberGrid;
            DistributedView.CustomColumnDisplayText += NumberGrid;

            lkpCollector.LookupPopup = new CollectorPopup();
            lkpCollector.AutoCompleteDataManager = new EmployeeDataManager();
            lkpCollector.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " " + ((EmployeeModel)model).Name;
            lkpCollector.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("(code = @0 or name.StartsWith(@0)) and branch_id = @1 and as_collector", s, BaseControl.BranchId);

            lkpPaymentType.LookupPopup = new PaymentTypePopup();
            lkpPaymentType.AutoCompleteDataManager = new PaymentTypeDataManager();
            lkpPaymentType.AutoCompleteDisplayFormater = model => ((PaymentTypeModel)model).Name;
            lkpPaymentType.AutoCompleteWhereExpression += (s, param) => param.SetWhereExpression("name.StartsWith(@0)", s);

            tbxKwitansi.Enabled = false;
            btnAdd.Enabled = false;

            tbxKwitansi.KeyDown += tbxKwitansi_KeyDown;
            btnFind.Click += btnFind_Click;
            btnAdd.Click += btnAdd_Click;
            btnDelete.ButtonClick += btnDelete_ButtonClick;
        }

        private void UpdateDistribution(object sender, EventArgs e)
        {
            var rows = DistributedView.GetSelectedRows();
            lkpCollector.Value = null;
            lkpCollector.Text = string.Empty;
            tbxReceipt.Clear();

            tbxKwitansi.Text = DistributedView.GetRowCellValue(rows[0], "RefNumber").ToString();

            btnFind_Click(sender, e);

            lkpCollector.DefaultValue = new IListParameter[] { WhereTerm.Default((int)DistributedView.GetRowCellValue(rows[0], "CollectorId"), "id", EnumSqlOperator.Equals) };
            lkpPaymentType.DefaultValue = new IListParameter[] { WhereTerm.Default((int)DistributedView.GetRowCellValue(rows[0], "PaymentTypeId"), "id", EnumSqlOperator.Equals) };
            tbxReceipt.Text = DistributedView.GetRowCellValue(rows[0], "ReceiptName").ToString();
            lkpCollector.Focus();
        }

        void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var dialog = MessageForm.Ask(form, Resources.delete_confirm, Resources.delete_confirm_msg);
            if (dialog == DialogResult.Yes)
            {
                var rowHandle = DistributedView.FocusedRowHandle;
                if ((int)DistributedView.GetRowCellValue(rowHandle, DistributedView.Columns["Id"]) > 0) DeletedRows.Add((int)DistributedView.GetRowCellValue(rowHandle, DistributedView.Columns["Id"]));
                DistributedView.DeleteSelectedRows();
            }
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            if (invoiceCollector == null)
            {
                MessageBox.Show("No Kwitansi tidak dikenali.");
                tbxKwitansi.Focus();
                return;
            }

            if (lkpCollector.Value == null)
            {
                lkpCollector.Focus();
                return;
            }

            if (lkpPaymentType.Value == null)
            {
                lkpPaymentType.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tbxReceipt.Text))
            {
                tbxReceipt.Focus();
                return;
            }

            var details = GridDistributed.DataSource as List<InvoiceDistributionDetailModel>;

            if (details.Where(p => p.RefNumber == tbxKwitansi.Text).FirstOrDefault() == null)
            {
                if (new InvoiceDistributionResultDetailDataManager().IsDistributed(tbxKwitansi.Text))
                    MessageBox.Show("No Kwitansi sudah didistribusikan.");
                else
                {
                    details.Add(new InvoiceDistributionDetailModel
                    {
                        Id = 0,
                        SalesInvoiceId = invoiceCollector.SalesInvoiceId,
                        RefNumber = tbxKwitansi.Text,
                        CustomerName = invoiceCollector.CustomerName,
                        CollectorId = (int)lkpCollector.Value,
                        CollectorName = lkpCollector.Text,
                        PaymentTypeId = (int)lkpPaymentType.Value,
                        PaymentTypeName = lkpPaymentType.Text,
                        ReceiptName = tbxReceipt.Text,
                        StateChange = EnumStateChange.Insert.ToString()
                    });

                    GridDistributed.DataSource = details;
                    DistributedView.RefreshData();

                    DistributedView.FocusedRowHandle = DistributedView.RowCount - 1;
                }
            }
            else
            {
                details.ForEach(p =>
                {
                    if (p.RefNumber == tbxKwitansi.Text)
                    {
                        p.CollectorId = (int)lkpCollector.Value;
                        p.CollectorName = lkpCollector.Text;
                        p.PaymentTypeId = (int)lkpPaymentType.Value;
                        p.PaymentTypeName = lkpPaymentType.Text;
                        p.ReceiptName = tbxReceipt.Text;
                        p.StateChange = p.StateChange == EnumStateChange.Select.ToString() ? EnumStateChange.Update.ToString() : p.StateChange;
                    }
                });

                GridDistributed.DataSource = details;
                DistributedView.RefreshData();
            }

            tbxKwitansi.Clear();
            tbxKwitansi.Focus();
            lkpCollector.Value = null;
            lkpCollector.Text = string.Empty;
            lkpPaymentType.Value = null;
            lkpPaymentType.Text = string.Empty;
            tbxReceipt.Clear();
        }

        InvoiceCollectorModel invoiceCollector { get; set; }
        void btnFind_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxKwitansi.Text))
            {
                invoiceCollector = new InvoiceDistributionResultDetailDataManager().GetCollector(tbxKwitansi.Text);
                if (invoiceCollector != null)
                {
                    if (invoiceCollector.Cancelled)
                    {
                        MessageBox.Show("No Kwitansi sudah dibatalkan.");
                        tbxKwitansi.Clear();
                        tbxKwitansi.Focus();
                        return;
                    }

                    if (!invoiceCollector.Printed)
                    {
                        MessageBox.Show("No Kwitansi belum dicetak.");
                        tbxKwitansi.Clear();
                        tbxKwitansi.Focus();
                        return;
                    }

                    tbxReceipt.Focus();
                    if (invoiceCollector.CollectorId > 0)
                    {
                        lkpCollector.DefaultValue = new IListParameter[] { WhereTerm.Default((int)invoiceCollector.CollectorId, "id") };
                    }
                    else
                    {
                        lkpPaymentType.Value = null;
                        lkpPaymentType.Text = string.Empty;
                        lkpCollector.Value = null;
                        lkpCollector.Text = string.Empty;
                    }

                    lkpCollector.Focus();
                }
                else
                {
                    MessageBox.Show("No Kwitansi tidak dikenali");
                    tbxKwitansi.Clear();
                    tbxKwitansi.Focus();
                }
            }
        }

        void tbxKwitansi_KeyDown(object sender, KeyEventArgs e)
        {
            invoiceCollector = null;
            if (e.KeyCode == Keys.Enter) btnFind_Click(sender, e);
        }

        void InvoiceDistributionResultForm_Shown(object sender, EventArgs e)
        {
            GridUndistributed.DataSource = new InvoiceDistributionResultDetailDataManager().GetUnDistributed(BaseControl.BranchId);
            UndistributedView.RefreshData();
        }

        protected override void AfterSave()
        {
            OpenData(ToolbarCode);
            tsBaseTxt_Code.Focus();
        }

        public override void AfterDelete()
        {
            var detail = new InvoiceDistributionResultDetailDataManager().Get<InvoiceDistributionResultDetailModel>(WhereTerm.Default(CurrentModel.Id, "invoice_distribution_result_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new InvoiceDistributionResultDetailDataManager();
                foreach (InvoiceDistributionResultDetailModel obj in detail)
                {
                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
                }
            }

            base.AfterDelete();
        }

        public override void New()
        {
            base.New();

            ClearForm();

            tbxDate.Text = DateTime.Now.ToString();
            tbxDate.DateTime = DateTime.Now;
            tbxKwitansi.Enabled = true;
            btnAdd.Enabled = true;

            tbxKwitansi.Focus();

            GridDistributed.DataSource = new List<InvoiceDistributionDetailModel>();
            DistributedView.RefreshData();

            GridUndistributed.DataSource = new InvoiceDistributionResultDetailDataManager().GetUnDistributed(BaseControl.BranchId);
            UndistributedView.RefreshData();

            DeletedRows = new List<int>();
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            for (int i = 0; i < DistributedView.RowCount; i++)
            {
                int rowHandle = DistributedView.GetVisibleRowHandle(i);
                if (DistributedView.IsDataRow(rowHandle))
                {
                    var state = DistributedView.GetRowCellValue(rowHandle, DistributedView.Columns["StateChange"]);
                    if (state.ToString().Equals(EnumStateChange.Insert.ToString()))
                    {
                        var detail = new InvoiceDistributionResultDetailModel();
                        detail.Rowstatus = true;
                        detail.Rowversion = DateTime.Now;
                        detail.InvoiceDistributionResultId = CurrentModel.Id;
                        detail.SalesInvoiceId = (int)DistributedView.GetRowCellValue(rowHandle, DistributedView.Columns["SalesInvoiceId"]);

                        detail.CollectorId = (int)DistributedView.GetRowCellValue(rowHandle, DistributedView.Columns["CollectorId"]);
                        detail.PaymentTypeId = (int)DistributedView.GetRowCellValue(rowHandle, DistributedView.Columns["PaymentTypeId"]);

                        detail.ReceiptName = DistributedView.GetRowCellValue(rowHandle, DistributedView.Columns["ReceiptName"]).ToString();

                        detail.Createddate = DateTime.Now;
                        detail.Createdby = BaseControl.UserLogin;

                        new InvoiceDistributionResultDetailDataManager().Save<InvoiceDistributionResultDetailModel>(detail);
                    }

                    if (state.ToString().Equals(EnumStateChange.Update.ToString()))
                    {
                        var rec = new InvoiceDistributionResultDetailDataManager().GetFirst<InvoiceDistributionResultDetailModel>(WhereTerm.Default((int)DistributedView.GetRowCellValue(rowHandle, DistributedView.Columns["Id"]), "id", EnumSqlOperator.Equals));
                        if (rec != null)
                        {
                            rec.CollectorId = (int)DistributedView.GetRowCellValue(rowHandle, DistributedView.Columns["CollectorId"]);
                            rec.PaymentTypeId = (int)DistributedView.GetRowCellValue(rowHandle, DistributedView.Columns["PaymentTypeId"]);
                            rec.ReceiptName = DistributedView.GetRowCellValue(rowHandle, DistributedView.Columns["ReceiptName"]).ToString();

                            rec.Modifieddate = DateTime.Now;
                            new InvoiceDistributionResultDetailDataManager().Update<InvoiceDistributionResultDetailModel>(rec);
                        }
                    }
                }
            }

            foreach (int o in DeletedRows)
            {
                new InvoiceDistributionResultDetailDataManager().DeActive(o, BaseControl.UserLogin, DateTime.Now);
            }

            ToolbarCode = CurrentModel.Id.ToString();
        }

        protected override bool ValidateForm()
        {
            if (DistributedView.RowCount == 0)
            {
                tbxKwitansi.Focus();
                return false;
            }

            return true;
        }

        protected override void PopulateForm(InvoiceDistributionResultModel model)
        {
            ClearForm();
            tbxKwitansi.Enabled = false;
            btnAdd.Enabled = false;
            if (model == null) return;

            tbxKwitansi.Enabled = true;
            btnAdd.Enabled = true;

            ToolbarCode = model.Id.ToString();
            tbxDate.DateTime = model.DateProcess;

            GridUndistributed.DataSource = new InvoiceDistributionResultDetailDataManager().GetUnDistributed(BaseControl.BranchId);
            UndistributedView.RefreshData();

            GridDistributed.DataSource = new InvoiceDistributionResultDetailDataManager().GetDetails(model.Id);
            DistributedView.RefreshData();

            DeletedRows = new List<int>();
        }

        protected override InvoiceDistributionResultModel PopulateModel(InvoiceDistributionResultModel model)
        {
            model.DateProcess = tbxDate.DateTime;
            model.BranchId = BaseControl.BranchId;
            return model;
        }

        protected override InvoiceDistributionResultModel Find(string searchTerm)
        {
            return DataManager.GetFirst<InvoiceDistributionResultModel>(WhereTerm.Default(Convert.ToInt32(searchTerm), "id"));
        }
    }
}
