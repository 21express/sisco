namespace SISCO.Presentation.Operation.Forms
{
    partial class OnboardReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnboardReportForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tbxAirline = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tbxDestination = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.btnFilter = new DevExpress.XtraEditors.SimpleButton();
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
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxAwb = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAirline.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDestination.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridOnboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnboardView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditRepo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditRepo1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(90, 12);
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
            this.tbxDate.Location = new System.Drawing.Point(130, 9);
            this.tbxDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.tbxDate.Size = new System.Drawing.Size(190, 24);
            this.tbxDate.TabIndex = 1;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(80, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Airline";
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
            this.tbxAirline.Location = new System.Drawing.Point(130, 62);
            this.tbxAirline.LookupPopup = null;
            this.tbxAirline.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxAirline.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxAirline.Properties.LookupPopup = null;
            this.tbxAirline.Properties.NullText = "<<Choose...>>";
            this.tbxAirline.Size = new System.Drawing.Size(327, 24);
            this.tbxAirline.TabIndex = 3;
            this.tbxAirline.ValidationRules = null;
            this.tbxAirline.Value = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(54, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Destination";
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
            this.tbxDestination.Location = new System.Drawing.Point(130, 88);
            this.tbxDestination.LookupPopup = null;
            this.tbxDestination.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxDestination.Name = "tbxDestination";
            this.tbxDestination.OriginalBackColor = System.Drawing.Color.Empty;
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxDestination.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.tbxDestination.Properties.LookupPopup = null;
            this.tbxDestination.Properties.NullText = "<<Choose...>>";
            this.tbxDestination.Size = new System.Drawing.Size(327, 24);
            this.tbxDestination.TabIndex = 4;
            this.tbxDestination.ValidationRules = null;
            this.tbxDestination.Value = null;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(475, 86);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(87, 27);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "Filter";
            // 
            // GridOnboard
            // 
            this.GridOnboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridOnboard.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GridOnboard.Location = new System.Drawing.Point(0, 121);
            this.GridOnboard.MainView = this.OnboardView;
            this.GridOnboard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GridOnboard.Name = "GridOnboard";
            this.GridOnboard.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.dateEditRepo1,
            this.repositoryItemTextEdit1,
            this.repositoryItemTimeEdit1});
            this.GridOnboard.Size = new System.Drawing.Size(903, 320);
            this.GridOnboard.TabIndex = 7;
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
            this.clDest.Caption = "Dest";
            this.clDest.FieldName = "DestAirport";
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
            // clKiloSmu
            // 
            this.clKiloSmu.Caption = "Kilo SMU";
            this.clKiloSmu.ColumnEdit = this.repositoryItemTextEdit1;
            this.clKiloSmu.FieldName = "GwSmu";
            this.clKiloSmu.Name = "clKiloSmu";
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
            this.clDiff.FieldName = "DiffSmu";
            this.clDiff.Name = "clDiff";
            this.clDiff.OptionsColumn.AllowEdit = false;
            this.clDiff.OptionsColumn.AllowFocus = false;
            this.clDiff.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
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
            this.clActFlight.OptionsColumn.AllowMove = false;
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
            this.clActDate.OptionsColumn.AllowMove = false;
            this.clActDate.Visible = true;
            this.clActDate.VisibleIndex = 13;
            this.clActDate.Width = 63;
            // 
            // dateEditRepo1
            // 
            this.dateEditRepo1.AutoHeight = false;
            this.dateEditRepo1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dateEditRepo1.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.dateEditRepo1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditRepo1.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.dateEditRepo1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditRepo1.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.dateEditRepo1.Mask.EditMask = "dd-MM-yyyy";
            this.dateEditRepo1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEditRepo1.Name = "dateEditRepo1";
            this.dateEditRepo1.NullText = "<<Choose...>>";
            this.dateEditRepo1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
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
            this.clAtd.OptionsColumn.AllowMove = false;
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
            this.clActNote.OptionsColumn.AllowMove = false;
            this.clActNote.Visible = true;
            this.clActNote.VisibleIndex = 16;
            this.clActNote.Width = 78;
            // 
            // clSame
            // 
            this.clSame.Caption = " ";
            this.clSame.FieldName = "ActSame";
            this.clSame.Name = "clSame";
            this.clSame.OptionsColumn.AllowMove = false;
            this.clSame.Visible = true;
            this.clSame.VisibleIndex = 17;
            this.clSame.Width = 25;
            // 
            // clConfirmed
            // 
            this.clConfirmed.Caption = "Confrm";
            this.clConfirmed.FieldName = "ActConfirmed";
            this.clConfirmed.Name = "clConfirmed";
            this.clConfirmed.OptionsColumn.AllowMove = false;
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
            this.clState.FieldName = "StateChange2";
            this.clState.Name = "clState";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 441);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(901, 45);
            this.pnlBottom.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(807, 5);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 34);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(66, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "AWB No.";
            // 
            // tbxAwb
            // 
            this.tbxAwb.Capslock = true;
            this.tbxAwb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxAwb.FieldLabel = null;
            this.tbxAwb.Location = new System.Drawing.Point(130, 36);
            this.tbxAwb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxAwb.Name = "tbxAwb";
            this.tbxAwb.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxAwb.Size = new System.Drawing.Size(326, 24);
            this.tbxAwb.TabIndex = 2;
            this.tbxAwb.ValidationRules = null;
            // 
            // OnboardReportForm
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 486);
            this.Controls.Add(this.tbxAwb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.GridOnboard);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.tbxDestination);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxAirline);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxDate);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "OnboardReportForm";
            this.Text = "Operation - Onboard Report";
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAirline.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDestination.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridOnboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnboardView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditRepo1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditRepo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Common.Component.dCalendar tbxDate;
        private System.Windows.Forms.Label label2;
        private Common.Component.dLookup tbxAirline;
        private System.Windows.Forms.Label label3;
        private Common.Component.dLookup tbxDestination;
        private DevExpress.XtraEditors.SimpleButton btnFilter;
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
        private DevExpress.XtraGrid.Columns.GridColumn clSame;
        private DevExpress.XtraGrid.Columns.GridColumn clConfirmed;
        private DevExpress.XtraGrid.Columns.GridColumn clId;
        private System.Windows.Forms.Panel pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn clState;
        private Common.ComponentRepositories.DateEditRepo dateEditRepo1;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private DevExpress.XtraGrid.Columns.GridColumn clKiloSmu;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn clDimension;
        private System.Windows.Forms.Label label4;
        private Common.Component.dTextBox tbxAwb;
        private DevExpress.XtraGrid.Columns.GridColumn clDiff;
    }
}