using Devenlab.Common;
using SISCO.App.Finance;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Finance.Popup;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class InputTransactionalAccountForm : BaseForm
    {
        private BankAccountModel _bank { get; set; }
        public InputTransactionalAccountForm()
        {
            InitializeComponent();
            form = this;

            Load += TransactionalAccountForm_Load;
        }

        void Clear()
        {
            lblName.Text = "Rekening Atas Nama :";
            lblAddress.Text = "Alamat :";
            lblNo.Text = "No. Rekening :";
            lblBank.Text = "Nama Bank :";
            lblKcp.Text = "Kantor Cabang Pembantu :";

            _bank = new BankAccountModel();
            GridTransactional.DataSource = new List<TransactionalAccountModel>();
            TransactionalView.RefreshData();
        }

        void TransactionalAccountForm_Load(object sender, EventArgs e)
        {
            Clear();

            lkpAccount.LookupPopup = new BankAccountPopup();
            lkpAccount.AutoCompleteDataManager = new BankAccountDataManager();
            lkpAccount.AutoCompleteDisplayFormater = model => ((BankAccountModel)model).AccountNo + " " + ((BankAccountModel)model).BankName;
            lkpAccount.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("account_no.StartsWith(@0) and branch_id = @1", s, BaseControl.BranchId);
            
            lkpAccount.Leave += lkpAccount_Leave;
            btnAdd.Click += btnAdd_Click;
            tbxDebit.TextChanged += tbxDebit_TextChanged;
            tbxCredit.TextChanged += tbxCredit_TextChanged;

            TransactionalView.DoubleClick += TransactionalView_DoubleClick;
            btnFilter.Click += btnFilter_Click;
        }

        void btnFilter_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        void TransactionalView_DoubleClick(object sender, EventArgs e)
        {
            var rows = TransactionalView.GetSelectedRows();
            var id = (int)TransactionalView.GetRowCellValue(rows[0], "Id");

            if (id > 0)
            {
                var currentRow = new TransactionalAccountDataManager().GetFirst<TransactionalAccountModel>(WhereTerm.Default(id, "id"));
                if (currentRow != null)
                {
                    if (currentRow.ClosedDate == null)
                    {
                        var popup = new TransactionalModificationPopup();
                        popup.transaction = currentRow;
                        popup.ShowDialog();

                        RefreshGrid();
                        TransactionalView.FocusedRowHandle = rows[0];
                    }
                    else
                        MessageBox.Show("Transaksi sudah di validasi.");
                }
            }
        }

        void tbxCredit_TextChanged(object sender, EventArgs e)
        {
            if (tbxCredit.Value > 0) tbxDebit.Value = 0;
        }

        void tbxDebit_TextChanged(object sender, EventArgs e)
        {
            if (tbxDebit.Value > 0) tbxCredit.Value = 0;
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            if (_bank.Id > 0)
            {
                if (string.IsNullOrEmpty(tbxDate.Text) || (tbxDebit.Value <= 0 && tbxCredit.Value <= 0))
                {
                    MessageBox.Show("Silakan lengkapi transaksinya");
                    tbxDate.Focus();
                }
                else
                {
                    var transactional = new TransactionalAccountModel
                    {
                        BankAccountId = (int) lkpAccount.Value,
                        DateProcess = tbxDate.DateTime,
                        Description = tbxDescription.Text,
                        DebitTotalAmount = tbxDebit.Value,
                        CreditTotalAmount = tbxCredit.Value
                    };

                    new TransactionalAccountDataManager().AddTransaction(transactional, BaseControl.UserLogin);
                    RefreshGrid();

                    TransactionalView.FocusedRowHandle = TransactionalView.RowCount - 1;
                }
            }
            else lkpAccount.Focus();

            tbxDate.DateTime = tbxDate.DateTime.AddSeconds(5);
            tbxDescription.Clear();
            tbxDebit.Value = 0;
            tbxCredit.Value = 0;
            tbxDescription.Focus();
        }

        void lkpAccount_Leave(object sender, EventArgs e)
        {
            Clear();

 	        if (lkpAccount.Value != null) {
                _bank = new BankAccountDataManager().GetFirst<BankAccountModel>(WhereTerm.Default((int)lkpAccount.Value, "id"));

                lblName.Text = _bank.AccountName;
                lblAddress.Text = _bank.AccountAddress;
                lblNo.Text = _bank.AccountNo;
                lblBank.Text = _bank.BankName;
                lblKcp.Text = _bank.BranchName;

                RefreshGrid();

                TransactionalView.FocusedRowHandle = TransactionalView.RowCount - 1;

                tbxDate.EditValue = DateTime.Now;
                tbxDescription.Focus();
            }
        }

        void RefreshGrid()
        {
            if (_bank.Id > 0)
            {
                GridTransactional.DataSource = new TransactionalAccountDataManager().GetDetails(_bank.Id, tbxFilter.DateTime, tbxFilter.DateTime);
                TransactionalView.RefreshData();
            }
            else
            {
                GridTransactional.DataSource = new List<TransactionalAccountModel>();
                TransactionalView.RefreshData();
            }
        }
    }
}