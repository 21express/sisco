namespace SISCO.Presentation.Finance.Popup
{
    partial class TransactionalModificationPopup
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
            this.GridTransaction = new DevExpress.XtraGrid.GridControl();
            this.TransactionView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTimeEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDebit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCredit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // GridTransaction
            // 
            this.GridTransaction.Location = new System.Drawing.Point(3, 4);
            this.GridTransaction.MainView = this.TransactionView;
            this.GridTransaction.Name = "GridTransaction";
            this.GridTransaction.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTimeEdit1});
            this.GridTransaction.Size = new System.Drawing.Size(804, 297);
            this.GridTransaction.TabIndex = 3;
            this.GridTransaction.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.TransactionView});
            // 
            // TransactionView
            // 
            this.TransactionView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gcDebit,
            this.gcCredit,
            this.gridColumn16,
            this.gridColumn1,
            this.gridColumn2});
            this.TransactionView.GridControl = this.GridTransaction;
            this.TransactionView.Name = "TransactionView";
            this.TransactionView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "gridColumn1";
            this.gridColumn10.FieldName = "Id";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Tgl";
            this.gridColumn11.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn11.FieldName = "DateProcess";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            this.gridColumn11.Width = 72;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Jam";
            this.gridColumn12.ColumnEdit = this.repositoryItemTimeEdit1;
            this.gridColumn12.DisplayFormat.FormatString = "HH:mm:ss";
            this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn12.FieldName = "DateProcess";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            this.gridColumn12.Width = 87;
            // 
            // repositoryItemTimeEdit1
            // 
            this.repositoryItemTimeEdit1.AutoHeight = false;
            this.repositoryItemTimeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemTimeEdit1.DisplayFormat.FormatString = "HH:mm:ss";
            this.repositoryItemTimeEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemTimeEdit1.EditFormat.FormatString = "HH:mm:ss";
            this.repositoryItemTimeEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemTimeEdit1.Name = "repositoryItemTimeEdit1";
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Rincian / No. Referensi";
            this.gridColumn13.FieldName = "Description";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 2;
            this.gridColumn13.Width = 211;
            // 
            // gcDebit
            // 
            this.gcDebit.Caption = "Debit";
            this.gcDebit.DisplayFormat.FormatString = "n2";
            this.gcDebit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcDebit.FieldName = "DebitTotalAmount";
            this.gcDebit.Name = "gcDebit";
            this.gcDebit.OptionsColumn.AllowEdit = false;
            this.gcDebit.OptionsColumn.AllowFocus = false;
            this.gcDebit.OptionsColumn.ReadOnly = true;
            this.gcDebit.Visible = true;
            this.gcDebit.VisibleIndex = 3;
            this.gcDebit.Width = 111;
            // 
            // gcCredit
            // 
            this.gcCredit.Caption = "Kredit";
            this.gcCredit.DisplayFormat.FormatString = "n2";
            this.gcCredit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcCredit.FieldName = "CreditTotalAmount";
            this.gcCredit.Name = "gcCredit";
            this.gcCredit.OptionsColumn.AllowEdit = false;
            this.gcCredit.OptionsColumn.AllowFocus = false;
            this.gcCredit.OptionsColumn.ReadOnly = true;
            this.gcCredit.Visible = true;
            this.gcCredit.VisibleIndex = 4;
            this.gcCredit.Width = 90;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Saldo";
            this.gridColumn16.DisplayFormat.FormatString = "n2";
            this.gridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn16.FieldName = "Balance";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.OptionsColumn.ReadOnly = true;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 5;
            this.gridColumn16.Width = 104;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "IsModify";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(654, 304);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 29);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Revisi";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(732, 304);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Batal";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.FieldName = "StateChange";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // ModifiedBankAccountPopup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(810, 336);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.GridTransaction);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ModifiedBankAccountPopup";
            this.Text = "Revisi Transaksi Bank";
            ((System.ComponentModel.ISupportInitialize)(this.GridTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GridTransaction;
        private DevExpress.XtraGrid.Views.Grid.GridView TransactionView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gcDebit;
        private DevExpress.XtraGrid.Columns.GridColumn gcCredit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;

    }
}