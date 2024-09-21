using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Forms.FrontDesk.Room;
using ESMART_HMS.Presentation.Sessions;
using ESMART_HMS.Presentation.ViewModels;
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
        private readonly CardController _cardController;
        private readonly ApplicationUserController _userController;
        private PrintDocument printDocument1 = new PrintDocument();
        private string documentTitle = "Rooms List";
        private PrintDocument printDocument = new PrintDocument();

        public RoomForm(RoomController roomController, RoomTypeController roomTypeController, ApplicationUserController applicationUserController, SystemSetupController systemSetupController, CardController cardController, ApplicationUserController userController)
        {
            _roomController = roomController;
            _roomTypeController = roomTypeController;
            printDocument.DefaultPageSettings.Landscape = true;
            _applicationUserController = applicationUserController;
            InitializeComponent();
            ApplyAuthorization();
            _systemSetupController = systemSetupController;
            _cardController = cardController;
            _userController = userController;
        }

        private void ApplyAuthorization()
        {
            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
        }

        private void RoomsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            dgvRooms.AutoGenerateColumns = false;
            try
            {
                var allRooms = _roomController.GetAllRooms();
                var allRoomTypes = new List<RoomTypeViewModel>();
                var roomTypes = _roomTypeController.GetAllRoomType();

                if (allRooms != null)
                {
                    foreach (var room in allRooms)
                    {
                        FormHelper.TryConvertStringToDecimal(room.Rate.ToString(), out decimal rate);
                        room.Rate = FormHelper.FormatNumberWithCommas(rate);

                        room.DateCreated = FormHelper.FormatDateTimeWithSuffix(room.DateCreated);
                        room.DateModified = FormHelper.FormatDateTimeWithSuffix(room.DateModified);
                    }

                    dgvRooms.DataSource = allRooms;
                    dgvRooms.CellFormatting += DataGridViewRooms_CellFormatting;
                    txtRoomCount.Text = allRooms.Count.ToString();
                    txtVacant.Text = _roomController.GetAllRooms().Where(r => r.Status == RoomStatusEnum.Vacant.ToString()).Count().ToString();
                    txtReserved.Text = _roomController.GetAllRooms().Where(r => r.Status == RoomStatusEnum.Reserved.ToString()).Count().ToString();
                    txtBooked.Text = _roomController.GetAllRooms().Where(r => r.Status == RoomStatusEnum.CheckedIn.ToString()).Count().ToString();
                }

                if (roomTypes != null)
                {
                    RoomTypeViewModel all = new RoomTypeViewModel()
                    {
                        Id = Guid.NewGuid().ToString(),
                        RoomTypeId = "ALL",
                        Title = "ALL",
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                    };
                    allRoomTypes.Add(all);

                    foreach (var roomType in roomTypes)
                    {
                        allRoomTypes.Add(roomType);
                    }

                    txtRoomType.DataSource = allRoomTypes;
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
            if (dgvRooms.Columns[e.ColumnIndex].Name == "statusDataGridViewTextBoxColumn")
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string companyName = _systemSetupController.GetCompanyInfo().Name;
            PrintHelper.PrintDataGridView(dgvRooms, documentTitle, companyName);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtSearch.Text);
            if (isNull == false)
            {
                List<RoomViewModel> searchedRooms = _roomController.SearchRoom(txtSearch.Text);
                if (searchedRooms != null)
                {
                    foreach (var room in searchedRooms)
                    {
                        FormHelper.TryConvertStringToDecimal(room.Rate.ToString(), out decimal rate);
                        room.Rate = FormHelper.FormatNumberWithCommas(rate);
                    }

                    dgvRooms.DataSource = searchedRooms;
                    dgvRooms.CellFormatting += DataGridViewRooms_CellFormatting;
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

        private void btnShowRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRooms.SelectedRows.Count > 0)
                {
                    var row = dgvRooms.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                    using (ShowRoomForm showRoomForm = new ShowRoomForm(id, _roomController, _cardController, _userController))
                    {
                        if (showRoomForm.ShowDialog() == DialogResult.OK)
                        {

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a room to issue card.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
