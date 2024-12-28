using Bunifu.UI.WinForms.Extensions;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Forms.FrontDesk.Room;
using ESMART_HMS.Presentation.Forms.FrontDesk.Room.Building;
using ESMART_HMS.Presentation.Forms.FrontDesk.Room.Floor;
using ESMART_HMS.Presentation.Forms.RoomTypes;
using ESMART_HMS.Presentation.Sessions;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Rooms
{
    public partial class AddRoomForm : Form
    {
        Room room = new Room();
        private readonly RoomController _roomController;
        private readonly RoomTypeController _roomTypeController;
        private readonly ApplicationUserController _userController;
        public AddRoomForm(RoomController roomController, RoomTypeController roomTypeController, ApplicationUserController userController)
        {
            _roomController = roomController;
            _roomTypeController = roomTypeController;
            _userController = userController;
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                var allRoomTypes = _roomTypeController.GetAllRoomType();
                var allBuilding = _roomController.GetAllBuildings();
                var allFloors = _roomController.GetAllFloors();
                var allAreas = _roomController.GetAllAreas();
                if (allRoomTypes != null)
                {
                    txtRoomType.DataSource = allRoomTypes;
                    txtRoomType.Text = allRoomTypes.Count.ToString();
                }

                if (allBuilding != null)
                {
                    txtBuilding.DataSource = allBuilding;
                }

                if (allAreas != null)
                {
                    txtArea.DataSource = allAreas;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var closeForm = MessageBox.Show("Are you sure you want to close this form?", "Confirm Closure", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (closeForm == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void AddRoomForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eSMART_HMSDBDataSet.Area' table. You can move, or remove it, as needed.
            this.areaTableAdapter.Fill(this.eSMART_HMSDBDataSet.Area);
            // TODO: This line of code loads data into the 'eSMART_HMSDBDataSet.Building' table. You can move, or remove it, as needed.
            this.buildingTableAdapter.Fill(this.eSMART_HMSDBDataSet.Building);
            this.roomTypeTableAdapter.Fill(this.eSMART_HMSDBDataSet.RoomType);
        }

        private void txtCardNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLockNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAdultPerRoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtChildrenPerRoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                bool isNull = FormHelper.AreAnyNullOrEmpty(txtRoomNo.Text, txtRate.Text, txtAdultPerRoom.Text, txtChildrenPerRoom.Text, txtRoomType.Text, txtBuilding.Text, txtFloor.Text, txtArea.Text);
                if (isNull == true)
                {
                    MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }

                else
                {
                    Random random = new Random();

                    room.Id = Guid.NewGuid().ToString();
                    room.RoomId = "RM" + random.Next(1000, 5000);
                    room.RoomNo = txtRoomNo.Text.Trim();
                    room.Rate = decimal.Parse(txtRate.Text);
                    room.AdultPerRoom = int.Parse(txtAdultPerRoom.Text);
                    room.ChildrenPerRoom = int.Parse(txtChildrenPerRoom.Text);

                    room.RoomTypeId = txtRoomType.SelectedValue.ToString();
                    room.RoomType = _roomTypeController.GetRoomTypeById(txtRoomType.SelectedValue.ToString());

                    room.BuildingId = txtBuilding.SelectedValue.ToString();
                    room.Building = _roomController.GetBuildingById(txtBuilding.SelectedValue.ToString());

                    room.FloorId = txtFloor.SelectedValue.ToString();
                    room.Floor = _roomController.GetFloorById(txtFloor.SelectedValue.ToString());

                    room.AreaId = txtArea.SelectedValue.ToString();
                    room.Area = _roomController.GetAreaById(txtArea.SelectedValue.ToString());

                    room.Description = txtDescription.Text.Trim().ToUpper();
                    room.Status = RoomStatusEnum.Vacant.ToString();

                    room.DateCreated = DateTime.Now;
                    room.DateModified = DateTime.Now;

                    room.CreatedBy = AuthSession.CurrentUser.Id;
                    room.ApplicationUser = _userController.GetApplicationUserById(AuthSession.CurrentUser.Id);

                    var foundRoom = _roomController.GetRoomByRoomNo(txtRoomNo.Text);
                    if (foundRoom != null)
                    {
                        MessageBox.Show($"Room with the number {room.RoomNo} already exists", "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else
                    {
                        _roomController.CreateRoom(room);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void txtRoomNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtRate.Text);
            if (isNull == false)
            {
                txtRate.Text = FormHelper.FormatNumberWithCommas(decimal.Parse(txtRate.Text));
            }
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void addRoomType_Click(object sender, EventArgs e)
        {
            AddRoomTypeForm addRoomTypeForm = new AddRoomTypeForm(_roomTypeController);
            if (addRoomTypeForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnAddBuilding_Click(object sender, EventArgs e)
        {
            AddBuildingForm addBuildingForm = new AddBuildingForm(_roomController);
            if (addBuildingForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            AddAreaForm addAreaForm = new AddAreaForm(_roomController);
            if (addAreaForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void AddFloor_Click(object sender, EventArgs e)
        {
            AddFloorForm addFloorForm = new AddFloorForm(_roomController);
            if (addFloorForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void txtBuilding_TextChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtBuilding.Text);
            {
                var building = _roomController.GetBuildingById(txtBuilding.SelectedValue.ToString());
                txtFloor.DataSource = building.Floors.ToList();
            }
        }
    }
}
