using Devenlab.Common;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Modal
{
    public partial class LogoffForm : Form
    {
        private string _username { get; set; }

        public LogoffForm()
        {
            InitializeComponent();

            Load += LogoffLoad;
        }

        private void LogoffLoad(object sender, EventArgs e)
        {
            _username = BaseControl.UserLogin;
            BaseControl.UserLogin = string.Empty;

            lblMessage.Text = "Locked";

            var employee = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default(BaseControl.EmployeeId, "id"));
            lblUsername.Text = _username;
            if (employee != null) lblEmployee.Text = string.Format("{0} {1}", employee.Code, employee.Name);
            else lblEmployee.Text = string.Empty;

            tbxPassword.Clear();
            tbxPassword.Focus();

            btnLogoff.Click += LogOff;
            btnOk.Click += Login;
        }

        private void Login(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxPassword.Text))
            {
                lblMessage.Text = "Password harus diisi.";
                tbxPassword.Focus();
                return;
            }

            var dm = new UsersDataManager();
            var user = dm.Login(_username, tbxPassword.Text);

            if (user != null)
            {
                BaseControl.UserLogin = user.Username;
                Dispose();
            }
            else
            {
                lblMessage.Text = Resources.enter_correct_login;
                tbxPassword.Focus();
            }
        }

        private void LogOff(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(@"Apa anda yakin akan logoff? Jika iya semua form aktif akan ditutup.", "Log Off Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Dispose();
            }
        }
    }
}
