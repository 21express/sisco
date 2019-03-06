namespace SISCO.Presentation.Finance.Forms
{
    partial class PaymentInCollectOutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentInCollectOutForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label7 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxBarcode = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.btnTambah = new DevExpress.XtraEditors.SimpleButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.tbxOrigin = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.tbxAmount = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.tbxPayment = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.tbxDescription = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.GridCollectOut = new DevExpress.XtraGrid.GridControl();
            this.CollectOutView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clInvoiceId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clInvoiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clInvoiceDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clInvoiceTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clInvoiceBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tbxTotalSales = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.tbxAdjustment = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.tbxTotal = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.lkpTransactional = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.lkpAccount = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxOrigin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPayment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridCollectOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectOutView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotalSales.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAdjustment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpTransactional.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpAccount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Meiryo", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(459, 462);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 15);
            this.label7.TabIndex = 52;
            this.label7.Text = "(Jika ada pengurangan  / claim)";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(628, 488);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 17);
            this.label16.TabIndex = 48;
            this.label16.Text = "Total";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(628, 462);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 17);
            this.label15.TabIndex = 47;
            this.label15.Text = "Adjustment";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(628, 436);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 17);
            this.label14.TabIndex = 46;
            this.label14.Text = "Total Sales";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbxBarcode);
            this.panel1.Controls.Add(this.btnTambah);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(531, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 78);
            this.panel1.TabIndex = 6;
            // 
            // tbxBarcode
            // 
            this.tbxBarcode.Capslock = true;
            this.tbxBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxBarcode.FieldLabel = null;
            this.tbxBarcode.Location = new System.Drawing.Point(74, 11);
            this.tbxBarcode.Name = "tbxBarcode";
            this.tbxBarcode.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxBarcode.Size = new System.Drawing.Size(221, 24);
            this.tbxBarcode.TabIndex = 6;
            this.tbxBarcode.ValidationRules = null;
            // 
            // btnTambah
            // 
            this.btnTambah.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.btnTambah.Appearance.Options.UseFont = true;
            this.btnTambah.Location = new System.Drawing.Point(74, 38);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(75, 29);
            this.btnTambah.TabIndex = 7;
            this.btnTambah.Text = "TAMBAH";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(21, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "No. CN";
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(20, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 42;
            this.label5.Text = "Description";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(20, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 40;
            this.label4.Text = "Payment Type";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(286, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 38;
            this.label3.Text = "Amount";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(20, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 19);
            this.label2.TabIndex = 36;
            this.label2.Text = "Branch";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(20, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 34;
            this.label1.Text = "Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(110, 44);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxDate.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxDate.Properties.Appearance.Options.UseBackColor = true;
            this.tbxDate.Properties.Appearance.Options.UseFont = true;
            this.tbxDate.Properties.AutoHeight = false;
            this.tbxDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.tbxDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxDate.Properties.NullText = "<<Choose...>>";
            this.tbxDate.Size = new System.Drawing.Size(137, 24);
            this.tbxDate.TabIndex = 1;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // tbxOrigin
            // 
            this.tbxOrigin.AutoCompleteDataManager = null;
            this.tbxOrigin.AutoCompleteDisplayFormater = null;
            this.tbxOrigin.AutoCompleteInitialized = false;
            this.tbxOrigin.AutocompleteMinimumTextLength = 0;
            this.tbxOrigin.AutoCompleteText = null;
            this.tbxOrigin.AutoCompleteWhereExpression = null;
            this.tbxOrigin.AutoCompleteWheretermFormater = null;
            this.tbxOrigin.ClearOnLeave = true;
            this.tbxOrigin.DisplayString = null;
            this.tbxOrigin.FieldLabel = null;
            this.tbxOrigin.Location = new System.Drawing.Point(110, 70);
            this.tbxOrigin.LookupPopup = null;
            this.tbxOrigin.Name = "tbxOrigin";
            this.tbxOrigin.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxOrigin.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxOrigin.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxOrigin.Properties.Appearance.Options.UseBackColor = true;
            this.tbxOrigin.Properties.Appearance.Options.UseFont = true;
            this.tbxOrigin.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxOrigin.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxOrigin.Properties.AutoCompleteDataManager = null;
            this.tbxOrigin.Properties.AutoCompleteDisplayFormater = null;
            this.tbxOrigin.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxOrigin.Properties.AutoCompleteText = null;
            this.tbxOrigin.Properties.AutoCompleteWhereExpression = null;
            this.tbxOrigin.Properties.AutoCompleteWheretermFormater = null;
            this.tbxOrigin.Properties.AutoHeight = false;
            this.tbxOrigin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxOrigin.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "", null, null, true)});
            this.tbxOrigin.Properties.LookupPopup = null;
            this.tbxOrigin.Properties.NullText = "<<Choose...>>";
            this.tbxOrigin.Size = new System.Drawing.Size(285, 24);
            this.tbxOrigin.TabIndex = 2;
            this.tbxOrigin.ValidationRules = null;
            this.tbxOrigin.Value = null;
            // 
            // tbxAmount
            // 
            this.tbxAmount.EditMask = "###,###,###,###,###,##0.00";
            this.tbxAmount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxAmount.FieldLabel = null;
            this.tbxAmount.Location = new System.Drawing.Point(376, 174);
            this.tbxAmount.Name = "tbxAmount";
            this.tbxAmount.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxAmount.Properties.AllowMouseWheel = false;
            this.tbxAmount.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxAmount.Properties.Appearance.Options.UseFont = true;
            this.tbxAmount.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxAmount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxAmount.Properties.Mask.BeepOnError = true;
            this.tbxAmount.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxAmount.ReadOnly = false;
            this.tbxAmount.Size = new System.Drawing.Size(137, 24);
            this.tbxAmount.TabIndex = 3;
            this.tbxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxAmount.ValidationRules = null;
            this.tbxAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // tbxPayment
            // 
            this.tbxPayment.AutoCompleteDataManager = null;
            this.tbxPayment.AutoCompleteDisplayFormater = null;
            this.tbxPayment.AutoCompleteInitialized = false;
            this.tbxPayment.AutocompleteMinimumTextLength = 0;
            this.tbxPayment.AutoCompleteText = null;
            this.tbxPayment.AutoCompleteWhereExpression = null;
            this.tbxPayment.AutoCompleteWheretermFormater = null;
            this.tbxPayment.ClearOnLeave = true;
            this.tbxPayment.DisplayString = null;
            this.tbxPayment.FieldLabel = null;
            this.tbxPayment.Location = new System.Drawing.Point(110, 96);
            this.tbxPayment.LookupPopup = null;
            this.tbxPayment.Name = "tbxPayment";
            this.tbxPayment.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPayment.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxPayment.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxPayment.Properties.Appearance.Options.UseBackColor = true;
            this.tbxPayment.Properties.Appearance.Options.UseFont = true;
            this.tbxPayment.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxPayment.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxPayment.Properties.AutoCompleteDataManager = null;
            this.tbxPayment.Properties.AutoCompleteDisplayFormater = null;
            this.tbxPayment.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxPayment.Properties.AutoCompleteText = null;
            this.tbxPayment.Properties.AutoCompleteWhereExpression = null;
            this.tbxPayment.Properties.AutoCompleteWheretermFormater = null;
            this.tbxPayment.Properties.AutoHeight = false;
            this.tbxPayment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxPayment.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.tbxPayment.Properties.LookupPopup = null;
            this.tbxPayment.Properties.NullText = "<<Choose...>>";
            this.tbxPayment.Size = new System.Drawing.Size(137, 24);
            this.tbxPayment.TabIndex = 4;
            this.tbxPayment.ValidationRules = null;
            this.tbxPayment.Value = null;
            // 
            // tbxDescription
            // 
            this.tbxDescription.Capslock = true;
            this.tbxDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDescription.FieldLabel = null;
            this.tbxDescription.Location = new System.Drawing.Point(110, 122);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDescription.Size = new System.Drawing.Size(285, 24);
            this.tbxDescription.TabIndex = 5;
            this.tbxDescription.ValidationRules = null;
            // 
            // GridCollectOut
            // 
            this.GridCollectOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridCollectOut.Location = new System.Drawing.Point(0, 202);
            this.GridCollectOut.MainView = this.CollectOutView;
            this.GridCollectOut.Name = "GridCollectOut";
            this.GridCollectOut.Size = new System.Drawing.Size(851, 228);
            this.GridCollectOut.TabIndex = 58;
            this.GridCollectOut.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.CollectOutView});
            // 
            // CollectOutView
            // 
            this.CollectOutView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clNo,
            this.clInvoiceId,
            this.clInvoiceCode,
            this.clInvoiceDate,
            this.clInvoiceTotal,
            this.clInvoiceBalance,
            this.clPayment,
            this.clBalance,
            this.clChecked,
            this.clState,
            this.gridColumn1,
            this.gridColumn2});
            this.CollectOutView.GridControl = this.GridCollectOut;
            this.CollectOutView.Name = "CollectOutView";
            this.CollectOutView.OptionsView.ShowGroupPanel = false;
            // 
            // clNo
            // 
            this.clNo.Caption = "No";
            this.clNo.Name = "clNo";
            this.clNo.Visible = true;
            this.clNo.VisibleIndex = 0;
            // 
            // clInvoiceId
            // 
            this.clInvoiceId.Caption = "Invoice Id";
            this.clInvoiceId.FieldName = "InvoiceId";
            this.clInvoiceId.Name = "clInvoiceId";
            // 
            // clInvoiceCode
            // 
            this.clInvoiceCode.Caption = "Inv";
            this.clInvoiceCode.FieldName = "InvoiceCode";
            this.clInvoiceCode.Name = "clInvoiceCode";
            this.clInvoiceCode.OptionsColumn.AllowEdit = false;
            this.clInvoiceCode.OptionsColumn.AllowFocus = false;
            this.clInvoiceCode.OptionsColumn.AllowMove = false;
            this.clInvoiceCode.OptionsColumn.ReadOnly = true;
            this.clInvoiceCode.Visible = true;
            this.clInvoiceCode.VisibleIndex = 1;
            // 
            // clInvoiceDate
            // 
            this.clInvoiceDate.Caption = "Date";
            this.clInvoiceDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.clInvoiceDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clInvoiceDate.FieldName = "InvoiceDate";
            this.clInvoiceDate.Name = "clInvoiceDate";
            this.clInvoiceDate.OptionsColumn.AllowEdit = false;
            this.clInvoiceDate.OptionsColumn.AllowFocus = false;
            this.clInvoiceDate.OptionsColumn.AllowMove = false;
            this.clInvoiceDate.OptionsColumn.ReadOnly = true;
            this.clInvoiceDate.Visible = true;
            this.clInvoiceDate.VisibleIndex = 2;
            // 
            // clInvoiceTotal
            // 
            this.clInvoiceTotal.Caption = "Amount";
            this.clInvoiceTotal.DisplayFormat.FormatString = "#,#0";
            this.clInvoiceTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clInvoiceTotal.FieldName = "InvoiceTotal";
            this.clInvoiceTotal.Name = "clInvoiceTotal";
            this.clInvoiceTotal.OptionsColumn.AllowEdit = false;
            this.clInvoiceTotal.OptionsColumn.AllowFocus = false;
            this.clInvoiceTotal.OptionsColumn.AllowMove = false;
            this.clInvoiceTotal.OptionsColumn.ReadOnly = true;
            this.clInvoiceTotal.Visible = true;
            this.clInvoiceTotal.VisibleIndex = 3;
            // 
            // clInvoiceBalance
            // 
            this.clInvoiceBalance.Caption = "Amount Due";
            this.clInvoiceBalance.DisplayFormat.FormatString = "#,#0";
            this.clInvoiceBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clInvoiceBalance.FieldName = "InvoiceBalance";
            this.clInvoiceBalance.Name = "clInvoiceBalance";
            this.clInvoiceBalance.OptionsColumn.AllowEdit = false;
            this.clInvoiceBalance.OptionsColumn.AllowFocus = false;
            this.clInvoiceBalance.OptionsColumn.AllowMove = false;
            this.clInvoiceBalance.OptionsColumn.ReadOnly = true;
            this.clInvoiceBalance.Visible = true;
            this.clInvoiceBalance.VisibleIndex = 4;
            // 
            // clPayment
            // 
            this.clPayment.Caption = "Payment";
            this.clPayment.DisplayFormat.FormatString = "#,#0";
            this.clPayment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clPayment.FieldName = "Payment";
            this.clPayment.Name = "clPayment";
            this.clPayment.Visible = true;
            this.clPayment.VisibleIndex = 5;
            // 
            // clBalance
            // 
            this.clBalance.Caption = "Balance";
            this.clBalance.DisplayFormat.FormatString = "#,#0";
            this.clBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clBalance.FieldName = "Balance";
            this.clBalance.Name = "clBalance";
            this.clBalance.OptionsColumn.AllowEdit = false;
            this.clBalance.OptionsColumn.AllowFocus = false;
            this.clBalance.OptionsColumn.AllowMove = false;
            this.clBalance.OptionsColumn.ReadOnly = true;
            this.clBalance.Visible = true;
            this.clBalance.VisibleIndex = 6;
            // 
            // clChecked
            // 
            this.clChecked.FieldName = "Checked";
            this.clChecked.Name = "clChecked";
            this.clChecked.Visible = true;
            this.clChecked.VisibleIndex = 7;
            // 
            // clState
            // 
            this.clState.Caption = "State";
            this.clState.FieldName = "StateChange2";
            this.clState.Name = "clState";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "CollectPaymentMethod";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.FieldName = "Id";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // tbxTotalSales
            // 
            this.tbxTotalSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxTotalSales.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotalSales.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTotalSales.FieldLabel = null;
            this.tbxTotalSales.Location = new System.Drawing.Point(703, 433);
            this.tbxTotalSales.Name = "tbxTotalSales";
            this.tbxTotalSales.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTotalSales.Properties.AllowMouseWheel = false;
            this.tbxTotalSales.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTotalSales.Properties.Appearance.Options.UseFont = true;
            this.tbxTotalSales.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTotalSales.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTotalSales.Properties.Mask.BeepOnError = true;
            this.tbxTotalSales.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotalSales.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxTotalSales.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTotalSales.Properties.ReadOnly = true;
            this.tbxTotalSales.ReadOnly = true;
            this.tbxTotalSales.Size = new System.Drawing.Size(141, 24);
            this.tbxTotalSales.TabIndex = 0;
            this.tbxTotalSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxTotalSales.ValidationRules = null;
            this.tbxTotalSales.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // tbxAdjustment
            // 
            this.tbxAdjustment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxAdjustment.EditMask = "###,###,###,###,###,##0.00";
            this.tbxAdjustment.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxAdjustment.FieldLabel = null;
            this.tbxAdjustment.Location = new System.Drawing.Point(703, 459);
            this.tbxAdjustment.Name = "tbxAdjustment";
            this.tbxAdjustment.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxAdjustment.Properties.AllowMouseWheel = false;
            this.tbxAdjustment.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxAdjustment.Properties.Appearance.Options.UseFont = true;
            this.tbxAdjustment.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxAdjustment.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxAdjustment.Properties.Mask.BeepOnError = true;
            this.tbxAdjustment.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxAdjustment.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxAdjustment.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxAdjustment.ReadOnly = false;
            this.tbxAdjustment.Size = new System.Drawing.Size(141, 24);
            this.tbxAdjustment.TabIndex = 8;
            this.tbxAdjustment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxAdjustment.ValidationRules = null;
            this.tbxAdjustment.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // tbxTotal
            // 
            this.tbxTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxTotal.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTotal.FieldLabel = null;
            this.tbxTotal.Location = new System.Drawing.Point(703, 485);
            this.tbxTotal.Name = "tbxTotal";
            this.tbxTotal.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTotal.Properties.AllowMouseWheel = false;
            this.tbxTotal.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTotal.Properties.Appearance.Options.UseFont = true;
            this.tbxTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTotal.Properties.Mask.BeepOnError = true;
            this.tbxTotal.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTotal.Properties.ReadOnly = true;
            this.tbxTotal.ReadOnly = true;
            this.tbxTotal.Size = new System.Drawing.Size(141, 24);
            this.tbxTotal.TabIndex = 61;
            this.tbxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxTotal.ValidationRules = null;
            this.tbxTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lkpTransactional
            // 
            this.lkpTransactional.AutoCompleteDataManager = null;
            this.lkpTransactional.AutoCompleteDisplayFormater = null;
            this.lkpTransactional.AutoCompleteInitialized = false;
            this.lkpTransactional.AutocompleteMinimumTextLength = 0;
            this.lkpTransactional.AutoCompleteText = null;
            this.lkpTransactional.AutoCompleteWhereExpression = null;
            this.lkpTransactional.AutoCompleteWheretermFormater = null;
            this.lkpTransactional.ClearOnLeave = true;
            this.lkpTransactional.DisplayString = null;
            this.lkpTransactional.FieldLabel = null;
            this.lkpTransactional.Location = new System.Drawing.Point(110, 174);
            this.lkpTransactional.LookupPopup = null;
            this.lkpTransactional.Name = "lkpTransactional";
            this.lkpTransactional.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpTransactional.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lkpTransactional.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpTransactional.Properties.Appearance.Options.UseBackColor = true;
            this.lkpTransactional.Properties.Appearance.Options.UseFont = true;
            this.lkpTransactional.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpTransactional.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpTransactional.Properties.AutoCompleteDataManager = null;
            this.lkpTransactional.Properties.AutoCompleteDisplayFormater = null;
            this.lkpTransactional.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpTransactional.Properties.AutoCompleteText = null;
            this.lkpTransactional.Properties.AutoCompleteWhereExpression = null;
            this.lkpTransactional.Properties.AutoCompleteWheretermFormater = null;
            this.lkpTransactional.Properties.AutoHeight = false;
            this.lkpTransactional.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpTransactional.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpTransactional.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpTransactional.Properties.LookupPopup = null;
            this.lkpTransactional.Properties.NullText = "<<Choose...>>";
            this.lkpTransactional.Size = new System.Drawing.Size(164, 24);
            this.lkpTransactional.TabIndex = 63;
            this.lkpTransactional.ValidationRules = null;
            this.lkpTransactional.Value = null;
            // 
            // label20
            // 
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(1, 177);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(105, 17);
            this.label20.TabIndex = 65;
            this.label20.Text = "Transaksi Bank";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.lkpAccount.Location = new System.Drawing.Point(110, 148);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpAccount.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.lkpAccount.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpAccount.Properties.LookupPopup = null;
            this.lkpAccount.Properties.NullText = "<<Choose...>>";
            this.lkpAccount.Size = new System.Drawing.Size(231, 24);
            this.lkpAccount.TabIndex = 62;
            this.lkpAccount.ValidationRules = null;
            this.lkpAccount.Value = null;
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(20, 150);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(84, 17);
            this.label19.TabIndex = 64;
            this.label19.Text = "No. Rekening";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PaymentInCollectOutForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(851, 513);
            this.Controls.Add(this.lkpTransactional);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lkpAccount);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.tbxTotal);
            this.Controls.Add(this.tbxAdjustment);
            this.Controls.Add(this.tbxTotalSales);
            this.Controls.Add(this.GridCollectOut);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.tbxPayment);
            this.Controls.Add(this.tbxAmount);
            this.Controls.Add(this.tbxOrigin);
            this.Controls.Add(this.tbxDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PaymentInCollectOutForm";
            this.Text = "Finance - Payment In Collect Out";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.tbxDate, 0);
            this.Controls.SetChildIndex(this.tbxOrigin, 0);
            this.Controls.SetChildIndex(this.tbxAmount, 0);
            this.Controls.SetChildIndex(this.tbxPayment, 0);
            this.Controls.SetChildIndex(this.tbxDescription, 0);
            this.Controls.SetChildIndex(this.GridCollectOut, 0);
            this.Controls.SetChildIndex(this.tbxTotalSales, 0);
            this.Controls.SetChildIndex(this.tbxAdjustment, 0);
            this.Controls.SetChildIndex(this.tbxTotal, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.lkpAccount, 0);
            this.Controls.SetChildIndex(this.label20, 0);
            this.Controls.SetChildIndex(this.lkpTransactional, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxOrigin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPayment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridCollectOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectOutView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotalSales.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAdjustment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpTransactional.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpAccount.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnTambah;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Common.Component.dTextBox tbxBarcode;
        private Common.Component.dCalendar tbxDate;
        private Common.Component.dLookup tbxOrigin;
        private Common.Component.dTextBoxNumber tbxAmount;
        private Common.Component.dLookup tbxPayment;
        private Common.Component.dTextBox tbxDescription;
        private DevExpress.XtraGrid.GridControl GridCollectOut;
        private DevExpress.XtraGrid.Views.Grid.GridView CollectOutView;
        private Common.Component.dTextBoxNumber tbxTotalSales;
        private Common.Component.dTextBoxNumber tbxAdjustment;
        private Common.Component.dTextBoxNumber tbxTotal;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private DevExpress.XtraGrid.Columns.GridColumn clInvoiceId;
        private DevExpress.XtraGrid.Columns.GridColumn clInvoiceCode;
        private DevExpress.XtraGrid.Columns.GridColumn clInvoiceDate;
        private DevExpress.XtraGrid.Columns.GridColumn clInvoiceTotal;
        private DevExpress.XtraGrid.Columns.GridColumn clInvoiceBalance;
        private DevExpress.XtraGrid.Columns.GridColumn clPayment;
        private DevExpress.XtraGrid.Columns.GridColumn clBalance;
        private DevExpress.XtraGrid.Columns.GridColumn clChecked;
        private DevExpress.XtraGrid.Columns.GridColumn clState;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private Common.Component.dLookup lkpTransactional;
        private System.Windows.Forms.Label label20;
        private Common.Component.dLookup lkpAccount;
        private System.Windows.Forms.Label label19;
    }
}