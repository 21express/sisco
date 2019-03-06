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
            this.ms = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miFile_Login = new System.Windows.Forms.ToolStripMenuItem();
            this.miFile_Logout = new System.Windows.Forms.ToolStripMenuItem();
            this.miFile_Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miFile_Preference = new System.Windows.Forms.ToolStripMenuItem();
            this.miFile_Preference_DBConnection = new System.Windows.Forms.ToolStripMenuItem();
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
            this.miMasterData = new System.Windows.Forms.ToolStripMenuItem();
            this.miMarketing = new System.Windows.Forms.ToolStripMenuItem();
            this.miCustomerService = new System.Windows.Forms.ToolStripMenuItem();
            this.miCounterCash = new System.Windows.Forms.ToolStripMenuItem();
            this.miOperation = new System.Windows.Forms.ToolStripMenuItem();
            this.miAdministration = new System.Windows.Forms.ToolStripMenuItem();
            this.miBilling = new System.Windows.Forms.ToolStripMenuItem();
            this.miFinance = new System.Windows.Forms.ToolStripMenuItem();
            this.miAccounting = new System.Windows.Forms.ToolStripMenuItem();
            this.miNavigator = new System.Windows.Forms.ToolStripMenuItem();
            this.ts = new System.Windows.Forms.ToolStrip();
            this.tsBtnLogin = new System.Windows.Forms.ToolStripButton();
            this.tsBtnLogout = new System.Windows.Forms.ToolStripButton();
            this.tsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnExit = new System.Windows.Forms.ToolStripButton();
            this.taSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
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
            this.nb = new DevExpress.XtraNavBar.NavBarControl();
            this.nbNotification = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.NotificationGrid = new DevExpress.XtraGrid.GridControl();
            this.NotificationView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clmDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.nbList = new DevExpress.XtraNavBar.NavBarGroup();
            this.ms.SuspendLayout();
            this.ts.SuspendLayout();
            this.ss.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nb)).BeginInit();
            this.nb.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NotificationGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotificationView)).BeginInit();
            this.SuspendLayout();
            // 
            // ms
            // 
            this.ms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miEdit,
            this.miView,
            this.miMasterData,
            this.miMarketing,
            this.miCustomerService,
            this.miCounterCash,
            this.miOperation,
            this.miAdministration,
            this.miBilling,
            this.miFinance,
            this.miAccounting,
            this.miNavigator});
            this.ms.Location = new System.Drawing.Point(0, 0);
            this.ms.Name = "ms";
            this.ms.Size = new System.Drawing.Size(766, 24);
            this.ms.TabIndex = 1;
            this.ms.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile_Login,
            this.miFile_Logout,
            this.miFile_Separator1,
            this.miFile_Preference,
            this.miFile_Separator2,
            this.miFile_Exit});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(37, 20);
            this.miFile.Text = "&File";
            // 
            // miFile_Login
            // 
            this.miFile_Login.Image = ((System.Drawing.Image)(resources.GetObject("miFile_Login.Image")));
            this.miFile_Login.Name = "miFile_Login";
            this.miFile_Login.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.miFile_Login.Size = new System.Drawing.Size(155, 22);
            this.miFile_Login.Text = "Log&in";
            // 
            // miFile_Logout
            // 
            this.miFile_Logout.Enabled = false;
            this.miFile_Logout.Image = ((System.Drawing.Image)(resources.GetObject("miFile_Logout.Image")));
            this.miFile_Logout.Name = "miFile_Logout";
            this.miFile_Logout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.miFile_Logout.Size = new System.Drawing.Size(155, 22);
            this.miFile_Logout.Text = "L&ogout";
            // 
            // miFile_Separator1
            // 
            this.miFile_Separator1.Name = "miFile_Separator1";
            this.miFile_Separator1.Size = new System.Drawing.Size(152, 6);
            // 
            // miFile_Preference
            // 
            this.miFile_Preference.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile_Preference_DBConnection});
            this.miFile_Preference.Name = "miFile_Preference";
            this.miFile_Preference.Size = new System.Drawing.Size(155, 22);
            this.miFile_Preference.Text = "&Preference";
            // 
            // miFile_Preference_DBConnection
            // 
            this.miFile_Preference_DBConnection.Name = "miFile_Preference_DBConnection";
            this.miFile_Preference_DBConnection.Size = new System.Drawing.Size(154, 22);
            this.miFile_Preference_DBConnection.Text = "&DB Connection";
            // 
            // miFile_Separator2
            // 
            this.miFile_Separator2.Name = "miFile_Separator2";
            this.miFile_Separator2.Size = new System.Drawing.Size(152, 6);
            // 
            // miFile_Exit
            // 
            this.miFile_Exit.Image = ((System.Drawing.Image)(resources.GetObject("miFile_Exit.Image")));
            this.miFile_Exit.Name = "miFile_Exit";
            this.miFile_Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.miFile_Exit.Size = new System.Drawing.Size(155, 22);
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
            this.miEdit.Name = "miEdit";
            this.miEdit.Size = new System.Drawing.Size(39, 20);
            this.miEdit.Text = "&Edit";
            // 
            // miEdit_Undo
            // 
            this.miEdit_Undo.Enabled = false;
            this.miEdit_Undo.Image = ((System.Drawing.Image)(resources.GetObject("miEdit_Undo.Image")));
            this.miEdit_Undo.Name = "miEdit_Undo";
            this.miEdit_Undo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.miEdit_Undo.Size = new System.Drawing.Size(164, 22);
            this.miEdit_Undo.Text = "&Undo";
            // 
            // miEdit_Redo
            // 
            this.miEdit_Redo.Enabled = false;
            this.miEdit_Redo.Image = ((System.Drawing.Image)(resources.GetObject("miEdit_Redo.Image")));
            this.miEdit_Redo.Name = "miEdit_Redo";
            this.miEdit_Redo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.miEdit_Redo.Size = new System.Drawing.Size(164, 22);
            this.miEdit_Redo.Text = "Re&do";
            // 
            // miEdit_Separator1
            // 
            this.miEdit_Separator1.Name = "miEdit_Separator1";
            this.miEdit_Separator1.Size = new System.Drawing.Size(161, 6);
            // 
            // miEdit_Cut
            // 
            this.miEdit_Cut.Enabled = false;
            this.miEdit_Cut.Image = ((System.Drawing.Image)(resources.GetObject("miEdit_Cut.Image")));
            this.miEdit_Cut.Name = "miEdit_Cut";
            this.miEdit_Cut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.miEdit_Cut.Size = new System.Drawing.Size(164, 22);
            this.miEdit_Cut.Text = "Cu&t";
            // 
            // miEdit_Copy
            // 
            this.miEdit_Copy.Enabled = false;
            this.miEdit_Copy.Image = ((System.Drawing.Image)(resources.GetObject("miEdit_Copy.Image")));
            this.miEdit_Copy.Name = "miEdit_Copy";
            this.miEdit_Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.miEdit_Copy.Size = new System.Drawing.Size(164, 22);
            this.miEdit_Copy.Text = "&Copy";
            // 
            // miEdit_Paste
            // 
            this.miEdit_Paste.Enabled = false;
            this.miEdit_Paste.Image = ((System.Drawing.Image)(resources.GetObject("miEdit_Paste.Image")));
            this.miEdit_Paste.Name = "miEdit_Paste";
            this.miEdit_Paste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.miEdit_Paste.Size = new System.Drawing.Size(164, 22);
            this.miEdit_Paste.Text = "&Paste";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Enabled = false;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.clearToolStripMenuItem.Text = "Cle&ar";
            // 
            // tsEdit_Separator2
            // 
            this.tsEdit_Separator2.Name = "tsEdit_Separator2";
            this.tsEdit_Separator2.Size = new System.Drawing.Size(161, 6);
            // 
            // miEdit_SelectAll
            // 
            this.miEdit_SelectAll.Enabled = false;
            this.miEdit_SelectAll.Name = "miEdit_SelectAll";
            this.miEdit_SelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.miEdit_SelectAll.Size = new System.Drawing.Size(164, 22);
            this.miEdit_SelectAll.Text = "Select All";
            // 
            // miView
            // 
            this.miView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miView_Notification,
            this.miView_StatusBar});
            this.miView.Name = "miView";
            this.miView.Size = new System.Drawing.Size(44, 20);
            this.miView.Text = "&View";
            // 
            // miView_Notification
            // 
            this.miView_Notification.Checked = true;
            this.miView_Notification.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miView_Notification.Name = "miView_Notification";
            this.miView_Notification.Size = new System.Drawing.Size(137, 22);
            this.miView_Notification.Text = "&Notification";
            // 
            // miView_StatusBar
            // 
            this.miView_StatusBar.Checked = true;
            this.miView_StatusBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miView_StatusBar.Name = "miView_StatusBar";
            this.miView_StatusBar.Size = new System.Drawing.Size(137, 22);
            this.miView_StatusBar.Text = "Status &Bar";
            // 
            // miMasterData
            // 
            this.miMasterData.Name = "miMasterData";
            this.miMasterData.Size = new System.Drawing.Size(82, 20);
            this.miMasterData.Text = "&Master Data";
            // 
            // miMarketing
            // 
            this.miMarketing.Name = "miMarketing";
            this.miMarketing.Size = new System.Drawing.Size(73, 20);
            this.miMarketing.Text = "Marketing";
            // 
            // miCustomerService
            // 
            this.miCustomerService.Name = "miCustomerService";
            this.miCustomerService.Size = new System.Drawing.Size(111, 20);
            this.miCustomerService.Text = "&Customer Service";
            // 
            // miCounterCash
            // 
            this.miCounterCash.Name = "miCounterCash";
            this.miCounterCash.Size = new System.Drawing.Size(94, 20);
            this.miCounterCash.Text = "Cou&nter Cash ";
            // 
            // miOperation
            // 
            this.miOperation.Name = "miOperation";
            this.miOperation.Size = new System.Drawing.Size(72, 20);
            this.miOperation.Text = "&Operation";
            // 
            // miAdministration
            // 
            this.miAdministration.Name = "miAdministration";
            this.miAdministration.Size = new System.Drawing.Size(98, 20);
            this.miAdministration.Text = "Administration";
            // 
            // miBilling
            // 
            this.miBilling.Name = "miBilling";
            this.miBilling.Size = new System.Drawing.Size(52, 20);
            this.miBilling.Text = "Billing";
            // 
            // miFinance
            // 
            this.miFinance.Name = "miFinance";
            this.miFinance.Size = new System.Drawing.Size(60, 20);
            this.miFinance.Text = "F&inance";
            // 
            // miAccounting
            // 
            this.miAccounting.Name = "miAccounting";
            this.miAccounting.Size = new System.Drawing.Size(81, 20);
            this.miAccounting.Text = "Accounting";
            // 
            // miNavigator
            // 
            this.miNavigator.Name = "miNavigator";
            this.miNavigator.Size = new System.Drawing.Size(77, 20);
            this.miNavigator.Text = "&Navigation";
            // 
            // ts
            // 
            this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnLogin,
            this.tsBtnLogout,
            this.tsSeparator1,
            this.tsBtnExit,
            this.taSeparator2,
            this.toolStripTextBox1,
            this.tsSeparator3,
            this.toolStripLabel1,
            this.tsQb1,
            this.tsQb2,
            this.tsQb3,
            this.tsQb4,
            this.tsQb5});
            this.ts.Location = new System.Drawing.Point(0, 24);
            this.ts.Name = "ts";
            this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ts.Size = new System.Drawing.Size(766, 37);
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
            this.tsBtnLogin.Text = "toolStripButton1";
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
            this.tsBtnLogout.Text = "toolStripButton1";
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
            this.tsBtnExit.Text = "toolStripButton1";
            // 
            // taSeparator2
            // 
            this.taSeparator2.Name = "taSeparator2";
            this.taSeparator2.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.BackColor = System.Drawing.Color.Black;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Meiryo", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(200, 25);
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
            this.tsUserLogged});
            this.ss.Location = new System.Drawing.Point(0, 463);
            this.ss.Name = "ss";
            this.ss.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ss.Size = new System.Drawing.Size(766, 24);
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
            this.tsUserLogged.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsUserLogged.Name = "tsUserLogged";
            this.tsUserLogged.Size = new System.Drawing.Size(43, 19);
            this.tsUserLogged.Text = "Admin";
            this.tsUserLogged.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nb
            // 
            this.nb.ActiveGroup = this.nbNotification;
            this.nb.Controls.Add(this.navBarGroupControlContainer1);
            this.nb.Controls.Add(this.navBarGroupControlContainer2);
            this.nb.Dock = System.Windows.Forms.DockStyle.Left;
            this.nb.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbNotification,
            this.nbList});
            this.nb.Location = new System.Drawing.Point(0, 61);
            this.nb.Name = "nb";
            this.nb.OptionsNavPane.ExpandedWidth = 247;
            this.nb.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Collapsed;
            this.nb.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.nb.Size = new System.Drawing.Size(37, 402);
            this.nb.TabIndex = 6;
            this.nb.Text = "Notification";
            this.nb.View = new DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneViewInfoRegistrator();
            // 
            // nbNotification
            // 
            this.nbNotification.Caption = "Notification";
            this.nbNotification.ControlContainer = this.navBarGroupControlContainer1;
            this.nbNotification.Expanded = true;
            this.nbNotification.GroupClientHeight = 80;
            this.nbNotification.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbNotification.Name = "nbNotification";
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Controls.Add(this.NotificationGrid);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(247, 273);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // NotificationGrid
            // 
            this.NotificationGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotificationGrid.Location = new System.Drawing.Point(0, 0);
            this.NotificationGrid.MainView = this.NotificationView;
            this.NotificationGrid.Name = "NotificationGrid";
            this.NotificationGrid.Size = new System.Drawing.Size(247, 273);
            this.NotificationGrid.TabIndex = 0;
            this.NotificationGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.NotificationView});
            // 
            // NotificationView
            // 
            this.NotificationView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clmDescription,
            this.clmDate});
            this.NotificationView.GridControl = this.NotificationGrid;
            this.NotificationView.Name = "NotificationView";
            this.NotificationView.OptionsView.ShowGroupPanel = false;
            // 
            // clmDescription
            // 
            this.clmDescription.Caption = "Description";
            this.clmDescription.Name = "clmDescription";
            this.clmDescription.Visible = true;
            this.clmDescription.VisibleIndex = 0;
            // 
            // clmDate
            // 
            this.clmDate.Caption = "Date";
            this.clmDate.DisplayFormat.FormatString = "d";
            this.clmDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clmDate.Name = "clmDate";
            this.clmDate.Visible = true;
            this.clmDate.VisibleIndex = 1;
            // 
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(247, 273);
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
            this.ClientSize = new System.Drawing.Size(766, 487);
            this.Controls.Add(this.nb);
            this.Controls.Add(this.ss);
            this.Controls.Add(this.ts);
            this.Controls.Add(this.ms);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.ms;
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
            ((System.ComponentModel.ISupportInitialize)(this.NotificationView)).EndInit();
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
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
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
        private DevExpress.XtraGrid.GridControl NotificationGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView NotificationView;
        private DevExpress.XtraGrid.Columns.GridColumn clmDescription;
        private DevExpress.XtraGrid.Columns.GridColumn clmDate;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer2;
        private System.Windows.Forms.ToolStripStatusLabel tsDate;
        private System.Windows.Forms.ToolStripStatusLabel tsUserLogged;
        private System.Windows.Forms.ToolStripMenuItem miMarketing;
        private System.Windows.Forms.ToolStripMenuItem miAdministration;
        private System.Windows.Forms.ToolStripMenuItem miBilling;
        private System.Windows.Forms.ToolStripMenuItem miAccounting;
    }
}

