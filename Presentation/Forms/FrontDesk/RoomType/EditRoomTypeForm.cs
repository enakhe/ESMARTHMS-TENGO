using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.FrontDesk.RoomType
{
    public partial class EditRoomTypeForm : Form
    {
        private readonly RoomTypeController _roomTypeController;
        private readonly string _id;
        public EditRoomTypeForm(RoomTypeController roomTypeController, string id)
        {
            _roomTypeController = roomTypeController;
            _id = id;
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                Domain.Entities.RoomType roomType = _roomTypeController.GetRoomTypeById(_id);
                if (roomType != null)
                {
                    txtTitle.Text = roomType.Title;
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
                bool isNull = FormHelper.AreAnyNullOrEmpty(txtTitle.Text);
                if (isNull)
                {
                    MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                else
                {
                    Domain.Entities.RoomType roomType = _roomTypeController.GetRoomTypeById(_id);
                    if (roomType != null)
                    {
                        roomType.Title = txtTitle.Text;
                        roomType.DateModified = DateTime.Now;

                        _roomTypeController.UpdateRoomType(roomType);
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
