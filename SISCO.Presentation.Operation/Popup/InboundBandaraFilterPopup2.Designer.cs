namespace SISCO.Presentation.Operation.Popup
{
    partial class InboundBandaraFilterPopup
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InboundBandaraFilterPopup));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxFrom = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.tbxTo = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxAirline = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.tbxOrigin = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.tbxDest = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).BeginInit();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAirline.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxOrigin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDest.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // MainContainer
            // 
            // 
            // MainContainer.Panel1
            // 
            this.MainContainer.Panel1.Controls.Add(this.tbxDest);
            this.MainContainer.Panel1.Controls.Add(this.label8);
            this.MainContainer.Panel1.Controls.Add(this.tbxOrigin);
            this.MainContainer.Panel1.Controls.Add(this.label7);
            this.MainContainer.Panel1.Controls.Add(this.tbxAirline);
            this.MainContainer.Panel1.Controls.Add(this.label6);
            this.MainContainer.Panel1.Controls.Add(this.tbxTo);
            this.MainContainer.Panel1.Controls.Add(this.label5);
            this.MainContainer.Panel1.Controls.Add(this.tbxFrom);
            this.MainContainer.Panel1.Controls.Add(this.label4);
            this.MainContainer.Panel1.Controls.Add(this.label3);
            this.MainContainer.Panel1.Controls.Add(this.label2);
            this.MainContainer.Size = new System.Drawing.Size(664, 360);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(113, 324);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(50, 324);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Options";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date Between";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "From";
            // 
            // tbxFrom
            // 
            this.tbxFrom.EditValue = null;
            this.tbxFrom.FieldLabel = null;
            this.tbxFrom.FormatDateTime = "dd-MM-yyyy";
            this.tbxFrom.Location = new System.Drawing.Point(71, 106);
            this.tbxFrom.Name = "tbxFrom";
            this.tbxFrom.Nullable = false;
            this.tbxFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFrom.Properties.AutoHeight = false;
            this.tbxFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dCalendar1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
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
            this.tbxFrom.Size = new System.Drawing.Size(100, 24);
            this.tbxFrom.TabIndex = 2;
            this.tbxFrom.ValidationRules = null;
            this.tbxFrom.Value = new System.DateTime(((long)(0)));
            // 
            // tbxTo
            // 
            this.tbxTo.EditValue = null;
            this.tbxTo.FieldLabel = null;
            this.tbxTo.FormatDateTime = "dd-MM-yyyy";
            this.tbxTo.Location = new System.Drawing.Point(71, 133);
            this.tbxTo.Name = "tbxTo";
            this.tbxTo.Nullable = false;
            this.tbxTo.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTo.Properties.AutoHeight = false;
            this.tbxTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dCalendar2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
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
            this.tbxTo.Size = new System.Drawing.Size(100, 24);
            this.tbxTo.TabIndex = 3;
            this.tbxTo.ValidationRules = null;
            this.tbxTo.Value = new System.DateTime(((long)(0)));
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "To";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Airline";
            // 
            // tbxAirline
            // 
            this.tbxAirline.AutoCompleteDataManager = null;
            this.tbxAirline.AutoCompleteDisplayFormater = null;
            this.tbxAirline.AutoCompleteInitialized = false;
            this.tbxAirline.AutocompleteMinimumTextLength = 0;
            this.tbxAirline.AutoCompleteText = null;
            this.tbxAirline.AutoCompleteWhereExpression = null;
            this.tbxAirline.AutoCompleteWheretermFormater = null;
            this.tbxAirline.ClearOnLeave = true;
            this.tbxAirline.DisplayString = null;
            this.tbxAirline.FieldLabel = null;
            this.tbxAirline.Location = new System.Drawing.Point(32, 183);
            this.tbxAirline.LookupPopup = null;
            this.tbxAirline.Name = "tbxAirline";
            this.tbxAirline.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxAirline.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxAirline.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxAirline.Properties.AutoCompleteDataManager = null;
            this.tbxAirline.Properties.AutoCompleteDisplayFormater = null;
            this.tbxAirline.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxAirline.Properties.AutoCompleteText = null;
            this.tbxAirline.Properties.AutoCompleteWhereExpression = null;
            this.tbxAirline.Properties.AutoCompleteWheretermFormater = null;
            this.tbxAirline.Properties.AutoHeight = false;
            this.tbxAirline.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dLookup1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.tbxAirline.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxAirline.Properties.LookupPopup = null;
            this.tbxAirline.Properties.NullText = "<<Choose...>>";
            this.tbxAirline.Size = new System.Drawing.Size(139, 24);
            this.tbxAirline.TabIndex = 4;
            this.tbxAirline.ValidationRules = null;
            this.tbxAirline.Value = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Origin Airport";
            // 
            // tbxOrigin
            // 
            this.tbxOrigin.AutoCompleteDataManager = null;
            this.tbxOrigin.AutoCompleteDisplayFormater = null;
            this.tbxOrigin.AutoCompleteInitialized = false;
            this.tbxOrigin.AutocompleteMinimumTextLength = 0;
            this.tbxOrigin.AutoCompleteText = null;
            this.tbxOrigin.AutoCompleteWhereExpression = null;
            this.tbxOrigin.AutoCompleteWheretermFormater = null;
            this.tbxOrigin.ClearOnLeave = true;
            this.tbxOrigin.DisplayString = null;
            this.tbxOrigin.FieldLabel = null;
            this.tbxOrigin.Location = new System.Drawing.Point(32, 232);
            this.tbxOrigin.LookupPopup = null;
            this.tbxOrigin.Name = "tbxOrigin";
            this.tbxOrigin.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxOrigin.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxOrigin.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxOrigin.Properties.AutoCompleteDataManager = null;
            this.tbxOrigin.Properties.AutoCompleteDisplayFormater = null;
            this.tbxOrigin.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxOrigin.Properties.AutoCompleteText = null;
            this.tbxOrigin.Properties.AutoCompleteWhereExpression = null;
            this.tbxOrigin.Properties.AutoCompleteWheretermFormater = null;
            this.tbxOrigin.Properties.AutoHeight = false;
            this.tbxOrigin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dLookup2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxOrigin.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxOrigin.Properties.LookupPopup = null;
            this.tbxOrigin.Properties.NullText = "<<Choose...>>";
            this.tbxOrigin.Size = new System.Drawing.Size(139, 24);
            this.tbxOrigin.TabIndex = 5;
            this.tbxOrigin.ValidationRules = null;
            this.tbxOrigin.Value = null;
            // 
            // tbxDest
            // 
            this.tbxDest.AutoCompleteDataManager = null;
            this.tbxDest.AutoCompleteDisplayFormater = null;
            this.tbxDest.AutoCompleteInitialized = false;
            this.tbxDest.AutocompleteMinimumTextLength = 0;
            this.tbxDest.AutoCompleteText = null;
            this.tbxDest.AutoCompleteWhereExpression = null;
            this.tbxDest.AutoCompleteWheretermFormater = null;
            this.tbxDest.ClearOnLeave = true;
            this.tbxDest.DisplayString = null;
            this.tbxDest.FieldLabel = null;
            this.tbxDest.Location = new System.Drawing.Point(32, 280);
            this.tbxDest.LookupPopup = null;
            this.tbxDest.Name = "tbxDest";
            this.tbxDest.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDest.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxDest.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxDest.Properties.AutoCompleteDataManager = null;
            this.tbxDest.Properties.AutoCompleteDisplayFormater = null;
            this.tbxDest.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxDest.Properties.AutoCompleteText = null;
            this.tbxDest.Properties.AutoCompleteWhereExpression = null;
            this.tbxDest.Properties.AutoCompleteWheretermFormater = null;
            this.tbxDest.Properties.AutoHeight = false;
            this.tbxDest.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dLookup3.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.tbxDest.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDest.Properties.LookupPopup = null;
            this.tbxDest.Properties.NullText = "<<Choose...>>";
            this.tbxDest.Size = new System.Drawing.Size(139, 24);
            this.tbxDest.TabIndex = 6;
            this.tbxDest.ValidationRules = null;
            this.tbxDest.Value = null;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Dest Airport";
            // 
            // InboundBandaraFilterPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 360);
            this.Name = "InboundBandaraFilterPopup";
            this.SelectedText = "";
            this.Text = "Filter Popup - Inbound Bandara";
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).EndInit();
            this.MainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAirline.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxOrigin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDest.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Common.Component.dCalendar tbxFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private Common.Component.dLookup tbxAirline;
        private System.Windows.Forms.Label label6;
        private Common.Component.dCalendar tbxTo;
        private System.Windows.Forms.Label label5;
        private Common.Component.dLookup tbxDest;
        private System.Windows.Forms.Label label8;
        private Common.Component.dLookup tbxOrigin;
    }
}