﻿namespace SISCO.Presentation.Finance.Forms
{
    partial class PaymentOutRCForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentOutRCForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTambah = new DevExpress.XtraEditors.SimpleButton();
            this.tbxBarcode = new SISCO.Presentation.Common.Component.dTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.tbxCustomer = new SISCO.Presentation.Common.Component.dLookup();
            this.tbxAmount = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.tbxPayment = new SISCO.Presentation.Common.Component.dLookup();
            this.tbxDescription = new SISCO.Presentation.Common.Component.dTextBox();
            this.tbxTotalInvoice = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.tbxAdjustment = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.tbxTotal = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.GridRc = new DevExpress.XtraGrid.GridControl();
            this.RcView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPayment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotalInvoice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAdjustment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridRc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RcView)).BeginInit();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(639, 490);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 17);
            this.label16.TabIndex = 98;
            this.label16.Text = "Total";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(603, 464);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 17);
            this.label15.TabIndex = 97;
            this.label15.Text = "Adjustment";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(596, 436);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 17);
            this.label14.TabIndex = 96;
            this.label14.Text = "Total Invoice";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnTambah);
            this.panel1.Controls.Add(this.tbxBarcode);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(504, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 78);
            this.panel1.TabIndex = 6;
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(94, 38);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(83, 29);
            this.btnTambah.TabIndex = 7;
            this.btnTambah.Text = "Tambah";
            // 
            // tbxBarcode
            // 
            this.tbxBarcode.Capslock = true;
            this.tbxBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxBarcode.FieldLabel = null;
            this.tbxBarcode.Location = new System.Drawing.Point(94, 11);
            this.tbxBarcode.Name = "tbxBarcode";
            this.tbxBarcode.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxBarcode.Size = new System.Drawing.Size(197, 24);
            this.tbxBarcode.TabIndex = 6;
            this.tbxBarcode.ValidationRules = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(16, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "No. Kwitansi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(32, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 93;
            this.label5.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(17, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 91;
            this.label4.Text = "Payment Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(50, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 89;
            this.label3.Text = "Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(41, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 87;
            this.label2.Text = "Customer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(69, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 85;
            this.label1.Text = "Date";
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(107, 47);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxDate.Properties.Appearance.Options.UseBackColor = true;
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
            this.tbxDate.Size = new System.Drawing.Size(167, 24);
            this.tbxDate.TabIndex = 1;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // tbxCustomer
            // 
            this.tbxCustomer.AutoCompleteDataManager = null;
            this.tbxCustomer.AutoCompleteDisplayFormater = null;
            this.tbxCustomer.AutoCompleteInitialized = false;
            this.tbxCustomer.AutocompleteMinimumTextLength = 0;
            this.tbxCustomer.AutoCompleteText = null;
            this.tbxCustomer.AutoCompleteWhereExpression = null;
            this.tbxCustomer.AutoCompleteWheretermFormater = null;
            this.tbxCustomer.ClearOnLeave = true;
            this.tbxCustomer.DisplayString = null;
            this.tbxCustomer.FieldLabel = null;
            this.tbxCustomer.Location = new System.Drawing.Point(107, 73);
            this.tbxCustomer.LookupPopup = null;
            this.tbxCustomer.Name = "tbxCustomer";
            this.tbxCustomer.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxCustomer.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxCustomer.Properties.Appearance.Options.UseBackColor = true;
            this.tbxCustomer.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxCustomer.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxCustomer.Properties.AutoCompleteDataManager = null;
            this.tbxCustomer.Properties.AutoCompleteDisplayFormater = null;
            this.tbxCustomer.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxCustomer.Properties.AutoCompleteText = null;
            this.tbxCustomer.Properties.AutoCompleteWhereExpression = null;
            this.tbxCustomer.Properties.AutoCompleteWheretermFormater = null;
            this.tbxCustomer.Properties.AutoHeight = false;
            this.tbxCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxCustomer.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxCustomer.Properties.LookupPopup = null;
            this.tbxCustomer.Properties.NullText = "<<Choose...>>";
            this.tbxCustomer.Size = new System.Drawing.Size(311, 24);
            this.tbxCustomer.TabIndex = 2;
            this.tbxCustomer.ValidationRules = null;
            this.tbxCustomer.Value = null;
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
            this.tbxAmount.Location = new System.Drawing.Point(107, 99);
            this.tbxAmount.Name = "tbxAmount";
            this.tbxAmount.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxAmount.Properties.AllowMouseWheel = false;
            this.tbxAmount.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxAmount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxAmount.Properties.Mask.BeepOnError = true;
            this.tbxAmount.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxAmount.ReadOnly = false;
            this.tbxAmount.Size = new System.Drawing.Size(100, 20);
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
            this.tbxPayment.Location = new System.Drawing.Point(107, 125);
            this.tbxPayment.LookupPopup = null;
            this.tbxPayment.Name = "tbxPayment";
            this.tbxPayment.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPayment.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxPayment.Properties.Appearance.Options.UseBackColor = true;
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxPayment.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.tbxPayment.Properties.LookupPopup = null;
            this.tbxPayment.Properties.NullText = "<<Choose...>>";
            this.tbxPayment.Size = new System.Drawing.Size(167, 24);
            this.tbxPayment.TabIndex = 4;
            this.tbxPayment.ValidationRules = null;
            this.tbxPayment.Value = null;
            // 
            // tbxDescription
            // 
            this.tbxDescription.Capslock = true;
            this.tbxDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDescription.FieldLabel = null;
            this.tbxDescription.Location = new System.Drawing.Point(107, 151);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDescription.Size = new System.Drawing.Size(311, 24);
            this.tbxDescription.TabIndex = 5;
            this.tbxDescription.ValidationRules = null;
            // 
            // tbxTotalInvoice
            // 
            this.tbxTotalInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxTotalInvoice.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotalInvoice.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTotalInvoice.FieldLabel = null;
            this.tbxTotalInvoice.Location = new System.Drawing.Point(684, 433);
            this.tbxTotalInvoice.Name = "tbxTotalInvoice";
            this.tbxTotalInvoice.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTotalInvoice.Properties.AllowMouseWheel = false;
            this.tbxTotalInvoice.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTotalInvoice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTotalInvoice.Properties.Mask.BeepOnError = true;
            this.tbxTotalInvoice.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotalInvoice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxTotalInvoice.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTotalInvoice.Properties.ReadOnly = true;
            this.tbxTotalInvoice.ReadOnly = true;
            this.tbxTotalInvoice.Size = new System.Drawing.Size(134, 20);
            this.tbxTotalInvoice.TabIndex = 108;
            this.tbxTotalInvoice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxTotalInvoice.ValidationRules = null;
            this.tbxTotalInvoice.Value = new decimal(new int[] {
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
            this.tbxAdjustment.Location = new System.Drawing.Point(684, 460);
            this.tbxAdjustment.Name = "tbxAdjustment";
            this.tbxAdjustment.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxAdjustment.Properties.AllowMouseWheel = false;
            this.tbxAdjustment.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxAdjustment.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxAdjustment.Properties.Mask.BeepOnError = true;
            this.tbxAdjustment.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxAdjustment.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxAdjustment.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxAdjustment.ReadOnly = false;
            this.tbxAdjustment.Size = new System.Drawing.Size(134, 20);
            this.tbxAdjustment.TabIndex = 109;
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
            this.tbxTotal.Location = new System.Drawing.Point(684, 487);
            this.tbxTotal.Name = "tbxTotal";
            this.tbxTotal.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTotal.Properties.AllowMouseWheel = false;
            this.tbxTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTotal.Properties.Mask.BeepOnError = true;
            this.tbxTotal.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTotal.Properties.ReadOnly = true;
            this.tbxTotal.ReadOnly = true;
            this.tbxTotal.Size = new System.Drawing.Size(134, 20);
            this.tbxTotal.TabIndex = 110;
            this.tbxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxTotal.ValidationRules = null;
            this.tbxTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // GridRc
            // 
            this.GridRc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridRc.Location = new System.Drawing.Point(0, 181);
            this.GridRc.MainView = this.RcView;
            this.GridRc.Name = "GridRc";
            this.GridRc.Size = new System.Drawing.Size(824, 246);
            this.GridRc.TabIndex = 111;
            this.GridRc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.RcView});
            // 
            // RcView
            // 
            this.RcView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clNo,
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.clPayment,
            this.clBalance,
            this.clChecked,
            this.clState});
            this.RcView.GridControl = this.GridRc;
            this.RcView.Name = "RcView";
            this.RcView.OptionsView.ShowGroupPanel = false;
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
            this.clNo.Width = 26;
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
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Invoice Id";
            this.gridColumn3.FieldName = "InvoiceId";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Invoice";
            this.gridColumn4.FieldName = "InvoiceCode";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 181;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Date";
            this.gridColumn5.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn5.FieldName = "InvoiceDate";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.AllowMove = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 64;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Amount";
            this.gridColumn6.DisplayFormat.FormatString = "#,#0";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn6.FieldName = "InvoiceTotal";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.AllowMove = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 89;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Amount Due";
            this.gridColumn7.DisplayFormat.FormatString = "#,#0";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn7.FieldName = "InvoiceBalance";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.AllowMove = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 97;
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
            this.clPayment.Width = 86;
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
            this.clBalance.Width = 145;
            // 
            // clChecked
            // 
            this.clChecked.Caption = " ";
            this.clChecked.FieldName = "Checked";
            this.clChecked.Name = "clChecked";
            this.clChecked.Visible = true;
            this.clChecked.VisibleIndex = 7;
            this.clChecked.Width = 26;
            // 
            // clState
            // 
            this.clState.Caption = "State";
            this.clState.FieldName = "StateChange2";
            this.clState.Name = "clState";
            this.clState.OptionsColumn.AllowEdit = false;
            this.clState.OptionsColumn.AllowFocus = false;
            this.clState.OptionsColumn.AllowMove = false;
            this.clState.OptionsColumn.ReadOnly = true;
            // 
            // PaymentOutRCForm
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(824, 516);
            this.Controls.Add(this.GridRc);
            this.Controls.Add(this.tbxTotal);
            this.Controls.Add(this.tbxAdjustment);
            this.Controls.Add(this.tbxTotalInvoice);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.tbxPayment);
            this.Controls.Add(this.tbxAmount);
            this.Controls.Add(this.tbxCustomer);
            this.Controls.Add(this.tbxDate);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PaymentOutRCForm";
            this.Text = "Finance - Payment Out RC";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.tbxDate, 0);
            this.Controls.SetChildIndex(this.tbxCustomer, 0);
            this.Controls.SetChildIndex(this.tbxAmount, 0);
            this.Controls.SetChildIndex(this.tbxPayment, 0);
            this.Controls.SetChildIndex(this.tbxDescription, 0);
            this.Controls.SetChildIndex(this.tbxTotalInvoice, 0);
            this.Controls.SetChildIndex(this.tbxAdjustment, 0);
            this.Controls.SetChildIndex(this.tbxTotal, 0);
            this.Controls.SetChildIndex(this.GridRc, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPayment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotalInvoice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAdjustment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridRc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RcView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnTambah;
        private Common.Component.dTextBox tbxBarcode;
        private Common.Component.dCalendar tbxDate;
        private Common.Component.dLookup tbxCustomer;
        private Common.Component.dTextBoxNumber tbxAmount;
        private Common.Component.dLookup tbxPayment;
        private Common.Component.dTextBox tbxDescription;
        private Common.Component.dTextBoxNumber tbxTotalInvoice;
        private Common.Component.dTextBoxNumber tbxAdjustment;
        private Common.Component.dTextBoxNumber tbxTotal;
        private DevExpress.XtraGrid.GridControl GridRc;
        private DevExpress.XtraGrid.Views.Grid.GridView RcView;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn clPayment;
        private DevExpress.XtraGrid.Columns.GridColumn clBalance;
        private DevExpress.XtraGrid.Columns.GridColumn clChecked;
        private DevExpress.XtraGrid.Columns.GridColumn clState;
    }
}