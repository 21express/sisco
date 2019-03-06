namespace SISCO.Presentation.Operation.Forms
{
    partial class DeliveryResultForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryResultForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxNote = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.tbxReciever = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tbxBarcode = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.btnFilter = new DevExpress.XtraEditors.SimpleButton();
            this.tbxCourier = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.GridDeliveryResult = new DevExpress.XtraGrid.GridControl();
            this.DeliveryResultView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clBranch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clConsignee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPiece = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clChargeable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clReceived = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clReceive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clReceivedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clService = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnPrintPreview = new DevExpress.XtraEditors.SimpleButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCourier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDeliveryResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryResultView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.PeachPuff;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbxDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnFilter);
            this.panel1.Controls.Add(this.tbxCourier);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(948, 206);
            this.panel1.TabIndex = 0;
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(101, 8);
            this.tbxDate.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
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
            this.tbxDate.Size = new System.Drawing.Size(147, 24);
            this.tbxDate.TabIndex = 26;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(37, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 22);
            this.label1.TabIndex = 27;
            this.label1.Text = "Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbxNote);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbxReciever);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbxBarcode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Meiryo", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(507, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.groupBox1.Size = new System.Drawing.Size(427, 189);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update Delivery";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.Location = new System.Drawing.Point(93, 140);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(107, 40);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Meiryo", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(90, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 15);
            this.label6.TabIndex = 32;
            this.label6.Text = "(Kosongkan apabila tidak terkirim)";
            // 
            // tbxNote
            // 
            this.tbxNote.Capslock = true;
            this.tbxNote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxNote.FieldLabel = null;
            this.tbxNote.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNote.Location = new System.Drawing.Point(93, 113);
            this.tbxNote.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.tbxNote.Name = "tbxNote";
            this.tbxNote.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxNote.Size = new System.Drawing.Size(312, 24);
            this.tbxNote.TabIndex = 6;
            this.tbxNote.ValidationRules = null;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(29, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 22);
            this.label5.TabIndex = 30;
            this.label5.Text = "Note";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxReciever
            // 
            this.tbxReciever.Capslock = true;
            this.tbxReciever.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxReciever.FieldLabel = null;
            this.tbxReciever.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxReciever.Location = new System.Drawing.Point(93, 56);
            this.tbxReciever.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.tbxReciever.Name = "tbxReciever";
            this.tbxReciever.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxReciever.Size = new System.Drawing.Size(312, 24);
            this.tbxReciever.TabIndex = 5;
            this.tbxReciever.ValidationRules = null;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(29, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 22);
            this.label4.TabIndex = 28;
            this.label4.Text = "Nama Penerima";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxBarcode
            // 
            this.tbxBarcode.Capslock = true;
            this.tbxBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxBarcode.FieldLabel = null;
            this.tbxBarcode.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxBarcode.Location = new System.Drawing.Point(93, 30);
            this.tbxBarcode.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.tbxBarcode.Name = "tbxBarcode";
            this.tbxBarcode.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxBarcode.Size = new System.Drawing.Size(184, 24);
            this.tbxBarcode.TabIndex = 4;
            this.tbxBarcode.ValidationRules = null;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(29, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 22);
            this.label3.TabIndex = 26;
            this.label3.Text = "No. CN";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnFilter
            // 
            this.btnFilter.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnFilter.Appearance.Options.UseFont = true;
            this.btnFilter.Location = new System.Drawing.Point(101, 61);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(107, 32);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "Filter";
            // 
            // tbxCourier
            // 
            this.tbxCourier.AutoCompleteDataManager = null;
            this.tbxCourier.AutoCompleteDisplayFormater = null;
            this.tbxCourier.AutoCompleteInitialized = false;
            this.tbxCourier.AutocompleteMinimumTextLength = 0;
            this.tbxCourier.AutoCompleteText = null;
            this.tbxCourier.AutoCompleteWhereExpression = null;
            this.tbxCourier.AutoCompleteWheretermFormater = null;
            this.tbxCourier.ClearOnLeave = true;
            this.tbxCourier.DisplayString = null;
            this.tbxCourier.FieldLabel = null;
            this.tbxCourier.Location = new System.Drawing.Point(101, 34);
            this.tbxCourier.LookupPopup = null;
            this.tbxCourier.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.tbxCourier.Name = "tbxCourier";
            this.tbxCourier.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxCourier.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxCourier.Properties.Appearance.Options.UseFont = true;
            this.tbxCourier.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxCourier.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxCourier.Properties.AutoCompleteDataManager = null;
            this.tbxCourier.Properties.AutoCompleteDisplayFormater = null;
            this.tbxCourier.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxCourier.Properties.AutoCompleteText = null;
            this.tbxCourier.Properties.AutoCompleteWhereExpression = null;
            this.tbxCourier.Properties.AutoCompleteWheretermFormater = null;
            this.tbxCourier.Properties.AutoHeight = false;
            this.tbxCourier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxCourier.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxCourier.Properties.LookupPopup = null;
            this.tbxCourier.Properties.NullText = "<<Choose...>>";
            this.tbxCourier.Size = new System.Drawing.Size(293, 24);
            this.tbxCourier.TabIndex = 1;
            this.tbxCourier.ValidationRules = null;
            this.tbxCourier.Value = null;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(37, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 22);
            this.label2.TabIndex = 15;
            this.label2.Text = "Kurir";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GridDeliveryResult
            // 
            this.GridDeliveryResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridDeliveryResult.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.GridDeliveryResult.Location = new System.Drawing.Point(3, 217);
            this.GridDeliveryResult.MainView = this.DeliveryResultView;
            this.GridDeliveryResult.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.GridDeliveryResult.Name = "GridDeliveryResult";
            this.GridDeliveryResult.Size = new System.Drawing.Size(948, 229);
            this.GridDeliveryResult.TabIndex = 1;
            this.GridDeliveryResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DeliveryResultView});
            // 
            // DeliveryResultView
            // 
            this.DeliveryResultView.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.DeliveryResultView.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Transparent;
            this.DeliveryResultView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.DeliveryResultView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Transparent;
            this.DeliveryResultView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Transparent;
            this.DeliveryResultView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.DeliveryResultView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clNo,
            this.clShipment,
            this.clCustomer,
            this.clBranch,
            this.clPayment,
            this.clConsignee,
            this.clPiece,
            this.clWeight,
            this.clChargeable,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn1,
            this.clReceived,
            this.clNote,
            this.clId,
            this.clState,
            this.clReceive,
            this.clReceivedDate,
            this.clUpdate,
            this.clService,
            this.gridColumn4});
            this.DeliveryResultView.GridControl = this.GridDeliveryResult;
            this.DeliveryResultView.Name = "DeliveryResultView";
            this.DeliveryResultView.OptionsView.ShowFooter = true;
            this.DeliveryResultView.OptionsView.ShowGroupPanel = false;
            // 
            // clNo
            // 
            this.clNo.Caption = "No";
            this.clNo.Name = "clNo";
            this.clNo.OptionsColumn.AllowEdit = false;
            this.clNo.OptionsColumn.AllowFocus = false;
            this.clNo.OptionsColumn.AllowMove = false;
            this.clNo.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.True;
            this.clNo.Visible = true;
            this.clNo.VisibleIndex = 0;
            this.clNo.Width = 20;
            // 
            // clShipment
            // 
            this.clShipment.Caption = "Shipment";
            this.clShipment.FieldName = "ShipmentCode";
            this.clShipment.Name = "clShipment";
            this.clShipment.OptionsColumn.AllowEdit = false;
            this.clShipment.OptionsColumn.AllowFocus = false;
            this.clShipment.OptionsColumn.AllowMove = false;
            this.clShipment.OptionsColumn.ReadOnly = true;
            this.clShipment.Visible = true;
            this.clShipment.VisibleIndex = 1;
            this.clShipment.Width = 59;
            // 
            // clCustomer
            // 
            this.clCustomer.Caption = "Customer";
            this.clCustomer.FieldName = "CustomerName";
            this.clCustomer.Name = "clCustomer";
            this.clCustomer.OptionsColumn.AllowEdit = false;
            this.clCustomer.OptionsColumn.AllowFocus = false;
            this.clCustomer.OptionsColumn.AllowMove = false;
            this.clCustomer.OptionsColumn.ReadOnly = true;
            this.clCustomer.Visible = true;
            this.clCustomer.VisibleIndex = 2;
            this.clCustomer.Width = 49;
            // 
            // clBranch
            // 
            this.clBranch.Caption = "Branch";
            this.clBranch.FieldName = "Branch";
            this.clBranch.Name = "clBranch";
            this.clBranch.OptionsColumn.AllowEdit = false;
            this.clBranch.OptionsColumn.AllowFocus = false;
            this.clBranch.OptionsColumn.AllowMove = false;
            this.clBranch.OptionsColumn.ReadOnly = true;
            this.clBranch.Visible = true;
            this.clBranch.VisibleIndex = 3;
            this.clBranch.Width = 41;
            // 
            // clPayment
            // 
            this.clPayment.Caption = "Payment";
            this.clPayment.FieldName = "PaymentMethod";
            this.clPayment.Name = "clPayment";
            this.clPayment.OptionsColumn.AllowEdit = false;
            this.clPayment.OptionsColumn.AllowFocus = false;
            this.clPayment.OptionsColumn.AllowMove = false;
            this.clPayment.OptionsColumn.ReadOnly = true;
            this.clPayment.Visible = true;
            this.clPayment.VisibleIndex = 4;
            this.clPayment.Width = 38;
            // 
            // clConsignee
            // 
            this.clConsignee.Caption = "Consignee";
            this.clConsignee.FieldName = "ConsigneeName";
            this.clConsignee.Name = "clConsignee";
            this.clConsignee.OptionsColumn.AllowEdit = false;
            this.clConsignee.OptionsColumn.AllowFocus = false;
            this.clConsignee.OptionsColumn.AllowMove = false;
            this.clConsignee.OptionsColumn.ReadOnly = true;
            this.clConsignee.Visible = true;
            this.clConsignee.VisibleIndex = 5;
            this.clConsignee.Width = 38;
            // 
            // clPiece
            // 
            this.clPiece.Caption = "Pcs";
            this.clPiece.FieldName = "TtlPiece";
            this.clPiece.Name = "clPiece";
            this.clPiece.OptionsColumn.AllowEdit = false;
            this.clPiece.OptionsColumn.AllowFocus = false;
            this.clPiece.OptionsColumn.AllowMove = false;
            this.clPiece.OptionsColumn.ReadOnly = true;
            this.clPiece.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clPiece.Visible = true;
            this.clPiece.VisibleIndex = 6;
            this.clPiece.Width = 38;
            // 
            // clWeight
            // 
            this.clWeight.Caption = "Weight";
            this.clWeight.FieldName = "TtlGrossWeight";
            this.clWeight.Name = "clWeight";
            this.clWeight.OptionsColumn.AllowEdit = false;
            this.clWeight.OptionsColumn.AllowFocus = false;
            this.clWeight.OptionsColumn.AllowMove = false;
            this.clWeight.OptionsColumn.ReadOnly = true;
            this.clWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clWeight.Visible = true;
            this.clWeight.VisibleIndex = 7;
            this.clWeight.Width = 38;
            // 
            // clChargeable
            // 
            this.clChargeable.Caption = "Chargeable";
            this.clChargeable.FieldName = "TtlChargeableWeight";
            this.clChargeable.Name = "clChargeable";
            this.clChargeable.OptionsColumn.AllowEdit = false;
            this.clChargeable.OptionsColumn.AllowFocus = false;
            this.clChargeable.OptionsColumn.AllowMove = false;
            this.clChargeable.OptionsColumn.ReadOnly = true;
            this.clChargeable.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clChargeable.Visible = true;
            this.clChargeable.VisibleIndex = 8;
            this.clChargeable.Width = 38;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "COD";
            this.gridColumn2.FieldName = "IsCod";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 12;
            this.gridColumn2.Width = 27;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Total COD";
            this.gridColumn3.DisplayFormat.FormatString = "#,#0";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "TotalCod";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalCod", "{0:n2}")});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 13;
            this.gridColumn3.Width = 66;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = " ";
            this.gridColumn1.FieldName = "Received";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 9;
            this.gridColumn1.Width = 20;
            // 
            // clReceived
            // 
            this.clReceived.Caption = "Received By";
            this.clReceived.FieldName = "ReceivedBy";
            this.clReceived.Name = "clReceived";
            this.clReceived.OptionsColumn.AllowEdit = false;
            this.clReceived.OptionsColumn.AllowFocus = false;
            this.clReceived.OptionsColumn.AllowMove = false;
            this.clReceived.OptionsColumn.ReadOnly = true;
            this.clReceived.Visible = true;
            this.clReceived.VisibleIndex = 10;
            this.clReceived.Width = 52;
            // 
            // clNote
            // 
            this.clNote.Caption = "Note";
            this.clNote.FieldName = "ReceivedNote";
            this.clNote.Name = "clNote";
            this.clNote.OptionsColumn.AllowEdit = false;
            this.clNote.OptionsColumn.AllowFocus = false;
            this.clNote.OptionsColumn.AllowMove = false;
            this.clNote.OptionsColumn.ReadOnly = true;
            this.clNote.Visible = true;
            this.clNote.VisibleIndex = 11;
            this.clNote.Width = 90;
            // 
            // clId
            // 
            this.clId.Caption = "Id";
            this.clId.FieldName = "Id";
            this.clId.Name = "clId";
            // 
            // clState
            // 
            this.clState.Caption = "State";
            this.clState.FieldName = "StateChange2";
            this.clState.Name = "clState";
            // 
            // clReceive
            // 
            this.clReceive.Caption = "Received";
            this.clReceive.FieldName = "Received";
            this.clReceive.Name = "clReceive";
            // 
            // clReceivedDate
            // 
            this.clReceivedDate.Caption = "Received Date";
            this.clReceivedDate.FieldName = "ReceivedDate";
            this.clReceivedDate.Name = "clReceivedDate";
            // 
            // clUpdate
            // 
            this.clUpdate.Caption = "Update";
            this.clUpdate.FieldName = "ReceivedUpdate";
            this.clUpdate.Name = "clUpdate";
            // 
            // clService
            // 
            this.clService.Caption = "Service";
            this.clService.FieldName = "ServiceTypeId";
            this.clService.Name = "clService";
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintPreview.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPrintPreview.Appearance.Options.UseFont = true;
            this.btnPrintPreview.Location = new System.Drawing.Point(689, 450);
            this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(142, 35);
            this.btnPrintPreview.TabIndex = 2;
            this.btnPrintPreview.Text = "Print Preview";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Red;
            this.label7.ForeColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(9, 457);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "ONS / SDS";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Blue;
            this.label8.ForeColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(99, 457);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Regular";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(837, 450);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 35);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "SAVE";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Location = new System.Drawing.Point(572, 450);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(111, 35);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Print";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Fulfilment";
            this.gridColumn4.FieldName = "Fulfilment";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 14;
            this.gridColumn4.Width = 82;
            // 
            // DeliveryResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(955, 488);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnPrintPreview);
            this.Controls.Add(this.GridDeliveryResult);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DeliveryResultForm";
            this.Text = "Operation - Delivery Result";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCourier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDeliveryResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryResultView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnFilter;
        private Common.Component.dLookup tbxCourier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private System.Windows.Forms.Label label6;
        private Common.Component.dTextBox tbxNote;
        private System.Windows.Forms.Label label5;
        private Common.Component.dTextBox tbxReciever;
        private System.Windows.Forms.Label label4;
        private Common.Component.dTextBox tbxBarcode;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.GridControl GridDeliveryResult;
        private DevExpress.XtraGrid.Views.Grid.GridView DeliveryResultView;
        private DevExpress.XtraEditors.SimpleButton btnPrintPreview;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraGrid.Columns.GridColumn clShipment;
        private DevExpress.XtraGrid.Columns.GridColumn clCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn clBranch;
        private DevExpress.XtraGrid.Columns.GridColumn clPayment;
        private DevExpress.XtraGrid.Columns.GridColumn clConsignee;
        private DevExpress.XtraGrid.Columns.GridColumn clReceived;
        private DevExpress.XtraGrid.Columns.GridColumn clNote;
        private DevExpress.XtraGrid.Columns.GridColumn clId;
        private DevExpress.XtraGrid.Columns.GridColumn clPiece;
        private DevExpress.XtraGrid.Columns.GridColumn clWeight;
        private DevExpress.XtraGrid.Columns.GridColumn clChargeable;
        private DevExpress.XtraGrid.Columns.GridColumn clState;
        private DevExpress.XtraGrid.Columns.GridColumn clReceive;
        private DevExpress.XtraGrid.Columns.GridColumn clReceivedDate;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn clUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn clService;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private Common.Component.dCalendar tbxDate;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;


    }
}