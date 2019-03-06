namespace Corporate.Presentation.Common.Forms
{
    partial class BaseToolbarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseToolbarForm));
            this.rb = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.rbSearch_Code = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.rbData_New = new DevExpress.XtraBars.BarButtonItem();
            this.rbData_Save = new DevExpress.XtraBars.BarButtonItem();
            this.rbData_Delete = new DevExpress.XtraBars.BarButtonItem();
            this.rbNavigation_First = new DevExpress.XtraBars.BarButtonItem();
            this.rbNavigation_Previous = new DevExpress.XtraBars.BarButtonItem();
            this.rbNavigation_Next = new DevExpress.XtraBars.BarButtonItem();
            this.rbNavigation_Last = new DevExpress.XtraBars.BarButtonItem();
            this.rbPage_Refresh = new DevExpress.XtraBars.BarButtonItem();
            this.rbPage_Search = new DevExpress.XtraBars.BarButtonItem();
            this.rbLayout_Print = new DevExpress.XtraBars.BarButtonItem();
            this.rbLayout_PrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.rbLayout_Info = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbData = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbNavigation = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbLayout = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.rbSearch = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.barDockingMenuItem1 = new DevExpress.XtraBars.BarDockingMenuItem();
            this.barMdiChildrenListItem1 = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.tbxSearch_Code = new Corporate.Presentation.Common.Component.dTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbPod = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbPod_Void = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.rb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // rb
            // 
            this.rb.ExpandCollapseItem.Id = 0;
            this.rb.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rb.ExpandCollapseItem,
            this.rbSearch_Code,
            this.rbData_New,
            this.rbData_Save,
            this.rbData_Delete,
            this.rbNavigation_First,
            this.rbNavigation_Previous,
            this.rbNavigation_Next,
            this.rbNavigation_Last,
            this.rbPage_Refresh,
            this.rbPage_Search,
            this.rbLayout_Print,
            this.rbLayout_PrintPreview,
            this.rbLayout_Info,
            this.barSubItem1,
            this.rbPod_Void});
            this.rb.Location = new System.Drawing.Point(0, 0);
            this.rb.MaxItemId = 38;
            this.rb.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.rb.Name = "rb";
            this.rb.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.rb.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemButtonEdit1,
            this.repositoryItemButtonEdit2});
            this.rb.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.MacOffice;
            this.rb.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.rb.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.True;
            this.rb.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.ShowOnMultiplePages;
            this.rb.Size = new System.Drawing.Size(895, 83);
            this.rb.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // rbSearch_Code
            // 
            this.rbSearch_Code.Edit = this.repositoryItemTextEdit1;
            this.rbSearch_Code.Id = 1;
            this.rbSearch_Code.Name = "rbSearch_Code";
            this.rbSearch_Code.Width = 200;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // rbData_New
            // 
            this.rbData_New.Caption = "New";
            this.rbData_New.Id = 11;
            this.rbData_New.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.rbData_New.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("rbData_New.LargeGlyph")));
            this.rbData_New.Name = "rbData_New";
            // 
            // rbData_Save
            // 
            this.rbData_Save.Caption = "Save";
            this.rbData_Save.Id = 12;
            this.rbData_Save.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.rbData_Save.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("rbData_Save.LargeGlyph")));
            this.rbData_Save.Name = "rbData_Save";
            // 
            // rbData_Delete
            // 
            this.rbData_Delete.Caption = "Delete";
            this.rbData_Delete.Id = 13;
            this.rbData_Delete.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("rbData_Delete.LargeGlyph")));
            this.rbData_Delete.Name = "rbData_Delete";
            // 
            // rbNavigation_First
            // 
            this.rbNavigation_First.Caption = "First";
            this.rbNavigation_First.Id = 14;
            this.rbNavigation_First.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("rbNavigation_First.LargeGlyph")));
            this.rbNavigation_First.Name = "rbNavigation_First";
            // 
            // rbNavigation_Previous
            // 
            this.rbNavigation_Previous.Caption = "Previous";
            this.rbNavigation_Previous.Id = 15;
            this.rbNavigation_Previous.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("rbNavigation_Previous.LargeGlyph")));
            this.rbNavigation_Previous.Name = "rbNavigation_Previous";
            // 
            // rbNavigation_Next
            // 
            this.rbNavigation_Next.Caption = "Next";
            this.rbNavigation_Next.Id = 16;
            this.rbNavigation_Next.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("rbNavigation_Next.LargeGlyph")));
            this.rbNavigation_Next.Name = "rbNavigation_Next";
            // 
            // rbNavigation_Last
            // 
            this.rbNavigation_Last.Caption = "Last";
            this.rbNavigation_Last.Id = 17;
            this.rbNavigation_Last.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("rbNavigation_Last.LargeGlyph")));
            this.rbNavigation_Last.Name = "rbNavigation_Last";
            // 
            // rbPage_Refresh
            // 
            this.rbPage_Refresh.Caption = "Refresh";
            this.rbPage_Refresh.Id = 19;
            this.rbPage_Refresh.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("rbPage_Refresh.LargeGlyph")));
            this.rbPage_Refresh.Name = "rbPage_Refresh";
            // 
            // rbPage_Search
            // 
            this.rbPage_Search.Caption = "Search";
            this.rbPage_Search.Id = 20;
            this.rbPage_Search.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("rbPage_Search.LargeGlyph")));
            this.rbPage_Search.Name = "rbPage_Search";
            // 
            // rbLayout_Print
            // 
            this.rbLayout_Print.Caption = "Print";
            this.rbLayout_Print.Id = 21;
            this.rbLayout_Print.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("rbLayout_Print.LargeGlyph")));
            this.rbLayout_Print.Name = "rbLayout_Print";
            // 
            // rbLayout_PrintPreview
            // 
            this.rbLayout_PrintPreview.Caption = "Print Preview";
            this.rbLayout_PrintPreview.Id = 22;
            this.rbLayout_PrintPreview.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("rbLayout_PrintPreview.LargeGlyph")));
            this.rbLayout_PrintPreview.Name = "rbLayout_PrintPreview";
            // 
            // rbLayout_Info
            // 
            this.rbLayout_Info.Caption = "Information";
            this.rbLayout_Info.Id = 23;
            this.rbLayout_Info.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("rbLayout_Info.LargeGlyph")));
            this.rbLayout_Info.Name = "rbLayout_Info";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "barSubItem1";
            this.barSubItem1.Id = 27;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbData,
            this.rbNavigation,
            this.ribbonPageGroup1,
            this.rbLayout,
            this.rbPod});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Navigation";
            // 
            // rbData
            // 
            this.rbData.ItemLinks.Add(this.rbData_New);
            this.rbData.ItemLinks.Add(this.rbData_Save);
            this.rbData.ItemLinks.Add(this.rbData_Delete);
            this.rbData.Name = "rbData";
            this.rbData.Text = "Data";
            // 
            // rbNavigation
            // 
            this.rbNavigation.ItemLinks.Add(this.rbNavigation_First);
            this.rbNavigation.ItemLinks.Add(this.rbNavigation_Previous);
            this.rbNavigation.ItemLinks.Add(this.rbNavigation_Next);
            this.rbNavigation.ItemLinks.Add(this.rbNavigation_Last);
            this.rbNavigation.Name = "rbNavigation";
            this.rbNavigation.Text = "Navigation";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.rbPage_Refresh);
            this.ribbonPageGroup1.ItemLinks.Add(this.rbPage_Search);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Page";
            // 
            // rbLayout
            // 
            this.rbLayout.ItemLinks.Add(this.rbLayout_Print);
            this.rbLayout.ItemLinks.Add(this.rbLayout_PrintPreview);
            this.rbLayout.ItemLinks.Add(this.rbLayout_Info);
            this.rbLayout.Name = "rbLayout";
            this.rbLayout.Text = "Layout";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            // 
            // rbSearch
            // 
            this.rbSearch.ItemLinks.Add(this.rbSearch_Code);
            this.rbSearch.Name = "rbSearch";
            this.rbSearch.Text = "Search";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemButtonEdit2;
            this.barEditItem1.Id = 29;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // barDockingMenuItem1
            // 
            this.barDockingMenuItem1.Caption = "barDockingMenuItem1";
            this.barDockingMenuItem1.Id = 31;
            this.barDockingMenuItem1.Name = "barDockingMenuItem1";
            // 
            // barMdiChildrenListItem1
            // 
            this.barMdiChildrenListItem1.Caption = "barMdiChildrenListItem1";
            this.barMdiChildrenListItem1.Id = 32;
            this.barMdiChildrenListItem1.Name = "barMdiChildrenListItem1";
            // 
            // tbxSearch_Code
            // 
            this.tbxSearch_Code.Capslock = true;
            this.tbxSearch_Code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxSearch_Code.FieldLabel = null;
            this.tbxSearch_Code.Location = new System.Drawing.Point(71, 85);
            this.tbxSearch_Code.Name = "tbxSearch_Code";
            this.tbxSearch_Code.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxSearch_Code.Size = new System.Drawing.Size(203, 24);
            this.tbxSearch_Code.TabIndex = 3;
            this.tbxSearch_Code.ValidationRules = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search";
            // 
            // rbPod
            // 
            this.rbPod.ItemLinks.Add(this.rbPod_Void);
            this.rbPod.Name = "rbPod";
            this.rbPod.Text = "POD";
            this.rbPod.Visible = false;
            // 
            // rbPod_Void
            // 
            this.rbPod_Void.Caption = "Void / Batal";
            this.rbPod_Void.Id = 37;
            this.rbPod_Void.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("rbPod_Void.LargeGlyph")));
            this.rbPod_Void.Name = "rbPod_Void";
            // 
            // BaseToolbarForm
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(895, 484);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxSearch_Code);
            this.Controls.Add(this.rb);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BaseToolbarForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "BaseToolbarForm";
            ((System.ComponentModel.ISupportInitialize)(this.rb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl rb;
        public DevExpress.XtraBars.BarEditItem rbSearch_Code;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        public DevExpress.XtraBars.BarButtonItem rbData_New;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        public DevExpress.XtraBars.BarButtonItem rbData_Save;
        public DevExpress.XtraBars.BarButtonItem rbData_Delete;
        public DevExpress.XtraBars.BarButtonItem rbNavigation_First;
        public DevExpress.XtraBars.Ribbon.RibbonPageGroup rbNavigation;
        public DevExpress.XtraBars.BarButtonItem rbNavigation_Previous;
        public DevExpress.XtraBars.BarButtonItem rbNavigation_Next;
        public DevExpress.XtraBars.BarButtonItem rbNavigation_Last;
        public DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        public DevExpress.XtraBars.BarButtonItem rbPage_Refresh;
        public DevExpress.XtraBars.BarButtonItem rbPage_Search;
        public DevExpress.XtraBars.BarButtonItem rbLayout_Print;
        public DevExpress.XtraBars.BarButtonItem rbLayout_PrintPreview;
        public DevExpress.XtraBars.BarButtonItem rbLayout_Info;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbLayout;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbSearch;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraBars.BarDockingMenuItem barDockingMenuItem1;
        private DevExpress.XtraBars.BarMdiChildrenListItem barMdiChildrenListItem1;
        public Component.dTextBox tbxSearch_Code;
        private System.Windows.Forms.Label label1;
        public DevExpress.XtraBars.Ribbon.RibbonPageGroup rbData;
        public DevExpress.XtraBars.Ribbon.RibbonPageGroup rbPod;
        public DevExpress.XtraBars.BarButtonItem rbPod_Void;
    }
}