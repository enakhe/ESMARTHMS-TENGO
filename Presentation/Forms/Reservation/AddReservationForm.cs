using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Forms.Customers;
using ESMART_HMS.Presentation.Forms.Rooms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Reservation
{
    public partial class AddReservationForm : Form
    {
        ESMART_HMS.Domain.Entities.Reservation reservation = new ESMART_HMS.Domain.Entities.Reservation();
        private readonly CustomerController _customerController;
        private readonly RoomController _roomController;
        private readonly ReservationController _reservationController;
        private readonly FormHelper _formHelper;
        public AddReservationForm(CustomerController customerController, RoomController roomController, ReservationController reservationController, FormHelper formHelper)
        {
            _customerController = customerController;
            _reservationController = reservationController;
            _roomController = roomController;
            _formHelper = formHelper;
            InitializeComponent();
        }

        private void AddReservationForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eSMART_HMSDBDataSet.Room' table. You can move, or remove it, as needed.
            this.roomTableAdapter.Fill(this.eSMART_HMSDBDataSet.Room);
            // TODO: This line of code loads data into the 'eSMART_HMSDBDataSet.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.eSMART_HMSDBDataSet.Customer);
        }

        public void LoadRoomData()
        {
            try
            {
                var allRoom = _roomController.GetAllRooms();
                if (allRoom != null)
                {
                    txtRoom.DataSource = allRoom;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            AddCustomerForm addCustomerForm = serviceProvider.GetRequiredService<AddCustomerForm>();
            if (addCustomerForm.ShowDialog() == DialogResult.OK)
            {
                //LoadData();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Random random = new Random();                

                reservation.Id = Guid.NewGuid().ToString();
                reservation.ReservationId = "RES" + random.Next(1000, 5000);
                reservation.CustomerId = txtCustomer.SelectedValue.ToString();
                reservation.Customer = _customerController.GetCustomerById(reservation.CustomerId);

                reservation.RoomId = txtRoom.SelectedValue.ToString();
                reservation.Room = _roomController.GetRealRoom(reservation.RoomId);

                reservation.CheckInDate = txtCheckIn.Value;
                reservation.CheckOutDate = txtCheckOut.Value;

                reservation.PaymentMethod = txtPaymentMethod.Text;
                reservation.ReservationRefNo = "REF" + random.Next(10000, 50000);
                reservation.Status = txtStatus.Text;

                reservation.Amount = _formHelper.GetPriceByRateAndTime(reservation.CheckInDate, reservation.CheckOutDate, reservation.Room.Rate);

                reservation.IsTrashed = false;
                reservation.DateCreated = DateTime.Now;
                reservation.DateModified = DateTime.Now;

                _reservationController.AddReservation(reservation);
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
