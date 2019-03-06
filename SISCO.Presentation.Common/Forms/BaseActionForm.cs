using System;

namespace SISCO.Presentation.Common.Forms
{
    public partial class BaseActionForm : BaseForm
    {
        public BaseActionForm()
        {
            InitializeComponent();

            lblCreatedOn.Text = @"N/A";
            lblCreatedBy.Text = @"N/A";
            lblModifiedOn.Text = @"N/A";
            lblModifiedBy.Text = @"N/A";

            BtnBaseNew.Click += NewClick;
            BtnBaseSave.Click += SaveClick;

            BtnBaseFirst.Click += GotoFirstRecord;
            BtnBasePrevious.Click += GotoPreviousRecord;
            BtnBaseNext.Click += GotoNextRecord;
            BtnBaseLast.Click += GotoLastRecord;
        }

        protected override void SetPagingState()
        {
            base.SetPagingState();
            BtnBaseFirst.Enabled = CurrentIndexPage > 1;
            BtnBasePrevious.Enabled = CurrentIndexPage > 1;
            BtnBaseNext.Enabled = !(CurrentIndexPage >= TotalPage);
            BtnBaseLast.Enabled = !(CurrentIndexPage >= TotalPage);
        }

        protected bool NewEnabled
        {
            set { BtnBaseNew.Enabled = value; }
        }

        protected bool SaveEnabled
        {
            set { BtnBaseSave.Enabled = value; }
        }

        protected bool FirstEnabled
        {
            set { BtnBaseFirst.Enabled = value; }
        }

        protected bool PreviousEnabled
        {
            set { BtnBasePrevious.Enabled = value; }
        }

        protected bool NextEnabled
        {
            set { BtnBaseNext.Enabled = value; }
        }

        protected bool LastEnabled
        {
            set { BtnBaseLast.Enabled = value; }
        }

        protected virtual void NewClick(object sender, EventArgs e)
        {
            base.OnClick(e);
        }

        protected virtual void SaveClick(object sender, EventArgs e)
        {
            base.OnClick(e);
        }

        protected string CreatedOn
        {
            set
            {
                if (string.IsNullOrEmpty(value)) lblCreatedOn.Text = "N/A";
                else lblCreatedOn.Text = value;
            }

            get { return lblCreatedOn.Text; }
        }

        protected string CreatedBy
        {
            set
            {
                if (string.IsNullOrEmpty(value)) lblCreatedBy.Text = "N/A";
                else lblCreatedBy.Text = value;
            }
            get { return lblCreatedBy.Text; }
        }

        protected string ModifiedOn
        {
            set
            {
                if (string.IsNullOrEmpty(value)) lblModifiedOn.Text = "N/A";
                else lblModifiedOn.Text = value;
            }
            get { return lblModifiedOn.Text; }
        }

        protected string ModifiedBy
        {
            set
            {
                if (string.IsNullOrEmpty(value)) lblModifiedBy.Text = "N/A";
                else lblModifiedBy.Text = value;
            }
            get { return lblModifiedBy.Text; }
        }
    }
}
