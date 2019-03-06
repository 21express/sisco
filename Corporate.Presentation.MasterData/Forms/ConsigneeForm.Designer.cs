namespace Corporate.Presentation.MasterData.Forms
{
    partial class ConsigneeForm
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
            this.tbxPhone = new Corporate.Presentation.Common.Component.dTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxAddress = new Corporate.Presentation.Common.Component.dTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxName = new Corporate.Presentation.Common.Component.dTextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.tbxPhone);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.tbxAddress);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.tbxName);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Location = new System.Drawing.Point(7, 113);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(727, 112);
            this.panelControl1.TabIndex = 6;
            // 
            // tbxPhone
            // 
            this.tbxPhone.Capslock = true;
            this.tbxPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxPhone.FieldLabel = null;
            this.tbxPhone.Location = new System.Drawing.Point(129, 68);
            this.tbxPhone.Name = "tbxPhone";
            this.tbxPhone.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPhone.Size = new System.Drawing.Size(183, 24);
            this.tbxPhone.TabIndex = 3;
            this.tbxPhone.ValidationRules = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 71);
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
            this.tbxAddress.Location = new System.Drawing.Point(129, 41);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxAddress.Size = new System.Drawing.Size(559, 24);
            this.tbxAddress.TabIndex = 2;
            this.tbxAddress.ValidationRules = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 44);
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
            this.tbxName.Location = new System.Drawing.Point(129, 15);
            this.tbxName.Name = "tbxName";
            this.tbxName.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxName.Size = new System.Drawing.Size(398, 24);
            this.tbxName.TabIndex = 1;
            this.tbxName.ValidationRules = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // ConsigneeForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 232);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "ConsigneeForm";
            this.Text = "Master Data - Customer";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.tbxSearch_Code, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private Common.Component.dTextBox tbxPhone;
        private System.Windows.Forms.Label label4;
        private Common.Component.dTextBox tbxAddress;
        private System.Windows.Forms.Label label3;
        private Common.Component.dTextBox tbxName;
        private System.Windows.Forms.Label label2;


    }
}