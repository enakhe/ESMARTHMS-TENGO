using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Forms.RoomTypes;
using ESMART_HMS.Presentation.Sessions;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
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
            InitializeComponent();
            _roomController = roomController;
            _roomTypeController = roomTypeController;
            _userController = userController;
        }

        public void LoadRoomTypeData()
        {
            try
            {
                var allRoomTypes = _roomTypeController.GetAllRoomType();
                if (allRoomTypes != null)
                {
                    txtRoomType.DataSource = allRoomTypes;
                    txtRoomType.Text = allRoomTypes.Count.ToString();
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

        private void btnRoomType_Click(object sender, EventArgs e)
        {
            AddRoomTypeForm addRoomTypeForm = new AddRoomTypeForm(_roomTypeController);
            if (addRoomTypeForm.ShowDialog() == DialogResult.OK)
            {
                LoadRoomTypeData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                bool isNull = FormHelper.AreAnyNullOrEmpty(txtRoomNo.Text, txtRate.Text, txtAdultPerRoom.Text, txtChildrenPerRoom.Text, txtRoomType.Text);
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
    }
}
