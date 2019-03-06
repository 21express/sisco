using System;
using System.Diagnostics;
using System.Windows.Forms;
using SISCO.Presentation.Administration;
using SISCO.Presentation.Billing;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.CounterCash;
using SISCO.Presentation.Marketing;
using SISCO.Presentation.Operation;
using SISCO.Presentation.MasterData;
using SISCO.Presentation.Finance;
using SISCO.Presentation.CustomerService;
using SISCO.Modal;

namespace SISCO
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            FormClosed += Terminate;
            Shown += InitForm;
        }

        private void InitForm(object sender, EventArgs e)
        {
            tsDate.Text = DateTime.Now.ToString("D");
            tsUserLogged.Text = @"Please Login";

            miFile_Login.Click += Login;
            miFile_Logout.Click += Logout;
            miFile_Exit.Click += Exit;
            miFile_Preference_DBConnection.Click += ShowDbConnection;

            tsBtnLogin.Click += Login;
            tsBtnLogout.Click += Logout;
            tsBtnExit.Click += Exit;

            miMasterData.DropDownItems.AddRange(MasterDataMenu.GetMenus().ToArray());
            miMasterData.DropDownItemClicked += ItemClick;

            miMarketing.DropDownItems.AddRange(MarketingMenu.GetMenus().ToArray());
            miMarketing.DropDownItemClicked += ItemClick;

            miCounterCash.DropDownItems.AddRange(CounterCashMenu.GetMenus().ToArray());
            miCounterCash.DropDownItemClicked += ItemClick;

            miOperation.DropDownItems.AddRange(OperationMenu.GetMenus().ToArray());
            miOperation.DropDownItemClicked += ItemClick;

            miAdministration.DropDownItems.AddRange(AdministrationMenu.GetMenus().ToArray());
            miAdministration.DropDownItemClicked += ItemClick;

            miBilling.DropDownItems.AddRange(BillingMenu.GetMenus().ToArray());
            miBilling.DropDownItemClicked += ItemClick;

            miFinance.DropDownItems.AddRange(FinanceMenu.GetMenus().ToArray());
            miFinance.DropDownItemClicked += ItemClick;

            miCustomerService.DropDownItems.AddRange(CustomerServiceMenu.GetMenus().ToArray());
            miCustomerService.DropDownItemClicked += ItemClick;

            miNavigator.DropDownItems.AddRange(NavigationMenu.GetMenus().ToArray());
            VisibleMenuItem(false);

            var dateTimeForm = new DateTimeForm();
            dateTimeForm.ShowDialog();
        }

        private void VisibleMenuItem(bool visible)
        {
            miMasterData.Visible = visible;
            miMarketing.Visible = visible;
            miCustomerService.Visible = visible;
            miCounterCash.Visible = visible;
            miAdministration.Visible = visible;
            miOperation.Visible = visible;
            miBilling.Visible = visible;
            miFinance.Visible = visible;
            miAccounting.Visible = visible;
            miNavigator.Visible = visible;
        }

        private void LoginEnabled(bool enabled)
        {
            tsBtnLogin.Enabled = enabled;
            miFile_Login.Enabled = enabled;

            tsBtnLogout.Enabled = !enabled;
            miFile_Logout.Enabled = !enabled;
        }

        private void Terminate(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        protected void Login(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            BaseControl.OpenForm(loginForm, true);

            if (BaseControl.UserId > 0)
            {
                VisibleMenuItem(true);
                LoginEnabled(false);
                tsUserLogged.Text = BaseControl.UserLogin;
            }
        }

        protected void Logout(object sender, EventArgs e)
        {
            BaseControl.UserLogin = string.Empty;
            BaseControl.UserId = null;

            VisibleMenuItem(false);
            LoginEnabled(true);
            tsUserLogged.Text = string.Empty;
        }

        protected void Exit(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(Resources.exit_application, Resources.information, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();   
            }
        }

        protected void ItemClick(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                var form = e.ClickedItem as MenuCommand;
                Debug.Assert(form != null, "form != null");
                form.MenuInvoker.open(this);

                NavigationMenu.NewStrip.Enabled = true;
                NavigationMenu.TopStrip.Enabled = true;
                NavigationMenu.BottomStrip.Enabled = true;
            }
            catch(Exception ex)
            {
                // ReSharper disable once RedundantJumpStatement
                return;
            }
        }

        protected void ShowDbConnection(object sender, EventArgs e)
        {
            var mysqlForm = new MySQLSettingForm();
            BaseControl.OpenForm(mysqlForm);
        }
    }
}
