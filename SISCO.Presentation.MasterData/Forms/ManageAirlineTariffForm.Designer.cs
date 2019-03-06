using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;

namespace SISCO.Presentation.MasterData.Forms
{
    partial class ManageAirlineTariffForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageAirlineTariffForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OriginAirportCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookupRepoAirport = new SISCO.Presentation.Common.ComponentRepositories.LookupRepo();
            this.DestinationAirportCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemButtonEditOriginAirport = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemButtonDestinationAirport = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAirlineName = new SISCO.Presentation.Common.Component.dTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoAirport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditOriginAirport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonDestinationAirport)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.First.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.grid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grid.Location = new System.Drawing.Point(12, 84);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemButtonEditOriginAirport,
            this.repositoryItemButtonDestinationAirport,
            this.lookupRepoAirport});
            this.grid.Size = new System.Drawing.Size(612, 346);
            this.grid.TabIndex = 116;
            this.grid.UseEmbeddedNavigator = true;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn8,
            this.gridColumn7,
            this.gridColumn6,
            this.gridColumn14,
            this.gridColumn13,
            this.gridColumn16,
            this.gridColumn15,
            this.gridColumn12,
            this.gridColumn11,
            this.gridColumn9,
            this.gridColumn21,
            this.gridColumn20,
            this.gridColumn19,
            this.gridColumn18,
            this.gridColumn17,
            this.gridColumn22,
            this.OriginAirportCode,
            this.DestinationAirportCode,
            this.gridColumn5});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "ID";
            this.gridColumn10.FieldName = "Id";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "CustomerID";
            this.gridColumn8.FieldName = "CustomerId";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "AirlineOrigId";
            this.gridColumn7.FieldName = "AirlineOrigId";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "AirlineDestId";
            this.gridColumn6.FieldName = "AirlineDestId";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "ServiceTypeId";
            this.gridColumn14.FieldName = "ServiceTypeId";
            this.gridColumn14.Name = "gridColumn14";
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "PackageTypeId";
            this.gridColumn13.FieldName = "PackageTypeId";
            this.gridColumn13.Name = "gridColumn13";
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Handling Fee";
            this.gridColumn16.FieldName = "HandlingFee";
            this.gridColumn16.Name = "gridColumn16";
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "DiscountPercent";
            this.gridColumn15.FieldName = "DiscountPercent";
            this.gridColumn15.Name = "gridColumn15";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "DiscountFixed";
            this.gridColumn12.FieldName = "DiscountFixed";
            this.gridColumn12.Name = "gridColumn12";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "MinWeight";
            this.gridColumn11.FieldName = "MinWeight";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "OtherFee";
            this.gridColumn9.FieldName = "OtherFee";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "OtherPercent";
            this.gridColumn21.FieldName = "OtherPercent";
            this.gridColumn21.Name = "gridColumn21";
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "OtherKg";
            this.gridColumn20.FieldName = "OtherKg";
            this.gridColumn20.Name = "gridColumn20";
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "CurrencyId";
            this.gridColumn19.FieldName = "CurrencyId";
            this.gridColumn19.Name = "gridColumn19";
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "PricingPlanId";
            this.gridColumn18.FieldName = "PricingPlanId";
            this.gridColumn18.Name = "gridColumn18";
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "FromWeight";
            this.gridColumn17.FieldName = "FromWeight";
            this.gridColumn17.Name = "gridColumn17";
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "ToWeight";
            this.gridColumn22.FieldName = "ToWeight";
            this.gridColumn22.Name = "gridColumn22";
            // 
            // OriginAirportCode
            // 
            this.OriginAirportCode.Caption = "Origin";
            this.OriginAirportCode.FieldName = "AirlineOrigId";
            this.OriginAirportCode.Name = "OriginAirportCode";
            this.OriginAirportCode.Visible = true;
            this.OriginAirportCode.VisibleIndex = 0;
            this.OriginAirportCode.Width = 214;
            // 
            // lookupRepo1
            // 
            this.lookupRepoAirport.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lookupRepoAirport.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lookupRepoAirport.AutoCompleteDisplayFormater = null;
            this.lookupRepoAirport.AutocompleteMinimumTextLength = 2;
            this.lookupRepoAirport.AutoCompleteText = null;
            this.lookupRepoAirport.AutoCompleteWhereExpression = null;
            this.lookupRepoAirport.AutoCompleteWheretermFormater = null;
            this.lookupRepoAirport.AutoHeight = false;
            this.lookupRepoAirport.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lookupRepo1.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lookupRepoAirport.LookupPopup = null;
            this.lookupRepoAirport.Name = "lookupRepo1";
            this.lookupRepoAirport.NullText = "<<Choose...>>";
            // 
            // DestinationAirportCode
            // 
            this.DestinationAirportCode.Caption = "Destination";
            this.DestinationAirportCode.FieldName = "AirlineDestId";
            this.DestinationAirportCode.Name = "DestinationAirportCode";
            this.DestinationAirportCode.Visible = true;
            this.DestinationAirportCode.VisibleIndex = 1;
            this.DestinationAirportCode.Width = 237;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tariff";
            this.gridColumn5.ColumnEdit = this.repositoryItemTextEdit1;
            this.gridColumn5.DisplayFormat.FormatString = "###,###,##0";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "Tariff";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 143;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.DisplayFormat.FormatString = "###,###,##0";
            this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.Mask.EditMask = "###,###,##0";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemButtonEditOriginAirport
            // 
            this.repositoryItemButtonEditOriginAirport.AutoHeight = false;
            this.repositoryItemButtonEditOriginAirport.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEditOriginAirport.Name = "repositoryItemButtonEditOriginAirport";
            // 
            // repositoryItemButtonDestinationAirport
            // 
            this.repositoryItemButtonDestinationAirport.AutoHeight = false;
            this.repositoryItemButtonDestinationAirport.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonDestinationAirport.Name = "repositoryItemButtonDestinationAirport";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(24, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 114;
            this.label1.Text = "Airline";
            // 
            // txtAirlineName
            // 
            this.txtAirlineName.Capslock = true;
            this.txtAirlineName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirlineName.FieldLabel = null;
            this.txtAirlineName.Location = new System.Drawing.Point(124, 48);
            this.txtAirlineName.Name = "txtAirlineName";
            this.txtAirlineName.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtAirlineName.Size = new System.Drawing.Size(234, 20);
            this.txtAirlineName.TabIndex = 115;
            this.txtAirlineName.ValidationRules = null;
            // 
            // ManageAirlineTariffForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(636, 441);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAirlineName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ManageAirlineTariffForm";
            this.Text = "Master Airline Tariff";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.Controls.SetChildIndex(this.txtAirlineName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoAirport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditOriginAirport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonDestinationAirport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.Label label1;
        private Common.Component.dTextBox txtAirlineName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn OriginAirportCode;
        private DevExpress.XtraGrid.Columns.GridColumn DestinationAirportCode;
        private RepositoryItemTextEdit repositoryItemTextEdit1;
        private RepositoryItemButtonEdit repositoryItemButtonEditOriginAirport;
        private RepositoryItemButtonEdit repositoryItemButtonDestinationAirport;
        private Common.ComponentRepositories.LookupRepo lookupRepoAirport;




    }
}