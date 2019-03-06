using Corporate.Presentation.Common.Component;

namespace Corporate.Presentation.CustomerService.Forms
{
    partial class TariffForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TariffForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFind = new DevExpress.XtraEditors.SimpleButton();
            this.lkpDestination = new Corporate.Presentation.Common.Component.dLookupC(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lkpOrigin = new Corporate.Presentation.Common.Component.dLookupC(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tarifGrid = new DevExpress.XtraGrid.GridControl();
            this.tarifView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestination.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpOrigin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarifGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarifView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.lkpDestination);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lkpOrigin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 118);
            this.panel1.TabIndex = 0;
            // 
            // btnFind
            // 
            this.btnFind.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnFind.Appearance.Options.UseFont = true;
            this.btnFind.Location = new System.Drawing.Point(288, 78);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 29);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "&Find";
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
            this.lkpDestination.Location = new System.Drawing.Point(102, 45);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpDestination.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpDestination.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpDestination.Properties.LookupPopup = null;
            this.lkpDestination.Size = new System.Drawing.Size(261, 24);
            this.lkpDestination.TabIndex = 2;
            this.lkpDestination.ValidationRules = null;
            this.lkpDestination.Value = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Destination";
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
            this.lkpOrigin.Location = new System.Drawing.Point(102, 19);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpOrigin.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpOrigin.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpOrigin.Properties.LookupPopup = null;
            this.lkpOrigin.Size = new System.Drawing.Size(261, 24);
            this.lkpOrigin.TabIndex = 1;
            this.lkpOrigin.ValidationRules = null;
            this.lkpOrigin.Value = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Origin";
            // 
            // tarifGrid
            // 
            this.tarifGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tarifGrid.Location = new System.Drawing.Point(4, 128);
            this.tarifGrid.MainView = this.tarifView;
            this.tarifGrid.Name = "tarifGrid";
            this.tarifGrid.Size = new System.Drawing.Size(395, 223);
            this.tarifGrid.TabIndex = 1;
            this.tarifGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tarifView});
            // 
            // tarifView
            // 
            this.tarifView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.tarifView.GridControl = this.tarifGrid;
            this.tarifView.Name = "tarifView";
            this.tarifView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Service Type";
            this.gridColumn1.FieldName = "ServiceTypeName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 153;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tariff";
            this.gridColumn2.DisplayFormat.FormatString = "n";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn2.FieldName = "Tariff";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 128;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Lead Time";
            this.gridColumn3.FieldName = "LeadTime";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 96;
            // 
            // TariffForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(403, 356);
            this.Controls.Add(this.tarifGrid);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TariffForm";
            this.Text = "Check Tariff";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestination.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpOrigin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarifGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarifView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Common.Component.dLookupC lkpDestination;
        private System.Windows.Forms.Label label2;
        private Common.Component.dLookupC lkpOrigin;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnFind;
        private DevExpress.XtraGrid.GridControl tarifGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView tarifView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}