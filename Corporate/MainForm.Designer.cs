using SISCO.App.Corporate;

namespace Corporate
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
            this.st = new System.Windows.Forms.StatusStrip();
            this.tsDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsCorporate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsAnnouncement = new Corporate.Presentation.Common.Component.MarqueeLabel();
            this.rbApplication = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbApplication_SignIn = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbLogin = new DevExpress.XtraBars.BarButtonItem();
            this.rbLogout = new DevExpress.XtraBars.BarButtonItem();
            this.rbExit = new DevExpress.XtraBars.BarButtonItem();
            this.rbApplication_Preference = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbChangePassword = new DevExpress.XtraBars.BarButtonItem();
            this.rbPrinterPreference = new DevExpress.XtraBars.BarButtonItem();
            this.rbApplication_About = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbAbout_Info = new DevExpress.XtraBars.BarButtonItem();
            this.rbA = new DevExpress.XtraBars.BarButtonItem();
            this.rb = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.rbGoFirst = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPageCategory1 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonPageCategory2 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.miMasterData = new System.Windows.Forms.ToolStripMenuItem();
            this.ms = new System.Windows.Forms.MenuStrip();
            this.miCustomerService = new System.Windows.Forms.ToolStripMenuItem();
            this.miDataEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.miReport = new System.Windows.Forms.ToolStripMenuItem();
            this.st.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).BeginInit();
            this.ms.SuspendLayout();
            this.SuspendLayout();
            // 
            // st
            // 
            this.st.BackColor = System.Drawing.Color.WhiteSmoke;
            this.st.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDate,
            this.tsUser,
            this.tsCorporate,
            this.tsAnnouncement});
            this.st.Location = new System.Drawing.Point(0, 482);
            this.st.Name = "st";
            this.st.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.st.Size = new System.Drawing.Size(896, 24);
            this.st.TabIndex = 0;
            this.st.Text = "statusStrip1";
            // 
            // tsDate
            // 
            this.tsDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tsDate.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsDate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsDate.Name = "tsDate";
            this.tsDate.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.tsDate.Size = new System.Drawing.Size(125, 19);
            this.tsDate.Text = "Friday, 18 Sep 2015";
            this.tsDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsUser
            // 
            this.tsUser.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tsUser.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsUser.Name = "tsUser";
            this.tsUser.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.tsUser.Size = new System.Drawing.Size(62, 19);
            this.tsUser.Text = "Admin";
            this.tsUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsCorporate
            // 
            this.tsCorporate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tsCorporate.Name = "tsCorporate";
            this.tsCorporate.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.tsCorporate.Size = new System.Drawing.Size(75, 19);
            this.tsCorporate.Text = "Corporate";
            this.tsCorporate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsAnnouncement
            // 
            this.tsAnnouncement.AutoSize = false;
            this.tsAnnouncement.BackColor = System.Drawing.Color.Black;
            this.tsAnnouncement.Border = false;
            this.tsAnnouncement.ForeColor = System.Drawing.Color.White;
            this.tsAnnouncement.Interval = 10000;
            this.tsAnnouncement.MarqueeText = null;
            this.tsAnnouncement.Name = "tsAnnouncement";
            this.tsAnnouncement.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsAnnouncement.Size = new System.Drawing.Size(550, 19);
            this.tsAnnouncement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbApplication
            // 
            this.rbApplication.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbApplication_SignIn,
            this.rbApplication_Preference,
            this.rbApplication_About});
            this.rbApplication.Name = "rbApplication";
            this.rbApplication.Text = "Application";
            // 
            // rbApplication_SignIn
            // 
            this.rbApplication_SignIn.ItemLinks.Add(this.rbLogin);
            this.rbApplication_SignIn.ItemLinks.Add(this.rbLogout);
            this.rbApplication_SignIn.ItemLinks.Add(this.rbExit);
            this.rbApplication_SignIn.Name = "rbApplication_SignIn";
            this.rbApplication_SignIn.Text = "Sign In";
            // 
            // rbLogin
            // 
            this.rbLogin.Caption = "Login";
            this.rbLogin.Id = 4;
            this.rbLogin.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("rbLogin.LargeGlyph")));
            this.rbLogin.LargeWidth = 50;
            this.rbLogin.Name = "rbLogin";
            // 
            // rbLogout
            // 
            this.rbLogout.Caption = "Logout";
            this.rbLogout.Enabled = false;
            this.rbLogout.Glyph = ((System.Drawing.Image)(resources.GetObject("rbLogout.Glyph")));
            this.rbLogout.Id = 8;
            this.rbLogout.Name = "rbLogout";
            // 
            // rbExit
            // 
            this.rbExit.Caption = "Exit";
            this.rbExit.Glyph = ((System.Drawing.Image)(resources.GetObject("rbExit.Glyph")));
            this.rbExit.Id = 9;
            this.rbExit.Name = "rbExit";
            // 
            // rbApplication_Preference
            // 
            this.rbApplication_Preference.ItemLinks.Add(this.rbChangePassword);
            this.rbApplication_Preference.ItemLinks.Add(this.rbPrinterPreference);
            this.rbApplication_Preference.Name = "rbApplication_Preference";
            this.rbApplication_Preference.Text = "Preference";
            // 
            // rbChangePassword
            // 
            this.rbChangePassword.Caption = "Change Password";
            this.rbChangePassword.Enabled = false;
            this.rbChangePassword.Id = 13;
            this.rbChangePassword.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("rbChangePassword.LargeGlyph")));
            this.rbChangePassword.Name = "rbChangePassword";
            // 
            // rbPrinterPreference
            // 
            this.rbPrinterPreference.Caption = "Printer Preference";
            this.rbPrinterPreference.Enabled = false;
            this.rbPrinterPreference.Id = 14;
            this.rbPrinterPreference.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("rbPrinterPreference.LargeGlyph")));
            this.rbPrinterPreference.Name = "rbPrinterPreference";
            // 
            // rbApplication_About
            // 
            this.rbApplication_About.ItemLinks.Add(this.rbAbout_Info);
            this.rbApplication_About.Name = "rbApplication_About";
            this.rbApplication_About.Text = "Information";
            // 
            // rbAbout_Info
            // 
            this.rbAbout_Info.Caption = "About";
            this.rbAbout_Info.Id = 37;
            this.rbAbout_Info.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("rbAbout_Info.LargeGlyph")));
            this.rbAbout_Info.Name = "rbAbout_Info";
            // 
            // rbA
            // 
            this.rbA.Caption = "barButtonItem1";
            this.rbA.Id = 6;
            this.rbA.Name = "rbA";
            // 
            // rb
            // 
            this.rb.AllowMdiChildButtons = false;
            this.rb.ExpandCollapseItem.Id = 0;
            this.rb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rb.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rb.ExpandCollapseItem,
            this.rbLogin,
            this.rbA,
            this.rbLogout,
            this.rbExit,
            this.rbChangePassword,
            this.rbPrinterPreference,
            this.rbGoFirst,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barButtonItem7,
            this.barButtonItem8,
            this.barButtonItem9,
            this.barStaticItem1,
            this.rbAbout_Info});
            this.rb.ItemsVertAlign = DevExpress.Utils.VertAlignment.Center;
            this.rb.Location = new System.Drawing.Point(0, 24);
            this.rb.MaxItemId = 40;
            this.rb.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.OnlyWhenMaximized;
            this.rb.Name = "rb";
            this.rb.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.ribbonPageCategory1,
            this.ribbonPageCategory2});
            this.rb.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbApplication});
            this.rb.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4,
            this.repositoryItemTextEdit5});
            this.rb.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.MacOffice;
            this.rb.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.ShowOnMultiplePages;
            this.rb.Size = new System.Drawing.Size(896, 83);
            this.rb.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // rbGoFirst
            // 
            this.rbGoFirst.Caption = "First";
            this.rbGoFirst.Id = 17;
            this.rbGoFirst.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("rbGoFirst.LargeGlyph")));
            this.rbGoFirst.Name = "rbGoFirst";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Previous";
            this.barButtonItem1.Id = 19;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Save";
            this.barButtonItem2.Id = 20;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "New";
            this.barButtonItem3.Id = 21;
            this.barButtonItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.LargeGlyph")));
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 23;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Delete";
            this.barButtonItem5.Id = 24;
            this.barButtonItem5.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.LargeGlyph")));
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Next";
            this.barButtonItem6.Id = 29;
            this.barButtonItem6.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.LargeGlyph")));
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Last";
            this.barButtonItem7.Id = 30;
            this.barButtonItem7.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem7.LargeGlyph")));
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "barButtonItem8";
            this.barButtonItem8.Id = 32;
            this.barButtonItem8.Name = "barButtonItem8";
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "barButtonItem9";
            this.barButtonItem9.Id = 33;
            this.barButtonItem9.Name = "barButtonItem9";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "barStaticItem1";
            this.barStaticItem1.Id = 36;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ribbonPageCategory1
            // 
            this.ribbonPageCategory1.Name = "ribbonPageCategory1";
            this.ribbonPageCategory1.Text = "ribbonPageCategory1";
            // 
            // ribbonPageCategory2
            // 
            this.ribbonPageCategory2.Name = "ribbonPageCategory2";
            this.ribbonPageCategory2.Text = "ribbonPageCategory2";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            this.repositoryItemTextEdit2.ReadOnly = true;
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // repositoryItemTextEdit4
            // 
            this.repositoryItemTextEdit4.AutoHeight = false;
            this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
            // 
            // repositoryItemTextEdit5
            // 
            this.repositoryItemTextEdit5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.repositoryItemTextEdit5.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.repositoryItemTextEdit5.Name = "repositoryItemTextEdit5";
            this.repositoryItemTextEdit5.ReadOnly = true;
            // 
            // miMasterData
            // 
            this.miMasterData.Name = "miMasterData";
            this.miMasterData.Size = new System.Drawing.Size(82, 20);
            this.miMasterData.Text = "&Master Data";
            this.miMasterData.Visible = false;
            // 
            // ms
            // 
            this.ms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMasterData,
            this.miCustomerService,
            this.miDataEntry,
            this.miReport});
            this.ms.Location = new System.Drawing.Point(0, 0);
            this.ms.Name = "ms";
            this.ms.Size = new System.Drawing.Size(896, 24);
            this.ms.TabIndex = 1;
            this.ms.Text = "menuStrip1";
            // 
            // miCustomerService
            // 
            this.miCustomerService.Name = "miCustomerService";
            this.miCustomerService.Size = new System.Drawing.Size(111, 20);
            this.miCustomerService.Text = "Customer &Service";
            this.miCustomerService.Visible = false;
            // 
            // miDataEntry
            // 
            this.miDataEntry.Name = "miDataEntry";
            this.miDataEntry.Size = new System.Drawing.Size(73, 20);
            this.miDataEntry.Text = "&Data Entry";
            this.miDataEntry.Visible = false;
            // 
            // miReport
            // 
            this.miReport.Name = "miReport";
            this.miReport.Size = new System.Drawing.Size(54, 20);
            this.miReport.Text = "&Report";
            this.miReport.Visible = false;
            // 
            // MainForm
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(896, 506);
            this.Controls.Add(this.rb);
            this.Controls.Add(this.st);
            this.Controls.Add(this.ms);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.ms;
            this.Name = "MainForm";
            this.Text = "Corporate - PT. Globalindo Dua Satu Ekspres";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.st.ResumeLayout(false);
            this.st.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).EndInit();
            this.ms.ResumeLayout(false);
            this.ms.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip st;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbApplication;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbApplication_SignIn;
        private DevExpress.XtraBars.BarButtonItem rbLogin;
        private DevExpress.XtraBars.BarButtonItem rbLogout;
        private DevExpress.XtraBars.BarButtonItem rbExit;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbApplication_Preference;
        private DevExpress.XtraBars.BarButtonItem rbChangePassword;
        private DevExpress.XtraBars.BarButtonItem rbPrinterPreference;
        private DevExpress.XtraBars.BarButtonItem rbA;
        private DevExpress.XtraBars.Ribbon.RibbonControl rb;
        private DevExpress.XtraBars.BarButtonItem rbGoFirst;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private System.Windows.Forms.ToolStripMenuItem miMasterData;
        private System.Windows.Forms.MenuStrip ms;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private System.Windows.Forms.ToolStripStatusLabel tsDate;
        private System.Windows.Forms.ToolStripStatusLabel tsUser;
        private System.Windows.Forms.ToolStripStatusLabel tsCorporate;
        private System.Windows.Forms.ToolStripMenuItem miDataEntry;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbApplication_About;
        private DevExpress.XtraBars.BarButtonItem rbAbout_Info;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory2;
        private Corporate.Presentation.Common.Component.MarqueeLabel tsAnnouncement;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit5;
        private System.Windows.Forms.ToolStripMenuItem miCustomerService;
        private System.Windows.Forms.ToolStripMenuItem miReport;
    }
}