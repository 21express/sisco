using SISCO.Presentation.Common.Component;

namespace SISCO.Presentation.MasterData.Forms
{
    partial class ManageDeliveryTariffForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageDeliveryTariffForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookupRepoCity = new SISCO.Presentation.Common.ComponentRepositories.LookupRepo();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPackageType = new SISCO.Presentation.Common.Component.dTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddToAll = new System.Windows.Forms.Button();
            this.txtAddToAll = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoCity)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddToAll.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grid.Location = new System.Drawing.Point(12, 100);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookupRepoCity});
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
            this.gridColumn5});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Destination";
            this.gridColumn1.ColumnEdit = this.lookupRepoCity;
            this.gridColumn1.FieldName = "DestCityId";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 73;
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
            this.gridColumn2.Caption = "Weight From";
            this.gridColumn2.FieldName = "WeightFrom";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 80;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Weight To";
            this.gridColumn3.FieldName = "WeightTo";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 68;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tariff";
            this.gridColumn4.FieldName = "Tariff";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 46;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Min Weight";
            this.gridColumn5.FieldName = "MinWeight";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 72;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 116;
            this.label1.Text = "Package Type";
            // 
            // txtPackageType
            // 
            this.txtPackageType.Capslock = true;
            this.txtPackageType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPackageType.FieldLabel = null;
            this.txtPackageType.Location = new System.Drawing.Point(100, 59);
            this.txtPackageType.Name = "txtPackageType";
            this.txtPackageType.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtPackageType.Size = new System.Drawing.Size(187, 20);
            this.txtPackageType.TabIndex = 101;
            this.txtPackageType.ValidationRules = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddToAll);
            this.groupBox1.Controls.Add(this.txtAddToAll);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(500, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 55);
            this.groupBox1.TabIndex = 104;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add To All";
            // 
            // btnAddToAll
            // 
            this.btnAddToAll.Location = new System.Drawing.Point(133, 18);
            this.btnAddToAll.Name = "btnAddToAll";
            this.btnAddToAll.Size = new System.Drawing.Size(58, 23);
            this.btnAddToAll.TabIndex = 106;
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
            this.btnExport.Location = new System.Drawing.Point(405, 53);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 30);
            this.btnExport.TabIndex = 103;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.ForeColor = System.Drawing.Color.Black;
            this.btnImport.Location = new System.Drawing.Point(324, 53);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 30);
            this.btnImport.TabIndex = 102;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // ManageDeliveryTariffForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(720, 503);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPackageType);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ManageDeliveryTariffForm";
            this.Text = "Master Delivery Tariff";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.Controls.SetChildIndex(this.btnImport, 0);
            this.Controls.SetChildIndex(this.btnExport, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txtPackageType, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoCity)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private dTextBox txtPackageType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddToAll;
        private Common.Component.dTextBoxNumber txtAddToAll;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private Common.ComponentRepositories.LookupRepo lookupRepoCity;
    }
}