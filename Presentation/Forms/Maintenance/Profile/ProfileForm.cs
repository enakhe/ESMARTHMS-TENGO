using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Infrastructure.Services;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Sessions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Maintenance.Profile
{
    public partial class ProfileForm : Form
    {
        private readonly ApplicationUserController _applicationUserController;
        private bool _continueRunning = true;
        public ProfileForm(ApplicationUserController applicationUserController)
        {
            _applicationUserController = applicationUserController;
            InitializeComponent();
            tabControl1.Appearance = TabAppearance.Normal;
        }


        public async void StartBackgroundTask()
        {
            await Task.Run(() =>
            {
                while (_continueRunning)
                {
                    LoadDetails();
                    Task.Delay(1000).Wait();
                }
            });
        }

        private void LoadDetails()
        {
            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
            if (user != null)
            {
                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtUserName.Text = user.UserName;
                txtEmail.Text = user.Email;
                txtPhoneNumber.Text = user.PhoneNumber;
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            TabPage tabPage = tabControl.TabPages[e.Index];

            Rectangle tabRect = tabControl.GetTabRect(e.Index);
            tabRect.Inflate(-2, -2);

            Color backColor;

            if (tabPage.Text == "Profile")
            {
                backColor = ColorTranslator.FromHtml("#98b4d0");
            }
            else if (tabPage.Text == "Change Password")
            {
                backColor = Color.Red;
            }
            else
            {
                backColor = e.State == DrawItemState.Selected ? Color.LightBlue : Color.LightGray;
            }

            using (Brush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, tabRect);
            }

            Font font = new Font("Segoe UI", 13, FontStyle.Bold);

            TextRenderer.DrawText(e.Graphics, tabPage.Text, font, tabRect, tabPage.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            LoadDetails();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtUserName.Text);
            if (isNull == false)
            {
                ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
                if (user != null)
                {
                    user.UserName = txtUserName.Text;
                    user.FirstName = txtFirstName.Text.ToUpper();
                    user.LastName = txtLastName.Text.ToUpper();
                    user.FirstName = txtFirstName.Text.ToUpper() + " " + txtLastName.Text.ToUpper();
                    user.Email = txtEmail.Text;
                    user.PhoneNumber = txtPhoneNumber.Text;

                    _applicationUserController.UpdateUser(user);
                    MessageBox.Show("Profile updated sucessfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("The username field is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtOldPassword.Text, txtNewPassword.Text);
            if (isNull == false)
            {
                ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
                if (user != null)
                {
                    bool isSame = _applicationUserController.VerifyPassword(txtOldPassword.Text, user.PasswordHash);
                    if (isSame == true)
                    {
                        user.PasswordHash = _applicationUserController.HashPassword(txtNewPassword.Text);
                        _applicationUserController.UpdateUser(user);
                        MessageBox.Show("Password updated sucessfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("The passwords field is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPassword.Checked == false)
            {
                txtNewPassword.UseSystemPasswordChar = true;
                txtOldPassword.UseSystemPasswordChar = true;

            }
            else
            {
                txtNewPassword.UseSystemPasswordChar = false;
                txtOldPassword.UseSystemPasswordChar = false;
            }
        }
    }
}
