using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;
        private readonly CustomerController _customerController;
        private readonly RoomController _roomController;
        public LoginForm(AuthService authService, CustomerController customerViewModel, RoomController roomController)
        {
            _authService = authService;
            _customerController = customerViewModel;
            InitializeComponent();
            _roomController = roomController;
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

                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                var homeForm = serviceProvider.GetRequiredService<Home>();
                this.Hide();
                homeForm.Show();
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
