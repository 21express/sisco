namespace Corporate.Presentation.Common.Forms
{
    partial class BaseSearchPopup
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
            this.MainContainer = new System.Windows.Forms.SplitContainer();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnFilter = new DevExpress.XtraEditors.SimpleButton();
            this.tbxCode = new Corporate.Presentation.Common.Component.dTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.GridSearch = new DevExpress.XtraGrid.GridControl();
            this.SearchView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clNo = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).BeginInit();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.Panel2.SuspendLayout();
            this.MainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainContainer
            // 
            this.MainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContainer.Location = new System.Drawing.Point(0, 0);
            this.MainContainer.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MainContainer.Name = "MainContainer";
            // 
            // MainContainer.Panel1
            // 
            this.MainContainer.Panel1.Controls.Add(this.btnClear);
            this.MainContainer.Panel1.Controls.Add(this.btnFilter);
            this.MainContainer.Panel1.Controls.Add(this.tbxCode);
            this.MainContainer.Panel1.Controls.Add(this.label1);
            // 
            // MainContainer.Panel2
            // 
            this.MainContainer.Panel2.Controls.Add(this.btnClose);
            this.MainContainer.Panel2.Controls.Add(this.btnSelect);
            this.MainContainer.Panel2.Controls.Add(this.GridSearch);
            this.MainContainer.Size = new System.Drawing.Size(775, 450);
            this.MainContainer.SplitterDistance = 214;
            this.MainContainer.SplitterWidth = 6;
            this.MainContainer.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(131, 403);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(68, 38);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Location = new System.Drawing.Point(57, 403);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(68, 38);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "Filter";
            // 
            // tbxCode
            // 
            this.tbxCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxCode.Capslock = true;
            this.tbxCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxCode.FieldLabel = null;
            this.tbxCode.Location = new System.Drawing.Point(62, 43);
            this.tbxCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxCode.Size = new System.Drawing.Size(136, 24);
            this.tbxCode.TabIndex = 1;
            this.tbxCode.ValidationRules = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(385, 405);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 37);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(468, 405);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(76, 37);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Select";
            // 
            // GridSearch
            // 
            this.GridSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridSearch.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GridSearch.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GridSearch.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GridSearch.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GridSearch.EmbeddedNavigator.Buttons.First.Visible = false;
            this.GridSearch.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.GridSearch.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.GridSearch.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.GridSearch.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.GridSearch.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.GridSearch.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.GridSearch.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(0),
            new DevExpress.XtraEditors.NavigatorCustomButton(2),
            new DevExpress.XtraEditors.NavigatorCustomButton(3),
            new DevExpress.XtraEditors.NavigatorCustomButton(5)});
            this.GridSearch.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GridSearch.EmbeddedNavigator.TextStringFormat = "Page {0} of {1}";
            this.GridSearch.Location = new System.Drawing.Point(3, 0);
            this.GridSearch.MainView = this.SearchView;
            this.GridSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GridSearch.Name = "GridSearch";
            this.GridSearch.Size = new System.Drawing.Size(540, 398);
            this.GridSearch.TabIndex = 0;
            this.GridSearch.UseEmbeddedNavigator = true;
            this.GridSearch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.SearchView});
            // 
            // SearchView
            // 
            this.SearchView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clNo});
            this.SearchView.GridControl = this.GridSearch;
            this.SearchView.Name = "SearchView";
            this.SearchView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.SearchView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.SearchView.OptionsBehavior.Editable = false;
            this.SearchView.OptionsBehavior.ReadOnly = true;
            this.SearchView.OptionsCustomization.AllowColumnMoving = false;
            this.SearchView.OptionsPrint.AutoWidth = false;
            this.SearchView.OptionsView.ShowGroupPanel = false;
            // 
            // clNo
            // 
            this.clNo.Caption = "No";
            this.clNo.Name = "clNo";
            this.clNo.Visible = true;
            this.clNo.VisibleIndex = 0;
            // 
            // BaseSearchPopup
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(775, 450);
            this.Controls.Add(this.MainContainer);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseSearchPopup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "BaseSearchPopup";
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel1.PerformLayout();
            this.MainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).EndInit();
            this.MainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.SplitContainer MainContainer;
        public Component.dTextBox tbxCode;
        public DevExpress.XtraGrid.GridControl GridSearch;
        public DevExpress.XtraGrid.Views.Grid.GridView SearchView;
        public DevExpress.XtraEditors.SimpleButton btnClear;
        public DevExpress.XtraEditors.SimpleButton btnFilter;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        public System.Windows.Forms.Label label1;
    }
}