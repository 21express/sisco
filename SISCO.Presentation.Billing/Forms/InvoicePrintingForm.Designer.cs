namespace SISCO.Presentation.Billing.Forms
{
    partial class InvoicePrintingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoicePrintingForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxFaktur = new DevExpress.XtraEditors.ButtonEdit();
            this.chkContinous2 = new SISCO.Presentation.Common.Component.dCheckBox();
            this.chkContinous1 = new SISCO.Presentation.Common.Component.dCheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxDelivery = new DevExpress.XtraEditors.ButtonEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxInvoice = new DevExpress.XtraEditors.ButtonEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxDetail = new DevExpress.XtraEditors.ButtonEdit();
            this.cmbTaxInvoice = new SISCO.Presentation.Common.Component.dComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFind = new DevExpress.XtraEditors.SimpleButton();
            this.lkpBranch = new SISCO.Presentation.Common.Component.dLookup();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxMonth = new SISCO.Presentation.Common.Component.dComboBox();
            this.cbxYear = new SISCO.Presentation.Common.Component.dComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.GridInvoice = new DevExpress.XtraGrid.GridControl();
            this.InvoiceView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chc2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.chc1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.chc3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.chc4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnChkDetail = new DevExpress.XtraEditors.SimpleButton();
            this.btnChkInvoice = new DevExpress.XtraEditors.SimpleButton();
            this.btnChkDelivery = new DevExpress.XtraEditors.SimpleButton();
            this.btnChkFaktur = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFaktur.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDelivery.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxInvoice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDetail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chc2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chc3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chc4)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Honeydew;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupControl1);
            this.panel1.Controls.Add(this.cmbTaxInvoice);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.lkpBranch);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbxMonth);
            this.panel1.Controls.Add(this.cbxYear);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(893, 155);
            this.panel1.TabIndex = 1;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.label8);
            this.groupControl1.Controls.Add(this.tbxFaktur);
            this.groupControl1.Controls.Add(this.chkContinous2);
            this.groupControl1.Controls.Add(this.chkContinous1);
            this.groupControl1.Controls.Add(this.label7);
            this.groupControl1.Controls.Add(this.tbxDelivery);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.tbxInvoice);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.tbxDetail);
            this.groupControl1.Location = new System.Drawing.Point(426, 8);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(456, 136);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "Setting Printer";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 17);
            this.label8.TabIndex = 30;
            this.label8.Text = "Folder Download Faktur";
            // 
            // tbxFaktur
            // 
            this.tbxFaktur.EditValue = "";
            this.tbxFaktur.Location = new System.Drawing.Point(187, 103);
            this.tbxFaktur.Name = "tbxFaktur";
            this.tbxFaktur.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxFaktur.Properties.Appearance.Options.UseFont = true;
            this.tbxFaktur.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tbxFaktur.Size = new System.Drawing.Size(249, 24);
            this.tbxFaktur.TabIndex = 11;
            // 
            // chkContinous2
            // 
            this.chkContinous2.AutoSize = true;
            this.chkContinous2.FieldLabel = null;
            this.chkContinous2.Location = new System.Drawing.Point(362, 53);
            this.chkContinous2.Name = "chkContinous2";
            this.chkContinous2.Size = new System.Drawing.Size(81, 21);
            this.chkContinous2.TabIndex = 9;
            this.chkContinous2.Text = "Continous";
            this.chkContinous2.UseVisualStyleBackColor = true;
            this.chkContinous2.ValidationRules = null;
            // 
            // chkContinous1
            // 
            this.chkContinous1.AutoSize = true;
            this.chkContinous1.FieldLabel = null;
            this.chkContinous1.Location = new System.Drawing.Point(362, 30);
            this.chkContinous1.Name = "chkContinous1";
            this.chkContinous1.Size = new System.Drawing.Size(81, 21);
            this.chkContinous1.TabIndex = 7;
            this.chkContinous1.Text = "Continous";
            this.chkContinous1.UseVisualStyleBackColor = true;
            this.chkContinous1.ValidationRules = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "Cetak Tanda Terima (InkJet)";
            // 
            // tbxDelivery
            // 
            this.tbxDelivery.Location = new System.Drawing.Point(187, 78);
            this.tbxDelivery.Name = "tbxDelivery";
            this.tbxDelivery.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxDelivery.Properties.Appearance.Options.UseFont = true;
            this.tbxDelivery.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tbxDelivery.Size = new System.Drawing.Size(249, 24);
            this.tbxDelivery.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Cetak Kwitansi (DotMatrix)";
            // 
            // tbxInvoice
            // 
            this.tbxInvoice.Location = new System.Drawing.Point(187, 53);
            this.tbxInvoice.Name = "tbxInvoice";
            this.tbxInvoice.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxInvoice.Properties.Appearance.Options.UseFont = true;
            this.tbxInvoice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tbxInvoice.Size = new System.Drawing.Size(168, 24);
            this.tbxInvoice.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Cetak Rincian (DotMatrix)";
            // 
            // tbxDetail
            // 
            this.tbxDetail.Location = new System.Drawing.Point(187, 28);
            this.tbxDetail.Name = "tbxDetail";
            this.tbxDetail.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxDetail.Properties.Appearance.Options.UseFont = true;
            this.tbxDetail.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tbxDetail.Size = new System.Drawing.Size(168, 24);
            this.tbxDetail.TabIndex = 6;
            // 
            // cmbTaxInvoice
            // 
            this.cmbTaxInvoice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTaxInvoice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTaxInvoice.FieldLabel = null;
            this.cmbTaxInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbTaxInvoice.FormattingEnabled = true;
            this.cmbTaxInvoice.Location = new System.Drawing.Point(116, 60);
            this.cmbTaxInvoice.Name = "cmbTaxInvoice";
            this.cmbTaxInvoice.Size = new System.Drawing.Size(231, 25);
            this.cmbTaxInvoice.TabIndex = 4;
            this.cmbTaxInvoice.ValidationRules = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Faktur Pajak";
            // 
            // btnFind
            // 
            this.btnFind.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnFind.Appearance.Options.UseFont = true;
            this.btnFind.Location = new System.Drawing.Point(116, 89);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 33);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Cari";
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
            this.lkpBranch.Location = new System.Drawing.Point(116, 33);
            this.lkpBranch.LookupPopup = null;
            this.lkpBranch.Name = "lkpBranch";
            this.lkpBranch.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpBranch.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpBranch.Properties.Appearance.Options.UseFont = true;
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpBranch.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpBranch.Properties.LookupPopup = null;
            this.lkpBranch.Properties.NullText = "<<Choose...>>";
            this.lkpBranch.Size = new System.Drawing.Size(225, 24);
            this.lkpBranch.TabIndex = 3;
            this.lkpBranch.ValidationRules = null;
            this.lkpBranch.Value = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Branch";
            // 
            // cbxMonth
            // 
            this.cbxMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxMonth.DisplayMember = "Name";
            this.cbxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMonth.FieldLabel = "Name";
            this.cbxMonth.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxMonth.FormattingEnabled = true;
            this.cbxMonth.Location = new System.Drawing.Point(202, 5);
            this.cbxMonth.Name = "cbxMonth";
            this.cbxMonth.Size = new System.Drawing.Size(110, 25);
            this.cbxMonth.TabIndex = 2;
            this.cbxMonth.ValidationRules = null;
            this.cbxMonth.ValueMember = "Id";
            // 
            // cbxYear
            // 
            this.cbxYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxYear.DisplayMember = "Id";
            this.cbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxYear.FieldLabel = "Name";
            this.cbxYear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxYear.FormattingEnabled = true;
            this.cbxYear.Location = new System.Drawing.Point(116, 5);
            this.cbxYear.Name = "cbxYear";
            this.cbxYear.Size = new System.Drawing.Size(81, 25);
            this.cbxYear.TabIndex = 1;
            this.cbxYear.ValidationRules = null;
            this.cbxYear.ValueMember = "Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Periode";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(3, 475);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Merah : Invoice sudah dicetak";
            // 
            // GridInvoice
            // 
            this.GridInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridInvoice.Location = new System.Drawing.Point(2, 160);
            this.GridInvoice.MainView = this.InvoiceView;
            this.GridInvoice.Name = "GridInvoice";
            this.GridInvoice.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chc2,
            this.chc1,
            this.chc3,
            this.chc4});
            this.GridInvoice.Size = new System.Drawing.Size(893, 300);
            this.GridInvoice.TabIndex = 1;
            this.GridInvoice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.InvoiceView});
            // 
            // InvoiceView
            // 
            this.InvoiceView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn5,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn10,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15});
            this.InvoiceView.GridControl = this.GridInvoice;
            this.InvoiceView.Name = "InvoiceView";
            this.InvoiceView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 41;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tgl Invoice";
            this.gridColumn5.DisplayFormat.FormatString = "dd MM yyyy";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn5.FieldName = "DateProcess";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 79;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "No Kwitansi";
            this.gridColumn2.FieldName = "RefNumber";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 82;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Customer";
            this.gridColumn3.FieldName = "CustomerName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 147;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Period";
            this.gridColumn4.FieldName = "Period";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 62;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Due Date";
            this.gridColumn6.DisplayFormat.FormatString = "dd MM yyyy";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn6.FieldName = "DueDate";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 70;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Total";
            this.gridColumn10.DisplayFormat.FormatString = "n0";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "Total";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 6;
            this.gridColumn10.Width = 83;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Cetak Rincian";
            this.gridColumn7.FieldName = "PrintDetail";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 86;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Cetak Kwitansi";
            this.gridColumn8.FieldName = "PrintInvoice";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            this.gridColumn8.Width = 88;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Cetak Tanda Terima";
            this.gridColumn9.FieldName = "PrintDelivery";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 9;
            this.gridColumn9.Width = 124;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Download Faktur";
            this.gridColumn11.FieldName = "DownloadFaktur";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "gridColumn12";
            this.gridColumn12.FieldName = "TaxInvoice";
            this.gridColumn12.Name = "gridColumn12";
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "gridColumn13";
            this.gridColumn13.FieldName = "Printed";
            this.gridColumn13.Name = "gridColumn13";
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "gridColumn14";
            this.gridColumn14.FieldName = "Id";
            this.gridColumn14.Name = "gridColumn14";
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "gridColumn15";
            this.gridColumn15.FieldName = "Code";
            this.gridColumn15.Name = "gridColumn15";
            // 
            // chc2
            // 
            this.chc2.AutoHeight = false;
            this.chc2.Caption = "Check";
            this.chc2.Name = "chc2";
            // 
            // chc1
            // 
            this.chc1.AutoHeight = false;
            this.chc1.Caption = "Check";
            this.chc1.Name = "chc1";
            // 
            // chc3
            // 
            this.chc3.AutoHeight = false;
            this.chc3.Caption = "Check";
            this.chc3.Name = "chc3";
            // 
            // chc4
            // 
            this.chc4.AutoHeight = false;
            this.chc4.Caption = "Check";
            this.chc4.Name = "chc4";
            // 
            // btnPrint
            // 
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Location = new System.Drawing.Point(807, 462);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 32);
            this.btnPrint.TabIndex = 19;
            this.btnPrint.Text = "Proses";
            // 
            // btnChkDetail
            // 
            this.btnChkDetail.Location = new System.Drawing.Point(226, 467);
            this.btnChkDetail.Name = "btnChkDetail";
            this.btnChkDetail.Size = new System.Drawing.Size(94, 23);
            this.btnChkDetail.TabIndex = 20;
            this.btnChkDetail.Text = "Check Rincian";
            // 
            // btnChkInvoice
            // 
            this.btnChkInvoice.Location = new System.Drawing.Point(326, 467);
            this.btnChkInvoice.Name = "btnChkInvoice";
            this.btnChkInvoice.Size = new System.Drawing.Size(100, 23);
            this.btnChkInvoice.TabIndex = 21;
            this.btnChkInvoice.Text = "Check Kwitansi";
            // 
            // btnChkDelivery
            // 
            this.btnChkDelivery.Location = new System.Drawing.Point(432, 467);
            this.btnChkDelivery.Name = "btnChkDelivery";
            this.btnChkDelivery.Size = new System.Drawing.Size(120, 23);
            this.btnChkDelivery.TabIndex = 22;
            this.btnChkDelivery.Text = "Check Tanda Terima";
            // 
            // btnChkFaktur
            // 
            this.btnChkFaktur.Location = new System.Drawing.Point(558, 467);
            this.btnChkFaktur.Name = "btnChkFaktur";
            this.btnChkFaktur.Size = new System.Drawing.Size(97, 23);
            this.btnChkFaktur.TabIndex = 23;
            this.btnChkFaktur.Text = "Check Faktur";
            // 
            // InvoicePrintingForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(897, 496);
            this.Controls.Add(this.btnChkFaktur);
            this.Controls.Add(this.btnChkDelivery);
            this.Controls.Add(this.btnChkInvoice);
            this.Controls.Add(this.btnChkDetail);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GridInvoice);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "InvoicePrintingForm";
            this.Text = "Cetak Invoice";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFaktur.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDelivery.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxInvoice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDetail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chc2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chc3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chc4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnFind;
        private Common.Component.dLookup lkpBranch;
        private System.Windows.Forms.Label label2;
        private Common.Component.dComboBox cbxMonth;
        private Common.Component.dComboBox cbxYear;
        private System.Windows.Forms.Label label1;
        private Common.Component.dComboBox cmbTaxInvoice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.GridControl GridInvoice;
        private DevExpress.XtraGrid.Views.Grid.GridView InvoiceView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.ButtonEdit tbxDetail;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.ButtonEdit tbxDelivery;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.ButtonEdit tbxInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chc1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chc2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chc3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chc4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.SimpleButton btnChkDetail;
        private DevExpress.XtraEditors.SimpleButton btnChkInvoice;
        private DevExpress.XtraEditors.SimpleButton btnChkDelivery;
        private DevExpress.XtraEditors.SimpleButton btnChkFaktur;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private Common.Component.dCheckBox chkContinous2;
        private Common.Component.dCheckBox chkContinous1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.ButtonEdit tbxFaktur;
    }
}