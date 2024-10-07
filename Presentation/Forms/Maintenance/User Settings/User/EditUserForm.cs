using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Maintenance.User_Settings.User
{
    public partial class EditUserForm : Form
    {
        private readonly ApplicationUserController _userController;
        private readonly RoleController _roleController;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly SystemSetupController _systemSetupController;
        private string _id;

        public EditUserForm(ApplicationUserController userController, RoleController roleController, IUserRoleRepository userRoleRepository, SystemSetupController systemSetupController, string id)
        {
            _userController = userController;
            _roleController = roleController;
            _userRoleRepository = userRoleRepository;
            _systemSetupController = systemSetupController;
            _id = id;
            InitializeComponent();
            LoadPassword();
            LoadRole();
            LoadDetails();
        }

        private void LoadRole()
        {
            List<RoleViewModel> roles = _roleController.GetAllRoles();
            if (roles != null)
            {
                txtRole.DataSource = roles;
            }
        }

        private void LoadDetails()
        {
            ApplicationUser user = _userController.GetApplicationUserById(_id);
            if (user != null)
            {
                txtRole.SelectedValue = user.ApplicationUserRoles.FirstOrDefault(ap => ap.ApplicationUser.Id == user.Id).RoleId;
                txtRole.SelectedItem = user.ApplicationUserRoles.FirstOrDefault(ap => ap.ApplicationUser.Id == user.Id).Role;

                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtEmail.Text = user.Email;
                txtPhoneNumber.Text = user.PhoneNumber;
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
                    ApplicationUser user = _userController.GetApplicationUserById(_id);
                    user.UserName = txtUsername.Text;
                    user.FirstName = txtFirstName.Text;
                    user.LastName = txtLastName.Text;
                    user.Email = txtEmail.Text;
                    user.PhoneNumber = txtPhoneNumber.Text;
                    user.PasswordHash = txtPassword.Text;
                    user.DateModified = DateTime.Now;

                    user.FullName = user.FirstName + " " + user.LastName;
                    _userController.UpdateUser(user);

                    Domain.Entities.Role role = _roleController.GetRoleById(txtRole.SelectedValue.ToString());
                    ApplicationUserRole userRole = _userRoleRepository.FindUserRole(user.Id);

                    userRole.Role = role;
                    userRole.RoleId = role.Id;

                    _userRoleRepository.UpdateUserRole(userRole);

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
                            await EmailHelper.SendEmail(foundCompany.Email, "User Updated", userString);
                        }
                    }
                    MessageBox.Show("Account edited successfully", "Success", MessageBoxButtons.OK,
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
