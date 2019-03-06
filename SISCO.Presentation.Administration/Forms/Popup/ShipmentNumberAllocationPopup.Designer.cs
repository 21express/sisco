namespace SISCO.Presentation.Administration.Popup
{
    partial class ShipmentNumberAllocationPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShipmentNumberAllocationPopup));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.txtFilterDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.lkpFilterCustomer = new SISCO.Presentation.Common.Component.dLookup();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFilterShipmentNo = new Common.Component.dTextBoxNumber();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).BeginInit();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilterCustomer.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // MainContainer
            // 
            // 
            // MainContainer.Panel1
            // 
            this.MainContainer.Panel1.Controls.Add(this.txtFilterDate);
            this.MainContainer.Panel1.Controls.Add(this.lkpFilterCustomer);
            this.MainContainer.Panel1.Controls.Add(this.label14);
            this.MainContainer.Panel1.Controls.Add(this.label8);
            this.MainContainer.Panel1.Controls.Add(this.label12);
            this.MainContainer.Panel1.Controls.Add(this.txtFilterShipmentNo);
            this.MainContainer.Size = new System.Drawing.Size(867, 344);
            this.MainContainer.SplitterDistance = 333;
            // 
            // tbxCode
            // 
            this.tbxCode.Location = new System.Drawing.Point(89, 33);
            this.tbxCode.Size = new System.Drawing.Size(241, 24);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(243, 309);
            this.btnClear.Size = new System.Drawing.Size(76, 29);
            this.btnClear.TabIndex = 0;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(163, 309);
            this.btnFilter.Size = new System.Drawing.Size(74, 29);
            this.btnFilter.TabIndex = 6;
            // 
            // txtFilterDate
            // 
            this.txtFilterDate.EditValue = null;
            this.txtFilterDate.FieldLabel = null;
            this.txtFilterDate.FormatDateTime = "dd-MM-yyyy";
            this.txtFilterDate.Location = new System.Drawing.Point(89, 99);
            this.txtFilterDate.Name = "txtFilterDate";
            this.txtFilterDate.Nullable = false;
            this.txtFilterDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtFilterDate.Properties.AutoHeight = false;
            this.txtFilterDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtFilterDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtFilterDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFilterDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtFilterDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFilterDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtFilterDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFilterDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtFilterDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtFilterDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtFilterDate.Size = new System.Drawing.Size(168, 20);
            this.txtFilterDate.TabIndex = 3;
            this.txtFilterDate.ValidationRules = null;
            this.txtFilterDate.Value = new System.DateTime(((long)(0)));
            // 
            // lkpFilterCustomer
            // 
            this.lkpFilterCustomer.AutoCompleteDataManager = null;
            this.lkpFilterCustomer.AutoCompleteDisplayFormater = null;
            this.lkpFilterCustomer.AutoCompleteInitialized = false;
            this.lkpFilterCustomer.AutocompleteMinimumTextLength = 0;
            this.lkpFilterCustomer.AutoCompleteText = null;
            this.lkpFilterCustomer.AutoCompleteWhereExpression = null;
            this.lkpFilterCustomer.AutoCompleteWheretermFormater = null;
            this.lkpFilterCustomer.ClearOnLeave = true;
            this.lkpFilterCustomer.DisplayString = null;
            this.lkpFilterCustomer.FieldLabel = null;
            this.lkpFilterCustomer.Location = new System.Drawing.Point(89, 77);
            this.lkpFilterCustomer.LookupPopup = null;
            this.lkpFilterCustomer.Name = "lkpFilterCustomer";
            this.lkpFilterCustomer.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpFilterCustomer.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpFilterCustomer.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpFilterCustomer.Properties.AutoCompleteDataManager = null;
            this.lkpFilterCustomer.Properties.AutoCompleteDisplayFormater = null;
            this.lkpFilterCustomer.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpFilterCustomer.Properties.AutoCompleteText = null;
            this.lkpFilterCustomer.Properties.AutoCompleteWhereExpression = null;
            this.lkpFilterCustomer.Properties.AutoCompleteWheretermFormater = null;
            this.lkpFilterCustomer.Properties.AutoHeight = false;
            this.lkpFilterCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpFilterCustomer.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpFilterCustomer.Properties.LookupPopup = null;
            this.lkpFilterCustomer.Properties.NullText = "<<Choose...>>";
            this.lkpFilterCustomer.Size = new System.Drawing.Size(241, 20);
            this.lkpFilterCustomer.TabIndex = 2;
            this.lkpFilterCustomer.ValidationRules = null;
            this.lkpFilterCustomer.Value = null;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 13);
            this.label14.TabIndex = 148;
            this.label14.Text = "Customer";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 145;
            this.label8.Text = "Date";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 146;
            this.label12.Text = "Shipment No.";
            // 
            // txtFilterShipmentNo
            // 
            this.txtFilterShipmentNo.Location = new System.Drawing.Point(89, 121);
            this.txtFilterShipmentNo.Name = "txtFilterShipmentNo";
            this.txtFilterShipmentNo.Size = new System.Drawing.Size(168, 20);
            this.txtFilterShipmentNo.TabIndex = 4;
            // 
            // ShipmentNumberAllocationPopup
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 344);
            this.Name = "ShipmentNumberAllocationPopup";
            this.SelectedText = "";
            this.Text = "Shipment Number Allocation Popup";
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).EndInit();
            this.MainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilterCustomer.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Common.Component.dCalendar txtFilterDate;
        private Common.Component.dLookup lkpFilterCustomer;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private Common.Component.dTextBoxNumber txtFilterShipmentNo;
    }
}