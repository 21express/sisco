using SISCO.Presentation.Common.Component;

namespace SISCO.Presentation.MasterData.Forms
{
    partial class ManageCustomerTariffForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageCustomerTariffForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookupRepoCity = new SISCO.Presentation.Common.ComponentRepositories.LookupRepo();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookupRepoServiceType = new SISCO.Presentation.Common.ComponentRepositories.LookupRepo();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerCode = new SISCO.Presentation.Common.Component.dTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddToAll = new System.Windows.Forms.Button();
            this.txtAddToAll = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtCustomerName = new SISCO.Presentation.Common.Component.dTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lkpFilter = new SISCO.Presentation.Common.Component.dLookup();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoServiceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddToAll.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grid.Location = new System.Drawing.Point(3, 125);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.lookupRepoCity,
            this.lookupRepoServiceType});
            this.grid.Size = new System.Drawing.Size(699, 333);
            this.grid.TabIndex = 108;
            this.grid.UseEmbeddedNavigator = true;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn14,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn7,
            this.clState,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Origin";
            this.gridColumn1.ColumnEdit = this.lookupRepoCity;
            this.gridColumn1.FieldName = "CityOrigId";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 57;
            // 
            // lookupRepoCity
            // 
            this.lookupRepoCity.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lookupRepoCity.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lookupRepoCity.AutoCompleteDataManager = null;
            this.lookupRepoCity.AutoCompleteDisplayFormater = null;
            this.lookupRepoCity.AutocompleteMinimumTextLength = 2;
            this.lookupRepoCity.AutoCompleteText = null;
            this.lookupRepoCity.AutoCompleteWhereExpression = null;
            this.lookupRepoCity.AutoCompleteWheretermFormater = null;
            this.lookupRepoCity.AutoHeight = false;
            this.lookupRepoCity.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lookupRepoCity.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lookupRepoCity.LookupPopup = null;
            this.lookupRepoCity.Name = "lookupRepoCity";
            this.lookupRepoCity.NullText = "<<Choose...>>";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Destination";
            this.gridColumn2.ColumnEdit = this.lookupRepoCity;
            this.gridColumn2.FieldName = "CityDestId";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 62;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Service";
            this.gridColumn3.ColumnEdit = this.lookupRepoServiceType;
            this.gridColumn3.FieldName = "ServiceTypeId";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 44;
            // 
            // lookupRepoServiceType
            // 
            this.lookupRepoServiceType.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lookupRepoServiceType.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lookupRepoServiceType.AutoCompleteDataManager = null;
            this.lookupRepoServiceType.AutoCompleteDisplayFormater = null;
            this.lookupRepoServiceType.AutocompleteMinimumTextLength = 2;
            this.lookupRepoServiceType.AutoCompleteText = null;
            this.lookupRepoServiceType.AutoCompleteWhereExpression = null;
            this.lookupRepoServiceType.AutoCompleteWheretermFormater = null;
            this.lookupRepoServiceType.AutoHeight = false;
            this.lookupRepoServiceType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lookupRepoServiceType.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lookupRepoServiceType.LookupPopup = null;
            this.lookupRepoServiceType.Name = "lookupRepoServiceType";
            this.lookupRepoServiceType.NullText = "<<Choose...>>";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tariff PerKg";
            this.gridColumn4.FieldName = "Tariff";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 64;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Tariff";
            this.gridColumn14.FieldName = "FixedTariff";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 4;
            this.gridColumn14.Width = 46;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Handling Fee";
            this.gridColumn5.FieldName = "HandlingFee";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 67;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "RA";
            this.gridColumn6.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn6.FieldName = "Ra";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 21;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Min Weight";
            this.gridColumn8.FieldName = "MinWeight";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 63;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Lead Time";
            this.gridColumn7.FieldName = "Ltime";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 8;
            this.gridColumn7.Width = 56;
            // 
            // clState
            // 
            this.clState.Caption = "gridColumn8";
            this.clState.FieldName = "Id";
            this.clState.Name = "clState";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "gridColumn9";
            this.gridColumn9.FieldName = "StateChange";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Min. Charg.";
            this.gridColumn10.FieldName = "FromWeight";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 70;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Max. Charg.";
            this.gridColumn11.FieldName = "ToWeight";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            this.gridColumn11.Width = 70;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "gridColumn12";
            this.gridColumn12.FieldName = "Id";
            this.gridColumn12.Name = "gridColumn12";
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Next Tariff";
            this.gridColumn13.FieldName = "NextTariff";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 11;
            this.gridColumn13.Width = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 116;
            this.label1.Text = "Customer";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Capslock = true;
            this.txtCustomerCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustomerCode.FieldLabel = null;
            this.txtCustomerCode.Location = new System.Drawing.Point(71, 54);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtCustomerCode.Size = new System.Drawing.Size(55, 24);
            this.txtCustomerCode.TabIndex = 101;
            this.txtCustomerCode.ValidationRules = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnAddToAll);
            this.groupBox1.Controls.Add(this.txtAddToAll);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(504, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 49);
            this.groupBox1.TabIndex = 105;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add To All";
            // 
            // btnAddToAll
            // 
            this.btnAddToAll.Location = new System.Drawing.Point(132, 17);
            this.btnAddToAll.Name = "btnAddToAll";
            this.btnAddToAll.Size = new System.Drawing.Size(58, 26);
            this.btnAddToAll.TabIndex = 107;
            this.btnAddToAll.Text = "Add";
            this.btnAddToAll.UseVisualStyleBackColor = true;
            // 
            // txtAddToAll
            // 
            this.txtAddToAll.EditMask = "###,###,###,###,###,##0.00";
            this.txtAddToAll.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAddToAll.FieldLabel = null;
            this.txtAddToAll.Location = new System.Drawing.Point(6, 19);
            this.txtAddToAll.Name = "txtAddToAll";
            this.txtAddToAll.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtAddToAll.Properties.AllowMouseWheel = false;
            this.txtAddToAll.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.txtAddToAll.Properties.Appearance.Options.UseFont = true;
            this.txtAddToAll.Properties.Appearance.Options.UseTextOptions = true;
            this.txtAddToAll.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtAddToAll.Properties.Mask.BeepOnError = true;
            this.txtAddToAll.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtAddToAll.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAddToAll.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtAddToAll.ReadOnly = false;
            this.txtAddToAll.Size = new System.Drawing.Size(120, 24);
            this.txtAddToAll.TabIndex = 106;
            this.txtAddToAll.TextAlign = null;
            this.txtAddToAll.ValidationRules = null;
            this.txtAddToAll.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btnExport
            // 
            this.btnExport.ForeColor = System.Drawing.Color.Black;
            this.btnExport.Location = new System.Drawing.Point(390, 52);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(65, 28);
            this.btnExport.TabIndex = 104;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.ForeColor = System.Drawing.Color.Black;
            this.btnImport.Location = new System.Drawing.Point(322, 52);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(65, 28);
            this.btnImport.TabIndex = 103;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Capslock = true;
            this.txtCustomerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustomerName.FieldLabel = null;
            this.txtCustomerName.Location = new System.Drawing.Point(130, 54);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtCustomerName.Size = new System.Drawing.Size(190, 24);
            this.txtCustomerName.TabIndex = 102;
            this.txtCustomerName.ValidationRules = null;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(709, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 420);
            this.groupBox2.TabIndex = 118;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cara Penggunaan";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(23, 377);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(232, 34);
            this.label12.TabIndex = 10;
            this.label12.Text = "a. Digunakan untuk menentukan harga kilo selanjutnya.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 360);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 17);
            this.label11.TabIndex = 9;
            this.label11.Text = "4. Next Tariff : ";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(23, 302);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(232, 52);
            this.label10.TabIndex = 8;
            this.label10.Text = "c. Contoh. Jika tariff berlaku untuk berat di atas 10 kg, maka isi Min. Charg. de" +
    "ngan 10 dan kosongkan Max. Charg.";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(23, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(232, 52);
            this.label9.TabIndex = 7;
            this.label9.Text = "b. Contoh. Jika tariff berlaku untuk berat di bawah 5 kg, maka isi Min. Charg. de" +
    "ngan 0 dan Max. Charg. dengan 5";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(23, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(232, 51);
            this.label8.TabIndex = 6;
            this.label8.Text = "a. Tentukan batas bawah(Min. Charge.) dan batas atas (Max. Charg.) jika tariff be" +
    "rdasarkan jarak berat tertentu";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "3. Min. Charg. && Max. Charg. :";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(23, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(232, 38);
            this.label6.TabIndex = 4;
            this.label6.Text = "a. Isi nilai 0 jika tidak ada batasan minimum charge";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "2. Min Weight :";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(23, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 38);
            this.label4.TabIndex = 2;
            this.label4.Text = "b. Pilih service jika tariff hanya berlaku untuk 1 service saja";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(23, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 38);
            this.label3.TabIndex = 1;
            this.label3.Text = "a. Kosongkan Service jika tariff berlaku untuk semua service";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "1. Service :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(26, 101);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 17);
            this.label13.TabIndex = 119;
            this.label13.Text = "Filter Destination";
            // 
            // lkpFilter
            // 
            this.lkpFilter.AutoCompleteDataManager = null;
            this.lkpFilter.AutoCompleteDisplayFormater = null;
            this.lkpFilter.AutoCompleteInitialized = false;
            this.lkpFilter.AutocompleteMinimumTextLength = 0;
            this.lkpFilter.AutoCompleteText = null;
            this.lkpFilter.AutoCompleteWhereExpression = null;
            this.lkpFilter.AutoCompleteWheretermFormater = null;
            this.lkpFilter.ClearOnLeave = true;
            this.lkpFilter.DisplayString = null;
            this.lkpFilter.FieldLabel = null;
            this.lkpFilter.Location = new System.Drawing.Point(130, 98);
            this.lkpFilter.LookupPopup = null;
            this.lkpFilter.Name = "lkpFilter";
            this.lkpFilter.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpFilter.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpFilter.Properties.Appearance.Options.UseFont = true;
            this.lkpFilter.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpFilter.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpFilter.Properties.AutoCompleteDataManager = null;
            this.lkpFilter.Properties.AutoCompleteDisplayFormater = null;
            this.lkpFilter.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpFilter.Properties.AutoCompleteText = null;
            this.lkpFilter.Properties.AutoCompleteWhereExpression = null;
            this.lkpFilter.Properties.AutoCompleteWheretermFormater = null;
            this.lkpFilter.Properties.AutoHeight = false;
            this.lkpFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dLookup1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.lkpFilter.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpFilter.Properties.LookupPopup = null;
            this.lkpFilter.Properties.NullText = "<<Choose...>>";
            this.lkpFilter.Size = new System.Drawing.Size(225, 24);
            this.lkpFilter.TabIndex = 120;
            this.lkpFilter.ValidationRules = null;
            this.lkpFilter.Value = null;
            // 
            // btnClear
            // 
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(417, 97);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(57, 25);
            this.btnClear.TabIndex = 122;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnFilter
            // 
            this.btnFilter.ForeColor = System.Drawing.Color.Black;
            this.btnFilter.Location = new System.Drawing.Point(359, 97);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(57, 25);
            this.btnFilter.TabIndex = 121;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // ManageCustomerTariffForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(974, 460);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.lkpFilter);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCustomerCode);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtCustomerName);
            this.Name = "ManageCustomerTariffForm";
            this.Text = "Master Customer Tariff";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.txtCustomerName, 0);
            this.Controls.SetChildIndex(this.btnImport, 0);
            this.Controls.SetChildIndex(this.btnExport, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txtCustomerCode, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.lkpFilter, 0);
            this.Controls.SetChildIndex(this.btnFilter, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoServiceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAddToAll.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilter.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.Label label1;
        private dTextBox txtCustomerCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddToAll;
        private Common.Component.dTextBoxNumber txtAddToAll;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private dTextBox txtCustomerName;
        private Common.ComponentRepositories.LookupRepo lookupRepoCity;
        private Common.ComponentRepositories.LookupRepo lookupRepoServiceType;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn clState;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private System.Windows.Forms.Label label13;
        private dLookup lkpFilter;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFilter;
    }
}