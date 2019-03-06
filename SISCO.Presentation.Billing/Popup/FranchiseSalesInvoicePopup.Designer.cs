namespace SISCO.Presentation.Billing.Popup
{
    partial class FranchiseSalesInvoicePopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FranchiseSalesInvoicePopup));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.txtFilterDateFrom = new SISCO.Presentation.Common.Component.dCalendar();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFilterDateTo = new SISCO.Presentation.Common.Component.dCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).BeginInit();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterDateTo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // MainContainer
            // 
            // 
            // MainContainer.Panel1
            // 
            this.MainContainer.Panel1.Controls.Add(this.txtFilterDateFrom);
            this.MainContainer.Panel1.Controls.Add(this.label8);
            this.MainContainer.Panel1.Controls.Add(this.label12);
            this.MainContainer.Panel1.Controls.Add(this.txtFilterDateTo);
            this.MainContainer.Size = new System.Drawing.Size(867, 344);
            this.MainContainer.SplitterDistance = 279;
            // 
            // tbxCode
            // 
            this.tbxCode.Location = new System.Drawing.Point(89, 33);
            this.tbxCode.Size = new System.Drawing.Size(175, 24);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(188, 309);
            this.btnClear.Size = new System.Drawing.Size(76, 29);
            this.btnClear.TabIndex = 0;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(108, 309);
            this.btnFilter.Size = new System.Drawing.Size(74, 29);
            this.btnFilter.TabIndex = 112;
            // 
            // txtFilterDateFrom
            // 
            this.txtFilterDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilterDateFrom.EditValue = null;
            this.txtFilterDateFrom.FieldLabel = null;
            this.txtFilterDateFrom.FormatDateTime = "dd-MM-yyyy";
            this.txtFilterDateFrom.Location = new System.Drawing.Point(89, 68);
            this.txtFilterDateFrom.Name = "txtFilterDateFrom";
            this.txtFilterDateFrom.Nullable = false;
            this.txtFilterDateFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtFilterDateFrom.Properties.AutoHeight = false;
            this.txtFilterDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtFilterDateFrom.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtFilterDateFrom.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtFilterDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFilterDateFrom.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtFilterDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFilterDateFrom.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtFilterDateFrom.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtFilterDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtFilterDateFrom.Size = new System.Drawing.Size(168, 24);
            this.txtFilterDateFrom.TabIndex = 3;
            this.txtFilterDateFrom.ValidationRules = null;
            this.txtFilterDateFrom.Value = new System.DateTime(((long)(0)));
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 145;
            this.label8.Text = "Date From";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(37, 101);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 146;
            this.label12.Text = "Date To";
            // 
            // txtFilterDateTo
            // 
            this.txtFilterDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilterDateTo.EditValue = null;
            this.txtFilterDateTo.FieldLabel = null;
            this.txtFilterDateTo.FormatDateTime = "dd-MM-yyyy";
            this.txtFilterDateTo.Location = new System.Drawing.Point(89, 96);
            this.txtFilterDateTo.Name = "txtFilterDateTo";
            this.txtFilterDateTo.Nullable = false;
            this.txtFilterDateTo.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtFilterDateTo.Properties.AutoHeight = false;
            this.txtFilterDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtFilterDateTo.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.txtFilterDateTo.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtFilterDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFilterDateTo.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtFilterDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFilterDateTo.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtFilterDateTo.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtFilterDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtFilterDateTo.Size = new System.Drawing.Size(168, 24);
            this.txtFilterDateTo.TabIndex = 5;
            this.txtFilterDateTo.ValidationRules = null;
            this.txtFilterDateTo.Value = new System.DateTime(((long)(0)));
            // 
            // FranchiseSalesInvoicePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 344);
            this.Name = "FranchiseSalesInvoicePopup";
            this.SelectedText = "";
            this.Text = "Sales Invoice Popup";
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).EndInit();
            this.MainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterDateTo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Common.Component.dCalendar txtFilterDateFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private Common.Component.dCalendar txtFilterDateTo;
    }
}