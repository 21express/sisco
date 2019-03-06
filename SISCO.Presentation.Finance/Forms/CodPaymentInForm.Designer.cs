namespace SISCO.Presentation.Finance.Forms
{
    partial class CodPaymentInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodPaymentInForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxPod = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.GridCod = new DevExpress.XtraGrid.GridControl();
            this.CodView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxTotalSales = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.tbxTotalCash = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxDescription = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridCod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotalSales.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotalCash.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbxDescription);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbxPod);
            this.panel1.Controls.Add(this.tbxDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(888, 63);
            this.panel1.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Location = new System.Drawing.Point(717, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(48, 26);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(408, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "No. POD / STT / AWB";
            // 
            // tbxPod
            // 
            this.tbxPod.Capslock = true;
            this.tbxPod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxPod.FieldLabel = null;
            this.tbxPod.Location = new System.Drawing.Point(540, 4);
            this.tbxPod.Name = "tbxPod";
            this.tbxPod.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPod.Size = new System.Drawing.Size(173, 24);
            this.tbxPod.TabIndex = 3;
            this.tbxPod.ValidationRules = null;
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(86, 5);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxDate.Properties.Appearance.Options.UseFont = true;
            this.tbxDate.Properties.AutoHeight = false;
            this.tbxDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("tbxDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxDate.Size = new System.Drawing.Size(110, 24);
            this.tbxDate.TabIndex = 1;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // GridCod
            // 
            this.GridCod.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridCod.Location = new System.Drawing.Point(4, 108);
            this.GridCod.MainView = this.CodView;
            this.GridCod.Name = "GridCod";
            this.GridCod.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemButtonEdit2});
            this.GridCod.Size = new System.Drawing.Size(888, 318);
            this.GridCod.TabIndex = 2;
            this.GridCod.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.CodView});
            // 
            // CodView
            // 
            this.CodView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.clState,
            this.gridColumn7,
            this.clChecked});
            this.CodView.GridControl = this.GridCod;
            this.CodView.Name = "CodView";
            this.CodView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No.";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 38;
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "ShipmentId";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "No. POD / STT/ AWB";
            this.gridColumn3.FieldName = "ShipmentCode";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 143;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Date";
            this.gridColumn4.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "ShipmentDate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 115;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Total COD";
            this.gridColumn5.DisplayFormat.FormatString = "#,#";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "TotalCod";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.AllowMove = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 160;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "gridColumn6";
            this.gridColumn6.FieldName = "Id";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // clState
            // 
            this.clState.Caption = "gridColumn7";
            this.clState.FieldName = "StateChange2";
            this.clState.Name = "clState";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "DN Code";
            this.gridColumn7.FieldName = "DeliveryCode";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 142;
            // 
            // clChecked
            // 
            this.clChecked.Caption = "Terima Cash COD";
            this.clChecked.FieldName = "Checked";
            this.clChecked.Name = "clChecked";
            this.clChecked.Visible = true;
            this.clChecked.VisibleIndex = 5;
            this.clChecked.Width = 98;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.repositoryItemButtonEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(689, 435);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Total COD";
            // 
            // tbxTotalSales
            // 
            this.tbxTotalSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxTotalSales.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotalSales.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTotalSales.FieldLabel = null;
            this.tbxTotalSales.Location = new System.Drawing.Point(756, 432);
            this.tbxTotalSales.Name = "tbxTotalSales";
            this.tbxTotalSales.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTotalSales.Properties.AllowMouseWheel = false;
            this.tbxTotalSales.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTotalSales.Properties.Appearance.Options.UseFont = true;
            this.tbxTotalSales.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTotalSales.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTotalSales.Properties.Mask.BeepOnError = true;
            this.tbxTotalSales.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotalSales.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxTotalSales.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTotalSales.Properties.ReadOnly = true;
            this.tbxTotalSales.ReadOnly = true;
            this.tbxTotalSales.Size = new System.Drawing.Size(136, 24);
            this.tbxTotalSales.TabIndex = 4;
            this.tbxTotalSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxTotalSales.ValidationRules = null;
            this.tbxTotalSales.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // tbxTotalCash
            // 
            this.tbxTotalCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxTotalCash.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotalCash.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTotalCash.FieldLabel = null;
            this.tbxTotalCash.Location = new System.Drawing.Point(756, 462);
            this.tbxTotalCash.Name = "tbxTotalCash";
            this.tbxTotalCash.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTotalCash.Properties.AllowMouseWheel = false;
            this.tbxTotalCash.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTotalCash.Properties.Appearance.Options.UseFont = true;
            this.tbxTotalCash.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTotalCash.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTotalCash.Properties.Mask.BeepOnError = true;
            this.tbxTotalCash.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotalCash.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxTotalCash.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTotalCash.Properties.ReadOnly = true;
            this.tbxTotalCash.ReadOnly = true;
            this.tbxTotalCash.Size = new System.Drawing.Size(136, 24);
            this.tbxTotalCash.TabIndex = 6;
            this.tbxTotalCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxTotalCash.ValidationRules = null;
            this.tbxTotalCash.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(687, 465);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Total Cash";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Description";
            // 
            // tbxDescription
            // 
            this.tbxDescription.Capslock = true;
            this.tbxDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDescription.FieldLabel = null;
            this.tbxDescription.Location = new System.Drawing.Point(86, 32);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDescription.Size = new System.Drawing.Size(252, 24);
            this.tbxDescription.TabIndex = 2;
            this.tbxDescription.ValidationRules = null;
            // 
            // CodPaymentInForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(895, 490);
            this.Controls.Add(this.tbxTotalCash);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxTotalSales);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GridCod);
            this.Controls.Add(this.panel1);
            this.Name = "CodPaymentInForm";
            this.Text = "Finance - Pembayaran COD";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.GridCod, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tbxTotalSales, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.tbxTotalCash, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridCod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotalSales.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotalCash.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.Label label2;
        private Common.Component.dTextBox tbxPod;
        private Common.Component.dCalendar tbxDate;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl GridCod;
        private DevExpress.XtraGrid.Views.Grid.GridView CodView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn clState;
        private DevExpress.XtraGrid.Columns.GridColumn clChecked;
        private System.Windows.Forms.Label label3;
        private Common.Component.dTextBoxNumber tbxTotalSales;
        private Common.Component.dTextBoxNumber tbxTotalCash;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private Common.Component.dTextBox tbxDescription;
        private System.Windows.Forms.Label label5;
    }
}