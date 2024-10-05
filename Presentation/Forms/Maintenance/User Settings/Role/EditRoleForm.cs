using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Maintenance.User_Settings.Role
{
    public partial class EditRoleForm : Form
    {
        private readonly RoleController _roleController;
        private readonly string _id;
        public EditRoleForm(RoleController roleController, string id)
        {
            _roleController = roleController;
            _id = id;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                Domain.Entities.Role role = _roleController.GetRoleById(_id);
                if (role != null)
                {
                    txtTitle.Text = role.Title;
                    txtDescription.Text = role.Description;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool isNull = FormHelper.AreAnyNullOrEmpty(txtTitle.Text, txtDescription.Text);
                if (isNull == false)
                {
                    Domain.Entities.Role role = _roleController.GetRoleById(_id);
                    if (role != null)
                    {
                        role.Title = txtTitle.Text.ToUpper();
                        role.Description = txtDescription.Text;
                        role.DateModified = DateTime.Now;

                        _roleController.UpdatedRole(role);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
