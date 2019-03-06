using SISCO.Presentation.Common.Component;

namespace SISCO.Presentation.MasterData.Popup
{
    partial class CurrencyPopup
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
            this.tbxCode = new dTextBox();
            this.tbxName = new dTextBox();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.gcBottom = new DevExpress.XtraEditors.GroupControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.CurrencyGrid = new DevExpress.XtraGrid.GridControl();
            this.CurrencyView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcTop)).BeginInit();
            this.gcTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBottom)).BeginInit();
            this.gcBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrencyGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrencyView)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTop
            // 
            this.gcTop.Controls.Add(this.tbxCode);
            this.gcTop.Controls.Add(this.tbxName);
            this.gcTop.Controls.Add(this.btnClear);
            this.gcTop.Controls.Add(this.label1);
            this.gcTop.Controls.Add(this.btnView);
            this.gcTop.Controls.Add(this.label2);
            this.gcTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcTop.Location = new System.Drawing.Point(0, 0);
            this.gcTop.Name = "gcTop";
            this.gcTop.Size = new System.Drawing.Size(444, 108);
            this.gcTop.TabIndex = 0;
            this.gcTop.Text = "Filter Data";
            // 
            // tbxCode
            // 
            this.tbxCode.Location = new System.Drawing.Point(60, 37);
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.Size = new System.Drawing.Size(164, 24);
            this.tbxCode.TabIndex = 101;
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(60, 67);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(249, 24);
            this.tbxName.TabIndex = 102;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(320, 66);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(56, 24);
            this.btnClear.TabIndex = 103;
            this.btnClear.Text = "&Clear";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Code";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(378, 66);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(56, 24);
            this.btnView.TabIndex = 104;
            this.btnView.Text = "&View";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // gcBottom
            // 
            this.gcBottom.Controls.Add(this.btnCancel);
            this.gcBottom.Controls.Add(this.BtnSelect);
            this.gcBottom.Controls.Add(this.CurrencyGrid);
            this.gcBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcBottom.Location = new System.Drawing.Point(0, 108);
            this.gcBottom.Name = "gcBottom";
            this.gcBottom.Size = new System.Drawing.Size(444, 311);
            this.gcBottom.TabIndex = 1;
            this.gcBottom.Text = "Data Currency";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(361, 272);
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
            this.BtnSelect.Location = new System.Drawing.Point(282, 272);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(75, 28);
            this.BtnSelect.TabIndex = 1;
            this.BtnSelect.Text = "Select";
            // 
            // CurrencyGrid
            // 
            this.CurrencyGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.CurrencyGrid.Location = new System.Drawing.Point(2, 21);
            this.CurrencyGrid.MainView = this.CurrencyView;
            this.CurrencyGrid.Name = "CurrencyGrid";
            this.CurrencyGrid.Size = new System.Drawing.Size(440, 231);
            this.CurrencyGrid.TabIndex = 0;
            this.CurrencyGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.CurrencyView});
            // 
            // CurrencyView
            // 
            this.CurrencyView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn2});
            this.CurrencyView.GridControl = this.CurrencyGrid;
            this.CurrencyView.Name = "CurrencyView";
            this.CurrencyView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.CurrencyView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.CurrencyView.OptionsBehavior.Editable = false;
            this.CurrencyView.OptionsBehavior.ReadOnly = true;
            this.CurrencyView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.CurrencyView.OptionsView.ShowGroupPanel = false;
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
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Code";
            this.gridColumn1.FieldName = "Code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // CurrencyPopup
            // 
            this.AcceptButton = this.BtnSelect;
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(444, 419);
            this.Controls.Add(this.gcBottom);
            this.Controls.Add(this.gcTop);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "CurrencyPopup";
            this.Text = "Popup - Currency";
            ((System.ComponentModel.ISupportInitialize)(this.gcTop)).EndInit();
            this.gcTop.ResumeLayout(false);
            this.gcTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBottom)).EndInit();
            this.gcBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CurrencyGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrencyView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcTop;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraEditors.GroupControl gcBottom;
        public DevExpress.XtraGrid.GridControl CurrencyGrid;
        private dTextBox tbxName;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        public DevExpress.XtraEditors.SimpleButton BtnSelect;
        private DevExpress.XtraGrid.Views.Grid.GridView CurrencyView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private dTextBox tbxCode;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}