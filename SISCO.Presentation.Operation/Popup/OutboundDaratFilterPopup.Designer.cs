﻿namespace SISCO.Presentation.Operation.Popup
{
    partial class OutboundDaratFilterPopup
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutboundDaratFilterPopup));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxFrom = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.tbxTo = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.tbxBranch = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.tbxPengangkut = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.tbxDriver = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).BeginInit();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxBranch.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // MainContainer
            // 
            // 
            // MainContainer.Panel1
            // 
            this.MainContainer.Panel1.Controls.Add(this.tbxDriver);
            this.MainContainer.Panel1.Controls.Add(this.label8);
            this.MainContainer.Panel1.Controls.Add(this.tbxPengangkut);
            this.MainContainer.Panel1.Controls.Add(this.label7);
            this.MainContainer.Panel1.Controls.Add(this.tbxBranch);
            this.MainContainer.Panel1.Controls.Add(this.label6);
            this.MainContainer.Panel1.Controls.Add(this.tbxTo);
            this.MainContainer.Panel1.Controls.Add(this.label5);
            this.MainContainer.Panel1.Controls.Add(this.tbxFrom);
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
            this.btnFilter.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Options";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date Between";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 106);
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
            this.tbxFrom.Location = new System.Drawing.Point(71, 103);
            this.tbxFrom.Name = "tbxFrom";
            this.tbxFrom.Nullable = false;
            this.tbxFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFrom.Properties.AutoHeight = false;
            this.tbxFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxFrom.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
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
            this.tbxFrom.Size = new System.Drawing.Size(100, 24);
            this.tbxFrom.TabIndex = 2;
            this.tbxFrom.ValidationRules = null;
            this.tbxFrom.Value = new System.DateTime(((long)(0)));
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "To";
            // 
            // tbxTo
            // 
            this.tbxTo.EditValue = null;
            this.tbxTo.FieldLabel = null;
            this.tbxTo.FormatDateTime = "dd-MM-yyyy";
            this.tbxTo.Location = new System.Drawing.Point(71, 128);
            this.tbxTo.Name = "tbxTo";
            this.tbxTo.Nullable = false;
            this.tbxTo.OriginalBackColor = System.Drawing.Color.Empty;
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
            this.tbxTo.Properties.NullText = "<<Choose...>>";
            this.tbxTo.Size = new System.Drawing.Size(100, 24);
            this.tbxTo.TabIndex = 3;
            this.tbxTo.ValidationRules = null;
            this.tbxTo.Value = new System.DateTime(((long)(0)));
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Branch";
            // 
            // tbxBranch
            // 
            this.tbxBranch.AutoCompleteDataManager = null;
            this.tbxBranch.AutoCompleteDisplayFormater = null;
            this.tbxBranch.AutoCompleteInitialized = false;
            this.tbxBranch.AutocompleteMinimumTextLength = 0;
            this.tbxBranch.AutoCompleteText = null;
            this.tbxBranch.AutoCompleteWhereExpression = null;
            this.tbxBranch.AutoCompleteWheretermFormater = null;
            this.tbxBranch.ClearOnLeave = true;
            this.tbxBranch.DisplayString = null;
            this.tbxBranch.FieldLabel = null;
            this.tbxBranch.Location = new System.Drawing.Point(33, 180);
            this.tbxBranch.LookupPopup = null;
            this.tbxBranch.Name = "tbxBranch";
            this.tbxBranch.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxBranch.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxBranch.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxBranch.Properties.AutoCompleteDataManager = null;
            this.tbxBranch.Properties.AutoCompleteDisplayFormater = null;
            this.tbxBranch.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxBranch.Properties.AutoCompleteText = null;
            this.tbxBranch.Properties.AutoCompleteWhereExpression = null;
            this.tbxBranch.Properties.AutoCompleteWheretermFormater = null;
            this.tbxBranch.Properties.AutoHeight = false;
            this.tbxBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.tbxBranch.Properties.LookupPopup = null;
            this.tbxBranch.Properties.NullText = "<<Choose...>>";
            this.tbxBranch.Size = new System.Drawing.Size(138, 24);
            this.tbxBranch.TabIndex = 4;
            this.tbxBranch.ValidationRules = null;
            this.tbxBranch.Value = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Pengangkut";
            // 
            // tbxPengangkut
            // 
            this.tbxPengangkut.Capslock = true;
            this.tbxPengangkut.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxPengangkut.FieldLabel = null;
            this.tbxPengangkut.Location = new System.Drawing.Point(33, 228);
            this.tbxPengangkut.Name = "tbxPengangkut";
            this.tbxPengangkut.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPengangkut.Size = new System.Drawing.Size(138, 24);
            this.tbxPengangkut.TabIndex = 5;
            this.tbxPengangkut.ValidationRules = null;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Driver";
            // 
            // tbxDriver
            // 
            this.tbxDriver.Capslock = true;
            this.tbxDriver.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDriver.FieldLabel = null;
            this.tbxDriver.Location = new System.Drawing.Point(33, 276);
            this.tbxDriver.Name = "tbxDriver";
            this.tbxDriver.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDriver.Size = new System.Drawing.Size(138, 24);
            this.tbxDriver.TabIndex = 6;
            this.tbxDriver.ValidationRules = null;
            // 
            // OutboundDaratFilterPopup
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 344);
            this.Name = "OutboundDaratFilterPopup";
            this.SelectedText = "";
            this.Text = "Filter - Outbound Darat";
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).EndInit();
            this.MainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxBranch.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Common.Component.dCalendar tbxTo;
        private System.Windows.Forms.Label label5;
        private Common.Component.dCalendar tbxFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Common.Component.dLookup tbxBranch;
        private System.Windows.Forms.Label label6;
        private Common.Component.dTextBox tbxDriver;
        private System.Windows.Forms.Label label8;
        private Common.Component.dTextBox tbxPengangkut;
        private System.Windows.Forms.Label label7;
    }
}