namespace SISCO.Presentation.Finance.Forms
{
    partial class ClosingBankTransactionForm
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClosingBankTransactionForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.TransactionView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridJournals = new DevExpress.XtraGrid.GridControl();
            this.JournalView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnVerify = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.InvoiceView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnFilter = new DevExpress.XtraEditors.SimpleButton();
            this.tbxTo = new SISCO.Presentation.Common.Component.dCalendar();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxFrom = new SISCO.Presentation.Common.Component.dCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.lkpAccount = new SISCO.Presentation.Common.Component.dLookup();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cbxVerified = new SISCO.Presentation.Common.Component.dCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridJournals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JournalView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerify)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TransactionView
            // 
            this.TransactionView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn10,
            this.gridColumn12,
            this.gridColumn13});
            this.TransactionView.GridControl = this.GridJournals;
            this.TransactionView.Name = "TransactionView";
            this.TransactionView.OptionsView.ShowFooter = true;
            this.TransactionView.OptionsView.ShowGroupPanel = false;
            this.TransactionView.ViewCaption = "Transaksi";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "No. Transaksi";
            this.gridColumn6.FieldName = "TransactionCode";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 147;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Tanggal";
            this.gridColumn7.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn7.FieldName = "TransactionDate";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 74;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Total";
            this.gridColumn10.DisplayFormat.FormatString = "n2";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "Amount";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:n2}")});
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Description";
            this.gridColumn12.FieldName = "Description";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            this.gridColumn12.Width = 317;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Adjustment";
            this.gridColumn13.DisplayFormat.FormatString = "n2";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn13.FieldName = "Adjustment";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 4;
            this.gridColumn13.Width = 83;
            // 
            // GridJournals
            // 
            this.GridJournals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode1.LevelTemplate = this.TransactionView;
            gridLevelNode2.LevelTemplate = this.InvoiceView;
            gridLevelNode2.RelationName = "Lists";
            gridLevelNode1.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            gridLevelNode1.RelationName = "Details";
            this.GridJournals.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.GridJournals.Location = new System.Drawing.Point(3, 23);
            this.GridJournals.MainView = this.JournalView;
            this.GridJournals.Name = "GridJournals";
            this.GridJournals.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnVerify});
            this.GridJournals.Size = new System.Drawing.Size(890, 349);
            this.GridJournals.TabIndex = 5;
            this.GridJournals.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.JournalView,
            this.InvoiceView,
            this.gridView1,
            this.TransactionView});
            // 
            // JournalView
            // 
            this.JournalView.ChildGridLevelName = "Details";
            this.JournalView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn1});
            this.JournalView.GridControl = this.GridJournals;
            this.JournalView.Name = "JournalView";
            this.JournalView.OptionsView.ShowChildrenInGroupPanel = true;
            this.JournalView.OptionsView.ShowGroupPanel = false;
            this.JournalView.ViewCaption = "Detail Transaksi";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.FieldName = "Id";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gridColumn5.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn5.ColumnEdit = this.btnVerify;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 50;
            // 
            // btnVerify
            // 
            this.btnVerify.AutoHeight = false;
            this.btnVerify.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Verify", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.btnVerify.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gridColumn3.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn3.Caption = "Tanggal";
            this.gridColumn3.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "TransactionAccountDate";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 95;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gridColumn4.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn4.Caption = "Rincian / No. Referensi";
            this.gridColumn4.FieldName = "Description";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 321;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gridColumn8.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn8.Caption = "Debit";
            this.gridColumn8.DisplayFormat.FormatString = "n2";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "Debit";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 144;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gridColumn9.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn9.Caption = "Kredit";
            this.gridColumn9.DisplayFormat.FormatString = "n2";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "Credit";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 127;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gridColumn1.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn1.Caption = "Sisa";
            this.gridColumn1.DisplayFormat.FormatString = "n2";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "Balance";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            this.gridColumn1.Width = 135;
            // 
            // InvoiceView
            // 
            this.InvoiceView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn11,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16});
            this.InvoiceView.GridControl = this.GridJournals;
            this.InvoiceView.Name = "InvoiceView";
            this.InvoiceView.OptionsView.ShowGroupPanel = false;
            this.InvoiceView.ViewCaption = "Invoice";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "No. Invoice";
            this.gridColumn11.FieldName = "InvoiceNo";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            this.gridColumn11.Width = 355;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Total Pembayaran";
            this.gridColumn14.DisplayFormat.FormatString = "n0";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn14.FieldName = "Total";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 1;
            this.gridColumn14.Width = 297;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Total PPh";
            this.gridColumn15.DisplayFormat.FormatString = "n0";
            this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn15.FieldName = "TotalPph";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 2;
            this.gridColumn15.Width = 108;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Materai";
            this.gridColumn16.DisplayFormat.FormatString = "n0";
            this.gridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn16.FieldName = "MateraiFee";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 3;
            this.gridColumn16.Width = 112;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.GridJournals;
            this.gridView1.Name = "gridView1";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.cbxVerified);
            this.groupControl1.Controls.Add(this.btnFilter);
            this.groupControl1.Controls.Add(this.tbxTo);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.tbxFrom);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.lkpAccount);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(896, 85);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Filter Transaksi";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(485, 30);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 44);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "Filter";
            // 
            // tbxTo
            // 
            this.tbxTo.EditValue = null;
            this.tbxTo.FieldLabel = null;
            this.tbxTo.FormatDateTime = "dd-MM-yyyy";
            this.tbxTo.Location = new System.Drawing.Point(245, 53);
            this.tbxTo.Name = "tbxTo";
            this.tbxTo.Nullable = false;
            this.tbxTo.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTo.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTo.Properties.Appearance.Options.UseFont = true;
            this.tbxTo.Properties.AutoHeight = false;
            this.tbxTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxTo.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxTo.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxTo.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxTo.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxTo.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxTo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTo.Size = new System.Drawing.Size(100, 24);
            this.tbxTo.TabIndex = 3;
            this.tbxTo.ValidationRules = null;
            this.tbxTo.Value = new System.DateTime(((long)(0)));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "s.d";
            // 
            // tbxFrom
            // 
            this.tbxFrom.EditValue = null;
            this.tbxFrom.FieldLabel = null;
            this.tbxFrom.FormatDateTime = "dd-MM-yyyy";
            this.tbxFrom.Location = new System.Drawing.Point(109, 53);
            this.tbxFrom.Name = "tbxFrom";
            this.tbxFrom.Nullable = false;
            this.tbxFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFrom.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxFrom.Properties.Appearance.Options.UseFont = true;
            this.tbxFrom.Properties.AutoHeight = false;
            this.tbxFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxFrom.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.tbxFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxFrom.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxFrom.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxFrom.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxFrom.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxFrom.Size = new System.Drawing.Size(100, 24);
            this.tbxFrom.TabIndex = 2;
            this.tbxFrom.ValidationRules = null;
            this.tbxFrom.Value = new System.DateTime(((long)(0)));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tanggal";
            // 
            // lkpAccount
            // 
            this.lkpAccount.AutoCompleteDataManager = null;
            this.lkpAccount.AutoCompleteDisplayFormater = null;
            this.lkpAccount.AutoCompleteInitialized = false;
            this.lkpAccount.AutocompleteMinimumTextLength = 0;
            this.lkpAccount.AutoCompleteText = null;
            this.lkpAccount.AutoCompleteWhereExpression = null;
            this.lkpAccount.AutoCompleteWheretermFormater = null;
            this.lkpAccount.ClearOnLeave = true;
            this.lkpAccount.DisplayString = "";
            this.lkpAccount.EditValue = "";
            this.lkpAccount.FieldLabel = null;
            this.lkpAccount.Location = new System.Drawing.Point(109, 27);
            this.lkpAccount.LookupPopup = null;
            this.lkpAccount.Name = "lkpAccount";
            this.lkpAccount.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpAccount.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lkpAccount.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpAccount.Properties.Appearance.Options.UseBackColor = true;
            this.lkpAccount.Properties.Appearance.Options.UseFont = true;
            this.lkpAccount.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpAccount.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpAccount.Properties.AutoCompleteDataManager = null;
            this.lkpAccount.Properties.AutoCompleteDisplayFormater = null;
            this.lkpAccount.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpAccount.Properties.AutoCompleteText = null;
            this.lkpAccount.Properties.AutoCompleteWhereExpression = null;
            this.lkpAccount.Properties.AutoCompleteWheretermFormater = null;
            this.lkpAccount.Properties.AutoHeight = false;
            this.lkpAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpAccount.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.lkpAccount.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpAccount.Properties.LookupPopup = null;
            this.lkpAccount.Properties.NullText = "<<Choose...>>";
            this.lkpAccount.Size = new System.Drawing.Size(236, 24);
            this.lkpAccount.TabIndex = 1;
            this.lkpAccount.ValidationRules = null;
            this.lkpAccount.Value = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "No. Rekening";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.GridJournals);
            this.groupControl2.Location = new System.Drawing.Point(3, 92);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(896, 376);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Closing Transaksi";
            // 
            // cbxVerified
            // 
            this.cbxVerified.AutoSize = true;
            this.cbxVerified.FieldLabel = null;
            this.cbxVerified.Location = new System.Drawing.Point(351, 53);
            this.cbxVerified.Name = "cbxVerified";
            this.cbxVerified.Size = new System.Drawing.Size(118, 21);
            this.cbxVerified.TabIndex = 5;
            this.cbxVerified.Text = "Sudah Verifikasi?";
            this.cbxVerified.UseVisualStyleBackColor = true;
            this.cbxVerified.ValidationRules = null;
            // 
            // ClosingBankTransactionForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(902, 472);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ClosingBankTransactionForm";
            this.Text = "Tutup Buku Journal Transaksi";
            ((System.ComponentModel.ISupportInitialize)(this.TransactionView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridJournals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JournalView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerify)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private Common.Component.dLookup lkpAccount;
        private System.Windows.Forms.Label label1;
        private Common.Component.dCalendar tbxTo;
        private System.Windows.Forms.Label label3;
        private Common.Component.dCalendar tbxFrom;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnFilter;
        private DevExpress.XtraGrid.GridControl GridJournals;
        private DevExpress.XtraGrid.Views.Grid.GridView TransactionView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Views.Grid.GridView InvoiceView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Views.Grid.GridView JournalView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnVerify;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private Common.Component.dCheckBox cbxVerified;
    }
}