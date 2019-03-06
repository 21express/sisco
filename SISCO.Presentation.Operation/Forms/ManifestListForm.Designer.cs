namespace SISCO.Presentation.Operation.Forms
{
    partial class ManifestListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManifestListForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.tbxDestination = new SISCO.Presentation.Common.Component.dLookup();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.GridManifestList = new DevExpress.XtraGrid.GridControl();
            this.ManifestListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDest = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPiece = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clChargeable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPrint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDestination.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridManifestList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManifestListView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(60, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dest. Branch";
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(98, 4);
            this.tbxDate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
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
            this.tbxDate.Properties.NullText = "<<Choose...>>";
            this.tbxDate.Size = new System.Drawing.Size(229, 24);
            this.tbxDate.TabIndex = 2;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // tbxDestination
            // 
            this.tbxDestination.AutoCompleteDataManager = null;
            this.tbxDestination.AutoCompleteDisplayFormater = null;
            this.tbxDestination.AutoCompleteInitialized = false;
            this.tbxDestination.AutocompleteMinimumTextLength = 0;
            this.tbxDestination.AutoCompleteText = null;
            this.tbxDestination.AutoCompleteWhereExpression = null;
            this.tbxDestination.AutoCompleteWheretermFormater = null;
            this.tbxDestination.ClearOnLeave = true;
            this.tbxDestination.DisplayString = null;
            this.tbxDestination.FieldLabel = null;
            this.tbxDestination.Location = new System.Drawing.Point(98, 31);
            this.tbxDestination.LookupPopup = null;
            this.tbxDestination.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbxDestination.Name = "tbxDestination";
            this.tbxDestination.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDestination.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxDestination.Properties.Appearance.Options.UseFont = true;
            this.tbxDestination.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxDestination.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxDestination.Properties.AutoCompleteDataManager = null;
            this.tbxDestination.Properties.AutoCompleteDisplayFormater = null;
            this.tbxDestination.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxDestination.Properties.AutoCompleteText = null;
            this.tbxDestination.Properties.AutoCompleteWhereExpression = null;
            this.tbxDestination.Properties.AutoCompleteWheretermFormater = null;
            this.tbxDestination.Properties.AutoHeight = false;
            this.tbxDestination.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxDestination.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxDestination.Properties.LookupPopup = null;
            this.tbxDestination.Properties.NullText = "<<Choose...>>";
            this.tbxDestination.Size = new System.Drawing.Size(401, 24);
            this.tbxDestination.TabIndex = 3;
            this.tbxDestination.ValidationRules = null;
            this.tbxDestination.Value = null;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(98, 59);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(101, 30);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "View";
            // 
            // GridManifestList
            // 
            this.GridManifestList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridManifestList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.GridManifestList.Location = new System.Drawing.Point(0, 95);
            this.GridManifestList.MainView = this.ManifestListView;
            this.GridManifestList.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.GridManifestList.Name = "GridManifestList";
            this.GridManifestList.Size = new System.Drawing.Size(896, 355);
            this.GridManifestList.TabIndex = 5;
            this.GridManifestList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ManifestListView});
            // 
            // ManifestListView
            // 
            this.ManifestListView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clNo,
            this.clCode,
            this.clDest,
            this.clPiece,
            this.clWeight,
            this.clChargeable,
            this.clPrint,
            this.gridColumn1});
            this.ManifestListView.GridControl = this.GridManifestList;
            this.ManifestListView.Name = "ManifestListView";
            this.ManifestListView.OptionsView.ShowFooter = true;
            this.ManifestListView.OptionsView.ShowGroupPanel = false;
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
            this.clNo.Width = 27;
            // 
            // clCode
            // 
            this.clCode.Caption = "Manifest";
            this.clCode.FieldName = "Code";
            this.clCode.Name = "clCode";
            this.clCode.OptionsColumn.AllowEdit = false;
            this.clCode.OptionsColumn.AllowFocus = false;
            this.clCode.OptionsColumn.AllowMove = false;
            this.clCode.OptionsColumn.ReadOnly = true;
            this.clCode.Visible = true;
            this.clCode.VisibleIndex = 1;
            this.clCode.Width = 198;
            // 
            // clDest
            // 
            this.clDest.Caption = "Dest";
            this.clDest.FieldName = "DestBranch";
            this.clDest.Name = "clDest";
            this.clDest.OptionsColumn.AllowEdit = false;
            this.clDest.OptionsColumn.AllowFocus = false;
            this.clDest.OptionsColumn.AllowMove = false;
            this.clDest.OptionsColumn.ReadOnly = true;
            this.clDest.Visible = true;
            this.clDest.VisibleIndex = 2;
            this.clDest.Width = 221;
            // 
            // clPiece
            // 
            this.clPiece.Caption = "Piece";
            this.clPiece.DisplayFormat.FormatString = "#,#0";
            this.clPiece.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clPiece.FieldName = "TtlPiece";
            this.clPiece.Name = "clPiece";
            this.clPiece.OptionsColumn.AllowEdit = false;
            this.clPiece.OptionsColumn.AllowFocus = false;
            this.clPiece.OptionsColumn.AllowMove = false;
            this.clPiece.OptionsColumn.ReadOnly = true;
            this.clPiece.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TtlPiece", "{0:#,#0}")});
            this.clPiece.Visible = true;
            this.clPiece.VisibleIndex = 3;
            this.clPiece.Width = 62;
            // 
            // clWeight
            // 
            this.clWeight.Caption = "Weight";
            this.clWeight.DisplayFormat.FormatString = "#,#0";
            this.clWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clWeight.FieldName = "TtlGrossWeight";
            this.clWeight.Name = "clWeight";
            this.clWeight.OptionsColumn.AllowEdit = false;
            this.clWeight.OptionsColumn.AllowFocus = false;
            this.clWeight.OptionsColumn.AllowMove = false;
            this.clWeight.OptionsColumn.ReadOnly = true;
            this.clWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TtlGrossWeight", "{0:#,#0.0}")});
            this.clWeight.Visible = true;
            this.clWeight.VisibleIndex = 4;
            this.clWeight.Width = 64;
            // 
            // clChargeable
            // 
            this.clChargeable.Caption = "Chargeable";
            this.clChargeable.DisplayFormat.FormatString = "#,#0";
            this.clChargeable.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clChargeable.FieldName = "TtlChargeableWeight";
            this.clChargeable.Name = "clChargeable";
            this.clChargeable.OptionsColumn.AllowEdit = false;
            this.clChargeable.OptionsColumn.AllowFocus = false;
            this.clChargeable.OptionsColumn.AllowMove = false;
            this.clChargeable.OptionsColumn.ReadOnly = true;
            this.clChargeable.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TtlChargeableWeight", "{0:#,#0.0}")});
            this.clChargeable.Visible = true;
            this.clChargeable.VisibleIndex = 5;
            this.clChargeable.Width = 104;
            // 
            // clPrint
            // 
            this.clPrint.Caption = "Print";
            this.clPrint.FieldName = "Printed";
            this.clPrint.Name = "clPrint";
            this.clPrint.OptionsColumn.AllowEdit = false;
            this.clPrint.OptionsColumn.AllowFocus = false;
            this.clPrint.OptionsColumn.AllowMove = false;
            this.clPrint.OptionsColumn.ReadOnly = true;
            this.clPrint.Visible = true;
            this.clPrint.VisibleIndex = 6;
            this.clPrint.Width = 38;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Via";
            this.gridColumn1.FieldName = "ShippingPlan";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 7;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(783, 454);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(107, 32);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Save To Excel";
            // 
            // ManifestListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(895, 489);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.GridManifestList);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.tbxDestination);
            this.Controls.Add(this.tbxDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ManifestListForm";
            this.Text = "Operation - Manifest List";
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDestination.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridManifestList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManifestListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Common.Component.dCalendar tbxDate;
        private Common.Component.dLookup tbxDestination;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraGrid.GridControl GridManifestList;
        private DevExpress.XtraGrid.Views.Grid.GridView ManifestListView;
        private DevExpress.XtraGrid.Columns.GridColumn clCode;
        private DevExpress.XtraGrid.Columns.GridColumn clDest;
        private DevExpress.XtraGrid.Columns.GridColumn clPiece;
        private DevExpress.XtraGrid.Columns.GridColumn clWeight;
        private DevExpress.XtraGrid.Columns.GridColumn clChargeable;
        private DevExpress.XtraGrid.Columns.GridColumn clPrint;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}