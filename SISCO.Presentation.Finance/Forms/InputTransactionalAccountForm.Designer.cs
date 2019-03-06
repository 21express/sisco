namespace SISCO.Presentation.Finance.Forms
{
    partial class InputTransactionalAccountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputTransactionalAccountForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblKcp = new System.Windows.Forms.Label();
            this.lblBank = new System.Windows.Forms.Label();
            this.lblNo = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lkpAccount = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.tbxCredit = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tbxDebit = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tbxDescription = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.GridTransactional = new DevExpress.XtraGrid.GridControl();
            this.TransactionalView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tbxFilter = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.btnFilter = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCredit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDebit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridTransactional)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionalView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFilter.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFilter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.lblKcp);
            this.groupControl1.Controls.Add(this.lblBank);
            this.groupControl1.Controls.Add(this.lblNo);
            this.groupControl1.Controls.Add(this.lblAddress);
            this.groupControl1.Controls.Add(this.lblName);
            this.groupControl1.Controls.Add(this.lkpAccount);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(781, 143);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Pilih Rekening";
            // 
            // lblKcp
            // 
            this.lblKcp.AutoSize = true;
            this.lblKcp.Location = new System.Drawing.Point(476, 84);
            this.lblKcp.Name = "lblKcp";
            this.lblKcp.Size = new System.Drawing.Size(156, 17);
            this.lblKcp.TabIndex = 5;
            this.lblKcp.Text = "Kantor Cabang Pembantu :";
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Location = new System.Drawing.Point(476, 57);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(78, 17);
            this.lblBank.TabIndex = 4;
            this.lblBank.Text = "Nama Bank :";
            // 
            // lblNo
            // 
            this.lblNo.AutoSize = true;
            this.lblNo.Location = new System.Drawing.Point(476, 31);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(90, 17);
            this.lblNo.TabIndex = 3;
            this.lblNo.Text = "No. Rekening :";
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(9, 84);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(347, 52);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Alamat :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 60);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(128, 17);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Rekening Atas Nama :";
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
            this.lkpAccount.DisplayString = null;
            this.lkpAccount.FieldLabel = null;
            this.lkpAccount.Location = new System.Drawing.Point(10, 27);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpAccount.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpAccount.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpAccount.Properties.LookupPopup = null;
            this.lkpAccount.Properties.NullText = "<<Choose...>>";
            this.lkpAccount.Size = new System.Drawing.Size(346, 24);
            this.lkpAccount.TabIndex = 1;
            this.lkpAccount.ValidationRules = null;
            this.lkpAccount.Value = null;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnAdd);
            this.groupControl2.Controls.Add(this.tbxCredit);
            this.groupControl2.Controls.Add(this.label4);
            this.groupControl2.Controls.Add(this.tbxDebit);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Controls.Add(this.tbxDescription);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.tbxDate);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Location = new System.Drawing.Point(3, 149);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(781, 92);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Tambah Transaksi";
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Location = new System.Drawing.Point(745, 56);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(33, 25);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "+";
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
            this.tbxCredit.Location = new System.Drawing.Point(570, 57);
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
            this.tbxCredit.Size = new System.Drawing.Size(171, 24);
            this.tbxCredit.TabIndex = 5;
            this.tbxCredit.TextAlign = null;
            this.tbxCredit.ValidationRules = null;
            this.tbxCredit.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(567, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Kredit :";
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
            this.tbxDebit.Location = new System.Drawing.Point(388, 57);
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
            this.tbxDebit.Size = new System.Drawing.Size(171, 24);
            this.tbxDebit.TabIndex = 4;
            this.tbxDebit.TextAlign = null;
            this.tbxDebit.ValidationRules = null;
            this.tbxDebit.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(385, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Debit :";
            // 
            // tbxDescription
            // 
            this.tbxDescription.Capslock = true;
            this.tbxDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDescription.FieldLabel = null;
            this.tbxDescription.Location = new System.Drawing.Point(141, 57);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDescription.Size = new System.Drawing.Size(236, 24);
            this.tbxDescription.TabIndex = 3;
            this.tbxDescription.ValidationRules = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Rincian / No. Referensi";
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(15, 57);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxDate.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxDate.Properties.Appearance.Options.UseBackColor = true;
            this.tbxDate.Properties.Appearance.Options.UseFont = true;
            this.tbxDate.Properties.AutoHeight = false;
            this.tbxDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
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
            this.tbxDate.TabIndex = 2;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tanggal";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.btnFilter);
            this.groupControl3.Controls.Add(this.label5);
            this.groupControl3.Controls.Add(this.tbxFilter);
            this.groupControl3.Controls.Add(this.GridTransactional);
            this.groupControl3.Location = new System.Drawing.Point(3, 244);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(781, 249);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "Rincian Transaksi";
            // 
            // GridTransactional
            // 
            this.GridTransactional.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridTransactional.Location = new System.Drawing.Point(4, 48);
            this.GridTransactional.MainView = this.TransactionalView;
            this.GridTransactional.Name = "GridTransactional";
            this.GridTransactional.Size = new System.Drawing.Size(774, 198);
            this.GridTransactional.TabIndex = 0;
            this.GridTransactional.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.TransactionalView});
            // 
            // TransactionalView
            // 
            this.TransactionalView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.TransactionalView.GridControl = this.GridTransactional;
            this.TransactionalView.Name = "TransactionalView";
            this.TransactionalView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "No. ";
            this.gridColumn8.FieldName = "RowNum";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            this.gridColumn8.Width = 63;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tgl";
            this.gridColumn3.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "DateProcess";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 80;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Rincian / No. Referensi";
            this.gridColumn4.FieldName = "Description";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 228;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Debit";
            this.gridColumn5.DisplayFormat.FormatString = "n2";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "DebitTotalAmount";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 120;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Kredit";
            this.gridColumn6.DisplayFormat.FormatString = "n2";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "CreditTotalAmount";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 98;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Saldo";
            this.gridColumn7.DisplayFormat.FormatString = "n2";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "Balance";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 107;
            // 
            // tbxFilter
            // 
            this.tbxFilter.EditValue = null;
            this.tbxFilter.FieldLabel = null;
            this.tbxFilter.FormatDateTime = "dd-MM-yyyy";
            this.tbxFilter.Location = new System.Drawing.Point(83, 22);
            this.tbxFilter.Name = "tbxFilter";
            this.tbxFilter.Nullable = false;
            this.tbxFilter.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFilter.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.tbxFilter.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxFilter.Properties.Appearance.Options.UseBackColor = true;
            this.tbxFilter.Properties.Appearance.Options.UseFont = true;
            this.tbxFilter.Properties.AutoHeight = false;
            this.tbxFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dCalendar1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.tbxFilter.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxFilter.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxFilter.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxFilter.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxFilter.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxFilter.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxFilter.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxFilter.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxFilter.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxFilter.Size = new System.Drawing.Size(115, 24);
            this.tbxFilter.TabIndex = 3;
            this.tbxFilter.ValidationRules = null;
            this.tbxFilter.Value = new System.DateTime(((long)(0)));
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Filter Tgl :";
            // 
            // btnFilter
            // 
            this.btnFilter.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnFilter.Appearance.Options.UseFont = true;
            this.btnFilter.Location = new System.Drawing.Point(202, 22);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(49, 25);
            this.btnFilter.TabIndex = 7;
            this.btnFilter.Text = "Lihat";
            // 
            // InputTransactionalAccountForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(787, 496);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "InputTransactionalAccountForm";
            this.Text = "Input Rekening Koran";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCredit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDebit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridTransactional)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionalView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFilter.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFilter.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private Common.Component.dLookup lkpAccount;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblKcp;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label lblNo;
        private System.Windows.Forms.Label lblAddress;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private Common.Component.dTextBoxNumber tbxCredit;
        private System.Windows.Forms.Label label4;
        private Common.Component.dTextBoxNumber tbxDebit;
        private System.Windows.Forms.Label label3;
        private Common.Component.dTextBox tbxDescription;
        private System.Windows.Forms.Label label2;
        private Common.Component.dCalendar tbxDate;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl GridTransactional;
        private DevExpress.XtraGrid.Views.Grid.GridView TransactionalView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.SimpleButton btnFilter;
        private System.Windows.Forms.Label label5;
        private Common.Component.dCalendar tbxFilter;

    }
}