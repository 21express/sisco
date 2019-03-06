namespace SISCO.Presentation.MasterData.Forms
{
    partial class ManageCostTypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageCostTypeForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxName = new SISCO.Presentation.Common.Component.dTextBox();
            this.GridDivision = new DevExpress.XtraGrid.GridControl();
            this.DivisionView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.lkpDivision = new SISCO.Presentation.Common.Component.dLookup();
            ((System.ComponentModel.ISupportInitialize)(this.GridDivision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DivisionView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDivision.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnNew.Location = new System.Drawing.Point(5, 4);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(60, 60);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(73, 4);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 60);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(137, 4);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 60);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cost Type";
            // 
            // tbxName
            // 
            this.tbxName.Capslock = true;
            this.tbxName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxName.FieldLabel = null;
            this.tbxName.Location = new System.Drawing.Point(112, 78);
            this.tbxName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxName.Name = "tbxName";
            this.tbxName.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxName.Size = new System.Drawing.Size(251, 24);
            this.tbxName.TabIndex = 4;
            this.tbxName.ValidationRules = null;
            // 
            // GridDivision
            // 
            this.GridDivision.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridDivision.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GridDivision.Location = new System.Drawing.Point(5, 136);
            this.GridDivision.MainView = this.DivisionView;
            this.GridDivision.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GridDivision.Name = "GridDivision";
            this.GridDivision.Size = new System.Drawing.Size(465, 359);
            this.GridDivision.TabIndex = 5;
            this.GridDivision.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DivisionView});
            // 
            // DivisionView
            // 
            this.DivisionView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.DivisionView.GridControl = this.GridDivision;
            this.DivisionView.Name = "DivisionView";
            this.DivisionView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 20;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Cost Type";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 177;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "gridColumn3";
            this.gridColumn3.FieldName = "Id";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "gridColumn4";
            this.gridColumn4.FieldName = "DivisionId";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Division";
            this.gridColumn5.FieldName = "DivisionName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 250;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Division";
            // 
            // lkpDivision
            // 
            this.lkpDivision.AutoCompleteDataManager = null;
            this.lkpDivision.AutoCompleteDisplayFormater = null;
            this.lkpDivision.AutoCompleteInitialized = false;
            this.lkpDivision.AutocompleteMinimumTextLength = 0;
            this.lkpDivision.AutoCompleteText = null;
            this.lkpDivision.AutoCompleteWhereExpression = null;
            this.lkpDivision.AutoCompleteWheretermFormater = null;
            this.lkpDivision.ClearOnLeave = true;
            this.lkpDivision.DisplayString = null;
            this.lkpDivision.FieldLabel = null;
            this.lkpDivision.Location = new System.Drawing.Point(112, 104);
            this.lkpDivision.LookupPopup = null;
            this.lkpDivision.Name = "lkpDivision";
            this.lkpDivision.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpDivision.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpDivision.Properties.Appearance.Options.UseFont = true;
            this.lkpDivision.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpDivision.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpDivision.Properties.AutoCompleteDataManager = null;
            this.lkpDivision.Properties.AutoCompleteDisplayFormater = null;
            this.lkpDivision.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpDivision.Properties.AutoCompleteText = null;
            this.lkpDivision.Properties.AutoCompleteWhereExpression = null;
            this.lkpDivision.Properties.AutoCompleteWheretermFormater = null;
            this.lkpDivision.Properties.AutoHeight = false;
            this.lkpDivision.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpDivision.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpDivision.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpDivision.Properties.LookupPopup = null;
            this.lkpDivision.Properties.NullText = "<<Choose...>>";
            this.lkpDivision.Size = new System.Drawing.Size(251, 24);
            this.lkpDivision.TabIndex = 7;
            this.lkpDivision.ValidationRules = null;
            this.lkpDivision.Value = null;
            // 
            // ManageCostTypeForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(475, 500);
            this.Controls.Add(this.lkpDivision);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GridDivision);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ManageCostTypeForm";
            this.Text = "Master Data - Cost Type";
            ((System.ComponentModel.ISupportInitialize)(this.GridDivision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DivisionView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDivision.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private System.Windows.Forms.Label label1;
        private Common.Component.dTextBox tbxName;
        private DevExpress.XtraGrid.GridControl GridDivision;
        private DevExpress.XtraGrid.Views.Grid.GridView DivisionView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.Label label2;
        private Common.Component.dLookup lkpDivision;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}