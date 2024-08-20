using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.FrontDesk.Room.Building
{
    public partial class EditBuildingForm : Form
    {
        private readonly RoomController _roomController;
        private readonly string _id;
        public EditBuildingForm(RoomController roomController, string id)
        {
            _roomController = roomController;
            _id = id;
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                Domain.Entities.Building building = _roomController.GetBuildingById(_id);
                if (building != null)
                {
                    txtName.Text = building.BuildingName;
                    txtNumber.Text = building.BuildingNo;
                    txtRemark.Text = building.Remark;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                bool isNull = FormHelper.AreAnyNullOrEmpty(txtName.Text, txtNumber.Text);
                if (isNull)
                {
                    MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                else
                {
                    Domain.Entities.Building building = _roomController.GetBuildingById(_id);
                    if (building != null)
                    {
                        building.BuildingNo = txtNumber.Text;
                        building.BuildingName = txtName.Text;
                        building.Remark = txtRemark.Text;
                        building.DateModified = DateTime.Now;

                        _roomController.UpdateBuilding(building);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
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
