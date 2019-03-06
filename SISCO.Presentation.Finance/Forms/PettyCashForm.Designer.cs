namespace SISCO.Presentation.Finance.Forms
{
    partial class PettyCashForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PettyCashForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxDescription = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tbxBalance = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.GridJournal = new DevExpress.XtraGrid.GridControl();
            this.JournalView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tbxDebit = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.lkpEmployee = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxCredit = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxBalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridJournal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JournalView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDebit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCredit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Maksud / Tujuan Petty Cash";
            // 
            // tbxDescription
            // 
            this.tbxDescription.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxDescription.Capslock = true;
            this.tbxDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDescription.FieldLabel = null;
            this.tbxDescription.Location = new System.Drawing.Point(183, 45);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDescription.Size = new System.Drawing.Size(279, 24);
            this.tbxDescription.TabIndex = 1;
            this.tbxDescription.ValidationRules = null;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.tbxBalance);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.GridJournal);
            this.groupControl1.Location = new System.Drawing.Point(2, 135);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(775, 286);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Petty Cash Journal";
            // 
            // tbxBalance
            // 
            this.tbxBalance.EditMask = "###,###,###,###,###,##0.00";
            this.tbxBalance.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxBalance.Enabled = false;
            this.tbxBalance.FieldLabel = null;
            this.tbxBalance.Location = new System.Drawing.Point(619, 258);
            this.tbxBalance.Name = "tbxBalance";
            this.tbxBalance.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxBalance.Properties.AllowMouseWheel = false;
            this.tbxBalance.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.tbxBalance.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxBalance.Properties.Appearance.Options.UseBackColor = true;
            this.tbxBalance.Properties.Appearance.Options.UseFont = true;
            this.tbxBalance.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxBalance.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxBalance.Properties.Mask.BeepOnError = true;
            this.tbxBalance.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxBalance.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxBalance.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxBalance.ReadOnly = false;
            this.tbxBalance.Size = new System.Drawing.Size(154, 24);
            this.tbxBalance.TabIndex = 0;
            this.tbxBalance.TextAlign = null;
            this.tbxBalance.ValidationRules = null;
            this.tbxBalance.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(575, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Saldo";
            // 
            // GridJournal
            // 
            this.GridJournal.Location = new System.Drawing.Point(3, 24);
            this.GridJournal.MainView = this.JournalView;
            this.GridJournal.Name = "GridJournal";
            this.GridJournal.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnDelete});
            this.GridJournal.Size = new System.Drawing.Size(770, 232);
            this.GridJournal.TabIndex = 0;
            this.GridJournal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.JournalView});
            // 
            // JournalView
            // 
            this.JournalView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn9,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn8,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.JournalView.GridControl = this.GridJournal;
            this.JournalView.Name = "JournalView";
            this.JournalView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No.";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 39;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.FieldName = "Id";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn9
            // 
            this.gridColumn9.ColumnEdit = this.btnDelete;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            this.gridColumn9.Width = 32;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoHeight = false;
            this.btnDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tanggal";
            this.gridColumn3.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "DateProcess";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 113;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Debit (Rp)";
            this.gridColumn4.DisplayFormat.FormatString = "n0";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "DebitAmount";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0,n0}")});
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 198;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Kredit (Rp)";
            this.gridColumn8.DisplayFormat.FormatString = "n0";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "CreditAmount";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 166;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Diterima Dari/Oleh";
            this.gridColumn5.FieldName = "EmployeeName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 204;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "gridColumn6";
            this.gridColumn6.FieldName = "PaidReceivedBy";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "gridColumn7";
            this.gridColumn7.FieldName = "StateChange";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tanggal";
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(22, 101);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxDate.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxDate.Properties.Appearance.Options.UseBackColor = true;
            this.tbxDate.Properties.Appearance.Options.UseFont = true;
            this.tbxDate.Properties.AutoHeight = false;
            this.tbxDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.tbxDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxDate.Size = new System.Drawing.Size(122, 24);
            this.tbxDate.TabIndex = 2;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Debit (Rp)";
            // 
            // tbxDebit
            // 
            this.tbxDebit.EditMask = "###,###,###,###,###,##0.00";
            this.tbxDebit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxDebit.FieldLabel = null;
            this.tbxDebit.Location = new System.Drawing.Point(156, 101);
            this.tbxDebit.Name = "tbxDebit";
            this.tbxDebit.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDebit.Properties.AllowMouseWheel = false;
            this.tbxDebit.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxDebit.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxDebit.Properties.Appearance.Options.UseBackColor = true;
            this.tbxDebit.Properties.Appearance.Options.UseFont = true;
            this.tbxDebit.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxDebit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxDebit.Properties.Mask.BeepOnError = true;
            this.tbxDebit.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxDebit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxDebit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxDebit.ReadOnly = false;
            this.tbxDebit.Size = new System.Drawing.Size(154, 24);
            this.tbxDebit.TabIndex = 3;
            this.tbxDebit.TextAlign = null;
            this.tbxDebit.ValidationRules = null;
            this.tbxDebit.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(488, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Diterima Dari/Oleh";
            // 
            // lkpEmployee
            // 
            this.lkpEmployee.AutoCompleteDataManager = null;
            this.lkpEmployee.AutoCompleteDisplayFormater = null;
            this.lkpEmployee.AutoCompleteInitialized = false;
            this.lkpEmployee.AutocompleteMinimumTextLength = 0;
            this.lkpEmployee.AutoCompleteText = null;
            this.lkpEmployee.AutoCompleteWhereExpression = null;
            this.lkpEmployee.AutoCompleteWheretermFormater = null;
            this.lkpEmployee.ClearOnLeave = true;
            this.lkpEmployee.DisplayString = null;
            this.lkpEmployee.FieldLabel = null;
            this.lkpEmployee.Location = new System.Drawing.Point(491, 101);
            this.lkpEmployee.LookupPopup = null;
            this.lkpEmployee.Name = "lkpEmployee";
            this.lkpEmployee.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpEmployee.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lkpEmployee.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpEmployee.Properties.Appearance.Options.UseBackColor = true;
            this.lkpEmployee.Properties.Appearance.Options.UseFont = true;
            this.lkpEmployee.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpEmployee.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpEmployee.Properties.AutoCompleteDataManager = null;
            this.lkpEmployee.Properties.AutoCompleteDisplayFormater = null;
            this.lkpEmployee.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpEmployee.Properties.AutoCompleteText = null;
            this.lkpEmployee.Properties.AutoCompleteWhereExpression = null;
            this.lkpEmployee.Properties.AutoCompleteWheretermFormater = null;
            this.lkpEmployee.Properties.AutoHeight = false;
            this.lkpEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpEmployee.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpEmployee.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpEmployee.Properties.LookupPopup = null;
            this.lkpEmployee.Properties.NullText = "<<Choose...>>";
            this.lkpEmployee.Size = new System.Drawing.Size(211, 24);
            this.lkpEmployee.TabIndex = 5;
            this.lkpEmployee.ValidationRules = null;
            this.lkpEmployee.Value = null;
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Location = new System.Drawing.Point(707, 95);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(61, 34);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "+ Cash";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(321, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Kredit (Rp)";
            // 
            // tbxCredit
            // 
            this.tbxCredit.EditMask = "###,###,###,###,###,##0.00";
            this.tbxCredit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxCredit.FieldLabel = null;
            this.tbxCredit.Location = new System.Drawing.Point(324, 101);
            this.tbxCredit.Name = "tbxCredit";
            this.tbxCredit.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxCredit.Properties.AllowMouseWheel = false;
            this.tbxCredit.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxCredit.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxCredit.Properties.Appearance.Options.UseBackColor = true;
            this.tbxCredit.Properties.Appearance.Options.UseFont = true;
            this.tbxCredit.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxCredit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxCredit.Properties.Mask.BeepOnError = true;
            this.tbxCredit.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxCredit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxCredit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxCredit.ReadOnly = false;
            this.tbxCredit.Size = new System.Drawing.Size(154, 24);
            this.tbxCredit.TabIndex = 4;
            this.tbxCredit.TextAlign = null;
            this.tbxCredit.ValidationRules = null;
            this.tbxCredit.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // PettyCashForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(779, 424);
            this.Controls.Add(this.tbxCredit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lkpEmployee);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxDebit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.label1);
            this.Name = "PettyCashForm";
            this.Text = "Petty Cash";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbxDescription, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbxDate, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tbxDebit, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lkpEmployee, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.tbxCredit, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxBalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridJournal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JournalView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDebit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCredit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Common.Component.dTextBox tbxDescription;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label2;
        private Common.Component.dCalendar tbxDate;
        private System.Windows.Forms.Label label3;
        private Common.Component.dTextBoxNumber tbxDebit;
        private System.Windows.Forms.Label label4;
        private Common.Component.dLookup lkpEmployee;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.GridControl GridJournal;
        private DevExpress.XtraGrid.Views.Grid.GridView JournalView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private System.Windows.Forms.Label label5;
        private Common.Component.dTextBoxNumber tbxCredit;
        private Common.Component.dTextBoxNumber tbxBalance;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDelete;

    }
}