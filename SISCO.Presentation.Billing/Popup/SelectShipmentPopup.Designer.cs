namespace SISCO.Presentation.Billing.Popup
{
    partial class SelectShipmentPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectShipmentPopup));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnGetData = new System.Windows.Forms.Button();
            this.lkpPaymentMethod = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.lkpPackageType = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.lkpDestinationCity = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.txtDateTo = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.txtDateFrom = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.txtPeriod = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtTotalRecords = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lkpCustomer = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPaymentMethod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPackageType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestinationCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalRecords.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.Location = new System.Drawing.Point(783, 72);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(75, 26);
            this.btnDeselectAll.TabIndex = 24;
            this.btnDeselectAll.Text = "Deselect All";
            this.btnDeselectAll.UseVisualStyleBackColor = true;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(783, 45);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 26);
            this.btnSelectAll.TabIndex = 23;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.Location = new System.Drawing.Point(705, 57);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 30);
            this.btnGetData.TabIndex = 8;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // lkpPaymentMethod
            // 
            this.lkpPaymentMethod.AutoCompleteDataManager = null;
            this.lkpPaymentMethod.AutoCompleteDisplayFormater = null;
            this.lkpPaymentMethod.AutoCompleteInitialized = false;
            this.lkpPaymentMethod.AutocompleteMinimumTextLength = 0;
            this.lkpPaymentMethod.AutoCompleteText = null;
            this.lkpPaymentMethod.AutoCompleteWhereExpression = null;
            this.lkpPaymentMethod.AutoCompleteWheretermFormater = null;
            this.lkpPaymentMethod.ClearOnLeave = true;
            this.lkpPaymentMethod.DisplayString = null;
            this.lkpPaymentMethod.FieldLabel = null;
            this.lkpPaymentMethod.Location = new System.Drawing.Point(505, 86);
            this.lkpPaymentMethod.LookupPopup = null;
            this.lkpPaymentMethod.Name = "lkpPaymentMethod";
            this.lkpPaymentMethod.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpPaymentMethod.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpPaymentMethod.Properties.Appearance.Options.UseFont = true;
            this.lkpPaymentMethod.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpPaymentMethod.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpPaymentMethod.Properties.AutoCompleteDataManager = null;
            this.lkpPaymentMethod.Properties.AutoCompleteDisplayFormater = null;
            this.lkpPaymentMethod.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpPaymentMethod.Properties.AutoCompleteText = null;
            this.lkpPaymentMethod.Properties.AutoCompleteWhereExpression = null;
            this.lkpPaymentMethod.Properties.AutoCompleteWheretermFormater = null;
            this.lkpPaymentMethod.Properties.AutoHeight = false;
            this.lkpPaymentMethod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpPaymentMethod.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpPaymentMethod.Properties.LookupPopup = null;
            this.lkpPaymentMethod.Properties.NullText = "<<Choose...>>";
            this.lkpPaymentMethod.Size = new System.Drawing.Size(194, 24);
            this.lkpPaymentMethod.TabIndex = 7;
            this.lkpPaymentMethod.ValidationRules = null;
            this.lkpPaymentMethod.Value = null;
            // 
            // lkpPackageType
            // 
            this.lkpPackageType.AutoCompleteDataManager = null;
            this.lkpPackageType.AutoCompleteDisplayFormater = null;
            this.lkpPackageType.AutoCompleteInitialized = false;
            this.lkpPackageType.AutocompleteMinimumTextLength = 0;
            this.lkpPackageType.AutoCompleteText = null;
            this.lkpPackageType.AutoCompleteWhereExpression = null;
            this.lkpPackageType.AutoCompleteWheretermFormater = null;
            this.lkpPackageType.ClearOnLeave = true;
            this.lkpPackageType.DisplayString = null;
            this.lkpPackageType.FieldLabel = null;
            this.lkpPackageType.Location = new System.Drawing.Point(505, 61);
            this.lkpPackageType.LookupPopup = null;
            this.lkpPackageType.Name = "lkpPackageType";
            this.lkpPackageType.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpPackageType.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpPackageType.Properties.Appearance.Options.UseFont = true;
            this.lkpPackageType.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpPackageType.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpPackageType.Properties.AutoCompleteDataManager = null;
            this.lkpPackageType.Properties.AutoCompleteDisplayFormater = null;
            this.lkpPackageType.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpPackageType.Properties.AutoCompleteText = null;
            this.lkpPackageType.Properties.AutoCompleteWhereExpression = null;
            this.lkpPackageType.Properties.AutoCompleteWheretermFormater = null;
            this.lkpPackageType.Properties.AutoHeight = false;
            this.lkpPackageType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpPackageType.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpPackageType.Properties.LookupPopup = null;
            this.lkpPackageType.Properties.NullText = "<<Choose...>>";
            this.lkpPackageType.Size = new System.Drawing.Size(194, 24);
            this.lkpPackageType.TabIndex = 6;
            this.lkpPackageType.ValidationRules = null;
            this.lkpPackageType.Value = null;
            // 
            // lkpDestinationCity
            // 
            this.lkpDestinationCity.AutoCompleteDataManager = null;
            this.lkpDestinationCity.AutoCompleteDisplayFormater = null;
            this.lkpDestinationCity.AutoCompleteInitialized = false;
            this.lkpDestinationCity.AutocompleteMinimumTextLength = 0;
            this.lkpDestinationCity.AutoCompleteText = null;
            this.lkpDestinationCity.AutoCompleteWhereExpression = null;
            this.lkpDestinationCity.AutoCompleteWheretermFormater = null;
            this.lkpDestinationCity.ClearOnLeave = true;
            this.lkpDestinationCity.DisplayString = null;
            this.lkpDestinationCity.FieldLabel = null;
            this.lkpDestinationCity.Location = new System.Drawing.Point(505, 36);
            this.lkpDestinationCity.LookupPopup = null;
            this.lkpDestinationCity.Name = "lkpDestinationCity";
            this.lkpDestinationCity.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpDestinationCity.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpDestinationCity.Properties.Appearance.Options.UseFont = true;
            this.lkpDestinationCity.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpDestinationCity.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpDestinationCity.Properties.AutoCompleteDataManager = null;
            this.lkpDestinationCity.Properties.AutoCompleteDisplayFormater = null;
            this.lkpDestinationCity.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpDestinationCity.Properties.AutoCompleteText = null;
            this.lkpDestinationCity.Properties.AutoCompleteWhereExpression = null;
            this.lkpDestinationCity.Properties.AutoCompleteWheretermFormater = null;
            this.lkpDestinationCity.Properties.AutoHeight = false;
            this.lkpDestinationCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpDestinationCity.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.lkpDestinationCity.Properties.LookupPopup = null;
            this.lkpDestinationCity.Properties.NullText = "<<Choose...>>";
            this.lkpDestinationCity.Size = new System.Drawing.Size(194, 24);
            this.lkpDestinationCity.TabIndex = 5;
            this.lkpDestinationCity.ValidationRules = null;
            this.lkpDestinationCity.Value = null;
            // 
            // txtDateTo
            // 
            this.txtDateTo.EditValue = null;
            this.txtDateTo.FieldLabel = null;
            this.txtDateTo.FormatDateTime = "dd-MM-yyyy";
            this.txtDateTo.Location = new System.Drawing.Point(255, 86);
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Nullable = false;
            this.txtDateTo.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDateTo.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.txtDateTo.Properties.Appearance.Options.UseFont = true;
            this.txtDateTo.Properties.AutoHeight = false;
            this.txtDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtDateTo.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.txtDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateTo.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDateTo.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDateTo.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtDateTo.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDateTo.Size = new System.Drawing.Size(131, 24);
            this.txtDateTo.TabIndex = 4;
            this.txtDateTo.ValidationRules = null;
            this.txtDateTo.Value = new System.DateTime(((long)(0)));
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.EditValue = null;
            this.txtDateFrom.FieldLabel = null;
            this.txtDateFrom.FormatDateTime = "dd-MM-yyyy";
            this.txtDateFrom.Location = new System.Drawing.Point(255, 61);
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.Nullable = false;
            this.txtDateFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDateFrom.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.txtDateFrom.Properties.Appearance.Options.UseFont = true;
            this.txtDateFrom.Properties.AutoHeight = false;
            this.txtDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtDateFrom.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.txtDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateFrom.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDateFrom.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDateFrom.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtDateFrom.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDateFrom.Size = new System.Drawing.Size(131, 24);
            this.txtDateFrom.TabIndex = 3;
            this.txtDateFrom.ValidationRules = null;
            this.txtDateFrom.Value = new System.DateTime(((long)(0)));
            // 
            // txtPeriod
            // 
            this.txtPeriod.Capslock = true;
            this.txtPeriod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPeriod.FieldLabel = null;
            this.txtPeriod.Location = new System.Drawing.Point(255, 36);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtPeriod.Size = new System.Drawing.Size(131, 24);
            this.txtPeriod.TabIndex = 2;
            this.txtPeriod.ValidationRules = null;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(394, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Payment Method";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(173, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Date To";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(394, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Destination";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(394, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Package Type";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(173, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Periode";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(173, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Date From";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Meiryo", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "Select Shipment";
            // 
            // grid
            // 
            this.grid.Location = new System.Drawing.Point(2, 117);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(861, 282);
            this.grid.TabIndex = 26;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridColumn13,
            this.gridColumn14});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Shipment No.";
            this.gridColumn1.FieldName = "Code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Date";
            this.gridColumn2.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "DateProcess";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 70;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Dest City";
            this.gridColumn3.FieldName = "DestCity";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 81;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Pcs";
            this.gridColumn4.DisplayFormat.FormatString = "#";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn4.FieldName = "TtlPiece";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 35;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "CW";
            this.gridColumn5.DisplayFormat.FormatString = "#.0";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn5.FieldName = "TtlChargeableWeight";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 38;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Tariff";
            this.gridColumn6.DisplayFormat.FormatString = "#,#0";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn6.FieldName = "Tariff";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 58;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Handling";
            this.gridColumn7.DisplayFormat.FormatString = "#,#0";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn7.FieldName = "HandlingFeeTotal";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 52;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Tariff Total";
            this.gridColumn8.DisplayFormat.FormatString = "#,#0";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn8.FieldName = "TariffTotal";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            this.gridColumn8.Width = 67;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Discount";
            this.gridColumn9.DisplayFormat.FormatString = "#,#0";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn9.FieldName = "DiscountTotal";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 9;
            this.gridColumn9.Width = 45;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Net";
            this.gridColumn10.DisplayFormat.FormatString = "#,#0";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn10.FieldName = "TariffNet";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 10;
            this.gridColumn10.Width = 74;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Packing";
            this.gridColumn11.DisplayFormat.FormatString = "#,#0";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn11.FieldName = "Packing Fee";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 11;
            this.gridColumn11.Width = 45;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Other";
            this.gridColumn12.DisplayFormat.FormatString = "#,#0";
            this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn12.FieldName = "Other Fee";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 12;
            this.gridColumn12.Width = 38;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Insurance";
            this.gridColumn13.DisplayFormat.FormatString = "#,#0";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn13.FieldName = "InsuranceFee";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 13;
            this.gridColumn13.Width = 50;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Total";
            this.gridColumn14.DisplayFormat.FormatString = "#,#0";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn14.FieldName = "Total";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 14;
            this.gridColumn14.Width = 132;
            // 
            // txtTotalRecords
            // 
            this.txtTotalRecords.EditMask = "###,###,###,###,###,##0.00";
            this.txtTotalRecords.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalRecords.Enabled = false;
            this.txtTotalRecords.FieldLabel = null;
            this.txtTotalRecords.Location = new System.Drawing.Point(120, 404);
            this.txtTotalRecords.Name = "txtTotalRecords";
            this.txtTotalRecords.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtTotalRecords.Properties.AllowMouseWheel = false;
            this.txtTotalRecords.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.txtTotalRecords.Properties.Appearance.Options.UseFont = true;
            this.txtTotalRecords.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalRecords.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalRecords.Properties.Mask.BeepOnError = true;
            this.txtTotalRecords.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtTotalRecords.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalRecords.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalRecords.ReadOnly = false;
            this.txtTotalRecords.Size = new System.Drawing.Size(104, 24);
            this.txtTotalRecords.TabIndex = 101;
            this.txtTotalRecords.TextAlign = null;
            this.txtTotalRecords.ValidationRules = null;
            this.txtTotalRecords.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(11, 407);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 17);
            this.label8.TabIndex = 100;
            this.label8.Text = "Total Records";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(781, 401);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 32);
            this.btnCancel.TabIndex = 103;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(713, 401);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(68, 32);
            this.btnOk.TabIndex = 102;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
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
            this.lkpCustomer.Location = new System.Drawing.Point(12, 60);
            this.lkpCustomer.LookupPopup = null;
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpCustomer.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "", null, null, true)});
            this.lkpCustomer.Properties.LookupPopup = null;
            this.lkpCustomer.Properties.NullText = "<<Choose...>>";
            this.lkpCustomer.Size = new System.Drawing.Size(155, 24);
            this.lkpCustomer.TabIndex = 1;
            this.lkpCustomer.ValidationRules = null;
            this.lkpCustomer.Value = null;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(12, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 17);
            this.label9.TabIndex = 104;
            this.label9.Text = "Customer";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SelectShipmentPopup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(866, 435);
            this.Controls.Add(this.lkpCustomer);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtTotalRecords);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnDeselectAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.lkpPaymentMethod);
            this.Controls.Add(this.lkpPackageType);
            this.Controls.Add(this.lkpDestinationCity);
            this.Controls.Add(this.txtDateTo);
            this.Controls.Add(this.txtDateFrom);
            this.Controls.Add(this.txtPeriod);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelectShipmentPopup";
            this.Text = "SelectShipmentPopup";
            ((System.ComponentModel.ISupportInitialize)(this.lkpPaymentMethod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPackageType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestinationCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalRecords.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeselectAll;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnGetData;
        private Common.Component.dLookup lkpPaymentMethod;
        private Common.Component.dLookup lkpPackageType;
        private Common.Component.dLookup lkpDestinationCity;
        private Common.Component.dCalendar txtDateTo;
        private Common.Component.dCalendar txtDateFrom;
        private Common.Component.dTextBox txtPeriod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private Common.Component.dTextBoxNumber txtTotalRecords;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private Common.Component.dLookup lkpCustomer;
        private System.Windows.Forms.Label label9;
    }
}