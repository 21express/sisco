namespace SISCO.Presentation.Audit.Forms
{
    partial class OutstandingVerificationCollectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutstandingVerificationCollectForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chbOut = new System.Windows.Forms.CheckBox();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.tbxEnd = new Franchise.Presentation.Common.Component.dCalendar(this.components);
            this.tbxStart = new Franchise.Presentation.Common.Component.dCalendar(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PaymentCollectGrid = new DevExpress.XtraGrid.GridControl();
            this.PaymentCollectView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentCollectGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentCollectView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSalmon;
            this.panel1.Controls.Add(this.chbOut);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.tbxEnd);
            this.panel1.Controls.Add(this.tbxStart);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 76);
            this.panel1.TabIndex = 0;
            // 
            // chbOut
            // 
            this.chbOut.AutoSize = true;
            this.chbOut.Checked = true;
            this.chbOut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOut.ForeColor = System.Drawing.Color.Black;
            this.chbOut.Location = new System.Drawing.Point(484, 6);
            this.chbOut.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.chbOut.Name = "chbOut";
            this.chbOut.Size = new System.Drawing.Size(94, 21);
            this.chbOut.TabIndex = 7;
            this.chbOut.Text = "OutStanding";
            this.chbOut.UseVisualStyleBackColor = true;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(88, 33);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "View";
            // 
            // tbxEnd
            // 
            this.tbxEnd.EditValue = null;
            this.tbxEnd.FieldLabel = null;
            this.tbxEnd.FormatDateTime = "dd-MM-yyyy";
            this.tbxEnd.Location = new System.Drawing.Point(317, 8);
            this.tbxEnd.Name = "tbxEnd";
            this.tbxEnd.Nullable = false;
            this.tbxEnd.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxEnd.Properties.AutoHeight = false;
            this.tbxEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxEnd.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.tbxEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxEnd.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxEnd.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxEnd.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxEnd.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxEnd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxEnd.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxEnd.Size = new System.Drawing.Size(133, 20);
            this.tbxEnd.TabIndex = 2;
            this.tbxEnd.ValidationRules = null;
            this.tbxEnd.Value = new System.DateTime(((long)(0)));
            // 
            // tbxStart
            // 
            this.tbxStart.EditValue = null;
            this.tbxStart.FieldLabel = null;
            this.tbxStart.FormatDateTime = "dd-MM-yyyy";
            this.tbxStart.Location = new System.Drawing.Point(88, 7);
            this.tbxStart.Name = "tbxStart";
            this.tbxStart.Nullable = false;
            this.tbxStart.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxStart.Properties.AutoHeight = false;
            this.tbxStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxStart.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxStart.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxStart.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxStart.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxStart.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxStart.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxStart.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxStart.Size = new System.Drawing.Size(133, 20);
            this.tbxStart.TabIndex = 1;
            this.tbxStart.ValidationRules = null;
            this.tbxStart.Value = new System.DateTime(((long)(0)));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sampai";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dari";
            // 
            // PaymentCollectGrid
            // 
            this.PaymentCollectGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PaymentCollectGrid.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.PaymentCollectGrid.Location = new System.Drawing.Point(0, 76);
            this.PaymentCollectGrid.MainView = this.PaymentCollectView;
            this.PaymentCollectGrid.Name = "PaymentCollectGrid";
            this.PaymentCollectGrid.Size = new System.Drawing.Size(784, 292);
            this.PaymentCollectGrid.TabIndex = 1;
            this.PaymentCollectGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PaymentCollectView});
            // 
            // PaymentCollectView
            // 
            this.PaymentCollectView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.PaymentCollectView.GridControl = this.PaymentCollectGrid;
            this.PaymentCollectView.Name = "PaymentCollectView";
            this.PaymentCollectView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Kode Payment Collect";
            this.gridColumn1.FieldName = "Code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 150;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tanggal";
            this.gridColumn2.FieldName = "DateProcess";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 102;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Description";
            this.gridColumn3.FieldName = "Description";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 102;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Total";
            this.gridColumn4.FieldName = "TotalInvoice";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 102;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Verified";
            this.gridColumn5.FieldName = "Verified";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 102;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Verified_by";
            this.gridColumn6.FieldName = "VerifiedBy";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 102;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Verified_date";
            this.gridColumn7.FieldName = "VerifiedDate";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 106;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(634, 375);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 31);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save To Excel";
            // 
            // OutstandingVerificationCollectForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 414);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.PaymentCollectGrid);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OutstandingVerificationCollectForm";
            this.Text = "Audit - Outstanding Verifikasi Collect Form";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentCollectGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentCollectView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Franchise.Presentation.Common.Component.dCalendar tbxStart;
        private Franchise.Presentation.Common.Component.dCalendar tbxEnd;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraGrid.GridControl PaymentCollectGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView PaymentCollectView;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private System.Windows.Forms.CheckBox chbOut;
    }
}