namespace SISCO.Presentation.Finance.Forms
{
    partial class TitipInvoiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TitipInvoiceForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxDesc1 = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.tbxPaymentIn = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbxDesc2 = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.tbxPaymentOut = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.tbxNumber = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.tbxCustomer = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.tbxDueDate = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.tbxDescription = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.tbxGrandTotal = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.ucLunas = new SISCO.Presentation.Common.UserControls.ucIconYesNo();
            this.tbxBranch = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.ucCancel = new SISCO.Presentation.Common.UserControls.ucIconYesNo();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPaymentIn.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPaymentOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDueDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDueDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxGrandTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxBranch.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(49, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(49, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(49, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Customer";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(49, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Due Date";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(49, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Dest Branch";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(49, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Description";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(49, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Grand Total";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbxDesc1);
            this.panel1.Controls.Add(this.tbxPaymentIn);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(509, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 91);
            this.panel1.TabIndex = 9;
            // 
            // tbxDesc1
            // 
            this.tbxDesc1.Capslock = true;
            this.tbxDesc1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDesc1.Enabled = false;
            this.tbxDesc1.FieldLabel = null;
            this.tbxDesc1.Location = new System.Drawing.Point(10, 59);
            this.tbxDesc1.Name = "tbxDesc1";
            this.tbxDesc1.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDesc1.Size = new System.Drawing.Size(172, 24);
            this.tbxDesc1.TabIndex = 10;
            this.tbxDesc1.ValidationRules = null;
            // 
            // tbxPaymentIn
            // 
            this.tbxPaymentIn.EditMask = "###,###,###,###,###,##0.00";
            this.tbxPaymentIn.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxPaymentIn.FieldLabel = null;
            this.tbxPaymentIn.Location = new System.Drawing.Point(10, 33);
            this.tbxPaymentIn.Name = "tbxPaymentIn";
            this.tbxPaymentIn.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPaymentIn.Properties.AllowMouseWheel = false;
            this.tbxPaymentIn.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxPaymentIn.Properties.Appearance.Options.UseFont = true;
            this.tbxPaymentIn.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxPaymentIn.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxPaymentIn.Properties.Mask.BeepOnError = true;
            this.tbxPaymentIn.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxPaymentIn.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxPaymentIn.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxPaymentIn.Properties.ReadOnly = true;
            this.tbxPaymentIn.ReadOnly = true;
            this.tbxPaymentIn.Size = new System.Drawing.Size(172, 24);
            this.tbxPaymentIn.TabIndex = 9;
            this.tbxPaymentIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxPaymentIn.ValidationRules = null;
            this.tbxPaymentIn.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Meiryo", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(7, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Payment In";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tbxDesc2);
            this.panel2.Controls.Add(this.tbxPaymentOut);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(509, 135);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 93);
            this.panel2.TabIndex = 10;
            // 
            // tbxDesc2
            // 
            this.tbxDesc2.Capslock = true;
            this.tbxDesc2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDesc2.Enabled = false;
            this.tbxDesc2.FieldLabel = null;
            this.tbxDesc2.Location = new System.Drawing.Point(10, 60);
            this.tbxDesc2.Name = "tbxDesc2";
            this.tbxDesc2.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDesc2.Size = new System.Drawing.Size(172, 24);
            this.tbxDesc2.TabIndex = 11;
            this.tbxDesc2.ValidationRules = null;
            // 
            // tbxPaymentOut
            // 
            this.tbxPaymentOut.EditMask = "###,###,###,###,###,##0.00";
            this.tbxPaymentOut.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxPaymentOut.FieldLabel = null;
            this.tbxPaymentOut.Location = new System.Drawing.Point(10, 34);
            this.tbxPaymentOut.Name = "tbxPaymentOut";
            this.tbxPaymentOut.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPaymentOut.Properties.AllowMouseWheel = false;
            this.tbxPaymentOut.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxPaymentOut.Properties.Appearance.Options.UseFont = true;
            this.tbxPaymentOut.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxPaymentOut.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxPaymentOut.Properties.Mask.BeepOnError = true;
            this.tbxPaymentOut.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxPaymentOut.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxPaymentOut.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxPaymentOut.Properties.ReadOnly = true;
            this.tbxPaymentOut.ReadOnly = true;
            this.tbxPaymentOut.Size = new System.Drawing.Size(172, 24);
            this.tbxPaymentOut.TabIndex = 10;
            this.tbxPaymentOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxPaymentOut.ValidationRules = null;
            this.tbxPaymentOut.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Meiryo", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(7, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 18);
            this.label9.TabIndex = 0;
            this.label9.Text = "Payment Out";
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(130, 52);
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
            this.tbxDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxDate.Size = new System.Drawing.Size(137, 24);
            this.tbxDate.TabIndex = 1;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // tbxNumber
            // 
            this.tbxNumber.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxNumber.Capslock = true;
            this.tbxNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxNumber.FieldLabel = null;
            this.tbxNumber.Location = new System.Drawing.Point(130, 78);
            this.tbxNumber.Name = "tbxNumber";
            this.tbxNumber.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxNumber.Size = new System.Drawing.Size(290, 24);
            this.tbxNumber.TabIndex = 2;
            this.tbxNumber.ValidationRules = null;
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
            this.tbxCustomer.Location = new System.Drawing.Point(130, 156);
            this.tbxCustomer.LookupPopup = null;
            this.tbxCustomer.Name = "tbxCustomer";
            this.tbxCustomer.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxCustomer.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.tbxCustomer.Properties.Appearance.Options.UseBackColor = true;
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
            this.tbxCustomer.Size = new System.Drawing.Size(202, 24);
            this.tbxCustomer.TabIndex = 6;
            this.tbxCustomer.ValidationRules = null;
            this.tbxCustomer.Value = null;
            // 
            // tbxDueDate
            // 
            this.tbxDueDate.EditValue = null;
            this.tbxDueDate.FieldLabel = null;
            this.tbxDueDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDueDate.Location = new System.Drawing.Point(130, 104);
            this.tbxDueDate.Name = "tbxDueDate";
            this.tbxDueDate.Nullable = false;
            this.tbxDueDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDueDate.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxDueDate.Properties.Appearance.Options.UseBackColor = true;
            this.tbxDueDate.Properties.AutoHeight = false;
            this.tbxDueDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxDueDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.tbxDueDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxDueDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxDueDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxDueDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxDueDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxDueDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxDueDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxDueDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxDueDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxDueDate.Size = new System.Drawing.Size(137, 24);
            this.tbxDueDate.TabIndex = 4;
            this.tbxDueDate.ValidationRules = null;
            this.tbxDueDate.Value = new System.DateTime(((long)(0)));
            // 
            // tbxDescription
            // 
            this.tbxDescription.Capslock = true;
            this.tbxDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDescription.FieldLabel = null;
            this.tbxDescription.Location = new System.Drawing.Point(130, 182);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDescription.Size = new System.Drawing.Size(322, 24);
            this.tbxDescription.TabIndex = 7;
            this.tbxDescription.ValidationRules = null;
            // 
            // tbxGrandTotal
            // 
            this.tbxGrandTotal.EditMask = "###,###,###,###,###,##0.00";
            this.tbxGrandTotal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxGrandTotal.FieldLabel = null;
            this.tbxGrandTotal.Location = new System.Drawing.Point(130, 218);
            this.tbxGrandTotal.Name = "tbxGrandTotal";
            this.tbxGrandTotal.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxGrandTotal.Properties.AllowMouseWheel = false;
            this.tbxGrandTotal.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxGrandTotal.Properties.Appearance.Options.UseFont = true;
            this.tbxGrandTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxGrandTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxGrandTotal.Properties.Mask.BeepOnError = true;
            this.tbxGrandTotal.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxGrandTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxGrandTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxGrandTotal.Properties.ReadOnly = true;
            this.tbxGrandTotal.ReadOnly = true;
            this.tbxGrandTotal.Size = new System.Drawing.Size(170, 24);
            this.tbxGrandTotal.TabIndex = 8;
            this.tbxGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxGrandTotal.ValidationRules = null;
            this.tbxGrandTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ucLunas
            // 
            this.ucLunas.AutoSize = true;
            this.ucLunas.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucLunas.ForeColor = System.Drawing.Color.Black;
            this.ucLunas.Icon = false;
            this.ucLunas.Label = "Text";
            this.ucLunas.Location = new System.Drawing.Point(321, 210);
            this.ucLunas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucLunas.Name = "ucLunas";
            this.ucLunas.Size = new System.Drawing.Size(80, 17);
            this.ucLunas.TabIndex = 0;
            // 
            // tbxBranch
            // 
            this.tbxBranch.AutoCompleteDataManager = null;
            this.tbxBranch.AutoCompleteDisplayFormater = null;
            this.tbxBranch.AutoCompleteInitialized = false;
            this.tbxBranch.AutocompleteMinimumTextLength = 0;
            this.tbxBranch.AutoCompleteText = null;
            this.tbxBranch.AutoCompleteWhereExpression = null;
            this.tbxBranch.AutoCompleteWheretermFormater = null;
            this.tbxBranch.ClearOnLeave = true;
            this.tbxBranch.DisplayString = null;
            this.tbxBranch.FieldLabel = null;
            this.tbxBranch.Location = new System.Drawing.Point(130, 130);
            this.tbxBranch.LookupPopup = null;
            this.tbxBranch.Name = "tbxBranch";
            this.tbxBranch.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxBranch.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxBranch.Properties.Appearance.Options.UseBackColor = true;
            this.tbxBranch.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxBranch.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxBranch.Properties.AutoCompleteDataManager = null;
            this.tbxBranch.Properties.AutoCompleteDisplayFormater = null;
            this.tbxBranch.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxBranch.Properties.AutoCompleteText = null;
            this.tbxBranch.Properties.AutoCompleteWhereExpression = null;
            this.tbxBranch.Properties.AutoCompleteWheretermFormater = null;
            this.tbxBranch.Properties.AutoHeight = false;
            this.tbxBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.tbxBranch.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxBranch.Properties.LookupPopup = null;
            this.tbxBranch.Properties.NullText = "<<Choose...>>";
            this.tbxBranch.Size = new System.Drawing.Size(202, 24);
            this.tbxBranch.TabIndex = 5;
            this.tbxBranch.ValidationRules = null;
            this.tbxBranch.Value = null;
            // 
            // ucCancel
            // 
            this.ucCancel.AutoSize = true;
            this.ucCancel.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucCancel.ForeColor = System.Drawing.Color.Black;
            this.ucCancel.Icon = false;
            this.ucCancel.Label = "Text";
            this.ucCancel.Location = new System.Drawing.Point(321, 235);
            this.ucCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucCancel.Name = "ucCancel";
            this.ucCancel.Size = new System.Drawing.Size(80, 17);
            this.ucCancel.TabIndex = 11;
            // 
            // TitipInvoiceForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(742, 257);
            this.Controls.Add(this.ucCancel);
            this.Controls.Add(this.tbxBranch);
            this.Controls.Add(this.ucLunas);
            this.Controls.Add(this.tbxGrandTotal);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.tbxDueDate);
            this.Controls.Add(this.tbxCustomer);
            this.Controls.Add(this.tbxNumber);
            this.Controls.Add(this.tbxDate);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TitipInvoiceForm";
            this.Text = "Finance - Titip Invoice";
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
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.tbxDate, 0);
            this.Controls.SetChildIndex(this.tbxNumber, 0);
            this.Controls.SetChildIndex(this.tbxCustomer, 0);
            this.Controls.SetChildIndex(this.tbxDueDate, 0);
            this.Controls.SetChildIndex(this.tbxDescription, 0);
            this.Controls.SetChildIndex(this.tbxGrandTotal, 0);
            this.Controls.SetChildIndex(this.ucLunas, 0);
            this.Controls.SetChildIndex(this.tbxBranch, 0);
            this.Controls.SetChildIndex(this.ucCancel, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPaymentIn.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPaymentOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDueDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDueDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxGrandTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxBranch.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private Common.Component.dTextBoxNumber tbxPaymentIn;
        private Common.Component.dTextBoxNumber tbxPaymentOut;
        private Common.Component.dCalendar tbxDate;
        private Common.Component.dTextBox tbxNumber;
        private Common.Component.dLookup tbxCustomer;
        private Common.Component.dCalendar tbxDueDate;
        private Common.Component.dTextBox tbxDescription;
        private Common.Component.dTextBoxNumber tbxGrandTotal;
        private Common.UserControls.ucIconYesNo ucLunas;
        private Common.Component.dLookup tbxBranch;
        private Common.Component.dTextBox tbxDesc1;
        private Common.Component.dTextBox tbxDesc2;
        private Common.UserControls.ucIconYesNo ucCancel;
    }
}