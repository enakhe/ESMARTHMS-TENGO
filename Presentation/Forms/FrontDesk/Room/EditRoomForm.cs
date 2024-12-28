using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Forms.RoomTypes;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Rooms
{
    public partial class EditRoomForm : Form
    {
        private string _Id;
        private readonly RoomController _roomController;
        private readonly RoomTypeController _roomTypeController;
        private readonly SystemSetupController _systemSetupController;
        public EditRoomForm(RoomController roomController, RoomTypeController roomTypeController, SystemSetupController systemSetupController, string Id)
        {
            InitializeComponent();
            _roomController = roomController;
            _systemSetupController = systemSetupController;
            _roomTypeController = roomTypeController;
            _Id = Id;
        }

        private void EditRoomForm_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadRoomTypeData();
        }

        public void LoadData()
        {
            try
            {
                var allRoomTypes = _roomTypeController.GetAllRoomType();
                var allBuilding = _roomController.GetAllBuildings();
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

        public void LoadRoomTypeData()
        {
            try
            {
                Room room = _roomController.GetRealRoom(_Id);

                if (room == null)
                {
                    MessageBox.Show("Room not found", "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }

                else
                {
                    txtId.Text = room.Id;
                    txtRate.Text = FormHelper.FormatNumberWithCommas(room.Rate);

                    txtBuilding.SelectedValue = room.BuildingId;
                    txtBuilding.SelectedItem = room.Building;

                    txtFloor.SelectedItem = room.Floor;
                    txtFloor.SelectedValue = room.FloorId;

                    txtArea.SelectedItem = room.Area;
                    txtArea.SelectedValue = room.AreaId;

                    txtRoomNo.Text = room.RoomNo;
                    txtAdultPerRoom.Text = room.AdultPerRoom.ToString();
                    txtChildrenPerRoom.Text = room.ChildrenPerRoom.ToString();
                    txtDescription.Text = room.Description;

                    txtRoomType.SelectedValue = room.RoomTypeId;
                    txtRoomType.SelectedItem = room.RoomType;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnRoomType_Click(object sender, EventArgs e)
        {
            AddRoomTypeForm addRoomTypeForm = new AddRoomTypeForm(_roomTypeController);
            if (addRoomTypeForm.ShowDialog() == DialogResult.OK)
            {
                LoadRoomTypeData();
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

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtRate.Text);
            if (isNull == false)
            {
                txtRate.Text = FormHelper.FormatNumberWithCommas(decimal.Parse(txtRate.Text));
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CompanyInformation foundCompany = _systemSetupController.GetCompanyInfo();

                Room room = _roomController.GetRealRoom(_Id);
                bool anyNull = FormHelper.AreAnyNullOrEmpty(txtRoomNo.Text, txtRate.Text, txtAdultPerRoom.Text, txtChildrenPerRoom.Text, txtRoomType.Text, txtBuilding.Text, txtArea.Text, txtFloor.Text);
                if (anyNull == true)
                {
                    MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }

                else
                {
                    room.RoomNo = txtRoomNo.Text.Trim();
                    room.Rate = decimal.Parse(txtRate.Text);
                    room.AdultPerRoom = int.Parse(txtAdultPerRoom.Text);
                    room.ChildrenPerRoom = int.Parse(txtChildrenPerRoom.Text);
                    room.Description = txtDescription.Text.Trim().ToUpper();

                    room.RoomTypeId = (string)txtRoomType.SelectedValue.ToString();
                    room.RoomType = _roomTypeController?.GetRoomTypeById(txtRoomType.SelectedValue?.ToString());

                    room.BuildingId = (string)txtBuilding.SelectedValue.ToString();
                    room.Building = _roomController?.GetBuildingById(txtBuilding.SelectedValue?.ToString());

                    room.FloorId = (string)txtFloor.SelectedValue.ToString();
                    room.Floor = _roomController?.GetFloorById(txtFloor.SelectedValue?.ToString());

                    room.AreaId = (string)txtArea.SelectedValue.ToString();
                    room.Area = _roomController?.GetAreaById(txtArea.SelectedValue?.ToString());

                    room.DateModified = DateTime.Now;

                    _roomController.UpdateRoom(room);
                    string roomString = $"Room Details:\n" +
               $"Id: {room.Id}\n" +
               $"RoomId: {room.RoomId}\n" +
               $"RoomNo: {room.RoomNo}\n" +
               $"RoomType: {room.RoomType.Title}\n" +
               $"Building: {room.Building.BuildingName}\n" +
               $"Floor: {room.Floor.FloorNo}\n" +
               $"Area: {room.Area.AreaName}\n" +
               $"Rate: {room.Rate}\n" +
               $"Status: {room.Status}\n" +
               $"Created By: {room.CreatedBy}\n" +
               $"Date Created: {room.DateCreated}\n" +
               $"Date Modified: {room.DateModified}\n";
                    if (foundCompany != null)
                    {
                        if (foundCompany.Email != null)
                        {
                            await EmailHelper.SendEmail(foundCompany.Email, "Room Edited", roomString);
                        }
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
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
