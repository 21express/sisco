using SISCO.Presentation.Common.Component;

namespace SISCO.Presentation.MasterData.Popup
{
    partial class CostTypePopup
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
            this.tbxName = new SISCO.Presentation.Common.Component.dTextBox();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.gcBottom = new DevExpress.XtraEditors.GroupControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.CostTypeGrid = new DevExpress.XtraGrid.GridControl();
            this.CostTypeView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcTop)).BeginInit();
            this.gcTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBottom)).BeginInit();
            this.gcBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CostTypeGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CostTypeView)).BeginInit();
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
            this.gcTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcTop.Name = "gcTop";
            this.gcTop.Size = new System.Drawing.Size(482, 79);
            this.gcTop.TabIndex = 0;
            this.gcTop.Text = "Filter Data";
            // 
            // tbxName
            // 
            this.tbxName.Capslock = true;
            this.tbxName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxName.FieldLabel = null;
            this.tbxName.Location = new System.Drawing.Point(72, 39);
            this.tbxName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxName.Name = "tbxName";
            this.tbxName.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxName.Size = new System.Drawing.Size(257, 24);
            this.tbxName.TabIndex = 7;
            this.tbxName.ValidationRules = null;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(341, 35);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(65, 31);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "&Clear";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(408, 35);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(65, 31);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "&View";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // gcBottom
            // 
            this.gcBottom.Controls.Add(this.btnCancel);
            this.gcBottom.Controls.Add(this.BtnSelect);
            this.gcBottom.Controls.Add(this.CostTypeGrid);
            this.gcBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcBottom.Location = new System.Drawing.Point(0, 79);
            this.gcBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcBottom.Name = "gcBottom";
            this.gcBottom.Size = new System.Drawing.Size(482, 411);
            this.gcBottom.TabIndex = 1;
            this.gcBottom.Text = "Data Cost Type";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(387, 372);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 33);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            // 
            // BtnSelect
            // 
            this.BtnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSelect.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.BtnSelect.Appearance.Options.UseFont = true;
            this.BtnSelect.Location = new System.Drawing.Point(291, 372);
            this.BtnSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(90, 33);
            this.BtnSelect.TabIndex = 1;
            this.BtnSelect.Text = "Select";
            // 
            // CostTypeGrid
            // 
            this.CostTypeGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.CostTypeGrid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CostTypeGrid.Location = new System.Drawing.Point(2, 21);
            this.CostTypeGrid.MainView = this.CostTypeView;
            this.CostTypeGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CostTypeGrid.Name = "CostTypeGrid";
            this.CostTypeGrid.Size = new System.Drawing.Size(478, 343);
            this.CostTypeGrid.TabIndex = 0;
            this.CostTypeGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.CostTypeView});
            // 
            // CostTypeView
            // 
            this.CostTypeView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn1});
            this.CostTypeView.GridControl = this.CostTypeGrid;
            this.CostTypeView.Name = "CostTypeView";
            this.CostTypeView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.CostTypeView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.CostTypeView.OptionsBehavior.Editable = false;
            this.CostTypeView.OptionsBehavior.ReadOnly = true;
            this.CostTypeView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.CostTypeView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Id";
            this.gridColumn3.FieldName = "Id";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Cost Type";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 210;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Division";
            this.gridColumn1.FieldName = "DivisionName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 252;
            // 
            // CostTypePopup
            // 
            this.AcceptButton = this.BtnSelect;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(482, 490);
            this.Controls.Add(this.gcBottom);
            this.Controls.Add(this.gcTop);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "CostTypePopup";
            this.Text = "Popup - Cost Type";
            ((System.ComponentModel.ISupportInitialize)(this.gcTop)).EndInit();
            this.gcTop.ResumeLayout(false);
            this.gcTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBottom)).EndInit();
            this.gcBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CostTypeGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CostTypeView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcTop;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraEditors.GroupControl gcBottom;
        public DevExpress.XtraGrid.GridControl CostTypeGrid;
        private dTextBox tbxName;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        public DevExpress.XtraEditors.SimpleButton BtnSelect;
        private DevExpress.XtraGrid.Views.Grid.GridView CostTypeView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}