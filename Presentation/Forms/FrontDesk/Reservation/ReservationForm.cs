using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Forms.booking;
using ESMART_HMS.Presentation.Forms.Rooms;
using ESMART_HMS.Presentation.Middleware;
using ESMART_HMS.Presentation.Sessions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;
using ESMART_HMS.Domain.Enum;

namespace ESMART_HMS.Presentation.Forms.Reservation
{
    public partial class ReservationForm : Form
    {
        private bool _continueRunning = true;

        private readonly ReservationController _reservationController;
        private readonly GuestController _guestController;
        private readonly RoomController _roomController;
        private readonly ConfigurationController _configurationController;
        private readonly bookingController _bookingController;
        private readonly TransactionController _transactionController;
        private readonly ApplicationUserController _applicationUserController;
        private readonly SystemSetupController _systemSetupController;
        public ReservationForm(ReservationController reservationController, GuestController guestController, RoomController roomController, ConfigurationController configurationController, bookingController bookingController, TransactionController transactionController, ApplicationUserController applicationUserController, SystemSetupController systemSetupController)
        {
            _reservationController = reservationController;
            _guestController = guestController;
            _roomController = roomController;
            _configurationController = configurationController;
            _bookingController = bookingController;
            _transactionController = transactionController;
            _applicationUserController = applicationUserController;
            _systemSetupController = systemSetupController;
            InitializeComponent();
            ApplyAuthorization();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Activated += ReservationForm_Activated;
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            LoadData();
            splitContainer19.SplitterWidth = 1;
            splitContainer19.BackColor = splitContainer19.Panel1.BackColor;
            dgvReservation.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvReservation.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
        }

        private void ApplyAuthorization()
        {
            List<string> roles = new List<string> { "Admin", "SuperAdmin", "Manager" };
            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
            AuthorizationMiddleware.ProtectControl(user, btnDelete, roles);
        }

        private void LoadData()
        {
            //try
            //{
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
                    txtReservationCount.Text = allReservations.Count.ToString();
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
            //                MessageBoxIcon.Error);
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
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

        private void btnBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReservation.SelectedRows.Count > 0)
                {
                    var row = dgvReservation.SelectedRows[0];
                    string reservationId = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();
                    string roomId = row.Cells["roomIdDataGridViewTextBoxColumn"].Value.ToString();
                    string guestId = row.Cells["GuestId"].Value.ToString();

                    AddbookingForm addbookingForm = new AddbookingForm(reservationId, guestId, roomId, _guestController, _roomController, _reservationController, _configurationController, _bookingController, _transactionController, _applicationUserController, _systemSetupController);
                    if (addbookingForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a reservation to book.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReservation.SelectedRows.Count > 0)
                {
                    CompanyInformation foundCompany = _systemSetupController.GetCompanyInfo();

                    var result = MessageBox.Show("Are you sure you want to add the selected reservation to the recycle?\nIts record including all entries tagged to such reservation will be added to the recycle bin as well.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvReservation.SelectedRows)
                        {
                            string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();
                            var reservation = _reservationController.GetReservationById(id);
                            var room = _roomController.GetRealRoom(reservation.Room.Id);
                            room.Status = RoomStatusEnum.Vacant.ToString();
                            _roomController.UpdateRoom(room);
                            _reservationController.DeleteReservation(id);

                            string reservationString = $"Id = {reservation.Id}\n" +
     $"Reservation Id = {reservation.ReservationId}\n" +
     $"Guest = {reservation.Guest.FullName}\n" +
     $"Room = {reservation.Room.RoomNo}\n" +
     $"Check-In Date = {reservation.CheckInDate.ToString("yyyy-MM-dd HH:mm:ss")}\n" +
     $"Check-Out Date = {reservation.CheckOutDate.ToString("yyyy-MM-dd HH:mm:ss")}\n" +
     $"Payment Method = {reservation.PaymentMethod}\n" +
     $"Amount = {reservation.Amount}\n" +
     $"Status = {reservation.Status}\n" +
     $"Created By = {reservation.ApplicationUser.FullName}\n" +
     $"Date Created = {reservation.DateCreated.ToString("yyyy-MM-dd HH:mm:ss")}\n" +
     $"Date Modified = {reservation.DateModified.ToString("yyyy-MM-dd HH:mm:ss")}\n" +
     $"Is Trashed = {reservation.IsTrashed}\n" +
     $"Amount Paid = {reservation.AmountPaid}";

                            if (foundCompany != null)
                            {
                                if (foundCompany.Email != null)
                                {
                                    await EmailHelper.SendEmail(foundCompany.Email, "Reservation Recycled", reservationString);
                                }
                            }
                        }
                        LoadData();
                        MessageBox.Show("Successfully added reservation information to recycle", "Success", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a reservation to recycle.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ReservationForm_Activated(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
