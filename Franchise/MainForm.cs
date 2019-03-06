using System;
using System.Configuration;
using System.Linq;
using System.Linq.Dynamic;
using System.Windows.Forms;
using Devenlab.Common;
using DevExpress.XtraBars;
using DevExpress.XtraNavBar;
using Franchise.Presentation.Common;
using Franchise.Presentation.Common.Properties;
using Franchise.Modal;
using Franchise.Presentation.CounterCash;
using Franchise.Presentation.CustomerService;
using Franchise.Presentation.MasterData;
using Franchise.Presentation.Reports;
using SISCO.App.MasterData;
using Franchise.Presentation.DropPoint;

namespace Franchise
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            rbLogin.ItemClick += Login;
            rbLogout.ItemClick += Logout;
            rbExit.ItemClick += Exit;

            miMasterData.DropDownItems.AddRange(MasterDataMenu.GetMenus().ToArray());
            miMasterData.DropDownItemClicked += ItemClick;

            miCustomerService.DropDownItems.AddRange(CustomerServiceMenu.GetMenus().ToArray());
            miCustomerService.DropDownItemClicked += ItemClick;

            miCounterCash.DropDownItems.AddRange(CounterCashMenu.GetMenus().ToArray());
            miCounterCash.DropDownItemClicked += ItemClick;

            miDropPoint.DropDownItems.AddRange(DropPointMenu.GetMenus().ToArray());
            miDropPoint.DropDownItemClicked += ItemClick;

            miReport.DropDownItems.AddRange(ReportMenu.GetMenus().ToArray());
            miReport.DropDownItemClicked += ItemClick;

            rbPrinterPreference.ItemClick += ShowPrinterPreference;
            rbChangePassword.ItemClick += ShowChangePassword;
            rbAbout_Info.ItemClick += ShowAboutForm;

            tsDate.Text = string.Empty;
            tsUser.Text = string.Empty;
            tsFranchise.Text = string.Empty;
            tsAnnouncement.Text = string.Empty;

            SalesControl.Init();
        }

        private void ShowAboutForm(object sender, ItemClickEventArgs e)
        {
            var aboutForm = new About();
            BaseControl.OpenForm(aboutForm);
        }

        private void ShowChangePassword(object sender, ItemClickEventArgs e)
        {
            var changeForm = new ChangePasswordForm();
            BaseControl.OpenForm(changeForm);
        }

        private void ShowPrinterPreference(object sender, ItemClickEventArgs e)
        {
            var preferenceForm = new UserPreferencesForm();
            BaseControl.OpenForm(preferenceForm);
        }

        private void ItemClick(object sender, ToolStripItemClickedEventArgs e)
        {
            var form = e.ClickedItem as MenuCommand;

            if (form == null) return;

            form.MenuInvoker.open(this);
        }

        private void Exit(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(Resources.exit_question, Resources.title_confirmation, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Logout(object sender, EventArgs e)
        {
            BaseControl.UserLogin = string.Empty;
            BaseControl.UserId = 0;

            foreach (var form in MdiChildren)
            {
                form.Close();
                form.Dispose();
            }

            VisibleMenuItem(false);
            LoginButtons(true);

            tsDate.Text = string.Empty;
            tsUser.Text = string.Empty;
            tsFranchise.Text = string.Empty;

            navBarControl1.OptionsNavPane.NavPaneState = NavPaneState.Collapsed;

            SalesControl.Reset();
            SalesControl.SetTimer(false);

            tsAnnouncement.MarqueeText = string.Empty;
            tsAnnouncement.Interval = 30000;
        }

        private void Login(object sender, EventArgs e)
        {
            BaseControl.OpenForm(new LoginForm(), true);
            if (BaseControl.UserId > 0)
            {
                VisibleMenuItem(true);
                LoginButtons(false);

                tsDate.Text = DateTime.Now.ToString("dddd, yyyy-MMM-d");
                tsUser.Text = BaseControl.UserLogin;
                tsFranchise.Text = BaseControl.FranchiseName;

                SalesControl.RefreshSales();
                SalesControl.SetTimer(true);

                var runningText = new RunningTextDataManager().GetRunningText(WhereTerm.Default(1, "announcement_type", EnumSqlOperator.Equals));
                var text = ConfigurationManager.AppSettings["DefaultAnnouncement"];
                if (DynamicQueryable.Any(runningText))
                {
                    var rFranchise = runningText.FirstOrDefault(r => r.FranchiseId == BaseControl.FranchiseId);
                    if (rFranchise != null) text = rFranchise.Name;
                    var rDate = runningText.FirstOrDefault(r => r.FromDate >= DateTime.Now && r.ToDate <= DateTime.Now && r.FromHour >= DateTime.Now.Hour && r.FromMinute >= DateTime.Now.Minute && r.ToHour <= DateTime.Now.Minute && r.ToMinute <= DateTime.Now.Minute);
                    if (rDate != null) text = rDate.Name;
                }
                tsAnnouncement.MarqueeText = text;
                tsAnnouncement.Interval = 300;

                Authorization.FilterToolstripMenu(ms.Items);
            }
        }

        private void VisibleMenuItem(bool visible)
        {
            miMasterData.Visible = visible;
            miCounterCash.Visible = visible;
            miCustomerService.Visible = visible;
            miDropPoint.Visible = visible;
            miReport.Visible = visible;
        }

        private void LoginButtons(bool enable)
        {
            rbLogin.Enabled = enable;
            rbLogout.Enabled = !enable;

            rbChangePassword.Enabled = !enable;
            rbPrinterPreference.Enabled = !enable;
        }
    }
}
