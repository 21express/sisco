using SISCO.Presentation.Common.Component;

namespace SISCO.Presentation.MasterData.Forms
{
    partial class ManageEmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageEmployeeForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnGetID = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddress = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtName = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtEmail = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtPhone = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtCode = new SISCO.Presentation.Common.Component.dTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lkpBranch = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpDepartment = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpAssociatedUser = new SISCO.Presentation.Common.Component.dLookup();
            this.chkAsMessenger = new SISCO.Presentation.Common.Component.dCheckBox();
            this.chkAsMarketing = new SISCO.Presentation.Common.Component.dCheckBox();
            this.chkAsCustomerService = new SISCO.Presentation.Common.Component.dCheckBox();
            this.chkAsCollector = new SISCO.Presentation.Common.Component.dCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpAssociatedUser.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetID
            // 
            this.btnGetID.Location = new System.Drawing.Point(269, 49);
            this.btnGetID.Name = "btnGetID";
            this.btnGetID.Size = new System.Drawing.Size(61, 27);
            this.btnGetID.TabIndex = 299;
            this.btnGetID.Text = "Get ID";
            this.btnGetID.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(26, 244);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 17);
            this.label8.TabIndex = 130;
            this.label8.Text = "Associated User";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(454, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 17);
            this.label9.TabIndex = 129;
            this.label9.Text = "Role";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(26, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 128;
            this.label7.Text = "Department";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(26, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 17);
            this.label6.TabIndex = 127;
            this.label6.Text = "Branch";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAddress
            // 
            this.txtAddress.Capslock = true;
            this.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddress.FieldLabel = null;
            this.txtAddress.Location = new System.Drawing.Point(124, 102);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtAddress.Size = new System.Drawing.Size(475, 24);
            this.txtAddress.TabIndex = 104;
            this.txtAddress.ValidationRules = null;
            // 
            // txtName
            // 
            this.txtName.Capslock = true;
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName.FieldLabel = null;
            this.txtName.Location = new System.Drawing.Point(124, 76);
            this.txtName.Name = "txtName";
            this.txtName.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtName.Size = new System.Drawing.Size(326, 24);
            this.txtName.TabIndex = 103;
            this.txtName.ValidationRules = null;
            // 
            // txtEmail
            // 
            this.txtEmail.Capslock = true;
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmail.FieldLabel = null;
            this.txtEmail.Location = new System.Drawing.Point(124, 154);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtEmail.Size = new System.Drawing.Size(158, 24);
            this.txtEmail.TabIndex = 106;
            this.txtEmail.ValidationRules = null;
            // 
            // txtPhone
            // 
            this.txtPhone.Capslock = true;
            this.txtPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPhone.FieldLabel = null;
            this.txtPhone.Location = new System.Drawing.Point(124, 128);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtPhone.Size = new System.Drawing.Size(158, 24);
            this.txtPhone.TabIndex = 105;
            this.txtPhone.ValidationRules = null;
            // 
            // txtCode
            // 
            this.txtCode.Capslock = true;
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCode.FieldLabel = null;
            this.txtCode.Location = new System.Drawing.Point(124, 50);
            this.txtCode.Name = "txtCode";
            this.txtCode.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtCode.Size = new System.Drawing.Size(140, 24);
            this.txtCode.TabIndex = 101;
            this.txtCode.ValidationRules = null;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(26, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 120;
            this.label5.Text = "Email";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(26, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 119;
            this.label3.Text = "Address";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(26, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 118;
            this.label4.Text = "Phone";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(26, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 121;
            this.label2.Text = "Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(26, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 117;
            this.label1.Text = "Code";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.lkpBranch.Location = new System.Drawing.Point(124, 189);
            this.lkpBranch.LookupPopup = null;
            this.lkpBranch.Name = "lkpBranch";
            this.lkpBranch.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpBranch.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpBranch.Properties.LookupPopup = null;
            this.lkpBranch.Properties.NullText = "<<Choose...>>";
            this.lkpBranch.Size = new System.Drawing.Size(280, 24);
            this.lkpBranch.TabIndex = 107;
            this.lkpBranch.ValidationRules = null;
            this.lkpBranch.Value = null;
            // 
            // lkpDepartment
            // 
            this.lkpDepartment.AutoCompleteDataManager = null;
            this.lkpDepartment.AutoCompleteDisplayFormater = null;
            this.lkpDepartment.AutoCompleteInitialized = false;
            this.lkpDepartment.AutocompleteMinimumTextLength = 0;
            this.lkpDepartment.AutoCompleteText = null;
            this.lkpDepartment.AutoCompleteWhereExpression = null;
            this.lkpDepartment.AutoCompleteWheretermFormater = null;
            this.lkpDepartment.ClearOnLeave = true;
            this.lkpDepartment.DisplayString = null;
            this.lkpDepartment.FieldLabel = null;
            this.lkpDepartment.Location = new System.Drawing.Point(124, 215);
            this.lkpDepartment.LookupPopup = null;
            this.lkpDepartment.Name = "lkpDepartment";
            this.lkpDepartment.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpDepartment.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpDepartment.Properties.Appearance.Options.UseFont = true;
            this.lkpDepartment.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpDepartment.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpDepartment.Properties.AutoCompleteDataManager = null;
            this.lkpDepartment.Properties.AutoCompleteDisplayFormater = null;
            this.lkpDepartment.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpDepartment.Properties.AutoCompleteText = null;
            this.lkpDepartment.Properties.AutoCompleteWhereExpression = null;
            this.lkpDepartment.Properties.AutoCompleteWheretermFormater = null;
            this.lkpDepartment.Properties.AutoHeight = false;
            this.lkpDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpDepartment.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpDepartment.Properties.LookupPopup = null;
            this.lkpDepartment.Properties.NullText = "<<Choose...>>";
            this.lkpDepartment.Size = new System.Drawing.Size(280, 24);
            this.lkpDepartment.TabIndex = 108;
            this.lkpDepartment.ValidationRules = null;
            this.lkpDepartment.Value = null;
            // 
            // lkpAssociatedUser
            // 
            this.lkpAssociatedUser.AutoCompleteDataManager = null;
            this.lkpAssociatedUser.AutoCompleteDisplayFormater = null;
            this.lkpAssociatedUser.AutoCompleteInitialized = false;
            this.lkpAssociatedUser.AutocompleteMinimumTextLength = 0;
            this.lkpAssociatedUser.AutoCompleteText = null;
            this.lkpAssociatedUser.AutoCompleteWhereExpression = null;
            this.lkpAssociatedUser.AutoCompleteWheretermFormater = null;
            this.lkpAssociatedUser.ClearOnLeave = true;
            this.lkpAssociatedUser.DisplayString = null;
            this.lkpAssociatedUser.FieldLabel = null;
            this.lkpAssociatedUser.Location = new System.Drawing.Point(124, 241);
            this.lkpAssociatedUser.LookupPopup = null;
            this.lkpAssociatedUser.Name = "lkpAssociatedUser";
            this.lkpAssociatedUser.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpAssociatedUser.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpAssociatedUser.Properties.Appearance.Options.UseFont = true;
            this.lkpAssociatedUser.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpAssociatedUser.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpAssociatedUser.Properties.AutoCompleteDataManager = null;
            this.lkpAssociatedUser.Properties.AutoCompleteDisplayFormater = null;
            this.lkpAssociatedUser.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpAssociatedUser.Properties.AutoCompleteText = null;
            this.lkpAssociatedUser.Properties.AutoCompleteWhereExpression = null;
            this.lkpAssociatedUser.Properties.AutoCompleteWheretermFormater = null;
            this.lkpAssociatedUser.Properties.AutoHeight = false;
            this.lkpAssociatedUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpAssociatedUser.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.lkpAssociatedUser.Properties.LookupPopup = null;
            this.lkpAssociatedUser.Properties.NullText = "<<Choose...>>";
            this.lkpAssociatedUser.Size = new System.Drawing.Size(280, 24);
            this.lkpAssociatedUser.TabIndex = 110;
            this.lkpAssociatedUser.ValidationRules = null;
            this.lkpAssociatedUser.Value = null;
            // 
            // chkAsMessenger
            // 
            this.chkAsMessenger.AutoSize = true;
            this.chkAsMessenger.FieldLabel = null;
            this.chkAsMessenger.ForeColor = System.Drawing.Color.Black;
            this.chkAsMessenger.Location = new System.Drawing.Point(557, 169);
            this.chkAsMessenger.Name = "chkAsMessenger";
            this.chkAsMessenger.Size = new System.Drawing.Size(83, 21);
            this.chkAsMessenger.TabIndex = 120;
            this.chkAsMessenger.Text = "Messenger";
            this.chkAsMessenger.UseVisualStyleBackColor = true;
            this.chkAsMessenger.ValidationRules = null;
            // 
            // chkAsMarketing
            // 
            this.chkAsMarketing.AutoSize = true;
            this.chkAsMarketing.FieldLabel = null;
            this.chkAsMarketing.ForeColor = System.Drawing.Color.Black;
            this.chkAsMarketing.Location = new System.Drawing.Point(557, 195);
            this.chkAsMarketing.Name = "chkAsMarketing";
            this.chkAsMarketing.Size = new System.Drawing.Size(80, 21);
            this.chkAsMarketing.TabIndex = 121;
            this.chkAsMarketing.Text = "Marketing";
            this.chkAsMarketing.UseVisualStyleBackColor = true;
            this.chkAsMarketing.ValidationRules = null;
            // 
            // chkAsCustomerService
            // 
            this.chkAsCustomerService.AutoSize = true;
            this.chkAsCustomerService.FieldLabel = null;
            this.chkAsCustomerService.ForeColor = System.Drawing.Color.Black;
            this.chkAsCustomerService.Location = new System.Drawing.Point(557, 221);
            this.chkAsCustomerService.Name = "chkAsCustomerService";
            this.chkAsCustomerService.Size = new System.Drawing.Size(122, 21);
            this.chkAsCustomerService.TabIndex = 122;
            this.chkAsCustomerService.Text = "Customer Service";
            this.chkAsCustomerService.UseVisualStyleBackColor = true;
            this.chkAsCustomerService.ValidationRules = null;
            // 
            // chkAsCollector
            // 
            this.chkAsCollector.AutoSize = true;
            this.chkAsCollector.FieldLabel = null;
            this.chkAsCollector.ForeColor = System.Drawing.Color.Black;
            this.chkAsCollector.Location = new System.Drawing.Point(557, 248);
            this.chkAsCollector.Name = "chkAsCollector";
            this.chkAsCollector.Size = new System.Drawing.Size(75, 21);
            this.chkAsCollector.TabIndex = 300;
            this.chkAsCollector.Text = "Collector";
            this.chkAsCollector.UseVisualStyleBackColor = true;
            this.chkAsCollector.ValidationRules = null;
            // 
            // ManageEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(745, 275);
            this.Controls.Add(this.chkAsCollector);
            this.Controls.Add(this.chkAsCustomerService);
            this.Controls.Add(this.chkAsMarketing);
            this.Controls.Add(this.chkAsMessenger);
            this.Controls.Add(this.lkpAssociatedUser);
            this.Controls.Add(this.lkpDepartment);
            this.Controls.Add(this.lkpBranch);
            this.Controls.Add(this.btnGetID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ManageEmployeeForm";
            this.Text = "Master Employee";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtCode, 0);
            this.Controls.SetChildIndex(this.txtPhone, 0);
            this.Controls.SetChildIndex(this.txtEmail, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.txtAddress, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.btnGetID, 0);
            this.Controls.SetChildIndex(this.lkpBranch, 0);
            this.Controls.SetChildIndex(this.lkpDepartment, 0);
            this.Controls.SetChildIndex(this.lkpAssociatedUser, 0);
            this.Controls.SetChildIndex(this.chkAsMessenger, 0);
            this.Controls.SetChildIndex(this.chkAsMarketing, 0);
            this.Controls.SetChildIndex(this.chkAsCustomerService, 0);
            this.Controls.SetChildIndex(this.chkAsCollector, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lkpBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpAssociatedUser.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Common.Component.dTextBox txtAddress;
        private Common.Component.dTextBox txtName;
        private Common.Component.dTextBox txtEmail;
        private Common.Component.dTextBox txtPhone;
        private Common.Component.dTextBox txtCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Common.Component.dLookup lkpBranch;
        private Common.Component.dLookup lkpDepartment;
        private Common.Component.dLookup lkpAssociatedUser;
        private dCheckBox chkAsMessenger;
        private dCheckBox chkAsMarketing;
        private dCheckBox chkAsCustomerService;
        private dCheckBox chkAsCollector;
    }
}