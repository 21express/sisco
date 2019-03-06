using SISCO.Presentation.Common.Component;

namespace SISCO.Presentation.MasterData.Forms
{
    partial class ManageFlightScheduleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageFlightScheduleForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnOriginAirport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookupRepoAirport = new SISCO.Presentation.Common.ComponentRepositories.LookupRepo();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clFlightNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.comboBoxRepoWeekday = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timeEditRepoTime1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAirlineName = new SISCO.Presentation.Common.Component.dTextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoAirport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxRepoWeekday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditRepoTime1)).BeginInit();
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
            this.grid.Location = new System.Drawing.Point(14, 83);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookupRepoAirport,
            this.comboBoxRepoWeekday,
            this.timeEditRepoTime1});
            this.grid.Size = new System.Drawing.Size(628, 332);
            this.grid.TabIndex = 117;
            this.grid.UseEmbeddedNavigator = true;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnOriginAirport,
            this.gridColumn4,
            this.clFlightNumber,
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
            // lookupRepoAirport
            // 
            this.lookupRepoAirport.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lookupRepoAirport.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lookupRepoAirport.AutoCompleteDataManager = null;
            this.lookupRepoAirport.AutoCompleteDisplayFormater = null;
            this.lookupRepoAirport.AutocompleteMinimumTextLength = 2;
            this.lookupRepoAirport.AutoCompleteText = null;
            this.lookupRepoAirport.AutoCompleteWhereExpression = null;
            this.lookupRepoAirport.AutoCompleteWheretermFormater = null;
            this.lookupRepoAirport.AutoHeight = false;
            this.lookupRepoAirport.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lookupRepoAirport.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lookupRepoAirport.LookupPopup = null;
            this.lookupRepoAirport.Name = "lookupRepoAirport";
            this.lookupRepoAirport.NullText = "<<Choose...>>";
            // 
            // gridColumnOriginAirport
            // 
            this.gridColumnOriginAirport.Caption = "Origin Airport";
            this.gridColumnOriginAirport.FieldName = "OriginAirportId";
            this.gridColumnOriginAirport.Name = "gridColumnOriginAirport";
            this.gridColumnOriginAirport.Visible = true;
            this.gridColumnOriginAirport.VisibleIndex = 0;
            this.gridColumnOriginAirport.Width = 123;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Destination Airport";
            this.gridColumn4.FieldName = "DestAirportId";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 131;
            // 
            // clFlightNumber
            // 
            this.clFlightNumber.Caption = "Flight Number";
            this.clFlightNumber.FieldName = "FlightNumber";
            this.clFlightNumber.Name = "clFlightNumber";
            this.clFlightNumber.Visible = true;
            this.clFlightNumber.VisibleIndex = 2;
            this.clFlightNumber.Width = 94;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Weekday";
            this.gridColumn5.FieldName = "WeekDay";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 90;
            // 
            // comboBoxRepoWeekday
            // 
            this.comboBoxRepoWeekday.AutoHeight = false;
            this.comboBoxRepoWeekday.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxRepoWeekday.Name = "comboBoxRepoWeekday";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Depart Time";
            this.gridColumn6.FieldName = "EstDepartureTime";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 70;
            // 
            // timeEditRepoTime1
            // 
            this.timeEditRepoTime1.AutoHeight = false;
            this.timeEditRepoTime1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditRepoTime1.Name = "timeEditRepoTime1";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Arrival Time";
            this.gridColumn7.FieldName = "EstArrivalTime";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 79;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(26, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 115;
            this.label1.Text = "Airline";
            // 
            // txtAirlineName
            // 
            this.txtAirlineName.Capslock = true;
            this.txtAirlineName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirlineName.FieldLabel = null;
            this.txtAirlineName.Location = new System.Drawing.Point(126, 47);
            this.txtAirlineName.Name = "txtAirlineName";
            this.txtAirlineName.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtAirlineName.Size = new System.Drawing.Size(234, 20);
            this.txtAirlineName.TabIndex = 116;
            this.txtAirlineName.ValidationRules = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 421);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 13);
            this.label2.TabIndex = 118;
            this.label2.Text = "Double click on a route to edit route schedules";
            // 
            // ManageFlightScheduleForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(658, 438);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAirlineName);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ManageFlightScheduleForm";
            this.Text = "Master Flight Schedule";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtAirlineName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRepoAirport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxRepoWeekday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditRepoTime1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnOriginAirport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private System.Windows.Forms.Label label1;
        private dTextBox txtAirlineName;
        private System.Windows.Forms.Label label2;
        private Common.ComponentRepositories.LookupRepo lookupRepoAirport;
        private DevExpress.XtraGrid.Columns.GridColumn clFlightNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit comboBoxRepoWeekday;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit timeEditRepoTime1;



    }
}