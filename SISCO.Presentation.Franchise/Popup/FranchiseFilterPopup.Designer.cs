namespace SISCO.Presentation.Franchise.Popup
{
    partial class FranchiseFilterPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FranchiseFilterPopup));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxName = new SISCO.Presentation.Common.Component.dTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lkpCity = new SISCO.Presentation.Common.Component.dLookup();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).BeginInit();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCity.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // MainContainer
            // 
            // 
            // MainContainer.Panel1
            // 
            this.MainContainer.Panel1.Controls.Add(this.lkpCity);
            this.MainContainer.Panel1.Controls.Add(this.label4);
            this.MainContainer.Panel1.Controls.Add(this.tbxName);
            this.MainContainer.Panel1.Controls.Add(this.label3);
            this.MainContainer.Panel1.Controls.Add(this.label2);
            // 
            // btnFilter
            // 
            this.btnFilter.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Options";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nama Agent";
            // 
            // tbxName
            // 
            this.tbxName.Capslock = true;
            this.tbxName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxName.FieldLabel = null;
            this.tbxName.Location = new System.Drawing.Point(24, 107);
            this.tbxName.Name = "tbxName";
            this.tbxName.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxName.Size = new System.Drawing.Size(147, 24);
            this.tbxName.TabIndex = 2;
            this.tbxName.ValidationRules = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "City";
            // 
            // lkpCity
            // 
            this.lkpCity.AutoCompleteDataManager = null;
            this.lkpCity.AutoCompleteDisplayFormater = null;
            this.lkpCity.AutoCompleteInitialized = false;
            this.lkpCity.AutocompleteMinimumTextLength = 0;
            this.lkpCity.AutoCompleteText = null;
            this.lkpCity.AutoCompleteWhereExpression = null;
            this.lkpCity.AutoCompleteWheretermFormater = null;
            this.lkpCity.ClearOnLeave = true;
            this.lkpCity.DisplayString = null;
            this.lkpCity.FieldLabel = null;
            this.lkpCity.Location = new System.Drawing.Point(24, 157);
            this.lkpCity.LookupPopup = null;
            this.lkpCity.Name = "lkpCity";
            this.lkpCity.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpCity.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpCity.Properties.Appearance.Options.UseFont = true;
            this.lkpCity.Properties.AutoCompleteDataManager = null;
            this.lkpCity.Properties.AutoCompleteDisplayFormater = null;
            this.lkpCity.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpCity.Properties.AutoCompleteText = null;
            this.lkpCity.Properties.AutoCompleteWhereExpression = null;
            this.lkpCity.Properties.AutoCompleteWheretermFormater = null;
            this.lkpCity.Properties.AutoHeight = false;
            this.lkpCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dLookup1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpCity.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpCity.Properties.LookupPopup = null;
            this.lkpCity.Properties.NullText = "<<Choose...>>";
            this.lkpCity.Size = new System.Drawing.Size(147, 22);
            this.lkpCity.TabIndex = 3;
            this.lkpCity.ValidationRules = null;
            this.lkpCity.Value = null;
            // 
            // FranchiseFilterPopup
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 344);
            this.Name = "FranchiseFilterPopup";
            this.SelectedText = "";
            this.Text = "Filter - Inbound";
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).EndInit();
            this.MainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkpCity.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private Common.Component.dTextBox tbxName;
        private Common.Component.dLookup lkpCity;
    }
}