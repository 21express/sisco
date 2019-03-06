using System.Windows.Forms;
using DevExpress.Utils;
using SISCO.Presentation.Common.Component;

namespace SISCO.Presentation.Billing.Forms
{
    partial class CreateSalesInvoiceByScanForm
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateSalesInvoiceByScanForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.txtPrintInvoiceToNo = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label4 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.chkPrintContinuous = new SISCO.Presentation.Common.Component.dCheckBox();
            this.chkCancelled = new SISCO.Presentation.Common.Component.dCheckBox();
            this.chkPrinted = new SISCO.Presentation.Common.Component.dCheckBox();
            this.btnSaveToExcel = new System.Windows.Forms.Button();
            this.btnPrintStatus = new System.Windows.Forms.Button();
            this.btnPrintDelivery = new System.Windows.Forms.Button();
            this.btnPrintReceipt = new System.Windows.Forms.Button();
            this.btnPrintInvoice = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnCancelInvoice = new System.Windows.Forms.Button();
            this.txtPrintInvoiceFromNo = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.btnDeleteShipment = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrintDelivery2 = new System.Windows.Forms.Button();
            this.btnReqFaktur = new System.Windows.Forms.Button();
            this.btnFaktur = new System.Windows.Forms.Button();
            this.pnlPrintInvoice = new System.Windows.Forms.Panel();
            this.chkIsCorporateInvoice = new SISCO.Presentation.Common.Component.dCheckBox();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridViewOtherFee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridOtherFee = new DevExpress.XtraGrid.GridControl();
            this.btnAddOtherFee = new System.Windows.Forms.Button();
            this.btnDeleteOtherFee = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlShipmentInfo = new System.Windows.Forms.Panel();
            this.tbxRevision = new SISCO.Presentation.Common.Component.dTextBox();
            this.lblRevision = new System.Windows.Forms.Label();
            this.tbxRevised = new SISCO.Presentation.Common.Component.dTextBox();
            this.lblRevised = new System.Windows.Forms.Label();
            this.lkpCustomer = new SISCO.Presentation.Common.Component.dLookup();
            this.txtDueDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.txtDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescription3 = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtDescription2 = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtDescription1 = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtInvoicedTo = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtReceiptNo = new SISCO.Presentation.Common.Component.dTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGrandTotal = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.pnlTotalAndAction = new System.Windows.Forms.Panel();
            this.cmbTaxType = new SISCO.Presentation.Common.Component.dComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRaFeePerPiece = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRaCwTotal = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTaxTotal = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.txtBeforeTax = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.txtCurrencyRate = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.txtDiscountPercent = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.txtTotalDiscountTotal = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.txtMateraiFee = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.txtTotalRaFee = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.txtFilterDateFrom = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtPeriod = new SISCO.Presentation.Common.Component.dTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFilterDateTo = new SISCO.Presentation.Common.Component.dTextBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.txtFilterDestinationCity = new SISCO.Presentation.Common.Component.dTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbTaxInvoice = new SISCO.Presentation.Common.Component.dComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbFilterCustomerType = new SISCO.Presentation.Common.Component.dComboBox();
            this.btnAddShipment = new System.Windows.Forms.Button();
            this.txtAddShipmentNo = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtTotalSales = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.txtTotalInternational = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotalCityCourier = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtTotalDomestic = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label21 = new System.Windows.Forms.Label();
            this.tbxNumber = new SISCO.Presentation.Common.Component.dTextBox();
            this.btnRelocation = new DevExpress.XtraEditors.SimpleButton();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrintInvoiceToNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrintInvoiceFromNo.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlPrintInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOtherFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOtherFee)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.pnlShipmentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDueDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDueDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrandTotal.Properties)).BeginInit();
            this.pnlTotalAndAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRaFeePerPiece.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRaCwTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeforeTax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrencyRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountPercent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDiscountTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMateraiFee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalRaFee.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalSales.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalInternational.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCityCourier.Properties)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDomestic.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Total";
            this.gridColumn16.DisplayFormat.FormatString = "#,#0";
            this.gridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn16.FieldName = "GrandTotalInBaseCurrency";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 15;
            this.gridColumn16.Width = 69;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Other";
            this.gridColumn14.DisplayFormat.FormatString = "#,#0";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn14.FieldName = "OtherFee";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 13;
            this.gridColumn14.Width = 66;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Net";
            this.gridColumn12.DisplayFormat.FormatString = "#,#0";
            this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn12.FieldName = "NetTariff";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 11;
            this.gridColumn12.Width = 64;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Discount";
            this.gridColumn8.DisplayFormat.FormatString = "n2";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "Discount";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 10;
            this.gridColumn8.Width = 55;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Tariff Total";
            this.gridColumn7.DisplayFormat.FormatString = "#,#0";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn7.FieldName = "TotalTariff";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 9;
            this.gridColumn7.Width = 68;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Packing";
            this.gridColumn11.DisplayFormat.FormatString = "#,#0";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn11.FieldName = "PackingFee";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 12;
            this.gridColumn11.Width = 64;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Handling";
            this.gridColumn3.DisplayFormat.FormatString = "#,#0";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn3.FieldName = "HandlingFee";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 8;
            this.gridColumn3.Width = 68;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Tariff";
            this.gridColumn10.DisplayFormat.FormatString = "#,#0";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn10.FieldName = "TariffPerKg";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 7;
            this.gridColumn10.Width = 59;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Service Type";
            this.gridColumn9.FieldName = "ServiceType";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            this.gridColumn9.Width = 72;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Insurance";
            this.gridColumn15.DisplayFormat.FormatString = "#,#0";
            this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn15.FieldName = "InsuranceFee";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 14;
            this.gridColumn15.Width = 55;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Weight";
            this.gridColumn5.DisplayFormat.FormatString = "#.0";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn5.FieldName = "TotalChargeableWeight";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 45;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Destination";
            this.gridColumn1.FieldName = "DestinationCity";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 91;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Date";
            this.gridColumn2.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "ShipmentProcessDate";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 62;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Shipment No.";
            this.gridColumn4.FieldName = "ShipmentCode";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 86;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "#";
            this.gridColumn6.FieldName = "Index";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 30;
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn4,
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn13,
            this.gridColumn5,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn3,
            this.gridColumn11,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn12,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn31,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19});
            this.gridView.GridControl = this.grid;
            this.gridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "gridColumn3", this.gridColumn3, "")});
            this.gridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Pcs";
            this.gridColumn13.DisplayFormat.FormatString = "#";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn13.FieldName = "TotalPiece";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 4;
            this.gridColumn13.Width = 33;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "Total IDR";
            this.gridColumn31.DisplayFormat.FormatString = "#,#0";
            this.gridColumn31.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn31.FieldName = "GrandTotal";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 18;
            this.gridColumn31.Width = 69;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Currency";
            this.gridColumn17.DisplayFormat.FormatString = "#,#0";
            this.gridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn17.FieldName = "Currency";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 16;
            this.gridColumn17.Width = 61;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Rate";
            this.gridColumn18.DisplayFormat.FormatString = "#,#0";
            this.gridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn18.FieldName = "CurrencyRate";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 17;
            this.gridColumn18.Width = 53;
            // 
            // grid
            // 
            gridLevelNode1.RelationName = "Level1";
            this.grid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grid.Location = new System.Drawing.Point(0, 158);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(921, 163);
            this.grid.TabIndex = 53;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // txtPrintInvoiceToNo
            // 
            this.txtPrintInvoiceToNo.EditMask = "###,###,###,###,###,##0.00";
            this.txtPrintInvoiceToNo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPrintInvoiceToNo.FieldLabel = null;
            this.txtPrintInvoiceToNo.Location = new System.Drawing.Point(45, 76);
            this.txtPrintInvoiceToNo.Name = "txtPrintInvoiceToNo";
            this.txtPrintInvoiceToNo.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtPrintInvoiceToNo.Properties.AllowMouseWheel = false;
            this.txtPrintInvoiceToNo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPrintInvoiceToNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtPrintInvoiceToNo.Properties.Mask.BeepOnError = true;
            this.txtPrintInvoiceToNo.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtPrintInvoiceToNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrintInvoiceToNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPrintInvoiceToNo.ReadOnly = false;
            this.txtPrintInvoiceToNo.Size = new System.Drawing.Size(48, 20);
            this.txtPrintInvoiceToNo.TabIndex = 107;
            this.txtPrintInvoiceToNo.TextAlign = null;
            this.txtPrintInvoiceToNo.ValidationRules = null;
            this.txtPrintInvoiceToNo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(8, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 106;
            this.label4.Text = "Invoiced To";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.Black;
            this.label35.Location = new System.Drawing.Point(8, 94);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(64, 13);
            this.label35.TabIndex = 106;
            this.label35.Text = "Due Date";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkPrintContinuous
            // 
            this.chkPrintContinuous.AutoSize = true;
            this.chkPrintContinuous.Enabled = false;
            this.chkPrintContinuous.FieldLabel = null;
            this.chkPrintContinuous.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrintContinuous.ForeColor = System.Drawing.Color.Black;
            this.chkPrintContinuous.Location = new System.Drawing.Point(10, 35);
            this.chkPrintContinuous.Name = "chkPrintContinuous";
            this.chkPrintContinuous.Size = new System.Drawing.Size(79, 17);
            this.chkPrintContinuous.TabIndex = 108;
            this.chkPrintContinuous.Text = "Continuous";
            this.chkPrintContinuous.UseVisualStyleBackColor = true;
            this.chkPrintContinuous.ValidationRules = null;
            // 
            // chkCancelled
            // 
            this.chkCancelled.AutoSize = true;
            this.chkCancelled.Enabled = false;
            this.chkCancelled.FieldLabel = null;
            this.chkCancelled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCancelled.ForeColor = System.Drawing.Color.Black;
            this.chkCancelled.Location = new System.Drawing.Point(145, 25);
            this.chkCancelled.Name = "chkCancelled";
            this.chkCancelled.Size = new System.Drawing.Size(71, 17);
            this.chkCancelled.TabIndex = 108;
            this.chkCancelled.Text = "Canceled";
            this.chkCancelled.UseVisualStyleBackColor = true;
            this.chkCancelled.ValidationRules = null;
            // 
            // chkPrinted
            // 
            this.chkPrinted.AutoSize = true;
            this.chkPrinted.Enabled = false;
            this.chkPrinted.FieldLabel = null;
            this.chkPrinted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrinted.ForeColor = System.Drawing.Color.Black;
            this.chkPrinted.Location = new System.Drawing.Point(145, 5);
            this.chkPrinted.Name = "chkPrinted";
            this.chkPrinted.Size = new System.Drawing.Size(59, 17);
            this.chkPrinted.TabIndex = 108;
            this.chkPrinted.Text = "Printed";
            this.chkPrinted.UseVisualStyleBackColor = true;
            this.chkPrinted.ValidationRules = null;
            // 
            // btnSaveToExcel
            // 
            this.btnSaveToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveToExcel.Location = new System.Drawing.Point(15, 154);
            this.btnSaveToExcel.Name = "btnSaveToExcel";
            this.btnSaveToExcel.Size = new System.Drawing.Size(106, 23);
            this.btnSaveToExcel.TabIndex = 143;
            this.btnSaveToExcel.Text = "Save to Excel";
            this.btnSaveToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveToExcel.UseVisualStyleBackColor = true;
            // 
            // btnPrintStatus
            // 
            this.btnPrintStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintStatus.Location = new System.Drawing.Point(15, 131);
            this.btnPrintStatus.Name = "btnPrintStatus";
            this.btnPrintStatus.Size = new System.Drawing.Size(106, 23);
            this.btnPrintStatus.TabIndex = 143;
            this.btnPrintStatus.Text = "Print Status";
            this.btnPrintStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintStatus.UseVisualStyleBackColor = true;
            // 
            // btnPrintDelivery
            // 
            this.btnPrintDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintDelivery.Location = new System.Drawing.Point(15, 108);
            this.btnPrintDelivery.Name = "btnPrintDelivery";
            this.btnPrintDelivery.Size = new System.Drawing.Size(106, 23);
            this.btnPrintDelivery.TabIndex = 143;
            this.btnPrintDelivery.Text = "Print Delivery";
            this.btnPrintDelivery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintDelivery.UseVisualStyleBackColor = true;
            // 
            // btnPrintReceipt
            // 
            this.btnPrintReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintReceipt.Location = new System.Drawing.Point(15, 85);
            this.btnPrintReceipt.Name = "btnPrintReceipt";
            this.btnPrintReceipt.Size = new System.Drawing.Size(106, 23);
            this.btnPrintReceipt.TabIndex = 143;
            this.btnPrintReceipt.Text = "Print Receipt";
            this.btnPrintReceipt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintReceipt.UseVisualStyleBackColor = true;
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintInvoice.Location = new System.Drawing.Point(8, 9);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(104, 23);
            this.btnPrintInvoice.TabIndex = 143;
            this.btnPrintInvoice.Text = "Print Invoice";
            this.btnPrintInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintInvoice.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(19, 79);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(20, 13);
            this.label19.TabIndex = 106;
            this.label19.Text = "To";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(9, 56);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 13);
            this.label18.TabIndex = 106;
            this.label18.Text = "From";
            // 
            // btnCancelInvoice
            // 
            this.btnCancelInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelInvoice.Location = new System.Drawing.Point(15, 1);
            this.btnCancelInvoice.Name = "btnCancelInvoice";
            this.btnCancelInvoice.Size = new System.Drawing.Size(106, 35);
            this.btnCancelInvoice.TabIndex = 101;
            this.btnCancelInvoice.Text = "Cancel Invoice";
            this.btnCancelInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelInvoice.UseVisualStyleBackColor = true;
            // 
            // txtPrintInvoiceFromNo
            // 
            this.txtPrintInvoiceFromNo.EditMask = "###,###,###,###,###,##0.00";
            this.txtPrintInvoiceFromNo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPrintInvoiceFromNo.FieldLabel = null;
            this.txtPrintInvoiceFromNo.Location = new System.Drawing.Point(45, 53);
            this.txtPrintInvoiceFromNo.Name = "txtPrintInvoiceFromNo";
            this.txtPrintInvoiceFromNo.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtPrintInvoiceFromNo.Properties.AllowMouseWheel = false;
            this.txtPrintInvoiceFromNo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPrintInvoiceFromNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtPrintInvoiceFromNo.Properties.Mask.BeepOnError = true;
            this.txtPrintInvoiceFromNo.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtPrintInvoiceFromNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrintInvoiceFromNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPrintInvoiceFromNo.ReadOnly = false;
            this.txtPrintInvoiceFromNo.Size = new System.Drawing.Size(48, 20);
            this.txtPrintInvoiceFromNo.TabIndex = 107;
            this.txtPrintInvoiceFromNo.TextAlign = null;
            this.txtPrintInvoiceFromNo.ValidationRules = null;
            this.txtPrintInvoiceFromNo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btnDeleteShipment
            // 
            this.btnDeleteShipment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteShipment.Location = new System.Drawing.Point(223, 277);
            this.btnDeleteShipment.Name = "btnDeleteShipment";
            this.btnDeleteShipment.Size = new System.Drawing.Size(60, 24);
            this.btnDeleteShipment.TabIndex = 105;
            this.btnDeleteShipment.Text = "Delete";
            this.btnDeleteShipment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteShipment.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnPrintDelivery2);
            this.panel2.Controls.Add(this.btnReqFaktur);
            this.panel2.Controls.Add(this.btnFaktur);
            this.panel2.Controls.Add(this.pnlPrintInvoice);
            this.panel2.Controls.Add(this.chkCancelled);
            this.panel2.Controls.Add(this.chkIsCorporateInvoice);
            this.panel2.Controls.Add(this.chkPrinted);
            this.panel2.Controls.Add(this.btnSaveToExcel);
            this.panel2.Controls.Add(this.btnPrintStatus);
            this.panel2.Controls.Add(this.btnPrintDelivery);
            this.panel2.Controls.Add(this.btnPrintReceipt);
            this.panel2.Controls.Add(this.btnCancelInvoice);
            this.panel2.Location = new System.Drawing.Point(660, 368);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 206);
            this.panel2.TabIndex = 57;
            // 
            // btnPrintDelivery2
            // 
            this.btnPrintDelivery2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintDelivery2.Location = new System.Drawing.Point(15, 180);
            this.btnPrintDelivery2.Name = "btnPrintDelivery2";
            this.btnPrintDelivery2.Size = new System.Drawing.Size(106, 23);
            this.btnPrintDelivery2.TabIndex = 147;
            this.btnPrintDelivery2.Text = "Print SerahTerima";
            this.btnPrintDelivery2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintDelivery2.UseVisualStyleBackColor = true;
            // 
            // btnReqFaktur
            // 
            this.btnReqFaktur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReqFaktur.Location = new System.Drawing.Point(15, 39);
            this.btnReqFaktur.Name = "btnReqFaktur";
            this.btnReqFaktur.Size = new System.Drawing.Size(106, 23);
            this.btnReqFaktur.TabIndex = 146;
            this.btnReqFaktur.Text = "Request Faktur";
            this.btnReqFaktur.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReqFaktur.UseVisualStyleBackColor = true;
            // 
            // btnFaktur
            // 
            this.btnFaktur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFaktur.Location = new System.Drawing.Point(15, 62);
            this.btnFaktur.Name = "btnFaktur";
            this.btnFaktur.Size = new System.Drawing.Size(106, 23);
            this.btnFaktur.TabIndex = 145;
            this.btnFaktur.Text = "Download Faktur";
            this.btnFaktur.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFaktur.UseVisualStyleBackColor = true;
            // 
            // pnlPrintInvoice
            // 
            this.pnlPrintInvoice.BackColor = System.Drawing.Color.PeachPuff;
            this.pnlPrintInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrintInvoice.Controls.Add(this.chkPrintContinuous);
            this.pnlPrintInvoice.Controls.Add(this.btnPrintInvoice);
            this.pnlPrintInvoice.Controls.Add(this.txtPrintInvoiceFromNo);
            this.pnlPrintInvoice.Controls.Add(this.txtPrintInvoiceToNo);
            this.pnlPrintInvoice.Controls.Add(this.label18);
            this.pnlPrintInvoice.Controls.Add(this.label19);
            this.pnlPrintInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlPrintInvoice.Location = new System.Drawing.Point(130, 68);
            this.pnlPrintInvoice.Name = "pnlPrintInvoice";
            this.pnlPrintInvoice.Size = new System.Drawing.Size(120, 107);
            this.pnlPrintInvoice.TabIndex = 144;
            // 
            // chkIsCorporateInvoice
            // 
            this.chkIsCorporateInvoice.AutoSize = true;
            this.chkIsCorporateInvoice.Enabled = false;
            this.chkIsCorporateInvoice.FieldLabel = null;
            this.chkIsCorporateInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsCorporateInvoice.ForeColor = System.Drawing.Color.Black;
            this.chkIsCorporateInvoice.Location = new System.Drawing.Point(145, 45);
            this.chkIsCorporateInvoice.Name = "chkIsCorporateInvoice";
            this.chkIsCorporateInvoice.Size = new System.Drawing.Size(83, 17);
            this.chkIsCorporateInvoice.TabIndex = 106;
            this.chkIsCorporateInvoice.Text = "Perusahaan";
            this.chkIsCorporateInvoice.UseVisualStyleBackColor = true;
            this.chkIsCorporateInvoice.ValidationRules = null;
            // 
            // gridColumn36
            // 
            this.gridColumn36.Caption = "Amount";
            this.gridColumn36.FieldName = "Total";
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn36.Visible = true;
            this.gridColumn36.VisibleIndex = 1;
            this.gridColumn36.Width = 89;
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "Description";
            this.gridColumn35.FieldName = "Description";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 0;
            this.gridColumn35.Width = 195;
            // 
            // gridViewOtherFee
            // 
            this.gridViewOtherFee.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn35,
            this.gridColumn36});
            this.gridViewOtherFee.GridControl = this.gridOtherFee;
            this.gridViewOtherFee.Name = "gridViewOtherFee";
            this.gridViewOtherFee.OptionsView.ColumnAutoWidth = false;
            this.gridViewOtherFee.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridViewOtherFee.OptionsView.ShowFooter = true;
            this.gridViewOtherFee.OptionsView.ShowGroupPanel = false;
            this.gridViewOtherFee.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            // 
            // gridOtherFee
            // 
            this.gridOtherFee.Location = new System.Drawing.Point(5, 19);
            this.gridOtherFee.MainView = this.gridViewOtherFee;
            this.gridOtherFee.Name = "gridOtherFee";
            this.gridOtherFee.Size = new System.Drawing.Size(334, 181);
            this.gridOtherFee.TabIndex = 135;
            this.gridOtherFee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOtherFee});
            // 
            // btnAddOtherFee
            // 
            this.btnAddOtherFee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddOtherFee.Location = new System.Drawing.Point(10, 150);
            this.btnAddOtherFee.Name = "btnAddOtherFee";
            this.btnAddOtherFee.Size = new System.Drawing.Size(55, 21);
            this.btnAddOtherFee.TabIndex = 101;
            this.btnAddOtherFee.Text = "Add";
            this.btnAddOtherFee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddOtherFee.UseVisualStyleBackColor = true;
            // 
            // btnDeleteOtherFee
            // 
            this.btnDeleteOtherFee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteOtherFee.Location = new System.Drawing.Point(70, 150);
            this.btnDeleteOtherFee.Name = "btnDeleteOtherFee";
            this.btnDeleteOtherFee.Size = new System.Drawing.Size(65, 21);
            this.btnDeleteOtherFee.TabIndex = 101;
            this.btnDeleteOtherFee.Text = "Remove";
            this.btnDeleteOtherFee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteOtherFee.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddOtherFee);
            this.groupBox2.Controls.Add(this.btnDeleteOtherFee);
            this.groupBox2.Controls.Add(this.gridOtherFee);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(3, 368);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 206);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Other Invoice Items";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 106;
            this.label1.Text = "Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "Receipt No.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlShipmentInfo
            // 
            this.pnlShipmentInfo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlShipmentInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlShipmentInfo.Controls.Add(this.tbxRevision);
            this.pnlShipmentInfo.Controls.Add(this.lblRevision);
            this.pnlShipmentInfo.Controls.Add(this.tbxRevised);
            this.pnlShipmentInfo.Controls.Add(this.lblRevised);
            this.pnlShipmentInfo.Controls.Add(this.lkpCustomer);
            this.pnlShipmentInfo.Controls.Add(this.txtDueDate);
            this.pnlShipmentInfo.Controls.Add(this.txtDate);
            this.pnlShipmentInfo.Controls.Add(this.label35);
            this.pnlShipmentInfo.Controls.Add(this.label7);
            this.pnlShipmentInfo.Controls.Add(this.label1);
            this.pnlShipmentInfo.Controls.Add(this.label4);
            this.pnlShipmentInfo.Controls.Add(this.label2);
            this.pnlShipmentInfo.Controls.Add(this.txtDescription3);
            this.pnlShipmentInfo.Controls.Add(this.txtDescription2);
            this.pnlShipmentInfo.Controls.Add(this.txtDescription1);
            this.pnlShipmentInfo.Controls.Add(this.txtInvoicedTo);
            this.pnlShipmentInfo.Controls.Add(this.txtReceiptNo);
            this.pnlShipmentInfo.Controls.Add(this.label3);
            this.pnlShipmentInfo.Location = new System.Drawing.Point(0, 38);
            this.pnlShipmentInfo.Name = "pnlShipmentInfo";
            this.pnlShipmentInfo.Size = new System.Drawing.Size(600, 118);
            this.pnlShipmentInfo.TabIndex = 51;
            // 
            // tbxRevision
            // 
            this.tbxRevision.Capslock = true;
            this.tbxRevision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxRevision.FieldLabel = null;
            this.tbxRevision.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRevision.Location = new System.Drawing.Point(485, 92);
            this.tbxRevision.Name = "tbxRevision";
            this.tbxRevision.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxRevision.Size = new System.Drawing.Size(106, 20);
            this.tbxRevision.TabIndex = 112;
            this.tbxRevision.ValidationRules = null;
            this.tbxRevision.Visible = false;
            // 
            // lblRevision
            // 
            this.lblRevision.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevision.ForeColor = System.Drawing.Color.Black;
            this.lblRevision.Location = new System.Drawing.Point(405, 95);
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Size = new System.Drawing.Size(69, 13);
            this.lblRevision.TabIndex = 111;
            this.lblRevision.Text = "Revisi Dari";
            this.lblRevision.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRevision.Visible = false;
            // 
            // tbxRevised
            // 
            this.tbxRevised.Capslock = true;
            this.tbxRevised.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxRevised.FieldLabel = null;
            this.tbxRevised.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRevised.Location = new System.Drawing.Point(291, 91);
            this.tbxRevised.Name = "tbxRevised";
            this.tbxRevised.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxRevised.Size = new System.Drawing.Size(106, 20);
            this.tbxRevised.TabIndex = 110;
            this.tbxRevised.ValidationRules = null;
            this.tbxRevised.Visible = false;
            // 
            // lblRevised
            // 
            this.lblRevised.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevised.ForeColor = System.Drawing.Color.Black;
            this.lblRevised.Location = new System.Drawing.Point(216, 94);
            this.lblRevised.Name = "lblRevised";
            this.lblRevised.Size = new System.Drawing.Size(69, 13);
            this.lblRevised.TabIndex = 109;
            this.lblRevised.Text = "Direvisi Ke";
            this.lblRevised.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRevised.Visible = false;
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
            this.lkpCustomer.Location = new System.Drawing.Point(79, 47);
            this.lkpCustomer.LookupPopup = null;
            this.lkpCustomer.Name = "lkpCustomer";
            this.lkpCustomer.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpCustomer.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkpCustomer.Properties.Appearance.Options.UseFont = true;
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpCustomer.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpCustomer.Properties.LookupPopup = null;
            this.lkpCustomer.Properties.NullText = "<<Choose...>>";
            this.lkpCustomer.Size = new System.Drawing.Size(206, 20);
            this.lkpCustomer.TabIndex = 103;
            this.lkpCustomer.ValidationRules = null;
            this.lkpCustomer.Value = null;
            // 
            // txtDueDate
            // 
            this.txtDueDate.EditValue = null;
            this.txtDueDate.FieldLabel = null;
            this.txtDueDate.FormatDateTime = "dd-MM-yyyy";
            this.txtDueDate.Location = new System.Drawing.Point(78, 91);
            this.txtDueDate.Name = "txtDueDate";
            this.txtDueDate.Nullable = false;
            this.txtDueDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDueDate.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDueDate.Properties.Appearance.Options.UseFont = true;
            this.txtDueDate.Properties.AutoHeight = false;
            this.txtDueDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtDueDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.txtDueDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDueDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtDueDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDueDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtDueDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDueDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtDueDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtDueDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDueDate.Size = new System.Drawing.Size(101, 20);
            this.txtDueDate.TabIndex = 105;
            this.txtDueDate.ValidationRules = null;
            this.txtDueDate.Value = new System.DateTime(((long)(0)));
            // 
            // txtDate
            // 
            this.txtDate.EditValue = null;
            this.txtDate.FieldLabel = null;
            this.txtDate.FormatDateTime = "dd-MM-yyyy";
            this.txtDate.Location = new System.Drawing.Point(78, 3);
            this.txtDate.Name = "txtDate";
            this.txtDate.Nullable = false;
            this.txtDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDate.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Properties.Appearance.Options.UseFont = true;
            this.txtDate.Properties.AutoHeight = false;
            this.txtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.txtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDate.Size = new System.Drawing.Size(101, 20);
            this.txtDate.TabIndex = 101;
            this.txtDate.ValidationRules = null;
            this.txtDate.Value = new System.DateTime(((long)(0)));
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(288, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 106;
            this.label7.Text = "Description";
            // 
            // txtDescription3
            // 
            this.txtDescription3.Capslock = true;
            this.txtDescription3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription3.FieldLabel = null;
            this.txtDescription3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription3.Location = new System.Drawing.Point(291, 69);
            this.txtDescription3.Name = "txtDescription3";
            this.txtDescription3.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDescription3.Size = new System.Drawing.Size(300, 20);
            this.txtDescription3.TabIndex = 108;
            this.txtDescription3.ValidationRules = null;
            // 
            // txtDescription2
            // 
            this.txtDescription2.Capslock = true;
            this.txtDescription2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription2.FieldLabel = null;
            this.txtDescription2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription2.Location = new System.Drawing.Point(291, 47);
            this.txtDescription2.Name = "txtDescription2";
            this.txtDescription2.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDescription2.Size = new System.Drawing.Size(300, 20);
            this.txtDescription2.TabIndex = 107;
            this.txtDescription2.ValidationRules = null;
            // 
            // txtDescription1
            // 
            this.txtDescription1.Capslock = true;
            this.txtDescription1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription1.FieldLabel = null;
            this.txtDescription1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription1.Location = new System.Drawing.Point(291, 25);
            this.txtDescription1.Name = "txtDescription1";
            this.txtDescription1.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDescription1.Size = new System.Drawing.Size(300, 20);
            this.txtDescription1.TabIndex = 106;
            this.txtDescription1.ValidationRules = null;
            // 
            // txtInvoicedTo
            // 
            this.txtInvoicedTo.Capslock = true;
            this.txtInvoicedTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInvoicedTo.FieldLabel = null;
            this.txtInvoicedTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoicedTo.Location = new System.Drawing.Point(78, 69);
            this.txtInvoicedTo.Name = "txtInvoicedTo";
            this.txtInvoicedTo.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtInvoicedTo.Size = new System.Drawing.Size(207, 20);
            this.txtInvoicedTo.TabIndex = 104;
            this.txtInvoicedTo.ValidationRules = null;
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Capslock = true;
            this.txtReceiptNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReceiptNo.FieldLabel = null;
            this.txtReceiptNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiptNo.Location = new System.Drawing.Point(78, 25);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtReceiptNo.Size = new System.Drawing.Size(207, 20);
            this.txtReceiptNo.TabIndex = 102;
            this.txtReceiptNo.ValidationRules = null;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 106;
            this.label3.Text = "Customer";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.EditMask = "###,###,###,###,###,##0.00";
            this.txtGrandTotal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtGrandTotal.FieldLabel = null;
            this.txtGrandTotal.Location = new System.Drawing.Point(173, 155);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtGrandTotal.Properties.AllowMouseWheel = false;
            this.txtGrandTotal.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrandTotal.Properties.Appearance.Options.UseFont = true;
            this.txtGrandTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.txtGrandTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtGrandTotal.Properties.Mask.BeepOnError = true;
            this.txtGrandTotal.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtGrandTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGrandTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtGrandTotal.ReadOnly = false;
            this.txtGrandTotal.Size = new System.Drawing.Size(132, 20);
            this.txtGrandTotal.TabIndex = 110;
            this.txtGrandTotal.TextAlign = null;
            this.txtGrandTotal.ValidationRules = null;
            this.txtGrandTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // pnlTotalAndAction
            // 
            this.pnlTotalAndAction.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTotalAndAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTotalAndAction.Controls.Add(this.cmbTaxType);
            this.pnlTotalAndAction.Controls.Add(this.txtGrandTotal);
            this.pnlTotalAndAction.Controls.Add(this.label15);
            this.pnlTotalAndAction.Controls.Add(this.label8);
            this.pnlTotalAndAction.Controls.Add(this.label13);
            this.pnlTotalAndAction.Controls.Add(this.label17);
            this.pnlTotalAndAction.Controls.Add(this.label12);
            this.pnlTotalAndAction.Controls.Add(this.label11);
            this.pnlTotalAndAction.Controls.Add(this.label10);
            this.pnlTotalAndAction.Controls.Add(this.txtRaFeePerPiece);
            this.pnlTotalAndAction.Controls.Add(this.label16);
            this.pnlTotalAndAction.Controls.Add(this.label14);
            this.pnlTotalAndAction.Controls.Add(this.txtRaCwTotal);
            this.pnlTotalAndAction.Controls.Add(this.label9);
            this.pnlTotalAndAction.Controls.Add(this.txtTaxTotal);
            this.pnlTotalAndAction.Controls.Add(this.txtBeforeTax);
            this.pnlTotalAndAction.Controls.Add(this.txtCurrencyRate);
            this.pnlTotalAndAction.Controls.Add(this.txtDiscountPercent);
            this.pnlTotalAndAction.Controls.Add(this.txtTotalDiscountTotal);
            this.pnlTotalAndAction.Controls.Add(this.txtMateraiFee);
            this.pnlTotalAndAction.Controls.Add(this.txtTotalRaFee);
            this.pnlTotalAndAction.Location = new System.Drawing.Point(345, 368);
            this.pnlTotalAndAction.Name = "pnlTotalAndAction";
            this.pnlTotalAndAction.Size = new System.Drawing.Size(316, 206);
            this.pnlTotalAndAction.TabIndex = 56;
            // 
            // cmbTaxType
            // 
            this.cmbTaxType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTaxType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaxType.FieldLabel = null;
            this.cmbTaxType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbTaxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTaxType.FormattingEnabled = true;
            this.cmbTaxType.Location = new System.Drawing.Point(65, 107);
            this.cmbTaxType.Name = "cmbTaxType";
            this.cmbTaxType.Size = new System.Drawing.Size(102, 21);
            this.cmbTaxType.TabIndex = 108;
            this.cmbTaxType.ValidationRules = null;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(111, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 13);
            this.label15.TabIndex = 106;
            this.label15.Text = "Before Tax";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(93, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 106;
            this.label8.Text = "Grand Total";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(111, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 106;
            this.label13.Text = "Currency Rate";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(34, 109);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 13);
            this.label17.TabIndex = 106;
            this.label17.Text = "Tax";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(78, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 106;
            this.label12.Text = "Discount";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(111, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 106;
            this.label11.Text = "Materai";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(7, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 106;
            this.label10.Text = "RA Fee";
            // 
            // txtRaFeePerPiece
            // 
            this.txtRaFeePerPiece.EditMask = "###,###,###,###,###,##0.00";
            this.txtRaFeePerPiece.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtRaFeePerPiece.FieldLabel = null;
            this.txtRaFeePerPiece.Location = new System.Drawing.Point(114, 2);
            this.txtRaFeePerPiece.Name = "txtRaFeePerPiece";
            this.txtRaFeePerPiece.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtRaFeePerPiece.Properties.AllowMouseWheel = false;
            this.txtRaFeePerPiece.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRaFeePerPiece.Properties.Appearance.Options.UseFont = true;
            this.txtRaFeePerPiece.Properties.Appearance.Options.UseTextOptions = true;
            this.txtRaFeePerPiece.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtRaFeePerPiece.Properties.Mask.BeepOnError = true;
            this.txtRaFeePerPiece.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtRaFeePerPiece.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtRaFeePerPiece.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtRaFeePerPiece.ReadOnly = false;
            this.txtRaFeePerPiece.Size = new System.Drawing.Size(60, 20);
            this.txtRaFeePerPiece.TabIndex = 102;
            this.txtRaFeePerPiece.TextAlign = null;
            this.txtRaFeePerPiece.ValidationRules = null;
            this.txtRaFeePerPiece.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(173, 109);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(13, 13);
            this.label16.TabIndex = 106;
            this.label16.Text = "=";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(178, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(13, 13);
            this.label14.TabIndex = 106;
            this.label14.Text = "=";
            // 
            // txtRaCwTotal
            // 
            this.txtRaCwTotal.EditMask = "###,###,###,###,###,##0.00";
            this.txtRaCwTotal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtRaCwTotal.Enabled = false;
            this.txtRaCwTotal.FieldLabel = null;
            this.txtRaCwTotal.Location = new System.Drawing.Point(56, 2);
            this.txtRaCwTotal.Name = "txtRaCwTotal";
            this.txtRaCwTotal.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtRaCwTotal.Properties.AllowMouseWheel = false;
            this.txtRaCwTotal.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRaCwTotal.Properties.Appearance.Options.UseFont = true;
            this.txtRaCwTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.txtRaCwTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtRaCwTotal.Properties.Mask.BeepOnError = true;
            this.txtRaCwTotal.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtRaCwTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtRaCwTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtRaCwTotal.ReadOnly = false;
            this.txtRaCwTotal.Size = new System.Drawing.Size(42, 20);
            this.txtRaCwTotal.TabIndex = 101;
            this.txtRaCwTotal.TextAlign = null;
            this.txtRaCwTotal.ValidationRules = null;
            this.txtRaCwTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(100, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 13);
            this.label9.TabIndex = 106;
            this.label9.Text = "x";
            // 
            // txtTaxTotal
            // 
            this.txtTaxTotal.EditMask = "###,###,###,###,###,##0.00";
            this.txtTaxTotal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTaxTotal.FieldLabel = null;
            this.txtTaxTotal.Location = new System.Drawing.Point(192, 106);
            this.txtTaxTotal.Name = "txtTaxTotal";
            this.txtTaxTotal.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtTaxTotal.Properties.AllowMouseWheel = false;
            this.txtTaxTotal.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaxTotal.Properties.Appearance.Options.UseFont = true;
            this.txtTaxTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTaxTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTaxTotal.Properties.Mask.BeepOnError = true;
            this.txtTaxTotal.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtTaxTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTaxTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTaxTotal.ReadOnly = false;
            this.txtTaxTotal.Size = new System.Drawing.Size(113, 20);
            this.txtTaxTotal.TabIndex = 109;
            this.txtTaxTotal.TextAlign = null;
            this.txtTaxTotal.ValidationRules = null;
            this.txtTaxTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtBeforeTax
            // 
            this.txtBeforeTax.EditMask = "###,###,###,###,###,##0.00";
            this.txtBeforeTax.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtBeforeTax.FieldLabel = null;
            this.txtBeforeTax.Location = new System.Drawing.Point(192, 82);
            this.txtBeforeTax.Name = "txtBeforeTax";
            this.txtBeforeTax.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtBeforeTax.Properties.AllowMouseWheel = false;
            this.txtBeforeTax.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBeforeTax.Properties.Appearance.Options.UseFont = true;
            this.txtBeforeTax.Properties.Appearance.Options.UseTextOptions = true;
            this.txtBeforeTax.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtBeforeTax.Properties.Mask.BeepOnError = true;
            this.txtBeforeTax.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtBeforeTax.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtBeforeTax.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtBeforeTax.ReadOnly = false;
            this.txtBeforeTax.Size = new System.Drawing.Size(113, 20);
            this.txtBeforeTax.TabIndex = 107;
            this.txtBeforeTax.TextAlign = null;
            this.txtBeforeTax.ValidationRules = null;
            this.txtBeforeTax.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtCurrencyRate
            // 
            this.txtCurrencyRate.EditMask = "###,###,###,###,###,##0.00";
            this.txtCurrencyRate.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCurrencyRate.FieldLabel = null;
            this.txtCurrencyRate.Location = new System.Drawing.Point(192, 48);
            this.txtCurrencyRate.Name = "txtCurrencyRate";
            this.txtCurrencyRate.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtCurrencyRate.Properties.AllowMouseWheel = false;
            this.txtCurrencyRate.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrencyRate.Properties.Appearance.Options.UseFont = true;
            this.txtCurrencyRate.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCurrencyRate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtCurrencyRate.Properties.Mask.BeepOnError = true;
            this.txtCurrencyRate.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtCurrencyRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCurrencyRate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtCurrencyRate.ReadOnly = false;
            this.txtCurrencyRate.Size = new System.Drawing.Size(113, 20);
            this.txtCurrencyRate.TabIndex = 106;
            this.txtCurrencyRate.TextAlign = null;
            this.txtCurrencyRate.ValidationRules = null;
            this.txtCurrencyRate.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtDiscountPercent
            // 
            this.txtDiscountPercent.EditMask = "###,###,###,###,###,##0.00";
            this.txtDiscountPercent.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDiscountPercent.FieldLabel = null;
            this.txtDiscountPercent.Location = new System.Drawing.Point(130, 25);
            this.txtDiscountPercent.Name = "txtDiscountPercent";
            this.txtDiscountPercent.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDiscountPercent.Properties.AllowMouseWheel = false;
            this.txtDiscountPercent.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountPercent.Properties.Appearance.Options.UseFont = true;
            this.txtDiscountPercent.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDiscountPercent.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtDiscountPercent.Properties.Mask.BeepOnError = true;
            this.txtDiscountPercent.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtDiscountPercent.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDiscountPercent.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDiscountPercent.ReadOnly = false;
            this.txtDiscountPercent.Size = new System.Drawing.Size(56, 20);
            this.txtDiscountPercent.TabIndex = 105;
            this.txtDiscountPercent.TabStop = false;
            this.txtDiscountPercent.TextAlign = null;
            this.txtDiscountPercent.ValidationRules = null;
            this.txtDiscountPercent.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtTotalDiscountTotal
            // 
            this.txtTotalDiscountTotal.EditMask = "###,###,###,###,###,##0.00";
            this.txtTotalDiscountTotal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalDiscountTotal.FieldLabel = null;
            this.txtTotalDiscountTotal.Location = new System.Drawing.Point(192, 25);
            this.txtTotalDiscountTotal.Name = "txtTotalDiscountTotal";
            this.txtTotalDiscountTotal.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtTotalDiscountTotal.Properties.AllowMouseWheel = false;
            this.txtTotalDiscountTotal.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDiscountTotal.Properties.Appearance.Options.UseFont = true;
            this.txtTotalDiscountTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalDiscountTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalDiscountTotal.Properties.Mask.BeepOnError = true;
            this.txtTotalDiscountTotal.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtTotalDiscountTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalDiscountTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalDiscountTotal.ReadOnly = false;
            this.txtTotalDiscountTotal.Size = new System.Drawing.Size(113, 20);
            this.txtTotalDiscountTotal.TabIndex = 105;
            this.txtTotalDiscountTotal.TextAlign = null;
            this.txtTotalDiscountTotal.ValidationRules = null;
            this.txtTotalDiscountTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtMateraiFee
            // 
            this.txtMateraiFee.EditMask = "###,###,###,###,###,##0.00";
            this.txtMateraiFee.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMateraiFee.FieldLabel = null;
            this.txtMateraiFee.Location = new System.Drawing.Point(192, 130);
            this.txtMateraiFee.Name = "txtMateraiFee";
            this.txtMateraiFee.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtMateraiFee.Properties.AllowMouseWheel = false;
            this.txtMateraiFee.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMateraiFee.Properties.Appearance.Options.UseFont = true;
            this.txtMateraiFee.Properties.Appearance.Options.UseTextOptions = true;
            this.txtMateraiFee.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtMateraiFee.Properties.Mask.BeepOnError = true;
            this.txtMateraiFee.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtMateraiFee.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMateraiFee.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMateraiFee.ReadOnly = false;
            this.txtMateraiFee.Size = new System.Drawing.Size(113, 20);
            this.txtMateraiFee.TabIndex = 104;
            this.txtMateraiFee.TextAlign = null;
            this.txtMateraiFee.ValidationRules = null;
            this.txtMateraiFee.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtTotalRaFee
            // 
            this.txtTotalRaFee.EditMask = "###,###,###,###,###,##0.00";
            this.txtTotalRaFee.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalRaFee.FieldLabel = null;
            this.txtTotalRaFee.Location = new System.Drawing.Point(192, 2);
            this.txtTotalRaFee.Name = "txtTotalRaFee";
            this.txtTotalRaFee.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtTotalRaFee.Properties.AllowMouseWheel = false;
            this.txtTotalRaFee.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRaFee.Properties.Appearance.Options.UseFont = true;
            this.txtTotalRaFee.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalRaFee.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalRaFee.Properties.Mask.BeepOnError = true;
            this.txtTotalRaFee.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtTotalRaFee.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalRaFee.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalRaFee.ReadOnly = false;
            this.txtTotalRaFee.Size = new System.Drawing.Size(113, 20);
            this.txtTotalRaFee.TabIndex = 103;
            this.txtTotalRaFee.TextAlign = null;
            this.txtTotalRaFee.ValidationRules = null;
            this.txtTotalRaFee.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtFilterDateFrom
            // 
            this.txtFilterDateFrom.Capslock = true;
            this.txtFilterDateFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFilterDateFrom.FieldLabel = null;
            this.txtFilterDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterDateFrom.Location = new System.Drawing.Point(127, 25);
            this.txtFilterDateFrom.Name = "txtFilterDateFrom";
            this.txtFilterDateFrom.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtFilterDateFrom.Size = new System.Drawing.Size(108, 20);
            this.txtFilterDateFrom.TabIndex = 104;
            this.txtFilterDateFrom.ValidationRules = null;
            // 
            // txtPeriod
            // 
            this.txtPeriod.Capslock = true;
            this.txtPeriod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPeriod.FieldLabel = null;
            this.txtPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriod.Location = new System.Drawing.Point(127, 2);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtPeriod.Size = new System.Drawing.Size(108, 20);
            this.txtPeriod.TabIndex = 103;
            this.txtPeriod.ValidationRules = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(3, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 106;
            this.label5.Text = "Customer Type";
            // 
            // txtFilterDateTo
            // 
            this.txtFilterDateTo.Capslock = true;
            this.txtFilterDateTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFilterDateTo.FieldLabel = null;
            this.txtFilterDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterDateTo.Location = new System.Drawing.Point(127, 48);
            this.txtFilterDateTo.Name = "txtFilterDateTo";
            this.txtFilterDateTo.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtFilterDateTo.Size = new System.Drawing.Size(108, 20);
            this.txtFilterDateTo.TabIndex = 105;
            this.txtFilterDateTo.ValidationRules = null;
            // 
            // btnGetData
            // 
            this.btnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.Location = new System.Drawing.Point(244, 7);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(71, 50);
            this.btnGetData.TabIndex = 102;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.Color.Black;
            this.label38.Location = new System.Drawing.Point(2, 4);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(103, 13);
            this.label38.TabIndex = 109;
            this.label38.Text = "Shipment Search";
            // 
            // txtFilterDestinationCity
            // 
            this.txtFilterDestinationCity.Capslock = true;
            this.txtFilterDestinationCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFilterDestinationCity.FieldLabel = null;
            this.txtFilterDestinationCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterDestinationCity.Location = new System.Drawing.Point(127, 71);
            this.txtFilterDestinationCity.Name = "txtFilterDestinationCity";
            this.txtFilterDestinationCity.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtFilterDestinationCity.Size = new System.Drawing.Size(108, 20);
            this.txtFilterDestinationCity.TabIndex = 106;
            this.txtFilterDestinationCity.ValidationRules = null;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCoral;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmbTaxInvoice);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.cmbFilterCustomerType);
            this.panel1.Controls.Add(this.btnAddShipment);
            this.panel1.Controls.Add(this.btnGetData);
            this.panel1.Controls.Add(this.label38);
            this.panel1.Controls.Add(this.txtAddShipmentNo);
            this.panel1.Controls.Add(this.txtFilterDestinationCity);
            this.panel1.Controls.Add(this.txtFilterDateTo);
            this.panel1.Controls.Add(this.txtFilterDateFrom);
            this.panel1.Controls.Add(this.txtPeriod);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(601, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 118);
            this.panel1.TabIndex = 52;
            // 
            // cmbTaxInvoice
            // 
            this.cmbTaxInvoice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTaxInvoice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTaxInvoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaxInvoice.FieldLabel = null;
            this.cmbTaxInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbTaxInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTaxInvoice.FormattingEnabled = true;
            this.cmbTaxInvoice.Location = new System.Drawing.Point(8, 84);
            this.cmbTaxInvoice.Name = "cmbTaxInvoice";
            this.cmbTaxInvoice.Size = new System.Drawing.Size(110, 21);
            this.cmbTaxInvoice.TabIndex = 110;
            this.cmbTaxInvoice.ValidationRules = null;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(5, 67);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(67, 13);
            this.label20.TabIndex = 111;
            this.label20.Text = "Faktur Pajak";
            // 
            // cmbFilterCustomerType
            // 
            this.cmbFilterCustomerType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFilterCustomerType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFilterCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterCustomerType.FieldLabel = null;
            this.cmbFilterCustomerType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbFilterCustomerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterCustomerType.FormattingEnabled = true;
            this.cmbFilterCustomerType.Location = new System.Drawing.Point(6, 41);
            this.cmbFilterCustomerType.Name = "cmbFilterCustomerType";
            this.cmbFilterCustomerType.Size = new System.Drawing.Size(110, 21);
            this.cmbFilterCustomerType.TabIndex = 101;
            this.cmbFilterCustomerType.ValidationRules = null;
            // 
            // btnAddShipment
            // 
            this.btnAddShipment.Location = new System.Drawing.Point(260, 90);
            this.btnAddShipment.Name = "btnAddShipment";
            this.btnAddShipment.Size = new System.Drawing.Size(55, 23);
            this.btnAddShipment.TabIndex = 102;
            this.btnAddShipment.Text = "Insert";
            this.btnAddShipment.UseVisualStyleBackColor = true;
            // 
            // txtAddShipmentNo
            // 
            this.txtAddShipmentNo.Capslock = true;
            this.txtAddShipmentNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddShipmentNo.FieldLabel = null;
            this.txtAddShipmentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddShipmentNo.Location = new System.Drawing.Point(127, 92);
            this.txtAddShipmentNo.Name = "txtAddShipmentNo";
            this.txtAddShipmentNo.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtAddShipmentNo.Size = new System.Drawing.Size(127, 20);
            this.txtAddShipmentNo.TabIndex = 101;
            this.txtAddShipmentNo.ValidationRules = null;
            // 
            // txtTotalSales
            // 
            this.txtTotalSales.EditMask = "###,###,###,###,###,##0.00";
            this.txtTotalSales.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalSales.FieldLabel = null;
            this.txtTotalSales.Location = new System.Drawing.Point(778, 9);
            this.txtTotalSales.Name = "txtTotalSales";
            this.txtTotalSales.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtTotalSales.Properties.AllowMouseWheel = false;
            this.txtTotalSales.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSales.Properties.Appearance.Options.UseFont = true;
            this.txtTotalSales.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalSales.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalSales.Properties.Mask.BeepOnError = true;
            this.txtTotalSales.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtTotalSales.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalSales.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalSales.ReadOnly = false;
            this.txtTotalSales.Size = new System.Drawing.Size(132, 20);
            this.txtTotalSales.TabIndex = 106;
            this.txtTotalSales.TextAlign = null;
            this.txtTotalSales.ValidationRules = null;
            this.txtTotalSales.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtTotalInternational
            // 
            this.txtTotalInternational.EditMask = "###,###,###,###,###,##0.00";
            this.txtTotalInternational.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalInternational.FieldLabel = null;
            this.txtTotalInternational.Location = new System.Drawing.Point(517, 16);
            this.txtTotalInternational.Name = "txtTotalInternational";
            this.txtTotalInternational.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtTotalInternational.Properties.AllowMouseWheel = false;
            this.txtTotalInternational.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalInternational.Properties.Appearance.Options.UseFont = true;
            this.txtTotalInternational.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalInternational.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalInternational.Properties.Mask.BeepOnError = true;
            this.txtTotalInternational.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtTotalInternational.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalInternational.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalInternational.ReadOnly = false;
            this.txtTotalInternational.Size = new System.Drawing.Size(118, 20);
            this.txtTotalInternational.TabIndex = 105;
            this.txtTotalInternational.TextAlign = null;
            this.txtTotalInternational.ValidationRules = null;
            this.txtTotalInternational.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(390, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(60, 13);
            this.label32.TabIndex = 106;
            this.label32.Text = "City Courier";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(514, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(65, 13);
            this.label33.TabIndex = 106;
            this.label33.Text = "International";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(263, 2);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(51, 13);
            this.label31.TabIndex = 106;
            this.label31.Text = "Domestic";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(701, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 106;
            this.label6.Text = "Total Sales";
            // 
            // txtTotalCityCourier
            // 
            this.txtTotalCityCourier.EditMask = "###,###,###,###,###,##0.00";
            this.txtTotalCityCourier.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalCityCourier.FieldLabel = null;
            this.txtTotalCityCourier.Location = new System.Drawing.Point(393, 16);
            this.txtTotalCityCourier.Name = "txtTotalCityCourier";
            this.txtTotalCityCourier.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtTotalCityCourier.Properties.AllowMouseWheel = false;
            this.txtTotalCityCourier.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCityCourier.Properties.Appearance.Options.UseFont = true;
            this.txtTotalCityCourier.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalCityCourier.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalCityCourier.Properties.Mask.BeepOnError = true;
            this.txtTotalCityCourier.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtTotalCityCourier.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalCityCourier.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalCityCourier.ReadOnly = false;
            this.txtTotalCityCourier.Size = new System.Drawing.Size(118, 20);
            this.txtTotalCityCourier.TabIndex = 104;
            this.txtTotalCityCourier.TextAlign = null;
            this.txtTotalCityCourier.ValidationRules = null;
            this.txtTotalCityCourier.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label32);
            this.panel5.Controls.Add(this.label33);
            this.panel5.Controls.Add(this.label31);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.txtTotalSales);
            this.panel5.Controls.Add(this.txtTotalInternational);
            this.panel5.Controls.Add(this.txtTotalCityCourier);
            this.panel5.Controls.Add(this.txtTotalDomestic);
            this.panel5.Location = new System.Drawing.Point(0, 324);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(921, 43);
            this.panel5.TabIndex = 54;
            // 
            // txtTotalDomestic
            // 
            this.txtTotalDomestic.EditMask = "###,###,###,###,###,##0.00";
            this.txtTotalDomestic.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalDomestic.FieldLabel = null;
            this.txtTotalDomestic.Location = new System.Drawing.Point(266, 16);
            this.txtTotalDomestic.Name = "txtTotalDomestic";
            this.txtTotalDomestic.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtTotalDomestic.Properties.AllowMouseWheel = false;
            this.txtTotalDomestic.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDomestic.Properties.Appearance.Options.UseFont = true;
            this.txtTotalDomestic.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalDomestic.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalDomestic.Properties.Mask.BeepOnError = true;
            this.txtTotalDomestic.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtTotalDomestic.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalDomestic.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalDomestic.ReadOnly = false;
            this.txtTotalDomestic.Size = new System.Drawing.Size(118, 20);
            this.txtTotalDomestic.TabIndex = 103;
            this.txtTotalDomestic.TextAlign = null;
            this.txtTotalDomestic.ValidationRules = null;
            this.txtTotalDomestic.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(9, 282);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(93, 13);
            this.label21.TabIndex = 113;
            this.label21.Text = "Pindah Ke Baris :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxNumber
            // 
            this.tbxNumber.Capslock = true;
            this.tbxNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxNumber.FieldLabel = null;
            this.tbxNumber.Location = new System.Drawing.Point(108, 277);
            this.tbxNumber.Name = "tbxNumber";
            this.tbxNumber.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxNumber.Size = new System.Drawing.Size(39, 24);
            this.tbxNumber.TabIndex = 116;
            this.tbxNumber.ValidationRules = null;
            // 
            // btnRelocation
            // 
            this.btnRelocation.Location = new System.Drawing.Point(149, 277);
            this.btnRelocation.Name = "btnRelocation";
            this.btnRelocation.Size = new System.Drawing.Size(27, 24);
            this.btnRelocation.TabIndex = 117;
            this.btnRelocation.Text = "Ok";
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "gridColumn19";
            this.gridColumn19.FieldName = "Scanned";
            this.gridColumn19.Name = "gridColumn19";
            // 
            // CreateSalesInvoiceByScanForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(921, 577);
            this.Controls.Add(this.btnRelocation);
            this.Controls.Add(this.tbxNumber);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnDeleteShipment);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pnlShipmentInfo);
            this.Controls.Add(this.pnlTotalAndAction);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Name = "CreateSalesInvoiceByScanForm";
            this.Text = "Create Sales Invoice By Scan";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.panel5, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            this.Controls.SetChildIndex(this.pnlTotalAndAction, 0);
            this.Controls.SetChildIndex(this.pnlShipmentInfo, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.btnDeleteShipment, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.tbxNumber, 0);
            this.Controls.SetChildIndex(this.btnRelocation, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrintInvoiceToNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrintInvoiceFromNo.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlPrintInvoice.ResumeLayout(false);
            this.pnlPrintInvoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOtherFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOtherFee)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.pnlShipmentInfo.ResumeLayout(false);
            this.pnlShipmentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDueDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDueDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrandTotal.Properties)).EndInit();
            this.pnlTotalAndAction.ResumeLayout(false);
            this.pnlTotalAndAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRaFeePerPiece.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRaCwTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeforeTax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrencyRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountPercent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDiscountTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMateraiFee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalRaFee.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalSales.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalInternational.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCityCourier.Properties)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDomestic.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.GridControl grid;
        private SISCO.Presentation.Common.Component.dTextBoxNumber txtPrintInvoiceToNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label35;
        private dCheckBox chkPrintContinuous;
        private dCheckBox chkCancelled;
        private dCheckBox chkPrinted;
        private System.Windows.Forms.Button btnSaveToExcel;
        private System.Windows.Forms.Button btnPrintStatus;
        private System.Windows.Forms.Button btnPrintDelivery;
        private System.Windows.Forms.Button btnPrintReceipt;
        private System.Windows.Forms.Button btnPrintInvoice;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnCancelInvoice;
        private SISCO.Presentation.Common.Component.dTextBoxNumber txtPrintInvoiceFromNo;
        private System.Windows.Forms.Button btnDeleteShipment;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOtherFee;
        private DevExpress.XtraGrid.GridControl gridOtherFee;
        private System.Windows.Forms.Button btnAddOtherFee;
        private System.Windows.Forms.Button btnDeleteOtherFee;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlShipmentInfo;
        private SISCO.Presentation.Common.Component.dTextBox txtDescription3;
        private SISCO.Presentation.Common.Component.dTextBox txtDescription2;
        private SISCO.Presentation.Common.Component.dTextBox txtDescription1;
        private SISCO.Presentation.Common.Component.dTextBox txtInvoicedTo;
        private SISCO.Presentation.Common.Component.dTextBox txtReceiptNo;
        private System.Windows.Forms.Label label3;
        private SISCO.Presentation.Common.Component.dTextBoxNumber txtGrandTotal;
        private System.Windows.Forms.Panel pnlTotalAndAction;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private SISCO.Presentation.Common.Component.dTextBoxNumber txtRaFeePerPiece;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private SISCO.Presentation.Common.Component.dTextBoxNumber txtRaCwTotal;
        private System.Windows.Forms.Label label9;
        private SISCO.Presentation.Common.Component.dTextBoxNumber txtTaxTotal;
        private SISCO.Presentation.Common.Component.dTextBoxNumber txtBeforeTax;
        private SISCO.Presentation.Common.Component.dTextBoxNumber txtCurrencyRate;
        private SISCO.Presentation.Common.Component.dTextBoxNumber txtTotalDiscountTotal;
        private SISCO.Presentation.Common.Component.dTextBoxNumber txtMateraiFee;
        private SISCO.Presentation.Common.Component.dTextBoxNumber txtTotalRaFee;
        private SISCO.Presentation.Common.Component.dTextBox txtFilterDateFrom;
        private SISCO.Presentation.Common.Component.dTextBox txtPeriod;
        private System.Windows.Forms.Label label5;
        private SISCO.Presentation.Common.Component.dTextBox txtFilterDateTo;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Label label38;
        private SISCO.Presentation.Common.Component.dTextBox txtFilterDestinationCity;
        private System.Windows.Forms.Panel panel1;
        private SISCO.Presentation.Common.Component.dTextBoxNumber txtTotalSales;
        private SISCO.Presentation.Common.Component.dTextBox txtAddShipmentNo;
        private SISCO.Presentation.Common.Component.dTextBoxNumber txtTotalInternational;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Button btnAddShipment;
        private System.Windows.Forms.Label label6;
        private SISCO.Presentation.Common.Component.dTextBoxNumber txtTotalCityCourier;
        private System.Windows.Forms.Panel panel5;
        private SISCO.Presentation.Common.Component.dTextBoxNumber txtTotalDomestic;
        private Common.Component.dLookup lkpCustomer;
        private Common.Component.dCalendar txtDueDate;
        private Common.Component.dCalendar txtDate;
        private dCheckBox chkIsCorporateInvoice;
        private dComboBox cmbTaxType;
        private System.Windows.Forms.Panel pnlPrintInvoice;
        private System.Windows.Forms.Label label7;
        private Common.Component.dComboBox cmbFilterCustomerType;
        private dTextBoxNumber txtDiscountPercent;
        private dTextBox tbxRevised;
        private Label lblRevised;
        private Button btnFaktur;
        private dTextBox tbxRevision;
        private Label lblRevision;
        private dComboBox cmbTaxInvoice;
        private Label label20;
        private Button btnReqFaktur;
        private Button btnPrintDelivery2;
        private Label label21;
        private dTextBox tbxNumber;
        private DevExpress.XtraEditors.SimpleButton btnRelocation;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        
    }
}

