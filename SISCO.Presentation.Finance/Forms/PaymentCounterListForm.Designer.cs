namespace SISCO.Presentation.Finance.Forms
{
    partial class PaymentCounterListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentCounterListForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxTo = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tbxFrom = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.GridCash = new DevExpress.XtraGrid.GridControl();
            this.CashView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipper = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clConsignee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPiece = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clChargeable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridCash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.cbxStatus);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbxTo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbxFrom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 123);
            this.panel1.TabIndex = 0;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(100, 86);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(92, 30);
            this.btnView.TabIndex = 14;
            this.btnView.Text = "VIEW";
            // 
            // cbxStatus
            // 
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Location = new System.Drawing.Point(100, 56);
            this.cbxStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(230, 25);
            this.cbxStatus.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(11, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Status";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxTo
            // 
            this.tbxTo.EditValue = null;
            this.tbxTo.FieldLabel = null;
            this.tbxTo.FormatDateTime = "dd-MM-yyyy";
            this.tbxTo.Location = new System.Drawing.Point(100, 30);
            this.tbxTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxTo.Name = "tbxTo";
            this.tbxTo.Nullable = false;
            this.tbxTo.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTo.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxTo.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTo.Properties.Appearance.Options.UseBackColor = true;
            this.tbxTo.Properties.Appearance.Options.UseFont = true;
            this.tbxTo.Properties.AutoHeight = false;
            this.tbxTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxTo.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.tbxTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxTo.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxTo.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxTo.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxTo.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxTo.Properties.NullText = "<<Choose...>>";
            this.tbxTo.Size = new System.Drawing.Size(141, 24);
            this.tbxTo.TabIndex = 9;
            this.tbxTo.ValidationRules = null;
            this.tbxTo.Value = new System.DateTime(((long)(0)));
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Sampai";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxFrom
            // 
            this.tbxFrom.EditValue = null;
            this.tbxFrom.FieldLabel = null;
            this.tbxFrom.FormatDateTime = "dd-MM-yyyy";
            this.tbxFrom.Location = new System.Drawing.Point(100, 4);
            this.tbxFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxFrom.Name = "tbxFrom";
            this.tbxFrom.Nullable = false;
            this.tbxFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFrom.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxFrom.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxFrom.Properties.Appearance.Options.UseBackColor = true;
            this.tbxFrom.Properties.Appearance.Options.UseFont = true;
            this.tbxFrom.Properties.AutoHeight = false;
            this.tbxFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxFrom.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxFrom.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxFrom.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxFrom.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxFrom.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxFrom.Properties.NullText = "<<Choose...>>";
            this.tbxFrom.Size = new System.Drawing.Size(141, 24);
            this.tbxFrom.TabIndex = 8;
            this.tbxFrom.ValidationRules = null;
            this.tbxFrom.Value = new System.DateTime(((long)(0)));
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Dari";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnExcel);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Location = new System.Drawing.Point(2, 422);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(828, 46);
            this.panel2.TabIndex = 12;
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Location = new System.Drawing.Point(720, 7);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(103, 31);
            this.btnExcel.TabIndex = 0;
            this.btnExcel.Text = "Save To Excel";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(625, 7);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(87, 31);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "PRINT";
            // 
            // GridCash
            // 
            this.GridCash.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridCash.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GridCash.Location = new System.Drawing.Point(2, 126);
            this.GridCash.MainView = this.CashView;
            this.GridCash.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GridCash.Name = "GridCash";
            this.GridCash.Size = new System.Drawing.Size(828, 295);
            this.GridCash.TabIndex = 11;
            this.GridCash.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.CashView});
            // 
            // CashView
            // 
            this.CashView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clNo,
            this.clShipment,
            this.clDate,
            this.clShipper,
            this.clConsignee,
            this.clType,
            this.clPiece,
            this.clWeight,
            this.clChargeable,
            this.clTotal,
            this.clMethod,
            this.gridColumn1,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.CashView.GridControl = this.GridCash;
            this.CashView.Name = "CashView";
            this.CashView.OptionsView.ColumnAutoWidth = false;
            this.CashView.OptionsView.ShowFooter = true;
            this.CashView.OptionsView.ShowGroupPanel = false;
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
            this.clNo.Width = 30;
            // 
            // clShipment
            // 
            this.clShipment.Caption = "No. STT";
            this.clShipment.FieldName = "Code";
            this.clShipment.Name = "clShipment";
            this.clShipment.OptionsColumn.AllowEdit = false;
            this.clShipment.OptionsColumn.AllowFocus = false;
            this.clShipment.OptionsColumn.AllowMove = false;
            this.clShipment.OptionsColumn.ReadOnly = true;
            this.clShipment.Visible = true;
            this.clShipment.VisibleIndex = 1;
            this.clShipment.Width = 113;
            // 
            // clDate
            // 
            this.clDate.Caption = "Date";
            this.clDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.clDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clDate.FieldName = "DateProcess";
            this.clDate.Name = "clDate";
            this.clDate.OptionsColumn.AllowEdit = false;
            this.clDate.OptionsColumn.AllowFocus = false;
            this.clDate.OptionsColumn.AllowMove = false;
            this.clDate.OptionsColumn.ReadOnly = true;
            this.clDate.Visible = true;
            this.clDate.VisibleIndex = 2;
            this.clDate.Width = 69;
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
            this.clShipper.Width = 100;
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
            this.clConsignee.Width = 82;
            // 
            // clType
            // 
            this.clType.Caption = "Sales Type";
            this.clType.FieldName = "SalesType";
            this.clType.Name = "clType";
            this.clType.OptionsColumn.AllowEdit = false;
            this.clType.OptionsColumn.AllowFocus = false;
            this.clType.OptionsColumn.AllowMove = false;
            this.clType.OptionsColumn.ReadOnly = true;
            this.clType.Visible = true;
            this.clType.VisibleIndex = 5;
            this.clType.Width = 79;
            // 
            // clPiece
            // 
            this.clPiece.Caption = "Piece";
            this.clPiece.DisplayFormat.FormatString = "#";
            this.clPiece.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clPiece.FieldName = "TtlPiece";
            this.clPiece.GroupFormat.FormatString = "n";
            this.clPiece.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clPiece.Name = "clPiece";
            this.clPiece.OptionsColumn.AllowEdit = false;
            this.clPiece.OptionsColumn.AllowFocus = false;
            this.clPiece.OptionsColumn.AllowMove = false;
            this.clPiece.OptionsColumn.ReadOnly = true;
            this.clPiece.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TtlPiece", "{0:n2}")});
            this.clPiece.Visible = true;
            this.clPiece.VisibleIndex = 6;
            this.clPiece.Width = 38;
            // 
            // clWeight
            // 
            this.clWeight.Caption = "Weight";
            this.clWeight.DisplayFormat.FormatString = "n";
            this.clWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clWeight.FieldName = "TtlGrossWeight";
            this.clWeight.GroupFormat.FormatString = "n";
            this.clWeight.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clWeight.Name = "clWeight";
            this.clWeight.OptionsColumn.AllowEdit = false;
            this.clWeight.OptionsColumn.AllowFocus = false;
            this.clWeight.OptionsColumn.AllowMove = false;
            this.clWeight.OptionsColumn.ReadOnly = true;
            this.clWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TtlGrossWeight", "{0:n2}")});
            this.clWeight.Visible = true;
            this.clWeight.VisibleIndex = 7;
            this.clWeight.Width = 53;
            // 
            // clChargeable
            // 
            this.clChargeable.Caption = "Chargeable";
            this.clChargeable.DisplayFormat.FormatString = "n";
            this.clChargeable.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clChargeable.FieldName = "TtlChargeableWeight";
            this.clChargeable.GroupFormat.FormatString = "n";
            this.clChargeable.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clChargeable.Name = "clChargeable";
            this.clChargeable.OptionsColumn.AllowEdit = false;
            this.clChargeable.OptionsColumn.AllowFocus = false;
            this.clChargeable.OptionsColumn.AllowMove = false;
            this.clChargeable.OptionsColumn.ReadOnly = true;
            this.clChargeable.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TtlChargeableWeight", "{0:n2}")});
            this.clChargeable.Visible = true;
            this.clChargeable.VisibleIndex = 8;
            this.clChargeable.Width = 69;
            // 
            // clTotal
            // 
            this.clTotal.Caption = "Total";
            this.clTotal.DisplayFormat.FormatString = "#,#0";
            this.clTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clTotal.FieldName = "Total";
            this.clTotal.GroupFormat.FormatString = "n";
            this.clTotal.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clTotal.Name = "clTotal";
            this.clTotal.OptionsColumn.AllowEdit = false;
            this.clTotal.OptionsColumn.AllowFocus = false;
            this.clTotal.OptionsColumn.AllowMove = false;
            this.clTotal.OptionsColumn.ReadOnly = true;
            this.clTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:n2}")});
            this.clTotal.Visible = true;
            this.clTotal.VisibleIndex = 9;
            this.clTotal.Width = 81;
            // 
            // clMethod
            // 
            this.clMethod.Caption = "Paid";
            this.clMethod.FieldName = "Paid";
            this.clMethod.Name = "clMethod";
            this.clMethod.OptionsColumn.AllowEdit = false;
            this.clMethod.OptionsColumn.AllowFocus = false;
            this.clMethod.OptionsColumn.AllowMove = false;
            this.clMethod.OptionsColumn.ReadOnly = true;
            this.clMethod.Visible = true;
            this.clMethod.VisibleIndex = 10;
            this.clMethod.Width = 38;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Void";
            this.gridColumn1.FieldName = "Voided";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 11;
            this.gridColumn1.Width = 40;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Verified";
            this.gridColumn2.FieldName = "Verified";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 15;
            this.gridColumn2.Width = 49;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Verified Date";
            this.gridColumn3.FieldName = "VerifiedDate";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 16;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Verified By";
            this.gridColumn4.FieldName = "VerifiedBy";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 17;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Payment Code";
            this.gridColumn5.FieldName = "PaymentCode";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 12;
            this.gridColumn5.Width = 88;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Payment Date";
            this.gridColumn6.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn6.FieldName = "PaymentDate";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 13;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Description";
            this.gridColumn7.FieldName = "PaymentDescription";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 14;
            // 
            // PaymentCounterListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 470);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.GridCash);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PaymentCounterListForm";
            this.Text = "Finance - Counter Cash List";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridCash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.Label label4;
        private Common.Component.dCalendar tbxTo;
        private System.Windows.Forms.Label label2;
        private Common.Component.dCalendar tbxFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraGrid.GridControl GridCash;
        private DevExpress.XtraGrid.Views.Grid.GridView CashView;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private DevExpress.XtraGrid.Columns.GridColumn clShipment;
        private DevExpress.XtraGrid.Columns.GridColumn clDate;
        private DevExpress.XtraGrid.Columns.GridColumn clShipper;
        private DevExpress.XtraGrid.Columns.GridColumn clConsignee;
        private DevExpress.XtraGrid.Columns.GridColumn clType;
        private DevExpress.XtraGrid.Columns.GridColumn clPiece;
        private DevExpress.XtraGrid.Columns.GridColumn clWeight;
        private DevExpress.XtraGrid.Columns.GridColumn clChargeable;
        private DevExpress.XtraGrid.Columns.GridColumn clTotal;
        private DevExpress.XtraGrid.Columns.GridColumn clMethod;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;

    }
}