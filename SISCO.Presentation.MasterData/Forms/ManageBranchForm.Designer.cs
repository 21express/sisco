using SISCO.Presentation.Common.Component;

namespace SISCO.Presentation.MasterData.Forms
{
    partial class ManageBranchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageBranchForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.txtShipmentPrefix2 = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtRaFee = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.txtShipmentPrefix1 = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtMaxDiscount = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.txtBankAccountNumber = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtBankAccountName = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtName = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtPodHeader = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtInvoiceFooter2 = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtInvoiceHeader3 = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtInvoiceFooter1 = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtInvoiceHeader2 = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtInvoiceHeader1 = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtAddress = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtContactPhone = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtContactEmail = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtShipmentNoPrefix = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtContactPerson = new SISCO.Presentation.Common.Component.dTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBankName = new SISCO.Presentation.Common.Component.dTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCode = new SISCO.Presentation.Common.Component.dTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhone = new SISCO.Presentation.Common.Component.dTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lkpCity = new SISCO.Presentation.Common.Component.dLookup();
            this.cmbBranchType = new SISCO.Presentation.Common.Component.dComboBox();
            this.txtShipmentPrefixOnlineCode1 = new SISCO.Presentation.Common.Component.dTextBox();
            this.label26 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtRaFee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxDiscount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCity.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtShipmentPrefix2
            // 
            this.txtShipmentPrefix2.Capslock = true;
            this.txtShipmentPrefix2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipmentPrefix2.FieldLabel = null;
            this.txtShipmentPrefix2.Location = new System.Drawing.Point(523, 486);
            this.txtShipmentPrefix2.Name = "txtShipmentPrefix2";
            this.txtShipmentPrefix2.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtShipmentPrefix2.Size = new System.Drawing.Size(92, 20);
            this.txtShipmentPrefix2.TabIndex = 123;
            this.txtShipmentPrefix2.ValidationRules = null;
            // 
            // txtRaFee
            // 
            this.txtRaFee.EditMask = "###,###,###,###,###,##0.00";
            this.txtRaFee.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtRaFee.FieldLabel = null;
            this.txtRaFee.Location = new System.Drawing.Point(523, 200);
            this.txtRaFee.Name = "txtRaFee";
            this.txtRaFee.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtRaFee.Properties.AllowMouseWheel = false;
            this.txtRaFee.Properties.Appearance.Options.UseTextOptions = true;
            this.txtRaFee.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtRaFee.Properties.Mask.BeepOnError = true;
            this.txtRaFee.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtRaFee.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtRaFee.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtRaFee.ReadOnly = false;
            this.txtRaFee.Size = new System.Drawing.Size(92, 20);
            this.txtRaFee.TabIndex = 110;
            this.txtRaFee.TextAlign = null;
            this.txtRaFee.ValidationRules = null;
            this.txtRaFee.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtShipmentPrefix1
            // 
            this.txtShipmentPrefix1.Capslock = true;
            this.txtShipmentPrefix1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipmentPrefix1.FieldLabel = null;
            this.txtShipmentPrefix1.Location = new System.Drawing.Point(523, 463);
            this.txtShipmentPrefix1.Name = "txtShipmentPrefix1";
            this.txtShipmentPrefix1.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtShipmentPrefix1.Size = new System.Drawing.Size(92, 20);
            this.txtShipmentPrefix1.TabIndex = 122;
            this.txtShipmentPrefix1.ValidationRules = null;
            // 
            // txtMaxDiscount
            // 
            this.txtMaxDiscount.EditMask = "###,###,###,###,###,##0.00";
            this.txtMaxDiscount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMaxDiscount.FieldLabel = null;
            this.txtMaxDiscount.Location = new System.Drawing.Point(523, 178);
            this.txtMaxDiscount.Name = "txtMaxDiscount";
            this.txtMaxDiscount.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtMaxDiscount.Properties.AllowMouseWheel = false;
            this.txtMaxDiscount.Properties.Appearance.Options.UseTextOptions = true;
            this.txtMaxDiscount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtMaxDiscount.Properties.Mask.BeepOnError = true;
            this.txtMaxDiscount.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtMaxDiscount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMaxDiscount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMaxDiscount.ReadOnly = false;
            this.txtMaxDiscount.Size = new System.Drawing.Size(92, 20);
            this.txtMaxDiscount.TabIndex = 109;
            this.txtMaxDiscount.TextAlign = null;
            this.txtMaxDiscount.ValidationRules = null;
            this.txtMaxDiscount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtBankAccountNumber
            // 
            this.txtBankAccountNumber.Capslock = true;
            this.txtBankAccountNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBankAccountNumber.FieldLabel = null;
            this.txtBankAccountNumber.Location = new System.Drawing.Point(140, 506);
            this.txtBankAccountNumber.Name = "txtBankAccountNumber";
            this.txtBankAccountNumber.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtBankAccountNumber.Size = new System.Drawing.Size(213, 20);
            this.txtBankAccountNumber.TabIndex = 121;
            this.txtBankAccountNumber.ValidationRules = null;
            // 
            // txtBankAccountName
            // 
            this.txtBankAccountName.Capslock = true;
            this.txtBankAccountName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBankAccountName.FieldLabel = null;
            this.txtBankAccountName.Location = new System.Drawing.Point(140, 484);
            this.txtBankAccountName.Name = "txtBankAccountName";
            this.txtBankAccountName.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtBankAccountName.Size = new System.Drawing.Size(213, 20);
            this.txtBankAccountName.TabIndex = 120;
            this.txtBankAccountName.ValidationRules = null;
            // 
            // txtName
            // 
            this.txtName.Capslock = true;
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName.FieldLabel = null;
            this.txtName.Location = new System.Drawing.Point(140, 69);
            this.txtName.Name = "txtName";
            this.txtName.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtName.Size = new System.Drawing.Size(313, 20);
            this.txtName.TabIndex = 102;
            this.txtName.ValidationRules = null;
            // 
            // txtPodHeader
            // 
            this.txtPodHeader.Capslock = true;
            this.txtPodHeader.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPodHeader.FieldLabel = null;
            this.txtPodHeader.Location = new System.Drawing.Point(140, 301);
            this.txtPodHeader.Name = "txtPodHeader";
            this.txtPodHeader.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtPodHeader.Size = new System.Drawing.Size(522, 20);
            this.txtPodHeader.TabIndex = 113;
            this.txtPodHeader.ValidationRules = null;
            // 
            // txtInvoiceFooter2
            // 
            this.txtInvoiceFooter2.Capslock = true;
            this.txtInvoiceFooter2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInvoiceFooter2.FieldLabel = null;
            this.txtInvoiceFooter2.Location = new System.Drawing.Point(140, 425);
            this.txtInvoiceFooter2.Name = "txtInvoiceFooter2";
            this.txtInvoiceFooter2.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtInvoiceFooter2.Size = new System.Drawing.Size(522, 20);
            this.txtInvoiceFooter2.TabIndex = 118;
            this.txtInvoiceFooter2.ValidationRules = null;
            // 
            // txtInvoiceHeader3
            // 
            this.txtInvoiceHeader3.Capslock = true;
            this.txtInvoiceHeader3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInvoiceHeader3.FieldLabel = null;
            this.txtInvoiceHeader3.Location = new System.Drawing.Point(140, 381);
            this.txtInvoiceHeader3.Name = "txtInvoiceHeader3";
            this.txtInvoiceHeader3.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtInvoiceHeader3.Size = new System.Drawing.Size(522, 20);
            this.txtInvoiceHeader3.TabIndex = 116;
            this.txtInvoiceHeader3.ValidationRules = null;
            // 
            // txtInvoiceFooter1
            // 
            this.txtInvoiceFooter1.Capslock = true;
            this.txtInvoiceFooter1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInvoiceFooter1.FieldLabel = null;
            this.txtInvoiceFooter1.Location = new System.Drawing.Point(140, 403);
            this.txtInvoiceFooter1.Name = "txtInvoiceFooter1";
            this.txtInvoiceFooter1.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtInvoiceFooter1.Size = new System.Drawing.Size(522, 20);
            this.txtInvoiceFooter1.TabIndex = 117;
            this.txtInvoiceFooter1.ValidationRules = null;
            // 
            // txtInvoiceHeader2
            // 
            this.txtInvoiceHeader2.Capslock = true;
            this.txtInvoiceHeader2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInvoiceHeader2.FieldLabel = null;
            this.txtInvoiceHeader2.Location = new System.Drawing.Point(140, 359);
            this.txtInvoiceHeader2.Name = "txtInvoiceHeader2";
            this.txtInvoiceHeader2.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtInvoiceHeader2.Size = new System.Drawing.Size(522, 20);
            this.txtInvoiceHeader2.TabIndex = 115;
            this.txtInvoiceHeader2.ValidationRules = null;
            // 
            // txtInvoiceHeader1
            // 
            this.txtInvoiceHeader1.Capslock = true;
            this.txtInvoiceHeader1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInvoiceHeader1.FieldLabel = null;
            this.txtInvoiceHeader1.Location = new System.Drawing.Point(140, 337);
            this.txtInvoiceHeader1.Name = "txtInvoiceHeader1";
            this.txtInvoiceHeader1.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtInvoiceHeader1.Size = new System.Drawing.Size(522, 20);
            this.txtInvoiceHeader1.TabIndex = 114;
            this.txtInvoiceHeader1.ValidationRules = null;
            // 
            // txtAddress
            // 
            this.txtAddress.Capslock = true;
            this.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddress.FieldLabel = null;
            this.txtAddress.Location = new System.Drawing.Point(140, 102);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtAddress.Size = new System.Drawing.Size(522, 20);
            this.txtAddress.TabIndex = 103;
            this.txtAddress.ValidationRules = null;
            // 
            // txtContactPhone
            // 
            this.txtContactPhone.Capslock = true;
            this.txtContactPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactPhone.FieldLabel = null;
            this.txtContactPhone.Location = new System.Drawing.Point(140, 222);
            this.txtContactPhone.Name = "txtContactPhone";
            this.txtContactPhone.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtContactPhone.Size = new System.Drawing.Size(213, 20);
            this.txtContactPhone.TabIndex = 108;
            this.txtContactPhone.ValidationRules = null;
            // 
            // txtContactEmail
            // 
            this.txtContactEmail.Capslock = true;
            this.txtContactEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactEmail.FieldLabel = null;
            this.txtContactEmail.Location = new System.Drawing.Point(140, 200);
            this.txtContactEmail.Name = "txtContactEmail";
            this.txtContactEmail.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtContactEmail.Size = new System.Drawing.Size(213, 20);
            this.txtContactEmail.TabIndex = 107;
            this.txtContactEmail.ValidationRules = null;
            // 
            // txtShipmentNoPrefix
            // 
            this.txtShipmentNoPrefix.Capslock = true;
            this.txtShipmentNoPrefix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipmentNoPrefix.FieldLabel = null;
            this.txtShipmentNoPrefix.Location = new System.Drawing.Point(140, 279);
            this.txtShipmentNoPrefix.Name = "txtShipmentNoPrefix";
            this.txtShipmentNoPrefix.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtShipmentNoPrefix.Size = new System.Drawing.Size(74, 20);
            this.txtShipmentNoPrefix.TabIndex = 112;
            this.txtShipmentNoPrefix.ValidationRules = null;
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Capslock = true;
            this.txtContactPerson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactPerson.FieldLabel = null;
            this.txtContactPerson.Location = new System.Drawing.Point(140, 178);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtContactPerson.Size = new System.Drawing.Size(213, 20);
            this.txtContactPerson.TabIndex = 106;
            this.txtContactPerson.ValidationRules = null;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(621, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 114;
            this.label10.Text = "Rp / kg";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(422, 487);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(95, 13);
            this.label24.TabIndex = 113;
            this.label24.Text = "Shipment (Prefix 2)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(422, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 112;
            this.label8.Text = "RA (X-Ray) Fee";
            // 
            // txtBankName
            // 
            this.txtBankName.Capslock = true;
            this.txtBankName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBankName.FieldLabel = null;
            this.txtBankName.Location = new System.Drawing.Point(140, 462);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtBankName.Size = new System.Drawing.Size(213, 20);
            this.txtBankName.TabIndex = 119;
            this.txtBankName.ValidationRules = null;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(12, 260);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 110;
            this.label13.Text = "Type";
            // 
            // txtCode
            // 
            this.txtCode.Capslock = true;
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCode.FieldLabel = null;
            this.txtCode.Location = new System.Drawing.Point(140, 47);
            this.txtCode.Name = "txtCode";
            this.txtCode.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtCode.Size = new System.Drawing.Size(213, 20);
            this.txtCode.TabIndex = 101;
            this.txtCode.ValidationRules = null;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(12, 225);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 108;
            this.label12.Text = "Contact Phone";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(621, 181);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 107;
            this.label9.Text = "Percent";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(12, 203);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 130;
            this.label11.Text = "Contact Email";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(422, 465);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(95, 13);
            this.label23.TabIndex = 119;
            this.label23.Text = "Shipment (Prefix 1)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(422, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 111;
            this.label7.Text = "Max. Discount";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(12, 509);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(115, 13);
            this.label22.TabIndex = 115;
            this.label22.Text = "Bank Account Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 116;
            this.label3.Text = "Contact Person";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(12, 487);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(106, 13);
            this.label21.TabIndex = 117;
            this.label21.Text = "Bank Account Name";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(12, 428);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(46, 13);
            this.label19.TabIndex = 118;
            this.label19.Text = "Footer 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "Name";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(12, 384);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 13);
            this.label17.TabIndex = 120;
            this.label17.Text = "Header 3";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(12, 465);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 13);
            this.label20.TabIndex = 121;
            this.label20.Text = "Bank Name";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(12, 406);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 13);
            this.label18.TabIndex = 122;
            this.label18.Text = "Footer 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 123;
            this.label1.Text = "Code";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(12, 362);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 13);
            this.label16.TabIndex = 124;
            this.label16.Text = "Header 2";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(12, 304);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 13);
            this.label25.TabIndex = 125;
            this.label25.Text = "POD Header";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(12, 282);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 13);
            this.label14.TabIndex = 126;
            this.label14.Text = "Shipment No. Prefix";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(12, 340);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 13);
            this.label15.TabIndex = 127;
            this.label15.Text = "Header 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 128;
            this.label4.Text = "Address";
            // 
            // txtPhone
            // 
            this.txtPhone.Capslock = true;
            this.txtPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPhone.FieldLabel = null;
            this.txtPhone.Location = new System.Drawing.Point(140, 146);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtPhone.Size = new System.Drawing.Size(213, 20);
            this.txtPhone.TabIndex = 105;
            this.txtPhone.ValidationRules = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 129;
            this.label5.Text = "Phone";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(12, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 109;
            this.label6.Text = "City";
            // 
            // lkpCity
            // 
            this.lkpCity.AutoCompleteDataManager = null;
            this.lkpCity.AutoCompleteDisplayFormater = null;
            this.lkpCity.AutoCompleteInitialized = false;
            this.lkpCity.AutocompleteMinimumTextLength = 0;
            this.lkpCity.AutoCompleteText = null;
            this.lkpCity.AutoCompleteWhereExpression = null;
            this.lkpCity.AutoCompleteWheretermFormater = null;
            this.lkpCity.ClearOnLeave = true;
            this.lkpCity.DisplayString = null;
            this.lkpCity.FieldLabel = null;
            this.lkpCity.Location = new System.Drawing.Point(140, 124);
            this.lkpCity.LookupPopup = null;
            this.lkpCity.Name = "lkpCity";
            this.lkpCity.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpCity.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpCity.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpCity.Properties.AutoCompleteDataManager = null;
            this.lkpCity.Properties.AutoCompleteDisplayFormater = null;
            this.lkpCity.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpCity.Properties.AutoCompleteText = null;
            this.lkpCity.Properties.AutoCompleteWhereExpression = null;
            this.lkpCity.Properties.AutoCompleteWheretermFormater = null;
            this.lkpCity.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lkpCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.BottomCenter, ((System.Drawing.Image)(resources.GetObject("lkpCity.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpCity.Properties.LookupPopup = null;
            this.lkpCity.Properties.NullText = "<<Choose..>>";
            this.lkpCity.Size = new System.Drawing.Size(213, 20);
            this.lkpCity.TabIndex = 104;
            this.lkpCity.ValidationRules = null;
            this.lkpCity.Value = null;
            // 
            // cmbBranchType
            // 
            this.cmbBranchType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBranchType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBranchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranchType.FieldLabel = null;
            this.cmbBranchType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbBranchType.FormattingEnabled = true;
            this.cmbBranchType.Location = new System.Drawing.Point(140, 257);
            this.cmbBranchType.Name = "cmbBranchType";
            this.cmbBranchType.Size = new System.Drawing.Size(121, 21);
            this.cmbBranchType.TabIndex = 111;
            this.cmbBranchType.ValidationRules = null;
            // 
            // txtShipmentPrefixOnlineCode1
            // 
            this.txtShipmentPrefixOnlineCode1.Capslock = true;
            this.txtShipmentPrefixOnlineCode1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipmentPrefixOnlineCode1.FieldLabel = null;
            this.txtShipmentPrefixOnlineCode1.Location = new System.Drawing.Point(523, 506);
            this.txtShipmentPrefixOnlineCode1.Name = "txtShipmentPrefixOnlineCode1";
            this.txtShipmentPrefixOnlineCode1.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtShipmentPrefixOnlineCode1.Size = new System.Drawing.Size(92, 20);
            this.txtShipmentPrefixOnlineCode1.TabIndex = 124;
            this.txtShipmentPrefixOnlineCode1.ValidationRules = null;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(358, 508);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(159, 13);
            this.label26.TabIndex = 131;
            this.label26.Text = "Shipment (Prefix Online Code 1 )";
            // 
            // ManageBranchForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(675, 538);
            this.Controls.Add(this.txtShipmentPrefixOnlineCode1);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.cmbBranchType);
            this.Controls.Add(this.lkpCity);
            this.Controls.Add(this.txtShipmentPrefix2);
            this.Controls.Add(this.txtRaFee);
            this.Controls.Add(this.txtShipmentPrefix1);
            this.Controls.Add(this.txtMaxDiscount);
            this.Controls.Add(this.txtBankAccountNumber);
            this.Controls.Add(this.txtBankAccountName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPodHeader);
            this.Controls.Add(this.txtInvoiceFooter2);
            this.Controls.Add(this.txtInvoiceHeader3);
            this.Controls.Add(this.txtInvoiceFooter1);
            this.Controls.Add(this.txtInvoiceHeader2);
            this.Controls.Add(this.txtInvoiceHeader1);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtContactPhone);
            this.Controls.Add(this.txtContactEmail);
            this.Controls.Add(this.txtShipmentNoPrefix);
            this.Controls.Add(this.txtContactPerson);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBankName);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ManageBranchForm";
            this.Text = "Master Branch";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtPhone, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label25, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.label20, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label22, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label23, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtCode, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtBankName, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label24, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtContactPerson, 0);
            this.Controls.SetChildIndex(this.txtShipmentNoPrefix, 0);
            this.Controls.SetChildIndex(this.txtContactEmail, 0);
            this.Controls.SetChildIndex(this.txtContactPhone, 0);
            this.Controls.SetChildIndex(this.txtAddress, 0);
            this.Controls.SetChildIndex(this.txtInvoiceHeader1, 0);
            this.Controls.SetChildIndex(this.txtInvoiceHeader2, 0);
            this.Controls.SetChildIndex(this.txtInvoiceFooter1, 0);
            this.Controls.SetChildIndex(this.txtInvoiceHeader3, 0);
            this.Controls.SetChildIndex(this.txtInvoiceFooter2, 0);
            this.Controls.SetChildIndex(this.txtPodHeader, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.txtBankAccountName, 0);
            this.Controls.SetChildIndex(this.txtBankAccountNumber, 0);
            this.Controls.SetChildIndex(this.txtMaxDiscount, 0);
            this.Controls.SetChildIndex(this.txtShipmentPrefix1, 0);
            this.Controls.SetChildIndex(this.txtRaFee, 0);
            this.Controls.SetChildIndex(this.txtShipmentPrefix2, 0);
            this.Controls.SetChildIndex(this.lkpCity, 0);
            this.Controls.SetChildIndex(this.cmbBranchType, 0);
            this.Controls.SetChildIndex(this.label26, 0);
            this.Controls.SetChildIndex(this.txtShipmentPrefixOnlineCode1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtRaFee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxDiscount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCity.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Component.dTextBox txtShipmentPrefix2;
        private Common.Component.dTextBoxNumber txtRaFee;
        private Common.Component.dTextBox txtShipmentPrefix1;
        private Common.Component.dTextBoxNumber txtMaxDiscount;
        private Common.Component.dTextBox txtBankAccountNumber;
        private Common.Component.dTextBox txtBankAccountName;
        private Common.Component.dTextBox txtName;
        private Common.Component.dTextBox txtPodHeader;
        private Common.Component.dTextBox txtInvoiceFooter2;
        private Common.Component.dTextBox txtInvoiceHeader3;
        private Common.Component.dTextBox txtInvoiceFooter1;
        private Common.Component.dTextBox txtInvoiceHeader2;
        private Common.Component.dTextBox txtInvoiceHeader1;
        private Common.Component.dTextBox txtAddress;
        private Common.Component.dTextBox txtContactPhone;
        private Common.Component.dTextBox txtContactEmail;
        private Common.Component.dTextBox txtShipmentNoPrefix;
        private Common.Component.dTextBox txtContactPerson;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label8;
        private Common.Component.dTextBox txtBankName;
        private System.Windows.Forms.Label label13;
        private Common.Component.dTextBox txtCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label4;
        private Common.Component.dTextBox txtPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Common.Component.dLookup lkpCity;
        private dComboBox cmbBranchType;
        private dTextBox txtShipmentPrefixOnlineCode1;
        private System.Windows.Forms.Label label26;



    }
}