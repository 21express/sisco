namespace SISCO.Presentation.MasterData.Forms
{
    partial class ManageAirportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageAirportForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContactPhone = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtCode = new SISCO.Presentation.Common.Component.dTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContactPerson = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtName = new SISCO.Presentation.Common.Component.dTextBox();
            this.lkpCity = new SISCO.Presentation.Common.Component.dLookup();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCity.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 115;
            this.label5.Text = "Contact Phone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 116;
            this.label4.Text = "City";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 117;
            this.label1.Text = "Code";
            // 
            // txtContactPhone
            // 
            this.txtContactPhone.Capslock = true;
            this.txtContactPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactPhone.FieldLabel = null;
            this.txtContactPhone.Location = new System.Drawing.Point(112, 158);
            this.txtContactPhone.Name = "txtContactPhone";
            this.txtContactPhone.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtContactPhone.Size = new System.Drawing.Size(200, 20);
            this.txtContactPhone.TabIndex = 105;
            this.txtContactPhone.ValidationRules = null;
            // 
            // txtCode
            // 
            this.txtCode.Capslock = true;
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCode.FieldLabel = null;
            this.txtCode.Location = new System.Drawing.Point(112, 52);
            this.txtCode.Name = "txtCode";
            this.txtCode.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtCode.Size = new System.Drawing.Size(200, 20);
            this.txtCode.TabIndex = 101;
            this.txtCode.ValidationRules = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 113;
            this.label3.Text = "Contact Person";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 114;
            this.label2.Text = "Name";
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Capslock = true;
            this.txtContactPerson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactPerson.FieldLabel = null;
            this.txtContactPerson.Location = new System.Drawing.Point(112, 136);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtContactPerson.Size = new System.Drawing.Size(313, 20);
            this.txtContactPerson.TabIndex = 104;
            this.txtContactPerson.ValidationRules = null;
            // 
            // txtName
            // 
            this.txtName.Capslock = true;
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName.FieldLabel = null;
            this.txtName.Location = new System.Drawing.Point(112, 74);
            this.txtName.Name = "txtName";
            this.txtName.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtName.Size = new System.Drawing.Size(313, 20);
            this.txtName.TabIndex = 102;
            this.txtName.ValidationRules = null;
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
            this.lkpCity.EditValue = "";
            this.lkpCity.FieldLabel = null;
            this.lkpCity.Location = new System.Drawing.Point(112, 104);
            this.lkpCity.LookupPopup = null;
            this.lkpCity.Name = "lkpCity";
            this.lkpCity.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpCity.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpCity.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpCity.Properties.AutoCompleteDataManager = null;
            this.lkpCity.Properties.AutoCompleteDisplayFormater = null;
            this.lkpCity.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpCity.Properties.AutoCompleteText = null;
            this.lkpCity.Properties.AutoCompleteWhereExpression = null;
            this.lkpCity.Properties.AutoCompleteWheretermFormater = null;
            this.lkpCity.Properties.AutoHeight = false;
            this.lkpCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpCity.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpCity.Properties.LookupPopup = null;
            this.lkpCity.Properties.NullText = "<<Choose..>>";
            this.lkpCity.Size = new System.Drawing.Size(200, 20);
            this.lkpCity.TabIndex = 103;
            this.lkpCity.ValidationRules = null;
            this.lkpCity.Value = null;
            // 
            // ManageAirportForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(640, 198);
            this.Controls.Add(this.lkpCity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContactPhone);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtContactPerson);
            this.Controls.Add(this.txtName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ManageAirportForm";
            this.Text = "Master Airport";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.txtContactPerson, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtCode, 0);
            this.Controls.SetChildIndex(this.txtContactPhone, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.lkpCity, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lkpCity.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private Common.Component.dTextBox txtContactPhone;
        private Common.Component.dTextBox txtCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Common.Component.dTextBox txtContactPerson;
        private Common.Component.dTextBox txtName;
        private Common.Component.dLookup lkpCity;
    }
}