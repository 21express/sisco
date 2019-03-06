namespace Corporate.Presentation.Common.Forms
{
    partial class InfoPopup
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
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.gbCreated = new System.Windows.Forms.GroupBox();
            this.lblCreatedPc = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbModified = new System.Windows.Forms.GroupBox();
            this.lblModifiedPc = new System.Windows.Forms.Label();
            this.lblModifiedBy = new System.Windows.Forms.Label();
            this.lblModifiedDate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gbCreated.SuspendLayout();
            this.gbModified.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(243, 252);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 26);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            // 
            // gbCreated
            // 
            this.gbCreated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCreated.Controls.Add(this.lblCreatedPc);
            this.gbCreated.Controls.Add(this.lblCreatedBy);
            this.gbCreated.Controls.Add(this.lblCreatedDate);
            this.gbCreated.Controls.Add(this.label3);
            this.gbCreated.Controls.Add(this.label2);
            this.gbCreated.Controls.Add(this.label1);
            this.gbCreated.Location = new System.Drawing.Point(12, 19);
            this.gbCreated.Name = "gbCreated";
            this.gbCreated.Size = new System.Drawing.Size(312, 107);
            this.gbCreated.TabIndex = 1;
            this.gbCreated.TabStop = false;
            this.gbCreated.Text = "Created";
            // 
            // lblCreatedPc
            // 
            this.lblCreatedPc.AutoSize = true;
            this.lblCreatedPc.Location = new System.Drawing.Point(104, 76);
            this.lblCreatedPc.Name = "lblCreatedPc";
            this.lblCreatedPc.Size = new System.Drawing.Size(12, 17);
            this.lblCreatedPc.TabIndex = 5;
            this.lblCreatedPc.Text = " ";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(104, 50);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(12, 17);
            this.lblCreatedBy.TabIndex = 4;
            this.lblCreatedBy.Text = " ";
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Location = new System.Drawing.Point(104, 24);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(12, 17);
            this.lblCreatedDate.TabIndex = 3;
            this.lblCreatedDate.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Computer :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "User :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date :";
            // 
            // gbModified
            // 
            this.gbModified.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbModified.Controls.Add(this.lblModifiedPc);
            this.gbModified.Controls.Add(this.lblModifiedBy);
            this.gbModified.Controls.Add(this.lblModifiedDate);
            this.gbModified.Controls.Add(this.label7);
            this.gbModified.Controls.Add(this.label8);
            this.gbModified.Controls.Add(this.label9);
            this.gbModified.Location = new System.Drawing.Point(12, 132);
            this.gbModified.Name = "gbModified";
            this.gbModified.Size = new System.Drawing.Size(312, 109);
            this.gbModified.TabIndex = 2;
            this.gbModified.TabStop = false;
            this.gbModified.Text = "Modified";
            // 
            // lblModifiedPc
            // 
            this.lblModifiedPc.AutoSize = true;
            this.lblModifiedPc.Location = new System.Drawing.Point(104, 77);
            this.lblModifiedPc.Name = "lblModifiedPc";
            this.lblModifiedPc.Size = new System.Drawing.Size(12, 17);
            this.lblModifiedPc.TabIndex = 11;
            this.lblModifiedPc.Text = " ";
            // 
            // lblModifiedBy
            // 
            this.lblModifiedBy.AutoSize = true;
            this.lblModifiedBy.Location = new System.Drawing.Point(104, 51);
            this.lblModifiedBy.Name = "lblModifiedBy";
            this.lblModifiedBy.Size = new System.Drawing.Size(12, 17);
            this.lblModifiedBy.TabIndex = 10;
            this.lblModifiedBy.Text = " ";
            // 
            // lblModifiedDate
            // 
            this.lblModifiedDate.AutoSize = true;
            this.lblModifiedDate.Location = new System.Drawing.Point(104, 25);
            this.lblModifiedDate.Name = "lblModifiedDate";
            this.lblModifiedDate.Size = new System.Drawing.Size(12, 17);
            this.lblModifiedDate.TabIndex = 9;
            this.lblModifiedDate.Text = " ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Computer :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(54, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "User :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(54, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "Date :";
            // 
            // InfoPopup
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(336, 288);
            this.Controls.Add(this.gbModified);
            this.Controls.Add(this.gbCreated);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoPopup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Record Properties";
            this.gbCreated.ResumeLayout(false);
            this.gbCreated.PerformLayout();
            this.gbModified.ResumeLayout(false);
            this.gbModified.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.GroupBox gbCreated;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCreatedPc;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbModified;
        private System.Windows.Forms.Label lblModifiedPc;
        private System.Windows.Forms.Label lblModifiedBy;
        private System.Windows.Forms.Label lblModifiedDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}