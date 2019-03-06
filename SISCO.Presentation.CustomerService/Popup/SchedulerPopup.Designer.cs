namespace SISCO.Presentation.CustomerService.Popup
{
    partial class SchedulerPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchedulerPopup));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label2 = new System.Windows.Forms.Label();
            this.lkpCustomer = new SISCO.Presentation.Common.Component.dLookup();
            this.cbxActive = new SISCO.Presentation.Common.Component.dCheckBox();
            this.cbxMon = new SISCO.Presentation.Common.Component.dCheckBox();
            this.cbxTue = new SISCO.Presentation.Common.Component.dCheckBox();
            this.cbxWed = new SISCO.Presentation.Common.Component.dCheckBox();
            this.cbxThu = new SISCO.Presentation.Common.Component.dCheckBox();
            this.cbxFri = new SISCO.Presentation.Common.Component.dCheckBox();
            this.cbxSat = new SISCO.Presentation.Common.Component.dCheckBox();
            this.cbxSun = new SISCO.Presentation.Common.Component.dCheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxCustomer = new SISCO.Presentation.Common.Component.dTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).BeginInit();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // MainContainer
            // 
            // 
            // MainContainer.Panel1
            // 
            this.MainContainer.Panel1.Controls.Add(this.tbxCustomer);
            this.MainContainer.Panel1.Controls.Add(this.label4);
            this.MainContainer.Panel1.Controls.Add(this.label3);
            this.MainContainer.Panel1.Controls.Add(this.cbxSun);
            this.MainContainer.Panel1.Controls.Add(this.cbxSat);
            this.MainContainer.Panel1.Controls.Add(this.cbxFri);
            this.MainContainer.Panel1.Controls.Add(this.cbxThu);
            this.MainContainer.Panel1.Controls.Add(this.cbxWed);
            this.MainContainer.Panel1.Controls.Add(this.cbxTue);
            this.MainContainer.Panel1.Controls.Add(this.cbxMon);
            this.MainContainer.Panel1.Controls.Add(this.cbxActive);
            this.MainContainer.Panel1.Controls.Add(this.lkpCustomer);
            this.MainContainer.Panel1.Controls.Add(this.label2);
            this.MainContainer.Size = new System.Drawing.Size(883, 403);
            this.MainContainer.SplitterDistance = 243;
            // 
            // tbxCode
            // 
            this.tbxCode.Size = new System.Drawing.Size(195, 24);
            this.tbxCode.TabIndex = 0;
            this.tbxCode.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(194, 310);
            this.btnClear.TabIndex = 11;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(120, 310);
            this.btnFilter.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Customer";
            // 
            // lkpCustomer
            // 
            this.lkpCustomer.AutoCompleteDataManager = null;
            this.lkpCustomer.AutoCompleteDisplayFormater = null;
            this.lkpCustomer.AutoCompleteInitialized = false;
            this.lkpCustomer.AutocompleteMinimumTextLength = 0;
            this.lkpCustomer.AutoCompleteText = null;
            this.lkpCustomer.AutoCompleteWhereExpression = null;
            this.lkpCustomer.AutoCompleteWheretermFormater = null;
            this.lkpCustomer.ClearOnLeave = true;
            this.lkpCustomer.DisplayString = null;
            this.lkpCustomer.FieldLabel = null;
            this.lkpCustomer.Location = new System.Drawing.Point(80, 68);
            this.lkpCustomer.LookupPopup = null;
            this.lkpCustomer.Name = "lkpCustomer";
            this.lkpCustomer.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpCustomer.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpCustomer.Properties.Appearance.Options.UseFont = true;
            this.lkpCustomer.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpCustomer.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpCustomer.Properties.AutoCompleteDataManager = null;
            this.lkpCustomer.Properties.AutoCompleteDisplayFormater = null;
            this.lkpCustomer.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpCustomer.Properties.AutoCompleteText = null;
            this.lkpCustomer.Properties.AutoCompleteWhereExpression = null;
            this.lkpCustomer.Properties.AutoCompleteWheretermFormater = null;
            this.lkpCustomer.Properties.AutoHeight = false;
            this.lkpCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpCustomer.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpCustomer.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpCustomer.Properties.LookupPopup = null;
            this.lkpCustomer.Properties.NullText = "<<Choose...>>";
            this.lkpCustomer.Size = new System.Drawing.Size(147, 24);
            this.lkpCustomer.TabIndex = 1;
            this.lkpCustomer.ValidationRules = null;
            this.lkpCustomer.Value = null;
            // 
            // cbxActive
            // 
            this.cbxActive.AutoSize = true;
            this.cbxActive.FieldLabel = null;
            this.cbxActive.Location = new System.Drawing.Point(17, 150);
            this.cbxActive.Name = "cbxActive";
            this.cbxActive.Size = new System.Drawing.Size(58, 21);
            this.cbxActive.TabIndex = 3;
            this.cbxActive.Text = "Aktif?";
            this.cbxActive.UseVisualStyleBackColor = true;
            this.cbxActive.ValidationRules = null;
            // 
            // cbxMon
            // 
            this.cbxMon.AutoSize = true;
            this.cbxMon.FieldLabel = null;
            this.cbxMon.Location = new System.Drawing.Point(17, 200);
            this.cbxMon.Name = "cbxMon";
            this.cbxMon.Size = new System.Drawing.Size(57, 21);
            this.cbxMon.TabIndex = 0;
            this.cbxMon.Text = "Senin";
            this.cbxMon.UseVisualStyleBackColor = true;
            this.cbxMon.ValidationRules = null;
            // 
            // cbxTue
            // 
            this.cbxTue.AutoSize = true;
            this.cbxTue.FieldLabel = null;
            this.cbxTue.Location = new System.Drawing.Point(83, 200);
            this.cbxTue.Name = "cbxTue";
            this.cbxTue.Size = new System.Drawing.Size(60, 21);
            this.cbxTue.TabIndex = 0;
            this.cbxTue.Text = "Selasa";
            this.cbxTue.UseVisualStyleBackColor = true;
            this.cbxTue.ValidationRules = null;
            // 
            // cbxWed
            // 
            this.cbxWed.AutoSize = true;
            this.cbxWed.FieldLabel = null;
            this.cbxWed.Location = new System.Drawing.Point(144, 200);
            this.cbxWed.Name = "cbxWed";
            this.cbxWed.Size = new System.Drawing.Size(55, 21);
            this.cbxWed.TabIndex = 0;
            this.cbxWed.Text = "Rabu";
            this.cbxWed.UseVisualStyleBackColor = true;
            this.cbxWed.ValidationRules = null;
            // 
            // cbxThu
            // 
            this.cbxThu.AutoSize = true;
            this.cbxThu.FieldLabel = null;
            this.cbxThu.Location = new System.Drawing.Point(17, 227);
            this.cbxThu.Name = "cbxThu";
            this.cbxThu.Size = new System.Drawing.Size(59, 21);
            this.cbxThu.TabIndex = 0;
            this.cbxThu.Text = "Kamis";
            this.cbxThu.UseVisualStyleBackColor = true;
            this.cbxThu.ValidationRules = null;
            // 
            // cbxFri
            // 
            this.cbxFri.AutoSize = true;
            this.cbxFri.FieldLabel = null;
            this.cbxFri.Location = new System.Drawing.Point(83, 227);
            this.cbxFri.Name = "cbxFri";
            this.cbxFri.Size = new System.Drawing.Size(60, 21);
            this.cbxFri.TabIndex = 0;
            this.cbxFri.Text = "Jumat";
            this.cbxFri.UseVisualStyleBackColor = true;
            this.cbxFri.ValidationRules = null;
            // 
            // cbxSat
            // 
            this.cbxSat.AutoSize = true;
            this.cbxSat.FieldLabel = null;
            this.cbxSat.Location = new System.Drawing.Point(144, 227);
            this.cbxSat.Name = "cbxSat";
            this.cbxSat.Size = new System.Drawing.Size(58, 21);
            this.cbxSat.TabIndex = 0;
            this.cbxSat.Text = "Sabtu";
            this.cbxSat.UseVisualStyleBackColor = true;
            this.cbxSat.ValidationRules = null;
            // 
            // cbxSun
            // 
            this.cbxSun.AutoSize = true;
            this.cbxSun.FieldLabel = null;
            this.cbxSun.Location = new System.Drawing.Point(17, 254);
            this.cbxSun.Name = "cbxSun";
            this.cbxSun.Size = new System.Drawing.Size(67, 21);
            this.cbxSun.TabIndex = 0;
            this.cbxSun.Text = "Minggu";
            this.cbxSun.UseVisualStyleBackColor = true;
            this.cbxSun.ValidationRules = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Jadwal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Customer Baru";
            // 
            // tbxCustomer
            // 
            this.tbxCustomer.Capslock = true;
            this.tbxCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxCustomer.FieldLabel = null;
            this.tbxCustomer.Location = new System.Drawing.Point(31, 118);
            this.tbxCustomer.Name = "tbxCustomer";
            this.tbxCustomer.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxCustomer.Size = new System.Drawing.Size(196, 24);
            this.tbxCustomer.TabIndex = 2;
            this.tbxCustomer.ValidationRules = null;
            // 
            // SchedulerPopup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(883, 403);
            this.Name = "SchedulerPopup";
            this.SelectedText = "";
            this.Text = "Filter Scheduler";
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).EndInit();
            this.MainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Common.Component.dLookup lkpCustomer;
        private System.Windows.Forms.Label label2;
        private Common.Component.dCheckBox cbxSun;
        private Common.Component.dCheckBox cbxSat;
        private Common.Component.dCheckBox cbxFri;
        private Common.Component.dCheckBox cbxThu;
        private Common.Component.dCheckBox cbxWed;
        private Common.Component.dCheckBox cbxTue;
        private Common.Component.dCheckBox cbxMon;
        private Common.Component.dCheckBox cbxActive;
        private System.Windows.Forms.Label label3;
        private Common.Component.dTextBox tbxCustomer;
        private System.Windows.Forms.Label label4;

    }
}