using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Inventory;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Maintenance
{
    public partial class RecycledItemForm : Form
    {
        private readonly bookingController _bookingController;
        private readonly GuestController _guestController;
        private readonly ReservationController _reservationController;
        private readonly InventoryController _inventoryController;
        public RecycledItemForm(bookingController bookingController, GuestController guestController, ReservationController reservationController, InventoryController inventoryController)
        {
            _bookingController = bookingController;
            _guestController = guestController;
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            _reservationController = reservationController;
            _inventoryController = inventoryController;
        }

        private void RecycledItemForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eSMART_HMSDBDataSet.Inventory' table. You can move, or remove it, as needed.
            LoadbookingsData();
            LoadGuestData();
            LoadReservation();
            LoadItem();

            dgvbooking.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvbooking.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);

            dgvGuests.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvGuests.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);

            dgvReservation.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvReservation.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);

            dgvItem.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvItem.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
        }

        private void LoadbookingsData()
        {
            List<BookingViewModel> allbookings = _bookingController.GetRecycledBooking();
            if (allbookings != null)
            {
                foreach (var booking in allbookings)
                {
                    booking.TotalAmount = FormHelper.FormatNumberWithCommas(decimal.Parse(booking.TotalAmount));
                }
                dgvbooking.DataSource = allbookings;
            }
        }

        private void LoadGuestData()
        {
            var allGuest = _guestController.GetDeletedGuest();
            if (allGuest != null)
            {
                dgvGuests.DataSource = allGuest;
            }
        }

        private void LoadReservation()
        {
            var allReservations = _reservationController.GetAllReservation();
            if (allReservations != null)
            {
                foreach (var reservation in allReservations)
                {
                    FormHelper.TryConvertStringToDecimal(reservation.Amount, out decimal amount);
                    FormHelper.TryConvertStringToDecimal(reservation.AmountPaid, out decimal amountPaid);
                    FormHelper.TryConvertStringToDecimal(reservation.Balance, out decimal balance);

                    reservation.Amount = FormHelper.FormatNumberWithCommas(amount);
                    reservation.AmountPaid = FormHelper.FormatNumberWithCommas(amountPaid);
                    reservation.Balance = FormHelper.FormatNumberWithCommas(balance);
                    reservation.DateCreated = FormHelper.FormatDateTimeWithSuffix(reservation.DateCreated);
                    reservation.DateModified = FormHelper.FormatDateTimeWithSuffix(reservation.DateModified);

                    reservation.CheckInDate = FormHelper.FormatDateTimeWithSuffix(reservation.CheckInDate);
                    reservation.CheckOutDate = FormHelper.FormatDateTimeWithSuffix(reservation.CheckOutDate);
                }

                dgvReservation.DataSource = allReservations;
            }
        }

        private void LoadItem()
        {
            List<InventoryViewModel> inventoryList = _inventoryController.GetInventoryViewModels();
            foreach (InventoryViewModel inventoryViewModel in inventoryList)
            {
                inventoryViewModel.SellingPrice = FormHelper.FormatNumberWithCommas(decimal.Parse(inventoryViewModel.SellingPrice));
                inventoryViewModel.CostPrice = FormHelper.FormatNumberWithCommas(decimal.Parse(inventoryViewModel.CostPrice));

                inventoryViewModel.DateCreated = FormHelper.FormatDateTimeWithSuffix(inventoryViewModel.DateCreated);
                inventoryViewModel.DateModified = FormHelper.FormatDateTimeWithSuffix(inventoryViewModel.DateModified);
            }
            dgvItem.DataSource = inventoryList;
        }
    }
}
