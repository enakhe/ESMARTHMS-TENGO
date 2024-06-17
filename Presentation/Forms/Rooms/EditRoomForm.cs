using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Forms.RoomTypes;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Rooms
{
    public partial class EditRoomForm : Form
    {
        private string _Id;
        private readonly RoomController _roomController;
        private readonly RoomTypeController _roomTypeController;
        public EditRoomForm(RoomController roomController, RoomTypeController roomTypeController, string Id)
        {
            InitializeComponent();
            _roomController = roomController;
            _roomTypeController = roomTypeController;
            _Id = Id;
        }

        private void EditRoomForm_Load(object sender, EventArgs e)
        {
            LoadRoomType();
            LoadRoomTypeData();
        }

        public void LoadRoomType()
        {
            try
            {
                List<RoomType> roomTypes = _roomTypeController.GetAllRoomType();
                txtRoomType.DataSource = roomTypes;
                txtRoomType.DisplayMember = "Title";
                txtRoomType.ValueMember = "Id";
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
                    txtRoomNo.Text = room.RoomName;
                    txtLockNo.Text = room.RoomLockNo;
                    txtCardNo.Text = room.RoomCardNo;
                    txtAdultPerRoom.Text = room.AdultPerRoom.ToString();
                    txtChildrenPerRoom.Text = room.ChildrenPerRoom.ToString();
                    txtRate.Text = room.Rate.ToString();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var closeForm = MessageBox.Show("Are you sure you want to close this form?", "Confirm Closure", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (closeForm == DialogResult.Yes)
            {
                this.Close();
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

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                return;
            }

            if (e.KeyChar == '.' && !txtRate.Text.Contains("."))
            {
                return;
            }

            e.Handled = true;
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
            string text = txtRate.Text;

            if (decimal.TryParse(text, out decimal value))
            {
                txtRate.Text = value.ToString("F2");
            }
            else if (text != string.Empty)
            {
                txtRate.Text = string.Empty;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Room room = _roomController.GetRealRoom(_Id);
                if (txtRoomNo.Text == "" || txtCardNo.Text == "" || txtLockNo.Text == "" || txtRate.Text == "" || txtAdultPerRoom.Text == "" || txtChildrenPerRoom.Text == "" || txtRoomType.Text == "" || txtDescription.Text == "")
                {
                    MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }

                else
                {
                    room.RoomName = txtRoomNo.Text.Trim();
                    room.RoomCardNo = txtCardNo.Text.Trim();
                    room.RoomLockNo = txtLockNo.Text.Trim();
                    room.Rate = decimal.Parse(txtRate.Text);
                    room.AdultPerRoom = int.Parse(txtAdultPerRoom.Text);
                    room.ChildrenPerRoom = int.Parse(txtChildrenPerRoom.Text);
                    room.RoomTypeId = (string)txtRoomType.SelectedValue.ToString();
                    room.RoomType = _roomTypeController?.GetRoomTypeById(txtRoomType.SelectedValue?.ToString());
                    room.Description = txtDescription.Text.Trim().ToUpper();
                    room.IsAvailable = true;

                    room.DateCreated = DateTime.Now;
                    room.DateModified = DateTime.Now;

                    _roomController.UpdateRoom(room);
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
    }
}
