using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.Billing;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using SISCO.Presentation.Billing.Popup;

namespace SISCO.Presentation.Billing.Forms
{
    public partial class InvoiceToFinanceForm : BaseCrudForm<InvoiceToFinanceModel, InvoiceToFinanceDataManager>//BaseToolbarForm//
    {
        public InvoiceToFinanceForm()
        {
            InitializeComponent();
            form = this;

            tbxRefNumber.KeyDown += tbxRefNumber_KeyDown;
            btnAdd.Click += btnAdd_Click;
            btnDelete.ButtonClick += btnDelete_ButtonClick;
            DetailView.CustomColumnDisplayText += NumberGrid;

            tbxRefNumber.Enabled = false;
            btnAdd.Enabled = false;

            EnableBtnSearch = true;
            SearchPopup = new InvoiceFinancePopup();

            btnExport.Click += (a,s) => ExportExcel(GridDetail);

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id")
            };
        }

        void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (CurrentModel.Id == 0)
                DetailView.DeleteSelectedRows();
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxRefNumber.Text))
            {
                var invoice = new SalesInvoiceDataManager().GetFirst<SalesInvoiceModel>(new IListParameter[]
                {
                    WhereTerm.Default(tbxRefNumber.Text, "ref_number", EnumSqlOperator.Equals)
                });

                if (invoice == null) MessageBox.Show("Nomor invoice tidak ditemukan");
                else
                {
                    if (invoice.Cancelled)
                    {
                        MessageBox.Show("Nomor invoice sudah dibatalkan");
                        return;
                    }

                    if (!invoice.Printed)
                    {
                        MessageBox.Show("Invoice belum dicetak.");
                        return;
                    }

                    if (new InvoiceToFinanceDetailDataManager().IsRefSent(tbxRefNumber.Text))
                    {
                        MessageBox.Show("Invoice sudah dikirimkan.");
                        return;
                    }

                    var details = GridDetail.DataSource as List<InvoiceFinanceDetailModel>;

                    if (details.Where(p => p.RefNumber == tbxRefNumber.Text).FirstOrDefault() == null)
                    {
                        details.Add(new InvoiceFinanceDetailModel
                        {
                            Id = 0,
                            SalesInvoiceId = invoice.Id,
                            RefNumber = invoice.RefNumber,
                            CustomerName = invoice.CompanyInvoicedTo,
                            Period = invoice.Period,
                            Total = invoice.Total,
                            StateChange = EnumStateChange.Insert.ToString()
                        });

                        GridDetail.DataSource = details;
                        DetailView.RefreshData();

                        DetailView.FocusedRowHandle = DetailView.RowCount - 1;
                    }
                }
            }
        }

        void tbxRefNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(sender, e);
                tbxRefNumber.Clear();
                tbxRefNumber.Focus();
            }
        }

        public override void New()
        {
            base.New();

            ClearForm();

            tbxDate.DateTime = DateTime.Now;
            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;

            GridDetail.DataSource = new List<InvoiceFinanceDetailModel>();
            DetailView.RefreshData();

            tbxRefNumber.Enabled = true;
            btnAdd.Enabled = true;

            tbxDescription.Focus();
            btnExport.Enabled = false;
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            for (int i = 0; i < DetailView.RowCount; i++)
            {
                if (DetailView.GetRowCellValue(i, DetailView.Columns["StateChange"]).ToString() == EnumStateChange.Insert.ToString())
                {
                    var detail = new InvoiceToFinanceDetailModel();
                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.InvoiceToFinanceId = CurrentModel.Id;
                    detail.SalesInvoiceId = (int)DetailView.GetRowCellValue(i, DetailView.Columns["SalesInvoiceId"]);
                    detail.Createddate = DateTime.Now;
                    detail.Createdby = BaseControl.UserLogin;

                    new InvoiceToFinanceDetailDataManager().Save<InvoiceToFinanceDetailModel>(detail);
                }
            }

            ToolbarCode = CurrentModel.Id.ToString();
        }

        protected override void AfterSave()
        {
            OpenData(ToolbarCode);
        }

        public override void AfterDelete()
        {
            var details = new InvoiceToFinanceDetailDataManager().Get<InvoiceToFinanceDetailModel>(WhereTerm.Default(CurrentModel.Id, " invoice_to_finance_id"));
            foreach (var d in details) new InvoiceToFinanceDetailDataManager().DeActive(d.Id, BaseControl.UserLogin, DateTime.Now);

            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text == "")
            {
                tbxDate.Focus();
                return false;
            }

            if (DetailView.RowCount == 0)
            {
                tbxRefNumber.Focus();
                return false;
            }

            return true;
        }

        protected override void PopulateForm(InvoiceToFinanceModel model)
        {
            ClearForm();
            if (model == null) return;

            btnExport.Enabled = true;
            tbxRefNumber.Enabled = false;
            btnAdd.Enabled = false;

            if (model == null) return;

            tbxRefNumber.Enabled = true;
            btnAdd.Enabled = true;

            ToolbarCode = model.Id.ToString();
            tbxDate.DateTime = model.DateProcess;
            tbxDescription.Text = model.Description;

            GridDetail.DataSource = new InvoiceToFinanceDetailDataManager().Get(model.Id);
            DetailView.RefreshData();
        }

        protected override InvoiceToFinanceModel PopulateModel(InvoiceToFinanceModel model)
        {
            model.DateProcess = tbxDate.DateTime;
            model.BranchId = BaseControl.BranchId;
            model.Description = tbxDescription.Text;

            return model;
        }

        protected override InvoiceToFinanceModel Find(string searchTerm)
        {
            return DataManager.GetFirst<InvoiceToFinanceModel>(WhereTerm.Default(Convert.ToInt32(searchTerm), "id"), WhereTerm.Default(BaseControl.BranchId, "branch_id"));
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            var model = CurrentModel as InvoiceToFinanceModel;
            if (model != null && model.Id > 0)
            {
                tbxDate.Enabled = false;
                tbxDate.Properties.Buttons[0].Enabled = false;
                tbxDescription.Enabled = false;
            }
        }
    }
}
