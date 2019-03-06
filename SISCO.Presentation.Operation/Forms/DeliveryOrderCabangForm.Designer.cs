namespace SISCO.Presentation.Operation.Forms
{
    partial class DeliveryOrderCabangForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryOrderCabangForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.GridDeliveryOrder = new DevExpress.XtraGrid.GridControl();
            this.DeliveryOrderView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipper = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clBranch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clConsignee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPiece = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.tbxAsstDriver = new SISCO.Presentation.Common.Component.dLookup();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxCourier = new SISCO.Presentation.Common.Component.dLookup();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.tbxBarcode = new SISCO.Presentation.Common.Component.dTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxKendaraan = new SISCO.Presentation.Common.Component.dLookup();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxCabang = new SISCO.Presentation.Common.Component.dComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDeliveryOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryOrderView)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAsstDriver.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCourier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxKendaraan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.AutoHeight = false;
            this.btnDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Delete", null, null, true)});
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // GridDeliveryOrder
            // 
            this.GridDeliveryOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridDeliveryOrder.Location = new System.Drawing.Point(-4, 152);
            this.GridDeliveryOrder.MainView = this.DeliveryOrderView;
            this.GridDeliveryOrder.Name = "GridDeliveryOrder";
            this.GridDeliveryOrder.Size = new System.Drawing.Size(899, 303);
            this.GridDeliveryOrder.TabIndex = 8;
            this.GridDeliveryOrder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DeliveryOrderView});
            // 
            // DeliveryOrderView
            // 
            this.DeliveryOrderView.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.DeliveryOrderView.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Transparent;
            this.DeliveryOrderView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.DeliveryOrderView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Transparent;
            this.DeliveryOrderView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Transparent;
            this.DeliveryOrderView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.DeliveryOrderView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clNo,
            this.clDelete,
            this.clShipment,
            this.clShipper,
            this.clBranch,
            this.clPayment,
            this.clConsignee,
            this.clPiece,
            this.clWeight,
            this.gridColumn13,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn17,
            this.gridColumn16});
            this.DeliveryOrderView.GridControl = this.GridDeliveryOrder;
            this.DeliveryOrderView.Name = "DeliveryOrderView";
            this.DeliveryOrderView.OptionsView.ShowFooter = true;
            this.DeliveryOrderView.OptionsView.ShowGroupPanel = false;
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
            this.clNo.Width = 20;
            // 
            // clDelete
            // 
            this.clDelete.Caption = " ";
            this.clDelete.ColumnEdit = this.btnDelete;
            this.clDelete.Name = "clDelete";
            this.clDelete.OptionsColumn.AllowMove = false;
            this.clDelete.Visible = true;
            this.clDelete.VisibleIndex = 1;
            this.clDelete.Width = 20;
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
            this.clShipment.Width = 77;
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
            this.clShipper.Width = 98;
            // 
            // clBranch
            // 
            this.clBranch.Caption = "Origin Branch";
            this.clBranch.FieldName = "Branch";
            this.clBranch.Name = "clBranch";
            this.clBranch.OptionsColumn.AllowEdit = false;
            this.clBranch.OptionsColumn.AllowFocus = false;
            this.clBranch.OptionsColumn.AllowMove = false;
            this.clBranch.OptionsColumn.ReadOnly = true;
            this.clBranch.Visible = true;
            this.clBranch.VisibleIndex = 4;
            this.clBranch.Width = 81;
            // 
            // clPayment
            // 
            this.clPayment.Caption = "Payment";
            this.clPayment.FieldName = "PaymentMethod";
            this.clPayment.Name = "clPayment";
            this.clPayment.OptionsColumn.AllowEdit = false;
            this.clPayment.OptionsColumn.AllowFocus = false;
            this.clPayment.OptionsColumn.AllowMove = false;
            this.clPayment.OptionsColumn.ReadOnly = true;
            this.clPayment.Visible = true;
            this.clPayment.VisibleIndex = 5;
            this.clPayment.Width = 64;
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
            this.clConsignee.VisibleIndex = 6;
            this.clConsignee.Width = 70;
            // 
            // clPiece
            // 
            this.clPiece.Caption = "Pcs";
            this.clPiece.FieldName = "TtlPiece";
            this.clPiece.Name = "clPiece";
            this.clPiece.OptionsColumn.AllowEdit = false;
            this.clPiece.OptionsColumn.AllowFocus = false;
            this.clPiece.OptionsColumn.AllowMove = false;
            this.clPiece.OptionsColumn.ReadOnly = true;
            this.clPiece.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clPiece.Visible = true;
            this.clPiece.VisibleIndex = 7;
            this.clPiece.Width = 33;
            // 
            // clWeight
            // 
            this.clWeight.Caption = "GW";
            this.clWeight.FieldName = "TtlGrossWeight";
            this.clWeight.Name = "clWeight";
            this.clWeight.OptionsColumn.AllowEdit = false;
            this.clWeight.OptionsColumn.AllowFocus = false;
            this.clWeight.OptionsColumn.AllowMove = false;
            this.clWeight.OptionsColumn.ReadOnly = true;
            this.clWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clWeight.Visible = true;
            this.clWeight.VisibleIndex = 8;
            this.clWeight.Width = 22;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "CW";
            this.gridColumn13.FieldName = "TtlChargeableWeight";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.OptionsColumn.AllowMove = false;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 9;
            this.gridColumn13.Width = 39;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.FieldName = "ShipmentId";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "gridColumn3";
            this.gridColumn3.FieldName = "ShipmentDate";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "gridColumn4";
            this.gridColumn4.FieldName = "BranchId";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "gridColumn5";
            this.gridColumn5.FieldName = "DestCityId";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "gridColumn6";
            this.gridColumn6.FieldName = "CustomerId";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "gridColumn7";
            this.gridColumn7.FieldName = "CustomerName";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "gridColumn8";
            this.gridColumn8.FieldName = "ServiceTypeId";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "gridColumn9";
            this.gridColumn9.FieldName = "PackageTypeId";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "gridColumn10";
            this.gridColumn10.FieldName = "PaymentMethodId";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "gridColumn11";
            this.gridColumn11.FieldName = "TtlChargeableWeight";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "gridColumn12";
            this.gridColumn12.FieldName = "StateChange2";
            this.gridColumn12.Name = "gridColumn12";
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "COD";
            this.gridColumn14.FieldName = "IsCod";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.OptionsColumn.AllowMove = false;
            this.gridColumn14.OptionsColumn.ReadOnly = true;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 10;
            this.gridColumn14.Width = 35;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Total COD";
            this.gridColumn15.DisplayFormat.FormatString = "#,#0";
            this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn15.FieldName = "TotalCod";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.OptionsColumn.AllowMove = false;
            this.gridColumn15.OptionsColumn.ReadOnly = true;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 11;
            this.gridColumn15.Width = 64;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Total";
            this.gridColumn17.DisplayFormat.FormatString = "#,#0";
            this.gridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn17.FieldName = "Total";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.OptionsColumn.ReadOnly = true;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 12;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Fulfilment";
            this.gridColumn16.FieldName = "Fulfilment";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.OptionsColumn.ReadOnly = true;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 13;
            this.gridColumn16.Width = 73;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Red;
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(12, 467);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "ONS / SDS";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Blue;
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(84, 467);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Regular";
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExcel.Appearance.Options.UseFont = true;
            this.btnExcel.Location = new System.Drawing.Point(792, 458);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(104, 29);
            this.btnExcel.TabIndex = 9;
            this.btnExcel.Text = "Export To Excel";
            // 
            // pnlTop
            // 
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.Color.Khaki;
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.tbxAsstDriver);
            this.pnlTop.Controls.Add(this.label8);
            this.pnlTop.Controls.Add(this.tbxCourier);
            this.pnlTop.Controls.Add(this.tbxDate);
            this.pnlTop.Controls.Add(this.panel2);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.tbxKendaraan);
            this.pnlTop.Controls.Add(this.label6);
            this.pnlTop.Location = new System.Drawing.Point(0, 69);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(899, 80);
            this.pnlTop.TabIndex = 10;
            // 
            // tbxAsstDriver
            // 
            this.tbxAsstDriver.AutoCompleteDataManager = null;
            this.tbxAsstDriver.AutoCompleteDisplayFormater = null;
            this.tbxAsstDriver.AutoCompleteInitialized = false;
            this.tbxAsstDriver.AutocompleteMinimumTextLength = 0;
            this.tbxAsstDriver.AutoCompleteText = null;
            this.tbxAsstDriver.AutoCompleteWhereExpression = null;
            this.tbxAsstDriver.AutoCompleteWheretermFormater = null;
            this.tbxAsstDriver.ClearOnLeave = true;
            this.tbxAsstDriver.DisplayString = null;
            this.tbxAsstDriver.EditValue = "";
            this.tbxAsstDriver.FieldLabel = null;
            this.tbxAsstDriver.Location = new System.Drawing.Point(116, 52);
            this.tbxAsstDriver.LookupPopup = null;
            this.tbxAsstDriver.Name = "tbxAsstDriver";
            this.tbxAsstDriver.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxAsstDriver.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.tbxAsstDriver.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxAsstDriver.Properties.Appearance.Options.UseBackColor = true;
            this.tbxAsstDriver.Properties.Appearance.Options.UseFont = true;
            this.tbxAsstDriver.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxAsstDriver.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxAsstDriver.Properties.AutoCompleteDataManager = null;
            this.tbxAsstDriver.Properties.AutoCompleteDisplayFormater = null;
            this.tbxAsstDriver.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxAsstDriver.Properties.AutoCompleteText = null;
            this.tbxAsstDriver.Properties.AutoCompleteWhereExpression = null;
            this.tbxAsstDriver.Properties.AutoCompleteWheretermFormater = null;
            this.tbxAsstDriver.Properties.AutoHeight = false;
            this.tbxAsstDriver.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxAsstDriver.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxAsstDriver.Properties.LookupPopup = null;
            this.tbxAsstDriver.Properties.NullText = "<<Choose...>>";
            this.tbxAsstDriver.Size = new System.Drawing.Size(264, 24);
            this.tbxAsstDriver.TabIndex = 4;
            this.tbxAsstDriver.ValidationRules = null;
            this.tbxAsstDriver.Value = null;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(30, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Asst. Driver";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxCourier
            // 
            this.tbxCourier.AutoCompleteDataManager = null;
            this.tbxCourier.AutoCompleteDisplayFormater = null;
            this.tbxCourier.AutoCompleteInitialized = false;
            this.tbxCourier.AutocompleteMinimumTextLength = 0;
            this.tbxCourier.AutoCompleteText = null;
            this.tbxCourier.AutoCompleteWhereExpression = null;
            this.tbxCourier.AutoCompleteWheretermFormater = null;
            this.tbxCourier.ClearOnLeave = true;
            this.tbxCourier.DisplayString = null;
            this.tbxCourier.EditValue = "";
            this.tbxCourier.FieldLabel = null;
            this.tbxCourier.Location = new System.Drawing.Point(116, 27);
            this.tbxCourier.LookupPopup = null;
            this.tbxCourier.Name = "tbxCourier";
            this.tbxCourier.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxCourier.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxCourier.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxCourier.Properties.Appearance.Options.UseBackColor = true;
            this.tbxCourier.Properties.Appearance.Options.UseFont = true;
            this.tbxCourier.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxCourier.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxCourier.Properties.AutoCompleteDataManager = null;
            this.tbxCourier.Properties.AutoCompleteDisplayFormater = null;
            this.tbxCourier.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxCourier.Properties.AutoCompleteText = null;
            this.tbxCourier.Properties.AutoCompleteWhereExpression = null;
            this.tbxCourier.Properties.AutoCompleteWheretermFormater = null;
            this.tbxCourier.Properties.AutoHeight = false;
            this.tbxCourier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxCourier.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.tbxCourier.Properties.LookupPopup = null;
            this.tbxCourier.Properties.NullText = "<<Choose...>>";
            this.tbxCourier.Size = new System.Drawing.Size(264, 24);
            this.tbxCourier.TabIndex = 3;
            this.tbxCourier.ValidationRules = null;
            this.tbxCourier.Value = null;
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(116, 2);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxDate.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxDate.Properties.Appearance.Options.UseBackColor = true;
            this.tbxDate.Properties.Appearance.Options.UseFont = true;
            this.tbxDate.Properties.AutoHeight = false;
            this.tbxDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
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
            this.tbxDate.Size = new System.Drawing.Size(152, 24);
            this.tbxDate.TabIndex = 2;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.tbxBarcode);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(514, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 39);
            this.panel2.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Location = new System.Drawing.Point(309, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(63, 29);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Tambah";
            // 
            // tbxBarcode
            // 
            this.tbxBarcode.Capslock = true;
            this.tbxBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxBarcode.FieldLabel = null;
            this.tbxBarcode.Location = new System.Drawing.Point(68, 6);
            this.tbxBarcode.Name = "tbxBarcode";
            this.tbxBarcode.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxBarcode.Size = new System.Drawing.Size(235, 24);
            this.tbxBarcode.TabIndex = 6;
            this.tbxBarcode.ValidationRules = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "No. CN";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(30, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Kurir / Driver";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(30, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxKendaraan
            // 
            this.tbxKendaraan.AutoCompleteDataManager = null;
            this.tbxKendaraan.AutoCompleteDisplayFormater = null;
            this.tbxKendaraan.AutoCompleteInitialized = false;
            this.tbxKendaraan.AutocompleteMinimumTextLength = 0;
            this.tbxKendaraan.AutoCompleteText = null;
            this.tbxKendaraan.AutoCompleteWhereExpression = null;
            this.tbxKendaraan.AutoCompleteWheretermFormater = null;
            this.tbxKendaraan.ClearOnLeave = true;
            this.tbxKendaraan.DisplayString = null;
            this.tbxKendaraan.EditValue = "";
            this.tbxKendaraan.FieldLabel = null;
            this.tbxKendaraan.Location = new System.Drawing.Point(514, 2);
            this.tbxKendaraan.LookupPopup = null;
            this.tbxKendaraan.Name = "tbxKendaraan";
            this.tbxKendaraan.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxKendaraan.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxKendaraan.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxKendaraan.Properties.Appearance.Options.UseBackColor = true;
            this.tbxKendaraan.Properties.Appearance.Options.UseFont = true;
            this.tbxKendaraan.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxKendaraan.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxKendaraan.Properties.AutoCompleteDataManager = null;
            this.tbxKendaraan.Properties.AutoCompleteDisplayFormater = null;
            this.tbxKendaraan.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxKendaraan.Properties.AutoCompleteText = null;
            this.tbxKendaraan.Properties.AutoCompleteWhereExpression = null;
            this.tbxKendaraan.Properties.AutoCompleteWheretermFormater = null;
            this.tbxKendaraan.Properties.AutoHeight = false;
            this.tbxKendaraan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxKendaraan.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.tbxKendaraan.Properties.LookupPopup = null;
            this.tbxKendaraan.Properties.NullText = "<<Choose...>>";
            this.tbxKendaraan.Size = new System.Drawing.Size(264, 24);
            this.tbxKendaraan.TabIndex = 5;
            this.tbxKendaraan.ValidationRules = null;
            this.tbxKendaraan.Value = null;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(444, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Kendaraan";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(33, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Pilih Cabang";
            // 
            // cbxCabang
            // 
            this.cbxCabang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxCabang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxCabang.FieldLabel = null;
            this.cbxCabang.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxCabang.FormattingEnabled = true;
            this.cbxCabang.Location = new System.Drawing.Point(117, 41);
            this.cbxCabang.Name = "cbxCabang";
            this.cbxCabang.Size = new System.Drawing.Size(504, 25);
            this.cbxCabang.TabIndex = 1;
            this.cbxCabang.ValidationRules = null;
            // 
            // DeliveryOrderCabangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(899, 490);
            this.Controls.Add(this.cbxCabang);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GridDeliveryOrder);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "DeliveryOrderCabangForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Operation - Delivery Order";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.GridDeliveryOrder, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.btnExcel, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.cbxCabang, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDeliveryOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryOrderView)).EndInit();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbxAsstDriver.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCourier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxKendaraan.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GridDeliveryOrder;
        private DevExpress.XtraGrid.Views.Grid.GridView DeliveryOrderView;
        private DevExpress.XtraGrid.Columns.GridColumn clDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn clShipment;
        private DevExpress.XtraGrid.Columns.GridColumn clShipper;
        private DevExpress.XtraGrid.Columns.GridColumn clBranch;
        private DevExpress.XtraGrid.Columns.GridColumn clPayment;
        private DevExpress.XtraGrid.Columns.GridColumn clConsignee;
        private DevExpress.XtraGrid.Columns.GridColumn clPiece;
        private DevExpress.XtraGrid.Columns.GridColumn clWeight;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private System.Windows.Forms.Panel pnlTop;
        private Common.Component.dLookup tbxAsstDriver;
        private System.Windows.Forms.Label label8;
        private Common.Component.dLookup tbxCourier;
        private Common.Component.dCalendar tbxDate;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private Common.Component.dTextBox tbxBarcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Common.Component.dLookup tbxKendaraan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Common.Component.dComboBox cbxCabang;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
    }
}