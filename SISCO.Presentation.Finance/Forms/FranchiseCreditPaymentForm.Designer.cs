namespace SISCO.Presentation.Finance.Forms
{
    partial class FranchiseCreditPaymentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FranchiseCreditPaymentForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxDescription = new SISCO.Presentation.Common.Component.dTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lkpPaymentType = new SISCO.Presentation.Common.Component.dLookup();
            this.label3 = new System.Windows.Forms.Label();
            this.lkpFranchise = new SISCO.Presentation.Common.Component.dLookup();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.GridPayment = new DevExpress.XtraGrid.GridControl();
            this.PaymentView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbxTotal = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxAdjustment = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxTotalInvoice = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPaymentType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFranchise.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentView)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAdjustment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotalInvoice.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbxDescription);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lkpPaymentType);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lkpFranchise);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbxDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 110);
            this.panel1.TabIndex = 1;
            // 
            // tbxDescription
            // 
            this.tbxDescription.Capslock = true;
            this.tbxDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDescription.FieldLabel = null;
            this.tbxDescription.Location = new System.Drawing.Point(109, 81);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDescription.Size = new System.Drawing.Size(357, 24);
            this.tbxDescription.TabIndex = 4;
            this.tbxDescription.ValidationRules = null;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(18, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Description";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lkpPaymentType
            // 
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
            this.lkpPaymentType.Location = new System.Drawing.Point(109, 55);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("lkpPaymentType.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpPaymentType.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpPaymentType.Properties.LookupPopup = null;
            this.lkpPaymentType.Properties.NullText = "<<Choose...>>";
            this.lkpPaymentType.Size = new System.Drawing.Size(274, 24);
            this.lkpPaymentType.TabIndex = 3;
            this.lkpPaymentType.ValidationRules = null;
            this.lkpPaymentType.Value = null;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(18, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Payment Type";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lkpFranchise
            // 
            this.lkpFranchise.AutoCompleteDataManager = null;
            this.lkpFranchise.AutoCompleteDisplayFormater = null;
            this.lkpFranchise.AutoCompleteInitialized = false;
            this.lkpFranchise.AutocompleteMinimumTextLength = 0;
            this.lkpFranchise.AutoCompleteText = null;
            this.lkpFranchise.AutoCompleteWhereExpression = null;
            this.lkpFranchise.AutoCompleteWheretermFormater = null;
            this.lkpFranchise.ClearOnLeave = true;
            this.lkpFranchise.DisplayString = null;
            this.lkpFranchise.FieldLabel = null;
            this.lkpFranchise.Location = new System.Drawing.Point(109, 29);
            this.lkpFranchise.LookupPopup = null;
            this.lkpFranchise.Name = "lkpFranchise";
            this.lkpFranchise.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpFranchise.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lkpFranchise.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpFranchise.Properties.Appearance.Options.UseBackColor = true;
            this.lkpFranchise.Properties.Appearance.Options.UseFont = true;
            this.lkpFranchise.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpFranchise.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpFranchise.Properties.AutoCompleteDataManager = null;
            this.lkpFranchise.Properties.AutoCompleteDisplayFormater = null;
            this.lkpFranchise.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpFranchise.Properties.AutoCompleteText = null;
            this.lkpFranchise.Properties.AutoCompleteWhereExpression = null;
            this.lkpFranchise.Properties.AutoCompleteWheretermFormater = null;
            this.lkpFranchise.Properties.AutoHeight = false;
            this.lkpFranchise.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("lkpFranchise.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpFranchise.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpFranchise.Properties.LookupPopup = null;
            this.lkpFranchise.Properties.NullText = "<<Choose...>>";
            this.lkpFranchise.Size = new System.Drawing.Size(274, 24);
            this.lkpFranchise.TabIndex = 2;
            this.lkpFranchise.ValidationRules = null;
            this.lkpFranchise.Value = null;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(18, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Franchise";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(109, 3);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxDate.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxDate.Properties.Appearance.Options.UseBackColor = true;
            this.tbxDate.Properties.Appearance.Options.UseFont = true;
            this.tbxDate.Properties.AutoHeight = false;
            this.tbxDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("tbxDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
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
            this.tbxDate.Size = new System.Drawing.Size(118, 24);
            this.tbxDate.TabIndex = 1;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GridPayment
            // 
            this.GridPayment.Location = new System.Drawing.Point(3, 152);
            this.GridPayment.MainView = this.PaymentView;
            this.GridPayment.Name = "GridPayment";
            this.GridPayment.Size = new System.Drawing.Size(793, 221);
            this.GridPayment.TabIndex = 2;
            this.GridPayment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PaymentView});
            // 
            // PaymentView
            // 
            this.PaymentView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn7,
            this.clPayment,
            this.gridColumn8,
            this.clChecked,
            this.clState,
            this.gridColumn6});
            this.PaymentView.GridControl = this.GridPayment;
            this.PaymentView.Name = "PaymentView";
            this.PaymentView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No.";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 33;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.FieldName = "InvoiceId";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Date";
            this.gridColumn3.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "InvoiceDate";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 73;
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
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 116;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Amount";
            this.gridColumn5.DisplayFormat.FormatString = "#,#";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "InvoiceTotal";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.AllowMove = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 111;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Amount Due";
            this.gridColumn7.DisplayFormat.FormatString = "#,#";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "InvoiceBalance";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.AllowMove = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 124;
            // 
            // clPayment
            // 
            this.clPayment.Caption = "Payment";
            this.clPayment.DisplayFormat.FormatString = "#,#0";
            this.clPayment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clPayment.FieldName = "Payment";
            this.clPayment.Name = "clPayment";
            this.clPayment.OptionsColumn.AllowMove = false;
            this.clPayment.Visible = true;
            this.clPayment.VisibleIndex = 5;
            this.clPayment.Width = 116;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Balance";
            this.gridColumn8.DisplayFormat.FormatString = "#,#0";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "Balance";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.OptionsColumn.AllowMove = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 87;
            // 
            // clChecked
            // 
            this.clChecked.Caption = " ";
            this.clChecked.FieldName = "Checked";
            this.clChecked.Name = "clChecked";
            this.clChecked.Visible = true;
            this.clChecked.VisibleIndex = 7;
            this.clChecked.Width = 36;
            // 
            // clState
            // 
            this.clState.Caption = "gridColumn9";
            this.clState.FieldName = "StateChange";
            this.clState.Name = "clState";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "gridColumn6";
            this.gridColumn6.FieldName = "Id";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MistyRose;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tbxTotal);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.tbxAdjustment);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.tbxTotalInvoice);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(3, 375);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(793, 85);
            this.panel2.TabIndex = 3;
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
            this.tbxTotal.Location = new System.Drawing.Point(631, 55);
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
            this.tbxTotal.ReadOnly = false;
            this.tbxTotal.Size = new System.Drawing.Size(157, 24);
            this.tbxTotal.TabIndex = 7;
            this.tbxTotal.TextAlign = null;
            this.tbxTotal.ValidationRules = null;
            this.tbxTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(541, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Total";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.tbxAdjustment.Location = new System.Drawing.Point(631, 29);
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
            this.tbxAdjustment.Size = new System.Drawing.Size(157, 24);
            this.tbxAdjustment.TabIndex = 6;
            this.tbxAdjustment.TextAlign = null;
            this.tbxAdjustment.ValidationRules = null;
            this.tbxAdjustment.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(541, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Adjustment";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxTotalInvoice
            // 
            this.tbxTotalInvoice.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotalInvoice.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTotalInvoice.FieldLabel = null;
            this.tbxTotalInvoice.Location = new System.Drawing.Point(631, 3);
            this.tbxTotalInvoice.Name = "tbxTotalInvoice";
            this.tbxTotalInvoice.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTotalInvoice.Properties.AllowMouseWheel = false;
            this.tbxTotalInvoice.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTotalInvoice.Properties.Appearance.Options.UseFont = true;
            this.tbxTotalInvoice.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTotalInvoice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTotalInvoice.Properties.Mask.BeepOnError = true;
            this.tbxTotalInvoice.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotalInvoice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxTotalInvoice.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTotalInvoice.ReadOnly = false;
            this.tbxTotalInvoice.Size = new System.Drawing.Size(157, 24);
            this.tbxTotalInvoice.TabIndex = 5;
            this.tbxTotalInvoice.TextAlign = null;
            this.tbxTotalInvoice.ValidationRules = null;
            this.tbxTotalInvoice.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(518, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Total Payment";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FranchiseCreditPaymentForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 463);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.GridPayment);
            this.Controls.Add(this.panel1);
            this.Name = "FranchiseCreditPaymentForm";
            this.Text = "Finance - Pembayaran Invoice Agent Franchise";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.GridPayment, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPaymentType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFranchise.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentView)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAdjustment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotalInvoice.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Common.Component.dTextBox tbxDescription;
        private System.Windows.Forms.Label label4;
        private Common.Component.dLookup lkpPaymentType;
        private System.Windows.Forms.Label label3;
        private Common.Component.dLookup lkpFranchise;
        private System.Windows.Forms.Label label2;
        private Common.Component.dCalendar tbxDate;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl GridPayment;
        private DevExpress.XtraGrid.Views.Grid.GridView PaymentView;
        private System.Windows.Forms.Panel panel2;
        private Common.Component.dTextBoxNumber tbxTotal;
        private System.Windows.Forms.Label label7;
        private Common.Component.dTextBoxNumber tbxAdjustment;
        private System.Windows.Forms.Label label6;
        private Common.Component.dTextBoxNumber tbxTotalInvoice;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn clPayment;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn clChecked;
        private DevExpress.XtraGrid.Columns.GridColumn clState;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
    }
}