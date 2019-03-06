namespace SISCO.Presentation.Operation.Forms
{
    partial class OutboundDaratForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutboundDaratForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.tbxCw = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.tbxGw = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.tbxBarcode = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.tbxDriver = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.tbxPengangkut = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tbxBranch = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tbxNo = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.GridWaybillDetail = new DevExpress.XtraGrid.GridControl();
            this.WaybillDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.clId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clWaybillId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clWaybillCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipmentId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipmentCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipmentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clConsol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clBranchId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDestinationId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDestination = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipper = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clConsignee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clService = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPackage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPiece = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clGw = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCw = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clManifestId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clManifestCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxDimension = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxGw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridWaybillDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WaybillDetailView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.tbxCw);
            this.pnlTop.Controls.Add(this.label8);
            this.pnlTop.Controls.Add(this.tbxGw);
            this.pnlTop.Controls.Add(this.label7);
            this.pnlTop.Controls.Add(this.btnAdd);
            this.pnlTop.Controls.Add(this.tbxBarcode);
            this.pnlTop.Controls.Add(this.label6);
            this.pnlTop.Location = new System.Drawing.Point(497, 57);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(312, 125);
            this.pnlTop.TabIndex = 7;
            // 
            // tbxCw
            // 
            this.tbxCw.EditMask = "###,###,###,###,###,##0.00";
            this.tbxCw.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxCw.FieldLabel = null;
            this.tbxCw.Location = new System.Drawing.Point(99, 59);
            this.tbxCw.Name = "tbxCw";
            this.tbxCw.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxCw.Properties.AllowMouseWheel = false;
            this.tbxCw.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxCw.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxCw.Properties.Mask.BeepOnError = true;
            this.tbxCw.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxCw.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxCw.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxCw.ReadOnly = false;
            this.tbxCw.Size = new System.Drawing.Size(100, 20);
            this.tbxCw.TabIndex = 9;
            this.tbxCw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxCw.ValidationRules = null;
            this.tbxCw.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(24, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "Ch. Weight";
            // 
            // tbxGw
            // 
            this.tbxGw.EditMask = "###,###,###,###,###,##0.00";
            this.tbxGw.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxGw.FieldLabel = null;
            this.tbxGw.Location = new System.Drawing.Point(99, 33);
            this.tbxGw.Name = "tbxGw";
            this.tbxGw.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxGw.Properties.AllowMouseWheel = false;
            this.tbxGw.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxGw.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxGw.Properties.Mask.BeepOnError = true;
            this.tbxGw.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxGw.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxGw.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxGw.ReadOnly = false;
            this.tbxGw.Size = new System.Drawing.Size(100, 20);
            this.tbxGw.TabIndex = 8;
            this.tbxGw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxGw.ValidationRules = null;
            this.tbxGw.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(13, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Gross Weight";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(99, 87);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 30);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Tambah";
            // 
            // tbxBarcode
            // 
            this.tbxBarcode.Capslock = true;
            this.tbxBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxBarcode.FieldLabel = null;
            this.tbxBarcode.Location = new System.Drawing.Point(99, 7);
            this.tbxBarcode.Name = "tbxBarcode";
            this.tbxBarcode.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxBarcode.Size = new System.Drawing.Size(196, 24);
            this.tbxBarcode.TabIndex = 7;
            this.tbxBarcode.ValidationRules = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(20, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "CN / Consol";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(741, 524);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 31);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "PRINT";
            // 
            // tbxDriver
            // 
            this.tbxDriver.Capslock = true;
            this.tbxDriver.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDriver.FieldLabel = null;
            this.tbxDriver.Location = new System.Drawing.Point(97, 150);
            this.tbxDriver.Name = "tbxDriver";
            this.tbxDriver.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDriver.Size = new System.Drawing.Size(209, 24);
            this.tbxDriver.TabIndex = 5;
            this.tbxDriver.ValidationRules = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(49, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 29;
            this.label5.Text = "Driver";
            // 
            // tbxPengangkut
            // 
            this.tbxPengangkut.Capslock = true;
            this.tbxPengangkut.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxPengangkut.FieldLabel = null;
            this.tbxPengangkut.Location = new System.Drawing.Point(97, 123);
            this.tbxPengangkut.Name = "tbxPengangkut";
            this.tbxPengangkut.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPengangkut.Size = new System.Drawing.Size(174, 24);
            this.tbxPengangkut.TabIndex = 4;
            this.tbxPengangkut.ValidationRules = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(18, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "Pengangkut";
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
            this.tbxBranch.Location = new System.Drawing.Point(97, 96);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.tbxBranch.Properties.LookupPopup = null;
            this.tbxBranch.Properties.NullText = "<<Choose...>>";
            this.tbxBranch.Size = new System.Drawing.Size(257, 24);
            this.tbxBranch.TabIndex = 3;
            this.tbxBranch.ValidationRules = null;
            this.tbxBranch.Value = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(17, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Dest Branch";
            // 
            // tbxNo
            // 
            this.tbxNo.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxNo.Capslock = true;
            this.tbxNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxNo.FieldLabel = null;
            this.tbxNo.Location = new System.Drawing.Point(97, 70);
            this.tbxNo.Name = "tbxNo";
            this.tbxNo.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxNo.Size = new System.Drawing.Size(257, 24);
            this.tbxNo.TabIndex = 2;
            this.tbxNo.ValidationRules = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(21, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Waybill No.";
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(97, 43);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxDate.Properties.Appearance.Options.UseBackColor = true;
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
            this.tbxDate.Properties.NullText = "<<Choose...>>";
            this.tbxDate.Size = new System.Drawing.Size(174, 24);
            this.tbxDate.TabIndex = 1;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(58, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Date";
            // 
            // GridWaybillDetail
            // 
            this.GridWaybillDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridWaybillDetail.Location = new System.Drawing.Point(0, 209);
            this.GridWaybillDetail.MainView = this.WaybillDetailView;
            this.GridWaybillDetail.Name = "GridWaybillDetail";
            this.GridWaybillDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnDelete});
            this.GridWaybillDetail.Size = new System.Drawing.Size(821, 311);
            this.GridWaybillDetail.TabIndex = 10;
            this.GridWaybillDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.WaybillDetailView});
            // 
            // WaybillDetailView
            // 
            this.WaybillDetailView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clNo,
            this.clDelete,
            this.clId,
            this.clWaybillId,
            this.clWaybillCode,
            this.clShipmentId,
            this.clShipmentCode,
            this.clShipmentDate,
            this.clConsol,
            this.clBranchId,
            this.clDestinationId,
            this.clDestination,
            this.clCustomerId,
            this.clCustomerName,
            this.clShipper,
            this.clConsignee,
            this.clService,
            this.clPackage,
            this.clPayment,
            this.clPiece,
            this.clGw,
            this.clCw,
            this.clManifestId,
            this.clManifestCode,
            this.clState});
            this.WaybillDetailView.GridControl = this.GridWaybillDetail;
            this.WaybillDetailView.Name = "WaybillDetailView";
            this.WaybillDetailView.OptionsView.ShowFooter = true;
            this.WaybillDetailView.OptionsView.ShowGroupPanel = false;
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
            this.clDelete.ColumnEdit = this.btnDelete;
            this.clDelete.Name = "clDelete";
            this.clDelete.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.clDelete.Visible = true;
            this.clDelete.VisibleIndex = 1;
            this.clDelete.Width = 30;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoHeight = false;
            this.btnDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Delete", null, null, true)});
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // clId
            // 
            this.clId.Caption = "Id";
            this.clId.FieldName = "Id";
            this.clId.Name = "clId";
            this.clId.OptionsColumn.AllowEdit = false;
            this.clId.OptionsColumn.AllowFocus = false;
            this.clId.OptionsColumn.AllowMove = false;
            this.clId.OptionsColumn.ReadOnly = true;
            // 
            // clWaybillId
            // 
            this.clWaybillId.Caption = "Waybill Id";
            this.clWaybillId.FieldName = "WaybillId";
            this.clWaybillId.Name = "clWaybillId";
            this.clWaybillId.OptionsColumn.AllowEdit = false;
            this.clWaybillId.OptionsColumn.AllowFocus = false;
            this.clWaybillId.OptionsColumn.AllowMove = false;
            this.clWaybillId.OptionsColumn.ReadOnly = true;
            // 
            // clWaybillCode
            // 
            this.clWaybillCode.Caption = "Waybill Code";
            this.clWaybillCode.FieldName = "Waybill Code";
            this.clWaybillCode.Name = "clWaybillCode";
            this.clWaybillCode.OptionsColumn.AllowEdit = false;
            this.clWaybillCode.OptionsColumn.AllowFocus = false;
            this.clWaybillCode.OptionsColumn.AllowMove = false;
            this.clWaybillCode.OptionsColumn.ReadOnly = true;
            // 
            // clShipmentId
            // 
            this.clShipmentId.Caption = "Shipment Id";
            this.clShipmentId.FieldName = "ShipmentId";
            this.clShipmentId.Name = "clShipmentId";
            this.clShipmentId.OptionsColumn.AllowEdit = false;
            this.clShipmentId.OptionsColumn.AllowFocus = false;
            this.clShipmentId.OptionsColumn.AllowMove = false;
            this.clShipmentId.OptionsColumn.ReadOnly = true;
            // 
            // clShipmentCode
            // 
            this.clShipmentCode.Caption = "Shipment";
            this.clShipmentCode.FieldName = "ShipmentCode";
            this.clShipmentCode.Name = "clShipmentCode";
            this.clShipmentCode.OptionsColumn.AllowEdit = false;
            this.clShipmentCode.OptionsColumn.AllowFocus = false;
            this.clShipmentCode.OptionsColumn.AllowMove = false;
            this.clShipmentCode.OptionsColumn.ReadOnly = true;
            this.clShipmentCode.Visible = true;
            this.clShipmentCode.VisibleIndex = 2;
            this.clShipmentCode.Width = 98;
            // 
            // clShipmentDate
            // 
            this.clShipmentDate.Caption = "Shipment Date";
            this.clShipmentDate.FieldName = "ShipmentDate";
            this.clShipmentDate.Name = "clShipmentDate";
            this.clShipmentDate.OptionsColumn.AllowEdit = false;
            this.clShipmentDate.OptionsColumn.AllowFocus = false;
            this.clShipmentDate.OptionsColumn.AllowMove = false;
            this.clShipmentDate.OptionsColumn.ReadOnly = true;
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
            // 
            // clBranchId
            // 
            this.clBranchId.Caption = "BranchId";
            this.clBranchId.FieldName = "BranchId";
            this.clBranchId.Name = "clBranchId";
            this.clBranchId.OptionsColumn.AllowEdit = false;
            this.clBranchId.OptionsColumn.AllowFocus = false;
            this.clBranchId.OptionsColumn.AllowMove = false;
            this.clBranchId.OptionsColumn.ReadOnly = true;
            // 
            // clDestinationId
            // 
            this.clDestinationId.Caption = "Dest City Id";
            this.clDestinationId.FieldName = "DestCityId";
            this.clDestinationId.Name = "clDestinationId";
            // 
            // clDestination
            // 
            this.clDestination.Caption = "Destination";
            this.clDestination.FieldName = "DestCity";
            this.clDestination.Name = "clDestination";
            this.clDestination.OptionsColumn.AllowEdit = false;
            this.clDestination.OptionsColumn.AllowFocus = false;
            this.clDestination.OptionsColumn.AllowMove = false;
            this.clDestination.OptionsColumn.ReadOnly = true;
            this.clDestination.Visible = true;
            this.clDestination.VisibleIndex = 4;
            this.clDestination.Width = 101;
            // 
            // clCustomerId
            // 
            this.clCustomerId.Caption = "Customer Id";
            this.clCustomerId.FieldName = "CustomerId";
            this.clCustomerId.Name = "clCustomerId";
            this.clCustomerId.OptionsColumn.AllowEdit = false;
            this.clCustomerId.OptionsColumn.AllowFocus = false;
            this.clCustomerId.OptionsColumn.AllowMove = false;
            this.clCustomerId.OptionsColumn.ReadOnly = true;
            // 
            // clCustomerName
            // 
            this.clCustomerName.Caption = "Customer";
            this.clCustomerName.FieldName = "CustomerName";
            this.clCustomerName.Name = "clCustomerName";
            this.clCustomerName.OptionsColumn.AllowEdit = false;
            this.clCustomerName.OptionsColumn.AllowFocus = false;
            this.clCustomerName.OptionsColumn.AllowMove = false;
            this.clCustomerName.OptionsColumn.ReadOnly = true;
            this.clCustomerName.Visible = true;
            this.clCustomerName.VisibleIndex = 3;
            this.clCustomerName.Width = 255;
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
            this.clConsignee.Width = 70;
            // 
            // clService
            // 
            this.clService.Caption = "Service Type";
            this.clService.FieldName = "ServiceTypeId";
            this.clService.Name = "clService";
            this.clService.OptionsColumn.AllowEdit = false;
            this.clService.OptionsColumn.AllowFocus = false;
            this.clService.OptionsColumn.AllowMove = false;
            this.clService.OptionsColumn.ReadOnly = true;
            // 
            // clPackage
            // 
            this.clPackage.Caption = "Package";
            this.clPackage.FieldName = "PackageTypeId";
            this.clPackage.Name = "clPackage";
            this.clPackage.OptionsColumn.AllowEdit = false;
            this.clPackage.OptionsColumn.AllowFocus = false;
            this.clPackage.OptionsColumn.AllowMove = false;
            this.clPackage.OptionsColumn.ReadOnly = true;
            // 
            // clPayment
            // 
            this.clPayment.Caption = "Payment";
            this.clPayment.FieldName = "PaymentMethodId";
            this.clPayment.Name = "clPayment";
            this.clPayment.OptionsColumn.AllowEdit = false;
            this.clPayment.OptionsColumn.AllowFocus = false;
            this.clPayment.OptionsColumn.AllowMove = false;
            this.clPayment.OptionsColumn.ReadOnly = true;
            // 
            // clPiece
            // 
            this.clPiece.Caption = "Piece";
            this.clPiece.FieldName = "TtlPiece";
            this.clPiece.Name = "clPiece";
            this.clPiece.OptionsColumn.AllowEdit = false;
            this.clPiece.OptionsColumn.AllowFocus = false;
            this.clPiece.OptionsColumn.AllowMove = false;
            this.clPiece.OptionsColumn.ReadOnly = true;
            this.clPiece.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)});
            this.clPiece.Visible = true;
            this.clPiece.VisibleIndex = 5;
            this.clPiece.Width = 41;
            // 
            // clGw
            // 
            this.clGw.Caption = "Weight";
            this.clGw.DisplayFormat.FormatString = "#,#0.#";
            this.clGw.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clGw.FieldName = "TtlGrossWeight";
            this.clGw.Name = "clGw";
            this.clGw.OptionsColumn.AllowEdit = false;
            this.clGw.OptionsColumn.AllowFocus = false;
            this.clGw.OptionsColumn.AllowMove = false;
            this.clGw.OptionsColumn.ReadOnly = true;
            this.clGw.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clGw.Visible = true;
            this.clGw.VisibleIndex = 6;
            this.clGw.Width = 43;
            // 
            // clCw
            // 
            this.clCw.Caption = "Chargeable";
            this.clCw.DisplayFormat.FormatString = "#,#0.#";
            this.clCw.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clCw.FieldName = "TtlChargeableWeight";
            this.clCw.Name = "clCw";
            this.clCw.OptionsColumn.AllowEdit = false;
            this.clCw.OptionsColumn.AllowFocus = false;
            this.clCw.OptionsColumn.AllowMove = false;
            this.clCw.OptionsColumn.ReadOnly = true;
            this.clCw.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clCw.Visible = true;
            this.clCw.VisibleIndex = 7;
            this.clCw.Width = 82;
            // 
            // clManifestId
            // 
            this.clManifestId.Caption = "Manifest Id";
            this.clManifestId.FieldName = "ManifestId";
            this.clManifestId.Name = "clManifestId";
            this.clManifestId.OptionsColumn.AllowEdit = false;
            this.clManifestId.OptionsColumn.AllowFocus = false;
            this.clManifestId.OptionsColumn.AllowMove = false;
            this.clManifestId.OptionsColumn.ReadOnly = true;
            // 
            // clManifestCode
            // 
            this.clManifestCode.Caption = "Manifest Code";
            this.clManifestCode.FieldName = "ManifestCode";
            this.clManifestCode.Name = "clManifestCode";
            this.clManifestCode.OptionsColumn.AllowEdit = false;
            this.clManifestCode.OptionsColumn.AllowFocus = false;
            this.clManifestCode.OptionsColumn.AllowMove = false;
            this.clManifestCode.OptionsColumn.ReadOnly = true;
            // 
            // clState
            // 
            this.clState.Caption = "State";
            this.clState.FieldName = "StateChange2";
            this.clState.Name = "clState";
            this.clState.OptionsColumn.AllowFocus = false;
            this.clState.OptionsColumn.AllowMove = false;
            this.clState.OptionsColumn.ReadOnly = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(8, 496);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 17);
            this.label9.TabIndex = 30;
            this.label9.Text = "Dimension";
            // 
            // tbxDimension
            // 
            this.tbxDimension.Capslock = true;
            this.tbxDimension.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDimension.FieldLabel = null;
            this.tbxDimension.Location = new System.Drawing.Point(77, 493);
            this.tbxDimension.Name = "tbxDimension";
            this.tbxDimension.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDimension.ReadOnly = true;
            this.tbxDimension.Size = new System.Drawing.Size(257, 24);
            this.tbxDimension.TabIndex = 31;
            this.tbxDimension.ValidationRules = null;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(37, 181);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 17);
            this.label10.TabIndex = 32;
            this.label10.Text = "Kategori";
            // 
            // cbxCategory
            // 
            this.cbxCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(97, 177);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(159, 25);
            this.cbxCategory.TabIndex = 6;
            // 
            // OutboundDaratForm
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 562);
            this.Controls.Add(this.cbxCategory);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbxDimension);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.GridWaybillDetail);
            this.Controls.Add(this.tbxDriver);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxPengangkut);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxBranch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.pnlTop);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "OutboundDaratForm";
            this.Text = "Operation - Lap Outbound Darat";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbxDate, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbxNo, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tbxBranch, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.tbxPengangkut, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.tbxDriver, 0);
            this.Controls.SetChildIndex(this.GridWaybillDetail, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.tbxDimension, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.cbxCategory, 0);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxGw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridWaybillDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WaybillDetailView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private Common.Component.dTextBox tbxBarcode;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private Common.Component.dTextBoxNumber tbxCw;
        private System.Windows.Forms.Label label8;
        private Common.Component.dTextBoxNumber tbxGw;
        private System.Windows.Forms.Label label7;
        private Common.Component.dTextBox tbxDriver;
        private System.Windows.Forms.Label label5;
        private Common.Component.dTextBox tbxPengangkut;
        private System.Windows.Forms.Label label4;
        private Common.Component.dLookup tbxBranch;
        private System.Windows.Forms.Label label3;
        private Common.Component.dTextBox tbxNo;
        private System.Windows.Forms.Label label2;
        private Common.Component.dCalendar tbxDate;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl GridWaybillDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView WaybillDetailView;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private DevExpress.XtraGrid.Columns.GridColumn clDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn clId;
        private DevExpress.XtraGrid.Columns.GridColumn clWaybillId;
        private DevExpress.XtraGrid.Columns.GridColumn clWaybillCode;
        private DevExpress.XtraGrid.Columns.GridColumn clShipmentId;
        private DevExpress.XtraGrid.Columns.GridColumn clShipmentCode;
        private DevExpress.XtraGrid.Columns.GridColumn clShipmentDate;
        private DevExpress.XtraGrid.Columns.GridColumn clConsol;
        private DevExpress.XtraGrid.Columns.GridColumn clBranchId;
        private DevExpress.XtraGrid.Columns.GridColumn clDestinationId;
        private DevExpress.XtraGrid.Columns.GridColumn clDestination;
        private DevExpress.XtraGrid.Columns.GridColumn clCustomerId;
        private DevExpress.XtraGrid.Columns.GridColumn clCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn clShipper;
        private DevExpress.XtraGrid.Columns.GridColumn clConsignee;
        private DevExpress.XtraGrid.Columns.GridColumn clService;
        private DevExpress.XtraGrid.Columns.GridColumn clPackage;
        private DevExpress.XtraGrid.Columns.GridColumn clPayment;
        private DevExpress.XtraGrid.Columns.GridColumn clPiece;
        private DevExpress.XtraGrid.Columns.GridColumn clGw;
        private DevExpress.XtraGrid.Columns.GridColumn clCw;
        private DevExpress.XtraGrid.Columns.GridColumn clManifestId;
        private DevExpress.XtraGrid.Columns.GridColumn clManifestCode;
        private DevExpress.XtraGrid.Columns.GridColumn clState;
        private System.Windows.Forms.Label label9;
        private Common.Component.dTextBox tbxDimension;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxCategory;

    }
}