using SISCO.Presentation.Common.Component;

namespace SISCO.Presentation.MasterData.Forms
{
    partial class ManagePublishedInternationalTariffForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagePublishedInternationalTariffForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookupRepoPackageType = new SISCO.Presentation.Common.ComponentRepositories.LookupRepo();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookupRepoCurrency = new SISCO.Presentation.Common.ComponentRepositories.LookupRepo();
            this.label1 = new System.Windows.Forms.Label();
            this.txtZoneName = new SISCO.Presentation.Common.Component.dTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoPackageType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoCurrency)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grid.Location = new System.Drawing.Point(15, 85);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookupRepoPackageType,
            this.lookupRepoCurrency});
            this.grid.Size = new System.Drawing.Size(747, 390);
            this.grid.TabIndex = 116;
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
            this.gridView.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Package Type";
            this.gridColumn1.ColumnEdit = this.lookupRepoPackageType;
            this.gridColumn1.FieldName = "PackageTypeId";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 142;
            // 
            // lookupRepoPackageType
            // 
            this.lookupRepoPackageType.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lookupRepoPackageType.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lookupRepoPackageType.AutoCompleteDataManager = null;
            this.lookupRepoPackageType.AutoCompleteDisplayFormater = null;
            this.lookupRepoPackageType.AutocompleteMinimumTextLength = 2;
            this.lookupRepoPackageType.AutoCompleteText = null;
            this.lookupRepoPackageType.AutoCompleteWhereExpression = null;
            this.lookupRepoPackageType.AutoCompleteWheretermFormater = null;
            this.lookupRepoPackageType.AutoHeight = false;
            this.lookupRepoPackageType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lookupRepoPackageType.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lookupRepoPackageType.LookupPopup = null;
            this.lookupRepoPackageType.Name = "lookupRepoPackageType";
            this.lookupRepoPackageType.NullText = "<<Choose...>>";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Weight From";
            this.gridColumn2.FieldName = "FromWeight";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 73;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Weight To";
            this.gridColumn3.FieldName = "ToWeight";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 73;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tariff";
            this.gridColumn4.FieldName = "Tariff";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 107;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Add Kg";
            this.gridColumn5.FieldName = "OtherKg";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 76;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Add Fee";
            this.gridColumn6.FieldName = "OtherFee";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 121;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Currency";
            this.gridColumn7.ColumnEdit = this.lookupRepoCurrency;
            this.gridColumn7.FieldName = "CurrencyId";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 137;
            // 
            // lookupRepoCurrency
            // 
            this.lookupRepoCurrency.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lookupRepoCurrency.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lookupRepoCurrency.AutoCompleteDataManager = null;
            this.lookupRepoCurrency.AutoCompleteDisplayFormater = null;
            this.lookupRepoCurrency.AutocompleteMinimumTextLength = 2;
            this.lookupRepoCurrency.AutoCompleteText = null;
            this.lookupRepoCurrency.AutoCompleteWhereExpression = null;
            this.lookupRepoCurrency.AutoCompleteWheretermFormater = null;
            this.lookupRepoCurrency.AutoHeight = false;
            this.lookupRepoCurrency.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lookupRepoCurrency.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lookupRepoCurrency.LookupPopup = null;
            this.lookupRepoCurrency.Name = "lookupRepoCurrency";
            this.lookupRepoCurrency.NullText = "<<Choose...>>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 114;
            this.label1.Text = "Zone Name";
            // 
            // txtZoneName
            // 
            this.txtZoneName.Capslock = true;
            this.txtZoneName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtZoneName.FieldLabel = null;
            this.txtZoneName.Location = new System.Drawing.Point(122, 48);
            this.txtZoneName.Name = "txtZoneName";
            this.txtZoneName.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtZoneName.Size = new System.Drawing.Size(212, 20);
            this.txtZoneName.TabIndex = 115;
            this.txtZoneName.ValidationRules = null;
            // 
            // ManagePublishedInternationalTariffForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(772, 487);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtZoneName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ManagePublishedInternationalTariffForm";
            this.Text = "Master Published International Tariff";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.Controls.SetChildIndex(this.txtZoneName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoPackageType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoCurrency)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private System.Windows.Forms.Label label1;
        private dTextBox txtZoneName;
        private Common.ComponentRepositories.LookupRepo lookupRepoPackageType;
        private Common.ComponentRepositories.LookupRepo lookupRepoCurrency;



    }
}