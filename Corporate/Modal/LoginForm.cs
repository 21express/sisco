using System;
using System.Windows.Forms;
using Corporate.Presentation.Common;
using Corporate.Presentation.Common.Properties;
using Devenlab.Common;

using SISCO.App.Corporate;
using SISCO.App.MasterData;
using SISCO.Models;

namespace Corporate.Modal
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

            var dm = new CorporateUserDataManager();
            var user = dm.Login(tbxUsername.Text, tbxPassword.Text, BaseControl.CorporateId);

            if (user != null)
            {
                var em = new CustomerDataManager();
                var corporate = em.GetFirst<CustomerModel>(WhereTerm.Default(user.CorporateId, "id", EnumSqlOperator.Equals));

                if (corporate != null)
                {
                    BaseControl.UserId = user.Id;
                    BaseControl.UserLogin = user.UserName;
                    BaseControl.CorporateName = corporate.Name;
                    BaseControl.BranchId = corporate.BranchId;

                    var branch =
                        new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(corporate.BranchId, "id",
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

                    Authorization.SetCorporateUserId(BaseControl.UserId);

                    Dispose();
                }
                else MessageBox.Show(string.Format("{0} {1}", Resources.franchise_account_not_found, Resources.contact_it_support), Resources.title_information);
            }
            else MessageBox.Show(Resources.invalid_login, Resources.title_login_failed);
            UseWaitCursor = false;
        }
    }
}
