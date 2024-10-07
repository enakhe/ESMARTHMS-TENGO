using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Forms.Maintenance.User_Settings.Role;
using ESMART_HMS.Presentation.Forms.Maintenance.User_Settings.User;
using ESMART_HMS.Presentation.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Tools.Options.Accounts
{
    public partial class UserForm : Form
    {
        private readonly ApplicationUserController _userController;
        private readonly RoleController _roleController;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly SystemSetupController _systemSetupController;
        public UserForm(ApplicationUserController applicationUserController, RoleController roleController, IUserRoleRepository userRoleRepository, SystemSetupController systemSetupController)
        {
            _userController = applicationUserController;
            _roleController = roleController;
            _userRoleRepository = userRoleRepository;
            _systemSetupController = systemSetupController;
            InitializeComponent();
            InitializeRoleTab(roleTab);
            InitializeUserTab(userTab);
        }

        private void InitializeRoleTab(TabPage tabPage)
        {
            if (tabPage != null)
            {
                if (tabPage.Text == "Roles")
                {
                    List<RoleViewModel> allRole = _roleController.GetAllRoles();
                    if (allRole != null)
                    {
                        foreach (RoleViewModel role in allRole)
                        {
                            role.DateModified = FormHelper.FormatDateTimeWithSuffix(role.DateModified);
                            role.DateCreated = FormHelper.FormatDateTimeWithSuffix(role.DateCreated);
                        }

                        dgvRole.DataSource = allRole;
                    }
                }
            }
        }
        private void InitializeUserTab(TabPage tabPage)
        {
            if (tabPage != null)
            {
                if (tabPage.Text == "Users")
                {
                    List<UserViewModel> allUser = _userController.GetAllUserViewModel();
                    if (allUser != null)
                    {
                        foreach (UserViewModel user in allUser)
                        {
                            user.DateCreated = FormHelper.FormatDateTimeWithSuffix(user.DateCreated);
                        }

                        dgvUser.DataSource = allUser;
                    }
                }
            }
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }

        private void addRoleBtn_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            AddRoleForm addRoleForm = serviceProvider.GetRequiredService<AddRoleForm>();
            if (addRoleForm.ShowDialog() == DialogResult.OK)
            {
                InitializeRoleTab(roleTab);
            }
        }

        private void editRoleBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRole.SelectedRows.Count > 0)
                {
                    var row = dgvRole.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn1"].Value.ToString();

                    using (EditRoleForm editRoleForm = new EditRoleForm(_roleController, id))
                    {
                        if (editRoleForm.ShowDialog() == DialogResult.OK)
                        {
                            InitializeRoleTab(roleTab);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a floor to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void deleteRoleBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRole.SelectedRows.Count > 0)
                {
                    var result = MessageBox.Show("Are you sure you want to add the selected role to the recycle?\nIts record including all entries tagged to such role will be added to the recycle bin as well.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvRole.SelectedRows)
                        {
                            string id = row.Cells["idDataGridViewTextBoxColumn1"].Value.ToString();
                            _roleController.DeleteRole(id);
                        }
                        InitializeRoleTab(roleTab);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a role to recycle.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            AddUserForm addUserForm = serviceProvider.GetRequiredService<AddUserForm>();
            if (addUserForm.ShowDialog() == DialogResult.OK)
            {
                InitializeUserTab(userTab);
            }
        }

        private void btnDeleteBtn_Click(object sender, EventArgs e)
        {

        }

        private void btnEditFloor_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUser.SelectedRows.Count > 0)
                {
                    var row = dgvUser.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                    using (EditUserForm editUserForm = new EditUserForm(_userController, _roleController, _userRoleRepository, _systemSetupController, id))
                    {
                        if (editUserForm.ShowDialog() == DialogResult.OK)
                        {
                            InitializeUserTab(userTab);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a user to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
