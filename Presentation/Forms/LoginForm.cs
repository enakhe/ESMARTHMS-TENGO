using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Infrastructure.Services;
using ESMART_HMS.Presentation.Sessions;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;
        public LoginForm(AuthService authService)
        {
            _authService = authService;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            ApplicationUser user = _authService.Login(username, password);

            if (user != null)
            {
                this.Cursor = Cursors.WaitCursor;
                AuthSession.CurrentUser = user;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPassword.Checked == false)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
            }
        }
    }
}
