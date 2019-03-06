namespace Corporate.Modal
{
    partial class ChangePasswordForm
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
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new Corporate.Presentation.Common.Component.dTextBox();
            this.txtOldPassword = new Corporate.Presentation.Common.Component.dTextBox();
            this.txtNewPassword = new Corporate.Presentation.Common.Component.dTextBox();
            this.txtUsername = new Corporate.Presentation.Common.Component.dTextBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(181, 140);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 105;
            this.btnOK.Text = "&Ok";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(265, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 106;
            this.btnCancel.Text = "Cancel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(50, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(31, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Old Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(26, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Capslock = true;
            this.txtConfirmPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConfirmPassword.FieldLabel = null;
            this.txtConfirmPassword.Location = new System.Drawing.Point(118, 101);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(222, 24);
            this.txtConfirmPassword.TabIndex = 104;
            this.txtConfirmPassword.ValidationRules = null;
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Capslock = true;
            this.txtOldPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOldPassword.FieldLabel = null;
            this.txtOldPassword.Location = new System.Drawing.Point(118, 39);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(222, 24);
            this.txtOldPassword.TabIndex = 102;
            this.txtOldPassword.ValidationRules = null;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Capslock = true;
            this.txtNewPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNewPassword.FieldLabel = null;
            this.txtNewPassword.Location = new System.Drawing.Point(118, 75);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtNewPassword.Size = new System.Drawing.Size(222, 24);
            this.txtNewPassword.TabIndex = 103;
            this.txtNewPassword.ValidationRules = null;
            // 
            // txtUsername
            // 
            this.txtUsername.Capslock = true;
            this.txtUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsername.FieldLabel = null;
            this.txtUsername.Location = new System.Drawing.Point(118, 13);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtUsername.Size = new System.Drawing.Size(222, 24);
            this.txtUsername.TabIndex = 101;
            this.txtUsername.ValidationRules = null;
            // 
            // ChangePasswordForm
            // 
            this.AcceptButton = this.btnOK;
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(354, 183);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Label label3;
        private Corporate.Presentation.Common.Component.dTextBox txtUsername;
        private System.Windows.Forms.Label label4;
        private Corporate.Presentation.Common.Component.dTextBox txtOldPassword;
        private System.Windows.Forms.Label label1;
        private Corporate.Presentation.Common.Component.dTextBox txtNewPassword;
        private System.Windows.Forms.Label label2;
        private Corporate.Presentation.Common.Component.dTextBox txtConfirmPassword;
    }
}