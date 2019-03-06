namespace SISCO.Presentation.Marketing.Forms
{
    partial class ManageContactsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageContactsForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnNewContact = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtFilterContactPerson = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtContactEmail = new SISCO.Presentation.Common.Component.dTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.txtContactPhone = new SISCO.Presentation.Common.Component.dTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilterCompanyName = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtPhone = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtCompanyName = new SISCO.Presentation.Common.Component.dTextBox();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lkpFilterMarketing = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpFilterRespBranch = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpFilterCustomer = new SISCO.Presentation.Common.Component.dLookup();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.txtDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.lkpMarketing = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpCustomer = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpRespBranch = new SISCO.Presentation.Common.Component.dLookup();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtContactPerson = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtNote = new SISCO.Presentation.Common.Component.dTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilterMarketing.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilterRespBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilterCustomer.Properties)).BeginInit();
            this.grpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpMarketing.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpRespBranch.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Contact Person";
            this.gridColumn4.FieldName = "ContactName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // btnNewContact
            // 
            this.btnNewContact.Image = global::SISCO.Presentation.Marketing.Properties.Resources.icon_add_small;
            this.btnNewContact.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewContact.Location = new System.Drawing.Point(356, 117);
            this.btnNewContact.Name = "btnNewContact";
            this.btnNewContact.Size = new System.Drawing.Size(107, 22);
            this.btnNewContact.TabIndex = 107;
            this.btnNewContact.Text = "New Contact";
            this.btnNewContact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewContact.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::SISCO.Presentation.Marketing.Properties.Resources.icon_search_small;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(279, 117);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(68, 22);
            this.btnSearch.TabIndex = 106;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 138;
            this.label4.Text = "Resp. Branch";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(40, 68);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 13);
            this.label15.TabIndex = 138;
            this.label15.Text = "Marketing";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Marketing";
            this.gridColumn1.FieldName = "Marketing";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(40, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 13);
            this.label14.TabIndex = 138;
            this.label14.Text = "Customer";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(13, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 13);
            this.label16.TabIndex = 137;
            this.label16.Text = "Date";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "gridColumn8";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            // 
            // txtFilterContactPerson
            // 
            this.txtFilterContactPerson.Capslock = true;
            this.txtFilterContactPerson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFilterContactPerson.FieldLabel = null;
            this.txtFilterContactPerson.Location = new System.Drawing.Point(97, 119);
            this.txtFilterContactPerson.Name = "txtFilterContactPerson";
            this.txtFilterContactPerson.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtFilterContactPerson.Size = new System.Drawing.Size(156, 20);
            this.txtFilterContactPerson.TabIndex = 105;
            this.txtFilterContactPerson.ValidationRules = null;
            // 
            // txtContactEmail
            // 
            this.txtContactEmail.Capslock = true;
            this.txtContactEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactEmail.FieldLabel = null;
            this.txtContactEmail.Location = new System.Drawing.Point(117, 259);
            this.txtContactEmail.Name = "txtContactEmail";
            this.txtContactEmail.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtContactEmail.Size = new System.Drawing.Size(248, 20);
            this.txtContactEmail.TabIndex = 110;
            this.txtContactEmail.ValidationRules = null;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 134;
            this.label8.Text = "Company Name";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::SISCO.Presentation.Marketing.Properties.Resources.icon_delete_small;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(261, 407);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(77, 37);
            this.btnDelete.TabIndex = 114;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::SISCO.Presentation.Marketing.Properties.Resources.icon_save_small;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(184, 407);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 37);
            this.btnSave.TabIndex = 113;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            this.btnCopy.Image = global::SISCO.Presentation.Marketing.Properties.Resources.icon_copy_small;
            this.btnCopy.Location = new System.Drawing.Point(56, 407);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(122, 37);
            this.btnCopy.TabIndex = 112;
            this.btnCopy.Text = "Copy to Customer Master Data";
            this.btnCopy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopy.UseVisualStyleBackColor = true;
            // 
            // txtContactPhone
            // 
            this.txtContactPhone.Capslock = true;
            this.txtContactPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactPhone.FieldLabel = null;
            this.txtContactPhone.Location = new System.Drawing.Point(117, 237);
            this.txtContactPhone.Name = "txtContactPhone";
            this.txtContactPhone.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtContactPhone.Size = new System.Drawing.Size(136, 20);
            this.txtContactPhone.TabIndex = 109;
            this.txtContactPhone.ValidationRules = null;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 284);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 106;
            this.label11.Text = "Note";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 262);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 106;
            this.label10.Text = "Contact Email";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 106;
            this.label9.Text = "Contact Ph. Number";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 218);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 13);
            this.label13.TabIndex = 107;
            this.label13.Text = "Contact Person";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 135;
            this.label3.Text = "Contact Person";
            // 
            // txtFilterCompanyName
            // 
            this.txtFilterCompanyName.Capslock = true;
            this.txtFilterCompanyName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFilterCompanyName.FieldLabel = null;
            this.txtFilterCompanyName.Location = new System.Drawing.Point(97, 97);
            this.txtFilterCompanyName.Name = "txtFilterCompanyName";
            this.txtFilterCompanyName.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtFilterCompanyName.Size = new System.Drawing.Size(156, 20);
            this.txtFilterCompanyName.TabIndex = 104;
            this.txtFilterCompanyName.ValidationRules = null;
            // 
            // txtPhone
            // 
            this.txtPhone.Capslock = true;
            this.txtPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPhone.FieldLabel = null;
            this.txtPhone.Location = new System.Drawing.Point(117, 97);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtPhone.Size = new System.Drawing.Size(136, 20);
            this.txtPhone.TabIndex = 104;
            this.txtPhone.ValidationRules = null;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Capslock = true;
            this.txtCompanyName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCompanyName.FieldLabel = null;
            this.txtCompanyName.Location = new System.Drawing.Point(117, 43);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtCompanyName.Size = new System.Drawing.Size(248, 20);
            this.txtCompanyName.TabIndex = 102;
            this.txtCompanyName.ValidationRules = null;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Company Name";
            this.gridColumn2.FieldName = "CompanyName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn1});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Responsible Branch";
            this.gridColumn3.FieldName = "ResponsibleBranch";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // grid
            // 
            this.grid.Location = new System.Drawing.Point(8, 157);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(455, 338);
            this.grid.TabIndex = 108;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lkpFilterMarketing);
            this.groupBox1.Controls.Add(this.lkpFilterRespBranch);
            this.groupBox1.Controls.Add(this.lkpFilterCustomer);
            this.groupBox1.Controls.Add(this.grid);
            this.groupBox1.Controls.Add(this.btnNewContact);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFilterCompanyName);
            this.groupBox1.Controls.Add(this.txtFilterContactPerson);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 505);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "All Contacts";
            // 
            // lkpFilterMarketing
            // 
            this.lkpFilterMarketing.AutoCompleteDataManager = null;
            this.lkpFilterMarketing.AutoCompleteDisplayFormater = null;
            this.lkpFilterMarketing.AutoCompleteInitialized = false;
            this.lkpFilterMarketing.AutocompleteMinimumTextLength = 0;
            this.lkpFilterMarketing.AutoCompleteText = null;
            this.lkpFilterMarketing.AutoCompleteWhereExpression = null;
            this.lkpFilterMarketing.AutoCompleteWheretermFormater = null;
            this.lkpFilterMarketing.ClearOnLeave = true;
            this.lkpFilterMarketing.DisplayString = null;
            this.lkpFilterMarketing.FieldLabel = null;
            this.lkpFilterMarketing.Location = new System.Drawing.Point(97, 64);
            this.lkpFilterMarketing.LookupPopup = null;
            this.lkpFilterMarketing.Name = "lkpFilterMarketing";
            this.lkpFilterMarketing.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpFilterMarketing.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpFilterMarketing.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpFilterMarketing.Properties.AutoCompleteDataManager = null;
            this.lkpFilterMarketing.Properties.AutoCompleteDisplayFormater = null;
            this.lkpFilterMarketing.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpFilterMarketing.Properties.AutoCompleteText = null;
            this.lkpFilterMarketing.Properties.AutoCompleteWhereExpression = null;
            this.lkpFilterMarketing.Properties.AutoCompleteWheretermFormater = null;
            this.lkpFilterMarketing.Properties.AutoHeight = false;
            this.lkpFilterMarketing.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpFilterMarketing.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpFilterMarketing.Properties.LookupPopup = null;
            this.lkpFilterMarketing.Size = new System.Drawing.Size(288, 20);
            this.lkpFilterMarketing.TabIndex = 103;
            this.lkpFilterMarketing.ValidationRules = null;
            this.lkpFilterMarketing.Value = null;
            // 
            // lkpFilterRespBranch
            // 
            this.lkpFilterRespBranch.AutoCompleteDataManager = null;
            this.lkpFilterRespBranch.AutoCompleteDisplayFormater = null;
            this.lkpFilterRespBranch.AutoCompleteInitialized = false;
            this.lkpFilterRespBranch.AutocompleteMinimumTextLength = 0;
            this.lkpFilterRespBranch.AutoCompleteText = null;
            this.lkpFilterRespBranch.AutoCompleteWhereExpression = null;
            this.lkpFilterRespBranch.AutoCompleteWheretermFormater = null;
            this.lkpFilterRespBranch.ClearOnLeave = true;
            this.lkpFilterRespBranch.DisplayString = null;
            this.lkpFilterRespBranch.FieldLabel = null;
            this.lkpFilterRespBranch.Location = new System.Drawing.Point(97, 21);
            this.lkpFilterRespBranch.LookupPopup = null;
            this.lkpFilterRespBranch.Name = "lkpFilterRespBranch";
            this.lkpFilterRespBranch.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpFilterRespBranch.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpFilterRespBranch.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpFilterRespBranch.Properties.AutoCompleteDataManager = null;
            this.lkpFilterRespBranch.Properties.AutoCompleteDisplayFormater = null;
            this.lkpFilterRespBranch.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpFilterRespBranch.Properties.AutoCompleteText = null;
            this.lkpFilterRespBranch.Properties.AutoCompleteWhereExpression = null;
            this.lkpFilterRespBranch.Properties.AutoCompleteWheretermFormater = null;
            this.lkpFilterRespBranch.Properties.AutoHeight = false;
            this.lkpFilterRespBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpFilterRespBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpFilterRespBranch.Properties.LookupPopup = null;
            this.lkpFilterRespBranch.Size = new System.Drawing.Size(288, 20);
            this.lkpFilterRespBranch.TabIndex = 101;
            this.lkpFilterRespBranch.ValidationRules = null;
            this.lkpFilterRespBranch.Value = null;
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
            this.lkpFilterCustomer.Location = new System.Drawing.Point(97, 43);
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
            this.lkpFilterCustomer.Size = new System.Drawing.Size(288, 20);
            this.lkpFilterCustomer.TabIndex = 102;
            this.lkpFilterCustomer.ValidationRules = null;
            this.lkpFilterCustomer.Value = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 106;
            this.label1.Text = "Marketing";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 155);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 106;
            this.label12.Text = "Customer";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "gridColumn9";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.txtDate);
            this.grpDetail.Controls.Add(this.label16);
            this.grpDetail.Controls.Add(this.lkpMarketing);
            this.grpDetail.Controls.Add(this.lkpCustomer);
            this.grpDetail.Controls.Add(this.lkpRespBranch);
            this.grpDetail.Controls.Add(this.btnDelete);
            this.grpDetail.Controls.Add(this.btnSave);
            this.grpDetail.Controls.Add(this.txtContactEmail);
            this.grpDetail.Controls.Add(this.btnCopy);
            this.grpDetail.Controls.Add(this.txtContactPhone);
            this.grpDetail.Controls.Add(this.label11);
            this.grpDetail.Controls.Add(this.label10);
            this.grpDetail.Controls.Add(this.txtPhone);
            this.grpDetail.Controls.Add(this.label9);
            this.grpDetail.Controls.Add(this.label13);
            this.grpDetail.Controls.Add(this.txtCompanyName);
            this.grpDetail.Controls.Add(this.label2);
            this.grpDetail.Controls.Add(this.txtAddress);
            this.grpDetail.Controls.Add(this.txtContactPerson);
            this.grpDetail.Controls.Add(this.txtNote);
            this.grpDetail.Controls.Add(this.label1);
            this.grpDetail.Controls.Add(this.label7);
            this.grpDetail.Controls.Add(this.label12);
            this.grpDetail.Controls.Add(this.label5);
            this.grpDetail.Controls.Add(this.label6);
            this.grpDetail.ForeColor = System.Drawing.Color.Black;
            this.grpDetail.Location = new System.Drawing.Point(491, 12);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(381, 505);
            this.grpDetail.TabIndex = 52;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "Detail";
            // 
            // txtDate
            // 
            this.txtDate.EditValue = null;
            this.txtDate.FieldLabel = null;
            this.txtDate.FormatDateTime = "dd-MM-yyyy";
            this.txtDate.Location = new System.Drawing.Point(117, 21);
            this.txtDate.Name = "txtDate";
            this.txtDate.Nullable = false;
            this.txtDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDate.Properties.AutoHeight = false;
            this.txtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.txtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDate.Size = new System.Drawing.Size(138, 20);
            this.txtDate.TabIndex = 101;
            this.txtDate.ValidationRules = null;
            this.txtDate.Value = new System.DateTime(((long)(0)));
            // 
            // lkpMarketing
            // 
            this.lkpMarketing.AutoCompleteDataManager = null;
            this.lkpMarketing.AutoCompleteDisplayFormater = null;
            this.lkpMarketing.AutoCompleteInitialized = false;
            this.lkpMarketing.AutocompleteMinimumTextLength = 0;
            this.lkpMarketing.AutoCompleteText = null;
            this.lkpMarketing.AutoCompleteWhereExpression = null;
            this.lkpMarketing.AutoCompleteWheretermFormater = null;
            this.lkpMarketing.ClearOnLeave = true;
            this.lkpMarketing.DisplayString = null;
            this.lkpMarketing.FieldLabel = null;
            this.lkpMarketing.Location = new System.Drawing.Point(117, 174);
            this.lkpMarketing.LookupPopup = null;
            this.lkpMarketing.Name = "lkpMarketing";
            this.lkpMarketing.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpMarketing.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpMarketing.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpMarketing.Properties.AutoCompleteDataManager = null;
            this.lkpMarketing.Properties.AutoCompleteDisplayFormater = null;
            this.lkpMarketing.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpMarketing.Properties.AutoCompleteText = null;
            this.lkpMarketing.Properties.AutoCompleteWhereExpression = null;
            this.lkpMarketing.Properties.AutoCompleteWheretermFormater = null;
            this.lkpMarketing.Properties.AutoHeight = false;
            this.lkpMarketing.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpMarketing.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.lkpMarketing.Properties.LookupPopup = null;
            this.lkpMarketing.Size = new System.Drawing.Size(248, 20);
            this.lkpMarketing.TabIndex = 107;
            this.lkpMarketing.ValidationRules = null;
            this.lkpMarketing.Value = null;
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
            this.lkpCustomer.Location = new System.Drawing.Point(117, 152);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpCustomer.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "", null, null, true)});
            this.lkpCustomer.Properties.LookupPopup = null;
            this.lkpCustomer.Size = new System.Drawing.Size(248, 20);
            this.lkpCustomer.TabIndex = 106;
            this.lkpCustomer.ValidationRules = null;
            this.lkpCustomer.Value = null;
            // 
            // lkpRespBranch
            // 
            this.lkpRespBranch.AutoCompleteDataManager = null;
            this.lkpRespBranch.AutoCompleteDisplayFormater = null;
            this.lkpRespBranch.AutoCompleteInitialized = false;
            this.lkpRespBranch.AutocompleteMinimumTextLength = 0;
            this.lkpRespBranch.AutoCompleteText = null;
            this.lkpRespBranch.AutoCompleteWhereExpression = null;
            this.lkpRespBranch.AutoCompleteWheretermFormater = null;
            this.lkpRespBranch.ClearOnLeave = true;
            this.lkpRespBranch.DisplayString = null;
            this.lkpRespBranch.FieldLabel = null;
            this.lkpRespBranch.Location = new System.Drawing.Point(117, 130);
            this.lkpRespBranch.LookupPopup = null;
            this.lkpRespBranch.Name = "lkpRespBranch";
            this.lkpRespBranch.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpRespBranch.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpRespBranch.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpRespBranch.Properties.AutoCompleteDataManager = null;
            this.lkpRespBranch.Properties.AutoCompleteDisplayFormater = null;
            this.lkpRespBranch.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpRespBranch.Properties.AutoCompleteText = null;
            this.lkpRespBranch.Properties.AutoCompleteWhereExpression = null;
            this.lkpRespBranch.Properties.AutoCompleteWheretermFormater = null;
            this.lkpRespBranch.Properties.AutoHeight = false;
            this.lkpRespBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpRespBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "", null, null, true)});
            this.lkpRespBranch.Properties.LookupPopup = null;
            this.lkpRespBranch.Size = new System.Drawing.Size(248, 20);
            this.lkpRespBranch.TabIndex = 105;
            this.lkpRespBranch.ValidationRules = null;
            this.lkpRespBranch.Value = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "Company Name";
            // 
            // txtAddress
            // 
            this.txtAddress.Capslock = true;
            this.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddress.FieldLabel = null;
            this.txtAddress.Location = new System.Drawing.Point(117, 65);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtAddress.Size = new System.Drawing.Size(248, 20);
            this.txtAddress.TabIndex = 103;
            this.txtAddress.ValidationRules = null;
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Capslock = true;
            this.txtContactPerson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactPerson.FieldLabel = null;
            this.txtContactPerson.Location = new System.Drawing.Point(117, 215);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtContactPerson.Size = new System.Drawing.Size(136, 20);
            this.txtContactPerson.TabIndex = 108;
            this.txtContactPerson.ValidationRules = null;
            // 
            // txtNote
            // 
            this.txtNote.Capslock = true;
            this.txtNote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNote.FieldLabel = null;
            this.txtNote.Location = new System.Drawing.Point(117, 281);
            this.txtNote.Name = "txtNote";
            this.txtNote.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtNote.Size = new System.Drawing.Size(248, 20);
            this.txtNote.TabIndex = 111;
            this.txtNote.ValidationRules = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 106;
            this.label7.Text = "Office Ph. Number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 106;
            this.label5.Text = "Address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 106;
            this.label6.Text = "Responsible Branch";
            // 
            // ManageContactsForm
            // 
            this.ClientSize = new System.Drawing.Size(882, 527);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpDetail);
            this.Name = "ManageContactsForm";
            this.Text = "Manage Contacts";
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilterMarketing.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilterRespBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilterCustomer.Properties)).EndInit();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpMarketing.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpRespBranch.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.Button btnNewContact;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private SISCO.Presentation.Common.Component.dTextBox txtFilterContactPerson;
        private SISCO.Presentation.Common.Component.dTextBox txtContactEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCopy;
        private SISCO.Presentation.Common.Component.dTextBox txtContactPhone;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private SISCO.Presentation.Common.Component.dTextBox txtFilterCompanyName;
        private SISCO.Presentation.Common.Component.dTextBox txtPhone;
        private SISCO.Presentation.Common.Component.dTextBox txtCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.GridControl grid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Label label2;
        private SISCO.Presentation.Common.Component.dTextBox txtContactPerson;
        private SISCO.Presentation.Common.Component.dTextBox txtNote;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Common.Component.dLookup lkpFilterMarketing;
        private Common.Component.dLookup lkpFilterCustomer;
        private Common.Component.dLookup lkpRespBranch;
        private Common.Component.dLookup lkpFilterRespBranch;
        private Common.Component.dCalendar txtDate;
        private Common.Component.dLookup lkpMarketing;
        private Common.Component.dLookup lkpCustomer;
        private SISCO.Presentation.Common.Component.dTextBox txtAddress;
        
    }
}

