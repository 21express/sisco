namespace SISCO.Presentation.Operation.Popup
{
    partial class FindAirwaybillPopup
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindAirwaybillPopup));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxFrom = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tbxTo = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tbxAwb = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.lkpAirline = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lkpOrigin = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.lkpDestination = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.btnFind = new DevExpress.XtraEditors.SimpleButton();
            this.GridAirwaybill = new DevExpress.XtraGrid.GridControl();
            this.AirwaybillView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpAirline.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpOrigin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestination.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridAirwaybill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AirwaybillView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.lkpDestination);
            this.panel1.Controls.Add(this.lkpOrigin);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lkpAirline);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbxAwb);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbxTo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbxFrom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 108);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tgl AWB";
            // 
            // tbxFrom
            // 
            this.tbxFrom.EditValue = null;
            this.tbxFrom.FieldLabel = null;
            this.tbxFrom.FormatDateTime = "dd-MM-yyyy";
            this.tbxFrom.Location = new System.Drawing.Point(80, 15);
            this.tbxFrom.Name = "tbxFrom";
            this.tbxFrom.Nullable = false;
            this.tbxFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFrom.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxFrom.Properties.Appearance.Options.UseFont = true;
            this.tbxFrom.Properties.AutoHeight = false;
            this.tbxFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dCalendar1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
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
            this.tbxFrom.Size = new System.Drawing.Size(120, 24);
            this.tbxFrom.TabIndex = 1;
            this.tbxFrom.ValidationRules = null;
            this.tbxFrom.Value = new System.DateTime(((long)(0)));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "s.d";
            // 
            // tbxTo
            // 
            this.tbxTo.EditValue = null;
            this.tbxTo.FieldLabel = null;
            this.tbxTo.FormatDateTime = "dd-MM-yyyy";
            this.tbxTo.Location = new System.Drawing.Point(236, 15);
            this.tbxTo.Name = "tbxTo";
            this.tbxTo.Nullable = false;
            this.tbxTo.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTo.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTo.Properties.Appearance.Options.UseFont = true;
            this.tbxTo.Properties.AutoHeight = false;
            this.tbxTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dCalendar2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
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
            this.tbxTo.Size = new System.Drawing.Size(120, 24);
            this.tbxTo.TabIndex = 2;
            this.tbxTo.ValidationRules = null;
            this.tbxTo.Value = new System.DateTime(((long)(0)));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "AWB No.";
            // 
            // tbxAwb
            // 
            this.tbxAwb.Capslock = true;
            this.tbxAwb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxAwb.FieldLabel = null;
            this.tbxAwb.Location = new System.Drawing.Point(80, 42);
            this.tbxAwb.Name = "tbxAwb";
            this.tbxAwb.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxAwb.Size = new System.Drawing.Size(157, 24);
            this.tbxAwb.TabIndex = 3;
            this.tbxAwb.ValidationRules = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Airline";
            // 
            // lkpAirline
            // 
            this.lkpAirline.AutoCompleteDataManager = null;
            this.lkpAirline.AutoCompleteDisplayFormater = null;
            this.lkpAirline.AutoCompleteInitialized = false;
            this.lkpAirline.AutocompleteMinimumTextLength = 0;
            this.lkpAirline.AutoCompleteText = null;
            this.lkpAirline.AutoCompleteWhereExpression = null;
            this.lkpAirline.AutoCompleteWheretermFormater = null;
            this.lkpAirline.ClearOnLeave = true;
            this.lkpAirline.DisplayString = null;
            this.lkpAirline.FieldLabel = null;
            this.lkpAirline.Location = new System.Drawing.Point(80, 69);
            this.lkpAirline.LookupPopup = null;
            this.lkpAirline.Name = "lkpAirline";
            this.lkpAirline.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpAirline.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpAirline.Properties.Appearance.Options.UseFont = true;
            this.lkpAirline.Properties.AutoCompleteDataManager = null;
            this.lkpAirline.Properties.AutoCompleteDisplayFormater = null;
            this.lkpAirline.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpAirline.Properties.AutoCompleteText = null;
            this.lkpAirline.Properties.AutoCompleteWhereExpression = null;
            this.lkpAirline.Properties.AutoCompleteWheretermFormater = null;
            this.lkpAirline.Properties.AutoHeight = false;
            this.lkpAirline.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dLookup1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.lkpAirline.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpAirline.Properties.LookupPopup = null;
            this.lkpAirline.Properties.NullText = "<<Choose...>>";
            this.lkpAirline.Size = new System.Drawing.Size(276, 24);
            this.lkpAirline.TabIndex = 4;
            this.lkpAirline.ValidationRules = null;
            this.lkpAirline.Value = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(389, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Destination";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(416, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Origin";
            // 
            // lkpOrigin
            // 
            this.lkpOrigin.AutoCompleteDataManager = null;
            this.lkpOrigin.AutoCompleteDisplayFormater = null;
            this.lkpOrigin.AutoCompleteInitialized = false;
            this.lkpOrigin.AutocompleteMinimumTextLength = 0;
            this.lkpOrigin.AutoCompleteText = null;
            this.lkpOrigin.AutoCompleteWhereExpression = null;
            this.lkpOrigin.AutoCompleteWheretermFormater = null;
            this.lkpOrigin.ClearOnLeave = true;
            this.lkpOrigin.DisplayString = null;
            this.lkpOrigin.FieldLabel = null;
            this.lkpOrigin.Location = new System.Drawing.Point(463, 15);
            this.lkpOrigin.LookupPopup = null;
            this.lkpOrigin.Name = "lkpOrigin";
            this.lkpOrigin.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpOrigin.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpOrigin.Properties.Appearance.Options.UseFont = true;
            this.lkpOrigin.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpOrigin.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpOrigin.Properties.AutoCompleteDataManager = null;
            this.lkpOrigin.Properties.AutoCompleteDisplayFormater = null;
            this.lkpOrigin.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpOrigin.Properties.AutoCompleteText = null;
            this.lkpOrigin.Properties.AutoCompleteWhereExpression = null;
            this.lkpOrigin.Properties.AutoCompleteWheretermFormater = null;
            this.lkpOrigin.Properties.AutoHeight = false;
            this.lkpOrigin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dLookup2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpOrigin.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpOrigin.Properties.LookupPopup = null;
            this.lkpOrigin.Properties.NullText = "<<Choose...>>";
            this.lkpOrigin.Size = new System.Drawing.Size(194, 24);
            this.lkpOrigin.TabIndex = 5;
            this.lkpOrigin.ValidationRules = null;
            this.lkpOrigin.Value = null;
            // 
            // lkpDestination
            // 
            this.lkpDestination.AutoCompleteDataManager = null;
            this.lkpDestination.AutoCompleteDisplayFormater = null;
            this.lkpDestination.AutoCompleteInitialized = false;
            this.lkpDestination.AutocompleteMinimumTextLength = 0;
            this.lkpDestination.AutoCompleteText = null;
            this.lkpDestination.AutoCompleteWhereExpression = null;
            this.lkpDestination.AutoCompleteWheretermFormater = null;
            this.lkpDestination.ClearOnLeave = true;
            this.lkpDestination.DisplayString = null;
            this.lkpDestination.FieldLabel = null;
            this.lkpDestination.Location = new System.Drawing.Point(463, 42);
            this.lkpDestination.LookupPopup = null;
            this.lkpDestination.Name = "lkpDestination";
            this.lkpDestination.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpDestination.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpDestination.Properties.Appearance.Options.UseFont = true;
            this.lkpDestination.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpDestination.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpDestination.Properties.AutoCompleteDataManager = null;
            this.lkpDestination.Properties.AutoCompleteDisplayFormater = null;
            this.lkpDestination.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpDestination.Properties.AutoCompleteText = null;
            this.lkpDestination.Properties.AutoCompleteWhereExpression = null;
            this.lkpDestination.Properties.AutoCompleteWheretermFormater = null;
            this.lkpDestination.Properties.AutoHeight = false;
            this.lkpDestination.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dLookup3.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpDestination.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpDestination.Properties.LookupPopup = null;
            this.lkpDestination.Properties.NullText = "<<Choose...>>";
            this.lkpDestination.Size = new System.Drawing.Size(194, 24);
            this.lkpDestination.TabIndex = 6;
            this.lkpDestination.ValidationRules = null;
            this.lkpDestination.Value = null;
            // 
            // btnFind
            // 
            this.btnFind.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.btnFind.Appearance.Options.UseFont = true;
            this.btnFind.Location = new System.Drawing.Point(463, 69);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 30);
            this.btnFind.TabIndex = 7;
            this.btnFind.Text = "Cari";
            // 
            // GridAirwaybill
            // 
            this.GridAirwaybill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridAirwaybill.Location = new System.Drawing.Point(2, 112);
            this.GridAirwaybill.MainView = this.AirwaybillView;
            this.GridAirwaybill.Name = "GridAirwaybill";
            this.GridAirwaybill.Size = new System.Drawing.Size(668, 319);
            this.GridAirwaybill.TabIndex = 2;
            this.GridAirwaybill.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.AirwaybillView});
            // 
            // AirwaybillView
            // 
            this.AirwaybillView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn8,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.AirwaybillView.GridControl = this.GridAirwaybill;
            this.AirwaybillView.Name = "AirwaybillView";
            this.AirwaybillView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "No";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 36;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "AWB No.";
            this.gridColumn3.FieldName = "Code";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 106;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Airline";
            this.gridColumn4.FieldName = "Airline";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 111;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Keberangkatan";
            this.gridColumn5.FieldName = "Airport";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 148;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Tujuan";
            this.gridColumn6.FieldName = "DestAirport";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 167;
            // 
            // btnOk
            // 
            this.btnOk.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnOk.Appearance.Options.UseFont = true;
            this.btnOk.Location = new System.Drawing.Point(515, 433);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 30);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Pilih";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(595, 433);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Batal";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = " ";
            this.gridColumn7.FieldName = "Select";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 37;
            // 
            // btnSelect
            // 
            this.btnSelect.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.btnSelect.Appearance.Options.UseFont = true;
            this.btnSelect.Location = new System.Drawing.Point(2, 433);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 30);
            this.btnSelect.TabIndex = 10;
            this.btnSelect.Text = "Pilih Semua";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Tgl AWB";
            this.gridColumn8.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn8.FieldName = "DateProcess";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 91;
            // 
            // FindAirwaybillPopup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(672, 465);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.GridAirwaybill);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindAirwaybillPopup";
            this.Text = "Cari Airwaybill";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpAirline.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpOrigin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestination.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridAirwaybill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AirwaybillView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Common.Component.dLookup lkpAirline;
        private System.Windows.Forms.Label label4;
        private Common.Component.dTextBox tbxAwb;
        private System.Windows.Forms.Label label3;
        private Common.Component.dCalendar tbxTo;
        private System.Windows.Forms.Label label2;
        private Common.Component.dCalendar tbxFrom;
        private System.Windows.Forms.Label label1;
        private Common.Component.dLookup lkpDestination;
        private Common.Component.dLookup lkpOrigin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SimpleButton btnFind;
        private DevExpress.XtraGrid.GridControl GridAirwaybill;
        private DevExpress.XtraGrid.Views.Grid.GridView AirwaybillView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
    }
}