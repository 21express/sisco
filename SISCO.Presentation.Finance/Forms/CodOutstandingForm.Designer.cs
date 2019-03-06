namespace SISCO.Presentation.Finance.Forms
{
    partial class CodOutstandingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodOutstandingForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label1 = new System.Windows.Forms.Label();
            this.lkpBranch = new SISCO.Presentation.Common.Component.dLookup();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.GridOutstanding = new DevExpress.XtraGrid.GridControl();
            this.outstandingPaymentBindingSource = new System.Windows.Forms.BindingSource();
            this.OutstandingView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateProcess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBranchId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBranchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransfer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransferCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransferDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerify = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerifyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerifyDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridOutstanding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outstandingPaymentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutstandingView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Branch";
            // 
            // lkpBranch
            // 
            this.lkpBranch.AutoCompleteDataManager = null;
            this.lkpBranch.AutoCompleteDisplayFormater = null;
            this.lkpBranch.AutoCompleteInitialized = false;
            this.lkpBranch.AutocompleteMinimumTextLength = 0;
            this.lkpBranch.AutoCompleteText = null;
            this.lkpBranch.AutoCompleteWhereExpression = null;
            this.lkpBranch.AutoCompleteWheretermFormater = null;
            this.lkpBranch.ClearOnLeave = true;
            this.lkpBranch.DisplayString = null;
            this.lkpBranch.FieldLabel = null;
            this.lkpBranch.Location = new System.Drawing.Point(85, 9);
            this.lkpBranch.LookupPopup = null;
            this.lkpBranch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lkpBranch.Name = "lkpBranch";
            this.lkpBranch.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpBranch.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpBranch.Properties.Appearance.Options.UseFont = true;
            this.lkpBranch.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpBranch.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpBranch.Properties.AutoCompleteDataManager = null;
            this.lkpBranch.Properties.AutoCompleteDisplayFormater = null;
            this.lkpBranch.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpBranch.Properties.AutoCompleteText = null;
            this.lkpBranch.Properties.AutoCompleteWhereExpression = null;
            this.lkpBranch.Properties.AutoCompleteWheretermFormater = null;
            this.lkpBranch.Properties.AutoHeight = false;
            this.lkpBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpBranch.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpBranch.Properties.LookupPopup = null;
            this.lkpBranch.Properties.NullText = "<<Choose...>>";
            this.lkpBranch.Size = new System.Drawing.Size(262, 24);
            this.lkpBranch.TabIndex = 1;
            this.lkpBranch.ValidationRules = null;
            this.lkpBranch.Value = null;
            // 
            // btnLoad
            // 
            this.btnLoad.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLoad.Appearance.Options.UseFont = true;
            this.btnLoad.Location = new System.Drawing.Point(353, 7);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(77, 27);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            // 
            // GridOutstanding
            // 
            this.GridOutstanding.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridOutstanding.DataSource = this.outstandingPaymentBindingSource;
            this.GridOutstanding.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GridOutstanding.Location = new System.Drawing.Point(3, 42);
            this.GridOutstanding.MainView = this.OutstandingView;
            this.GridOutstanding.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GridOutstanding.Name = "GridOutstanding";
            this.GridOutstanding.Size = new System.Drawing.Size(971, 415);
            this.GridOutstanding.TabIndex = 3;
            this.GridOutstanding.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.OutstandingView});
            // 
            // outstandingPaymentBindingSource
            // 
            this.outstandingPaymentBindingSource.DataSource = typeof(SISCO.Models.OutstandingPayment);
            // 
            // OutstandingView
            // 
            this.OutstandingView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colCode,
            this.colDateProcess,
            this.colTotal,
            this.colBranchId,
            this.colBranchName,
            this.colPaid,
            this.colPaymentCode,
            this.colPaymentDate,
            this.colTransfer,
            this.colTransferCode,
            this.colTransferDate,
            this.colVerify,
            this.colVerifyCode,
            this.colVerifyDate,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.OutstandingView.GridControl = this.GridOutstanding;
            this.OutstandingView.Name = "OutstandingView";
            this.OutstandingView.OptionsView.ColumnAutoWidth = false;
            this.OutstandingView.OptionsView.ShowFooter = true;
            this.OutstandingView.OptionsView.ShowGroupPanel = false;
            this.OutstandingView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colBranchName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.AllowFocus = false;
            this.colId.OptionsColumn.AllowMove = false;
            this.colId.OptionsColumn.ReadOnly = true;
            // 
            // colCode
            // 
            this.colCode.Caption = "STT";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.OptionsColumn.AllowFocus = false;
            this.colCode.OptionsColumn.AllowMove = false;
            this.colCode.OptionsColumn.ReadOnly = true;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 1;
            this.colCode.Width = 105;
            // 
            // colDateProcess
            // 
            this.colDateProcess.Caption = "Date";
            this.colDateProcess.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.colDateProcess.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDateProcess.FieldName = "DateProcess";
            this.colDateProcess.Name = "colDateProcess";
            this.colDateProcess.OptionsColumn.AllowEdit = false;
            this.colDateProcess.OptionsColumn.AllowFocus = false;
            this.colDateProcess.OptionsColumn.AllowMove = false;
            this.colDateProcess.OptionsColumn.ReadOnly = true;
            this.colDateProcess.Visible = true;
            this.colDateProcess.VisibleIndex = 2;
            this.colDateProcess.Width = 79;
            // 
            // colTotal
            // 
            this.colTotal.Caption = "Total";
            this.colTotal.DisplayFormat.FormatString = "#,#0";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.OptionsColumn.AllowFocus = false;
            this.colTotal.OptionsColumn.AllowMove = false;
            this.colTotal.OptionsColumn.ReadOnly = true;
            this.colTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:#,#0}")});
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 3;
            this.colTotal.Width = 106;
            // 
            // colBranchId
            // 
            this.colBranchId.FieldName = "BranchId";
            this.colBranchId.Name = "colBranchId";
            this.colBranchId.OptionsColumn.AllowEdit = false;
            this.colBranchId.OptionsColumn.AllowFocus = false;
            this.colBranchId.OptionsColumn.AllowMove = false;
            this.colBranchId.OptionsColumn.ReadOnly = true;
            // 
            // colBranchName
            // 
            this.colBranchName.Caption = "Dest. Branch";
            this.colBranchName.FieldName = "BranchName";
            this.colBranchName.Name = "colBranchName";
            this.colBranchName.OptionsColumn.AllowEdit = false;
            this.colBranchName.OptionsColumn.AllowFocus = false;
            this.colBranchName.OptionsColumn.AllowMove = false;
            this.colBranchName.OptionsColumn.ReadOnly = true;
            this.colBranchName.Visible = true;
            this.colBranchName.VisibleIndex = 4;
            this.colBranchName.Width = 115;
            // 
            // colPaid
            // 
            this.colPaid.Caption = "Paid";
            this.colPaid.FieldName = "Paid";
            this.colPaid.Name = "colPaid";
            this.colPaid.OptionsColumn.AllowEdit = false;
            this.colPaid.OptionsColumn.AllowFocus = false;
            this.colPaid.OptionsColumn.AllowMove = false;
            this.colPaid.OptionsColumn.ReadOnly = true;
            this.colPaid.Visible = true;
            this.colPaid.VisibleIndex = 5;
            this.colPaid.Width = 37;
            // 
            // colPaymentCode
            // 
            this.colPaymentCode.Caption = "Payment Code";
            this.colPaymentCode.FieldName = "PaymentCode";
            this.colPaymentCode.Name = "colPaymentCode";
            this.colPaymentCode.OptionsColumn.AllowEdit = false;
            this.colPaymentCode.OptionsColumn.AllowFocus = false;
            this.colPaymentCode.OptionsColumn.AllowMove = false;
            this.colPaymentCode.OptionsColumn.ReadOnly = true;
            this.colPaymentCode.Visible = true;
            this.colPaymentCode.VisibleIndex = 6;
            this.colPaymentCode.Width = 92;
            // 
            // colPaymentDate
            // 
            this.colPaymentDate.Caption = "Payment Date";
            this.colPaymentDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.colPaymentDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colPaymentDate.FieldName = "PaymentDate";
            this.colPaymentDate.Name = "colPaymentDate";
            this.colPaymentDate.OptionsColumn.AllowEdit = false;
            this.colPaymentDate.OptionsColumn.AllowFocus = false;
            this.colPaymentDate.OptionsColumn.AllowMove = false;
            this.colPaymentDate.OptionsColumn.ReadOnly = true;
            this.colPaymentDate.Visible = true;
            this.colPaymentDate.VisibleIndex = 7;
            this.colPaymentDate.Width = 76;
            // 
            // colTransfer
            // 
            this.colTransfer.Caption = "Transfer";
            this.colTransfer.FieldName = "Transfer";
            this.colTransfer.Name = "colTransfer";
            this.colTransfer.OptionsColumn.AllowEdit = false;
            this.colTransfer.OptionsColumn.AllowFocus = false;
            this.colTransfer.OptionsColumn.AllowMove = false;
            this.colTransfer.OptionsColumn.ReadOnly = true;
            this.colTransfer.Visible = true;
            this.colTransfer.VisibleIndex = 8;
            this.colTransfer.Width = 54;
            // 
            // colTransferCode
            // 
            this.colTransferCode.Caption = "Transfer Code";
            this.colTransferCode.FieldName = "TransferCode";
            this.colTransferCode.Name = "colTransferCode";
            this.colTransferCode.OptionsColumn.AllowEdit = false;
            this.colTransferCode.OptionsColumn.AllowFocus = false;
            this.colTransferCode.OptionsColumn.AllowMove = false;
            this.colTransferCode.OptionsColumn.ReadOnly = true;
            this.colTransferCode.Visible = true;
            this.colTransferCode.VisibleIndex = 9;
            this.colTransferCode.Width = 98;
            // 
            // colTransferDate
            // 
            this.colTransferDate.Caption = "Transfer Date";
            this.colTransferDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.colTransferDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTransferDate.FieldName = "TransferDate";
            this.colTransferDate.Name = "colTransferDate";
            this.colTransferDate.OptionsColumn.AllowEdit = false;
            this.colTransferDate.OptionsColumn.AllowFocus = false;
            this.colTransferDate.OptionsColumn.AllowMove = false;
            this.colTransferDate.OptionsColumn.ReadOnly = true;
            this.colTransferDate.Visible = true;
            this.colTransferDate.VisibleIndex = 10;
            this.colTransferDate.Width = 80;
            // 
            // colVerify
            // 
            this.colVerify.Caption = "Verify";
            this.colVerify.FieldName = "Verify";
            this.colVerify.Name = "colVerify";
            this.colVerify.OptionsColumn.AllowEdit = false;
            this.colVerify.OptionsColumn.AllowFocus = false;
            this.colVerify.OptionsColumn.AllowMove = false;
            this.colVerify.OptionsColumn.ReadOnly = true;
            this.colVerify.Visible = true;
            this.colVerify.VisibleIndex = 11;
            this.colVerify.Width = 68;
            // 
            // colVerifyCode
            // 
            this.colVerifyCode.FieldName = "VerifyCode";
            this.colVerifyCode.Name = "colVerifyCode";
            this.colVerifyCode.OptionsColumn.AllowEdit = false;
            this.colVerifyCode.OptionsColumn.AllowFocus = false;
            this.colVerifyCode.OptionsColumn.AllowMove = false;
            this.colVerifyCode.OptionsColumn.ReadOnly = true;
            // 
            // colVerifyDate
            // 
            this.colVerifyDate.FieldName = "VerifyDate";
            this.colVerifyDate.Name = "colVerifyDate";
            this.colVerifyDate.OptionsColumn.AllowEdit = false;
            this.colVerifyDate.OptionsColumn.AllowFocus = false;
            this.colVerifyDate.OptionsColumn.AllowMove = false;
            this.colVerifyDate.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No.";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 38;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Received By";
            this.gridColumn2.FieldName = "StatusBy";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 13;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Received";
            this.gridColumn3.FieldName = "Received";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 12;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Received Date";
            this.gridColumn4.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "StatusDate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 14;
            // 
            // CodOutstandingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 462);
            this.Controls.Add(this.GridOutstanding);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lkpBranch);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "CodOutstandingForm";
            this.Text = "Finance - COD Outstanding";
            ((System.ComponentModel.ISupportInitialize)(this.lkpBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridOutstanding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outstandingPaymentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutstandingView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Common.Component.dLookup lkpBranch;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
        private DevExpress.XtraGrid.GridControl GridOutstanding;
        private DevExpress.XtraGrid.Views.Grid.GridView OutstandingView;
        private System.Windows.Forms.BindingSource outstandingPaymentBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDateProcess;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colBranchId;
        private DevExpress.XtraGrid.Columns.GridColumn colBranchName;
        private DevExpress.XtraGrid.Columns.GridColumn colPaid;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTransfer;
        private DevExpress.XtraGrid.Columns.GridColumn colTransferCode;
        private DevExpress.XtraGrid.Columns.GridColumn colTransferDate;
        private DevExpress.XtraGrid.Columns.GridColumn colVerify;
        private DevExpress.XtraGrid.Columns.GridColumn colVerifyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colVerifyDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}