using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Middleware;
using ESMART_HMS.Presentation.Sessions;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;
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
        public BookingForm(BookingController bookingController, GuestController guestController, RoomController roomController, ReservationController reservationController, ConfigurationController configurationController, TransactionController transactionController, ApplicationUserController applicationUserController)
        {
            InitializeComponent();
            _guestController = guestController;
            _roomController = roomController;
            _reservationController = reservationController;
            _configurationController = configurationController;
            _bookingController = bookingController;
            _transactionController = transactionController;
            _applicationUserController = applicationUserController;
            ApplyAuthorization();
        }

        private void ApplyAuthorization()
        {
            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
            AuthorizationMiddleware.Protect(user, btnDelete, "SuperAdmin");
        }

        private void BookingForm_Load(object sender, System.EventArgs e)
        {
            LoadBookingsData();
            this.bookingTableAdapter.Fill(this.eSMART_HMSDBDataSet.Booking);
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

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            AddBookingForm addBookingForm = new AddBookingForm("0", "0", "0", _guestController, _roomController, _reservationController, _configurationController, _bookingController, _transactionController, _applicationUserController);
            if (addBookingForm.ShowDialog() == DialogResult.OK)
            {
                LoadBookingsData();
            }
        }
    }
}
