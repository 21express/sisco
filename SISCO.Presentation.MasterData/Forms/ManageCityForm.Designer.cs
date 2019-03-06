namespace SISCO.Presentation.MasterData.Forms
{
    partial class ManageCityForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageCityForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new SISCO.Presentation.Common.Component.dTextBox();
            this.lkpCountry = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpBranch = new SISCO.Presentation.Common.Component.dLookup();
            this.label2 = new System.Windows.Forms.Label();
            this.txtZipcode = new SISCO.Presentation.Common.Component.dTextBox();
            this.cbxCod = new SISCO.Presentation.Common.Component.dCheckBox();
            this.cbxOutArea = new SISCO.Presentation.Common.Component.dCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCountry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBranch.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(51, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 122;
            this.label3.Text = "Branch";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(51, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 123;
            this.label4.Text = "Country";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(51, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 121;
            this.label1.Text = "Code";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCode
            // 
            this.txtCode.Capslock = true;
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCode.FieldLabel = null;
            this.txtCode.Location = new System.Drawing.Point(121, 41);
            this.txtCode.Name = "txtCode";
            this.txtCode.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtCode.Size = new System.Drawing.Size(151, 24);
            this.txtCode.TabIndex = 1;
            this.txtCode.ValidationRules = null;
            // 
            // lkpCountry
            // 
            this.lkpCountry.AutoCompleteDataManager = null;
            this.lkpCountry.AutoCompleteDisplayFormater = null;
            this.lkpCountry.AutoCompleteInitialized = false;
            this.lkpCountry.AutocompleteMinimumTextLength = 0;
            this.lkpCountry.AutoCompleteText = null;
            this.lkpCountry.AutoCompleteWhereExpression = null;
            this.lkpCountry.AutoCompleteWheretermFormater = null;
            this.lkpCountry.ClearOnLeave = true;
            this.lkpCountry.DisplayString = null;
            this.lkpCountry.EditValue = "";
            this.lkpCountry.FieldLabel = null;
            this.lkpCountry.Location = new System.Drawing.Point(121, 70);
            this.lkpCountry.LookupPopup = null;
            this.lkpCountry.Name = "lkpCountry";
            this.lkpCountry.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpCountry.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpCountry.Properties.Appearance.Options.UseFont = true;
            this.lkpCountry.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpCountry.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpCountry.Properties.AutoCompleteDataManager = null;
            this.lkpCountry.Properties.AutoCompleteDisplayFormater = null;
            this.lkpCountry.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpCountry.Properties.AutoCompleteText = null;
            this.lkpCountry.Properties.AutoCompleteWhereExpression = null;
            this.lkpCountry.Properties.AutoCompleteWheretermFormater = null;
            this.lkpCountry.Properties.AutoHeight = false;
            this.lkpCountry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpCountry.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpCountry.Properties.LookupPopup = null;
            this.lkpCountry.Properties.NullText = "<<Choose..>>";
            this.lkpCountry.Size = new System.Drawing.Size(249, 24);
            this.lkpCountry.TabIndex = 2;
            this.lkpCountry.ValidationRules = null;
            this.lkpCountry.Value = null;
            // 
            // lkpBranch
            // 
            this.lkpBranch.AutoCompleteDataManager = null;
            this.lkpBranch.AutoCompleteDisplayFormater = null;
            this.lkpBranch.AutoCompleteInitialized = false;
            this.lkpBranch.AutocompleteMinimumTextLength = 0;
            this.lkpBranch.AutoCompleteText = null;
            this.lkpBranch.AutoCompleteWhereExpression = null;
            this.lkpBranch.AutoCompleteWheretermFormater = null;
            this.lkpBranch.ClearOnLeave = true;
            this.lkpBranch.DisplayString = null;
            this.lkpBranch.EditValue = "";
            this.lkpBranch.FieldLabel = null;
            this.lkpBranch.Location = new System.Drawing.Point(121, 95);
            this.lkpBranch.LookupPopup = null;
            this.lkpBranch.Name = "lkpBranch";
            this.lkpBranch.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpBranch.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpBranch.Properties.Appearance.Options.UseFont = true;
            this.lkpBranch.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpBranch.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpBranch.Properties.AutoCompleteDataManager = null;
            this.lkpBranch.Properties.AutoCompleteDisplayFormater = null;
            this.lkpBranch.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpBranch.Properties.AutoCompleteText = null;
            this.lkpBranch.Properties.AutoCompleteWhereExpression = null;
            this.lkpBranch.Properties.AutoCompleteWheretermFormater = null;
            this.lkpBranch.Properties.AutoHeight = false;
            this.lkpBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpBranch.Properties.LookupPopup = null;
            this.lkpBranch.Properties.NullText = "<<Choose..>>";
            this.lkpBranch.Size = new System.Drawing.Size(346, 24);
            this.lkpBranch.TabIndex = 3;
            this.lkpBranch.ValidationRules = null;
            this.lkpBranch.Value = null;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(51, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 124;
            this.label2.Text = "Zip Code";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtZipcode
            // 
            this.txtZipcode.Capslock = true;
            this.txtZipcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtZipcode.FieldLabel = null;
            this.txtZipcode.Location = new System.Drawing.Point(121, 120);
            this.txtZipcode.Name = "txtZipcode";
            this.txtZipcode.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtZipcode.Size = new System.Drawing.Size(107, 24);
            this.txtZipcode.TabIndex = 4;
            this.txtZipcode.ValidationRules = null;
            // 
            // cbxCod
            // 
            this.cbxCod.AutoSize = true;
            this.cbxCod.FieldLabel = null;
            this.cbxCod.Location = new System.Drawing.Point(121, 153);
            this.cbxCod.Name = "cbxCod";
            this.cbxCod.Size = new System.Drawing.Size(99, 21);
            this.cbxCod.TabIndex = 5;
            this.cbxCod.Text = "Service COD?";
            this.cbxCod.UseVisualStyleBackColor = true;
            this.cbxCod.ValidationRules = null;
            // 
            // cbxOutArea
            // 
            this.cbxOutArea.AutoSize = true;
            this.cbxOutArea.FieldLabel = null;
            this.cbxOutArea.Location = new System.Drawing.Point(121, 181);
            this.cbxOutArea.Name = "cbxOutArea";
            this.cbxOutArea.Size = new System.Drawing.Size(80, 21);
            this.cbxOutArea.TabIndex = 6;
            this.cbxOutArea.Text = "Out Area?";
            this.cbxOutArea.UseVisualStyleBackColor = true;
            this.cbxOutArea.ValidationRules = null;
            // 
            // ManageCityForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(756, 209);
            this.Controls.Add(this.cbxOutArea);
            this.Controls.Add(this.cbxCod);
            this.Controls.Add(this.txtZipcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lkpBranch);
            this.Controls.Add(this.lkpCountry);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCode);
            this.Name = "ManageCityForm";
            this.Text = "Master City";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.txtCode, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lkpCountry, 0);
            this.Controls.SetChildIndex(this.lkpBranch, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtZipcode, 0);
            this.Controls.SetChildIndex(this.cbxCod, 0);
            this.Controls.SetChildIndex(this.cbxOutArea, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lkpCountry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBranch.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private Common.Component.dTextBox txtCode;
        private Common.Component.dLookup lkpCountry;
        private Common.Component.dLookup lkpBranch;
        private System.Windows.Forms.Label label2;
        private Common.Component.dTextBox txtZipcode;
        private Common.Component.dCheckBox cbxCod;
        private Common.Component.dCheckBox cbxOutArea;
    }
}