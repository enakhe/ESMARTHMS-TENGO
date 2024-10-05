using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Maintenance.User_Settings.User
{
    public partial class AddUserForm : Form
    {
        private readonly ApplicationUserController _userController;
        private readonly RoleController _roleController;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly SystemSetupController _systemSetupController;
        public AddUserForm(ApplicationUserController userController, RoleController roleController, IUserRoleRepository userRoleRepository, SystemSetupController systemSetupController)
        {
            _userController = userController;
            _roleController = roleController;
            _userRoleRepository = userRoleRepository;
            _systemSetupController = systemSetupController;
            InitializeComponent();
            LoadPassword();
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            LoadRole();
        }

        private void LoadRole()
        {
            List<RoleViewModel> roles = _roleController.GetAllRoles();
            if (roles != null)
            {
                txtRole.DataSource = roles;
            }
        }

        public void LoadPassword()
        {
            Random random = new Random();
            txtPassword.Text = "Password" + random.Next(10000, 30000).ToString();
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtFirstName.Text);
            if (isNull == false)
            {
                Random random = new Random();
                txtUsername.Text = txtFirstName.Text.ToUpper() + random.Next(1000, 2000);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CompanyInformation foundCompany = _systemSetupController.GetCompanyInfo();

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
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,    
                    };
                    user.FullName = user.FirstName + " " + user.LastName;
                    _userController.AddApplicationUser(user);
                    Domain.Entities.Role role = _roleController.GetRoleById(txtRole.SelectedValue.ToString());
                    Random random = new Random();

                    ApplicationUserRole applicationUserRole = new ApplicationUserRole()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserRoleId = "USR" + random.Next(10000, 20000),
                        ApplicationUser = user,
                        UserId = user.Id,
                        Role = role,
                        RoleId = role.Id,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        IsTrashed = false
                    };
                    _userRoleRepository.AssignUserToRole(applicationUserRole);
                    string userString = $"Id = {user.Id}\n" +
     $"User Id = {user.UserId}\n" +
     $"First Name = {user.FirstName}\n" +
     $"Last Name = {user.LastName}\n" +
     $"Full Name = {user.FullName}\n" +
     $"User Name = {user.UserName}\n" +
     $"Email = {user.Email}\n" +
     $"Phone Number = {user.PhoneNumber}\n" +
     $"Date Created = {user.DateCreated.ToString("yyyy-MM-dd HH:mm:ss")}\n" +
     $"Date Modified = {user.DateModified.ToString("yyyy-MM-dd HH:mm:ss")}";
                    if (foundCompany != null)
                    {
                        if (foundCompany.Email != null)
                        {
                            await EmailHelper.SendEmail(foundCompany.Email, "User Added", userString);
                        }
                    }
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }
    }
}
