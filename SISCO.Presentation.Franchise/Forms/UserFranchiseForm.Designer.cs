namespace SISCO.Presentation.Franchise.Forms
{
    partial class UserFranchiseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserFranchiseForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPassword = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtUsername = new SISCO.Presentation.Common.Component.dTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.lkpFranchise = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.gridUsers = new DevExpress.XtraGrid.GridControl();
            this.userView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkpFilterFranchise = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridPriviledge = new DevExpress.XtraGrid.GridControl();
            this.priviledgeView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.lblInfo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFranchise.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilterFranchise.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPriviledge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priviledgeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lblInfo);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lkpFranchise);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.gridUsers);
            this.groupBox1.Controls.Add(this.lkpFilterFranchise);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 482);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Users";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Capslock = true;
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassword.FieldLabel = null;
            this.txtPassword.Location = new System.Drawing.Point(82, 159);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(168, 22);
            this.txtPassword.TabIndex = 147;
            this.txtPassword.ValidationRules = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 14);
            this.label5.TabIndex = 146;
            this.label5.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Capslock = true;
            this.txtUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsername.FieldLabel = null;
            this.txtUsername.Location = new System.Drawing.Point(82, 134);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtUsername.Size = new System.Drawing.Size(200, 22);
            this.txtUsername.TabIndex = 145;
            this.txtUsername.ValidationRules = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 14);
            this.label4.TabIndex = 144;
            this.label4.Text = "Username";
            // 
            // lkpFranchise
            // 
            this.lkpFranchise.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.lkpFranchise.Location = new System.Drawing.Point(82, 109);
            this.lkpFranchise.LookupPopup = null;
            this.lkpFranchise.Name = "lkpFranchise";
            this.lkpFranchise.OriginalBackColor = System.Drawing.Color.Empty;
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpFranchise.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.lkpFranchise.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpFranchise.Properties.LookupPopup = null;
            this.lkpFranchise.Properties.NullText = "<<Choose...>>";
            this.lkpFranchise.Size = new System.Drawing.Size(262, 22);
            this.lkpFranchise.TabIndex = 143;
            this.lkpFranchise.ValidationRules = null;
            this.lkpFranchise.Value = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 14);
            this.label3.TabIndex = 142;
            this.label3.Text = "Franchise";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(153, 25);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 62);
            this.btnDelete.TabIndex = 140;
            this.btnDelete.Text = "Delete";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(82, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 62);
            this.btnSave.TabIndex = 139;
            this.btnSave.Text = "Save";
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNew.Location = new System.Drawing.Point(11, 25);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(65, 62);
            this.btnNew.TabIndex = 138;
            this.btnNew.Text = "New";
            // 
            // gridUsers
            // 
            this.gridUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridUsers.Location = new System.Drawing.Point(7, 242);
            this.gridUsers.MainView = this.userView;
            this.gridUsers.Name = "gridUsers";
            this.gridUsers.Size = new System.Drawing.Size(400, 234);
            this.gridUsers.TabIndex = 6;
            this.gridUsers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.userView});
            // 
            // userView
            // 
            this.userView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn12,
            this.gridColumn3});
            this.userView.GridControl = this.gridUsers;
            this.userView.Name = "userView";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Username";
            this.gridColumn1.FieldName = "UserName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 124;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Franchise";
            this.gridColumn2.FieldName = "FranchiseName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 201;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "gridColumn12";
            this.gridColumn12.FieldName = "FranchiseId";
            this.gridColumn12.Name = "gridColumn12";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "gridColumn3";
            this.gridColumn3.FieldName = "Id";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // lkpFilterFranchise
            // 
            this.lkpFilterFranchise.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lkpFilterFranchise.AutoCompleteDataManager = null;
            this.lkpFilterFranchise.AutoCompleteDisplayFormater = null;
            this.lkpFilterFranchise.AutoCompleteInitialized = false;
            this.lkpFilterFranchise.AutocompleteMinimumTextLength = 0;
            this.lkpFilterFranchise.AutoCompleteText = null;
            this.lkpFilterFranchise.AutoCompleteWhereExpression = null;
            this.lkpFilterFranchise.AutoCompleteWheretermFormater = null;
            this.lkpFilterFranchise.ClearOnLeave = true;
            this.lkpFilterFranchise.DisplayString = null;
            this.lkpFilterFranchise.FieldLabel = null;
            this.lkpFilterFranchise.Location = new System.Drawing.Point(7, 219);
            this.lkpFilterFranchise.LookupPopup = null;
            this.lkpFilterFranchise.Name = "lkpFilterFranchise";
            this.lkpFilterFranchise.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpFilterFranchise.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpFilterFranchise.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpFilterFranchise.Properties.AutoCompleteDataManager = null;
            this.lkpFilterFranchise.Properties.AutoCompleteDisplayFormater = null;
            this.lkpFilterFranchise.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpFilterFranchise.Properties.AutoCompleteText = null;
            this.lkpFilterFranchise.Properties.AutoCompleteWhereExpression = null;
            this.lkpFilterFranchise.Properties.AutoCompleteWheretermFormater = null;
            this.lkpFilterFranchise.Properties.AutoHeight = false;
            this.lkpFilterFranchise.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpFilterFranchise.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpFilterFranchise.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpFilterFranchise.Properties.LookupPopup = null;
            this.lkpFilterFranchise.Properties.NullText = "<<Filter By Franchise>>";
            this.lkpFilterFranchise.Size = new System.Drawing.Size(400, 22);
            this.lkpFilterFranchise.TabIndex = 1;
            this.lkpFilterFranchise.ValidationRules = null;
            this.lkpFilterFranchise.Value = null;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.gridPriviledge);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(435, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 482);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Priviledges";
            // 
            // gridPriviledge
            // 
            this.gridPriviledge.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPriviledge.Location = new System.Drawing.Point(7, 21);
            this.gridPriviledge.MainView = this.priviledgeView;
            this.gridPriviledge.Name = "gridPriviledge";
            this.gridPriviledge.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gridPriviledge.Size = new System.Drawing.Size(453, 455);
            this.gridPriviledge.TabIndex = 127;
            this.gridPriviledge.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.priviledgeView});
            // 
            // priviledgeView
            // 
            this.priviledgeView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.priviledgeView.GridControl = this.gridPriviledge;
            this.priviledgeView.GroupCount = 1;
            this.priviledgeView.GroupFormat = "[#image]{1} {2}";
            this.priviledgeView.Name = "priviledgeView";
            this.priviledgeView.OptionsBehavior.AutoExpandAllGroups = true;
            this.priviledgeView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.priviledgeView.OptionsView.ShowGroupPanel = false;
            this.priviledgeView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn4, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Module";
            this.gridColumn4.FieldName = "ModuleDisplayName";
            this.gridColumn4.GroupFormat.FormatString = "{0}";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 125;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Form";
            this.gridColumn5.FieldName = "FormDisplayName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 229;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Access";
            this.gridColumn6.FieldName = "RoleAllowAccess";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 51;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "View";
            this.gridColumn7.FieldName = "RoleAllowView";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 45;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "New";
            this.gridColumn8.FieldName = "RoleAllowCreate";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 48;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Edit";
            this.gridColumn9.FieldName = "RoleAllowEdit";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 44;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Delete";
            this.gridColumn10.FieldName = "RoleAllowDelete";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 5;
            this.gridColumn10.Width = 47;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Print";
            this.gridColumn11.FieldName = "RoleAllowPrint";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 6;
            this.gridColumn11.Width = 57;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(79, 184);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(203, 12);
            this.lblInfo.TabIndex = 148;
            this.lblInfo.Text = "(Kosongkan bila tidak akan ganti password)";
            this.lblInfo.Visible = false;
            // 
            // UserFranchiseForm
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 507);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserFranchiseForm";
            this.Text = "Master Data - Users";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFranchise.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFilterFranchise.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPriviledge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priviledgeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl gridUsers;
        private DevExpress.XtraGrid.Views.Grid.GridView userView;
        private Common.Component.dLookup lkpFilterFranchise;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.GridControl gridPriviledge;
        private DevExpress.XtraGrid.Views.Grid.GridView priviledgeView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private Common.Component.dTextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private Common.Component.dTextBox txtUsername;
        private System.Windows.Forms.Label label4;
        private Common.Component.dLookup lkpFranchise;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private System.Windows.Forms.Label lblInfo;
    }
}