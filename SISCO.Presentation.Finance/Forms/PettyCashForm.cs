using Devenlab.Common;
using SISCO.App.Finance;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using SISCO.Presentation.MasterData.Popup;
using SISCO.App.MasterData;
using Devenlab.Common.Interfaces;
using SISCO.Presentation.Finance.Popup;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class PettyCashForm : BaseCrudForm<PettyCashModel, PettyCashDataManager>//BaseToolbarForm//
    {
        private int? _id { get; set; }
        private List<int> DeletedId { get; set; }

        public PettyCashForm()
        {
            InitializeComponent();
            form = this;

            Load += PettyCashForm_Load;
            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id") };
        }

        void PettyCashForm_Load(object sender, EventArgs e)
        {
            JournalView.CustomColumnDisplayText += NumberGrid;
            EnableBtnSearch = true;
            SearchPopup = new PettyCashFilterPopup();

            lkpEmployee.LookupPopup = new EmployeePopup();
            lkpEmployee.AutoCompleteDataManager = new EmployeeDataManager();
            lkpEmployee.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            lkpEmployee.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);

            btnAdd.Click += btnAdd_Click;
            tbxDebit.KeyPress += tbxDebit_KeyPress;
            tbxCredit.KeyPress += tbxCredit_KeyPress;

            btnDelete.Click += btnDelete_Click;
            JournalView.DoubleClick += JournalView_DoubleClick;
        }

        void JournalView_DoubleClick(object sender, EventArgs e)
        {
            var row = JournalView.GetSelectedRows();
            
            tbxDate.DateTime = (DateTime)JournalView.GetRowCellValue(row[0], JournalView.Columns["DateProcess"]);
            tbxDebit.Value = (decimal)JournalView.GetRowCellValue(row[0], JournalView.Columns["DebitAmount"]);
            tbxCredit.Value = (decimal)JournalView.GetRowCellValue(row[0], JournalView.Columns["CreditAmount"]);
            lkpEmployee.DefaultValue = new IListParameter[] { WhereTerm.Default((int)JournalView.GetRowCellValue(row[0], JournalView.Columns["PaidReceivedBy"]), "id") };

            if (JournalView.GetRowCellValue(row[0], JournalView.Columns["StateChange"]).ToString().Equals(EnumStateChange.Insert))
            {
                _id = null;
                JournalView.DeleteSelectedRows();
            }
            else _id = row[0];
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            var row = JournalView.GetSelectedRows();
            if ((int)JournalView.GetRowCellValue(row[0], JournalView.Columns["Id"]) > 0)
                DeletedId.Add((int)JournalView.GetRowCellValue(row[0], JournalView.Columns["Id"]));

            JournalView.DeleteSelectedRows();
        }

        void tbxCredit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tbxCredit.Value > 0) tbxDebit.Value = 0;
        }

        void tbxDebit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tbxDebit.Value > 0) tbxCredit.Value = 0;
        }

        public override void New()
        {
            ClearForm();
            base.New();

            GridJournal.DataSource = new List<PettyCashDetailJournalModel>();
            JournalView.RefreshData();

            tbxDate.DateTime = DateTime.Now;
            tbxDescription.Focus();

            tbxBalance.Enabled = false;
            _id = null;

            DeletedId = new List<int>();
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbxDate.Text == "")
            {
                tbxDate.Focus();
                return;
            }

            if (tbxDebit.Value == 0 && tbxCredit.Value == 0)
            {
                tbxDebit.Focus();
                return;
            }

            if (lkpEmployee.Value == null)
            {
                lkpEmployee.Focus();
                return;
            }

            var journals = GridJournal.DataSource as List<PettyCashDetailJournalModel>;

            if (_id == null)
            {
                journals.Add(new PettyCashDetailJournalModel
                {
                    Id = 0,
                    DateProcess = tbxDate.DateTime,
                    DebitAmount = tbxDebit.Value,
                    CreditAmount = tbxCredit.Value,
                    PaidReceivedBy = (int)lkpEmployee.Value,
                    EmployeeName = lkpEmployee.Text,
                    StateChange = EnumStateChange.Insert.ToString()
                });

                GridJournal.DataSource = journals;
                JournalView.RefreshData();
            }
            else
            {
                JournalView.SetRowCellValue((int)_id, JournalView.Columns["DateProcess"], tbxDate.DateTime);
                JournalView.SetRowCellValue((int)_id, JournalView.Columns["DebitAmount"], tbxDebit.Value);
                JournalView.SetRowCellValue((int)_id, JournalView.Columns["CreditAmount"], tbxCredit.Value);
                JournalView.SetRowCellValue((int)_id, JournalView.Columns["PaidReceivedBy"], lkpEmployee.Value);
                JournalView.SetRowCellValue((int)_id, JournalView.Columns["EmployeeName"], lkpEmployee.Text);
                JournalView.SetRowCellValue((int)_id, JournalView.Columns["StateChange"], EnumStateChange.Update.ToString());
            }

            tbxDate.DateTime = DateTime.Now;
            tbxDebit.Value = 0;
            tbxCredit.Value = 0;
            lkpEmployee.Text = string.Empty;
            lkpEmployee.Value = null;

            tbxDebit.Focus();
            tbxBalance.Value = Balance;

            _id = null;
        }

        protected override bool ValidateForm()
        {
            if (string.IsNullOrEmpty(tbxDescription.Text))
            {
                tbxDescription.Focus();
                return false;
            }

            if (JournalView.RowCount == 0)
            {
                tbxDate.Focus();
                return false;
            }

            return true;
        }

        protected override void PopulateForm(PettyCashModel model)
        {
            ClearForm();
            if (model == null) return;

            ToolbarCode = model.Code;
            tbxDescription.Text = model.Description;

            GridJournal.DataSource = new PettyCashJournalDataManager().GetJournals(model.Id);
            JournalView.RefreshData();

            tbxDate.DateTime = DateTime.Now;
            tbxDate.Focus();

            tbxBalance.Value = Balance;
            tbxBalance.Enabled = false;

            _id = null;
            DeletedId = new List<int>();
        }

        decimal Balance
        {
            get
            {
                if (JournalView.RowCount > 0)
                {
                    var journal = GridJournal.DataSource as List<PettyCashDetailJournalModel>;
                    var credit = journal.Sum(p => p.CreditAmount);
                    var debit = journal.Sum(p => p.DebitAmount);

                    return credit - debit;
                }

                return 0;
            }
        }

        protected override PettyCashModel PopulateModel(PettyCashModel model)
        {
            model.BranchId = BaseControl.BranchId;
            model.Description = tbxDescription.Text;
            if (model.Id == 0) model.Code = GetCode("pettycash", DateTime.Now);

            return model;
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            for (var i = 0; i < JournalView.RowCount; i++)
            {
                if (JournalView.GetRowCellValue(i, JournalView.Columns["StateChange"]).ToString().Equals(EnumStateChange.Insert.ToString()))
                {
                    var journals = new PettyCashJournalModel();
                    journals.PettyCashId = CurrentModel.Id;
                    journals.Rowstatus = true;
                    journals.Rowversion = DateTime.Now;
                    journals.DateProcess = (DateTime)JournalView.GetRowCellValue(i, JournalView.Columns["DateProcess"]);
                    journals.DebitAmount= (decimal)JournalView.GetRowCellValue(i, JournalView.Columns["DebitAmount"]);
                    journals.CreditAmount = (decimal)JournalView.GetRowCellValue(i, JournalView.Columns["CreditAmount"]);
                    journals.PaidReceivedBy = (int)JournalView.GetRowCellValue(i, JournalView.Columns["PaidReceivedBy"]);
                    journals.Createddate = DateTime.Now;
                    journals.Createdby = BaseControl.UserLogin;

                    new PettyCashJournalDataManager().Save<PettyCashJournalModel>(journals);
                }
                else if (JournalView.GetRowCellValue(i, JournalView.Columns["StateChange"]).ToString().Equals(EnumStateChange.Update.ToString()))
                {
                    var journals = new PettyCashJournalDataManager().GetFirst<PettyCashJournalModel>(WhereTerm.Default(
                        (int)JournalView.GetRowCellValue(i, JournalView.Columns["Id"]), "id"));

                    journals.DateProcess = (DateTime)JournalView.GetRowCellValue(i, JournalView.Columns["DateProcess"]);
                    journals.DebitAmount = (decimal)JournalView.GetRowCellValue(i, JournalView.Columns["DebitAmount"]);
                    journals.CreditAmount = (decimal)JournalView.GetRowCellValue(i, JournalView.Columns["CreditAmount"]);
                    journals.PaidReceivedBy = (int)JournalView.GetRowCellValue(i, JournalView.Columns["PaidReceivedBy"]);
                    journals.Modifieddate = DateTime.Now;
                    journals.Modifiedby = BaseControl.UserLogin;

                    new PettyCashJournalDataManager().Update<PettyCashJournalModel>(journals);
                }
            }

            foreach (var d in DeletedId)
                new PettyCashJournalDataManager().DeActive(d, BaseControl.UserLogin, DateTime.Now);

            ToolbarCode = ((PettyCashModel)CurrentModel).Code;
        }

        protected override void AfterSave()
        {
            OpenData(ToolbarCode);
            tsBaseTxt_Code.Focus();
        }

        public override void AfterDelete()
        {
            var journals = new PettyCashJournalDataManager().Get<PettyCashJournalModel>(WhereTerm.Default(CurrentModel.Id, "petty_cash_id"));
            foreach (var j in journals)
                new PettyCashJournalDataManager().DeActive(j.Id, BaseControl.UserLogin, DateTime.Now);

            base.AfterDelete();
        }

        protected override PettyCashModel Find(string searchTerm)
        {
            return new PettyCashDataManager().GetFirst<PettyCashModel>(WhereTerm.Default(searchTerm, "code", EnumSqlOperator.Equals));
        }
    }
}