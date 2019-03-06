using DevExpress.XtraEditors;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.ComponentRepositories;
using SISCO.Presentation.Common.Forms;

namespace SISCO.Presentation.Operation.Forms
{
    partial class PickupArrangementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickupArrangementForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnFilter = new DevExpress.XtraEditors.SimpleButton();
            this.lkpPayment = new SISCO.Presentation.Common.Component.dLookup();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeselectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnPrintPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.gridArrangement = new DevExpress.XtraGrid.GridControl();
            this.arrangementView = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.msgLookup = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.clMsgId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clConfirm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPayment.Properties)).BeginInit();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridArrangement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrangementView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.msgLookup)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.btnFilter);
            this.pnlHeader.Controls.Add(this.lkpPayment);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Controls.Add(this.btnDeselectAll);
            this.pnlHeader.Controls.Add(this.btnSelectAll);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(905, 37);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Location = new System.Drawing.Point(263, 4);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(62, 28);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "Filter";
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
            this.lkpPayment.Location = new System.Drawing.Point(72, 6);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpPayment.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpPayment.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpPayment.Properties.LookupPopup = null;
            this.lkpPayment.Properties.NullText = "<<Choose...>>";
            this.lkpPayment.Size = new System.Drawing.Size(185, 24);
            this.lkpPayment.TabIndex = 4;
            this.lkpPayment.ValidationRules = null;
            this.lkpPayment.Value = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Payment";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(807, 4);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(92, 28);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeselectAll.Enabled = false;
            this.btnDeselectAll.Location = new System.Drawing.Point(713, 4);
            this.btnDeselectAll.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(92, 28);
            this.btnDeselectAll.TabIndex = 1;
            this.btnDeselectAll.Text = "Deselect All";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.Enabled = false;
            this.btnSelectAll.Location = new System.Drawing.Point(618, 4);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(92, 28);
            this.btnSelectAll.TabIndex = 0;
            this.btnSelectAll.Text = "Select All";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.btnPrintPreview);
            this.pnlFooter.Controls.Add(this.btnPrint);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 448);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(905, 39);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintPreview.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPrintPreview.Enabled = false;
            this.btnPrintPreview.Location = new System.Drawing.Point(687, 3);
            this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(103, 30);
            this.btnPrintPreview.TabIndex = 3;
            this.btnPrintPreview.Text = "Print Preview";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(578, 3);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(103, 30);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(796, 3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            // 
            // gridArrangement
            // 
            this.gridArrangement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridArrangement.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.gridArrangement.Location = new System.Drawing.Point(0, 37);
            this.gridArrangement.MainView = this.arrangementView;
            this.gridArrangement.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.gridArrangement.Name = "gridArrangement";
            this.gridArrangement.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.msgLookup});
            this.gridArrangement.Size = new System.Drawing.Size(905, 411);
            this.gridArrangement.TabIndex = 3;
            this.gridArrangement.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.arrangementView});
            // 
            // arrangementView
            // 
            this.arrangementView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.clConfirm,
            this.clState});
            this.arrangementView.GridControl = this.gridArrangement;
            this.arrangementView.Name = "arrangementView";
            this.arrangementView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.arrangementView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.arrangementView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.arrangementView.OptionsView.ShowGroupPanel = false;
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
            this.clNo.Width = 20;
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
            this.clDate.Width = 71;
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
            this.clTime.Width = 42;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Payment Method";
            this.gridColumn1.FieldName = "PaymentMethodName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 57;
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
            this.clCustomer.Width = 94;
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
            this.clAddress.Width = 80;
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
            this.clNote.Width = 78;
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
            this.clKoli.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.clKoli.OptionsColumn.ReadOnly = true;
            this.clKoli.Width = 29;
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
            this.clWeight.OptionsColumn.AllowEdit = false;
            this.clWeight.OptionsColumn.AllowFocus = false;
            this.clWeight.OptionsColumn.AllowMove = false;
            this.clWeight.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.clWeight.OptionsColumn.ReadOnly = true;
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
            this.clVehicle.VisibleIndex = 8;
            this.clVehicle.Width = 44;
            // 
            // clMessenger
            // 
            this.clMessenger.Caption = "Messenger";
            this.clMessenger.ColumnEdit = this.msgLookup;
            this.clMessenger.FieldName = "MessengerName";
            this.clMessenger.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.clMessenger.Name = "clMessenger";
            this.clMessenger.Visible = true;
            this.clMessenger.VisibleIndex = 7;
            this.clMessenger.Width = 108;
            // 
            // msgLookup
            // 
            this.msgLookup.AutoHeight = false;
            this.msgLookup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.msgLookup.Name = "msgLookup";
            // 
            // clMsgId
            // 
            this.clMsgId.Caption = "Messenger ID";
            this.clMsgId.FieldName = "MessengerId";
            this.clMsgId.Name = "clMsgId";
            // 
            // clConfirm
            // 
            this.clConfirm.Caption = "Conf";
            this.clConfirm.FieldName = "Confirmed";
            this.clConfirm.Name = "clConfirm";
            this.clConfirm.Visible = true;
            this.clConfirm.VisibleIndex = 9;
            this.clConfirm.Width = 32;
            // 
            // clState
            // 
            this.clState.Caption = "State Change";
            this.clState.FieldName = "StateChange2";
            this.clState.Name = "clState";
            // 
            // PickupArrangementForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(905, 487);
            this.Controls.Add(this.gridArrangement);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PickupArrangementForm";
            this.Text = "Operation - Pick Up Arrangement";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPayment.Properties)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridArrangement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrangementView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.msgLookup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnDeselectAll;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private System.Windows.Forms.Panel pnlFooter;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.GridControl gridArrangement;
        private DevExpress.XtraGrid.Views.Grid.GridView arrangementView;
        private DevExpress.XtraGrid.Columns.GridColumn clDate;
        private DevExpress.XtraGrid.Columns.GridColumn clTime;
        private DevExpress.XtraGrid.Columns.GridColumn clCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn clAddress;
        private DevExpress.XtraGrid.Columns.GridColumn clNote;
        private DevExpress.XtraGrid.Columns.GridColumn clKoli;
        private DevExpress.XtraGrid.Columns.GridColumn clWeight;
        private DevExpress.XtraGrid.Columns.GridColumn clVehicle;
        private DevExpress.XtraGrid.Columns.GridColumn clMessenger;
        private DevExpress.XtraGrid.Columns.GridColumn clConfirm;
        private DevExpress.XtraGrid.Columns.GridColumn clMsgId;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit msgLookup;
        private DevExpress.XtraGrid.Columns.GridColumn clState;
        private DevExpress.XtraGrid.Columns.GridColumn clId;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private SimpleButton btnPrint;
        private SimpleButton btnPrintPreview;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private SimpleButton btnFilter;
        private dLookup lkpPayment;
        private System.Windows.Forms.Label label1;
    }
}