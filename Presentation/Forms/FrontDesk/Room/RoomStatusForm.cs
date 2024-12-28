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

namespace ESMART_HMS.Presentation.Forms.FrontDesk.Room
{
    public partial class RoomStatusForm : Form
    {
        private readonly RoomController _roomController;
        private readonly List<Domain.Entities.Room> _rooms;
        private readonly SystemSetupController _systemSetupController;
        public RoomStatusForm(RoomController roomController, SystemSetupController systemSetupController, List<Domain.Entities.Room> rooms)
        {
            _rooms = rooms;
            _roomController = roomController;
            _systemSetupController = systemSetupController;
            InitializeComponent();
        }

        private void LoadRooms()
        {
            roomList.DataSource = _rooms;
        }

        private void RoomStatusForm_Load(object sender, EventArgs e)
        {
            LoadRooms();
        }

        private async void btnStatus_Click(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtRoomStatus.Text);
            if (isNull == false) 
            {
                CompanyInformation foundCompany = _systemSetupController.GetCompanyInfo();

                foreach (Domain.Entities.Room room in _rooms)
                {
                    var oldStatus = room.Status;
                    room.Status = txtRoomStatus.Text;
                    _roomController.UpdateRoom(room);

                    string roomString = $"Id = {room.Id}\n" +
     $"Room Id = {room.RoomId}\n" +
     $"Room No = {room.RoomNo}\n" +
     $"Room Type = {room.RoomType.Title}\n" +
     $"Building = {room.Building.BuildingName}\n" +
     $"Floor = {room.Floor.FloorNo}\n" +
     $"Area = {room.Area.AreaName}\n" +
     $"Adults Per Room = {room.AdultPerRoom}\n" +
     $"Children Per Room = {room.ChildrenPerRoom}\n" +
     $"Description = {room.Description}\n" +
     $"Rate = {room.Rate}\n" +
     $"Status = {room.Status}\n" +
     $"Created By = {room.ApplicationUser.FullName}\n" +
     $"Date Created = {room.DateCreated.ToString("yyyy-MM-dd HH:mm:ss")}\n" +
     $"Date Modified = {room.DateModified.ToString("yyyy-MM-dd HH:mm:ss")}";
                    if (foundCompany != null)
                    {
                        if (foundCompany.Email != null)
                        {
                            await EmailHelper.SendEmail(foundCompany.Email, $"Room Status Changed from {oldStatus} to {room.Status} ", roomString);
                        }
                    }
                }
                MessageBox.Show("Successfully changed room status", "Success", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a status", "Error", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }
    }
}
