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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManageBankAccountBranchForm : BaseForm
    {
        public ManageBankAccountBranchForm()
        {
            InitializeComponent();
            form = this;

            Load += BankAccountBranchForm_Load;
        }

        void BankAccountBranchForm_Load(object sender, EventArgs e)
        {
            ClearForm();

            clbBranch.Items.Clear();
            clbBranch.DisplayMember = "Text";
            clbBranch.ValueMember = "Value";

            lkpAccount.LookupPopup = new BankAccountPopup();
            lkpAccount.AutoCompleteDataManager = new BankAccountDataManager();
            lkpAccount.AutoCompleteDisplayFormater = model => ((BankAccountModel)model).AccountNo + " " + ((BankAccountModel)model).BankName;
            lkpAccount.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("account_no.StartsWith(@0) and branch_id = @1", s, BaseControl.BranchId);

            lkpAccount.Leave += lkpAccount_Leave;
            btnSave.Click += btnSave_Click;
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            if (lkpAccount.Value == null)
            {
                lkpAccount.Focus();
                return;
            }

            new BankAccountBranchDataManager().Reupdate((int)lkpAccount.Value);
            foreach (var item in clbBranch.CheckedItems)
            {
                new BankAccountBranchDataManager().SaveChanges((int)lkpAccount.Value, ((BranchSelection)item).Value, BaseControl.UserLogin);
            }

            RefreshBranch();
        }

        void lkpAccount_Leave(object sender, EventArgs e)
        {
            RefreshBranch();
        }

        void RefreshBranch()
        {
            clbBranch.Items.Clear();
            if (lkpAccount.Value != null)
            {
                var branches = new BranchDataManager().Get<BranchModel>(WhereTerm.Default(BaseControl.BranchId, "id", EnumSqlOperator.NotEqual)).OrderBy(p => p.Name);
                var branchSelection = new List<BranchSelection>();

                var bankBranches = new BankAccountBranchDataManager().Get<BankAccountBranchModel>(WhereTerm.Default((int)lkpAccount.Value, "bank_account_id"));
                var indx = 0;
                var checklist = new List<int>();
                foreach (var b in branches)
                {
                    if (b.Id != BaseControl.BranchId)
                    {
                        branchSelection.Add(new BranchSelection
                        {
                            Text = b.Name,
                            Value = b.Id
                        });

                        if (bankBranches.Count() > 0)
                        {
                            if (bankBranches.Where(p => p.BranchId == b.Id).FirstOrDefault() != null)
                                checklist.Add(indx);
                        }

                        indx++;
                    }
                }

                clbBranch.DataSource = branchSelection;

                foreach (var i in checklist)
                    clbBranch.SetItemChecked(i, true);
            }
        }
    }

    internal class BranchSelection
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }
}