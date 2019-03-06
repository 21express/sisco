using System.Windows.Forms;

namespace SISCO.Presentation.CustomerService.Forms
{
    partial class UnReceivedListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnReceivedListForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn99 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lkpOriginBranch = new SISCO.Presentation.Common.Component.dLookup();
            this.label1 = new System.Windows.Forms.Label();
            this.lkpOrigin = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpDestination = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpServiceType = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpDestinationBranch = new SISCO.Presentation.Common.Component.dLookup();
            this.btnSearch = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpOriginBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpOrigin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestination.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpServiceType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestinationBranch.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalChargeableWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPieces.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grid.Location = new System.Drawing.Point(6, 143);
            this.grid.MainView = this.gridView;
            this.grid.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(948, 355);
            this.grid.TabIndex = 52;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn15,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn14,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn17,
            this.gridColumn16,
            this.gridColumn6,
            this.gridColumn99,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn3,
            this.gridColumn13,
            this.gridColumn11,
            this.gridColumn12});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Status";
            this.gridColumn15.FieldName = "TrackingStatus";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.OptionsColumn.AllowMove = false;
            this.gridColumn15.OptionsColumn.ReadOnly = true;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 0;
            this.gridColumn15.Width = 85;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Shipment No.";
            this.gridColumn1.FieldName = "Code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 85;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Date";
            this.gridColumn2.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "DateProcess";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 68;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Shipper";
            this.gridColumn14.FieldName = "ShipperName";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.OptionsColumn.AllowMove = false;
            this.gridColumn14.OptionsColumn.ReadOnly = true;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Consignee";
            this.gridColumn4.FieldName = "ConsigneeName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 82;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Package Type";
            this.gridColumn5.FieldName = "PackageType";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.AllowMove = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 60;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Origin";
            this.gridColumn17.FieldName = "CityName";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.OptionsColumn.AllowMove = false;
            this.gridColumn17.OptionsColumn.ReadOnly = true;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 6;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Origin Branch";
            this.gridColumn16.FieldName = "BranchName";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.OptionsColumn.AllowMove = false;
            this.gridColumn16.OptionsColumn.ReadOnly = true;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 7;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Destination";
            this.gridColumn6.FieldName = "DestCity";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.AllowMove = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            this.gridColumn6.Width = 86;
            // 
            // gridColumn99
            // 
            this.gridColumn99.Caption = "Dest. Branch";
            this.gridColumn99.FieldName = "DestBranch";
            this.gridColumn99.Name = "gridColumn99";
            this.gridColumn99.OptionsColumn.AllowEdit = false;
            this.gridColumn99.OptionsColumn.AllowFocus = false;
            this.gridColumn99.OptionsColumn.AllowMove = false;
            this.gridColumn99.OptionsColumn.ReadOnly = true;
            this.gridColumn99.Visible = true;
            this.gridColumn99.VisibleIndex = 9;
            this.gridColumn99.Width = 72;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Service Type";
            this.gridColumn7.FieldName = "ServiceType";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.AllowMove = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 10;
            this.gridColumn7.Width = 57;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Piece";
            this.gridColumn8.FieldName = "TtlPiece";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.OptionsColumn.AllowMove = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 11;
            this.gridColumn8.Width = 35;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "CW";
            this.gridColumn9.FieldName = "TtlChargeableWeight";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.OptionsColumn.AllowMove = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 12;
            this.gridColumn9.Width = 45;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Status Date";
            this.gridColumn10.FieldName = "StatusDateStr";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.OptionsColumn.AllowMove = false;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 13;
            this.gridColumn10.Width = 74;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Status Time";
            this.gridColumn3.FieldName = "StatusTime";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 14;
            this.gridColumn3.Width = 45;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Lead Time";
            this.gridColumn13.FieldName = "LeadTime";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.OptionsColumn.AllowMove = false;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 15;
            this.gridColumn13.Width = 62;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "gridColumn11";
            this.gridColumn11.FieldName = "BranchId";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "gridColumn12";
            this.gridColumn12.FieldName = "DestBranchId";
            this.gridColumn12.Name = "gridColumn12";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lkpOriginBranch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lkpOrigin);
            this.groupBox1.Controls.Add(this.lkpDestination);
            this.groupBox1.Controls.Add(this.lkpServiceType);
            this.groupBox1.Controls.Add(this.lkpDestinationBranch);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label91);
            this.groupBox1.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(6, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox1.Size = new System.Drawing.Size(948, 130);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 196;
            this.label5.Text = "Origin Branch";
            // 
            // lkpOriginBranch
            // 
            this.lkpOriginBranch.AutoCompleteDataManager = null;
            this.lkpOriginBranch.AutoCompleteDisplayFormater = null;
            this.lkpOriginBranch.AutoCompleteInitialized = false;
            this.lkpOriginBranch.AutocompleteMinimumTextLength = 0;
            this.lkpOriginBranch.AutoCompleteText = null;
            this.lkpOriginBranch.AutoCompleteWhereExpression = null;
            this.lkpOriginBranch.AutoCompleteWheretermFormater = null;
            this.lkpOriginBranch.ClearOnLeave = true;
            this.lkpOriginBranch.DisplayString = null;
            this.lkpOriginBranch.FieldLabel = null;
            this.lkpOriginBranch.Location = new System.Drawing.Point(129, 40);
            this.lkpOriginBranch.LookupPopup = null;
            this.lkpOriginBranch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lkpOriginBranch.Name = "lkpOriginBranch";
            this.lkpOriginBranch.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpOriginBranch.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpOriginBranch.Properties.Appearance.Options.UseFont = true;
            this.lkpOriginBranch.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpOriginBranch.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpOriginBranch.Properties.AutoCompleteDataManager = null;
            this.lkpOriginBranch.Properties.AutoCompleteDisplayFormater = null;
            this.lkpOriginBranch.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpOriginBranch.Properties.AutoCompleteText = null;
            this.lkpOriginBranch.Properties.AutoCompleteWhereExpression = null;
            this.lkpOriginBranch.Properties.AutoCompleteWheretermFormater = null;
            this.lkpOriginBranch.Properties.AutoHeight = false;
            this.lkpOriginBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("dLookup1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpOriginBranch.Properties.LookupPopup = null;
            this.lkpOriginBranch.Properties.NullText = "<<Choose...>>";
            this.lkpOriginBranch.Size = new System.Drawing.Size(283, 24);
            this.lkpOriginBranch.TabIndex = 2;
            this.lkpOriginBranch.ValidationRules = null;
            this.lkpOriginBranch.Value = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 194;
            this.label1.Text = "Origin";
            // 
            // lkpOrigin
            // 
            this.lkpOrigin.AutoCompleteDataManager = null;
            this.lkpOrigin.AutoCompleteDisplayFormater = null;
            this.lkpOrigin.AutoCompleteInitialized = false;
            this.lkpOrigin.AutocompleteMinimumTextLength = 0;
            this.lkpOrigin.AutoCompleteText = null;
            this.lkpOrigin.AutoCompleteWhereExpression = null;
            this.lkpOrigin.AutoCompleteWheretermFormater = null;
            this.lkpOrigin.ClearOnLeave = true;
            this.lkpOrigin.DisplayString = null;
            this.lkpOrigin.FieldLabel = null;
            this.lkpOrigin.Location = new System.Drawing.Point(129, 14);
            this.lkpOrigin.LookupPopup = null;
            this.lkpOrigin.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lkpOrigin.Name = "lkpOrigin";
            this.lkpOrigin.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpOrigin.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpOrigin.Properties.Appearance.Options.UseFont = true;
            this.lkpOrigin.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpOrigin.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpOrigin.Properties.AutoCompleteDataManager = null;
            this.lkpOrigin.Properties.AutoCompleteDisplayFormater = null;
            this.lkpOrigin.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpOrigin.Properties.AutoCompleteText = null;
            this.lkpOrigin.Properties.AutoCompleteWhereExpression = null;
            this.lkpOrigin.Properties.AutoCompleteWheretermFormater = null;
            this.lkpOrigin.Properties.AutoHeight = false;
            this.lkpOrigin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("lkpOrigin.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpOrigin.Properties.LookupPopup = null;
            this.lkpOrigin.Properties.NullText = "<<Choose...>>";
            this.lkpOrigin.Size = new System.Drawing.Size(283, 24);
            this.lkpOrigin.TabIndex = 1;
            this.lkpOrigin.ValidationRules = null;
            this.lkpOrigin.Value = null;
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
            this.lkpDestination.Location = new System.Drawing.Point(520, 14);
            this.lkpDestination.LookupPopup = null;
            this.lkpDestination.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("lkpDestination.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.lkpDestination.Properties.LookupPopup = null;
            this.lkpDestination.Properties.NullText = "<<Choose...>>";
            this.lkpDestination.Size = new System.Drawing.Size(283, 24);
            this.lkpDestination.TabIndex = 3;
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
            this.lkpServiceType.Location = new System.Drawing.Point(129, 66);
            this.lkpServiceType.LookupPopup = null;
            this.lkpServiceType.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("lkpServiceType.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.lkpServiceType.Properties.LookupPopup = null;
            this.lkpServiceType.Properties.NullText = "<<Choose...>>";
            this.lkpServiceType.Size = new System.Drawing.Size(246, 24);
            this.lkpServiceType.TabIndex = 5;
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
            this.lkpDestinationBranch.Location = new System.Drawing.Point(520, 40);
            this.lkpDestinationBranch.LookupPopup = null;
            this.lkpDestinationBranch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("lkpDestinationBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.lkpDestinationBranch.Properties.LookupPopup = null;
            this.lkpDestinationBranch.Properties.NullText = "<<Choose...>>";
            this.lkpDestinationBranch.Size = new System.Drawing.Size(283, 24);
            this.lkpDestinationBranch.TabIndex = 4;
            this.lkpDestinationBranch.ValidationRules = null;
            this.lkpDestinationBranch.Value = null;
            // 
            // btnSearch
            // 
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(129, 94);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(103, 29);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(47, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 17);
            this.label7.TabIndex = 106;
            this.label7.Text = "Service Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(446, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 106;
            this.label2.Text = "Destination";
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label91.Location = new System.Drawing.Point(437, 43);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(77, 17);
            this.label91.TabIndex = 106;
            this.label91.Text = "Dest. Branch";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 17);
            this.label4.TabIndex = 134;
            this.label4.Text = "Pcs:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(262, 22);
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
            this.groupBox2.Location = new System.Drawing.Point(6, 506);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox2.Size = new System.Drawing.Size(678, 51);
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
            this.txtTotalChargeableWeight.Location = new System.Drawing.Point(300, 19);
            this.txtTotalChargeableWeight.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
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
            this.txtTotalChargeableWeight.Size = new System.Drawing.Size(160, 24);
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
            this.txtTotalPieces.Location = new System.Drawing.Point(68, 19);
            this.txtTotalPieces.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
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
            this.txtTotalPieces.Size = new System.Drawing.Size(164, 24);
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
            this.btnSaveToExcel.Location = new System.Drawing.Point(840, 515);
            this.btnSaveToExcel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSaveToExcel.Name = "btnSaveToExcel";
            this.btnSaveToExcel.Size = new System.Drawing.Size(114, 36);
            this.btnSaveToExcel.TabIndex = 137;
            this.btnSaveToExcel.Text = "Save To Excel";
            this.btnSaveToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveToExcel.UseVisualStyleBackColor = true;
            // 
            // btnSaveToCsv
            // 
            this.btnSaveToCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveToCsv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveToCsv.Location = new System.Drawing.Point(720, 515);
            this.btnSaveToCsv.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSaveToCsv.Name = "btnSaveToCsv";
            this.btnSaveToCsv.Size = new System.Drawing.Size(114, 36);
            this.btnSaveToCsv.TabIndex = 137;
            this.btnSaveToCsv.Text = "Save To CSV";
            this.btnSaveToCsv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveToCsv.UseVisualStyleBackColor = true;
            // 
            // UnReceivedListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 562);
            this.Controls.Add(this.btnSaveToCsv);
            this.Controls.Add(this.btnSaveToExcel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grid);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UnReceivedListForm";
            this.Text = "Undelivered List";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpOriginBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpOrigin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestination.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpServiceType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestinationBranch.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalChargeableWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPieces.Properties)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn99;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaveToExcel;
        private System.Windows.Forms.Button btnSaveToCsv;
        private Common.Component.dLookup lkpDestination;
        private Common.Component.dLookup lkpDestinationBranch;
        private Common.Component.dTextBoxNumber txtTotalChargeableWeight;
        private Common.Component.dTextBoxNumber txtTotalPieces;
        private Common.Component.dLookup lkpServiceType;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private Label label1;
        private Common.Component.dLookup lkpOrigin;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private Label label5;
        private Common.Component.dLookup lkpOriginBranch;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;


    }
}

