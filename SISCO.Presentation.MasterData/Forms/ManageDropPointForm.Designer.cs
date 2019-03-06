namespace SISCO.Presentation.MasterData.Forms
{
    partial class ManageDropPointForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageDropPointForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lkpBranch = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.tbxCommission = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxPhone = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.tbxEmail = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tbxId = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tbxAddress = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tbxName = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCommission.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lkpBranch);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tbxCommission);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.tbxId);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbxAddress);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbxName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 179);
            this.panel1.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(212, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "%";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lkpBranch
            // 
            this.lkpBranch.AutoCompleteDataManager = null;
            this.lkpBranch.AutoCompleteDisplayFormater = null;
            this.lkpBranch.AutoCompleteInitialized = false;
            this.lkpBranch.AutocompleteMinimumTextLength = 0;
            this.lkpBranch.AutoCompleteText = null;
            this.lkpBranch.AutoCompleteWhereExpression = null;
            this.lkpBranch.AutoCompleteWheretermFormater = null;
            this.lkpBranch.ClearOnLeave = true;
            this.lkpBranch.DisplayString = null;
            this.lkpBranch.FieldLabel = null;
            this.lkpBranch.Location = new System.Drawing.Point(112, 68);
            this.lkpBranch.LookupPopup = null;
            this.lkpBranch.Name = "lkpBranch";
            this.lkpBranch.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpBranch.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lkpBranch.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpBranch.Properties.Appearance.Options.UseBackColor = true;
            this.lkpBranch.Properties.Appearance.Options.UseFont = true;
            this.lkpBranch.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpBranch.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpBranch.Properties.AutoCompleteDataManager = null;
            this.lkpBranch.Properties.AutoCompleteDisplayFormater = null;
            this.lkpBranch.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpBranch.Properties.AutoCompleteText = null;
            this.lkpBranch.Properties.AutoCompleteWhereExpression = null;
            this.lkpBranch.Properties.AutoCompleteWheretermFormater = null;
            this.lkpBranch.Properties.AutoHeight = false;
            this.lkpBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.TopCenter, ((System.Drawing.Image)(resources.GetObject("lkpBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpBranch.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpBranch.Properties.LookupPopup = null;
            this.lkpBranch.Properties.NullText = "<<Choose...>>";
            this.lkpBranch.Size = new System.Drawing.Size(260, 24);
            this.lkpBranch.TabIndex = 3;
            this.lkpBranch.ValidationRules = null;
            this.lkpBranch.Value = null;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(53, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Cabang";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxCommission
            // 
            this.tbxCommission.EditMask = "###,###,###,###,###,##0.00";
            this.tbxCommission.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxCommission.FieldLabel = null;
            this.tbxCommission.Location = new System.Drawing.Point(112, 130);
            this.tbxCommission.Name = "tbxCommission";
            this.tbxCommission.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxCommission.Properties.AllowMouseWheel = false;
            this.tbxCommission.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxCommission.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxCommission.Properties.Appearance.Options.UseBackColor = true;
            this.tbxCommission.Properties.Appearance.Options.UseFont = true;
            this.tbxCommission.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxCommission.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxCommission.Properties.Mask.BeepOnError = true;
            this.tbxCommission.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxCommission.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxCommission.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxCommission.ReadOnly = false;
            this.tbxCommission.Size = new System.Drawing.Size(94, 24);
            this.tbxCommission.TabIndex = 5;
            this.tbxCommission.TextAlign = null;
            this.tbxCommission.ValidationRules = null;
            this.tbxCommission.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(53, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Komisi";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxPhone);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbxEmail);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(378, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 88);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kontak";
            // 
            // tbxPhone
            // 
            this.tbxPhone.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxPhone.Capslock = true;
            this.tbxPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxPhone.FieldLabel = null;
            this.tbxPhone.Location = new System.Drawing.Point(86, 49);
            this.tbxPhone.Name = "tbxPhone";
            this.tbxPhone.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPhone.Size = new System.Drawing.Size(201, 24);
            this.tbxPhone.TabIndex = 7;
            this.tbxPhone.ValidationRules = null;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(25, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "No. Telp";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxEmail
            // 
            this.tbxEmail.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxEmail.Capslock = true;
            this.tbxEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxEmail.FieldLabel = null;
            this.tbxEmail.Location = new System.Drawing.Point(86, 23);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxEmail.Size = new System.Drawing.Size(201, 24);
            this.tbxEmail.TabIndex = 6;
            this.tbxEmail.ValidationRules = null;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(25, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Email";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxId
            // 
            this.tbxId.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxId.Capslock = true;
            this.tbxId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxId.FieldLabel = null;
            this.tbxId.Location = new System.Drawing.Point(112, 104);
            this.tbxId.Name = "tbxId";
            this.tbxId.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxId.Size = new System.Drawing.Size(260, 24);
            this.tbxId.TabIndex = 4;
            this.tbxId.ValidationRules = null;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(53, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "No. KTP";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxAddress
            // 
            this.tbxAddress.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxAddress.Capslock = true;
            this.tbxAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxAddress.FieldLabel = null;
            this.tbxAddress.Location = new System.Drawing.Point(112, 41);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxAddress.Size = new System.Drawing.Size(488, 24);
            this.tbxAddress.TabIndex = 2;
            this.tbxAddress.ValidationRules = null;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(53, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Alamat";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxName
            // 
            this.tbxName.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxName.Capslock = true;
            this.tbxName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxName.FieldLabel = null;
            this.tbxName.Location = new System.Drawing.Point(112, 15);
            this.tbxName.Name = "tbxName";
            this.tbxName.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxName.Size = new System.Drawing.Size(271, 24);
            this.tbxName.TabIndex = 1;
            this.tbxName.ValidationRules = null;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(53, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nama";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ManageDropPointForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(746, 224);
            this.Controls.Add(this.panel1);
            this.Name = "ManageDropPointForm";
            this.Text = "Manage Drop Point";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCommission.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Common.Component.dTextBox tbxName;
        private System.Windows.Forms.Label label1;
        private Common.Component.dTextBox tbxId;
        private System.Windows.Forms.Label label3;
        private Common.Component.dTextBox tbxAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Common.Component.dTextBox tbxEmail;
        private System.Windows.Forms.Label label4;
        private Common.Component.dLookup lkpBranch;
        private System.Windows.Forms.Label label7;
        private Common.Component.dTextBoxNumber tbxCommission;
        private System.Windows.Forms.Label label6;
        private Common.Component.dTextBox tbxPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
    }
}