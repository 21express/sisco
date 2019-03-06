namespace SISCO.Presentation.Audit.Forms
{
    partial class VerificationCashForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerificationCashForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tbxDescription = new SISCO.Presentation.Common.Component.dTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxTotal = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.tbxAdjustment = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.tbxTotalSales = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar();
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
            this.label7 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblVerifiedDate = new System.Windows.Forms.Label();
            this.lblVerifiedBy = new System.Windows.Forms.Label();
            this.ucVerified = new SISCO.Presentation.Common.UserControls.ucIconYesNo();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVerify = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAdjustment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotalSales.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxDescription
            // 
            this.tbxDescription.Capslock = true;
            this.tbxDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDescription.FieldLabel = null;
            this.tbxDescription.Location = new System.Drawing.Point(101, 71);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDescription.Size = new System.Drawing.Size(335, 24);
            this.tbxDescription.TabIndex = 42;
            this.tbxDescription.ValidationRules = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(26, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 50;
            this.label3.Text = "Description";
            // 
            // tbxTotal
            // 
            this.tbxTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxTotal.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTotal.FieldLabel = null;
            this.tbxTotal.Location = new System.Drawing.Point(694, 458);
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
            this.tbxTotal.Size = new System.Drawing.Size(125, 20);
            this.tbxTotal.TabIndex = 38;
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
            this.tbxAdjustment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxAdjustment.EditMask = "###,###,###,###,###,##0.00";
            this.tbxAdjustment.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxAdjustment.FieldLabel = null;
            this.tbxAdjustment.Location = new System.Drawing.Point(694, 431);
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
            this.tbxAdjustment.Size = new System.Drawing.Size(125, 20);
            this.tbxAdjustment.TabIndex = 44;
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
            this.tbxTotalSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxTotalSales.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotalSales.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTotalSales.FieldLabel = null;
            this.tbxTotalSales.Location = new System.Drawing.Point(694, 405);
            this.tbxTotalSales.Name = "tbxTotalSales";
            this.tbxTotalSales.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTotalSales.Properties.AllowMouseWheel = false;
            this.tbxTotalSales.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTotalSales.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTotalSales.Properties.Mask.BeepOnError = true;
            this.tbxTotalSales.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotalSales.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxTotalSales.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTotalSales.Properties.ReadOnly = true;
            this.tbxTotalSales.ReadOnly = true;
            this.tbxTotalSales.Size = new System.Drawing.Size(125, 20);
            this.tbxTotalSales.TabIndex = 39;
            this.tbxTotalSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxTotalSales.ValidationRules = null;
            this.tbxTotalSales.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(101, 44);
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
            this.tbxDate.Size = new System.Drawing.Size(137, 24);
            this.tbxDate.TabIndex = 40;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // GridPayment
            // 
            this.GridPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridPayment.Location = new System.Drawing.Point(3, 143);
            this.GridPayment.MainView = this.PaymentView;
            this.GridPayment.Name = "GridPayment";
            this.GridPayment.Size = new System.Drawing.Size(816, 254);
            this.GridPayment.TabIndex = 49;
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
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Meiryo", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(451, 434);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 15);
            this.label7.TabIndex = 48;
            this.label7.Text = "(Jika ada pengurangan  / claim)";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(655, 460);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 17);
            this.label16.TabIndex = 47;
            this.label16.Text = "Total";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(619, 433);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 17);
            this.label15.TabIndex = 46;
            this.label15.Text = "Adjustment";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(624, 406);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 17);
            this.label14.TabIndex = 45;
            this.label14.Text = "Total Sales";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(63, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 41;
            this.label1.Text = "Date";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblVerifiedDate);
            this.panel1.Controls.Add(this.lblVerifiedBy);
            this.panel1.Controls.Add(this.ucVerified);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(467, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 96);
            this.panel1.TabIndex = 51;
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
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(19, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 43;
            this.label4.Text = "Tgl. Verifikasi :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 42;
            this.label2.Text = "Verifikasi Oleh :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnVerify
            // 
            this.btnVerify.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnVerify.Appearance.Options.UseFont = true;
            this.btnVerify.Location = new System.Drawing.Point(361, 101);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 32);
            this.btnVerify.TabIndex = 52;
            this.btnVerify.Text = "Verifikasi";
            // 
            // VerificationCashForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(822, 481);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxTotal);
            this.Controls.Add(this.tbxAdjustment);
            this.Controls.Add(this.tbxTotalSales);
            this.Controls.Add(this.tbxDate);
            this.Controls.Add(this.GridPayment);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label1);
            this.Name = "VerificationCashForm";
            this.Text = "Verifikasi Cash";
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
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.GridPayment, 0);
            this.Controls.SetChildIndex(this.tbxDate, 0);
            this.Controls.SetChildIndex(this.tbxTotalSales, 0);
            this.Controls.SetChildIndex(this.tbxAdjustment, 0);
            this.Controls.SetChildIndex(this.tbxTotal, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tbxDescription, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnVerify, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAdjustment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotalSales.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Component.dTextBox tbxDescription;
        private System.Windows.Forms.Label label3;
        private Common.Component.dTextBoxNumber tbxTotal;
        private Common.Component.dTextBoxNumber tbxAdjustment;
        private Common.Component.dTextBoxNumber tbxTotalSales;
        private Common.Component.dCalendar tbxDate;
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
        private DevExpress.XtraGrid.Columns.GridColumn clBalance;
        private DevExpress.XtraGrid.Columns.GridColumn clPaid;
        private DevExpress.XtraGrid.Columns.GridColumn clInvDate;
        private DevExpress.XtraGrid.Columns.GridColumn clId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblVerifiedDate;
        private System.Windows.Forms.Label lblVerifiedBy;
        private Common.UserControls.ucIconYesNo ucVerified;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnVerify;
    }
}