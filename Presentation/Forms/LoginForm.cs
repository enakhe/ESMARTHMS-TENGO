using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Forms;
using ESMART_HMS.Presentation.ViewModels;
using ESMART_HMS.Services;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;
        private readonly CustomerViewModel _customerViewModel;
        public LoginForm(AuthService authService, CustomerViewModel customerViewModel)
        {
            _authService = authService;
            _customerViewModel = customerViewModel;
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            User user = _authService.Login(username, password);

            if (user != null)
            {
                this.Cursor = Cursors.WaitCursor;
                Home dashboard = new Home(_customerViewModel);
                this.Hide();
                dashboard.Show();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

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

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
