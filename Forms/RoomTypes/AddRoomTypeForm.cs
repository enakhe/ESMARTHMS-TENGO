using ESMART_HMS.Forms.Guests;
using ESMART_HMS.Forms.Rooms;
using ESMART_HMS.Models;
using ESMART_HMS.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Forms.RoomTypes
{
    public partial class AddRoomTypeForm : Form
    {
        RoomType roomType = new RoomType();
        AddRoomForm addRoomForm = new AddRoomForm();
        public AddRoomTypeForm()
        {
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
                if (txtTitle.Text == "" || txtRateBase.Text == "" || txtDescription.Text == "")
                {
                    MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }

                else
                {
                    roomType.Title = txtTitle.Text.Trim().ToUpper();
                    roomType.RateBase =  decimal.Parse(txtRateBase.Text);
                    roomType.Description = txtDescription.Text.Trim().ToUpper();
                    roomType.DateCreated = DateTime.Now;
                    roomType.DateModified = DateTime.Now;

                    ESMART_HMSDBEntities _db = new ESMART_HMSDBEntities();
                    RoomTypeRepository roomTypeRepository = new RoomTypeRepository(_db);

                    roomTypeRepository.AddRoomType(roomType);
                    this.DialogResult = DialogResult.OK;

                    addRoomForm.LoadRoomTypeData();
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
