namespace SISCO.Presentation.Operation.Forms
{
    partial class DeliveryOrderListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryOrderListForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxFrom = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tbxTo = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tbxCourier = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tbxFleet = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.GridDo = new DevExpress.XtraGrid.GridControl();
            this.DoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCourier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFleet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(41, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dari";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxFrom
            // 
            this.tbxFrom.EditValue = null;
            this.tbxFrom.FieldLabel = null;
            this.tbxFrom.FormatDateTime = "dd-MM-yyyy";
            this.tbxFrom.Location = new System.Drawing.Point(125, 5);
            this.tbxFrom.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbxFrom.Name = "tbxFrom";
            this.tbxFrom.Nullable = false;
            this.tbxFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFrom.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxFrom.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxFrom.Properties.Appearance.Options.UseBackColor = true;
            this.tbxFrom.Properties.Appearance.Options.UseFont = true;
            this.tbxFrom.Properties.AutoHeight = false;
            this.tbxFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxFrom.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.tbxFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxFrom.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxFrom.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxFrom.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxFrom.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxFrom.Size = new System.Drawing.Size(150, 24);
            this.tbxFrom.TabIndex = 1;
            this.tbxFrom.ValidationRules = null;
            this.tbxFrom.Value = new System.DateTime(((long)(0)));
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(41, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sampai";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxTo
            // 
            this.tbxTo.EditValue = null;
            this.tbxTo.FieldLabel = null;
            this.tbxTo.FormatDateTime = "dd-MM-yyyy";
            this.tbxTo.Location = new System.Drawing.Point(125, 31);
            this.tbxTo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbxTo.Name = "tbxTo";
            this.tbxTo.Nullable = false;
            this.tbxTo.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTo.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxTo.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTo.Properties.Appearance.Options.UseBackColor = true;
            this.tbxTo.Properties.Appearance.Options.UseFont = true;
            this.tbxTo.Properties.AutoHeight = false;
            this.tbxTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxTo.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxTo.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxTo.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxTo.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxTo.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxTo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTo.Size = new System.Drawing.Size(150, 24);
            this.tbxTo.TabIndex = 3;
            this.tbxTo.ValidationRules = null;
            this.tbxTo.Value = new System.DateTime(((long)(0)));
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(41, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kurir";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxCourier
            // 
            this.tbxCourier.AutoCompleteDataManager = null;
            this.tbxCourier.AutoCompleteDisplayFormater = null;
            this.tbxCourier.AutoCompleteInitialized = false;
            this.tbxCourier.AutocompleteMinimumTextLength = 0;
            this.tbxCourier.AutoCompleteText = null;
            this.tbxCourier.AutoCompleteWhereExpression = null;
            this.tbxCourier.AutoCompleteWheretermFormater = null;
            this.tbxCourier.ClearOnLeave = true;
            this.tbxCourier.DisplayString = null;
            this.tbxCourier.FieldLabel = null;
            this.tbxCourier.Location = new System.Drawing.Point(125, 57);
            this.tbxCourier.LookupPopup = null;
            this.tbxCourier.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbxCourier.Name = "tbxCourier";
            this.tbxCourier.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxCourier.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxCourier.Properties.Appearance.Options.UseFont = true;
            this.tbxCourier.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxCourier.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxCourier.Properties.AutoCompleteDataManager = null;
            this.tbxCourier.Properties.AutoCompleteDisplayFormater = null;
            this.tbxCourier.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxCourier.Properties.AutoCompleteText = null;
            this.tbxCourier.Properties.AutoCompleteWhereExpression = null;
            this.tbxCourier.Properties.AutoCompleteWheretermFormater = null;
            this.tbxCourier.Properties.AutoHeight = false;
            this.tbxCourier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxCourier.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.tbxCourier.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxCourier.Properties.LookupPopup = null;
            this.tbxCourier.Properties.NullText = "<<Choose...>>";
            this.tbxCourier.Size = new System.Drawing.Size(331, 24);
            this.tbxCourier.TabIndex = 5;
            this.tbxCourier.ValidationRules = null;
            this.tbxCourier.Value = null;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(41, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Kendaraan";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxFleet
            // 
            this.tbxFleet.AutoCompleteDataManager = null;
            this.tbxFleet.AutoCompleteDisplayFormater = null;
            this.tbxFleet.AutoCompleteInitialized = false;
            this.tbxFleet.AutocompleteMinimumTextLength = 0;
            this.tbxFleet.AutoCompleteText = null;
            this.tbxFleet.AutoCompleteWhereExpression = null;
            this.tbxFleet.AutoCompleteWheretermFormater = null;
            this.tbxFleet.ClearOnLeave = true;
            this.tbxFleet.DisplayString = null;
            this.tbxFleet.FieldLabel = null;
            this.tbxFleet.Location = new System.Drawing.Point(125, 83);
            this.tbxFleet.LookupPopup = null;
            this.tbxFleet.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbxFleet.Name = "tbxFleet";
            this.tbxFleet.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFleet.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxFleet.Properties.Appearance.Options.UseFont = true;
            this.tbxFleet.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxFleet.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxFleet.Properties.AutoCompleteDataManager = null;
            this.tbxFleet.Properties.AutoCompleteDisplayFormater = null;
            this.tbxFleet.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxFleet.Properties.AutoCompleteText = null;
            this.tbxFleet.Properties.AutoCompleteWhereExpression = null;
            this.tbxFleet.Properties.AutoCompleteWheretermFormater = null;
            this.tbxFleet.Properties.AutoHeight = false;
            this.tbxFleet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxFleet.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.tbxFleet.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxFleet.Properties.LookupPopup = null;
            this.tbxFleet.Properties.NullText = "<<Choose...>>";
            this.tbxFleet.Size = new System.Drawing.Size(199, 24);
            this.tbxFleet.TabIndex = 7;
            this.tbxFleet.ValidationRules = null;
            this.tbxFleet.Value = null;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(125, 109);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(83, 32);
            this.btnView.TabIndex = 8;
            this.btnView.Text = "View";
            // 
            // GridDo
            // 
            this.GridDo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridDo.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.GridDo.Location = new System.Drawing.Point(-1, 146);
            this.GridDo.MainView = this.DoView;
            this.GridDo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.GridDo.Name = "GridDo";
            this.GridDo.Size = new System.Drawing.Size(975, 347);
            this.GridDo.TabIndex = 9;
            this.GridDo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DoView});
            // 
            // DoView
            // 
            this.DoView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn5,
            this.gridColumn8});
            this.DoView.GridControl = this.GridDo;
            this.DoView.Name = "DoView";
            this.DoView.OptionsView.ShowFooter = true;
            this.DoView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No.";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 39;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Date";
            this.gridColumn2.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "DateProcess";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 111;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Code";
            this.gridColumn3.FieldName = "Code";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 192;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Kurir";
            this.gridColumn4.FieldName = "MessengerName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 226;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Koli";
            this.gridColumn6.DisplayFormat.FormatString = "#0";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn6.FieldName = "TtlPiece";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 96;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "GW";
            this.gridColumn7.DisplayFormat.FormatString = "#0.0";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn7.FieldName = "TtlGrossWeight";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TtlGrossWeight", "{0:#0.0}")});
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 57;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Kendaraan";
            this.gridColumn5.FieldName = "FleetNumber";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            this.gridColumn5.Width = 146;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Jenis Kendaraan";
            this.gridColumn8.FieldName = "VehicleType";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 90;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(863, 109);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(101, 32);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Save to Excel";
            // 
            // DeliveryOrderListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 493);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.GridDo);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.tbxFleet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxCourier);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxFrom);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DeliveryOrderListForm";
            this.Text = "Operation - Delivery Order List";
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCourier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFleet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Common.Component.dCalendar tbxFrom;
        private System.Windows.Forms.Label label2;
        private Common.Component.dCalendar tbxTo;
        private System.Windows.Forms.Label label3;
        private Common.Component.dLookup tbxCourier;
        private System.Windows.Forms.Label label4;
        private Common.Component.dLookup tbxFleet;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraGrid.GridControl GridDo;
        private DevExpress.XtraGrid.Views.Grid.GridView DoView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;

    }
}