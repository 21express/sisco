namespace SISCO.Presentation.MasterData.Forms
{
    partial class ManageAnnouncementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageAnnouncementForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnNew = new System.Windows.Forms.Button();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.lkpUserRole = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpUser = new SISCO.Presentation.Common.Component.dLookup();
            this.txtNote = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtEndTime = new SISCO.Presentation.Common.Component.dTime();
            this.txtStartTime = new SISCO.Presentation.Common.Component.dTime();
            this.txtEndDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.txtStartDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.grpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpUserRole.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(339, 19);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(127, 22);
            this.btnNew.TabIndex = 133;
            this.btnNew.Text = "New Announcement";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn1});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Start Date";
            this.gridColumn2.FieldName = "FromDate";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 57;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "End Date";
            this.gridColumn3.FieldName = "ToDate";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 54;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Start Time";
            this.gridColumn4.FieldName = "FromTime";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 55;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "End Time";
            this.gridColumn5.FieldName = "ToTime";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 50;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Note";
            this.gridColumn1.FieldName = "Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 221;
            // 
            // grid
            // 
            this.grid.Location = new System.Drawing.Point(11, 47);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(455, 320);
            this.grid.TabIndex = 126;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(199, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 134;
            this.label10.Text = "Time";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(198, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 134;
            this.label8.Text = "Time";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(194, 212);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(103, 37);
            this.btnDelete.TabIndex = 109;
            this.btnDelete.Text = "Delete Annoucement";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(89, 212);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 37);
            this.btnSave.TabIndex = 108;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(40, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 118;
            this.label9.Text = "Text";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(16, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 108;
            this.label7.Text = "End Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(13, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 118;
            this.label3.Text = "User Role";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(39, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 118;
            this.label2.Text = "User";
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.lkpUserRole);
            this.grpDetail.Controls.Add(this.lkpUser);
            this.grpDetail.Controls.Add(this.txtNote);
            this.grpDetail.Controls.Add(this.txtEndTime);
            this.grpDetail.Controls.Add(this.txtStartTime);
            this.grpDetail.Controls.Add(this.txtEndDate);
            this.grpDetail.Controls.Add(this.txtStartDate);
            this.grpDetail.Controls.Add(this.label10);
            this.grpDetail.Controls.Add(this.label8);
            this.grpDetail.Controls.Add(this.btnDelete);
            this.grpDetail.Controls.Add(this.btnSave);
            this.grpDetail.Controls.Add(this.label9);
            this.grpDetail.Controls.Add(this.label7);
            this.grpDetail.Controls.Add(this.label1);
            this.grpDetail.Controls.Add(this.label3);
            this.grpDetail.Controls.Add(this.label2);
            this.grpDetail.ForeColor = System.Drawing.Color.Black;
            this.grpDetail.Location = new System.Drawing.Point(499, 12);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(385, 297);
            this.grpDetail.TabIndex = 129;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "Detail";
            // 
            // lkpUserRole
            // 
            this.lkpUserRole.AutoCompleteDataManager = null;
            this.lkpUserRole.AutoCompleteDisplayFormater = null;
            this.lkpUserRole.AutoCompleteInitialized = false;
            this.lkpUserRole.AutocompleteMinimumTextLength = 0;
            this.lkpUserRole.AutoCompleteText = null;
            this.lkpUserRole.AutoCompleteWhereExpression = null;
            this.lkpUserRole.AutoCompleteWheretermFormater = null;
            this.lkpUserRole.ClearOnLeave = true;
            this.lkpUserRole.DisplayString = null;
            this.lkpUserRole.EditValue = "";
            this.lkpUserRole.FieldLabel = null;
            this.lkpUserRole.Location = new System.Drawing.Point(74, 144);
            this.lkpUserRole.LookupPopup = null;
            this.lkpUserRole.Name = "lkpUserRole";
            this.lkpUserRole.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpUserRole.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpUserRole.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpUserRole.Properties.AutoCompleteDataManager = null;
            this.lkpUserRole.Properties.AutoCompleteDisplayFormater = null;
            this.lkpUserRole.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpUserRole.Properties.AutoCompleteText = null;
            this.lkpUserRole.Properties.AutoCompleteWhereExpression = null;
            this.lkpUserRole.Properties.AutoCompleteWheretermFormater = null;
            this.lkpUserRole.Properties.AutoHeight = false;
            this.lkpUserRole.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpUserRole.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpUserRole.Properties.LookupPopup = null;
            this.lkpUserRole.Properties.NullText = "<<Choose...>>";
            this.lkpUserRole.Size = new System.Drawing.Size(208, 20);
            this.lkpUserRole.TabIndex = 107;
            this.lkpUserRole.ValidationRules = null;
            this.lkpUserRole.Value = null;
            // 
            // lkpUser
            // 
            this.lkpUser.AutoCompleteDataManager = null;
            this.lkpUser.AutoCompleteDisplayFormater = null;
            this.lkpUser.AutoCompleteInitialized = false;
            this.lkpUser.AutocompleteMinimumTextLength = 0;
            this.lkpUser.AutoCompleteText = null;
            this.lkpUser.AutoCompleteWhereExpression = null;
            this.lkpUser.AutoCompleteWheretermFormater = null;
            this.lkpUser.ClearOnLeave = true;
            this.lkpUser.DisplayString = null;
            this.lkpUser.EditValue = "";
            this.lkpUser.FieldLabel = null;
            this.lkpUser.Location = new System.Drawing.Point(74, 122);
            this.lkpUser.LookupPopup = null;
            this.lkpUser.Name = "lkpUser";
            this.lkpUser.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpUser.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpUser.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpUser.Properties.AutoCompleteDataManager = null;
            this.lkpUser.Properties.AutoCompleteDisplayFormater = null;
            this.lkpUser.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpUser.Properties.AutoCompleteText = null;
            this.lkpUser.Properties.AutoCompleteWhereExpression = null;
            this.lkpUser.Properties.AutoCompleteWheretermFormater = null;
            this.lkpUser.Properties.AutoHeight = false;
            this.lkpUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpUser.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpUser.Properties.LookupPopup = null;
            this.lkpUser.Properties.NullText = "<<Choose...>>";
            this.lkpUser.Size = new System.Drawing.Size(208, 20);
            this.lkpUser.TabIndex = 106;
            this.lkpUser.ValidationRules = null;
            this.lkpUser.Value = null;
            // 
            // txtNote
            // 
            this.txtNote.Capslock = true;
            this.txtNote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNote.FieldLabel = null;
            this.txtNote.Location = new System.Drawing.Point(74, 81);
            this.txtNote.Name = "txtNote";
            this.txtNote.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtNote.Size = new System.Drawing.Size(294, 20);
            this.txtNote.TabIndex = 105;
            this.txtNote.ValidationRules = null;
            // 
            // txtEndTime
            // 
            this.txtEndTime.EditValue = new System.DateTime(2014, 8, 27, 0, 0, 0, 0);
            this.txtEndTime.FieldLabel = null;
            this.txtEndTime.FormatDateTime = "hh:mm";
            this.txtEndTime.Location = new System.Drawing.Point(235, 47);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtEndTime.Properties.AutoHeight = false;
            this.txtEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtEndTime.Properties.DisplayFormat.FormatString = "hh:mm";
            this.txtEndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtEndTime.Properties.EditFormat.FormatString = "hh:mm";
            this.txtEndTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtEndTime.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtEndTime.Properties.Mask.EditMask = "hh:mm";
            this.txtEndTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtEndTime.Properties.NullText = "00:00";
            this.txtEndTime.Size = new System.Drawing.Size(63, 20);
            this.txtEndTime.TabIndex = 104;
            this.txtEndTime.ValidationRules = null;
            this.txtEndTime.Value = new System.DateTime(((long)(0)));
            // 
            // txtStartTime
            // 
            this.txtStartTime.EditValue = new System.DateTime(2014, 8, 27, 0, 0, 0, 0);
            this.txtStartTime.FieldLabel = null;
            this.txtStartTime.FormatDateTime = "hh:mm";
            this.txtStartTime.Location = new System.Drawing.Point(234, 25);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtStartTime.Properties.AutoHeight = false;
            this.txtStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtStartTime.Properties.DisplayFormat.FormatString = "hh:mm";
            this.txtStartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtStartTime.Properties.EditFormat.FormatString = "hh:mm";
            this.txtStartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtStartTime.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtStartTime.Properties.Mask.EditMask = "hh:mm";
            this.txtStartTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtStartTime.Properties.NullText = "00:00";
            this.txtStartTime.Size = new System.Drawing.Size(63, 20);
            this.txtStartTime.TabIndex = 102;
            this.txtStartTime.ValidationRules = null;
            this.txtStartTime.Value = new System.DateTime(((long)(0)));
            // 
            // txtEndDate
            // 
            this.txtEndDate.EditValue = null;
            this.txtEndDate.FieldLabel = null;
            this.txtEndDate.FormatDateTime = "dd-MM-yyyy";
            this.txtEndDate.Location = new System.Drawing.Point(74, 47);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Nullable = false;
            this.txtEndDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtEndDate.Properties.AutoHeight = false;
            this.txtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtEndDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.txtEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtEndDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtEndDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtEndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtEndDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtEndDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtEndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtEndDate.Properties.NullText = "<<Choose...>>";
            this.txtEndDate.Size = new System.Drawing.Size(118, 20);
            this.txtEndDate.TabIndex = 103;
            this.txtEndDate.ValidationRules = null;
            this.txtEndDate.Value = new System.DateTime(((long)(0)));
            // 
            // txtStartDate
            // 
            this.txtStartDate.EditValue = null;
            this.txtStartDate.FieldLabel = null;
            this.txtStartDate.FormatDateTime = "dd-MM-yyyy";
            this.txtStartDate.Location = new System.Drawing.Point(74, 25);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Nullable = false;
            this.txtStartDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtStartDate.Properties.AutoHeight = false;
            this.txtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtStartDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.txtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtStartDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtStartDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtStartDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtStartDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtStartDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtStartDate.Properties.NullText = "<<Choose...>>";
            this.txtStartDate.Size = new System.Drawing.Size(118, 20);
            this.txtStartDate.TabIndex = 101;
            this.txtStartDate.ValidationRules = null;
            this.txtStartDate.Value = new System.DateTime(((long)(0)));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 108;
            this.label1.Text = "Start Date";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.grid);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(481, 376);
            this.groupBox2.TabIndex = 130;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "All Announcements";
            // 
            // ManageAnnouncementForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(897, 398);
            this.Controls.Add(this.grpDetail);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ManageAnnouncementForm";
            this.Text = "Master Announcement";
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpUserRole.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.GridControl grid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Common.Component.dTime txtEndTime;
        private Common.Component.dTime txtStartTime;
        private Common.Component.dCalendar txtEndDate;
        private Common.Component.dCalendar txtStartDate;
        private Common.Component.dTextBox txtNote;
        private Common.Component.dLookup lkpUserRole;
        private Common.Component.dLookup lkpUser;
    }
}