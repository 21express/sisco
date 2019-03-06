using System.Windows.Forms;

namespace SISCO.Presentation.Billing.Forms
{
    partial class ViewShipmentListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewShipmentListForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rdoValidatedAll = new System.Windows.Forms.RadioButton();
            this.rdoValidatedYes = new System.Windows.Forms.RadioButton();
            this.rdoValidatedNo = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.rdoCustomerTypeAll = new System.Windows.Forms.RadioButton();
            this.rdoCustomerTypeCorporate = new System.Windows.Forms.RadioButton();
            this.rdoCustomerTypePersonal = new System.Windows.Forms.RadioButton();
            this.pnlCustomerTypeOptions = new System.Windows.Forms.Panel();
            this.pnlValidatedOptions = new System.Windows.Forms.Panel();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lkpPackageType = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpDestCity = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpCustomer = new SISCO.Presentation.Common.Component.dLookup();
            this.txtDateTo = new SISCO.Presentation.Common.Component.dCalendar();
            this.txtDateFrom = new SISCO.Presentation.Common.Component.dCalendar();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.pnlCustomerTypeOptions.SuspendLayout();
            this.pnlValidatedOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPackageType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(487, 122);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(215, 13);
            this.label12.TabIndex = 56;
            this.label12.Text = "Black -> Validated, Not Yet Invoiced";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Green;
            this.label7.Location = new System.Drawing.Point(487, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = "Green --> Invoiced and Canceled";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(487, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "Blue --> Invoiced";
            // 
            // rdoValidatedAll
            // 
            this.rdoValidatedAll.AutoSize = true;
            this.rdoValidatedAll.Checked = true;
            this.rdoValidatedAll.Location = new System.Drawing.Point(3, 2);
            this.rdoValidatedAll.Name = "rdoValidatedAll";
            this.rdoValidatedAll.Size = new System.Drawing.Size(36, 17);
            this.rdoValidatedAll.TabIndex = 106;
            this.rdoValidatedAll.TabStop = true;
            this.rdoValidatedAll.Text = "All";
            this.rdoValidatedAll.UseVisualStyleBackColor = true;
            // 
            // rdoValidatedYes
            // 
            this.rdoValidatedYes.AutoSize = true;
            this.rdoValidatedYes.Location = new System.Drawing.Point(45, 2);
            this.rdoValidatedYes.Name = "rdoValidatedYes";
            this.rdoValidatedYes.Size = new System.Drawing.Size(43, 17);
            this.rdoValidatedYes.TabIndex = 107;
            this.rdoValidatedYes.TabStop = true;
            this.rdoValidatedYes.Text = "Yes";
            this.rdoValidatedYes.UseVisualStyleBackColor = true;
            // 
            // rdoValidatedNo
            // 
            this.rdoValidatedNo.AutoSize = true;
            this.rdoValidatedNo.Location = new System.Drawing.Point(94, 2);
            this.rdoValidatedNo.Name = "rdoValidatedNo";
            this.rdoValidatedNo.Size = new System.Drawing.Size(39, 17);
            this.rdoValidatedNo.TabIndex = 108;
            this.rdoValidatedNo.TabStop = true;
            this.rdoValidatedNo.Text = "No";
            this.rdoValidatedNo.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(487, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(257, 13);
            this.label11.TabIndex = 55;
            this.label11.Text = "Red --> Not Yet Validated, Not Yet Invoiced";
            // 
            // rdoCustomerTypeAll
            // 
            this.rdoCustomerTypeAll.AutoSize = true;
            this.rdoCustomerTypeAll.Checked = true;
            this.rdoCustomerTypeAll.Location = new System.Drawing.Point(3, 2);
            this.rdoCustomerTypeAll.Name = "rdoCustomerTypeAll";
            this.rdoCustomerTypeAll.Size = new System.Drawing.Size(36, 17);
            this.rdoCustomerTypeAll.TabIndex = 109;
            this.rdoCustomerTypeAll.TabStop = true;
            this.rdoCustomerTypeAll.Text = "All";
            this.rdoCustomerTypeAll.UseVisualStyleBackColor = true;
            // 
            // rdoCustomerTypeCorporate
            // 
            this.rdoCustomerTypeCorporate.AutoSize = true;
            this.rdoCustomerTypeCorporate.Location = new System.Drawing.Point(45, 2);
            this.rdoCustomerTypeCorporate.Name = "rdoCustomerTypeCorporate";
            this.rdoCustomerTypeCorporate.Size = new System.Drawing.Size(71, 17);
            this.rdoCustomerTypeCorporate.TabIndex = 110;
            this.rdoCustomerTypeCorporate.TabStop = true;
            this.rdoCustomerTypeCorporate.Text = "Corporate";
            this.rdoCustomerTypeCorporate.UseVisualStyleBackColor = true;
            // 
            // rdoCustomerTypePersonal
            // 
            this.rdoCustomerTypePersonal.AutoSize = true;
            this.rdoCustomerTypePersonal.Location = new System.Drawing.Point(122, 2);
            this.rdoCustomerTypePersonal.Name = "rdoCustomerTypePersonal";
            this.rdoCustomerTypePersonal.Size = new System.Drawing.Size(66, 17);
            this.rdoCustomerTypePersonal.TabIndex = 111;
            this.rdoCustomerTypePersonal.TabStop = true;
            this.rdoCustomerTypePersonal.Text = "Personal";
            this.rdoCustomerTypePersonal.UseVisualStyleBackColor = true;
            // 
            // pnlCustomerTypeOptions
            // 
            this.pnlCustomerTypeOptions.Controls.Add(this.rdoCustomerTypeAll);
            this.pnlCustomerTypeOptions.Controls.Add(this.rdoCustomerTypeCorporate);
            this.pnlCustomerTypeOptions.Controls.Add(this.rdoCustomerTypePersonal);
            this.pnlCustomerTypeOptions.Location = new System.Drawing.Point(104, 148);
            this.pnlCustomerTypeOptions.Name = "pnlCustomerTypeOptions";
            this.pnlCustomerTypeOptions.Size = new System.Drawing.Size(213, 22);
            this.pnlCustomerTypeOptions.TabIndex = 148;
            // 
            // pnlValidatedOptions
            // 
            this.pnlValidatedOptions.Controls.Add(this.rdoValidatedAll);
            this.pnlValidatedOptions.Controls.Add(this.rdoValidatedYes);
            this.pnlValidatedOptions.Controls.Add(this.rdoValidatedNo);
            this.pnlValidatedOptions.Location = new System.Drawing.Point(104, 126);
            this.pnlValidatedOptions.Name = "pnlValidatedOptions";
            this.pnlValidatedOptions.Size = new System.Drawing.Size(140, 22);
            this.pnlValidatedOptions.TabIndex = 148;
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.Location = new System.Drawing.Point(12, 197);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(759, 314);
            this.grid.TabIndex = 199;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            this.grid.Click += new System.EventHandler(this.grid_Click);
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn13,
            this.gridColumn5,
            this.gridColumn4,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn3,
            this.gridColumn11,
            this.gridColumn6});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsFilter.AllowMRUFilterList = false;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Date";
            this.gridColumn2.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "DateProcess";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 81;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Destination";
            this.gridColumn1.FieldName = "DestCity";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 140;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Shipment Number";
            this.gridColumn13.FieldName = "Code";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 2;
            this.gridColumn13.Width = 98;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Pieces";
            this.gridColumn5.DisplayFormat.FormatString = "{0:#,0}";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "TtlPiece";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TtlPiece", "{0:#,0}")});
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 52;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "GW";
            this.gridColumn4.DisplayFormat.FormatString = "#,0.0";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "TtlGrossWeight";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TtlGrossWeight", "{0:#,0.0}")});
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 60;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "CW";
            this.gridColumn9.DisplayFormat.FormatString = "#,0.0";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "TtlChargeableWeight";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TtlChargeableWeight", "{0:#,0.0}")});
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            this.gridColumn9.Width = 60;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Package Type";
            this.gridColumn10.FieldName = "PackageType";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            this.gridColumn10.Width = 81;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Total";
            this.gridColumn3.DisplayFormat.FormatString = "#,0";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "Total";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:#,0}")});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 7;
            this.gridColumn3.Width = 110;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Payment Receipt No.";
            this.gridColumn11.FieldName = "PaymentReceiptNumber";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 8;
            this.gridColumn11.Width = 136;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Packing";
            this.gridColumn6.DisplayFormat.FormatString = "#,0";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "PackingFee";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lkpPackageType);
            this.groupBox1.Controls.Add(this.lkpDestCity);
            this.groupBox1.Controls.Add(this.lkpCustomer);
            this.groupBox1.Controls.Add(this.txtDateTo);
            this.groupBox1.Controls.Add(this.txtDateFrom);
            this.groupBox1.Controls.Add(this.pnlCustomerTypeOptions);
            this.groupBox1.Controls.Add(this.pnlValidatedOptions);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 184);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
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
            this.lkpPackageType.Location = new System.Drawing.Point(104, 105);
            this.lkpPackageType.LookupPopup = null;
            this.lkpPackageType.Name = "lkpPackageType";
            this.lkpPackageType.OriginalBackColor = System.Drawing.Color.Empty;
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpPackageType.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpPackageType.Properties.LookupPopup = null;
            this.lkpPackageType.Properties.NullText = "<<Choose...>>";
            this.lkpPackageType.Size = new System.Drawing.Size(156, 20);
            this.lkpPackageType.TabIndex = 105;
            this.lkpPackageType.ValidationRules = null;
            this.lkpPackageType.Value = null;
            // 
            // lkpDestCity
            // 
            this.lkpDestCity.AutoCompleteDataManager = null;
            this.lkpDestCity.AutoCompleteDisplayFormater = null;
            this.lkpDestCity.AutoCompleteInitialized = false;
            this.lkpDestCity.AutocompleteMinimumTextLength = 0;
            this.lkpDestCity.AutoCompleteText = null;
            this.lkpDestCity.AutoCompleteWhereExpression = null;
            this.lkpDestCity.AutoCompleteWheretermFormater = null;
            this.lkpDestCity.ClearOnLeave = true;
            this.lkpDestCity.DisplayString = null;
            this.lkpDestCity.FieldLabel = null;
            this.lkpDestCity.Location = new System.Drawing.Point(104, 83);
            this.lkpDestCity.LookupPopup = null;
            this.lkpDestCity.Name = "lkpDestCity";
            this.lkpDestCity.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpDestCity.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpDestCity.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpDestCity.Properties.AutoCompleteDataManager = null;
            this.lkpDestCity.Properties.AutoCompleteDisplayFormater = null;
            this.lkpDestCity.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpDestCity.Properties.AutoCompleteText = null;
            this.lkpDestCity.Properties.AutoCompleteWhereExpression = null;
            this.lkpDestCity.Properties.AutoCompleteWheretermFormater = null;
            this.lkpDestCity.Properties.AutoHeight = false;
            this.lkpDestCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpDestCity.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpDestCity.Properties.LookupPopup = null;
            this.lkpDestCity.Properties.NullText = "<<Choose...>>";
            this.lkpDestCity.Size = new System.Drawing.Size(311, 20);
            this.lkpDestCity.TabIndex = 104;
            this.lkpDestCity.ValidationRules = null;
            this.lkpDestCity.Value = null;
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
            this.lkpCustomer.Location = new System.Drawing.Point(104, 61);
            this.lkpCustomer.LookupPopup = null;
            this.lkpCustomer.Name = "lkpCustomer";
            this.lkpCustomer.OriginalBackColor = System.Drawing.Color.Empty;
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpCustomer.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.lkpCustomer.Properties.LookupPopup = null;
            this.lkpCustomer.Properties.NullText = "<<Choose...>>";
            this.lkpCustomer.Size = new System.Drawing.Size(311, 20);
            this.lkpCustomer.TabIndex = 103;
            this.lkpCustomer.ValidationRules = null;
            this.lkpCustomer.Value = null;
            // 
            // txtDateTo
            // 
            this.txtDateTo.EditValue = null;
            this.txtDateTo.FieldLabel = null;
            this.txtDateTo.FormatDateTime = "dd-MM-yyyy";
            this.txtDateTo.Location = new System.Drawing.Point(104, 39);
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Nullable = false;
            this.txtDateTo.OriginalBackColor = System.Drawing.Color.Empty;
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
            this.txtDateTo.Properties.NullText = "<<Choose...>>";
            this.txtDateTo.Size = new System.Drawing.Size(155, 20);
            this.txtDateTo.TabIndex = 102;
            this.txtDateTo.ValidationRules = null;
            this.txtDateTo.Value = new System.DateTime(((long)(0)));
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.EditValue = null;
            this.txtDateFrom.FieldLabel = null;
            this.txtDateFrom.FormatDateTime = "dd-MM-yyyy";
            this.txtDateFrom.Location = new System.Drawing.Point(104, 17);
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.Nullable = false;
            this.txtDateFrom.OriginalBackColor = System.Drawing.Color.Empty;
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
            this.txtDateFrom.Properties.NullText = "<<Choose...>>";
            this.txtDateFrom.Size = new System.Drawing.Size(155, 20);
            this.txtDateFrom.TabIndex = 101;
            this.txtDateFrom.ValidationRules = null;
            this.txtDateFrom.Value = new System.DateTime(((long)(0)));
            // 
            // btnSearch
            // 
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(338, 145);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(77, 26);
            this.btnSearch.TabIndex = 112;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(48, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 127;
            this.label1.Text = "Customer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(52, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 127;
            this.label5.Text = "Date To";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(20, 152);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 13);
            this.label16.TabIndex = 127;
            this.label16.Text = "Customer Type";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(47, 130);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 13);
            this.label15.TabIndex = 127;
            this.label15.Text = "Validated";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(42, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 127;
            this.label14.Text = "Date From";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(21, 108);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 13);
            this.label13.TabIndex = 106;
            this.label13.Text = "Package Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(39, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "Destination";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(23, 489);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 127;
            this.label3.Text = "Total:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(182, 490);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 200;
            this.label4.Text = "Rows:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(494, 157);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 31);
            this.btnSave.TabIndex = 201;
            this.btnSave.Text = "Save To Excel";
            // 
            // ViewShipmentListForm
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(783, 520);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.groupBox1);
            this.Name = "ViewShipmentListForm";
            this.Text = "Pre-Invoice";
            this.pnlCustomerTypeOptions.ResumeLayout(false);
            this.pnlCustomerTypeOptions.PerformLayout();
            this.pnlValidatedOptions.ResumeLayout(false);
            this.pnlValidatedOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPackageType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rdoValidatedAll;
        private System.Windows.Forms.RadioButton rdoValidatedYes;
        private System.Windows.Forms.RadioButton rdoValidatedNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rdoCustomerTypeAll;
        private System.Windows.Forms.RadioButton rdoCustomerTypeCorporate;
        private System.Windows.Forms.RadioButton rdoCustomerTypePersonal;
        private System.Windows.Forms.Panel pnlCustomerTypeOptions;
        private System.Windows.Forms.Panel pnlValidatedOptions;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private Common.Component.dLookup lkpDestCity;
        private Common.Component.dLookup lkpCustomer;
        private Common.Component.dCalendar txtDateTo;
        private Common.Component.dCalendar txtDateFrom;
        private Common.Component.dLookup lkpPackageType;
        private Label label3;
        private Label label4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}

