using Devenlab.Common;
using DevExpress.XtraGrid.Views.Grid;
using SISCO.App.Finance;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Finance.Popup
{
    public partial class TransactionalModificationPopup : BaseForm
    {
        public TransactionalAccountModel transaction { get; set; }
        private DateTime startDate { get; set; }
        public TransactionalModificationPopup()
        {
            InitializeComponent();
            form = this;

            Load += ModifiedBankAccountPopup_Load;
            Shown += ModifiedBankAccountPopup_Shown;
        }

        void ModifiedBankAccountPopup_Shown(object sender, EventArgs e)
        {
            GridTransaction.DataSource = new TransactionalAccountDataManager().GetTransactionRevisionList(transaction);
            TransactionView.RefreshData();

            startDate = transaction.DateProcess;
        }

        void ModifiedBankAccountPopup_Load(object sender, EventArgs e)
        {
            TransactionView.RowCellStyle += TransactionView_RowCellStyle;
            TransactionView.CellValueChanged += TransactionView_CellValueChanged;
            TransactionView.ShowingEditor += TransactionView_ShowingEditor;
            TransactionView.Columns["DateProcess"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            TransactionView.RowUpdated += TransactionView_RowUpdated;
            btnClose.Click += (s, ar) => Close();
            btnSave.Click += btnSave_Click;
        }

        void TransactionView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            AfterUpdate();
        }

        void AfterUpdate()
        {
            var balance = new TransactionalAccountDataManager().GetBankBalance(transaction.BankAccountId, startDate);
            for (var i = 0; i < TransactionView.RowCount; i++)
            {
                var date = (DateTime)TransactionView.GetRowCellValue(i, TransactionView.Columns[1]);
                if (DateTime.Compare(date, startDate) >= 0)
                {
                    var debit = (decimal)TransactionView.GetRowCellValue(i, TransactionView.Columns["DebitTotalAmount"]);
                    var credit = (decimal)TransactionView.GetRowCellValue(i, TransactionView.Columns["CreditTotalAmount"]);
                    balance = (balance + credit) - debit;

                    TransactionView.SetRowCellValue(i, TransactionView.Columns["Balance"], balance);
                    TransactionView.SetRowCellValue(i, TransactionView.Columns["StateChange"], EnumStateChange.Update.ToString());

                    if ((bool)TransactionView.GetRowCellValue(i, TransactionView.Columns["IsModify"]))
                    {
                        transaction.DateProcess = (DateTime)TransactionView.GetRowCellValue(i, TransactionView.Columns[1]);
                        transaction.Description = TransactionView.GetRowCellValue(i, TransactionView.Columns["Description"]).ToString();
                        transaction.DebitTotalAmount = debit;
                        transaction.CreditTotalAmount = credit;
                    }
                }
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            new TransactionalAccountDataManager().TransactionalRevision(transaction.Id, transaction.Description, transaction.DateProcess,
            transaction.DebitTotalAmount, transaction.CreditTotalAmount, startDate, BaseControl.UserLogin);

            Close();
        }

        void TransactionView_ShowingEditor(object sender, CancelEventArgs e)
        {
            var view = sender as GridView;
            if (view.FocusedColumn.FieldName == "Balance")
                e.Cancel = true;
        }

        void TransactionView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            switch (e.Column.Caption)
            {
                case "Debit" :
                    if ((decimal)TransactionView.GetRowCellValue(e.RowHandle, TransactionView.Columns["DebitTotalAmount"]) > 0)
                    {
                        TransactionView.SetRowCellValue(e.RowHandle, TransactionView.Columns["CreditTotalAmount"], 0);
                        TransactionView.RefreshData();
                    }
                    break;
                case "Kredit":
                    if ((decimal)TransactionView.GetRowCellValue(e.RowHandle, TransactionView.Columns["CreditTotalAmount"]) > 0)
                    {
                        TransactionView.SetRowCellValue(e.RowHandle, TransactionView.Columns["DebitTotalAmount"], 0);
                        TransactionView.RefreshData();
                    }
                    break;
                case "Tgl":
                case "Jam":    
                    var date = (DateTime)TransactionView.GetRowCellValue(e.RowHandle, TransactionView.Columns[1]);
                    if (DateTime.Compare(startDate, date) > 0) startDate = date;
                    TransactionView.RefreshData();
                    break;
            }
        }

        void TransactionView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;

                e.Appearance.BackColor = Color.Transparent;
                e.Appearance.ForeColor = Color.Black;
                
                if (view != null && (bool)view.GetRowCellValue(e.RowHandle, view.Columns["IsModify"]))
                {
                    //e.Appearance.ForeColor = Color.Red;
                    e.Column.OptionsColumn.AllowEdit = true;
                    e.Column.OptionsColumn.AllowFocus = true;
                    e.Column.OptionsColumn.ReadOnly = false;

                    TransactionView.FocusedRowHandle = e.RowHandle;
                }
            }
        }
    }
}
