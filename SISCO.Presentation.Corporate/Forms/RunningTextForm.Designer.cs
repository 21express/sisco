namespace SISCO.Presentation.Corporate.Forms
{
    partial class RunningTextForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RunningTextForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.AnnGrid = new DevExpress.XtraGrid.GridControl();
            this.AnnView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.tbxAnnouncement = new SISCO.Presentation.Common.Component.dTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxTimeTo = new SISCO.Presentation.Common.Component.dTime();
            this.tbxDateTo = new SISCO.Presentation.Common.Component.dCalendar();
            this.tbxTimeFrom = new SISCO.Presentation.Common.Component.dTime();
            this.tbxDateFrom = new SISCO.Presentation.Common.Component.dCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.lkpCustomer = new SISCO.Presentation.Common.Component.dLookup();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AnnGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnView)).BeginInit();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTimeTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTimeFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Location = new System.Drawing.Point(12, 8);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 45);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "&New";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(93, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 45);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "&Save";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(174, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 45);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "&Delete";
            // 
            // AnnGrid
            // 
            this.AnnGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnnGrid.Location = new System.Drawing.Point(2, 265);
            this.AnnGrid.MainView = this.AnnView;
            this.AnnGrid.Name = "AnnGrid";
            this.AnnGrid.Size = new System.Drawing.Size(684, 233);
            this.AnnGrid.TabIndex = 14;
            this.AnnGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.AnnView});
            // 
            // AnnView
            // 
            this.AnnView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn9,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn10,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.AnnView.GridControl = this.AnnGrid;
            this.AnnView.Name = "AnnView";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "From Date";
            this.gridColumn2.DisplayFormat.FormatString = "d MMM yyyy";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "FromDate";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 76;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "From Hour";
            this.gridColumn3.FieldName = "FromHour";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 59;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "From Minute";
            this.gridColumn9.FieldName = "FromMinute";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.OptionsColumn.AllowMove = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            this.gridColumn9.Width = 68;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "To Date";
            this.gridColumn4.DisplayFormat.FormatString = "d MMM yyyy";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "ToDate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 73;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "To Hour";
            this.gridColumn5.FieldName = "ToHour";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.AllowMove = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 50;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "To Minute";
            this.gridColumn10.FieldName = "ToMinute";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.OptionsColumn.AllowMove = false;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 5;
            this.gridColumn10.Width = 55;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Announcement";
            this.gridColumn6.FieldName = "Name";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.AllowMove = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 183;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "gridColumn7";
            this.gridColumn7.FieldName = "CorporateId";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.AllowMove = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Customer";
            this.gridColumn8.FieldName = "CorporateName";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.OptionsColumn.AllowMove = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 102;
            // 
            // pnlForm
            // 
            this.pnlForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlForm.BackColor = System.Drawing.Color.Pink;
            this.pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlForm.Controls.Add(this.tbxAnnouncement);
            this.pnlForm.Controls.Add(this.label4);
            this.pnlForm.Controls.Add(this.label3);
            this.pnlForm.Controls.Add(this.tbxTimeTo);
            this.pnlForm.Controls.Add(this.tbxDateTo);
            this.pnlForm.Controls.Add(this.tbxTimeFrom);
            this.pnlForm.Controls.Add(this.tbxDateFrom);
            this.pnlForm.Controls.Add(this.label2);
            this.pnlForm.Controls.Add(this.lkpCustomer);
            this.pnlForm.Controls.Add(this.label1);
            this.pnlForm.Location = new System.Drawing.Point(2, 63);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(684, 196);
            this.pnlForm.TabIndex = 15;
            // 
            // tbxAnnouncement
            // 
            this.tbxAnnouncement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxAnnouncement.BackColor = System.Drawing.Color.White;
            this.tbxAnnouncement.Capslock = true;
            this.tbxAnnouncement.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxAnnouncement.FieldLabel = null;
            this.tbxAnnouncement.Location = new System.Drawing.Point(122, 95);
            this.tbxAnnouncement.Multiline = true;
            this.tbxAnnouncement.Name = "tbxAnnouncement";
            this.tbxAnnouncement.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxAnnouncement.Size = new System.Drawing.Size(536, 89);
            this.tbxAnnouncement.TabIndex = 20;
            this.tbxAnnouncement.ValidationRules = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Announcement";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Date To";
            // 
            // tbxTimeTo
            // 
            this.tbxTimeTo.EditValue = new System.DateTime(2015, 10, 28, 0, 0, 0, 0);
            this.tbxTimeTo.FieldLabel = null;
            this.tbxTimeTo.FormatDateTime = "hh:mm";
            this.tbxTimeTo.Location = new System.Drawing.Point(243, 60);
            this.tbxTimeTo.Name = "tbxTimeTo";
            this.tbxTimeTo.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTimeTo.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTimeTo.Properties.Appearance.Options.UseFont = true;
            this.tbxTimeTo.Properties.AutoHeight = false;
            this.tbxTimeTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxTimeTo.Properties.DisplayFormat.FormatString = "hh:mm";
            this.tbxTimeTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxTimeTo.Properties.EditFormat.FormatString = "hh:mm";
            this.tbxTimeTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxTimeTo.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxTimeTo.Properties.Mask.EditMask = "hh:mm";
            this.tbxTimeTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxTimeTo.Properties.NullText = "00:00";
            this.tbxTimeTo.Size = new System.Drawing.Size(59, 22);
            this.tbxTimeTo.TabIndex = 17;
            this.tbxTimeTo.ValidationRules = null;
            this.tbxTimeTo.Value = new System.DateTime(((long)(0)));
            // 
            // tbxDateTo
            // 
            this.tbxDateTo.EditValue = null;
            this.tbxDateTo.FieldLabel = null;
            this.tbxDateTo.FormatDateTime = "dd-MM-yyyy";
            this.tbxDateTo.Location = new System.Drawing.Point(122, 60);
            this.tbxDateTo.Name = "tbxDateTo";
            this.tbxDateTo.Nullable = false;
            this.tbxDateTo.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDateTo.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxDateTo.Properties.Appearance.Options.UseFont = true;
            this.tbxDateTo.Properties.AutoHeight = false;
            this.tbxDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxDateTo.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.tbxDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxDateTo.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxDateTo.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxDateTo.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxDateTo.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxDateTo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxDateTo.Size = new System.Drawing.Size(107, 22);
            this.tbxDateTo.TabIndex = 16;
            this.tbxDateTo.ValidationRules = null;
            this.tbxDateTo.Value = new System.DateTime(((long)(0)));
            // 
            // tbxTimeFrom
            // 
            this.tbxTimeFrom.EditValue = new System.DateTime(2015, 10, 28, 0, 0, 0, 0);
            this.tbxTimeFrom.FieldLabel = null;
            this.tbxTimeFrom.FormatDateTime = "hh:mm";
            this.tbxTimeFrom.Location = new System.Drawing.Point(243, 35);
            this.tbxTimeFrom.Name = "tbxTimeFrom";
            this.tbxTimeFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTimeFrom.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTimeFrom.Properties.Appearance.Options.UseFont = true;
            this.tbxTimeFrom.Properties.AutoHeight = false;
            this.tbxTimeFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxTimeFrom.Properties.DisplayFormat.FormatString = "hh:mm";
            this.tbxTimeFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxTimeFrom.Properties.EditFormat.FormatString = "hh:mm";
            this.tbxTimeFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxTimeFrom.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxTimeFrom.Properties.Mask.EditMask = "hh:mm";
            this.tbxTimeFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxTimeFrom.Properties.NullText = "00:00";
            this.tbxTimeFrom.Size = new System.Drawing.Size(59, 22);
            this.tbxTimeFrom.TabIndex = 15;
            this.tbxTimeFrom.ValidationRules = null;
            this.tbxTimeFrom.Value = new System.DateTime(((long)(0)));
            // 
            // tbxDateFrom
            // 
            this.tbxDateFrom.EditValue = null;
            this.tbxDateFrom.FieldLabel = null;
            this.tbxDateFrom.FormatDateTime = "dd-MM-yyyy";
            this.tbxDateFrom.Location = new System.Drawing.Point(122, 35);
            this.tbxDateFrom.Name = "tbxDateFrom";
            this.tbxDateFrom.Nullable = false;
            this.tbxDateFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDateFrom.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxDateFrom.Properties.Appearance.Options.UseFont = true;
            this.tbxDateFrom.Properties.AutoHeight = false;
            this.tbxDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxDateFrom.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxDateFrom.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxDateFrom.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxDateFrom.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxDateFrom.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxDateFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxDateFrom.Size = new System.Drawing.Size(107, 22);
            this.tbxDateFrom.TabIndex = 14;
            this.tbxDateFrom.ValidationRules = null;
            this.tbxDateFrom.Value = new System.DateTime(((long)(0)));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Date From";
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
            this.lkpCustomer.Location = new System.Drawing.Point(122, 10);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpFranchise.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.lkpCustomer.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpCustomer.Properties.LookupPopup = null;
            this.lkpCustomer.Properties.NullText = "<<Choose...>>";
            this.lkpCustomer.Size = new System.Drawing.Size(379, 22);
            this.lkpCustomer.TabIndex = 12;
            this.lkpCustomer.ValidationRules = null;
            this.lkpCustomer.Value = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Customer";
            // 
            // RunningTextForm
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 501);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.AnnGrid);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RunningTextForm";
            this.Text = "AnnouncementForm";
            ((System.ComponentModel.ISupportInitialize)(this.AnnGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnView)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTimeTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTimeFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraGrid.GridControl AnnGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView AnnView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private System.Windows.Forms.Panel pnlForm;
        private Common.Component.dTextBox tbxAnnouncement;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Common.Component.dTime tbxTimeTo;
        private Common.Component.dCalendar tbxDateTo;
        private Common.Component.dTime tbxTimeFrom;
        private Common.Component.dCalendar tbxDateFrom;
        private System.Windows.Forms.Label label2;
        private Common.Component.dLookup lkpCustomer;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
    }
}