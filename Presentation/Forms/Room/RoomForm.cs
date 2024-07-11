using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Rooms
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
        }

        private void RoomsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eSMART_HMSDBDataSet.Reservation' table. You can move, or remove it, as needed.
            LoadData();
            this.roomTableAdapter.Fill(this.eSMART_HMSDBDataSet.Room);
        }

        public void LoadData()
        {
            dgvRooms.AutoGenerateColumns = false;
            try
            {
                var allRooms = _roomController.GetAllRooms();
                if (allRooms != null)
                {
                    foreach (var room in allRooms)
                    {
                        FormHelper.TryConvertStringToDecimal(room.Rate.ToString(), out decimal rate);
                        room.Rate = FormHelper.FormatNumberWithCommas(rate);
                    }

                    dgvRooms.DataSource = allRooms;
                    dgvRooms.CellFormatting += DataGridViewRooms_CellFormatting;
                    txtRoomCount.Text = allRooms.Count.ToString();
                    txtVacantRooms.Text = _roomController.GetAllRooms().Where(r => r.Status == RoomStatusEnum.Vacant.ToString()).Count().ToString();
                    txtReservedRooms.Text = _roomController.GetAllRooms().Where(r => r.Status == RoomStatusEnum.Reserved.ToString()).Count().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void DataGridViewRooms_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRooms.Columns[e.ColumnIndex].Name == "Status")
            {
                var cell = dgvRooms.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null && cell.Value.ToString() == "Vacant")
                {
                    cell.Style.BackColor = System.Drawing.Color.Green;
                    cell.Style.ForeColor = System.Drawing.Color.White;
                }
                else if (cell.Value != null && cell.Value.ToString() == "Reserved")
                {
                    cell.Style.BackColor = System.Drawing.Color.Yellow;
                    cell.Style.ForeColor = System.Drawing.Color.Black;
                }
                else if (cell.Value != null && cell.Value.ToString() == "CheckedIn")
                {
                    cell.Style.BackColor = System.Drawing.Color.Blue;
                    cell.Style.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    cell.Style.BackColor = System.Drawing.Color.Red;
                    cell.Style.ForeColor = System.Drawing.Color.Black;
                }
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

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRooms.SelectedRows.Count > 0)
                {
                    var row = dgvRooms.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                    using (ViewRoomForm viewGuestForm = new ViewRoomForm(id, _roomController))
                    {
                        if (viewGuestForm.ShowDialog() == DialogResult.OK)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRooms.SelectedRows.Count > 0)
                {
                    var result = MessageBox.Show("Are you sure you want to delete the selected rooms?\nIf you delete any room, its record including all orders tagged to such room will be added to the recycle bin as well.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvRooms.SelectedRows)
                        {
                            string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();
                            _roomController.DeleteRoom(id);
                        }
                        LoadData();
                        MessageBox.Show("Successfully deleted customer information", "Success", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a customer to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
