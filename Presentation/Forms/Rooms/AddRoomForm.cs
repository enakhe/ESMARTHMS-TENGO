using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.Controllers;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Forms.Rooms
{
    public partial class AddRoomForm : Form
    {
        Room room = new Room();
        private readonly RoomController _roomController;
        public AddRoomForm(RoomController roomController)
        {
            InitializeComponent();
            txtRate.KeyPress += new KeyPressEventHandler(txtRate_KeyPress);
            txtRate.TextChanged += new EventHandler(txtRate_TextChanged);
            _roomController = roomController;
        }

        public void LoadRoomTypeData()
        {
            try
            {
                //var allRoomTypes = roomTypeRepository.GetAllRoomTypes();
                //if (allRoomTypes != null)
                //{
                //txtRoomType.DataSource = _db.RoomTypes.ToList<RoomType>();
                //txtRoomType.Text = allRoomTypes.Count.ToString();
                //}
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
            // TODO: This line of code loads data into the 'eSMART_HMSDBDataSet.RoomType' table. You can move, or remove it, as needed.
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
            //AddRoomTypeForm addRoomTypeForm = new AddRoomTypeForm();
            //if (addRoomTypeForm.ShowDialog() == DialogResult.OK)
            //{
            //LoadRoomTypeData();
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
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
                    room.RoomTypeId = txtRoomType.SelectedValue.ToString();
                    //room.RoomType = _db.RoomTypes.FirstOrDefault(x => x.Id == txtRoomType.SelectedValue.ToString());
                    room.Description = txtDescription.Text.Trim().ToUpper();
                    room.IsAvailable = true;

                    room.DateCreated = DateTime.Now;
                    room.DateModified = DateTime.Now;


                    _roomController.CreateRoom(room);
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

        private void txtRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
