using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Sessions;
using ESMART_HMS.Presentation.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Rooms
{
    public partial class RoomForm : Form
    {
        private readonly RoomController _roomController;
        private readonly RoomTypeController _roomTypeController;
        private readonly ApplicationUserController _applicationUserController;
        private readonly SystemSetupController _systemSetupController;
        private PrintDocument printDocument1 = new PrintDocument();
        private string documentTitle = "Rooms List";
        private PrintDocument printDocument = new PrintDocument();

        public RoomForm(RoomController roomController, RoomTypeController roomTypeController, ApplicationUserController applicationUserController, SystemSetupController systemSetupController)
        {
            _roomController = roomController;
            _roomTypeController = roomTypeController;
            printDocument.DefaultPageSettings.Landscape = true;
            _applicationUserController = applicationUserController;
            InitializeComponent();
            ApplyAuthorization();
            _systemSetupController = systemSetupController;
        }

        private void ApplyAuthorization()
        {
            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
        }

        private void RoomsForm_Load(object sender, EventArgs e)
        {
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
                    txtVacant.Text = _roomController.GetAllRooms().Where(r => r.Status == RoomStatusEnum.Vacant.ToString()).Count().ToString();
                    txtReserved.Text = _roomController.GetAllRooms().Where(r => r.Status == RoomStatusEnum.Reserved.ToString()).Count().ToString();
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

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(comboBox1.Text);
            if (isNull == false)
            {
                List<RoomViewModel> filteredRooms = _roomController.FilterByStatus(comboBox1.Text);
                if (filteredRooms != null)
                {
                    if (filteredRooms.Count > 0)
                    {
                        foreach (var room in filteredRooms)
                        {
                            FormHelper.TryConvertStringToDecimal(room.Rate.ToString(), out decimal rate);
                            room.Rate = FormHelper.FormatNumberWithCommas(rate);
                        }

                        dgvRooms.DataSource = filteredRooms;
                    }
                    else
                    {
                        LoadData();
                    }
                }
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtSearch.Text);
            if (isNull == false)
            {
                List<RoomViewModel> searchedRooms = _roomController.SearchRoom(txtSearch.Text);
                if (searchedRooms != null)
                {
                    dgvRooms.DataSource = searchedRooms;
                }
                else
                {
                    LoadData();
                }
            }
            else
            {
                LoadData();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string companyName = _systemSetupController.GetCompanyInfo().Name;
            PrintHelper.PrintDataGridView(dgvRooms, documentTitle, companyName);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(comboBox1.Text);
            if (isNull == false)
            {
                List<RoomViewModel> filteredRooms = _roomController.FilterByStatus(comboBox1.Text);
                if (filteredRooms != null)
                {
                    if (filteredRooms.Count > 0)
                    {
                        foreach (var room in filteredRooms)
                        {
                            FormHelper.TryConvertStringToDecimal(room.Rate.ToString(), out decimal rate);
                            room.Rate = FormHelper.FormatNumberWithCommas(rate);
                        }

                        dgvRooms.DataSource = filteredRooms;
                    }
                    else
                    {
                        LoadData();
                    }
                }
            }
        }

        private void btnGrid_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            RoomGridViewForm roomGridView = serviceProvider.GetRequiredService<RoomGridViewForm>();
            roomGridView.Show();
        }
    }
}
