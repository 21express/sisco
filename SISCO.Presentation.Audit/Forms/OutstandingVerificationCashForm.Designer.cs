namespace SISCO.Presentation.Audit.Forms
{
    partial class OutstandingVerificationCashForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutstandingVerificationCashForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.tbxEnd = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.tbxStart = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PaymentCounterGrid = new DevExpress.XtraGrid.GridControl();
            this.PaymentCounterView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.chbOut = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentCounterGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentCounterView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chbOut);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.tbxEnd);
            this.panel1.Controls.Add(this.tbxStart);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 71);
            this.panel1.TabIndex = 0;
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(63, 31);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 29);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "View";
            // 
            // tbxEnd
            // 
            this.tbxEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxEnd.EditValue = null;
            this.tbxEnd.FieldLabel = null;
            this.tbxEnd.FormatDateTime = "dd-MM-yyyy";
            this.tbxEnd.Location = new System.Drawing.Point(251, 3);
            this.tbxEnd.Name = "tbxEnd";
            this.tbxEnd.Nullable = false;
            this.tbxEnd.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxEnd.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxEnd.Properties.Appearance.Options.UseFont = true;
            this.tbxEnd.Properties.AutoHeight = false;
            this.tbxEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxEnd.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
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
            this.tbxEnd.Size = new System.Drawing.Size(120, 24);
            this.tbxEnd.TabIndex = 2;
            this.tbxEnd.ValidationRules = null;
            this.tbxEnd.Value = new System.DateTime(((long)(0)));
            // 
            // tbxStart
            // 
            this.tbxStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxStart.EditValue = null;
            this.tbxStart.FieldLabel = null;
            this.tbxStart.FormatDateTime = "dd-MM-yyyy";
            this.tbxStart.Location = new System.Drawing.Point(63, 3);
            this.tbxStart.Name = "tbxStart";
            this.tbxStart.Nullable = false;
            this.tbxStart.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxStart.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxStart.Properties.Appearance.Options.UseFont = true;
            this.tbxStart.Properties.AutoHeight = false;
            this.tbxStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxStart.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
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
            this.tbxStart.Size = new System.Drawing.Size(122, 24);
            this.tbxStart.TabIndex = 1;
            this.tbxStart.ValidationRules = null;
            this.tbxStart.Value = new System.DateTime(((long)(0)));
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sampai";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dari";
            // 
            // PaymentCounterGrid
            // 
            this.PaymentCounterGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PaymentCounterGrid.Location = new System.Drawing.Point(0, 72);
            this.PaymentCounterGrid.MainView = this.PaymentCounterView;
            this.PaymentCounterGrid.Name = "PaymentCounterGrid";
            this.PaymentCounterGrid.Size = new System.Drawing.Size(784, 285);
            this.PaymentCounterGrid.TabIndex = 1;
            this.PaymentCounterGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PaymentCounterView});
            // 
            // PaymentCounterView
            // 
            this.PaymentCounterView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.PaymentCounterView.GridControl = this.PaymentCounterGrid;
            this.PaymentCounterView.Name = "PaymentCounterView";
            this.PaymentCounterView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Kode Payment Counter";
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
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Total";
            this.gridColumn5.DisplayFormat.FormatString = "#,#0";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn5.FieldName = "Total";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 102;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Verified";
            this.gridColumn6.FieldName = "Verified";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 102;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Verified By";
            this.gridColumn7.FieldName = "VerifiedBy";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 102;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Verified Date";
            this.gridColumn8.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn8.FieldName = "VerifiedDate";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 106;
            // 
            // btnSave
            // 
            this.btnSave.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(658, 369);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 29);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save To Excel";
            // 
            // chbOut
            // 
            this.chbOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbOut.AutoSize = true;
            this.chbOut.Checked = true;
            this.chbOut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOut.ForeColor = System.Drawing.Color.Black;
            this.chbOut.Location = new System.Drawing.Point(403, 5);
            this.chbOut.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.chbOut.Name = "chbOut";
            this.chbOut.Size = new System.Drawing.Size(94, 21);
            this.chbOut.TabIndex = 6;
            this.chbOut.Text = "OutStanding";
            this.chbOut.UseVisualStyleBackColor = true;
            // 
            // OutstandingVerificationCashForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 410);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.PaymentCounterGrid);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "OutstandingVerificationCashForm";
            this.Text = "Audit - Outstanding Verifikasi Counter Form";
            this.Load += new System.EventHandler(this.OutstandingVerificationCashForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentCounterGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentCounterView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Common.Component.dCalendar tbxEnd;
        private Common.Component.dCalendar tbxStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraGrid.GridControl PaymentCounterGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView PaymentCounterView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.CheckBox chbOut;
    }
}