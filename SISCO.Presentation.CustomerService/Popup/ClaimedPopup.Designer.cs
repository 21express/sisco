namespace SISCO.Presentation.CustomerService.Popup
{
    partial class ClaimedPopup
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClaimedPopup));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxFrom = new SISCO.Presentation.Common.Component.dCalendar();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxCustomer = new SISCO.Presentation.Common.Component.dTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lkpBranch = new SISCO.Presentation.Common.Component.dLookup();
            this.tbxTo = new SISCO.Presentation.Common.Component.dCalendar();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxPod = new SISCO.Presentation.Common.Component.dTextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).BeginInit();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // MainContainer
            // 
            // 
            // MainContainer.Panel1
            // 
            this.MainContainer.Panel1.Controls.Add(this.tbxPod);
            this.MainContainer.Panel1.Controls.Add(this.label6);
            this.MainContainer.Panel1.Controls.Add(this.tbxTo);
            this.MainContainer.Panel1.Controls.Add(this.label5);
            this.MainContainer.Panel1.Controls.Add(this.lkpBranch);
            this.MainContainer.Panel1.Controls.Add(this.label4);
            this.MainContainer.Panel1.Controls.Add(this.tbxCustomer);
            this.MainContainer.Panel1.Controls.Add(this.label3);
            this.MainContainer.Panel1.Controls.Add(this.tbxFrom);
            this.MainContainer.Panel1.Controls.Add(this.label2);
            this.MainContainer.Size = new System.Drawing.Size(756, 312);
            this.MainContainer.SplitterDistance = 232;
            // 
            // tbxCode
            // 
            this.tbxCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxCode.Location = new System.Drawing.Point(76, 43);
            this.tbxCode.Size = new System.Drawing.Size(141, 24);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(148, 266);
            this.btnClear.TabIndex = 8;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(74, 266);
            this.btnFilter.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.Text = "No Surat";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tanggal";
            // 
            // tbxFrom
            // 
            this.tbxFrom.EditValue = null;
            this.tbxFrom.FieldLabel = null;
            this.tbxFrom.FormatDateTime = "dd-MM-yyyy";
            this.tbxFrom.Location = new System.Drawing.Point(76, 157);
            this.tbxFrom.Name = "tbxFrom";
            this.tbxFrom.Nullable = false;
            this.tbxFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFrom.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxFrom.Properties.Appearance.Options.UseFont = true;
            this.tbxFrom.Properties.AutoHeight = false;
            this.tbxFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxFrom.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.tbxFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxFrom.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxFrom.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxFrom.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxFrom.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxFrom.Size = new System.Drawing.Size(141, 24);
            this.tbxFrom.TabIndex = 4;
            this.tbxFrom.ValidationRules = null;
            this.tbxFrom.Value = new System.DateTime(((long)(0)));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Customer";
            // 
            // tbxCustomer
            // 
            this.tbxCustomer.Capslock = true;
            this.tbxCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxCustomer.FieldLabel = null;
            this.tbxCustomer.Location = new System.Drawing.Point(76, 69);
            this.tbxCustomer.Name = "tbxCustomer";
            this.tbxCustomer.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxCustomer.Size = new System.Drawing.Size(141, 24);
            this.tbxCustomer.TabIndex = 2;
            this.tbxCustomer.ValidationRules = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Customer Cabang";
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
            this.lkpBranch.FieldLabel = null;
            this.lkpBranch.Location = new System.Drawing.Point(33, 120);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.lkpBranch.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpBranch.Properties.LookupPopup = null;
            this.lkpBranch.Properties.NullText = "<<Choose...>>";
            this.lkpBranch.Size = new System.Drawing.Size(184, 24);
            this.lkpBranch.TabIndex = 3;
            this.lkpBranch.ValidationRules = null;
            this.lkpBranch.Value = null;
            // 
            // tbxTo
            // 
            this.tbxTo.EditValue = null;
            this.tbxTo.FieldLabel = null;
            this.tbxTo.FormatDateTime = "dd-MM-yyyy";
            this.tbxTo.Location = new System.Drawing.Point(76, 183);
            this.tbxTo.Name = "tbxTo";
            this.tbxTo.Nullable = false;
            this.tbxTo.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTo.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTo.Properties.Appearance.Options.UseFont = true;
            this.tbxTo.Properties.AutoHeight = false;
            this.tbxTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxTo.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxTo.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxTo.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxTo.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxTo.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxTo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTo.Size = new System.Drawing.Size(141, 24);
            this.tbxTo.TabIndex = 5;
            this.tbxTo.ValidationRules = null;
            this.tbxTo.Value = new System.DateTime(((long)(0)));
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "s.d";
            // 
            // tbxPod
            // 
            this.tbxPod.Capslock = true;
            this.tbxPod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxPod.FieldLabel = null;
            this.tbxPod.Location = new System.Drawing.Point(76, 215);
            this.tbxPod.Name = "tbxPod";
            this.tbxPod.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPod.Size = new System.Drawing.Size(141, 24);
            this.tbxPod.TabIndex = 6;
            this.tbxPod.ValidationRules = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "POD";
            // 
            // ClaimedPopup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(756, 312);
            this.Name = "ClaimedPopup";
            this.SelectedText = "";
            this.Text = "Claimed Search";
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).EndInit();
            this.MainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Common.Component.dCalendar tbxTo;
        private System.Windows.Forms.Label label5;
        private Common.Component.dLookup lkpBranch;
        private System.Windows.Forms.Label label4;
        private Common.Component.dTextBox tbxCustomer;
        private System.Windows.Forms.Label label3;
        private Common.Component.dCalendar tbxFrom;
        private System.Windows.Forms.Label label2;
        private Common.Component.dTextBox tbxPod;
        private System.Windows.Forms.Label label6;
    }
}