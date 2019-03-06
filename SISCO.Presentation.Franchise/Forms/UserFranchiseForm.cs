using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Native;
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
    public partial class UserFranchiseForm : BasePage//BaseMasterForm<UserFranchiseModel, UserFranchiseDataManager>//
    {
        private int FUserId { get; set; }
        private BindingList<FranchisePrivilegeJoinFranchiseUserPrivilegeModel> _privileges;
        public UserFranchiseForm()
        {
            InitializeComponent();
            form = this;

            form.Load += LoadForm;
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            lkpFranchise.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            txtUsername.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpFranchise.Enabled = false;
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;

            DataManager = new UserFranchiseDataManager();

            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnNew.Enabled = true;

            lkpFranchise.LookupPopup = new FranchisePopup();
            lkpFranchise.AutoCompleteDataManager = new FranchiseDataManager();
            lkpFranchise.AutoCompleteDisplayFormater = model => ((FranchiseModel)model).Code + " " + ((FranchiseModel)model).Name;
            lkpFranchise.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code.StartsWith(@0) or name.StartsWith(@0)", s);

            lkpFilterFranchise.LookupPopup = new FranchisePopup();
            lkpFilterFranchise.AutoCompleteDataManager = new FranchiseDataManager();
            lkpFilterFranchise.AutoCompleteDisplayFormater = model => ((FranchiseModel)model).Code + " " + ((FranchiseModel)model).Name;
            lkpFilterFranchise.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code.StartsWith(@0) or name.StartsWith(@0)", s);

            lkpFilterFranchise.Leave += (o, args) => LoadUser();

            LoadUser();
            _privileges = new BindingList<FranchisePrivilegeJoinFranchiseUserPrivilegeModel>();
            gridPriviledge.DataSource = _privileges;

            priviledgeView.CustomRowCellEdit += (o, args) =>
            {
                var gridView = o as GridView;
                if (gridView != null)
                {
                    var row = gridView.GetRow(args.RowHandle) as FranchisePrivilegeJoinFranchiseUserPrivilegeModel;

                    if (row == null) return;

                    switch (args.Column.FieldName)
                    {
                        case "RoleAllowAccess":
                            if (!row.AllowAccess)
                            {
                                args.RepositoryItem = repositoryItemButtonEdit1;
                            }
                            break;
                        case "RoleAllowView":
                            if (!row.AllowView)
                            {
                                args.RepositoryItem = repositoryItemButtonEdit1;
                            }
                            break;
                        case "RoleAllowViewAll":
                            if (!row.AllowViewAll)
                            {
                                args.RepositoryItem = repositoryItemButtonEdit1;
                            }
                            break;
                        case "RoleAllowCreate":
                            if (!row.AllowCreate)
                            {
                                args.RepositoryItem = repositoryItemButtonEdit1;
                            }
                            break;
                        case "RoleAllowEdit":
                            if (!row.AllowEdit)
                            {
                                args.RepositoryItem = repositoryItemButtonEdit1;
                            }
                            break;
                        case "RoleAllowDelete":
                            if (!row.AllowDelete)
                            {
                                args.RepositoryItem = repositoryItemButtonEdit1;
                            }
                            break;
                        case "RoleAllowPrint":
                            if (!row.AllowPrint)
                            {
                                args.RepositoryItem = repositoryItemButtonEdit1;
                            }
                            break;
                    }
                }
            };

            gridUsers.DoubleClick += (s, args) => Edit();
            btnNew.Click += New;
            btnSave.Click += Save;
            btnDelete.Click += Delete;
        }

        private void Delete(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(Resources.delete_confirm_msg, Resources.delete_confirm,
                MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                ((UserFranchiseDataManager)DataManager).DeActive(FUserId, BaseControl.UserLogin, DateTime.Now);
            }

            SetDataSource();
            LoadUser();
            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;

            ClearForm();
            lkpFranchise.Focus();
            txtUsername.Clear();
            txtPassword.Clear();
            lkpFranchise.Value = null;

            lkpFranchise.Enabled = false;
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
        }

        private void SetDataSource()
        {
            _privileges.RaiseListChangedEvents = false;
            _privileges.Clear();

            _privileges.RaiseListChangedEvents = true;
            _privileges.ResetBindings();

            DeleteDetail();
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

            if (!ValidateFormWithAlert())
            {
                return;
            }

            CurrentModel = PopulateModel(CurrentModel as UserFranchiseModel);

            using (var scope = new System.Transactions.TransactionScope())
            {
                if (CurrentModel.Id == 0)
                {
                    CurrentModel.Rowstatus = true;
                    CurrentModel.Rowversion = DateTime.Now;
                    CurrentModel.Createddate = DateTime.Now;
                    CurrentModel.Createdby = BaseControl.UserLogin;

                    ((UserFranchiseDataManager)DataManager).Save<UserFranchiseModel>(CurrentModel);

                    SaveDetail();
                }
                else
                {
                    ((UserFranchiseDataManager)DataManager).Update<UserFranchiseModel>(CurrentModel);
                    CurrentModel.Rowversion = DateTime.Now;
                    CurrentModel.Modifieddate = DateTime.Now;
                    CurrentModel.Modifiedby = BaseControl.UserLogin;

                    SaveDetail(true);
                }

                scope.Complete();
            }

            LoadUser();
            _privileges.RaiseListChangedEvents = false;
            _privileges.Clear();
            _privileges.RaiseListChangedEvents = true;
            _privileges.ResetBindings();

            btnSave.Enabled = false;
            btnNew.Enabled = true;
            btnDelete.Enabled = false;

            lkpFranchise.Enabled = false;
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;

            lkpFranchise.Value = null;
            txtPassword.Clear();
            txtUsername.Clear();
        }

        private void New(object sender, EventArgs e)
        {
            ClearForm();
            lkpFranchise.Focus();
            txtUsername.Clear();
            txtPassword.Clear();
            lkpFranchise.Value = null;

            lkpFranchise.Enabled = true;
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;

            btnDelete.Enabled = false;
            btnSave.Enabled = true;

            _privileges.RaiseListChangedEvents = false;

            _privileges.Clear();

            new FranchisePriviledgeDataManager()
                .GetJoinFranchiseUserPrivilegeByFranchiseUserId<FranchisePrivilegeJoinFranchiseUserPrivilegeModel>(0)
                .ForEach(r => _privileges.Add(r));

            _privileges.RaiseListChangedEvents = true;
            _privileges.ResetBindings();

            FUserId = 0;
            lblInfo.Visible = false;
            CurrentModel = new UserFranchiseModel();
        }

        private void Edit()
        {
            var rows = userView.GetSelectedRows();
            _privileges.RaiseListChangedEvents = false;
            _privileges.Clear();

            if (rows.Count() > 0)
            {
                lkpFranchise.DefaultValue = new IListParameter[] { WhereTerm.Default((int) userView.GetRowCellValue(rows[0], "FranchiseId"), "id", EnumSqlOperator.Equals) };
                txtUsername.Text = userView.GetRowCellValue(rows[0], "UserName").ToString();
                txtPassword.Text = string.Empty;
                FUserId = (int) userView.GetRowCellValue(rows[0], "Id");

                lkpFranchise.Enabled = true;
                txtPassword.Enabled = true;
                txtUsername.Enabled = true;

                CurrentModel = DataManager.GetFirst<UserFranchiseModel>(WhereTerm.Default(FUserId, "id"));

                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                lkpFranchise.Focus();
                lblInfo.Visible = true;

                new FranchisePriviledgeDataManager().
                    GetJoinFranchiseUserPrivilegeByFranchiseUserId<FranchisePrivilegeJoinFranchiseUserPrivilegeModel>((int)userView.GetRowCellValue(rows[0], "Id"))
                    .ForEach(r => _privileges.Add(r));

                _privileges.RaiseListChangedEvents = true;
                _privileges.ResetBindings();
            }
        }

        private void LoadUser()
        {
            List<UserFranchiseModel> user;

            if (lkpFilterFranchise.Value == null)
            {
                user = new UserFranchiseDataManager().GetUserList();
            }
            else
            {
                user = new UserFranchiseDataManager().GetUserList(WhereTerm.Default((int)lkpFilterFranchise.Value, "franchise_id", EnumSqlOperator.Equals));
            }

            gridUsers.DataSource = user;
            gridUsers.Refresh();
        }

        protected bool ValidateForm()
        {
            if (FUserId == 0 && string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        protected bool ValidateFormWithAlert()
        {
            using (var roleDm = new UserFranchiseDataManager())
            {
                var role = roleDm.GetFirst<UserFranchiseModel>(WhereTerm.Default(txtUsername.Text, "username"));
                if (role != null && role.Id != FUserId)
                {
                    MessageBox.Show(@"Username sudah terdaftar sudah terdaftar!");
                    return false;
                }
            }

            return true;
        }

        protected UserFranchiseModel PopulateModel(UserFranchiseModel model)
        {
            model.Id = FUserId;
            model.UserName = txtUsername.Text;
            if (!string.IsNullOrEmpty(txtPassword.Text)) model.Password = UsersDataManager.GetMd5Hash(txtPassword.Text);
            if (lkpFranchise.Value != null) model.FranchiseId = (int) lkpFranchise.Value;

            return model;
        }

        protected void AfterSave()
        {
            LoadUser();
            Authorization.ClearPrivileges();
        }

        protected void SaveDetail(bool isUpdate = false)
        {
            var rows = _privileges.Select(r => new FranchiseUserPrivilegeModel
            {
                FranchiseUserId = CurrentModel.Id,
                ModuleName = r.ModuleName,
                FormName = r.FormName,
                AllowAccess = r.RoleAllowAccess,
                AllowView = r.RoleAllowView,
                AllowViewAll = r.RoleAllowViewAll,
                AllowCreate = r.RoleAllowCreate,
                AllowEdit = r.RoleAllowEdit,
                AllowDelete = r.RoleAllowDelete,
                AllowPrint = r.RoleAllowPrint,
                Rowversion = DateTime.Now,
                Rowstatus = true,
                Createdby = BaseControl.UserLogin,
                Createddate = DateTime.Now,
            }).ToList();

            new FranchiseUserPrivilegeDataManager().Save(CurrentModel.Id, rows);
        }

        protected void DeleteDetail()
        {
            new FranchiseUserPrivilegeDataManager().Delete(CurrentModel.Id);
        }
    }
}
