namespace BarcodeMachine
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navPrinter = new DevExpress.XtraNavBar.NavBarItem();
            this.navKurir = new DevExpress.XtraNavBar.NavBarItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlKurir = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lkpMessenger = new SISCO.Presentation.Common.Component.dLookup();
            this.btnBarcodeClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlPrinter = new System.Windows.Forms.Panel();
            this.btnPrintClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintOk = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxPrinter = new DevExpress.XtraEditors.ButtonEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dbStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.tbxPcs = new SISCO.Presentation.Common.Component.dTextBoxNumber();
            this.lblWarning = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlKurir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpMessenger.Properties)).BeginInit();
            this.pnlPrinter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPrinter.Properties)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPcs.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navPrinter,
            this.navKurir});
            this.navBarControl1.LargeImages = this.imageCollection1;
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 173;
            this.navBarControl1.OptionsNavPane.ShowOverflowButton = false;
            this.navBarControl1.OptionsNavPane.ShowOverflowPanel = false;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new System.Drawing.Size(173, 445);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "Control";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Main Control";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Small;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navPrinter),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navKurir)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navPrinter
            // 
            this.navPrinter.Caption = "Printer Setting";
            this.navPrinter.LargeImageIndex = 0;
            this.navPrinter.Name = "navPrinter";
            this.navPrinter.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navPrinter_LinkClicked);
            // 
            // navKurir
            // 
            this.navKurir.Caption = "Kurir";
            this.navKurir.LargeImageIndex = 1;
            this.navKurir.Name = "navKurir";
            this.navKurir.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navKurir_LinkClicked);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(64, 64);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::BarcodeMachine.Properties.Resources.printconf_gui, "printconf_gui", typeof(global::BarcodeMachine.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "printconf_gui");
            this.imageCollection1.InsertImage(global::BarcodeMachine.Properties.Resources.messenger, "messenger", typeof(global::BarcodeMachine.Properties.Resources), 1);
            this.imageCollection1.Images.SetKeyName(1, "messenger");
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlKurir);
            this.pnlMain.Controls.Add(this.pnlPrinter);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(173, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(735, 445);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlKurir
            // 
            this.pnlKurir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlKurir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.pnlKurir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKurir.Controls.Add(this.lblWarning);
            this.pnlKurir.Controls.Add(this.tbxPcs);
            this.pnlKurir.Controls.Add(this.label7);
            this.pnlKurir.Controls.Add(this.lkpMessenger);
            this.pnlKurir.Controls.Add(this.btnBarcodeClose);
            this.pnlKurir.Controls.Add(this.btnPrint);
            this.pnlKurir.Controls.Add(this.label4);
            this.pnlKurir.Controls.Add(this.panel3);
            this.pnlKurir.Controls.Add(this.label5);
            this.pnlKurir.Controls.Add(this.label6);
            this.pnlKurir.Font = new System.Drawing.Font("Meiryo", 10.25F);
            this.pnlKurir.Location = new System.Drawing.Point(6, 5);
            this.pnlKurir.Name = "pnlKurir";
            this.pnlKurir.Size = new System.Drawing.Size(723, 435);
            this.pnlKurir.TabIndex = 3;
            this.pnlKurir.Visible = false;
            this.pnlKurir.VisibleChanged += new System.EventHandler(this.pnlKurir_VisibleChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Meiryo", 10.25F);
            this.label7.Location = new System.Drawing.Point(28, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 21);
            this.label7.TabIndex = 8;
            this.label7.Text = "Jumlah Koli:";
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
            this.lkpMessenger.Location = new System.Drawing.Point(139, 81);
            this.lkpMessenger.LookupPopup = null;
            this.lkpMessenger.Name = "lkpMessenger";
            this.lkpMessenger.OriginalBackColor = System.Drawing.Color.Empty;
            this.lkpMessenger.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 10.25F);
            this.lkpMessenger.Properties.Appearance.Options.UseFont = true;
            this.lkpMessenger.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lkpMessenger.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lkpMessenger.Properties.AutoCompleteDataManager = null;
            this.lkpMessenger.Properties.AutoCompleteDisplayFormater = null;
            this.lkpMessenger.Properties.AutocompleteMinimumTextLength = 2;
            this.lkpMessenger.Properties.AutoCompleteText = null;
            this.lkpMessenger.Properties.AutoCompleteWhereExpression = null;
            this.lkpMessenger.Properties.AutoCompleteWheretermFormater = null;
            this.lkpMessenger.Properties.AutoHeight = false;
            this.lkpMessenger.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("lkpMessenger.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lkpMessenger.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lkpMessenger.Properties.LookupPopup = null;
            this.lkpMessenger.Properties.NullText = "<<Choose...>>";
            this.lkpMessenger.Size = new System.Drawing.Size(552, 28);
            this.lkpMessenger.TabIndex = 7;
            this.lkpMessenger.ValidationRules = null;
            this.lkpMessenger.Value = null;
            // 
            // btnBarcodeClose
            // 
            this.btnBarcodeClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBarcodeClose.Appearance.Font = new System.Drawing.Font("Meiryo", 9.25F);
            this.btnBarcodeClose.Appearance.Options.UseFont = true;
            this.btnBarcodeClose.Location = new System.Drawing.Point(496, 370);
            this.btnBarcodeClose.Name = "btnBarcodeClose";
            this.btnBarcodeClose.Size = new System.Drawing.Size(57, 47);
            this.btnBarcodeClose.TabIndex = 6;
            this.btnBarcodeClose.Text = "Tutup";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Meiryo", 9.25F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Location = new System.Drawing.Point(559, 370);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(132, 47);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Print";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Meiryo", 9.25F);
            this.label4.Location = new System.Drawing.Point(28, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(663, 52);
            this.label4.TabIndex = 4;
            this.label4.Text = "Printer yang digunakan adalah printer barcode. Tidak diperkenankan mengubah konfi" +
    "gurasi pada printer. Jika menemukan kesulitan silakan menghubungi tim IT.";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(32, 148);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(659, 1);
            this.panel3.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Meiryo", 10.25F);
            this.label5.Location = new System.Drawing.Point(28, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "Nama Kurir:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Meiryo", 18F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(25, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(236, 36);
            this.label6.TabIndex = 0;
            this.label6.Text = "Print Barcode Kurir";
            // 
            // pnlPrinter
            // 
            this.pnlPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPrinter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlPrinter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrinter.Controls.Add(this.btnPrintClose);
            this.pnlPrinter.Controls.Add(this.btnPrintOk);
            this.pnlPrinter.Controls.Add(this.label3);
            this.pnlPrinter.Controls.Add(this.panel1);
            this.pnlPrinter.Controls.Add(this.tbxPrinter);
            this.pnlPrinter.Controls.Add(this.label2);
            this.pnlPrinter.Controls.Add(this.label1);
            this.pnlPrinter.Font = new System.Drawing.Font("Meiryo", 10.25F);
            this.pnlPrinter.Location = new System.Drawing.Point(6, 5);
            this.pnlPrinter.Name = "pnlPrinter";
            this.pnlPrinter.Size = new System.Drawing.Size(723, 435);
            this.pnlPrinter.TabIndex = 2;
            this.pnlPrinter.Visible = false;
            this.pnlPrinter.VisibleChanged += new System.EventHandler(this.pnlPrinter_VisibleChanged);
            // 
            // btnPrintClose
            // 
            this.btnPrintClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintClose.Appearance.Font = new System.Drawing.Font("Meiryo", 9.25F);
            this.btnPrintClose.Appearance.Options.UseFont = true;
            this.btnPrintClose.Location = new System.Drawing.Point(496, 370);
            this.btnPrintClose.Name = "btnPrintClose";
            this.btnPrintClose.Size = new System.Drawing.Size(57, 47);
            this.btnPrintClose.TabIndex = 6;
            this.btnPrintClose.Text = "Tutup";
            // 
            // btnPrintOk
            // 
            this.btnPrintOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintOk.Appearance.Font = new System.Drawing.Font("Meiryo", 9.25F, System.Drawing.FontStyle.Bold);
            this.btnPrintOk.Appearance.Options.UseFont = true;
            this.btnPrintOk.Location = new System.Drawing.Point(559, 370);
            this.btnPrintOk.Name = "btnPrintOk";
            this.btnPrintOk.Size = new System.Drawing.Size(132, 47);
            this.btnPrintOk.TabIndex = 5;
            this.btnPrintOk.Text = "Simpan";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Meiryo", 9.25F);
            this.label3.Location = new System.Drawing.Point(28, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(663, 133);
            this.label3.TabIndex = 4;
            this.label3.Text = "Printer yang digunakan adalah printer barcode. Tidak diperkenankan mengubah konfi" +
    "gurasi pada printer. Jika menemukan kesulitan silakan menghubungi tim IT.";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(32, 123);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 1);
            this.panel1.TabIndex = 3;
            // 
            // tbxPrinter
            // 
            this.tbxPrinter.Location = new System.Drawing.Point(152, 81);
            this.tbxPrinter.Name = "tbxPrinter";
            this.tbxPrinter.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 10.25F);
            this.tbxPrinter.Properties.Appearance.Options.UseFont = true;
            this.tbxPrinter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.tbxPrinter.Size = new System.Drawing.Size(539, 28);
            this.tbxPrinter.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo", 10.25F);
            this.label2.Location = new System.Drawing.Point(28, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Printer Barcode:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo", 18F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Setting Printer";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dbStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(908, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // dbStrip
            // 
            this.dbStrip.Name = "dbStrip";
            this.dbStrip.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.dbStrip.Size = new System.Drawing.Size(67, 20);
            this.dbStrip.Text = "Database";
            this.dbStrip.Click += new System.EventHandler(this.dbStrip_Click);
            // 
            // tbxPcs
            // 
            this.tbxPcs.EditMask = "###,###,###,###,###,##0.00";
            this.tbxPcs.FieldLabel = null;
            this.tbxPcs.Location = new System.Drawing.Point(139, 114);
            this.tbxPcs.Name = "tbxPcs";
            this.tbxPcs.OriginalBackColor = System.Drawing.Color.Empty;
            this.tbxPcs.Properties.AllowMouseWheel = false;
            this.tbxPcs.Properties.Appearance.Font = new System.Drawing.Font("Meiryo", 10.25F);
            this.tbxPcs.Properties.Appearance.Options.UseFont = true;
            this.tbxPcs.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxPcs.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxPcs.Properties.Mask.BeepOnError = true;
            this.tbxPcs.Properties.Mask.EditMask = "###,###,###,###,###,##0.00";
            this.tbxPcs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbxPcs.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbxPcs.ReadOnly = false;
            this.tbxPcs.Size = new System.Drawing.Size(100, 28);
            this.tbxPcs.TabIndex = 9;
            this.tbxPcs.TextAlign = null;
            this.tbxPcs.ValidationRules = null;
            this.tbxPcs.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblWarning
            // 
            this.lblWarning.Font = new System.Drawing.Font("Meiryo", 9.25F);
            this.lblWarning.ForeColor = System.Drawing.Color.Yellow;
            this.lblWarning.Location = new System.Drawing.Point(28, 329);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(663, 29);
            this.lblWarning.TabIndex = 10;
            this.lblWarning.Text = "Tidak mendapatkan koneksi. Silakan menghubungi IT.";
            this.lblWarning.Visible = false;
            // 
            // MainForm
            // 
            this.Appearance.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(908, 445);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Barcode Machine";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlKurir.ResumeLayout(false);
            this.pnlKurir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpMessenger.Properties)).EndInit();
            this.pnlPrinter.ResumeLayout(false);
            this.pnlPrinter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPrinter.Properties)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPcs.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraNavBar.NavBarItem navPrinter;
        private DevExpress.XtraNavBar.NavBarItem navKurir;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlPrinter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ButtonEdit tbxPrinter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnPrintOk;
        private DevExpress.XtraEditors.SimpleButton btnPrintClose;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dbStrip;
        private System.Windows.Forms.Panel pnlKurir;
        private DevExpress.XtraEditors.SimpleButton btnBarcodeClose;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private SISCO.Presentation.Common.Component.dLookup lkpMessenger;
        private System.Windows.Forms.Label label7;
        private SISCO.Presentation.Common.Component.dTextBoxNumber tbxPcs;
        private System.Windows.Forms.Label lblWarning;
    }
}