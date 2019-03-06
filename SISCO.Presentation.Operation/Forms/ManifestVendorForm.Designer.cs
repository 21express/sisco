namespace SISCO.Presentation.Operation.Forms
{
    partial class ManifestVendorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManifestVendorForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnScan = new DevExpress.XtraEditors.SimpleButton();
            this.tbxPod = new SISCO.Presentation.Common.Component.dTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lkpVendor = new SISCO.Presentation.Common.Component.dLookup();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.GridManifest = new DevExpress.XtraGrid.GridControl();
            this.ManifestView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRowDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.clShipment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipper = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clConsignee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clService = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clIsi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clKoli = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clGw = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCw = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipmentId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clServiceId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPackageid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPaymentId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDestCity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpVendor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridManifest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManifestView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRowDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.lkpVendor);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbxDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(927, 90);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnScan);
            this.groupBox1.Controls.Add(this.tbxPod);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(589, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 74);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scan POD";
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(271, 27);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(45, 32);
            this.btnScan.TabIndex = 4;
            this.btnScan.Text = "Scan";
            // 
            // tbxPod
            // 
            this.tbxPod.Capslock = true;
            this.tbxPod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxPod.FieldLabel = null;
            this.tbxPod.Location = new System.Drawing.Point(58, 31);
            this.tbxPod.Name = "tbxPod";
            this.tbxPod.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPod.Size = new System.Drawing.Size(208, 24);
            this.tbxPod.TabIndex = 3;
            this.tbxPod.ValidationRules = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "POD";
            // 
            // lkpVendor
            // 
            this.lkpVendor.AutoCompleteDataManager = null;
            this.lkpVendor.AutoCompleteDisplayFormater = null;
            this.lkpVendor.AutoCompleteInitialized = false;
            this.lkpVendor.AutocompleteMinimumTextLength = 0;
            this.lkpVendor.AutoCompleteText = null;
            this.lkpVendor.AutoCompleteWhereExpression = null;
            this.lkpVendor.AutoCompleteWheretermFormater = null;
            this.lkpVendor.ClearOnLeave = true;
            this.lkpVendor.DisplayString = null;
            this.lkpVendor.FieldLabel = null;
            this.lkpVendor.Location = new System.Drawing.Point(88, 38);
            this.lkpVendor.LookupPopup = null;
            this.lkpVendor.Name = "lkpVendor";
            this.lkpVendor.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpVendor.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lkpVendor.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpVendor.Properties.Appearance.Options.UseBackColor = true;
            this.lkpVendor.Properties.Appearance.Options.UseFont = true;
            this.lkpVendor.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpVendor.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpVendor.Properties.AutoCompleteDataManager = null;
            this.lkpVendor.Properties.AutoCompleteDisplayFormater = null;
            this.lkpVendor.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpVendor.Properties.AutoCompleteText = null;
            this.lkpVendor.Properties.AutoCompleteWhereExpression = null;
            this.lkpVendor.Properties.AutoCompleteWheretermFormater = null;
            this.lkpVendor.Properties.AutoHeight = false;
            this.lkpVendor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpVendor.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpVendor.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpVendor.Properties.LookupPopup = null;
            this.lkpVendor.Properties.NullText = "<<Choose...>>";
            this.lkpVendor.Size = new System.Drawing.Size(225, 24);
            this.lkpVendor.TabIndex = 2;
            this.lkpVendor.ValidationRules = null;
            this.lkpVendor.Value = null;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(31, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vendor";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(88, 12);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxDate.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxDate.Properties.Appearance.Options.UseBackColor = true;
            this.tbxDate.Properties.Appearance.Options.UseFont = true;
            this.tbxDate.Properties.AutoHeight = false;
            this.tbxDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxDate.Size = new System.Drawing.Size(100, 24);
            this.tbxDate.TabIndex = 1;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(31, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GridManifest
            // 
            this.GridManifest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridManifest.Location = new System.Drawing.Point(4, 134);
            this.GridManifest.MainView = this.ManifestView;
            this.GridManifest.Name = "GridManifest";
            this.GridManifest.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnRowDelete});
            this.GridManifest.Size = new System.Drawing.Size(927, 301);
            this.GridManifest.TabIndex = 8;
            this.GridManifest.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ManifestView});
            // 
            // ManifestView
            // 
            this.ManifestView.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.ManifestView.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Transparent;
            this.ManifestView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.ManifestView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Transparent;
            this.ManifestView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Transparent;
            this.ManifestView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.ManifestView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clNo,
            this.clDelete,
            this.clShipment,
            this.clShipper,
            this.clConsignee,
            this.clDate,
            this.gridColumn1,
            this.clPayment,
            this.clService,
            this.clIsi,
            this.clKoli,
            this.clGw,
            this.clCw,
            this.clShipmentId,
            this.clServiceId,
            this.clPackageid,
            this.clPaymentId,
            this.clId,
            this.clState,
            this.clDestCity,
            this.gridColumn2});
            this.ManifestView.GridControl = this.GridManifest;
            this.ManifestView.Name = "ManifestView";
            this.ManifestView.OptionsView.ShowFooter = true;
            this.ManifestView.OptionsView.ShowGroupPanel = false;
            // 
            // clNo
            // 
            this.clNo.Caption = "No";
            this.clNo.Name = "clNo";
            this.clNo.OptionsColumn.AllowEdit = false;
            this.clNo.OptionsColumn.AllowFocus = false;
            this.clNo.OptionsColumn.AllowMove = false;
            this.clNo.OptionsColumn.ReadOnly = true;
            this.clNo.Visible = true;
            this.clNo.VisibleIndex = 0;
            this.clNo.Width = 29;
            // 
            // clDelete
            // 
            this.clDelete.Caption = " ";
            this.clDelete.ColumnEdit = this.btnRowDelete;
            this.clDelete.Name = "clDelete";
            this.clDelete.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.clDelete.Visible = true;
            this.clDelete.VisibleIndex = 1;
            this.clDelete.Width = 30;
            // 
            // btnRowDelete
            // 
            this.btnRowDelete.AutoHeight = false;
            this.btnRowDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Delete", null, null, true)});
            this.btnRowDelete.Name = "btnRowDelete";
            this.btnRowDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // clShipment
            // 
            this.clShipment.Caption = "Shipment";
            this.clShipment.FieldName = "ShipmentCode";
            this.clShipment.Name = "clShipment";
            this.clShipment.OptionsColumn.AllowEdit = false;
            this.clShipment.OptionsColumn.AllowFocus = false;
            this.clShipment.OptionsColumn.AllowMove = false;
            this.clShipment.OptionsColumn.ReadOnly = true;
            this.clShipment.Visible = true;
            this.clShipment.VisibleIndex = 2;
            this.clShipment.Width = 102;
            // 
            // clShipper
            // 
            this.clShipper.Caption = "Shipper";
            this.clShipper.FieldName = "ShipperName";
            this.clShipper.Name = "clShipper";
            this.clShipper.OptionsColumn.AllowEdit = false;
            this.clShipper.OptionsColumn.AllowFocus = false;
            this.clShipper.OptionsColumn.AllowMove = false;
            this.clShipper.OptionsColumn.ReadOnly = true;
            this.clShipper.Visible = true;
            this.clShipper.VisibleIndex = 3;
            // 
            // clConsignee
            // 
            this.clConsignee.Caption = "Consignee";
            this.clConsignee.FieldName = "ConsigneeName";
            this.clConsignee.Name = "clConsignee";
            this.clConsignee.OptionsColumn.AllowEdit = false;
            this.clConsignee.OptionsColumn.AllowFocus = false;
            this.clConsignee.OptionsColumn.AllowMove = false;
            this.clConsignee.OptionsColumn.ReadOnly = true;
            this.clConsignee.Visible = true;
            this.clConsignee.VisibleIndex = 4;
            // 
            // clDate
            // 
            this.clDate.Caption = "Date";
            this.clDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.clDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clDate.FieldName = "ShipmentDate";
            this.clDate.Name = "clDate";
            this.clDate.OptionsColumn.AllowEdit = false;
            this.clDate.OptionsColumn.AllowFocus = false;
            this.clDate.OptionsColumn.AllowMove = false;
            this.clDate.OptionsColumn.ReadOnly = true;
            this.clDate.Visible = true;
            this.clDate.VisibleIndex = 5;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Destination";
            this.gridColumn1.FieldName = "DestCity";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            this.gridColumn1.Width = 99;
            // 
            // clPayment
            // 
            this.clPayment.Caption = "Bayar";
            this.clPayment.FieldName = "PaymentMethod";
            this.clPayment.Name = "clPayment";
            this.clPayment.OptionsColumn.AllowEdit = false;
            this.clPayment.OptionsColumn.AllowFocus = false;
            this.clPayment.OptionsColumn.AllowMove = false;
            this.clPayment.OptionsColumn.ReadOnly = true;
            this.clPayment.Visible = true;
            this.clPayment.VisibleIndex = 7;
            // 
            // clService
            // 
            this.clService.Caption = "Service";
            this.clService.FieldName = "ServiceType";
            this.clService.Name = "clService";
            this.clService.OptionsColumn.AllowEdit = false;
            this.clService.OptionsColumn.AllowFocus = false;
            this.clService.OptionsColumn.AllowMove = false;
            this.clService.OptionsColumn.ReadOnly = true;
            this.clService.Visible = true;
            this.clService.VisibleIndex = 8;
            // 
            // clIsi
            // 
            this.clIsi.Caption = "Isi";
            this.clIsi.FieldName = "PackageType";
            this.clIsi.Name = "clIsi";
            this.clIsi.OptionsColumn.AllowEdit = false;
            this.clIsi.OptionsColumn.AllowFocus = false;
            this.clIsi.OptionsColumn.AllowMove = false;
            this.clIsi.OptionsColumn.ReadOnly = true;
            this.clIsi.Visible = true;
            this.clIsi.VisibleIndex = 9;
            // 
            // clKoli
            // 
            this.clKoli.Caption = "Koli";
            this.clKoli.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clKoli.FieldName = "TtlPiece";
            this.clKoli.Name = "clKoli";
            this.clKoli.OptionsColumn.AllowEdit = false;
            this.clKoli.OptionsColumn.AllowFocus = false;
            this.clKoli.OptionsColumn.AllowMove = false;
            this.clKoli.OptionsColumn.ReadOnly = true;
            this.clKoli.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clKoli.Visible = true;
            this.clKoli.VisibleIndex = 10;
            this.clKoli.Width = 37;
            // 
            // clGw
            // 
            this.clGw.Caption = "GW";
            this.clGw.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clGw.FieldName = "TtlGrossWeight";
            this.clGw.Name = "clGw";
            this.clGw.OptionsColumn.AllowEdit = false;
            this.clGw.OptionsColumn.AllowFocus = false;
            this.clGw.OptionsColumn.AllowMove = false;
            this.clGw.OptionsColumn.ReadOnly = true;
            this.clGw.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clGw.Visible = true;
            this.clGw.VisibleIndex = 11;
            this.clGw.Width = 39;
            // 
            // clCw
            // 
            this.clCw.Caption = "CW";
            this.clCw.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clCw.FieldName = "TtlChargeableWeight";
            this.clCw.Name = "clCw";
            this.clCw.OptionsColumn.AllowEdit = false;
            this.clCw.OptionsColumn.AllowFocus = false;
            this.clCw.OptionsColumn.AllowMove = false;
            this.clCw.OptionsColumn.ReadOnly = true;
            this.clCw.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clCw.Visible = true;
            this.clCw.VisibleIndex = 12;
            this.clCw.Width = 37;
            // 
            // clShipmentId
            // 
            this.clShipmentId.Caption = "Shipment Id";
            this.clShipmentId.FieldName = "ShipmentId";
            this.clShipmentId.Name = "clShipmentId";
            this.clShipmentId.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.True;
            // 
            // clServiceId
            // 
            this.clServiceId.Caption = "gridColumn1";
            this.clServiceId.FieldName = "ServiceTypeId";
            this.clServiceId.Name = "clServiceId";
            // 
            // clPackageid
            // 
            this.clPackageid.Caption = "gridColumn1";
            this.clPackageid.FieldName = "PackageTypeId";
            this.clPackageid.Name = "clPackageid";
            // 
            // clPaymentId
            // 
            this.clPaymentId.Caption = "gridColumn1";
            this.clPaymentId.FieldName = "PaymentMethodId";
            this.clPaymentId.Name = "clPaymentId";
            // 
            // clId
            // 
            this.clId.Caption = "Id";
            this.clId.FieldName = "Id";
            this.clId.Name = "clId";
            // 
            // clState
            // 
            this.clState.Caption = "State";
            this.clState.FieldName = "StateChange2";
            this.clState.Name = "clState";
            // 
            // clDestCity
            // 
            this.clDestCity.Caption = "Dest City Id";
            this.clDestCity.FieldName = "DestCityId";
            this.clDestCity.Name = "clDestCity";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.FieldName = "BranchId";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // ManifestVendorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(934, 440);
            this.Controls.Add(this.GridManifest);
            this.Controls.Add(this.panel1);
            this.Name = "ManifestVendorForm";
            this.Text = "Operation Manifest Vendor";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.GridManifest, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpVendor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridManifest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManifestView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRowDelete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Common.Component.dTextBox tbxPod;
        private System.Windows.Forms.Label label3;
        private Common.Component.dLookup lkpVendor;
        private System.Windows.Forms.Label label2;
        private Common.Component.dCalendar tbxDate;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnScan;
        private DevExpress.XtraGrid.GridControl GridManifest;
        private DevExpress.XtraGrid.Views.Grid.GridView ManifestView;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private DevExpress.XtraGrid.Columns.GridColumn clDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnRowDelete;
        private DevExpress.XtraGrid.Columns.GridColumn clShipment;
        private DevExpress.XtraGrid.Columns.GridColumn clShipper;
        private DevExpress.XtraGrid.Columns.GridColumn clConsignee;
        private DevExpress.XtraGrid.Columns.GridColumn clDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn clPayment;
        private DevExpress.XtraGrid.Columns.GridColumn clService;
        private DevExpress.XtraGrid.Columns.GridColumn clIsi;
        private DevExpress.XtraGrid.Columns.GridColumn clKoli;
        private DevExpress.XtraGrid.Columns.GridColumn clGw;
        private DevExpress.XtraGrid.Columns.GridColumn clCw;
        private DevExpress.XtraGrid.Columns.GridColumn clShipmentId;
        private DevExpress.XtraGrid.Columns.GridColumn clServiceId;
        private DevExpress.XtraGrid.Columns.GridColumn clPackageid;
        private DevExpress.XtraGrid.Columns.GridColumn clPaymentId;
        private DevExpress.XtraGrid.Columns.GridColumn clId;
        private DevExpress.XtraGrid.Columns.GridColumn clState;
        private DevExpress.XtraGrid.Columns.GridColumn clDestCity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}