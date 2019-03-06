using SISCO.Presentation.Common.Component;

namespace SISCO.Presentation.CustomerService.Forms
{
    partial class ComplaintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComplaintForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbFilterStatus = new SISCO.Presentation.Common.Component.dComboBox(this.components);
            this.cmbFilterCategory = new SISCO.Presentation.Common.Component.dComboBox(this.components);
            this.txtFilterDate = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.txtFilterReference = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.lkpFilterBranch = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.lkpFilterCustomer = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSaveToExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbStatus = new SISCO.Presentation.Common.Component.dComboBox(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtActionAdd = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.cmbCategory = new SISCO.Presentation.Common.Component.dComboBox(this.components);
            this.btnSaveFollowUpsToExcel = new System.Windows.Forms.Button();
            this.txtNote = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.txtPhone = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.txtContact = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.txtReference = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.lkpCustomer = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.lkpBranch = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.gridFollowUp = new DevExpress.XtraGrid.GridControl();
            this.gridFollowUpView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilterBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilterCustomer.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFollowUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFollowUpView)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.Location = new System.Drawing.Point(9, 160);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(487, 328);
            this.grid.TabIndex = 110;
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
            this.gridColumn7});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 35;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Date";
            this.gridColumn2.FieldName = "Vdate";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 62;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Customer";
            this.gridColumn3.FieldName = "CustomerName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 109;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Branch";
            this.gridColumn4.FieldName = "Branch";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 49;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Reference";
            this.gridColumn5.FieldName = "RefCode";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 67;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "CS";
            this.gridColumn6.FieldName = "CustomerService";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 50;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Note";
            this.gridColumn7.FieldName = "Note";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 65;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbFilterStatus);
            this.groupBox1.Controls.Add(this.cmbFilterCategory);
            this.groupBox1.Controls.Add(this.txtFilterDate);
            this.groupBox1.Controls.Add(this.txtFilterReference);
            this.groupBox1.Controls.Add(this.lkpFilterBranch);
            this.groupBox1.Controls.Add(this.lkpFilterCustomer);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.btnSaveToExcel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.grid);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 501);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // cmbFilterStatus
            // 
            this.cmbFilterStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFilterStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterStatus.FieldLabel = null;
            this.cmbFilterStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbFilterStatus.FormattingEnabled = true;
            this.cmbFilterStatus.Location = new System.Drawing.Point(88, 129);
            this.cmbFilterStatus.Name = "cmbFilterStatus";
            this.cmbFilterStatus.Size = new System.Drawing.Size(156, 21);
            this.cmbFilterStatus.TabIndex = 106;
            this.cmbFilterStatus.ValidationRules = null;
            // 
            // cmbFilterCategory
            // 
            this.cmbFilterCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFilterCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterCategory.FieldLabel = null;
            this.cmbFilterCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbFilterCategory.FormattingEnabled = true;
            this.cmbFilterCategory.Location = new System.Drawing.Point(88, 107);
            this.cmbFilterCategory.Name = "cmbFilterCategory";
            this.cmbFilterCategory.Size = new System.Drawing.Size(156, 21);
            this.cmbFilterCategory.TabIndex = 105;
            this.cmbFilterCategory.ValidationRules = null;
            // 
            // txtFilterDate
            // 
            this.txtFilterDate.EditValue = null;
            this.txtFilterDate.FieldLabel = null;
            this.txtFilterDate.FormatDateTime = "dd-MM-yyyy";
            this.txtFilterDate.Location = new System.Drawing.Point(88, 85);
            this.txtFilterDate.Name = "txtFilterDate";
            this.txtFilterDate.Nullable = false;
            this.txtFilterDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtFilterDate.Properties.AutoHeight = false;
            this.txtFilterDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtFilterDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtFilterDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFilterDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtFilterDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFilterDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtFilterDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFilterDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtFilterDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtFilterDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtFilterDate.Size = new System.Drawing.Size(156, 20);
            this.txtFilterDate.TabIndex = 104;
            this.txtFilterDate.ValidationRules = null;
            this.txtFilterDate.Value = new System.DateTime(((long)(0)));
            // 
            // txtFilterReference
            // 
            this.txtFilterReference.Capslock = true;
            this.txtFilterReference.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFilterReference.FieldLabel = null;
            this.txtFilterReference.Location = new System.Drawing.Point(88, 63);
            this.txtFilterReference.Name = "txtFilterReference";
            this.txtFilterReference.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtFilterReference.Size = new System.Drawing.Size(156, 20);
            this.txtFilterReference.TabIndex = 103;
            this.txtFilterReference.ValidationRules = null;
            // 
            // lkpFilterBranch
            // 
            this.lkpFilterBranch.AutoCompleteDataManager = null;
            this.lkpFilterBranch.AutoCompleteDisplayFormater = null;
            this.lkpFilterBranch.AutoCompleteInitialized = false;
            this.lkpFilterBranch.AutocompleteMinimumTextLength = 0;
            this.lkpFilterBranch.AutoCompleteText = null;
            this.lkpFilterBranch.AutoCompleteWhereExpression = null;
            this.lkpFilterBranch.AutoCompleteWheretermFormater = null;
            this.lkpFilterBranch.ClearOnLeave = true;
            this.lkpFilterBranch.DisplayString = null;
            this.lkpFilterBranch.FieldLabel = null;
            this.lkpFilterBranch.Location = new System.Drawing.Point(88, 41);
            this.lkpFilterBranch.LookupPopup = null;
            this.lkpFilterBranch.Name = "lkpFilterBranch";
            this.lkpFilterBranch.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpFilterBranch.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpFilterBranch.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpFilterBranch.Properties.AutoCompleteDataManager = null;
            this.lkpFilterBranch.Properties.AutoCompleteDisplayFormater = null;
            this.lkpFilterBranch.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpFilterBranch.Properties.AutoCompleteText = null;
            this.lkpFilterBranch.Properties.AutoCompleteWhereExpression = null;
            this.lkpFilterBranch.Properties.AutoCompleteWheretermFormater = null;
            this.lkpFilterBranch.Properties.AutoHeight = false;
            this.lkpFilterBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpFilterBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpFilterBranch.Properties.LookupPopup = null;
            this.lkpFilterBranch.Properties.NullText = "<<Choose...>>";
            this.lkpFilterBranch.Size = new System.Drawing.Size(264, 20);
            this.lkpFilterBranch.TabIndex = 102;
            this.lkpFilterBranch.ValidationRules = null;
            this.lkpFilterBranch.Value = null;
            // 
            // lkpFilterCustomer
            // 
            this.lkpFilterCustomer.AutoCompleteDataManager = null;
            this.lkpFilterCustomer.AutoCompleteDisplayFormater = null;
            this.lkpFilterCustomer.AutoCompleteInitialized = false;
            this.lkpFilterCustomer.AutocompleteMinimumTextLength = 0;
            this.lkpFilterCustomer.AutoCompleteText = null;
            this.lkpFilterCustomer.AutoCompleteWhereExpression = null;
            this.lkpFilterCustomer.AutoCompleteWheretermFormater = null;
            this.lkpFilterCustomer.ClearOnLeave = true;
            this.lkpFilterCustomer.DisplayString = null;
            this.lkpFilterCustomer.FieldLabel = null;
            this.lkpFilterCustomer.Location = new System.Drawing.Point(88, 19);
            this.lkpFilterCustomer.LookupPopup = null;
            this.lkpFilterCustomer.Name = "lkpFilterCustomer";
            this.lkpFilterCustomer.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpFilterCustomer.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpFilterCustomer.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpFilterCustomer.Properties.AutoCompleteDataManager = null;
            this.lkpFilterCustomer.Properties.AutoCompleteDisplayFormater = null;
            this.lkpFilterCustomer.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpFilterCustomer.Properties.AutoCompleteText = null;
            this.lkpFilterCustomer.Properties.AutoCompleteWhereExpression = null;
            this.lkpFilterCustomer.Properties.AutoCompleteWheretermFormater = null;
            this.lkpFilterCustomer.Properties.AutoHeight = false;
            this.lkpFilterCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpFilterCustomer.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.lkpFilterCustomer.Properties.LookupPopup = null;
            this.lkpFilterCustomer.Properties.NullText = "<<Choose...>>";
            this.lkpFilterCustomer.Size = new System.Drawing.Size(264, 20);
            this.lkpFilterCustomer.TabIndex = 101;
            this.lkpFilterCustomer.ValidationRules = null;
            this.lkpFilterCustomer.Value = null;
            // 
            // btnSearch
            // 
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(304, 125);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(77, 26);
            this.btnSearch.TabIndex = 107;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnSaveToExcel
            // 
            this.btnSaveToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveToExcel.Location = new System.Drawing.Point(387, 125);
            this.btnSaveToExcel.Name = "btnSaveToExcel";
            this.btnSaveToExcel.Size = new System.Drawing.Size(108, 26);
            this.btnSaveToExcel.TabIndex = 111;
            this.btnSaveToExcel.Text = "Save To Excel";
            this.btnSaveToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveToExcel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 127;
            this.label1.Text = "Branch";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(45, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 106;
            this.label10.Text = "Status";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(31, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 13);
            this.label14.TabIndex = 127;
            this.label14.Text = "Customer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 106;
            this.label4.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 106;
            this.label3.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "Reference";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbStatus);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.cmbCategory);
            this.groupBox2.Controls.Add(this.btnSaveFollowUpsToExcel);
            this.groupBox2.Controls.Add(this.txtNote);
            this.groupBox2.Controls.Add(this.txtPhone);
            this.groupBox2.Controls.Add(this.txtContact);
            this.groupBox2.Controls.Add(this.txtReference);
            this.groupBox2.Controls.Add(this.lkpCustomer);
            this.groupBox2.Controls.Add(this.lkpBranch);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.gridFollowUp);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(522, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 501);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detail";
            // 
            // cmbStatus
            // 
            this.cmbStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FieldLabel = null;
            this.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(84, 173);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(156, 21);
            this.cmbStatus.TabIndex = 108;
            this.cmbStatus.ValidationRules = null;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtActionAdd);
            this.panel1.Location = new System.Drawing.Point(10, 202);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 50);
            this.panel1.TabIndex = 109;
            // 
            // btnAdd
            // 
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(272, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(49, 21);
            this.btnAdd.TabIndex = 102;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(10, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 13);
            this.label13.TabIndex = 106;
            this.label13.Text = "Action/Follow-up";
            // 
            // txtActionAdd
            // 
            this.txtActionAdd.Capslock = true;
            this.txtActionAdd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtActionAdd.FieldLabel = null;
            this.txtActionAdd.Location = new System.Drawing.Point(13, 17);
            this.txtActionAdd.Name = "txtActionAdd";
            this.txtActionAdd.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtActionAdd.Size = new System.Drawing.Size(253, 20);
            this.txtActionAdd.TabIndex = 101;
            this.txtActionAdd.ValidationRules = null;
            // 
            // cmbCategory
            // 
            this.cmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FieldLabel = null;
            this.cmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(84, 151);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(156, 21);
            this.cmbCategory.TabIndex = 107;
            this.cmbCategory.ValidationRules = null;
            // 
            // btnSaveFollowUpsToExcel
            // 
            this.btnSaveFollowUpsToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveFollowUpsToExcel.Location = new System.Drawing.Point(227, 464);
            this.btnSaveFollowUpsToExcel.Name = "btnSaveFollowUpsToExcel";
            this.btnSaveFollowUpsToExcel.Size = new System.Drawing.Size(114, 24);
            this.btnSaveFollowUpsToExcel.TabIndex = 150;
            this.btnSaveFollowUpsToExcel.Text = "Save To Excel";
            this.btnSaveFollowUpsToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveFollowUpsToExcel.UseVisualStyleBackColor = true;
            // 
            // txtNote
            // 
            this.txtNote.Capslock = true;
            this.txtNote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNote.FieldLabel = null;
            this.txtNote.Location = new System.Drawing.Point(84, 129);
            this.txtNote.Name = "txtNote";
            this.txtNote.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtNote.Size = new System.Drawing.Size(257, 20);
            this.txtNote.TabIndex = 106;
            this.txtNote.ValidationRules = null;
            // 
            // txtPhone
            // 
            this.txtPhone.Capslock = true;
            this.txtPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPhone.FieldLabel = null;
            this.txtPhone.Location = new System.Drawing.Point(84, 107);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtPhone.Size = new System.Drawing.Size(156, 20);
            this.txtPhone.TabIndex = 105;
            this.txtPhone.ValidationRules = null;
            // 
            // txtContact
            // 
            this.txtContact.Capslock = true;
            this.txtContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContact.FieldLabel = null;
            this.txtContact.Location = new System.Drawing.Point(84, 85);
            this.txtContact.Name = "txtContact";
            this.txtContact.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtContact.Size = new System.Drawing.Size(156, 20);
            this.txtContact.TabIndex = 104;
            this.txtContact.ValidationRules = null;
            // 
            // txtReference
            // 
            this.txtReference.Capslock = true;
            this.txtReference.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReference.FieldLabel = null;
            this.txtReference.Location = new System.Drawing.Point(84, 63);
            this.txtReference.Name = "txtReference";
            this.txtReference.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtReference.Size = new System.Drawing.Size(156, 20);
            this.txtReference.TabIndex = 103;
            this.txtReference.ValidationRules = null;
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
            this.lkpCustomer.Location = new System.Drawing.Point(84, 19);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpCustomer.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.lkpCustomer.Properties.LookupPopup = null;
            this.lkpCustomer.Properties.NullText = "<<Choose...>>";
            this.lkpCustomer.Size = new System.Drawing.Size(257, 20);
            this.lkpCustomer.TabIndex = 101;
            this.lkpCustomer.ValidationRules = null;
            this.lkpCustomer.Value = null;
            // 
            // lkpBranch
            // 
            this.lkpBranch.AutoCompleteDataManager = null;
            this.lkpBranch.AutoCompleteDisplayFormater = null;
            this.lkpBranch.AutoCompleteInitialized = false;
            this.lkpBranch.AutocompleteMinimumTextLength = 0;
            this.lkpBranch.AutoCompleteText = null;
            this.lkpBranch.AutoCompleteWhereExpression = null;
            this.lkpBranch.AutoCompleteWheretermFormater = null;
            this.lkpBranch.ClearOnLeave = true;
            this.lkpBranch.DisplayString = null;
            this.lkpBranch.FieldLabel = null;
            this.lkpBranch.Location = new System.Drawing.Point(84, 41);
            this.lkpBranch.LookupPopup = null;
            this.lkpBranch.Name = "lkpBranch";
            this.lkpBranch.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpBranch.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpBranch.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpBranch.Properties.AutoCompleteDataManager = null;
            this.lkpBranch.Properties.AutoCompleteDisplayFormater = null;
            this.lkpBranch.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpBranch.Properties.AutoCompleteText = null;
            this.lkpBranch.Properties.AutoCompleteWhereExpression = null;
            this.lkpBranch.Properties.AutoCompleteWheretermFormater = null;
            this.lkpBranch.Properties.AutoHeight = false;
            this.lkpBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.lkpBranch.Properties.LookupPopup = null;
            this.lkpBranch.Properties.NullText = "<<Choose...>>";
            this.lkpBranch.Size = new System.Drawing.Size(257, 20);
            this.lkpBranch.TabIndex = 102;
            this.lkpBranch.ValidationRules = null;
            this.lkpBranch.Value = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 127;
            this.label5.Text = "Branch";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 127;
            this.label6.Text = "Customer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(41, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 106;
            this.label7.Text = "Status";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(29, 154);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 13);
            this.label16.TabIndex = 106;
            this.label16.Text = "Category";
            // 
            // gridFollowUp
            // 
            this.gridFollowUp.Location = new System.Drawing.Point(10, 254);
            this.gridFollowUp.MainView = this.gridFollowUpView;
            this.gridFollowUp.Name = "gridFollowUp";
            this.gridFollowUp.Size = new System.Drawing.Size(331, 204);
            this.gridFollowUp.TabIndex = 54;
            this.gridFollowUp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridFollowUpView});
            // 
            // gridFollowUpView
            // 
            this.gridFollowUpView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn13,
            this.gridColumn14});
            this.gridFollowUpView.GridControl = this.gridFollowUp;
            this.gridFollowUpView.Name = "gridFollowUpView";
            this.gridFollowUpView.OptionsBehavior.Editable = false;
            this.gridFollowUpView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridFollowUpView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Date";
            this.gridColumn8.FieldName = "Vdate";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "CS";
            this.gridColumn13.FieldName = "CustomerService";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 1;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Note";
            this.gridColumn14.FieldName = "Note";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(21, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 106;
            this.label9.Text = "Reference";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(48, 132);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 13);
            this.label15.TabIndex = 106;
            this.label15.Text = "Note";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(41, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 106;
            this.label12.Text = "Phone";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(34, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 106;
            this.label11.Text = "Contact";
            // 
            // ComplaintForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(890, 571);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ComplaintForm";
            this.Text = "Complaint";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilterBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilterCustomer.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFollowUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFollowUpView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraGrid.GridControl gridFollowUp;
        private DevExpress.XtraGrid.Views.Grid.GridView gridFollowUpView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private System.Windows.Forms.Button btnSaveToExcel;
        private System.Windows.Forms.Button btnSaveFollowUpsToExcel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label16;
        private Common.Component.dLookup lkpFilterCustomer;
        private dComboBox cmbFilterStatus;
        private dComboBox cmbFilterCategory;
        private Common.Component.dCalendar txtFilterDate;
        private Common.Component.dTextBox txtFilterReference;
        private Common.Component.dLookup lkpFilterBranch;
        private dComboBox cmbStatus;
        private Common.Component.dTextBox txtActionAdd;
        private dComboBox cmbCategory;
        private Common.Component.dTextBox txtNote;
        private Common.Component.dTextBox txtPhone;
        private Common.Component.dTextBox txtContact;
        private Common.Component.dTextBox txtReference;
        private Common.Component.dLookup lkpCustomer;
        private Common.Component.dLookup lkpBranch;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;


    }
}

