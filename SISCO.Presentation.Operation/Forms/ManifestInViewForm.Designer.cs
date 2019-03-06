namespace SISCO.Presentation.Operation.Forms
{
    partial class ManifestInViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManifestInViewForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxFrom = new SISCO.Presentation.Common.Component.dTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.GridManifest = new DevExpress.XtraGrid.GridControl();
            this.ManifestView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clShipmentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDestination = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clBayar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clService = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clKoli = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clChargeable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clConsol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridManifest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManifestView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(28, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.Enabled = false;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(66, 47);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.tbxDate.Properties.Appearance.Options.UseBackColor = true;
            this.tbxDate.Properties.AutoHeight = false;
            this.tbxDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, false, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.tbxDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxDate.Properties.NullText = "<<Choose...>>";
            this.tbxDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.tbxDate.Size = new System.Drawing.Size(161, 24);
            this.tbxDate.TabIndex = 2;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(23, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "From";
            // 
            // tbxFrom
            // 
            this.tbxFrom.Capslock = true;
            this.tbxFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxFrom.FieldLabel = null;
            this.tbxFrom.Location = new System.Drawing.Point(66, 73);
            this.tbxFrom.Name = "tbxFrom";
            this.tbxFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFrom.ReadOnly = true;
            this.tbxFrom.Size = new System.Drawing.Size(246, 24);
            this.tbxFrom.TabIndex = 4;
            this.tbxFrom.ValidationRules = null;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 424);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(899, 39);
            this.panel1.TabIndex = 5;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(820, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            // 
            // GridManifest
            // 
            this.GridManifest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridManifest.Location = new System.Drawing.Point(0, 110);
            this.GridManifest.MainView = this.ManifestView;
            this.GridManifest.Name = "GridManifest";
            this.GridManifest.Size = new System.Drawing.Size(899, 319);
            this.GridManifest.TabIndex = 6;
            this.GridManifest.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ManifestView});
            // 
            // ManifestView
            // 
            this.ManifestView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clNo,
            this.clShipment,
            this.clShipmentDate,
            this.clDestination,
            this.clBayar,
            this.clService,
            this.clKoli,
            this.clWeight,
            this.clChargeable,
            this.clConsol});
            this.ManifestView.GridControl = this.GridManifest;
            this.ManifestView.Name = "ManifestView";
            this.ManifestView.OptionsView.ShowFooter = true;
            this.ManifestView.OptionsView.ShowGroupPanel = false;
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
            this.clShipment.Width = 110;
            // 
            // clShipmentDate
            // 
            this.clShipmentDate.Caption = "Date";
            this.clShipmentDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.clShipmentDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clShipmentDate.FieldName = "ShipmentDate";
            this.clShipmentDate.Name = "clShipmentDate";
            this.clShipmentDate.OptionsColumn.AllowEdit = false;
            this.clShipmentDate.OptionsColumn.AllowFocus = false;
            this.clShipmentDate.OptionsColumn.AllowMove = false;
            this.clShipmentDate.OptionsColumn.ReadOnly = true;
            this.clShipmentDate.Visible = true;
            this.clShipmentDate.VisibleIndex = 2;
            this.clShipmentDate.Width = 88;
            // 
            // clDestination
            // 
            this.clDestination.Caption = "Destination";
            this.clDestination.FieldName = "DestCity";
            this.clDestination.Name = "clDestination";
            this.clDestination.OptionsColumn.AllowEdit = false;
            this.clDestination.OptionsColumn.AllowFocus = false;
            this.clDestination.OptionsColumn.AllowMove = false;
            this.clDestination.OptionsColumn.ReadOnly = true;
            this.clDestination.Visible = true;
            this.clDestination.VisibleIndex = 3;
            this.clDestination.Width = 90;
            // 
            // clBayar
            // 
            this.clBayar.Caption = "Bayar";
            this.clBayar.FieldName = "PaymentMethod";
            this.clBayar.Name = "clBayar";
            this.clBayar.OptionsColumn.AllowEdit = false;
            this.clBayar.OptionsColumn.AllowFocus = false;
            this.clBayar.OptionsColumn.AllowMove = false;
            this.clBayar.OptionsColumn.ReadOnly = true;
            this.clBayar.Visible = true;
            this.clBayar.VisibleIndex = 4;
            this.clBayar.Width = 86;
            // 
            // clService
            // 
            this.clService.Caption = "Service";
            this.clService.FieldName = "ServiceType";
            this.clService.Name = "clService";
            this.clService.OptionsColumn.AllowEdit = false;
            this.clService.OptionsColumn.AllowFocus = false;
            this.clService.OptionsColumn.AllowMove = false;
            this.clService.OptionsColumn.ReadOnly = true;
            this.clService.Visible = true;
            this.clService.VisibleIndex = 5;
            this.clService.Width = 57;
            // 
            // clKoli
            // 
            this.clKoli.Caption = "Koli";
            this.clKoli.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clKoli.FieldName = "TtlPiece";
            this.clKoli.Name = "clKoli";
            this.clKoli.OptionsColumn.AllowEdit = false;
            this.clKoli.OptionsColumn.AllowFocus = false;
            this.clKoli.OptionsColumn.AllowMove = false;
            this.clKoli.OptionsColumn.ReadOnly = true;
            this.clKoli.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clKoli.Visible = true;
            this.clKoli.VisibleIndex = 6;
            this.clKoli.Width = 41;
            // 
            // clWeight
            // 
            this.clWeight.Caption = "GW";
            this.clWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clWeight.FieldName = "TtlGrossWeight";
            this.clWeight.Name = "clWeight";
            this.clWeight.OptionsColumn.AllowEdit = false;
            this.clWeight.OptionsColumn.AllowFocus = false;
            this.clWeight.OptionsColumn.AllowMove = false;
            this.clWeight.OptionsColumn.ReadOnly = true;
            this.clWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clWeight.Visible = true;
            this.clWeight.VisibleIndex = 7;
            this.clWeight.Width = 36;
            // 
            // clChargeable
            // 
            this.clChargeable.Caption = "CW";
            this.clChargeable.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clChargeable.FieldName = "TtlChargeableWeight";
            this.clChargeable.Name = "clChargeable";
            this.clChargeable.OptionsColumn.AllowEdit = false;
            this.clChargeable.OptionsColumn.AllowFocus = false;
            this.clChargeable.OptionsColumn.AllowMove = false;
            this.clChargeable.OptionsColumn.ReadOnly = true;
            this.clChargeable.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clChargeable.Visible = true;
            this.clChargeable.VisibleIndex = 8;
            this.clChargeable.Width = 37;
            // 
            // clConsol
            // 
            this.clConsol.Caption = "Consol";
            this.clConsol.FieldName = "ConsolCode";
            this.clConsol.Name = "clConsol";
            this.clConsol.OptionsColumn.AllowEdit = false;
            this.clConsol.OptionsColumn.AllowFocus = false;
            this.clConsol.OptionsColumn.AllowMove = false;
            this.clConsol.OptionsColumn.ReadOnly = true;
            this.clConsol.Visible = true;
            this.clConsol.VisibleIndex = 9;
            this.clConsol.Width = 138;
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Location = new System.Drawing.Point(721, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(93, 25);
            this.btnExcel.TabIndex = 1;
            this.btnExcel.Text = "Save To Excel";
            // 
            // ManifestInViewForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(899, 463);
            this.Controls.Add(this.GridManifest);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbxFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxDate);
            this.Controls.Add(this.label1);
            this.Name = "ManifestInViewForm";
            this.Text = "Operation - Manifest In View";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbxDate, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbxFrom, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.GridManifest, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridManifest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManifestView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Common.Component.dCalendar tbxDate;
        private System.Windows.Forms.Label label2;
        private Common.Component.dTextBox tbxFrom;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraGrid.GridControl GridManifest;
        private DevExpress.XtraGrid.Views.Grid.GridView ManifestView;
        private DevExpress.XtraGrid.Columns.GridColumn clShipment;
        private DevExpress.XtraGrid.Columns.GridColumn clShipmentDate;
        private DevExpress.XtraGrid.Columns.GridColumn clDestination;
        private DevExpress.XtraGrid.Columns.GridColumn clBayar;
        private DevExpress.XtraGrid.Columns.GridColumn clService;
        private DevExpress.XtraGrid.Columns.GridColumn clKoli;
        private DevExpress.XtraGrid.Columns.GridColumn clWeight;
        private DevExpress.XtraGrid.Columns.GridColumn clChargeable;
        private DevExpress.XtraGrid.Columns.GridColumn clConsol;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
    }
}