﻿using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Forms.Guests;
using ESMART_HMS.Presentation.Forms.Rooms;
using ESMART_HMS.Presentation.Sessions;
using ESMART_HMS.Presentation.ViewModels;
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
        private readonly ApplicationUserController _applicationUserController;
        private readonly TransactionController _transactionController;
        private readonly SystemSetupController _systemSetupController;
        private readonly ESMART_HMSDBEntities _db;
        public AddReservationForm(GuestController guestController, RoomController roomController, ReservationController reservationController, ApplicationUserController applicationUserController, TransactionController transactionController, SystemSetupController systemSetupController, ESMART_HMSDBEntities db)
        {
            _guestController = guestController;
            _reservationController = reservationController;
            _roomController = roomController;
            _applicationUserController = applicationUserController;
            _transactionController = transactionController;
            _systemSetupController = systemSetupController;
            InitializeComponent();
            ApplyAuthorization();
            LoadBankDetails();
            _db = db;
        }

        private void AddReservationForm_Load(object sender, EventArgs e)
        {
            this.customerTableAdapter.Fill(this.eSMART_HMSDBDataSet.Guest);
            LoadRoomData();
            LoadGuestData();
            txtCheckIn.Value = DateTime.Now;
            txtCheckOut.Value = DateTime.Now.AddDays(1);
        }

        private void ApplyAuthorization()
        {
            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
        }

        public void LoadBankDetails()
        {
            List<BankAccountViewModel> allAccounts = _systemSetupController.GetAllBankAccount();
            if (allAccounts != null)
            {
                foreach (BankAccountViewModel account in allAccounts)
                {
                    bankAccounts.Items.Add($"{account.BankAccNo} | {account.BankName}");
                }
            }
        }

        public void LoadRoomData()
        {
            try
            {
                var allRoom = _roomController.GetAvailbleRoom();
                if (allRoom != null)
                {
                    if (allRoom.Count > 0)
                    {
                        foreach (var roomm in allRoom)
                        {
                            roomm.RoomNo = $"{roomm.RoomNo}";
                        }
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
                var allGuest = _guestController.LoadGuests();
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
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtCheckOut.Text, txtCheckIn.Text, txtRoom.SelectedValue.ToString(), textBox2.Text);
            if (isNull == false)
            {
                Room room = _roomController.GetRealRoom(txtRoom.SelectedValue.ToString());
                if (room != null)
                {
                    txtAmount.Text = FormHelper.GetPriceByRateAndTime(DateTime.Parse(txtCheckIn.Text), DateTime.Parse(txtCheckOut.Text), room.Rate).ToString();
                }

                int numberOfDays = int.Parse(textBox2.Text);
                txtCheckOut.Value = txtCheckIn.Value.AddDays(numberOfDays);
            }
        }

        private void txtCheckOut_ValueChanged(object sender, EventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool isNull = FormHelper.AreAnyNullOrEmpty(txtGuest.Text, txtRoom.Text, txtCheckIn.Text, txtCheckOut.Text, txtPaymentMethod.Text, txtAmount.Text, txtAmountPaid.Text, textBox2.Text);
                if (isNull == false)
                {
                    Random random = new Random();

                    reservation.Id = Guid.NewGuid().ToString();
                    reservation.ReservationId = "RES" + random.Next(1000, 5000);
                    reservation.GuestId = txtGuest.SelectedValue.ToString();
                    reservation.Guest = _guestController.GetGuestById(reservation.GuestId);

                    reservation.RoomId = txtRoom.SelectedValue.ToString();
                    reservation.Room = _roomController.GetRealRoom(reservation.RoomId);

                    reservation.CheckInDate = txtCheckIn.Value;
                    DateTime selectedDate = txtCheckOut.Value;
                    reservation.CheckOutDate = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 12, 0, 0);

                    reservation.PaymentMethod = txtPaymentMethod.Text;
                    reservation.Amount = FormHelper.GetPriceByRateAndTime(reservation.CheckInDate, reservation.CheckOutDate, reservation.Room.Rate);
                    reservation.AmountPaid = decimal.Parse(txtAmountPaid.Text);

                    reservation.IsTrashed = false;
                    reservation.DateCreated = DateTime.Now;
                    reservation.DateModified = DateTime.Now;

                    if (reservation.Amount > reservation.AmountPaid)
                    {
                        reservation.Status = "Balance";
                    }
                    else
                    {
                        reservation.Status = "Paid";
                    }

                    reservation.CreatedBy = AuthSession.CurrentUser.Id;
                    reservation.ApplicationUser = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);

                    //Room room = _roomController.GetRealRoom(reservation.RoomId);
                    //room.Status = RoomStatusEnum.Reserved.ToString();
                    //room.DateModified = DateTime.Now;
                    var foundReservation = _db.Reservations.FirstOrDefault(r => r.RoomId == txtRoom.SelectedValue.ToString() && (r.CheckInDate.Month + r.CheckInDate.Day) == (txtCheckIn.Value.Month + txtCheckIn.Value.Day) && (r.CheckOutDate.Month + r.CheckOutDate.Day) == (txtCheckIn.Value.Month + txtCheckIn.Value.Day));
                    if(foundReservation != null)
                    {
                        MessageBox.Show($"A reservation has already been made for {reservation.Room.RoomNo} with the selected date", "Invalid Date", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    }
                    else
                    {
                        _reservationController.AddReservation(reservation);
                    }

                    //_roomController.UpdateRoom(room);

                    if (reservation.Amount == reservation.AmountPaid)
                    {
                        Domain.Entities.Transaction transaction = new Domain.Entities.Transaction()
                        {
                            Id = Guid.NewGuid().ToString(),
                            TransactionId = "TR" + random.Next(1000, 5000),
                            GuestId = reservation.GuestId,
                            Guest = reservation.Guest,
                            ServiceId = reservation.ReservationId,
                            Date = DateTime.Now,
                            Amount = reservation.AmountPaid,
                            Type = "Room Service",
                            Description = "Reservation",
                            Status = "Paid"
                        };

                        _transactionController.AddTransaction(transaction);
                    }
                    else if (reservation.Amount > reservation.AmountPaid)
                    {
                        Domain.Entities.Transaction paidTransaction = new Domain.Entities.Transaction()
                        {
                            Id = Guid.NewGuid().ToString(),
                            TransactionId = "TR" + random.Next(1000, 5000),
                            GuestId = reservation.GuestId,
                            Guest = reservation.Guest,
                            ServiceId = reservation.ReservationId,
                            Date = DateTime.Now,
                            Amount = reservation.AmountPaid,
                            Type = "Room Service",
                            Description = "Reservation",
                            Status = "Paid"
                        };

                        if (bankAccounts.SelectedItem != null)
                        {
                            paidTransaction.BankAccount = bankAccounts.SelectedItem.ToString();
                        }

                        _transactionController.AddTransaction(paidTransaction);

                        Domain.Entities.Transaction unPaidTransaction = new Domain.Entities.Transaction()
                        {
                            Id = Guid.NewGuid().ToString(),
                            TransactionId = "TR" + random.Next(1000, 5000),
                            GuestId = reservation.GuestId,
                            Guest = reservation.Guest,
                            ServiceId = reservation.ReservationId,
                            Date = DateTime.Now,
                            Amount = reservation.Amount - reservation.AmountPaid,
                            Type = "Room Service",
                            Description = "Reservation",
                            Status = "Un Paid"
                        };
                        _transactionController.AddTransaction(unPaidTransaction);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(textBox2.Text);
            if (isNull == false)
            {
                int numberOfDays = int.Parse(textBox2.Text);
                txtCheckOut.Value = txtCheckIn.Value.AddDays(numberOfDays);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtAmountPaid.Text);
            if (!isNull)
            {
                txtAmountPaid.Text = FormHelper.FormatNumberWithCommas(decimal.Parse(txtAmountPaid.Text));
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
