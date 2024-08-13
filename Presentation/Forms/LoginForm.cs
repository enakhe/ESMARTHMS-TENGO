using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Infrastructure.Services;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Sessions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;
        private readonly GuestController _customerController;
        private readonly RoomController _roomController;
        public LoginForm(AuthService authService, GuestController customerViewModel, RoomController roomController)
        {
            _authService = authService;
            _customerController = customerViewModel;
            InitializeComponent();
            _roomController = roomController;
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            ApplicationUser user = _authService.Login(username, password);

            if (user != null)
            {
                this.Cursor = Cursors.WaitCursor;
                AuthSession.CurrentUser = user;
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                var homeForm = serviceProvider.GetRequiredService<Home>();
                this.Hide();
                homeForm.ShowDialog();
            }
        }
    }
}
