using System;
using System.Windows.Forms;

namespace SISCO.Presentation.Common.Forms
{
    public partial class InfoPopup : Form
    {
        public InfoPopup()
        {
            InitializeComponent();
        }

        public DateTime CreatedDate
        {
            // ReSharper disable once ValueParameterNotUsed
            set { lblCreatedDate.Text = value.ToString("dd-MM-yyyy HH:mm"); }
        }

        public string CreatedBy
        {
            set { lblCreatedBy.Text = value; }
        }

        public string CreatedPc
        {
            set { lblCreatedPc.Text = value; }
        }

        public DateTime? ModifiedDate
        {
            // ReSharper disable once ValueParameterNotUsed
            set { if (value != null) lblModifiedDate.Text = ((DateTime)value).ToString("dd-MM-yyyy HH:mm"); }
        }

        public string ModifiedBy
        {
            set { lblModifiedBy.Text = value; }
        }

        public string ModifiedPc
        {
            set { lblModifiedPc.Text = value; }
        }
    }
}
