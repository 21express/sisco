using System;
using System.Windows.Forms;
using SISCO.App.MasterData;

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
            lblDate.Text = DateTime.Now.ToString("dd MMM yyyy");
            lblTime.Text = DateTime.Now.ToString("HH:mm");

            using (var dm = new ConfigDataManager())
            {
                var dt = dm.GetServerDateTime();

                lblDateServer.Text = dt.ToString("dd MMM yyyy");
                lblTimeServer.Text = dt.ToString("HH:mm");
            }
        }
    }
}
