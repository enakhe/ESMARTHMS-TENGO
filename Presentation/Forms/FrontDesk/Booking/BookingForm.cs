using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Forms.FrontDesk.booking;
using ESMART_HMS.Presentation.Sessions;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.booking
{
    public partial class bookingForm : Form
    {
        private readonly GuestController _guestController;
        private readonly RoomController _roomController;
        private readonly ReservationController _reservationController;
        private readonly ConfigurationController _configurationController;
        private readonly bookingController _bookingController;
        private readonly TransactionController _transactionController;
        private readonly ApplicationUserController _applicationUserController;
        private readonly CardController _cardController;
        private readonly SystemSetupController _systemSetupController;
        public bookingForm(bookingController bookingController, GuestController guestController, RoomController roomController, ReservationController reservationController, ConfigurationController configurationController, TransactionController transactionController, ApplicationUserController applicationUserController, CardController cardController, SystemSetupController systemSetupController)
        {
            _guestController = guestController;
            _roomController = roomController;
            _reservationController = reservationController;
            _configurationController = configurationController;
            _bookingController = bookingController;
            _transactionController = transactionController;
            _applicationUserController = applicationUserController;
            _cardController = cardController;
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            ApplyAuthorization();
            _systemSetupController = systemSetupController;
        }

        private void ApplyAuthorization()
        {
            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
        }

        private void bookingForm_Load(object sender, System.EventArgs e)
        {
            LoadbookingsData();
            this.bookingTableAdapter.Fill(this.eSMART_HMSDBDataSet.booking);

            dgvbooking.SelectionChanged += DataGridView1_SelectionChanged;
            splitContainer21.BackColor = splitContainer21.Panel1.BackColor;
            splitContainer21.SplitterWidth = 1;
            splitContainer21.BackColor = splitContainer21.Panel1.BackColor;
        }

        private void LoadbookingsData()
        {
            List<BookingViewModel> allbookings = _bookingController.GetAllbookings();
            if (allbookings != null)
            {
                foreach (var booking in allbookings)
                {
                    booking.TotalAmount = FormHelper.FormatNumberWithCommas(decimal.Parse(booking.TotalAmount));
                }
                dgvbooking.DataSource = allbookings;
                txtCount.Text = allbookings.Count.ToString();
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvbooking.SelectedRows.Count > 0)
                {
                    var row = dgvbooking.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                    GuestCard guestCard = _cardController.GetGuestCard(id);
                    if (guestCard != null)
                    {
                        btnBook.Enabled = false;
                    }
                    else
                    {
                        btnBook.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddbookingForm addbookingForm = new AddbookingForm("0", "0", "0", _guestController, _roomController, _reservationController, _configurationController, _bookingController, _transactionController, _applicationUserController, _systemSetupController);
            if (addbookingForm.ShowDialog() == DialogResult.OK)
            {
                LoadbookingsData();
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvbooking.SelectedRows.Count > 0)
                {
                    var row = dgvbooking.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                    Domain.Entities.Booking booking = _bookingController.GetbookingById(id);
                    Domain.Entities.Room room = _roomController.GetRealRoom(booking.RoomId);
                    GuestCard guestCard = _cardController.GetGuestCard(booking.Id);

                    room.Status = RoomStatusEnum.Vacant.ToString();

                    if (guestCard != null)
                    {
                        _cardController.DeleteGuestCard(guestCard.Id);
                    }
                    _roomController.UpdateRoom(room);
                    _bookingController.Deletebooking(booking);
                    LoadbookingsData();
                }
                else
                {
                    MessageBox.Show("Please select a booking to isue card.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvbooking.SelectedRows.Count > 0)
                {
                    var row = dgvbooking.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                    using (IssueCardForm issueCardForm = new IssueCardForm(_bookingController, id, _cardController, _applicationUserController))
                    {
                        if (issueCardForm.ShowDialog() == DialogResult.OK)
                        {

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a booking to isue card.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
