using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Linq.Dynamic;
using System.Windows.Forms;
using Devenlab.Common;
using SISCO.App;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Administration;
using SISCO.Presentation.Billing;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.Corporate;
using SISCO.Presentation.CounterCash;
using SISCO.Presentation.Marketing;
using SISCO.Presentation.Operation;
using SISCO.Presentation.MasterData;
using SISCO.Presentation.Finance;
using SISCO.Presentation.Franchise;
using SISCO.Presentation.CustomerService;
using SISCO.Modal;
using SISCO.Presentation.Operation.Forms;
using SISCO.Presentation.Reports;
using SISCO.Presentation.Audit;

namespace SISCO
{
    public partial class MainForm : Form 
    {
        private Timer _timer;
        private int _x;

        public MainForm()
        {
            InitializeComponent();

            foreach (Control control in Controls)
            {
                if (control is MdiClient)
                    control.Paint += MdiBackgroundPaint;
            }

            FormClosed += Terminate;
            Shown += InitForm;
            Resize += (sender, args) => DrawBackground();
            NotificationView.MouseDown += NotificationView_MouseDown;
            nb.Resize += (sender, args) => DrawBackground();
            tsIdle.Text = "0s";

            _timer = new Timer();
            _timer.Tick += new EventHandler(Timer_Exipred);
            _timer.Interval = 60000;
        }

        private void Timer_Exipred(object sender, EventArgs e)
        {
            _x = new IdleTimeFinder().GetLastInputTime();
            var tick = Environment.TickCount / 1000;

            tsIdle.Text = string.Format("{0}s", (tick - (_x / 1000)));
            if ((tick - (_x / 1000)) >= 600 && _x > 0)
            {
                if (!string.IsNullOrEmpty(BaseControl.UserLogin))
                {
                    _timer.Stop();

                    var logoffForm = new LogoffForm();
                    logoffForm.ShowDialog();

                    if (string.IsNullOrEmpty(BaseControl.UserLogin)) Logout(sender, e);
                    else _timer.Start();
                }
            }
        }

        private void MdiBackgroundPaint(object sender, PaintEventArgs e)
        {
            if (string.IsNullOrEmpty(BaseControl.UserLogin)) return;

            var appVersion = (ApplicationDeployment.IsNetworkDeployed) ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() : "N/A";

            var mdi = sender as MdiClient;
            if (mdi == null) return;

            var message = string.Format("Welcome {0}\nBranch: {1}\nDept: {2}\nApp. Version:{3}", BaseControl.UserLogin,
                BaseControl.BranchCode, BaseControl.DepartmentName, appVersion);

            #if DEBUG
                message += string.Format("\nDebug: true\nDatabase Server: {0}\nDatabase: {1}", BaseControl.DatabaseSetting.Host, BaseControl.DatabaseSetting.DatabaseName);
            #endif

            e.Graphics.Clip = new Region(mdi.ClientRectangle);
            e.Graphics.DrawString(message, new Font(FontFamily.GenericSansSerif, 10F, FontStyle.Bold), Brushes.Black, (Width - nb.Width) - 300, 20F);

            using (var announcementDm = new RunningTextDataManager())
            {
                var list = announcementDm.GetByBranchIdAndDepartmentIdAndUserId<RunningTextModel>(BaseControl.BranchId, BaseControl.DepartmentId, BaseControl.UserId ?? 0);
                //todo announcement
            }
        }

