namespace SISCO.Presentation.CustomerService.Forms
{
    partial class ClaimedForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClaimedForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dbUpload = new DevExpress.XtraEditors.ButtonEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxCode = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.GridClaim = new DevExpress.XtraGrid.GridControl();
            this.ClaimView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tbxTotal = new SISCO.Presentation.Common.Component.dTextBoxNumber(this.components);
            this.tbxLetterNo = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.tbxCustomer = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.tbxDescription = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lkpCustBranch = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.lkpClaimBranch = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dbUpload.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridClaim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClaimView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpClaimBranch.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tanggal";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(128, 44);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 17);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "-----";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Customer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(476, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Upload Dokumen";
            // 
            // dbUpload
            // 
            this.dbUpload.Location = new System.Drawing.Point(588, 95);
            this.dbUpload.Name = "dbUpload";
            this.dbUpload.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.dbUpload.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.dbUpload.Properties.Appearance.Options.UseBackColor = true;
            this.dbUpload.Properties.Appearance.Options.UseFont = true;
            this.dbUpload.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dbUpload.Size = new System.Drawing.Size(256, 24);
            this.dbUpload.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(561, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tambah POD";
            // 
            // tbxCode
            // 
            this.tbxCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxCode.Capslock = true;
            this.tbxCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxCode.FieldLabel = null;
            this.tbxCode.Location = new System.Drawing.Point(645, 150);
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxCode.Size = new System.Drawing.Size(173, 24);
            this.tbxCode.TabIndex = 8;
            this.tbxCode.ValidationRules = null;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Location = new System.Drawing.Point(821, 149);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(32, 26);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "+";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Total Claims";
            // 
            // GridClaim
            // 
            this.GridClaim.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridClaim.Location = new System.Drawing.Point(3, 177);
            this.GridClaim.MainView = this.ClaimView;
            this.GridClaim.Name = "GridClaim";
            this.GridClaim.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnDelete});
            this.GridClaim.Size = new System.Drawing.Size(850, 234);
            this.GridClaim.TabIndex = 11;
            this.GridClaim.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ClaimView});
            // 
            // ClaimView
            // 
            this.ClaimView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn7,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn8,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn9});
            this.ClaimView.GridControl = this.GridClaim;
            this.ClaimView.Name = "ClaimView";
            this.ClaimView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No.";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 38;
            // 
            // gridColumn7
            // 
            this.gridColumn7.ColumnEdit = this.btnDelete;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 28;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoHeight = false;
            this.btnDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.FieldName = "Id";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "POD";
            this.gridColumn3.FieldName = "ShipmentCode";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 139;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Customer";
            this.gridColumn8.FieldName = "CustomerName";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 257;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Nilai Barang";
            this.gridColumn4.DisplayFormat.FormatString = "n2";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "GoodsValue";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 178;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Asuransi";
            this.gridColumn5.DisplayFormat.FormatString = "n2";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "InsuranceFee";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 183;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "gridColumn6";
            this.gridColumn6.FieldName = "StateChange2";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "gridColumn9";
            this.gridColumn9.FieldName = "ShipmentId";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // tbxTotal
            // 
            this.tbxTotal.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbxTotal.FieldLabel = null;
            this.tbxTotal.Location = new System.Drawing.Point(131, 151);
            this.tbxTotal.Name = "tbxTotal";
            this.tbxTotal.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxTotal.Properties.AllowMouseWheel = false;
            this.tbxTotal.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxTotal.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.tbxTotal.Properties.Appearance.Options.UseBackColor = true;
            this.tbxTotal.Properties.Appearance.Options.UseFont = true;
            this.tbxTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTotal.Properties.Mask.BeepOnError = true;
            this.tbxTotal.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxTotal.ReadOnly = false;
            this.tbxTotal.Size = new System.Drawing.Size(132, 24);
            this.tbxTotal.TabIndex = 10;
            this.tbxTotal.TextAlign = null;
            this.tbxTotal.ValidationRules = null;
            this.tbxTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // tbxLetterNo
            // 
            this.tbxLetterNo.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxLetterNo.Capslock = true;
            this.tbxLetterNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxLetterNo.FieldLabel = null;
            this.tbxLetterNo.Location = new System.Drawing.Point(588, 45);
            this.tbxLetterNo.Name = "tbxLetterNo";
            this.tbxLetterNo.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxLetterNo.Size = new System.Drawing.Size(256, 24);
            this.tbxLetterNo.TabIndex = 5;
            this.tbxLetterNo.ValidationRules = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(499, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Nomor Surat";
            // 
            // tbxCustomer
            // 
            this.tbxCustomer.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbxCustomer.Capslock = true;
            this.tbxCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxCustomer.FieldLabel = null;
            this.tbxCustomer.Location = new System.Drawing.Point(131, 68);
            this.tbxCustomer.Name = "tbxCustomer";
            this.tbxCustomer.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxCustomer.Size = new System.Drawing.Size(283, 24);
            this.tbxCustomer.TabIndex = 1;
            this.tbxCustomer.ValidationRules = null;
            // 
            // tbxDescription
            // 
            this.tbxDescription.Capslock = true;
            this.tbxDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxDescription.FieldLabel = null;
            this.tbxDescription.Location = new System.Drawing.Point(588, 70);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxDescription.Size = new System.Drawing.Size(256, 24);
            this.tbxDescription.TabIndex = 6;
            this.tbxDescription.ValidationRules = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(509, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Description";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Customer Cabang";
            // 
            // lkpCustBranch
            // 
            this.lkpCustBranch.AutoCompleteDataManager = null;
            this.lkpCustBranch.AutoCompleteDisplayFormater = null;
            this.lkpCustBranch.AutoCompleteInitialized = false;
            this.lkpCustBranch.AutocompleteMinimumTextLength = 0;
            this.lkpCustBranch.AutoCompleteText = null;
            this.lkpCustBranch.AutoCompleteWhereExpression = null;
            this.lkpCustBranch.AutoCompleteWheretermFormater = null;
            this.lkpCustBranch.ClearOnLeave = true;
            this.lkpCustBranch.DisplayString = null;
            this.lkpCustBranch.FieldLabel = null;
            this.lkpCustBranch.Location = new System.Drawing.Point(131, 120);
            this.lkpCustBranch.LookupPopup = null;
            this.lkpCustBranch.Name = "lkpCustBranch";
            this.lkpCustBranch.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpCustBranch.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lkpCustBranch.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpCustBranch.Properties.Appearance.Options.UseBackColor = true;
            this.lkpCustBranch.Properties.Appearance.Options.UseFont = true;
            this.lkpCustBranch.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpCustBranch.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpCustBranch.Properties.AutoCompleteDataManager = null;
            this.lkpCustBranch.Properties.AutoCompleteDisplayFormater = null;
            this.lkpCustBranch.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpCustBranch.Properties.AutoCompleteText = null;
            this.lkpCustBranch.Properties.AutoCompleteWhereExpression = null;
            this.lkpCustBranch.Properties.AutoCompleteWheretermFormater = null;
            this.lkpCustBranch.Properties.AutoHeight = false;
            this.lkpCustBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpCustBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpCustBranch.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpCustBranch.Properties.LookupPopup = null;
            this.lkpCustBranch.Properties.NullText = "<<Choose...>>";
            this.lkpCustBranch.Size = new System.Drawing.Size(248, 24);
            this.lkpCustBranch.TabIndex = 3;
            this.lkpCustBranch.ValidationRules = null;
            this.lkpCustBranch.Value = null;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(585, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(195, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "Klik 2x jika ingin unduh document";
            // 
            // lkpClaimBranch
            // 
            this.lkpClaimBranch.AutoCompleteDataManager = null;
            this.lkpClaimBranch.AutoCompleteDisplayFormater = null;
            this.lkpClaimBranch.AutoCompleteInitialized = false;
            this.lkpClaimBranch.AutocompleteMinimumTextLength = 0;
            this.lkpClaimBranch.AutoCompleteText = null;
            this.lkpClaimBranch.AutoCompleteWhereExpression = null;
            this.lkpClaimBranch.AutoCompleteWheretermFormater = null;
            this.lkpClaimBranch.ClearOnLeave = true;
            this.lkpClaimBranch.DisplayString = null;
            this.lkpClaimBranch.FieldLabel = null;
            this.lkpClaimBranch.Location = new System.Drawing.Point(131, 94);
            this.lkpClaimBranch.LookupPopup = null;
            this.lkpClaimBranch.Name = "lkpClaimBranch";
            this.lkpClaimBranch.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpClaimBranch.Properties.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lkpClaimBranch.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpClaimBranch.Properties.Appearance.Options.UseBackColor = true;
            this.lkpClaimBranch.Properties.Appearance.Options.UseFont = true;
            this.lkpClaimBranch.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpClaimBranch.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpClaimBranch.Properties.AutoCompleteDataManager = null;
            this.lkpClaimBranch.Properties.AutoCompleteDisplayFormater = null;
            this.lkpClaimBranch.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpClaimBranch.Properties.AutoCompleteText = null;
            this.lkpClaimBranch.Properties.AutoCompleteWhereExpression = null;
            this.lkpClaimBranch.Properties.AutoCompleteWheretermFormater = null;
            this.lkpClaimBranch.Properties.AutoHeight = false;
            this.lkpClaimBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpClaimBranch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpClaimBranch.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpClaimBranch.Properties.LookupPopup = null;
            this.lkpClaimBranch.Properties.NullText = "<<Choose...>>";
            this.lkpClaimBranch.Size = new System.Drawing.Size(248, 24);
            this.lkpClaimBranch.TabIndex = 2;
            this.lkpClaimBranch.ValidationRules = null;
            this.lkpClaimBranch.Value = null;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(46, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "Beban Claim";
            // 
            // ClaimedForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(856, 413);
            this.Controls.Add(this.lkpClaimBranch);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lkpCustBranch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbxCustomer);
            this.Controls.Add(this.tbxLetterNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbxTotal);
            this.Controls.Add(this.GridClaim);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbxCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dbUpload);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "ClaimedForm";
            this.Text = "Claimed";
            this.VisibleBtnDelete = true;
            this.VisibleBtnNew = true;
            this.VisibleBtnPrint = true;
            this.VisibleBtnPrintPreview = true;
            this.VisibleBtnSave = true;
            this.VisibleBtnSearch = true;
            this.VisibleNavigation = true;
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblDate, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.dbUpload, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.tbxCode, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.GridClaim, 0);
            this.Controls.SetChildIndex(this.tbxTotal, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.tbxLetterNo, 0);
            this.Controls.SetChildIndex(this.tbxCustomer, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.tbxDescription, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.lkpCustBranch, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.lkpClaimBranch, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dbUpload.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridClaim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClaimView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpClaimBranch.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.ButtonEdit dbUpload;
        private System.Windows.Forms.Label label4;
        private Common.Component.dTextBox tbxCode;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.GridControl GridClaim;
        private DevExpress.XtraGrid.Views.Grid.GridView ClaimView;
        private Common.Component.dTextBoxNumber tbxTotal;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDelete;
        private Common.Component.dTextBox tbxLetterNo;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private Common.Component.dTextBox tbxCustomer;
        private Common.Component.dTextBox tbxDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Common.Component.dLookup lkpCustBranch;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private Common.Component.dLookup lkpClaimBranch;
        private System.Windows.Forms.Label label10;
    }
}