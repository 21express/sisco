namespace SISCO.Presentation.Operation.Forms
{
    partial class InboundBandaraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InboundBandaraForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxArrTime = new SISCO.Presentation.Common.Component.dTime();
            this.tbxArrWeight = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxArrKoli = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxArrDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxDestination = new SISCO.Presentation.Common.Component.dTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxOrigin = new SISCO.Presentation.Common.Component.dTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxAirline = new SISCO.Presentation.Common.Component.dTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxAwb = new SISCO.Presentation.Common.Component.dTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.GridAirwaybillDetail = new DevExpress.XtraGrid.GridControl();
            this.AirwaybillDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDest = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPiece = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clChargeable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxDimension = new SISCO.Presentation.Common.Component.dTextBox();
            this.pnlLeft.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxArrTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxArrWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxArrKoli.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxArrDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxArrDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridAirwaybillDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AirwaybillDetailView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlLeft.BackColor = System.Drawing.SystemColors.Control;
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.groupBox1);
            this.pnlLeft.Controls.Add(this.tbxDestination);
            this.pnlLeft.Controls.Add(this.label5);
            this.pnlLeft.Controls.Add(this.tbxOrigin);
            this.pnlLeft.Controls.Add(this.label4);
            this.pnlLeft.Controls.Add(this.tbxAirline);
            this.pnlLeft.Controls.Add(this.label3);
            this.pnlLeft.Controls.Add(this.tbxAwb);
            this.pnlLeft.Controls.Add(this.label2);
            this.pnlLeft.Controls.Add(this.tbxDate);
            this.pnlLeft.Controls.Add(this.label1);
            this.pnlLeft.Location = new System.Drawing.Point(5, 39);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(344, 358);
            this.pnlLeft.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.tbxArrTime);
            this.groupBox1.Controls.Add(this.tbxArrWeight);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbxArrKoli);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbxArrDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 118);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arrival at Office";
            // 
            // tbxArrTime
            // 
            this.tbxArrTime.EditValue = new System.DateTime(2014, 7, 8, 0, 0, 0, 0);
            this.tbxArrTime.FieldLabel = null;
            this.tbxArrTime.FormatDateTime = "HH:mm";
            this.tbxArrTime.Location = new System.Drawing.Point(74, 52);
            this.tbxArrTime.Name = "tbxArrTime";
            this.tbxArrTime.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxArrTime.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxArrTime.Properties.Appearance.Options.UseBackColor = true;
            this.tbxArrTime.Properties.AutoHeight = false;
            this.tbxArrTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxArrTime.Properties.DisplayFormat.FormatString = "HH:mm";
            this.tbxArrTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxArrTime.Properties.EditFormat.FormatString = "HH:mm";
            this.tbxArrTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxArrTime.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxArrTime.Properties.Mask.EditMask = "HH:mm";
            this.tbxArrTime.Properties.NullText = "00:00";
            this.tbxArrTime.Size = new System.Drawing.Size(57, 24);
            this.tbxArrTime.TabIndex = 2;
            this.tbxArrTime.ValidationRules = null;
            this.tbxArrTime.Value = new System.DateTime(((long)(0)));
            // 
            // tbxArrWeight
            // 
            this.tbxArrWeight.EditMask = "###,###,###,###,###,##0.00";
            this.tbxArrWeight.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxArrWeight.FieldLabel = null;
            this.tbxArrWeight.Location = new System.Drawing.Point(221, 78);
            this.tbxArrWeight.Name = "tbxArrWeight";
            this.tbxArrWeight.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxArrWeight.Properties.AllowMouseWheel = false;
            this.tbxArrWeight.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxArrWeight.Properties.Appearance.Options.UseBackColor = true;
            this.tbxArrWeight.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxArrWeight.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxArrWeight.Properties.Mask.BeepOnError = true;
            this.tbxArrWeight.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxArrWeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxArrWeight.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxArrWeight.ReadOnly = false;
            this.tbxArrWeight.Size = new System.Drawing.Size(64, 20);
            this.tbxArrWeight.TabIndex = 4;
            this.tbxArrWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxArrWeight.ValidationRules = null;
            this.tbxArrWeight.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(169, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "Weight";
            // 
            // tbxArrKoli
            // 
            this.tbxArrKoli.EditMask = "###,###,###,###,###,##0.00";
            this.tbxArrKoli.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxArrKoli.FieldLabel = null;
            this.tbxArrKoli.Location = new System.Drawing.Point(221, 52);
            this.tbxArrKoli.Name = "tbxArrKoli";
            this.tbxArrKoli.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxArrKoli.Properties.AllowMouseWheel = false;
            this.tbxArrKoli.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxArrKoli.Properties.Appearance.Options.UseBackColor = true;
            this.tbxArrKoli.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxArrKoli.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxArrKoli.Properties.Mask.BeepOnError = true;
            this.tbxArrKoli.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxArrKoli.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxArrKoli.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxArrKoli.ReadOnly = false;
            this.tbxArrKoli.Size = new System.Drawing.Size(64, 20);
            this.tbxArrKoli.TabIndex = 3;
            this.tbxArrKoli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxArrKoli.ValidationRules = null;
            this.tbxArrKoli.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(186, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Koli";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(30, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Time";
            // 
            // tbxArrDate
            // 
            this.tbxArrDate.EditValue = null;
            this.tbxArrDate.FieldLabel = null;
            this.tbxArrDate.FormatDateTime = "hh:mm";
            this.tbxArrDate.Location = new System.Drawing.Point(74, 26);
            this.tbxArrDate.Name = "tbxArrDate";
            this.tbxArrDate.Nullable = false;
            this.tbxArrDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxArrDate.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxArrDate.Properties.Appearance.Options.UseBackColor = true;
            this.tbxArrDate.Properties.AutoHeight = false;
            this.tbxArrDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxArrDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.tbxArrDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxArrDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxArrDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxArrDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxArrDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxArrDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxArrDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxArrDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxArrDate.Properties.NullText = "<<Choose...>>";
            this.tbxArrDate.Size = new System.Drawing.Size(211, 24);
            this.tbxArrDate.TabIndex = 1;
            this.tbxArrDate.ValidationRules = null;
            this.tbxArrDate.Value = new System.DateTime(((long)(0)));
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(33, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Date";
            // 
            // tbxDestination
            // 
            this.tbxDestination.BackColor = System.Drawing.SystemColors.Window;
            this.tbxDestination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxDestination.Capslock = true;
            this.tbxDestination.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDestination.FieldLabel = null;
            this.tbxDestination.Location = new System.Drawing.Point(86, 115);
            this.tbxDestination.Name = "tbxDestination";
            this.tbxDestination.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDestination.ReadOnly = true;
            this.tbxDestination.Size = new System.Drawing.Size(245, 24);
            this.tbxDestination.TabIndex = 21;
            this.tbxDestination.ValidationRules = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(9, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Destination";
            // 
            // tbxOrigin
            // 
            this.tbxOrigin.BackColor = System.Drawing.SystemColors.Window;
            this.tbxOrigin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxOrigin.Capslock = true;
            this.tbxOrigin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxOrigin.FieldLabel = null;
            this.tbxOrigin.Location = new System.Drawing.Point(86, 88);
            this.tbxOrigin.Name = "tbxOrigin";
            this.tbxOrigin.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxOrigin.ReadOnly = true;
            this.tbxOrigin.Size = new System.Drawing.Size(245, 24);
            this.tbxOrigin.TabIndex = 19;
            this.tbxOrigin.ValidationRules = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(36, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Origin";
            // 
            // tbxAirline
            // 
            this.tbxAirline.BackColor = System.Drawing.SystemColors.Window;
            this.tbxAirline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxAirline.Capslock = true;
            this.tbxAirline.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxAirline.FieldLabel = null;
            this.tbxAirline.Location = new System.Drawing.Point(86, 61);
            this.tbxAirline.Name = "tbxAirline";
            this.tbxAirline.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxAirline.ReadOnly = true;
            this.tbxAirline.Size = new System.Drawing.Size(134, 24);
            this.tbxAirline.TabIndex = 17;
            this.tbxAirline.ValidationRules = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(35, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Airline";
            // 
            // tbxAwb
            // 
            this.tbxAwb.BackColor = System.Drawing.SystemColors.Window;
            this.tbxAwb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxAwb.Capslock = true;
            this.tbxAwb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxAwb.FieldLabel = null;
            this.tbxAwb.Location = new System.Drawing.Point(86, 35);
            this.tbxAwb.Name = "tbxAwb";
            this.tbxAwb.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxAwb.ReadOnly = true;
            this.tbxAwb.Size = new System.Drawing.Size(212, 24);
            this.tbxAwb.TabIndex = 15;
            this.tbxAwb.ValidationRules = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(21, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "AWB No.";
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.Enabled = false;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "hh:mm";
            this.tbxDate.Location = new System.Drawing.Point(86, 9);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.tbxDate.Properties.Appearance.Options.UseBackColor = true;
            this.tbxDate.Properties.AutoHeight = false;
            this.tbxDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, false, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
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
            this.tbxDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.tbxDate.Size = new System.Drawing.Size(155, 24);
            this.tbxDate.TabIndex = 13;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(45, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Date";
            // 
            // GridAirwaybillDetail
            // 
            this.GridAirwaybillDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridAirwaybillDetail.Location = new System.Drawing.Point(355, 39);
            this.GridAirwaybillDetail.MainView = this.AirwaybillDetailView;
            this.GridAirwaybillDetail.Name = "GridAirwaybillDetail";
            this.GridAirwaybillDetail.Size = new System.Drawing.Size(490, 313);
            this.GridAirwaybillDetail.TabIndex = 2;
            this.GridAirwaybillDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.AirwaybillDetailView});
            // 
            // AirwaybillDetailView
            // 
            this.AirwaybillDetailView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clNo,
            this.clShipment,
            this.clCustomer,
            this.clDest,
            this.clPiece,
            this.clWeight,
            this.clChargeable});
            this.AirwaybillDetailView.GridControl = this.GridAirwaybillDetail;
            this.AirwaybillDetailView.Name = "AirwaybillDetailView";
            this.AirwaybillDetailView.OptionsView.ShowFooter = true;
            this.AirwaybillDetailView.OptionsView.ShowGroupPanel = false;
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
            this.clNo.Width = 35;
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
            this.clShipment.Width = 147;
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
            this.clCustomer.Width = 174;
            // 
            // clDest
            // 
            this.clDest.Caption = "Destination";
            this.clDest.FieldName = "DestCity";
            this.clDest.Name = "clDest";
            this.clDest.OptionsColumn.AllowEdit = false;
            this.clDest.OptionsColumn.AllowFocus = false;
            this.clDest.OptionsColumn.AllowMove = false;
            this.clDest.OptionsColumn.ReadOnly = true;
            this.clDest.Visible = true;
            this.clDest.VisibleIndex = 3;
            this.clDest.Width = 172;
            // 
            // clPiece
            // 
            this.clPiece.Caption = "Piece";
            this.clPiece.FieldName = "TtlPiece";
            this.clPiece.Name = "clPiece";
            this.clPiece.OptionsColumn.AllowEdit = false;
            this.clPiece.OptionsColumn.AllowFocus = false;
            this.clPiece.OptionsColumn.AllowMove = false;
            this.clPiece.OptionsColumn.ReadOnly = true;
            this.clPiece.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)});
            this.clPiece.Visible = true;
            this.clPiece.VisibleIndex = 4;
            this.clPiece.Width = 49;
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
            this.clWeight.VisibleIndex = 5;
            this.clWeight.Width = 63;
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
            this.clChargeable.VisibleIndex = 6;
            this.clChargeable.Width = 74;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Location = new System.Drawing.Point(355, 355);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 42);
            this.panel1.TabIndex = 3;
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Location = new System.Drawing.Point(394, 2);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(91, 35);
            this.btnExcel.TabIndex = 0;
            this.btnExcel.Text = "Save To Excel";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(363, 329);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = "Dimension";
            // 
            // tbxDimension
            // 
            this.tbxDimension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxDimension.Capslock = true;
            this.tbxDimension.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDimension.FieldLabel = null;
            this.tbxDimension.Location = new System.Drawing.Point(434, 325);
            this.tbxDimension.Name = "tbxDimension";
            this.tbxDimension.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDimension.ReadOnly = true;
            this.tbxDimension.Size = new System.Drawing.Size(219, 24);
            this.tbxDimension.TabIndex = 5;
            this.tbxDimension.ValidationRules = null;
            // 
            // InboundBandaraForm
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(852, 402);
            this.Controls.Add(this.tbxDimension);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GridAirwaybillDetail);
            this.Controls.Add(this.pnlLeft);
            this.Name = "InboundBandaraForm";
            this.Text = "Operation - Inbound Bandara";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.Controls.SetChildIndex(this.pnlLeft, 0);
            this.Controls.SetChildIndex(this.GridAirwaybillDetail, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.tbxDimension, 0);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxArrTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxArrWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxArrKoli.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxArrDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxArrDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridAirwaybillDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AirwaybillDetailView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private Common.Component.dTextBox tbxDestination;
        private System.Windows.Forms.Label label5;
        private Common.Component.dTextBox tbxOrigin;
        private System.Windows.Forms.Label label4;
        private Common.Component.dTextBox tbxAirline;
        private System.Windows.Forms.Label label3;
        private Common.Component.dTextBox tbxAwb;
        private System.Windows.Forms.Label label2;
        private Common.Component.dCalendar tbxDate;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl GridAirwaybillDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView AirwaybillDetailView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private Common.Component.dCalendar tbxArrDate;
        private System.Windows.Forms.Label label6;
        private Common.Component.dTextBoxNumber tbxArrWeight;
        private System.Windows.Forms.Label label9;
        private Common.Component.dTextBoxNumber tbxArrKoli;
        private System.Windows.Forms.Label label8;
        private Common.Component.dTime tbxArrTime;
        private DevExpress.XtraGrid.Columns.GridColumn clShipment;
        private DevExpress.XtraGrid.Columns.GridColumn clCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn clDest;
        private DevExpress.XtraGrid.Columns.GridColumn clPiece;
        private DevExpress.XtraGrid.Columns.GridColumn clWeight;
        private DevExpress.XtraGrid.Columns.GridColumn clChargeable;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private System.Windows.Forms.Label label10;
        private Common.Component.dTextBox tbxDimension;

    }
}