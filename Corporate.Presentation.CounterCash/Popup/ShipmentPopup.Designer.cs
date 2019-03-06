namespace Corporate.Presentation.CounterCash.Popup
{
    partial class ShipmentPopup
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShipmentPopup));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxTo = new Corporate.Presentation.Common.Component.dCalendar();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxDestination = new Corporate.Presentation.Common.Component.dLookupC();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxCustomer = new Corporate.Presentation.Common.Component.dLookupC();
            this.tbxFrom = new Corporate.Presentation.Common.Component.dCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).BeginInit();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDestination.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // MainContainer
            // 
            // 
            // MainContainer.Panel1
            // 
            this.MainContainer.Panel1.Controls.Add(this.tbxFrom);
            this.MainContainer.Panel1.Controls.Add(this.tbxCustomer);
            this.MainContainer.Panel1.Controls.Add(this.label8);
            this.MainContainer.Panel1.Controls.Add(this.tbxDestination);
            this.MainContainer.Panel1.Controls.Add(this.label7);
            this.MainContainer.Panel1.Controls.Add(this.tbxTo);
            this.MainContainer.Panel1.Controls.Add(this.label6);
            this.MainContainer.Panel1.Controls.Add(this.label5);
            this.MainContainer.Panel1.Controls.Add(this.label3);
            this.MainContainer.Panel1.Controls.Add(this.label2);
            this.MainContainer.Size = new System.Drawing.Size(664, 374);
            this.MainContainer.SplitterDistance = 157;
            // 
            // tbxCode
            // 
            this.tbxCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxCode.Size = new System.Drawing.Size(83, 24);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Location = new System.Drawing.Point(83, 329);
            this.btnClear.Size = new System.Drawing.Size(63, 35);
            this.btnClear.TabIndex = 0;
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFilter.Location = new System.Drawing.Point(14, 329);
            this.btnFilter.Size = new System.Drawing.Size(63, 35);
            this.btnFilter.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Options";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date Between";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "From";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "To";
            // 
            // tbxTo
            // 
            this.tbxTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxTo.EditValue = null;
            this.tbxTo.FieldLabel = null;
            this.tbxTo.FormatDateTime = "dd-MM-yyyy";
            this.tbxTo.Location = new System.Drawing.Point(71, 141);
            this.tbxTo.Name = "tbxTo";
            this.tbxTo.Nullable = true;
            this.tbxTo.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTo.Properties.AutoHeight = false;
            this.tbxTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxTo.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.tbxTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxTo.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxTo.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxTo.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxTo.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxTo.Properties.NullText = "<<Choose...>>";
            this.tbxTo.Size = new System.Drawing.Size(74, 24);
            this.tbxTo.TabIndex = 3;
            this.tbxTo.ValidationRules = null;
            this.tbxTo.Value = new System.DateTime(((long)(0)));
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Destination";
            // 
            // tbxDestination
            // 
            this.tbxDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxDestination.AutoCompleteDataManager = null;
            this.tbxDestination.AutoCompleteDisplayFormater = null;
            this.tbxDestination.AutoCompleteInitialized = false;
            this.tbxDestination.AutocompleteMinimumTextLength = 0;
            this.tbxDestination.AutoCompleteText = null;
            this.tbxDestination.AutoCompleteWhereExpression = null;
            this.tbxDestination.AutoCompleteWheretermFormater = null;
            this.tbxDestination.ClearOnLeave = true;
            this.tbxDestination.DisplayString = null;
            this.tbxDestination.FieldLabel = null;
            this.tbxDestination.Location = new System.Drawing.Point(32, 194);
            this.tbxDestination.LookupPopup = null;
            this.tbxDestination.Name = "tbxDestination";
            this.tbxDestination.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDestination.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxDestination.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxDestination.Properties.AutoCompleteDataManager = null;
            this.tbxDestination.Properties.AutoCompleteDisplayFormater = null;
            this.tbxDestination.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxDestination.Properties.AutoCompleteText = null;
            this.tbxDestination.Properties.AutoCompleteWhereExpression = null;
            this.tbxDestination.Properties.AutoCompleteWheretermFormater = null;
            this.tbxDestination.Properties.AutoHeight = false;
            this.tbxDestination.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxDestination.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxDestination.Properties.LookupPopup = null;
            this.tbxDestination.Properties.NullText = "<<Choose...>>";
            this.tbxDestination.Size = new System.Drawing.Size(113, 24);
            this.tbxDestination.TabIndex = 5;
            this.tbxDestination.ValidationRules = null;
            this.tbxDestination.Value = null;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Customer";
            // 
            // tbxCustomer
            // 
            this.tbxCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxCustomer.AutoCompleteDataManager = null;
            this.tbxCustomer.AutoCompleteDisplayFormater = null;
            this.tbxCustomer.AutoCompleteInitialized = false;
            this.tbxCustomer.AutocompleteMinimumTextLength = 0;
            this.tbxCustomer.AutoCompleteText = null;
            this.tbxCustomer.AutoCompleteWhereExpression = null;
            this.tbxCustomer.AutoCompleteWheretermFormater = null;
            this.tbxCustomer.ClearOnLeave = true;
            this.tbxCustomer.DisplayString = null;
            this.tbxCustomer.FieldLabel = null;
            this.tbxCustomer.Location = new System.Drawing.Point(32, 244);
            this.tbxCustomer.LookupPopup = null;
            this.tbxCustomer.Name = "tbxCustomer";
            this.tbxCustomer.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxCustomer.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxCustomer.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxCustomer.Properties.AutoCompleteDataManager = null;
            this.tbxCustomer.Properties.AutoCompleteDisplayFormater = null;
            this.tbxCustomer.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxCustomer.Properties.AutoCompleteText = null;
            this.tbxCustomer.Properties.AutoCompleteWhereExpression = null;
            this.tbxCustomer.Properties.AutoCompleteWheretermFormater = null;
            this.tbxCustomer.Properties.AutoHeight = false;
            this.tbxCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxCustomer.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.tbxCustomer.Properties.LookupPopup = null;
            this.tbxCustomer.Properties.NullText = "<<Choose...>>";
            this.tbxCustomer.Size = new System.Drawing.Size(113, 24);
            this.tbxCustomer.TabIndex = 6;
            this.tbxCustomer.ValidationRules = null;
            this.tbxCustomer.Value = null;
            // 
            // tbxFrom
            // 
            this.tbxFrom.EditValue = null;
            this.tbxFrom.FieldLabel = null;
            this.tbxFrom.FormatDateTime = "dd-MM-yyyy";
            this.tbxFrom.Location = new System.Drawing.Point(71, 114);
            this.tbxFrom.Name = "tbxFrom";
            this.tbxFrom.Nullable = true;
            this.tbxFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFrom.Properties.AutoHeight = false;
            this.tbxFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxFrom.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.tbxFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxFrom.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxFrom.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxFrom.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxFrom.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxFrom.Properties.NullText = "<<Choose...>>";
            this.tbxFrom.Size = new System.Drawing.Size(74, 24);
            this.tbxFrom.TabIndex = 2;
            this.tbxFrom.ValidationRules = null;
            this.tbxFrom.Value = new System.DateTime(((long)(0)));
            // 
            // ShipmentPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 374);
            this.Name = "ShipmentPopup";
            this.SelectedText = "";
            this.Text = "Filter - Data Entry";
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).EndInit();
            this.MainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDestination.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private Common.Component.dLookupC tbxCustomer;
        private System.Windows.Forms.Label label8;
        private Common.Component.dLookupC tbxDestination;
        private System.Windows.Forms.Label label7;
        private Common.Component.dCalendar tbxTo;
        private Common.Component.dCalendar tbxFrom;
    }
}