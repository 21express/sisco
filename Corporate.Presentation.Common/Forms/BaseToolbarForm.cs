using System;

namespace Corporate.Presentation.Common.Forms
{
    public partial class BaseToolbarForm : BaseForm
    {
        public BaseToolbarForm()
        {
            InitializeComponent();
            Load += LoadBase;

            tbxSearch_Code.Location = new System.Drawing.Point(71, rb.Size.Height + 2);
            label1.Location = new System.Drawing.Point(17, rb.Size.Height + 5);
        }

        public string ToolbarCode
        {
            set { rbSearch_Code.EditValue = value; }
            get { return (string) rbSearch_Code.EditValue; }
        }

        public bool EnableBtnSearch
        {
            set { rbPage_Search.Enabled = value; }
            get { return rbPage_Search.Enabled; }
        }

        public bool EnableBtnRefresh
        {
            set { rbPage_Refresh.Enabled = value; }
            get { return rbPage_Refresh.Enabled; }
        }

        public bool EnableBtnSave
        {
            set { rbData_Save.Enabled = value; }
            get { return rbData_Save.Enabled; }
        }

        public bool EnableBtnDelete
        {
            set { rbData_Delete.Enabled = value; }
            get { return rbData_Delete.Enabled; }
        }

        public bool EnableBtnPrint
        {
            set { rbLayout_Print.Enabled = value; }
            get { return rbLayout_Print.Enabled; }
        }

        public bool EnableBtnPrintPreview
        {
            set { rbLayout_PrintPreview.Enabled = value; }
            get { return rbLayout_PrintPreview.Enabled; }
        }

        private void LoadBase(object sender, EventArgs e)
        {
            //SetDirtyEvent();
        }

        /*public override void EnabledForm(bool enabled)
        {
            base.EnabledForm(enabled);

            rbSearch_Code.Enabled = true;
        }*/

        protected void FirstState()
        {
            rbSearch_Code.EditValue = string.Empty;
            rbData_New.Enabled = true;
            rbData_Save.Enabled = false;
            rbData_Delete.Enabled = false;
            rbNavigation_First.Enabled = true;
            rbNavigation_Previous.Enabled = false;
            rbNavigation_Next.Enabled = false;
            rbNavigation_Last.Enabled = true;
            rbLayout_Print.Enabled = false;
            rbLayout_PrintPreview.Enabled = false;
        }
    }
}
