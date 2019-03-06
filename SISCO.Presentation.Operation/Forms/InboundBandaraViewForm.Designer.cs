namespace SISCO.Presentation.Operation.Forms
{
    partial class InboundBandaraViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InboundBandaraViewForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxFrom = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tbxTo = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tbxOrigin = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tbxAirline = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
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
            this.clDimension = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPiece = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clKiloSmu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.clDiff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clActFlight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clActDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dateEditRepo1 = new SISCO.Presentation.Common.ComponentRepositories.DateEditRepo();
            this.clAtd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTimeEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.clActNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clSame = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clConfirmed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxOrigin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAirline.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridOnboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnboardView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditRepo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditRepo1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(65, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dari";
            // 
            // tbxFrom
            // 
            this.tbxFrom.EditValue = null;
            this.tbxFrom.FieldLabel = null;
            this.tbxFrom.FormatDateTime = "dd-MM-yyyy";
            this.tbxFrom.Location = new System.Drawing.Point(100, 11);
            this.tbxFrom.Name = "tbxFrom";
            this.tbxFrom.Nullable = false;
            this.tbxFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFrom.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxFrom.Properties.Appearance.Options.UseBackColor = true;
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
            this.tbxFrom.Size = new System.Drawing.Size(152, 24);
            this.tbxFrom.TabIndex = 1;
            this.tbxFrom.ValidationRules = null;
            this.tbxFrom.Value = new System.DateTime(((long)(0)));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(47, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sampai";
            // 
            // tbxTo
            // 
            this.tbxTo.EditValue = null;
            this.tbxTo.FieldLabel = null;
            this.tbxTo.FormatDateTime = "dd-MM-yyyy";
            this.tbxTo.Location = new System.Drawing.Point(100, 37);
            this.tbxTo.Name = "tbxTo";
            this.tbxTo.Nullable = false;
            this.tbxTo.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTo.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxTo.Properties.Appearance.Options.UseBackColor = true;
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
            this.tbxTo.Size = new System.Drawing.Size(152, 24);
            this.tbxTo.TabIndex = 3;
            this.tbxTo.ValidationRules = null;
            this.tbxTo.Value = new System.DateTime(((long)(0)));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Origin Airport";
            // 
            // tbxOrigin
            // 
            this.tbxOrigin.AutoCompleteDataManager = null;
            this.tbxOrigin.AutoCompleteDisplayFormater = null;
            this.tbxOrigin.AutoCompleteInitialized = false;
            this.tbxOrigin.AutocompleteMinimumTextLength = 0;
            this.tbxOrigin.AutoCompleteText = null;
            this.tbxOrigin.AutoCompleteWhereExpression = null;
            this.tbxOrigin.AutoCompleteWheretermFormater = null;
            this.tbxOrigin.ClearOnLeave = true;
            this.tbxOrigin.DisplayString = null;
            this.tbxOrigin.FieldLabel = null;
            this.tbxOrigin.Location = new System.Drawing.Point(100, 63);
            this.tbxOrigin.LookupPopup = null;
            this.tbxOrigin.Name = "tbxOrigin";
            this.tbxOrigin.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxOrigin.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxOrigin.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxOrigin.Properties.AutoCompleteDataManager = null;
            this.tbxOrigin.Properties.AutoCompleteDisplayFormater = null;
            this.tbxOrigin.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxOrigin.Properties.AutoCompleteText = null;
            this.tbxOrigin.Properties.AutoCompleteWhereExpression = null;
            this.tbxOrigin.Properties.AutoCompleteWheretermFormater = null;
            this.tbxOrigin.Properties.AutoHeight = false;
            this.tbxOrigin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxOrigin.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.tbxOrigin.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxOrigin.Properties.LookupPopup = null;
            this.tbxOrigin.Properties.NullText = "<<Choose...>>";
            this.tbxOrigin.Size = new System.Drawing.Size(225, 24);
            this.tbxOrigin.TabIndex = 5;
            this.tbxOrigin.ValidationRules = null;
            this.tbxOrigin.Value = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(53, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Airline";
            // 
            // tbxAirline
            // 
            this.tbxAirline.AutoCompleteDataManager = null;
            this.tbxAirline.AutoCompleteDisplayFormater = null;
            this.tbxAirline.AutoCompleteInitialized = false;
            this.tbxAirline.AutocompleteMinimumTextLength = 0;
            this.tbxAirline.AutoCompleteText = null;
            this.tbxAirline.AutoCompleteWhereExpression = null;
            this.tbxAirline.AutoCompleteWheretermFormater = null;
            this.tbxAirline.ClearOnLeave = true;
            this.tbxAirline.DisplayString = null;
            this.tbxAirline.FieldLabel = null;
            this.tbxAirline.Location = new System.Drawing.Point(100, 89);
            this.tbxAirline.LookupPopup = null;
            this.tbxAirline.Name = "tbxAirline";
            this.tbxAirline.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxAirline.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxAirline.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxAirline.Properties.AutoCompleteDataManager = null;
            this.tbxAirline.Properties.AutoCompleteDisplayFormater = null;
            this.tbxAirline.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxAirline.Properties.AutoCompleteText = null;
            this.tbxAirline.Properties.AutoCompleteWhereExpression = null;
            this.tbxAirline.Properties.AutoCompleteWheretermFormater = null;
            this.tbxAirline.Properties.AutoHeight = false;
            this.tbxAirline.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxAirline.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.tbxAirline.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxAirline.Properties.LookupPopup = null;
            this.tbxAirline.Properties.NullText = "<<Choose...>>";
            this.tbxAirline.Size = new System.Drawing.Size(225, 24);
            this.tbxAirline.TabIndex = 7;
            this.tbxAirline.ValidationRules = null;
            this.tbxAirline.Value = null;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(331, 82);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 31);
            this.btnView.TabIndex = 8;
            this.btnView.Text = "View";
            // 
            // GridOnboard
            // 
            this.GridOnboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridOnboard.Location = new System.Drawing.Point(-1, 127);
            this.GridOnboard.MainView = this.OnboardView;
            this.GridOnboard.Name = "GridOnboard";
            this.GridOnboard.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.dateEditRepo1,
            this.repositoryItemTextEdit1,
            this.repositoryItemTimeEdit1});
            this.GridOnboard.Size = new System.Drawing.Size(779, 299);
            this.GridOnboard.TabIndex = 9;
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
            this.clDimension,
            this.clPiece,
            this.clWeight,
            this.clKiloSmu,
            this.clDiff,
            this.clActFlight,
            this.clActDate,
            this.clAtd,
            this.clActNote,
            this.clSame,
            this.clConfirmed,
            this.clId,
            this.clState});
            this.OnboardView.GridControl = this.GridOnboard;
            this.OnboardView.Name = "OnboardView";
            this.OnboardView.OptionsView.ColumnAutoWidth = false;
            this.OnboardView.OptionsView.ShowGroupPanel = false;
            // 
            // clNo
            // 
            this.clNo.Caption = "No";
            this.clNo.Name = "clNo";
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
            this.clAwb.Width = 104;
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
            this.clDate.Width = 48;
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
            this.clAirline.Width = 68;
            // 
            // clDest
            // 
            this.clDest.Caption = "Origin";
            this.clDest.FieldName = "Airport";
            this.clDest.Name = "clDest";
            this.clDest.OptionsColumn.AllowEdit = false;
            this.clDest.OptionsColumn.AllowFocus = false;
            this.clDest.OptionsColumn.AllowMove = false;
            this.clDest.OptionsColumn.ReadOnly = true;
            this.clDest.Visible = true;
            this.clDest.VisibleIndex = 4;
            this.clDest.Width = 57;
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
            this.clFlight.Width = 65;
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
            this.clEstDate.Width = 65;
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
            this.clEstTime.VisibleIndex = 7;
            this.clEstTime.Width = 35;
            // 
            // clDimension
            // 
            this.clDimension.Caption = "Rincian";
            this.clDimension.FieldName = "Dimension";
            this.clDimension.Name = "clDimension";
            this.clDimension.Visible = true;
            this.clDimension.VisibleIndex = 8;
            // 
            // clPiece
            // 
            this.clPiece.Caption = "Koli";
            this.clPiece.DisplayFormat.FormatString = "#,#";
            this.clPiece.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
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
            this.clWeight.DisplayFormat.FormatString = "#,#";
            this.clWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
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
            // clKiloSmu
            // 
            this.clKiloSmu.Caption = "Kilo SMU";
            this.clKiloSmu.ColumnEdit = this.repositoryItemTextEdit1;
            this.clKiloSmu.DisplayFormat.FormatString = "#,#";
            this.clKiloSmu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clKiloSmu.FieldName = "GwSmu";
            this.clKiloSmu.Name = "clKiloSmu";
            this.clKiloSmu.OptionsColumn.AllowEdit = false;
            this.clKiloSmu.OptionsColumn.AllowFocus = false;
            this.clKiloSmu.OptionsColumn.AllowMove = false;
            this.clKiloSmu.OptionsColumn.ReadOnly = true;
            this.clKiloSmu.Visible = true;
            this.clKiloSmu.VisibleIndex = 11;
            this.clKiloSmu.Width = 48;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Mask.EditMask = "###.0";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // clDiff
            // 
            this.clDiff.Caption = "Selisih";
            this.clDiff.DisplayFormat.FormatString = "#,#";
            this.clDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.clDiff.FieldName = "DiffSmu";
            this.clDiff.Name = "clDiff";
            this.clDiff.OptionsColumn.AllowEdit = false;
            this.clDiff.OptionsColumn.AllowFocus = false;
            this.clDiff.OptionsColumn.AllowMove = false;
            this.clDiff.OptionsColumn.ReadOnly = true;
            this.clDiff.Visible = true;
            this.clDiff.VisibleIndex = 12;
            this.clDiff.Width = 44;
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
            this.clActFlight.Width = 60;
            // 
            // clActDate
            // 
            this.clActDate.Caption = "Act Date";
            this.clActDate.ColumnEdit = this.dateEditRepo1;
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
            this.clActDate.Width = 63;
            // 
            // dateEditRepo1
            // 
            this.dateEditRepo1.AutoHeight = false;
            this.dateEditRepo1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dateEditRepo1.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.dateEditRepo1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditRepo1.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.dateEditRepo1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditRepo1.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.dateEditRepo1.Mask.EditMask = "dd-MM-yyyy";
            this.dateEditRepo1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEditRepo1.Name = "dateEditRepo1";
            this.dateEditRepo1.NullText = "<<Choose...>>";
            // 
            // clAtd
            // 
            this.clAtd.Caption = "ATD";
            this.clAtd.ColumnEdit = this.repositoryItemTimeEdit1;
            this.clAtd.DisplayFormat.FormatString = "HH:mm";
            this.clAtd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clAtd.FieldName = "ActDepTime";
            this.clAtd.GroupFormat.FormatString = "HH:mm";
            this.clAtd.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clAtd.Name = "clAtd";
            this.clAtd.OptionsColumn.AllowEdit = false;
            this.clAtd.OptionsColumn.AllowFocus = false;
            this.clAtd.OptionsColumn.AllowMove = false;
            this.clAtd.OptionsColumn.ReadOnly = true;
            this.clAtd.Visible = true;
            this.clAtd.VisibleIndex = 15;
            this.clAtd.Width = 43;
            // 
            // repositoryItemTimeEdit1
            // 
            this.repositoryItemTimeEdit1.AutoHeight = false;
            this.repositoryItemTimeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemTimeEdit1.DisplayFormat.FormatString = "HH:mm";
            this.repositoryItemTimeEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemTimeEdit1.EditFormat.FormatString = "HH:mm";
            this.repositoryItemTimeEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemTimeEdit1.Mask.EditMask = "HH:mm";
            this.repositoryItemTimeEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTimeEdit1.Name = "repositoryItemTimeEdit1";
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
            this.clActNote.Width = 78;
            // 
            // clSame
            // 
            this.clSame.Caption = " ";
            this.clSame.FieldName = "ActSame";
            this.clSame.Name = "clSame";
            this.clSame.OptionsColumn.AllowEdit = false;
            this.clSame.OptionsColumn.AllowFocus = false;
            this.clSame.OptionsColumn.AllowMove = false;
            this.clSame.OptionsColumn.ReadOnly = true;
            this.clSame.Visible = true;
            this.clSame.VisibleIndex = 17;
            this.clSame.Width = 25;
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
            this.clConfirmed.VisibleIndex = 18;
            this.clConfirmed.Width = 44;
            // 
            // clId
            // 
            this.clId.Caption = "Id";
            this.clId.FieldName = "Id";
            this.clId.Name = "clId";
            // 
            // clState
            // 
            this.clState.Caption = "State Change";
            this.clState.FieldName = "StateChange";
            this.clState.Name = "clState";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(479, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 100);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Legend";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(251, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Warna Hitam => Sudah OnBoard dari Origin";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(27, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(252, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Warna Merah => Belum OnBoard dari Origin";
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(694, 430);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 28);
            this.btnExcel.TabIndex = 11;
            this.btnExcel.Text = "Save to Excel";
            // 
            // InboundBandaraViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 462);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GridOnboard);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.tbxAirline);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxOrigin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxFrom);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "InboundBandaraViewForm";
            this.Text = "Operation - Inbound Bandara View";
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxOrigin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAirline.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridOnboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnboardView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditRepo1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditRepo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Common.Component.dCalendar tbxFrom;
        private System.Windows.Forms.Label label2;
        private Common.Component.dCalendar tbxTo;
        private System.Windows.Forms.Label label3;
        private Common.Component.dLookup tbxOrigin;
        private System.Windows.Forms.Label label4;
        private Common.Component.dLookup tbxAirline;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraGrid.GridControl GridOnboard;
        private DevExpress.XtraGrid.Views.Grid.GridView OnboardView;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private DevExpress.XtraGrid.Columns.GridColumn clAwb;
        private DevExpress.XtraGrid.Columns.GridColumn clDate;
        private DevExpress.XtraGrid.Columns.GridColumn clAirline;
        private DevExpress.XtraGrid.Columns.GridColumn clDest;
        private DevExpress.XtraGrid.Columns.GridColumn clFlight;
        private DevExpress.XtraGrid.Columns.GridColumn clEstDate;
        private DevExpress.XtraGrid.Columns.GridColumn clEstTime;
        private DevExpress.XtraGrid.Columns.GridColumn clDimension;
        private DevExpress.XtraGrid.Columns.GridColumn clPiece;
        private DevExpress.XtraGrid.Columns.GridColumn clWeight;
        private DevExpress.XtraGrid.Columns.GridColumn clKiloSmu;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn clDiff;
        private DevExpress.XtraGrid.Columns.GridColumn clActFlight;
        private DevExpress.XtraGrid.Columns.GridColumn clActDate;
        private Common.ComponentRepositories.DateEditRepo dateEditRepo1;
        private DevExpress.XtraGrid.Columns.GridColumn clAtd;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn clActNote;
        private DevExpress.XtraGrid.Columns.GridColumn clSame;
        private DevExpress.XtraGrid.Columns.GridColumn clConfirmed;
        private DevExpress.XtraGrid.Columns.GridColumn clId;
        private DevExpress.XtraGrid.Columns.GridColumn clState;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton btnExcel;

    }
}