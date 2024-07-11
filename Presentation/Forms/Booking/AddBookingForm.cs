using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Forms.Tools.Option;
using ESMART_HMS.Presentation.Forms.Tools.Option.Financial;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Booking
{
    public partial class AddBookingForm : Form
    {
        private readonly string _reservationId;
        private readonly string _guestId;
        private readonly string _roomId;
        private readonly GuestController _guestController;
        private readonly RoomController _roomController;
        private readonly ReservationController _reservationController;
        private readonly ConfigurationController _configurationController;
        private readonly BookingController _bookingController;
        public AddBookingForm(string reservationId, string guestId, string roomId, GuestController guestController, RoomController roomController, ReservationController reservationController, ConfigurationController configurationController, BookingController bookingController)
        {
            InitializeComponent();
            DisableInput();
            _reservationId = reservationId;
            _guestId = guestId;
            _roomId = roomId;
            _guestController = guestController;
            _roomController = roomController;
            _reservationController = reservationController;
            _configurationController = configurationController;
            _bookingController = bookingController;
        }

        private void AddBookingForm_Load(object sender, EventArgs e)
        {
            DisableInput();
            LoadGuest();
            LoadRoom();
            LoadReservation();
            LoadMetric();
            LoadTotalAmount();
        }

        private void DisableInput()
        {
            if (_reservationId != "0")
            {
                txtGuest.Enabled = false;
                txtRoom.Enabled = false;
                txtCheckIn.Enabled = false;
                txtPaymentMethod.Enabled = false;
                txtAmount.Enabled = false;
                txtDuration.Enabled = false;
                txtVAT.Enabled = false;
                txtDiscount.Enabled = false;
                txtTotalAmount.Enabled = false;
            }
        }

        private void LoadGuest()
        {
            Guest guest = _guestController.GetGuestById(_guestId);
            if (guest != null)
            {
                List<Guest> guestList = new List<Guest>() { guest };
                txtGuest.DataSource = guestList;
            }
        }

        private void LoadRoom()
        {
            Room room = _roomController.GetRealRoom(_roomId);
            if (room != null)
            {
                List<Room> roomList = new List<Room>() { room };
                txtRoom.DataSource = roomList;

                txtAmount.Text = FormHelper.FormatNumberWithCommas(room.Rate);
            }
        }

        private void LoadReservation()
        {
            ESMART_HMS.Domain.Entities.Reservation reservation = _reservationController.GetReservationById(_reservationId);
            if (reservation != null)
            {
                txtCheckIn.Value = reservation.CheckInDate;
                txtCheckOut.Value = reservation.CheckOutDate;
                txtPaymentMethod.Text = reservation.PaymentMethod;
                TimeSpan difference = txtCheckOut.Value - txtCheckIn.Value;
                txtDuration.Text = difference.Days.ToString();
            }
        }

        private void LoadMetric()
        {
            Configuration vatConfiguration = _configurationController.GetConfigurationValue("VAT");
            txtVAT.Text = vatConfiguration.Value.ToString();

            Configuration discountConfiguration = _configurationController.GetConfigurationValue("Discount");
            txtDiscount.Text = discountConfiguration.Value.ToString();
        }

        private void LoadTotalAmount()
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtVAT.Text, txtAmount.Text);
            if (isNull == false)
            {
                decimal vatAmount = 100 * (decimal.Parse(txtVAT.Text) / 100);
                decimal totalAmount = decimal.Parse(txtAmount.Text) + vatAmount;

                txtTotalAmount.Text = totalAmount.ToString();
            }
        }

        private void txtNoOfPerson_TextChanged(object sender, EventArgs e)
        {
            Room room = _roomController.GetRealRoom(_roomId);
            if (room != null)
            {
                bool isNull = FormHelper.AreAnyNullOrEmpty(txtNoOfPerson.Text);
                if (isNull == false)
                {
                    if (int.Parse(txtNoOfPerson.Text) > room.AdultPerRoom + room.ChildrenPerRoom)
                    {
                        MessageBox.Show("The number of persons exceed room capacity", "Full capacity", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtCheckOut_ValueChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtCheckOut.Text, txtCheckIn.Text, txtRoom.SelectedValue.ToString());
            if (isNull == false)
            {
                Room room = _roomController.GetRealRoom(txtRoom.SelectedValue.ToString());
                txtAmount.Text = FormHelper.GetPriceByRateAndTime(DateTime.Parse(txtCheckIn.Text), DateTime.Parse(txtCheckOut.Text), room.Rate).ToString();

                TimeSpan difference = txtCheckOut.Value - txtCheckIn.Value;
                txtDuration.Text = difference.Days.ToString();
                LoadTotalAmount();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OptionsFrom optionsFrom = new OptionsFrom();
            if (optionsFrom.ShowDialog() == DialogResult.OK)
            {
                this.AddBookingForm_Load(sender, e);
                LoadMetric();
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtAmount.Text);
            if (isNull == false)
            {
                txtAmount.Text = FormHelper.FormatNumberWithCommas(decimal.Parse(txtAmount.Text));
            }
        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtTotalAmount.Text);
            if (isNull == false)
            {
                txtTotalAmount.Text = FormHelper.FormatNumberWithCommas(decimal.Parse(txtTotalAmount.Text));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtAmount.Text, txtCheckIn.Text, txtCheckOut.Text, txtDiscount.Text, txtDuration.Text, txtGuest.Text, txtNoOfPerson.Text, txtPaymentMethod.Text, txtRoom.Text, txtTotalAmount.Text, txtVAT.Text);
            if (isNull == false)
            {
                Domain.Entities.Booking booking = new Domain.Entities.Booking();

                Random random = new Random();

                booking.Id = Guid.NewGuid().ToString();
                booking.BookingId = "BK" + random.Next(1000, 5000);
                booking.GuestId = _guestId;
                booking.Guest = _guestController.GetGuestById(_guestId);
                booking.RoomId = _roomId;
                booking.Room = _roomController.GetRealRoom(_roomId);
                booking.ReservationId = _reservationId;
                booking.Reservation = _reservationController.GetReservationById(_reservationId);
                booking.CheckInDate = txtCheckIn.Value;
                booking.CheckOutDate = txtCheckOut.Value;
                booking.PaymentMethod = txtPaymentMethod.Text;
                booking.Amount = decimal.Parse(txtAmount.Text);
                booking.NoOfPerson = int.Parse(txtNoOfPerson.Text);
                booking.Duration = int.Parse(txtNoOfPerson.Text);
                booking.Discount = decimal.Parse(txtDiscount.Text);
                booking.VAT = decimal.Parse(txtVAT.Text);
                booking.TotalAmount = decimal.Parse(txtTotalAmount.Text);
                booking.DateCreated = DateTime.Now;
                booking.DateModified = DateTime.Now;
                booking.IsTrashed = false;

                _bookingController.AddBooking(booking);

                Domain.Entities.Reservation reservation = _reservationController.GetReservationById(_reservationId);
                reservation.Status = RoomStatusEnum.CheckedIn.ToString();
                _reservationController.UpdateReservation(reservation);

                Domain.Entities.Room room = _roomController.GetRealRoom(_roomId);
                room.Status = RoomStatusEnum.CheckedIn.ToString();
                _roomController.UpdateRoom(room);


                this.DialogResult = DialogResult.OK;
                this.Close();
            } 
            else
            {
                MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}