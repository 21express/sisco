namespace SISCO.Presentation.Operation.Forms
{
    partial class OnboardReportViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnboardReportViewForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.GridOnboard = new DevExpress.XtraGrid.GridControl();
            this.OnboardView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clAwb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clAirline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDest = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clFlight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clEstDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clEstTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clReincian = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPiece = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clActFlight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clActDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clAtd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clActNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clConfirmed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clId = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridOnboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnboardView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(39, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(80, 15);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxDate.Properties.Appearance.Options.UseBackColor = true;
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
            this.tbxDate.Size = new System.Drawing.Size(201, 24);
            this.tbxDate.TabIndex = 1;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // pnlBottom
            // 
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.btnPrint);
            this.pnlBottom.Controls.Add(this.btnPrintPreview);
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 393);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(810, 38);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(476, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(96, 32);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintPreview.Enabled = false;
            this.btnPrintPreview.Location = new System.Drawing.Point(578, 2);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(96, 32);
            this.btnPrintPreview.TabIndex = 1;
            this.btnPrintPreview.Text = "Print Preview";
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Location = new System.Drawing.Point(710, 2);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(96, 32);
            this.btnExcel.TabIndex = 0;
            this.btnExcel.Text = "Save To Excel";
            // 
            // GridOnboard
            // 
            this.GridOnboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridOnboard.Location = new System.Drawing.Point(0, 55);
            this.GridOnboard.MainView = this.OnboardView;
            this.GridOnboard.Name = "GridOnboard";
            this.GridOnboard.Size = new System.Drawing.Size(810, 339);
            this.GridOnboard.TabIndex = 8;
            this.GridOnboard.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.OnboardView});
            // 
            // OnboardView
            // 
            this.OnboardView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clNo,
            this.clAwb,
            this.clDate,
            this.clAirline,
            this.clDest,
            this.clFlight,
            this.clEstDate,
            this.clEstTime,
            this.clReincian,
            this.clPiece,
            this.clWeight,
            this.gridColumn1,
            this.gridColumn2,
            this.clActFlight,
            this.clActDate,
            this.clAtd,
            this.clActNote,
            this.clConfirmed,
            this.clId});
            this.OnboardView.GridControl = this.GridOnboard;
            this.OnboardView.Name = "OnboardView";
            this.OnboardView.OptionsView.ColumnAutoWidth = false;
            this.OnboardView.OptionsView.ShowGroupPanel = false;
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
            this.clNo.Width = 29;
            // 
            // clAwb
            // 
            this.clAwb.Caption = "AWB No.";
            this.clAwb.FieldName = "Code";
            this.clAwb.Name = "clAwb";
            this.clAwb.OptionsColumn.AllowEdit = false;
            this.clAwb.OptionsColumn.AllowFocus = false;
            this.clAwb.OptionsColumn.AllowMove = false;
            this.clAwb.OptionsColumn.ReadOnly = true;
            this.clAwb.Visible = true;
            this.clAwb.VisibleIndex = 1;
            this.clAwb.Width = 107;
            // 
            // clDate
            // 
            this.clDate.Caption = "Date";
            this.clDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.clDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clDate.FieldName = "DateProcess";
            this.clDate.Name = "clDate";
            this.clDate.OptionsColumn.AllowEdit = false;
            this.clDate.OptionsColumn.AllowFocus = false;
            this.clDate.OptionsColumn.AllowMove = false;
            this.clDate.OptionsColumn.ReadOnly = true;
            this.clDate.Visible = true;
            this.clDate.VisibleIndex = 2;
            this.clDate.Width = 51;
            // 
            // clAirline
            // 
            this.clAirline.Caption = "Airline";
            this.clAirline.FieldName = "Airline";
            this.clAirline.Name = "clAirline";
            this.clAirline.OptionsColumn.AllowEdit = false;
            this.clAirline.OptionsColumn.AllowFocus = false;
            this.clAirline.OptionsColumn.AllowMove = false;
            this.clAirline.OptionsColumn.ReadOnly = true;
            this.clAirline.Visible = true;
            this.clAirline.VisibleIndex = 3;
            this.clAirline.Width = 85;
            // 
            // clDest
            // 
            this.clDest.Caption = "Dest";
            this.clDest.FieldName = "DestAirport";
            this.clDest.Name = "clDest";
            this.clDest.OptionsColumn.AllowEdit = false;
            this.clDest.OptionsColumn.AllowFocus = false;
            this.clDest.OptionsColumn.AllowMove = false;
            this.clDest.OptionsColumn.ReadOnly = true;
            this.clDest.Visible = true;
            this.clDest.VisibleIndex = 4;
            this.clDest.Width = 100;
            // 
            // clFlight
            // 
            this.clFlight.Caption = "Est Flight";
            this.clFlight.FieldName = "Flight";
            this.clFlight.Name = "clFlight";
            this.clFlight.OptionsColumn.AllowEdit = false;
            this.clFlight.OptionsColumn.AllowFocus = false;
            this.clFlight.OptionsColumn.AllowMove = false;
            this.clFlight.OptionsColumn.ReadOnly = true;
            this.clFlight.Visible = true;
            this.clFlight.VisibleIndex = 5;
            this.clFlight.Width = 84;
            // 
            // clEstDate
            // 
            this.clEstDate.Caption = "Est Date";
            this.clEstDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.clEstDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clEstDate.FieldName = "EstDepDate";
            this.clEstDate.Name = "clEstDate";
            this.clEstDate.OptionsColumn.AllowEdit = false;
            this.clEstDate.OptionsColumn.AllowFocus = false;
            this.clEstDate.OptionsColumn.AllowMove = false;
            this.clEstDate.OptionsColumn.ReadOnly = true;
            this.clEstDate.Visible = true;
            this.clEstDate.VisibleIndex = 6;
            // 
            // clEstTime
            // 
            this.clEstTime.Caption = "ETD";
            this.clEstTime.FieldName = "EstDepTime";
            this.clEstTime.Name = "clEstTime";
            this.clEstTime.OptionsColumn.AllowEdit = false;
            this.clEstTime.OptionsColumn.AllowFocus = false;
            this.clEstTime.OptionsColumn.AllowMove = false;
            this.clEstTime.OptionsColumn.ReadOnly = true;
            this.clEstTime.Visible = true;
            this.clEstTime.VisibleIndex = 8;
            this.clEstTime.Width = 40;
            // 
            // clReincian
            // 
            this.clReincian.Caption = "Rincian";
            this.clReincian.FieldName = "Dimension";
            this.clReincian.Name = "clReincian";
            this.clReincian.OptionsColumn.AllowEdit = false;
            this.clReincian.OptionsColumn.AllowFocus = false;
            this.clReincian.OptionsColumn.AllowMove = false;
            this.clReincian.OptionsColumn.ReadOnly = true;
            this.clReincian.Visible = true;
            this.clReincian.VisibleIndex = 7;
            // 
            // clPiece
            // 
            this.clPiece.Caption = "Koli";
            this.clPiece.FieldName = "TtlPiece";
            this.clPiece.Name = "clPiece";
            this.clPiece.OptionsColumn.AllowEdit = false;
            this.clPiece.OptionsColumn.AllowFocus = false;
            this.clPiece.OptionsColumn.AllowMove = false;
            this.clPiece.OptionsColumn.ReadOnly = true;
            this.clPiece.Visible = true;
            this.clPiece.VisibleIndex = 9;
            this.clPiece.Width = 39;
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
            this.clWeight.Visible = true;
            this.clWeight.VisibleIndex = 10;
            this.clWeight.Width = 49;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Kilo SMU";
            this.gridColumn1.FieldName = "GwSmu";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 11;
            this.gridColumn1.Width = 56;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Selisih";
            this.gridColumn2.FieldName = "DiffSmu";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 12;
            this.gridColumn2.Width = 52;
            // 
            // clActFlight
            // 
            this.clActFlight.Caption = "Act Flight";
            this.clActFlight.FieldName = "ActFlight";
            this.clActFlight.Name = "clActFlight";
            this.clActFlight.OptionsColumn.AllowEdit = false;
            this.clActFlight.OptionsColumn.AllowFocus = false;
            this.clActFlight.OptionsColumn.AllowMove = false;
            this.clActFlight.OptionsColumn.ReadOnly = true;
            this.clActFlight.Visible = true;
            this.clActFlight.VisibleIndex = 14;
            this.clActFlight.Width = 77;
            // 
            // clActDate
            // 
            this.clActDate.Caption = "Act Date";
            this.clActDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.clActDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clActDate.FieldName = "ActDepDate";
            this.clActDate.Name = "clActDate";
            this.clActDate.OptionsColumn.AllowEdit = false;
            this.clActDate.OptionsColumn.AllowFocus = false;
            this.clActDate.OptionsColumn.AllowMove = false;
            this.clActDate.OptionsColumn.ReadOnly = true;
            this.clActDate.Visible = true;
            this.clActDate.VisibleIndex = 13;
            this.clActDate.Width = 82;
            // 
            // clAtd
            // 
            this.clAtd.Caption = "ATD";
            this.clAtd.FieldName = "ActDepTime";
            this.clAtd.Name = "clAtd";
            this.clAtd.OptionsColumn.AllowEdit = false;
            this.clAtd.OptionsColumn.AllowFocus = false;
            this.clAtd.OptionsColumn.AllowMove = false;
            this.clAtd.OptionsColumn.ReadOnly = true;
            this.clAtd.Visible = true;
            this.clAtd.VisibleIndex = 15;
            this.clAtd.Width = 58;
            // 
            // clActNote
            // 
            this.clActNote.Caption = "Note";
            this.clActNote.FieldName = "ActNote";
            this.clActNote.Name = "clActNote";
            this.clActNote.OptionsColumn.AllowEdit = false;
            this.clActNote.OptionsColumn.AllowFocus = false;
            this.clActNote.OptionsColumn.AllowMove = false;
            this.clActNote.OptionsColumn.ReadOnly = true;
            this.clActNote.Visible = true;
            this.clActNote.VisibleIndex = 16;
            this.clActNote.Width = 101;
            // 
            // clConfirmed
            // 
            this.clConfirmed.Caption = "Confrm";
            this.clConfirmed.FieldName = "ActConfirmed";
            this.clConfirmed.Name = "clConfirmed";
            this.clConfirmed.OptionsColumn.AllowEdit = false;
            this.clConfirmed.OptionsColumn.AllowFocus = false;
            this.clConfirmed.OptionsColumn.AllowMove = false;
            this.clConfirmed.OptionsColumn.ReadOnly = true;
            this.clConfirmed.Visible = true;
            this.clConfirmed.VisibleIndex = 17;
            this.clConfirmed.Width = 44;
            // 
            // clId
            // 
            this.clId.Caption = "Id";
            this.clId.FieldName = "Id";
            this.clId.Name = "clId";
            // 
            // OnboardReportViewForm
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 431);
            this.Controls.Add(this.GridOnboard);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.tbxDate);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "OnboardReportViewForm";
            this.Text = "Operation - Onboard Report View";
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridOnboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnboardView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Common.Component.dCalendar tbxDate;
        private System.Windows.Forms.Panel pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraGrid.GridControl GridOnboard;
        private DevExpress.XtraGrid.Views.Grid.GridView OnboardView;
        private DevExpress.XtraGrid.Columns.GridColumn clAwb;
        private DevExpress.XtraGrid.Columns.GridColumn clDate;
        private DevExpress.XtraGrid.Columns.GridColumn clAirline;
        private DevExpress.XtraGrid.Columns.GridColumn clDest;
        private DevExpress.XtraGrid.Columns.GridColumn clFlight;
        private DevExpress.XtraGrid.Columns.GridColumn clEstDate;
        private DevExpress.XtraGrid.Columns.GridColumn clEstTime;
        private DevExpress.XtraGrid.Columns.GridColumn clPiece;
        private DevExpress.XtraGrid.Columns.GridColumn clWeight;
        private DevExpress.XtraGrid.Columns.GridColumn clActFlight;
        private DevExpress.XtraGrid.Columns.GridColumn clActDate;
        private DevExpress.XtraGrid.Columns.GridColumn clAtd;
        private DevExpress.XtraGrid.Columns.GridColumn clActNote;
        private DevExpress.XtraGrid.Columns.GridColumn clConfirmed;
        private DevExpress.XtraGrid.Columns.GridColumn clId;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnPrintPreview;
        private DevExpress.XtraGrid.Columns.GridColumn clReincian;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}