        private void InitForm(object sender, EventArgs e)
        {
            tsDate.Text = DateTime.Now.ToString("D");
            tsUserLogged.Text = @"Please Login";

            toolStripLabel2.MarqueeText = System.Configuration.ConfigurationManager.AppSettings["MarqueeText"];
            toolStripLabel2.Interval = 300;

            mi_File_ChangePassword.Enabled = false;

            miFile_Login.Click += Login;
            miFile_Logout.Click += Logout;
            miFile_Exit.Click += Exit;
            miFile_Preference_DBConnection.Click += ShowDbConnection;
            mi_File_ChangePassword.Click += (o, args) =>
            {
                using (var form = new ChangePasswordForm())
                {
                    form.ShowDialog();
                }
            };

            miView_About.Click += ShowAbout;

            tsBtnLogin.Click += Login;
            tsBtnLogout.Click += Logout;
            tsBtnExit.Click += Exit;

            miFranchise.DropDownItems.AddRange(FranchiseMenu.GetMenus().ToArray());
            _applyClickEvent(miFranchise, ItemClick);

            miCorporate.DropDownItems.AddRange(CorporateMenu.GetMenus().ToArray());
            _applyClickEvent(miCorporate, ItemClick);

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

            miAudit.DropDownItems.AddRange(AuditMenu.GetMenus().ToArray());
            miAudit.DropDownItemClicked += ItemClick;

            miCustomerService.DropDownItems.AddRange(CustomerServiceMenu.GetMenus().ToArray());
            miCustomerService.DropDownItemClicked += ItemClick;

            //miReports.DropDownItems.AddRange(CustomerServiceMenu.GetReportMenus().ToArray());
            miReports.DropDownItems.AddRange(ReportMenu.GetMenus().ToArray());
            _applyClickEvent(miReports, ItemClick);

            miNavigator.DropDownItems.AddRange(NavigationMenu.GetMenus().ToArray());
            VisibleMenuItem(false);

            if (!string.IsNullOrEmpty(BaseControl.BackgroundImagePath))
            {
                DesktopBackgroundImagePath = BaseControl.BackgroundImagePath;
                DrawBackground();
            }

            var dateTimeForm = new DateTimeForm();
            dateTimeForm.ShowDialog();
        }

        private void ShowAbout(object sender, EventArgs e)
        {
            var aboutForm = new AboutBox();
            BaseControl.OpenForm(aboutForm);
        }

        private void RefreshInbox()
        {
            using (var dm = new InboxDataManager())
            {
                NotificationGrid.DataSource = dm.Get<InboxModel>(WhereTerm.Default(BaseControl.BranchId, "branch_id"), WhereTerm.Default(BaseControl.DepartmentId, "department_id"), WhereTerm.Default(true, "is_open"));
            }
        }

        private void _applyClickEvent(ToolStripMenuItem parent, ToolStripItemClickedEventHandler eventHandler)
        {
            parent.DropDownItemClicked += eventHandler;

            for (var i = 0; i < parent.DropDownItems.Count; i++)
            {
                if (parent.DropDownItems[i] is ToolStripMenuItem)
                {
                    _applyClickEvent(parent.DropDownItems[i] as ToolStripMenuItem, eventHandler);
                }
            }
        }

        private void VisibleMenuItem(bool visible)
        {
            miFranchise.Visible = visible;
            miCorporate.Visible = visible;
            miMasterData.Visible = visible;
            miMarketing.Visible = visible;
            miCustomerService.Visible = visible;
            miCounterCash.Visible = visible;
            miAdministration.Visible = visible;
            miOperation.Visible = visible;
            miBilling.Visible = visible;
            miFinance.Visible = visible;
            miAudit.Visible = visible;
            miNavigator.Visible = visible;
            miReports.Visible = visible;
        }

        private void LoginEnabled(bool enabled)
        {
            tsBtnLogin.Enabled = enabled;
            miFile_Login.Enabled = enabled;

            tsBtnLogout.Enabled = !enabled;
            miFile_Logout.Enabled = !enabled;
            mi_File_ChangePassword.Enabled = !enabled;
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

                DrawBackground();
                //RefreshInbox();
                _timer.Start();
            }
        }

