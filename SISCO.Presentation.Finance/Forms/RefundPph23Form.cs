using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using SISCO.App.Finance;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using SISCO.Presentation.Common;
using SISCO.Presentation.Finance.Popup;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class RefundPph23Form : BaseCrudForm<RefundPph23Model, RefundPph23DataManager>//BaseToolbarForm//
    {
        private Dictionary<int, string> DeletedRows { get; set; }
        private string Code { get; set; }

        public RefundPph23Form()
        {
            InitializeComponent();

            form = this;
            Load += RefundPph23Load;
            btnReturn.Click += (sender, e) => AddRow();
            btnRowDelete.ButtonClick += DeleteRow;
            ReturnView.RowCellStyle += ChangeColor;

            GridReturn.DoubleClick += UpdateRefund;
            tbxKwitansi.Leave += (s, a) =>
            {
                if (string.IsNullOrEmpty(tbxKwitansi.Text)) return;
                bw.RunWorkerAsync();
            };

            DataManager.DefaultParameters = new IListParameter[] {
                WhereTerm.Default(BaseControl.BranchId, "branch_id")
            };
        }

        private void UpdateRefund(object sender, EventArgs e)
        {
            var rows = ReturnView.GetSelectedRows();
            
            tbxNote.Text = string.Empty;
            tbxKwitansi.Text = ReturnView.GetRowCellValue(rows[0], "InvoiceRefNumber").ToString();
            tbxNote.Text = ReturnView.GetRowCellValue(rows[0], "Note") != null ? ReturnView.GetRowCellValue(rows[0], "Note").ToString() : string.Empty;
        }

        private void DeleteRow(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!btnReturn.Enabled) return;
            var dialog = MessageForm.Ask(form, Resources.delete_confirm, Resources.delete_confirm_msg);
            if (dialog == DialogResult.Yes)
            {
                var rowHandle = ReturnView.FocusedRowHandle;
                if (ReturnView.GetRowCellValue(rowHandle, ReturnView.Columns["Id"]) != null) DeletedRows.Add((int)ReturnView.GetRowCellValue(rowHandle, ReturnView.Columns["Id"]), ReturnView.GetRowCellValue(rowHandle, ReturnView.Columns["PayType"]).ToString());
                ReturnView.DeleteSelectedRows();
            }
        }

        private void AddRow()
        {
            if (tbxKwitansi.Text == string.Empty)
            {
                tbxKwitansi.Focus();
                return;
            }

            var invoice = new PaymentInDetailDataManager().GetFirst<PaymentInDetailModel>(
                    new IListParameter[]
                    {
                        WhereTerm.Default(tbxKwitansi.Text, "invoice_ref_number", EnumSqlOperator.Equals),
                        WhereTerm.Default(true, "use_pph23")
                    }
                );
            if (invoice == null)
            {
                var otherInvoice = new OtherInvoicePaymentInDetailDataManager().GetFirst<OtherInvoicePaymentInDetailModel>(
                    new IListParameter[]
                    { 
                        WhereTerm.Default(tbxKwitansi.Text, "invoice_ref_number", EnumSqlOperator.Equals),
                        WhereTerm.Default(true, "use_pph23")
                    }
                );

                if (otherInvoice == null)
                {
                    MessageBox.Show(@"No Kwitansi tidak dikenali atau sudah pernah di terima pengembalian bukti Pph23", Resources.information,
                                MessageBoxButtons.OK);
                    return;
                }

                invoice = new PaymentInDetailModel
                {
                    Id = otherInvoice.Id,
                    IsReturn = otherInvoice.IsReturn,
                    InvoiceRefNumber = otherInvoice.InvoiceRefNumber,
                    InvoiceTotal = otherInvoice.InvoiceTotal,
                    TotalPph23 = otherInvoice.TotalPph23,
                    StateChange = EnumStateChange.Idle,
                    PayType = 2
                };
            }
            else invoice.PayType = 1;

            Detail(invoice);

            tbxKwitansi.Clear();
            tbxNote.Clear();
            tbxKwitansi.Focus();
        }

        private void Detail(PaymentInDetailModel invoice)
        {
            var invoices = GridReturn.DataSource as List<PaymentInDetailModel>;

            if (invoice.IsReturn)
            {
                MessageBox.Show(@"No Kwitansi sudah ada bukti pengembalian Pph23.", Resources.information,
                            MessageBoxButtons.OK);
                return;
            }

            if (ReturnView.RowCount > 0)
            {
                if (invoices.FirstOrDefault(b => b.InvoiceRefNumber == tbxKwitansi.Text) != null)
                {
                    for (int i = 0; i < ReturnView.DataRowCount; i++)
                    {
                        object b = ReturnView.GetRowCellValue(i, "InvoiceRefNumber");
                        if (b != null && b.Equals(tbxKwitansi.Text))
                        {
                            ReturnView.FocusedRowHandle = i;
                            ReturnView.SetRowCellValue(i, ReturnView.Columns["StateChange"], EnumStateChange.Update);

                            ReturnView.SetRowCellValue(i, ReturnView.Columns["IsReturn"], true);
                            ReturnView.SetRowCellValue(i, ReturnView.Columns["Note"], tbxNote.Text);
                        }
                    }

                    ReturnView.RefreshData();
                    return;
                }
            }

            invoice.Note = tbxNote.Text;
            invoice.StateChange = EnumStateChange.Update;

            if (invoices == null) invoices = new List<PaymentInDetailModel>();
            invoices.Add(invoice);
            GridReturn.DataSource = invoices;

            ReturnView.RefreshData();
            ReturnView.FocusedRowHandle = ReturnView.RowCount - 1;
        }

        private void ChangeColor(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                if (view != null && view.GetRowCellValue(e.RowHandle, view.Columns["PayType"]).ToString().Equals("2"))
                {
                    //e.Appearance.BackColor = Color.Salmon;
                    //e.Appearance.BackColor2 = Color.SeaShell;
                    e.Appearance.ForeColor = Color.Red;
                }

                if (view != null && view.GetRowCellValue(e.RowHandle, view.Columns["PayType"]).ToString().Equals("1"))
                {
                    //e.Appearance.BackColor = Color.SeaGreen;
                    //e.Appearance.BackColor2 = Color.SeaShell;
                    e.Appearance.ForeColor = Color.Black;
                }
            }
        }

        private void RefundPph23Load(object sender, EventArgs e)
        {
            EnableBtnSearch = true;
            SearchPopup = new RefundFilterPopup();

            ReturnView.CustomColumnDisplayText += NumberGrid;

            EnableBtnSearch = true;
            EnableBtnPrint = false;
            EnableBtnPrintPreview = false;
        }

        public override void New()
        {
            base.New();

            ClearForm();
            ToolbarCode = string.Empty;
            StateChange = EnumStateChange.Insert;
            GridReturn.DataSource = null;
            ReturnView.RefreshData();

            DeletedRows = new Dictionary<int, string>();

            tbxCalendar.Enabled = false;
            tbxCalendar.Properties.Buttons[0].Enabled = false;
            btnReturn.Enabled = true;

            tbxCalendar.Value = DateTime.Now;
            tbxKwitansi.Focus();
        }

        public override void Save()
        {
            if (ReturnView.RowCount == 0)
            {
                MessageForm.Info(form, Resources.title_save_changes, Resources.stt_detail_empty);
                tbxKwitansi.Focus();
                tbxKwitansi.Clear();
                return;
            }

            // ReSharper disable once RedundantAssignment
            var refund = CurrentModel as RefundPph23Model;
            if (CurrentModel.Id == 0)
            {
                if (tbxCalendar.Text != "")
                    Code = GetCode("refundpph23", tbxCalendar.Value);
            }
            else
            {
                refund = new RefundPph23DataManager().GetFirst<RefundPph23Model>(WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.Equals));
                Code = refund.Code;
            }

            base.Save();
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            form.Enabled = false;
            var refund = new RefundPph23DataManager().GetFirst<RefundPph23Model>(WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.Equals));
            Code = refund.Code;

            StateChange = EnumStateChange.Select;
            for (int i = 0; i < ReturnView.RowCount; i++)
            {
                int rowHandle = ReturnView.GetVisibleRowHandle(i);
                if (ReturnView.IsDataRow(rowHandle))
                {
                    var state = ReturnView.GetRowCellValue(rowHandle, ReturnView.Columns["StateChange"]);

                    if (state.ToString().Equals(EnumStateChange.Update.ToString()))
                    {
                        if (ReturnView.GetRowCellValue(rowHandle, ReturnView.Columns["PayType"]).ToString() == "1")
                        {
                            var rec = new PaymentInDetailDataManager().GetFirst<PaymentInDetailModel>(WhereTerm.Default((int)ReturnView.GetRowCellValue(rowHandle, ReturnView.Columns["Id"]), "id", EnumSqlOperator.Equals));
                            if (rec != null)
                            {
                                rec.DateReturn = refund.DateProcess;
                                rec.IsReturn = true;
                                rec.RefundId = refund.Id;
                                rec.Note = ReturnView.GetRowCellValue(rowHandle, ReturnView.Columns["Note"]).ToString();
                                rec.Modifiedby = BaseControl.UserLogin;
                                rec.Modifieddate = DateTime.Now;

                                new PaymentInDetailDataManager().Update<PaymentInDetailModel>(rec);
                            }
                        }
                        else
                        {
                            var rec = new OtherInvoicePaymentInDetailDataManager().GetFirst<OtherInvoicePaymentInDetailModel>(WhereTerm.Default((int)ReturnView.GetRowCellValue(rowHandle, ReturnView.Columns["Id"]), "id", EnumSqlOperator.Equals));
                            if (rec != null)
                            {
                                rec.DateReturn = refund.DateProcess;
                                rec.IsReturn = true;
                                rec.RefundId = refund.Id;
                                rec.Note = ReturnView.GetRowCellValue(rowHandle, ReturnView.Columns["Note"]).ToString();
                                rec.Modifiedby = BaseControl.UserLogin;
                                rec.Modifieddate = DateTime.Now;

                                new OtherInvoicePaymentInDetailDataManager().Update<OtherInvoicePaymentInDetailModel>(rec);
                            }
                        }
                    }
                }
            }

            foreach (var o in DeletedRows)
            {
                if (o.Value.Equals("1"))
                {
                    var data = new PaymentInDetailDataManager().GetFirst<PaymentInDetailModel>(WhereTerm.Default(o.Key, "id", EnumSqlOperator.Equals));
                    if (data != null)
                    {
                        data.IsReturn = false;
                        data.DateReturn = null;
                        data.Note = string.Empty;
                        data.RefundId = null;
                        new PaymentInDetailDataManager().Update<PaymentInDetailModel>(data);
                    }
                }
                else
                {
                    var data = new OtherInvoicePaymentInDetailDataManager().GetFirst<OtherInvoicePaymentInDetailModel>(WhereTerm.Default(o.Key, "id", EnumSqlOperator.Equals));
                    if (data != null)
                    {
                        data.IsReturn = false;
                        data.DateReturn = null;
                        data.Note = string.Empty;
                        data.RefundId = null;
                        new OtherInvoicePaymentInDetailDataManager().Update<OtherInvoicePaymentInDetailModel>(data);
                    }
                }
            }

            Enabled = true;
            ToolbarCode = refund.Code;
        }

        protected override void AfterSave()
        {
            OpenData(ToolbarCode);
            tsBaseTxt_Code.Focus();
        }

        public override void AfterDelete()
        {
            var detail = new PaymentInDetailDataManager().Get<PaymentInDetailModel>(WhereTerm.Default(CurrentModel.Id, "refund_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new PaymentInDetailDataManager();
                foreach (PaymentInDetailModel obj in detail)
                {
                    obj.IsReturn = false;
                    obj.DateReturn = null;
                    obj.Note = string.Empty;
                    obj.RefundId = null;

                    repo.Update<PaymentInDetailModel>(obj);
                }
            }

            var others = new OtherInvoicePaymentInDetailDataManager().Get<OtherInvoicePaymentInDetailModel>(WhereTerm.Default(CurrentModel.Id, "refund_id"));
            if (others != null)
            {
                var repoOther = new OtherInvoicePaymentInDetailDataManager();
                foreach(var obj in others)
                {
                    obj.IsReturn = false;
                    obj.DateReturn = null;
                    obj.Note = string.Empty;
                    obj.RefundId = null;

                    repoOther.Update<OtherInvoicePaymentInDetailModel>(obj);
                }
            }

            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override void PopulateForm(RefundPph23Model model)
        {
            ClearForm();
            if (model == null) return;

            DeletedRows = new Dictionary<int, string>();
            EnableBtnPrint = false;
            EnableBtnPrintPreview = false;

            tbxCalendar.Enabled = false;
            tbxCalendar.Properties.Buttons[0].Enabled = false;

            ToolbarCode = model.Code;
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxCalendar.DateTime = model.DateProcess;

            var details =
                new PaymentInDetailDataManager().Get<PaymentInDetailModel>(WhereTerm.Default(model.Id,
                    "refund_id", EnumSqlOperator.Equals)).ToList();

            var others = new OtherInvoicePaymentInDetailDataManager().Get<OtherInvoicePaymentInDetailModel>(WhereTerm.Default(model.Id, "refund_id"));
            foreach(var o in others)
            {
                details.Add(new PaymentInDetailModel
                    {
                        Id = o.Id,
                        IsReturn = o.IsReturn,
                        InvoiceRefNumber = o.InvoiceRefNumber,
                        InvoiceTotal = o.InvoiceTotal,
                        TotalPph23 = o.TotalPph23,
                        Note = o.Note,
                        StateChange = EnumStateChange.Idle,
                        PayType = 2
                    });
            }

            GridReturn.DataSource = details;
            //ConsolidationView.RefreshData();
            tsBaseTxt_Code.Focus();
        }

        protected override RefundPph23Model PopulateModel(RefundPph23Model model)
        {
            model.DateProcess = tbxCalendar.Value;
            model.Code = Code;
            model.BranchId = BaseControl.BranchId;

            if (model.Id == 0)
            {
                model.Createdpc = Environment.MachineName;
            }
            else model.Modifiedpc = Environment.MachineName;

            return model;
        }

        protected override RefundPph23Model Find(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm)) tsBaseTxt_Code.Text = searchTerm;
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<RefundPph23Model>(param);
            PopulateForm(obj);

            return obj;
        }

        public override void Info()
        {
            var model = CurrentModel as RefundPph23Model;

            if (model != null)
            {
                info.CreatedPc = model.Createdpc;
                info.ModifiedPc = model.Modifiedpc;
            }

            base.Info();
        }

        private void bw_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (tbxKwitansi.Text == string.Empty)
            {
                return;
            }

            var invoice = new PaymentInDetailDataManager().GetFirst<PaymentInDetailModel>(
                    new IListParameter[]
                    {
                        WhereTerm.Default(tbxKwitansi.Text, "invoice_ref_number", EnumSqlOperator.Equals),
                        WhereTerm.Default(true, "use_pph23")
                    }
                );
            if (invoice == null)
            {
                var otherInvoice = new OtherInvoicePaymentInDetailDataManager().GetFirst<OtherInvoicePaymentInDetailModel>(
                    new IListParameter[]
                    { 
                        WhereTerm.Default(tbxKwitansi.Text, "invoice_ref_number", EnumSqlOperator.Equals),
                        WhereTerm.Default(true, "use_pph23")
                    }
                );

                if (otherInvoice == null)
                {
                    bw.ReportProgress(100, "No Kwitansi tidak dikenali atau sudah pernah di terima pengembalian bukti Pph23");
                    return;
                }
            }
        }

        private void bw_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.UserState.ToString()))
            {
                MessageBox.Show("No Kwitansi tidak dikenali atau sudah pernah di terima pengembalian bukti Pph23.");
                tbxKwitansi.SelectAll();
                tbxKwitansi.Focus();
            }
        }
    }
}
