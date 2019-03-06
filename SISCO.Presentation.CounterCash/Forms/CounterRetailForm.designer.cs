using System;
using System.Windows.Forms;
using SISCO.Presentation.Common.Component;

namespace SISCO.Presentation.CounterCash.Forms
{
    public partial class CounterRetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CounterRetailForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lkpMessenger = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpPaymentMethod = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpServiceType = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpPackageType = new SISCO.Presentation.Common.Component.dLookup();
            this.label22 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNatureOfGoods = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtNote = new SISCO.Presentation.Common.Component.dTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtConsigneeName = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtConsigneeAddress = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtConsigneePhone = new SISCO.Presentation.Common.Component.dTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtShipperName = new SISCO.Presentation.Common.Component.dTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtShipperAddress = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtShipperRef = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtShipperPhone = new SISCO.Presentation.Common.Component.dTextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label30 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtDiscountTotal = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.txtHandlingFee = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtTariffNet = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.txtTariffTotal = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.txtDiscount = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.txtTariffPerKg = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.pnlTotalAndAction = new System.Windows.Forms.Panel();
            this.btnRefreshTariff = new System.Windows.Forms.Button();
            this.chkPrintBarcode = new SISCO.Presentation.Common.Component.dCheckBox();
            this.chkPrintContinuous = new SISCO.Presentation.Common.Component.dCheckBox();
            this.chkPrintOrder = new SISCO.Presentation.Common.Component.dCheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.txtGrandTotal = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cbxPacking = new SISCO.Presentation.Common.Component.dCheckBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txtInsuranceFee = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.txtGoodsValue = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.txtOtherFee = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label35 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtPackingFee = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.tbxH = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label36 = new System.Windows.Forms.Label();
            this.tbxW = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxL = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label19 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtTotalWeight = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.label26 = new System.Windows.Forms.Label();
            this.txtChargeable = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.txtTotalPiece = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.pnlShipmentInfo = new System.Windows.Forms.Panel();
            this.lkpBranch = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpDestinationCity = new SISCO.Presentation.Common.Component.dLookup();
            this.lkpOriginCity = new SISCO.Presentation.Common.Component.dLookup();
            this.txtDate = new SISCO.Presentation.Common.Component.dCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.chkRA = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtShipmentNo = new SISCO.Presentation.Common.Component.dTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label31 = new System.Windows.Forms.Label();
            this.tbxPromo = new SISCO.Presentation.Common.Component.dTextBox();
            this.cbxMobilePoint = new SISCO.Presentation.Common.Component.dCheckBox();
            this.tbxEmailPoint = new SISCO.Presentation.Common.Component.dTextBox();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpMessenger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPaymentMethod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpServiceType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPackageType.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHandlingFee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTariffNet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTariffTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTariffPerKg.Properties)).BeginInit();
            this.pnlTotalAndAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrandTotal.Properties)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsuranceFee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoodsValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherFee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackingFee.Properties)).BeginInit();
            this.panel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChargeable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPiece.Properties)).BeginInit();
            this.pnlShipmentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestinationCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpOriginCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SandyBrown;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lkpMessenger);
            this.panel4.Controls.Add(this.lkpPaymentMethod);
            this.panel4.Controls.Add(this.lkpServiceType);
            this.panel4.Controls.Add(this.lkpPackageType);
            this.panel4.Controls.Add(this.label22);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.txtNatureOfGoods);
            this.panel4.Controls.Add(this.txtNote);
            this.panel4.Location = new System.Drawing.Point(3, 357);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(516, 157);
            this.panel4.TabIndex = 54;
            // 
            // lkpMessenger
            // 
            this.lkpMessenger.AutoCompleteDataManager = null;
            this.lkpMessenger.AutoCompleteDisplayFormater = null;
            this.lkpMessenger.AutoCompleteInitialized = false;
            this.lkpMessenger.AutocompleteMinimumTextLength = 0;
            this.lkpMessenger.AutoCompleteText = null;
            this.lkpMessenger.AutoCompleteWhereExpression = null;
            this.lkpMessenger.AutoCompleteWheretermFormater = null;
            this.lkpMessenger.ClearOnLeave = true;
            this.lkpMessenger.DisplayString = null;
            this.lkpMessenger.FieldLabel = null;
            this.lkpMessenger.Location = new System.Drawing.Point(107, 78);
            this.lkpMessenger.LookupPopup = null;
            this.lkpMessenger.Name = "lkpMessenger";
            this.lkpMessenger.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpMessenger.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkpMessenger.Properties.Appearance.Options.UseFont = true;
            this.lkpMessenger.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpMessenger.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpMessenger.Properties.AutoCompleteDataManager = null;
            this.lkpMessenger.Properties.AutoCompleteDisplayFormater = null;
            this.lkpMessenger.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpMessenger.Properties.AutoCompleteText = null;
            this.lkpMessenger.Properties.AutoCompleteWhereExpression = null;
            this.lkpMessenger.Properties.AutoCompleteWheretermFormater = null;
            this.lkpMessenger.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lkpMessenger.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("lkpMessenger.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpMessenger.Properties.LookupPopup = null;
            this.lkpMessenger.Properties.NullText = "<<Choose...>>";
            this.lkpMessenger.Size = new System.Drawing.Size(255, 24);
            this.lkpMessenger.TabIndex = 16;
            this.lkpMessenger.ValidationRules = null;
            this.lkpMessenger.Value = null;
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
            this.lkpPaymentMethod.Location = new System.Drawing.Point(107, 53);
            this.lkpPaymentMethod.LookupPopup = null;
            this.lkpPaymentMethod.Name = "lkpPaymentMethod";
            this.lkpPaymentMethod.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpPaymentMethod.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkpPaymentMethod.Properties.Appearance.Options.UseFont = true;
            this.lkpPaymentMethod.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpPaymentMethod.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpPaymentMethod.Properties.AutoCompleteDataManager = null;
            this.lkpPaymentMethod.Properties.AutoCompleteDisplayFormater = null;
            this.lkpPaymentMethod.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpPaymentMethod.Properties.AutoCompleteText = null;
            this.lkpPaymentMethod.Properties.AutoCompleteWhereExpression = null;
            this.lkpPaymentMethod.Properties.AutoCompleteWheretermFormater = null;
            this.lkpPaymentMethod.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lkpPaymentMethod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("lkpPaymentMethod.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpPaymentMethod.Properties.LookupPopup = null;
            this.lkpPaymentMethod.Properties.NullText = "<<Choose...>>";
            this.lkpPaymentMethod.Size = new System.Drawing.Size(255, 24);
            this.lkpPaymentMethod.TabIndex = 15;
            this.lkpPaymentMethod.ValidationRules = null;
            this.lkpPaymentMethod.Value = null;
            // 
            // lkpServiceType
            // 
            this.lkpServiceType.AutoCompleteDataManager = null;
            this.lkpServiceType.AutoCompleteDisplayFormater = null;
            this.lkpServiceType.AutoCompleteInitialized = false;
            this.lkpServiceType.AutocompleteMinimumTextLength = 0;
            this.lkpServiceType.AutoCompleteText = null;
            this.lkpServiceType.AutoCompleteWhereExpression = null;
            this.lkpServiceType.AutoCompleteWheretermFormater = null;
            this.lkpServiceType.ClearOnLeave = true;
            this.lkpServiceType.DisplayString = null;
            this.lkpServiceType.FieldLabel = null;
            this.lkpServiceType.Location = new System.Drawing.Point(107, 28);
            this.lkpServiceType.LookupPopup = null;
            this.lkpServiceType.Name = "lkpServiceType";
            this.lkpServiceType.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpServiceType.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkpServiceType.Properties.Appearance.Options.UseFont = true;
            this.lkpServiceType.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpServiceType.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpServiceType.Properties.AutoCompleteDataManager = null;
            this.lkpServiceType.Properties.AutoCompleteDisplayFormater = null;
            this.lkpServiceType.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpServiceType.Properties.AutoCompleteText = null;
            this.lkpServiceType.Properties.AutoCompleteWhereExpression = null;
            this.lkpServiceType.Properties.AutoCompleteWheretermFormater = null;
            this.lkpServiceType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lkpServiceType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("lkpServiceType.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.lkpServiceType.Properties.LookupPopup = null;
            this.lkpServiceType.Properties.NullText = "<<Choose...>>";
            this.lkpServiceType.Size = new System.Drawing.Size(255, 24);
            this.lkpServiceType.TabIndex = 14;
            this.lkpServiceType.ValidationRules = null;
            this.lkpServiceType.Value = null;
            this.lkpServiceType.Leave += new System.EventHandler(this.lkpServiceType_EditValueChanged);
            // 
            // lkpPackageType
            // 
            this.lkpPackageType.AutoCompleteDataManager = null;
            this.lkpPackageType.AutoCompleteDisplayFormater = null;
            this.lkpPackageType.AutoCompleteInitialized = false;
            this.lkpPackageType.AutocompleteMinimumTextLength = 0;
            this.lkpPackageType.AutoCompleteText = null;
            this.lkpPackageType.AutoCompleteWhereExpression = null;
            this.lkpPackageType.AutoCompleteWheretermFormater = null;
            this.lkpPackageType.ClearOnLeave = true;
            this.lkpPackageType.DisplayString = null;
            this.lkpPackageType.FieldLabel = null;
            this.lkpPackageType.Location = new System.Drawing.Point(107, 3);
            this.lkpPackageType.LookupPopup = null;
            this.lkpPackageType.Name = "lkpPackageType";
            this.lkpPackageType.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpPackageType.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkpPackageType.Properties.Appearance.Options.UseFont = true;
            this.lkpPackageType.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpPackageType.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpPackageType.Properties.AutoCompleteDataManager = null;
            this.lkpPackageType.Properties.AutoCompleteDisplayFormater = null;
            this.lkpPackageType.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpPackageType.Properties.AutoCompleteText = null;
            this.lkpPackageType.Properties.AutoCompleteWhereExpression = null;
            this.lkpPackageType.Properties.AutoCompleteWheretermFormater = null;
            this.lkpPackageType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lkpPackageType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("lkpPackageType.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.lkpPackageType.Properties.LookupPopup = null;
            this.lkpPackageType.Properties.NullText = "<<Choose...>>";
            this.lkpPackageType.Size = new System.Drawing.Size(255, 24);
            this.lkpPackageType.TabIndex = 13;
            this.lkpPackageType.ValidationRules = null;
            this.lkpPackageType.Value = null;
            this.lkpPackageType.Leave += new System.EventHandler(this.lkpPackageType_EditValueChanged);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(3, 131);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(99, 17);
            this.label22.TabIndex = 112;
            this.label22.Text = "Note";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(3, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 17);
            this.label12.TabIndex = 112;
            this.label12.Text = "Payment Method";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(3, 81);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(99, 17);
            this.label21.TabIndex = 113;
            this.label21.Text = "Messenger";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(3, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(99, 17);
            this.label17.TabIndex = 113;
            this.label17.Text = "Package Type";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(3, 106);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(99, 17);
            this.label20.TabIndex = 108;
            this.label20.Text = "Nature of Goods";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(3, 31);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 17);
            this.label18.TabIndex = 108;
            this.label18.Text = "Service Type";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNatureOfGoods
            // 
            this.txtNatureOfGoods.Capslock = true;
            this.txtNatureOfGoods.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNatureOfGoods.FieldLabel = null;
            this.txtNatureOfGoods.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNatureOfGoods.Location = new System.Drawing.Point(107, 103);
            this.txtNatureOfGoods.Name = "txtNatureOfGoods";
            this.txtNatureOfGoods.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtNatureOfGoods.Size = new System.Drawing.Size(398, 24);
            this.txtNatureOfGoods.TabIndex = 17;
            this.txtNatureOfGoods.ValidationRules = null;
            // 
            // txtNote
            // 
            this.txtNote.Capslock = true;
            this.txtNote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNote.FieldLabel = null;
            this.txtNote.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(107, 128);
            this.txtNote.Name = "txtNote";
            this.txtNote.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtNote.Size = new System.Drawing.Size(398, 24);
            this.txtNote.TabIndex = 18;
            this.txtNote.ValidationRules = null;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.txtConsigneeName);
            this.panel3.Controls.Add(this.txtConsigneeAddress);
            this.panel3.Controls.Add(this.txtConsigneePhone);
            this.panel3.Location = new System.Drawing.Point(3, 253);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(516, 103);
            this.panel3.TabIndex = 53;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(52, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 17);
            this.label13.TabIndex = 112;
            this.label13.Text = "Phone";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(52, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 17);
            this.label14.TabIndex = 113;
            this.label14.Text = "Name";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(52, 53);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 17);
            this.label15.TabIndex = 108;
            this.label15.Text = "Address";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(104, 5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 17);
            this.label16.TabIndex = 109;
            this.label16.Text = "Consignee";
            // 
            // txtConsigneeName
            // 
            this.txtConsigneeName.Capslock = true;
            this.txtConsigneeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConsigneeName.FieldLabel = null;
            this.txtConsigneeName.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsigneeName.Location = new System.Drawing.Point(107, 25);
            this.txtConsigneeName.Name = "txtConsigneeName";
            this.txtConsigneeName.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtConsigneeName.Size = new System.Drawing.Size(255, 24);
            this.txtConsigneeName.TabIndex = 10;
            this.txtConsigneeName.ValidationRules = null;
            // 
            // txtConsigneeAddress
            // 
            this.txtConsigneeAddress.Capslock = true;
            this.txtConsigneeAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConsigneeAddress.FieldLabel = null;
            this.txtConsigneeAddress.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsigneeAddress.Location = new System.Drawing.Point(107, 50);
            this.txtConsigneeAddress.Name = "txtConsigneeAddress";
            this.txtConsigneeAddress.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtConsigneeAddress.Size = new System.Drawing.Size(398, 24);
            this.txtConsigneeAddress.TabIndex = 11;
            this.txtConsigneeAddress.ValidationRules = null;
            // 
            // txtConsigneePhone
            // 
            this.txtConsigneePhone.Capslock = true;
            this.txtConsigneePhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConsigneePhone.FieldLabel = null;
            this.txtConsigneePhone.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsigneePhone.Location = new System.Drawing.Point(107, 75);
            this.txtConsigneePhone.Name = "txtConsigneePhone";
            this.txtConsigneePhone.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtConsigneePhone.Size = new System.Drawing.Size(174, 24);
            this.txtConsigneePhone.TabIndex = 12;
            this.txtConsigneePhone.ValidationRules = null;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtShipperName);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtShipperAddress);
            this.panel2.Controls.Add(this.txtShipperRef);
            this.panel2.Controls.Add(this.txtShipperPhone);
            this.panel2.Location = new System.Drawing.Point(3, 148);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(516, 104);
            this.panel2.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(330, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 17);
            this.label6.TabIndex = 111;
            this.label6.Text = "Ref";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(52, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 17);
            this.label7.TabIndex = 112;
            this.label7.Text = "Phone";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(52, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 17);
            this.label8.TabIndex = 113;
            this.label8.Text = "Name";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(52, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 17);
            this.label9.TabIndex = 108;
            this.label9.Text = "Address";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtShipperName
            // 
            this.txtShipperName.Capslock = true;
            this.txtShipperName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipperName.FieldLabel = null;
            this.txtShipperName.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShipperName.Location = new System.Drawing.Point(107, 25);
            this.txtShipperName.Name = "txtShipperName";
            this.txtShipperName.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtShipperName.Size = new System.Drawing.Size(255, 24);
            this.txtShipperName.TabIndex = 6;
            this.txtShipperName.ValidationRules = null;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(104, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 17);
            this.label10.TabIndex = 109;
            this.label10.Text = "Shipper";
            // 
            // txtShipperAddress
            // 
            this.txtShipperAddress.Capslock = true;
            this.txtShipperAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipperAddress.FieldLabel = null;
            this.txtShipperAddress.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShipperAddress.Location = new System.Drawing.Point(107, 50);
            this.txtShipperAddress.Name = "txtShipperAddress";
            this.txtShipperAddress.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtShipperAddress.Size = new System.Drawing.Size(398, 24);
            this.txtShipperAddress.TabIndex = 7;
            this.txtShipperAddress.ValidationRules = null;
            // 
            // txtShipperRef
            // 
            this.txtShipperRef.Capslock = true;
            this.txtShipperRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipperRef.FieldLabel = null;
            this.txtShipperRef.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShipperRef.Location = new System.Drawing.Point(362, 75);
            this.txtShipperRef.Name = "txtShipperRef";
            this.txtShipperRef.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtShipperRef.Size = new System.Drawing.Size(143, 24);
            this.txtShipperRef.TabIndex = 9;
            this.txtShipperRef.ValidationRules = null;
            // 
            // txtShipperPhone
            // 
            this.txtShipperPhone.Capslock = true;
            this.txtShipperPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipperPhone.FieldLabel = null;
            this.txtShipperPhone.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShipperPhone.Location = new System.Drawing.Point(107, 75);
            this.txtShipperPhone.Name = "txtShipperPhone";
            this.txtShipperPhone.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtShipperPhone.Size = new System.Drawing.Size(174, 24);
            this.txtShipperPhone.TabIndex = 8;
            this.txtShipperPhone.ValidationRules = null;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label30);
            this.panel6.Controls.Add(this.label23);
            this.panel6.Controls.Add(this.label29);
            this.panel6.Controls.Add(this.label25);
            this.panel6.Controls.Add(this.txtDiscountTotal);
            this.panel6.Controls.Add(this.txtHandlingFee);
            this.panel6.Controls.Add(this.label28);
            this.panel6.Controls.Add(this.label27);
            this.panel6.Controls.Add(this.txtTariffNet);
            this.panel6.Controls.Add(this.txtTariffTotal);
            this.panel6.Controls.Add(this.txtDiscount);
            this.panel6.Controls.Add(this.txtTariffPerKg);
            this.panel6.Location = new System.Drawing.Point(709, 40);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(219, 161);
            this.panel6.TabIndex = 56;
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(7, 83);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(85, 17);
            this.label30.TabIndex = 106;
            this.label30.Text = "Discount";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(7, 6);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(85, 17);
            this.label23.TabIndex = 106;
            this.label23.Text = "Tariff (/kg)";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(7, 108);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(85, 17);
            this.label29.TabIndex = 106;
            this.label29.Text = "Discount Total";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(7, 31);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(85, 17);
            this.label25.TabIndex = 106;
            this.label25.Text = "Handling Fee";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDiscountTotal
            // 
            this.txtDiscountTotal.EditMask = "###,###,###,###,###,##0.00";
            this.txtDiscountTotal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDiscountTotal.FieldLabel = null;
            this.txtDiscountTotal.Location = new System.Drawing.Point(98, 105);
            this.txtDiscountTotal.Name = "txtDiscountTotal";
            this.txtDiscountTotal.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDiscountTotal.Properties.AllowMouseWheel = false;
            this.txtDiscountTotal.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountTotal.Properties.Appearance.Options.UseFont = true;
            this.txtDiscountTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDiscountTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtDiscountTotal.Properties.Mask.BeepOnError = true;
            this.txtDiscountTotal.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtDiscountTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDiscountTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDiscountTotal.ReadOnly = false;
            this.txtDiscountTotal.Size = new System.Drawing.Size(110, 24);
            this.txtDiscountTotal.TabIndex = 29;
            this.txtDiscountTotal.TextAlign = null;
            this.txtDiscountTotal.ValidationRules = null;
            this.txtDiscountTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtHandlingFee
            // 
            this.txtHandlingFee.EditMask = "###,###,###,###,###,##0.00";
            this.txtHandlingFee.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtHandlingFee.FieldLabel = null;
            this.txtHandlingFee.Location = new System.Drawing.Point(98, 28);
            this.txtHandlingFee.Name = "txtHandlingFee";
            this.txtHandlingFee.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtHandlingFee.Properties.AllowMouseWheel = false;
            this.txtHandlingFee.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHandlingFee.Properties.Appearance.Options.UseFont = true;
            this.txtHandlingFee.Properties.Appearance.Options.UseTextOptions = true;
            this.txtHandlingFee.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtHandlingFee.Properties.Mask.BeepOnError = true;
            this.txtHandlingFee.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtHandlingFee.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtHandlingFee.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtHandlingFee.ReadOnly = false;
            this.txtHandlingFee.Size = new System.Drawing.Size(110, 24);
            this.txtHandlingFee.TabIndex = 26;
            this.txtHandlingFee.TextAlign = null;
            this.txtHandlingFee.ValidationRules = null;
            this.txtHandlingFee.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(7, 135);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(85, 17);
            this.label28.TabIndex = 106;
            this.label28.Text = "Tariff Net";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(7, 56);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(85, 17);
            this.label27.TabIndex = 106;
            this.label27.Text = "Tariff Total";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTariffNet
            // 
            this.txtTariffNet.EditMask = "###,###,###,###,###,##0.00";
            this.txtTariffNet.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTariffNet.FieldLabel = null;
            this.txtTariffNet.Location = new System.Drawing.Point(98, 132);
            this.txtTariffNet.Name = "txtTariffNet";
            this.txtTariffNet.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtTariffNet.Properties.AllowMouseWheel = false;
            this.txtTariffNet.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTariffNet.Properties.Appearance.Options.UseFont = true;
            this.txtTariffNet.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTariffNet.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTariffNet.Properties.Mask.BeepOnError = true;
            this.txtTariffNet.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtTariffNet.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTariffNet.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTariffNet.ReadOnly = false;
            this.txtTariffNet.Size = new System.Drawing.Size(110, 24);
            this.txtTariffNet.TabIndex = 30;
            this.txtTariffNet.TextAlign = null;
            this.txtTariffNet.ValidationRules = null;
            this.txtTariffNet.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtTariffTotal
            // 
            this.txtTariffTotal.EditMask = "###,###,###,###,###,##0.00";
            this.txtTariffTotal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTariffTotal.FieldLabel = null;
            this.txtTariffTotal.Location = new System.Drawing.Point(98, 53);
            this.txtTariffTotal.Name = "txtTariffTotal";
            this.txtTariffTotal.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtTariffTotal.Properties.AllowMouseWheel = false;
            this.txtTariffTotal.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTariffTotal.Properties.Appearance.Options.UseFont = true;
            this.txtTariffTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTariffTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTariffTotal.Properties.Mask.BeepOnError = true;
            this.txtTariffTotal.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtTariffTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTariffTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTariffTotal.ReadOnly = false;
            this.txtTariffTotal.Size = new System.Drawing.Size(110, 24);
            this.txtTariffTotal.TabIndex = 27;
            this.txtTariffTotal.TextAlign = null;
            this.txtTariffTotal.ValidationRules = null;
            this.txtTariffTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtDiscount
            // 
            this.txtDiscount.EditMask = "###,###,###,###,###,##0.00";
            this.txtDiscount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDiscount.FieldLabel = null;
            this.txtDiscount.Location = new System.Drawing.Point(98, 80);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDiscount.Properties.AllowMouseWheel = false;
            this.txtDiscount.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Properties.Appearance.Options.UseFont = true;
            this.txtDiscount.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDiscount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtDiscount.Properties.Mask.BeepOnError = true;
            this.txtDiscount.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtDiscount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDiscount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDiscount.ReadOnly = false;
            this.txtDiscount.Size = new System.Drawing.Size(110, 24);
            this.txtDiscount.TabIndex = 28;
            this.txtDiscount.TextAlign = null;
            this.txtDiscount.ValidationRules = null;
            this.txtDiscount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtTariffPerKg
            // 
            this.txtTariffPerKg.EditMask = "###,###,###,###,###,##0.00";
            this.txtTariffPerKg.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTariffPerKg.FieldLabel = null;
            this.txtTariffPerKg.Location = new System.Drawing.Point(98, 3);
            this.txtTariffPerKg.Name = "txtTariffPerKg";
            this.txtTariffPerKg.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtTariffPerKg.Properties.AllowMouseWheel = false;
            this.txtTariffPerKg.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTariffPerKg.Properties.Appearance.Options.UseFont = true;
            this.txtTariffPerKg.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTariffPerKg.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTariffPerKg.Properties.Mask.BeepOnError = true;
            this.txtTariffPerKg.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtTariffPerKg.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTariffPerKg.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTariffPerKg.ReadOnly = false;
            this.txtTariffPerKg.Size = new System.Drawing.Size(110, 24);
            this.txtTariffPerKg.TabIndex = 25;
            this.txtTariffPerKg.TextAlign = null;
            this.txtTariffPerKg.ValidationRules = null;
            this.txtTariffPerKg.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // pnlTotalAndAction
            // 
            this.pnlTotalAndAction.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTotalAndAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTotalAndAction.Controls.Add(this.btnRefreshTariff);
            this.pnlTotalAndAction.Controls.Add(this.chkPrintBarcode);
            this.pnlTotalAndAction.Controls.Add(this.chkPrintContinuous);
            this.pnlTotalAndAction.Controls.Add(this.chkPrintOrder);
            this.pnlTotalAndAction.Controls.Add(this.btnSave);
            this.pnlTotalAndAction.Controls.Add(this.label34);
            this.pnlTotalAndAction.Controls.Add(this.txtGrandTotal);
            this.pnlTotalAndAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTotalAndAction.Location = new System.Drawing.Point(521, 381);
            this.pnlTotalAndAction.Name = "pnlTotalAndAction";
            this.pnlTotalAndAction.Size = new System.Drawing.Size(407, 133);
            this.pnlTotalAndAction.TabIndex = 58;
            // 
            // btnRefreshTariff
            // 
            this.btnRefreshTariff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefreshTariff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshTariff.Image = global::SISCO.Presentation.CounterCash.Properties.Resources.Icon_Refresh_Small;
            this.btnRefreshTariff.Location = new System.Drawing.Point(131, 13);
            this.btnRefreshTariff.Name = "btnRefreshTariff";
            this.btnRefreshTariff.Size = new System.Drawing.Size(24, 24);
            this.btnRefreshTariff.TabIndex = 140;
            this.btnRefreshTariff.UseVisualStyleBackColor = true;
            this.btnRefreshTariff.Click += new System.EventHandler(this.btnRefreshTariff_Click);
            // 
            // chkPrintBarcode
            // 
            this.chkPrintBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkPrintBarcode.AutoSize = true;
            this.chkPrintBarcode.FieldLabel = null;
            this.chkPrintBarcode.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrintBarcode.ForeColor = System.Drawing.Color.Black;
            this.chkPrintBarcode.Location = new System.Drawing.Point(103, 105);
            this.chkPrintBarcode.Name = "chkPrintBarcode";
            this.chkPrintBarcode.Size = new System.Drawing.Size(101, 21);
            this.chkPrintBarcode.TabIndex = 138;
            this.chkPrintBarcode.Text = "Print Barcode";
            this.chkPrintBarcode.UseVisualStyleBackColor = true;
            this.chkPrintBarcode.ValidationRules = null;
            // 
            // chkPrintContinuous
            // 
            this.chkPrintContinuous.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkPrintContinuous.AutoSize = true;
            this.chkPrintContinuous.FieldLabel = null;
            this.chkPrintContinuous.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrintContinuous.ForeColor = System.Drawing.Color.Black;
            this.chkPrintContinuous.Location = new System.Drawing.Point(129, 79);
            this.chkPrintContinuous.Name = "chkPrintContinuous";
            this.chkPrintContinuous.Size = new System.Drawing.Size(88, 21);
            this.chkPrintContinuous.TabIndex = 137;
            this.chkPrintContinuous.Text = "Continuous";
            this.chkPrintContinuous.UseVisualStyleBackColor = true;
            this.chkPrintContinuous.ValidationRules = null;
            // 
            // chkPrintOrder
            // 
            this.chkPrintOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkPrintOrder.AutoSize = true;
            this.chkPrintOrder.FieldLabel = null;
            this.chkPrintOrder.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrintOrder.ForeColor = System.Drawing.Color.Black;
            this.chkPrintOrder.Location = new System.Drawing.Point(103, 55);
            this.chkPrintOrder.Name = "chkPrintOrder";
            this.chkPrintOrder.Size = new System.Drawing.Size(88, 21);
            this.chkPrintOrder.TabIndex = 136;
            this.chkPrintOrder.Text = "Print Order";
            this.chkPrintOrder.UseVisualStyleBackColor = true;
            this.chkPrintOrder.ValidationRules = null;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Font = new System.Drawing.Font("Meiryo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(269, 56);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 67);
            this.btnSave.TabIndex = 40;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Meiryo", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.Black;
            this.label34.Location = new System.Drawing.Point(24, 14);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(101, 23);
            this.label34.TabIndex = 106;
            this.label34.Text = "Grand Total";
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtGrandTotal.EditMask = "###,###,###,###,###,##0.00";
            this.txtGrandTotal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtGrandTotal.FieldLabel = null;
            this.txtGrandTotal.Location = new System.Drawing.Point(161, 15);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtGrandTotal.Properties.AllowMouseWheel = false;
            this.txtGrandTotal.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrandTotal.Properties.Appearance.Options.UseFont = true;
            this.txtGrandTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.txtGrandTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtGrandTotal.Properties.Mask.BeepOnError = true;
            this.txtGrandTotal.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtGrandTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGrandTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtGrandTotal.ReadOnly = false;
            this.txtGrandTotal.Size = new System.Drawing.Size(235, 24);
            this.txtGrandTotal.TabIndex = 39;
            this.txtGrandTotal.TextAlign = null;
            this.txtGrandTotal.ValidationRules = null;
            this.txtGrandTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.cbxPacking);
            this.panel7.Controls.Add(this.label32);
            this.panel7.Controls.Add(this.txtInsuranceFee);
            this.panel7.Controls.Add(this.txtGoodsValue);
            this.panel7.Controls.Add(this.txtOtherFee);
            this.panel7.Controls.Add(this.label35);
            this.panel7.Controls.Add(this.label33);
            this.panel7.Controls.Add(this.txtPackingFee);
            this.panel7.Location = new System.Drawing.Point(709, 203);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(219, 110);
            this.panel7.TabIndex = 57;
            // 
            // cbxPacking
            // 
            this.cbxPacking.FieldLabel = null;
            this.cbxPacking.Location = new System.Drawing.Point(17, 5);
            this.cbxPacking.Name = "cbxPacking";
            this.cbxPacking.Size = new System.Drawing.Size(75, 17);
            this.cbxPacking.TabIndex = 31;
            this.cbxPacking.Text = "Packing";
            this.cbxPacking.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxPacking.UseVisualStyleBackColor = true;
            this.cbxPacking.ValidationRules = null;
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(17, 32);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(75, 17);
            this.label32.TabIndex = 106;
            this.label32.Text = "Other";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInsuranceFee
            // 
            this.txtInsuranceFee.EditMask = "###,###,###,###,###,##0.00";
            this.txtInsuranceFee.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtInsuranceFee.FieldLabel = null;
            this.txtInsuranceFee.Location = new System.Drawing.Point(98, 81);
            this.txtInsuranceFee.Name = "txtInsuranceFee";
            this.txtInsuranceFee.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtInsuranceFee.Properties.AllowMouseWheel = false;
            this.txtInsuranceFee.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInsuranceFee.Properties.Appearance.Options.UseFont = true;
            this.txtInsuranceFee.Properties.Appearance.Options.UseTextOptions = true;
            this.txtInsuranceFee.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtInsuranceFee.Properties.Mask.BeepOnError = true;
            this.txtInsuranceFee.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtInsuranceFee.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtInsuranceFee.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtInsuranceFee.ReadOnly = false;
            this.txtInsuranceFee.Size = new System.Drawing.Size(110, 24);
            this.txtInsuranceFee.TabIndex = 35;
            this.txtInsuranceFee.TextAlign = null;
            this.txtInsuranceFee.ValidationRules = null;
            this.txtInsuranceFee.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtInsuranceFee.TextChanged += new System.EventHandler(this.txtInsuranceFee_EditValueChanged);
            // 
            // txtGoodsValue
            // 
            this.txtGoodsValue.EditMask = "###,###,###,###,###,##0.00";
            this.txtGoodsValue.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtGoodsValue.FieldLabel = null;
            this.txtGoodsValue.Location = new System.Drawing.Point(98, 55);
            this.txtGoodsValue.Name = "txtGoodsValue";
            this.txtGoodsValue.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtGoodsValue.Properties.AllowMouseWheel = false;
            this.txtGoodsValue.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGoodsValue.Properties.Appearance.Options.UseFont = true;
            this.txtGoodsValue.Properties.Appearance.Options.UseTextOptions = true;
            this.txtGoodsValue.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtGoodsValue.Properties.Mask.BeepOnError = true;
            this.txtGoodsValue.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtGoodsValue.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGoodsValue.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtGoodsValue.ReadOnly = false;
            this.txtGoodsValue.Size = new System.Drawing.Size(110, 24);
            this.txtGoodsValue.TabIndex = 34;
            this.txtGoodsValue.TextAlign = null;
            this.txtGoodsValue.ValidationRules = null;
            this.txtGoodsValue.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtGoodsValue.TextChanged += new System.EventHandler(this.txtGoodsValue_EditValueChanged);
            // 
            // txtOtherFee
            // 
            this.txtOtherFee.EditMask = "###,###,###,###,###,##0.00";
            this.txtOtherFee.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOtherFee.FieldLabel = null;
            this.txtOtherFee.Location = new System.Drawing.Point(98, 29);
            this.txtOtherFee.Name = "txtOtherFee";
            this.txtOtherFee.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtOtherFee.Properties.AllowMouseWheel = false;
            this.txtOtherFee.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherFee.Properties.Appearance.Options.UseFont = true;
            this.txtOtherFee.Properties.Appearance.Options.UseTextOptions = true;
            this.txtOtherFee.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtOtherFee.Properties.Mask.BeepOnError = true;
            this.txtOtherFee.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtOtherFee.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtOtherFee.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtOtherFee.ReadOnly = false;
            this.txtOtherFee.Size = new System.Drawing.Size(110, 24);
            this.txtOtherFee.TabIndex = 33;
            this.txtOtherFee.TextAlign = null;
            this.txtOtherFee.ValidationRules = null;
            this.txtOtherFee.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOtherFee.TextChanged += new System.EventHandler(this.txtOtherFee_EditValueChanged);
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.Black;
            this.label35.Location = new System.Drawing.Point(17, 85);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(75, 17);
            this.label35.TabIndex = 106;
            this.label35.Text = "Insurance";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(17, 58);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(75, 17);
            this.label33.TabIndex = 106;
            this.label33.Text = "Goods Value";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPackingFee
            // 
            this.txtPackingFee.EditMask = "###,###,###,###,###,##0.00";
            this.txtPackingFee.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPackingFee.FieldLabel = null;
            this.txtPackingFee.Location = new System.Drawing.Point(98, 3);
            this.txtPackingFee.Name = "txtPackingFee";
            this.txtPackingFee.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtPackingFee.Properties.AllowMouseWheel = false;
            this.txtPackingFee.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPackingFee.Properties.Appearance.Options.UseFont = true;
            this.txtPackingFee.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPackingFee.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtPackingFee.Properties.Mask.BeepOnError = true;
            this.txtPackingFee.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtPackingFee.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPackingFee.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPackingFee.ReadOnly = false;
            this.txtPackingFee.Size = new System.Drawing.Size(110, 24);
            this.txtPackingFee.TabIndex = 32;
            this.txtPackingFee.TextAlign = null;
            this.txtPackingFee.ValidationRules = null;
            this.txtPackingFee.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPackingFee.TextChanged += new System.EventHandler(this.txtPackingFee_EditValueChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Controls.Add(this.label19);
            this.panel5.Controls.Add(this.label24);
            this.panel5.Controls.Add(this.txtTotalWeight);
            this.panel5.Controls.Add(this.label26);
            this.panel5.Controls.Add(this.txtChargeable);
            this.panel5.Controls.Add(this.txtTotalPiece);
            this.panel5.Location = new System.Drawing.Point(521, 40);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(186, 273);
            this.panel5.TabIndex = 55;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label37);
            this.groupBox1.Controls.Add(this.tbxH);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.tbxW);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.tbxL);
            this.groupBox1.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 107);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Volume (cm)";
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.Black;
            this.label37.Location = new System.Drawing.Point(37, 78);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(45, 17);
            this.label37.TabIndex = 129;
            this.label37.Text = "Height";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxH
            // 
            this.tbxH.EditMask = "###,###,###,###,###,##0.00";
            this.tbxH.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxH.FieldLabel = null;
            this.tbxH.Location = new System.Drawing.Point(87, 75);
            this.tbxH.Name = "tbxH";
            this.tbxH.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxH.Properties.AllowMouseWheel = false;
            this.tbxH.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxH.Properties.Appearance.Options.UseFont = true;
            this.tbxH.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxH.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxH.Properties.Mask.BeepOnError = true;
            this.tbxH.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxH.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxH.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxH.ReadOnly = false;
            this.tbxH.Size = new System.Drawing.Size(87, 24);
            this.tbxH.TabIndex = 23;
            this.tbxH.TextAlign = null;
            this.tbxH.ValidationRules = null;
            this.tbxH.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.Black;
            this.label36.Location = new System.Drawing.Point(37, 52);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(45, 17);
            this.label36.TabIndex = 127;
            this.label36.Text = "Width";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxW
            // 
            this.tbxW.EditMask = "###,###,###,###,###,##0.00";
            this.tbxW.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxW.FieldLabel = null;
            this.tbxW.Location = new System.Drawing.Point(87, 49);
            this.tbxW.Name = "tbxW";
            this.tbxW.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxW.Properties.AllowMouseWheel = false;
            this.tbxW.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxW.Properties.Appearance.Options.UseFont = true;
            this.tbxW.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxW.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxW.Properties.Mask.BeepOnError = true;
            this.tbxW.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxW.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxW.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxW.ReadOnly = false;
            this.tbxW.Size = new System.Drawing.Size(87, 24);
            this.tbxW.TabIndex = 22;
            this.tbxW.TextAlign = null;
            this.tbxW.ValidationRules = null;
            this.tbxW.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(37, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 17);
            this.label11.TabIndex = 125;
            this.label11.Text = "Length";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxL
            // 
            this.tbxL.EditMask = "###,###,###,###,###,##0.00";
            this.tbxL.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxL.FieldLabel = null;
            this.tbxL.Location = new System.Drawing.Point(87, 23);
            this.tbxL.Name = "tbxL";
            this.tbxL.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxL.Properties.AllowMouseWheel = false;
            this.tbxL.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxL.Properties.Appearance.Options.UseFont = true;
            this.tbxL.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxL.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxL.Properties.Mask.BeepOnError = true;
            this.tbxL.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxL.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxL.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxL.ReadOnly = false;
            this.tbxL.Size = new System.Drawing.Size(87, 24);
            this.tbxL.TabIndex = 21;
            this.tbxL.TextAlign = null;
            this.tbxL.ValidationRules = null;
            this.tbxL.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(9, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 17);
            this.label19.TabIndex = 106;
            this.label19.Text = "Total Piece";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(9, 37);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(75, 17);
            this.label24.TabIndex = 106;
            this.label24.Text = "Total Weight";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotalWeight
            // 
            this.txtTotalWeight.EditMask = "###,###,###,###,###,##0.00";
            this.txtTotalWeight.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalWeight.FieldLabel = null;
            this.txtTotalWeight.Location = new System.Drawing.Point(90, 34);
            this.txtTotalWeight.Name = "txtTotalWeight";
            this.txtTotalWeight.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtTotalWeight.Properties.AllowMouseWheel = false;
            this.txtTotalWeight.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalWeight.Properties.Appearance.Options.UseFont = true;
            this.txtTotalWeight.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalWeight.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalWeight.Properties.Mask.BeepOnError = true;
            this.txtTotalWeight.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtTotalWeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalWeight.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalWeight.ReadOnly = false;
            this.txtTotalWeight.Size = new System.Drawing.Size(87, 24);
            this.txtTotalWeight.TabIndex = 20;
            this.txtTotalWeight.TextAlign = null;
            this.txtTotalWeight.ValidationRules = null;
            this.txtTotalWeight.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalWeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTotalWeight_EditValueChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(16, 192);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(68, 17);
            this.label26.TabIndex = 106;
            this.label26.Text = "Chargeable";
            // 
            // txtChargeable
            // 
            this.txtChargeable.EditMask = "###,###,###,###,###,##0.00";
            this.txtChargeable.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtChargeable.FieldLabel = null;
            this.txtChargeable.Location = new System.Drawing.Point(90, 189);
            this.txtChargeable.Name = "txtChargeable";
            this.txtChargeable.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtChargeable.Properties.AllowMouseWheel = false;
            this.txtChargeable.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChargeable.Properties.Appearance.Options.UseFont = true;
            this.txtChargeable.Properties.Appearance.Options.UseTextOptions = true;
            this.txtChargeable.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtChargeable.Properties.Mask.BeepOnError = true;
            this.txtChargeable.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtChargeable.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtChargeable.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtChargeable.ReadOnly = false;
            this.txtChargeable.Size = new System.Drawing.Size(87, 24);
            this.txtChargeable.TabIndex = 24;
            this.txtChargeable.TextAlign = null;
            this.txtChargeable.ValidationRules = null;
            this.txtChargeable.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtChargeable.TextChanged += new System.EventHandler(this.txtChargeable_EditValueChanged);
            // 
            // txtTotalPiece
            // 
            this.txtTotalPiece.EditMask = "###,###,###,###,###,##0.00";
            this.txtTotalPiece.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalPiece.FieldLabel = null;
            this.txtTotalPiece.Location = new System.Drawing.Point(90, 9);
            this.txtTotalPiece.Name = "txtTotalPiece";
            this.txtTotalPiece.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtTotalPiece.Properties.AllowMouseWheel = false;
            this.txtTotalPiece.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPiece.Properties.Appearance.Options.UseFont = true;
            this.txtTotalPiece.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalPiece.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalPiece.Properties.Mask.BeepOnError = true;
            this.txtTotalPiece.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.txtTotalPiece.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalPiece.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalPiece.ReadOnly = false;
            this.txtTotalPiece.Size = new System.Drawing.Size(87, 24);
            this.txtTotalPiece.TabIndex = 19;
            this.txtTotalPiece.TextAlign = null;
            this.txtTotalPiece.ValidationRules = null;
            this.txtTotalPiece.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalPiece.TextChanged += new System.EventHandler(this.txtTotalPiece_EditValueChanged);
            // 
            // pnlShipmentInfo
            // 
            this.pnlShipmentInfo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlShipmentInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlShipmentInfo.Controls.Add(this.lkpBranch);
            this.pnlShipmentInfo.Controls.Add(this.lkpDestinationCity);
            this.pnlShipmentInfo.Controls.Add(this.lkpOriginCity);
            this.pnlShipmentInfo.Controls.Add(this.txtDate);
            this.pnlShipmentInfo.Controls.Add(this.label1);
            this.pnlShipmentInfo.Controls.Add(this.chkRA);
            this.pnlShipmentInfo.Controls.Add(this.label4);
            this.pnlShipmentInfo.Controls.Add(this.label2);
            this.pnlShipmentInfo.Controls.Add(this.txtShipmentNo);
            this.pnlShipmentInfo.Controls.Add(this.label5);
            this.pnlShipmentInfo.Controls.Add(this.label3);
            this.pnlShipmentInfo.Location = new System.Drawing.Point(3, 40);
            this.pnlShipmentInfo.Name = "pnlShipmentInfo";
            this.pnlShipmentInfo.Size = new System.Drawing.Size(516, 107);
            this.pnlShipmentInfo.TabIndex = 51;
            // 
            // lkpBranch
            // 
            this.lkpBranch.AutoCompleteDataManager = null;
            this.lkpBranch.AutoCompleteDisplayFormater = null;
            this.lkpBranch.AutoCompleteInitialized = false;
            this.lkpBranch.AutocompleteMinimumTextLength = 0;
            this.lkpBranch.AutoCompleteText = null;
            this.lkpBranch.AutoCompleteWhereExpression = null;
            this.lkpBranch.AutoCompleteWheretermFormater = null;
            this.lkpBranch.ClearOnLeave = true;
            this.lkpBranch.DisplayString = null;
            this.lkpBranch.FieldLabel = null;
            this.lkpBranch.Location = new System.Drawing.Point(362, 3);
            this.lkpBranch.LookupPopup = null;
            this.lkpBranch.Name = "lkpBranch";
            this.lkpBranch.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpBranch.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpBranch.Properties.Appearance.Options.UseFont = true;
            this.lkpBranch.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpBranch.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpBranch.Properties.AutoCompleteDataManager = null;
            this.lkpBranch.Properties.AutoCompleteDisplayFormater = null;
            this.lkpBranch.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpBranch.Properties.AutoCompleteText = null;
            this.lkpBranch.Properties.AutoCompleteWhereExpression = null;
            this.lkpBranch.Properties.AutoCompleteWheretermFormater = null;
            this.lkpBranch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lkpBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.BottomCenter, ((System.Drawing.Image)(resources.GetObject("lkpBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true)});
            this.lkpBranch.Properties.LookupPopup = null;
            this.lkpBranch.Properties.NullText = "<<Choose...>>";
            this.lkpBranch.Size = new System.Drawing.Size(143, 24);
            this.lkpBranch.TabIndex = 2;
            this.lkpBranch.ValidationRules = null;
            this.lkpBranch.Value = null;
            this.lkpBranch.EditValueChanged += new System.EventHandler(this.lkpBranch_EditValueChanged);
            // 
            // lkpDestinationCity
            // 
            this.lkpDestinationCity.AutoCompleteDataManager = null;
            this.lkpDestinationCity.AutoCompleteDisplayFormater = null;
            this.lkpDestinationCity.AutoCompleteInitialized = false;
            this.lkpDestinationCity.AutocompleteMinimumTextLength = 0;
            this.lkpDestinationCity.AutoCompleteText = null;
            this.lkpDestinationCity.AutoCompleteWhereExpression = null;
            this.lkpDestinationCity.AutoCompleteWheretermFormater = null;
            this.lkpDestinationCity.ClearOnLeave = true;
            this.lkpDestinationCity.DisplayString = null;
            this.lkpDestinationCity.FieldLabel = null;
            this.lkpDestinationCity.Location = new System.Drawing.Point(107, 78);
            this.lkpDestinationCity.LookupPopup = null;
            this.lkpDestinationCity.Name = "lkpDestinationCity";
            this.lkpDestinationCity.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpDestinationCity.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkpDestinationCity.Properties.Appearance.Options.UseFont = true;
            this.lkpDestinationCity.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpDestinationCity.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpDestinationCity.Properties.AutoCompleteDataManager = null;
            this.lkpDestinationCity.Properties.AutoCompleteDisplayFormater = null;
            this.lkpDestinationCity.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpDestinationCity.Properties.AutoCompleteText = null;
            this.lkpDestinationCity.Properties.AutoCompleteWhereExpression = null;
            this.lkpDestinationCity.Properties.AutoCompleteWheretermFormater = null;
            this.lkpDestinationCity.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lkpDestinationCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("lkpDestinationCity.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "", null, null, true)});
            this.lkpDestinationCity.Properties.LookupPopup = null;
            this.lkpDestinationCity.Properties.NullText = "<<Choose...>>";
            this.lkpDestinationCity.Size = new System.Drawing.Size(255, 24);
            this.lkpDestinationCity.TabIndex = 5;
            this.lkpDestinationCity.ValidationRules = null;
            this.lkpDestinationCity.Value = null;
            this.lkpDestinationCity.EditValueChanged += new System.EventHandler(this.lkpDestinationCity_EditValueChanged);
            this.lkpDestinationCity.Leave += new System.EventHandler(this.lkpDestinationCity_Leave);
            // 
            // lkpOriginCity
            // 
            this.lkpOriginCity.AutoCompleteDataManager = null;
            this.lkpOriginCity.AutoCompleteDisplayFormater = null;
            this.lkpOriginCity.AutoCompleteInitialized = false;
            this.lkpOriginCity.AutocompleteMinimumTextLength = 0;
            this.lkpOriginCity.AutoCompleteText = null;
            this.lkpOriginCity.AutoCompleteWhereExpression = null;
            this.lkpOriginCity.AutoCompleteWheretermFormater = null;
            this.lkpOriginCity.ClearOnLeave = true;
            this.lkpOriginCity.DisplayString = null;
            this.lkpOriginCity.EditValue = "";
            this.lkpOriginCity.FieldLabel = null;
            this.lkpOriginCity.Location = new System.Drawing.Point(107, 53);
            this.lkpOriginCity.LookupPopup = null;
            this.lkpOriginCity.Name = "lkpOriginCity";
            this.lkpOriginCity.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpOriginCity.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkpOriginCity.Properties.Appearance.Options.UseFont = true;
            this.lkpOriginCity.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpOriginCity.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpOriginCity.Properties.AutoCompleteDataManager = null;
            this.lkpOriginCity.Properties.AutoCompleteDisplayFormater = null;
            this.lkpOriginCity.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpOriginCity.Properties.AutoCompleteText = null;
            this.lkpOriginCity.Properties.AutoCompleteWhereExpression = null;
            this.lkpOriginCity.Properties.AutoCompleteWheretermFormater = null;
            this.lkpOriginCity.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lkpOriginCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("lkpOriginCity.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "", null, null, true)});
            this.lkpOriginCity.Properties.LookupPopup = null;
            this.lkpOriginCity.Properties.NullText = "<<Choose...>>";
            this.lkpOriginCity.Size = new System.Drawing.Size(255, 24);
            this.lkpOriginCity.TabIndex = 4;
            this.lkpOriginCity.ValidationRules = null;
            this.lkpOriginCity.Value = null;
            this.lkpOriginCity.EditValueChanged += new System.EventHandler(this.lkpOriginCity_EditValueChanged);
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDate.EditValue = null;
            this.txtDate.FieldLabel = null;
            this.txtDate.FormatDateTime = "dd-MM-yyyy";
            this.txtDate.Location = new System.Drawing.Point(107, 3);
            this.txtDate.Name = "txtDate";
            this.txtDate.Nullable = false;
            this.txtDate.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtDate.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Properties.Appearance.Options.UseFont = true;
            this.txtDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("txtDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, "", null, null, true)});
            this.txtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDate.Size = new System.Drawing.Size(109, 20);
            this.txtDate.TabIndex = 1;
            this.txtDate.ValidationRules = null;
            this.txtDate.Value = new System.DateTime(((long)(0)));
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(34, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 106;
            this.label1.Text = "Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkRA
            // 
            this.chkRA.AutoSize = true;
            this.chkRA.Enabled = false;
            this.chkRA.ForeColor = System.Drawing.Color.Black;
            this.chkRA.Location = new System.Drawing.Point(368, 81);
            this.chkRA.Name = "chkRA";
            this.chkRA.Size = new System.Drawing.Size(88, 21);
            this.chkRA.TabIndex = 107;
            this.chkRA.Text = "RA (X-Ray)";
            this.chkRA.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(34, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 106;
            this.label4.Text = "Destination";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(34, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 106;
            this.label2.Text = "No.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtShipmentNo
            // 
            this.txtShipmentNo.Capslock = true;
            this.txtShipmentNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipmentNo.FieldLabel = null;
            this.txtShipmentNo.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShipmentNo.Location = new System.Drawing.Point(107, 28);
            this.txtShipmentNo.Name = "txtShipmentNo";
            this.txtShipmentNo.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtShipmentNo.Size = new System.Drawing.Size(255, 24);
            this.txtShipmentNo.TabIndex = 3;
            this.txtShipmentNo.ValidationRules = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(310, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 106;
            this.label5.Text = "Branch";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(34, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 106;
            this.label3.Text = "Origin";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbxEmailPoint);
            this.panel1.Controls.Add(this.cbxMobilePoint);
            this.panel1.Controls.Add(this.label31);
            this.panel1.Controls.Add(this.tbxPromo);
            this.panel1.Location = new System.Drawing.Point(521, 314);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 66);
            this.panel1.TabIndex = 59;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(39, 36);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(94, 21);
            this.label31.TabIndex = 114;
            this.label31.Text = "Kode Promo";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxPromo
            // 
            this.tbxPromo.Capslock = true;
            this.tbxPromo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxPromo.FieldLabel = null;
            this.tbxPromo.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPromo.Location = new System.Drawing.Point(139, 33);
            this.tbxPromo.Name = "tbxPromo";
            this.tbxPromo.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPromo.Size = new System.Drawing.Size(228, 24);
            this.tbxPromo.TabIndex = 38;
            this.tbxPromo.ValidationRules = null;
            // 
            // cbxMobilePoint
            // 
            this.cbxMobilePoint.FieldLabel = null;
            this.cbxMobilePoint.Location = new System.Drawing.Point(39, 7);
            this.cbxMobilePoint.Name = "cbxMobilePoint";
            this.cbxMobilePoint.Size = new System.Drawing.Size(94, 21);
            this.cbxMobilePoint.TabIndex = 36;
            this.cbxMobilePoint.Text = "Mobile Point";
            this.cbxMobilePoint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxMobilePoint.UseVisualStyleBackColor = true;
            this.cbxMobilePoint.ValidationRules = null;
            // 
            // tbxEmailPoint
            // 
            this.tbxEmailPoint.Capslock = true;
            this.tbxEmailPoint.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxEmailPoint.FieldLabel = null;
            this.tbxEmailPoint.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxEmailPoint.Location = new System.Drawing.Point(139, 5);
            this.tbxEmailPoint.Name = "tbxEmailPoint";
            this.tbxEmailPoint.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxEmailPoint.Size = new System.Drawing.Size(228, 24);
            this.tbxEmailPoint.TabIndex = 37;
            this.tbxEmailPoint.ValidationRules = null;
            // 
            // CounterRetailForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(931, 517);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.pnlTotalAndAction);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pnlShipmentInfo);
            this.Name = "CounterRetailForm";
            this.Text = "Data Entry Retail";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.pnlShipmentInfo, 0);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.Controls.SetChildIndex(this.panel7, 0);
            this.Controls.SetChildIndex(this.pnlTotalAndAction, 0);
            this.Controls.SetChildIndex(this.panel6, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpMessenger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPaymentMethod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpServiceType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPackageType.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHandlingFee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTariffNet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTariffTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTariffPerKg.Properties)).EndInit();
            this.pnlTotalAndAction.ResumeLayout(false);
            this.pnlTotalAndAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrandTotal.Properties)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtInsuranceFee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoodsValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherFee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackingFee.Properties)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbxH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChargeable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPiece.Properties)).EndInit();
            this.pnlShipmentInfo.ResumeLayout(false);
            this.pnlShipmentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDestinationCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpOriginCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private Common.Component.dTextBox txtNatureOfGoods;
        private Common.Component.dTextBox txtNote;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private Common.Component.dTextBox txtConsigneeName;
        private Common.Component.dTextBox txtConsigneeAddress;
        private Common.Component.dTextBox txtConsigneePhone;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private Common.Component.dTextBox txtShipperAddress;
        private Common.Component.dTextBox txtShipperRef;
        private Common.Component.dTextBox txtShipperPhone;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label25;
        private Common.Component.dTextBoxNumber txtDiscountTotal;
        private Common.Component.dTextBoxNumber txtHandlingFee;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private Common.Component.dTextBoxNumber txtTariffNet;
        private Common.Component.dTextBoxNumber txtTariffTotal;
        private Common.Component.dTextBoxNumber txtDiscount;
        private Common.Component.dTextBoxNumber txtTariffPerKg;
        private System.Windows.Forms.Panel pnlTotalAndAction;
        private System.Windows.Forms.Button btnRefreshTariff;
        private dCheckBox chkPrintBarcode;
        private dCheckBox chkPrintContinuous;
        private dCheckBox chkPrintOrder;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label34;
        private Common.Component.dTextBoxNumber txtGrandTotal;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label32;
        private Common.Component.dTextBoxNumber txtOtherFee;
        private System.Windows.Forms.Label label33;
        private Common.Component.dTextBoxNumber txtPackingFee;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label24;
        private Common.Component.dTextBoxNumber txtTotalWeight;
        private System.Windows.Forms.Label label26;
        private Common.Component.dTextBoxNumber txtChargeable;
        private Common.Component.dTextBoxNumber txtTotalPiece;
        private System.Windows.Forms.Panel pnlShipmentInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkRA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Common.Component.dTextBox txtShipmentNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private SISCO.Presentation.Common.Component.dCalendar txtDate;
        private Common.Component.dTextBox txtShipperName;
        private Common.Component.dLookup lkpDestinationCity;
        private Common.Component.dLookup lkpOriginCity;
        private System.Windows.Forms.Label label35;
        private Common.Component.dLookup lkpBranch;
        private Common.Component.dLookup lkpMessenger;
        private Common.Component.dLookup lkpPaymentMethod;
        private Common.Component.dLookup lkpServiceType;
        private Common.Component.dLookup lkpPackageType;

        private Common.Component.dTextBoxNumber txtInsuranceFee;
        private Common.Component.dTextBoxNumber txtGoodsValue;
        private GroupBox groupBox1;
        private Label label37;
        private dTextBoxNumber tbxH;
        private Label label36;
        private dTextBoxNumber tbxW;
        private Label label11;
        private dTextBoxNumber tbxL;
        private dCheckBox cbxPacking;
        private Panel panel1;
        private Label label31;
        private dTextBox tbxPromo;
        private dTextBox tbxEmailPoint;
        private dCheckBox cbxMobilePoint;
    }
}

