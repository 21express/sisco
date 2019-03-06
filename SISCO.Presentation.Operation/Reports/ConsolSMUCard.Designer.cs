namespace SISCO.Presentation.Operation.Reports
{
    partial class ConsolSMUCard
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCust6 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCust5 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCust4 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCust3 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCust2 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCust1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBarCode1 = new DevExpress.XtraReports.UI.XRBarCode();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.bindingSource1 = new System.Windows.Forms.BindingSource();
            this.bindingSource2 = new System.Windows.Forms.BindingSource();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPanel1});
            this.Detail.Font = new System.Drawing.Font("Mangal", 9.75F);
            this.Detail.HeightF = 241.4583F;
            this.Detail.MultiColumn.ColumnSpacing = 13F;
            this.Detail.MultiColumn.ColumnWidth = 390F;
            this.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnWidth;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StylePriority.UseFont = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPanel1
            // 
            this.xrPanel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrPanel1.CanGrow = false;
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.lblCust6,
            this.lblCust5,
            this.lblCust4,
            this.lblCust3,
            this.lblCust2,
            this.lblCust1,
            this.xrLabel13,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3,
            this.xrBarCode1,
            this.xrLabel11});
            this.xrPanel1.KeepTogether = false;
            this.xrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(4.000001F, 2F);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.SizeF = new System.Drawing.SizeF(375.5F, 226.9583F);
            this.xrPanel1.StylePriority.UseBorders = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ServiceType")});
            this.xrLabel1.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(16.50009F, 197.9583F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(63.04153F, 19F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel1.WordWrap = false;
            // 
            // lblCust6
            // 
            this.lblCust6.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblCust6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Customer6")});
            this.lblCust6.Font = new System.Drawing.Font("Lucida Console", 10.25F);
            this.lblCust6.LocationFloat = new DevExpress.Utils.PointFloat(16.50008F, 162F);
            this.lblCust6.Name = "lblCust6";
            this.lblCust6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCust6.SizeF = new System.Drawing.SizeF(337.4999F, 18F);
            this.lblCust6.StylePriority.UseBorders = false;
            this.lblCust6.StylePriority.UseFont = false;
            this.lblCust6.StylePriority.UseTextAlignment = false;
            this.lblCust6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblCust5
            // 
            this.lblCust5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblCust5.CanGrow = false;
            this.lblCust5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Customer5")});
            this.lblCust5.Font = new System.Drawing.Font("Lucida Console", 10.25F);
            this.lblCust5.LocationFloat = new DevExpress.Utils.PointFloat(16.50008F, 143F);
            this.lblCust5.Name = "lblCust5";
            this.lblCust5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCust5.SizeF = new System.Drawing.SizeF(337.4999F, 18F);
            this.lblCust5.StylePriority.UseBorders = false;
            this.lblCust5.StylePriority.UseFont = false;
            this.lblCust5.StylePriority.UseTextAlignment = false;
            this.lblCust5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblCust4
            // 
            this.lblCust4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblCust4.CanGrow = false;
            this.lblCust4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Customer4")});
            this.lblCust4.Font = new System.Drawing.Font("Lucida Console", 10.25F);
            this.lblCust4.LocationFloat = new DevExpress.Utils.PointFloat(16.50007F, 124F);
            this.lblCust4.Name = "lblCust4";
            this.lblCust4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCust4.SizeF = new System.Drawing.SizeF(337.4999F, 18F);
            this.lblCust4.StylePriority.UseBorders = false;
            this.lblCust4.StylePriority.UseFont = false;
            this.lblCust4.StylePriority.UseTextAlignment = false;
            this.lblCust4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblCust3
            // 
            this.lblCust3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblCust3.CanGrow = false;
            this.lblCust3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Customer3")});
            this.lblCust3.Font = new System.Drawing.Font("Lucida Console", 10.25F);
            this.lblCust3.LocationFloat = new DevExpress.Utils.PointFloat(16.50006F, 105F);
            this.lblCust3.Name = "lblCust3";
            this.lblCust3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCust3.SizeF = new System.Drawing.SizeF(337.4999F, 18F);
            this.lblCust3.StylePriority.UseBorders = false;
            this.lblCust3.StylePriority.UseFont = false;
            this.lblCust3.StylePriority.UseTextAlignment = false;
            this.lblCust3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblCust2
            // 
            this.lblCust2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblCust2.CanGrow = false;
            this.lblCust2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Customer2")});
            this.lblCust2.Font = new System.Drawing.Font("Lucida Console", 10.25F);
            this.lblCust2.LocationFloat = new DevExpress.Utils.PointFloat(16.50005F, 86F);
            this.lblCust2.Name = "lblCust2";
            this.lblCust2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCust2.SizeF = new System.Drawing.SizeF(337.4999F, 18F);
            this.lblCust2.StylePriority.UseBorders = false;
            this.lblCust2.StylePriority.UseFont = false;
            this.lblCust2.StylePriority.UseTextAlignment = false;
            this.lblCust2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblCust1
            // 
            this.lblCust1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblCust1.CanGrow = false;
            this.lblCust1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Customer1")});
            this.lblCust1.Font = new System.Drawing.Font("Lucida Console", 10.25F);
            this.lblCust1.LocationFloat = new DevExpress.Utils.PointFloat(16F, 67F);
            this.lblCust1.Name = "lblCust1";
            this.lblCust1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCust1.SizeF = new System.Drawing.SizeF(337.4999F, 18F);
            this.lblCust1.StylePriority.UseBorders = false;
            this.lblCust1.StylePriority.UseFont = false;
            this.lblCust1.StylePriority.UseTextAlignment = false;
            this.lblCust1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel13.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(102.4583F, 197.9583F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(251.0417F, 19F);
            this.xrLabel13.StylePriority.UseBorders = false;
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "Printed On";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel13.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrLabel13_BeforePrint);
            // 
            // xrLabel6
            // 
            this.xrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel6.Font = new System.Drawing.Font("Lucida Console", 10.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(316.9584F, 43.66332F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(36.54166F, 18F);
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Pcs";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Number")});
            this.xrLabel5.Font = new System.Drawing.Font("Lucida Console", 10.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(283.9584F, 43.66332F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(30F, 17.99999F);
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "GrossWeight", "{0:#0}")});
            this.xrLabel4.Font = new System.Drawing.Font("Lucida Console", 13.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(242.125F, 24.66332F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(84.375F, 19F);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel3.Font = new System.Drawing.Font("Lucida Console", 13.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(326.5F, 24.66332F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(27F, 19F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Kg";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrBarCode1
            // 
            this.xrBarCode1.AutoModule = true;
            this.xrBarCode1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Code")});
            this.xrBarCode1.Font = new System.Drawing.Font("Lucida Console", 12.75F, System.Drawing.FontStyle.Bold);
            this.xrBarCode1.LocationFloat = new DevExpress.Utils.PointFloat(16F, 8.999997F);
            this.xrBarCode1.Name = "xrBarCode1";
            this.xrBarCode1.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.xrBarCode1.SizeF = new System.Drawing.SizeF(244.5833F, 49.20835F);
            this.xrBarCode1.StylePriority.UseFont = false;
            this.xrBarCode1.StylePriority.UseTextAlignment = false;
            this.xrBarCode1.Symbology = code128Generator1;
            this.xrBarCode1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel11.CanGrow = false;
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DestBranchName")});
            this.xrLabel11.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(244.625F, 5.663309F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(109.375F, 19F);
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel11.WordWrap = false;
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 3F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 19F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // bindingSource2
            // 
            this.bindingSource2.DataSource = typeof(SISCO.Models.PrintBarcodeCustomer);
            // 
            // ConsolSMUCard
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.DataSource = this.bindingSource2;
            this.Font = new System.Drawing.Font("Lucida Console", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(17, 14, 3, 19);
            this.PageHeight = 258;
            this.PageWidth = 417;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Version = "13.2";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCode1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel lblCust6;
        private DevExpress.XtraReports.UI.XRLabel lblCust5;
        private DevExpress.XtraReports.UI.XRLabel lblCust4;
        private DevExpress.XtraReports.UI.XRLabel lblCust3;
        private DevExpress.XtraReports.UI.XRLabel lblCust2;
        private DevExpress.XtraReports.UI.XRLabel lblCust1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
    }
}
