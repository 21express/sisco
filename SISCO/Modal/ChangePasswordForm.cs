using System;
using System.Windows.Forms;
using Devenlab.Common;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Properties;
using System.Security.Permissions;

namespace SISCO.Modal
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();

            txtUsername.Text = BaseControl.UserLogin;
            txtUsername.Enabled = false;

            txtOldPassword.CharacterCasing = CharacterCasing.Normal;
            txtOldPassword.PasswordChar = '*';
            txtNewPassword.CharacterCasing = CharacterCasing.Normal;
            txtNewPassword.PasswordChar = '*';
            txtConfirmPassword.CharacterCasing = CharacterCasing.Normal;
            txtConfirmPassword.PasswordChar = '*';

            btnOK.Click += ChangePassword;
        }

        private void ChangePassword(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOldPassword.Text))
            {
                txtOldPassword.Focus();
                MessageBox.Show(@"Please enter your OLD password!");
                return;
            }

            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                txtNewPassword.Focus();
                MessageBox.Show(@"Please enter your NEW password!");
                return;
            }

            if (!txtNewPassword.Text.Equals(txtConfirmPassword.Text))
            {
                txtConfirmPassword.Focus();
                MessageBox.Show(@"Confirm password must be the same as the new password!");
                return;
            }

            var userDm = new UsersDataManager();
            var user = userDm.Login(txtUsername.Text, txtOldPassword.Text);

            if (user == null)
            {
                txtOldPassword.Focus();
                MessageBox.Show(@"Incorrect old password!");
                return;
            }

            user.Password = UsersDataManager.GetMd5Hash(txtNewPassword.Text);
            userDm.Update<UsersModel>(user);

            MessageBox.Show(@"Your password has been changed");

            Close();
        }
    }
}