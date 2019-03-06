namespace SISCO.Modal
{
    partial class MySQLSettingForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbxPort = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.btnTestConnection = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxPassword = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.tbxUsername = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tbxDBName = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxServer = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(7, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(311, 332);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.tbxPort);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnTestConnection);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.tbxDBName);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tbxServer);
            this.tabPage1.ForeColor = System.Drawing.Color.Black;
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(303, 302);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "MySQL Connection";
            // 
            // tbxPort
            // 
            this.tbxPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxPort.Capslock = true;
            this.tbxPort.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxPort.FieldLabel = null;
            this.tbxPort.Location = new System.Drawing.Point(211, 48);
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPort.Size = new System.Drawing.Size(82, 24);
            this.tbxPort.TabIndex = 2;
            this.tbxPort.ValidationRules = null;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(208, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Port*";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTestConnection.Location = new System.Drawing.Point(11, 259);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(115, 31);
            this.btnTestConnection.TabIndex = 6;
            this.btnTestConnection.Text = "&Test Connection";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbxPassword);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbxUsername);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(11, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 131);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // tbxPassword
            // 
            this.tbxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxPassword.Capslock = true;
            this.tbxPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxPassword.FieldLabel = null;
            this.tbxPassword.Location = new System.Drawing.Point(14, 94);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPassword.PasswordChar = '*';
            this.tbxPassword.Size = new System.Drawing.Size(251, 24);
            this.tbxPassword.TabIndex = 5;
            this.tbxPassword.ValidationRules = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(11, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Password*";
            // 
            // tbxUsername
            // 
            this.tbxUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxUsername.Capslock = true;
            this.tbxUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxUsername.FieldLabel = null;
            this.tbxUsername.Location = new System.Drawing.Point(14, 42);
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxUsername.Size = new System.Drawing.Size(251, 24);
            this.tbxUsername.TabIndex = 4;
            this.tbxUsername.ValidationRules = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(11, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Username*";
            // 
            // tbxDBName
            // 
            this.tbxDBName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxDBName.Capslock = true;
            this.tbxDBName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDBName.FieldLabel = null;
            this.tbxDBName.Location = new System.Drawing.Point(11, 98);
            this.tbxDBName.Name = "tbxDBName";
            this.tbxDBName.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDBName.Size = new System.Drawing.Size(282, 24);
            this.tbxDBName.TabIndex = 3;
            this.tbxDBName.ValidationRules = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Database Name*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Server Name*";
            // 
            // tbxServer
            // 
            this.tbxServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxServer.Capslock = true;
            this.tbxServer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxServer.FieldLabel = null;
            this.tbxServer.Location = new System.Drawing.Point(11, 48);
            this.tbxServer.Name = "tbxServer";
            this.tbxServer.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxServer.Size = new System.Drawing.Size(194, 24);
            this.tbxServer.TabIndex = 1;
            this.tbxServer.ValidationRules = null;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(162, 345);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 31);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "&Ok";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(243, 345);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancel";
            // 
            // MySQLSettingForm
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(324, 385);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MySQLSettingForm";
            this.Text = "Database Connection";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private DevExpress.XtraEditors.SimpleButton btnTestConnection;
        private System.Windows.Forms.GroupBox groupBox1;
        private Presentation.Common.Component.dTextBox tbxPassword;
        private System.Windows.Forms.Label label5;
        private Presentation.Common.Component.dTextBox tbxUsername;
        private System.Windows.Forms.Label label4;
        private Presentation.Common.Component.dTextBox tbxDBName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Presentation.Common.Component.dTextBox tbxServer;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private Presentation.Common.Component.dTextBox tbxPort;
        private System.Windows.Forms.Label label2;

    }
}