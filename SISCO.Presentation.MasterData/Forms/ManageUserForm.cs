using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Annotations;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManageUserForm : BaseMasterForm<UsersModel, ManageUserForm.UserDataRow, UsersDataManager>
    {
        public class UserDataRow : UsersModel, INotifyPropertyChanged
        {
            public UserRoleDataManager UserRoleDataManager { get; set; }

            private string _userRole;
            public string Role
            {
                get
                {
                    if (string.IsNullOrEmpty(_userRole) && UserRoleId != 0)
                    {
                        var model = UserRoleDataManager.Get<UserRolesModel>(WhereTerm.Default(UserRoleId, "id")).FirstOrDefault();
                        _userRole = string.Format("{0}", model.Role);
                    }
                    return _userRole;
                }
                set { _userRole = value; }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }

            internal void NotifyUpdate(string propertyName)
            {
                OnPropertyChanged(propertyName);

                switch (propertyName)
                {
                    case "UserRoleId":
                        Role = null;
                        NotifyUpdate("Role");
                        break;
                }
            }
        }

        public UserRoleDataManager UserRoleDataManager { get; set; }

        public ManageUserForm()
        {
            InitializeComponent();
            form = this;

            UserRoleDataManager = new UserRoleDataManager();

            MainModelTransformFunc = model =>
            {
                var row = ConvertModel<UsersModel, ManageUserForm.UserDataRow>(model);
                row.UserRoleDataManager = UserRoleDataManager;

                return row;
            };

            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            Init();

            Shown += (sender, args) =>
            {
                form.Enabled = false;
                UseWaitCursor = true;

                var fleets = LoadGrid(GridLoadDirection.First);
                modeltmp = fleets.ToList();

                form.Enabled = true;
                UseWaitCursor = false;

                SetDataSource(fleets);
                NavigatorPagingState = PagingState;
            };
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
        
        private List<UsersModel> modeltmp { get; set; }
        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            txtUsername.FieldLabel = "Username";
            txtUsername.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpUserRole.LookupPopup = new UserRolePopup();
            lkpUserRole.AutoCompleteDataManager = new UserRoleDataManager();
            lkpUserRole.AutoCompleteDisplayFormater = model => ((UserRolesModel)model).Role;
            lkpUserRole.AutoCompleteWheretermFormater = s => new IListParameter[] { WhereTerm.Default(s, "role", EnumSqlOperator.BeginWith) };
            lkpUserRole.FieldLabel = "User Role";
            lkpUserRole.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            PageLimit = 99999;

            tbxSearch.Focus();
            btnFind.Click += FindUsername;
        }

        private void FindUsername(object sender, EventArgs e)
        {
            if (tbxSearch.Text == "") return;
            var data = modeltmp;
            if (data == null) return;
            var idx = data.FindIndex(x => x.Username.StartsWith(tbxSearch.Text));

            CtlGridView.FocusedRowHandle = idx;
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            var errors = ComponentValidationHelper.Validate(txtUsername, lkpUserRole);

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors));
                return false;
            }

            if (txtPassword.Text != string.Empty)
            {
                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show(@"You have entered a new password for this user, but the password entered in both 'Password' and 'Confirm password' do not match each other.");
                    return false;
                }
            }

            using (var userDm = new UsersDataManager())
            {
                var user = userDm.GetFirst<UsersModel>(WhereTerm.Default(txtUsername.Text, "username"));
                if (user != null && user.Id != CurrentModel.Id)
                {
                    MessageBox.Show(@"Username sudah dipakai user lain!");
                    return false;
                }
            }

            return true;
        }

        protected override void PopulateForm(UsersModel model)
        {
            txtUsername.Text = model.Username;
            lkpUserRole.DefaultValue = new IListParameter[] {WhereTerm.Default(model.UserRoleId, "id")};

            btnDelete.Enabled = true;
        }

        protected override UsersModel PopulateModel(UsersModel model)
        {
            model.Username = txtUsername.Text;
            model.UserRoleId = (int) lkpUserRole.Value;

            if (model.Password == null)
            {
                model.Password = UsersDataManager.GetMd5Hash(string.Empty);
            } 
            
            if (txtPassword.Text != string.Empty)
            {
                model.Password = UsersDataManager.GetMd5Hash(txtPassword.Text);
            }
            

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

            txtUsername.Focus();

            btnDelete.Enabled = false;

            PageLimit = 99999;
        }
    }
}