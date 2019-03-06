using System.Windows.Forms;

namespace SISCO.Presentation.CustomerService.Forms
{
    partial class TrackingByShipment
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlShipmentInformation = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlShipmentStatus = new System.Windows.Forms.Panel();
            this.txtDateAdd = new SISCO.Presentation.Common.Component.dCalendar(this.components);
            this.cmbMissDeliveryReason = new System.Windows.Forms.ComboBox();
            this.lkpBranch = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.cmbShipmentStatus = new System.Windows.Forms.ComboBox();
            this.chkPodSent = new System.Windows.Forms.CheckBox();
            this.txtTimeAdd = new DevExpress.XtraEditors.TimeEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtBy = new DevExpress.XtraEditors.ButtonEdit();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.btnAddStatus = new System.Windows.Forms.Button();
            this.txtNote = new Common.Component.dTextBox();
            this.pnlOtherInformation = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNatureOfGoods = new Common.Component.dTextBox();
            this.txtPaymentMethod = new Common.Component.dTextBox();
            this.txtServiceType = new Common.Component.dTextBox();
            this.txtPackageType = new Common.Component.dTextBox();
            this.pnlConsigneeInformation = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtConsigneeName = new Common.Component.dTextBox();
            this.txtConsigneeAddress = new Common.Component.dTextBox();
            this.txtConsigneePhone = new Common.Component.dTextBox();
            this.txtShipperName = new Common.Component.dTextBox();
            this.txtCustomerName = new Common.Component.dTextBox();
            this.txtCustomerCode = new Common.Component.dTextBox();
            this.txtShipperPhone = new Common.Component.dTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtShipperAddress = new Common.Component.dTextBox();
            this.pnlShipperInformation = new System.Windows.Forms.Panel();
            this.txtDestination = new Common.Component.dTextBox();
            this.txtOrigin = new Common.Component.dTextBox();
            this.txtShipmentNo = new Common.Component.dTextBox();
            this.txtDate = new Common.Component.dTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.pnlShipmentInformation.SuspendLayout();
            this.pnlShipmentStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateAdd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateAdd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeAdd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBy.Properties)).BeginInit();
            this.pnlOtherInformation.SuspendLayout();
            this.pnlConsigneeInformation.SuspendLayout();
            this.pnlShipperInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.Location = new System.Drawing.Point(490, 44);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(387, 246);
            this.grid.TabIndex = 55;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn13,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn11});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Date";
            this.gridColumn2.FieldName = "StatusDate";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Time";
            this.gridColumn13.FieldName = "StatusTime";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Status";
            this.gridColumn4.FieldName = "TrackingStatus";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Position";
            this.gridColumn6.FieldName = "Position";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "By";
            this.gridColumn7.FieldName = "StatusBy";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Note";
            this.gridColumn11.FieldName = "StatusNote";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 5;
            // 
            // pnlShipmentInformation
            // 
            this.pnlShipmentInformation.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlShipmentInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlShipmentInformation.Controls.Add(this.label1);
            this.pnlShipmentInformation.Controls.Add(this.label4);
            this.pnlShipmentInformation.Controls.Add(this.label2);
            this.pnlShipmentInformation.Controls.Add(this.txtDestination);
            this.pnlShipmentInformation.Controls.Add(this.txtOrigin);
            this.pnlShipmentInformation.Controls.Add(this.txtDate);
            this.pnlShipmentInformation.Controls.Add(this.txtShipmentNo);
            this.pnlShipmentInformation.Controls.Add(this.label3);
            this.pnlShipmentInformation.Location = new System.Drawing.Point(-1, 37);
            this.pnlShipmentInformation.Name = "pnlShipmentInformation";
            this.pnlShipmentInformation.Size = new System.Drawing.Size(482, 110);
            this.pnlShipmentInformation.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 106;
            this.label1.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 106;
            this.label4.Text = "Destination";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "No.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 106;
            this.label3.Text = "Origin";
            // 
            // pnlShipmentStatus
            // 
            this.pnlShipmentStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlShipmentStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlShipmentStatus.Controls.Add(this.txtDateAdd);
            this.pnlShipmentStatus.Controls.Add(this.cmbMissDeliveryReason);
            this.pnlShipmentStatus.Controls.Add(this.lkpBranch);
            this.pnlShipmentStatus.Controls.Add(this.cmbShipmentStatus);
            this.pnlShipmentStatus.Controls.Add(this.chkPodSent);
            this.pnlShipmentStatus.Controls.Add(this.txtTimeAdd);
            this.pnlShipmentStatus.Controls.Add(this.label5);
            this.pnlShipmentStatus.Controls.Add(this.label6);
            this.pnlShipmentStatus.Controls.Add(this.label19);
            this.pnlShipmentStatus.Controls.Add(this.label21);
            this.pnlShipmentStatus.Controls.Add(this.txtBy);
            this.pnlShipmentStatus.Controls.Add(this.label22);
            this.pnlShipmentStatus.Controls.Add(this.label23);
            this.pnlShipmentStatus.Controls.Add(this.label24);
            this.pnlShipmentStatus.Controls.Add(this.btnAddStatus);
            this.pnlShipmentStatus.Controls.Add(this.txtNote);
            this.pnlShipmentStatus.Location = new System.Drawing.Point(490, 296);
            this.pnlShipmentStatus.Name = "pnlShipmentStatus";
            this.pnlShipmentStatus.Size = new System.Drawing.Size(387, 218);
            this.pnlShipmentStatus.TabIndex = 56;
            // 
            // txtDateAdd
            // 
            this.txtDateAdd.EditValue = null;
            this.txtDateAdd.FormatDateTime = "dd-MM-yyyy";
            this.txtDateAdd.Location = new System.Drawing.Point(92, 106);
            this.txtDateAdd.Name = "txtDateAdd";
            this.txtDateAdd.Nullable = false;
            this.txtDateAdd.Properties.AutoHeight = false;
            this.txtDateAdd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtDateAdd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateAdd.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtDateAdd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDateAdd.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtDateAdd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDateAdd.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtDateAdd.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtDateAdd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDateAdd.Properties.NullText = "<<Choose...>>";
            this.txtDateAdd.Size = new System.Drawing.Size(137, 20);
            this.txtDateAdd.TabIndex = 106;
            this.txtDateAdd.Value = new System.DateTime(((long)(0)));
            // 
            // cmbMissDeliveryReason
            // 
            this.cmbMissDeliveryReason.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbMissDeliveryReason.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMissDeliveryReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMissDeliveryReason.Location = new System.Drawing.Point(204, 31);
            this.cmbMissDeliveryReason.Name = "cmbMissDeliveryReason";
            this.cmbMissDeliveryReason.Size = new System.Drawing.Size(144, 21);
            this.cmbMissDeliveryReason.TabIndex = 102;
            // 
            // lkpBranch
            // 
            this.lkpBranch.AutoCompleteDataManager = null;
            this.lkpBranch.AutoCompleteDisplayFormater = null;
            this.lkpBranch.AutoCompleteInitialized = false;
            this.lkpBranch.AutoCompleteText = null;
            this.lkpBranch.AutoCompleteWhereExpression = null;
            this.lkpBranch.AutoCompleteWheretermFormater = null;
            this.lkpBranch.Location = new System.Drawing.Point(92, 62);
            this.lkpBranch.LookupPopup = null;
            this.lkpBranch.Name = "lkpBranch";
            this.lkpBranch.Properties.AutoHeight = false;
            this.lkpBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpBranch.Properties.NullText = "<<Choose...>>";
            this.lkpBranch.Size = new System.Drawing.Size(256, 20);
            this.lkpBranch.TabIndex = 103;
            this.lkpBranch.Value = null;
            // 
            // cmbShipmentStatus
            // 
            this.cmbShipmentStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbShipmentStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbShipmentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShipmentStatus.Location = new System.Drawing.Point(92, 9);
            this.cmbShipmentStatus.Name = "cmbShipmentStatus";
            this.cmbShipmentStatus.Size = new System.Drawing.Size(256, 21);
            this.cmbShipmentStatus.TabIndex = 101;
            // 
            // chkPodSent
            // 
            this.chkPodSent.AutoSize = true;
            this.chkPodSent.Checked = true;
            this.chkPodSent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPodSent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPodSent.Location = new System.Drawing.Point(92, 159);
            this.chkPodSent.Name = "chkPodSent";
            this.chkPodSent.Size = new System.Drawing.Size(137, 17);
            this.chkPodSent.TabIndex = 109;
            this.chkPodSent.Text = "POD Outgoing Sent";
            this.chkPodSent.UseVisualStyleBackColor = true;
            // 
            // txtTimeAdd
            // 
            this.txtTimeAdd.EditValue = new System.DateTime(2014, 4, 22, 0, 0, 0, 0);
            this.txtTimeAdd.Location = new System.Drawing.Point(269, 106);
            this.txtTimeAdd.Name = "txtTimeAdd";
            this.txtTimeAdd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTimeAdd.Properties.Mask.EditMask = "HH:mm";
            this.txtTimeAdd.Size = new System.Drawing.Size(79, 20);
            this.txtTimeAdd.TabIndex = 107;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(56, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 153;
            this.label5.Text = "Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(233, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 152;
            this.label6.Text = "Time";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(56, 131);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(30, 13);
            this.label19.TabIndex = 148;
            this.label19.Text = "Note";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(67, 87);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(19, 13);
            this.label21.TabIndex = 149;
            this.label21.Text = "By";
            // 
            // txtBy
            // 
            this.txtBy.EditValue = "";
            this.txtBy.Location = new System.Drawing.Point(92, 84);
            this.txtBy.Name = "txtBy";
            this.txtBy.Size = new System.Drawing.Size(256, 20);
            this.txtBy.TabIndex = 104;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(45, 65);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 13);
            this.label22.TabIndex = 144;
            this.label22.Text = "Branch";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(89, 34);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(109, 13);
            this.label23.TabIndex = 142;
            this.label23.Text = "Miss Delivery Reason";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(49, 12);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(37, 13);
            this.label24.TabIndex = 143;
            this.label24.Text = "Status";
            // 
            // btnAddStatus
            // 
            this.btnAddStatus.Location = new System.Drawing.Point(286, 180);
            this.btnAddStatus.Name = "btnAddStatus";
            this.btnAddStatus.Size = new System.Drawing.Size(89, 26);
            this.btnAddStatus.TabIndex = 110;
            this.btnAddStatus.Text = "Add Status";
            this.btnAddStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddStatus.UseVisualStyleBackColor = true;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(92, 128);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(283, 20);
            this.txtNote.TabIndex = 108;
            // 
            // pnlOtherInformation
            // 
            this.pnlOtherInformation.BackColor = System.Drawing.Color.SandyBrown;
            this.pnlOtherInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOtherInformation.Controls.Add(this.label12);
            this.pnlOtherInformation.Controls.Add(this.label17);
            this.pnlOtherInformation.Controls.Add(this.label20);
            this.pnlOtherInformation.Controls.Add(this.label18);
            this.pnlOtherInformation.Controls.Add(this.txtNatureOfGoods);
            this.pnlOtherInformation.Controls.Add(this.txtPaymentMethod);
            this.pnlOtherInformation.Controls.Add(this.txtServiceType);
            this.pnlOtherInformation.Controls.Add(this.txtPackageType);
            this.pnlOtherInformation.Location = new System.Drawing.Point(-1, 367);
            this.pnlOtherInformation.Name = "pnlOtherInformation";
            this.pnlOtherInformation.Size = new System.Drawing.Size(482, 147);
            this.pnlOtherInformation.TabIndex = 54;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 13);
            this.label12.TabIndex = 112;
            this.label12.Text = "Payment Method";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 13);
            this.label17.TabIndex = 113;
            this.label17.Text = "Package Type";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(5, 75);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(85, 13);
            this.label20.TabIndex = 108;
            this.label20.Text = "Nature of Goods";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(20, 31);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 13);
            this.label18.TabIndex = 108;
            this.label18.Text = "Service Type";
            // 
            // txtNatureOfGoods
            // 
            this.txtNatureOfGoods.Location = new System.Drawing.Point(96, 72);
            this.txtNatureOfGoods.Name = "txtNatureOfGoods";
            this.txtNatureOfGoods.Size = new System.Drawing.Size(372, 20);
            this.txtNatureOfGoods.TabIndex = 104;
            // 
            // txtPaymentMethod
            // 
            this.txtPaymentMethod.Location = new System.Drawing.Point(96, 50);
            this.txtPaymentMethod.Name = "txtPaymentMethod";
            this.txtPaymentMethod.Size = new System.Drawing.Size(151, 20);
            this.txtPaymentMethod.TabIndex = 103;
            // 
            // txtServiceType
            // 
            this.txtServiceType.Location = new System.Drawing.Point(96, 28);
            this.txtServiceType.Name = "txtServiceType";
            this.txtServiceType.Size = new System.Drawing.Size(151, 20);
            this.txtServiceType.TabIndex = 102;
            // 
            // txtPackageType
            // 
            this.txtPackageType.Location = new System.Drawing.Point(96, 6);
            this.txtPackageType.Name = "txtPackageType";
            this.txtPackageType.Size = new System.Drawing.Size(151, 20);
            this.txtPackageType.TabIndex = 101;
            // 
            // pnlConsigneeInformation
            // 
            this.pnlConsigneeInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pnlConsigneeInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConsigneeInformation.Controls.Add(this.label13);
            this.pnlConsigneeInformation.Controls.Add(this.label14);
            this.pnlConsigneeInformation.Controls.Add(this.label15);
            this.pnlConsigneeInformation.Controls.Add(this.label16);
            this.pnlConsigneeInformation.Controls.Add(this.txtConsigneeName);
            this.pnlConsigneeInformation.Controls.Add(this.txtConsigneeAddress);
            this.pnlConsigneeInformation.Controls.Add(this.txtConsigneePhone);
            this.pnlConsigneeInformation.Location = new System.Drawing.Point(-1, 270);
            this.pnlConsigneeInformation.Name = "pnlConsigneeInformation";
            this.pnlConsigneeInformation.Size = new System.Drawing.Size(482, 98);
            this.pnlConsigneeInformation.TabIndex = 53;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(52, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 112;
            this.label13.Text = "Phone";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(55, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 113;
            this.label14.Text = "Name";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(44, 46);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 13);
            this.label15.TabIndex = 108;
            this.label15.Text = "Address";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(96, 6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 13);
            this.label16.TabIndex = 109;
            this.label16.Text = "Consignee";
            // 
            // txtConsigneeName
            // 
            this.txtConsigneeName.Location = new System.Drawing.Point(96, 21);
            this.txtConsigneeName.Name = "txtConsigneeName";
            this.txtConsigneeName.Size = new System.Drawing.Size(219, 20);
            this.txtConsigneeName.TabIndex = 101;
            // 
            // txtConsigneeAddress
            // 
            this.txtConsigneeAddress.Location = new System.Drawing.Point(96, 43);
            this.txtConsigneeAddress.Name = "txtConsigneeAddress";
            this.txtConsigneeAddress.Size = new System.Drawing.Size(372, 20);
            this.txtConsigneeAddress.TabIndex = 102;
            // 
            // txtConsigneePhone
            // 
            this.txtConsigneePhone.Location = new System.Drawing.Point(96, 65);
            this.txtConsigneePhone.Name = "txtConsigneePhone";
            this.txtConsigneePhone.Size = new System.Drawing.Size(151, 20);
            this.txtConsigneePhone.TabIndex = 103;
            // 
            // txtShipperName
            // 
            this.txtShipperName.Location = new System.Drawing.Point(96, 48);
            this.txtShipperName.Name = "txtShipperName";
            this.txtShipperName.Size = new System.Drawing.Size(219, 20);
            this.txtShipperName.TabIndex = 103;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(166, 10);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(246, 20);
            this.txtCustomerName.TabIndex = 102;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(96, 10);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(66, 20);
            this.txtCustomerCode.TabIndex = 101;
            // 
            // txtShipperPhone
            // 
            this.txtShipperPhone.Location = new System.Drawing.Point(96, 92);
            this.txtShipperPhone.Name = "txtShipperPhone";
            this.txtShipperPhone.Size = new System.Drawing.Size(151, 20);
            this.txtShipperPhone.TabIndex = 105;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(51, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 112;
            this.label7.Text = "Phone";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(55, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 113;
            this.label8.Text = "Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(45, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 108;
            this.label9.Text = "Address";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(96, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 109;
            this.label10.Text = "Shipper";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(39, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 110;
            this.label11.Text = "Customer";
            // 
            // txtShipperAddress
            // 
            this.txtShipperAddress.Location = new System.Drawing.Point(96, 70);
            this.txtShipperAddress.Name = "txtShipperAddress";
            this.txtShipperAddress.Size = new System.Drawing.Size(372, 20);
            this.txtShipperAddress.TabIndex = 104;
            // 
            // pnlShipperInformation
            // 
            this.pnlShipperInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlShipperInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlShipperInformation.Controls.Add(this.label7);
            this.pnlShipperInformation.Controls.Add(this.label8);
            this.pnlShipperInformation.Controls.Add(this.label9);
            this.pnlShipperInformation.Controls.Add(this.label10);
            this.pnlShipperInformation.Controls.Add(this.label11);
            this.pnlShipperInformation.Controls.Add(this.txtShipperAddress);
            this.pnlShipperInformation.Controls.Add(this.txtShipperName);
            this.pnlShipperInformation.Controls.Add(this.txtCustomerName);
            this.pnlShipperInformation.Controls.Add(this.txtCustomerCode);
            this.pnlShipperInformation.Controls.Add(this.txtShipperPhone);
            this.pnlShipperInformation.Location = new System.Drawing.Point(-1, 146);
            this.pnlShipperInformation.Name = "pnlShipperInformation";
            this.pnlShipperInformation.Size = new System.Drawing.Size(482, 125);
            this.pnlShipperInformation.TabIndex = 52;
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(96, 78);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(219, 20);
            this.txtDestination.TabIndex = 104;
            // 
            // txtOrigin
            // 
            this.txtOrigin.Location = new System.Drawing.Point(96, 56);
            this.txtOrigin.Name = "txtOrigin";
            this.txtOrigin.Size = new System.Drawing.Size(219, 20);
            this.txtOrigin.TabIndex = 103;
            // 
            // txtShipmentNo
            // 
            this.txtShipmentNo.Location = new System.Drawing.Point(96, 34);
            this.txtShipmentNo.Name = "txtShipmentNo";
            this.txtShipmentNo.Size = new System.Drawing.Size(178, 20);
            this.txtShipmentNo.TabIndex = 102;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(96, 12);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(178, 20);
            this.txtDate.TabIndex = 101;
            // 
            // TrackingByShipment
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(878, 515);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.pnlShipmentInformation);
            this.Controls.Add(this.pnlShipmentStatus);
            this.Controls.Add(this.pnlOtherInformation);
            this.Controls.Add(this.pnlConsigneeInformation);
            this.Controls.Add(this.pnlShipperInformation);
            this.Name = "TrackingByShipment";
            this.Text = "Outgoing POD Detail";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.pnlShipmentInformation.ResumeLayout(false);
            this.pnlShipmentInformation.PerformLayout();
            this.pnlShipmentStatus.ResumeLayout(false);
            this.pnlShipmentStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateAdd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateAdd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeAdd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBy.Properties)).EndInit();
            this.pnlOtherInformation.ResumeLayout(false);
            this.pnlOtherInformation.PerformLayout();
            this.pnlConsigneeInformation.ResumeLayout(false);
            this.pnlConsigneeInformation.PerformLayout();
            this.pnlShipperInformation.ResumeLayout(false);
            this.pnlShipperInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private System.Windows.Forms.Panel pnlShipmentInformation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlShipmentStatus;
        private System.Windows.Forms.CheckBox chkPodSent;
        private DevExpress.XtraEditors.TimeEdit txtTimeAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private DevExpress.XtraEditors.ButtonEdit txtBy;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnAddStatus;
        private Common.Component.dTextBox txtNote;
        private System.Windows.Forms.Panel pnlOtherInformation;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private Common.Component.dTextBox txtNatureOfGoods;
        private Common.Component.dTextBox txtPaymentMethod;
        private Common.Component.dTextBox txtServiceType;
        private Common.Component.dTextBox txtPackageType;
        private System.Windows.Forms.Panel pnlConsigneeInformation;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private Common.Component.dTextBox txtConsigneeName;
        private Common.Component.dTextBox txtConsigneeAddress;
        private Common.Component.dTextBox txtConsigneePhone;
        private Common.Component.dTextBox txtShipperName;
        private Common.Component.dTextBox txtCustomerName;
        private Common.Component.dTextBox txtCustomerCode;
        private Common.Component.dTextBox txtShipperPhone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private Common.Component.dTextBox txtShipperAddress;
        private System.Windows.Forms.Panel pnlShipperInformation;
        private Common.Component.dCalendar txtDateAdd;
        private ComboBox cmbMissDeliveryReason;
        private Common.Component.dLookup lkpBranch;
        private ComboBox cmbShipmentStatus;
        private Common.Component.dTextBox txtDestination;
        private Common.Component.dTextBox txtOrigin;
        private Common.Component.dTextBox txtDate;
        private Common.Component.dTextBox txtShipmentNo;

    }
}

