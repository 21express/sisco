namespace SISCO.Presentation.MasterData.Forms
{
    partial class ManageUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageUserForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnNew = new System.Windows.Forms.Button();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new SISCO.Presentation.Common.Component.dTextBox();
            this.txtPassword = new SISCO.Presentation.Common.Component.dTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lkpUserRole = new SISCO.Presentation.Common.Component.dLookup();
            this.txtUsername = new SISCO.Presentation.Common.Component.dTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbxSearch = new SISCO.Presentation.Common.Component.dTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.grpDetail.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpUserRole.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(256, 16);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(86, 22);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New User";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Username";
            this.gridColumn2.FieldName = "Username";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 125;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Role";
            this.gridColumn3.FieldName = "Role";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 188;
            // 
            // grid
            // 
            this.grid.Location = new System.Drawing.Point(11, 47);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(331, 320);
            this.grid.TabIndex = 3;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(164, 269);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 37);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete User";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(59, 269);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 37);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 118;
            this.label9.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 118;
            this.label3.Text = "User Role";
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.panel1);
            this.grpDetail.Controls.Add(this.lkpUserRole);
            this.grpDetail.Controls.Add(this.txtUsername);
            this.grpDetail.Controls.Add(this.btnDelete);
            this.grpDetail.Controls.Add(this.btnSave);
            this.grpDetail.Controls.Add(this.label9);
            this.grpDetail.Controls.Add(this.label3);
            this.grpDetail.ForeColor = System.Drawing.Color.Black;
            this.grpDetail.Location = new System.Drawing.Point(375, 12);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(324, 416);
            this.grpDetail.TabIndex = 129;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "Detail";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtConfirmPassword);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(9, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 96);
            this.panel1.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 108;
            this.label7.Text = "Update Password";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Capslock = true;
            this.txtConfirmPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConfirmPassword.FieldLabel = null;
            this.txtConfirmPassword.Location = new System.Drawing.Point(77, 59);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(194, 20);
            this.txtConfirmPassword.TabIndex = 7;
            this.txtConfirmPassword.ValidationRules = null;
            // 
            // txtPassword
            // 
            this.txtPassword.Capslock = true;
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassword.FieldLabel = null;
            this.txtPassword.Location = new System.Drawing.Point(77, 33);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(194, 20);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.ValidationRules = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(141, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 13);
            this.label2.TabIndex = 118;
            this.label2.Text = "(kosongkan jika tidak berubah)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 118;
            this.label4.Text = "Confirm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 118;
            this.label1.Text = "Password";
            // 
            // lkpUserRole
            // 
            this.lkpUserRole.AutoCompleteDataManager = null;
            this.lkpUserRole.AutoCompleteDisplayFormater = null;
            this.lkpUserRole.AutoCompleteInitialized = false;
            this.lkpUserRole.AutocompleteMinimumTextLength = 0;
            this.lkpUserRole.AutoCompleteText = null;
            this.lkpUserRole.AutoCompleteWhereExpression = null;
            this.lkpUserRole.AutoCompleteWheretermFormater = null;
            this.lkpUserRole.ClearOnLeave = true;
            this.lkpUserRole.DisplayString = null;
            this.lkpUserRole.EditValue = "";
            this.lkpUserRole.FieldLabel = null;
            this.lkpUserRole.Location = new System.Drawing.Point(87, 61);
            this.lkpUserRole.LookupPopup = null;
            this.lkpUserRole.Name = "lkpUserRole";
            this.lkpUserRole.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpUserRole.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpUserRole.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpUserRole.Properties.AutoCompleteDataManager = null;
            this.lkpUserRole.Properties.AutoCompleteDisplayFormater = null;
            this.lkpUserRole.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpUserRole.Properties.AutoCompleteText = null;
            this.lkpUserRole.Properties.AutoCompleteWhereExpression = null;
            this.lkpUserRole.Properties.AutoCompleteWheretermFormater = null;
            this.lkpUserRole.Properties.AutoHeight = false;
            this.lkpUserRole.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpUserRole.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpUserRole.Properties.LookupPopup = null;
            this.lkpUserRole.Properties.NullText = "<<Choose...>>";
            this.lkpUserRole.Size = new System.Drawing.Size(194, 20);
            this.lkpUserRole.TabIndex = 5;
            this.lkpUserRole.ValidationRules = null;
            this.lkpUserRole.Value = null;
            // 
            // txtUsername
            // 
            this.txtUsername.Capslock = true;
            this.txtUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsername.FieldLabel = null;
            this.txtUsername.Location = new System.Drawing.Point(87, 35);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.OriginalBackColor = System.Drawing.Color.Empty;
            this.txtUsername.Size = new System.Drawing.Size(194, 20);
            this.txtUsername.TabIndex = 4;
            this.txtUsername.ValidationRules = null;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.grid);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(357, 381);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "All Users";
            // 
            // tbxSearch
            // 
            this.tbxSearch.Capslock = true;
            this.tbxSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxSearch.FieldLabel = null;
            this.tbxSearch.Location = new System.Drawing.Point(110, 12);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxSearch.Size = new System.Drawing.Size(174, 20);
            this.tbxSearch.TabIndex = 1;
            this.tbxSearch.ValidationRules = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 136;
            this.label5.Text = "Search Username";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(290, 9);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(79, 23);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // ManageUserForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(712, 438);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.grpDetail);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ManageUserForm";
            this.Text = "Master Users";
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpUserRole.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.GridControl grid;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.GroupBox groupBox2;
        private Common.Component.dTextBox txtUsername;
        private Common.Component.dLookup lkpUserRole;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private Common.Component.dTextBox txtConfirmPassword;
        private Common.Component.dTextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private Common.Component.dTextBox tbxSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFind;
    }
}