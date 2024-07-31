using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Tools.Options.Accounts
{
    public partial class UserForm : Form
    {
        private readonly ApplicationUserController _userController;
        public UserForm(ApplicationUserController applicationUserController)
        {
            InitializeComponent();
            LoadPassword();
            _userController = applicationUserController;
        }

        public void LoadPassword()
        {
            Random random = new Random();
            txtPassword.Text = random.Next(1000000, 3000000).ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtFirstName.Text, txtLastName.Text);
            if (isNull == false)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    FirstName = txtFirstName.Text.ToUpper(),
                    LastName = txtLastName.Text.ToUpper(),
                    PhoneNumber = txtPhoneNumber.Text,
                    Email = txtEmail.Text,
                    UserName = txtUsername.Text.ToUpper(),
                    PasswordHash = txtPassword.Text,
                };
                user.FullName = user.FirstName + " " + user.LastName;
                _userController.AddApplicationUser(user);
                MessageBox.Show("Account created successfully", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("First name and Last name are required", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtFirstName.Text, txtLastName.Text);
            if (isNull == false)
            {
                Random random = new Random();
                txtUsername.Text = txtFirstName.Text.ToUpper() + txtLastName.Text.ToUpper() + random.Next(1000, 2000);
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtFirstName.Text, txtLastName.Text);
            if (isNull == false)
            {
                Random random = new Random();
                txtUsername.Text = txtFirstName.Text.ToUpper() + txtLastName.Text.ToUpper() + random.Next(1000, 2000);
            }
        }
    }
}
