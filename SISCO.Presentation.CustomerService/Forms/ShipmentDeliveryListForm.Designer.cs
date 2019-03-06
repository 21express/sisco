using System.Windows.Forms;

namespace SISCO.Presentation.CustomerService.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShipmentDeliveryListForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
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
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lkpFranchise = new SISCO.Presentation.Common.Component.dLookup();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbTrackingStatus = new SISCO.Presentation.Common.Component.dComboBox();
            this.lkpDestination = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpServiceType = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpDestinationBranch = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpCustomer = new SISCO.Presentation.Common.Component.dLookup();
            this.txtDateTo = new SISCO.Presentation.Common.Component.dCalendar();
            this.txtDateFrom = new SISCO.Presentation.Common.Component.dCalendar();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTotalChargeableWeight = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.txtTotalPieces = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.btnSaveToExcel = new System.Windows.Forms.Button();
            this.btnSaveToCsv = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFranchise.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestination.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpServiceType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestinationBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalChargeableWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPieces.Properties)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grid.Location = new System.Drawing.Point(5, 189);
            this.grid.MainView = this.gridView;
            this.grid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(959, 265);
            this.grid.TabIndex = 52;
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
            this.gridColumn13,
            this.gridColumn15});
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
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Updated By";
            this.gridColumn15.FieldName = "Createdby";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.OptionsColumn.ReadOnly = true;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lkpFranchise);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cmbTrackingStatus);
            this.groupBox1.Controls.Add(this.lkpDestination);
            this.groupBox1.Controls.Add(this.lkpServiceType);
            this.groupBox1.Controls.Add(this.lkpDestinationBranch);
            this.groupBox1.Controls.Add(this.lkpCustomer);
            this.groupBox1.Controls.Add(this.txtDateTo);
            this.groupBox1.Controls.Add(this.txtDateFrom);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label91);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(530, 178);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // lkpFranchise
            // 
            this.lkpFranchise.AutoCompleteDataManager = null;
            this.lkpFranchise.AutoCompleteDisplayFormater = null;
            this.lkpFranchise.AutoCompleteInitialized = false;
            this.lkpFranchise.AutocompleteMinimumTextLength = 0;
            this.lkpFranchise.AutoCompleteText = null;
            this.lkpFranchise.AutoCompleteWhereExpression = null;
            this.lkpFranchise.AutoCompleteWheretermFormater = null;
            this.lkpFranchise.ClearOnLeave = true;
            this.lkpFranchise.DisplayString = null;
            this.lkpFranchise.FieldLabel = null;
            this.lkpFranchise.Location = new System.Drawing.Point(97, 95);
            this.lkpFranchise.LookupPopup = null;
            this.lkpFranchise.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkpFranchise.Name = "lkpFranchise";
            this.lkpFranchise.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpFranchise.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpFranchise.Properties.Appearance.Options.UseFont = true;
            this.lkpFranchise.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpFranchise.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpFranchise.Properties.AutoCompleteDataManager = null;
            this.lkpFranchise.Properties.AutoCompleteDisplayFormater = null;
            this.lkpFranchise.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpFranchise.Properties.AutoCompleteText = null;
            this.lkpFranchise.Properties.AutoCompleteWhereExpression = null;
            this.lkpFranchise.Properties.AutoCompleteWheretermFormater = null;
            this.lkpFranchise.Properties.AutoHeight = false;
            this.lkpFranchise.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpFranchise.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpFranchise.Properties.LookupPopup = null;
            this.lkpFranchise.Properties.NullText = "<<Choose...>>";
            this.lkpFranchise.Size = new System.Drawing.Size(292, 24);
            this.lkpFranchise.TabIndex = 6;
            this.lkpFranchise.ValidationRules = null;
            this.lkpFranchise.Value = null;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(15, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 17);
            this.label11.TabIndex = 191;
            this.label11.Text = "Franchise";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTrackingStatus
            // 
            this.cmbTrackingStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTrackingStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTrackingStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrackingStatus.FieldLabel = null;
            this.cmbTrackingStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbTrackingStatus.FormattingEnabled = true;
            this.cmbTrackingStatus.IntegralHeight = false;
            this.cmbTrackingStatus.Location = new System.Drawing.Point(343, 120);
            this.cmbTrackingStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTrackingStatus.Name = "cmbTrackingStatus";
            this.cmbTrackingStatus.Size = new System.Drawing.Size(170, 25);
            this.cmbTrackingStatus.TabIndex = 8;
            this.cmbTrackingStatus.ValidationRules = null;
            // 
            // lkpDestination
            // 
            this.lkpDestination.AutoCompleteDataManager = null;
            this.lkpDestination.AutoCompleteDisplayFormater = null;
            this.lkpDestination.AutoCompleteInitialized = false;
            this.lkpDestination.AutocompleteMinimumTextLength = 0;
            this.lkpDestination.AutoCompleteText = null;
            this.lkpDestination.AutoCompleteWhereExpression = null;
            this.lkpDestination.AutoCompleteWheretermFormater = null;
            this.lkpDestination.ClearOnLeave = true;
            this.lkpDestination.DisplayString = null;
            this.lkpDestination.FieldLabel = null;
            this.lkpDestination.Location = new System.Drawing.Point(97, 69);
            this.lkpDestination.LookupPopup = null;
            this.lkpDestination.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkpDestination.Name = "lkpDestination";
            this.lkpDestination.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpDestination.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpDestination.Properties.Appearance.Options.UseFont = true;
            this.lkpDestination.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpDestination.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpDestination.Properties.AutoCompleteDataManager = null;
            this.lkpDestination.Properties.AutoCompleteDisplayFormater = null;
            this.lkpDestination.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpDestination.Properties.AutoCompleteText = null;
            this.lkpDestination.Properties.AutoCompleteWhereExpression = null;
            this.lkpDestination.Properties.AutoCompleteWheretermFormater = null;
            this.lkpDestination.Properties.AutoHeight = false;
            this.lkpDestination.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpDestination.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpDestination.Properties.LookupPopup = null;
            this.lkpDestination.Properties.NullText = "<<Choose...>>";
            this.lkpDestination.Size = new System.Drawing.Size(148, 24);
            this.lkpDestination.TabIndex = 4;
            this.lkpDestination.ValidationRules = null;
            this.lkpDestination.Value = null;
            // 
            // lkpServiceType
            // 
            this.lkpServiceType.AutoCompleteDataManager = null;
            this.lkpServiceType.AutoCompleteDisplayFormater = null;
            this.lkpServiceType.AutoCompleteInitialized = false;
            this.lkpServiceType.AutocompleteMinimumTextLength = 0;
            this.lkpServiceType.AutoCompleteText = null;
            this.lkpServiceType.AutoCompleteWhereExpression = null;
            this.lkpServiceType.AutoCompleteWheretermFormater = null;
            this.lkpServiceType.ClearOnLeave = true;
            this.lkpServiceType.DisplayString = null;
            this.lkpServiceType.EditValue = "";
            this.lkpServiceType.FieldLabel = null;
            this.lkpServiceType.Location = new System.Drawing.Point(97, 122);
            this.lkpServiceType.LookupPopup = null;
            this.lkpServiceType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkpServiceType.Name = "lkpServiceType";
            this.lkpServiceType.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpServiceType.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpServiceType.Properties.Appearance.Options.UseFont = true;
            this.lkpServiceType.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpServiceType.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpServiceType.Properties.AutoCompleteDataManager = null;
            this.lkpServiceType.Properties.AutoCompleteDisplayFormater = null;
            this.lkpServiceType.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpServiceType.Properties.AutoCompleteText = null;
            this.lkpServiceType.Properties.AutoCompleteWhereExpression = null;
            this.lkpServiceType.Properties.AutoCompleteWheretermFormater = null;
            this.lkpServiceType.Properties.AutoHeight = false;
            this.lkpServiceType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpServiceType.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.lkpServiceType.Properties.LookupPopup = null;
            this.lkpServiceType.Properties.NullText = "<<Choose...>>";
            this.lkpServiceType.Size = new System.Drawing.Size(148, 24);
            this.lkpServiceType.TabIndex = 7;
            this.lkpServiceType.ValidationRules = null;
            this.lkpServiceType.Value = null;
            // 
            // lkpDestinationBranch
            // 
            this.lkpDestinationBranch.AutoCompleteDataManager = null;
            this.lkpDestinationBranch.AutoCompleteDisplayFormater = null;
            this.lkpDestinationBranch.AutoCompleteInitialized = false;
            this.lkpDestinationBranch.AutocompleteMinimumTextLength = 0;
            this.lkpDestinationBranch.AutoCompleteText = null;
            this.lkpDestinationBranch.AutoCompleteWhereExpression = null;
            this.lkpDestinationBranch.AutoCompleteWheretermFormater = null;
            this.lkpDestinationBranch.ClearOnLeave = true;
            this.lkpDestinationBranch.DisplayString = null;
            this.lkpDestinationBranch.FieldLabel = null;
            this.lkpDestinationBranch.Location = new System.Drawing.Point(343, 69);
            this.lkpDestinationBranch.LookupPopup = null;
            this.lkpDestinationBranch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkpDestinationBranch.Name = "lkpDestinationBranch";
            this.lkpDestinationBranch.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpDestinationBranch.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpDestinationBranch.Properties.Appearance.Options.UseFont = true;
            this.lkpDestinationBranch.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpDestinationBranch.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpDestinationBranch.Properties.AutoCompleteDataManager = null;
            this.lkpDestinationBranch.Properties.AutoCompleteDisplayFormater = null;
            this.lkpDestinationBranch.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpDestinationBranch.Properties.AutoCompleteText = null;
            this.lkpDestinationBranch.Properties.AutoCompleteWhereExpression = null;
            this.lkpDestinationBranch.Properties.AutoCompleteWheretermFormater = null;
            this.lkpDestinationBranch.Properties.AutoHeight = false;
            this.lkpDestinationBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpDestinationBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.lkpDestinationBranch.Properties.LookupPopup = null;
            this.lkpDestinationBranch.Properties.NullText = "<<Choose...>>";
            this.lkpDestinationBranch.Size = new System.Drawing.Size(170, 24);
            this.lkpDestinationBranch.TabIndex = 5;
            this.lkpDestinationBranch.ValidationRules = null;
            this.lkpDestinationBranch.Value = null;
            // 
            // lkpCustomer
            // 
            this.lkpCustomer.AutoCompleteDataManager = null;
            this.lkpCustomer.AutoCompleteDisplayFormater = null;
            this.lkpCustomer.AutoCompleteInitialized = false;
            this.lkpCustomer.AutocompleteMinimumTextLength = 0;
            this.lkpCustomer.AutoCompleteText = null;
            this.lkpCustomer.AutoCompleteWhereExpression = null;
            this.lkpCustomer.AutoCompleteWheretermFormater = null;
            this.lkpCustomer.ClearOnLeave = true;
            this.lkpCustomer.DisplayString = null;
            this.lkpCustomer.FieldLabel = null;
            this.lkpCustomer.Location = new System.Drawing.Point(97, 44);
            this.lkpCustomer.LookupPopup = null;
            this.lkpCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkpCustomer.Name = "lkpCustomer";
            this.lkpCustomer.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpCustomer.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpCustomer.Properties.Appearance.Options.UseFont = true;
            this.lkpCustomer.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpCustomer.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpCustomer.Properties.AutoCompleteDataManager = null;
            this.lkpCustomer.Properties.AutoCompleteDisplayFormater = null;
            this.lkpCustomer.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpCustomer.Properties.AutoCompleteText = null;
            this.lkpCustomer.Properties.AutoCompleteWhereExpression = null;
            this.lkpCustomer.Properties.AutoCompleteWheretermFormater = null;
            this.lkpCustomer.Properties.AutoHeight = false;
            this.lkpCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpCustomer.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.lkpCustomer.Properties.LookupPopup = null;
            this.lkpCustomer.Properties.NullText = "<<Choose...>>";
            this.lkpCustomer.Size = new System.Drawing.Size(292, 24);
            this.lkpCustomer.TabIndex = 3;
            this.lkpCustomer.ValidationRules = null;
            this.lkpCustomer.Value = null;
            // 
            // txtDateTo
            // 
            this.txtDateTo.EditValue = null;
            this.txtDateTo.FieldLabel = null;
            this.txtDateTo.FormatDateTime = "dd-MM-yyyy";
            this.txtDateTo.Location = new System.Drawing.Point(279, 18);
            this.txtDateTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Nullable = false;
            this.txtDateTo.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDateTo.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.txtDateTo.Properties.Appearance.Options.UseFont = true;
            this.txtDateTo.Properties.AutoHeight = false;
            this.txtDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtDateTo.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "", null, null, true)});
            this.txtDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateTo.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDateTo.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDateTo.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtDateTo.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDateTo.Size = new System.Drawing.Size(110, 24);
            this.txtDateTo.TabIndex = 2;
            this.txtDateTo.ValidationRules = null;
            this.txtDateTo.Value = new System.DateTime(((long)(0)));
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.EditValue = null;
            this.txtDateFrom.FieldLabel = null;
            this.txtDateFrom.FormatDateTime = "dd-MM-yyyy";
            this.txtDateFrom.Location = new System.Drawing.Point(137, 18);
            this.txtDateFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.Nullable = false;
            this.txtDateFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDateFrom.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.txtDateFrom.Properties.Appearance.Options.UseFont = true;
            this.txtDateFrom.Properties.AutoHeight = false;
            this.txtDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtDateFrom.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "", null, null, true)});
            this.txtDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateFrom.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDateFrom.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDateFrom.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtDateFrom.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDateFrom.Size = new System.Drawing.Size(108, 24);
            this.txtDateFrom.TabIndex = 1;
            this.txtDateFrom.ValidationRules = null;
            this.txtDateFrom.Value = new System.DateTime(((long)(0)));
            // 
            // btnSearch
            // 
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(97, 148);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(112, 28);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 127;
            this.label1.Text = "Customer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(94, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 17);
            this.label6.TabIndex = 127;
            this.label6.Text = "From";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(252, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 17);
            this.label5.TabIndex = 127;
            this.label5.Text = "To";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(15, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 17);
            this.label14.TabIndex = 127;
            this.label14.Text = "Date";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(252, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 17);
            this.label8.TabIndex = 106;
            this.label8.Text = "Status";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 17);
            this.label7.TabIndex = 106;
            this.label7.Text = "Service Type";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 106;
            this.label2.Text = "Dest. City";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label91
            // 
            this.label91.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label91.Location = new System.Drawing.Point(252, 72);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(85, 17);
            this.label91.TabIndex = 106;
            this.label91.Text = "Dest. Branch";
            this.label91.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 17);
            this.label4.TabIndex = 134;
            this.label4.Text = "Pcs:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(205, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 17);
            this.label3.TabIndex = 134;
            this.label3.Text = "CW:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtTotalChargeableWeight);
            this.groupBox2.Controls.Add(this.txtTotalPieces);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(5, 459);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(657, 47);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total";
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
            this.txtTotalChargeableWeight.Location = new System.Drawing.Point(245, 18);
            this.txtTotalChargeableWeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.txtTotalChargeableWeight.Size = new System.Drawing.Size(113, 24);
            this.txtTotalChargeableWeight.TabIndex = 135;
            this.txtTotalChargeableWeight.TextAlign = null;
            this.txtTotalChargeableWeight.ValidationRules = null;
            this.txtTotalChargeableWeight.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
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
            this.txtTotalPieces.Location = new System.Drawing.Point(58, 18);
            this.txtTotalPieces.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.txtTotalPieces.Size = new System.Drawing.Size(113, 24);
            this.txtTotalPieces.TabIndex = 135;
            this.txtTotalPieces.TextAlign = null;
            this.txtTotalPieces.ValidationRules = null;
            this.txtTotalPieces.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btnSaveToExcel
            // 
            this.btnSaveToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveToExcel.Location = new System.Drawing.Point(856, 472);
            this.btnSaveToExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveToExcel.Name = "btnSaveToExcel";
            this.btnSaveToExcel.Size = new System.Drawing.Size(108, 33);
            this.btnSaveToExcel.TabIndex = 137;
            this.btnSaveToExcel.Text = "Save To Excel";
            this.btnSaveToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveToExcel.UseVisualStyleBackColor = true;
            // 
            // btnSaveToCsv
            // 
            this.btnSaveToCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveToCsv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveToCsv.Location = new System.Drawing.Point(739, 472);
            this.btnSaveToCsv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveToCsv.Name = "btnSaveToCsv";
            this.btnSaveToCsv.Size = new System.Drawing.Size(111, 33);
            this.btnSaveToCsv.TabIndex = 137;
            this.btnSaveToCsv.Text = "Save To CSV";
            this.btnSaveToCsv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveToCsv.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(541, 125);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(423, 58);
            this.groupBox3.TabIndex = 138;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Legend";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(20, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(196, 17);
            this.label10.TabIndex = 142;
            this.label10.Text = "Warna Merah : Loss atau Returned";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(261, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 17);
            this.label9.TabIndex = 141;
            this.label9.Text = "Warna Biru : Received";
            // 
            // ShipmentDeliveryListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(969, 510);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSaveToCsv);
            this.Controls.Add(this.btnSaveToExcel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grid);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ShipmentDeliveryListForm";
            this.Text = "Shipment Delivery List";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFranchise.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestination.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpServiceType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestinationBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalChargeableWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPieces.Properties)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn99;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaveToExcel;
        private System.Windows.Forms.Button btnSaveToCsv;
        private Common.Component.dLookup lkpDestination;
        private Common.Component.dLookup lkpDestinationBranch;
        private Common.Component.dLookup lkpCustomer;
        private Common.Component.dCalendar txtDateTo;
        private Common.Component.dCalendar txtDateFrom;
        private Common.Component.dTextBoxNumber txtTotalChargeableWeight;
        private Common.Component.dTextBoxNumber txtTotalPieces;
        private Common.Component.dLookup lkpServiceType;
        private System.Windows.Forms.Label label7;
        private Common.Component.dComboBox cmbTrackingStatus;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private GroupBox groupBox3;
        private Label label10;
        private Label label9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private Label label11;
        private Common.Component.dLookup lkpFranchise;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;


    }
}

