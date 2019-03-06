namespace SISCO.Presentation.Operation.Popup
{
    partial class HeavyDifferenceAirwaybillFilterPopup
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbxShipment = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).BeginInit();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainContainer
            // 
            // 
            // MainContainer.Panel1
            // 
            this.MainContainer.Panel1.Controls.Add(this.tbxShipment);
            this.MainContainer.Panel1.Controls.Add(this.label2);
            // 
            // tbxCode
            // 
            this.tbxCode.Location = new System.Drawing.Point(17, 69);
            this.tbxCode.Size = new System.Drawing.Size(169, 24);
            // 
            // btnClear
            // 
            this.btnClear.TabIndex = 4;
            // 
            // btnFilter
            // 
            this.btnFilter.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.Text = "Consolidation Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "No. POD";
            // 
            // tbxShipment
            // 
            this.tbxShipment.Capslock = true;
            this.tbxShipment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxShipment.FieldLabel = null;
            this.tbxShipment.Location = new System.Drawing.Point(17, 123);
            this.tbxShipment.Name = "tbxShipment";
            this.tbxShipment.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxShipment.Size = new System.Drawing.Size(169, 24);
            this.tbxShipment.TabIndex = 2;
            this.tbxShipment.ValidationRules = null;
            // 
            // HeavyDifferenceAirwaybillFilterPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 450);
            this.Name = "HeavyDifferenceAirwaybillFilterPopup";
            this.SelectedText = "";
            this.Text = "HeavyDifferenceAirwaybillFilterPopup";
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).EndInit();
            this.MainContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Common.Component.dTextBox tbxShipment;
        private System.Windows.Forms.Label label2;
    }
}