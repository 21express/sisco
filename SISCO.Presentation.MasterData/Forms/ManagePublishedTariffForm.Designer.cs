using System.Windows.Forms;
using SISCO.Presentation.Common.Component;

namespace SISCO.Presentation.MasterData.Forms
{
    partial class ManagePublishedTariffForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagePublishedTariffForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookupRepoCity = new SISCO.Presentation.Common.ComponentRepositories.LookupRepo();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookupRepoServiceType = new SISCO.Presentation.Common.ComponentRepositories.LookupRepo();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.lkpFilter = new SISCO.Presentation.Common.Component.dLookup();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOriginCity = new SISCO.Presentation.Common.Component.dTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddToAll = new System.Windows.Forms.Button();
            this.txtAddToAll = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoServiceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilter.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddToAll.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grid.Location = new System.Drawing.Point(2, 145);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookupRepoCity,
            this.lookupRepoServiceType,
            this.repositoryItemCheckEdit1});
            this.grid.Size = new System.Drawing.Size(846, 363);
            this.grid.TabIndex = 118;
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
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn9,
            this.gridColumn7,
            this.clState,
            this.gridColumn8});
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
            this.gridColumn1.Width = 120;
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lookupRepoCity.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.lookupRepoCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
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
            this.gridColumn2.Width = 126;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Service";
            this.gridColumn3.ColumnEdit = this.lookupRepoServiceType;
            this.gridColumn3.FieldName = "ServiceTypeId";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 89;
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lookupRepoServiceType.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "", null, null, true)});
            this.lookupRepoServiceType.LookupPopup = null;
            this.lookupRepoServiceType.Name = "lookupRepoServiceType";
            this.lookupRepoServiceType.NullText = "<<Choose...>>";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tariff";
            this.gridColumn4.FieldName = "Tariff";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 91;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Handling Fee";
            this.gridColumn5.FieldName = "HandlingFee";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 95;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "RA";
            this.gridColumn6.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn6.FieldName = "Ra";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 38;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Min Weight";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "MinWeight";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Lead Time";
            this.gridColumn7.FieldName = "LeadTime";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 62;
            // 
            // clState
            // 
            this.clState.Caption = "gridColumn8";
            this.clState.FieldName = "StateChange";
            this.clState.Name = "clState";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "gridColumn8";
            this.gridColumn8.FieldName = "Id";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 120;
            this.label2.Text = "Filter Destination";
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
            this.lkpFilter.Location = new System.Drawing.Point(119, 117);
            this.lkpFilter.LookupPopup = null;
            this.lkpFilter.Name = "lkpFilter";
            this.lkpFilter.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpFilter.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpFilter.Properties.Appearance.Options.UseFont = true;
            this.lkpFilter.Properties.AutoCompleteDataManager = null;
            this.lkpFilter.Properties.AutoCompleteDisplayFormater = null;
            this.lkpFilter.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpFilter.Properties.AutoCompleteText = null;
            this.lkpFilter.Properties.AutoCompleteWhereExpression = null;
            this.lkpFilter.Properties.AutoCompleteWheretermFormater = null;
            this.lkpFilter.Properties.AutoHeight = false;
            this.lkpFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dLookup1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, "", null, null, true)});
            this.lkpFilter.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpFilter.Properties.LookupPopup = null;
            this.lkpFilter.Properties.NullText = "<<Choose...>>";
            this.lkpFilter.Size = new System.Drawing.Size(225, 24);
            this.lkpFilter.TabIndex = 121;
            this.lkpFilter.ValidationRules = null;
            this.lkpFilter.Value = null;
            // 
            // btnClear
            // 
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(410, 116);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(62, 25);
            this.btnClear.TabIndex = 123;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnFilter
            // 
            this.btnFilter.ForeColor = System.Drawing.Color.Black;
            this.btnFilter.Location = new System.Drawing.Point(347, 116);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(62, 25);
            this.btnFilter.TabIndex = 122;
            this.btnFilter.Text = "Find";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Honeydew;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtOriginCity);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Location = new System.Drawing.Point(2, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 61);
            this.panel1.TabIndex = 124;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(4, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 123;
            this.label1.Text = "Origin";
            // 
            // txtOriginCity
            // 
            this.txtOriginCity.Capslock = true;
            this.txtOriginCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOriginCity.FieldLabel = null;
            this.txtOriginCity.Location = new System.Drawing.Point(51, 18);
            this.txtOriginCity.Name = "txtOriginCity";
            this.txtOriginCity.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtOriginCity.Size = new System.Drawing.Size(234, 24);
            this.txtOriginCity.TabIndex = 120;
            this.txtOriginCity.ValidationRules = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnAddToAll);
            this.groupBox1.Controls.Add(this.txtAddToAll);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(636, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 55);
            this.groupBox1.TabIndex = 122;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add To All";
            // 
            // btnAddToAll
            // 
            this.btnAddToAll.Location = new System.Drawing.Point(133, 18);
            this.btnAddToAll.Name = "btnAddToAll";
            this.btnAddToAll.Size = new System.Drawing.Size(58, 23);
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
            this.txtAddToAll.Location = new System.Drawing.Point(7, 20);
            this.txtAddToAll.Name = "txtAddToAll";
            this.txtAddToAll.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtAddToAll.Properties.AllowMouseWheel = false;
            this.txtAddToAll.Properties.Appearance.Options.UseTextOptions = true;
            this.txtAddToAll.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtAddToAll.Properties.Mask.BeepOnError = true;
            this.txtAddToAll.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtAddToAll.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAddToAll.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtAddToAll.ReadOnly = false;
            this.txtAddToAll.Size = new System.Drawing.Size(120, 20);
            this.txtAddToAll.TabIndex = 105;
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
            this.btnExport.Location = new System.Drawing.Point(369, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 30);
            this.btnExport.TabIndex = 124;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.ForeColor = System.Drawing.Color.Black;
            this.btnImport.Location = new System.Drawing.Point(288, 15);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 30);
            this.btnImport.TabIndex = 121;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // ManagePublishedTariffForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(850, 511);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.lkpFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grid);
            this.Name = "ManagePublishedTariffForm";
            this.Text = "Master Published Tariff";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.grid, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lkpFilter, 0);
            this.Controls.SetChildIndex(this.btnFilter, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoServiceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilter.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAddToAll.Properties)).EndInit();
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
        private Common.ComponentRepositories.LookupRepo lookupRepoCity;
        private Common.ComponentRepositories.LookupRepo lookupRepoServiceType;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn clState;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private Label label2;
        private dLookup lkpFilter;
        private Button btnClear;
        private Button btnFilter;
        private Panel panel1;
        private Label label1;
        private dTextBox txtOriginCity;
        private GroupBox groupBox1;
        private Button btnAddToAll;
        private dTextBoxNumber txtAddToAll;
        private Button btnExport;
        private Button btnImport;
    }
}