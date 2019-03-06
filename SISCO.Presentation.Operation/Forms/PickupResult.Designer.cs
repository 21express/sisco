namespace SISCO.Presentation.Operation.Forms
{
    partial class PickupResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickupResult));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeselectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.gridArrangement = new DevExpress.XtraGrid.GridControl();
            this.arrangementView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clKoli = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clVehicle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clMessenger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.clMsgId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPopupContainerEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.dLookup1 = new SISCO.Presentation.Common.Component.dLookup();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFilter = new DevExpress.XtraEditors.SimpleButton();
            this.pnlFooter.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridArrangement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrangementView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dLookup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(759, 7);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 33);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(665, 7);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 33);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 425);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(852, 49);
            this.pnlFooter.TabIndex = 5;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.Enabled = false;
            this.btnSelectAll.Location = new System.Drawing.Point(570, 4);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(87, 33);
            this.btnSelectAll.TabIndex = 0;
            this.btnSelectAll.Text = "Select All";
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeselectAll.Enabled = false;
            this.btnDeselectAll.Location = new System.Drawing.Point(665, 4);
            this.btnDeselectAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(87, 33);
            this.btnDeselectAll.TabIndex = 1;
            this.btnDeselectAll.Text = "Deselect All";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Location = new System.Drawing.Point(759, 4);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(87, 33);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.btnFilter);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.dLookup1);
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Controls.Add(this.btnDeselectAll);
            this.pnlHeader.Controls.Add(this.btnSelectAll);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(852, 43);
            this.pnlHeader.TabIndex = 4;
            // 
            // gridArrangement
            // 
            this.gridArrangement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridArrangement.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridArrangement.Location = new System.Drawing.Point(0, 43);
            this.gridArrangement.MainView = this.arrangementView;
            this.gridArrangement.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridArrangement.Name = "gridArrangement";
            this.gridArrangement.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemPopupContainerEdit1});
            this.gridArrangement.Size = new System.Drawing.Size(852, 382);
            this.gridArrangement.TabIndex = 7;
            this.gridArrangement.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.arrangementView});
            // 
            // arrangementView
            // 
            this.arrangementView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clId,
            this.clDate,
            this.clTime,
            this.clCustomer,
            this.clAddress,
            this.clNote,
            this.clKoli,
            this.clWeight,
            this.clVehicle,
            this.clMessenger,
            this.clMsgId,
            this.clPU,
            this.clState});
            this.arrangementView.GridControl = this.gridArrangement;
            this.arrangementView.Name = "arrangementView";
            this.arrangementView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.arrangementView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.arrangementView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // clId
            // 
            this.clId.Caption = "Id";
            this.clId.FieldName = "Id";
            this.clId.Name = "clId";
            // 
            // clDate
            // 
            this.clDate.Caption = "Date";
            this.clDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.clDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clDate.FieldName = "DateProcess";
            this.clDate.GroupFormat.FormatString = "dd-MM-yyyy";
            this.clDate.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clDate.Name = "clDate";
            this.clDate.OptionsColumn.AllowEdit = false;
            this.clDate.OptionsColumn.AllowFocus = false;
            this.clDate.OptionsColumn.AllowMove = false;
            this.clDate.OptionsColumn.FixedWidth = true;
            this.clDate.OptionsColumn.ReadOnly = true;
            this.clDate.Visible = true;
            this.clDate.VisibleIndex = 0;
            this.clDate.Width = 94;
            // 
            // clTime
            // 
            this.clTime.Caption = "Time";
            this.clTime.DisplayFormat.FormatString = "HH:mm";
            this.clTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clTime.FieldName = "DateProcess";
            this.clTime.GroupFormat.FormatString = "HH:mm";
            this.clTime.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clTime.Name = "clTime";
            this.clTime.OptionsColumn.AllowEdit = false;
            this.clTime.OptionsColumn.AllowFocus = false;
            this.clTime.OptionsColumn.AllowMove = false;
            this.clTime.OptionsColumn.FixedWidth = true;
            this.clTime.OptionsColumn.ReadOnly = true;
            this.clTime.Visible = true;
            this.clTime.VisibleIndex = 1;
            this.clTime.Width = 55;
            // 
            // clCustomer
            // 
            this.clCustomer.Caption = "Customer";
            this.clCustomer.FieldName = "CustomerName";
            this.clCustomer.Name = "clCustomer";
            this.clCustomer.OptionsColumn.AllowEdit = false;
            this.clCustomer.OptionsColumn.AllowFocus = false;
            this.clCustomer.OptionsColumn.AllowMove = false;
            this.clCustomer.OptionsColumn.FixedWidth = true;
            this.clCustomer.OptionsColumn.ReadOnly = true;
            this.clCustomer.Visible = true;
            this.clCustomer.VisibleIndex = 2;
            this.clCustomer.Width = 117;
            // 
            // clAddress
            // 
            this.clAddress.Caption = "Address";
            this.clAddress.FieldName = "CustomerAddress";
            this.clAddress.Name = "clAddress";
            this.clAddress.OptionsColumn.AllowEdit = false;
            this.clAddress.OptionsColumn.AllowFocus = false;
            this.clAddress.OptionsColumn.AllowMove = false;
            this.clAddress.OptionsColumn.FixedWidth = true;
            this.clAddress.OptionsColumn.ReadOnly = true;
            this.clAddress.Visible = true;
            this.clAddress.VisibleIndex = 3;
            this.clAddress.Width = 117;
            // 
            // clNote
            // 
            this.clNote.Caption = "Note";
            this.clNote.FieldName = "Note";
            this.clNote.Name = "clNote";
            this.clNote.OptionsColumn.AllowEdit = false;
            this.clNote.OptionsColumn.AllowFocus = false;
            this.clNote.OptionsColumn.AllowMove = false;
            this.clNote.OptionsColumn.FixedWidth = true;
            this.clNote.Visible = true;
            this.clNote.VisibleIndex = 4;
            this.clNote.Width = 114;
            // 
            // clKoli
            // 
            this.clKoli.Caption = "Koli";
            this.clKoli.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clKoli.FieldName = "TtlPiece";
            this.clKoli.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clKoli.Name = "clKoli";
            this.clKoli.OptionsColumn.AllowEdit = false;
            this.clKoli.OptionsColumn.AllowFocus = false;
            this.clKoli.OptionsColumn.AllowMove = false;
            this.clKoli.OptionsColumn.FixedWidth = true;
            this.clKoli.OptionsColumn.ReadOnly = true;
            this.clKoli.Visible = true;
            this.clKoli.VisibleIndex = 5;
            this.clKoli.Width = 49;
            // 
            // clWeight
            // 
            this.clWeight.Caption = "Weight";
            this.clWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clWeight.FieldName = "TtlGrossWeight";
            this.clWeight.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clWeight.Name = "clWeight";
            this.clWeight.OptionsColumn.AllowEdit = false;
            this.clWeight.OptionsColumn.AllowFocus = false;
            this.clWeight.OptionsColumn.AllowMove = false;
            this.clWeight.OptionsColumn.ReadOnly = true;
            this.clWeight.Visible = true;
            this.clWeight.VisibleIndex = 6;
            this.clWeight.Width = 62;
            // 
            // clVehicle
            // 
            this.clVehicle.Caption = "Vehicle";
            this.clVehicle.FieldName = "VehicleTypeName";
            this.clVehicle.Name = "clVehicle";
            this.clVehicle.OptionsColumn.AllowEdit = false;
            this.clVehicle.OptionsColumn.AllowFocus = false;
            this.clVehicle.OptionsColumn.AllowMove = false;
            this.clVehicle.OptionsColumn.ReadOnly = true;
            this.clVehicle.Visible = true;
            this.clVehicle.VisibleIndex = 8;
            this.clVehicle.Width = 107;
            // 
            // clMessenger
            // 
            this.clMessenger.Caption = "Messenger";
            this.clMessenger.ColumnEdit = this.repositoryItemButtonEdit1;
            this.clMessenger.FieldName = "MessengerName";
            this.clMessenger.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.clMessenger.Name = "clMessenger";
            this.clMessenger.Visible = true;
            this.clMessenger.VisibleIndex = 7;
            this.clMessenger.Width = 71;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // clMsgId
            // 
            this.clMsgId.Caption = "Messenger ID";
            this.clMsgId.FieldName = "MessengerId";
            this.clMsgId.Name = "clMsgId";
            // 
            // clPU
            // 
            this.clPU.Caption = "PU";
            this.clPU.FieldName = "PickedUp";
            this.clPU.Name = "clPU";
            this.clPU.Visible = true;
            this.clPU.VisibleIndex = 9;
            this.clPU.Width = 48;
            // 
            // clState
            // 
            this.clState.Caption = "State Change";
            this.clState.FieldName = "StateChange";
            this.clState.Name = "clState";
            // 
            // repositoryItemPopupContainerEdit1
            // 
            this.repositoryItemPopupContainerEdit1.AutoHeight = false;
            this.repositoryItemPopupContainerEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemPopupContainerEdit1.Name = "repositoryItemPopupContainerEdit1";
            // 
            // dLookup1
            // 
            this.dLookup1.AutoCompleteDataManager = null;
            this.dLookup1.AutoCompleteDisplayFormater = null;
            this.dLookup1.AutoCompleteInitialized = false;
            this.dLookup1.AutoCompleteWheretermFormater = null;
            this.dLookup1.Location = new System.Drawing.Point(83, 9);
            this.dLookup1.LookupPopup = null;
            this.dLookup1.Name = "dLookup1";
            this.dLookup1.Properties.AutoHeight = false;
            this.dLookup1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dLookup1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.dLookup1.Properties.NullText = "<<Choose..>>";
            this.dLookup1.Size = new System.Drawing.Size(189, 24);
            this.dLookup1.TabIndex = 3;
            this.dLookup1.Value = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Messenger";
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Enabled = false;
            this.btnFilter.Location = new System.Drawing.Point(276, 4);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(58, 33);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "Filter";
            // 
            // PickupResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 474);
            this.Controls.Add(this.gridArrangement);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.Name = "PickupResult";
            this.Text = "Operation - Pick Up Result";
            this.pnlFooter.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridArrangement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrangementView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dLookup1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Panel pnlFooter;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private DevExpress.XtraEditors.SimpleButton btnDeselectAll;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private System.Windows.Forms.Panel pnlHeader;
        private DevExpress.XtraGrid.GridControl gridArrangement;
        private DevExpress.XtraGrid.Views.Grid.GridView arrangementView;
        private DevExpress.XtraGrid.Columns.GridColumn clId;
        private DevExpress.XtraGrid.Columns.GridColumn clDate;
        private DevExpress.XtraGrid.Columns.GridColumn clTime;
        private DevExpress.XtraGrid.Columns.GridColumn clCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn clAddress;
        private DevExpress.XtraGrid.Columns.GridColumn clNote;
        private DevExpress.XtraGrid.Columns.GridColumn clKoli;
        private DevExpress.XtraGrid.Columns.GridColumn clWeight;
        private DevExpress.XtraGrid.Columns.GridColumn clVehicle;
        private DevExpress.XtraGrid.Columns.GridColumn clMessenger;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn clMsgId;
        private DevExpress.XtraGrid.Columns.GridColumn clPU;
        private DevExpress.XtraGrid.Columns.GridColumn clState;
        private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit1;
        private System.Windows.Forms.Label label1;
        private Common.Component.dLookup dLookup1;
        private DevExpress.XtraEditors.SimpleButton btnFilter;
    }
}