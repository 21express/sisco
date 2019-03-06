using System;
using System.Windows.Forms;
using Devenlab.Common;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Properties;

namespace SISCO.Modal
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            btnLogin.Click += Login;

            #if DEBUG
                tbxUsername.Text = @"admin";
            #else
                tbxUsername.Text = "";
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

                    Dispose();
                }
                else MessageBox.Show(Resources.contact_it_dep, Resources.invalid_user_account);
            }
            else MessageBox.Show(Resources.enter_correct_login, Resources.incorrect_login);
            UseWaitCursor = false;
        }
    }
}