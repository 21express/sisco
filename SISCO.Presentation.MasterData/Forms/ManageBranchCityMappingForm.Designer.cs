using SISCO.Presentation.Common.Component;

namespace SISCO.Presentation.MasterData.Forms
{
    partial class ManageBranchCityMappingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageBranchCityMappingForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBranchName = new SISCO.Presentation.Common.Component.dTextBox();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookupRepoCity = new SISCO.Presentation.Common.ComponentRepositories.LookupRepo();
            this.grid = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(24, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 114;
            this.label1.Text = "Branch";
            // 
            // txtBranchName
            // 
            this.txtBranchName.Capslock = true;
            this.txtBranchName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBranchName.FieldLabel = null;
            this.txtBranchName.Location = new System.Drawing.Point(124, 45);
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtBranchName.Size = new System.Drawing.Size(234, 20);
            this.txtBranchName.TabIndex = 115;
            this.txtBranchName.ValidationRules = null;
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "City";
            this.gridColumn1.ColumnEdit = this.lookupRepoCity;
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "CityId";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
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
            // grid
            // 
            this.grid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grid.Location = new System.Drawing.Point(12, 81);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookupRepoCity});
            this.grid.Size = new System.Drawing.Size(588, 337);
            this.grid.TabIndex = 116;
            this.grid.UseEmbeddedNavigator = true;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // ManageBranchCityMappingForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(614, 430);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBranchName);
            this.Controls.Add(this.grid);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ManageBranchCityMappingForm";
            this.Text = "Master Branch City Mapping";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.Controls.SetChildIndex(this.grid, 0);
            this.Controls.SetChildIndex(this.txtBranchName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private dTextBox txtBranchName;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.GridControl grid;
        private Common.ComponentRepositories.LookupRepo lookupRepoCity;



    }
}