using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.FrontDesk.Room.Floor
{
    public partial class AddFloorForm : Form
    {
        private readonly RoomController _roomController;
        public AddFloorForm(RoomController roomController)
        {
            _roomController = roomController;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtFloorNumber.Text);
            if (isNull)
            {
                MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                Domain.Entities.Floor floor = new Domain.Entities.Floor()
                {
                    Id = Guid.NewGuid().ToString(),
                    FloorNo = txtFloorNumber.Text,
                    Remark = txtRemark.Text,
                    BuildingId = txtBuilding.SelectedValue.ToString(),
                    Building = _roomController.GetBuildingById(txtBuilding.SelectedValue.ToString()),
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                };
                _roomController.AddFloor(floor);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void AddFloorForm_Load(object sender, EventArgs e)
        {
            this.buildingTableAdapter.Fill(this.eSMART_HMSDBDataSet.Building);

        }
    }
}
