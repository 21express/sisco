namespace SISCO.Presentation.MasterData.Forms
{
    partial class NotificationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxExpired = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.rtMessage = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxExpired.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxExpired.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rtMessage);
            this.panel1.Controls.Add(this.tbxExpired);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(742, 285);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Expired Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Message";
            // 
            // tbxExpired
            // 
            this.tbxExpired.EditValue = null;
            this.tbxExpired.FieldLabel = null;
            this.tbxExpired.FormatDateTime = "dd-MM-yyyy";
            this.tbxExpired.Location = new System.Drawing.Point(114, 10);
            this.tbxExpired.Name = "tbxExpired";
            this.tbxExpired.Nullable = false;
            this.tbxExpired.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxExpired.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxExpired.Properties.Appearance.Options.UseFont = true;
            this.tbxExpired.Properties.AutoHeight = false;
            this.tbxExpired.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dCalendar1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.tbxExpired.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxExpired.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxExpired.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxExpired.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxExpired.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxExpired.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxExpired.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxExpired.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxExpired.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxExpired.Size = new System.Drawing.Size(112, 22);
            this.tbxExpired.TabIndex = 3;
            this.tbxExpired.ValidationRules = null;
            this.tbxExpired.Value = new System.DateTime(((long)(0)));
            // 
            // rtMessage
            // 
            this.rtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtMessage.Location = new System.Drawing.Point(114, 36);
            this.rtMessage.Name = "rtMessage";
            this.rtMessage.Size = new System.Drawing.Size(606, 229);
            this.rtMessage.TabIndex = 4;
            this.rtMessage.Text = "";
            // 
            // NotificationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 331);
            this.Controls.Add(this.panel1);
            this.Name = "NotificationForm";
            this.Text = "Notification";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxExpired.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxExpired.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Common.Component.dCalendar tbxExpired;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtMessage;
    }
}