using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Maintenance.User_Settings.Role
{
    public partial class AddRoleForm : Form
    {
        private readonly RoleController _roleController;
        public AddRoleForm(RoleController roleController)
        {
            _roleController = roleController;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool isNull = FormHelper.AreAnyNullOrEmpty(txtTitle.Text);
                if (isNull == false)
                {
                    Random random = new Random();
                    Domain.Entities.Role role = new Domain.Entities.Role()
                    {
                        Id = Guid.NewGuid().ToString(),
                        RoleId = "ROL" + random.Next(10000, 20000),
                        Title = txtTitle.Text.ToUpper(),
                        Description = txtDescription.Text,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        IsTrashed = false
                    };
                    _roleController.AddRole(role);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
