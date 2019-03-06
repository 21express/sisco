namespace SISCO.Presentation.Common.Forms
{
    partial class BasePopup
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
            this.gcFilter = new DevExpress.XtraEditors.GroupControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gcGrid = new DevExpress.XtraEditors.GroupControl();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.tbxFilterId = new SISCO.Presentation.Common.Component.dTextBox();
            this.tbxFilterName = new SISCO.Presentation.Common.Component.dTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gcFilter)).BeginInit();
            this.gcFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            this.gcGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gcFilter
            // 
            this.gcFilter.Controls.Add(this.tbxFilterName);
            this.gcFilter.Controls.Add(this.tbxFilterId);
            this.gcFilter.Controls.Add(this.btnSearch);
            this.gcFilter.Controls.Add(this.btnClear);
            this.gcFilter.Controls.Add(this.label2);
            this.gcFilter.Controls.Add(this.label1);
            this.gcFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcFilter.Location = new System.Drawing.Point(0, 0);
            this.gcFilter.Name = "gcFilter";
            this.gcFilter.Size = new System.Drawing.Size(440, 124);
            this.gcFilter.TabIndex = 0;
            this.gcFilter.Text = "Filter Data";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(151, 87);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 26);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "&Search";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(70, 87);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 26);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "&Clear";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // gcGrid
            // 
            this.gcGrid.Controls.Add(this.grid);
            this.gcGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcGrid.Location = new System.Drawing.Point(0, 124);
            this.gcGrid.Name = "gcGrid";
            this.gcGrid.Size = new System.Drawing.Size(440, 314);
            this.gcGrid.TabIndex = 0;
            this.gcGrid.Text = "Please Choose";
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.First.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grid.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(0),
            new DevExpress.XtraEditors.NavigatorCustomButton(2),
            new DevExpress.XtraEditors.NavigatorCustomButton(3),
            new DevExpress.XtraEditors.NavigatorCustomButton(5)});
            this.grid.EmbeddedNavigator.TextStringFormat = "Page {0} of {1}";
            this.grid.Location = new System.Drawing.Point(2, 21);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(436, 291);
            this.grid.TabIndex = 3;
            this.grid.UseEmbeddedNavigator = true;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridView.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.Gray;
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clId,
            this.clCode,
            this.clName});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsCustomization.AllowColumnMoving = false;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsCustomization.AllowSort = false;
            this.gridView.OptionsFilter.AllowFilterEditor = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // clId
            // 
            this.clId.Caption = "Id";
            this.clId.FieldName = "Id";
            this.clId.Name = "clId";
            this.clId.OptionsColumn.AllowEdit = false;
            this.clId.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.clId.OptionsColumn.AllowIncrementalSearch = false;
            this.clId.OptionsColumn.ReadOnly = true;
            this.clId.Width = 20;
            // 
            // clCode
            // 
            this.clCode.Caption = "Code";
            this.clCode.FieldName = "Code";
            this.clCode.Name = "clCode";
            this.clCode.Visible = true;
            this.clCode.VisibleIndex = 0;
            this.clCode.Width = 80;
            // 
            // clName
            // 
            this.clName.Caption = "Name";
            this.clName.FieldName = "Name";
            this.clName.Name = "clName";
            this.clName.Visible = true;
            this.clName.VisibleIndex = 1;
            this.clName.Width = 340;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(278, 444);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(359, 444);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 26);
            this.btnSelect.TabIndex = 6;
            this.btnSelect.Text = "Select";
            // 
            // tbxFilterId
            // 
            this.tbxFilterId.Capslock = true;
            this.tbxFilterId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxFilterId.FieldLabel = null;
            this.tbxFilterId.Location = new System.Drawing.Point(70, 30);
            this.tbxFilterId.Name = "tbxFilterId";
            this.tbxFilterId.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFilterId.Size = new System.Drawing.Size(100, 24);
            this.tbxFilterId.TabIndex = 1;
            this.tbxFilterId.ValidationRules = null;
            // 
            // tbxFilterName
            // 
            this.tbxFilterName.Capslock = true;
            this.tbxFilterName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxFilterName.FieldLabel = null;
            this.tbxFilterName.Location = new System.Drawing.Point(70, 57);
            this.tbxFilterName.Name = "tbxFilterName";
            this.tbxFilterName.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFilterName.Size = new System.Drawing.Size(293, 24);
            this.tbxFilterName.TabIndex = 2;
            this.tbxFilterName.ValidationRules = null;
            // 
            // BasePopup
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(440, 476);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gcGrid);
            this.Controls.Add(this.gcFilter);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BasePopup";
            this.ShowInTaskbar = false;
            this.Text = "BasePopup";
            ((System.ComponentModel.ISupportInitialize)(this.gcFilter)).EndInit();
            this.gcFilter.ResumeLayout(false);
            this.gcFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            this.gcGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcFilter;
        protected DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl gcGrid;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
        public DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn clId;
        private DevExpress.XtraGrid.Columns.GridColumn clCode;
        private DevExpress.XtraGrid.Columns.GridColumn clName;
        private Component.dTextBox tbxFilterName;
        private Component.dTextBox tbxFilterId;

    }
}