﻿using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Forms.Guests;
using ESMART_HMS.Presentation.Sessions;
using ESMART_HMS.Presentation.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.booking
{
    public partial class AddbookingForm : Form
    {
        private readonly string _reservationId;
        private bool _continueRunning = true;

        private readonly string _guestId;
        private readonly string _roomId;
        private readonly GuestController _guestController;
        private readonly RoomController _roomController;
        private readonly ReservationController _reservationController;
        private readonly ConfigurationController _configurationController;
        private readonly bookingController _bookingController;
        private readonly TransactionController _transactionController;
        private readonly ApplicationUserController _applicationUserController;
        private readonly SystemSetupController _systemSetupController;
        public AddbookingForm(string reservationId, string guestId, string roomId, GuestController guestController, RoomController roomController, ReservationController reservationController, ConfigurationController configurationController, bookingController bookingController, TransactionController transactionController, ApplicationUserController applicationUserController, SystemSetupController systemSetupController)
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
            _transactionController = transactionController;
            _applicationUserController = applicationUserController;
            _systemSetupController = systemSetupController;
        }

        private void AddbookingForm_Load(object sender, EventArgs e)
        {
            DisableInput();
            LoadGuest();
            LoadRoom();
            LoadReservation();
            LoadMetric();
            LoadTotalAmount();
            LoadBankDetails();
            txtCheckIn.Value = DateTime.Now;
        }

        public async void StartBackgroundTask()
        {
            await Task.Run(() =>
            {
                while (_continueRunning)
                {
                    LoadBankDetails();
                    LoadGuest();
                    LoadRoom();
                    LoadMetric();
                    Task.Delay(1000).Wait();
                }
            });
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
                btnGuest.Enabled = false;
            }
            else
            {
                txtGuest.Enabled = true;
                txtRoom.Enabled = true;
                txtCheckIn.Enabled = true;
                txtPaymentMethod.Enabled = true;
                txtbookingAmount.Enabled = true;
                btnGuest.Enabled = true;
                txtbookingAmount.Enabled = false;
            }
        }

        public void LoadBankDetails()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(LoadBankDetails));
                return;
            }
            List<BankAccountViewModel> allAccounts = _systemSetupController.GetAllBankAccount();
            if (allAccounts != null)
            {
                foreach (BankAccountViewModel account in allAccounts)
                {
                    bankAccounts.Items.Add($"{account.BankAccNo} | {account.BankName}");
                }
            }
        }

        private void LoadGuest()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(LoadGuest));
                return;
            }
            Guest guest = _guestController.GetGuestById(_guestId);
            if (guest != null)
            {
                List<Guest> guestList = new List<Guest>() { guest };
                txtGuest.DataSource = guestList;
            }
            else
            {
                List<GuestViewModel> allGuest = _guestController.LoadGuests();
                if (allGuest != null)
                {
                    txtGuest.DataSource = allGuest;
                }
            }
        }

        private void LoadRoom()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(LoadRoom));
                return;
            }
            Room room = _roomController.GetRealRoom(_roomId);
            if (room != null)
            {
                List<Room> roomList = new List<Room>() { room };
                foreach (var roomm in roomList)
                {
                    roomm.RoomNo = $"{roomm.RoomNo}";
                }
                txtRoom.DataSource = roomList;
            }
            else
            {
                List<RoomViewModel> allRooms = _roomController.GetAvailbleRoom();
                if (allRooms != null)
                {
                    if (allRooms.Count > 0)
                    {
                        foreach(var roomm in allRooms)
                        {
                            roomm.RoomNo = $"{roomm.RoomNo}";
                        }
                        txtRoom.DataSource = allRooms.OrderBy(r => r.RoomNo).ToList();
                    }
                    else
                    {
                        List<string> noResult = new List<string>() { "No Vacant Room" };
                        noOfDays.Enabled = false;
                        txtRoom.DataSource = noResult;
                    }
                }
            }
        }

        private void LoadReservation()
        {
            ESMART_HMS.Domain.Entities.Reservation reservation = _reservationController.GetReservationById(_reservationId);
            if (reservation != null)
            {
                txtAmount.Text = FormHelper.FormatNumberWithCommas((reservation.Amount - reservation.AmountPaid));
                txtCheckIn.Value = reservation.CheckInDate;
                txtCheckOut.Value = reservation.CheckOutDate;
                txtPaymentMethod.Text = reservation.PaymentMethod;
                TimeSpan difference = txtCheckOut.Value - txtCheckIn.Value;
                txtDuration.Text = difference.Days.ToString();
            }
        }

        private void LoadMetric()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(LoadMetric));
                return;
            }
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
                decimal vatAmount = decimal.Parse(txtAmount.Text) * (decimal.Parse(txtVAT.Text) / 100);
                decimal totalAmount = decimal.Parse(txtAmount.Text) + vatAmount;

                txtTotalAmount.Text = totalAmount.ToString();
            }
        }

        private void txtNoOfPerson_TextChanged(object sender, EventArgs e)
        {
            if (txtRoom.Text != null || txtRoom.Text != "")
            {
                Room room = _roomController.GetRealRoom(txtRoom.SelectedValue.ToString());
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
        }

        private void txtCheckOut_ValueChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtCheckOut.Text, txtCheckIn.Text, txtRoom.SelectedValue.ToString());
            if (isNull == false)
            {
                Room room = _roomController.GetRealRoom(_roomId);
                Domain.Entities.Reservation reservation = _reservationController.GetReservationById(_reservationId);

                if (room != null)
                {
                    txtbookingAmount.Text = (FormHelper.GetPriceByRateAndTime(DateTime.Parse(txtCheckIn.Text), DateTime.Parse(txtCheckOut.Text), room.Rate)).ToString();
                }

                if (reservation != null)
                {
                    if (txtCheckOut.Value > reservation.CheckOutDate)
                    {
                        decimal newPrice = FormHelper.GetPriceByRateAndTime(reservation.CheckOutDate, DateTime.Parse(txtCheckOut.Text), room.Rate);
                        txtAmount.Text = (newPrice + decimal.Parse(txtAmount.Text)).ToString();
                    }
                }
                else
                {
                    Room bookingRoom = _roomController.GetRealRoom(txtRoom.SelectedValue.ToString());
                    txtAmount.Text = FormHelper.GetPriceByRateAndTime(DateTime.Parse(txtCheckIn.Text), DateTime.Parse(txtCheckOut.Text), bookingRoom.Rate).ToString();
                    txtbookingAmount.Text = txtAmount.Text;
                }

                TimeSpan difference = txtCheckOut.Value - txtCheckIn.Value;
                txtDuration.Text = difference.Days.ToString();
                LoadTotalAmount();
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
                if (txtPaymentMethod.Text == "CASH")
                {
                    bankAccounts.SelectedItem = "";
                }

                Domain.Entities.Booking booking = new Domain.Entities.Booking();

                Random random = new Random();

                booking.Id = Guid.NewGuid().ToString();
                booking.BookingId = "BK" + random.Next(1000, 5000);
                booking.GuestId = txtGuest.SelectedValue.ToString();
                booking.Guest = _guestController.GetGuestById(txtGuest.SelectedValue.ToString());
                booking.RoomId = txtRoom.SelectedValue.ToString();
                booking.Room = _roomController.GetRealRoom(txtRoom.SelectedValue.ToString());
                booking.ReservationId = _reservationId;
                booking.CheckInDate = txtCheckIn.Value;
                DateTime selectedDate = txtCheckOut.Value;
                booking.CheckOutDate = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 12, 0, 0);
                booking.PaymentMethod = txtPaymentMethod.Text;
                booking.Amount = decimal.Parse(txtbookingAmount.Text);
                booking.NoOfPerson = int.Parse(txtNoOfPerson.Text);
                booking.Duration = int.Parse(txtDuration.Text);
                booking.Discount = decimal.Parse(txtDiscount.Text);
                booking.VAT = decimal.Parse(txtVAT.Text);
                booking.TotalAmount = decimal.Parse(txtTotalAmount.Text);
                booking.DateCreated = DateTime.Now;
                booking.DateModified = DateTime.Now;
                booking.IsTrashed = false;
                booking.CreatedBy = AuthSession.CurrentUser.Id;
                booking.ApplicationUser = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);

                _bookingController.Addbooking(booking);

                Domain.Entities.Room room = _roomController.GetRealRoom(txtRoom.SelectedValue.ToString());
                room.Status = RoomStatusEnum.CheckedIn.ToString();
                _roomController.UpdateRoom(room);

                if (_reservationId != "0")
                {
                    Domain.Entities.Reservation reservation = _reservationController.GetReservationById(_reservationId);
                    reservation.Status = RoomStatusEnum.CheckedIn.ToString();
                    _reservationController.UpdateReservation(reservation);

                    Domain.Entities.Transaction foundTransaction = _transactionController.GetByServiceIdAndStatus(reservation.ReservationId, "Un Paid");
                    if (foundTransaction != null)
                    {
                        foundTransaction.Status = "Paid";
                        foundTransaction.Amount = decimal.Parse(txtTotalAmount.Text);
                        _transactionController.UpdateTransaction(foundTransaction);

                        if (bankAccounts.SelectedItem != null)
                        {
                            foundTransaction.BankAccount = bankAccounts.SelectedItem.ToString();
                        }

                        reservation.Status = "CheckedIn";
                        _reservationController.UpdateReservation(reservation);
                    }
                }
                else
                {
                    if (txtUnpaid.Checked)
                    {
                        ESMART_HMS.Domain.Entities.Transaction transaction = new ESMART_HMS.Domain.Entities.Transaction()
                        {
                            Id = Guid.NewGuid().ToString(),
                            TransactionId = "TR" + random.Next(1000, 5000),
                            GuestId = booking.GuestId,
                            Guest = booking.Guest,
                            ServiceId = booking.BookingId,
                            Date = DateTime.Now,
                            Amount = booking.TotalAmount,
                            Type = "Room Service",
                            Description = "Booking",
                            Status = "Un Paid",
                        };

                        if (bankAccounts.SelectedItem != null)
                        {
                            transaction.BankAccount = bankAccounts.SelectedItem.ToString();
                        }

                        _transactionController.AddTransaction(transaction);
                    }
                    else
                    {
                        ESMART_HMS.Domain.Entities.Transaction transaction = new ESMART_HMS.Domain.Entities.Transaction()
                        {
                            Id = Guid.NewGuid().ToString(),
                            TransactionId = "TR" + random.Next(1000, 5000),
                            GuestId = booking.GuestId,
                            Guest = booking.Guest,
                            ServiceId = booking.BookingId,
                            Date = DateTime.Now,
                            Amount = booking.TotalAmount,
                            Type = "Room Service",
                            Description = "Booking",
                            Status = "Paid",
                        };

                        if (bankAccounts.SelectedItem != null)
                        {
                            transaction.BankAccount = bankAccounts.SelectedItem.ToString();
                        }

                        _transactionController.AddTransaction(transaction);
                    }
                    

                    
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
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
                LoadGuest();
            }
        }

        private void txtbookingAmount_TextChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtbookingAmount.Text);
            if (isNull == false)
            {
                txtbookingAmount.Text = FormHelper.FormatNumberWithCommas(decimal.Parse(txtbookingAmount.Text));
            }
        }

        private void noOfDays_TextChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(noOfDays.Text);
            if (isNull == false)
            {
                int numberOfDays = int.Parse(noOfDays.Text);
                txtCheckOut.Value = txtCheckIn.Value.AddDays(numberOfDays);
            }
        }

        private void txtPaymentMethod_SelectedValueChanged(object sender, EventArgs e)
        {
            if (txtPaymentMethod.Text == "CASH")
            {
                bankAccounts.Enabled = false;
            }
            else
            {
                bankAccounts.Enabled = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bool isNull = FormHelper.AreAnyNullOrEmpty(txtSearch.Text);
                if (isNull == false)
                {
                    var guest = _guestController.SearchGuest(txtSearch.Text);
                    if (guest != null)
                    {
                        txtGuest.DataSource = guest;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}