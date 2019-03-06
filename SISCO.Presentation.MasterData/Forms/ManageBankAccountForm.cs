using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManageBankAccountForm : BaseCrudForm<BankAccountModel, BankAccountDataManager>//BaseToolbarForm//
    {
        public ManageBankAccountForm()
        {
            InitializeComponent();
            form = this;

            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id") };
        }

        protected override bool ValidateForm()
        {
            if (string.IsNullOrEmpty(tbxNo.Text))
            {
                tbxNo.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbxBank.Text))
            {
                tbxBank.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbxKcp.Text))
            {
                tbxKcp.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbxAn.Text))
            {
                tbxAn.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbxAlamat.Text))
            {
                tbxAlamat.Focus();
                return false;
            }

            return true;
        }

        public override void New()
        {
            base.New();

            ClearForm();
            tbxNo.Focus();
        }

        protected override void AfterSave()
        {
            OpenData(((BankAccountModel)CurrentModel).AccountNo);
        }

        protected override void PopulateForm(BankAccountModel model)
        {
            ClearForm();
            if (model == null) return;

            ToolbarCode = model.AccountNo;
            tbxNo.Text = model.AccountNo;
            tbxBank.Text = model.BankName;
            tbxKcp.Text = model.BranchName;
            tbxAn.Text = model.AccountName;
            tbxAlamat.Text = model.AccountAddress;
        }

        protected override BankAccountModel PopulateModel(BankAccountModel model)
        {
            model.BranchId = BaseControl.BranchId;
            model.AccountNo = tbxNo.Text;
            model.BankName = tbxBank.Text;
            model.BranchName = tbxKcp.Text;
            model.AccountName = tbxAn.Text;
            model.AccountAddress = tbxAlamat.Text;

            return model;
        }

        protected override BankAccountModel Find(string searchTerm)
        {
            return DataManager.GetFirst<BankAccountModel>(WhereTerm.Default(searchTerm, "account_no", EnumSqlOperator.Equals));
        }
    }
}