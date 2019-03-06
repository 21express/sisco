using System;
using System.Windows.Forms;
using SISCO.App.Franchise;
using SISCO.Models;
using Franchise.Presentation.Common;

namespace Franchise.Modal
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
            btnCancel.Click += (sender, args) => Dispose();
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

            var userDm = new UserFranchiseDataManager();
            var user = userDm.Login(txtUsername.Text, txtOldPassword.Text, BaseControl.FranchiseId);

            if (user == null)
            {
                txtOldPassword.Focus();
                MessageBox.Show(@"Incorrect old password!");
                return;
            }

            user.Password = UserFranchiseDataManager.GetMd5Hash(txtNewPassword.Text);
            userDm.Update<UserFranchiseModel>(user);

            MessageBox.Show(@"Your password has been changed");

            Close();
        }
    }
}