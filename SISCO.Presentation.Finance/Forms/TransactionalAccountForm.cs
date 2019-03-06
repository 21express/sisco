using Devenlab.Common;
using SISCO.App.Finance;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class TransactionalAccountForm : BaseForm
    {
        public TransactionalAccountForm()
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

            tbxFrom.EditValue = DateTime.Now.AddDays(-1);
            tbxTo.EditValue = DateTime.Now;

            lkpAccount.Leave += lkpAccount_Leave;
            btnShow.Click += btnShow_Click;
        }

        void btnShow_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        void lkpAccount_Leave(object sender, EventArgs e)
        {
            Clear();

            if (lkpAccount.Value != null)
            {
                var bank = new BankAccountDataManager().GetFirst<BankAccountModel>(WhereTerm.Default((int)lkpAccount.Value, "id"));

                lblName.Text = bank.AccountName;
                lblAddress.Text = bank.AccountAddress;
                lblNo.Text = bank.AccountNo;
                lblBank.Text = bank.BankName;
                lblKcp.Text = bank.BranchName;

                RefreshGrid();
            }
        }

        void RefreshGrid()
        {
            if (lkpAccount.Value != null)
            {
                GridTransactional.DataSource = new TransactionalAccountDataManager().GetDetails((int)lkpAccount.Value, tbxFrom.DateTime, tbxTo.DateTime);
                TransactionalView.RefreshData();
            }
            else
            {
                GridTransactional.DataSource = new List<TransactionalAccountModel>();
                TransactionalView.RefreshData();
            }

            TransactionalView.FocusedRowHandle = TransactionalView.RowCount - 1;
        }
    }
}
