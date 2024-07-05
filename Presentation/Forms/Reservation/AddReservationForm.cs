using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Forms.Guests;
using ESMART_HMS.Presentation.Forms.Rooms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Reservation
{
    public partial class AddReservationForm : Form
    {
        ESMART_HMS.Domain.Entities.Reservation reservation = new ESMART_HMS.Domain.Entities.Reservation();
        private readonly GuestController _guestController;
        private readonly RoomController _roomController;
        private readonly ReservationController _reservationController;
        public AddReservationForm(GuestController guestController, RoomController roomController, ReservationController reservationController)
        {
            _guestController = guestController;
            _reservationController = reservationController;
            _roomController = roomController;
            InitializeComponent();
            LoadRoomData();
            LoadGuestData();
        }

        private void AddReservationForm_Load(object sender, EventArgs e)
        {
            LoadRoomData();
            LoadGuestData();
            this.roomTableAdapter.Fill(this.eSMART_HMSDBDataSet.Room);
            this.customerTableAdapter.Fill(this.eSMART_HMSDBDataSet.Guest);
        }

        public void LoadRoomData()
        {
            try
            {
                var allRoom = _roomController.GetAllRooms().Where(r => r.Status == RoomStatusEnum.Vacant.ToString()).ToList();
                if (allRoom != null)
                {
                    if (allRoom.Count > 0)
                    {
                        txtRoom.DataSource = allRoom;
                    }
                    else
                    {
                        List<string> noResult = new List<string>();
                        noResult.Add("No Vacant Room");
                        txtRoom.DataSource = noResult;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public void LoadGuestData()
        {
            try
            {
                var allGuest = _guestController.LoadGuests().ToList();
                if (allGuest != null)
                {
                    if (allGuest.Count > 0)
                    {
                        txtGuest.DataSource = allGuest;
                    }
                    else
                    {
                        List<string> noResult = new List<string>();
                        noResult.Add("No Guest");
                        txtGuest.DataSource = noResult;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            AddGuestForm addGuestForm = serviceProvider.GetRequiredService<AddGuestForm>();
            if (addGuestForm.ShowDialog() == DialogResult.OK)
            {
                LoadGuestData();
            }
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            AddRoomForm addRoomForm = serviceProvider.GetRequiredService<AddRoomForm>();
            if (addRoomForm.ShowDialog() == DialogResult.OK)
            {
                LoadRoomData();
            }
        }

        private void txtRoom_TextChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtCheckOut.Text, txtCheckIn.Text, txtRoom.SelectedValue.ToString());
            if (isNull == false)
            {
                Room room = _roomController.GetRealRoom(txtRoom.SelectedValue.ToString());
                if (room != null)
                {
                    txtAmount.Text = FormHelper.GetPriceByRateAndTime(DateTime.Parse(txtCheckIn.Text), DateTime.Parse(txtCheckOut.Text), room.Rate).ToString();
                }
            }
        }

        private void txtCheckIn_ValueChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtCheckOut.Text, txtCheckIn.Text, txtRoom.SelectedValue.ToString());
            if (isNull == false)
            {
                Room room = _roomController.GetRealRoom(txtRoom.SelectedValue.ToString());
                txtAmount.Text = FormHelper.GetPriceByRateAndTime(DateTime.Parse(txtCheckIn.Text), DateTime.Parse(txtCheckOut.Text), room.Rate).ToString();
            }
        }

        private void txtCheckOut_ValueChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtCheckOut.Text, txtCheckIn.Text, txtRoom.SelectedValue.ToString());
            if (isNull == false)
            {
                Room room = _roomController.GetRealRoom(txtRoom.SelectedValue.ToString());
                txtAmount.Text = FormHelper.GetPriceByRateAndTime(DateTime.Parse(txtCheckIn.Text), DateTime.Parse(txtCheckOut.Text), room.Rate).ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Random random = new Random();

                reservation.Id = Guid.NewGuid().ToString();
                reservation.ReservationId = "RES" + random.Next(1000, 5000);
                reservation.GuestId = txtGuest.SelectedValue.ToString();
                reservation.Guest = _guestController.GetGuestById(reservation.GuestId);

                reservation.RoomId = txtRoom.SelectedValue.ToString();
                reservation.Room = _roomController.GetRealRoom(reservation.RoomId);

                reservation.CheckInDate = txtCheckIn.Value;
                reservation.CheckOutDate = txtCheckOut.Value;

                reservation.PaymentMethod = txtPaymentMethod.Text;
                reservation.Amount = FormHelper.GetPriceByRateAndTime(reservation.CheckInDate, reservation.CheckOutDate, reservation.Room.Rate);

                reservation.IsTrashed = false;
                reservation.DateCreated = DateTime.Now;
                reservation.DateModified = DateTime.Now;

                reservation.Status = RoomStatusEnum.Reserved.ToString();

                Room room = _roomController.GetRealRoom(reservation.RoomId);
                room.Status = RoomStatusEnum.Reserved.ToString();
                room.DateModified = DateTime.Now;

                _reservationController.AddReservation(reservation);
                _roomController.UpdateRoom(room);
                this.DialogResult = DialogResult.OK;

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }
    }
}
