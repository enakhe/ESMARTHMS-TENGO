using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Forms.Tools.Option;
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
        public AddBookingForm(string reservationId, string guestId, string roomId, GuestController guestController, RoomController roomController, ReservationController reservationController)
        {
            InitializeComponent();
            DisableInput();
            _reservationId = reservationId;
            _guestId = guestId;
            _roomId = roomId;
            _guestController = guestController;
            _roomController = roomController;
            _reservationController = reservationController;
        }

        private void AddBookingForm_Load(object sender, EventArgs e)
        {
            DisableInput();
            LoadGuest();
            LoadRoom();
            LoadReservation();
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
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OptionsFrom optionsFrom = new OptionsFrom();
            if (optionsFrom.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
