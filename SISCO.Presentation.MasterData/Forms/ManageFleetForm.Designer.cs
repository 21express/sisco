using System.Windows.Forms;

namespace SISCO.Presentation.MasterData.Forms
{
    partial class ManageFleetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageFleetForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.lkpBaseBranch = new SISCO.Presentation.Common.Component.dLookup();
            this.txtNote = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtYear = new SISCO.Presentation.Common.Component.dTextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNextExpiryDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbVehicleType = new SISCO.Presentation.Common.Component.dComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPlateNumber = new SISCO.Presentation.Common.Component.dTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBrand = new SISCO.Presentation.Common.Component.dTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtModel = new SISCO.Presentation.Common.Component.dTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxVehicleType = new System.Windows.Forms.ComboBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.tbxModel = new SISCO.Presentation.Common.Component.dTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbxBrand = new SISCO.Presentation.Common.Component.dTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxPlate = new SISCO.Presentation.Common.Component.dTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBaseBranch.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNextExpiryDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNextExpiryDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(64, 309);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 30);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.lkpBaseBranch);
            this.grpDetail.Controls.Add(this.txtNote);
            this.grpDetail.Controls.Add(this.txtYear);
            this.grpDetail.Controls.Add(this.btnDelete);
            this.grpDetail.Controls.Add(this.btnSave);
            this.grpDetail.Controls.Add(this.panel1);
            this.grpDetail.Controls.Add(this.label10);
            this.grpDetail.Controls.Add(this.label2);
            this.grpDetail.Controls.Add(this.cmbVehicleType);
            this.grpDetail.Controls.Add(this.label6);
            this.grpDetail.Controls.Add(this.label11);
            this.grpDetail.Controls.Add(this.label5);
            this.grpDetail.Controls.Add(this.txtPlateNumber);
            this.grpDetail.Controls.Add(this.label8);
            this.grpDetail.Controls.Add(this.txtBrand);
            this.grpDetail.Controls.Add(this.label9);
            this.grpDetail.Controls.Add(this.txtModel);
            this.grpDetail.Location = new System.Drawing.Point(546, 12);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(338, 465);
            this.grpDetail.TabIndex = 7;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "Detail";
            // 
            // lkpBaseBranch
            // 
            this.lkpBaseBranch.AutoCompleteDataManager = null;
            this.lkpBaseBranch.AutoCompleteDisplayFormater = null;
            this.lkpBaseBranch.AutoCompleteInitialized = false;
            this.lkpBaseBranch.AutocompleteMinimumTextLength = 0;
            this.lkpBaseBranch.AutoCompleteText = null;
            this.lkpBaseBranch.AutoCompleteWhereExpression = null;
            this.lkpBaseBranch.AutoCompleteWheretermFormater = null;
            this.lkpBaseBranch.ClearOnLeave = true;
            this.lkpBaseBranch.DisplayString = null;
            this.lkpBaseBranch.FieldLabel = null;
            this.lkpBaseBranch.Location = new System.Drawing.Point(91, 51);
            this.lkpBaseBranch.LookupPopup = null;
            this.lkpBaseBranch.Name = "lkpBaseBranch";
            this.lkpBaseBranch.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpBaseBranch.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpBaseBranch.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpBaseBranch.Properties.AutoCompleteDataManager = null;
            this.lkpBaseBranch.Properties.AutoCompleteDisplayFormater = null;
            this.lkpBaseBranch.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpBaseBranch.Properties.AutoCompleteText = null;
            this.lkpBaseBranch.Properties.AutoCompleteWhereExpression = null;
            this.lkpBaseBranch.Properties.AutoCompleteWheretermFormater = null;
            this.lkpBaseBranch.Properties.AutoHeight = false;
            this.lkpBaseBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpBaseBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpBaseBranch.Properties.LookupPopup = null;
            this.lkpBaseBranch.Properties.NullText = "<<Choose...>>";
            this.lkpBaseBranch.Size = new System.Drawing.Size(200, 20);
            this.lkpBaseBranch.TabIndex = 8;
            this.lkpBaseBranch.ValidationRules = null;
            this.lkpBaseBranch.Value = null;
            // 
            // txtNote
            // 
            this.txtNote.Capslock = true;
            this.txtNote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNote.FieldLabel = null;
            this.txtNote.Location = new System.Drawing.Point(91, 171);
            this.txtNote.Name = "txtNote";
            this.txtNote.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtNote.Size = new System.Drawing.Size(224, 20);
            this.txtNote.TabIndex = 13;
            this.txtNote.ValidationRules = null;
            // 
            // txtYear
            // 
            this.txtYear.Capslock = true;
            this.txtYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtYear.FieldLabel = null;
            this.txtYear.Location = new System.Drawing.Point(91, 149);
            this.txtYear.Name = "txtYear";
            this.txtYear.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtYear.Size = new System.Drawing.Size(115, 20);
            this.txtYear.TabIndex = 12;
            this.txtYear.ValidationRules = null;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(169, 309);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtNextExpiryDate);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(91, 219);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 58);
            this.panel1.TabIndex = 14;
            // 
            // txtNextExpiryDate
            // 
            this.txtNextExpiryDate.EditValue = null;
            this.txtNextExpiryDate.FieldLabel = null;
            this.txtNextExpiryDate.FormatDateTime = "dd-MM-yyyy";
            this.txtNextExpiryDate.Location = new System.Drawing.Point(15, 28);
            this.txtNextExpiryDate.Name = "txtNextExpiryDate";
            this.txtNextExpiryDate.Nullable = false;
            this.txtNextExpiryDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtNextExpiryDate.Properties.AutoHeight = false;
            this.txtNextExpiryDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtNextExpiryDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.txtNextExpiryDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNextExpiryDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtNextExpiryDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtNextExpiryDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtNextExpiryDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtNextExpiryDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtNextExpiryDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtNextExpiryDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtNextExpiryDate.Size = new System.Drawing.Size(184, 20);
            this.txtNextExpiryDate.TabIndex = 14;
            this.txtNextExpiryDate.ValidationRules = null;
            this.txtNextExpiryDate.Value = new System.DateTime(((long)(0)));
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 13);
            this.label7.TabIndex = 108;
            this.label7.Text = "Next Registration Expiration Date";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(15, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 138;
            this.label10.Text = "Plate Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(55, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 139;
            this.label2.Text = "Note";
            // 
            // cmbVehicleType
            // 
            this.cmbVehicleType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbVehicleType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVehicleType.FieldLabel = null;
            this.cmbVehicleType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbVehicleType.Location = new System.Drawing.Point(91, 83);
            this.cmbVehicleType.Name = "cmbVehicleType";
            this.cmbVehicleType.Size = new System.Drawing.Size(200, 21);
            this.cmbVehicleType.TabIndex = 9;
            this.cmbVehicleType.ValidationRules = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(56, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 139;
            this.label6.Text = "Year";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(18, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 134;
            this.label11.Text = "Base Branch";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(49, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 137;
            this.label5.Text = "Model";
            // 
            // txtPlateNumber
            // 
            this.txtPlateNumber.Capslock = true;
            this.txtPlateNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlateNumber.FieldLabel = null;
            this.txtPlateNumber.Location = new System.Drawing.Point(91, 21);
            this.txtPlateNumber.Name = "txtPlateNumber";
            this.txtPlateNumber.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtPlateNumber.Size = new System.Drawing.Size(115, 20);
            this.txtPlateNumber.TabIndex = 7;
            this.txtPlateNumber.ValidationRules = null;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(50, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 135;
            this.label8.Text = "Brand";
            // 
            // txtBrand
            // 
            this.txtBrand.Capslock = true;
            this.txtBrand.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBrand.FieldLabel = null;
            this.txtBrand.Location = new System.Drawing.Point(91, 105);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtBrand.Size = new System.Drawing.Size(200, 20);
            this.txtBrand.TabIndex = 10;
            this.txtBrand.ValidationRules = null;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(17, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 136;
            this.label9.Text = "Vehicle Type";
            // 
            // txtModel
            // 
            this.txtModel.Capslock = true;
            this.txtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModel.FieldLabel = null;
            this.txtModel.Location = new System.Drawing.Point(91, 127);
            this.txtModel.Name = "txtModel";
            this.txtModel.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtModel.Size = new System.Drawing.Size(200, 20);
            this.txtModel.TabIndex = 11;
            this.txtModel.ValidationRules = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(8, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 13);
            this.label1.TabIndex = 138;
            this.label1.Text = "Plate registration expires within 1 month";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Model";
            this.gridColumn1.FieldName = "Model";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 89;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Next Exp. Date";
            this.gridColumn6.FieldName = "NextExpirationDate";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 79;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Brand";
            this.gridColumn5.FieldName = "Brand";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 80;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Vehicle Type";
            this.gridColumn4.FieldName = "VehicleType";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 80;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Base Branch";
            this.gridColumn3.FieldName = "BaseBranch";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 87;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Plate Number";
            this.gridColumn2.FieldName = "PlateNumber";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 73;
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn1});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // grid
            // 
            this.grid.Location = new System.Drawing.Point(11, 47);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(506, 298);
            this.grid.TabIndex = 6;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(423, 19);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(94, 22);
            this.btnNew.TabIndex = 101;
            this.btnNew.Text = "New Fleet";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.grid);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(528, 376);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "All Fleets";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.tbxVehicleType);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.tbxModel);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.tbxBrand);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbxPlate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 83);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // tbxVehicleType
            // 
            this.tbxVehicleType.FormattingEnabled = true;
            this.tbxVehicleType.Location = new System.Drawing.Point(97, 51);
            this.tbxVehicleType.Name = "tbxVehicleType";
            this.tbxVehicleType.Size = new System.Drawing.Size(130, 21);
            this.tbxVehicleType.TabIndex = 2;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(431, 24);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // tbxModel
            // 
            this.tbxModel.Capslock = true;
            this.tbxModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxModel.FieldLabel = null;
            this.tbxModel.Location = new System.Drawing.Point(285, 51);
            this.tbxModel.Name = "tbxModel";
            this.tbxModel.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxModel.Size = new System.Drawing.Size(140, 20);
            this.tbxModel.TabIndex = 4;
            this.tbxModel.ValidationRules = null;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(244, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Model";
            // 
            // tbxBrand
            // 
            this.tbxBrand.Capslock = true;
            this.tbxBrand.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxBrand.FieldLabel = null;
            this.tbxBrand.Location = new System.Drawing.Point(285, 21);
            this.tbxBrand.Name = "tbxBrand";
            this.tbxBrand.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxBrand.Size = new System.Drawing.Size(140, 20);
            this.tbxBrand.TabIndex = 3;
            this.tbxBrand.ValidationRules = null;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Vehicle Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Brand";
            // 
            // tbxPlate
            // 
            this.tbxPlate.Capslock = true;
            this.tbxPlate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxPlate.FieldLabel = null;
            this.tbxPlate.Location = new System.Drawing.Point(97, 21);
            this.tbxPlate.Name = "tbxPlate";
            this.tbxPlate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPlate.Size = new System.Drawing.Size(130, 20);
            this.tbxPlate.TabIndex = 1;
            this.tbxPlate.ValidationRules = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Plate Number";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(431, 48);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // ManageFleetForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(898, 488);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpDetail);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ManageFleetForm";
            this.Text = "Master Fleet";
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBaseBranch.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNextExpiryDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNextExpiryDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private Common.Component.dComboBox cmbVehicleType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private Common.Component.dTextBox txtPlateNumber;
        private System.Windows.Forms.Label label8;
        private Common.Component.dTextBox txtBrand;
        private System.Windows.Forms.Label label9;
        private Common.Component.dTextBox txtModel;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.GridControl grid;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox groupBox2;
        private Common.Component.dTextBox txtYear;
        private Common.Component.dCalendar txtNextExpiryDate;
        private Common.Component.dLookup lkpBaseBranch;
        private Common.Component.dTextBox txtNote;
        private Label label2;
        private GroupBox groupBox1;
        private Common.Component.dTextBox tbxModel;
        private Label label13;
        private Common.Component.dTextBox tbxBrand;
        private Label label12;
        private Label label4;
        private Common.Component.dTextBox tbxPlate;
        private Label label3;
        private Button btnFind;
        private ComboBox tbxVehicleType;
        private Button btnClear;
    }
}