namespace Franchise.Modal
{
    partial class ProductKeyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductKeyForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tbxProductKey = new Franchise.Presentation.Common.Component.dTextBox(this.components);
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Key :";
            // 
            // tbxProductKey
            // 
            this.tbxProductKey.Capslock = false;
            this.tbxProductKey.FieldLabel = null;
            this.tbxProductKey.Location = new System.Drawing.Point(26, 46);
            this.tbxProductKey.Name = "tbxProductKey";
            this.tbxProductKey.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxProductKey.Size = new System.Drawing.Size(357, 25);
            this.tbxProductKey.TabIndex = 1;
            this.tbxProductKey.ValidationRules = null;
            // 
            // btnOk
            // 
            this.btnOk.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnOk.Location = new System.Drawing.Point(389, 41);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(41, 35);
            this.btnOk.TabIndex = 2;
            // 
            // ProductKeyForm
            // 
            this.AcceptButton = this.btnOk;
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 108);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tbxProductKey);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Meiryo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductKeyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "G21 Franchise Product Key Viewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Presentation.Common.Component.dTextBox tbxProductKey;
        private DevExpress.XtraEditors.SimpleButton btnOk;
    }
}