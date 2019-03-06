namespace Corporate.Presentation.MasterData.Popup
{
    partial class PackageTypePopup
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
            this.gcTop = new DevExpress.XtraEditors.GroupControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.gcBottom = new DevExpress.XtraEditors.GroupControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.PackageTypeGrid = new DevExpress.XtraGrid.GridControl();
            this.PackageTypeView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tbxName = new Corporate.Presentation.Common.Component.dTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gcTop)).BeginInit();
            this.gcTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBottom)).BeginInit();
            this.gcBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PackageTypeGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PackageTypeView)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTop
            // 
            this.gcTop.Controls.Add(this.tbxName);
            this.gcTop.Controls.Add(this.btnClear);
            this.gcTop.Controls.Add(this.btnView);
            this.gcTop.Controls.Add(this.label2);
            this.gcTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcTop.Location = new System.Drawing.Point(0, 0);
            this.gcTop.Name = "gcTop";
            this.gcTop.Size = new System.Drawing.Size(444, 88);
            this.gcTop.TabIndex = 0;
            this.gcTop.Text = "Filter Data";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(57, 54);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(56, 24);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "&Clear";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(115, 54);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(56, 24);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "&View";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // gcBottom
            // 
            this.gcBottom.Controls.Add(this.btnCancel);
            this.gcBottom.Controls.Add(this.BtnSelect);
            this.gcBottom.Controls.Add(this.PackageTypeGrid);
            this.gcBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcBottom.Location = new System.Drawing.Point(0, 88);
            this.gcBottom.Name = "gcBottom";
            this.gcBottom.Size = new System.Drawing.Size(444, 302);
            this.gcBottom.TabIndex = 1;
            this.gcBottom.Text = "Data Package Type";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(283, 269);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            // 
            // BtnSelect
            // 
            this.BtnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSelect.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.BtnSelect.Appearance.Options.UseFont = true;
            this.BtnSelect.Location = new System.Drawing.Point(364, 269);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(75, 28);
            this.BtnSelect.TabIndex = 1;
            this.BtnSelect.Text = "Select";
            // 
            // PackageTypeGrid
            // 
            this.PackageTypeGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.PackageTypeGrid.Location = new System.Drawing.Point(2, 21);
            this.PackageTypeGrid.MainView = this.PackageTypeView;
            this.PackageTypeGrid.Name = "PackageTypeGrid";
            this.PackageTypeGrid.Size = new System.Drawing.Size(440, 240);
            this.PackageTypeGrid.TabIndex = 0;
            this.PackageTypeGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PackageTypeView});
            // 
            // PackageTypeView
            // 
            this.PackageTypeView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn2});
            this.PackageTypeView.GridControl = this.PackageTypeGrid;
            this.PackageTypeView.Name = "PackageTypeView";
            this.PackageTypeView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.PackageTypeView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.PackageTypeView.OptionsBehavior.Editable = false;
            this.PackageTypeView.OptionsBehavior.ReadOnly = true;
            this.PackageTypeView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.PackageTypeView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Id";
            this.gridColumn3.FieldName = "Id";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Nama";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // tbxName
            // 
            this.tbxName.Capslock = true;
            this.tbxName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxName.FieldLabel = null;
            this.tbxName.Location = new System.Drawing.Point(57, 28);
            this.tbxName.Name = "tbxName";
            this.tbxName.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxName.Size = new System.Drawing.Size(263, 24);
            this.tbxName.TabIndex = 1;
            this.tbxName.ValidationRules = null;
            // 
            // PackageTypePopup
            // 
            this.AcceptButton = this.BtnSelect;
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(444, 390);
            this.Controls.Add(this.gcBottom);
            this.Controls.Add(this.gcTop);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "PackageTypePopup";
            this.Text = "Popup - Package Type";
            ((System.ComponentModel.ISupportInitialize)(this.gcTop)).EndInit();
            this.gcTop.ResumeLayout(false);
            this.gcTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBottom)).EndInit();
            this.gcBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PackageTypeGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PackageTypeView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcTop;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraEditors.GroupControl gcBottom;
        public DevExpress.XtraGrid.GridControl PackageTypeGrid;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        public DevExpress.XtraEditors.SimpleButton BtnSelect;
        private DevExpress.XtraGrid.Views.Grid.GridView PackageTypeView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private Common.Component.dTextBox tbxName;
    }
}