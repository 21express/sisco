namespace SISCO.Presentation.CounterCash.Forms
{
    partial class FranchiseAcceptanceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FranchiseAcceptanceForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblFranchise = new System.Windows.Forms.Label();
            this.tbxPickup = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pnlPod = new System.Windows.Forms.Panel();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.tbxPod = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GridAcceptanceList = new DevExpress.XtraGrid.GridControl();
            this.AcceptanceListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clKoli = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn41 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn43 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridAcceptance = new DevExpress.XtraGrid.GridControl();
            this.AcceptanceView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            this.pnlPod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridAcceptanceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptanceListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridAcceptance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptanceView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlInfo
            // 
            this.pnlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfo.Controls.Add(this.lblFranchise);
            this.pnlInfo.Controls.Add(this.tbxPickup);
            this.pnlInfo.Controls.Add(this.label2);
            this.pnlInfo.Controls.Add(this.tbxDate);
            this.pnlInfo.Controls.Add(this.label1);
            this.pnlInfo.Location = new System.Drawing.Point(5, 42);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(482, 92);
            this.pnlInfo.TabIndex = 1;
            // 
            // lblFranchise
            // 
            this.lblFranchise.AutoSize = true;
            this.lblFranchise.Location = new System.Drawing.Point(112, 67);
            this.lblFranchise.Name = "lblFranchise";
            this.lblFranchise.Size = new System.Drawing.Size(24, 17);
            this.lblFranchise.TabIndex = 3;
            this.lblFranchise.Text = "    ";
            // 
            // tbxPickup
            // 
            this.tbxPickup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxPickup.BackColor = System.Drawing.SystemColors.Window;
            this.tbxPickup.Capslock = true;
            this.tbxPickup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxPickup.FieldLabel = null;
            this.tbxPickup.Location = new System.Drawing.Point(115, 37);
            this.tbxPickup.Name = "tbxPickup";
            this.tbxPickup.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPickup.Size = new System.Drawing.Size(326, 24);
            this.tbxPickup.TabIndex = 2;
            this.tbxPickup.ValidationRules = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "No. Pickup";
            // 
            // tbxDate
            // 
            this.tbxDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(115, 10);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.tbxDate.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxDate.Properties.Appearance.Options.UseBackColor = true;
            this.tbxDate.Properties.Appearance.Options.UseFont = true;
            this.tbxDate.Properties.AutoHeight = false;
            this.tbxDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
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
            this.tbxDate.Size = new System.Drawing.Size(140, 24);
            this.tbxDate.TabIndex = 1;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // pnlPod
            // 
            this.pnlPod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlPod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPod.Controls.Add(this.btnAdd);
            this.pnlPod.Controls.Add(this.tbxPod);
            this.pnlPod.Controls.Add(this.label3);
            this.pnlPod.Location = new System.Drawing.Point(492, 42);
            this.pnlPod.Name = "pnlPod";
            this.pnlPod.Size = new System.Drawing.Size(327, 92);
            this.pnlPod.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(17, 62);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 25);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            // 
            // tbxPod
            // 
            this.tbxPod.Capslock = true;
            this.tbxPod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxPod.FieldLabel = null;
            this.tbxPod.Location = new System.Drawing.Point(17, 33);
            this.tbxPod.Name = "tbxPod";
            this.tbxPod.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPod.Size = new System.Drawing.Size(275, 24);
            this.tbxPod.TabIndex = 3;
            this.tbxPod.ValidationRules = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "POD";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(5, 140);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GridAcceptanceList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GridAcceptance);
            this.splitContainer1.Size = new System.Drawing.Size(906, 327);
            this.splitContainer1.SplitterDistance = 451;
            this.splitContainer1.TabIndex = 3;
            // 
            // GridAcceptanceList
            // 
            this.GridAcceptanceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridAcceptanceList.Location = new System.Drawing.Point(0, 0);
            this.GridAcceptanceList.MainView = this.AcceptanceListView;
            this.GridAcceptanceList.Name = "GridAcceptanceList";
            this.GridAcceptanceList.Size = new System.Drawing.Size(451, 327);
            this.GridAcceptanceList.TabIndex = 5;
            this.GridAcceptanceList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.AcceptanceListView});
            // 
            // AcceptanceListView
            // 
            this.AcceptanceListView.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.AcceptanceListView.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Transparent;
            this.AcceptanceListView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.AcceptanceListView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Transparent;
            this.AcceptanceListView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Transparent;
            this.AcceptanceListView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.AcceptanceListView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clNo,
            this.clShipment,
            this.clKoli,
            this.clWeight,
            this.clState,
            this.gridColumn28,
            this.gridColumn37,
            this.gridColumn38,
            this.gridColumn39,
            this.gridColumn41,
            this.gridColumn43});
            this.AcceptanceListView.GridControl = this.GridAcceptanceList;
            this.AcceptanceListView.Name = "AcceptanceListView";
            this.AcceptanceListView.OptionsView.ShowFooter = true;
            this.AcceptanceListView.OptionsView.ShowGroupPanel = false;
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
            this.clNo.Width = 31;
            // 
            // clShipment
            // 
            this.clShipment.Caption = "Shipment";
            this.clShipment.FieldName = "ShipmentCode";
            this.clShipment.Name = "clShipment";
            this.clShipment.OptionsColumn.AllowEdit = false;
            this.clShipment.OptionsColumn.AllowFocus = false;
            this.clShipment.OptionsColumn.AllowMove = false;
            this.clShipment.OptionsColumn.ReadOnly = true;
            this.clShipment.Visible = true;
            this.clShipment.VisibleIndex = 1;
            this.clShipment.Width = 148;
            // 
            // clKoli
            // 
            this.clKoli.Caption = "Koli";
            this.clKoli.FieldName = "TtlPiece";
            this.clKoli.Name = "clKoli";
            this.clKoli.OptionsColumn.AllowEdit = false;
            this.clKoli.OptionsColumn.AllowFocus = false;
            this.clKoli.OptionsColumn.AllowMove = false;
            this.clKoli.OptionsColumn.ReadOnly = true;
            this.clKoli.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clKoli.Visible = true;
            this.clKoli.VisibleIndex = 2;
            this.clKoli.Width = 42;
            // 
            // clWeight
            // 
            this.clWeight.Caption = "Weight";
            this.clWeight.FieldName = "TtlGrossWeight";
            this.clWeight.Name = "clWeight";
            this.clWeight.OptionsColumn.AllowEdit = false;
            this.clWeight.OptionsColumn.AllowFocus = false;
            this.clWeight.OptionsColumn.AllowMove = false;
            this.clWeight.OptionsColumn.ReadOnly = true;
            this.clWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clWeight.Visible = true;
            this.clWeight.VisibleIndex = 3;
            this.clWeight.Width = 87;
            // 
            // clState
            // 
            this.clState.Caption = "State";
            this.clState.FieldName = "StateChange2";
            this.clState.Name = "clState";
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "gridColumn28";
            this.gridColumn28.FieldName = "ShipmentId";
            this.gridColumn28.Name = "gridColumn28";
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "gridColumn37";
            this.gridColumn37.FieldName = "ServiceTypeId";
            this.gridColumn37.Name = "gridColumn37";
            // 
            // gridColumn38
            // 
            this.gridColumn38.Caption = "gridColumn38";
            this.gridColumn38.FieldName = "PackageTypeId";
            this.gridColumn38.Name = "gridColumn38";
            // 
            // gridColumn39
            // 
            this.gridColumn39.Caption = "gridColumn39";
            this.gridColumn39.FieldName = "PaymentMethodId";
            this.gridColumn39.Name = "gridColumn39";
            // 
            // gridColumn41
            // 
            this.gridColumn41.Caption = "gridColumn41";
            this.gridColumn41.FieldName = "TtlChargeableWeight";
            this.gridColumn41.Name = "gridColumn41";
            // 
            // gridColumn43
            // 
            this.gridColumn43.Caption = "gridColumn43";
            this.gridColumn43.FieldName = "ShipmentDate";
            this.gridColumn43.Name = "gridColumn43";
            // 
            // GridAcceptance
            // 
            this.GridAcceptance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridAcceptance.Location = new System.Drawing.Point(0, 0);
            this.GridAcceptance.MainView = this.AcceptanceView;
            this.GridAcceptance.Name = "GridAcceptance";
            this.GridAcceptance.Size = new System.Drawing.Size(451, 327);
            this.GridAcceptance.TabIndex = 6;
            this.GridAcceptance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.AcceptanceView});
            // 
            // AcceptanceView
            // 
            this.AcceptanceView.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.AcceptanceView.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Transparent;
            this.AcceptanceView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.AcceptanceView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Transparent;
            this.AcceptanceView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Transparent;
            this.AcceptanceView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.AcceptanceView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.AcceptanceView.GridControl = this.GridAcceptance;
            this.AcceptanceView.Name = "AcceptanceView";
            this.AcceptanceView.OptionsView.ShowFooter = true;
            this.AcceptanceView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 31;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Shipment";
            this.gridColumn2.FieldName = "ShipmentCode";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 148;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Koli";
            this.gridColumn3.FieldName = "TtlPiece";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 42;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Weight";
            this.gridColumn4.FieldName = "TtlGrossWeight";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 87;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "State";
            this.gridColumn5.FieldName = "StateChange2";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "gridColumn28";
            this.gridColumn6.FieldName = "ShipmentId";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "gridColumn37";
            this.gridColumn7.FieldName = "ServiceTypeId";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "gridColumn38";
            this.gridColumn8.FieldName = "PackageTypeId";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "gridColumn39";
            this.gridColumn9.FieldName = "PaymentMethodId";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "gridColumn41";
            this.gridColumn10.FieldName = "TtlChargeableWeight";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "gridColumn43";
            this.gridColumn11.FieldName = "ShipmentDate";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // FranchiseAcceptanceForm
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 468);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlPod);
            this.Controls.Add(this.pnlInfo);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FranchiseAcceptanceForm";
            this.Text = "Franchise Acceptance";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.Controls.SetChildIndex(this.pnlInfo, 0);
            this.Controls.SetChildIndex(this.pnlPod, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            this.pnlPod.ResumeLayout(false);
            this.pnlPod.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridAcceptanceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptanceListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridAcceptance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptanceView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlInfo;
        private Common.Component.dTextBox tbxPickup;
        private System.Windows.Forms.Label label2;
        private Common.Component.dCalendar tbxDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlPod;
        private Common.Component.dTextBox tbxPod;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl GridAcceptanceList;
        private DevExpress.XtraGrid.Views.Grid.GridView AcceptanceListView;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private DevExpress.XtraGrid.Columns.GridColumn clShipment;
        private DevExpress.XtraGrid.Columns.GridColumn clKoli;
        private DevExpress.XtraGrid.Columns.GridColumn clWeight;
        private DevExpress.XtraGrid.Columns.GridColumn clState;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn39;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn41;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn43;
        private System.Windows.Forms.Label lblFranchise;
        private DevExpress.XtraGrid.GridControl GridAcceptance;
        private DevExpress.XtraGrid.Views.Grid.GridView AcceptanceView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
    }
}