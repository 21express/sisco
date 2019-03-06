namespace SISCO.Presentation.Franchise.Forms
{
    partial class ShipmentDeliveryListForm
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShipmentDeliveryListForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.cmbTrackingStatus = new SISCO.Presentation.Common.Component.dComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxService = new SISCO.Presentation.Common.Component.dLookup();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxFranchise = new SISCO.Presentation.Common.Component.dLookup();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxTo = new SISCO.Presentation.Common.Component.dCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxFrom = new SISCO.Presentation.Common.Component.dCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn99 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnCsv = new DevExpress.XtraEditors.SimpleButton();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalPieces = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotalChargeableWeight = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.tbxBranch = new SISCO.Presentation.Common.Component.dLookup();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlFilter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxService.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFranchise.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPieces.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalChargeableWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxBranch.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilter.BackColor = System.Drawing.Color.Thistle;
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilter.Controls.Add(this.tbxBranch);
            this.pnlFilter.Controls.Add(this.label10);
            this.pnlFilter.Controls.Add(this.cmbTrackingStatus);
            this.pnlFilter.Controls.Add(this.groupBox1);
            this.pnlFilter.Controls.Add(this.btnView);
            this.pnlFilter.Controls.Add(this.label5);
            this.pnlFilter.Controls.Add(this.tbxService);
            this.pnlFilter.Controls.Add(this.label4);
            this.pnlFilter.Controls.Add(this.tbxFranchise);
            this.pnlFilter.Controls.Add(this.label3);
            this.pnlFilter.Controls.Add(this.tbxTo);
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.tbxFrom);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Location = new System.Drawing.Point(4, 4);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(904, 178);
            this.pnlFilter.TabIndex = 0;
            // 
            // cmbTrackingStatus
            // 
            this.cmbTrackingStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTrackingStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTrackingStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrackingStatus.FieldLabel = null;
            this.cmbTrackingStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbTrackingStatus.FormattingEnabled = true;
            this.cmbTrackingStatus.Location = new System.Drawing.Point(104, 116);
            this.cmbTrackingStatus.Name = "cmbTrackingStatus";
            this.cmbTrackingStatus.Size = new System.Drawing.Size(206, 25);
            this.cmbTrackingStatus.TabIndex = 6;
            this.cmbTrackingStatus.ValidationRules = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(587, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 115);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Legend";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(38, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Received --> Biru";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(38, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Loss atau Return --> Merah";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(103, 144);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 7;
            this.btnView.Text = "&View";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Status";
            // 
            // tbxService
            // 
            this.tbxService.AutoCompleteDataManager = null;
            this.tbxService.AutoCompleteDisplayFormater = null;
            this.tbxService.AutoCompleteInitialized = false;
            this.tbxService.AutocompleteMinimumTextLength = 0;
            this.tbxService.AutoCompleteText = null;
            this.tbxService.AutoCompleteWhereExpression = null;
            this.tbxService.AutoCompleteWheretermFormater = null;
            this.tbxService.ClearOnLeave = true;
            this.tbxService.DisplayString = null;
            this.tbxService.FieldLabel = null;
            this.tbxService.Location = new System.Drawing.Point(104, 88);
            this.tbxService.LookupPopup = null;
            this.tbxService.Name = "tbxService";
            this.tbxService.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxService.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxService.Properties.Appearance.Options.UseFont = true;
            this.tbxService.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxService.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxService.Properties.AutoCompleteDataManager = null;
            this.tbxService.Properties.AutoCompleteDisplayFormater = null;
            this.tbxService.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxService.Properties.AutoCompleteText = null;
            this.tbxService.Properties.AutoCompleteWhereExpression = null;
            this.tbxService.Properties.AutoCompleteWheretermFormater = null;
            this.tbxService.Properties.AutoHeight = false;
            this.tbxService.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxService.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxService.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxService.Properties.LookupPopup = null;
            this.tbxService.Properties.NullText = "<<Choose...>>";
            this.tbxService.Size = new System.Drawing.Size(256, 25);
            this.tbxService.TabIndex = 5;
            this.tbxService.ValidationRules = null;
            this.tbxService.Value = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Service Type";
            // 
            // tbxFranchise
            // 
            this.tbxFranchise.AutoCompleteDataManager = null;
            this.tbxFranchise.AutoCompleteDisplayFormater = null;
            this.tbxFranchise.AutoCompleteInitialized = false;
            this.tbxFranchise.AutocompleteMinimumTextLength = 0;
            this.tbxFranchise.AutoCompleteText = null;
            this.tbxFranchise.AutoCompleteWhereExpression = null;
            this.tbxFranchise.AutoCompleteWheretermFormater = null;
            this.tbxFranchise.ClearOnLeave = true;
            this.tbxFranchise.DisplayString = null;
            this.tbxFranchise.FieldLabel = null;
            this.tbxFranchise.Location = new System.Drawing.Point(104, 32);
            this.tbxFranchise.LookupPopup = null;
            this.tbxFranchise.Name = "tbxFranchise";
            this.tbxFranchise.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFranchise.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxFranchise.Properties.Appearance.Options.UseFont = true;
            this.tbxFranchise.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxFranchise.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxFranchise.Properties.AutoCompleteDataManager = null;
            this.tbxFranchise.Properties.AutoCompleteDisplayFormater = null;
            this.tbxFranchise.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxFranchise.Properties.AutoCompleteText = null;
            this.tbxFranchise.Properties.AutoCompleteWhereExpression = null;
            this.tbxFranchise.Properties.AutoCompleteWheretermFormater = null;
            this.tbxFranchise.Properties.AutoHeight = false;
            this.tbxFranchise.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxFranchise.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.tbxFranchise.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxFranchise.Properties.LookupPopup = null;
            this.tbxFranchise.Properties.NullText = "<<Choose...>>";
            this.tbxFranchise.Size = new System.Drawing.Size(378, 25);
            this.tbxFranchise.TabIndex = 3;
            this.tbxFranchise.ValidationRules = null;
            this.tbxFranchise.Value = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Franchise";
            // 
            // tbxTo
            // 
            this.tbxTo.EditValue = null;
            this.tbxTo.FieldLabel = null;
            this.tbxTo.FormatDateTime = "dd-MM-yyyy";
            this.tbxTo.Location = new System.Drawing.Point(232, 5);
            this.tbxTo.Name = "tbxTo";
            this.tbxTo.Nullable = false;
            this.tbxTo.OriginalBackColor = System.Drawing.Color.Empty;
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
            this.tbxTo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTo.Size = new System.Drawing.Size(109, 25);
            this.tbxTo.TabIndex = 2;
            this.tbxTo.ValidationRules = null;
            this.tbxTo.Value = new System.DateTime(((long)(0)));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "-";
            // 
            // tbxFrom
            // 
            this.tbxFrom.EditValue = null;
            this.tbxFrom.FieldLabel = null;
            this.tbxFrom.FormatDateTime = "dd-MM-yyyy";
            this.tbxFrom.Location = new System.Drawing.Point(104, 5);
            this.tbxFrom.Name = "tbxFrom";
            this.tbxFrom.Nullable = false;
            this.tbxFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFrom.Properties.AutoHeight = false;
            this.tbxFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxFrom.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.tbxFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxFrom.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxFrom.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxFrom.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxFrom.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxFrom.Size = new System.Drawing.Size(109, 25);
            this.tbxFrom.TabIndex = 1;
            this.tbxFrom.ValidationRules = null;
            this.tbxFrom.Value = new System.DateTime(((long)(0)));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.Location = new System.Drawing.Point(4, 188);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(904, 237);
            this.grid.TabIndex = 53;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn14,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn99,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn3,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Shipment No.";
            this.gridColumn1.FieldName = "Code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 85;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Date";
            this.gridColumn2.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "DateProcess";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 68;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Shipper";
            this.gridColumn14.FieldName = "ShipperName";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Consignee";
            this.gridColumn4.FieldName = "ConsigneeName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 82;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Package Type";
            this.gridColumn5.FieldName = "PackageType";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 60;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Destination";
            this.gridColumn6.FieldName = "DestCity";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 86;
            // 
            // gridColumn99
            // 
            this.gridColumn99.Caption = "Dest. Branch";
            this.gridColumn99.FieldName = "DestBranch";
            this.gridColumn99.Name = "gridColumn99";
            this.gridColumn99.Visible = true;
            this.gridColumn99.VisibleIndex = 6;
            this.gridColumn99.Width = 72;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Service Type";
            this.gridColumn7.FieldName = "ServiceType";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 57;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Piece";
            this.gridColumn8.FieldName = "TtlPiece";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            this.gridColumn8.Width = 35;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "CW";
            this.gridColumn9.FieldName = "TtlChargeableWeight";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 9;
            this.gridColumn9.Width = 45;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Dlv. Date";
            this.gridColumn10.FieldName = "DeliveryDateStr";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 10;
            this.gridColumn10.Width = 74;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Time";
            this.gridColumn3.FieldName = "DeliveryTime";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 11;
            this.gridColumn3.Width = 45;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Recipient";
            this.gridColumn11.FieldName = "RecipientName";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 12;
            this.gridColumn11.Width = 71;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Note";
            this.gridColumn12.FieldName = "DeliveryNote";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 13;
            this.gridColumn12.Width = 73;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Lead Time";
            this.gridColumn13.FieldName = "LeadTime";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 14;
            this.gridColumn13.Width = 62;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(823, 428);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(85, 28);
            this.btnExcel.TabIndex = 54;
            this.btnExcel.Text = "Save to &Excel";
            // 
            // btnCsv
            // 
            this.btnCsv.Location = new System.Drawing.Point(732, 428);
            this.btnCsv.Name = "btnCsv";
            this.btnCsv.Size = new System.Drawing.Size(85, 28);
            this.btnCsv.TabIndex = 55;
            this.btnCsv.Text = "Save to &CSV";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 434);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 17);
            this.label8.TabIndex = 56;
            this.label8.Text = "Total Pcs:";
            // 
            // txtTotalPieces
            // 
            this.txtTotalPieces.EditMask = "###,###,###,###,###,##0.00";
            this.txtTotalPieces.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalPieces.FieldLabel = null;
            this.txtTotalPieces.Location = new System.Drawing.Point(97, 431);
            this.txtTotalPieces.Name = "txtTotalPieces";
            this.txtTotalPieces.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtTotalPieces.Properties.AllowMouseWheel = false;
            this.txtTotalPieces.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.txtTotalPieces.Properties.Appearance.Options.UseFont = true;
            this.txtTotalPieces.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalPieces.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalPieces.Properties.Mask.BeepOnError = true;
            this.txtTotalPieces.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtTotalPieces.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalPieces.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalPieces.ReadOnly = false;
            this.txtTotalPieces.Size = new System.Drawing.Size(97, 24);
            this.txtTotalPieces.TabIndex = 136;
            this.txtTotalPieces.TextAlign = null;
            this.txtTotalPieces.ValidationRules = null;
            this.txtTotalPieces.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(202, 435);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 17);
            this.label9.TabIndex = 137;
            this.label9.Text = "CW:";
            // 
            // txtTotalChargeableWeight
            // 
            this.txtTotalChargeableWeight.EditMask = "###,###,###,###,###,##0.00";
            this.txtTotalChargeableWeight.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalChargeableWeight.FieldLabel = null;
            this.txtTotalChargeableWeight.Location = new System.Drawing.Point(237, 431);
            this.txtTotalChargeableWeight.Name = "txtTotalChargeableWeight";
            this.txtTotalChargeableWeight.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtTotalChargeableWeight.Properties.AllowMouseWheel = false;
            this.txtTotalChargeableWeight.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.txtTotalChargeableWeight.Properties.Appearance.Options.UseFont = true;
            this.txtTotalChargeableWeight.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalChargeableWeight.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalChargeableWeight.Properties.Mask.BeepOnError = true;
            this.txtTotalChargeableWeight.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtTotalChargeableWeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalChargeableWeight.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalChargeableWeight.ReadOnly = false;
            this.txtTotalChargeableWeight.Size = new System.Drawing.Size(97, 24);
            this.txtTotalChargeableWeight.TabIndex = 138;
            this.txtTotalChargeableWeight.TextAlign = null;
            this.txtTotalChargeableWeight.ValidationRules = null;
            this.txtTotalChargeableWeight.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
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
            this.tbxBranch.Location = new System.Drawing.Point(104, 60);
            this.tbxBranch.LookupPopup = null;
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dLookup1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.tbxBranch.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxBranch.Properties.LookupPopup = null;
            this.tbxBranch.Properties.NullText = "<<Choose...>>";
            this.tbxBranch.Size = new System.Drawing.Size(256, 25);
            this.tbxBranch.TabIndex = 4;
            this.tbxBranch.ValidationRules = null;
            this.tbxBranch.Value = null;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(52, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 17);
            this.label10.TabIndex = 13;
            this.label10.Text = "Branch";
            // 
            // ShipmentDeliveryListForm
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 458);
            this.Controls.Add(this.txtTotalChargeableWeight);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTotalPieces);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCsv);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.pnlFilter);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShipmentDeliveryListForm";
            this.Text = "Shipment Delivery List";
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxService.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFranchise.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPieces.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalChargeableWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxBranch.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private global::SISCO.Presentation.Common.Component.dCalendar tbxFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private System.Windows.Forms.Label label5;
        private global::SISCO.Presentation.Common.Component.dLookup tbxService;
        private System.Windows.Forms.Label label4;
        private global::SISCO.Presentation.Common.Component.dLookup tbxFranchise;
        private System.Windows.Forms.Label label3;
        private global::SISCO.Presentation.Common.Component.dCalendar tbxTo;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn99;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraEditors.SimpleButton btnCsv;
        private Common.Component.dComboBox cmbTrackingStatus;
        private System.Windows.Forms.Label label8;
        private Common.Component.dTextBoxNumber txtTotalPieces;
        private System.Windows.Forms.Label label9;
        private Common.Component.dTextBoxNumber txtTotalChargeableWeight;
        private Common.Component.dLookup tbxBranch;
        private System.Windows.Forms.Label label10;
    }
}