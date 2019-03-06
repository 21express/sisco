namespace SISCO.Presentation.Operation.Forms
{
    partial class PickupResultForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickupResultForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnDeselectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lkpPayment = new SISCO.Presentation.Common.Component.dLookup();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxFilterMessenger = new SISCO.Presentation.Common.Component.dLookup();
            this.btnFilter = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.gridResult = new DevExpress.XtraGrid.GridControl();
            this.resultView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clKoli = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clVehicle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clMessenger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clMsgId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPUNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemPopupContainerEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.pnlFooter.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPayment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFilterMessenger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(822, 5);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 29);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.btnDeselectAll);
            this.pnlFooter.Controls.Add(this.btnSelectAll);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 433);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(915, 41);
            this.pnlFooter.TabIndex = 5;
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeselectAll.Enabled = false;
            this.btnDeselectAll.Location = new System.Drawing.Point(87, 4);
            this.btnDeselectAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(80, 31);
            this.btnDeselectAll.TabIndex = 3;
            this.btnDeselectAll.Text = "Deselect All";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.Enabled = false;
            this.btnSelectAll.Location = new System.Drawing.Point(3, 4);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(80, 30);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = "Select All";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Location = new System.Drawing.Point(827, 4);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 30);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.lkpPayment);
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Controls.Add(this.tbxFilterMessenger);
            this.pnlHeader.Controls.Add(this.btnFilter);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(915, 40);
            this.pnlHeader.TabIndex = 4;
            // 
            // lkpPayment
            // 
            this.lkpPayment.AutoCompleteDataManager = null;
            this.lkpPayment.AutoCompleteDisplayFormater = null;
            this.lkpPayment.AutoCompleteInitialized = false;
            this.lkpPayment.AutocompleteMinimumTextLength = 0;
            this.lkpPayment.AutoCompleteText = null;
            this.lkpPayment.AutoCompleteWhereExpression = null;
            this.lkpPayment.AutoCompleteWheretermFormater = null;
            this.lkpPayment.ClearOnLeave = true;
            this.lkpPayment.DisplayString = null;
            this.lkpPayment.FieldLabel = null;
            this.lkpPayment.Location = new System.Drawing.Point(359, 7);
            this.lkpPayment.LookupPopup = null;
            this.lkpPayment.Name = "lkpPayment";
            this.lkpPayment.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpPayment.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpPayment.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpPayment.Properties.AutoCompleteDataManager = null;
            this.lkpPayment.Properties.AutoCompleteDisplayFormater = null;
            this.lkpPayment.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpPayment.Properties.AutoCompleteText = null;
            this.lkpPayment.Properties.AutoCompleteWhereExpression = null;
            this.lkpPayment.Properties.AutoCompleteWheretermFormater = null;
            this.lkpPayment.Properties.AutoHeight = false;
            this.lkpPayment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpPayment.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.lkpPayment.Properties.LookupPopup = null;
            this.lkpPayment.Properties.NullText = "<<Choose...>>";
            this.lkpPayment.Size = new System.Drawing.Size(169, 24);
            this.lkpPayment.TabIndex = 8;
            this.lkpPayment.ValidationRules = null;
            this.lkpPayment.Value = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(254, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Payment Method";
            // 
            // tbxFilterMessenger
            // 
            this.tbxFilterMessenger.AutoCompleteDataManager = null;
            this.tbxFilterMessenger.AutoCompleteDisplayFormater = null;
            this.tbxFilterMessenger.AutoCompleteInitialized = false;
            this.tbxFilterMessenger.AutocompleteMinimumTextLength = 0;
            this.tbxFilterMessenger.AutoCompleteText = null;
            this.tbxFilterMessenger.AutoCompleteWhereExpression = null;
            this.tbxFilterMessenger.AutoCompleteWheretermFormater = null;
            this.tbxFilterMessenger.ClearOnLeave = true;
            this.tbxFilterMessenger.DisplayString = null;
            this.tbxFilterMessenger.FieldLabel = null;
            this.tbxFilterMessenger.Location = new System.Drawing.Point(79, 7);
            this.tbxFilterMessenger.LookupPopup = null;
            this.tbxFilterMessenger.Name = "tbxFilterMessenger";
            this.tbxFilterMessenger.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFilterMessenger.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxFilterMessenger.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxFilterMessenger.Properties.AutoCompleteDataManager = null;
            this.tbxFilterMessenger.Properties.AutoCompleteDisplayFormater = null;
            this.tbxFilterMessenger.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxFilterMessenger.Properties.AutoCompleteText = null;
            this.tbxFilterMessenger.Properties.AutoCompleteWhereExpression = null;
            this.tbxFilterMessenger.Properties.AutoCompleteWheretermFormater = null;
            this.tbxFilterMessenger.Properties.AutoHeight = false;
            this.tbxFilterMessenger.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxFilterMessenger.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.tbxFilterMessenger.Properties.LookupPopup = null;
            this.tbxFilterMessenger.Properties.NullText = "<<Choose...>>";
            this.tbxFilterMessenger.Size = new System.Drawing.Size(169, 24);
            this.tbxFilterMessenger.TabIndex = 6;
            this.tbxFilterMessenger.ValidationRules = null;
            this.tbxFilterMessenger.Value = null;
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Location = new System.Drawing.Point(534, 4);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(58, 30);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "Filter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Messenger";
            // 
            // gridResult
            // 
            this.gridResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridResult.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridResult.Location = new System.Drawing.Point(0, 40);
            this.gridResult.MainView = this.resultView;
            this.gridResult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridResult.Name = "gridResult";
            this.gridResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemPopupContainerEdit1});
            this.gridResult.Size = new System.Drawing.Size(915, 393);
            this.gridResult.TabIndex = 7;
            this.gridResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.resultView});
            // 
            // resultView
            // 
            this.resultView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clNo,
            this.clId,
            this.clDate,
            this.clTime,
            this.gridColumn1,
            this.clCustomer,
            this.clAddress,
            this.clNote,
            this.clKoli,
            this.clWeight,
            this.clVehicle,
            this.clMessenger,
            this.clMsgId,
            this.clPU,
            this.clState,
            this.clPUNote});
            this.resultView.GridControl = this.gridResult;
            this.resultView.Name = "resultView";
            this.resultView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.resultView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.resultView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.resultView.OptionsView.ColumnAutoWidth = false;
            this.resultView.OptionsView.ShowGroupPanel = false;
            // 
            // clNo
            // 
            this.clNo.Caption = "No";
            this.clNo.Name = "clNo";
            this.clNo.OptionsColumn.AllowEdit = false;
            this.clNo.OptionsColumn.AllowFocus = false;
            this.clNo.OptionsColumn.AllowMove = false;
            this.clNo.OptionsColumn.ReadOnly = true;
            this.clNo.Visible = true;
            this.clNo.VisibleIndex = 0;
            this.clNo.Width = 28;
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
            this.clDate.VisibleIndex = 1;
            this.clDate.Width = 52;
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
            this.clTime.VisibleIndex = 2;
            this.clTime.Width = 45;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Payment Method";
            this.gridColumn1.FieldName = "PaymentMethodName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 91;
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
            this.clCustomer.VisibleIndex = 4;
            this.clCustomer.Width = 106;
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
            this.clAddress.VisibleIndex = 5;
            this.clAddress.Width = 85;
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
            this.clNote.VisibleIndex = 6;
            this.clNote.Width = 89;
            // 
            // clKoli
            // 
            this.clKoli.Caption = "Koli";
            this.clKoli.FieldName = "TtlPiece";
            this.clKoli.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clKoli.Name = "clKoli";
            this.clKoli.OptionsColumn.AllowMove = false;
            this.clKoli.Visible = true;
            this.clKoli.VisibleIndex = 7;
            this.clKoli.Width = 33;
            // 
            // clWeight
            // 
            this.clWeight.Caption = "Weight";
            this.clWeight.DisplayFormat.FormatString = "N0";
            this.clWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clWeight.FieldName = "TtlGrossWeight";
            this.clWeight.GroupFormat.FormatString = "N0";
            this.clWeight.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clWeight.Name = "clWeight";
            this.clWeight.Visible = true;
            this.clWeight.VisibleIndex = 8;
            this.clWeight.Width = 41;
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
            this.clVehicle.VisibleIndex = 10;
            this.clVehicle.Width = 48;
            // 
            // clMessenger
            // 
            this.clMessenger.Caption = "Messenger";
            this.clMessenger.FieldName = "MessengerName";
            this.clMessenger.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.clMessenger.Name = "clMessenger";
            this.clMessenger.OptionsColumn.AllowEdit = false;
            this.clMessenger.OptionsColumn.AllowFocus = false;
            this.clMessenger.OptionsColumn.AllowMove = false;
            this.clMessenger.OptionsColumn.ReadOnly = true;
            this.clMessenger.Visible = true;
            this.clMessenger.VisibleIndex = 9;
            this.clMessenger.Width = 72;
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
            this.clPU.VisibleIndex = 11;
            this.clPU.Width = 28;
            // 
            // clState
            // 
            this.clState.Caption = "State Change";
            this.clState.FieldName = "StateChange2";
            this.clState.Name = "clState";
            // 
            // clPUNote
            // 
            this.clPUNote.Caption = "PU Note";
            this.clPUNote.FieldName = "PickupNote";
            this.clPUNote.Name = "clPUNote";
            this.clPUNote.Visible = true;
            this.clPUNote.VisibleIndex = 12;
            this.clPUNote.Width = 228;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // repositoryItemPopupContainerEdit1
            // 
            this.repositoryItemPopupContainerEdit1.AutoHeight = false;
            this.repositoryItemPopupContainerEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemPopupContainerEdit1.Name = "repositoryItemPopupContainerEdit1";
            // 
            // PickupResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 474);
            this.Controls.Add(this.gridResult);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.Name = "PickupResultForm";
            this.Text = "Operation - Pick Up Result";
            this.pnlFooter.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPayment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFilterMessenger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Panel pnlFooter;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private System.Windows.Forms.Panel pnlHeader;
        private DevExpress.XtraGrid.GridControl gridResult;
        private DevExpress.XtraGrid.Views.Grid.GridView resultView;
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
        private DevExpress.XtraEditors.SimpleButton btnFilter;
        private DevExpress.XtraGrid.Columns.GridColumn clPUNote;
        private Common.Component.dLookup tbxFilterMessenger;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private Common.Component.dLookup lkpPayment;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnDeselectAll;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}