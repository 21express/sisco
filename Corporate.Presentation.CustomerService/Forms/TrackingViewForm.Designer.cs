using SISCO.Models;

namespace Corporate.Presentation.CustomerService.Forms
{
    partial class TrackingViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrackingViewForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxDestination = new Corporate.Presentation.Common.Component.dTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tbxOrigin = new Corporate.Presentation.Common.Component.dTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tbxDate = new Corporate.Presentation.Common.Component.dTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.pnlOtherInformation = new System.Windows.Forms.Panel();
            this.tbxTtlChargeable = new Corporate.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxTtlWeight = new Corporate.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.tbxTtlPiece = new Corporate.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.tbxNatureOfGood = new Corporate.Presentation.Common.Component.dTextBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.tbxPayment = new Corporate.Presentation.Common.Component.dTextBox(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.tbxService = new Corporate.Presentation.Common.Component.dTextBox(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.tbxPackage = new Corporate.Presentation.Common.Component.dTextBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.pnlShipperInformation = new System.Windows.Forms.Panel();
            this.tbxPhone = new Corporate.Presentation.Common.Component.dTextBox(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.tbxAddress = new Corporate.Presentation.Common.Component.dTextBox(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.tbxName = new Corporate.Presentation.Common.Component.dTextBox(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbxCustomer = new Corporate.Presentation.Common.Component.dTextBox(this.components);
            this.tbxCustomerCode = new Corporate.Presentation.Common.Component.dTextBox(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.pnlConsigneeInformation = new System.Windows.Forms.Panel();
            this.tbxConsigneePhone = new Corporate.Presentation.Common.Component.dTextBox(this.components);
            this.label18 = new System.Windows.Forms.Label();
            this.tbxConsigneeAddress = new Corporate.Presentation.Common.Component.dTextBox(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.tbxConsigneeName = new Corporate.Presentation.Common.Component.dTextBox(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            this.pnlOtherInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTtlChargeable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTtlWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTtlPiece.Properties)).BeginInit();
            this.pnlShipperInformation.SuspendLayout();
            this.pnlConsigneeInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbxDestination);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbxOrigin);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbxDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(6, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(505, 135);
            this.panel1.TabIndex = 1;
            // 
            // tbxDestination
            // 
            this.tbxDestination.BackColor = System.Drawing.Color.AliceBlue;
            this.tbxDestination.Capslock = true;
            this.tbxDestination.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDestination.FieldLabel = null;
            this.tbxDestination.Location = new System.Drawing.Point(124, 76);
            this.tbxDestination.Name = "tbxDestination";
            this.tbxDestination.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDestination.ReadOnly = true;
            this.tbxDestination.Size = new System.Drawing.Size(288, 24);
            this.tbxDestination.TabIndex = 3;
            this.tbxDestination.ValidationRules = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Destination";
            // 
            // tbxOrigin
            // 
            this.tbxOrigin.BackColor = System.Drawing.Color.AliceBlue;
            this.tbxOrigin.Capslock = true;
            this.tbxOrigin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxOrigin.FieldLabel = null;
            this.tbxOrigin.Location = new System.Drawing.Point(124, 50);
            this.tbxOrigin.Name = "tbxOrigin";
            this.tbxOrigin.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxOrigin.ReadOnly = true;
            this.tbxOrigin.Size = new System.Drawing.Size(288, 24);
            this.tbxOrigin.TabIndex = 2;
            this.tbxOrigin.ValidationRules = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Origin";
            // 
            // tbxDate
            // 
            this.tbxDate.BackColor = System.Drawing.Color.AliceBlue;
            this.tbxDate.Capslock = true;
            this.tbxDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.Location = new System.Drawing.Point(124, 24);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.ReadOnly = true;
            this.tbxDate.Size = new System.Drawing.Size(125, 24);
            this.tbxDate.TabIndex = 1;
            this.tbxDate.ValidationRules = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Date";
            // 
            // pnlOtherInformation
            // 
            this.pnlOtherInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pnlOtherInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOtherInformation.Controls.Add(this.tbxTtlChargeable);
            this.pnlOtherInformation.Controls.Add(this.label7);
            this.pnlOtherInformation.Controls.Add(this.label6);
            this.pnlOtherInformation.Controls.Add(this.tbxTtlWeight);
            this.pnlOtherInformation.Controls.Add(this.tbxTtlPiece);
            this.pnlOtherInformation.Controls.Add(this.label5);
            this.pnlOtherInformation.Controls.Add(this.tbxNatureOfGood);
            this.pnlOtherInformation.Controls.Add(this.label11);
            this.pnlOtherInformation.Controls.Add(this.tbxPayment);
            this.pnlOtherInformation.Controls.Add(this.label10);
            this.pnlOtherInformation.Controls.Add(this.tbxService);
            this.pnlOtherInformation.Controls.Add(this.label9);
            this.pnlOtherInformation.Controls.Add(this.tbxPackage);
            this.pnlOtherInformation.Controls.Add(this.label8);
            this.pnlOtherInformation.Location = new System.Drawing.Point(6, 246);
            this.pnlOtherInformation.Name = "pnlOtherInformation";
            this.pnlOtherInformation.Size = new System.Drawing.Size(505, 118);
            this.pnlOtherInformation.TabIndex = 4;
            // 
            // tbxTtlChargeable
            // 
            this.tbxTtlChargeable.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTtlChargeable.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTtlChargeable.Enabled = false;
            this.tbxTtlChargeable.FieldLabel = null;
            this.tbxTtlChargeable.Location = new System.Drawing.Point(388, 56);
            this.tbxTtlChargeable.Name = "tbxTtlChargeable";
            this.tbxTtlChargeable.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTtlChargeable.Properties.AllowMouseWheel = false;
            this.tbxTtlChargeable.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.tbxTtlChargeable.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTtlChargeable.Properties.Appearance.Options.UseBackColor = true;
            this.tbxTtlChargeable.Properties.Appearance.Options.UseFont = true;
            this.tbxTtlChargeable.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTtlChargeable.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTtlChargeable.Properties.Mask.BeepOnError = true;
            this.tbxTtlChargeable.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTtlChargeable.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxTtlChargeable.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTtlChargeable.ReadOnly = false;
            this.tbxTtlChargeable.Size = new System.Drawing.Size(100, 24);
            this.tbxTtlChargeable.TabIndex = 10;
            this.tbxTtlChargeable.TextAlign = null;
            this.tbxTtlChargeable.ValidationRules = null;
            this.tbxTtlChargeable.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(314, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Chargeable";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Total Weight";
            // 
            // tbxTtlWeight
            // 
            this.tbxTtlWeight.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTtlWeight.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTtlWeight.Enabled = false;
            this.tbxTtlWeight.FieldLabel = null;
            this.tbxTtlWeight.Location = new System.Drawing.Point(388, 30);
            this.tbxTtlWeight.Name = "tbxTtlWeight";
            this.tbxTtlWeight.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTtlWeight.Properties.AllowMouseWheel = false;
            this.tbxTtlWeight.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.tbxTtlWeight.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTtlWeight.Properties.Appearance.Options.UseBackColor = true;
            this.tbxTtlWeight.Properties.Appearance.Options.UseFont = true;
            this.tbxTtlWeight.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTtlWeight.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTtlWeight.Properties.Mask.BeepOnError = true;
            this.tbxTtlWeight.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTtlWeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxTtlWeight.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTtlWeight.ReadOnly = false;
            this.tbxTtlWeight.Size = new System.Drawing.Size(100, 24);
            this.tbxTtlWeight.TabIndex = 9;
            this.tbxTtlWeight.TextAlign = null;
            this.tbxTtlWeight.ValidationRules = null;
            this.tbxTtlWeight.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // tbxTtlPiece
            // 
            this.tbxTtlPiece.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTtlPiece.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTtlPiece.Enabled = false;
            this.tbxTtlPiece.FieldLabel = null;
            this.tbxTtlPiece.Location = new System.Drawing.Point(388, 4);
            this.tbxTtlPiece.Name = "tbxTtlPiece";
            this.tbxTtlPiece.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTtlPiece.Properties.AllowMouseWheel = false;
            this.tbxTtlPiece.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.tbxTtlPiece.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTtlPiece.Properties.Appearance.Options.UseBackColor = true;
            this.tbxTtlPiece.Properties.Appearance.Options.UseFont = true;
            this.tbxTtlPiece.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTtlPiece.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTtlPiece.Properties.Mask.BeepOnError = true;
            this.tbxTtlPiece.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTtlPiece.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxTtlPiece.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTtlPiece.ReadOnly = false;
            this.tbxTtlPiece.Size = new System.Drawing.Size(100, 24);
            this.tbxTtlPiece.TabIndex = 8;
            this.tbxTtlPiece.TextAlign = null;
            this.tbxTtlPiece.ValidationRules = null;
            this.tbxTtlPiece.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(316, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Total Piece";
            // 
            // tbxNatureOfGood
            // 
            this.tbxNatureOfGood.BackColor = System.Drawing.Color.AliceBlue;
            this.tbxNatureOfGood.Capslock = true;
            this.tbxNatureOfGood.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxNatureOfGood.FieldLabel = null;
            this.tbxNatureOfGood.Location = new System.Drawing.Point(124, 83);
            this.tbxNatureOfGood.Name = "tbxNatureOfGood";
            this.tbxNatureOfGood.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxNatureOfGood.ReadOnly = true;
            this.tbxNatureOfGood.Size = new System.Drawing.Size(364, 24);
            this.tbxNatureOfGood.TabIndex = 7;
            this.tbxNatureOfGood.ValidationRules = null;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 17);
            this.label11.TabIndex = 11;
            this.label11.Text = "Nature of Goods";
            // 
            // tbxPayment
            // 
            this.tbxPayment.BackColor = System.Drawing.Color.AliceBlue;
            this.tbxPayment.Capslock = true;
            this.tbxPayment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxPayment.FieldLabel = null;
            this.tbxPayment.Location = new System.Drawing.Point(124, 57);
            this.tbxPayment.Name = "tbxPayment";
            this.tbxPayment.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPayment.ReadOnly = true;
            this.tbxPayment.Size = new System.Drawing.Size(159, 24);
            this.tbxPayment.TabIndex = 6;
            this.tbxPayment.ValidationRules = null;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "Payment Method";
            // 
            // tbxService
            // 
            this.tbxService.BackColor = System.Drawing.Color.AliceBlue;
            this.tbxService.Capslock = true;
            this.tbxService.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxService.FieldLabel = null;
            this.tbxService.Location = new System.Drawing.Point(124, 31);
            this.tbxService.Name = "tbxService";
            this.tbxService.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxService.ReadOnly = true;
            this.tbxService.Size = new System.Drawing.Size(159, 24);
            this.tbxService.TabIndex = 5;
            this.tbxService.ValidationRules = null;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "Service Type";
            // 
            // tbxPackage
            // 
            this.tbxPackage.BackColor = System.Drawing.Color.AliceBlue;
            this.tbxPackage.Capslock = true;
            this.tbxPackage.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxPackage.FieldLabel = null;
            this.tbxPackage.Location = new System.Drawing.Point(124, 5);
            this.tbxPackage.Name = "tbxPackage";
            this.tbxPackage.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPackage.ReadOnly = true;
            this.tbxPackage.Size = new System.Drawing.Size(159, 24);
            this.tbxPackage.TabIndex = 4;
            this.tbxPackage.ValidationRules = null;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Package Type";
            // 
            // pnlShipperInformation
            // 
            this.pnlShipperInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlShipperInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlShipperInformation.Controls.Add(this.tbxPhone);
            this.pnlShipperInformation.Controls.Add(this.label16);
            this.pnlShipperInformation.Controls.Add(this.tbxAddress);
            this.pnlShipperInformation.Controls.Add(this.label15);
            this.pnlShipperInformation.Controls.Add(this.tbxName);
            this.pnlShipperInformation.Controls.Add(this.label14);
            this.pnlShipperInformation.Controls.Add(this.label13);
            this.pnlShipperInformation.Controls.Add(this.tbxCustomer);
            this.pnlShipperInformation.Controls.Add(this.tbxCustomerCode);
            this.pnlShipperInformation.Controls.Add(this.label12);
            this.pnlShipperInformation.Location = new System.Drawing.Point(517, 112);
            this.pnlShipperInformation.Name = "pnlShipperInformation";
            this.pnlShipperInformation.Size = new System.Drawing.Size(377, 135);
            this.pnlShipperInformation.TabIndex = 11;
            // 
            // tbxPhone
            // 
            this.tbxPhone.BackColor = System.Drawing.Color.AliceBlue;
            this.tbxPhone.Capslock = true;
            this.tbxPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxPhone.FieldLabel = null;
            this.tbxPhone.Location = new System.Drawing.Point(81, 104);
            this.tbxPhone.Name = "tbxPhone";
            this.tbxPhone.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPhone.ReadOnly = true;
            this.tbxPhone.Size = new System.Drawing.Size(139, 24);
            this.tbxPhone.TabIndex = 15;
            this.tbxPhone.ValidationRules = null;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(33, 108);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 17);
            this.label16.TabIndex = 9;
            this.label16.Text = "Phone";
            // 
            // tbxAddress
            // 
            this.tbxAddress.BackColor = System.Drawing.Color.AliceBlue;
            this.tbxAddress.Capslock = true;
            this.tbxAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxAddress.FieldLabel = null;
            this.tbxAddress.Location = new System.Drawing.Point(81, 79);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxAddress.ReadOnly = true;
            this.tbxAddress.Size = new System.Drawing.Size(270, 24);
            this.tbxAddress.TabIndex = 14;
            this.tbxAddress.ValidationRules = null;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(25, 82);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 17);
            this.label15.TabIndex = 7;
            this.label15.Text = "Address";
            // 
            // tbxName
            // 
            this.tbxName.BackColor = System.Drawing.Color.AliceBlue;
            this.tbxName.Capslock = true;
            this.tbxName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxName.FieldLabel = null;
            this.tbxName.Location = new System.Drawing.Point(81, 54);
            this.tbxName.Name = "tbxName";
            this.tbxName.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxName.ReadOnly = true;
            this.tbxName.Size = new System.Drawing.Size(270, 24);
            this.tbxName.TabIndex = 13;
            this.tbxName.ValidationRules = null;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(36, 58);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 17);
            this.label14.TabIndex = 5;
            this.label14.Text = "Name";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(78, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 17);
            this.label13.TabIndex = 4;
            this.label13.Text = "Shipper";
            // 
            // tbxCustomer
            // 
            this.tbxCustomer.BackColor = System.Drawing.Color.AliceBlue;
            this.tbxCustomer.Capslock = true;
            this.tbxCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxCustomer.FieldLabel = null;
            this.tbxCustomer.Location = new System.Drawing.Point(165, 5);
            this.tbxCustomer.Name = "tbxCustomer";
            this.tbxCustomer.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxCustomer.ReadOnly = true;
            this.tbxCustomer.Size = new System.Drawing.Size(186, 24);
            this.tbxCustomer.TabIndex = 12;
            this.tbxCustomer.ValidationRules = null;
            // 
            // tbxCustomerCode
            // 
            this.tbxCustomerCode.BackColor = System.Drawing.Color.AliceBlue;
            this.tbxCustomerCode.Capslock = true;
            this.tbxCustomerCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxCustomerCode.FieldLabel = null;
            this.tbxCustomerCode.Location = new System.Drawing.Point(81, 5);
            this.tbxCustomerCode.Name = "tbxCustomerCode";
            this.tbxCustomerCode.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxCustomerCode.ReadOnly = true;
            this.tbxCustomerCode.Size = new System.Drawing.Size(80, 24);
            this.tbxCustomerCode.TabIndex = 11;
            this.tbxCustomerCode.ValidationRules = null;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 17);
            this.label12.TabIndex = 1;
            this.label12.Text = "Customer";
            // 
            // pnlConsigneeInformation
            // 
            this.pnlConsigneeInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pnlConsigneeInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConsigneeInformation.Controls.Add(this.tbxConsigneePhone);
            this.pnlConsigneeInformation.Controls.Add(this.label18);
            this.pnlConsigneeInformation.Controls.Add(this.tbxConsigneeAddress);
            this.pnlConsigneeInformation.Controls.Add(this.label19);
            this.pnlConsigneeInformation.Controls.Add(this.tbxConsigneeName);
            this.pnlConsigneeInformation.Controls.Add(this.label20);
            this.pnlConsigneeInformation.Controls.Add(this.label17);
            this.pnlConsigneeInformation.Location = new System.Drawing.Point(517, 246);
            this.pnlConsigneeInformation.Name = "pnlConsigneeInformation";
            this.pnlConsigneeInformation.Size = new System.Drawing.Size(377, 118);
            this.pnlConsigneeInformation.TabIndex = 16;
            // 
            // tbxConsigneePhone
            // 
            this.tbxConsigneePhone.BackColor = System.Drawing.Color.AliceBlue;
            this.tbxConsigneePhone.Capslock = true;
            this.tbxConsigneePhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxConsigneePhone.FieldLabel = null;
            this.tbxConsigneePhone.Location = new System.Drawing.Point(81, 81);
            this.tbxConsigneePhone.Name = "tbxConsigneePhone";
            this.tbxConsigneePhone.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxConsigneePhone.ReadOnly = true;
            this.tbxConsigneePhone.Size = new System.Drawing.Size(139, 24);
            this.tbxConsigneePhone.TabIndex = 18;
            this.tbxConsigneePhone.ValidationRules = null;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(33, 85);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 17);
            this.label18.TabIndex = 15;
            this.label18.Text = "Phone";
            // 
            // tbxConsigneeAddress
            // 
            this.tbxConsigneeAddress.BackColor = System.Drawing.Color.AliceBlue;
            this.tbxConsigneeAddress.Capslock = true;
            this.tbxConsigneeAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxConsigneeAddress.FieldLabel = null;
            this.tbxConsigneeAddress.Location = new System.Drawing.Point(81, 56);
            this.tbxConsigneeAddress.Name = "tbxConsigneeAddress";
            this.tbxConsigneeAddress.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxConsigneeAddress.ReadOnly = true;
            this.tbxConsigneeAddress.Size = new System.Drawing.Size(270, 24);
            this.tbxConsigneeAddress.TabIndex = 17;
            this.tbxConsigneeAddress.ValidationRules = null;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(25, 59);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(50, 17);
            this.label19.TabIndex = 13;
            this.label19.Text = "Address";
            // 
            // tbxConsigneeName
            // 
            this.tbxConsigneeName.BackColor = System.Drawing.Color.AliceBlue;
            this.tbxConsigneeName.Capslock = true;
            this.tbxConsigneeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxConsigneeName.FieldLabel = null;
            this.tbxConsigneeName.Location = new System.Drawing.Point(81, 31);
            this.tbxConsigneeName.Name = "tbxConsigneeName";
            this.tbxConsigneeName.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxConsigneeName.ReadOnly = true;
            this.tbxConsigneeName.Size = new System.Drawing.Size(270, 24);
            this.tbxConsigneeName.TabIndex = 16;
            this.tbxConsigneeName.ValidationRules = null;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(36, 35);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(39, 17);
            this.label20.TabIndex = 11;
            this.label20.Text = "Name";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(78, 11);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 17);
            this.label17.TabIndex = 5;
            this.label17.Text = "Consignee";
            // 
            // btnExport
            // 
            this.btnExport.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnExport.Location = new System.Drawing.Point(802, 429);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(92, 89);
            this.btnExport.TabIndex = 19;
            this.btnExport.Text = "&Save To Excel";
            // 
            // grid
            // 
            this.grid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid.Location = new System.Drawing.Point(6, 370);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(790, 148);
            this.grid.TabIndex = 57;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn3,
            this.gridColumn9,
            this.gridColumn10});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No";
            this.gridColumn1.FieldName = "Index";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 28;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Date";
            this.gridColumn2.FieldName = "StatusDate";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 70;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Time";
            this.gridColumn4.FieldName = "StatusTime";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 35;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Status";
            this.gridColumn5.FieldName = "TrackingStatus";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 98;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Position";
            this.gridColumn6.FieldName = "Position";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 98;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "By";
            this.gridColumn7.FieldName = "StatusBy";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 98;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Note";
            this.gridColumn8.FieldName = "StatusNote";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 125;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Miss Delivery Reason";
            this.gridColumn3.FieldName = "MissDeliveryReason";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 9;
            this.gridColumn3.Width = 111;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Reference";
            this.gridColumn9.FieldName = "Reference";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 94;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Actor";
            this.gridColumn10.FieldName = "Createdby";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            this.gridColumn10.Width = 85;
            // 
            // TrackingViewForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(899, 524);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.pnlConsigneeInformation);
            this.Controls.Add(this.pnlShipperInformation);
            this.Controls.Add(this.pnlOtherInformation);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrackingViewForm";
            this.Text = "Tracking View";
            this.Controls.SetChildIndex(this.tbxSearch_Code, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlOtherInformation, 0);
            this.Controls.SetChildIndex(this.pnlShipperInformation, 0);
            this.Controls.SetChildIndex(this.pnlConsigneeInformation, 0);
            this.Controls.SetChildIndex(this.btnExport, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlOtherInformation.ResumeLayout(false);
            this.pnlOtherInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTtlChargeable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTtlWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTtlPiece.Properties)).EndInit();
            this.pnlShipperInformation.ResumeLayout(false);
            this.pnlShipperInformation.PerformLayout();
            this.pnlConsigneeInformation.ResumeLayout(false);
            this.pnlConsigneeInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Common.Component.dTextBox tbxDestination;
        private System.Windows.Forms.Label label4;
        private Common.Component.dTextBox tbxOrigin;
        private System.Windows.Forms.Label label3;
        private Common.Component.dTextBox tbxDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlOtherInformation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Common.Component.dTextBox tbxNatureOfGood;
        private System.Windows.Forms.Label label11;
        private Common.Component.dTextBox tbxPayment;
        private System.Windows.Forms.Label label10;
        private Common.Component.dTextBox tbxService;
        private System.Windows.Forms.Label label9;
        private Common.Component.dTextBox tbxPackage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlShipperInformation;
        private Common.Component.dTextBox tbxPhone;
        private System.Windows.Forms.Label label16;
        private Common.Component.dTextBox tbxAddress;
        private System.Windows.Forms.Label label15;
        private Common.Component.dTextBox tbxName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private Common.Component.dTextBox tbxCustomer;
        private Common.Component.dTextBox tbxCustomerCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel pnlConsigneeInformation;
        private Common.Component.dTextBox tbxConsigneePhone;
        private System.Windows.Forms.Label label18;
        private Common.Component.dTextBox tbxConsigneeAddress;
        private System.Windows.Forms.Label label19;
        private Common.Component.dTextBox tbxConsigneeName;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label17;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private Corporate.Presentation.Common.Component.dTextBoxNumber tbxTtlChargeable;
        private Corporate.Presentation.Common.Component.dTextBoxNumber tbxTtlWeight;
        private Corporate.Presentation.Common.Component.dTextBoxNumber tbxTtlPiece;
    }
}