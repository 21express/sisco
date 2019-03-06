using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;

namespace SISCO.Presentation.Marketing.Forms
{
    partial class ManageLeadsForm
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageLeadsForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridFollowUpView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnVdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMarketing = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookUpFollowUpStatusRepo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridFollowUp = new DevExpress.XtraGrid.GridControl();
            this.label16 = new System.Windows.Forms.Label();
            this.rdoIsContact = new System.Windows.Forms.RadioButton();
            this.rdoIsRegisteredCustomer = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFilterLastFollowUp = new SISCO.Presentation.Common.Component.dCalendar();
            this.txtFilterLeadDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.lkpFilterMarketing = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpFilterContact = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpFilterCustomer = new SISCO.Presentation.Common.Component.dLookup();
            this.label5 = new System.Windows.Forms.Label();
            this.btnNewLead = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtContactEmail = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtContactPhone = new SISCO.Presentation.Common.Component.dTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtContactPerson = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtNote = new SISCO.Presentation.Common.Component.dTextBox();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtLeadDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.lkpContact = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpCustomer = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpMarketing = new SISCO.Presentation.Common.Component.dLookup();
            this.label10 = new System.Windows.Forms.Label();
            this.txtId = new SISCO.Presentation.Common.Component.dTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridFollowUpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpFollowUpStatusRepo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFollowUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterLastFollowUp.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterLastFollowUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterLeadDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterLeadDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilterMarketing.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilterContact.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilterCustomer.Properties)).BeginInit();
            this.grpDetail.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeadDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeadDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpContact.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpMarketing.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridFollowUpView
            // 
            this.gridFollowUpView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnVdate,
            this.gridColumnNote,
            this.gridColumnMarketing,
            this.gridColumn});
            this.gridFollowUpView.GridControl = this.gridFollowUp;
            this.gridFollowUpView.Name = "gridFollowUpView";
            this.gridFollowUpView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridFollowUpView.OptionsEditForm.EditFormColumnCount = 1;
            this.gridFollowUpView.OptionsEditForm.PopupEditFormWidth = 300;
            this.gridFollowUpView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridFollowUpView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnVdate
            // 
            this.gridColumnVdate.Caption = "Date";
            this.gridColumnVdate.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.gridColumnVdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnVdate.FieldName = "Vdate";
            this.gridColumnVdate.Name = "gridColumnVdate";
            this.gridColumnVdate.OptionsColumn.AllowEdit = false;
            this.gridColumnVdate.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnVdate.Visible = true;
            this.gridColumnVdate.VisibleIndex = 0;
            this.gridColumnVdate.Width = 64;
            // 
            // gridColumnNote
            // 
            this.gridColumnNote.Caption = "Follow up";
            this.gridColumnNote.FieldName = "Note";
            this.gridColumnNote.Name = "gridColumnNote";
            this.gridColumnNote.Visible = true;
            this.gridColumnNote.VisibleIndex = 2;
            this.gridColumnNote.Width = 132;
            // 
            // gridColumnMarketing
            // 
            this.gridColumnMarketing.Caption = "Marketing";
            this.gridColumnMarketing.FieldName = "Marketing";
            this.gridColumnMarketing.Name = "gridColumnMarketing";
            this.gridColumnMarketing.OptionsColumn.AllowEdit = false;
            this.gridColumnMarketing.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnMarketing.Visible = true;
            this.gridColumnMarketing.VisibleIndex = 1;
            this.gridColumnMarketing.Width = 77;
            // 
            // gridColumn
            // 
            this.gridColumn.Caption = "Status";
            this.gridColumn.ColumnEdit = this.lookUpFollowUpStatusRepo;
            this.gridColumn.FieldName = "LeadStatusId";
            this.gridColumn.Name = "gridColumn";
            this.gridColumn.Visible = true;
            this.gridColumn.VisibleIndex = 3;
            this.gridColumn.Width = 69;
            // 
            // lookUpFollowUpStatusRepo
            // 
            this.lookUpFollowUpStatusRepo.AutoHeight = false;
            this.lookUpFollowUpStatusRepo.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.lookUpFollowUpStatusRepo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpFollowUpStatusRepo.Name = "lookUpFollowUpStatusRepo";
            // 
            // gridFollowUp
            // 
            this.gridFollowUp.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridFollowUp.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridFollowUp.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridFollowUp.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gridFollowUp.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gridFollowUp.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.gridFollowUp.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gridFollowUp.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.gridFollowUp.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gridFollowUp.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.gridFollowUp.Location = new System.Drawing.Point(0, 21);
            this.gridFollowUp.MainView = this.gridFollowUpView;
            this.gridFollowUp.Name = "gridFollowUp";
            this.gridFollowUp.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookUpFollowUpStatusRepo});
            this.gridFollowUp.Size = new System.Drawing.Size(360, 162);
            this.gridFollowUp.TabIndex = 112;
            this.gridFollowUp.UseEmbeddedNavigator = true;
            this.gridFollowUp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridFollowUpView});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(14, 46);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 13);
            this.label16.TabIndex = 139;
            this.label16.Text = "Lead Date";
            // 
            // rdoIsContact
            // 
            this.rdoIsContact.AutoSize = true;
            this.rdoIsContact.Location = new System.Drawing.Point(259, 102);
            this.rdoIsContact.Name = "rdoIsContact";
            this.rdoIsContact.Size = new System.Drawing.Size(62, 17);
            this.rdoIsContact.TabIndex = 105;
            this.rdoIsContact.Text = "Contact";
            this.rdoIsContact.UseVisualStyleBackColor = true;
            // 
            // rdoIsRegisteredCustomer
            // 
            this.rdoIsRegisteredCustomer.AutoSize = true;
            this.rdoIsRegisteredCustomer.Checked = true;
            this.rdoIsRegisteredCustomer.Location = new System.Drawing.Point(118, 102);
            this.rdoIsRegisteredCustomer.Name = "rdoIsRegisteredCustomer";
            this.rdoIsRegisteredCustomer.Size = new System.Drawing.Size(123, 17);
            this.rdoIsRegisteredCustomer.TabIndex = 104;
            this.rdoIsRegisteredCustomer.TabStop = true;
            this.rdoIsRegisteredCustomer.Text = "Registered Customer";
            this.rdoIsRegisteredCustomer.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 144;
            this.label4.Text = "Follow-ups";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 107;
            this.label2.Text = "ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 106;
            this.label6.Text = "Contact";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 106;
            this.label12.Text = "Customer";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Lead Date";
            this.gridColumn4.FieldName = "Vdate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 57;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Company Name";
            this.gridColumn2.FieldName = "Company";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 106;
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn2,
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
            // gridColumn7
            // 
            this.gridColumn7.Caption = "ID";
            this.gridColumn7.FieldName = "Id";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 42;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Last Follow Up";
            this.gridColumn5.FieldName = "LastFollowUpDate";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 65;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Last Status";
            this.gridColumn6.FieldName = "LastLeadStatus";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 68;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Marketing";
            this.gridColumn1.FieldName = "Marketing";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            this.gridColumn1.Width = 99;
            // 
            // grid
            // 
            gridLevelNode1.RelationName = "Level1";
            this.grid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grid.Location = new System.Drawing.Point(8, 152);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(455, 360);
            this.grid.TabIndex = 108;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFilterLastFollowUp);
            this.groupBox1.Controls.Add(this.txtFilterLeadDate);
            this.groupBox1.Controls.Add(this.lkpFilterMarketing);
            this.groupBox1.Controls.Add(this.lkpFilterContact);
            this.groupBox1.Controls.Add(this.lkpFilterCustomer);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.grid);
            this.groupBox1.Controls.Add(this.btnNewLead);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 541);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "All Leads";
            // 
            // txtFilterLastFollowUp
            // 
            this.txtFilterLastFollowUp.EditValue = null;
            this.txtFilterLastFollowUp.FieldLabel = null;
            this.txtFilterLastFollowUp.FormatDateTime = "dd-MM-yyyy";
            this.txtFilterLastFollowUp.Location = new System.Drawing.Point(95, 123);
            this.txtFilterLastFollowUp.Name = "txtFilterLastFollowUp";
            this.txtFilterLastFollowUp.Nullable = false;
            this.txtFilterLastFollowUp.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtFilterLastFollowUp.Properties.AutoHeight = false;
            this.txtFilterLastFollowUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtFilterLastFollowUp.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtFilterLastFollowUp.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFilterLastFollowUp.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtFilterLastFollowUp.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFilterLastFollowUp.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtFilterLastFollowUp.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFilterLastFollowUp.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtFilterLastFollowUp.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtFilterLastFollowUp.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtFilterLastFollowUp.Size = new System.Drawing.Size(156, 20);
            this.txtFilterLastFollowUp.TabIndex = 105;
            this.txtFilterLastFollowUp.ValidationRules = null;
            this.txtFilterLastFollowUp.Value = new System.DateTime(((long)(0)));
            // 
            // txtFilterLeadDate
            // 
            this.txtFilterLeadDate.EditValue = null;
            this.txtFilterLeadDate.FieldLabel = null;
            this.txtFilterLeadDate.FormatDateTime = "dd-MM-yyyy";
            this.txtFilterLeadDate.Location = new System.Drawing.Point(95, 101);
            this.txtFilterLeadDate.Name = "txtFilterLeadDate";
            this.txtFilterLeadDate.Nullable = false;
            this.txtFilterLeadDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtFilterLeadDate.Properties.AutoHeight = false;
            this.txtFilterLeadDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtFilterLeadDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.txtFilterLeadDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFilterLeadDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtFilterLeadDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFilterLeadDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtFilterLeadDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFilterLeadDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtFilterLeadDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtFilterLeadDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtFilterLeadDate.Size = new System.Drawing.Size(156, 20);
            this.txtFilterLeadDate.TabIndex = 104;
            this.txtFilterLeadDate.ValidationRules = null;
            this.txtFilterLeadDate.Value = new System.DateTime(((long)(0)));
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
            this.lkpFilterMarketing.Location = new System.Drawing.Point(95, 65);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpFilterMarketing.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.lkpFilterMarketing.Properties.LookupPopup = null;
            this.lkpFilterMarketing.Properties.NullText = "<<Choose...>>";
            this.lkpFilterMarketing.Size = new System.Drawing.Size(288, 20);
            this.lkpFilterMarketing.TabIndex = 103;
            this.lkpFilterMarketing.ValidationRules = null;
            this.lkpFilterMarketing.Value = null;
            // 
            // lkpFilterContact
            // 
            this.lkpFilterContact.AutoCompleteDataManager = null;
            this.lkpFilterContact.AutoCompleteDisplayFormater = null;
            this.lkpFilterContact.AutoCompleteInitialized = false;
            this.lkpFilterContact.AutocompleteMinimumTextLength = 0;
            this.lkpFilterContact.AutoCompleteText = null;
            this.lkpFilterContact.AutoCompleteWhereExpression = null;
            this.lkpFilterContact.AutoCompleteWheretermFormater = null;
            this.lkpFilterContact.ClearOnLeave = true;
            this.lkpFilterContact.DisplayString = null;
            this.lkpFilterContact.FieldLabel = null;
            this.lkpFilterContact.Location = new System.Drawing.Point(95, 43);
            this.lkpFilterContact.LookupPopup = null;
            this.lkpFilterContact.Name = "lkpFilterContact";
            this.lkpFilterContact.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpFilterContact.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpFilterContact.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpFilterContact.Properties.AutoCompleteDataManager = null;
            this.lkpFilterContact.Properties.AutoCompleteDisplayFormater = null;
            this.lkpFilterContact.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpFilterContact.Properties.AutoCompleteText = null;
            this.lkpFilterContact.Properties.AutoCompleteWhereExpression = null;
            this.lkpFilterContact.Properties.AutoCompleteWheretermFormater = null;
            this.lkpFilterContact.Properties.AutoHeight = false;
            this.lkpFilterContact.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpFilterContact.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.lkpFilterContact.Properties.LookupPopup = null;
            this.lkpFilterContact.Properties.NullText = "<<Choose...>>";
            this.lkpFilterContact.Size = new System.Drawing.Size(288, 20);
            this.lkpFilterContact.TabIndex = 102;
            this.lkpFilterContact.ValidationRules = null;
            this.lkpFilterContact.Value = null;
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
            this.lkpFilterCustomer.Location = new System.Drawing.Point(95, 21);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpFilterCustomer.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.lkpFilterCustomer.Properties.LookupPopup = null;
            this.lkpFilterCustomer.Properties.NullText = "<<Choose...>>";
            this.lkpFilterCustomer.Size = new System.Drawing.Size(288, 20);
            this.lkpFilterCustomer.TabIndex = 101;
            this.lkpFilterCustomer.ValidationRules = null;
            this.lkpFilterCustomer.Value = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(9, 517);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 144;
            this.label5.Text = "Open Leads";
            // 
            // btnNewLead
            // 
            this.btnNewLead.Image = global::SISCO.Presentation.Marketing.Properties.Resources.icon_add_small;
            this.btnNewLead.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewLead.Location = new System.Drawing.Point(354, 121);
            this.btnNewLead.Name = "btnNewLead";
            this.btnNewLead.Size = new System.Drawing.Size(107, 22);
            this.btnNewLead.TabIndex = 107;
            this.btnNewLead.Text = "New Lead";
            this.btnNewLead.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewLead.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::SISCO.Presentation.Marketing.Properties.Resources.icon_search_small;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(277, 121);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(68, 22);
            this.btnSearch.TabIndex = 106;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(9, 68);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 13);
            this.label15.TabIndex = 138;
            this.label15.Text = "Marketing";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 138;
            this.label7.Text = "Contact";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(9, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 13);
            this.label14.TabIndex = 138;
            this.label14.Text = "Customer";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 134;
            this.label8.Text = "Lead Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 135;
            this.label3.Text = "Last Follow Up";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "gridColumn9";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::SISCO.Presentation.Marketing.Properties.Resources.icon_save_small;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(293, 500);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 30);
            this.btnSave.TabIndex = 113;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 174);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 13);
            this.label13.TabIndex = 107;
            this.label13.Text = "Contact Person";
            // 
            // txtContactEmail
            // 
            this.txtContactEmail.Capslock = true;
            this.txtContactEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactEmail.FieldLabel = null;
            this.txtContactEmail.Location = new System.Drawing.Point(116, 215);
            this.txtContactEmail.Name = "txtContactEmail";
            this.txtContactEmail.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtContactEmail.Size = new System.Drawing.Size(246, 20);
            this.txtContactEmail.TabIndex = 110;
            this.txtContactEmail.ValidationRules = null;
            // 
            // txtContactPhone
            // 
            this.txtContactPhone.Capslock = true;
            this.txtContactPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactPhone.FieldLabel = null;
            this.txtContactPhone.Location = new System.Drawing.Point(116, 193);
            this.txtContactPhone.Name = "txtContactPhone";
            this.txtContactPhone.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtContactPhone.Size = new System.Drawing.Size(136, 20);
            this.txtContactPhone.TabIndex = 109;
            this.txtContactPhone.ValidationRules = null;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 244);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 106;
            this.label11.Text = "Note";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 196);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 106;
            this.label9.Text = "Contact Ph. Number";
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Capslock = true;
            this.txtContactPerson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactPerson.FieldLabel = null;
            this.txtContactPerson.Location = new System.Drawing.Point(116, 171);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtContactPerson.Size = new System.Drawing.Size(246, 20);
            this.txtContactPerson.TabIndex = 108;
            this.txtContactPerson.ValidationRules = null;
            // 
            // txtNote
            // 
            this.txtNote.Capslock = true;
            this.txtNote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNote.FieldLabel = null;
            this.txtNote.Location = new System.Drawing.Point(116, 241);
            this.txtNote.Name = "txtNote";
            this.txtNote.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtNote.Size = new System.Drawing.Size(248, 20);
            this.txtNote.TabIndex = 111;
            this.txtNote.ValidationRules = null;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "gridColumn8";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 106;
            this.label1.Text = "Marketing";
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.panel1);
            this.grpDetail.Controls.Add(this.txtLeadDate);
            this.grpDetail.Controls.Add(this.lkpContact);
            this.grpDetail.Controls.Add(this.lkpCustomer);
            this.grpDetail.Controls.Add(this.lkpMarketing);
            this.grpDetail.Controls.Add(this.label16);
            this.grpDetail.Controls.Add(this.rdoIsContact);
            this.grpDetail.Controls.Add(this.rdoIsRegisteredCustomer);
            this.grpDetail.Controls.Add(this.btnSave);
            this.grpDetail.Controls.Add(this.txtContactEmail);
            this.grpDetail.Controls.Add(this.txtContactPhone);
            this.grpDetail.Controls.Add(this.label11);
            this.grpDetail.Controls.Add(this.label10);
            this.grpDetail.Controls.Add(this.label9);
            this.grpDetail.Controls.Add(this.label2);
            this.grpDetail.Controls.Add(this.label13);
            this.grpDetail.Controls.Add(this.txtId);
            this.grpDetail.Controls.Add(this.txtContactPerson);
            this.grpDetail.Controls.Add(this.txtNote);
            this.grpDetail.Controls.Add(this.label1);
            this.grpDetail.Controls.Add(this.label6);
            this.grpDetail.Controls.Add(this.label12);
            this.grpDetail.ForeColor = System.Drawing.Color.Black;
            this.grpDetail.Location = new System.Drawing.Point(491, 12);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(381, 541);
            this.grpDetail.TabIndex = 52;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "Detail";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.gridFollowUp);
            this.panel1.Location = new System.Drawing.Point(10, 311);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 183);
            this.panel1.TabIndex = 144;
            // 
            // txtLeadDate
            // 
            this.txtLeadDate.EditValue = null;
            this.txtLeadDate.FieldLabel = null;
            this.txtLeadDate.FormatDateTime = "dd-MM-yyyy";
            this.txtLeadDate.Location = new System.Drawing.Point(118, 43);
            this.txtLeadDate.Name = "txtLeadDate";
            this.txtLeadDate.Nullable = false;
            this.txtLeadDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtLeadDate.Properties.AutoHeight = false;
            this.txtLeadDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtLeadDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "", null, null, true)});
            this.txtLeadDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtLeadDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtLeadDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtLeadDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtLeadDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtLeadDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtLeadDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtLeadDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtLeadDate.Size = new System.Drawing.Size(156, 20);
            this.txtLeadDate.TabIndex = 102;
            this.txtLeadDate.ValidationRules = null;
            this.txtLeadDate.Value = new System.DateTime(((long)(0)));
            // 
            // lkpContact
            // 
            this.lkpContact.AutoCompleteDataManager = null;
            this.lkpContact.AutoCompleteDisplayFormater = null;
            this.lkpContact.AutoCompleteInitialized = false;
            this.lkpContact.AutocompleteMinimumTextLength = 0;
            this.lkpContact.AutoCompleteText = null;
            this.lkpContact.AutoCompleteWhereExpression = null;
            this.lkpContact.AutoCompleteWheretermFormater = null;
            this.lkpContact.ClearOnLeave = true;
            this.lkpContact.DisplayString = null;
            this.lkpContact.FieldLabel = null;
            this.lkpContact.Location = new System.Drawing.Point(116, 149);
            this.lkpContact.LookupPopup = null;
            this.lkpContact.Name = "lkpContact";
            this.lkpContact.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpContact.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpContact.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpContact.Properties.AutoCompleteDataManager = null;
            this.lkpContact.Properties.AutoCompleteDisplayFormater = null;
            this.lkpContact.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpContact.Properties.AutoCompleteText = null;
            this.lkpContact.Properties.AutoCompleteWhereExpression = null;
            this.lkpContact.Properties.AutoCompleteWheretermFormater = null;
            this.lkpContact.Properties.AutoHeight = false;
            this.lkpContact.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpContact.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "", null, null, true)});
            this.lkpContact.Properties.LookupPopup = null;
            this.lkpContact.Properties.NullText = "<<Choose...>>";
            this.lkpContact.Size = new System.Drawing.Size(246, 20);
            this.lkpContact.TabIndex = 107;
            this.lkpContact.ValidationRules = null;
            this.lkpContact.Value = null;
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
            this.lkpCustomer.Location = new System.Drawing.Point(116, 127);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpCustomer.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, "", null, null, true)});
            this.lkpCustomer.Properties.LookupPopup = null;
            this.lkpCustomer.Properties.NullText = "<<Choose...>>";
            this.lkpCustomer.Size = new System.Drawing.Size(246, 20);
            this.lkpCustomer.TabIndex = 106;
            this.lkpCustomer.ValidationRules = null;
            this.lkpCustomer.Value = null;
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
            this.lkpMarketing.Location = new System.Drawing.Point(118, 65);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpMarketing.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, "", null, null, true)});
            this.lkpMarketing.Properties.LookupPopup = null;
            this.lkpMarketing.Properties.NullText = "<<Choose...>>";
            this.lkpMarketing.Size = new System.Drawing.Size(246, 20);
            this.lkpMarketing.TabIndex = 103;
            this.lkpMarketing.ValidationRules = null;
            this.lkpMarketing.Value = null;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 218);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 106;
            this.label10.Text = "Contact Email";
            // 
            // txtId
            // 
            this.txtId.Capslock = true;
            this.txtId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId.FieldLabel = null;
            this.txtId.Location = new System.Drawing.Point(118, 21);
            this.txtId.Name = "txtId";
            this.txtId.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtId.Size = new System.Drawing.Size(136, 20);
            this.txtId.TabIndex = 101;
            this.txtId.ValidationRules = null;
            // 
            // ManageLeadsForm
            // 
            this.ClientSize = new System.Drawing.Size(882, 563);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpDetail);
            this.Name = "ManageLeadsForm";
            this.Text = "Manage Leads";
            ((System.ComponentModel.ISupportInitialize)(this.gridFollowUpView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpFollowUpStatusRepo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFollowUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterLastFollowUp.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterLastFollowUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterLeadDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterLeadDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilterMarketing.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilterContact.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilterCustomer.Properties)).EndInit();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeadDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeadDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpContact.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpMarketing.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridFollowUpView;
        private DevExpress.XtraGrid.GridControl gridFollowUp;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RadioButton rdoIsContact;
        private System.Windows.Forms.RadioButton rdoIsRegisteredCustomer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.GridControl grid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnNewLead;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label13;
        private SISCO.Presentation.Common.Component.dTextBox txtContactEmail;
        private SISCO.Presentation.Common.Component.dTextBox txtContactPhone;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private SISCO.Presentation.Common.Component.dTextBox txtContactPerson;
        private Common.Component.dTextBox txtNote;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private Common.Component.dLookup lkpContact;
        private Common.Component.dLookup lkpCustomer;
        private Common.Component.dLookup lkpMarketing;
        private SISCO.Presentation.Common.Component.dTextBox txtId;
        private Common.Component.dCalendar txtFilterLastFollowUp;
        private Common.Component.dCalendar txtFilterLeadDate;
        private Common.Component.dLookup lkpFilterMarketing;
        private Common.Component.dLookup lkpFilterContact;
        private Common.Component.dLookup lkpFilterCustomer;
        private Common.Component.dCalendar txtLeadDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnVdate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnNote;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMarketing;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookUpFollowUpStatusRepo;
        
    }
}

