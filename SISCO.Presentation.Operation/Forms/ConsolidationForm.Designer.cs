namespace SISCO.Presentation.Operation.Forms
{
    partial class ConsolidationForm
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsolidationForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.tbxBarcode = new System.Windows.Forms.TextBox();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxWeight = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.GridConsolidation = new DevExpress.XtraGrid.GridControl();
            this.ConsolidationView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.clShipment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipper = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clConsignee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDestination = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clService = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPiece = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clIsi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipmentId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipmentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDestCityId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clServiceTypeId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPackageTypeId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPaymentMethodId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clGrossWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clChargeable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tbxBranch = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.pnlRight.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridConsolidation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsolidationView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(104, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(26, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Destination Branch";
            // 
            // pnlRight
            // 
            this.pnlRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.tbxBarcode);
            this.pnlRight.Controls.Add(this.btnAdd);
            this.pnlRight.Controls.Add(this.label4);
            this.pnlRight.Location = new System.Drawing.Point(479, 48);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(341, 75);
            this.pnlRight.TabIndex = 2;
            // 
            // tbxBarcode
            // 
            this.tbxBarcode.Location = new System.Drawing.Point(89, 9);
            this.tbxBarcode.Name = "tbxBarcode";
            this.tbxBarcode.Size = new System.Drawing.Size(232, 24);
            this.tbxBarcode.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(89, 36);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 30);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Tambah";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(26, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Barcode";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.btnPrint);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 403);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(832, 39);
            this.pnlBottom.TabIndex = 8;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(718, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(107, 31);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print Barcode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(61, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Total Weight";
            // 
            // tbxWeight
            // 
            this.tbxWeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxWeight.EditMask = "###,###,###,###,###,##0.00";
            this.tbxWeight.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxWeight.FieldLabel = null;
            this.tbxWeight.Location = new System.Drawing.Point(143, 98);
            this.tbxWeight.Name = "tbxWeight";
            this.tbxWeight.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxWeight.Properties.AllowMouseWheel = false;
            this.tbxWeight.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxWeight.Properties.Appearance.Options.UseBackColor = true;
            this.tbxWeight.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxWeight.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxWeight.Properties.Mask.BeepOnError = true;
            this.tbxWeight.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxWeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxWeight.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxWeight.ReadOnly = false;
            this.tbxWeight.Size = new System.Drawing.Size(100, 20);
            this.tbxWeight.TabIndex = 0;
            this.tbxWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxWeight.ValidationRules = null;
            this.tbxWeight.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // GridConsolidation
            // 
            this.GridConsolidation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridConsolidation.Location = new System.Drawing.Point(0, 129);
            this.GridConsolidation.MainView = this.ConsolidationView;
            this.GridConsolidation.Name = "GridConsolidation";
            this.GridConsolidation.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnDelete});
            this.GridConsolidation.Size = new System.Drawing.Size(832, 276);
            this.GridConsolidation.TabIndex = 14;
            this.GridConsolidation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ConsolidationView});
            // 
            // ConsolidationView
            // 
            this.ConsolidationView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Transparent;
            this.ConsolidationView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Transparent;
            this.ConsolidationView.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Transparent;
            this.ConsolidationView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Transparent;
            this.ConsolidationView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.ConsolidationView.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.ConsolidationView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.ConsolidationView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clNo,
            this.clDelete,
            this.clShipment,
            this.clCode,
            this.clShipper,
            this.clConsignee,
            this.clDate,
            this.clDestination,
            this.clPayment,
            this.clService,
            this.clPiece,
            this.clIsi,
            this.clState,
            this.clShipmentId,
            this.clShipmentDate,
            this.clDestCityId,
            this.clServiceTypeId,
            this.clPackageTypeId,
            this.clPaymentMethodId,
            this.clGrossWeight,
            this.clChargeable,
            this.clId});
            this.ConsolidationView.GridControl = this.GridConsolidation;
            this.ConsolidationView.Name = "ConsolidationView";
            this.ConsolidationView.OptionsView.ColumnAutoWidth = false;
            this.ConsolidationView.OptionsView.ShowFooter = true;
            this.ConsolidationView.OptionsView.ShowGroupPanel = false;
            // 
            // clNo
            // 
            this.clNo.AppearanceCell.Options.UseTextOptions = true;
            this.clNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clNo.Caption = "No";
            this.clNo.Name = "clNo";
            this.clNo.OptionsColumn.AllowEdit = false;
            this.clNo.OptionsColumn.AllowFocus = false;
            this.clNo.OptionsColumn.AllowMove = false;
            this.clNo.OptionsColumn.ReadOnly = true;
            this.clNo.Visible = true;
            this.clNo.VisibleIndex = 0;
            this.clNo.Width = 36;
            // 
            // clDelete
            // 
            this.clDelete.Caption = " ";
            this.clDelete.ColumnEdit = this.btnDelete;
            this.clDelete.Name = "clDelete";
            this.clDelete.Visible = true;
            this.clDelete.VisibleIndex = 1;
            this.clDelete.Width = 33;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoHeight = false;
            this.btnDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "Delete", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Delete Row", null, null, true)});
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ReadOnly = true;
            this.btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
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
            this.clShipment.Width = 88;
            // 
            // clCode
            // 
            this.clCode.Caption = "Code";
            this.clCode.FieldName = "ConsolidationCode";
            this.clCode.Name = "clCode";
            this.clCode.OptionsColumn.AllowEdit = false;
            this.clCode.OptionsColumn.AllowFocus = false;
            this.clCode.OptionsColumn.AllowMove = false;
            this.clCode.OptionsColumn.ReadOnly = true;
            this.clCode.Visible = true;
            this.clCode.VisibleIndex = 3;
            this.clCode.Width = 38;
            // 
            // clShipper
            // 
            this.clShipper.Caption = "Shipper";
            this.clShipper.FieldName = "CustomerName";
            this.clShipper.Name = "clShipper";
            this.clShipper.OptionsColumn.AllowEdit = false;
            this.clShipper.OptionsColumn.AllowFocus = false;
            this.clShipper.OptionsColumn.AllowMove = false;
            this.clShipper.OptionsColumn.ReadOnly = true;
            this.clShipper.Visible = true;
            this.clShipper.VisibleIndex = 4;
            this.clShipper.Width = 140;
            // 
            // clConsignee
            // 
            this.clConsignee.Caption = "Consignee";
            this.clConsignee.FieldName = "Consignee";
            this.clConsignee.Name = "clConsignee";
            this.clConsignee.OptionsColumn.AllowEdit = false;
            this.clConsignee.OptionsColumn.AllowFocus = false;
            this.clConsignee.OptionsColumn.AllowMove = false;
            this.clConsignee.OptionsColumn.ReadOnly = true;
            this.clConsignee.Visible = true;
            this.clConsignee.VisibleIndex = 5;
            this.clConsignee.Width = 78;
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
            this.clDate.VisibleIndex = 6;
            this.clDate.Width = 90;
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
            this.clDestination.VisibleIndex = 7;
            this.clDestination.Width = 90;
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
            this.clPayment.VisibleIndex = 8;
            this.clPayment.Width = 70;
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
            this.clService.VisibleIndex = 9;
            this.clService.Width = 60;
            // 
            // clPiece
            // 
            this.clPiece.Caption = "Piece";
            this.clPiece.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clPiece.FieldName = "TtlPiece";
            this.clPiece.Name = "clPiece";
            this.clPiece.OptionsColumn.AllowEdit = false;
            this.clPiece.OptionsColumn.AllowFocus = false;
            this.clPiece.OptionsColumn.AllowMove = false;
            this.clPiece.OptionsColumn.ReadOnly = true;
            this.clPiece.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clPiece.Visible = true;
            this.clPiece.VisibleIndex = 10;
            this.clPiece.Width = 32;
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
            this.clIsi.VisibleIndex = 11;
            this.clIsi.Width = 59;
            // 
            // clState
            // 
            this.clState.Caption = "State";
            this.clState.FieldName = "StateChange2";
            this.clState.Name = "clState";
            this.clState.OptionsColumn.AllowFocus = false;
            this.clState.OptionsColumn.AllowMove = false;
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
            // clShipmentDate
            // 
            this.clShipmentDate.Caption = "Shipment Date";
            this.clShipmentDate.FieldName = "DateProcess";
            this.clShipmentDate.Name = "clShipmentDate";
            this.clShipmentDate.OptionsColumn.AllowEdit = false;
            this.clShipmentDate.OptionsColumn.AllowFocus = false;
            this.clShipmentDate.OptionsColumn.AllowMove = false;
            this.clShipmentDate.OptionsColumn.ReadOnly = true;
            // 
            // clDestCityId
            // 
            this.clDestCityId.Caption = "Dest City";
            this.clDestCityId.FieldName = "DestCityId";
            this.clDestCityId.Name = "clDestCityId";
            this.clDestCityId.OptionsColumn.AllowEdit = false;
            this.clDestCityId.OptionsColumn.AllowFocus = false;
            this.clDestCityId.OptionsColumn.AllowMove = false;
            this.clDestCityId.OptionsColumn.ReadOnly = true;
            // 
            // clServiceTypeId
            // 
            this.clServiceTypeId.Caption = "Service";
            this.clServiceTypeId.FieldName = "ServiceTypeId";
            this.clServiceTypeId.Name = "clServiceTypeId";
            this.clServiceTypeId.OptionsColumn.AllowEdit = false;
            this.clServiceTypeId.OptionsColumn.AllowFocus = false;
            this.clServiceTypeId.OptionsColumn.AllowMove = false;
            this.clServiceTypeId.OptionsColumn.ReadOnly = true;
            // 
            // clPackageTypeId
            // 
            this.clPackageTypeId.Caption = "Package Type";
            this.clPackageTypeId.FieldName = "PackageTypeId";
            this.clPackageTypeId.Name = "clPackageTypeId";
            this.clPackageTypeId.OptionsColumn.AllowEdit = false;
            this.clPackageTypeId.OptionsColumn.AllowFocus = false;
            this.clPackageTypeId.OptionsColumn.AllowMove = false;
            this.clPackageTypeId.OptionsColumn.ReadOnly = true;
            // 
            // clPaymentMethodId
            // 
            this.clPaymentMethodId.Caption = "Payment Method";
            this.clPaymentMethodId.FieldName = "PaymentMethodId";
            this.clPaymentMethodId.Name = "clPaymentMethodId";
            this.clPaymentMethodId.OptionsColumn.AllowEdit = false;
            this.clPaymentMethodId.OptionsColumn.AllowFocus = false;
            this.clPaymentMethodId.OptionsColumn.AllowMove = false;
            this.clPaymentMethodId.OptionsColumn.ReadOnly = true;
            // 
            // clGrossWeight
            // 
            this.clGrossWeight.Caption = "Gross Weight";
            this.clGrossWeight.FieldName = "TtlGrossWeight";
            this.clGrossWeight.Name = "clGrossWeight";
            this.clGrossWeight.OptionsColumn.AllowEdit = false;
            this.clGrossWeight.OptionsColumn.AllowFocus = false;
            this.clGrossWeight.OptionsColumn.AllowMove = false;
            this.clGrossWeight.OptionsColumn.ReadOnly = true;
            // 
            // clChargeable
            // 
            this.clChargeable.Caption = "Chargeable";
            this.clChargeable.FieldName = "TtlChargeableWeight";
            this.clChargeable.Name = "clChargeable";
            this.clChargeable.OptionsColumn.AllowEdit = false;
            this.clChargeable.OptionsColumn.AllowFocus = false;
            this.clChargeable.OptionsColumn.AllowMove = false;
            this.clChargeable.OptionsColumn.ReadOnly = true;
            // 
            // clId
            // 
            this.clId.Caption = "Id";
            this.clId.FieldName = "Id";
            this.clId.Name = "clId";
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
            this.tbxBranch.Location = new System.Drawing.Point(143, 72);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxBranch.Properties.LookupPopup = null;
            this.tbxBranch.Properties.NullText = "<<Choose...>>";
            this.tbxBranch.Size = new System.Drawing.Size(296, 24);
            this.tbxBranch.TabIndex = 1;
            this.tbxBranch.ValidationRules = null;
            this.tbxBranch.Value = null;
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(143, 46);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.AutoHeight = false;
            this.tbxDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
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
            this.tbxDate.Size = new System.Drawing.Size(218, 24);
            this.tbxDate.TabIndex = 0;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Meiryo", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(10, 364);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "Total";
            // 
            // ConsolidationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(832, 442);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxDate);
            this.Controls.Add(this.tbxBranch);
            this.Controls.Add(this.GridConsolidation);
            this.Controls.Add(this.tbxWeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "ConsolidationForm";
            this.Text = "Operation - Consolidation";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.pnlRight, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tbxWeight, 0);
            this.Controls.SetChildIndex(this.GridConsolidation, 0);
            this.Controls.SetChildIndex(this.tbxBranch, 0);
            this.Controls.SetChildIndex(this.tbxDate, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbxWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridConsolidation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsolidationView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlRight;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private System.Windows.Forms.Label label3;
        private Common.Component.dTextBoxNumber tbxWeight;
        private DevExpress.XtraGrid.GridControl GridConsolidation;
        private DevExpress.XtraGrid.Views.Grid.GridView ConsolidationView;
        private DevExpress.XtraGrid.Columns.GridColumn clShipment;
        private DevExpress.XtraGrid.Columns.GridColumn clShipper;
        private DevExpress.XtraGrid.Columns.GridColumn clCode;
        private DevExpress.XtraGrid.Columns.GridColumn clDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn clConsignee;
        private DevExpress.XtraGrid.Columns.GridColumn clDate;
        private DevExpress.XtraGrid.Columns.GridColumn clDestination;
        private DevExpress.XtraGrid.Columns.GridColumn clPayment;
        private DevExpress.XtraGrid.Columns.GridColumn clService;
        private DevExpress.XtraGrid.Columns.GridColumn clIsi;
        private DevExpress.XtraGrid.Columns.GridColumn clState;
        private DevExpress.XtraGrid.Columns.GridColumn clShipmentId;
        private DevExpress.XtraGrid.Columns.GridColumn clShipmentDate;
        private DevExpress.XtraGrid.Columns.GridColumn clDestCityId;
        private DevExpress.XtraGrid.Columns.GridColumn clServiceTypeId;
        private DevExpress.XtraGrid.Columns.GridColumn clPackageTypeId;
        private DevExpress.XtraGrid.Columns.GridColumn clPaymentMethodId;
        private DevExpress.XtraGrid.Columns.GridColumn clPiece;
        private DevExpress.XtraGrid.Columns.GridColumn clGrossWeight;
        private DevExpress.XtraGrid.Columns.GridColumn clChargeable;
        private DevExpress.XtraGrid.Columns.GridColumn clId;
        private Common.Component.dLookup tbxBranch;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private Common.Component.dCalendar tbxDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxBarcode;
    }
}