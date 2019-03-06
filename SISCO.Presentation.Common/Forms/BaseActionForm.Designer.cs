namespace SISCO.Presentation.Common.Forms
{
    partial class BaseActionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseActionForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.BtnBaseLast = new System.Windows.Forms.Button();
            this.BtnBaseNext = new System.Windows.Forms.Button();
            this.BtnBasePrevious = new System.Windows.Forms.Button();
            this.BtnBaseFirst = new System.Windows.Forms.Button();
            this.BtnBaseNew = new System.Windows.Forms.Button();
            this.BtnBaseSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCreatedOn = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblModifiedOn = new System.Windows.Forms.Label();
            this.lblModifiedBy = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Action";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(348, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Detail Information";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Meiryo", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(383, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Created On :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBottom.Controls.Add(this.BtnBaseLast);
            this.pnlBottom.Controls.Add(this.BtnBaseNext);
            this.pnlBottom.Controls.Add(this.BtnBasePrevious);
            this.pnlBottom.Controls.Add(this.BtnBaseFirst);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 324);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(571, 52);
            this.pnlBottom.TabIndex = 13;
            // 
            // BtnBaseLast
            // 
            this.BtnBaseLast.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnBaseLast.FlatAppearance.BorderSize = 0;
            this.BtnBaseLast.Image = ((System.Drawing.Image)(resources.GetObject("BtnBaseLast.Image")));
            this.BtnBaseLast.Location = new System.Drawing.Point(335, 5);
            this.BtnBaseLast.Margin = new System.Windows.Forms.Padding(0);
            this.BtnBaseLast.Name = "BtnBaseLast";
            this.BtnBaseLast.Size = new System.Drawing.Size(42, 42);
            this.BtnBaseLast.TabIndex = 14;
            this.BtnBaseLast.UseVisualStyleBackColor = true;
            // 
            // BtnBaseNext
            // 
            this.BtnBaseNext.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnBaseNext.FlatAppearance.BorderSize = 0;
            this.BtnBaseNext.Image = ((System.Drawing.Image)(resources.GetObject("BtnBaseNext.Image")));
            this.BtnBaseNext.Location = new System.Drawing.Point(291, 5);
            this.BtnBaseNext.Margin = new System.Windows.Forms.Padding(0);
            this.BtnBaseNext.Name = "BtnBaseNext";
            this.BtnBaseNext.Size = new System.Drawing.Size(42, 42);
            this.BtnBaseNext.TabIndex = 13;
            this.BtnBaseNext.UseVisualStyleBackColor = true;
            // 
            // BtnBasePrevious
            // 
            this.BtnBasePrevious.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnBasePrevious.Enabled = false;
            this.BtnBasePrevious.FlatAppearance.BorderSize = 0;
            this.BtnBasePrevious.Image = ((System.Drawing.Image)(resources.GetObject("BtnBasePrevious.Image")));
            this.BtnBasePrevious.Location = new System.Drawing.Point(228, 5);
            this.BtnBasePrevious.Margin = new System.Windows.Forms.Padding(0);
            this.BtnBasePrevious.Name = "BtnBasePrevious";
            this.BtnBasePrevious.Size = new System.Drawing.Size(42, 42);
            this.BtnBasePrevious.TabIndex = 12;
            this.BtnBasePrevious.UseVisualStyleBackColor = true;
            // 
            // BtnBaseFirst
            // 
            this.BtnBaseFirst.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnBaseFirst.Enabled = false;
            this.BtnBaseFirst.FlatAppearance.BorderSize = 0;
            this.BtnBaseFirst.Image = ((System.Drawing.Image)(resources.GetObject("BtnBaseFirst.Image")));
            this.BtnBaseFirst.Location = new System.Drawing.Point(184, 5);
            this.BtnBaseFirst.Margin = new System.Windows.Forms.Padding(0);
            this.BtnBaseFirst.Name = "BtnBaseFirst";
            this.BtnBaseFirst.Size = new System.Drawing.Size(42, 42);
            this.BtnBaseFirst.TabIndex = 11;
            this.BtnBaseFirst.UseVisualStyleBackColor = true;
            // 
            // BtnBaseNew
            // 
            this.BtnBaseNew.Font = new System.Drawing.Font("Meiryo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBaseNew.Image = ((System.Drawing.Image)(resources.GetObject("BtnBaseNew.Image")));
            this.BtnBaseNew.Location = new System.Drawing.Point(84, 14);
            this.BtnBaseNew.Name = "BtnBaseNew";
            this.BtnBaseNew.Size = new System.Drawing.Size(78, 45);
            this.BtnBaseNew.TabIndex = 14;
            this.BtnBaseNew.Text = "New";
            this.BtnBaseNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnBaseNew.UseVisualStyleBackColor = true;
            // 
            // BtnBaseSave
            // 
            this.BtnBaseSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBaseSave.Font = new System.Drawing.Font("Meiryo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBaseSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnBaseSave.Image")));
            this.BtnBaseSave.Location = new System.Drawing.Point(481, 273);
            this.BtnBaseSave.Name = "BtnBaseSave";
            this.BtnBaseSave.Size = new System.Drawing.Size(78, 45);
            this.BtnBaseSave.TabIndex = 15;
            this.BtnBaseSave.Text = "Save";
            this.BtnBaseSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnBaseSave.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Meiryo", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(385, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Created By :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Meiryo", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(354, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Last Modified On :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Meiryo", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(356, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Last Modified By :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCreatedOn
            // 
            this.lblCreatedOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreatedOn.AutoSize = true;
            this.lblCreatedOn.Font = new System.Drawing.Font("Meiryo", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedOn.Location = new System.Drawing.Point(466, 85);
            this.lblCreatedOn.Name = "lblCreatedOn";
            this.lblCreatedOn.Size = new System.Drawing.Size(28, 17);
            this.lblCreatedOn.TabIndex = 19;
            this.lblCreatedOn.Text = "N/A";
            this.lblCreatedOn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Meiryo", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(466, 102);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(28, 17);
            this.lblCreatedBy.TabIndex = 20;
            this.lblCreatedBy.Text = "N/A";
            this.lblCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModifiedOn
            // 
            this.lblModifiedOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModifiedOn.AutoSize = true;
            this.lblModifiedOn.Font = new System.Drawing.Font("Meiryo", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModifiedOn.Location = new System.Drawing.Point(466, 129);
            this.lblModifiedOn.Name = "lblModifiedOn";
            this.lblModifiedOn.Size = new System.Drawing.Size(28, 17);
            this.lblModifiedOn.TabIndex = 21;
            this.lblModifiedOn.Text = "N/A";
            this.lblModifiedOn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModifiedBy
            // 
            this.lblModifiedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModifiedBy.AutoSize = true;
            this.lblModifiedBy.Font = new System.Drawing.Font("Meiryo", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModifiedBy.Location = new System.Drawing.Point(466, 146);
            this.lblModifiedBy.Name = "lblModifiedBy";
            this.lblModifiedBy.Size = new System.Drawing.Size(28, 17);
            this.lblModifiedBy.TabIndex = 22;
            this.lblModifiedBy.Text = "N/A";
            this.lblModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BaseActionForm
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(571, 376);
            this.Controls.Add(this.lblModifiedBy);
            this.Controls.Add(this.lblModifiedOn);
            this.Controls.Add(this.lblCreatedBy);
            this.Controls.Add(this.lblCreatedOn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnBaseSave);
            this.Controls.Add(this.BtnBaseNew);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BaseActionForm";
            this.Text = "BaseActionForm";
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button BtnBaseLast;
        private System.Windows.Forms.Button BtnBaseNext;
        private System.Windows.Forms.Button BtnBasePrevious;
        private System.Windows.Forms.Button BtnBaseFirst;
        private System.Windows.Forms.Button BtnBaseNew;
        private System.Windows.Forms.Button BtnBaseSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCreatedOn;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblModifiedOn;
        private System.Windows.Forms.Label lblModifiedBy;
    }
}