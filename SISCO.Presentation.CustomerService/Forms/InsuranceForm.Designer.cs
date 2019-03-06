namespace SISCO.Presentation.CustomerService.Forms
{
    partial class InsuranceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsuranceForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxInsured = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.cbxCash = new SISCO.Presentation.Common.Component.dCheckBox(this.components);
            this.tbxConveyance = new System.Windows.Forms.TextBox();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.tbxInterest = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.tbxTsi = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProcess = new DevExpress.XtraEditors.SimpleButton();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxResi = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxDestination = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.tbxDeparture = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.tbxEtd = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GridInsurance = new DevExpress.XtraGrid.GridControl();
            this.InsuranceView = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTsi.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridInsurance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InsuranceView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.MintCream;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.tbxInsured);
            this.panel2.Controls.Add(this.cbxCash);
            this.panel2.Controls.Add(this.tbxConveyance);
            this.panel2.Controls.Add(this.tbxDate);
            this.panel2.Controls.Add(this.tbxInterest);
            this.panel2.Controls.Add(this.tbxTsi);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnProcess);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.tbxResi);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(3, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(363, 408);
            this.panel2.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(25, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 17);
            this.label11.TabIndex = 25;
            this.label11.Text = "Insured";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxInsured
            // 
            this.tbxInsured.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxInsured.Capslock = true;
            this.tbxInsured.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxInsured.FieldLabel = null;
            this.tbxInsured.Location = new System.Drawing.Point(136, 99);
            this.tbxInsured.Name = "tbxInsured";
            this.tbxInsured.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxInsured.Size = new System.Drawing.Size(216, 24);
            this.tbxInsured.TabIndex = 4;
            this.tbxInsured.ValidationRules = null;
            // 
            // cbxCash
            // 
            this.cbxCash.AutoSize = true;
            this.cbxCash.FieldLabel = null;
            this.cbxCash.Location = new System.Drawing.Point(192, 9);
            this.cbxCash.Name = "cbxCash";
            this.cbxCash.Size = new System.Drawing.Size(58, 21);
            this.cbxCash.TabIndex = 2;
            this.cbxCash.Text = "Cash?";
            this.cbxCash.UseVisualStyleBackColor = true;
            this.cbxCash.ValidationRules = null;
            // 
            // tbxConveyance
            // 
            this.tbxConveyance.Location = new System.Drawing.Point(136, 274);
            this.tbxConveyance.Multiline = true;
            this.tbxConveyance.Name = "tbxConveyance";
            this.tbxConveyance.Size = new System.Drawing.Size(216, 71);
            this.tbxConveyance.TabIndex = 6;
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(74, 7);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
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
            this.tbxDate.Size = new System.Drawing.Size(105, 24);
            this.tbxDate.TabIndex = 1;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // tbxInterest
            // 
            this.tbxInterest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxInterest.Capslock = true;
            this.tbxInterest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxInterest.FieldLabel = null;
            this.tbxInterest.Location = new System.Drawing.Point(136, 249);
            this.tbxInterest.Name = "tbxInterest";
            this.tbxInterest.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxInterest.Size = new System.Drawing.Size(216, 24);
            this.tbxInterest.TabIndex = 5;
            this.tbxInterest.ValidationRules = null;
            // 
            // tbxTsi
            // 
            this.tbxTsi.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTsi.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTsi.FieldLabel = null;
            this.tbxTsi.Location = new System.Drawing.Point(136, 346);
            this.tbxTsi.Name = "tbxTsi";
            this.tbxTsi.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTsi.Properties.AllowMouseWheel = false;
            this.tbxTsi.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTsi.Properties.Appearance.Options.UseFont = true;
            this.tbxTsi.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTsi.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTsi.Properties.Mask.BeepOnError = true;
            this.tbxTsi.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTsi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxTsi.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTsi.ReadOnly = false;
            this.tbxTsi.Size = new System.Drawing.Size(158, 24);
            this.tbxTsi.TabIndex = 7;
            this.tbxTsi.TextAlign = null;
            this.tbxTsi.ValidationRules = null;
            this.tbxTsi.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(25, 349);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "TSI (Rp) :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Location = new System.Drawing.Point(277, 373);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 30);
            this.btnProcess.TabIndex = 8;
            this.btnProcess.Text = "Proses";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(25, 277);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 17);
            this.label9.TabIndex = 11;
            this.label9.Text = "Conveyance :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxResi
            // 
            this.tbxResi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxResi.Capslock = true;
            this.tbxResi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxResi.FieldLabel = null;
            this.tbxResi.Location = new System.Drawing.Point(136, 74);
            this.tbxResi.Name = "tbxResi";
            this.tbxResi.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxResi.Size = new System.Drawing.Size(216, 24);
            this.tbxResi.TabIndex = 3;
            this.tbxResi.ValidationRules = null;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(25, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Interest Insured :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbxDestination);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbxDeparture);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbxEtd);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(136, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 110);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info Resi";
            // 
            // tbxDestination
            // 
            this.tbxDestination.Capslock = true;
            this.tbxDestination.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDestination.FieldLabel = null;
            this.tbxDestination.Location = new System.Drawing.Point(92, 78);
            this.tbxDestination.Name = "tbxDestination";
            this.tbxDestination.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDestination.Size = new System.Drawing.Size(119, 24);
            this.tbxDestination.TabIndex = 11;
            this.tbxDestination.ValidationRules = null;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(11, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "Destination";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxDeparture
            // 
            this.tbxDeparture.Capslock = true;
            this.tbxDeparture.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDeparture.FieldLabel = null;
            this.tbxDeparture.Location = new System.Drawing.Point(92, 52);
            this.tbxDeparture.Name = "tbxDeparture";
            this.tbxDeparture.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDeparture.Size = new System.Drawing.Size(119, 24);
            this.tbxDeparture.TabIndex = 10;
            this.tbxDeparture.ValidationRules = null;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(11, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Departure";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxEtd
            // 
            this.tbxEtd.Capslock = true;
            this.tbxEtd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxEtd.FieldLabel = null;
            this.tbxEtd.Location = new System.Drawing.Point(92, 26);
            this.tbxEtd.Name = "tbxEtd";
            this.tbxEtd.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxEtd.Size = new System.Drawing.Size(119, 24);
            this.tbxEtd.TabIndex = 9;
            this.tbxEtd.ValidationRules = null;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(11, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "ETD";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tambah Resi";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(25, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "No. Resi :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GridInsurance
            // 
            this.GridInsurance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridInsurance.Location = new System.Drawing.Point(368, 40);
            this.GridInsurance.MainView = this.InsuranceView;
            this.GridInsurance.Name = "GridInsurance";
            this.GridInsurance.Size = new System.Drawing.Size(567, 370);
            this.GridInsurance.TabIndex = 3;
            this.GridInsurance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.InsuranceView});
            // 
            // InsuranceView
            // 
            this.InsuranceView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14});
            this.InsuranceView.GridControl = this.GridInsurance;
            this.InsuranceView.Name = "InsuranceView";
            this.InsuranceView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No.";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 57;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "The Insured";
            this.gridColumn2.FieldName = "CustomerName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 65;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "ETD";
            this.gridColumn3.FieldName = "DateProcess";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 55;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Departure";
            this.gridColumn4.FieldName = "CityName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 55;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Destination";
            this.gridColumn5.FieldName = "DestCity";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 55;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Interest Insured";
            this.gridColumn6.FieldName = "NatureOfGoods";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 55;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Conveyance";
            this.gridColumn7.FieldName = "Conveyance";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 55;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "B/L No.";
            this.gridColumn8.FieldName = "Code";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 55;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "TSI";
            this.gridColumn9.DisplayFormat.FormatString = "n1";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn9.FieldName = "GoodsValue";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 61;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "gridColumn10";
            this.gridColumn10.FieldName = "Posted";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "gridColumn11";
            this.gridColumn11.FieldName = "ShipmentId";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Rate";
            this.gridColumn12.DisplayFormat.FormatString = "n2";
            this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn12.FieldName = "Rate";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 9;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Premium";
            this.gridColumn13.DisplayFormat.FormatString = "n1";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn13.FieldName = "InsuranceFee";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 10;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "gridColumn14";
            this.gridColumn14.FieldName = "StateChange";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExcel.Appearance.Options.UseFont = true;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(812, 411);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(123, 38);
            this.btnExcel.TabIndex = 8;
            this.btnExcel.Text = "Save To Excel";
            // 
            // InsuranceForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(937, 450);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.GridInsurance);
            this.Controls.Add(this.panel2);
            this.Name = "InsuranceForm";
            this.Text = "Insurance";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.GridInsurance, 0);
            this.Controls.SetChildIndex(this.btnExcel, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTsi.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridInsurance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InsuranceView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private Common.Component.dTextBox tbxResi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private Common.Component.dTextBox tbxDestination;
        private System.Windows.Forms.Label label8;
        private Common.Component.dTextBox tbxDeparture;
        private System.Windows.Forms.Label label7;
        private Common.Component.dTextBox tbxEtd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private System.Windows.Forms.Label label1;
        private Common.Component.dTextBox tbxInterest;
        private Common.Component.dTextBoxNumber tbxTsi;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraGrid.GridControl GridInsurance;
        private DevExpress.XtraGrid.Views.Grid.GridView InsuranceView;
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
        private Common.Component.dCalendar tbxDate;
        private System.Windows.Forms.TextBox tbxConveyance;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private Common.Component.dCheckBox cbxCash;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private System.Windows.Forms.Label label11;
        private Common.Component.dTextBox tbxInsured;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
    }
}