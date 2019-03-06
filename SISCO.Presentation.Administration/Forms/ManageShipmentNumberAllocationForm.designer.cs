namespace SISCO.Presentation.Administration.Forms
{
    partial class ManageShipmentNumberAllocationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageShipmentNumberAllocationForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlBlanko = new System.Windows.Forms.Panel();
            this.btnPrintPOD = new System.Windows.Forms.Button();
            this.chkPrintContinuos = new System.Windows.Forms.CheckBox();
            this.btnRecount = new System.Windows.Forms.Button();
            this.txtUsed = new SISCO.Presentation.Common.Component.dTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCount = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtAddress = new SISCO.Presentation.Common.Component.dTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEnd = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStart = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label2 = new System.Windows.Forms.Label();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.lkpDropPoint = new SISCO.Presentation.Common.Component.dLookup();
            this.rbDropPoint = new System.Windows.Forms.RadioButton();
            this.rbFranchise = new System.Windows.Forms.RadioButton();
            this.rbCustomer = new System.Windows.Forms.RadioButton();
            this.pnlBarcode = new System.Windows.Forms.Panel();
            this.cbxPrintName = new SISCO.Presentation.Common.Component.dCheckBox();
            this.tbxEnd = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxStart = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPrintBarcode = new System.Windows.Forms.Button();
            this.lkpFranchise = new SISCO.Presentation.Common.Component.dLookup();
            this.txtDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.lkpCustomer = new SISCO.Presentation.Common.Component.dLookup();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlBlanko.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStart.Properties)).BeginInit();
            this.grpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDropPoint.Properties)).BeginInit();
            this.pnlBarcode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFranchise.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBlanko
            // 
            this.pnlBlanko.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlBlanko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBlanko.Controls.Add(this.btnPrintPOD);
            this.pnlBlanko.Controls.Add(this.chkPrintContinuos);
            this.pnlBlanko.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBlanko.Location = new System.Drawing.Point(443, 188);
            this.pnlBlanko.Name = "pnlBlanko";
            this.pnlBlanko.Size = new System.Drawing.Size(255, 72);
            this.pnlBlanko.TabIndex = 135;
            // 
            // btnPrintPOD
            // 
            this.btnPrintPOD.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintPOD.Image = global::SISCO.Presentation.Administration.Properties.Resources.icon_print_small;
            this.btnPrintPOD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintPOD.Location = new System.Drawing.Point(8, 8);
            this.btnPrintPOD.Name = "btnPrintPOD";
            this.btnPrintPOD.Size = new System.Drawing.Size(85, 30);
            this.btnPrintPOD.TabIndex = 111;
            this.btnPrintPOD.Text = "Print POD";
            this.btnPrintPOD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintPOD.UseVisualStyleBackColor = true;
            // 
            // chkPrintContinuos
            // 
            this.chkPrintContinuos.AutoSize = true;
            this.chkPrintContinuos.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrintContinuos.Location = new System.Drawing.Point(8, 44);
            this.chkPrintContinuos.Name = "chkPrintContinuos";
            this.chkPrintContinuos.Size = new System.Drawing.Size(132, 21);
            this.chkPrintContinuos.TabIndex = 134;
            this.chkPrintContinuos.Text = "in continuous form";
            this.chkPrintContinuos.UseVisualStyleBackColor = true;
            // 
            // btnRecount
            // 
            this.btnRecount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRecount.Image = global::SISCO.Presentation.Administration.Properties.Resources.icon_refresh_small;
            this.btnRecount.Location = new System.Drawing.Point(246, 230);
            this.btnRecount.Name = "btnRecount";
            this.btnRecount.Size = new System.Drawing.Size(24, 24);
            this.btnRecount.TabIndex = 108;
            this.btnRecount.UseVisualStyleBackColor = true;
            // 
            // txtUsed
            // 
            this.txtUsed.Capslock = true;
            this.txtUsed.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsed.Enabled = false;
            this.txtUsed.FieldLabel = null;
            this.txtUsed.Location = new System.Drawing.Point(121, 230);
            this.txtUsed.Name = "txtUsed";
            this.txtUsed.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtUsed.Size = new System.Drawing.Size(119, 24);
            this.txtUsed.TabIndex = 9;
            this.txtUsed.ValidationRules = null;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(29, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 19);
            this.label9.TabIndex = 118;
            this.label9.Text = "Address";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 19);
            this.label5.TabIndex = 118;
            this.label5.Text = "Used";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCount
            // 
            this.txtCount.Capslock = true;
            this.txtCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCount.FieldLabel = null;
            this.txtCount.Location = new System.Drawing.Point(121, 205);
            this.txtCount.Name = "txtCount";
            this.txtCount.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtCount.Size = new System.Drawing.Size(89, 24);
            this.txtCount.TabIndex = 8;
            this.txtCount.ValidationRules = null;
            // 
            // txtAddress
            // 
            this.txtAddress.Capslock = true;
            this.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddress.FieldLabel = null;
            this.txtAddress.Location = new System.Drawing.Point(121, 127);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtAddress.Size = new System.Drawing.Size(306, 24);
            this.txtAddress.TabIndex = 5;
            this.txtAddress.ValidationRules = null;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 118;
            this.label4.Text = "Count";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEnd
            // 
            this.txtEnd.EditMask = "###,###,###,###,###,##0.00";
            this.txtEnd.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtEnd.FieldLabel = null;
            this.txtEnd.Location = new System.Drawing.Point(121, 180);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtEnd.Properties.AllowMouseWheel = false;
            this.txtEnd.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.txtEnd.Properties.Appearance.Options.UseFont = true;
            this.txtEnd.Properties.Appearance.Options.UseTextOptions = true;
            this.txtEnd.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtEnd.Properties.Mask.BeepOnError = true;
            this.txtEnd.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtEnd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtEnd.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtEnd.ReadOnly = false;
            this.txtEnd.Size = new System.Drawing.Size(155, 24);
            this.txtEnd.TabIndex = 7;
            this.txtEnd.TextAlign = null;
            this.txtEnd.ValidationRules = null;
            this.txtEnd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 108;
            this.label1.Text = "Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStart
            // 
            this.txtStart.EditMask = "###,###,###,###,###,##0.00";
            this.txtStart.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtStart.FieldLabel = null;
            this.txtStart.Location = new System.Drawing.Point(121, 155);
            this.txtStart.Name = "txtStart";
            this.txtStart.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtStart.Properties.AllowMouseWheel = false;
            this.txtStart.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.txtStart.Properties.Appearance.Options.UseFont = true;
            this.txtStart.Properties.Appearance.Options.UseTextOptions = true;
            this.txtStart.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtStart.Properties.Mask.BeepOnError = true;
            this.txtStart.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtStart.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtStart.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtStart.ReadOnly = false;
            this.txtStart.Size = new System.Drawing.Size(155, 24);
            this.txtStart.TabIndex = 6;
            this.txtStart.TextAlign = null;
            this.txtStart.ValidationRules = null;
            this.txtStart.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 118;
            this.label2.Text = "Start";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpDetail
            // 
            this.grpDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetail.Controls.Add(this.lkpDropPoint);
            this.grpDetail.Controls.Add(this.rbDropPoint);
            this.grpDetail.Controls.Add(this.rbFranchise);
            this.grpDetail.Controls.Add(this.rbCustomer);
            this.grpDetail.Controls.Add(this.pnlBarcode);
            this.grpDetail.Controls.Add(this.lkpFranchise);
            this.grpDetail.Controls.Add(this.txtDate);
            this.grpDetail.Controls.Add(this.lkpCustomer);
            this.grpDetail.Controls.Add(this.pnlBlanko);
            this.grpDetail.Controls.Add(this.btnRecount);
            this.grpDetail.Controls.Add(this.txtUsed);
            this.grpDetail.Controls.Add(this.label9);
            this.grpDetail.Controls.Add(this.label5);
            this.grpDetail.Controls.Add(this.txtCount);
            this.grpDetail.Controls.Add(this.txtAddress);
            this.grpDetail.Controls.Add(this.label4);
            this.grpDetail.Controls.Add(this.txtEnd);
            this.grpDetail.Controls.Add(this.label1);
            this.grpDetail.Controls.Add(this.label3);
            this.grpDetail.Controls.Add(this.txtStart);
            this.grpDetail.Controls.Add(this.label2);
            this.grpDetail.ForeColor = System.Drawing.Color.Black;
            this.grpDetail.Location = new System.Drawing.Point(6, 40);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(737, 272);
            this.grpDetail.TabIndex = 1;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "Detail";
            // 
            // lkpDropPoint
            // 
            this.lkpDropPoint.AutoCompleteDataManager = null;
            this.lkpDropPoint.AutoCompleteDisplayFormater = null;
            this.lkpDropPoint.AutoCompleteInitialized = false;
            this.lkpDropPoint.AutocompleteMinimumTextLength = 0;
            this.lkpDropPoint.AutoCompleteText = null;
            this.lkpDropPoint.AutoCompleteWhereExpression = null;
            this.lkpDropPoint.AutoCompleteWheretermFormater = null;
            this.lkpDropPoint.ClearOnLeave = true;
            this.lkpDropPoint.DisplayString = null;
            this.lkpDropPoint.FieldLabel = null;
            this.lkpDropPoint.Location = new System.Drawing.Point(121, 100);
            this.lkpDropPoint.LookupPopup = null;
            this.lkpDropPoint.Name = "lkpDropPoint";
            this.lkpDropPoint.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpDropPoint.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpDropPoint.Properties.Appearance.Options.UseFont = true;
            this.lkpDropPoint.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpDropPoint.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpDropPoint.Properties.AutoCompleteDataManager = null;
            this.lkpDropPoint.Properties.AutoCompleteDisplayFormater = null;
            this.lkpDropPoint.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpDropPoint.Properties.AutoCompleteText = null;
            this.lkpDropPoint.Properties.AutoCompleteWhereExpression = null;
            this.lkpDropPoint.Properties.AutoCompleteWheretermFormater = null;
            this.lkpDropPoint.Properties.AutoHeight = false;
            this.lkpDropPoint.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpDropPoint.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpDropPoint.Properties.LookupPopup = null;
            this.lkpDropPoint.Properties.NullText = "<<Choose...>>";
            this.lkpDropPoint.Size = new System.Drawing.Size(272, 24);
            this.lkpDropPoint.TabIndex = 4;
            this.lkpDropPoint.ValidationRules = null;
            this.lkpDropPoint.Value = null;
            // 
            // rbDropPoint
            // 
            this.rbDropPoint.Location = new System.Drawing.Point(29, 102);
            this.rbDropPoint.Name = "rbDropPoint";
            this.rbDropPoint.Size = new System.Drawing.Size(85, 19);
            this.rbDropPoint.TabIndex = 140;
            this.rbDropPoint.TabStop = true;
            this.rbDropPoint.Text = "Drop Point";
            this.rbDropPoint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbDropPoint.UseVisualStyleBackColor = true;
            // 
            // rbFranchise
            // 
            this.rbFranchise.Location = new System.Drawing.Point(29, 76);
            this.rbFranchise.Name = "rbFranchise";
            this.rbFranchise.Size = new System.Drawing.Size(85, 19);
            this.rbFranchise.TabIndex = 139;
            this.rbFranchise.TabStop = true;
            this.rbFranchise.Text = "Franchise";
            this.rbFranchise.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbFranchise.UseVisualStyleBackColor = true;
            // 
            // rbCustomer
            // 
            this.rbCustomer.Location = new System.Drawing.Point(29, 50);
            this.rbCustomer.Name = "rbCustomer";
            this.rbCustomer.Size = new System.Drawing.Size(85, 19);
            this.rbCustomer.TabIndex = 138;
            this.rbCustomer.TabStop = true;
            this.rbCustomer.Text = "Customer";
            this.rbCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbCustomer.UseVisualStyleBackColor = true;
            // 
            // pnlBarcode
            // 
            this.pnlBarcode.BackColor = System.Drawing.Color.Khaki;
            this.pnlBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBarcode.Controls.Add(this.cbxPrintName);
            this.pnlBarcode.Controls.Add(this.tbxEnd);
            this.pnlBarcode.Controls.Add(this.label7);
            this.pnlBarcode.Controls.Add(this.tbxStart);
            this.pnlBarcode.Controls.Add(this.label8);
            this.pnlBarcode.Controls.Add(this.btnPrintBarcode);
            this.pnlBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBarcode.Location = new System.Drawing.Point(443, 48);
            this.pnlBarcode.Name = "pnlBarcode";
            this.pnlBarcode.Size = new System.Drawing.Size(255, 138);
            this.pnlBarcode.TabIndex = 137;
            // 
            // cbxPrintName
            // 
            this.cbxPrintName.AutoSize = true;
            this.cbxPrintName.FieldLabel = null;
            this.cbxPrintName.Location = new System.Drawing.Point(82, 70);
            this.cbxPrintName.Name = "cbxPrintName";
            this.cbxPrintName.Size = new System.Drawing.Size(85, 17);
            this.cbxPrintName.TabIndex = 121;
            this.cbxPrintName.Text = "Cetak Nama";
            this.cbxPrintName.UseVisualStyleBackColor = true;
            this.cbxPrintName.ValidationRules = null;
            // 
            // tbxEnd
            // 
            this.tbxEnd.EditMask = "###,###,###,###,###,##0.00";
            this.tbxEnd.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxEnd.FieldLabel = null;
            this.tbxEnd.Location = new System.Drawing.Point(82, 37);
            this.tbxEnd.Name = "tbxEnd";
            this.tbxEnd.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxEnd.Properties.AllowMouseWheel = false;
            this.tbxEnd.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxEnd.Properties.Appearance.Options.UseFont = true;
            this.tbxEnd.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxEnd.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxEnd.Properties.Mask.BeepOnError = true;
            this.tbxEnd.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxEnd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxEnd.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxEnd.ReadOnly = false;
            this.tbxEnd.Size = new System.Drawing.Size(155, 24);
            this.tbxEnd.TabIndex = 120;
            this.tbxEnd.TextAlign = null;
            this.tbxEnd.ValidationRules = null;
            this.tbxEnd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 17);
            this.label7.TabIndex = 121;
            this.label7.Text = "End";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxStart
            // 
            this.tbxStart.EditMask = "###,###,###,###,###,##0.00";
            this.tbxStart.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxStart.FieldLabel = null;
            this.tbxStart.Location = new System.Drawing.Point(82, 11);
            this.tbxStart.Name = "tbxStart";
            this.tbxStart.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxStart.Properties.AllowMouseWheel = false;
            this.tbxStart.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxStart.Properties.Appearance.Options.UseFont = true;
            this.tbxStart.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxStart.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxStart.Properties.Mask.BeepOnError = true;
            this.tbxStart.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxStart.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxStart.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxStart.ReadOnly = false;
            this.tbxStart.Size = new System.Drawing.Size(155, 24);
            this.tbxStart.TabIndex = 119;
            this.tbxStart.TextAlign = null;
            this.tbxStart.ValidationRules = null;
            this.tbxStart.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 122;
            this.label8.Text = "Start";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrintBarcode
            // 
            this.btnPrintBarcode.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintBarcode.Image = global::SISCO.Presentation.Administration.Properties.Resources.icon_print_small;
            this.btnPrintBarcode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintBarcode.Location = new System.Drawing.Point(82, 96);
            this.btnPrintBarcode.Name = "btnPrintBarcode";
            this.btnPrintBarcode.Size = new System.Drawing.Size(113, 30);
            this.btnPrintBarcode.TabIndex = 122;
            this.btnPrintBarcode.Text = "Print Barcode";
            this.btnPrintBarcode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintBarcode.UseVisualStyleBackColor = true;
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
            this.lkpFranchise.Location = new System.Drawing.Point(121, 74);
            this.lkpFranchise.LookupPopup = null;
            this.lkpFranchise.Name = "lkpFranchise";
            this.lkpFranchise.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpFranchise.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpFranchise.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpFranchise.Properties.LookupPopup = null;
            this.lkpFranchise.Properties.NullText = "<<Choose...>>";
            this.lkpFranchise.Size = new System.Drawing.Size(272, 24);
            this.lkpFranchise.TabIndex = 3;
            this.lkpFranchise.ValidationRules = null;
            this.lkpFranchise.Value = null;
            // 
            // txtDate
            // 
            this.txtDate.EditValue = null;
            this.txtDate.FieldLabel = null;
            this.txtDate.FormatDateTime = "dd-MM-yyyy";
            this.txtDate.Location = new System.Drawing.Point(121, 18);
            this.txtDate.Name = "txtDate";
            this.txtDate.Nullable = false;
            this.txtDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDate.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.txtDate.Properties.Appearance.Options.UseFont = true;
            this.txtDate.Properties.AutoHeight = false;
            this.txtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.txtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDate.Size = new System.Drawing.Size(166, 24);
            this.txtDate.TabIndex = 1;
            this.txtDate.ValidationRules = null;
            this.txtDate.Value = new System.DateTime(((long)(0)));
            // 
            // lkpCustomer
            // 
            this.lkpCustomer.AutoCompleteDataManager = null;
            this.lkpCustomer.AutoCompleteDisplayFormater = null;
            this.lkpCustomer.AutoCompleteInitialized = false;
            this.lkpCustomer.AutocompleteMinimumTextLength = 0;
            this.lkpCustomer.AutoCompleteText = null;
            this.lkpCustomer.AutoCompleteWhereExpression = null;
            this.lkpCustomer.AutoCompleteWheretermFormater = null;
            this.lkpCustomer.ClearOnLeave = true;
            this.lkpCustomer.DisplayString = null;
            this.lkpCustomer.FieldLabel = null;
            this.lkpCustomer.Location = new System.Drawing.Point(121, 48);
            this.lkpCustomer.LookupPopup = null;
            this.lkpCustomer.Name = "lkpCustomer";
            this.lkpCustomer.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpCustomer.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpCustomer.Properties.Appearance.Options.UseFont = true;
            this.lkpCustomer.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpCustomer.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpCustomer.Properties.AutoCompleteDataManager = null;
            this.lkpCustomer.Properties.AutoCompleteDisplayFormater = null;
            this.lkpCustomer.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpCustomer.Properties.AutoCompleteText = null;
            this.lkpCustomer.Properties.AutoCompleteWhereExpression = null;
            this.lkpCustomer.Properties.AutoCompleteWheretermFormater = null;
            this.lkpCustomer.Properties.AutoHeight = false;
            this.lkpCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpCustomer.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.lkpCustomer.Properties.LookupPopup = null;
            this.lkpCustomer.Properties.NullText = "<<Choose...>>";
            this.lkpCustomer.Size = new System.Drawing.Size(272, 24);
            this.lkpCustomer.TabIndex = 2;
            this.lkpCustomer.ValidationRules = null;
            this.lkpCustomer.Value = null;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 118;
            this.label3.Text = "End";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ManageShipmentNumberAllocationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(749, 318);
            this.Controls.Add(this.grpDetail);
            this.Name = "ManageShipmentNumberAllocationForm";
            this.Text = "Alokasi CN";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.grpDetail, 0);
            this.pnlBlanko.ResumeLayout(false);
            this.pnlBlanko.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStart.Properties)).EndInit();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDropPoint.Properties)).EndInit();
            this.pnlBarcode.ResumeLayout(false);
            this.pnlBarcode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFranchise.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBlanko;
        private System.Windows.Forms.Button btnPrintPOD;
        private System.Windows.Forms.CheckBox chkPrintContinuos;
        private System.Windows.Forms.Button btnRecount;
        private SISCO.Presentation.Common.Component.dTextBox txtUsed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private SISCO.Presentation.Common.Component.dTextBox txtCount;
        private SISCO.Presentation.Common.Component.dTextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private SISCO.Presentation.Common.Component.dTextBoxNumber txtEnd;
        private System.Windows.Forms.Label label1;
        private SISCO.Presentation.Common.Component.dTextBoxNumber txtStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Label label3;
        private Common.Component.dCalendar txtDate;
        private Common.Component.dLookup lkpCustomer;
        private Common.Component.dLookup lkpFranchise;
        private System.Windows.Forms.Panel pnlBarcode;
        private Common.Component.dTextBoxNumber tbxEnd;
        private System.Windows.Forms.Label label7;
        private Common.Component.dTextBoxNumber tbxStart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPrintBarcode;
        private Common.Component.dCheckBox cbxPrintName;
        private Common.Component.dLookup lkpDropPoint;
        private System.Windows.Forms.RadioButton rbDropPoint;
        private System.Windows.Forms.RadioButton rbFranchise;
        private System.Windows.Forms.RadioButton rbCustomer;
        
    }
}

