using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.FrontDesk.Room.Building
{
    public partial class AddBuildingForm : Form
    {
        private readonly RoomController _roomController;
        public AddBuildingForm(RoomController roomController)
        {
            InitializeComponent();
            _roomController = roomController;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtName.Text, txtNumber.Text);
            if (isNull)
            {
                MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                Domain.Entities.Building building = new Domain.Entities.Building()
                {
                    Id = Guid.NewGuid().ToString(),
                    BuildingName = txtName.Text,
                    BuildingNo = txtNumber.Text,
                    Remark = txtRemark.Text,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                };
                _roomController.AddBuilding(building);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
