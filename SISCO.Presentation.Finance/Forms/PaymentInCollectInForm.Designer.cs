namespace SISCO.Presentation.Finance.Forms
{
    partial class PaymentInCollectInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentInCollectInForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.gbCash = new System.Windows.Forms.GroupBox();
            this.pnlCash = new System.Windows.Forms.Panel();
            this.GridCash = new DevExpress.XtraGrid.GridControl();
            this.CashView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clInvoiceId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clInvBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPaid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clpayMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clBranch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnTambahCash = new DevExpress.XtraEditors.SimpleButton();
            this.tbxCnCash = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.gbCredit = new System.Windows.Forms.GroupBox();
            this.pnlCredit = new System.Windows.Forms.Panel();
            this.GridCredit = new DevExpress.XtraGrid.GridControl();
            this.CreditView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tbxCustomer = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.btnTambahCredit = new DevExpress.XtraEditors.SimpleButton();
            this.tbxCnCredit = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            this.gbCash.SuspendLayout();
            this.pnlCash.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridCash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashView)).BeginInit();
            this.gbCredit.SuspendLayout();
            this.pnlCredit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridCredit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreditView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCustomer.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 45);
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
            this.tbxDate.Location = new System.Drawing.Point(54, 42);
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
            this.tbxDate.Size = new System.Drawing.Size(172, 24);
            this.tbxDate.TabIndex = 1;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // gbCash
            // 
            this.gbCash.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCash.Controls.Add(this.pnlCash);
            this.gbCash.ForeColor = System.Drawing.Color.Black;
            this.gbCash.Location = new System.Drawing.Point(5, 75);
            this.gbCash.Name = "gbCash";
            this.gbCash.Size = new System.Drawing.Size(809, 232);
            this.gbCash.TabIndex = 2;
            this.gbCash.TabStop = false;
            this.gbCash.Text = "Payment Method : CASH";
            // 
            // pnlCash
            // 
            this.pnlCash.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCash.BackColor = System.Drawing.Color.LightGreen;
            this.pnlCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCash.Controls.Add(this.GridCash);
            this.pnlCash.Controls.Add(this.btnTambahCash);
            this.pnlCash.Controls.Add(this.tbxCnCash);
            this.pnlCash.Controls.Add(this.label2);
            this.pnlCash.Location = new System.Drawing.Point(7, 25);
            this.pnlCash.Name = "pnlCash";
            this.pnlCash.Size = new System.Drawing.Size(795, 202);
            this.pnlCash.TabIndex = 2;
            // 
            // GridCash
            // 
            this.GridCash.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridCash.Location = new System.Drawing.Point(3, 34);
            this.GridCash.MainView = this.CashView;
            this.GridCash.Name = "GridCash";
            this.GridCash.Size = new System.Drawing.Size(787, 163);
            this.GridCash.TabIndex = 6;
            this.GridCash.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.CashView});
            // 
            // CashView
            // 
            this.CashView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clNo,
            this.clInvoiceId,
            this.clShipment,
            this.clDate,
            this.clTotal,
            this.clInvBalance,
            this.clPayment,
            this.clBalance,
            this.clChecked,
            this.clPaid,
            this.clState,
            this.clpayMethod,
            this.clBranch});
            this.CashView.GridControl = this.GridCash;
            this.CashView.Name = "CashView";
            this.CashView.OptionsView.ShowFooter = true;
            this.CashView.OptionsView.ShowGroupPanel = false;
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
            this.clNo.Width = 29;
            // 
            // clInvoiceId
            // 
            this.clInvoiceId.Caption = "Id";
            this.clInvoiceId.FieldName = "InvoiceId";
            this.clInvoiceId.Name = "clInvoiceId";
            this.clInvoiceId.OptionsColumn.AllowEdit = false;
            this.clInvoiceId.OptionsColumn.AllowFocus = false;
            this.clInvoiceId.OptionsColumn.AllowMove = false;
            this.clInvoiceId.OptionsColumn.ReadOnly = true;
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
            this.clShipment.Width = 170;
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
            this.clDate.Width = 92;
            // 
            // clTotal
            // 
            this.clTotal.Caption = "Amount";
            this.clTotal.DisplayFormat.FormatString = "#,#0";
            this.clTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clTotal.FieldName = "InvoiceTotal";
            this.clTotal.Name = "clTotal";
            this.clTotal.OptionsColumn.AllowEdit = false;
            this.clTotal.OptionsColumn.AllowFocus = false;
            this.clTotal.OptionsColumn.AllowMove = false;
            this.clTotal.OptionsColumn.ReadOnly = true;
            this.clTotal.Visible = true;
            this.clTotal.VisibleIndex = 3;
            // 
            // clInvBalance
            // 
            this.clInvBalance.Caption = "Amount";
            this.clInvBalance.DisplayFormat.FormatString = "#,#";
            this.clInvBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clInvBalance.FieldName = "InvoiceBalance";
            this.clInvBalance.Name = "clInvBalance";
            this.clInvBalance.OptionsColumn.AllowEdit = false;
            this.clInvBalance.OptionsColumn.AllowFocus = false;
            this.clInvBalance.OptionsColumn.AllowMove = false;
            this.clInvBalance.OptionsColumn.ReadOnly = true;
            this.clInvBalance.Width = 207;
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
            this.clPayment.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Payment", "{0:n2}")});
            this.clPayment.Visible = true;
            this.clPayment.VisibleIndex = 4;
            this.clPayment.Width = 216;
            // 
            // clBalance
            // 
            this.clBalance.Caption = "Balance";
            this.clBalance.DisplayFormat.FormatString = "#,#";
            this.clBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clBalance.FieldName = "Balance";
            this.clBalance.Name = "clBalance";
            this.clBalance.OptionsColumn.AllowEdit = false;
            this.clBalance.OptionsColumn.AllowFocus = false;
            this.clBalance.OptionsColumn.AllowMove = false;
            this.clBalance.OptionsColumn.ReadOnly = true;
            // 
            // clChecked
            // 
            this.clChecked.Caption = "Checked";
            this.clChecked.FieldName = "Checked";
            this.clChecked.Name = "clChecked";
            this.clChecked.OptionsColumn.AllowEdit = false;
            this.clChecked.OptionsColumn.AllowFocus = false;
            this.clChecked.OptionsColumn.AllowMove = false;
            this.clChecked.OptionsColumn.ReadOnly = true;
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
            // clState
            // 
            this.clState.Caption = "State";
            this.clState.FieldName = "StateChange2";
            this.clState.Name = "clState";
            // 
            // clpayMethod
            // 
            this.clpayMethod.Caption = "Payment Method";
            this.clpayMethod.FieldName = "CollectPaymentMethod";
            this.clpayMethod.Name = "clpayMethod";
            // 
            // clBranch
            // 
            this.clBranch.Caption = "gridColumn14";
            this.clBranch.FieldName = "BranchId";
            this.clBranch.Name = "clBranch";
            // 
            // btnTambahCash
            // 
            this.btnTambahCash.Location = new System.Drawing.Point(264, 3);
            this.btnTambahCash.Name = "btnTambahCash";
            this.btnTambahCash.Size = new System.Drawing.Size(66, 28);
            this.btnTambahCash.TabIndex = 5;
            this.btnTambahCash.Text = "Tambah";
            // 
            // tbxCnCash
            // 
            this.tbxCnCash.Capslock = true;
            this.tbxCnCash.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxCnCash.FieldLabel = null;
            this.tbxCnCash.Location = new System.Drawing.Point(63, 5);
            this.tbxCnCash.Name = "tbxCnCash";
            this.tbxCnCash.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxCnCash.Size = new System.Drawing.Size(198, 24);
            this.tbxCnCash.TabIndex = 4;
            this.tbxCnCash.ValidationRules = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "No. CN";
            // 
            // gbCredit
            // 
            this.gbCredit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCredit.Controls.Add(this.pnlCredit);
            this.gbCredit.ForeColor = System.Drawing.Color.Black;
            this.gbCredit.Location = new System.Drawing.Point(5, 311);
            this.gbCredit.Name = "gbCredit";
            this.gbCredit.Size = new System.Drawing.Size(809, 227);
            this.gbCredit.TabIndex = 7;
            this.gbCredit.TabStop = false;
            this.gbCredit.Text = "Payment Method : CREDIT";
            // 
            // pnlCredit
            // 
            this.pnlCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCredit.BackColor = System.Drawing.Color.DarkSalmon;
            this.pnlCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCredit.Controls.Add(this.GridCredit);
            this.pnlCredit.Controls.Add(this.tbxCustomer);
            this.pnlCredit.Controls.Add(this.label4);
            this.pnlCredit.Controls.Add(this.btnTambahCredit);
            this.pnlCredit.Controls.Add(this.tbxCnCredit);
            this.pnlCredit.Controls.Add(this.label3);
            this.pnlCredit.Location = new System.Drawing.Point(7, 22);
            this.pnlCredit.Name = "pnlCredit";
            this.pnlCredit.Size = new System.Drawing.Size(795, 200);
            this.pnlCredit.TabIndex = 7;
            // 
            // GridCredit
            // 
            this.GridCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridCredit.Location = new System.Drawing.Point(3, 65);
            this.GridCredit.MainView = this.CreditView;
            this.GridCredit.Name = "GridCredit";
            this.GridCredit.Size = new System.Drawing.Size(787, 130);
            this.GridCredit.TabIndex = 10;
            this.GridCredit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.CreditView});
            // 
            // CreditView
            // 
            this.CreditView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn7,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14});
            this.CreditView.GridControl = this.GridCredit;
            this.CreditView.Name = "CreditView";
            this.CreditView.OptionsView.ShowFooter = true;
            this.CreditView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 36;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Id";
            this.gridColumn2.FieldName = "InvoiceId";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Shipment";
            this.gridColumn3.FieldName = "InvoiceCode";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 184;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Date";
            this.gridColumn4.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "InvoiceDate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 120;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "InvoiceTotal";
            this.gridColumn5.FieldName = "InvoiceTotal";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.AllowMove = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Amount";
            this.gridColumn6.DisplayFormat.FormatString = "#,#0";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn6.FieldName = "InvoiceBalance";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.AllowMove = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InvoiceBalance", "{0:n2}")});
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 148;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Balance";
            this.gridColumn8.FieldName = "Balance";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.OptionsColumn.AllowMove = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Checked";
            this.gridColumn9.FieldName = "Checked";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.OptionsColumn.AllowMove = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Paid";
            this.gridColumn10.FieldName = "Paid";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.OptionsColumn.AllowMove = false;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "State";
            this.gridColumn11.FieldName = "StateChange2";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "PaymentMethod";
            this.gridColumn7.FieldName = "CollectPaymentMethod";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Customer Id";
            this.gridColumn12.FieldName = "CollectCustomerId";
            this.gridColumn12.Name = "gridColumn12";
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "CustomerName";
            this.gridColumn13.FieldName = "CollectCustomerName";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.OptionsColumn.AllowMove = false;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 4;
            this.gridColumn13.Width = 226;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "gridColumn14";
            this.gridColumn14.FieldName = "BranchId";
            this.gridColumn14.Name = "gridColumn14";
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
            this.tbxCustomer.Location = new System.Drawing.Point(76, 6);
            this.tbxCustomer.LookupPopup = null;
            this.tbxCustomer.Name = "tbxCustomer";
            this.tbxCustomer.OriginalBackColor = System.Drawing.Color.Empty;
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
            this.tbxCustomer.Size = new System.Drawing.Size(295, 24);
            this.tbxCustomer.TabIndex = 7;
            this.tbxCustomer.ValidationRules = null;
            this.tbxCustomer.Value = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Customer";
            // 
            // btnTambahCredit
            // 
            this.btnTambahCredit.Location = new System.Drawing.Point(305, 33);
            this.btnTambahCredit.Name = "btnTambahCredit";
            this.btnTambahCredit.Size = new System.Drawing.Size(66, 28);
            this.btnTambahCredit.TabIndex = 9;
            this.btnTambahCredit.Text = "Tambah";
            // 
            // tbxCnCredit
            // 
            this.tbxCnCredit.Capslock = true;
            this.tbxCnCredit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxCnCredit.FieldLabel = null;
            this.tbxCnCredit.Location = new System.Drawing.Point(76, 35);
            this.tbxCnCredit.Name = "tbxCnCredit";
            this.tbxCnCredit.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxCnCredit.Size = new System.Drawing.Size(225, 24);
            this.tbxCnCredit.TabIndex = 8;
            this.tbxCnCredit.ValidationRules = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "No. CN";
            // 
            // PaymentInCollectInForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(818, 543);
            this.Controls.Add(this.gbCredit);
            this.Controls.Add(this.gbCash);
            this.Controls.Add(this.tbxDate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PaymentInCollectInForm";
            this.Text = "Finance - Payment In Collect In";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbxDate, 0);
            this.Controls.SetChildIndex(this.gbCash, 0);
            this.Controls.SetChildIndex(this.gbCredit, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            this.gbCash.ResumeLayout(false);
            this.pnlCash.ResumeLayout(false);
            this.pnlCash.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridCash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashView)).EndInit();
            this.gbCredit.ResumeLayout(false);
            this.pnlCredit.ResumeLayout(false);
            this.pnlCredit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridCredit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreditView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCustomer.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Common.Component.dCalendar tbxDate;
        private System.Windows.Forms.GroupBox gbCash;
        private System.Windows.Forms.Panel pnlCash;
        private DevExpress.XtraGrid.GridControl GridCash;
        private DevExpress.XtraGrid.Views.Grid.GridView CashView;
        private DevExpress.XtraEditors.SimpleButton btnTambahCash;
        private Common.Component.dTextBox tbxCnCash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbCredit;
        private System.Windows.Forms.Panel pnlCredit;
        private DevExpress.XtraEditors.SimpleButton btnTambahCredit;
        private Common.Component.dTextBox tbxCnCredit;
        private System.Windows.Forms.Label label3;
        private Common.Component.dLookup tbxCustomer;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private DevExpress.XtraGrid.Columns.GridColumn clInvoiceId;
        private DevExpress.XtraGrid.Columns.GridColumn clShipment;
        private DevExpress.XtraGrid.Columns.GridColumn clDate;
        private DevExpress.XtraGrid.Columns.GridColumn clTotal;
        private DevExpress.XtraGrid.Columns.GridColumn clInvBalance;
        private DevExpress.XtraGrid.Columns.GridColumn clPayment;
        private DevExpress.XtraGrid.Columns.GridColumn clBalance;
        private DevExpress.XtraGrid.Columns.GridColumn clChecked;
        private DevExpress.XtraGrid.Columns.GridColumn clPaid;
        private DevExpress.XtraGrid.Columns.GridColumn clState;
        private DevExpress.XtraGrid.GridControl GridCredit;
        private DevExpress.XtraGrid.Views.Grid.GridView CreditView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn clpayMethod;
        private DevExpress.XtraGrid.Columns.GridColumn clBranch;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;

    }
}