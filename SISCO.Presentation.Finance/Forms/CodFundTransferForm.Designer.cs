namespace SISCO.Presentation.Finance.Forms
{
    partial class CodFundTransferForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodFundTransferForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxAmount = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.tbxDescription = new SISCO.Presentation.Common.Component.dTextBox();
            this.GridPayment = new DevExpress.XtraGrid.GridControl();
            this.PaymentView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clInvTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clInvoiceId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tbxTotalPayment = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxAdjustment = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxTotal = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label6 = new System.Windows.Forms.Label();
            this.lkpBranch = new SISCO.Presentation.Common.Component.dLookup();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotalPayment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAdjustment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBranch.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(92, 47);
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
            this.tbxDate.Size = new System.Drawing.Size(128, 24);
            this.tbxDate.TabIndex = 1;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Description";
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
            this.tbxAmount.Location = new System.Drawing.Point(92, 73);
            this.tbxAmount.Name = "tbxAmount";
            this.tbxAmount.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxAmount.Properties.AllowMouseWheel = false;
            this.tbxAmount.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxAmount.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxAmount.Properties.Appearance.Options.UseBackColor = true;
            this.tbxAmount.Properties.Appearance.Options.UseFont = true;
            this.tbxAmount.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxAmount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxAmount.Properties.Mask.BeepOnError = true;
            this.tbxAmount.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxAmount.ReadOnly = false;
            this.tbxAmount.Size = new System.Drawing.Size(178, 24);
            this.tbxAmount.TabIndex = 2;
            this.tbxAmount.TextAlign = null;
            this.tbxAmount.ValidationRules = null;
            this.tbxAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // tbxDescription
            // 
            this.tbxDescription.Capslock = true;
            this.tbxDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDescription.FieldLabel = null;
            this.tbxDescription.Location = new System.Drawing.Point(92, 99);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDescription.Size = new System.Drawing.Size(261, 24);
            this.tbxDescription.TabIndex = 3;
            this.tbxDescription.ValidationRules = null;
            // 
            // GridPayment
            // 
            this.GridPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridPayment.Location = new System.Drawing.Point(0, 129);
            this.GridPayment.MainView = this.PaymentView;
            this.GridPayment.Name = "GridPayment";
            this.GridPayment.Size = new System.Drawing.Size(906, 261);
            this.GridPayment.TabIndex = 37;
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
            this.clChecked,
            this.clInvoiceId,
            this.clState,
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
            this.clNo.Width = 36;
            // 
            // clShipment
            // 
            this.clShipment.Caption = "COD Payment In";
            this.clShipment.FieldName = "InvoiceCode";
            this.clShipment.Name = "clShipment";
            this.clShipment.OptionsColumn.AllowEdit = false;
            this.clShipment.OptionsColumn.AllowFocus = false;
            this.clShipment.OptionsColumn.AllowMove = false;
            this.clShipment.OptionsColumn.ReadOnly = true;
            this.clShipment.Visible = true;
            this.clShipment.VisibleIndex = 1;
            this.clShipment.Width = 314;
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
            this.clDate.Width = 124;
            // 
            // clInvTotal
            // 
            this.clInvTotal.Caption = "Total";
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
            this.clInvTotal.Width = 377;
            // 
            // clChecked
            // 
            this.clChecked.Caption = " ";
            this.clChecked.FieldName = "Checked";
            this.clChecked.Name = "clChecked";
            this.clChecked.Visible = true;
            this.clChecked.VisibleIndex = 4;
            this.clChecked.Width = 37;
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
            // clId
            // 
            this.clId.Caption = "Id";
            this.clId.FieldName = "Id";
            this.clId.Name = "clId";
            // 
            // tbxTotalPayment
            // 
            this.tbxTotalPayment.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotalPayment.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTotalPayment.FieldLabel = null;
            this.tbxTotalPayment.Location = new System.Drawing.Point(716, 395);
            this.tbxTotalPayment.Name = "tbxTotalPayment";
            this.tbxTotalPayment.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTotalPayment.Properties.AllowMouseWheel = false;
            this.tbxTotalPayment.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbxTotalPayment.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTotalPayment.Properties.Appearance.Options.UseBackColor = true;
            this.tbxTotalPayment.Properties.Appearance.Options.UseFont = true;
            this.tbxTotalPayment.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTotalPayment.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTotalPayment.Properties.Mask.BeepOnError = true;
            this.tbxTotalPayment.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotalPayment.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxTotalPayment.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTotalPayment.ReadOnly = false;
            this.tbxTotalPayment.Size = new System.Drawing.Size(178, 24);
            this.tbxTotalPayment.TabIndex = 4;
            this.tbxTotalPayment.TextAlign = null;
            this.tbxTotalPayment.ValidationRules = null;
            this.tbxTotalPayment.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(625, 398);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 17);
            this.label4.TabIndex = 38;
            this.label4.Text = "Total Payment";
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
            this.tbxAdjustment.Location = new System.Drawing.Point(716, 421);
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
            this.tbxAdjustment.Size = new System.Drawing.Size(178, 24);
            this.tbxAdjustment.TabIndex = 5;
            this.tbxAdjustment.TextAlign = null;
            this.tbxAdjustment.ValidationRules = null;
            this.tbxAdjustment.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(640, 424);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 40;
            this.label5.Text = "Adjustment";
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
            this.tbxTotal.Location = new System.Drawing.Point(716, 447);
            this.tbxTotal.Name = "tbxTotal";
            this.tbxTotal.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTotal.Properties.AllowMouseWheel = false;
            this.tbxTotal.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbxTotal.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTotal.Properties.Appearance.Options.UseBackColor = true;
            this.tbxTotal.Properties.Appearance.Options.UseFont = true;
            this.tbxTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTotal.Properties.Mask.BeepOnError = true;
            this.tbxTotal.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTotal.ReadOnly = false;
            this.tbxTotal.Size = new System.Drawing.Size(178, 24);
            this.tbxTotal.TabIndex = 6;
            this.tbxTotal.TextAlign = null;
            this.tbxTotal.ValidationRules = null;
            this.tbxTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(676, 450);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 17);
            this.label6.TabIndex = 42;
            this.label6.Text = "Total";
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
            this.lkpBranch.Location = new System.Drawing.Point(740, 46);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpBranch.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpBranch.Properties.LookupPopup = null;
            this.lkpBranch.Properties.NullText = "<<Choose...>>";
            this.lkpBranch.Size = new System.Drawing.Size(154, 24);
            this.lkpBranch.TabIndex = 0;
            this.lkpBranch.ValidationRules = null;
            this.lkpBranch.Value = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(621, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 17);
            this.label7.TabIndex = 44;
            this.label7.Text = "Transfer Ke Cabang";
            // 
            // CodFundTransferForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(906, 475);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lkpBranch);
            this.Controls.Add(this.tbxTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbxAdjustment);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxTotalPayment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GridPayment);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.tbxAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxDate);
            this.Controls.Add(this.label1);
            this.Name = "CodFundTransferForm";
            this.Text = "Finance - Transfer Pembayaran COD";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbxDate, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tbxAmount, 0);
            this.Controls.SetChildIndex(this.tbxDescription, 0);
            this.Controls.SetChildIndex(this.GridPayment, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.tbxTotalPayment, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.tbxAdjustment, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.tbxTotal, 0);
            this.Controls.SetChildIndex(this.lkpBranch, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotalPayment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAdjustment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBranch.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Common.Component.dCalendar tbxDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Common.Component.dTextBoxNumber tbxAmount;
        private Common.Component.dTextBox tbxDescription;
        private DevExpress.XtraGrid.GridControl GridPayment;
        private DevExpress.XtraGrid.Views.Grid.GridView PaymentView;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private DevExpress.XtraGrid.Columns.GridColumn clShipment;
        private DevExpress.XtraGrid.Columns.GridColumn clDate;
        private DevExpress.XtraGrid.Columns.GridColumn clInvTotal;
        private DevExpress.XtraGrid.Columns.GridColumn clChecked;
        private DevExpress.XtraGrid.Columns.GridColumn clInvoiceId;
        private DevExpress.XtraGrid.Columns.GridColumn clState;
        private DevExpress.XtraGrid.Columns.GridColumn clId;
        private Common.Component.dTextBoxNumber tbxTotalPayment;
        private System.Windows.Forms.Label label4;
        private Common.Component.dTextBoxNumber tbxAdjustment;
        private System.Windows.Forms.Label label5;
        private Common.Component.dTextBoxNumber tbxTotal;
        private System.Windows.Forms.Label label6;
        private Common.Component.dLookup lkpBranch;
        private System.Windows.Forms.Label label7;
    }
}