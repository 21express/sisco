using System;
using System.Windows.Forms;

namespace SISCO.Modal
{
    public partial class DateTimeForm : Form
    {
        public DateTimeForm()
        {
            InitializeComponent();

            Shown += DateTimeFormShow;
            btnClose.Click += (sender, args) => Dispose();
        }

        private void DateTimeFormShow(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
            lblTime.Text = DateTime.Now.ToString("hh:mm tt");
        }
    }
}
