using System;
using System.Windows.Forms;

namespace SISCO.Presentation.Common.Forms
{
    public partial class BaseToolbarForm : BaseForm
    {
        public BaseToolbarForm()
        {
            InitializeComponent();

            tsBaseTxt_Code.CharacterCasing = CharacterCasing.Upper;

            Load += LoadBase;
        }

        public string ToolbarCode
        {
            set { tsBaseTxt_Code.Text = value; }
            get { return tsBaseTxt_Code.Text; }
        }

        public bool VisibleBtnNew
        {
            set
            {
                tsBaseBtn_New.Visible = value;
                tsBase_Separator1.Visible = value;

                NavigationMenu.Separator1.Visible = value;
                NavigationMenu.NewStrip.Visible = value;
            }
            get { return tsBaseBtn_New.Visible; }
        }

        public bool VisibleBtnSave
        {
            set { tsBaseBtn_Save.Visible = value; }
            get { return tsBaseBtn_Save.Visible; }
        }

        public bool VisibleBtnDelete
        {
            set { tsBaseBtn_Delete.Visible = value; }
            get { return tsBaseBtn_Delete.Visible; }
        }

        public bool VisibleBtnPrint
        {
            set
            {
                tsBaseBtn_Print.Visible = value;

                if (!value && !tsBaseBtn_PrintPreview.Visible)
                {
                    tsBase_Separator4.Visible = false;
                }
            }
            get { return tsBaseBtn_Print.Visible; }
        }

        public bool VisibleBtnPrintPreview
        {
            set
            {
                tsBaseBtn_PrintPreview.Visible = value;

                if (!tsBaseBtn_Print.Visible && !value)
                {
                    tsBase_Separator4.Visible = false;
                }
            }
            get { return tsBaseBtn_PrintPreview.Visible; }
        }

        public bool VisibleBtnSearch
        {
            set { tsBaseBtn_Search.Visible = value; }
            get { return tsBaseBtn_Search.Visible; }
        }

        public bool VisibleBtnPdf
        {
            set
            {
                tsBaseBtn_Pdf.Visible = value;
                tsBase_Separator6.Visible = value;
            }

            get { return tsBaseBtn_Pdf.Visible; }
        }

        public bool VisibleBtnQr
        {
            set
            {
                tsBaseBtn_Qr.Visible = value;
                tsBase_Separator7.Visible = value;
            }

            get { return tsBaseBtn_Qr.Visible; }
        }

        public bool EnableBtnSearch
        {
            set { tsBaseBtn_Search.Enabled = value; }
            get { return tsBaseBtn_Search.Enabled; }
        }

        public bool EnableBtnRefresh
        {
            set { tsBaseBtn_Refresh.Enabled = value; }
            get { return tsBaseBtn_Refresh.Enabled; }
        }

        public bool EnableBtnSave
        {
            set { tsBaseBtn_Save.Enabled = value; }
            get { return tsBaseBtn_Save.Enabled; }
        }

        public bool EnableBtnDelete
        {
            set { tsBaseBtn_Delete.Enabled = value; }
            get { return tsBaseBtn_Delete.Enabled; }
        }

        public bool EnableBtnPrint
        {
            set { tsBaseBtn_Print.Enabled = value; }
            get { return tsBaseBtn_Print.Enabled; }
        }

        public bool EnableBtnPrintPreview
        {
            set { tsBaseBtn_PrintPreview.Enabled = value; }
            get { return tsBaseBtn_PrintPreview.Enabled; }
        }

        public bool EnableBtnPdf
        {
            set { tsBaseBtn_Pdf.Enabled = value; }

            get { return tsBaseBtn_Pdf.Enabled; }
        }

        public bool EnableBtnQr
        {
            set { tsBaseBtn_Qr.Enabled = value; }

            get { return tsBaseBtn_Qr.Enabled; }
        }

        public bool VisibleNavigation
        {
            set
            {
                tsBaseBtn_First.Visible = value;
                tsBaseBtn_Last.Visible = value;
                tsBaseBtn_Previous.Visible = value;
                tsBaseBtn_Next.Visible = value;
                tsBase_Separator3.Visible = value;
            }

            get
            {
                return tsBaseBtn_First.Visible;
            }
        }

        private void LoadBase(object sender, EventArgs e)
        {
            SetDirtyEvent();
        }

        public override void EnabledForm(bool enabled)
        {
            base.EnabledForm(enabled);

            tsBaseTxt_Code.Enabled = true;
        }

        protected void FirstState()
        {
            ClearForm();
            tsBaseTxt_Code.Text = string.Empty;
            tsBaseBtn_New.Enabled = true;
            tsBaseBtn_Save.Enabled = false;
            tsBaseBtn_Delete.Enabled = false;
            tsBaseBtn_First.Enabled = true;
            tsBaseBtn_Previous.Enabled = false;
            tsBaseBtn_Next.Enabled = false;
            tsBaseBtn_Last.Enabled = true;
            tsBaseBtn_Print.Enabled = false;
            tsBaseBtn_PrintPreview.Enabled = false;
        }

        public void Buttons()
        {
            NavigationMenu.NewStrip.Enabled = tsBaseBtn_New.Enabled;
            NavigationMenu.SaveStrip.Enabled = tsBaseBtn_Save.Enabled;
            NavigationMenu.DeleteStrip.Enabled = tsBaseBtn_Delete.Enabled;
            NavigationMenu.TopStrip.Enabled = tsBaseBtn_First.Enabled;
            NavigationMenu.PreviousStrip.Enabled = tsBaseBtn_Previous.Enabled;
            NavigationMenu.NextStrip.Enabled = tsBaseBtn_Next.Enabled;
            NavigationMenu.BottomStrip.Enabled = tsBaseBtn_Last.Enabled;
            NavigationMenu.FindStrip.Enabled = tsBaseBtn_Search.Enabled;
            NavigationMenu.RefreshStrip.Enabled = tsBaseBtn_Refresh.Enabled;

            NavigationMenu.NewStrip.Enabled = tsBaseBtn_New.Visible;
            NavigationMenu.SaveStrip.Enabled = tsBaseBtn_Save.Visible;
            NavigationMenu.DeleteStrip.Enabled = tsBaseBtn_Delete.Visible;
            NavigationMenu.TopStrip.Enabled = tsBaseBtn_First.Visible;
            NavigationMenu.PreviousStrip.Enabled = tsBaseBtn_Previous.Visible;
            NavigationMenu.NextStrip.Enabled = tsBaseBtn_Next.Visible;
            NavigationMenu.BottomStrip.Enabled = tsBaseBtn_Last.Visible;
            NavigationMenu.FindStrip.Enabled = tsBaseBtn_Search.Visible;
            NavigationMenu.RefreshStrip.Enabled = tsBaseBtn_Refresh.Visible;
        }
    }
}
