using Devenlab.Common;

namespace SISCO.Presentation.CustomerService.Forms
{
    partial class PickupOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickupOrderForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlGreen = new System.Windows.Forms.Panel();
            this.tbxPayment = new SISCO.Presentation.Common.Component.dLookup();
            this.tbxService = new SISCO.Presentation.Common.Component.dLookup();
            this.tbxPackage = new SISCO.Presentation.Common.Component.dLookup();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlPink = new System.Windows.Forms.Panel();
            this.tbxGrandTotal = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.tbxWeight = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.tbxPiece = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.tbxIsi = new SISCO.Presentation.Common.Component.dTextBox();
            this.tbxDimensi = new SISCO.Presentation.Common.Component.dTextBox();
            this.cbxCancelled = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.tbxFilterDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.tbxFilterMessenger = new SISCO.Presentation.Common.Component.dLookup();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.cbxFilterShow = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.pnlBlue = new System.Windows.Forms.Panel();
            this.rbDropPoint = new System.Windows.Forms.RadioButton();
            this.rbFranchise = new System.Windows.Forms.RadioButton();
            this.rbCustomer = new System.Windows.Forms.RadioButton();
            this.lkpDropPoint = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpFranchise = new SISCO.Presentation.Common.Component.dLookup();
            this.cbxNew = new System.Windows.Forms.CheckBox();
            this.tbxEmployee = new SISCO.Presentation.Common.Component.dLookup();
            this.tbxPickupDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.tbxDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.tbxMessenger = new SISCO.Presentation.Common.Component.dLookup();
            this.tbxVehicle = new SISCO.Presentation.Common.Component.dLookup();
            this.tbxCustomer = new SISCO.Presentation.Common.Component.dLookup();
            this.tbxPickupTime = new SISCO.Presentation.Common.Component.dTime();
            this.ucPickedup = new SISCO.Presentation.Common.UserControls.ucIconYesNo();
            this.ucConfirmed = new SISCO.Presentation.Common.UserControls.ucIconYesNo();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxNote = new SISCO.Presentation.Common.Component.dTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxContact = new SISCO.Presentation.Common.Component.dTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxPhone = new SISCO.Presentation.Common.Component.dTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxAddress = new SISCO.Presentation.Common.Component.dTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PickupOrderGrid = new DevExpress.XtraGrid.GridControl();
            this.PickupOrderView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPickup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPIC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPcs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clWt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clVehicle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clService = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clKurir = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clConf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPUNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCancel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlGreen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPayment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxService.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPackage.Properties)).BeginInit();
            this.pnlPink.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxGrandTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPiece.Properties)).BeginInit();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFilterDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFilterDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFilterMessenger.Properties)).BeginInit();
            this.pnlBlue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDropPoint.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFranchise.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPickupDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPickupDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxMessenger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxVehicle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPickupTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickupOrderGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickupOrderView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGreen
            // 
            this.pnlGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlGreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGreen.Controls.Add(this.tbxPayment);
            this.pnlGreen.Controls.Add(this.tbxService);
            this.pnlGreen.Controls.Add(this.tbxPackage);
            this.pnlGreen.Controls.Add(this.label14);
            this.pnlGreen.Controls.Add(this.label13);
            this.pnlGreen.Controls.Add(this.label12);
            this.pnlGreen.Location = new System.Drawing.Point(591, 39);
            this.pnlGreen.Name = "pnlGreen";
            this.pnlGreen.Size = new System.Drawing.Size(310, 97);
            this.pnlGreen.TabIndex = 12;
            // 
            // tbxPayment
            // 
            this.tbxPayment.AutoCompleteDataManager = null;
            this.tbxPayment.AutoCompleteDisplayFormater = null;
            this.tbxPayment.AutoCompleteInitialized = false;
            this.tbxPayment.AutocompleteMinimumTextLength = 0;
            this.tbxPayment.AutoCompleteText = null;
            this.tbxPayment.AutoCompleteWhereExpression = null;
            this.tbxPayment.AutoCompleteWheretermFormater = null;
            this.tbxPayment.ClearOnLeave = true;
            this.tbxPayment.DisplayString = null;
            this.tbxPayment.FieldLabel = null;
            this.tbxPayment.Location = new System.Drawing.Point(131, 61);
            this.tbxPayment.LookupPopup = null;
            this.tbxPayment.Name = "tbxPayment";
            this.tbxPayment.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPayment.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxPayment.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxPayment.Properties.Appearance.Options.UseBackColor = true;
            this.tbxPayment.Properties.Appearance.Options.UseFont = true;
            this.tbxPayment.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxPayment.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxPayment.Properties.AutoCompleteDataManager = null;
            this.tbxPayment.Properties.AutoCompleteDisplayFormater = null;
            this.tbxPayment.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxPayment.Properties.AutoCompleteText = null;
            this.tbxPayment.Properties.AutoCompleteWhereExpression = null;
            this.tbxPayment.Properties.AutoCompleteWheretermFormater = null;
            this.tbxPayment.Properties.AutoHeight = false;
            this.tbxPayment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxPayment.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.tbxPayment.Properties.LookupPopup = null;
            this.tbxPayment.Properties.NullText = "<<Choose...>>";
            this.tbxPayment.Size = new System.Drawing.Size(150, 24);
            this.tbxPayment.TabIndex = 16;
            this.tbxPayment.ValidationRules = null;
            this.tbxPayment.Value = null;
            // 
            // tbxService
            // 
            this.tbxService.AutoCompleteDataManager = null;
            this.tbxService.AutoCompleteDisplayFormater = null;
            this.tbxService.AutoCompleteInitialized = false;
            this.tbxService.AutocompleteMinimumTextLength = 0;
            this.tbxService.AutoCompleteText = null;
            this.tbxService.AutoCompleteWhereExpression = null;
            this.tbxService.AutoCompleteWheretermFormater = null;
            this.tbxService.ClearOnLeave = true;
            this.tbxService.DisplayString = null;
            this.tbxService.FieldLabel = null;
            this.tbxService.Location = new System.Drawing.Point(131, 35);
            this.tbxService.LookupPopup = null;
            this.tbxService.Name = "tbxService";
            this.tbxService.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxService.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxService.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxService.Properties.Appearance.Options.UseBackColor = true;
            this.tbxService.Properties.Appearance.Options.UseFont = true;
            this.tbxService.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxService.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxService.Properties.AutoCompleteDataManager = null;
            this.tbxService.Properties.AutoCompleteDisplayFormater = null;
            this.tbxService.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxService.Properties.AutoCompleteText = null;
            this.tbxService.Properties.AutoCompleteWhereExpression = null;
            this.tbxService.Properties.AutoCompleteWheretermFormater = null;
            this.tbxService.Properties.AutoHeight = false;
            this.tbxService.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxService.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.tbxService.Properties.LookupPopup = null;
            this.tbxService.Properties.NullText = "<<Choose...>>";
            this.tbxService.Size = new System.Drawing.Size(150, 24);
            this.tbxService.TabIndex = 15;
            this.tbxService.ValidationRules = null;
            this.tbxService.Value = null;
            // 
            // tbxPackage
            // 
            this.tbxPackage.AutoCompleteDataManager = null;
            this.tbxPackage.AutoCompleteDisplayFormater = null;
            this.tbxPackage.AutoCompleteInitialized = false;
            this.tbxPackage.AutocompleteMinimumTextLength = 0;
            this.tbxPackage.AutoCompleteText = null;
            this.tbxPackage.AutoCompleteWhereExpression = null;
            this.tbxPackage.AutoCompleteWheretermFormater = null;
            this.tbxPackage.ClearOnLeave = true;
            this.tbxPackage.DisplayString = null;
            this.tbxPackage.FieldLabel = null;
            this.tbxPackage.Location = new System.Drawing.Point(131, 9);
            this.tbxPackage.LookupPopup = null;
            this.tbxPackage.Name = "tbxPackage";
            this.tbxPackage.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPackage.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxPackage.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxPackage.Properties.Appearance.Options.UseBackColor = true;
            this.tbxPackage.Properties.Appearance.Options.UseFont = true;
            this.tbxPackage.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxPackage.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxPackage.Properties.AutoCompleteDataManager = null;
            this.tbxPackage.Properties.AutoCompleteDisplayFormater = null;
            this.tbxPackage.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxPackage.Properties.AutoCompleteText = null;
            this.tbxPackage.Properties.AutoCompleteWhereExpression = null;
            this.tbxPackage.Properties.AutoCompleteWheretermFormater = null;
            this.tbxPackage.Properties.AutoHeight = false;
            this.tbxPackage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxPackage.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.tbxPackage.Properties.LookupPopup = null;
            this.tbxPackage.Properties.NullText = "<<Choose...>>";
            this.tbxPackage.Size = new System.Drawing.Size(150, 24);
            this.tbxPackage.TabIndex = 14;
            this.tbxPackage.ValidationRules = null;
            this.tbxPackage.Value = null;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(18, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 17);
            this.label14.TabIndex = 3;
            this.label14.Text = "Payment Method";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(43, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 17);
            this.label13.TabIndex = 2;
            this.label13.Text = "Service Type";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(37, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "Package Type";
            // 
            // pnlPink
            // 
            this.pnlPink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pnlPink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPink.Controls.Add(this.tbxGrandTotal);
            this.pnlPink.Controls.Add(this.tbxWeight);
            this.pnlPink.Controls.Add(this.tbxPiece);
            this.pnlPink.Controls.Add(this.tbxIsi);
            this.pnlPink.Controls.Add(this.tbxDimensi);
            this.pnlPink.Controls.Add(this.cbxCancelled);
            this.pnlPink.Controls.Add(this.label19);
            this.pnlPink.Controls.Add(this.label18);
            this.pnlPink.Controls.Add(this.label17);
            this.pnlPink.Controls.Add(this.label16);
            this.pnlPink.Controls.Add(this.label15);
            this.pnlPink.Location = new System.Drawing.Point(591, 135);
            this.pnlPink.Name = "pnlPink";
            this.pnlPink.Size = new System.Drawing.Size(310, 199);
            this.pnlPink.TabIndex = 15;
            // 
            // tbxGrandTotal
            // 
            this.tbxGrandTotal.EditMask = "###,###,###,###,###,##0.00";
            this.tbxGrandTotal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxGrandTotal.FieldLabel = null;
            this.tbxGrandTotal.Location = new System.Drawing.Point(131, 129);
            this.tbxGrandTotal.Name = "tbxGrandTotal";
            this.tbxGrandTotal.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxGrandTotal.Properties.AllowMouseWheel = false;
            this.tbxGrandTotal.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxGrandTotal.Properties.Appearance.Options.UseFont = true;
            this.tbxGrandTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxGrandTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxGrandTotal.Properties.Mask.BeepOnError = true;
            this.tbxGrandTotal.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxGrandTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxGrandTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxGrandTotal.ReadOnly = false;
            this.tbxGrandTotal.Size = new System.Drawing.Size(144, 24);
            this.tbxGrandTotal.TabIndex = 21;
            this.tbxGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxGrandTotal.ValidationRules = null;
            this.tbxGrandTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // tbxWeight
            // 
            this.tbxWeight.EditMask = "###,###,###,###,###,##0.00";
            this.tbxWeight.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxWeight.FieldLabel = null;
            this.tbxWeight.Location = new System.Drawing.Point(131, 43);
            this.tbxWeight.Name = "tbxWeight";
            this.tbxWeight.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxWeight.Properties.AllowMouseWheel = false;
            this.tbxWeight.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxWeight.Properties.Appearance.Options.UseFont = true;
            this.tbxWeight.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxWeight.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxWeight.Properties.Mask.BeepOnError = true;
            this.tbxWeight.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxWeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxWeight.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxWeight.ReadOnly = false;
            this.tbxWeight.Size = new System.Drawing.Size(93, 24);
            this.tbxWeight.TabIndex = 18;
            this.tbxWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxWeight.ValidationRules = null;
            this.tbxWeight.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // tbxPiece
            // 
            this.tbxPiece.EditMask = "###,###,###,###,###,##0.00";
            this.tbxPiece.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxPiece.FieldLabel = null;
            this.tbxPiece.Location = new System.Drawing.Point(131, 16);
            this.tbxPiece.Name = "tbxPiece";
            this.tbxPiece.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPiece.Properties.AllowMouseWheel = false;
            this.tbxPiece.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxPiece.Properties.Appearance.Options.UseFont = true;
            this.tbxPiece.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxPiece.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxPiece.Properties.Mask.BeepOnError = true;
            this.tbxPiece.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxPiece.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxPiece.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxPiece.ReadOnly = false;
            this.tbxPiece.Size = new System.Drawing.Size(93, 24);
            this.tbxPiece.TabIndex = 17;
            this.tbxPiece.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxPiece.ValidationRules = null;
            this.tbxPiece.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // tbxIsi
            // 
            this.tbxIsi.Capslock = true;
            this.tbxIsi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxIsi.FieldLabel = null;
            this.tbxIsi.Location = new System.Drawing.Point(131, 96);
            this.tbxIsi.Name = "tbxIsi";
            this.tbxIsi.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxIsi.Size = new System.Drawing.Size(144, 24);
            this.tbxIsi.TabIndex = 20;
            this.tbxIsi.ValidationRules = null;
            // 
            // tbxDimensi
            // 
            this.tbxDimensi.Capslock = true;
            this.tbxDimensi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDimensi.FieldLabel = null;
            this.tbxDimensi.Location = new System.Drawing.Point(131, 70);
            this.tbxDimensi.Name = "tbxDimensi";
            this.tbxDimensi.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDimensi.Size = new System.Drawing.Size(144, 24);
            this.tbxDimensi.TabIndex = 19;
            this.tbxDimensi.ValidationRules = null;
            // 
            // cbxCancelled
            // 
            this.cbxCancelled.AutoSize = true;
            this.cbxCancelled.ForeColor = System.Drawing.Color.Black;
            this.cbxCancelled.Location = new System.Drawing.Point(132, 159);
            this.cbxCancelled.Name = "cbxCancelled";
            this.cbxCancelled.Size = new System.Drawing.Size(78, 21);
            this.cbxCancelled.TabIndex = 26;
            this.cbxCancelled.Text = "Cancelled";
            this.cbxCancelled.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(44, 132);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 17);
            this.label19.TabIndex = 9;
            this.label19.Text = "Grand Total";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(45, 99);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 17);
            this.label18.TabIndex = 7;
            this.label18.Text = "Isi Barang";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(45, 74);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 17);
            this.label17.TabIndex = 5;
            this.label17.Text = "Dimensi";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(44, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 17);
            this.label16.TabIndex = 3;
            this.label16.Text = "Total Weight";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(45, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 17);
            this.label15.TabIndex = 1;
            this.label15.Text = "Total Piece";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.tbxFilterDate);
            this.pnlSearch.Controls.Add(this.tbxFilterMessenger);
            this.pnlSearch.Controls.Add(this.btnExport);
            this.pnlSearch.Controls.Add(this.label22);
            this.pnlSearch.Controls.Add(this.label21);
            this.pnlSearch.Controls.Add(this.btnRefresh);
            this.pnlSearch.Controls.Add(this.cbxFilterShow);
            this.pnlSearch.Controls.Add(this.label20);
            this.pnlSearch.Location = new System.Drawing.Point(0, 335);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(903, 35);
            this.pnlSearch.TabIndex = 29;
            // 
            // tbxFilterDate
            // 
            this.tbxFilterDate.EditValue = null;
            this.tbxFilterDate.FieldLabel = null;
            this.tbxFilterDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxFilterDate.Location = new System.Drawing.Point(258, 5);
            this.tbxFilterDate.Name = "tbxFilterDate";
            this.tbxFilterDate.Nullable = false;
            this.tbxFilterDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFilterDate.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.tbxFilterDate.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxFilterDate.Properties.Appearance.Options.UseBackColor = true;
            this.tbxFilterDate.Properties.Appearance.Options.UseFont = true;
            this.tbxFilterDate.Properties.AutoHeight = false;
            this.tbxFilterDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxFilterDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.tbxFilterDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxFilterDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxFilterDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxFilterDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxFilterDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxFilterDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxFilterDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxFilterDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxFilterDate.Properties.NullText = "<<Choose...>>";
            this.tbxFilterDate.Size = new System.Drawing.Size(161, 24);
            this.tbxFilterDate.TabIndex = 28;
            this.tbxFilterDate.ValidationRules = null;
            this.tbxFilterDate.Value = new System.DateTime(((long)(0)));
            // 
            // tbxFilterMessenger
            // 
            this.tbxFilterMessenger.AutoCompleteDataManager = null;
            this.tbxFilterMessenger.AutoCompleteDisplayFormater = null;
            this.tbxFilterMessenger.AutoCompleteInitialized = false;
            this.tbxFilterMessenger.AutocompleteMinimumTextLength = 0;
            this.tbxFilterMessenger.AutoCompleteText = null;
            this.tbxFilterMessenger.AutoCompleteWhereExpression = null;
            this.tbxFilterMessenger.AutoCompleteWheretermFormater = null;
            this.tbxFilterMessenger.ClearOnLeave = true;
            this.tbxFilterMessenger.DisplayString = null;
            this.tbxFilterMessenger.FieldLabel = null;
            this.tbxFilterMessenger.Location = new System.Drawing.Point(500, 5);
            this.tbxFilterMessenger.LookupPopup = null;
            this.tbxFilterMessenger.Name = "tbxFilterMessenger";
            this.tbxFilterMessenger.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxFilterMessenger.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxFilterMessenger.Properties.Appearance.Options.UseFont = true;
            this.tbxFilterMessenger.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxFilterMessenger.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxFilterMessenger.Properties.AutoCompleteDataManager = null;
            this.tbxFilterMessenger.Properties.AutoCompleteDisplayFormater = null;
            this.tbxFilterMessenger.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxFilterMessenger.Properties.AutoCompleteText = null;
            this.tbxFilterMessenger.Properties.AutoCompleteWhereExpression = null;
            this.tbxFilterMessenger.Properties.AutoCompleteWheretermFormater = null;
            this.tbxFilterMessenger.Properties.AutoHeight = false;
            this.tbxFilterMessenger.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxFilterMessenger.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.tbxFilterMessenger.Properties.LookupPopup = null;
            this.tbxFilterMessenger.Properties.NullText = "<<Choose...>>";
            this.tbxFilterMessenger.Size = new System.Drawing.Size(172, 24);
            this.tbxFilterMessenger.TabIndex = 29;
            this.tbxFilterMessenger.ValidationRules = null;
            this.tbxFilterMessenger.Value = null;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(785, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(107, 26);
            this.btnExport.TabIndex = 25;
            this.btnExport.Text = "Save To Excel";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(431, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 17);
            this.label22.TabIndex = 6;
            this.label22.Text = "Messenger";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(220, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(32, 17);
            this.label21.TabIndex = 4;
            this.label21.Text = "Date";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(707, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 26);
            this.btnRefresh.TabIndex = 24;
            this.btnRefresh.Text = "Refresh";
            // 
            // cbxFilterShow
            // 
            this.cbxFilterShow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFilterShow.FormattingEnabled = true;
            this.cbxFilterShow.Items.AddRange(new object[] {
            "Not Yet Picked Up",
            "All By Date",
            "All By Date By Messenger",
            "Cancelled By Date"});
            this.cbxFilterShow.Location = new System.Drawing.Point(87, 3);
            this.cbxFilterShow.Name = "cbxFilterShow";
            this.cbxFilterShow.Size = new System.Drawing.Size(121, 25);
            this.cbxFilterShow.TabIndex = 27;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(44, 8);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(38, 17);
            this.label20.TabIndex = 0;
            this.label20.Text = "Show";
            // 
            // pnlBlue
            // 
            this.pnlBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBlue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlBlue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBlue.Controls.Add(this.rbDropPoint);
            this.pnlBlue.Controls.Add(this.rbFranchise);
            this.pnlBlue.Controls.Add(this.rbCustomer);
            this.pnlBlue.Controls.Add(this.lkpDropPoint);
            this.pnlBlue.Controls.Add(this.lkpFranchise);
            this.pnlBlue.Controls.Add(this.cbxNew);
            this.pnlBlue.Controls.Add(this.tbxEmployee);
            this.pnlBlue.Controls.Add(this.tbxPickupDate);
            this.pnlBlue.Controls.Add(this.tbxDate);
            this.pnlBlue.Controls.Add(this.tbxMessenger);
            this.pnlBlue.Controls.Add(this.tbxVehicle);
            this.pnlBlue.Controls.Add(this.tbxCustomer);
            this.pnlBlue.Controls.Add(this.tbxPickupTime);
            this.pnlBlue.Controls.Add(this.ucPickedup);
            this.pnlBlue.Controls.Add(this.ucConfirmed);
            this.pnlBlue.Controls.Add(this.label11);
            this.pnlBlue.Controls.Add(this.label10);
            this.pnlBlue.Controls.Add(this.label9);
            this.pnlBlue.Controls.Add(this.label8);
            this.pnlBlue.Controls.Add(this.tbxNote);
            this.pnlBlue.Controls.Add(this.label7);
            this.pnlBlue.Controls.Add(this.tbxContact);
            this.pnlBlue.Controls.Add(this.label6);
            this.pnlBlue.Controls.Add(this.tbxPhone);
            this.pnlBlue.Controls.Add(this.label5);
            this.pnlBlue.Controls.Add(this.tbxAddress);
            this.pnlBlue.Controls.Add(this.label4);
            this.pnlBlue.Controls.Add(this.label2);
            this.pnlBlue.Controls.Add(this.label1);
            this.pnlBlue.Location = new System.Drawing.Point(2, 39);
            this.pnlBlue.Name = "pnlBlue";
            this.pnlBlue.Size = new System.Drawing.Size(587, 295);
            this.pnlBlue.TabIndex = 1;
            // 
            // rbDropPoint
            // 
            this.rbDropPoint.AutoSize = true;
            this.rbDropPoint.Location = new System.Drawing.Point(17, 123);
            this.rbDropPoint.Name = "rbDropPoint";
            this.rbDropPoint.Size = new System.Drawing.Size(85, 21);
            this.rbDropPoint.TabIndex = 51;
            this.rbDropPoint.TabStop = true;
            this.rbDropPoint.Text = "Drop Point";
            this.rbDropPoint.UseVisualStyleBackColor = true;
            // 
            // rbFranchise
            // 
            this.rbFranchise.AutoSize = true;
            this.rbFranchise.Location = new System.Drawing.Point(25, 98);
            this.rbFranchise.Name = "rbFranchise";
            this.rbFranchise.Size = new System.Drawing.Size(77, 21);
            this.rbFranchise.TabIndex = 50;
            this.rbFranchise.TabStop = true;
            this.rbFranchise.Text = "Franchise";
            this.rbFranchise.UseVisualStyleBackColor = true;
            // 
            // rbCustomer
            // 
            this.rbCustomer.AutoSize = true;
            this.rbCustomer.Location = new System.Drawing.Point(24, 74);
            this.rbCustomer.Name = "rbCustomer";
            this.rbCustomer.Size = new System.Drawing.Size(78, 21);
            this.rbCustomer.TabIndex = 49;
            this.rbCustomer.TabStop = true;
            this.rbCustomer.Text = "Customer";
            this.rbCustomer.UseVisualStyleBackColor = true;
            // 
            // lkpDropPoint
            // 
            this.lkpDropPoint.AutoCompleteDataManager = null;
            this.lkpDropPoint.AutoCompleteDisplayFormater = null;
            this.lkpDropPoint.AutoCompleteInitialized = false;
            this.lkpDropPoint.AutocompleteMinimumTextLength = 0;
            this.lkpDropPoint.AutoCompleteText = null;
            this.lkpDropPoint.AutoCompleteWhereExpression = null;
            this.lkpDropPoint.AutoCompleteWheretermFormater = null;
            this.lkpDropPoint.ClearOnLeave = true;
            this.lkpDropPoint.DisplayString = null;
            this.lkpDropPoint.FieldLabel = null;
            this.lkpDropPoint.Location = new System.Drawing.Point(106, 122);
            this.lkpDropPoint.LookupPopup = null;
            this.lkpDropPoint.Name = "lkpDropPoint";
            this.lkpDropPoint.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpDropPoint.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lkpDropPoint.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpDropPoint.Properties.Appearance.Options.UseBackColor = true;
            this.lkpDropPoint.Properties.Appearance.Options.UseFont = true;
            this.lkpDropPoint.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpDropPoint.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpDropPoint.Properties.AutoCompleteDataManager = null;
            this.lkpDropPoint.Properties.AutoCompleteDisplayFormater = null;
            this.lkpDropPoint.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpDropPoint.Properties.AutoCompleteText = null;
            this.lkpDropPoint.Properties.AutoCompleteWhereExpression = null;
            this.lkpDropPoint.Properties.AutoCompleteWheretermFormater = null;
            this.lkpDropPoint.Properties.AutoHeight = false;
            this.lkpDropPoint.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpDropPoint.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "", null, null, true)});
            this.lkpDropPoint.Properties.LookupPopup = null;
            this.lkpDropPoint.Properties.NullText = "<<Choose...>>";
            this.lkpDropPoint.Size = new System.Drawing.Size(274, 24);
            this.lkpDropPoint.TabIndex = 7;
            this.lkpDropPoint.ValidationRules = null;
            this.lkpDropPoint.Value = null;
            // 
            // lkpFranchise
            // 
            this.lkpFranchise.AutoCompleteDataManager = null;
            this.lkpFranchise.AutoCompleteDisplayFormater = null;
            this.lkpFranchise.AutoCompleteInitialized = false;
            this.lkpFranchise.AutocompleteMinimumTextLength = 0;
            this.lkpFranchise.AutoCompleteText = null;
            this.lkpFranchise.AutoCompleteWhereExpression = null;
            this.lkpFranchise.AutoCompleteWheretermFormater = null;
            this.lkpFranchise.ClearOnLeave = true;
            this.lkpFranchise.DisplayString = null;
            this.lkpFranchise.FieldLabel = null;
            this.lkpFranchise.Location = new System.Drawing.Point(106, 97);
            this.lkpFranchise.LookupPopup = null;
            this.lkpFranchise.Name = "lkpFranchise";
            this.lkpFranchise.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpFranchise.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lkpFranchise.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpFranchise.Properties.Appearance.Options.UseBackColor = true;
            this.lkpFranchise.Properties.Appearance.Options.UseFont = true;
            this.lkpFranchise.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpFranchise.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpFranchise.Properties.AutoCompleteDataManager = null;
            this.lkpFranchise.Properties.AutoCompleteDisplayFormater = null;
            this.lkpFranchise.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpFranchise.Properties.AutoCompleteText = null;
            this.lkpFranchise.Properties.AutoCompleteWhereExpression = null;
            this.lkpFranchise.Properties.AutoCompleteWheretermFormater = null;
            this.lkpFranchise.Properties.AutoHeight = false;
            this.lkpFranchise.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpFranchise.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "", null, null, true)});
            this.lkpFranchise.Properties.LookupPopup = null;
            this.lkpFranchise.Properties.NullText = "<<Choose...>>";
            this.lkpFranchise.Size = new System.Drawing.Size(274, 24);
            this.lkpFranchise.TabIndex = 6;
            this.lkpFranchise.ValidationRules = null;
            this.lkpFranchise.Value = null;
            // 
            // cbxNew
            // 
            this.cbxNew.AutoSize = true;
            this.cbxNew.ForeColor = System.Drawing.Color.Black;
            this.cbxNew.Location = new System.Drawing.Point(386, 74);
            this.cbxNew.Name = "cbxNew";
            this.cbxNew.Size = new System.Drawing.Size(50, 21);
            this.cbxNew.TabIndex = 7;
            this.cbxNew.Text = "New";
            this.cbxNew.UseVisualStyleBackColor = true;
            // 
            // tbxEmployee
            // 
            this.tbxEmployee.AutoCompleteDataManager = null;
            this.tbxEmployee.AutoCompleteDisplayFormater = null;
            this.tbxEmployee.AutoCompleteInitialized = false;
            this.tbxEmployee.AutocompleteMinimumTextLength = 0;
            this.tbxEmployee.AutoCompleteText = null;
            this.tbxEmployee.AutoCompleteWhereExpression = null;
            this.tbxEmployee.AutoCompleteWheretermFormater = null;
            this.tbxEmployee.ClearOnLeave = true;
            this.tbxEmployee.DisplayString = null;
            this.tbxEmployee.FieldLabel = null;
            this.tbxEmployee.Location = new System.Drawing.Point(347, 4);
            this.tbxEmployee.LookupPopup = null;
            this.tbxEmployee.Name = "tbxEmployee";
            this.tbxEmployee.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxEmployee.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxEmployee.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxEmployee.Properties.Appearance.Options.UseBackColor = true;
            this.tbxEmployee.Properties.Appearance.Options.UseFont = true;
            this.tbxEmployee.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxEmployee.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxEmployee.Properties.AutoCompleteDataManager = null;
            this.tbxEmployee.Properties.AutoCompleteDisplayFormater = null;
            this.tbxEmployee.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxEmployee.Properties.AutoCompleteText = null;
            this.tbxEmployee.Properties.AutoCompleteWhereExpression = null;
            this.tbxEmployee.Properties.AutoCompleteWheretermFormater = null;
            this.tbxEmployee.Properties.AutoHeight = false;
            this.tbxEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxEmployee.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, "", null, null, true)});
            this.tbxEmployee.Properties.LookupPopup = null;
            this.tbxEmployee.Properties.NullText = "<<Choose...>>";
            this.tbxEmployee.Size = new System.Drawing.Size(181, 24);
            this.tbxEmployee.TabIndex = 2;
            this.tbxEmployee.ValidationRules = null;
            this.tbxEmployee.Value = null;
            // 
            // tbxPickupDate
            // 
            this.tbxPickupDate.EditValue = null;
            this.tbxPickupDate.FieldLabel = null;
            this.tbxPickupDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxPickupDate.Location = new System.Drawing.Point(106, 29);
            this.tbxPickupDate.Name = "tbxPickupDate";
            this.tbxPickupDate.Nullable = false;
            this.tbxPickupDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPickupDate.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxPickupDate.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxPickupDate.Properties.Appearance.Options.UseBackColor = true;
            this.tbxPickupDate.Properties.Appearance.Options.UseFont = true;
            this.tbxPickupDate.Properties.AutoHeight = false;
            this.tbxPickupDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxPickupDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, "", null, null, true)});
            this.tbxPickupDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxPickupDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxPickupDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxPickupDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxPickupDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxPickupDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxPickupDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxPickupDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxPickupDate.Properties.NullText = "<<Choose...>>";
            this.tbxPickupDate.Size = new System.Drawing.Size(123, 24);
            this.tbxPickupDate.TabIndex = 3;
            this.tbxPickupDate.ValidationRules = null;
            this.tbxPickupDate.Value = new System.DateTime(((long)(0)));
            // 
            // tbxDate
            // 
            this.tbxDate.EditValue = null;
            this.tbxDate.FieldLabel = null;
            this.tbxDate.FormatDateTime = "dd-MM-yyyy";
            this.tbxDate.Location = new System.Drawing.Point(106, 4);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Nullable = false;
            this.tbxDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDate.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxDate.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxDate.Properties.Appearance.Options.UseBackColor = true;
            this.tbxDate.Properties.Appearance.Options.UseFont = true;
            this.tbxDate.Properties.AutoHeight = false;
            this.tbxDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10, "", null, null, true)});
            this.tbxDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.tbxDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.tbxDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.tbxDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxDate.Properties.NullText = "<<Choose...>>";
            this.tbxDate.Size = new System.Drawing.Size(123, 24);
            this.tbxDate.TabIndex = 1;
            this.tbxDate.ValidationRules = null;
            this.tbxDate.Value = new System.DateTime(((long)(0)));
            // 
            // tbxMessenger
            // 
            this.tbxMessenger.AutoCompleteDataManager = null;
            this.tbxMessenger.AutoCompleteDisplayFormater = null;
            this.tbxMessenger.AutoCompleteInitialized = false;
            this.tbxMessenger.AutocompleteMinimumTextLength = 0;
            this.tbxMessenger.AutoCompleteText = null;
            this.tbxMessenger.AutoCompleteWhereExpression = null;
            this.tbxMessenger.AutoCompleteWheretermFormater = null;
            this.tbxMessenger.ClearOnLeave = true;
            this.tbxMessenger.DisplayString = null;
            this.tbxMessenger.FieldLabel = null;
            this.tbxMessenger.Location = new System.Drawing.Point(106, 265);
            this.tbxMessenger.LookupPopup = null;
            this.tbxMessenger.Name = "tbxMessenger";
            this.tbxMessenger.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxMessenger.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.tbxMessenger.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxMessenger.Properties.Appearance.Options.UseBackColor = true;
            this.tbxMessenger.Properties.Appearance.Options.UseFont = true;
            this.tbxMessenger.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxMessenger.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxMessenger.Properties.AutoCompleteDataManager = null;
            this.tbxMessenger.Properties.AutoCompleteDisplayFormater = null;
            this.tbxMessenger.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxMessenger.Properties.AutoCompleteText = null;
            this.tbxMessenger.Properties.AutoCompleteWhereExpression = null;
            this.tbxMessenger.Properties.AutoCompleteWheretermFormater = null;
            this.tbxMessenger.Properties.AutoHeight = false;
            this.tbxMessenger.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxMessenger.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11, "", null, null, true)});
            this.tbxMessenger.Properties.LookupPopup = null;
            this.tbxMessenger.Properties.NullText = "<<Choose...>>";
            this.tbxMessenger.Size = new System.Drawing.Size(193, 24);
            this.tbxMessenger.TabIndex = 13;
            this.tbxMessenger.ValidationRules = null;
            this.tbxMessenger.Value = null;
            // 
            // tbxVehicle
            // 
            this.tbxVehicle.AutoCompleteDataManager = null;
            this.tbxVehicle.AutoCompleteDisplayFormater = null;
            this.tbxVehicle.AutoCompleteInitialized = false;
            this.tbxVehicle.AutocompleteMinimumTextLength = 0;
            this.tbxVehicle.AutoCompleteText = null;
            this.tbxVehicle.AutoCompleteWhereExpression = null;
            this.tbxVehicle.AutoCompleteWheretermFormater = null;
            this.tbxVehicle.ClearOnLeave = true;
            this.tbxVehicle.DisplayString = null;
            this.tbxVehicle.EditValue = "<<Choose...>>";
            this.tbxVehicle.FieldLabel = null;
            this.tbxVehicle.Location = new System.Drawing.Point(106, 239);
            this.tbxVehicle.LookupPopup = null;
            this.tbxVehicle.Name = "tbxVehicle";
            this.tbxVehicle.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxVehicle.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxVehicle.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxVehicle.Properties.Appearance.Options.UseBackColor = true;
            this.tbxVehicle.Properties.Appearance.Options.UseFont = true;
            this.tbxVehicle.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxVehicle.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxVehicle.Properties.AutoCompleteDataManager = null;
            this.tbxVehicle.Properties.AutoCompleteDisplayFormater = null;
            this.tbxVehicle.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxVehicle.Properties.AutoCompleteText = null;
            this.tbxVehicle.Properties.AutoCompleteWhereExpression = null;
            this.tbxVehicle.Properties.AutoCompleteWheretermFormater = null;
            this.tbxVehicle.Properties.AutoHeight = false;
            this.tbxVehicle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxVehicle.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12, "", null, null, true)});
            this.tbxVehicle.Properties.LookupPopup = null;
            this.tbxVehicle.Properties.NullText = "<<Choose...>>";
            this.tbxVehicle.Size = new System.Drawing.Size(151, 24);
            this.tbxVehicle.TabIndex = 12;
            this.tbxVehicle.ValidationRules = null;
            this.tbxVehicle.Value = null;
            // 
            // tbxCustomer
            // 
            this.tbxCustomer.AutoCompleteDataManager = null;
            this.tbxCustomer.AutoCompleteDisplayFormater = null;
            this.tbxCustomer.AutoCompleteInitialized = false;
            this.tbxCustomer.AutocompleteMinimumTextLength = 0;
            this.tbxCustomer.AutoCompleteText = null;
            this.tbxCustomer.AutoCompleteWhereExpression = null;
            this.tbxCustomer.AutoCompleteWheretermFormater = null;
            this.tbxCustomer.ClearOnLeave = true;
            this.tbxCustomer.DisplayString = null;
            this.tbxCustomer.FieldLabel = null;
            this.tbxCustomer.Location = new System.Drawing.Point(106, 72);
            this.tbxCustomer.LookupPopup = null;
            this.tbxCustomer.Name = "tbxCustomer";
            this.tbxCustomer.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxCustomer.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxCustomer.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxCustomer.Properties.Appearance.Options.UseBackColor = true;
            this.tbxCustomer.Properties.Appearance.Options.UseFont = true;
            this.tbxCustomer.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.tbxCustomer.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tbxCustomer.Properties.AutoCompleteDataManager = null;
            this.tbxCustomer.Properties.AutoCompleteDisplayFormater = null;
            this.tbxCustomer.Properties.AutocompleteMinimumTextLength = 2;
            this.tbxCustomer.Properties.AutoCompleteText = null;
            this.tbxCustomer.Properties.AutoCompleteWhereExpression = null;
            this.tbxCustomer.Properties.AutoCompleteWheretermFormater = null;
            this.tbxCustomer.Properties.AutoHeight = false;
            this.tbxCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("tbxCustomer.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13, "", null, null, true)});
            this.tbxCustomer.Properties.LookupPopup = null;
            this.tbxCustomer.Properties.NullText = "<<Choose...>>";
            this.tbxCustomer.Size = new System.Drawing.Size(274, 24);
            this.tbxCustomer.TabIndex = 5;
            this.tbxCustomer.ValidationRules = null;
            this.tbxCustomer.Value = null;
            // 
            // tbxPickupTime
            // 
            this.tbxPickupTime.EditValue = new System.DateTime(2014, 7, 8, 0, 0, 0, 0);
            this.tbxPickupTime.FieldLabel = null;
            this.tbxPickupTime.FormatDateTime = "HH:mm";
            this.tbxPickupTime.Location = new System.Drawing.Point(347, 29);
            this.tbxPickupTime.Name = "tbxPickupTime";
            this.tbxPickupTime.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPickupTime.Properties.AutoHeight = false;
            this.tbxPickupTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbxPickupTime.Properties.DisplayFormat.FormatString = "HH:mm";
            this.tbxPickupTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxPickupTime.Properties.EditFormat.FormatString = "HH:mm";
            this.tbxPickupTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tbxPickupTime.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.tbxPickupTime.Properties.Mask.EditMask = "HH:mm";
            this.tbxPickupTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tbxPickupTime.Properties.NullText = "00:00";
            this.tbxPickupTime.Size = new System.Drawing.Size(49, 24);
            this.tbxPickupTime.TabIndex = 4;
            this.tbxPickupTime.ValidationRules = null;
            this.tbxPickupTime.Value = new System.DateTime(((long)(0)));
            // 
            // ucPickedup
            // 
            this.ucPickedup.AutoSize = true;
            this.ucPickedup.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucPickedup.ForeColor = System.Drawing.Color.Black;
            this.ucPickedup.Icon = false;
            this.ucPickedup.Label = "Text";
            this.ucPickedup.Location = new System.Drawing.Point(451, 268);
            this.ucPickedup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucPickedup.Name = "ucPickedup";
            this.ucPickedup.Size = new System.Drawing.Size(80, 19);
            this.ucPickedup.TabIndex = 0;
            // 
            // ucConfirmed
            // 
            this.ucConfirmed.AutoSize = true;
            this.ucConfirmed.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucConfirmed.ForeColor = System.Drawing.Color.Black;
            this.ucConfirmed.Icon = false;
            this.ucConfirmed.Label = "Text";
            this.ucConfirmed.Location = new System.Drawing.Point(312, 268);
            this.ucConfirmed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucConfirmed.Name = "ucConfirmed";
            this.ucConfirmed.Size = new System.Drawing.Size(80, 19);
            this.ucConfirmed.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(266, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 17);
            this.label11.TabIndex = 48;
            this.label11.Text = "Pickup Time";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(266, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 17);
            this.label10.TabIndex = 46;
            this.label10.Text = "Employee";
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(30, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 17);
            this.label9.TabIndex = 44;
            this.label9.Text = "Messenger";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(30, 243);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 17);
            this.label8.TabIndex = 41;
            this.label8.Text = "Vehicle";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxNote
            // 
            this.tbxNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxNote.Capslock = true;
            this.tbxNote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxNote.FieldLabel = null;
            this.tbxNote.Location = new System.Drawing.Point(106, 214);
            this.tbxNote.Name = "tbxNote";
            this.tbxNote.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxNote.Size = new System.Drawing.Size(425, 24);
            this.tbxNote.TabIndex = 11;
            this.tbxNote.ValidationRules = null;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(30, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 39;
            this.label7.Text = "Note";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxContact
            // 
            this.tbxContact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxContact.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxContact.Capslock = true;
            this.tbxContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxContact.FieldLabel = null;
            this.tbxContact.Location = new System.Drawing.Point(358, 189);
            this.tbxContact.Name = "tbxContact";
            this.tbxContact.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxContact.Size = new System.Drawing.Size(173, 24);
            this.tbxContact.TabIndex = 10;
            this.tbxContact.ValidationRules = null;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(282, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 37;
            this.label6.Text = "Contact";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxPhone
            // 
            this.tbxPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxPhone.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxPhone.Capslock = true;
            this.tbxPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxPhone.FieldLabel = null;
            this.tbxPhone.Location = new System.Drawing.Point(106, 189);
            this.tbxPhone.Name = "tbxPhone";
            this.tbxPhone.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPhone.Size = new System.Drawing.Size(173, 24);
            this.tbxPhone.TabIndex = 9;
            this.tbxPhone.ValidationRules = null;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(30, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 35;
            this.label5.Text = "Phone";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxAddress
            // 
            this.tbxAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxAddress.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxAddress.Capslock = true;
            this.tbxAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxAddress.FieldLabel = null;
            this.tbxAddress.Location = new System.Drawing.Point(106, 164);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxAddress.Size = new System.Drawing.Size(425, 24);
            this.tbxAddress.TabIndex = 8;
            this.tbxAddress.ValidationRules = null;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(30, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 33;
            this.label4.Text = "Address";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(30, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "Pickup Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(30, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PickupOrderGrid
            // 
            this.PickupOrderGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PickupOrderGrid.Location = new System.Drawing.Point(0, 370);
            this.PickupOrderGrid.MainView = this.PickupOrderView;
            this.PickupOrderGrid.Name = "PickupOrderGrid";
            this.PickupOrderGrid.Size = new System.Drawing.Size(903, 160);
            this.PickupOrderGrid.TabIndex = 30;
            this.PickupOrderGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PickupOrderView});
            // 
            // PickupOrderView
            // 
            this.PickupOrderView.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.PickupOrderView.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Transparent;
            this.PickupOrderView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.PickupOrderView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Transparent;
            this.PickupOrderView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Transparent;
            this.PickupOrderView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.PickupOrderView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clNo,
            this.clDate,
            this.clTime,
            this.clPickup,
            this.clCustomer,
            this.clConf,
            this.clPU,
            this.clPUNote,
            this.clCancel,
            this.clPIC,
            this.clAddress,
            this.clCS,
            this.clPcs,
            this.clWt,
            this.clVehicle,
            this.clService,
            this.clNote,
            this.clKurir,
            this.clId});
            this.PickupOrderView.GridControl = this.PickupOrderGrid;
            this.PickupOrderView.Name = "PickupOrderView";
            this.PickupOrderView.OptionsView.ColumnAutoWidth = false;
            this.PickupOrderView.OptionsView.ShowGroupPanel = false;
            // 
            // clNo
            // 
            this.clNo.Caption = "No";
            this.clNo.Name = "clNo";
            this.clNo.OptionsColumn.AllowEdit = false;
            this.clNo.OptionsColumn.AllowFocus = false;
            this.clNo.OptionsColumn.ReadOnly = true;
            this.clNo.Visible = true;
            this.clNo.VisibleIndex = 0;
            this.clNo.Width = 27;
            // 
            // clDate
            // 
            this.clDate.Caption = "Date";
            this.clDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.clDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clDate.FieldName = "DateProcess";
            this.clDate.GroupFormat.FormatString = "dd-MM-yyyy";
            this.clDate.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clDate.Name = "clDate";
            this.clDate.OptionsColumn.AllowEdit = false;
            this.clDate.OptionsColumn.AllowFocus = false;
            this.clDate.OptionsColumn.FixedWidth = true;
            this.clDate.OptionsColumn.ReadOnly = true;
            this.clDate.Visible = true;
            this.clDate.VisibleIndex = 1;
            this.clDate.Width = 124;
            // 
            // clTime
            // 
            this.clTime.Caption = "Time";
            this.clTime.DisplayFormat.FormatString = "HH:mm";
            this.clTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clTime.FieldName = "DateProcess";
            this.clTime.GroupFormat.FormatString = "HH:mm";
            this.clTime.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clTime.Name = "clTime";
            this.clTime.OptionsColumn.AllowEdit = false;
            this.clTime.OptionsColumn.AllowFocus = false;
            this.clTime.OptionsColumn.FixedWidth = true;
            this.clTime.OptionsColumn.ReadOnly = true;
            this.clTime.Visible = true;
            this.clTime.VisibleIndex = 2;
            this.clTime.Width = 80;
            // 
            // clPickup
            // 
            this.clPickup.Caption = "Pickup";
            this.clPickup.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.clPickup.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clPickup.FieldName = "PickupDate";
            this.clPickup.GroupFormat.FormatString = "dd-MM-yyyy";
            this.clPickup.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clPickup.Name = "clPickup";
            this.clPickup.OptionsColumn.AllowEdit = false;
            this.clPickup.OptionsColumn.AllowFocus = false;
            this.clPickup.OptionsColumn.FixedWidth = true;
            this.clPickup.OptionsColumn.ReadOnly = true;
            this.clPickup.Visible = true;
            this.clPickup.VisibleIndex = 3;
            this.clPickup.Width = 120;
            // 
            // clCustomer
            // 
            this.clCustomer.Caption = "Customer/Franchise/Drop Point";
            this.clCustomer.FieldName = "CustomerName";
            this.clCustomer.Name = "clCustomer";
            this.clCustomer.OptionsColumn.AllowEdit = false;
            this.clCustomer.OptionsColumn.AllowFocus = false;
            this.clCustomer.OptionsColumn.FixedWidth = true;
            this.clCustomer.OptionsColumn.ReadOnly = true;
            this.clCustomer.Visible = true;
            this.clCustomer.VisibleIndex = 4;
            this.clCustomer.Width = 150;
            // 
            // clPIC
            // 
            this.clPIC.Caption = "PIC";
            this.clPIC.FieldName = "EmployeeName";
            this.clPIC.Name = "clPIC";
            this.clPIC.OptionsColumn.AllowEdit = false;
            this.clPIC.OptionsColumn.AllowFocus = false;
            this.clPIC.OptionsColumn.FixedWidth = true;
            this.clPIC.OptionsColumn.ReadOnly = true;
            this.clPIC.Visible = true;
            this.clPIC.VisibleIndex = 9;
            this.clPIC.Width = 150;
            // 
            // clAddress
            // 
            this.clAddress.Caption = "Address";
            this.clAddress.FieldName = "CustomerAddress";
            this.clAddress.Name = "clAddress";
            this.clAddress.OptionsColumn.AllowEdit = false;
            this.clAddress.OptionsColumn.AllowFocus = false;
            this.clAddress.OptionsColumn.FixedWidth = true;
            this.clAddress.OptionsColumn.ReadOnly = true;
            this.clAddress.Visible = true;
            this.clAddress.VisibleIndex = 10;
            this.clAddress.Width = 150;
            // 
            // clCS
            // 
            this.clCS.Caption = "CS";
            this.clCS.FieldName = "EmployeeName";
            this.clCS.Name = "clCS";
            this.clCS.OptionsColumn.AllowEdit = false;
            this.clCS.OptionsColumn.AllowFocus = false;
            this.clCS.OptionsColumn.FixedWidth = true;
            this.clCS.OptionsColumn.ReadOnly = true;
            this.clCS.Visible = true;
            this.clCS.VisibleIndex = 11;
            this.clCS.Width = 150;
            // 
            // clPcs
            // 
            this.clPcs.Caption = "Pcs";
            this.clPcs.FieldName = "TtlPiece";
            this.clPcs.Name = "clPcs";
            this.clPcs.OptionsColumn.AllowEdit = false;
            this.clPcs.OptionsColumn.AllowFocus = false;
            this.clPcs.OptionsColumn.FixedWidth = true;
            this.clPcs.OptionsColumn.ReadOnly = true;
            this.clPcs.Visible = true;
            this.clPcs.VisibleIndex = 12;
            this.clPcs.Width = 80;
            // 
            // clWt
            // 
            this.clWt.Caption = "Wt";
            this.clWt.FieldName = "TtlGrossWeight";
            this.clWt.Name = "clWt";
            this.clWt.OptionsColumn.AllowEdit = false;
            this.clWt.OptionsColumn.AllowFocus = false;
            this.clWt.OptionsColumn.FixedWidth = true;
            this.clWt.OptionsColumn.ReadOnly = true;
            this.clWt.Visible = true;
            this.clWt.VisibleIndex = 13;
            this.clWt.Width = 80;
            // 
            // clVehicle
            // 
            this.clVehicle.Caption = "Vehicle";
            this.clVehicle.FieldName = "VehicleTypeName";
            this.clVehicle.Name = "clVehicle";
            this.clVehicle.OptionsColumn.AllowEdit = false;
            this.clVehicle.OptionsColumn.AllowFocus = false;
            this.clVehicle.OptionsColumn.FixedWidth = true;
            this.clVehicle.OptionsColumn.ReadOnly = true;
            this.clVehicle.Visible = true;
            this.clVehicle.VisibleIndex = 14;
            this.clVehicle.Width = 120;
            // 
            // clService
            // 
            this.clService.Caption = "Service";
            this.clService.FieldName = "ServiceName";
            this.clService.Name = "clService";
            this.clService.OptionsColumn.AllowEdit = false;
            this.clService.OptionsColumn.AllowFocus = false;
            this.clService.OptionsColumn.FixedWidth = true;
            this.clService.OptionsColumn.ReadOnly = true;
            this.clService.Visible = true;
            this.clService.VisibleIndex = 15;
            this.clService.Width = 120;
            // 
            // clNote
            // 
            this.clNote.Caption = "Note";
            this.clNote.FieldName = "Note";
            this.clNote.Name = "clNote";
            this.clNote.OptionsColumn.AllowEdit = false;
            this.clNote.OptionsColumn.AllowFocus = false;
            this.clNote.OptionsColumn.FixedWidth = true;
            this.clNote.OptionsColumn.ReadOnly = true;
            this.clNote.Visible = true;
            this.clNote.VisibleIndex = 16;
            this.clNote.Width = 190;
            // 
            // clKurir
            // 
            this.clKurir.Caption = "Kurir";
            this.clKurir.FieldName = "MessengerName";
            this.clKurir.Name = "clKurir";
            this.clKurir.OptionsColumn.AllowEdit = false;
            this.clKurir.OptionsColumn.AllowFocus = false;
            this.clKurir.OptionsColumn.FixedWidth = true;
            this.clKurir.OptionsColumn.ReadOnly = true;
            this.clKurir.Visible = true;
            this.clKurir.VisibleIndex = 17;
            this.clKurir.Width = 147;
            // 
            // clConf
            // 
            this.clConf.Caption = "Conf";
            this.clConf.FieldName = "Confirmed";
            this.clConf.Name = "clConf";
            this.clConf.OptionsColumn.AllowEdit = false;
            this.clConf.OptionsColumn.AllowFocus = false;
            this.clConf.OptionsColumn.FixedWidth = true;
            this.clConf.OptionsColumn.ReadOnly = true;
            this.clConf.Visible = true;
            this.clConf.VisibleIndex = 5;
            this.clConf.Width = 36;
            // 
            // clPU
            // 
            this.clPU.Caption = "PU";
            this.clPU.FieldName = "PickedUp";
            this.clPU.Name = "clPU";
            this.clPU.OptionsColumn.AllowEdit = false;
            this.clPU.OptionsColumn.AllowFocus = false;
            this.clPU.OptionsColumn.FixedWidth = true;
            this.clPU.OptionsColumn.ReadOnly = true;
            this.clPU.Visible = true;
            this.clPU.VisibleIndex = 6;
            this.clPU.Width = 28;
            // 
            // clPUNote
            // 
            this.clPUNote.Caption = "PU Note";
            this.clPUNote.FieldName = "PickupNote";
            this.clPUNote.Name = "clPUNote";
            this.clPUNote.OptionsColumn.AllowEdit = false;
            this.clPUNote.OptionsColumn.AllowFocus = false;
            this.clPUNote.OptionsColumn.FixedWidth = true;
            this.clPUNote.OptionsColumn.ReadOnly = true;
            this.clPUNote.Visible = true;
            this.clPUNote.VisibleIndex = 7;
            this.clPUNote.Width = 90;
            // 
            // clCancel
            // 
            this.clCancel.Caption = "Cancel";
            this.clCancel.FieldName = "Cancelled";
            this.clCancel.Name = "clCancel";
            this.clCancel.OptionsColumn.AllowEdit = false;
            this.clCancel.OptionsColumn.AllowFocus = false;
            this.clCancel.OptionsColumn.ReadOnly = true;
            this.clCancel.Visible = true;
            this.clCancel.VisibleIndex = 8;
            this.clCancel.Width = 49;
            // 
            // clId
            // 
            this.clId.Caption = "Id";
            this.clId.FieldName = "Id";
            this.clId.Name = "clId";
            this.clId.OptionsColumn.AllowMove = false;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.Green;
            this.label23.Location = new System.Drawing.Point(12, 538);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(104, 17);
            this.label23.TabIndex = 31;
            this.label23.Text = "Sudah Penjaluran";
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(128, 538);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(104, 17);
            this.label24.TabIndex = 32;
            this.label24.Text = "Belum Penjaluran";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(248, 538);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 33;
            this.label3.Text = "Sudah Pickup";
            // 
            // PickupOrderForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(903, 562);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.PickupOrderGrid);
            this.Controls.Add(this.pnlBlue);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlPink);
            this.Controls.Add(this.pnlGreen);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "PickupOrderForm";
            this.Text = "Customer Service - Pick Up Order";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.pnlGreen, 0);
            this.Controls.SetChildIndex(this.pnlPink, 0);
            this.Controls.SetChildIndex(this.pnlSearch, 0);
            this.Controls.SetChildIndex(this.pnlBlue, 0);
            this.Controls.SetChildIndex(this.PickupOrderGrid, 0);
            this.Controls.SetChildIndex(this.label23, 0);
            this.Controls.SetChildIndex(this.label24, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.pnlGreen.ResumeLayout(false);
            this.pnlGreen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPayment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxService.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPackage.Properties)).EndInit();
            this.pnlPink.ResumeLayout(false);
            this.pnlPink.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxGrandTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPiece.Properties)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFilterDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFilterDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFilterMessenger.Properties)).EndInit();
            this.pnlBlue.ResumeLayout(false);
            this.pnlBlue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDropPoint.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFranchise.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPickupDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPickupDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxMessenger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxVehicle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPickupTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickupOrderGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickupOrderView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlGreen;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel pnlPink;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox cbxCancelled;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label label20;
        private Common.Component.dTextBox tbxIsi;
        private Common.Component.dTextBox tbxDimensi;
        private System.Windows.Forms.Panel pnlBlue;
        private Common.UserControls.ucIconYesNo ucPickedup;
        private Common.UserControls.ucIconYesNo ucConfirmed;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Common.Component.dTextBox tbxNote;
        private System.Windows.Forms.Label label7;
        private Common.Component.dTextBox tbxContact;
        private System.Windows.Forms.Label label6;
        private Common.Component.dTextBox tbxPhone;
        private System.Windows.Forms.Label label5;
        private Common.Component.dTextBox tbxAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxFilterShow;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.GridControl PickupOrderGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView PickupOrderView;
        private DevExpress.XtraGrid.Columns.GridColumn clDate;
        private DevExpress.XtraGrid.Columns.GridColumn clTime;
        private DevExpress.XtraGrid.Columns.GridColumn clPickup;
        private DevExpress.XtraGrid.Columns.GridColumn clCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn clPIC;
        private DevExpress.XtraGrid.Columns.GridColumn clAddress;
        private DevExpress.XtraGrid.Columns.GridColumn clCS;
        private DevExpress.XtraGrid.Columns.GridColumn clPcs;
        private DevExpress.XtraGrid.Columns.GridColumn clWt;
        private DevExpress.XtraGrid.Columns.GridColumn clVehicle;
        private DevExpress.XtraGrid.Columns.GridColumn clService;
        private DevExpress.XtraGrid.Columns.GridColumn clNote;
        private DevExpress.XtraGrid.Columns.GridColumn clKurir;
        private DevExpress.XtraGrid.Columns.GridColumn clConf;
        private DevExpress.XtraGrid.Columns.GridColumn clPU;
        private DevExpress.XtraGrid.Columns.GridColumn clPUNote;
        private Common.Component.dTime tbxPickupTime;
        private Common.Component.dTextBoxNumber tbxGrandTotal;
        private Common.Component.dTextBoxNumber tbxWeight;
        private Common.Component.dLookup tbxCustomer;
        private Common.Component.dLookup tbxPackage;
        private Common.Component.dLookup tbxMessenger;
        private Common.Component.dLookup tbxVehicle;
        private Common.Component.dLookup tbxPayment;
        private Common.Component.dLookup tbxService;
        private Common.Component.dLookup tbxFilterMessenger;
        private Common.Component.dCalendar tbxPickupDate;
        private Common.Component.dCalendar tbxDate;
        private Common.Component.dLookup tbxEmployee;
        private Common.Component.dCalendar tbxFilterDate;
        private DevExpress.XtraGrid.Columns.GridColumn clNo;
        private DevExpress.XtraGrid.Columns.GridColumn clCancel;
        private DevExpress.XtraGrid.Columns.GridColumn clId;
        private System.Windows.Forms.CheckBox cbxNew;
        private Common.Component.dTextBoxNumber tbxPiece;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private Common.Component.dLookup lkpDropPoint;
        private Common.Component.dLookup lkpFranchise;
        private System.Windows.Forms.RadioButton rbDropPoint;
        private System.Windows.Forms.RadioButton rbFranchise;
        private System.Windows.Forms.RadioButton rbCustomer;
        private System.Windows.Forms.Label label3;
    }
}