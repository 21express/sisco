namespace SISCO.Presentation.MasterData.Forms
{
    partial class ManagePromoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagePromoForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxActive = new SISCO.Presentation.Common.Component.dCheckBox(this.components);
            this.tbxDescription = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tbxExpired = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lkpService = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.lkpPackage = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.lkpDestination = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.lkpOrigin = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbxDiscount = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.tbxTariff = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.tbxMinWeight = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxExpired.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxExpired.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpService.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPackage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestination.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpOrigin.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDiscount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTariff.Properties)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxMinWeight.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbxActive);
            this.panel1.Controls.Add(this.tbxDescription);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbxExpired);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 89);
            this.panel1.TabIndex = 1;
            // 
            // cbxActive
            // 
            this.cbxActive.AutoSize = true;
            this.cbxActive.FieldLabel = null;
            this.cbxActive.Location = new System.Drawing.Point(115, 63);
            this.cbxActive.Name = "cbxActive";
            this.cbxActive.Size = new System.Drawing.Size(65, 21);
            this.cbxActive.TabIndex = 4;
            this.cbxActive.Text = "Active?";
            this.cbxActive.UseVisualStyleBackColor = true;
            this.cbxActive.ValidationRules = null;
            // 
            // tbxDescription
            // 
            this.tbxDescription.Capslock = true;
            this.tbxDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDescription.FieldLabel = null;
            this.tbxDescription.Location = new System.Drawing.Point(115, 34);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDescription.Size = new System.Drawing.Size(513, 24);
            this.tbxDescription.TabIndex = 2;
            this.tbxDescription.ValidationRules = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description";
            // 
            // tbxExpired
            // 
            this.tbxExpired.EditValue = null;
            this.tbxExpired.FieldLabel = null;
            this.tbxExpired.FormatDateTime = "dd-MM-yyyy";
            this.tbxExpired.Location = new System.Drawing.Point(115, 10);
            this.tbxExpired.Name = "tbxExpired";
            this.tbxExpired.Nullable = false;
            this.tbxExpired.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxExpired.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxExpired.Properties.Appearance.Options.UseFont = true;
            this.tbxExpired.Properties.AutoHeight = false;
            this.tbxExpired.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxExpired.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.tbxExpired.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxExpired.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxExpired.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxExpired.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxExpired.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxExpired.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxExpired.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxExpired.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxExpired.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxExpired.Size = new System.Drawing.Size(124, 22);
            this.tbxExpired.TabIndex = 1;
            this.tbxExpired.ValidationRules = null;
            this.tbxExpired.Value = new System.DateTime(((long)(0)));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Expired Date";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lkpService);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lkpPackage);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.lkpDestination);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lkpOrigin);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(4, 134);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(365, 170);
            this.panel2.TabIndex = 2;
            // 
            // lkpService
            // 
            this.lkpService.AutoCompleteDataManager = null;
            this.lkpService.AutoCompleteDisplayFormater = null;
            this.lkpService.AutoCompleteInitialized = false;
            this.lkpService.AutocompleteMinimumTextLength = 0;
            this.lkpService.AutoCompleteText = null;
            this.lkpService.AutoCompleteWhereExpression = null;
            this.lkpService.AutoCompleteWheretermFormater = null;
            this.lkpService.ClearOnLeave = true;
            this.lkpService.DisplayString = null;
            this.lkpService.FieldLabel = null;
            this.lkpService.Location = new System.Drawing.Point(115, 119);
            this.lkpService.LookupPopup = null;
            this.lkpService.Name = "lkpService";
            this.lkpService.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpService.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpService.Properties.Appearance.Options.UseFont = true;
            this.lkpService.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpService.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpService.Properties.AutoCompleteDataManager = null;
            this.lkpService.Properties.AutoCompleteDisplayFormater = null;
            this.lkpService.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpService.Properties.AutoCompleteText = null;
            this.lkpService.Properties.AutoCompleteWhereExpression = null;
            this.lkpService.Properties.AutoCompleteWheretermFormater = null;
            this.lkpService.Properties.AutoHeight = false;
            this.lkpService.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpService.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpService.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpService.Properties.LookupPopup = null;
            this.lkpService.Properties.NullText = "<<Choose...>>";
            this.lkpService.Size = new System.Drawing.Size(225, 24);
            this.lkpService.TabIndex = 6;
            this.lkpService.ValidationRules = null;
            this.lkpService.Value = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Service Type";
            // 
            // lkpPackage
            // 
            this.lkpPackage.AutoCompleteDataManager = null;
            this.lkpPackage.AutoCompleteDisplayFormater = null;
            this.lkpPackage.AutoCompleteInitialized = false;
            this.lkpPackage.AutocompleteMinimumTextLength = 0;
            this.lkpPackage.AutoCompleteText = null;
            this.lkpPackage.AutoCompleteWhereExpression = null;
            this.lkpPackage.AutoCompleteWheretermFormater = null;
            this.lkpPackage.ClearOnLeave = true;
            this.lkpPackage.DisplayString = null;
            this.lkpPackage.FieldLabel = null;
            this.lkpPackage.Location = new System.Drawing.Point(115, 93);
            this.lkpPackage.LookupPopup = null;
            this.lkpPackage.Name = "lkpPackage";
            this.lkpPackage.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpPackage.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpPackage.Properties.Appearance.Options.UseFont = true;
            this.lkpPackage.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpPackage.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpPackage.Properties.AutoCompleteDataManager = null;
            this.lkpPackage.Properties.AutoCompleteDisplayFormater = null;
            this.lkpPackage.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpPackage.Properties.AutoCompleteText = null;
            this.lkpPackage.Properties.AutoCompleteWhereExpression = null;
            this.lkpPackage.Properties.AutoCompleteWheretermFormater = null;
            this.lkpPackage.Properties.AutoHeight = false;
            this.lkpPackage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpPackage.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.lkpPackage.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpPackage.Properties.LookupPopup = null;
            this.lkpPackage.Properties.NullText = "<<Choose...>>";
            this.lkpPackage.Size = new System.Drawing.Size(225, 24);
            this.lkpPackage.TabIndex = 5;
            this.lkpPackage.ValidationRules = null;
            this.lkpPackage.Value = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Package Type";
            // 
            // lkpDestination
            // 
            this.lkpDestination.AutoCompleteDataManager = null;
            this.lkpDestination.AutoCompleteDisplayFormater = null;
            this.lkpDestination.AutoCompleteInitialized = false;
            this.lkpDestination.AutocompleteMinimumTextLength = 0;
            this.lkpDestination.AutoCompleteText = null;
            this.lkpDestination.AutoCompleteWhereExpression = null;
            this.lkpDestination.AutoCompleteWheretermFormater = null;
            this.lkpDestination.ClearOnLeave = true;
            this.lkpDestination.DisplayString = null;
            this.lkpDestination.FieldLabel = null;
            this.lkpDestination.Location = new System.Drawing.Point(115, 63);
            this.lkpDestination.LookupPopup = null;
            this.lkpDestination.Name = "lkpDestination";
            this.lkpDestination.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpDestination.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpDestination.Properties.Appearance.Options.UseFont = true;
            this.lkpDestination.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpDestination.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpDestination.Properties.AutoCompleteDataManager = null;
            this.lkpDestination.Properties.AutoCompleteDisplayFormater = null;
            this.lkpDestination.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpDestination.Properties.AutoCompleteText = null;
            this.lkpDestination.Properties.AutoCompleteWhereExpression = null;
            this.lkpDestination.Properties.AutoCompleteWheretermFormater = null;
            this.lkpDestination.Properties.AutoHeight = false;
            this.lkpDestination.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpDestination.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.lkpDestination.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpDestination.Properties.LookupPopup = null;
            this.lkpDestination.Properties.NullText = "<<Choose...>>";
            this.lkpDestination.Size = new System.Drawing.Size(225, 24);
            this.lkpDestination.TabIndex = 4;
            this.lkpDestination.ValidationRules = null;
            this.lkpDestination.Value = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Destination";
            // 
            // lkpOrigin
            // 
            this.lkpOrigin.AutoCompleteDataManager = null;
            this.lkpOrigin.AutoCompleteDisplayFormater = null;
            this.lkpOrigin.AutoCompleteInitialized = false;
            this.lkpOrigin.AutocompleteMinimumTextLength = 0;
            this.lkpOrigin.AutoCompleteText = null;
            this.lkpOrigin.AutoCompleteWhereExpression = null;
            this.lkpOrigin.AutoCompleteWheretermFormater = null;
            this.lkpOrigin.ClearOnLeave = true;
            this.lkpOrigin.DisplayString = null;
            this.lkpOrigin.FieldLabel = null;
            this.lkpOrigin.Location = new System.Drawing.Point(115, 37);
            this.lkpOrigin.LookupPopup = null;
            this.lkpOrigin.Name = "lkpOrigin";
            this.lkpOrigin.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpOrigin.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpOrigin.Properties.Appearance.Options.UseFont = true;
            this.lkpOrigin.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpOrigin.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpOrigin.Properties.AutoCompleteDataManager = null;
            this.lkpOrigin.Properties.AutoCompleteDisplayFormater = null;
            this.lkpOrigin.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpOrigin.Properties.AutoCompleteText = null;
            this.lkpOrigin.Properties.AutoCompleteWhereExpression = null;
            this.lkpOrigin.Properties.AutoCompleteWheretermFormater = null;
            this.lkpOrigin.Properties.AutoHeight = false;
            this.lkpOrigin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpOrigin.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.lkpOrigin.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpOrigin.Properties.LookupPopup = null;
            this.lkpOrigin.Properties.NullText = "<<Choose...>>";
            this.lkpOrigin.Size = new System.Drawing.Size(225, 24);
            this.lkpOrigin.TabIndex = 3;
            this.lkpOrigin.ValidationRules = null;
            this.lkpOrigin.Value = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Origin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Meiryo", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Promo Parameter";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tbxDiscount);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.tbxTariff);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(375, 204);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(323, 100);
            this.panel3.TabIndex = 3;
            // 
            // tbxDiscount
            // 
            this.tbxDiscount.EditMask = "###,###,###,###,###,##0.00";
            this.tbxDiscount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxDiscount.FieldLabel = null;
            this.tbxDiscount.Location = new System.Drawing.Point(120, 62);
            this.tbxDiscount.Name = "tbxDiscount";
            this.tbxDiscount.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDiscount.Properties.AllowMouseWheel = false;
            this.tbxDiscount.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxDiscount.Properties.Appearance.Options.UseFont = true;
            this.tbxDiscount.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxDiscount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxDiscount.Properties.Mask.BeepOnError = true;
            this.tbxDiscount.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxDiscount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxDiscount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxDiscount.ReadOnly = false;
            this.tbxDiscount.Size = new System.Drawing.Size(166, 24);
            this.tbxDiscount.TabIndex = 9;
            this.tbxDiscount.TextAlign = null;
            this.tbxDiscount.ValidationRules = null;
            this.tbxDiscount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(34, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 17);
            this.label11.TabIndex = 15;
            this.label11.Text = "Discount (%)";
            // 
            // tbxTariff
            // 
            this.tbxTariff.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTariff.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTariff.FieldLabel = null;
            this.tbxTariff.Location = new System.Drawing.Point(120, 36);
            this.tbxTariff.Name = "tbxTariff";
            this.tbxTariff.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTariff.Properties.AllowMouseWheel = false;
            this.tbxTariff.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTariff.Properties.Appearance.Options.UseFont = true;
            this.tbxTariff.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTariff.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTariff.Properties.Mask.BeepOnError = true;
            this.tbxTariff.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTariff.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxTariff.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTariff.ReadOnly = false;
            this.tbxTariff.Size = new System.Drawing.Size(166, 24);
            this.tbxTariff.TabIndex = 8;
            this.tbxTariff.TextAlign = null;
            this.tbxTariff.ValidationRules = null;
            this.tbxTariff.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(79, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 17);
            this.label9.TabIndex = 5;
            this.label9.Text = "Tariff";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Meiryo", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 18);
            this.label8.TabIndex = 4;
            this.label8.Text = "Promo";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.tbxMinWeight);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Location = new System.Drawing.Point(375, 134);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(323, 65);
            this.panel4.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Meiryo", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(16, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(151, 18);
            this.label12.TabIndex = 5;
            this.label12.Text = "Additional Conditional";
            // 
            // tbxMinWeight
            // 
            this.tbxMinWeight.EditMask = "###,###,###,###,###,##0.00";
            this.tbxMinWeight.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxMinWeight.FieldLabel = null;
            this.tbxMinWeight.Location = new System.Drawing.Point(120, 33);
            this.tbxMinWeight.Name = "tbxMinWeight";
            this.tbxMinWeight.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxMinWeight.Properties.AllowMouseWheel = false;
            this.tbxMinWeight.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxMinWeight.Properties.Appearance.Options.UseFont = true;
            this.tbxMinWeight.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxMinWeight.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxMinWeight.Properties.Mask.BeepOnError = true;
            this.tbxMinWeight.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxMinWeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxMinWeight.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxMinWeight.ReadOnly = false;
            this.tbxMinWeight.Size = new System.Drawing.Size(122, 24);
            this.tbxMinWeight.TabIndex = 13;
            this.tbxMinWeight.TextAlign = null;
            this.tbxMinWeight.ValidationRules = null;
            this.tbxMinWeight.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(42, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 17);
            this.label10.TabIndex = 14;
            this.label10.Text = "Min. Weight";
            // 
            // ManagePromoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 308);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ManagePromoForm";
            this.Text = "Promo";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxExpired.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxExpired.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpService.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPackage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestination.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpOrigin.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDiscount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTariff.Properties)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxMinWeight.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Common.Component.dTextBox tbxDescription;
        private System.Windows.Forms.Label label2;
        private Common.Component.dCalendar tbxExpired;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private Common.Component.dLookup lkpService;
        private System.Windows.Forms.Label label6;
        private Common.Component.dLookup lkpPackage;
        private System.Windows.Forms.Label label7;
        private Common.Component.dLookup lkpDestination;
        private System.Windows.Forms.Label label5;
        private Common.Component.dLookup lkpOrigin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Common.Component.dTextBoxNumber tbxDiscount;
        private System.Windows.Forms.Label label11;
        private Common.Component.dTextBoxNumber tbxTariff;
        private Common.Component.dCheckBox cbxActive;
        private System.Windows.Forms.Panel panel4;
        private Common.Component.dTextBoxNumber tbxMinWeight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;

    }
}