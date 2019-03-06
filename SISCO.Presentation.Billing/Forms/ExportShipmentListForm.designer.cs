namespace SISCO.Presentation.Billing.Forms
{
    partial class ExportShipmentListForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportShipmentListForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.btnSaveToExcel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dcmbPayment = new SISCO.Presentation.Common.Component.dComboBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtDateTo = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.txtDateFrom = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.txtReceiptNumber = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.txtInvoiceNumber = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.gridExport = new DevExpress.XtraGrid.GridControl();
            this.gridViewExport = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewExport)).BeginInit();
            this.SuspendLayout();
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Total";
            this.gridColumn3.FieldName = "Total";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 10;
            this.gridColumn3.Width = 93;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "GW";
            this.gridColumn8.FieldName = "TtlGrossWeight";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            this.gridColumn8.Width = 43;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Pieces";
            this.gridColumn5.FieldName = "TtlPiece";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            this.gridColumn5.Width = 42;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Package Type";
            this.gridColumn10.FieldName = "PackageType";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 6;
            this.gridColumn10.Width = 67;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Payment Method";
            this.gridColumn6.FieldName = "PaymentMethod";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 62;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Destination";
            this.gridColumn7.FieldName = "DestCity";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 62;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Consignee";
            this.gridColumn1.FieldName = "ConsigneeName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 116;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Shipper";
            this.gridColumn4.FieldName = "ShipperName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 62;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Date";
            this.gridColumn2.FieldName = "DateProcess";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 67;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Shipment Number";
            this.gridColumn13.FieldName = "Code";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 0;
            this.gridColumn13.Width = 81;
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn13,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn1,
            this.gridColumn7,
            this.gridColumn6,
            this.gridColumn10,
            this.gridColumn5,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn3});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "CW";
            this.gridColumn9.FieldName = "TtlChargeableWeight";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 9;
            this.gridColumn9.Width = 46;
            // 
            // grid
            // 
            this.grid.Location = new System.Drawing.Point(12, 140);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(759, 342);
            this.grid.TabIndex = 102;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // btnSaveToExcel
            // 
            this.btnSaveToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveToExcel.Location = new System.Drawing.Point(682, 488);
            this.btnSaveToExcel.Name = "btnSaveToExcel";
            this.btnSaveToExcel.Size = new System.Drawing.Size(89, 30);
            this.btnSaveToExcel.TabIndex = 103;
            this.btnSaveToExcel.Text = "Export";
            this.btnSaveToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveToExcel.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(478, 69);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(77, 26);
            this.btnSearch.TabIndex = 131;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(322, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 127;
            this.label1.Text = "Invoice No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 127;
            this.label5.Text = "Date To";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(48, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 127;
            this.label14.Text = "Date From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(320, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "Receipt No.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dcmbPayment);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDateTo);
            this.groupBox1.Controls.Add(this.txtDateFrom);
            this.groupBox1.Controls.Add(this.txtReceiptNumber);
            this.groupBox1.Controls.Add(this.txtInvoiceNumber);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 122);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // dcmbPayment
            // 
            this.dcmbPayment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.dcmbPayment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.dcmbPayment.FieldLabel = null;
            this.dcmbPayment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dcmbPayment.FormattingEnabled = true;
            this.dcmbPayment.Location = new System.Drawing.Point(110, 64);
            this.dcmbPayment.Name = "dcmbPayment";
            this.dcmbPayment.Size = new System.Drawing.Size(165, 21);
            this.dcmbPayment.TabIndex = 103;
            this.dcmbPayment.ValidationRules = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 133;
            this.label3.Text = "Payment Method";
            // 
            // txtDateTo
            // 
            this.txtDateTo.EditValue = null;
            this.txtDateTo.FieldLabel = null;
            this.txtDateTo.FormatDateTime = "dd-MM-yyyy";
            this.txtDateTo.Location = new System.Drawing.Point(110, 41);
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Nullable = false;
            this.txtDateTo.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDateTo.Properties.AutoHeight = false;
            this.txtDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtDateTo.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateTo.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDateTo.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDateTo.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtDateTo.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDateTo.Size = new System.Drawing.Size(165, 20);
            this.txtDateTo.TabIndex = 102;
            this.txtDateTo.ValidationRules = null;
            this.txtDateTo.Value = new System.DateTime(((long)(0)));
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.EditValue = null;
            this.txtDateFrom.FieldLabel = null;
            this.txtDateFrom.FormatDateTime = "dd-MM-yyyy";
            this.txtDateFrom.Location = new System.Drawing.Point(110, 19);
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.Nullable = false;
            this.txtDateFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDateFrom.Properties.AutoHeight = false;
            this.txtDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtDateFrom.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.txtDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateFrom.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDateFrom.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDateFrom.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtDateFrom.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDateFrom.Size = new System.Drawing.Size(165, 20);
            this.txtDateFrom.TabIndex = 101;
            this.txtDateFrom.ValidationRules = null;
            this.txtDateFrom.Value = new System.DateTime(((long)(0)));
            // 
            // txtReceiptNumber
            // 
            this.txtReceiptNumber.Capslock = true;
            this.txtReceiptNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReceiptNumber.FieldLabel = null;
            this.txtReceiptNumber.Location = new System.Drawing.Point(390, 41);
            this.txtReceiptNumber.Name = "txtReceiptNumber";
            this.txtReceiptNumber.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtReceiptNumber.Size = new System.Drawing.Size(165, 20);
            this.txtReceiptNumber.TabIndex = 105;
            this.txtReceiptNumber.ValidationRules = null;
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Capslock = true;
            this.txtInvoiceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInvoiceNumber.FieldLabel = null;
            this.txtInvoiceNumber.Location = new System.Drawing.Point(390, 19);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtInvoiceNumber.Size = new System.Drawing.Size(165, 20);
            this.txtInvoiceNumber.TabIndex = 104;
            this.txtInvoiceNumber.ValidationRules = null;
            // 
            // gridExport
            // 
            this.gridExport.Location = new System.Drawing.Point(743, 12);
            this.gridExport.MainView = this.gridViewExport;
            this.gridExport.Name = "gridExport";
            this.gridExport.Size = new System.Drawing.Size(28, 26);
            this.gridExport.TabIndex = 104;
            this.gridExport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewExport});
            this.gridExport.Visible = false;
            // 
            // gridViewExport
            // 
            this.gridViewExport.GridControl = this.gridExport;
            this.gridViewExport.Name = "gridViewExport";
            // 
            // ExportShipmentListForm
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(782, 530);
            this.Controls.Add(this.gridExport);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnSaveToExcel);
            this.Controls.Add(this.groupBox1);
            this.Name = "ExportShipmentListForm";
            this.Text = "Export Shipment List";
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewExport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.GridControl grid;
        private System.Windows.Forms.Button btnSaveToExcel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Common.Component.dTextBox txtReceiptNumber;
        private Common.Component.dTextBox txtInvoiceNumber;
        private Common.Component.dCalendar txtDateTo;
        private Common.Component.dCalendar txtDateFrom;
        private DevExpress.XtraGrid.GridControl gridExport;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewExport;
        private System.Windows.Forms.Label label3;
        private Common.Component.dComboBox dcmbPayment;
        
    }
}

