namespace SISCO.Presentation.Finance.Forms
{
    partial class PaymentInCounterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentInCounterForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTambah = new DevExpress.XtraEditors.SimpleButton();
            this.tbxBarcode = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.GridPayment = new DevExpress.XtraGrid.GridControl();
            this.PaymentView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clInvTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clInvBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clInvoiceId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPaid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clInvDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.tbxTotalSales = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.tbxAdjustment = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.tbxTotal = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tbxDescription = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.lkpAccount = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.lkpTransactional = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotalSales.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAdjustment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpTransactional.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(62, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(645, 465);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 17);
            this.label16.TabIndex = 23;
            this.label16.Text = "Total";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(609, 439);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 17);
            this.label15.TabIndex = 22;
            this.label15.Text = "Adjustment";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(614, 412);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 17);
            this.label14.TabIndex = 21;
            this.label14.Text = "Total Sales";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnTambah);
            this.panel1.Controls.Add(this.tbxBarcode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(508, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 74);
            this.panel1.TabIndex = 5;
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(67, 35);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(75, 28);
            this.btnTambah.TabIndex = 6;
            this.btnTambah.Text = "Tambah";
            // 
            // tbxBarcode
            // 
            this.tbxBarcode.Capslock = true;
            this.tbxBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxBarcode.FieldLabel = null;
            this.tbxBarcode.Location = new System.Drawing.Point(67, 9);
            this.tbxBarcode.Name = "tbxBarcode";
            this.tbxBarcode.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxBarcode.Size = new System.Drawing.Size(224, 24);
            this.tbxBarcode.TabIndex = 5;
            this.tbxBarcode.ValidationRules = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "No. STT";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Meiryo", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(441, 440);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 15);
            this.label7.TabIndex = 34;
            this.label7.Text = "(Jika ada pengurangan  / claim)";
            // 
            // GridPayment
            // 
            this.GridPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridPayment.Location = new System.Drawing.Point(2, 150);
            this.GridPayment.MainView = this.PaymentView;
            this.GridPayment.Name = "GridPayment";
            this.GridPayment.Size = new System.Drawing.Size(808, 255);
            this.GridPayment.TabIndex = 36;
            this.GridPayment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PaymentView});
            // 
            // PaymentView
            // 
            this.PaymentView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clNo,
            this.clShipment,
            this.clDate,
            this.clInvTotal,
            this.clPayment,
            this.clChecked,
            this.clInvBalance,
            this.clInvoiceId,
            this.clState,
            this.clBalance,
            this.clPaid,
            this.clInvDate,
            this.clId});
            this.PaymentView.GridControl = this.GridPayment;
            this.PaymentView.Name = "PaymentView";
            this.PaymentView.OptionsView.ShowGroupPanel = false;
            // 
            // clNo
            // 
            this.clNo.Caption = "No";
            this.clNo.Name = "clNo";
            this.clNo.OptionsColumn.AllowEdit = false;
            this.clNo.OptionsColumn.AllowFocus = false;
            this.clNo.OptionsColumn.AllowMove = false;
            this.clNo.OptionsColumn.ReadOnly = true;
            this.clNo.Visible = true;
            this.clNo.VisibleIndex = 0;
            this.clNo.Width = 34;
            // 
            // clShipment
            // 
            this.clShipment.Caption = "Shipment";
            this.clShipment.FieldName = "InvoiceCode";
            this.clShipment.Name = "clShipment";
            this.clShipment.OptionsColumn.AllowEdit = false;
            this.clShipment.OptionsColumn.AllowFocus = false;
            this.clShipment.OptionsColumn.AllowMove = false;
            this.clShipment.OptionsColumn.ReadOnly = true;
            this.clShipment.Visible = true;
            this.clShipment.VisibleIndex = 1;
            this.clShipment.Width = 190;
            // 
            // clDate
            // 
            this.clDate.Caption = "Date";
            this.clDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.clDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clDate.FieldName = "InvoiceDate";
            this.clDate.Name = "clDate";
            this.clDate.OptionsColumn.AllowEdit = false;
            this.clDate.OptionsColumn.AllowFocus = false;
            this.clDate.OptionsColumn.AllowMove = false;
            this.clDate.OptionsColumn.ReadOnly = true;
            this.clDate.Visible = true;
            this.clDate.VisibleIndex = 2;
            this.clDate.Width = 145;
            // 
            // clInvTotal
            // 
            this.clInvTotal.Caption = "Amount";
            this.clInvTotal.DisplayFormat.FormatString = "#,#0";
            this.clInvTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clInvTotal.FieldName = "InvoiceTotal";
            this.clInvTotal.Name = "clInvTotal";
            this.clInvTotal.OptionsColumn.AllowEdit = false;
            this.clInvTotal.OptionsColumn.AllowFocus = false;
            this.clInvTotal.OptionsColumn.AllowMove = false;
            this.clInvTotal.OptionsColumn.ReadOnly = true;
            this.clInvTotal.Visible = true;
            this.clInvTotal.VisibleIndex = 3;
            this.clInvTotal.Width = 180;
            // 
            // clPayment
            // 
            this.clPayment.Caption = "Cash";
            this.clPayment.DisplayFormat.FormatString = "#,#0";
            this.clPayment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clPayment.FieldName = "Payment";
            this.clPayment.Name = "clPayment";
            this.clPayment.OptionsColumn.AllowEdit = false;
            this.clPayment.OptionsColumn.AllowFocus = false;
            this.clPayment.OptionsColumn.AllowMove = false;
            this.clPayment.OptionsColumn.ReadOnly = true;
            this.clPayment.Visible = true;
            this.clPayment.VisibleIndex = 4;
            this.clPayment.Width = 128;
            // 
            // clChecked
            // 
            this.clChecked.Caption = " ";
            this.clChecked.FieldName = "Checked";
            this.clChecked.Name = "clChecked";
            this.clChecked.Visible = true;
            this.clChecked.VisibleIndex = 5;
            this.clChecked.Width = 37;
            // 
            // clInvBalance
            // 
            this.clInvBalance.Caption = "Invoice Balance";
            this.clInvBalance.FieldName = "InvoiceBalance";
            this.clInvBalance.Name = "clInvBalance";
            // 
            // clInvoiceId
            // 
            this.clInvoiceId.Caption = "Id";
            this.clInvoiceId.FieldName = "InvoiceId";
            this.clInvoiceId.Name = "clInvoiceId";
            // 
            // clState
            // 
            this.clState.Caption = "State";
            this.clState.FieldName = "StateChange2";
            this.clState.Name = "clState";
            // 
            // clBalance
            // 
            this.clBalance.Caption = "Balance";
            this.clBalance.FieldName = "Balance";
            this.clBalance.Name = "clBalance";
            this.clBalance.OptionsColumn.AllowEdit = false;
            this.clBalance.OptionsColumn.AllowFocus = false;
            this.clBalance.OptionsColumn.AllowMove = false;
            this.clBalance.OptionsColumn.ReadOnly = true;
            // 
            // clPaid
            // 
            this.clPaid.Caption = "Paid";
            this.clPaid.FieldName = "Paid";
            this.clPaid.Name = "clPaid";
            // 
            // clInvDate
            // 
            this.clInvDate.Caption = "Invoice Date";
            this.clInvDate.FieldName = "InvoiceDate";
            this.clInvDate.Name = "clInvDate";
            // 
            // clId
            // 
            this.clId.Caption = "Id";
            this.clId.FieldName = "Id";
            this.clId.Name = "clId";
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(100, 40);
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
            this.tbxDate.Properties.NullText = "<<Choose...>>";
            this.tbxDate.Size = new System.Drawing.Size(137, 24);
            this.tbxDate.TabIndex = 1;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // tbxTotalSales
            // 
            this.tbxTotalSales.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotalSales.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTotalSales.FieldLabel = null;
            this.tbxTotalSales.Location = new System.Drawing.Point(685, 410);
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
            this.tbxTotalSales.Size = new System.Drawing.Size(120, 24);
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
            this.tbxAdjustment.EditMask = "###,###,###,###,###,##0.00";
            this.tbxAdjustment.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxAdjustment.FieldLabel = null;
            this.tbxAdjustment.Location = new System.Drawing.Point(685, 436);
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
            this.tbxAdjustment.Size = new System.Drawing.Size(120, 24);
            this.tbxAdjustment.TabIndex = 7;
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
            this.tbxTotal.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTotal.FieldLabel = null;
            this.tbxTotal.Location = new System.Drawing.Point(685, 462);
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
            this.tbxTotal.Size = new System.Drawing.Size(120, 24);
            this.tbxTotal.TabIndex = 0;
            this.tbxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxTotal.ValidationRules = null;
            this.tbxTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(25, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "Description";
            // 
            // tbxDescription
            // 
            this.tbxDescription.Capslock = true;
            this.tbxDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDescription.FieldLabel = null;
            this.tbxDescription.Location = new System.Drawing.Point(100, 66);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDescription.Size = new System.Drawing.Size(369, 24);
            this.tbxDescription.TabIndex = 2;
            this.tbxDescription.ValidationRules = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(13, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 38;
            this.label4.Text = "No. Rekening";
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
            this.lkpAccount.Location = new System.Drawing.Point(100, 92);
            this.lkpAccount.LookupPopup = null;
            this.lkpAccount.Name = "lkpAccount";
            this.lkpAccount.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpAccount.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lkpAccount.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpAccount.Properties.Appearance.Options.UseBackColor = true;
            this.lkpAccount.Properties.Appearance.Options.UseFont = true;
            this.lkpAccount.Properties.AutoCompleteDataManager = null;
            this.lkpAccount.Properties.AutoCompleteDisplayFormater = null;
            this.lkpAccount.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpAccount.Properties.AutoCompleteText = null;
            this.lkpAccount.Properties.AutoCompleteWhereExpression = null;
            this.lkpAccount.Properties.AutoCompleteWheretermFormater = null;
            this.lkpAccount.Properties.AutoHeight = false;
            this.lkpAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dLookup1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpAccount.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpAccount.Properties.LookupPopup = null;
            this.lkpAccount.Properties.NullText = "<<Choose...>>";
            this.lkpAccount.Size = new System.Drawing.Size(225, 24);
            this.lkpAccount.TabIndex = 3;
            this.lkpAccount.ValidationRules = null;
            this.lkpAccount.Value = null;
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
            this.lkpTransactional.Location = new System.Drawing.Point(100, 118);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dLookup2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.lkpTransactional.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpTransactional.Properties.LookupPopup = null;
            this.lkpTransactional.Properties.NullText = "<<Choose...>>";
            this.lkpTransactional.Size = new System.Drawing.Size(308, 24);
            this.lkpTransactional.TabIndex = 4;
            this.lkpTransactional.ValidationRules = null;
            this.lkpTransactional.Value = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(7, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 17);
            this.label5.TabIndex = 40;
            this.label5.Text = "Transaksi Bank";
            // 
            // PaymentInCounterForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(812, 490);
            this.Controls.Add(this.lkpTransactional);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lkpAccount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxTotal);
            this.Controls.Add(this.tbxAdjustment);
            this.Controls.Add(this.tbxTotalSales);
            this.Controls.Add(this.tbxDate);
            this.Controls.Add(this.GridPayment);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "PaymentInCounterForm";
            this.Text = "Finance - Payment In Counter";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.GridPayment, 0);
            this.Controls.SetChildIndex(this.tbxDate, 0);
            this.Controls.SetChildIndex(this.tbxTotalSales, 0);
            this.Controls.SetChildIndex(this.tbxAdjustment, 0);
            this.Controls.SetChildIndex(this.tbxTotal, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tbxDescription, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lkpAccount, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.lkpTransactional, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotalSales.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAdjustment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpTransactional.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraGrid.GridControl GridPayment;
        private DevExpress.XtraGrid.Views.Grid.GridView PaymentView;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private DevExpress.XtraGrid.Columns.GridColumn clShipment;
        private DevExpress.XtraGrid.Columns.GridColumn clDate;
        private DevExpress.XtraGrid.Columns.GridColumn clInvTotal;
        private DevExpress.XtraGrid.Columns.GridColumn clPayment;
        private DevExpress.XtraGrid.Columns.GridColumn clChecked;
        private DevExpress.XtraGrid.Columns.GridColumn clInvBalance;
        private DevExpress.XtraGrid.Columns.GridColumn clInvoiceId;
        private DevExpress.XtraGrid.Columns.GridColumn clState;
        private DevExpress.XtraEditors.SimpleButton btnTambah;
        private Common.Component.dTextBox tbxBarcode;
        private Common.Component.dCalendar tbxDate;
        private Common.Component.dTextBoxNumber tbxTotalSales;
        private Common.Component.dTextBoxNumber tbxAdjustment;
        private Common.Component.dTextBoxNumber tbxTotal;
        private DevExpress.XtraGrid.Columns.GridColumn clBalance;
        private DevExpress.XtraGrid.Columns.GridColumn clPaid;
        private DevExpress.XtraGrid.Columns.GridColumn clInvDate;
        private DevExpress.XtraGrid.Columns.GridColumn clId;
        private System.Windows.Forms.Label label3;
        private Common.Component.dTextBox tbxDescription;
        private System.Windows.Forms.Label label4;
        private Common.Component.dLookup lkpAccount;
        private Common.Component.dLookup lkpTransactional;
        private System.Windows.Forms.Label label5;
    }
}