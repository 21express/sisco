using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Native;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using BaseControl = SISCO.Presentation.Common.BaseControl;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManageRoleForm : BaseMasterForm<UserRolesModel, UserRoleDataManager>//BasePage//
    {
        private BindingList<PrivilegeJoinUserPrivilegeModel> Privileges;
        public ManageRoleForm()
        {
            InitializeComponent();
            form = this;

            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            Init();
        }

        public override void Init()
        {
            CtlClearButton = null;
            CtlDeleteButton = btnDelete;
            CtlGridControl = grid;
            CtlGridView = gridView;
            CtlNewButton = btnNew;
            CtlPanelDetail = grpDetail;
            CtlSaveButton = btnSave;

            base.Init();
        }
        
        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            txtRole.FieldLabel = "Role";
            txtRole.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            PageLimit = 99999;

            form.Enabled = false;
            UseWaitCursor = true;

            var fleets = LoadGrid(GridLoadDirection.First);

            form.Enabled = true;
            UseWaitCursor = false;

            SetDataSource(fleets);
            NavigatorPagingState = PagingState;

            Privileges = new BindingList<PrivilegeJoinUserPrivilegeModel>();
            gridPrivilege.DataSource = Privileges;

            gridPrivilegeView.CustomRowCellEdit += (o, args) =>
            {
                var row1 = (o as GridView).GetRow(args.RowHandle);
                var row = (o as GridView).GetRow(args.RowHandle) as PrivilegeJoinUserPrivilegeModel;

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
            };

            gridPrivilegeView.CellValueChanging += Changing;
        }

        private void Changing(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gridPrivilegeView.GetRowCellValue(e.RowHandle, gridPrivilegeView.Columns["StateChange2"]).ToString() == EnumStateChange.Idle.ToString())
            {
                gridPrivilegeView.SetRowCellValue(e.RowHandle, gridPrivilegeView.Columns["StateChange2"], EnumStateChange.Update);
            }
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            var errors = ComponentValidationHelper.Validate(txtRole);

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors));
                return false;
            }

            using (var roleDm = new UserRoleDataManager())
            {
                var role = roleDm.GetFirst<UserRolesModel>(WhereTerm.Default(txtRole.Text, "role"));
                if (role != null && role.Id != CurrentModel.Id)
                {
                    MessageBox.Show(@"Role sudah terdaftar!");
                    return false;
                }
            }

            return true;
        }

        protected override void PopulateForm(UserRolesModel model)
        {
            txtRole.Text = model.Role;

            btnDelete.Enabled = true;

            Privileges.RaiseListChangedEvents = false;

            Privileges.Clear();

            new PrivilegeDataManager()
                .GetJoinUserPrivilegeByRoleId<PrivilegeJoinUserPrivilegeModel>(model.Id)
                .ForEach(r => Privileges.Add(r));

            Privileges.RaiseListChangedEvents = true;
            Privileges.ResetBindings();
        }

        protected override UserRolesModel PopulateModel(UserRolesModel model)
        {
            model.Role = txtRole.Text;

            return model;
        }

        protected override IListParameter[] Filter()
        {
            var p = new List<IListParameter>();

            //if (lkpBaseBranch.Value != null) p.Add(WhereTerm.Default((int)lkpBaseBranch.Value, "branch_id"));
    
            return p.ToArray();
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();

            txtRole.Focus();

            btnDelete.Enabled = false;

            Privileges.RaiseListChangedEvents = false;

            Privileges.Clear();

            new PrivilegeDataManager()
                .GetJoinUserPrivilegeByRoleId<PrivilegeJoinUserPrivilegeModel>(0)
                .ForEach(r => Privileges.Add(r));

            Privileges.RaiseListChangedEvents = true;
            Privileges.ResetBindings();

            PageLimit = 99999;
        }

        protected override void AfterSave()
        {
            base.AfterSave();

            Authorization.ClearPrivileges();
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            //var rows = Privileges.Select(r => new UserPrivilegeModel
            //{
            //    RoleId = CurrentModel.Id,
            //    ModuleName = r.ModuleName,
            //    FormName = r.FormName,
            //    AllowAccess = r.RoleAllowAccess,
            //    AllowView = r.RoleAllowView,
            //    AllowViewAll = r.RoleAllowViewAll,
            //    AllowCreate = r.RoleAllowCreate,
            //    AllowEdit = r.RoleAllowEdit,
            //    AllowDelete = r.RoleAllowDelete,
            //    AllowPrint = r.RoleAllowPrint,
            //    Rowversion = DateTime.Now,
            //    Rowstatus = true,
            //    Createdby = BaseControl.UserLogin,
            //    Createddate = DateTime.Now,
            //}).ToList();

            //new UserPrivilegeDataManager().Save(CurrentModel.Id, rows);

            foreach (PrivilegeJoinUserPrivilegeModel obj in Privileges)
            {
                var model = new UserPrivilegeModel();
                if (obj.StateChange2 == EnumStateChange.Insert.ToString())
                {
                    model.RoleId = CurrentModel.Id;
                    model.ModuleName = obj.ModuleName;
                    model.FormName = obj.FormName;
                    model.AllowAccess = obj.RoleAllowAccess;
                    model.AllowView = obj.RoleAllowView;
                    model.AllowViewAll = obj.RoleAllowViewAll;
                    model.AllowCreate = obj.RoleAllowCreate;
                    model.AllowEdit = obj.RoleAllowEdit;
                    model.AllowDelete = obj.RoleAllowDelete;
                    model.AllowPrint = obj.RoleAllowPrint;
                    model.Rowversion = DateTime.Now;
                    model.Rowstatus = true;
                    model.Createdby = BaseControl.UserLogin;
                    model.Createddate = DateTime.Now;

                    new UserPrivilegeDataManager().Save<UserPrivilegeModel>(model);
                }

                if (obj.StateChange2 == EnumStateChange.Update.ToString())
                {
                    model = new UserPrivilegeDataManager().GetFirst<UserPrivilegeModel>(WhereTerm.Default((int)obj.UserPrivilegeId, "id"));
                    if (model != null)
                    {
                        model.RoleId = CurrentModel.Id;
                        model.ModuleName = obj.ModuleName;
                        model.FormName = obj.FormName;
                        model.AllowAccess = obj.RoleAllowAccess;
                        model.AllowView = obj.RoleAllowView;
                        model.AllowViewAll = obj.RoleAllowViewAll;
                        model.AllowCreate = obj.RoleAllowCreate;
                        model.AllowEdit = obj.RoleAllowEdit;
                        model.AllowDelete = obj.RoleAllowDelete;
                        model.AllowPrint = obj.RoleAllowPrint;
                        model.Modifiedby = BaseControl.UserLogin;
                        model.Modifieddate = DateTime.Now;

                        new UserPrivilegeDataManager().Update<UserPrivilegeModel>(model);
                    }
                }
            }
        }
    }
}