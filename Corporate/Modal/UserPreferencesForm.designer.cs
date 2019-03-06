namespace Corporate.Modal
{
    partial class UserPreferencesForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.PrinterTab = new System.Windows.Forms.TabPage();
            this.tbxBarcode = new DevExpress.XtraEditors.ButtonEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxInkJet = new DevExpress.XtraEditors.ButtonEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDotMetrix = new DevExpress.XtraEditors.ButtonEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.PrintDialog = new System.Windows.Forms.PrintDialog();
            this.tabControl1.SuspendLayout();
            this.PrinterTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxInkJet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDotMetrix.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.PrinterTab);
            this.tabControl1.Location = new System.Drawing.Point(7, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(311, 227);
            this.tabControl1.TabIndex = 0;
            // 
            // PrinterTab
            // 
            this.PrinterTab.BackColor = System.Drawing.SystemColors.Control;
            this.PrinterTab.Controls.Add(this.tbxBarcode);
            this.PrinterTab.Controls.Add(this.label3);
            this.PrinterTab.Controls.Add(this.tbxInkJet);
            this.PrinterTab.Controls.Add(this.label2);
            this.PrinterTab.Controls.Add(this.tbxDotMetrix);
            this.PrinterTab.Controls.Add(this.label1);
            this.PrinterTab.ForeColor = System.Drawing.Color.Black;
            this.PrinterTab.Location = new System.Drawing.Point(4, 26);
            this.PrinterTab.Name = "PrinterTab";
            this.PrinterTab.Padding = new System.Windows.Forms.Padding(3);
            this.PrinterTab.Size = new System.Drawing.Size(303, 197);
            this.PrinterTab.TabIndex = 0;
            this.PrinterTab.Text = "Printer Setting";
            // 
            // tbxBarcode
            // 
            this.tbxBarcode.Location = new System.Drawing.Point(22, 161);
            this.tbxBarcode.Name = "tbxBarcode";
            this.tbxBarcode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tbxBarcode.Size = new System.Drawing.Size(249, 20);
            this.tbxBarcode.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(19, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Barcode Printer";
            // 
            // tbxInkJet
            // 
            this.tbxInkJet.Location = new System.Drawing.Point(22, 104);
            this.tbxInkJet.Name = "tbxInkJet";
            this.tbxInkJet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tbxInkJet.Size = new System.Drawing.Size(249, 20);
            this.tbxInkJet.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ink Jet";
            // 
            // tbxDotMetrix
            // 
            this.tbxDotMetrix.Location = new System.Drawing.Point(22, 49);
            this.tbxDotMetrix.Name = "tbxDotMetrix";
            this.tbxDotMetrix.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tbxDotMetrix.Size = new System.Drawing.Size(249, 20);
            this.tbxDotMetrix.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(19, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dot Matrix";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnOk.Appearance.Options.UseFont = true;
            this.btnOk.Location = new System.Drawing.Point(158, 250);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 31);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "&Ok";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(239, 250);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "&Cancel";
            // 
            // PrintDialog
            // 
            this.PrintDialog.UseEXDialog = true;
            // 
            // UserPreferencesForm
            // 
            this.AcceptButton = this.btnOk;
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(324, 291);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserPreferencesForm";
            this.Text = "User Preferences";
            this.tabControl1.ResumeLayout(false);
            this.PrinterTab.ResumeLayout(false);
            this.PrinterTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxInkJet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDotMetrix.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage PrinterTab;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.ButtonEdit tbxBarcode;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.ButtonEdit tbxInkJet;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.ButtonEdit tbxDotMetrix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PrintDialog PrintDialog;

    }
}