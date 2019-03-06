namespace SISCO.Presentation.Administration.Forms
{
    partial class PODPrintForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbList = new System.Windows.Forms.GroupBox();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.lbPod = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbList = new System.Windows.Forms.RadioButton();
            this.gbRange = new System.Windows.Forms.GroupBox();
            this.tbxTo = new SISCO.Presentation.Common.Component.dTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxFrom = new SISCO.Presentation.Common.Component.dTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbRange = new System.Windows.Forms.RadioButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.tbxPod = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.gbList.SuspendLayout();
            this.gbRange.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.gbList);
            this.panel1.Controls.Add(this.rbList);
            this.panel1.Controls.Add(this.gbRange);
            this.panel1.Controls.Add(this.rbRange);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 448);
            this.panel1.TabIndex = 0;
            // 
            // gbList
            // 
            this.gbList.Controls.Add(this.tbxPod);
            this.gbList.Controls.Add(this.btnRemove);
            this.gbList.Controls.Add(this.lbPod);
            this.gbList.Controls.Add(this.label3);
            this.gbList.Location = new System.Drawing.Point(37, 157);
            this.gbList.Name = "gbList";
            this.gbList.Size = new System.Drawing.Size(293, 271);
            this.gbList.TabIndex = 3;
            this.gbList.TabStop = false;
            // 
            // btnRemove
            // 
            this.btnRemove.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnRemove.Enabled = false;
            this.btnRemove.Image = global::SISCO.Presentation.Administration.Properties.Resources.icon_cancel_small;
            this.btnRemove.Location = new System.Drawing.Point(29, 50);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(23, 23);
            this.btnRemove.TabIndex = 5;
            // 
            // lbPod
            // 
            this.lbPod.FormattingEnabled = true;
            this.lbPod.ItemHeight = 17;
            this.lbPod.Location = new System.Drawing.Point(58, 50);
            this.lbPod.Name = "lbPod";
            this.lbPod.Size = new System.Drawing.Size(224, 208);
            this.lbPod.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "POD";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbList
            // 
            this.rbList.AutoSize = true;
            this.rbList.Location = new System.Drawing.Point(17, 130);
            this.rbList.Name = "rbList";
            this.rbList.Size = new System.Drawing.Size(86, 21);
            this.rbList.TabIndex = 2;
            this.rbList.TabStop = true;
            this.rbList.Text = "Daftar POD";
            this.rbList.UseVisualStyleBackColor = true;
            // 
            // gbRange
            // 
            this.gbRange.Controls.Add(this.tbxTo);
            this.gbRange.Controls.Add(this.label2);
            this.gbRange.Controls.Add(this.tbxFrom);
            this.gbRange.Controls.Add(this.label1);
            this.gbRange.Location = new System.Drawing.Point(37, 44);
            this.gbRange.Name = "gbRange";
            this.gbRange.Size = new System.Drawing.Size(293, 71);
            this.gbRange.TabIndex = 1;
            this.gbRange.TabStop = false;
            // 
            // tbxTo
            // 
            this.tbxTo.Capslock = true;
            this.tbxTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxTo.FieldLabel = null;
            this.tbxTo.Location = new System.Drawing.Point(58, 40);
            this.tbxTo.Name = "tbxTo";
            this.tbxTo.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTo.Size = new System.Drawing.Size(224, 24);
            this.tbxTo.TabIndex = 3;
            this.tbxTo.ValidationRules = null;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sampai";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxFrom
            // 
            this.tbxFrom.Capslock = true;
            this.tbxFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxFrom.FieldLabel = null;
            this.tbxFrom.Location = new System.Drawing.Point(58, 14);
            this.tbxFrom.Name = "tbxFrom";
            this.tbxFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFrom.Size = new System.Drawing.Size(224, 24);
            this.tbxFrom.TabIndex = 1;
            this.tbxFrom.ValidationRules = null;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dari";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbRange
            // 
            this.rbRange.AutoSize = true;
            this.rbRange.Location = new System.Drawing.Point(17, 17);
            this.rbRange.Name = "rbRange";
            this.rbRange.Size = new System.Drawing.Size(98, 21);
            this.rbRange.TabIndex = 0;
            this.rbRange.TabStop = true;
            this.rbRange.Text = "Rentang POD";
            this.rbRange.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::SISCO.Presentation.Administration.Properties.Resources.icon_print;
            this.btnPrint.Location = new System.Drawing.Point(353, 19);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(129, 46);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            // 
            // btnPreview
            // 
            this.btnPreview.Image = global::SISCO.Presentation.Administration.Properties.Resources.icon_printpreview;
            this.btnPreview.Location = new System.Drawing.Point(353, 67);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(129, 46);
            this.btnPreview.TabIndex = 2;
            this.btnPreview.Text = "Print Preview";
            // 
            // tbxPod
            // 
            this.tbxPod.Location = new System.Drawing.Point(58, 22);
            this.tbxPod.Name = "tbxPod";
            this.tbxPod.Size = new System.Drawing.Size(224, 24);
            this.tbxPod.TabIndex = 6;
            // 
            // PODPrintForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(488, 454);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PODPrintForm";
            this.Text = "Administration - POD Print Form";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbList.ResumeLayout(false);
            this.gbList.PerformLayout();
            this.gbRange.ResumeLayout(false);
            this.gbRange.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbList;
        private System.Windows.Forms.ListBox lbPod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbList;
        private System.Windows.Forms.GroupBox gbRange;
        private Common.Component.dTextBox tbxTo;
        private System.Windows.Forms.Label label2;
        private Common.Component.dTextBox tbxFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbRange;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private System.Windows.Forms.TextBox tbxPod;

    }
}