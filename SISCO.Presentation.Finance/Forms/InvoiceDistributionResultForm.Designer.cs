namespace SISCO.Presentation.Finance.Forms
{
    partial class InvoiceDistributionResultForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceDistributionResultForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.GridUndistributed = new DevExpress.XtraGrid.GridControl();
            this.UndistributedView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lkpPaymentType = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.tbxKwitansi = new System.Windows.Forms.TextBox();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.tbxReceipt = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.lkpCollector = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.btnFind = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.GridDistributed = new DevExpress.XtraGrid.GridControl();
            this.DistributedView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridUndistributed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UndistributedView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPaymentType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCollector.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDistributed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DistributedView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl1.Controls.Add(this.GridUndistributed);
            this.groupControl1.Location = new System.Drawing.Point(2, 39);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(382, 426);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Invoice Belum Terkirim";
            // 
            // GridUndistributed
            // 
            this.GridUndistributed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridUndistributed.Location = new System.Drawing.Point(4, 23);
            this.GridUndistributed.MainView = this.UndistributedView;
            this.GridUndistributed.Name = "GridUndistributed";
            this.GridUndistributed.Size = new System.Drawing.Size(374, 398);
            this.GridUndistributed.TabIndex = 0;
            this.GridUndistributed.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.UndistributedView});
            // 
            // UndistributedView
            // 
            this.UndistributedView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.UndistributedView.GridControl = this.GridUndistributed;
            this.UndistributedView.Name = "UndistributedView";
            this.UndistributedView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "No";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 40;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No Kwitansi";
            this.gridColumn1.FieldName = "RefNumber";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 173;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tgl";
            this.gridColumn2.DisplayFormat.FormatString = "dd MM yyyy";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "DateProcess";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 107;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Due Date";
            this.gridColumn3.DisplayFormat.FormatString = "dd MM yyyy";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "DueDate";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 119;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Customer";
            this.gridColumn4.FieldName = "CustomerName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 121;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Collector";
            this.gridColumn5.FieldName = "CollectorName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 136;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Honeydew;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lkpPaymentType);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbxKwitansi);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.tbxReceipt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lkpCollector);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbxDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(386, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 151);
            this.panel1.TabIndex = 1;
            // 
            // lkpPaymentType
            // 
            this.lkpPaymentType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lkpPaymentType.AutoCompleteDataManager = null;
            this.lkpPaymentType.AutoCompleteDisplayFormater = null;
            this.lkpPaymentType.AutoCompleteInitialized = false;
            this.lkpPaymentType.AutocompleteMinimumTextLength = 0;
            this.lkpPaymentType.AutoCompleteText = null;
            this.lkpPaymentType.AutoCompleteWhereExpression = null;
            this.lkpPaymentType.AutoCompleteWheretermFormater = null;
            this.lkpPaymentType.ClearOnLeave = true;
            this.lkpPaymentType.DisplayString = null;
            this.lkpPaymentType.FieldLabel = null;
            this.lkpPaymentType.Location = new System.Drawing.Point(327, 60);
            this.lkpPaymentType.LookupPopup = null;
            this.lkpPaymentType.Name = "lkpPaymentType";
            this.lkpPaymentType.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpPaymentType.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lkpPaymentType.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpPaymentType.Properties.Appearance.Options.UseBackColor = true;
            this.lkpPaymentType.Properties.Appearance.Options.UseFont = true;
            this.lkpPaymentType.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpPaymentType.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpPaymentType.Properties.AutoCompleteDataManager = null;
            this.lkpPaymentType.Properties.AutoCompleteDisplayFormater = null;
            this.lkpPaymentType.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpPaymentType.Properties.AutoCompleteText = null;
            this.lkpPaymentType.Properties.AutoCompleteWhereExpression = null;
            this.lkpPaymentType.Properties.AutoCompleteWheretermFormater = null;
            this.lkpPaymentType.Properties.AutoHeight = false;
            this.lkpPaymentType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpPaymentType.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpPaymentType.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpPaymentType.Properties.LookupPopup = null;
            this.lkpPaymentType.Properties.NullText = "<<Choose...>>";
            this.lkpPaymentType.Size = new System.Drawing.Size(229, 24);
            this.lkpPaymentType.TabIndex = 4;
            this.lkpPaymentType.ValidationRules = null;
            this.lkpPaymentType.Value = null;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(266, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Payment";
            // 
            // tbxKwitansi
            // 
            this.tbxKwitansi.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxKwitansi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxKwitansi.Location = new System.Drawing.Point(327, 8);
            this.tbxKwitansi.Name = "tbxKwitansi";
            this.tbxKwitansi.Size = new System.Drawing.Size(129, 24);
            this.tbxKwitansi.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(328, 113);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 29);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            // 
            // tbxReceipt
            // 
            this.tbxReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxReceipt.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxReceipt.Capslock = true;
            this.tbxReceipt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxReceipt.FieldLabel = null;
            this.tbxReceipt.Location = new System.Drawing.Point(328, 86);
            this.tbxReceipt.Name = "tbxReceipt";
            this.tbxReceipt.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxReceipt.Size = new System.Drawing.Size(228, 24);
            this.tbxReceipt.TabIndex = 5;
            this.tbxReceipt.ValidationRules = null;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Penerima Invoice";
            // 
            // lkpCollector
            // 
            this.lkpCollector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lkpCollector.AutoCompleteDataManager = null;
            this.lkpCollector.AutoCompleteDisplayFormater = null;
            this.lkpCollector.AutoCompleteInitialized = false;
            this.lkpCollector.AutocompleteMinimumTextLength = 0;
            this.lkpCollector.AutoCompleteText = null;
            this.lkpCollector.AutoCompleteWhereExpression = null;
            this.lkpCollector.AutoCompleteWheretermFormater = null;
            this.lkpCollector.ClearOnLeave = true;
            this.lkpCollector.DisplayString = null;
            this.lkpCollector.FieldLabel = null;
            this.lkpCollector.Location = new System.Drawing.Point(327, 34);
            this.lkpCollector.LookupPopup = null;
            this.lkpCollector.Name = "lkpCollector";
            this.lkpCollector.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpCollector.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lkpCollector.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpCollector.Properties.Appearance.Options.UseBackColor = true;
            this.lkpCollector.Properties.Appearance.Options.UseFont = true;
            this.lkpCollector.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpCollector.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpCollector.Properties.AutoCompleteDataManager = null;
            this.lkpCollector.Properties.AutoCompleteDisplayFormater = null;
            this.lkpCollector.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpCollector.Properties.AutoCompleteText = null;
            this.lkpCollector.Properties.AutoCompleteWhereExpression = null;
            this.lkpCollector.Properties.AutoCompleteWheretermFormater = null;
            this.lkpCollector.Properties.AutoHeight = false;
            this.lkpCollector.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpCollector.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpCollector.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpCollector.Properties.LookupPopup = null;
            this.lkpCollector.Properties.NullText = "<<Choose...>>";
            this.lkpCollector.Size = new System.Drawing.Size(229, 24);
            this.lkpCollector.TabIndex = 3;
            this.lkpCollector.ValidationRules = null;
            this.lkpCollector.Value = null;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Collector";
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Location = new System.Drawing.Point(460, 5);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(56, 27);
            this.btnFind.TabIndex = 7;
            this.btnFind.Text = "Cari";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "No Kwitansi";
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(70, 7);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxDate.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxDate.Properties.Appearance.Options.UseBackColor = true;
            this.tbxDate.Properties.Appearance.Options.UseFont = true;
            this.tbxDate.Properties.AutoHeight = false;
            this.tbxDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
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
            this.tbxDate.Size = new System.Drawing.Size(115, 24);
            this.tbxDate.TabIndex = 1;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // GridDistributed
            // 
            this.GridDistributed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridDistributed.Location = new System.Drawing.Point(386, 192);
            this.GridDistributed.MainView = this.DistributedView;
            this.GridDistributed.Name = "GridDistributed";
            this.GridDistributed.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnDelete});
            this.GridDistributed.Size = new System.Drawing.Size(578, 273);
            this.GridDistributed.TabIndex = 3;
            this.GridDistributed.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DistributedView});
            // 
            // DistributedView
            // 
            this.DistributedView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn17,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn12,
            this.gridColumn18});
            this.DistributedView.GridControl = this.GridDistributed;
            this.DistributedView.Name = "DistributedView";
            this.DistributedView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "No";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 36;
            // 
            // gridColumn8
            // 
            this.gridColumn8.ColumnEdit = this.btnDelete;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 21;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoHeight = false;
            this.btnDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "gridColumn9";
            this.gridColumn9.FieldName = "SalesInvoiceId";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "No Kwitansi";
            this.gridColumn10.FieldName = "RefNumber";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 2;
            this.gridColumn10.Width = 122;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Customer";
            this.gridColumn11.FieldName = "CustomerName";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 3;
            this.gridColumn11.Width = 179;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "gridColumn13";
            this.gridColumn13.FieldName = "CollectorId";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Collector";
            this.gridColumn14.FieldName = "CollectorName";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.OptionsColumn.ReadOnly = true;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 4;
            this.gridColumn14.Width = 137;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Payment";
            this.gridColumn17.FieldName = "PaymentTypeName";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.OptionsColumn.ReadOnly = true;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 5;
            this.gridColumn17.Width = 82;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Penerima";
            this.gridColumn15.FieldName = "ReceiptName";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.OptionsColumn.ReadOnly = true;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 6;
            this.gridColumn15.Width = 119;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "gridColumn16";
            this.gridColumn16.FieldName = "StateChange";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "gridColumn12";
            this.gridColumn12.FieldName = "PaymentTypeId";
            this.gridColumn12.Name = "gridColumn12";
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "gridColumn18";
            this.gridColumn18.FieldName = "Id";
            this.gridColumn18.Name = "gridColumn18";
            // 
            // InvoiceDistributionResultForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(966, 467);
            this.Controls.Add(this.GridDistributed);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupControl1);
            this.Name = "InvoiceDistributionResultForm";
            this.Text = "Hasil Distribusi Invoice";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.GridDistributed, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridUndistributed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UndistributedView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPaymentType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCollector.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDistributed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DistributedView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl GridUndistributed;
        private DevExpress.XtraGrid.Views.Grid.GridView UndistributedView;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnFind;
        private System.Windows.Forms.Label label2;
        private Common.Component.dCalendar tbxDate;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private Common.Component.dTextBox tbxReceipt;
        private System.Windows.Forms.Label label4;
        private Common.Component.dLookup lkpCollector;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.GridControl GridDistributed;
        private DevExpress.XtraGrid.Views.Grid.GridView DistributedView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private System.Windows.Forms.TextBox tbxKwitansi;
        private Common.Component.dLookup lkpPaymentType;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
    }
}