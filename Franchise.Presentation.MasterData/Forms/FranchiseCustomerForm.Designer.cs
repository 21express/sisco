using Franchise.Presentation.MasterData.Command;

namespace Franchise.Presentation.MasterData.Forms
{
    partial class FranchiseCustomerForm
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cbxActive = new Franchise.Presentation.Common.Component.dCheckBox();
            this.btnGetId = new DevExpress.XtraEditors.SimpleButton();
            this.tbxDiscount = new Franchise.Presentation.Common.Component.dTextBoxNumber();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxContactEmail = new Franchise.Presentation.Common.Component.dTextBox();
            this.tbxContactPhone = new Franchise.Presentation.Common.Component.dTextBox();
            this.tbxContactPerson = new Franchise.Presentation.Common.Component.dTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxPhone = new Franchise.Presentation.Common.Component.dTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxAddress = new Franchise.Presentation.Common.Component.dTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxName = new Franchise.Presentation.Common.Component.dTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxId = new Franchise.Presentation.Common.Component.dTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxNote = new Franchise.Presentation.Common.Component.dTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDiscount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.tbxNote);
            this.panelControl1.Controls.Add(this.label10);
            this.panelControl1.Controls.Add(this.cbxActive);
            this.panelControl1.Controls.Add(this.btnGetId);
            this.panelControl1.Controls.Add(this.tbxDiscount);
            this.panelControl1.Controls.Add(this.label9);
            this.panelControl1.Controls.Add(this.tbxContactEmail);
            this.panelControl1.Controls.Add(this.tbxContactPhone);
            this.panelControl1.Controls.Add(this.tbxContactPerson);
            this.panelControl1.Controls.Add(this.label7);
            this.panelControl1.Controls.Add(this.label6);
            this.panelControl1.Controls.Add(this.label5);
            this.panelControl1.Controls.Add(this.tbxPhone);
            this.panelControl1.Controls.Add(this.label8);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.tbxAddress);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.tbxName);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.tbxId);
            this.panelControl1.Location = new System.Drawing.Point(7, 113);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(727, 292);
            this.panelControl1.TabIndex = 6;
            // 
            // cbxActive
            // 
            this.cbxActive.AutoSize = true;
            this.cbxActive.FieldLabel = null;
            this.cbxActive.Location = new System.Drawing.Point(129, 152);
            this.cbxActive.Name = "cbxActive";
            this.cbxActive.Size = new System.Drawing.Size(78, 21);
            this.cbxActive.TabIndex = 25;
            this.cbxActive.Text = "Disabled?";
            this.cbxActive.UseVisualStyleBackColor = true;
            this.cbxActive.ValidationRules = null;
            // 
            // btnGetId
            // 
            this.btnGetId.Location = new System.Drawing.Point(278, 8);
            this.btnGetId.Name = "btnGetId";
            this.btnGetId.Size = new System.Drawing.Size(53, 25);
            this.btnGetId.TabIndex = 24;
            this.btnGetId.Text = "Get ID";
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
            this.tbxDiscount.Location = new System.Drawing.Point(129, 124);
            this.tbxDiscount.Name = "tbxDiscount";
            this.tbxDiscount.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDiscount.Properties.AllowMouseWheel = false;
            this.tbxDiscount.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 9F);
            this.tbxDiscount.Properties.Appearance.Options.UseFont = true;
            this.tbxDiscount.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxDiscount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxDiscount.Properties.Mask.BeepOnError = true;
            this.tbxDiscount.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxDiscount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxDiscount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxDiscount.ReadOnly = false;
            this.tbxDiscount.Size = new System.Drawing.Size(100, 24);
            this.tbxDiscount.TabIndex = 5;
            this.tbxDiscount.TextAlign = null;
            this.tbxDiscount.ValidationRules = null;
            this.tbxDiscount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(103, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "ID";
            // 
            // tbxContactEmail
            // 
            this.tbxContactEmail.Capslock = true;
            this.tbxContactEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxContactEmail.FieldLabel = null;
            this.tbxContactEmail.Location = new System.Drawing.Point(129, 235);
            this.tbxContactEmail.Name = "tbxContactEmail";
            this.tbxContactEmail.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxContactEmail.Size = new System.Drawing.Size(244, 24);
            this.tbxContactEmail.TabIndex = 8;
            this.tbxContactEmail.ValidationRules = null;
            // 
            // tbxContactPhone
            // 
            this.tbxContactPhone.Capslock = true;
            this.tbxContactPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxContactPhone.FieldLabel = null;
            this.tbxContactPhone.Location = new System.Drawing.Point(129, 210);
            this.tbxContactPhone.Name = "tbxContactPhone";
            this.tbxContactPhone.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxContactPhone.Size = new System.Drawing.Size(165, 24);
            this.tbxContactPhone.TabIndex = 7;
            this.tbxContactPhone.ValidationRules = null;
            // 
            // tbxContactPerson
            // 
            this.tbxContactPerson.Capslock = true;
            this.tbxContactPerson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxContactPerson.FieldLabel = null;
            this.tbxContactPerson.Location = new System.Drawing.Point(129, 185);
            this.tbxContactPerson.Name = "tbxContactPerson";
            this.tbxContactPerson.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxContactPerson.Size = new System.Drawing.Size(340, 24);
            this.tbxContactPerson.TabIndex = 6;
            this.tbxContactPerson.ValidationRules = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(84, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(81, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Phone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Contact Person";
            // 
            // tbxPhone
            // 
            this.tbxPhone.Capslock = true;
            this.tbxPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxPhone.FieldLabel = null;
            this.tbxPhone.Location = new System.Drawing.Point(129, 99);
            this.tbxPhone.Name = "tbxPhone";
            this.tbxPhone.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPhone.Size = new System.Drawing.Size(183, 24);
            this.tbxPhone.TabIndex = 4;
            this.tbxPhone.ValidationRules = null;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Discount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Phone";
            // 
            // tbxAddress
            // 
            this.tbxAddress.Capslock = true;
            this.tbxAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxAddress.FieldLabel = null;
            this.tbxAddress.Location = new System.Drawing.Point(129, 74);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxAddress.Size = new System.Drawing.Size(559, 24);
            this.tbxAddress.TabIndex = 3;
            this.tbxAddress.ValidationRules = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Address";
            // 
            // tbxName
            // 
            this.tbxName.Capslock = true;
            this.tbxName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxName.FieldLabel = null;
            this.tbxName.Location = new System.Drawing.Point(129, 34);
            this.tbxName.Name = "tbxName";
            this.tbxName.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxName.Size = new System.Drawing.Size(398, 24);
            this.tbxName.TabIndex = 2;
            this.tbxName.ValidationRules = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // tbxId
            // 
            this.tbxId.Capslock = true;
            this.tbxId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxId.FieldLabel = null;
            this.tbxId.Location = new System.Drawing.Point(129, 9);
            this.tbxId.Name = "tbxId";
            this.tbxId.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxId.Size = new System.Drawing.Size(143, 24);
            this.tbxId.TabIndex = 1;
            this.tbxId.ValidationRules = null;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(89, 263);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 17);
            this.label10.TabIndex = 26;
            this.label10.Text = "Note";
            // 
            // tbxNote
            // 
            this.tbxNote.Capslock = true;
            this.tbxNote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxNote.FieldLabel = null;
            this.tbxNote.Location = new System.Drawing.Point(129, 260);
            this.tbxNote.Name = "tbxNote";
            this.tbxNote.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxNote.Size = new System.Drawing.Size(559, 24);
            this.tbxNote.TabIndex = 9;
            this.tbxNote.ValidationRules = null;
            // 
            // FranchiseCustomerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(741, 412);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "FranchiseCustomerForm";
            this.Text = "Master Data - Customer";
            this.Controls.SetChildIndex(this.tbxSearch_Code, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDiscount.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private Common.Component.dTextBox tbxContactEmail;
        private Common.Component.dTextBox tbxContactPhone;
        private Common.Component.dTextBox tbxContactPerson;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Common.Component.dTextBox tbxPhone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private Common.Component.dTextBox tbxAddress;
        private System.Windows.Forms.Label label3;
        private Common.Component.dTextBox tbxName;
        private System.Windows.Forms.Label label2;
        private Common.Component.dTextBox tbxId;
        private System.Windows.Forms.Label label9;
        private Franchise.Presentation.Common.Component.dTextBoxNumber tbxDiscount;
        private DevExpress.XtraEditors.SimpleButton btnGetId;
        private Common.Component.dCheckBox cbxActive;
        private Common.Component.dTextBox tbxNote;
        private System.Windows.Forms.Label label10;


    }
}