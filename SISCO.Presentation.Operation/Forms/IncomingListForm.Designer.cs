using DevExpress.XtraGrid.Views.Grid;

namespace SISCO.Presentation.Operation.Forms
{
    partial class IncomingListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IncomingListForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxTo = new SISCO.Presentation.Common.Component.dCalendar();
            this.tbxFrom = new SISCO.Presentation.Common.Component.dCalendar();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxBranch = new SISCO.Presentation.Common.Component.dLookup();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.GridIncoming = new DevExpress.XtraGrid.GridControl();
            this.IncomingView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipmentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipper = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clConsignee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clBranch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDestBranch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPackage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPiece = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCharge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxBranch.Properties)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridIncoming)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncomingView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Wheat;
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.cbxStatus);
            this.pnlTop.Controls.Add(this.label6);
            this.pnlTop.Controls.Add(this.tbxTo);
            this.pnlTop.Controls.Add(this.tbxFrom);
            this.pnlTop.Controls.Add(this.btnView);
            this.pnlTop.Controls.Add(this.groupBox1);
            this.pnlTop.Controls.Add(this.tbxBranch);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(971, 148);
            this.pnlTop.TabIndex = 0;
            // 
            // cbxStatus
            // 
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Location = new System.Drawing.Point(134, 80);
            this.cbxStatus.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(190, 25);
            this.cbxStatus.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(47, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Status";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxTo
            // 
            this.tbxTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxTo.EditValue = null;
            this.tbxTo.FieldLabel = null;
            this.tbxTo.FormatDateTime = "dd-MM-yyyy";
            this.tbxTo.Location = new System.Drawing.Point(134, 30);
            this.tbxTo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbxTo.Name = "tbxTo";
            this.tbxTo.Nullable = false;
            this.tbxTo.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTo.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxTo.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTo.Properties.Appearance.Options.UseBackColor = true;
            this.tbxTo.Properties.Appearance.Options.UseFont = true;
            this.tbxTo.Properties.AutoHeight = false;
            this.tbxTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxTo.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
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
            this.tbxTo.Size = new System.Drawing.Size(116, 24);
            this.tbxTo.TabIndex = 9;
            this.tbxTo.ValidationRules = null;
            this.tbxTo.Value = new System.DateTime(((long)(0)));
            // 
            // tbxFrom
            // 
            this.tbxFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxFrom.EditValue = null;
            this.tbxFrom.FieldLabel = null;
            this.tbxFrom.FormatDateTime = "dd-MM-yyyy";
            this.tbxFrom.Location = new System.Drawing.Point(134, 5);
            this.tbxFrom.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbxFrom.Name = "tbxFrom";
            this.tbxFrom.Nullable = false;
            this.tbxFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFrom.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxFrom.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxFrom.Properties.Appearance.Options.UseBackColor = true;
            this.tbxFrom.Properties.Appearance.Options.UseFont = true;
            this.tbxFrom.Properties.AutoHeight = false;
            this.tbxFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxFrom.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
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
            this.tbxFrom.Size = new System.Drawing.Size(116, 24);
            this.tbxFrom.TabIndex = 8;
            this.tbxFrom.ValidationRules = null;
            this.tbxFrom.Value = new System.DateTime(((long)(0)));
            // 
            // btnView
            // 
            this.btnView.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnView.Appearance.Options.UseFont = true;
            this.btnView.Location = new System.Drawing.Point(134, 109);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(91, 32);
            this.btnView.TabIndex = 7;
            this.btnView.Text = "View";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(678, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox1.Size = new System.Drawing.Size(284, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Legend";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(28, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Biru --> Sudah RECIEVED";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(28, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(218, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "MERAH --> Belum dilakukan INBOUND";
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
            this.tbxBranch.Location = new System.Drawing.Point(134, 55);
            this.tbxBranch.LookupPopup = null;
            this.tbxBranch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbxBranch.Name = "tbxBranch";
            this.tbxBranch.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxBranch.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxBranch.Properties.Appearance.Options.UseFont = true;
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
            this.tbxBranch.Size = new System.Drawing.Size(325, 24);
            this.tbxBranch.TabIndex = 5;
            this.tbxBranch.ValidationRules = null;
            this.tbxBranch.Value = null;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(47, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Origin Branch";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(47, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sampai";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(47, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Controls.Add(this.btnPrint);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 460);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(971, 45);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExcel.Appearance.Options.UseFont = true;
            this.btnExcel.Location = new System.Drawing.Point(845, 4);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(118, 35);
            this.btnExcel.TabIndex = 1;
            this.btnExcel.Text = "Save To Excel";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(738, 4);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(101, 35);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "PRINT";
            // 
            // GridIncoming
            // 
            this.GridIncoming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridIncoming.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.GridIncoming.Location = new System.Drawing.Point(0, 148);
            this.GridIncoming.MainView = this.IncomingView;
            this.GridIncoming.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.GridIncoming.Name = "GridIncoming";
            this.GridIncoming.Size = new System.Drawing.Size(971, 312);
            this.GridIncoming.TabIndex = 2;
            this.GridIncoming.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.IncomingView});
            // 
            // IncomingView
            // 
            this.IncomingView.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.IncomingView.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Transparent;
            this.IncomingView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.IncomingView.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.IncomingView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Transparent;
            this.IncomingView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.IncomingView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clNo,
            this.clShipment,
            this.clShipmentDate,
            this.gridColumn7,
            this.clShipper,
            this.clConsignee,
            this.clBranch,
            this.clDestBranch,
            this.clPayment,
            this.clPackage,
            this.clPiece,
            this.clWeight,
            this.clCharge,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.IncomingView.GridControl = this.GridIncoming;
            this.IncomingView.Name = "IncomingView";
            this.IncomingView.OptionsView.ColumnAutoWidth = false;
            this.IncomingView.OptionsView.ShowFooter = true;
            this.IncomingView.OptionsView.ShowGroupPanel = false;
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
            // clShipment
            // 
            this.clShipment.Caption = "Shipment";
            this.clShipment.FieldName = "Code";
            this.clShipment.Name = "clShipment";
            this.clShipment.OptionsColumn.AllowEdit = false;
            this.clShipment.OptionsColumn.AllowFocus = false;
            this.clShipment.OptionsColumn.AllowMove = false;
            this.clShipment.OptionsColumn.ReadOnly = true;
            this.clShipment.Visible = true;
            this.clShipment.VisibleIndex = 1;
            this.clShipment.Width = 101;
            // 
            // clShipmentDate
            // 
            this.clShipmentDate.Caption = "Date";
            this.clShipmentDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.clShipmentDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clShipmentDate.FieldName = "DateProcess";
            this.clShipmentDate.Name = "clShipmentDate";
            this.clShipmentDate.OptionsColumn.AllowEdit = false;
            this.clShipmentDate.OptionsColumn.AllowFocus = false;
            this.clShipmentDate.OptionsColumn.AllowMove = false;
            this.clShipmentDate.OptionsColumn.ReadOnly = true;
            this.clShipmentDate.Visible = true;
            this.clShipmentDate.VisibleIndex = 3;
            this.clShipmentDate.Width = 71;
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
            this.clShipper.VisibleIndex = 4;
            this.clShipper.Width = 112;
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
            this.clConsignee.VisibleIndex = 5;
            this.clConsignee.Width = 103;
            // 
            // clBranch
            // 
            this.clBranch.Caption = "Orig";
            this.clBranch.FieldName = "CityName";
            this.clBranch.Name = "clBranch";
            this.clBranch.OptionsColumn.AllowEdit = false;
            this.clBranch.OptionsColumn.AllowFocus = false;
            this.clBranch.OptionsColumn.AllowMove = false;
            this.clBranch.OptionsColumn.ReadOnly = true;
            this.clBranch.Visible = true;
            this.clBranch.VisibleIndex = 6;
            this.clBranch.Width = 78;
            // 
            // clDestBranch
            // 
            this.clDestBranch.Caption = "Destination";
            this.clDestBranch.FieldName = "DestCity";
            this.clDestBranch.Name = "clDestBranch";
            this.clDestBranch.OptionsColumn.AllowEdit = false;
            this.clDestBranch.OptionsColumn.AllowFocus = false;
            this.clDestBranch.OptionsColumn.AllowMove = false;
            this.clDestBranch.OptionsColumn.ReadOnly = true;
            this.clDestBranch.Visible = true;
            this.clDestBranch.VisibleIndex = 7;
            this.clDestBranch.Width = 105;
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
            this.clPayment.VisibleIndex = 10;
            this.clPayment.Width = 92;
            // 
            // clPackage
            // 
            this.clPackage.Caption = "Type";
            this.clPackage.FieldName = "PackageType";
            this.clPackage.Name = "clPackage";
            this.clPackage.OptionsColumn.AllowEdit = false;
            this.clPackage.OptionsColumn.AllowFocus = false;
            this.clPackage.OptionsColumn.AllowMove = false;
            this.clPackage.OptionsColumn.ReadOnly = true;
            this.clPackage.Visible = true;
            this.clPackage.VisibleIndex = 11;
            this.clPackage.Width = 79;
            // 
            // clPiece
            // 
            this.clPiece.Caption = "Piece";
            this.clPiece.DisplayFormat.FormatString = "#0";
            this.clPiece.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clPiece.FieldName = "TtlPiece";
            this.clPiece.Name = "clPiece";
            this.clPiece.OptionsColumn.AllowEdit = false;
            this.clPiece.OptionsColumn.AllowFocus = false;
            this.clPiece.OptionsColumn.AllowMove = false;
            this.clPiece.OptionsColumn.ReadOnly = true;
            this.clPiece.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TtlPiece", "{0:#0}")});
            this.clPiece.Visible = true;
            this.clPiece.VisibleIndex = 12;
            this.clPiece.Width = 43;
            // 
            // clWeight
            // 
            this.clWeight.Caption = "Weight";
            this.clWeight.DisplayFormat.FormatString = "#0.0";
            this.clWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clWeight.FieldName = "TtlGrossWeight";
            this.clWeight.Name = "clWeight";
            this.clWeight.OptionsColumn.AllowEdit = false;
            this.clWeight.OptionsColumn.AllowFocus = false;
            this.clWeight.OptionsColumn.AllowMove = false;
            this.clWeight.OptionsColumn.ReadOnly = true;
            this.clWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TtlGrossWeight", "{0:#0.0}")});
            this.clWeight.Visible = true;
            this.clWeight.VisibleIndex = 13;
            this.clWeight.Width = 49;
            // 
            // clCharge
            // 
            this.clCharge.Caption = "Chargeable";
            this.clCharge.DisplayFormat.FormatString = "#0.0";
            this.clCharge.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clCharge.FieldName = "TtlChargeableWeight";
            this.clCharge.Name = "clCharge";
            this.clCharge.OptionsColumn.AllowEdit = false;
            this.clCharge.OptionsColumn.AllowFocus = false;
            this.clCharge.OptionsColumn.AllowMove = false;
            this.clCharge.OptionsColumn.ReadOnly = true;
            this.clCharge.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TtlChargeableWeight", "{0:#0.0}")});
            this.clCharge.Visible = true;
            this.clCharge.VisibleIndex = 14;
            this.clCharge.Width = 74;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Status";
            this.gridColumn1.FieldName = "TrackingStatus";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 15;
            this.gridColumn1.Width = 101;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.FieldName = "Inbound";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Manifest";
            this.gridColumn3.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "ManifestDate";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 8;
            this.gridColumn3.Width = 76;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = " ";
            this.gridColumn4.DisplayFormat.FormatString = "HH:mm";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "ManifestDate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 9;
            this.gridColumn4.Width = 60;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "COD";
            this.gridColumn5.FieldName = "IsCod";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.AllowMove = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 16;
            this.gridColumn5.Width = 35;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Total COD";
            this.gridColumn6.DisplayFormat.FormatString = "#,#0";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn6.FieldName = "TotalCod";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.AllowMove = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalCod", "{0:#,#0}")});
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 17;
            this.gridColumn6.Width = 86;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Service";
            this.gridColumn7.FieldName = "ServiceType";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 78;
            // 
            // IncomingListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(971, 505);
            this.Controls.Add(this.GridIncoming);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "IncomingListForm";
            this.Text = "Operation - Incoming List";
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxBranch.Properties)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridIncoming)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncomingView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.GroupBox groupBox1;
        private Common.Component.dLookup tbxBranch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.GridControl GridIncoming;
        private DevExpress.XtraGrid.Views.Grid.GridView IncomingView;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraGrid.Columns.GridColumn clShipment;
        private DevExpress.XtraGrid.Columns.GridColumn clShipmentDate;
        private DevExpress.XtraGrid.Columns.GridColumn clShipper;
        private DevExpress.XtraGrid.Columns.GridColumn clConsignee;
        private DevExpress.XtraGrid.Columns.GridColumn clBranch;
        private DevExpress.XtraGrid.Columns.GridColumn clDestBranch;
        private DevExpress.XtraGrid.Columns.GridColumn clPayment;
        private DevExpress.XtraGrid.Columns.GridColumn clPackage;
        private DevExpress.XtraGrid.Columns.GridColumn clPiece;
        private DevExpress.XtraGrid.Columns.GridColumn clWeight;
        private DevExpress.XtraGrid.Columns.GridColumn clCharge;
        private Common.Component.dCalendar tbxFrom;
        private Common.Component.dCalendar tbxTo;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;

    }
}