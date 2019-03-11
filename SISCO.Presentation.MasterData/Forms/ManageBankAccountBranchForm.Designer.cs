namespace SISCO.Presentation.MasterData.Forms
{
    partial class ManageBankAccountBranchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageBankAccountBranchForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label1 = new System.Windows.Forms.Label();
            this.lkpAccount = new SISCO.Presentation.Common.Component.dLookup(this.components);
            this.clbBranch = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lkpAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clbBranch)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "No. Rekening";
            // 
            // lkpAccount
            // 
            this.lkpAccount.AutoCompleteDataManager = null;
            this.lkpAccount.AutoCompleteDisplayFormater = null;
            this.lkpAccount.AutoCompleteInitialized = false;
            this.lkpAccount.AutocompleteMinimumTextLength = 0;
            this.lkpAccount.AutoCompleteText = null;
            this.lkpAccount.AutoCompleteWhereExpression = null;
            this.lkpAccount.AutoCompleteWheretermFormater = null;
            this.lkpAccount.ClearOnLeave = true;
            this.lkpAccount.DisplayString = null;
            this.lkpAccount.FieldLabel = null;
            this.lkpAccount.Location = new System.Drawing.Point(111, 6);
            this.lkpAccount.LookupPopup = null;
            this.lkpAccount.Name = "lkpAccount";
            this.lkpAccount.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpAccount.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.lkpAccount.Properties.Appearance.Options.UseFont = true;
            this.lkpAccount.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpAccount.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpAccount.Properties.AutoCompleteDataManager = null;
            this.lkpAccount.Properties.AutoCompleteDisplayFormater = null;
            this.lkpAccount.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpAccount.Properties.AutoCompleteText = null;
            this.lkpAccount.Properties.AutoCompleteWhereExpression = null;
            this.lkpAccount.Properties.AutoCompleteWheretermFormater = null;
            this.lkpAccount.Properties.AutoHeight = false;
            this.lkpAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("dLookup1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lkpAccount.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpAccount.Properties.LookupPopup = null;
            this.lkpAccount.Properties.NullText = "<<Choose...>>";
            this.lkpAccount.Size = new System.Drawing.Size(305, 24);
            this.lkpAccount.TabIndex = 1;
            this.lkpAccount.ValidationRules = null;
            this.lkpAccount.Value = null;
            // 
            // clbBranch
            // 
            this.clbBranch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbBranch.Location = new System.Drawing.Point(111, 33);
            this.clbBranch.Name = "clbBranch";
            this.clbBranch.Size = new System.Drawing.Size(419, 177);
            this.clbBranch.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Branch";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(111, 213);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 31);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Simpan";
            // 
            // BankAccountBranchForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(551, 249);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clbBranch);
            this.Controls.Add(this.lkpAccount);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "BankAccountBranchForm";
            this.Text = "Atur Akses Rekening Cabang";
            ((System.ComponentModel.ISupportInitialize)(this.lkpAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clbBranch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Common.Component.dLookup lkpAccount;
        private DevExpress.XtraEditors.CheckedListBoxControl clbBranch;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}