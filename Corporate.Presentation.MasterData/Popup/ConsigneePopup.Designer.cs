namespace Corporate.Presentation.MasterData.Popup
{
    partial class ConsigneePopup
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxPhone = new Corporate.Presentation.Common.Component.dTextBox();
            this.tbxAddress = new Corporate.Presentation.Common.Component.dTextBox();
            this.tbxName = new Corporate.Presentation.Common.Component.dTextBox();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.gcBottom = new DevExpress.XtraEditors.GroupControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.ConsigneeGrid = new DevExpress.XtraGrid.GridControl();
            this.ConsigneeView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcTop)).BeginInit();
            this.gcTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBottom)).BeginInit();
            this.gcBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConsigneeGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsigneeView)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTop
            // 
            this.gcTop.Controls.Add(this.label3);
            this.gcTop.Controls.Add(this.label1);
            this.gcTop.Controls.Add(this.tbxPhone);
            this.gcTop.Controls.Add(this.tbxAddress);
            this.gcTop.Controls.Add(this.tbxName);
            this.gcTop.Controls.Add(this.btnClear);
            this.gcTop.Controls.Add(this.btnView);
            this.gcTop.Controls.Add(this.label2);
            this.gcTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcTop.Location = new System.Drawing.Point(0, 0);
            this.gcTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcTop.Name = "gcTop";
            this.gcTop.Size = new System.Drawing.Size(518, 161);
            this.gcTop.TabIndex = 0;
            this.gcTop.Text = "Filter Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Phone";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Alamat";
            // 
            // tbxPhone
            // 
            this.tbxPhone.Capslock = true;
            this.tbxPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxPhone.FieldLabel = null;
            this.tbxPhone.Location = new System.Drawing.Point(72, 89);
            this.tbxPhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxPhone.Name = "tbxPhone";
            this.tbxPhone.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPhone.Size = new System.Drawing.Size(157, 24);
            this.tbxPhone.TabIndex = 3;
            this.tbxPhone.ValidationRules = null;
            // 
            // tbxAddress
            // 
            this.tbxAddress.Capslock = true;
            this.tbxAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxAddress.FieldLabel = null;
            this.tbxAddress.Location = new System.Drawing.Point(72, 63);
            this.tbxAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxAddress.Size = new System.Drawing.Size(345, 24);
            this.tbxAddress.TabIndex = 2;
            this.tbxAddress.ValidationRules = null;
            // 
            // tbxName
            // 
            this.tbxName.Capslock = true;
            this.tbxName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxName.FieldLabel = null;
            this.tbxName.Location = new System.Drawing.Point(72, 37);
            this.tbxName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxName.Name = "tbxName";
            this.tbxName.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxName.Size = new System.Drawing.Size(213, 24);
            this.tbxName.TabIndex = 1;
            this.tbxName.ValidationRules = null;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(72, 118);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(65, 31);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "&Clear";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(145, 118);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(65, 31);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "&View";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // gcBottom
            // 
            this.gcBottom.Controls.Add(this.btnCancel);
            this.gcBottom.Controls.Add(this.BtnSelect);
            this.gcBottom.Controls.Add(this.ConsigneeGrid);
            this.gcBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcBottom.Location = new System.Drawing.Point(0, 161);
            this.gcBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcBottom.Name = "gcBottom";
            this.gcBottom.Size = new System.Drawing.Size(518, 349);
            this.gcBottom.TabIndex = 1;
            this.gcBottom.Text = "Data Consignee";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(330, 306);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 37);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            // 
            // BtnSelect
            // 
            this.BtnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSelect.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.BtnSelect.Appearance.Options.UseFont = true;
            this.BtnSelect.Location = new System.Drawing.Point(425, 306);
            this.BtnSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(87, 37);
            this.BtnSelect.TabIndex = 1;
            this.BtnSelect.Text = "Select";
            // 
            // ConsigneeGrid
            // 
            this.ConsigneeGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConsigneeGrid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConsigneeGrid.Location = new System.Drawing.Point(2, 21);
            this.ConsigneeGrid.MainView = this.ConsigneeView;
            this.ConsigneeGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConsigneeGrid.Name = "ConsigneeGrid";
            this.ConsigneeGrid.Size = new System.Drawing.Size(514, 279);
            this.ConsigneeGrid.TabIndex = 0;
            this.ConsigneeGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ConsigneeView});
            // 
            // ConsigneeView
            // 
            this.ConsigneeView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn4});
            this.ConsigneeView.GridControl = this.ConsigneeGrid;
            this.ConsigneeView.Name = "ConsigneeView";
            this.ConsigneeView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.ConsigneeView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.ConsigneeView.OptionsBehavior.Editable = false;
            this.ConsigneeView.OptionsBehavior.ReadOnly = true;
            this.ConsigneeView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ConsigneeView.OptionsView.ShowGroupPanel = false;
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
            this.gridColumn2.Width = 166;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Address";
            this.gridColumn1.FieldName = "Address";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 224;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Phone";
            this.gridColumn4.FieldName = "Phone";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 108;
            // 
            // ConsigneePopup
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(518, 510);
            this.Controls.Add(this.gcBottom);
            this.Controls.Add(this.gcTop);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "ConsigneePopup";
            this.Text = "Popup - Consignee";
            ((System.ComponentModel.ISupportInitialize)(this.gcTop)).EndInit();
            this.gcTop.ResumeLayout(false);
            this.gcTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBottom)).EndInit();
            this.gcBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ConsigneeGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsigneeView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcTop;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraEditors.GroupControl gcBottom;
        public DevExpress.XtraGrid.GridControl ConsigneeGrid;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        public DevExpress.XtraEditors.SimpleButton BtnSelect;
        private DevExpress.XtraGrid.Views.Grid.GridView ConsigneeView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private Common.Component.dTextBox tbxName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Common.Component.dTextBox tbxPhone;
        private Common.Component.dTextBox tbxAddress;
    }
}