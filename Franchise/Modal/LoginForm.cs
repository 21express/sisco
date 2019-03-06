using System;
using System.Windows.Forms;
using Devenlab.Common;
using Franchise.Presentation.Common;
using Franchise.Presentation.Common.Properties;
using SISCO.App.Franchise;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.LocalStorage;
using Newtonsoft.Json;
using System.Collections.Generic;
using SISCO.Models.TransferObject;
using Devenlab.Common.Interfaces;
using System.Linq;

namespace Franchise.Modal
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            InitLayouts();
        }

        public void InitLayouts()
        {
            btnLogin.Click += Login;
            btnCancel.Click += (sender, args) => Close();
        }

        private void Login(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            if (tbxUsername.Text == "")
            {
                MessageBox.Show(Resources.empty_username, Resources.title_information);
                UseWaitCursor = false;
                return;
            }

            var dm = new UserFranchiseDataManager();
            var user = dm.Login(tbxUsername.Text, tbxPassword.Text, BaseControl.FranchiseId);

            if (user != null)
            {
                var em = new FranchiseDataManager();
                var franchise = em.GetFirst<FranchiseModel>(WhereTerm.Default(user.FranchiseId, "id", EnumSqlOperator.Equals));

                if (franchise != null)
                {
                    BaseControl.UserId = user.Id;
                    BaseControl.UserLogin = user.UserName;
                    BaseControl.FranchiseName = franchise.Name;
                    BaseControl.BranchId = franchise.BranchId;

                    var branch =
                        new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(franchise.BranchId, "id",
                            EnumSqlOperator.Equals));

                    BaseControl.BranchCode = branch.Code;

                    var city =
                        new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(franchise.CityId, "id",
                            EnumSqlOperator.Equals));

                    BaseControl.CityId = city.Id;
                    BaseControl.CityName = city.Name;
                    BaseControl.CountryId = city.CountryId;

                    var country =
                        new CountryDataManager().GetFirst<CountryModel>(WhereTerm.Default(city.CountryId, "id",
                            EnumSqlOperator.Equals));

                    BaseControl.CountryName = country.Name;

                    Authorization.SetFranchseUserId(BaseControl.UserId);

                    var customers = new CustomerDataManager().Get<CustomerModel>(new IListParameter[]
                    {
                        WhereTerm.Default(branch.Id, "branch_id", EnumSqlOperator.Equals),
                        WhereTerm.Default(franchise.Id, "franchise_id", EnumSqlOperator.Equals),
                        WhereTerm.Default("0", "disabled", EnumSqlOperator.Equals),
                    }).ToList();
                    if (customers.Count > 0) new CustomerServices().Save(JsonConvert.DeserializeObject<List<CustomerData>>(JsonConvert.SerializeObject(customers)));

                    var messengers = new EmployeeDataManager().Get<EmployeeModel>(new IListParameter[]
                    {
                        WhereTerm.Default(true, "as_messenger"),
                        WhereTerm.Default(branch.Id, "branch_id", EnumSqlOperator.Equals)
                    }).ToList();
                    if (messengers.Count > 0) new MessengerServices().Save(JsonConvert.DeserializeObject<List<MessengerData>>(JsonConvert.SerializeObject(messengers)));

                    Dispose();
                }
                else MessageBox.Show(string.Format("{0} {1}", Resources.franchise_account_not_found, Resources.contact_it_support), Resources.title_information);
            }
            else MessageBox.Show(Resources.invalid_login, Resources.title_login_failed);
            UseWaitCursor = false;
        }
    }
}
