using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Forms.Customers;
using Microsoft.Extensions.DependencyInjection;
using ESMART_HMS.Presentation.Forms.Rooms;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Forms.Rooms
{
    public partial class RoomForm : Form
    {
        private readonly RoomController _roomController;
        private readonly RoomTypeController _roomTypeController;

        public RoomForm(RoomController roomController, RoomTypeController roomTypeController)
        {
            InitializeComponent();
            _roomController = roomController;
            _roomTypeController = roomTypeController;
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
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            AddRoomForm addRoomForm = serviceProvider.GetRequiredService<AddRoomForm>();
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

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRooms.SelectedRows.Count > 0)
                {
                    var row = dgvRooms.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                    using (ViewRoomForm viewCustomerForm = new ViewRoomForm(id, _roomController))
                    {
                        if (viewCustomerForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a customer to view.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void dgvRooms_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRooms.Rows[e.RowIndex];
                string roomId = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                using (EditRoomForm editRoomForm = new EditRoomForm(_roomController, _roomTypeController, roomId))
                {
                    if (editRoomForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
                
            }
        }
    }
}
