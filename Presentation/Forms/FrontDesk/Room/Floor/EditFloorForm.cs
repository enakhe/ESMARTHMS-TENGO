using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.FrontDesk.Room.Floor
{
    public partial class EditFloorForm : Form
    {
        private readonly RoomController _roomController;
        private string _id;
        public EditFloorForm(RoomController roomController, string id)
        {
            _id = id;
            _roomController = roomController;
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                Domain.Entities.Floor floor = _roomController.GetFloorById(_id);
                if (floor != null)
                {
                    txtFloorNumber.Text = floor.FloorNo;
                    txtRemark.Text = floor.Remark;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool isNull = FormHelper.AreAnyNullOrEmpty(txtFloorNumber.Text);
                if (isNull)
                {
                    MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                else
                {
                    Domain.Entities.Floor floor = _roomController.GetFloorById(_id);
                    if (floor != null)
                    {
                        floor.FloorNo = txtFloorNumber.Text;
                        floor.Remark = txtRemark.Text;
                        floor.DateModified = DateTime.Now;

                        _roomController.UpdateFloor(floor);
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
