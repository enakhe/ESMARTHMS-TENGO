using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Rooms
{
    public partial class ViewRoomForm : Form
    {
        private readonly RoomController _roomController;
        private readonly string _Id;
        public ViewRoomForm(string id, RoomController roomController)
        {
            InitializeComponent();
            _Id = id;
            _roomController = roomController;
            LoadRoomData();
        }

        private void LoadRoomData()
        {
            try
            {
                RoomViewModel room = _roomController.GetRoomById( _Id );
                if (room == null)
                {
                    MessageBox.Show("Customer not found", "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                else
                {
                    txtRoomId.Text = room.RoomId;
                    txtRoomNo.Text = room.RoomName;
                    txtRoomCard.Text = room.RoomCardNo;
                    txtRoomType.Text = room.RoomTypeName;
                    txtAdult.Text = room.AdultPerRoom.ToString();
                    txtChildren.Text = room.ChildrenPerRoom.ToString();
                    txtRate.Text = room.Rate.ToString();
                    txtAvailable.Text = room.IsAvailable.ToString();
                    txtDescription.Text = room.Description;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void ViewRoomForm_Load(object sender, EventArgs e)
        {

        }
    }
}
