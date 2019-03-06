namespace SISCO.Presentation.Operation.Forms
{
    partial class ManifestForm
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManifestForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxBranch = new SISCO.Presentation.Common.Component.dLookup();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.tbxCn = new System.Windows.Forms.TextBox();
            this.tbxBerat = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrintBarcode = new DevExpress.XtraEditors.SimpleButton();
            this.btnGenerate = new DevExpress.XtraEditors.SimpleButton();
            this.btnTambah = new DevExpress.XtraEditors.SimpleButton();
            this.tbxConsol = new SISCO.Presentation.Common.Component.dTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.clConsol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipmentId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clServiceId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPackageid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPaymentId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDestCity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clBranchId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbShipping = new SISCO.Presentation.Common.Component.dComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxBranch.Properties)).BeginInit();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxBerat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridManifest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManifestView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRowDelete)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.AutoHeight = false;
            this.btnDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Delete ", null, null, true)});
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(63, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // tbxDate
            // 
            this.tbxDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxDate.EditValue = null;
            this.tbxDate.Enabled = false;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(101, 54);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.AutoHeight = false;
            this.tbxDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, false, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxDate.Properties.NullText = "<<Choose...>>";
            this.tbxDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.tbxDate.Size = new System.Drawing.Size(138, 24);
            this.tbxDate.TabIndex = 0;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(18, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dest. Branch";
            // 
            // tbxBranch
            // 
            this.tbxBranch.AutoCompleteDataManager = null;
            this.tbxBranch.AutoCompleteDisplayFormater = null;
            this.tbxBranch.AutoCompleteInitialized = false;
            this.tbxBranch.AutocompleteMinimumTextLength = 0;
            this.tbxBranch.AutoCompleteText = null;
            this.tbxBranch.AutoCompleteWhereExpression = null;
            this.tbxBranch.AutoCompleteWheretermFormater = null;
            this.tbxBranch.ClearOnLeave = true;
            this.tbxBranch.DisplayString = null;
            this.tbxBranch.FieldLabel = null;
            this.tbxBranch.Location = new System.Drawing.Point(101, 81);
            this.tbxBranch.LookupPopup = null;
            this.tbxBranch.Name = "tbxBranch";
            this.tbxBranch.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxBranch.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxBranch.Properties.Appearance.Options.UseBackColor = true;
            this.tbxBranch.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxBranch.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxBranch.Properties.AutoCompleteDataManager = null;
            this.tbxBranch.Properties.AutoCompleteDisplayFormater = null;
            this.tbxBranch.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxBranch.Properties.AutoCompleteText = null;
            this.tbxBranch.Properties.AutoCompleteWhereExpression = null;
            this.tbxBranch.Properties.AutoCompleteWheretermFormater = null;
            this.tbxBranch.Properties.AutoHeight = false;
            this.tbxBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.tbxBranch.Properties.LookupPopup = null;
            this.tbxBranch.Properties.NullText = "<<Choose...>>";
            this.tbxBranch.Size = new System.Drawing.Size(231, 24);
            this.tbxBranch.TabIndex = 1;
            this.tbxBranch.ValidationRules = null;
            this.tbxBranch.Value = null;
            // 
            // pnlRight
            // 
            this.pnlRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.tbxCn);
            this.pnlRight.Controls.Add(this.tbxBerat);
            this.pnlRight.Controls.Add(this.label4);
            this.pnlRight.Controls.Add(this.btnPrintBarcode);
            this.pnlRight.Controls.Add(this.btnGenerate);
            this.pnlRight.Controls.Add(this.btnTambah);
            this.pnlRight.Controls.Add(this.tbxConsol);
            this.pnlRight.Controls.Add(this.label5);
            this.pnlRight.Controls.Add(this.label3);
            this.pnlRight.Location = new System.Drawing.Point(582, 48);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(339, 135);
            this.pnlRight.TabIndex = 3;
            // 
            // tbxCn
            // 
            this.tbxCn.Location = new System.Drawing.Point(101, 64);
            this.tbxCn.Name = "tbxCn";
            this.tbxCn.Size = new System.Drawing.Size(215, 24);
            this.tbxCn.TabIndex = 5;
            // 
            // tbxBerat
            // 
            this.tbxBerat.EditMask = "###,###,###,###,###,##0.00";
            this.tbxBerat.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxBerat.FieldLabel = null;
            this.tbxBerat.Location = new System.Drawing.Point(101, 38);
            this.tbxBerat.Name = "tbxBerat";
            this.tbxBerat.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxBerat.Properties.AllowMouseWheel = false;
            this.tbxBerat.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxBerat.Properties.Appearance.Options.UseFont = true;
            this.tbxBerat.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxBerat.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxBerat.Properties.Mask.BeepOnError = true;
            this.tbxBerat.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxBerat.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxBerat.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxBerat.ReadOnly = false;
            this.tbxBerat.Size = new System.Drawing.Size(109, 24);
            this.tbxBerat.TabIndex = 4;
            this.tbxBerat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxBerat.ValidationRules = null;
            this.tbxBerat.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(19, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Berat Consol";
            // 
            // btnPrintBarcode
            // 
            this.btnPrintBarcode.Location = new System.Drawing.Point(180, 92);
            this.btnPrintBarcode.Name = "btnPrintBarcode";
            this.btnPrintBarcode.Size = new System.Drawing.Size(136, 29);
            this.btnPrintBarcode.TabIndex = 100;
            this.btnPrintBarcode.Text = "Print Barcode (Consol)";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(254, 12);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(63, 24);
            this.btnGenerate.TabIndex = 100;
            this.btnGenerate.Text = "Generate";
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(101, 92);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(75, 29);
            this.btnTambah.TabIndex = 6;
            this.btnTambah.Text = "Tambah";
            // 
            // tbxConsol
            // 
            this.tbxConsol.Capslock = true;
            this.tbxConsol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxConsol.FieldLabel = null;
            this.tbxConsol.Location = new System.Drawing.Point(101, 13);
            this.tbxConsol.Name = "tbxConsol";
            this.tbxConsol.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxConsol.Size = new System.Drawing.Size(148, 24);
            this.tbxConsol.TabIndex = 3;
            this.tbxConsol.ValidationRules = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(48, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "No. CN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(28, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "No. Consol";
            // 
            // GridManifest
            // 
            this.GridManifest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridManifest.Location = new System.Drawing.Point(0, 189);
            this.GridManifest.MainView = this.ManifestView;
            this.GridManifest.Name = "GridManifest";
            this.GridManifest.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnRowDelete});
            this.GridManifest.Size = new System.Drawing.Size(935, 302);
            this.GridManifest.TabIndex = 6;
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
            this.clConsol,
            this.clShipmentId,
            this.clServiceId,
            this.clPackageid,
            this.clPaymentId,
            this.clId,
            this.clState,
            this.clDestCity,
            this.clCustomerId,
            this.clCustomer,
            this.clBranchId,
            this.gridColumn2});
            this.ManifestView.GridControl = this.GridManifest;
            this.ManifestView.Name = "ManifestView";
            this.ManifestView.OptionsView.ColumnAutoWidth = false;
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Delete", null, null, true)});
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
            // clConsol
            // 
            this.clConsol.Caption = "Consol";
            this.clConsol.FieldName = "ConsolCode";
            this.clConsol.Name = "clConsol";
            this.clConsol.OptionsColumn.AllowEdit = false;
            this.clConsol.OptionsColumn.AllowFocus = false;
            this.clConsol.OptionsColumn.AllowMove = false;
            this.clConsol.OptionsColumn.ReadOnly = true;
            this.clConsol.Visible = true;
            this.clConsol.VisibleIndex = 13;
            this.clConsol.Width = 87;
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
            // clCustomerId
            // 
            this.clCustomerId.Caption = "Customer Id";
            this.clCustomerId.FieldName = "CustomerId";
            this.clCustomerId.Name = "clCustomerId";
            // 
            // clCustomer
            // 
            this.clCustomer.Caption = "Customer Name";
            this.clCustomer.FieldName = "CustomerName";
            this.clCustomer.Name = "clCustomer";
            // 
            // clBranchId
            // 
            this.clBranchId.Caption = "Branch Id";
            this.clBranchId.FieldName = "BranchId";
            this.clBranchId.Name = "clBranchId";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Total COD";
            this.gridColumn2.DisplayFormat.FormatString = "n";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn2.FieldName = "TotalCod";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalCod", "{0:n}")});
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 14;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.btnPrint);
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 494);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(935, 35);
            this.pnlBottom.TabIndex = 7;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(861, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(64, 27);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "PRINT";
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Location = new System.Drawing.Point(762, 3);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(95, 27);
            this.btnExcel.TabIndex = 0;
            this.btnExcel.Text = "Save To Excel";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(501, 155);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 28);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "UPDATE";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(4, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Via Pengiriman";
            // 
            // cmbShipping
            // 
            this.cmbShipping.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbShipping.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbShipping.FieldLabel = null;
            this.cmbShipping.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbShipping.FormattingEnabled = true;
            this.cmbShipping.Location = new System.Drawing.Point(101, 108);
            this.cmbShipping.Name = "cmbShipping";
            this.cmbShipping.Size = new System.Drawing.Size(138, 25);
            this.cmbShipping.TabIndex = 2;
            this.cmbShipping.ValidationRules = null;
            // 
            // ManifestForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(935, 529);
            this.Controls.Add(this.cmbShipping);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.GridManifest);
            this.Controls.Add(this.tbxBranch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxDate);
            this.Controls.Add(this.label1);
            this.Name = "ManifestForm";
            this.Text = "Operation - Manifest";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbxDate, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbxBranch, 0);
            this.Controls.SetChildIndex(this.GridManifest, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlRight, 0);
            this.Controls.SetChildIndex(this.btnUpdate, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cmbShipping, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxBranch.Properties)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxBerat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridManifest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManifestView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRowDelete)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Common.Component.dCalendar tbxDate;
        private System.Windows.Forms.Label label2;
        private Common.Component.dLookup tbxBranch;
        private System.Windows.Forms.Panel pnlRight;
        private DevExpress.XtraEditors.SimpleButton btnGenerate;
        private DevExpress.XtraEditors.SimpleButton btnTambah;
        private Common.Component.dTextBox tbxConsol;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnPrintBarcode;
        private DevExpress.XtraGrid.GridControl GridManifest;
        private DevExpress.XtraGrid.Views.Grid.GridView ManifestView;
        private System.Windows.Forms.Panel pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraGrid.Columns.GridColumn clShipment;
        private DevExpress.XtraGrid.Columns.GridColumn clShipper;
        private DevExpress.XtraGrid.Columns.GridColumn clConsignee;
        private DevExpress.XtraGrid.Columns.GridColumn clDate;
        private DevExpress.XtraGrid.Columns.GridColumn clPayment;
        private DevExpress.XtraGrid.Columns.GridColumn clService;
        private DevExpress.XtraGrid.Columns.GridColumn clIsi;
        private DevExpress.XtraGrid.Columns.GridColumn clKoli;
        private DevExpress.XtraGrid.Columns.GridColumn clGw;
        private DevExpress.XtraGrid.Columns.GridColumn clCw;
        private DevExpress.XtraGrid.Columns.GridColumn clConsol;
        private DevExpress.XtraGrid.Columns.GridColumn clShipmentId;
        private DevExpress.XtraGrid.Columns.GridColumn clServiceId;
        private DevExpress.XtraGrid.Columns.GridColumn clPackageid;
        private DevExpress.XtraGrid.Columns.GridColumn clPaymentId;
        private DevExpress.XtraGrid.Columns.GridColumn clId;
        private DevExpress.XtraGrid.Columns.GridColumn clState;
        private DevExpress.XtraGrid.Columns.GridColumn clDelete;
        private DevExpress.XtraGrid.Columns.GridColumn clDestCity;
        private DevExpress.XtraGrid.Columns.GridColumn clCustomerId;
        private DevExpress.XtraGrid.Columns.GridColumn clCustomer;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnRowDelete;
        private DevExpress.XtraGrid.Columns.GridColumn clBranchId;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private Common.Component.dTextBoxNumber tbxBerat;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.TextBox tbxCn;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.Label label6;
        private Common.Component.dComboBox cmbShipping;
    }
}