using DevExpress.Utils.Frames;

namespace Franchise.Presentation.CustomerService.Forms
{
    partial class PickupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickupForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.tbxPod = new Franchise.Presentation.Common.Component.dTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxSetoran = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbxMessenger = new Franchise.Presentation.Common.Component.dLookupF();
            this.label15 = new System.Windows.Forms.Label();
            this.tbxDate = new Franchise.Presentation.Common.Component.dCalendar();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxTtlChargeable = new Franchise.Presentation.Common.Component.dTextBoxNumber();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxTtlWeight = new Franchise.Presentation.Common.Component.dTextBoxNumber();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxTtlPiece = new Franchise.Presentation.Common.Component.dTextBoxNumber();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxTtlPod = new Franchise.Presentation.Common.Component.dTextBoxNumber();
            this.label3 = new System.Windows.Forms.Label();
            this.PodGrid = new DevExpress.XtraGrid.GridControl();
            this.PodView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCheckbox = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlGrid.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxMessenger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTtlChargeable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTtlWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTtlPiece.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTtlPod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PodGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PodView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clCheckbox)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGrid.Controls.Add(this.panel2);
            this.pnlGrid.Controls.Add(this.cbxSetoran);
            this.pnlGrid.Controls.Add(this.label16);
            this.pnlGrid.Controls.Add(this.tbxMessenger);
            this.pnlGrid.Controls.Add(this.label15);
            this.pnlGrid.Controls.Add(this.tbxDate);
            this.pnlGrid.Controls.Add(this.label14);
            this.pnlGrid.Location = new System.Drawing.Point(3, 112);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(839, 109);
            this.pnlGrid.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.tbxPod);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(549, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 74);
            this.panel2.TabIndex = 23;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Location = new System.Drawing.Point(219, 34);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(43, 29);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "&Add";
            // 
            // tbxPod
            // 
            this.tbxPod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxPod.Capslock = true;
            this.tbxPod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxPod.FieldLabel = null;
            this.tbxPod.Location = new System.Drawing.Point(15, 37);
            this.tbxPod.Name = "tbxPod";
            this.tbxPod.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPod.Size = new System.Drawing.Size(194, 24);
            this.tbxPod.TabIndex = 27;
            this.tbxPod.ValidationRules = null;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Scan POD";
            // 
            // cbxSetoran
            // 
            this.cbxSetoran.BackColor = System.Drawing.Color.MistyRose;
            this.cbxSetoran.FormattingEnabled = true;
            this.cbxSetoran.Items.AddRange(new object[] {
            "Cash",
            "Bank Transfer"});
            this.cbxSetoran.Location = new System.Drawing.Point(108, 67);
            this.cbxSetoran.Name = "cbxSetoran";
            this.cbxSetoran.Size = new System.Drawing.Size(242, 25);
            this.cbxSetoran.TabIndex = 21;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(27, 72);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 17);
            this.label16.TabIndex = 22;
            this.label16.Text = "Pembayaran";
            // 
            // tbxMessenger
            // 
            this.tbxMessenger.AutoCompleteDataManager = null;
            this.tbxMessenger.AutoCompleteDisplayFormater = null;
            this.tbxMessenger.AutoCompleteInitialized = false;
            this.tbxMessenger.AutocompleteMinimumTextLength = 0;
            this.tbxMessenger.AutoCompleteText = null;
            this.tbxMessenger.AutoCompleteWhereExpression = null;
            this.tbxMessenger.AutoCompleteWheretermFormater = null;
            this.tbxMessenger.ClearOnLeave = true;
            this.tbxMessenger.DisplayString = null;
            this.tbxMessenger.FieldLabel = null;
            this.tbxMessenger.Location = new System.Drawing.Point(108, 41);
            this.tbxMessenger.LookupPopup = null;
            this.tbxMessenger.Name = "tbxMessenger";
            this.tbxMessenger.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxMessenger.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxMessenger.Properties.Appearance.Options.UseFont = true;
            this.tbxMessenger.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxMessenger.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxMessenger.Properties.AutoCompleteDataManager = null;
            this.tbxMessenger.Properties.AutoCompleteDisplayFormater = null;
            this.tbxMessenger.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxMessenger.Properties.AutoCompleteText = null;
            this.tbxMessenger.Properties.AutoCompleteWhereExpression = null;
            this.tbxMessenger.Properties.AutoCompleteWheretermFormater = null;
            this.tbxMessenger.Properties.AutoHeight = false;
            this.tbxMessenger.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxMessenger.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.tbxMessenger.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxMessenger.Properties.LookupPopup = null;
            this.tbxMessenger.Size = new System.Drawing.Size(242, 24);
            this.tbxMessenger.TabIndex = 2;
            this.tbxMessenger.ValidationRules = null;
            this.tbxMessenger.Value = null;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(67, 45);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 17);
            this.label15.TabIndex = 5;
            this.label15.Text = "Kurir";
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(108, 15);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxDate.Properties.Appearance.Options.UseFont = true;
            this.tbxDate.Properties.AutoHeight = false;
            this.tbxDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
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
            this.tbxDate.Size = new System.Drawing.Size(154, 24);
            this.tbxDate.TabIndex = 1;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(52, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 17);
            this.label14.TabIndex = 4;
            this.label14.Text = "Tanggal";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbxTtlChargeable);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbxTtlWeight);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbxTtlPiece);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbxTtlPod);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(3, 484);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(839, 36);
            this.panel1.TabIndex = 7;
            // 
            // tbxTtlChargeable
            // 
            this.tbxTtlChargeable.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTtlChargeable.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTtlChargeable.Enabled = false;
            this.tbxTtlChargeable.FieldLabel = null;
            this.tbxTtlChargeable.Location = new System.Drawing.Point(619, 5);
            this.tbxTtlChargeable.Name = "tbxTtlChargeable";
            this.tbxTtlChargeable.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTtlChargeable.Properties.AllowMouseWheel = false;
            this.tbxTtlChargeable.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.tbxTtlChargeable.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTtlChargeable.Properties.Appearance.Options.UseBackColor = true;
            this.tbxTtlChargeable.Properties.Appearance.Options.UseFont = true;
            this.tbxTtlChargeable.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTtlChargeable.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTtlChargeable.Properties.Mask.BeepOnError = true;
            this.tbxTtlChargeable.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTtlChargeable.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxTtlChargeable.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTtlChargeable.ReadOnly = false;
            this.tbxTtlChargeable.Size = new System.Drawing.Size(57, 24);
            this.tbxTtlChargeable.TabIndex = 8;
            this.tbxTtlChargeable.TextAlign = null;
            this.tbxTtlChargeable.ValidationRules = null;
            this.tbxTtlChargeable.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(511, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Total Chargeable";
            // 
            // tbxTtlWeight
            // 
            this.tbxTtlWeight.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTtlWeight.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTtlWeight.Enabled = false;
            this.tbxTtlWeight.FieldLabel = null;
            this.tbxTtlWeight.Location = new System.Drawing.Point(430, 6);
            this.tbxTtlWeight.Name = "tbxTtlWeight";
            this.tbxTtlWeight.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTtlWeight.Properties.AllowMouseWheel = false;
            this.tbxTtlWeight.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.tbxTtlWeight.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTtlWeight.Properties.Appearance.Options.UseBackColor = true;
            this.tbxTtlWeight.Properties.Appearance.Options.UseFont = true;
            this.tbxTtlWeight.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTtlWeight.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTtlWeight.Properties.Mask.BeepOnError = true;
            this.tbxTtlWeight.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTtlWeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxTtlWeight.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTtlWeight.ReadOnly = false;
            this.tbxTtlWeight.Size = new System.Drawing.Size(57, 24);
            this.tbxTtlWeight.TabIndex = 7;
            this.tbxTtlWeight.TextAlign = null;
            this.tbxTtlWeight.ValidationRules = null;
            this.tbxTtlWeight.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(345, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Total Weight";
            // 
            // tbxTtlPiece
            // 
            this.tbxTtlPiece.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTtlPiece.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTtlPiece.Enabled = false;
            this.tbxTtlPiece.FieldLabel = null;
            this.tbxTtlPiece.Location = new System.Drawing.Point(264, 6);
            this.tbxTtlPiece.Name = "tbxTtlPiece";
            this.tbxTtlPiece.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTtlPiece.Properties.AllowMouseWheel = false;
            this.tbxTtlPiece.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.tbxTtlPiece.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTtlPiece.Properties.Appearance.Options.UseBackColor = true;
            this.tbxTtlPiece.Properties.Appearance.Options.UseFont = true;
            this.tbxTtlPiece.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTtlPiece.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTtlPiece.Properties.Mask.BeepOnError = true;
            this.tbxTtlPiece.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTtlPiece.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxTtlPiece.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTtlPiece.ReadOnly = false;
            this.tbxTtlPiece.Size = new System.Drawing.Size(57, 24);
            this.tbxTtlPiece.TabIndex = 6;
            this.tbxTtlPiece.TextAlign = null;
            this.tbxTtlPiece.ValidationRules = null;
            this.tbxTtlPiece.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total Piece";
            // 
            // tbxTtlPod
            // 
            this.tbxTtlPod.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTtlPod.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTtlPod.Enabled = false;
            this.tbxTtlPod.FieldLabel = null;
            this.tbxTtlPod.Location = new System.Drawing.Point(106, 5);
            this.tbxTtlPod.Name = "tbxTtlPod";
            this.tbxTtlPod.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTtlPod.Properties.AllowMouseWheel = false;
            this.tbxTtlPod.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.tbxTtlPod.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTtlPod.Properties.Appearance.Options.UseBackColor = true;
            this.tbxTtlPod.Properties.Appearance.Options.UseFont = true;
            this.tbxTtlPod.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTtlPod.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTtlPod.Properties.Mask.BeepOnError = true;
            this.tbxTtlPod.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTtlPod.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxTtlPod.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTtlPod.ReadOnly = false;
            this.tbxTtlPod.Size = new System.Drawing.Size(57, 24);
            this.tbxTtlPod.TabIndex = 5;
            this.tbxTtlPod.TextAlign = null;
            this.tbxTtlPod.ValidationRules = null;
            this.tbxTtlPod.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Total POD";
            // 
            // PodGrid
            // 
            this.PodGrid.Location = new System.Drawing.Point(3, 223);
            this.PodGrid.MainView = this.PodView;
            this.PodGrid.Name = "PodGrid";
            this.PodGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.clCheckbox});
            this.PodGrid.Size = new System.Drawing.Size(839, 255);
            this.PodGrid.TabIndex = 8;
            this.PodGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PodView});
            // 
            // PodView
            // 
            this.PodView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn14,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.clState,
            this.gridColumn11,
            this.clChecked,
            this.gridColumn12,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn13});
            this.PodView.GridControl = this.PodGrid;
            this.PodView.Name = "PodView";
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
            // gridColumn2
            // 
            this.gridColumn2.Caption = "POD";
            this.gridColumn2.FieldName = "ShipmentCode";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 185;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Service";
            this.gridColumn14.FieldName = "ServiceType";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            this.gridColumn14.Width = 171;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Package";
            this.gridColumn7.FieldName = "PackageType";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.AllowMove = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 129;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Piece";
            this.gridColumn8.DisplayFormat.FormatString = "n2";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn8.FieldName = "TtlPiece";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.OptionsColumn.AllowMove = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 60;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "GW";
            this.gridColumn9.DisplayFormat.FormatString = "n2";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn9.FieldName = "TtlGrossWeight";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.OptionsColumn.AllowMove = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            this.gridColumn9.Width = 62;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "CW";
            this.gridColumn10.DisplayFormat.FormatString = "n2";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn10.FieldName = "TtlChargeableWeight";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.OptionsColumn.AllowMove = false;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 6;
            this.gridColumn10.Width = 61;
            // 
            // clState
            // 
            this.clState.FieldName = "StateChange";
            this.clState.Name = "clState";
            this.clState.OptionsColumn.AllowEdit = false;
            this.clState.OptionsColumn.AllowFocus = false;
            this.clState.OptionsColumn.AllowMove = false;
            this.clState.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "gridColumn11";
            this.gridColumn11.FieldName = "ShipmentId";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // clChecked
            // 
            this.clChecked.Caption = " ";
            this.clChecked.ColumnEdit = this.clCheckbox;
            this.clChecked.FieldName = "Checked";
            this.clChecked.Name = "clChecked";
            this.clChecked.OptionsColumn.AllowMove = false;
            this.clChecked.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.clChecked.Visible = true;
            this.clChecked.VisibleIndex = 0;
            this.clChecked.Width = 46;
            // 
            // clCheckbox
            // 
            this.clCheckbox.AutoHeight = false;
            this.clCheckbox.Caption = "Check";
            this.clCheckbox.Name = "clCheckbox";
            // 
            // gridColumn12
            // 
            this.gridColumn12.FieldName = "Debs";
            this.gridColumn12.Name = "gridColumn12";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "gridColumn3";
            this.gridColumn3.FieldName = "TotalSales";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "gridColumn4";
            this.gridColumn4.FieldName = "PPN";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "gridColumn5";
            this.gridColumn5.FieldName = "Commission";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "gridColumn6";
            this.gridColumn6.FieldName = "PPH23";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "gridColumn13";
            this.gridColumn13.FieldName = "TotalNetCommission";
            this.gridColumn13.Name = "gridColumn13";
            // 
            // PickupForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(845, 524);
            this.Controls.Add(this.PodGrid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PickupForm";
            this.Text = "Pickup POD";
            this.Controls.SetChildIndex(this.tbxSearch_Code, 0);
            this.Controls.SetChildIndex(this.pnlGrid, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.PodGrid, 0);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxMessenger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTtlChargeable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTtlWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTtlPiece.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTtlPod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PodGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PodView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clCheckbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel panel1;
        private Franchise.Presentation.Common.Component.dTextBoxNumber tbxTtlChargeable;
        private System.Windows.Forms.Label label6;
        private Franchise.Presentation.Common.Component.dTextBoxNumber tbxTtlWeight;
        private System.Windows.Forms.Label label5;
        private Franchise.Presentation.Common.Component.dTextBoxNumber tbxTtlPiece;
        private System.Windows.Forms.Label label4;
        private Franchise.Presentation.Common.Component.dTextBoxNumber tbxTtlPod;
        private System.Windows.Forms.Label label3;
        private Common.Component.dCalendar tbxDate;
        private System.Windows.Forms.Label label14;
        private Common.Component.dLookupF tbxMessenger;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbxSetoran;
        private System.Windows.Forms.Label label16;
        private DevExpress.XtraGrid.GridControl PodGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView PodView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn clState;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn clChecked;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit clCheckbox;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private Common.Component.dTextBox tbxPod;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
    }
}