namespace SISCO.Presentation.Operation.Popup
{
    partial class DeliveryOrderFilterPopup
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryOrderFilterPopup));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxFrom = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.tbxTo = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxKurir = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.tbxKendaraan = new SISCO.Presentation.Common.Component.dLookup(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).BeginInit();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxKurir.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxKendaraan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // MainContainer
            // 
            // 
            // MainContainer.Panel1
            // 
            this.MainContainer.Panel1.Controls.Add(this.tbxKendaraan);
            this.MainContainer.Panel1.Controls.Add(this.tbxKurir);
            this.MainContainer.Panel1.Controls.Add(this.label7);
            this.MainContainer.Panel1.Controls.Add(this.label6);
            this.MainContainer.Panel1.Controls.Add(this.tbxTo);
            this.MainContainer.Panel1.Controls.Add(this.tbxFrom);
            this.MainContainer.Panel1.Controls.Add(this.label5);
            this.MainContainer.Panel1.Controls.Add(this.label4);
            this.MainContainer.Panel1.Controls.Add(this.label3);
            this.MainContainer.Panel1.Controls.Add(this.label2);
            // 
            // btnClear
            // 
            this.btnClear.TabIndex = 0;
            // 
            // btnFilter
            // 
            this.btnFilter.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Options";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date Between";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "From";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "To";
            // 
            // tbxFrom
            // 
            this.tbxFrom.EditValue = null;
            this.tbxFrom.FieldLabel = null;
            this.tbxFrom.FormatDateTime = "dd-MM-yyyy";
            this.tbxFrom.Location = new System.Drawing.Point(71, 109);
            this.tbxFrom.Name = "tbxFrom";
            this.tbxFrom.Nullable = false;
            this.tbxFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFrom.Properties.AutoHeight = false;
            this.tbxFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dCalendar1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
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
            this.tbxTo.Location = new System.Drawing.Point(71, 135);
            this.tbxTo.Name = "tbxTo";
            this.tbxTo.Nullable = false;
            this.tbxTo.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTo.Properties.AutoHeight = false;
            this.tbxTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dCalendar2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Kurir";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Kendaraan";
            // 
            // tbxKurir
            // 
            this.tbxKurir.AutoCompleteDataManager = null;
            this.tbxKurir.AutoCompleteDisplayFormater = null;
            this.tbxKurir.AutoCompleteInitialized = false;
            this.tbxKurir.AutocompleteMinimumTextLength = 0;
            this.tbxKurir.AutoCompleteText = null;
            this.tbxKurir.AutoCompleteWhereExpression = null;
            this.tbxKurir.AutoCompleteWheretermFormater = null;
            this.tbxKurir.ClearOnLeave = true;
            this.tbxKurir.DisplayString = null;
            this.tbxKurir.FieldLabel = null;
            this.tbxKurir.Location = new System.Drawing.Point(33, 184);
            this.tbxKurir.LookupPopup = null;
            this.tbxKurir.Name = "tbxKurir";
            this.tbxKurir.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxKurir.Properties.AutoCompleteDataManager = null;
            this.tbxKurir.Properties.AutoCompleteDisplayFormater = null;
            this.tbxKurir.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxKurir.Properties.AutoCompleteText = null;
            this.tbxKurir.Properties.AutoCompleteWhereExpression = null;
            this.tbxKurir.Properties.AutoCompleteWheretermFormater = null;
            this.tbxKurir.Properties.AutoHeight = false;
            this.tbxKurir.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dLookup1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxKurir.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxKurir.Properties.LookupPopup = null;
            this.tbxKurir.Properties.NullText = "<<Choose...>>";
            this.tbxKurir.Size = new System.Drawing.Size(138, 24);
            this.tbxKurir.TabIndex = 4;
            this.tbxKurir.ValidationRules = null;
            this.tbxKurir.Value = null;
            // 
            // tbxKendaraan
            // 
            this.tbxKendaraan.AutoCompleteDataManager = null;
            this.tbxKendaraan.AutoCompleteDisplayFormater = null;
            this.tbxKendaraan.AutoCompleteInitialized = false;
            this.tbxKendaraan.AutocompleteMinimumTextLength = 0;
            this.tbxKendaraan.AutoCompleteText = null;
            this.tbxKendaraan.AutoCompleteWhereExpression = null;
            this.tbxKendaraan.AutoCompleteWheretermFormater = null;
            this.tbxKendaraan.ClearOnLeave = true;
            this.tbxKendaraan.DisplayString = null;
            this.tbxKendaraan.FieldLabel = null;
            this.tbxKendaraan.Location = new System.Drawing.Point(33, 234);
            this.tbxKendaraan.LookupPopup = null;
            this.tbxKendaraan.Name = "tbxKendaraan";
            this.tbxKendaraan.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxKendaraan.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxKendaraan.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxKendaraan.Properties.AutoCompleteDataManager = null;
            this.tbxKendaraan.Properties.AutoCompleteDisplayFormater = null;
            this.tbxKendaraan.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxKendaraan.Properties.AutoCompleteText = null;
            this.tbxKendaraan.Properties.AutoCompleteWhereExpression = null;
            this.tbxKendaraan.Properties.AutoCompleteWheretermFormater = null;
            this.tbxKendaraan.Properties.AutoHeight = false;
            this.tbxKendaraan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dLookup2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.tbxKendaraan.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxKendaraan.Properties.LookupPopup = null;
            this.tbxKendaraan.Properties.NullText = "<<Choose...>>";
            this.tbxKendaraan.Size = new System.Drawing.Size(138, 24);
            this.tbxKendaraan.TabIndex = 5;
            this.tbxKendaraan.ValidationRules = null;
            this.tbxKendaraan.Value = null;
            // 
            // DeliveryOrderFilterPopup
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 344);
            this.Name = "DeliveryOrderFilterPopup";
            this.SelectedText = "";
            this.Text = "DeliveryOrderFilterPopup";
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).EndInit();
            this.MainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxKurir.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxKendaraan.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private Common.Component.dLookup tbxKendaraan;
        private Common.Component.dLookup tbxKurir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Common.Component.dCalendar tbxTo;
        private Common.Component.dCalendar tbxFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}