using System.Windows.Forms;

namespace SISCO.Presentation.Common.UserControls
{
    public partial class ucIconYesNo : UserControl
    {
        public ucIconYesNo()
        {
            InitializeComponent();
        }

        public string Label
        {
            set { lblText.Text = value; }
            get { return lblText.Text; }
        }

        private bool _icon;
        public bool Icon
        {
            set
            {
                _icon = value;
                if (value) pb.Image = Properties.Resources.yes;
                else pb.Image = Properties.Resources.no;
            }

            get
            {
                return _icon;
            }
        }
    }
}
