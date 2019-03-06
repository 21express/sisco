namespace SISCO.Presentation.CustomerService.Forms
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtOriginCity = new DevExpress.XtraEditors.TextEdit();
            this.btnExport = new System.Windows.Forms.Button();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoServiceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOriginCity.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grid.Location = new System.Drawing.Point(15, 106);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookupRepoCity,
            this.lookupRepoServiceType,
            this.repositoryItemCheckEdit1});
            this.grid.Size = new System.Drawing.Size(696, 390);
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
            this.gridColumn7});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsFind.AlwaysVisible = true;
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
            this.gridColumn1.Width = 143;
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
            this.gridColumn2.Width = 150;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Service";
            this.gridColumn3.ColumnEdit = this.lookupRepoServiceType;
            this.gridColumn3.FieldName = "ServiceTypeId";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 107;
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
            this.gridColumn4.Caption = "Tariff";
            this.gridColumn4.FieldName = "Tariff";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 109;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Handling Fee";
            this.gridColumn5.FieldName = "HandlingFee";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 114;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "RA";
            this.gridColumn6.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn6.FieldName = "Ra";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 55;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 116;
            this.label1.Text = "Origin";
            // 
            // txtOriginCity
            // 
            this.txtOriginCity.Location = new System.Drawing.Point(56, 65);
            this.txtOriginCity.Name = "txtOriginCity";
            this.txtOriginCity.Size = new System.Drawing.Size(234, 20);
            this.txtOriginCity.TabIndex = 101;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(408, 59);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 30);
            this.btnExport.TabIndex = 119;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Lead Time";
            this.gridColumn7.FieldName = "LeadTime";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // ManagePublishedTariffForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(725, 511);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOriginCity);
            this.Controls.Add(this.btnExport);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ManagePublishedTariffForm";
            this.Text = "Master Published Tariff";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.Controls.SetChildIndex(this.btnExport, 0);
            this.Controls.SetChildIndex(this.txtOriginCity, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoServiceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOriginCity.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txtOriginCity;
        private System.Windows.Forms.Button btnExport;
        private Common.ComponentRepositories.LookupRepo lookupRepoCity;
        private Common.ComponentRepositories.LookupRepo lookupRepoServiceType;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;



    }
}