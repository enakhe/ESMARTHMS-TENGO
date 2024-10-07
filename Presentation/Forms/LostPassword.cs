using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
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

namespace ESMART_HMS.Presentation.Forms
{
    public partial class LostPassword : Form
    {
        private readonly LicenseController _licenseController;
        private readonly ApplicationUserController _applicationUserController;
        private readonly ESMART_HMSDBEntities _db;
        public LostPassword(LicenseController licenseController, ApplicationUserController applicationUserController, ESMART_HMSDBEntities db)
        {
            _licenseController = licenseController;
            _applicationUserController = applicationUserController;
            _db = db;
            InitializeComponent();
            txtLicence.MaxLength = 6;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtLicence.Text, txtNewPassword.Text);
            if (isNull == false)
            {
                Domain.Entities.LicenseInfo licenseInfo = _licenseController.GetLicenseInfo();
                string[] key = licenseInfo.ProductKey.Split('-');
                string lastSixDigit = key[key.Length - 1];
                if (txtLicence.Text != lastSixDigit)
                {
                    MessageBox.Show("Invalid licence key", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                else
                {
                    ApplicationUser admin = _db.ApplicationUserRoles.FirstOrDefault(ur => ur.Role.Title == "Admin").ApplicationUser;
                    if (admin != null)
                    {
                        admin.PasswordHash = _applicationUserController.HashPassword(txtNewPassword.Text);
                        _applicationUserController.UpdateUser(admin);
                        MessageBox.Show("Password updated", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Licence key and password are required", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPassword.Checked == false)
            {
                txtLicence.UseSystemPasswordChar = true;
                txtNewPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtLicence.UseSystemPasswordChar = false;
                txtNewPassword.UseSystemPasswordChar= false;
            }
        }
    }
}
