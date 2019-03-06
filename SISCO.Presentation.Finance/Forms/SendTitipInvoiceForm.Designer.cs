namespace SISCO.Presentation.Finance.Forms
{
    partial class SendTitipInvoiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendTitipInvoiceForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxNomor = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.lkpDestBranch = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.gbCreate = new System.Windows.Forms.GroupBox();
            this.tbxEnd = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tbxStart = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.btnGet = new DevExpress.XtraEditors.SimpleButton();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.GridSend = new DevExpress.XtraGrid.GridControl();
            this.SendView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestBranch.Properties)).BeginInit();
            this.gbCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbxNomor);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lkpDestBranch);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.gbCreate);
            this.panel1.Controls.Add(this.tbxDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 95);
            this.panel1.TabIndex = 1;
            // 
            // tbxNomor
            // 
            this.tbxNomor.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxNomor.Capslock = true;
            this.tbxNomor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxNomor.FieldLabel = null;
            this.tbxNomor.Location = new System.Drawing.Point(115, 58);
            this.tbxNomor.Name = "tbxNomor";
            this.tbxNomor.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxNomor.Size = new System.Drawing.Size(302, 24);
            this.tbxNomor.TabIndex = 3;
            this.tbxNomor.ValidationRules = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Nomor Surat";
            // 
            // lkpDestBranch
            // 
            this.lkpDestBranch.AutoCompleteDataManager = null;
            this.lkpDestBranch.AutoCompleteDisplayFormater = null;
            this.lkpDestBranch.AutoCompleteInitialized = false;
            this.lkpDestBranch.AutocompleteMinimumTextLength = 0;
            this.lkpDestBranch.AutoCompleteText = null;
            this.lkpDestBranch.AutoCompleteWhereExpression = null;
            this.lkpDestBranch.AutoCompleteWheretermFormater = null;
            this.lkpDestBranch.ClearOnLeave = true;
            this.lkpDestBranch.DisplayString = null;
            this.lkpDestBranch.FieldLabel = null;
            this.lkpDestBranch.Location = new System.Drawing.Point(115, 33);
            this.lkpDestBranch.LookupPopup = null;
            this.lkpDestBranch.Name = "lkpDestBranch";
            this.lkpDestBranch.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpDestBranch.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lkpDestBranch.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpDestBranch.Properties.Appearance.Options.UseBackColor = true;
            this.lkpDestBranch.Properties.Appearance.Options.UseFont = true;
            this.lkpDestBranch.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpDestBranch.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpDestBranch.Properties.AutoCompleteDataManager = null;
            this.lkpDestBranch.Properties.AutoCompleteDisplayFormater = null;
            this.lkpDestBranch.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpDestBranch.Properties.AutoCompleteText = null;
            this.lkpDestBranch.Properties.AutoCompleteWhereExpression = null;
            this.lkpDestBranch.Properties.AutoCompleteWheretermFormater = null;
            this.lkpDestBranch.Properties.AutoHeight = false;
            this.lkpDestBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpDestBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpDestBranch.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpDestBranch.Properties.LookupPopup = null;
            this.lkpDestBranch.Properties.NullText = "<<Choose...>>";
            this.lkpDestBranch.Size = new System.Drawing.Size(302, 24);
            this.lkpDestBranch.TabIndex = 2;
            this.lkpDestBranch.ValidationRules = null;
            this.lkpDestBranch.Value = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Branch Tujuan";
            // 
            // gbCreate
            // 
            this.gbCreate.Controls.Add(this.tbxEnd);
            this.gbCreate.Controls.Add(this.label3);
            this.gbCreate.Controls.Add(this.tbxStart);
            this.gbCreate.Controls.Add(this.label2);
            this.gbCreate.Controls.Add(this.btnGet);
            this.gbCreate.Location = new System.Drawing.Point(492, 3);
            this.gbCreate.Name = "gbCreate";
            this.gbCreate.Size = new System.Drawing.Size(330, 84);
            this.gbCreate.TabIndex = 3;
            this.gbCreate.TabStop = false;
            this.gbCreate.Text = "Titip Invoice";
            // 
            // tbxEnd
            // 
            this.tbxEnd.EditValue = null;
            this.tbxEnd.FieldLabel = null;
            this.tbxEnd.FormatDateTime = "dd-MM-yyyy";
            this.tbxEnd.Location = new System.Drawing.Point(118, 50);
            this.tbxEnd.Name = "tbxEnd";
            this.tbxEnd.Nullable = false;
            this.tbxEnd.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxEnd.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxEnd.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxEnd.Properties.Appearance.Options.UseBackColor = true;
            this.tbxEnd.Properties.Appearance.Options.UseFont = true;
            this.tbxEnd.Properties.AutoHeight = false;
            this.tbxEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxEnd.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxEnd.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxEnd.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxEnd.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxEnd.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxEnd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxEnd.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxEnd.Size = new System.Drawing.Size(114, 24);
            this.tbxEnd.TabIndex = 5;
            this.tbxEnd.ValidationRules = null;
            this.tbxEnd.Value = new System.DateTime(((long)(0)));
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(40, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tgl Akhir";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxStart
            // 
            this.tbxStart.EditValue = null;
            this.tbxStart.FieldLabel = null;
            this.tbxStart.FormatDateTime = "dd-MM-yyyy";
            this.tbxStart.Location = new System.Drawing.Point(118, 25);
            this.tbxStart.Name = "tbxStart";
            this.tbxStart.Nullable = false;
            this.tbxStart.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxStart.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxStart.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxStart.Properties.Appearance.Options.UseBackColor = true;
            this.tbxStart.Properties.Appearance.Options.UseFont = true;
            this.tbxStart.Properties.AutoHeight = false;
            this.tbxStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxStart.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.tbxStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxStart.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxStart.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxStart.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxStart.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxStart.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxStart.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxStart.Size = new System.Drawing.Size(114, 24);
            this.tbxStart.TabIndex = 4;
            this.tbxStart.ValidationRules = null;
            this.tbxStart.Value = new System.DateTime(((long)(0)));
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(40, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tgl Awal";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(244, 33);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 32);
            this.btnGet.TabIndex = 6;
            this.btnGet.Text = "Get Data";
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(115, 8);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxDate.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxDate.Properties.Appearance.Options.UseBackColor = true;
            this.tbxDate.Properties.Appearance.Options.UseFont = true;
            this.tbxDate.Properties.AutoHeight = false;
            this.tbxDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
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
            this.tbxDate.Size = new System.Drawing.Size(100, 24);
            this.tbxDate.TabIndex = 1;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // GridSend
            // 
            this.GridSend.Location = new System.Drawing.Point(3, 139);
            this.GridSend.MainView = this.SendView;
            this.GridSend.Name = "GridSend";
            this.GridSend.Size = new System.Drawing.Size(832, 311);
            this.GridSend.TabIndex = 2;
            this.GridSend.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.SendView});
            // 
            // SendView
            // 
            this.SendView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn6,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.SendView.GridControl = this.GridSend;
            this.SendView.Name = "SendView";
            this.SendView.OptionsView.ShowFooter = true;
            this.SendView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = " ";
            this.gridColumn6.FieldName = "Checked";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 26;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tgl Titip ";
            this.gridColumn2.DisplayFormat.FormatString = "dd-MMM-yyyy";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "DateProcess";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 83;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "No. Kwitansi";
            this.gridColumn3.FieldName = "RefNumber";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 136;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Customer";
            this.gridColumn4.FieldName = "CustomerName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 309;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Total";
            this.gridColumn5.DisplayFormat.FormatString = "n1";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "Total";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:n1}")});
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 142;
            // 
            // SendTitipInvoiceForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(838, 453);
            this.Controls.Add(this.GridSend);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "SendTitipInvoiceForm";
            this.Text = "Kirim Titip Invoice";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.GridSend, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestBranch.Properties)).EndInit();
            this.gbCreate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbxEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbCreate;
        private Common.Component.dCalendar tbxEnd;
        private System.Windows.Forms.Label label3;
        private Common.Component.dCalendar tbxStart;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnGet;
        private Common.Component.dCalendar tbxDate;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl GridSend;
        private DevExpress.XtraGrid.Views.Grid.GridView SendView;
        private Common.Component.dLookup lkpDestBranch;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private Common.Component.dTextBox tbxNomor;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;

    }
}