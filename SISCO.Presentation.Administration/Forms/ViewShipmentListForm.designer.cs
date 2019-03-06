using System.Windows.Forms;
using DevExpress.XtraEditors;
using SISCO.Presentation.Common.Component;

namespace SISCO.Presentation.Administration.Forms
{
    partial class ViewShipmentListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewShipmentListForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtTotalChargeableWeight = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtTotalGrossWeight = new SISCO.Presentation.Common.Component.dTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalPiece = new SISCO.Presentation.Common.Component.dTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveToExcel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lkpPaymentMethod = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpDestBranch = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpDestCity = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpCustomer = new SISCO.Presentation.Common.Component.dLookup();
            this.txtDateTo = new SISCO.Presentation.Common.Component.dCalendar();
            this.txtDateFrom = new SISCO.Presentation.Common.Component.dCalendar();
            this.cmbStatus = new SISCO.Presentation.Common.Component.dComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtShipmentCode = new SISCO.Presentation.Common.Component.dTextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPaymentMethod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(675, 497);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(77, 30);
            this.btnPrint.TabIndex = 141;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // txtTotalChargeableWeight
            // 
            this.txtTotalChargeableWeight.Capslock = true;
            this.txtTotalChargeableWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalChargeableWeight.FieldLabel = null;
            this.txtTotalChargeableWeight.Location = new System.Drawing.Point(331, 13);
            this.txtTotalChargeableWeight.Name = "txtTotalChargeableWeight";
            this.txtTotalChargeableWeight.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtTotalChargeableWeight.Size = new System.Drawing.Size(85, 20);
            this.txtTotalChargeableWeight.TabIndex = 135;
            this.txtTotalChargeableWeight.ValidationRules = null;
            // 
            // txtTotalGrossWeight
            // 
            this.txtTotalGrossWeight.Capslock = true;
            this.txtTotalGrossWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalGrossWeight.FieldLabel = null;
            this.txtTotalGrossWeight.Location = new System.Drawing.Point(187, 13);
            this.txtTotalGrossWeight.Name = "txtTotalGrossWeight";
            this.txtTotalGrossWeight.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtTotalGrossWeight.Size = new System.Drawing.Size(85, 20);
            this.txtTotalGrossWeight.TabIndex = 135;
            this.txtTotalGrossWeight.ValidationRules = null;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(297, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 134;
            this.label10.Text = "CW:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtTotalChargeableWeight);
            this.groupBox2.Controls.Add(this.txtTotalGrossWeight);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtTotalPiece);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 491);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 41);
            this.groupBox2.TabIndex = 140;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 134;
            this.label4.Text = "Pcs:";
            // 
            // txtTotalPiece
            // 
            this.txtTotalPiece.Capslock = true;
            this.txtTotalPiece.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalPiece.FieldLabel = null;
            this.txtTotalPiece.Location = new System.Drawing.Point(50, 13);
            this.txtTotalPiece.Name = "txtTotalPiece";
            this.txtTotalPiece.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtTotalPiece.Size = new System.Drawing.Size(85, 20);
            this.txtTotalPiece.TabIndex = 135;
            this.txtTotalPiece.ValidationRules = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(153, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 134;
            this.label3.Text = "GW:";
            // 
            // btnSaveToExcel
            // 
            this.btnSaveToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveToExcel.Location = new System.Drawing.Point(758, 497);
            this.btnSaveToExcel.Name = "btnSaveToExcel";
            this.btnSaveToExcel.Size = new System.Drawing.Size(114, 30);
            this.btnSaveToExcel.TabIndex = 142;
            this.btnSaveToExcel.Text = "Save To Excel";
            this.btnSaveToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveToExcel.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(430, 147);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(77, 26);
            this.btnSearch.TabIndex = 131;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(14, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 138;
            this.label7.Text = "Shipment Code";
            // 
            // grid
            // 
            this.grid.Location = new System.Drawing.Point(12, 199);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(860, 288);
            this.grid.TabIndex = 138;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn13,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn5,
            this.gridColumn14,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn3,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn29});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Shipment No.";
            this.gridColumn1.FieldName = "Code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Date";
            this.gridColumn2.FieldName = "DateProcess";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 56;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Shipper";
            this.gridColumn13.FieldName = "ShipperName";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 2;
            this.gridColumn13.Width = 99;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Consignee";
            this.gridColumn4.FieldName = "ConsigneeName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 100;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Destination";
            this.gridColumn6.FieldName = "DestBranchName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 78;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Payment Method";
            this.gridColumn7.FieldName = "PaymentMethod";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 43;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Package Type";
            this.gridColumn8.FieldName = "PackageType";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 43;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Pieces";
            this.gridColumn5.FieldName = "TtlPiece";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            this.gridColumn5.Width = 43;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "GW";
            this.gridColumn14.FieldName = "TtlGrossWeight";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 9;
            this.gridColumn14.Width = 43;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "CW";
            this.gridColumn9.FieldName = "TtlChargeableWeight";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 43;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Kirim";
            this.gridColumn10.FieldName = "PodSentStatus";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 10;
            this.gridColumn10.Width = 43;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Terima";
            this.gridColumn3.FieldName = "PodReceivedStatus";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 11;
            this.gridColumn3.Width = 43;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Customer";
            this.gridColumn11.FieldName = "PodReturnedStatus";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 12;
            this.gridColumn11.Width = 43;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Invoiced";
            this.gridColumn12.FieldName = "InvoicedStatus";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 13;
            this.gridColumn12.Width = 65;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "Process Time";
            this.gridColumn29.FieldName = "ProcessTime";
            this.gridColumn29.Name = "gridColumn14";
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 14;
            this.gridColumn29.Width = 49;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(6, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 138;
            this.label8.Text = "Payment Method";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(43, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 127;
            this.label1.Text = "Customer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(96, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 127;
            this.label6.Text = "From";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(261, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 127;
            this.label5.Text = "To";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(63, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 13);
            this.label14.TabIndex = 127;
            this.label14.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(44, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "Dest City";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lkpPaymentMethod);
            this.groupBox1.Controls.Add(this.lkpDestBranch);
            this.groupBox1.Controls.Add(this.lkpDestCity);
            this.groupBox1.Controls.Add(this.lkpCustomer);
            this.groupBox1.Controls.Add(this.txtDateTo);
            this.groupBox1.Controls.Add(this.txtDateFrom);
            this.groupBox1.Controls.Add(this.cmbStatus);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtShipmentCode);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 181);
            this.groupBox1.TabIndex = 139;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // lkpPaymentMethod
            // 
            this.lkpPaymentMethod.AutoCompleteDataManager = null;
            this.lkpPaymentMethod.AutoCompleteDisplayFormater = null;
            this.lkpPaymentMethod.AutoCompleteInitialized = false;
            this.lkpPaymentMethod.AutocompleteMinimumTextLength = 0;
            this.lkpPaymentMethod.AutoCompleteText = null;
            this.lkpPaymentMethod.AutoCompleteWhereExpression = null;
            this.lkpPaymentMethod.AutoCompleteWheretermFormater = null;
            this.lkpPaymentMethod.ClearOnLeave = true;
            this.lkpPaymentMethod.DisplayString = null;
            this.lkpPaymentMethod.FieldLabel = null;
            this.lkpPaymentMethod.Location = new System.Drawing.Point(99, 107);
            this.lkpPaymentMethod.LookupPopup = null;
            this.lkpPaymentMethod.Name = "lkpPaymentMethod";
            this.lkpPaymentMethod.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpPaymentMethod.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpPaymentMethod.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpPaymentMethod.Properties.AutoCompleteDataManager = null;
            this.lkpPaymentMethod.Properties.AutoCompleteDisplayFormater = null;
            this.lkpPaymentMethod.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpPaymentMethod.Properties.AutoCompleteText = null;
            this.lkpPaymentMethod.Properties.AutoCompleteWhereExpression = null;
            this.lkpPaymentMethod.Properties.AutoCompleteWheretermFormater = null;
            this.lkpPaymentMethod.Properties.AutoHeight = false;
            this.lkpPaymentMethod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpPaymentMethod.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpPaymentMethod.Properties.LookupPopup = null;
            this.lkpPaymentMethod.Properties.NullText = "<<Choose...>>";
            this.lkpPaymentMethod.Size = new System.Drawing.Size(156, 20);
            this.lkpPaymentMethod.TabIndex = 106;
            this.lkpPaymentMethod.ValidationRules = null;
            this.lkpPaymentMethod.Value = null;
            // 
            // lkpDestBranch
            // 
            this.lkpDestBranch.AutoCompleteDataManager = null;
            this.lkpDestBranch.AutoCompleteDisplayFormater = null;
            this.lkpDestBranch.AutoCompleteInitialized = false;
            this.lkpDestBranch.AutocompleteMinimumTextLength = 0;
            this.lkpDestBranch.AutoCompleteText = null;
            this.lkpDestBranch.AutoCompleteWhereExpression = null;
            this.lkpDestBranch.AutoCompleteWheretermFormater = null;
            this.lkpDestBranch.ClearOnLeave = true;
            this.lkpDestBranch.DisplayString = null;
            this.lkpDestBranch.FieldLabel = null;
            this.lkpDestBranch.Location = new System.Drawing.Point(99, 63);
            this.lkpDestBranch.LookupPopup = null;
            this.lkpDestBranch.Name = "lkpDestBranch";
            this.lkpDestBranch.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpDestBranch.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpDestBranch.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpDestBranch.Properties.AutoCompleteDataManager = null;
            this.lkpDestBranch.Properties.AutoCompleteDisplayFormater = null;
            this.lkpDestBranch.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpDestBranch.Properties.AutoCompleteText = null;
            this.lkpDestBranch.Properties.AutoCompleteWhereExpression = null;
            this.lkpDestBranch.Properties.AutoCompleteWheretermFormater = null;
            this.lkpDestBranch.Properties.AutoHeight = false;
            this.lkpDestBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpDestBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpDestBranch.Properties.LookupPopup = null;
            this.lkpDestBranch.Properties.NullText = "<<Choose...>>";
            this.lkpDestBranch.Size = new System.Drawing.Size(308, 20);
            this.lkpDestBranch.TabIndex = 104;
            this.lkpDestBranch.ValidationRules = null;
            this.lkpDestBranch.Value = null;
            // 
            // lkpDestCity
            // 
            this.lkpDestCity.AutoCompleteDataManager = null;
            this.lkpDestCity.AutoCompleteDisplayFormater = null;
            this.lkpDestCity.AutoCompleteInitialized = false;
            this.lkpDestCity.AutocompleteMinimumTextLength = 0;
            this.lkpDestCity.AutoCompleteText = null;
            this.lkpDestCity.AutoCompleteWhereExpression = null;
            this.lkpDestCity.AutoCompleteWheretermFormater = null;
            this.lkpDestCity.ClearOnLeave = true;
            this.lkpDestCity.DisplayString = null;
            this.lkpDestCity.FieldLabel = null;
            this.lkpDestCity.Location = new System.Drawing.Point(99, 85);
            this.lkpDestCity.LookupPopup = null;
            this.lkpDestCity.Name = "lkpDestCity";
            this.lkpDestCity.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpDestCity.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpDestCity.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpDestCity.Properties.AutoCompleteDataManager = null;
            this.lkpDestCity.Properties.AutoCompleteDisplayFormater = null;
            this.lkpDestCity.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpDestCity.Properties.AutoCompleteText = null;
            this.lkpDestCity.Properties.AutoCompleteWhereExpression = null;
            this.lkpDestCity.Properties.AutoCompleteWheretermFormater = null;
            this.lkpDestCity.Properties.AutoHeight = false;
            this.lkpDestCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpDestCity.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.lkpDestCity.Properties.LookupPopup = null;
            this.lkpDestCity.Properties.NullText = "<<Choose...>>";
            this.lkpDestCity.Size = new System.Drawing.Size(308, 20);
            this.lkpDestCity.TabIndex = 105;
            this.lkpDestCity.ValidationRules = null;
            this.lkpDestCity.Value = null;
            // 
            // lkpCustomer
            // 
            this.lkpCustomer.AutoCompleteDataManager = null;
            this.lkpCustomer.AutoCompleteDisplayFormater = null;
            this.lkpCustomer.AutoCompleteInitialized = false;
            this.lkpCustomer.AutocompleteMinimumTextLength = 0;
            this.lkpCustomer.AutoCompleteText = null;
            this.lkpCustomer.AutoCompleteWhereExpression = null;
            this.lkpCustomer.AutoCompleteWheretermFormater = null;
            this.lkpCustomer.ClearOnLeave = true;
            this.lkpCustomer.DisplayString = null;
            this.lkpCustomer.FieldLabel = null;
            this.lkpCustomer.Location = new System.Drawing.Point(99, 41);
            this.lkpCustomer.LookupPopup = null;
            this.lkpCustomer.Name = "lkpCustomer";
            this.lkpCustomer.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpCustomer.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpCustomer.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpCustomer.Properties.AutoCompleteDataManager = null;
            this.lkpCustomer.Properties.AutoCompleteDisplayFormater = null;
            this.lkpCustomer.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpCustomer.Properties.AutoCompleteText = null;
            this.lkpCustomer.Properties.AutoCompleteWhereExpression = null;
            this.lkpCustomer.Properties.AutoCompleteWheretermFormater = null;
            this.lkpCustomer.Properties.AutoHeight = false;
            this.lkpCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpCustomer.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.lkpCustomer.Properties.LookupPopup = null;
            this.lkpCustomer.Properties.NullText = "<<Choose...>>";
            this.lkpCustomer.Size = new System.Drawing.Size(308, 20);
            this.lkpCustomer.TabIndex = 103;
            this.lkpCustomer.ValidationRules = null;
            this.lkpCustomer.Value = null;
            // 
            // txtDateTo
            // 
            this.txtDateTo.EditValue = null;
            this.txtDateTo.FieldLabel = null;
            this.txtDateTo.FormatDateTime = "dd-MM-yyyy";
            this.txtDateTo.Location = new System.Drawing.Point(284, 19);
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Nullable = false;
            this.txtDateTo.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDateTo.Properties.AutoHeight = false;
            this.txtDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtDateTo.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.txtDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateTo.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDateTo.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDateTo.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtDateTo.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDateTo.Size = new System.Drawing.Size(123, 20);
            this.txtDateTo.TabIndex = 102;
            this.txtDateTo.ValidationRules = null;
            this.txtDateTo.Value = new System.DateTime(((long)(0)));
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.EditValue = null;
            this.txtDateFrom.FieldLabel = null;
            this.txtDateFrom.FormatDateTime = "dd-MM-yyyy";
            this.txtDateFrom.Location = new System.Drawing.Point(132, 19);
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.Nullable = false;
            this.txtDateFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDateFrom.Properties.AutoHeight = false;
            this.txtDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtDateFrom.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "", null, null, true)});
            this.txtDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateFrom.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDateFrom.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDateFrom.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtDateFrom.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDateFrom.Size = new System.Drawing.Size(123, 20);
            this.txtDateFrom.TabIndex = 101;
            this.txtDateFrom.ValidationRules = null;
            this.txtDateFrom.Value = new System.DateTime(((long)(0)));
            // 
            // cmbStatus
            // 
            this.cmbStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FieldLabel = null;
            this.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbStatus.Location = new System.Drawing.Point(99, 151);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(156, 21);
            this.cmbStatus.TabIndex = 108;
            this.cmbStatus.ValidationRules = null;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(56, 154);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 138;
            this.label11.Text = "Status";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(27, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 106;
            this.label12.Text = "Dest Branch";
            // 
            // txtShipmentCode
            // 
            this.txtShipmentCode.Capslock = true;
            this.txtShipmentCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipmentCode.FieldLabel = null;
            this.txtShipmentCode.Location = new System.Drawing.Point(99, 129);
            this.txtShipmentCode.Name = "txtShipmentCode";
            this.txtShipmentCode.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtShipmentCode.Size = new System.Drawing.Size(156, 20);
            this.txtShipmentCode.TabIndex = 107;
            this.txtShipmentCode.ValidationRules = null;
            // 
            // ViewShipmentListForm
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(884, 539);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSaveToExcel);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.groupBox1);
            this.Name = "ViewShipmentListForm";
            this.Text = "Shipment POD List";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPaymentMethod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private SISCO.Presentation.Common.Component.dTextBox txtTotalChargeableWeight;
        private SISCO.Presentation.Common.Component.dTextBox txtTotalGrossWeight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private SISCO.Presentation.Common.Component.dTextBox txtTotalPiece;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveToExcel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Common.Component.dLookup lkpPaymentMethod;
        private Common.Component.dLookup lkpDestCity;
        private Common.Component.dLookup lkpCustomer;
        private Common.Component.dCalendar txtDateTo;
        private Common.Component.dCalendar txtDateFrom;
        private dComboBox cmbStatus;
        private System.Windows.Forms.Label label11;
        private SISCO.Presentation.Common.Component.dTextBox txtShipmentCode;
        private dLookup lkpDestBranch;
        private Label label12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        
    }
}