        protected void Logout(object sender, EventArgs e)
        {
            BaseControl.UserLogin = string.Empty;
            BaseControl.UserId = null;

            foreach (var form in MdiChildren)
            {
                form.Close();
                form.Dispose();
            }

            VisibleMenuItem(false);
            LoginEnabled(true);
            tsUserLogged.Text = string.Empty;

            DrawBackground();
            NotificationGrid.DataSource = new object[0];
            _timer.Stop();
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
            var form = e.ClickedItem as MenuCommand;

            if (form == null) return;

            form.MenuInvoker.open(this);

            //NavigationMenu.NewStrip.Enabled = true;
            NavigationMenu.TopStrip.Enabled = true;
            NavigationMenu.BottomStrip.Enabled = true;
        }

        protected void ShowDbConnection(object sender, EventArgs e)
        {
            var mysqlForm = new MySQLSettingForm { MdiParent = this };
            BaseControl.OpenForm(mysqlForm);
        }

        private void userPreferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new UserPreferencesForm
            {
                MdiParent = this
            };
            BaseControl.OpenForm(form);
        }

        public void DrawBackground()
        {
            if (File.Exists(DesktopBackgroundImagePath))
            {
                BackgroundImage = Image.FromFile(DesktopBackgroundImagePath);
                BackgroundImageLayout = ImageLayout.Stretch;
            }

            foreach (Control control in Controls)
            {
                if (control is MdiClient)
                    control.Refresh();
            }

            Authorization.FilterToolstripMenu(ms.Items);
        }

        public string DesktopBackgroundImagePath { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshInbox();
        }

        private void NotificationView_MouseDown(object sender, MouseEventArgs e)
        {
            var hitInfo = NotificationView.CalcHitInfo(e.Location);

            if (!hitInfo.InRowCell) return;

            var row = (InboxModel)NotificationView.GetRow(hitInfo.RowHandle);

            if (hitInfo.Column.Name.Equals("clmDelete"))
            {
                row.DateViewed = DateTime.Now;

                if (true)
                {
                    row.IsOpen = false;
                    row.DateCompleted = DateTime.Now;
                }

                using (var dm = new InboxDataManager())
                {
                    dm.Update<InboxModel>(row);
                }

                NotificationView.DeleteRow(hitInfo.RowHandle);
            }
            else
            {
                switch ((Transaction)Enum.Parse(typeof(Transaction), row.TransactionType))
                {
                    case Transaction.Manifest:
                        BaseControl.OpenForm(new ManifestForm(), typeof(Presentation.Operation.Command.ManifestCommand));
                        break;

                    case Transaction.OutboundDarat:
                        BaseControl.OpenForm(new OutboundDaratForm(), typeof(Presentation.Operation.Command.OutboundDaratCommand));
                        break;

                    case Transaction.OutboundUdara:
                        BaseControl.OpenForm(new OutboundBandaraForm(), typeof(Presentation.Operation.Command.OutboundBandaraCommand));
                        break;

                    case Transaction.Inbound:
                        BaseControl.OpenForm(new InboundBandaraForm(), typeof(Presentation.Operation.Command.InboundBandaraCommand));
                        break;

                    case Transaction.DeliveryOrder:
                        BaseControl.OpenForm(new DeliveryOrderForm(), typeof(Presentation.Operation.Command.DeliveryOrderCommand));
                        break;
                }
            }
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _layoutMdi(MdiLayout.Cascade);
        }

        private void arrangeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _layoutMdi(MdiLayout.TileHorizontal);
        }

        void _layoutMdi(MdiLayout layout)
        {
            var minSizes = new List<Size>();
            var maxSizes = new List<Size>();
            for (int i = 0; i < MdiChildren.Count(); i++)
            {
                minSizes.Add(MdiChildren[i].MinimumSize);
                maxSizes.Add(MdiChildren[i].MaximumSize);
                MdiChildren[i].MinimumSize = MdiChildren[i].Size;
                MdiChildren[i].MaximumSize = MdiChildren[i].Size;
            }

            LayoutMdi(layout);

            for (int i = 0; i < MdiChildren.Count(); i++)
            {
                MdiChildren[i].MinimumSize = minSizes[i];
                MdiChildren[i].MaximumSize = maxSizes[i];
            }
        }
    }
}