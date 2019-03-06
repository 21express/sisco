using System;
using System.Windows.Forms;
using Devenlab.Common;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Properties;
using System.Linq;
using Newtonsoft.Json;
using SISCO.LocalStorage;
using SISCO.Models.TransferObject;
using System.Collections.Generic;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;

namespace SISCO.Modal
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            tbxPassword.CharacterCasing = CharacterCasing.Normal;

            btnLogin.Click += Login;
            btnCancel.Click += (sender, args) => Close();

            #if DEBUG
                tbxUsername.Text = @"JKT";
                tbxPassword.Text = @"panda21*";
            #endif
        }

        private void Login(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            if (tbxUsername.Text == "")
            {
                MessageBox.Show(Resources.username_cannot_be_empty, Resources.form_validation);
                UseWaitCursor = false;
                return;
            }

            var dm = new UsersDataManager();
            var user = dm.Login(tbxUsername.Text, tbxPassword.Text);

            if (user != null)
            {
                var em = new EmployeeDataManager();
                var employee = em.GetFirst<EmployeeModel>(new WhereTerm{Value = user.Id, TableName = "",  ColumnName = "user_id",Operator = EnumSqlOperator.Equals, ParamDataType = EnumParameterDataTypes.Number});

                if (employee != null)
                {
                    BaseControl.UserId = user.Id;
                    BaseControl.UserLogin = user.Username;
                    BaseControl.RoleId = user.UserRoleId;
                    BaseControl.EmployeeId = employee.Id;
                    BaseControl.EmployeeCode = employee.Code;
                    BaseControl.BranchId = employee.BranchId;

                    var branch =
                        new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(employee.BranchId, "id",
                            EnumSqlOperator.Equals));

                    BaseControl.CityId = branch.CityId;
                    BaseControl.BranchCode = branch.Code;

                    var city =
                        new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(branch.CityId, "id",
                            EnumSqlOperator.Equals));

                    BaseControl.CityName = city.Name;
                    BaseControl.CountryId = city.CountryId;

                    var country =
                        new CountryDataManager().GetFirst<CountryModel>(WhereTerm.Default(city.CountryId, "id",
                            EnumSqlOperator.Equals));

                    BaseControl.CountryName = country.Name;

                    var department =
                        new DepartmentDataManager().GetFirst<DepartmentModel>(WhereTerm.Default(employee.DepartmentId, "id"));

                    if (department != null)
                    {
                        BaseControl.DepartmentName = department.Name;
                        BaseControl.DepartmentId = department.Id;
                    }

                    using (var userRoleDm = new UserRoleDataManager())
                    {
                        var userRole = userRoleDm.GetFirst<UserRolesModel>(WhereTerm.Default(user.UserRoleId, "id"));
                        if (userRole != null)
                        {
                            BaseControl.UserRole = userRole.Role.ToUpper();
                        }
                    }

                    Authorization.SetRole((int) BaseControl.RoleId);

                    var customers = new CustomerDataManager().Get<CustomerModel>(WhereTerm.Default(branch.Id, "branch_id", EnumSqlOperator.Equals)).ToList();
                    if (customers.Count > 0) new CustomerServices().Save(JsonConvert.DeserializeObject<List<CustomerData>>(JsonConvert.SerializeObject(customers)));

                    var messengers = new EmployeeDataManager().Get<EmployeeModel>(new IListParameter[]
                    {
                        WhereTerm.Default(true, "as_messenger"),
                        WhereTerm.Default(branch.Id, "branch_id", EnumSqlOperator.Equals)
                    }).ToList();
                    if (messengers.Count > 0) new MessengerServices().Save(JsonConvert.DeserializeObject<List<MessengerData>>(JsonConvert.SerializeObject(messengers)));

                    var notification = new NotificationDataManager().Get<NotificationModel>(WhereTerm.Default(DateTime.Now, "expired_date", EnumSqlOperator.GreatThan)).ToList();
                    if (notification.Count > 0)
                    {
                        string notif = string.Empty;
                        foreach (NotificationModel obj in notification.OrderByDescending(p => p.DateProcess))
                        {
                            notif += obj.Message;
                            notif += "\n\n=================================\n\n";
                        }

                        MessageForm.Info(this, "Pengumuman", notif);
                    }

                    Dispose();
                }
                else MessageBox.Show(Resources.contact_it_dep, Resources.invalid_user_account);
            }
            else MessageBox.Show(Resources.enter_correct_login, Resources.incorrect_login);
            UseWaitCursor = false;
        }
    }
}