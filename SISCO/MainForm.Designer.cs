using SISCO.Presentation.Common.Component;

namespace SISCO
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.ms = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miFile_Login = new System.Windows.Forms.ToolStripMenuItem();
            this.miFile_Logout = new System.Windows.Forms.ToolStripMenuItem();
            this.miFile_Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_File_ChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.miFile_Preference = new System.Windows.Forms.ToolStripMenuItem();
            this.miFile_Preference_DBConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.userPreferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miFile_Separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miFile_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.miEdit_Undo = new System.Windows.Forms.ToolStripMenuItem();
            this.miEdit_Redo = new System.Windows.Forms.ToolStripMenuItem();
            this.miEdit_Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miEdit_Cut = new System.Windows.Forms.ToolStripMenuItem();
            this.miEdit_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.miEdit_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEdit_Separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miEdit_SelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.miView = new System.Windows.Forms.ToolStripMenuItem();
            this.miView_Notification = new System.Windows.Forms.ToolStripMenuItem();
            this.miView_StatusBar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miView_About = new System.Windows.Forms.ToolStripMenuItem();
            this.miMasterData = new System.Windows.Forms.ToolStripMenuItem();
            this.miFranchise = new System.Windows.Forms.ToolStripMenuItem();
            this.miCorporate = new System.Windows.Forms.ToolStripMenuItem();
            this.miMarketing = new System.Windows.Forms.ToolStripMenuItem();
            this.miCustomerService = new System.Windows.Forms.ToolStripMenuItem();
            this.miCounterCash = new System.Windows.Forms.ToolStripMenuItem();
            this.miOperation = new System.Windows.Forms.ToolStripMenuItem();
            this.miAdministration = new System.Windows.Forms.ToolStripMenuItem();
            this.miBilling = new System.Windows.Forms.ToolStripMenuItem();
            this.miFinance = new System.Windows.Forms.ToolStripMenuItem();
            this.miAudit = new System.Windows.Forms.ToolStripMenuItem();
            this.miReports = new System.Windows.Forms.ToolStripMenuItem();
            this.miNavigator = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts = new System.Windows.Forms.ToolStrip();
            this.tsBtnLogin = new System.Windows.Forms.ToolStripButton();
            this.tsBtnLogout = new System.Windows.Forms.ToolStripButton();
            this.tsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnExit = new System.Windows.Forms.ToolStripButton();
            this.taSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new SISCO.Presentation.Common.Component.MarqueeLabel();
            this.tsSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsQb1 = new System.Windows.Forms.ToolStripButton();
            this.tsQb2 = new System.Windows.Forms.ToolStripButton();
            this.tsQb3 = new System.Windows.Forms.ToolStripButton();
            this.tsQb4 = new System.Windows.Forms.ToolStripButton();
            this.tsQb5 = new System.Windows.Forms.ToolStripButton();
            this.ss = new System.Windows.Forms.StatusStrip();
            this.tsDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsUserLogged = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsIdle = new System.Windows.Forms.ToolStripStatusLabel();
            this.nb = new DevExpress.XtraNavBar.NavBarControl();
            this.nbNotification = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.NotificationGrid = new DevExpress.XtraGrid.GridControl();
            this.loginFormBindingSource = new System.Windows.Forms.BindingSource();
            this.NotificationView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clmTransactionType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmRefNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.nbList = new DevExpress.XtraNavBar.NavBarGroup();
            this.ms.SuspendLayout();
            this.ts.SuspendLayout();
            this.ss.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nb)).BeginInit();
            this.nb.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NotificationGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginFormBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotificationView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // ms
            // 
            this.ms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miEdit,
            this.miView,
            this.miMasterData,
            this.miFranchise,
            this.miCorporate,
            this.miMarketing,
            this.miCustomerService,
            this.miCounterCash,
            this.miOperation,
            this.miAdministration,
            this.miBilling,
            this.miFinance,
            this.miAudit,
            this.miReports,
            this.miNavigator,
            this.windowToolStripMenuItem});
            this.ms.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.ms.Location = new System.Drawing.Point(0, 0);
            this.ms.Name = "ms";
            this.ms.Padding = new System.Windows.Forms.Padding(5, 1, 0, 1);
            this.ms.Size = new System.Drawing.Size(1204, 21);
            this.ms.TabIndex = 1;
            this.ms.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile_Login,
            this.miFile_Logout,
            this.miFile_Separator1,
            this.mi_File_ChangePassword,
            this.miFile_Preference,
            this.miFile_Separator2,
            this.miFile_Exit});
            this.miFile.ForeColor = System.Drawing.Color.Black;
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(37, 19);
            this.miFile.Text = "&File";
            // 
            // miFile_Login
            // 
            this.miFile_Login.ForeColor = System.Drawing.Color.Black;
            this.miFile_Login.Image = ((System.Drawing.Image)(resources.GetObject("miFile_Login.Image")));
            this.miFile_Login.Name = "miFile_Login";
            this.miFile_Login.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.miFile_Login.Size = new System.Drawing.Size(168, 22);
            this.miFile_Login.Text = "Log&in";
            // 
            // miFile_Logout
            // 
            this.miFile_Logout.Enabled = false;
            this.miFile_Logout.ForeColor = System.Drawing.Color.Black;
            this.miFile_Logout.Image = ((System.Drawing.Image)(resources.GetObject("miFile_Logout.Image")));
            this.miFile_Logout.Name = "miFile_Logout";
            this.miFile_Logout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.miFile_Logout.Size = new System.Drawing.Size(168, 22);
            this.miFile_Logout.Text = "Log&out";
            // 
            // miFile_Separator1
            // 
            this.miFile_Separator1.Name = "miFile_Separator1";
            this.miFile_Separator1.Size = new System.Drawing.Size(165, 6);
            // 
            // mi_File_ChangePassword
            // 
            this.mi_File_ChangePassword.ForeColor = System.Drawing.Color.Black;
            this.mi_File_ChangePassword.Name = "mi_File_ChangePassword";
            this.mi_File_ChangePassword.Size = new System.Drawing.Size(168, 22);
            this.mi_File_ChangePassword.Text = "Change Password";
            // 
            // miFile_Preference
            // 
            this.miFile_Preference.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile_Preference_DBConnection,
            this.userPreferencesToolStripMenuItem});
            this.miFile_Preference.ForeColor = System.Drawing.Color.Black;
            this.miFile_Preference.Name = "miFile_Preference";
            this.miFile_Preference.Size = new System.Drawing.Size(168, 22);
            this.miFile_Preference.Text = "&Preference";
            // 
            // miFile_Preference_DBConnection
            // 
            this.miFile_Preference_DBConnection.Name = "miFile_Preference_DBConnection";
            this.miFile_Preference_DBConnection.Size = new System.Drawing.Size(161, 22);
            this.miFile_Preference_DBConnection.Text = "&DB Connection";
            // 
            // userPreferencesToolStripMenuItem
            // 
            this.userPreferencesToolStripMenuItem.Name = "userPreferencesToolStripMenuItem";
            this.userPreferencesToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.userPreferencesToolStripMenuItem.Text = "User Preferences";
            this.userPreferencesToolStripMenuItem.Click += new System.EventHandler(this.userPreferencesToolStripMenuItem_Click);
            // 
            // miFile_Separator2
            // 
            this.miFile_Separator2.ForeColor = System.Drawing.Color.Black;
            this.miFile_Separator2.Name = "miFile_Separator2";
            this.miFile_Separator2.Size = new System.Drawing.Size(165, 6);
            // 
            // miFile_Exit
            // 
            this.miFile_Exit.ForeColor = System.Drawing.Color.Black;
            this.miFile_Exit.Image = ((System.Drawing.Image)(resources.GetObject("miFile_Exit.Image")));
            this.miFile_Exit.Name = "miFile_Exit";
            this.miFile_Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.miFile_Exit.Size = new System.Drawing.Size(168, 22);
            this.miFile_Exit.Text = "E&xit";
            // 
            // miEdit
            // 
            this.miEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEdit_Undo,
            this.miEdit_Redo,
            this.miEdit_Separator1,
            this.miEdit_Cut,
            this.miEdit_Copy,
            this.miEdit_Paste,
            this.clearToolStripMenuItem,
            this.tsEdit_Separator2,
            this.miEdit_SelectAll});
            this.miEdit.ForeColor = System.Drawing.Color.Black;
            this.miEdit.Name = "miEdit";
            this.miEdit.Size = new System.Drawing.Size(39, 19);
            this.miEdit.Text = "&Edit";
            // 
            // miEdit_Undo
            // 
            this.miEdit_Undo.Enabled = false;
            this.miEdit_Undo.ForeColor = System.Drawing.Color.Black;
            this.miEdit_Undo.Image = ((System.Drawing.Image)(resources.GetObject("miEdit_Undo.Image")));
            this.miEdit_Undo.Name = "miEdit_Undo";
            this.miEdit_Undo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.miEdit_Undo.Size = new System.Drawing.Size(164, 22);
            this.miEdit_Undo.Text = "&Undo";
            // 
            // miEdit_Redo
            // 
            this.miEdit_Redo.Enabled = false;
            this.miEdit_Redo.ForeColor = System.Drawing.Color.Black;
            this.miEdit_Redo.Image = ((System.Drawing.Image)(resources.GetObject("miEdit_Redo.Image")));
            this.miEdit_Redo.Name = "miEdit_Redo";
            this.miEdit_Redo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.miEdit_Redo.Size = new System.Drawing.Size(164, 22);
            this.miEdit_Redo.Text = "Re&do";
            // 
            // miEdit_Separator1
            // 
            this.miEdit_Separator1.ForeColor = System.Drawing.Color.Black;
            this.miEdit_Separator1.Name = "miEdit_Separator1";
            this.miEdit_Separator1.Size = new System.Drawing.Size(161, 6);
            // 
            // miEdit_Cut
            // 
            this.miEdit_Cut.Enabled = false;
            this.miEdit_Cut.ForeColor = System.Drawing.Color.Black;
            this.miEdit_Cut.Image = ((System.Drawing.Image)(resources.GetObject("miEdit_Cut.Image")));
            this.miEdit_Cut.Name = "miEdit_Cut";
            this.miEdit_Cut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.miEdit_Cut.Size = new System.Drawing.Size(164, 22);
            this.miEdit_Cut.Text = "Cu&t";
            // 
            // miEdit_Copy
            // 
            this.miEdit_Copy.Enabled = false;
            this.miEdit_Copy.ForeColor = System.Drawing.Color.Black;
            this.miEdit_Copy.Image = ((System.Drawing.Image)(resources.GetObject("miEdit_Copy.Image")));
            this.miEdit_Copy.Name = "miEdit_Copy";
            this.miEdit_Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.miEdit_Copy.Size = new System.Drawing.Size(164, 22);
            this.miEdit_Copy.Text = "&Copy";
            // 
            // miEdit_Paste
            // 
            this.miEdit_Paste.Enabled = false;
            this.miEdit_Paste.ForeColor = System.Drawing.Color.Black;
            this.miEdit_Paste.Image = ((System.Drawing.Image)(resources.GetObject("miEdit_Paste.Image")));
            this.miEdit_Paste.Name = "miEdit_Paste";
            this.miEdit_Paste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.miEdit_Paste.Size = new System.Drawing.Size(164, 22);
            this.miEdit_Paste.Text = "&Paste";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Enabled = false;
            this.clearToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.clearToolStripMenuItem.Text = "Cle&ar";
            // 
            // tsEdit_Separator2
            // 
            this.tsEdit_Separator2.ForeColor = System.Drawing.Color.Black;
            this.tsEdit_Separator2.Name = "tsEdit_Separator2";
            this.tsEdit_Separator2.Size = new System.Drawing.Size(161, 6);
            // 
            // miEdit_SelectAll
            // 
            this.miEdit_SelectAll.Enabled = false;
            this.miEdit_SelectAll.ForeColor = System.Drawing.Color.Black;
            this.miEdit_SelectAll.Name = "miEdit_SelectAll";
            this.miEdit_SelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.miEdit_SelectAll.Size = new System.Drawing.Size(164, 22);
            this.miEdit_SelectAll.Text = "Select All";
            // 
            // miView
            // 
            this.miView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miView_Notification,
            this.miView_StatusBar,
            this.toolStripMenuItem1,
            this.miView_About});
            this.miView.ForeColor = System.Drawing.Color.Black;
            this.miView.Name = "miView";
            this.miView.Size = new System.Drawing.Size(44, 19);
            this.miView.Text = "&View";
            // 
            // miView_Notification
            // 
            this.miView_Notification.Checked = true;
            this.miView_Notification.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miView_Notification.ForeColor = System.Drawing.Color.Black;
            this.miView_Notification.Name = "miView_Notification";
            this.miView_Notification.Size = new System.Drawing.Size(137, 22);
            this.miView_Notification.Text = "&Notification";
            // 
            // miView_StatusBar
            // 
            this.miView_StatusBar.Checked = true;
            this.miView_StatusBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miView_StatusBar.ForeColor = System.Drawing.Color.Black;
            this.miView_StatusBar.Name = "miView_StatusBar";
            this.miView_StatusBar.Size = new System.Drawing.Size(137, 22);
            this.miView_StatusBar.Text = "Status &Bar";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(134, 6);
            // 
            // miView_About
            // 
            this.miView_About.Name = "miView_About";
            this.miView_About.Size = new System.Drawing.Size(137, 22);
            this.miView_About.Text = "About";
            // 
            // miMasterData
            // 
            this.miMasterData.ForeColor = System.Drawing.Color.Black;
            this.miMasterData.Name = "miMasterData";
            this.miMasterData.Size = new System.Drawing.Size(82, 19);
            this.miMasterData.Text = "&Master Data";
            // 
            // miFranchise
            // 
            this.miFranchise.Name = "miFranchise";
            this.miFranchise.Size = new System.Drawing.Size(69, 19);
            this.miFranchise.Text = "Franchise";
            // 
            // miCorporate
            // 
            this.miCorporate.Name = "miCorporate";
            this.miCorporate.Size = new System.Drawing.Size(72, 19);
            this.miCorporate.Text = "Corporate";
            // 
            // miMarketing
            // 
            this.miMarketing.ForeColor = System.Drawing.Color.Black;
            this.miMarketing.Name = "miMarketing";
            this.miMarketing.Size = new System.Drawing.Size(73, 19);
            this.miMarketing.Text = "Marketing";
            // 
            // miCustomerService
            // 
            this.miCustomerService.ForeColor = System.Drawing.Color.Black;
            this.miCustomerService.Name = "miCustomerService";
            this.miCustomerService.Size = new System.Drawing.Size(111, 19);
            this.miCustomerService.Text = "&Customer Service";
            // 
            // miCounterCash
            // 
            this.miCounterCash.ForeColor = System.Drawing.Color.Black;
            this.miCounterCash.Name = "miCounterCash";
            this.miCounterCash.Size = new System.Drawing.Size(94, 19);
            this.miCounterCash.Text = "Cou&nter Cash ";
            // 
            // miOperation
            // 
            this.miOperation.ForeColor = System.Drawing.Color.Black;
            this.miOperation.Name = "miOperation";
            this.miOperation.Size = new System.Drawing.Size(72, 19);
            this.miOperation.Text = "&Operation";
            // 
            // miAdministration
            // 
            this.miAdministration.ForeColor = System.Drawing.Color.Black;
            this.miAdministration.Name = "miAdministration";
            this.miAdministration.Size = new System.Drawing.Size(98, 19);
            this.miAdministration.Text = "Administration";
            // 
            // miBilling
            // 
            this.miBilling.ForeColor = System.Drawing.Color.Black;
            this.miBilling.Name = "miBilling";
            this.miBilling.Size = new System.Drawing.Size(52, 19);
            this.miBilling.Text = "Billing";
            // 
            // miFinance
            // 
            this.miFinance.ForeColor = System.Drawing.Color.Black;
            this.miFinance.Name = "miFinance";
            this.miFinance.Size = new System.Drawing.Size(60, 19);
            this.miFinance.Text = "F&inance";
            // 
            // miAudit
            // 
            this.miAudit.ForeColor = System.Drawing.Color.Black;
            this.miAudit.Name = "miAudit";
            this.miAudit.Size = new System.Drawing.Size(48, 19);
            this.miAudit.Text = "Audit";
            // 
            // miReports
            // 
            this.miReports.ForeColor = System.Drawing.Color.Black;
            this.miReports.Name = "miReports";
            this.miReports.Size = new System.Drawing.Size(59, 19);
            this.miReports.Text = "Reports";
            // 
            // miNavigator
            // 
            this.miNavigator.ForeColor = System.Drawing.Color.Black;
            this.miNavigator.Name = "miNavigator";
            this.miNavigator.Size = new System.Drawing.Size(77, 19);
            this.miNavigator.Text = "&Navigation";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.arrangeAllToolStripMenuItem});
            this.windowToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 19);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.cascadeToolStripMenuItem.Text = "Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // arrangeAllToolStripMenuItem
            // 
            this.arrangeAllToolStripMenuItem.Name = "arrangeAllToolStripMenuItem";
            this.arrangeAllToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.arrangeAllToolStripMenuItem.Text = "Arrange All";
            this.arrangeAllToolStripMenuItem.Click += new System.EventHandler(this.arrangeAllToolStripMenuItem_Click);
            // 
            // ts
            // 
            this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnLogin,
            this.tsBtnLogout,
            this.tsSeparator1,
            this.tsBtnExit,
            this.taSeparator2,
            this.toolStripLabel2,
            this.tsSeparator3,
            this.toolStripLabel1,
            this.tsQb1,
            this.tsQb2,
            this.tsQb3,
            this.tsQb4,
            this.tsQb5});
            this.ts.Location = new System.Drawing.Point(0, 21);
            this.ts.Name = "ts";
            this.ts.Padding = new System.Windows.Forms.Padding(0);
            this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ts.Size = new System.Drawing.Size(1204, 37);
            this.ts.TabIndex = 2;
            // 
            // tsBtnLogin
            // 
            this.tsBtnLogin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnLogin.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnLogin.Image")));
            this.tsBtnLogin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsBtnLogin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnLogin.Name = "tsBtnLogin";
            this.tsBtnLogin.Size = new System.Drawing.Size(34, 34);
            this.tsBtnLogin.Text = "Login";
            // 
            // tsBtnLogout
            // 
            this.tsBtnLogout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnLogout.Enabled = false;
            this.tsBtnLogout.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnLogout.Image")));
            this.tsBtnLogout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsBtnLogout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnLogout.Name = "tsBtnLogout";
            this.tsBtnLogout.Size = new System.Drawing.Size(34, 34);
            this.tsBtnLogout.Text = "Logout";
            // 
            // tsSeparator1
            // 
            this.tsSeparator1.Name = "tsSeparator1";
            this.tsSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // tsBtnExit
            // 
            this.tsBtnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnExit.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnExit.Image")));
            this.tsBtnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsBtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnExit.Name = "tsBtnExit";
            this.tsBtnExit.Size = new System.Drawing.Size(34, 34);
            this.tsBtnExit.Text = "Exit Application";
            // 
            // taSeparator2
            // 
            this.taSeparator2.Name = "taSeparator2";
            this.taSeparator2.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.AutoSize = false;
            this.toolStripLabel2.BackColor = System.Drawing.Color.Black;
            this.toolStripLabel2.Border = false;
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel2.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel2.Interval = 10000;
            this.toolStripLabel2.MarqueeText = null;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(300, 34);
            this.toolStripLabel2.Text = "SISCO - PT. Globalindo Dua Satu Ekspres";
            this.toolStripLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsSeparator3
            // 
            this.tsSeparator3.Name = "tsSeparator3";
            this.tsSeparator3.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Blue;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(128, 34);
            this.toolStripLabel1.Text = "Quick Launch >>";
            // 
            // tsQb1
            // 
            this.tsQb1.AutoSize = false;
            this.tsQb1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsQb1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsQb1.Enabled = false;
            this.tsQb1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.tsQb1.ForeColor = System.Drawing.Color.White;
            this.tsQb1.Image = ((System.Drawing.Image)(resources.GetObject("tsQb1.Image")));
            this.tsQb1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsQb1.Margin = new System.Windows.Forms.Padding(0);
            this.tsQb1.Name = "tsQb1";
            this.tsQb1.Size = new System.Drawing.Size(34, 34);
            this.tsQb1.Text = "1";
            this.tsQb1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // tsQb2
            // 
            this.tsQb2.AutoSize = false;
            this.tsQb2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsQb2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsQb2.Enabled = false;
            this.tsQb2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.tsQb2.ForeColor = System.Drawing.Color.White;
            this.tsQb2.Image = ((System.Drawing.Image)(resources.GetObject("tsQb2.Image")));
            this.tsQb2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsQb2.Name = "tsQb2";
            this.tsQb2.Size = new System.Drawing.Size(34, 34);
            this.tsQb2.Text = "2";
            // 
            // tsQb3
            // 
            this.tsQb3.AutoSize = false;
            this.tsQb3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsQb3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsQb3.Enabled = false;
            this.tsQb3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.tsQb3.ForeColor = System.Drawing.Color.White;
            this.tsQb3.Image = ((System.Drawing.Image)(resources.GetObject("tsQb3.Image")));
            this.tsQb3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsQb3.Name = "tsQb3";
            this.tsQb3.Size = new System.Drawing.Size(34, 34);
            this.tsQb3.Text = "3";
            // 
            // tsQb4
            // 
            this.tsQb4.AutoSize = false;
            this.tsQb4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsQb4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsQb4.Enabled = false;
            this.tsQb4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.tsQb4.ForeColor = System.Drawing.Color.White;
            this.tsQb4.Image = ((System.Drawing.Image)(resources.GetObject("tsQb4.Image")));
            this.tsQb4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsQb4.Name = "tsQb4";
            this.tsQb4.Size = new System.Drawing.Size(34, 34);
            this.tsQb4.Text = "4";
            // 
            // tsQb5
            // 
            this.tsQb5.AutoSize = false;
            this.tsQb5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsQb5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsQb5.Enabled = false;
            this.tsQb5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.tsQb5.ForeColor = System.Drawing.Color.White;
            this.tsQb5.Image = ((System.Drawing.Image)(resources.GetObject("tsQb5.Image")));
            this.tsQb5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsQb5.Name = "tsQb5";
            this.tsQb5.Size = new System.Drawing.Size(34, 34);
            this.tsQb5.Tag = "";
            this.tsQb5.Text = "5";
            // 
            // ss
            // 
            this.ss.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDate,
            this.tsUserLogged,
            this.tsIdle});
            this.ss.Location = new System.Drawing.Point(0, 536);
            this.ss.Name = "ss";
            this.ss.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.ss.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ss.Size = new System.Drawing.Size(1204, 24);
            this.ss.TabIndex = 5;
            this.ss.Text = "statusStrip1";
            // 
            // tsDate
            // 
            this.tsDate.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsDate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsDate.Name = "tsDate";
            this.tsDate.Size = new System.Drawing.Size(151, 19);
            this.tsDate.Text = "Monday, 2 June 2014 14:28";
            // 
            // tsUserLogged
            // 
            this.tsUserLogged.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsUserLogged.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsUserLogged.Name = "tsUserLogged";
            this.tsUserLogged.Size = new System.Drawing.Size(47, 19);
            this.tsUserLogged.Text = "Admin";
            // 
            // tsIdle
            // 
            this.tsIdle.Name = "tsIdle";
            this.tsIdle.Size = new System.Drawing.Size(49, 19);
            this.tsIdle.Text = "LastInpt";
            // 
            // nb
            // 
            this.nb.ActiveGroup = this.nbNotification;
            this.nb.Controls.Add(this.navBarGroupControlContainer1);
            this.nb.Controls.Add(this.navBarGroupControlContainer2);
            this.nb.Dock = System.Windows.Forms.DockStyle.Left;
            this.nb.ForeColor = System.Drawing.Color.Black;
            this.nb.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbNotification,
            this.nbList});
            this.nb.Location = new System.Drawing.Point(0, 58);
            this.nb.Margin = new System.Windows.Forms.Padding(2);
            this.nb.Name = "nb";
            this.nb.OptionsNavPane.ExpandedWidth = 302;
            this.nb.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Collapsed;
            this.nb.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.nb.Size = new System.Drawing.Size(37, 478);
            this.nb.TabIndex = 6;
            this.nb.Text = "Notification";
            this.nb.View = new DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneViewInfoRegistrator();
            this.nb.Visible = false;
            // 
            // nbNotification
            // 
            this.nbNotification.Caption = "Notification";
            this.nbNotification.ControlContainer = this.navBarGroupControlContainer1;
            this.nbNotification.Expanded = true;
            this.nbNotification.GroupClientHeight = 373;
            this.nbNotification.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbNotification.Name = "nbNotification";
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Controls.Add(this.button1);
            this.navBarGroupControlContainer1.Controls.Add(this.NotificationGrid);
            this.navBarGroupControlContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(302, 400);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::SISCO.Properties.Resources.icon_refresh_small;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(16, 19);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NotificationGrid
            // 
            this.NotificationGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NotificationGrid.DataSource = this.loginFormBindingSource;
            this.NotificationGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotificationGrid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.NotificationGrid.Location = new System.Drawing.Point(0, 0);
            this.NotificationGrid.MainView = this.NotificationView;
            this.NotificationGrid.Margin = new System.Windows.Forms.Padding(2);
            this.NotificationGrid.Name = "NotificationGrid";
            this.NotificationGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.NotificationGrid.Size = new System.Drawing.Size(302, 400);
            this.NotificationGrid.TabIndex = 0;
            this.NotificationGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.NotificationView});
            // 
            // loginFormBindingSource
            // 
            this.loginFormBindingSource.DataSource = typeof(SISCO.Modal.LoginForm);
            // 
            // NotificationView
            // 
            this.NotificationView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clmTransactionType,
            this.clmRefNumber,
            this.clmDescription,
            this.clmDate,
            this.clmDelete});
            this.NotificationView.GridControl = this.NotificationGrid;
            this.NotificationView.GroupCount = 1;
            this.NotificationView.GroupFormat = "[#image]{1} {2}";
            this.NotificationView.Name = "NotificationView";
            this.NotificationView.OptionsBehavior.AutoExpandAllGroups = true;
            this.NotificationView.OptionsBehavior.Editable = false;
            this.NotificationView.OptionsView.ShowGroupPanel = false;
            this.NotificationView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.clmTransactionType, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // clmTransactionType
            // 
            this.clmTransactionType.FieldName = "TransactionType";
            this.clmTransactionType.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Value;
            this.clmTransactionType.Name = "clmTransactionType";
            this.clmTransactionType.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.clmTransactionType.Visible = true;
            this.clmTransactionType.VisibleIndex = 0;
            // 
            // clmRefNumber
            // 
            this.clmRefNumber.Caption = "Ref Number";
            this.clmRefNumber.FieldName = "RefNumber";
            this.clmRefNumber.Name = "clmRefNumber";
            this.clmRefNumber.Visible = true;
            this.clmRefNumber.VisibleIndex = 0;
            this.clmRefNumber.Width = 114;
            // 
            // clmDescription
            // 
            this.clmDescription.Caption = "Description";
            this.clmDescription.FieldName = "Description";
            this.clmDescription.Name = "clmDescription";
            this.clmDescription.Visible = true;
            this.clmDescription.VisibleIndex = 1;
            this.clmDescription.Width = 85;
            // 
            // clmDate
            // 
            this.clmDate.Caption = "Date";
            this.clmDate.DisplayFormat.FormatString = "d/M H:mm";
            this.clmDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clmDate.FieldName = "DateAssigned";
            this.clmDate.Name = "clmDate";
            this.clmDate.Visible = true;
            this.clmDate.VisibleIndex = 2;
            this.clmDate.Width = 65;
            // 
            // clmDelete
            // 
            this.clmDelete.ColumnEdit = this.repositoryItemButtonEdit1;
            this.clmDelete.Name = "clmDelete";
            this.clmDelete.Visible = true;
            this.clmDelete.VisibleIndex = 3;
            this.clmDelete.Width = 24;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            serializableAppearanceObject1.ForeColor = System.Drawing.Color.Red;
            serializableAppearanceObject1.Options.UseForeColor = true;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(246, 272);
            this.navBarGroupControlContainer2.TabIndex = 1;
            // 
            // nbList
            // 
            this.nbList.Caption = "Display Status";
            this.nbList.ControlContainer = this.navBarGroupControlContainer2;
            this.nbList.GroupClientHeight = 80;
            this.nbList.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbList.Name = "nbList";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 560);
            this.Controls.Add(this.nb);
            this.Controls.Add(this.ss);
            this.Controls.Add(this.ts);
            this.Controls.Add(this.ms);
            this.ForeColor = System.Drawing.Color.Black;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.ms;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "SISCO - PT. Globalindo Dua Satu Ekspres";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ms.ResumeLayout(false);
            this.ms.PerformLayout();
            this.ts.ResumeLayout(false);
            this.ts.PerformLayout();
            this.ss.ResumeLayout(false);
            this.ss.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nb)).EndInit();
            this.nb.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NotificationGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginFormBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotificationView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ms;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miFile_Login;
        private System.Windows.Forms.ToolStripMenuItem miFile_Logout;
        private System.Windows.Forms.ToolStripSeparator miFile_Separator1;
        private System.Windows.Forms.ToolStripMenuItem miFile_Exit;
        private System.Windows.Forms.ToolStrip ts;
        private System.Windows.Forms.ToolStripButton tsBtnLogin;
        private System.Windows.Forms.ToolStripButton tsBtnLogout;
        private System.Windows.Forms.ToolStripSeparator tsSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnExit;
        private System.Windows.Forms.ToolStripSeparator taSeparator2;
        private System.Windows.Forms.ToolStripSeparator tsSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsQb1;
        private System.Windows.Forms.ToolStripButton tsQb2;
        private System.Windows.Forms.ToolStripButton tsQb3;
        private System.Windows.Forms.ToolStripButton tsQb4;
        private System.Windows.Forms.ToolStripButton tsQb5;
        private System.Windows.Forms.ToolStripMenuItem miEdit;
        private System.Windows.Forms.ToolStripMenuItem miEdit_Undo;
        private System.Windows.Forms.ToolStripMenuItem miEdit_Redo;
        private System.Windows.Forms.ToolStripSeparator miEdit_Separator1;
        private System.Windows.Forms.ToolStripMenuItem miEdit_Cut;
        private System.Windows.Forms.ToolStripMenuItem miEdit_Copy;
        private System.Windows.Forms.ToolStripMenuItem miEdit_Paste;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator tsEdit_Separator2;
        private System.Windows.Forms.ToolStripMenuItem miEdit_SelectAll;
        private System.Windows.Forms.ToolStripMenuItem miView;
        private System.Windows.Forms.ToolStripMenuItem miView_Notification;
        private System.Windows.Forms.ToolStripMenuItem miView_StatusBar;
        private System.Windows.Forms.ToolStripMenuItem miMasterData;
        private System.Windows.Forms.ToolStripMenuItem miCustomerService;
        private System.Windows.Forms.ToolStripMenuItem miCounterCash;
        private System.Windows.Forms.ToolStripMenuItem miOperation;
        private System.Windows.Forms.StatusStrip ss;
        private DevExpress.XtraNavBar.NavBarControl nb;
        private DevExpress.XtraNavBar.NavBarGroup nbNotification;
        private System.Windows.Forms.ToolStripMenuItem miFinance;
        private System.Windows.Forms.ToolStripMenuItem miFile_Preference;
        private System.Windows.Forms.ToolStripMenuItem miFile_Preference_DBConnection;
        private System.Windows.Forms.ToolStripSeparator miFile_Separator2;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private DevExpress.XtraNavBar.NavBarGroup nbList;
        private System.Windows.Forms.ToolStripMenuItem miNavigator;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer2;
        private System.Windows.Forms.ToolStripStatusLabel tsDate;
        private System.Windows.Forms.ToolStripStatusLabel tsUserLogged;
        private System.Windows.Forms.ToolStripMenuItem miMarketing;
        private System.Windows.Forms.ToolStripMenuItem miAdministration;
        private System.Windows.Forms.ToolStripMenuItem miBilling;
        private System.Windows.Forms.ToolStripMenuItem miAudit;
        private System.Windows.Forms.ToolStripMenuItem miReports;
        private System.Windows.Forms.ToolStripMenuItem userPreferencesToolStripMenuItem;
        private System.Windows.Forms.BindingSource loginFormBindingSource;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraGrid.GridControl NotificationGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView NotificationView;
        private DevExpress.XtraGrid.Columns.GridColumn clmTransactionType;
        private DevExpress.XtraGrid.Columns.GridColumn clmRefNumber;
        private DevExpress.XtraGrid.Columns.GridColumn clmDescription;
        private DevExpress.XtraGrid.Columns.GridColumn clmDate;
        private DevExpress.XtraGrid.Columns.GridColumn clmDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mi_File_ChangePassword;
        private MarqueeLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripMenuItem miFranchise;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miView_About;
        private System.Windows.Forms.ToolStripMenuItem miCorporate;
        private System.Windows.Forms.ToolStripStatusLabel tsIdle;
    }
}

