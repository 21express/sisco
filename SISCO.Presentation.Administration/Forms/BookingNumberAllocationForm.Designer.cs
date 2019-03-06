namespace SISCO.Presentation.Administration.Forms
{
    partial class BookingNumberAllocationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookingNumberAllocationForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tbxTtlResi = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxTtlBooking = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label4 = new System.Windows.Forms.Label();
            this.GridBooking = new DevExpress.XtraGrid.GridControl();
            this.BookingView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.lkpSprinter = new SISCO.Presentation.Common.Component.dLookup();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gbBooking = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxEnd = new SISCO.Presentation.Common.Component.dTextBox();
            this.tbxStart = new SISCO.Presentation.Common.Component.dTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxJml = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTtlResi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTtlBooking.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridBooking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BookingView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpSprinter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.gbBooking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxJml.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl1.Controls.Add(this.tbxTtlResi);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.tbxTtlBooking);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.GridBooking);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.lkpSprinter);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Location = new System.Drawing.Point(2, 39);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(488, 394);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Sprinter";
            // 
            // tbxTtlResi
            // 
            this.tbxTtlResi.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTtlResi.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTtlResi.FieldLabel = null;
            this.tbxTtlResi.Location = new System.Drawing.Point(395, 366);
            this.tbxTtlResi.Name = "tbxTtlResi";
            this.tbxTtlResi.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTtlResi.Properties.AllowMouseWheel = false;
            this.tbxTtlResi.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTtlResi.Properties.Appearance.Options.UseFont = true;
            this.tbxTtlResi.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTtlResi.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTtlResi.Properties.Mask.BeepOnError = true;
            this.tbxTtlResi.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTtlResi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxTtlResi.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTtlResi.Properties.ReadOnly = true;
            this.tbxTtlResi.ReadOnly = true;
            this.tbxTtlResi.Size = new System.Drawing.Size(88, 24);
            this.tbxTtlResi.TabIndex = 9;
            this.tbxTtlResi.TextAlign = null;
            this.tbxTtlResi.ValidationRules = null;
            this.tbxTtlResi.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(281, 370);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Total Resi";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxTtlBooking
            // 
            this.tbxTtlBooking.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTtlBooking.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTtlBooking.FieldLabel = null;
            this.tbxTtlBooking.Location = new System.Drawing.Point(395, 340);
            this.tbxTtlBooking.Name = "tbxTtlBooking";
            this.tbxTtlBooking.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTtlBooking.Properties.AllowMouseWheel = false;
            this.tbxTtlBooking.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTtlBooking.Properties.Appearance.Options.UseFont = true;
            this.tbxTtlBooking.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTtlBooking.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTtlBooking.Properties.Mask.BeepOnError = true;
            this.tbxTtlBooking.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTtlBooking.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxTtlBooking.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTtlBooking.Properties.ReadOnly = true;
            this.tbxTtlBooking.ReadOnly = true;
            this.tbxTtlBooking.Size = new System.Drawing.Size(88, 24);
            this.tbxTtlBooking.TabIndex = 7;
            this.tbxTtlBooking.TextAlign = null;
            this.tbxTtlBooking.ValidationRules = null;
            this.tbxTtlBooking.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(281, 344);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total Booking No";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GridBooking
            // 
            this.GridBooking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridBooking.Location = new System.Drawing.Point(3, 103);
            this.GridBooking.MainView = this.BookingView;
            this.GridBooking.Name = "GridBooking";
            this.GridBooking.Size = new System.Drawing.Size(482, 231);
            this.GridBooking.TabIndex = 3;
            this.GridBooking.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.BookingView});
            // 
            // BookingView
            // 
            this.BookingView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.BookingView.GridControl = this.GridBooking;
            this.BookingView.Name = "BookingView";
            this.BookingView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No.";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 42;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Booking No.";
            this.gridColumn2.FieldName = "BookingNo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 149;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "No. Resi";
            this.gridColumn3.FieldName = "ShipmentCode";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 118;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "POD Fisik?";
            this.gridColumn4.FieldName = "IsPodExists";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 57;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Alasan Hilang/Rusak";
            this.gridColumn5.FieldName = "ReasonLost";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 330;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "gridColumn6";
            this.gridColumn6.FieldName = "StateChange";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "gridColumn7";
            this.gridColumn7.FieldName = "Id";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Riwayat Alokasi Sprinter";
            // 
            // lkpSprinter
            // 
            this.lkpSprinter.AutoCompleteDataManager = null;
            this.lkpSprinter.AutoCompleteDisplayFormater = null;
            this.lkpSprinter.AutoCompleteInitialized = false;
            this.lkpSprinter.AutocompleteMinimumTextLength = 0;
            this.lkpSprinter.AutoCompleteText = null;
            this.lkpSprinter.AutoCompleteWhereExpression = null;
            this.lkpSprinter.AutoCompleteWheretermFormater = null;
            this.lkpSprinter.ClearOnLeave = true;
            this.lkpSprinter.DisplayString = null;
            this.lkpSprinter.FieldLabel = null;
            this.lkpSprinter.Location = new System.Drawing.Point(80, 29);
            this.lkpSprinter.LookupPopup = null;
            this.lkpSprinter.Name = "lkpSprinter";
            this.lkpSprinter.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpSprinter.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpSprinter.Properties.Appearance.Options.UseFont = true;
            this.lkpSprinter.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpSprinter.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpSprinter.Properties.AutoCompleteDataManager = null;
            this.lkpSprinter.Properties.AutoCompleteDisplayFormater = null;
            this.lkpSprinter.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpSprinter.Properties.AutoCompleteText = null;
            this.lkpSprinter.Properties.AutoCompleteWhereExpression = null;
            this.lkpSprinter.Properties.AutoCompleteWheretermFormater = null;
            this.lkpSprinter.Properties.AutoHeight = false;
            this.lkpSprinter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpSprinter.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpSprinter.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpSprinter.Properties.LookupPopup = null;
            this.lkpSprinter.Properties.NullText = "<<Choose...>>";
            this.lkpSprinter.Size = new System.Drawing.Size(252, 24);
            this.lkpSprinter.TabIndex = 1;
            this.lkpSprinter.ValidationRules = null;
            this.lkpSprinter.Value = null;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sprinter";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.btnSave);
            this.groupControl2.Controls.Add(this.btnPrint);
            this.groupControl2.Controls.Add(this.gbBooking);
            this.groupControl2.Controls.Add(this.tbxJml);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Location = new System.Drawing.Point(492, 39);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(253, 394);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Print Booking Resi";
            // 
            // gbBooking
            // 
            this.gbBooking.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBooking.Controls.Add(this.label8);
            this.gbBooking.Controls.Add(this.tbxEnd);
            this.gbBooking.Controls.Add(this.tbxStart);
            this.gbBooking.Controls.Add(this.label6);
            this.gbBooking.Location = new System.Drawing.Point(24, 70);
            this.gbBooking.Name = "gbBooking";
            this.gbBooking.Size = new System.Drawing.Size(206, 83);
            this.gbBooking.TabIndex = 10;
            this.gbBooking.TabStop = false;
            this.gbBooking.Text = "Booking No.";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(17, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "End";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxEnd
            // 
            this.tbxEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxEnd.Capslock = true;
            this.tbxEnd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxEnd.FieldLabel = null;
            this.tbxEnd.Location = new System.Drawing.Point(85, 48);
            this.tbxEnd.Name = "tbxEnd";
            this.tbxEnd.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxEnd.ReadOnly = true;
            this.tbxEnd.Size = new System.Drawing.Size(104, 24);
            this.tbxEnd.TabIndex = 13;
            this.tbxEnd.ValidationRules = null;
            // 
            // tbxStart
            // 
            this.tbxStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxStart.Capslock = true;
            this.tbxStart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxStart.FieldLabel = null;
            this.tbxStart.Location = new System.Drawing.Point(85, 23);
            this.tbxStart.Name = "tbxStart";
            this.tbxStart.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxStart.ReadOnly = true;
            this.tbxStart.Size = new System.Drawing.Size(104, 24);
            this.tbxStart.TabIndex = 12;
            this.tbxStart.ValidationRules = null;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(17, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Start";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxJml
            // 
            this.tbxJml.EditMask = "###,###,###,###,###,##0.00";
            this.tbxJml.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxJml.FieldLabel = null;
            this.tbxJml.Location = new System.Drawing.Point(91, 29);
            this.tbxJml.Name = "tbxJml";
            this.tbxJml.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxJml.Properties.AllowMouseWheel = false;
            this.tbxJml.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxJml.Properties.Appearance.Options.UseFont = true;
            this.tbxJml.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxJml.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxJml.Properties.Mask.BeepOnError = true;
            this.tbxJml.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxJml.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxJml.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxJml.ReadOnly = false;
            this.tbxJml.Size = new System.Drawing.Size(88, 24);
            this.tbxJml.TabIndex = 5;
            this.tbxJml.TextAlign = null;
            this.tbxJml.ValidationRules = null;
            this.tbxJml.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(21, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Jml. Resi";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(198, 342);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(48, 48);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Print";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(98, 342);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 48);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            // 
            // BookingNumberAllocationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(747, 435);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "BookingNumberAllocationForm";
            this.Text = "Booking Number";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTtlResi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTtlBooking.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridBooking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BookingView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpSprinter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.gbBooking.ResumeLayout(false);
            this.gbBooking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxJml.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private Common.Component.dLookup lkpSprinter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private Common.Component.dTextBoxNumber tbxJml;
        private System.Windows.Forms.Label label2;
        private Common.Component.dTextBoxNumber tbxTtlResi;
        private System.Windows.Forms.Label label5;
        private Common.Component.dTextBoxNumber tbxTtlBooking;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.GridControl GridBooking;
        private DevExpress.XtraGrid.Views.Grid.GridView BookingView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.GroupBox gbBooking;
        private System.Windows.Forms.Label label8;
        private Common.Component.dTextBox tbxEnd;
        private Common.Component.dTextBox tbxStart;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
    }
}