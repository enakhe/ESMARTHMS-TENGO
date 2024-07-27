using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.Controllers;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.RoomTypes
{
    public partial class AddRoomTypeForm : Form
    {
        RoomType roomType = new RoomType();
        private readonly RoomTypeController _roomTypeController;
        public AddRoomTypeForm(RoomTypeController roomTypeController)
        {
            _roomTypeController = roomTypeController;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var closeForm = MessageBox.Show("Are you sure you want to close this form?", "Confirm Closure", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (closeForm == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTitle.Text == "")
                {
                    MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }

                else
                {
                    roomType.Title = txtTitle.Text.Trim().ToUpper();
                    roomType.DateCreated = DateTime.Now;
                    roomType.DateModified = DateTime.Now;

                    _roomTypeController.AddRoomType(roomType);
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
