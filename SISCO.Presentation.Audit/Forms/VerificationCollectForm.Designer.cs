namespace SISCO.Presentation.Audit.Forms
{
    partial class VerificationCollectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerificationCollectForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tbxPayment = new SISCO.Presentation.Common.Component.dLookup();
            this.tbxOrigin = new SISCO.Presentation.Common.Component.dLookup();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.tbxDescription = new SISCO.Presentation.Common.Component.dTextBox();
            this.tbxAmount = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GridCollectOut = new DevExpress.XtraGrid.GridControl();
            this.CollectOutView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clInvoiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clInvoiceDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clBal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPaid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tbxTotal = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.tbxAdjustment = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.tbxTotalSales = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label7 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnVerify = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblVerifiedDate = new System.Windows.Forms.Label();
            this.lblVerifiedBy = new System.Windows.Forms.Label();
            this.ucVerified = new SISCO.Presentation.Common.UserControls.ucIconYesNo();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPayment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxOrigin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridCollectOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectOutView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAdjustment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotalSales.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.tbxPayment.Location = new System.Drawing.Point(102, 119);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxPayment.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.tbxPayment.Properties.LookupPopup = null;
            this.tbxPayment.Properties.NullText = "<<Choose...>>";
            this.tbxPayment.Size = new System.Drawing.Size(180, 24);
            this.tbxPayment.TabIndex = 70;
            this.tbxPayment.ValidationRules = null;
            this.tbxPayment.Value = null;
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
            this.tbxOrigin.Location = new System.Drawing.Point(102, 67);
            this.tbxOrigin.LookupPopup = null;
            this.tbxOrigin.Name = "tbxOrigin";
            this.tbxOrigin.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxOrigin.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxOrigin.Properties.Appearance.Options.UseBackColor = true;
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxOrigin.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxOrigin.Properties.LookupPopup = null;
            this.tbxOrigin.Properties.NullText = "<<Choose...>>";
            this.tbxOrigin.Size = new System.Drawing.Size(285, 24);
            this.tbxOrigin.TabIndex = 68;
            this.tbxOrigin.ValidationRules = null;
            this.tbxOrigin.Value = null;
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(102, 41);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxDate.Properties.Appearance.Options.UseBackColor = true;
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
            this.tbxDate.Properties.NullText = "<<Choose...>>";
            this.tbxDate.Size = new System.Drawing.Size(116, 24);
            this.tbxDate.TabIndex = 67;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // tbxDescription
            // 
            this.tbxDescription.Capslock = true;
            this.tbxDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDescription.FieldLabel = null;
            this.tbxDescription.Location = new System.Drawing.Point(102, 145);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDescription.Size = new System.Drawing.Size(285, 24);
            this.tbxDescription.TabIndex = 71;
            this.tbxDescription.ValidationRules = null;
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
            this.tbxAmount.Location = new System.Drawing.Point(102, 93);
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
            this.tbxAmount.Size = new System.Drawing.Size(180, 24);
            this.tbxAmount.TabIndex = 69;
            this.tbxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxAmount.ValidationRules = null;
            this.tbxAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 76;
            this.label5.Text = "Description";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 75;
            this.label4.Text = "Payment Type";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 74;
            this.label3.Text = "Amount";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 73;
            this.label2.Text = "Branch";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 72;
            this.label1.Text = "Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GridCollectOut
            // 
            this.GridCollectOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridCollectOut.Location = new System.Drawing.Point(2, 173);
            this.GridCollectOut.MainView = this.CollectOutView;
            this.GridCollectOut.Name = "GridCollectOut";
            this.GridCollectOut.Size = new System.Drawing.Size(813, 219);
            this.GridCollectOut.TabIndex = 77;
            this.GridCollectOut.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.CollectOutView});
            // 
            // CollectOutView
            // 
            this.CollectOutView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clNo,
            this.clId,
            this.clInvoiceCode,
            this.clInvoiceDate,
            this.clAmount,
            this.clBalance,
            this.clPayment,
            this.clBal,
            this.clChecked,
            this.clPaid,
            this.clMethod,
            this.clCode,
            this.clState,
            this.gridColumn1});
            this.CollectOutView.GridControl = this.GridCollectOut;
            this.CollectOutView.Name = "CollectOutView";
            this.CollectOutView.OptionsView.ShowGroupPanel = false;
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
            this.clNo.Width = 28;
            // 
            // clId
            // 
            this.clId.Caption = "Id";
            this.clId.FieldName = "Id";
            this.clId.Name = "clId";
            this.clId.OptionsColumn.AllowEdit = false;
            this.clId.OptionsColumn.AllowFocus = false;
            this.clId.OptionsColumn.AllowMove = false;
            this.clId.OptionsColumn.ReadOnly = true;
            // 
            // clInvoiceCode
            // 
            this.clInvoiceCode.Caption = "Invoice";
            this.clInvoiceCode.FieldName = "InvoiceCode";
            this.clInvoiceCode.Name = "clInvoiceCode";
            this.clInvoiceCode.OptionsColumn.AllowEdit = false;
            this.clInvoiceCode.OptionsColumn.AllowFocus = false;
            this.clInvoiceCode.OptionsColumn.AllowMove = false;
            this.clInvoiceCode.OptionsColumn.ReadOnly = true;
            this.clInvoiceCode.Visible = true;
            this.clInvoiceCode.VisibleIndex = 1;
            this.clInvoiceCode.Width = 103;
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
            this.clInvoiceDate.Width = 67;
            // 
            // clAmount
            // 
            this.clAmount.Caption = "Amount";
            this.clAmount.DisplayFormat.FormatString = "#,#0";
            this.clAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clAmount.FieldName = "InvoiceTotal";
            this.clAmount.Name = "clAmount";
            this.clAmount.OptionsColumn.AllowEdit = false;
            this.clAmount.OptionsColumn.AllowFocus = false;
            this.clAmount.OptionsColumn.AllowMove = false;
            this.clAmount.OptionsColumn.ReadOnly = true;
            this.clAmount.Visible = true;
            this.clAmount.VisibleIndex = 3;
            this.clAmount.Width = 98;
            // 
            // clBalance
            // 
            this.clBalance.Caption = "Amount Due";
            this.clBalance.DisplayFormat.FormatString = "#,#0";
            this.clBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clBalance.FieldName = "InvoiceBalance";
            this.clBalance.Name = "clBalance";
            this.clBalance.OptionsColumn.AllowEdit = false;
            this.clBalance.OptionsColumn.AllowFocus = false;
            this.clBalance.OptionsColumn.AllowMove = false;
            this.clBalance.OptionsColumn.ReadOnly = true;
            this.clBalance.Visible = true;
            this.clBalance.VisibleIndex = 4;
            this.clBalance.Width = 91;
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
            this.clPayment.Width = 90;
            // 
            // clBal
            // 
            this.clBal.Caption = "Balance";
            this.clBal.DisplayFormat.FormatString = "#,#0";
            this.clBal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clBal.FieldName = "Balance";
            this.clBal.Name = "clBal";
            this.clBal.OptionsColumn.AllowEdit = false;
            this.clBal.OptionsColumn.AllowFocus = false;
            this.clBal.OptionsColumn.AllowMove = false;
            this.clBal.OptionsColumn.ReadOnly = true;
            this.clBal.Visible = true;
            this.clBal.VisibleIndex = 6;
            this.clBal.Width = 85;
            // 
            // clChecked
            // 
            this.clChecked.Caption = " ";
            this.clChecked.FieldName = "Checked";
            this.clChecked.Name = "clChecked";
            this.clChecked.Visible = true;
            this.clChecked.VisibleIndex = 7;
            this.clChecked.Width = 21;
            // 
            // clPaid
            // 
            this.clPaid.Caption = "Paid";
            this.clPaid.FieldName = "Paid";
            this.clPaid.Name = "clPaid";
            this.clPaid.OptionsColumn.AllowEdit = false;
            this.clPaid.OptionsColumn.AllowFocus = false;
            this.clPaid.OptionsColumn.AllowMove = false;
            this.clPaid.OptionsColumn.ReadOnly = true;
            // 
            // clMethod
            // 
            this.clMethod.Caption = "Type";
            this.clMethod.FieldName = "CollectPaymentMethod";
            this.clMethod.Name = "clMethod";
            this.clMethod.OptionsColumn.AllowEdit = false;
            this.clMethod.OptionsColumn.AllowFocus = false;
            this.clMethod.OptionsColumn.AllowMove = false;
            this.clMethod.OptionsColumn.ReadOnly = true;
            this.clMethod.Visible = true;
            this.clMethod.VisibleIndex = 8;
            this.clMethod.Width = 48;
            // 
            // clCode
            // 
            this.clCode.Caption = "No";
            this.clCode.FieldName = "PaymentInCollectInCode";
            this.clCode.Name = "clCode";
            this.clCode.OptionsColumn.AllowEdit = false;
            this.clCode.OptionsColumn.AllowFocus = false;
            this.clCode.OptionsColumn.AllowMove = false;
            this.clCode.OptionsColumn.ReadOnly = true;
            this.clCode.Visible = true;
            this.clCode.VisibleIndex = 9;
            this.clCode.Width = 83;
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
            this.gridColumn1.FieldName = "InvoiceId";
            this.gridColumn1.Name = "gridColumn1";
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
            this.tbxTotal.Location = new System.Drawing.Point(674, 449);
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
            this.tbxTotal.Size = new System.Drawing.Size(141, 20);
            this.tbxTotal.TabIndex = 78;
            this.tbxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxTotal.ValidationRules = null;
            this.tbxTotal.Value = new decimal(new int[] {
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
            this.tbxAdjustment.Location = new System.Drawing.Point(674, 423);
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
            this.tbxAdjustment.Size = new System.Drawing.Size(141, 20);
            this.tbxAdjustment.TabIndex = 80;
            this.tbxAdjustment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxAdjustment.ValidationRules = null;
            this.tbxAdjustment.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
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
            this.tbxTotalSales.Location = new System.Drawing.Point(674, 397);
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
            this.tbxTotalSales.Size = new System.Drawing.Size(141, 20);
            this.tbxTotalSales.TabIndex = 79;
            this.tbxTotalSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxTotalSales.ValidationRules = null;
            this.tbxTotalSales.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Meiryo", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(428, 426);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 15);
            this.label7.TabIndex = 84;
            this.label7.Text = "(Jika ada pengurangan  / claim)";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(598, 452);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 17);
            this.label16.TabIndex = 83;
            this.label16.Text = "Total";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(598, 426);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 17);
            this.label15.TabIndex = 82;
            this.label15.Text = "Adjustment";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(598, 400);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 17);
            this.label14.TabIndex = 81;
            this.label14.Text = "Total Sales";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnVerify
            // 
            this.btnVerify.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnVerify.Appearance.Options.UseFont = true;
            this.btnVerify.Location = new System.Drawing.Point(463, 139);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 32);
            this.btnVerify.TabIndex = 86;
            this.btnVerify.Text = "Verifikasi";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblVerifiedDate);
            this.panel1.Controls.Add(this.lblVerifiedBy);
            this.panel1.Controls.Add(this.ucVerified);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(463, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 96);
            this.panel1.TabIndex = 85;
            // 
            // lblVerifiedDate
            // 
            this.lblVerifiedDate.AutoSize = true;
            this.lblVerifiedDate.ForeColor = System.Drawing.Color.Black;
            this.lblVerifiedDate.Location = new System.Drawing.Point(117, 35);
            this.lblVerifiedDate.Name = "lblVerifiedDate";
            this.lblVerifiedDate.Size = new System.Drawing.Size(28, 17);
            this.lblVerifiedDate.TabIndex = 46;
            this.lblVerifiedDate.Text = "N/A";
            // 
            // lblVerifiedBy
            // 
            this.lblVerifiedBy.AutoSize = true;
            this.lblVerifiedBy.ForeColor = System.Drawing.Color.Black;
            this.lblVerifiedBy.Location = new System.Drawing.Point(117, 8);
            this.lblVerifiedBy.Name = "lblVerifiedBy";
            this.lblVerifiedBy.Size = new System.Drawing.Size(28, 17);
            this.lblVerifiedBy.TabIndex = 45;
            this.lblVerifiedBy.Text = "N/A";
            // 
            // ucVerified
            // 
            this.ucVerified.AutoSize = true;
            this.ucVerified.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucVerified.Icon = false;
            this.ucVerified.Label = "Verifikasi?";
            this.ucVerified.Location = new System.Drawing.Point(106, 67);
            this.ucVerified.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucVerified.Name = "ucVerified";
            this.ucVerified.Size = new System.Drawing.Size(86, 17);
            this.ucVerified.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(19, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 17);
            this.label6.TabIndex = 43;
            this.label6.Text = "Tgl. Verifikasi :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(19, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 17);
            this.label8.TabIndex = 42;
            this.label8.Text = "Verifikasi Oleh :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // VerificationCollectForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(818, 477);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbxTotal);
            this.Controls.Add(this.tbxAdjustment);
            this.Controls.Add(this.tbxTotalSales);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.GridCollectOut);
            this.Controls.Add(this.tbxPayment);
            this.Controls.Add(this.tbxOrigin);
            this.Controls.Add(this.tbxDate);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.tbxAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "VerificationCollectForm";
            this.Text = "Verifikasi Collect";
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
            this.Controls.SetChildIndex(this.tbxAmount, 0);
            this.Controls.SetChildIndex(this.tbxDescription, 0);
            this.Controls.SetChildIndex(this.tbxDate, 0);
            this.Controls.SetChildIndex(this.tbxOrigin, 0);
            this.Controls.SetChildIndex(this.tbxPayment, 0);
            this.Controls.SetChildIndex(this.GridCollectOut, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.tbxTotalSales, 0);
            this.Controls.SetChildIndex(this.tbxAdjustment, 0);
            this.Controls.SetChildIndex(this.tbxTotal, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnVerify, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tbxPayment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxOrigin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridCollectOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectOutView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAdjustment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotalSales.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Component.dLookup tbxPayment;
        private Common.Component.dLookup tbxOrigin;
        private Common.Component.dCalendar tbxDate;
        private Common.Component.dTextBox tbxDescription;
        private Common.Component.dTextBoxNumber tbxAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl GridCollectOut;
        private DevExpress.XtraGrid.Views.Grid.GridView CollectOutView;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private DevExpress.XtraGrid.Columns.GridColumn clId;
        private DevExpress.XtraGrid.Columns.GridColumn clInvoiceCode;
        private DevExpress.XtraGrid.Columns.GridColumn clInvoiceDate;
        private DevExpress.XtraGrid.Columns.GridColumn clAmount;
        private DevExpress.XtraGrid.Columns.GridColumn clBalance;
        private DevExpress.XtraGrid.Columns.GridColumn clPayment;
        private DevExpress.XtraGrid.Columns.GridColumn clBal;
        private DevExpress.XtraGrid.Columns.GridColumn clChecked;
        private DevExpress.XtraGrid.Columns.GridColumn clPaid;
        private DevExpress.XtraGrid.Columns.GridColumn clMethod;
        private DevExpress.XtraGrid.Columns.GridColumn clCode;
        private DevExpress.XtraGrid.Columns.GridColumn clState;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private Common.Component.dTextBoxNumber tbxTotal;
        private Common.Component.dTextBoxNumber tbxAdjustment;
        private Common.Component.dTextBoxNumber tbxTotalSales;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private DevExpress.XtraEditors.SimpleButton btnVerify;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblVerifiedDate;
        private System.Windows.Forms.Label lblVerifiedBy;
        private Common.UserControls.ucIconYesNo ucVerified;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
    }
}