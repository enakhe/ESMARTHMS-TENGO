using ESMART_HMS.Presentation.Controllers;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Forms.Rooms
{
    public partial class RoomForm : Form
    {
        private readonly RoomController _roomController;
        public RoomForm(RoomController roomController)
        {
            _roomController = roomController;
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            dgvRooms.AutoGenerateColumns = false;
            try
            {
                var allRooms = _roomController.GetAllRooms();
                if (allRooms != null)
                {
                    dgvRooms.DataSource = allRooms;
                    txtRoomCount.Text = allRooms.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void addRoomBtn_Click(object sender, EventArgs e)
        {
            AddRoomForm addRoomForm = new AddRoomForm(_roomController);
            if (addRoomForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void dgvRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RoomsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eSMART_HMSDBDataSet.Room' table. You can move, or remove it, as needed.
            this.roomTableAdapter.Fill(this.eSMART_HMSDBDataSet.Room);

        }
    }
}
