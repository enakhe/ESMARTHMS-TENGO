using ESMART_HMS.Application.LockSDK;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Forms.FrontDesk.Room;
using ESMART_HMS.Presentation.Forms.Maintenance.CardMaintenance.Cards;
using ESMART_HMS.Presentation.Sessions;
using ESMART_HMS.Presentation.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Rooms
{
    public partial class RoomForm : Form
    {
        string computerName = Environment.MachineName;
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
            _systemSetupController = systemSetupController;
            _cardController = cardController;
            _userController = userController;
            _applicationUserController = applicationUserController;
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            printDocument.DefaultPageSettings.Landscape = true;
            this.Activated += RoomForm_Activated;
            ApplyAuthorization();
            GetAuthCardFromDB();
        }

        private void ApplyAuthorization()
        {
            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
        }

        public StringBuilder GetAuthCardFromDB()
        {
            Domain.Entities.AuthorizationCard AuthCard = _cardController.GetAuthCardByComputer(computerName);
            if (AuthCard != null)
            {
                return new StringBuilder(AuthCard.AuthId);
            }
            return null;
        }

        private void RoomsForm_Load(object sender, EventArgs e)
        {
            LoadData();
            splitContainer15.SplitterWidth = 1;
            splitContainer5.BackColor = splitContainer15.Panel1.BackColor;
            dgvRooms.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvRooms.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);

            string fnp = "1011899778569788";
            StringBuilder clientData = new StringBuilder(AUTHDATA.Text);

            int systemIni = LockSDKMethods.SystemInitialization(fnp, clientData);
            if (systemIni != 1)
            {
                LockSDKMethods.CheckErr(systemIni);
                return;
            }

            Int16 locktype = (short)LOCK_SETTING.LOCK_TYPE;
            AUTHDATA.Enabled = false;
            int checkEncoder = LockSDKMethods.CheckEncoder(locktype);
            if (checkEncoder != 1)
            {
                LockSDKMethods.CheckErr(checkEncoder);
            }

            StringBuilder authId = GetAuthCardFromDB();
            if (authId != null)
            {
                bool isNull = FormHelper.AreAnyNullOrEmpty(authId.ToString());
                if (isNull == false)
                {
                    AUTHDATA.Text = authId.ToString();
                }
            }
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

                using (EditRoomForm editRoomForm = new EditRoomForm(_roomController, _roomTypeController, _systemSetupController, roomId))
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

        //private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    bool isNull = FormHelper.AreAnyNullOrEmpty(txtSearch.Text);
        //    if (isNull == false)
        //    {
        //        List<RoomViewModel> searchedRooms = _roomController.SearchRoom(txtSearch.Text);
        //        if (searchedRooms != null)
        //        {
        //            foreach (var room in searchedRooms)
        //            {
        //                FormHelper.TryConvertStringToDecimal(room.Rate.ToString(), out decimal rate);
        //                room.Rate = FormHelper.FormatNumberWithCommas(rate);
        //            }

        //            dgvRooms.DataSource = searchedRooms;
        //            dgvRooms.CellFormatting += DataGridViewRooms_CellFormatting;
        //        }
        //    }
        //    else
        //    {
        //        LoadData();
        //    }
        //}

        private void btnShowRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRooms.SelectedRows.Count > 0)
                {
                    var row = dgvRooms.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                    using (ShowRoomForm showRoomForm = new ShowRoomForm(id, _roomController, _cardController, _userController, _systemSetupController))
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

        private void txtFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtFilter.Text);
            if (isNull == false)
            {
                if (txtFilter.Text == "All")
                {
                    LoadData();
                }
                else
                {
                    List<RoomViewModel> searchedRooms = _roomController.FilterByStatus(txtFilter.Text);
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
                }
            }
            else
            {
                LoadData();
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
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
            }
            else
            {
                LoadData();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnFloorCard_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            FloorCardForm floorCardForm = serviceProvider.GetRequiredService<FloorCardForm>();
            if (floorCardForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void RoomForm_Activated(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
