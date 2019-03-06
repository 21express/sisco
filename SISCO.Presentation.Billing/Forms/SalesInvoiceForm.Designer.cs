namespace SISCO.Presentation.Billing.Forms
{
    partial class SalesInvoiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesInvoiceForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDueDate = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.txtInvoicedTo = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.lkpCustomer = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.txtReceiptNo = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.txtDate = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDescription3 = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.txtDescription2 = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.txtDescription1 = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTaxInvoice = new SISCO.Presentation.Common.Component.dComboBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDueDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDueDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cmbTaxInvoice);
            this.panel1.Controls.Add(this.txtDueDate);
            this.panel1.Controls.Add(this.txtInvoicedTo);
            this.panel1.Controls.Add(this.lkpCustomer);
            this.panel1.Controls.Add(this.txtReceiptNo);
            this.panel1.Controls.Add(this.txtDate);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(728, 164);
            this.panel1.TabIndex = 1;
            // 
            // txtDueDate
            // 
            this.txtDueDate.EditValue = null;
            this.txtDueDate.FieldLabel = null;
            this.txtDueDate.FormatDateTime = "dd-MM-yyyy";
            this.txtDueDate.Location = new System.Drawing.Point(134, 105);
            this.txtDueDate.Name = "txtDueDate";
            this.txtDueDate.Nullable = false;
            this.txtDueDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDueDate.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.txtDueDate.Properties.Appearance.Options.UseFont = true;
            this.txtDueDate.Properties.AutoHeight = false;
            this.txtDueDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtDueDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.txtDueDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDueDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtDueDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDueDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtDueDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDueDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtDueDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtDueDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDueDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDueDate.Size = new System.Drawing.Size(119, 24);
            this.txtDueDate.TabIndex = 5;
            this.txtDueDate.ValidationRules = null;
            this.txtDueDate.Value = new System.DateTime(((long)(0)));
            // 
            // txtInvoicedTo
            // 
            this.txtInvoicedTo.Capslock = true;
            this.txtInvoicedTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInvoicedTo.FieldLabel = null;
            this.txtInvoicedTo.Location = new System.Drawing.Point(134, 80);
            this.txtInvoicedTo.Name = "txtInvoicedTo";
            this.txtInvoicedTo.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtInvoicedTo.Size = new System.Drawing.Size(531, 24);
            this.txtInvoicedTo.TabIndex = 4;
            this.txtInvoicedTo.ValidationRules = null;
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
            this.lkpCustomer.Location = new System.Drawing.Point(134, 55);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpCustomer.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.lkpCustomer.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpCustomer.Properties.LookupPopup = null;
            this.lkpCustomer.Properties.NullText = "<<Choose...>>";
            this.lkpCustomer.Size = new System.Drawing.Size(411, 24);
            this.lkpCustomer.TabIndex = 3;
            this.lkpCustomer.ValidationRules = null;
            this.lkpCustomer.Value = null;
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Capslock = true;
            this.txtReceiptNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReceiptNo.FieldLabel = null;
            this.txtReceiptNo.Location = new System.Drawing.Point(134, 30);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtReceiptNo.Size = new System.Drawing.Size(197, 24);
            this.txtReceiptNo.TabIndex = 2;
            this.txtReceiptNo.ValidationRules = null;
            // 
            // txtDate
            // 
            this.txtDate.EditValue = null;
            this.txtDate.FieldLabel = null;
            this.txtDate.FormatDateTime = "dd-MM-yyyy";
            this.txtDate.Location = new System.Drawing.Point(134, 5);
            this.txtDate.Name = "txtDate";
            this.txtDate.Nullable = false;
            this.txtDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDate.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.txtDate.Properties.Appearance.Options.UseFont = true;
            this.txtDate.Properties.AutoHeight = false;
            this.txtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDate.Size = new System.Drawing.Size(119, 24);
            this.txtDate.TabIndex = 1;
            this.txtDate.ValidationRules = null;
            this.txtDate.Value = new System.DateTime(((long)(0)));
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Due Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Invoiced To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Customer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Receipt No.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtDescription3);
            this.panel2.Controls.Add(this.txtDescription2);
            this.panel2.Controls.Add(this.txtDescription1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(4, 208);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(728, 88);
            this.panel2.TabIndex = 7;
            // 
            // txtDescription3
            // 
            this.txtDescription3.Capslock = true;
            this.txtDescription3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription3.FieldLabel = null;
            this.txtDescription3.Location = new System.Drawing.Point(134, 58);
            this.txtDescription3.Name = "txtDescription3";
            this.txtDescription3.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDescription3.Size = new System.Drawing.Size(473, 24);
            this.txtDescription3.TabIndex = 9;
            this.txtDescription3.ValidationRules = null;
            // 
            // txtDescription2
            // 
            this.txtDescription2.Capslock = true;
            this.txtDescription2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription2.FieldLabel = null;
            this.txtDescription2.Location = new System.Drawing.Point(134, 31);
            this.txtDescription2.Name = "txtDescription2";
            this.txtDescription2.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDescription2.Size = new System.Drawing.Size(473, 24);
            this.txtDescription2.TabIndex = 8;
            this.txtDescription2.ValidationRules = null;
            // 
            // txtDescription1
            // 
            this.txtDescription1.Capslock = true;
            this.txtDescription1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription1.FieldLabel = null;
            this.txtDescription1.Location = new System.Drawing.Point(134, 4);
            this.txtDescription1.Name = "txtDescription1";
            this.txtDescription1.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDescription1.Size = new System.Drawing.Size(473, 24);
            this.txtDescription1.TabIndex = 7;
            this.txtDescription1.ValidationRules = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Description";
            // 
            // cmbTaxInvoice
            // 
            this.cmbTaxInvoice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTaxInvoice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTaxInvoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaxInvoice.FieldLabel = null;
            this.cmbTaxInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbTaxInvoice.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTaxInvoice.FormattingEnabled = true;
            this.cmbTaxInvoice.Location = new System.Drawing.Point(134, 131);
            this.cmbTaxInvoice.Name = "cmbTaxInvoice";
            this.cmbTaxInvoice.Size = new System.Drawing.Size(137, 25);
            this.cmbTaxInvoice.TabIndex = 6;
            this.cmbTaxInvoice.ValidationRules = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 17);
            this.label7.TabIndex = 104;
            this.label7.Text = "Faktur Pajak";
            // 
            // SalesInvoiceForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(736, 300);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SalesInvoiceForm";
            this.Text = "Invoice";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDueDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDueDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Common.Component.dCalendar txtDueDate;
        private Common.Component.dTextBox txtInvoicedTo;
        private Common.Component.dLookup lkpCustomer;
        private Common.Component.dTextBox txtReceiptNo;
        private Common.Component.dCalendar txtDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private Common.Component.dTextBox txtDescription3;
        private Common.Component.dTextBox txtDescription2;
        private Common.Component.dTextBox txtDescription1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Common.Component.dComboBox cmbTaxInvoice;
    }
}