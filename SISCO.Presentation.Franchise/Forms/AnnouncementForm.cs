using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.Franchise;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.Franchise.Popup;

namespace SISCO.Presentation.Franchise.Forms
{
    public partial class AnnouncementForm : BasePage
    {
        private int Id { get; set; }
        public AnnouncementForm()
        {
            InitializeComponent();
            DataManager = new RunningTextDataManager();
            form = this;
            Init();
        }

        private void Init()
        {
            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;

            ClearForm();

            tbxDateFrom.EditValue = null;
            tbxDateTo.EditValue = null;

            tbxAnnouncement.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpFranchise.LookupPopup = new FranchisePopup();
            lkpFranchise.AutoCompleteDataManager = new FranchiseDataManager();
            lkpFranchise.AutoCompleteDisplayFormater = model => ((FranchiseModel)model).Code + " " + ((FranchiseModel)model).Name;
            lkpFranchise.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code = @0 or name.StartsWith(@0)", s);

            LoadRunningText();
            _SetControlEnableState(pnlForm, false);

            AnnGrid.DoubleClick += (s, args) => Edit();
            btnNew.Click += New;
            btnSave.Click += Save;
            btnDelete.Click += Delete;
        }

        private void Edit()
        {
            var rows = AnnView.GetSelectedRows();
            ClearForm();

            if (rows.Count() > 0)
            {
                Id = (int)AnnView.GetRowCellValue(rows[0], "Id");

                if (AnnView.GetRowCellValue(rows[0], "FranchiseId") != null)
                    lkpFranchise.DefaultValue = new IListParameter[] { WhereTerm.Default((int)AnnView.GetRowCellValue(rows[0], "FranchiseId"), "id", EnumSqlOperator.Equals) };

                CurrentModel = DataManager.GetFirst<RunningTextModel>(WhereTerm.Default(Id, "id"));
                var model = CurrentModel as RunningTextModel;

                tbxDateFrom.EditValue = null;
                tbxDateTo.EditValue = null;

                if (model.FromDate != null)
                {
                    var fromDateTime = new DateTime(model.FromDate.Value.Year, model.FromDate.Value.Month,
                        model.FromDate.Value.Day, model.FromHour, model.FromMinute, 0);

                    tbxDateFrom.DateTime = fromDateTime;
                    tbxTimeFrom.Text = fromDateTime.ToString("HH:mm");
                }

                if (model.ToDate != null)
                {
                    var toDateTime = new DateTime(model.ToDate.Value.Year, model.ToDate.Value.Month,
                        model.ToDate.Value.Day, model.ToHour, model.ToMinute, 0);

                    tbxDateTo.DateTime = toDateTime;
                    tbxTimeTo.Text = toDateTime.ToString("HH:mm");
                }

                tbxAnnouncement.Text = AnnView.GetRowCellValue(rows[0], "Name").ToString();

                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                lkpFranchise.Focus();

                _SetControlEnableState(pnlForm, true);
            }
        }

        private void LoadRunningText()
        {
            List<RunningTextModel> runningText = new RunningTextDataManager().GetRunningText(WhereTerm.Default(1, "announcement_type", EnumSqlOperator.Equals));

            AnnGrid.DataSource = runningText;
            AnnGrid.Refresh();
        }

        private void Delete(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(Resources.delete_confirm_msg, Resources.delete_confirm,
                MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                ((RunningTextDataManager)DataManager).DeActive(Id, BaseControl.UserLogin, DateTime.Now);
            }

            LoadRunningText();
            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;

            ClearForm();
            lkpFranchise.Focus();
            _SetControlEnableState(pnlForm, false);
        }

        private void New(object sender, EventArgs e)
        {
            ClearForm();
            _SetControlEnableState(pnlForm, true);

            tbxDateFrom.EditValue = null;
            tbxDateTo.EditValue = null;

            tbxTimeFrom.Text = string.Empty;
            tbxTimeTo.Text = string.Empty;

            lkpFranchise.Focus();

            btnDelete.Enabled = false;
            btnSave.Enabled = true;

            Id = 0;
            CurrentModel = new RunningTextModel();
        }

        private void Save(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                MessageBox.Show(
                    Resources.alert_empty_field
                    , Resources.title_save_changes
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);

                return;
            }

            CurrentModel = PopulateModel(CurrentModel as RunningTextModel);

            using (var scope = new System.Transactions.TransactionScope())
            {
                if (CurrentModel.Id == 0)
                {
                    CurrentModel.Rowstatus = true;
                    CurrentModel.Rowversion = DateTime.Now;
                    CurrentModel.Createddate = DateTime.Now;
                    CurrentModel.Createdby = BaseControl.UserLogin;

                    ((RunningTextDataManager)DataManager).Save<RunningTextModel>(CurrentModel);
                }
                else
                {
                    ((RunningTextDataManager)DataManager).Update<RunningTextModel>(CurrentModel);
                    CurrentModel.Rowversion = DateTime.Now;
                    CurrentModel.Modifieddate = DateTime.Now;
                    CurrentModel.Modifiedby = BaseControl.UserLogin;
                }

                scope.Complete();
            }

            LoadRunningText();

            btnSave.Enabled = false;
            btnNew.Enabled = true;
            btnDelete.Enabled = false;

            ClearForm();
            _SetControlEnableState(pnlForm, false);
        }

        protected bool ValidateForm()
        {
            if (Id == 0 && string.IsNullOrEmpty(tbxAnnouncement.Text))
            {
                tbxAnnouncement.Focus();
                return false;
            }
            return true;
        }

        protected RunningTextModel PopulateModel(RunningTextModel model)
        {
            model.FranchiseId = null;
            if (lkpFranchise.Value != null)
                model.FranchiseId = lkpFranchise.Value;

            model.FromDate = null;
            model.ToDate = null;
            model.FromHour = 0;
            model.FromMinute = 0;
            model.ToHour = 0;
            model.ToMinute = 0;

            if (tbxDateFrom.Text != string.Empty)
            {
                model.FromDate = tbxDateFrom.DateTime;
                model.FromHour = Convert.ToSByte(tbxTimeFrom.Value.ToString("HH"));
                model.FromMinute = Convert.ToSByte(tbxTimeFrom.Value.ToString("mm"));
            }

            if (tbxDateTo.Text != string.Empty)
            {
                model.ToDate = tbxDateTo.DateTime;
                model.ToHour = Convert.ToSByte(tbxTimeTo.Value.ToString("HH"));
                model.ToMinute = Convert.ToSByte(tbxTimeTo.Value.ToString("mm"));
            }

            model.Name = tbxAnnouncement.Text;
            model.AnnouncementType = 1;

            return model;
        }
    }
}
