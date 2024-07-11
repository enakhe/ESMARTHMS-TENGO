using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Forms.Booking;
using ESMART_HMS.Presentation.Forms.Rooms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Reservation
{
    public partial class ReservationForm : Form
    {
        private readonly ReservationController _reservationController;
        private readonly GuestController _guestController;
        private readonly RoomController _roomController;
        private readonly ConfigurationController _configurationController;
        private readonly BookingController _bookingController;
        public ReservationForm(ReservationController reservationController, GuestController guestController, RoomController roomController, ConfigurationController configurationController, BookingController bookingController)
        {
            _reservationController = reservationController;
            InitializeComponent();
            _guestController = guestController;
            _roomController = roomController;
            _configurationController = configurationController;
            _bookingController = bookingController;
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var allReservations = _reservationController.GetAllReservation();
                if (allReservations != null)
                {
                    foreach (var reservation in allReservations)
                    {
                        FormHelper.TryConvertStringToDecimal(reservation.Amount, out decimal amount);
                        reservation.Amount = FormHelper.FormatNumberWithCommas(amount);
                    }

                    dgvReservation.DataSource = allReservations;
                    txtReservationCount.Text = allReservations.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void addReservationBtn_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            AddReservationForm addReservationForm = serviceProvider.GetRequiredService<AddReservationForm>();
            if (addReservationForm.ShowDialog() == DialogResult.OK)
            {
                RoomForm roomForm = serviceProvider.GetRequiredService<RoomForm>();
                LoadData();
                roomForm.LoadData();
            }
        }

        private void btnBookRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReservation.SelectedRows.Count > 0)
                {
                    var row = dgvReservation.SelectedRows[0];
                    string reservationId = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();
                    string roomId = row.Cells["roomIdDataGridViewTextBoxColumn"].Value.ToString();
                    string guestId = row.Cells["GuestId"].Value.ToString();

                    AddBookingForm addBookingForm = new AddBookingForm(reservationId, guestId, roomId, _guestController, _roomController, _reservationController, _configurationController, _bookingController);
                    if (addBookingForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
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
    }
}
