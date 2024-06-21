using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Forms.Customers;
using ESMART_HMS.Presentation.Forms.Reservation;
using ESMART_HMS.Presentation.Forms.Rooms;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms
{
    public partial class Home : Form
    {
        CustomerForm customerForm;
        RoomForm roomForm;
        ReservationForm reservationForm;

        private readonly CustomerController _customerController;
        private readonly RoomController _roomController;
        private readonly RoomTypeController _roomTypeController;
        private readonly ReservationController _reservationController;

        public Home(CustomerController customerViewModel, RoomController roomController, RoomTypeController roomTypeController, ReservationController reservationController)
        {
            InitializeComponent();
            _customerController = customerViewModel;
            _roomController = roomController;
            _roomTypeController = roomTypeController;
            _reservationController = reservationController;
        }

        private void Customer_FormClosed(object sender, FormClosedEventArgs e)
        {
            customerForm = null;
        }

        private void customerMainToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (customerForm == null)
            {
                customerForm = new CustomerForm(_customerController);
                customerForm.FormClosed += Customer_FormClosed;
                customerForm.MdiParent = this;
                customerForm.Dock = DockStyle.Fill;
                customerForm.Show();
            }
            else
            {
                customerForm.Activate();
            }
        }

        private void Room_FormClosed(object sender, FormClosedEventArgs e)
        {
            customerForm = null;
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (roomForm == null)
            {
                roomForm = new RoomForm(_roomController, _roomTypeController);
                roomForm.FormClosed += Room_FormClosed;
                roomForm.MdiParent = this;
                roomForm.Dock = DockStyle.Fill;
                roomForm.Show();
            }
            else
            {
                roomForm.Activate();
            }
        }

        private void Reservation_FormClosed(object sender, FormClosedEventArgs e)
        {
            customerForm = null;
        }

        private void reservationListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (reservationForm == null)
            {
                reservationForm = new ReservationForm(_reservationController);
                reservationForm.FormClosed += Reservation_FormClosed;
                reservationForm.MdiParent = this;
                reservationForm.Dock = DockStyle.Fill;
                reservationForm.Show();
            }
            else
            {
                reservationForm.Activate();
            }
        }
    }
}
