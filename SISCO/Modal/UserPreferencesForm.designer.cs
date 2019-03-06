namespace SISCO.Modal
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDesktopBackground = new DevExpress.XtraEditors.ButtonEdit();
            this.PrintDialog = new System.Windows.Forms.PrintDialog();
            this.tbxRangkap4 = new DevExpress.XtraEditors.ButtonEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.PrinterTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxInkJet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDotMetrix.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesktopBackground.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxRangkap4.Properties)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(311, 293);
            this.tabControl1.TabIndex = 0;
            // 
            // PrinterTab
            // 
            this.PrinterTab.BackColor = System.Drawing.SystemColors.Control;
            this.PrinterTab.Controls.Add(this.tbxRangkap4);
            this.PrinterTab.Controls.Add(this.label4);
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
            this.PrinterTab.Size = new System.Drawing.Size(303, 263);
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
            this.btnOk.Location = new System.Drawing.Point(241, 387);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 31);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "&Ok";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(160, 387);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "&Cancel";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.txtDesktopBackground);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(7, 316);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 56);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Desktop Background";
            // 
            // txtDesktopBackground
            // 
            this.txtDesktopBackground.Location = new System.Drawing.Point(15, 23);
            this.txtDesktopBackground.Name = "txtDesktopBackground";
            this.txtDesktopBackground.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtDesktopBackground.Properties.Appearance.Options.UseBackColor = true;
            this.txtDesktopBackground.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDesktopBackground.Properties.ReadOnly = true;
            this.txtDesktopBackground.Size = new System.Drawing.Size(274, 20);
            this.txtDesktopBackground.TabIndex = 4;
            // 
            // PrintDialog
            // 
            this.PrintDialog.UseEXDialog = true;
            // 
            // tbxRangkap4
            // 
            this.tbxRangkap4.Location = new System.Drawing.Point(22, 227);
            this.tbxRangkap4.Name = "tbxRangkap4";
            this.tbxRangkap4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tbxRangkap4.Size = new System.Drawing.Size(249, 20);
            this.tbxRangkap4.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(19, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Dot Matrix [POD Rangkap 4]";
            // 
            // UserPreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(324, 427);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDesktopBackground.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxRangkap4.Properties)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.ButtonEdit txtDesktopBackground;
        private System.Windows.Forms.PrintDialog PrintDialog;
        private DevExpress.XtraEditors.ButtonEdit tbxRangkap4;
        private System.Windows.Forms.Label label4;

    }
}