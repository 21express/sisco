namespace SISCO.Presentation.Finance.Forms
{
    partial class TitipInvoiceViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TitipInvoiceViewForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxFrom = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tbxTo = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tbxDest = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tbxCustomer = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.GridTitipInvoice = new DevExpress.XtraGrid.GridControl();
            this.TitipInvoiceView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tbxOutstanding = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.chkLunas = new SISCO.Presentation.Common.Component.dCheckBox(this.components);
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridTitipInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitipInvoiceView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxOutstanding.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(18, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tgl Titip Invoice Awal";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxFrom
            // 
            this.tbxFrom.EditValue = null;
            this.tbxFrom.FieldLabel = null;
            this.tbxFrom.FormatDateTime = "dd-MM-yyyy";
            this.tbxFrom.Location = new System.Drawing.Point(159, 6);
            this.tbxFrom.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbxFrom.Name = "tbxFrom";
            this.tbxFrom.Nullable = false;
            this.tbxFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFrom.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxFrom.Properties.Appearance.Options.UseBackColor = true;
            this.tbxFrom.Properties.AutoHeight = false;
            this.tbxFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxFrom.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.tbxFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxFrom.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxFrom.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxFrom.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxFrom.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxFrom.Size = new System.Drawing.Size(116, 24);
            this.tbxFrom.TabIndex = 1;
            this.tbxFrom.ValidationRules = null;
            this.tbxFrom.Value = new System.DateTime(((long)(0)));
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(80, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Akhir";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxTo
            // 
            this.tbxTo.EditValue = null;
            this.tbxTo.FieldLabel = null;
            this.tbxTo.FormatDateTime = "dd-MM-yyyy";
            this.tbxTo.Location = new System.Drawing.Point(159, 33);
            this.tbxTo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbxTo.Name = "tbxTo";
            this.tbxTo.Nullable = false;
            this.tbxTo.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTo.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxTo.Properties.Appearance.Options.UseBackColor = true;
            this.tbxTo.Properties.AutoHeight = false;
            this.tbxTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxTo.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxTo.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxTo.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxTo.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxTo.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxTo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTo.Size = new System.Drawing.Size(171, 24);
            this.tbxTo.TabIndex = 2;
            this.tbxTo.ValidationRules = null;
            this.tbxTo.Value = new System.DateTime(((long)(0)));
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(80, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Dest Branch";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxDest
            // 
            this.tbxDest.AutoCompleteDataManager = null;
            this.tbxDest.AutoCompleteDisplayFormater = null;
            this.tbxDest.AutoCompleteInitialized = false;
            this.tbxDest.AutocompleteMinimumTextLength = 0;
            this.tbxDest.AutoCompleteText = null;
            this.tbxDest.AutoCompleteWhereExpression = null;
            this.tbxDest.AutoCompleteWheretermFormater = null;
            this.tbxDest.ClearOnLeave = true;
            this.tbxDest.DisplayString = null;
            this.tbxDest.FieldLabel = null;
            this.tbxDest.Location = new System.Drawing.Point(159, 60);
            this.tbxDest.LookupPopup = null;
            this.tbxDest.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbxDest.Name = "tbxDest";
            this.tbxDest.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDest.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxDest.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxDest.Properties.AutoCompleteDataManager = null;
            this.tbxDest.Properties.AutoCompleteDisplayFormater = null;
            this.tbxDest.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxDest.Properties.AutoCompleteText = null;
            this.tbxDest.Properties.AutoCompleteWhereExpression = null;
            this.tbxDest.Properties.AutoCompleteWheretermFormater = null;
            this.tbxDest.Properties.AutoHeight = false;
            this.tbxDest.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxDest.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.tbxDest.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDest.Properties.LookupPopup = null;
            this.tbxDest.Properties.NullText = "<<Choose...>>";
            this.tbxDest.Size = new System.Drawing.Size(262, 24);
            this.tbxDest.TabIndex = 3;
            this.tbxDest.ValidationRules = null;
            this.tbxDest.Value = null;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(80, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Customer";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.tbxCustomer.Location = new System.Drawing.Point(159, 86);
            this.tbxCustomer.LookupPopup = null;
            this.tbxCustomer.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxCustomer.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.tbxCustomer.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxCustomer.Properties.LookupPopup = null;
            this.tbxCustomer.Properties.NullText = "<<Choose...>>";
            this.tbxCustomer.Size = new System.Drawing.Size(306, 24);
            this.tbxCustomer.TabIndex = 4;
            this.tbxCustomer.ValidationRules = null;
            this.tbxCustomer.Value = null;
            // 
            // btnView
            // 
            this.btnView.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnView.Appearance.Options.UseFont = true;
            this.btnView.Location = new System.Drawing.Point(159, 142);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(101, 34);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "View";
            // 
            // GridTitipInvoice
            // 
            this.GridTitipInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridTitipInvoice.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.GridTitipInvoice.Location = new System.Drawing.Point(0, 181);
            this.GridTitipInvoice.MainView = this.TitipInvoiceView;
            this.GridTitipInvoice.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.GridTitipInvoice.Name = "GridTitipInvoice";
            this.GridTitipInvoice.Size = new System.Drawing.Size(885, 251);
            this.GridTitipInvoice.TabIndex = 8;
            this.GridTitipInvoice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.TitipInvoiceView});
            // 
            // TitipInvoiceView
            // 
            this.TitipInvoiceView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn6,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.TitipInvoiceView.GridControl = this.GridTitipInvoice;
            this.TitipInvoiceView.Name = "TitipInvoiceView";
            this.TitipInvoiceView.OptionsView.ColumnAutoWidth = false;
            this.TitipInvoiceView.OptionsView.ShowFooter = true;
            this.TitipInvoiceView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No.";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 29;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Date";
            this.gridColumn6.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn6.FieldName = "DateProcess";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.AllowMove = false;
            this.gridColumn6.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 68;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Titip Invoice";
            this.gridColumn2.FieldName = "Code";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 128;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "No. Kwitansi";
            this.gridColumn3.FieldName = "RefNumber";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 153;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Dest Branch";
            this.gridColumn4.FieldName = "BranchName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 109;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Customer";
            this.gridColumn5.FieldName = "CustomerName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.AllowMove = false;
            this.gridColumn5.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 109;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Total";
            this.gridColumn7.DisplayFormat.FormatString = "#,#0";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn7.FieldName = "Total";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.AllowMove = false;
            this.gridColumn7.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:n1}")});
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 115;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Total Payment In";
            this.gridColumn8.DisplayFormat.FormatString = "#,#0";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn8.FieldName = "InTotalPayment";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.OptionsColumn.AllowMove = false;
            this.gridColumn8.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InTotalPayment", "{0:n1}")});
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 113;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Total Payment Out";
            this.gridColumn9.DisplayFormat.FormatString = "#,#0";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn9.FieldName = "OutTotalPayment";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.OptionsColumn.AllowMove = false;
            this.gridColumn9.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutTotalPayment", "{0:n1}")});
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 97;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Lunas?";
            this.gridColumn10.FieldName = "OutPaid";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.OptionsColumn.AllowMove = false;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            // 
            // tbxOutstanding
            // 
            this.tbxOutstanding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxOutstanding.EditMask = "###,###,###,###,###,##0.00";
            this.tbxOutstanding.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxOutstanding.FieldLabel = null;
            this.tbxOutstanding.Location = new System.Drawing.Point(679, 436);
            this.tbxOutstanding.Name = "tbxOutstanding";
            this.tbxOutstanding.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxOutstanding.Properties.AllowMouseWheel = false;
            this.tbxOutstanding.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxOutstanding.Properties.Appearance.Options.UseFont = true;
            this.tbxOutstanding.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxOutstanding.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxOutstanding.Properties.Mask.BeepOnError = true;
            this.tbxOutstanding.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxOutstanding.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxOutstanding.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxOutstanding.Properties.ReadOnly = true;
            this.tbxOutstanding.ReadOnly = true;
            this.tbxOutstanding.Size = new System.Drawing.Size(201, 20);
            this.tbxOutstanding.TabIndex = 11;
            this.tbxOutstanding.TextAlign = null;
            this.tbxOutstanding.ValidationRules = null;
            this.tbxOutstanding.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(590, 439);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Outstanding";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkLunas
            // 
            this.chkLunas.AutoSize = true;
            this.chkLunas.FieldLabel = null;
            this.chkLunas.Location = new System.Drawing.Point(159, 116);
            this.chkLunas.Name = "chkLunas";
            this.chkLunas.Size = new System.Drawing.Size(64, 21);
            this.chkLunas.TabIndex = 12;
            this.chkLunas.Text = "Lunas?";
            this.chkLunas.UseVisualStyleBackColor = true;
            this.chkLunas.ValidationRules = null;
            // 
            // btnExcel
            // 
            this.btnExcel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExcel.Appearance.Options.UseFont = true;
            this.btnExcel.Location = new System.Drawing.Point(3, 434);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(89, 28);
            this.btnExcel.TabIndex = 13;
            this.btnExcel.Text = "Save To Excel";
            // 
            // TitipInvoiceViewForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(885, 464);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.chkLunas);
            this.Controls.Add(this.tbxOutstanding);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.GridTitipInvoice);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.tbxCustomer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxDest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxFrom);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TitipInvoiceViewForm";
            this.Text = "Finance - Titip Invoice Payment View";
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridTitipInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitipInvoiceView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxOutstanding.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Common.Component.dCalendar tbxFrom;
        private System.Windows.Forms.Label label2;
        private Common.Component.dCalendar tbxTo;
        private System.Windows.Forms.Label label3;
        private Common.Component.dLookup tbxDest;
        private System.Windows.Forms.Label label4;
        private Common.Component.dLookup tbxCustomer;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraGrid.GridControl GridTitipInvoice;
        private DevExpress.XtraGrid.Views.Grid.GridView TitipInvoiceView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private Common.Component.dTextBoxNumber tbxOutstanding;
        private System.Windows.Forms.Label label5;
        private Common.Component.dCheckBox chkLunas;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
    }
}