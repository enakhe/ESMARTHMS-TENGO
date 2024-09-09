using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Forms.FrontDesk.Booking;
using ESMART_HMS.Presentation.Sessions;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Booking
{
    public partial class BookingForm : Form
    {
        private readonly GuestController _guestController;
        private readonly RoomController _roomController;
        private readonly ReservationController _reservationController;
        private readonly ConfigurationController _configurationController;
        private readonly BookingController _bookingController;
        private readonly TransactionController _transactionController;
        private readonly ApplicationUserController _applicationUserController;
        private readonly CardController _cardController;
        public BookingForm(BookingController bookingController, GuestController guestController, RoomController roomController, ReservationController reservationController, ConfigurationController configurationController, TransactionController transactionController, ApplicationUserController applicationUserController, CardController cardController)
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
            ApplyAuthorization();
        }

        private void ApplyAuthorization()
        {
            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
        }

        private void BookingForm_Load(object sender, System.EventArgs e)
        {
            LoadBookingsData();
            this.bookingTableAdapter.Fill(this.eSMART_HMSDBDataSet.Booking);

            dgvBooking.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void LoadBookingsData()
        {
            List<BookingViewModel> allBookings = _bookingController.GetAllBookings();
            if (allBookings != null)
            {
                foreach (var booking in allBookings)
                {
                    booking.TotalAmount = FormHelper.FormatNumberWithCommas(decimal.Parse(booking.TotalAmount));
                }
                dgvBooking.DataSource = allBookings;
                txtCount.Text = allBookings.Count.ToString();
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvBooking.SelectedRows.Count > 0)
                {
                    var row = dgvBooking.SelectedRows[0];
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
            AddBookingForm addBookingForm = new AddBookingForm("0", "0", "0", _guestController, _roomController, _reservationController, _configurationController, _bookingController, _transactionController, _applicationUserController);
            if (addBookingForm.ShowDialog() == DialogResult.OK)
            {
                LoadBookingsData();
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBooking.SelectedRows.Count > 0)
                {
                    var row = dgvBooking.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                    Domain.Entities.Booking booking = _bookingController.GetBookingById(id);
                    Domain.Entities.Room room = _roomController.GetRealRoom(booking.RoomId);
                    room.Status = RoomStatusEnum.Vacant.ToString();

                    _roomController.UpdateRoom(room);
                    _bookingController.DeleteBooking(booking);
                    LoadBookingsData();
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
                if (dgvBooking.SelectedRows.Count > 0)
                {
                    var row = dgvBooking.SelectedRows[0];
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
