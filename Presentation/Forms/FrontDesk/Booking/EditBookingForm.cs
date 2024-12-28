using ESMART_HMS.Domain.Entities;
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.FrontDesk.Booking
{
    public partial class EditBookingForm : Form
    {
        private string _id;
        private string _roomId;
        private string _guestId;
        private readonly bookingController _bookingController;
        private readonly GuestController _guestController;
        private readonly RoomController _roomController;
        private readonly ConfigurationController _configurationController;
        private readonly SystemSetupController _systemSetupController;
        public EditBookingForm(string id, bookingController bookingController, GuestController guestController, RoomController roomController, string roomId, string guestId, ConfigurationController configurationController, SystemSetupController systemSetupController)
        {
            _id = id;
            _bookingController = bookingController;
            _guestController = guestController;
            _roomController = roomController;
            _roomId = roomId;
            _guestId = guestId;
            _configurationController = configurationController;
            _systemSetupController = systemSetupController;
            InitializeComponent();
            LoadGuest();
            LoadRoom();
            LoadMetric();
            LoadBankDetails();
            LoadData();
            LoadTotalAmount();
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

        private void LoadRoom()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(LoadRoom));
                return;
            }
            Domain.Entities.Room room = _roomController.GetRealRoom(_roomId);
            if (room != null)
            {
                List<Domain.Entities.Room> roomList = new List<Domain.Entities.Room>() { room };
                foreach (var roomm in roomList)
                {
                    roomm.RoomNo = $"{roomm.RoomNo} | {roomm.RoomType.Title}";
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
                        foreach (var roomm in allRooms)
                        {
                            roomm.RoomNo = $"{roomm.RoomNo} | {roomm.RoomType}";
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

        private void LoadData()
        {
            try
            {
                Domain.Entities.Booking boking = _bookingController.GetbookingById(_id);
                if (boking != null)
                {
                    txtGuest.Text = boking.Guest.FullName;
                    txtRoom.Text = boking.Room.RoomNo;
                    txtNoOfPerson.Text = boking.NoOfPerson.ToString();
                    noOfDays.Text = boking.Duration.ToString();
                    txtCheckIn.Value = boking.CheckInDate;
                    txtCheckOut.Value = boking.CheckOutDate;
                    txtDuration.Text = boking.Duration.ToString();
                    txtbookingAmount.Text = boking.Amount.ToString();
                    txtPaymentMethod.Text = boking.PaymentMethod.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
            MessageBoxIcon.Error);
            }
        }

        private void txtNoOfPerson_TextChanged(object sender, EventArgs e)
        {
            if (txtRoom.Text != null || txtRoom.Text != "")
            {
                Domain.Entities.Room room = _roomController.GetRealRoom(txtRoom.SelectedValue.ToString());
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

        private void noOfDays_TextChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(noOfDays.Text);
            if (isNull == false)
            {
                int numberOfDays = int.Parse(noOfDays.Text);
                txtCheckOut.Value = txtCheckIn.Value.AddDays(numberOfDays);
            }
        }

        private void txtCheckOut_ValueChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtCheckOut.Text, txtCheckIn.Text, txtRoom.SelectedValue.ToString());
            if (isNull == false)
            {
                Domain.Entities.Room room = _roomController.GetRealRoom(_roomId);

                if (room != null)
                {
                    txtbookingAmount.Text = (FormHelper.GetPriceByRateAndTime(DateTime.Parse(txtCheckIn.Text), DateTime.Parse(txtCheckOut.Text), room.Rate)).ToString();
                }
                else
                {
                    Domain.Entities.Room bookingRoom = _roomController.GetRealRoom(txtRoom.SelectedValue.ToString());
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

        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtTotalAmount.Text);
            if (isNull == false)
            {
                txtTotalAmount.Text = FormHelper.FormatNumberWithCommas(decimal.Parse(txtTotalAmount.Text));
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

        private void txtbookingAmount_TextChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtbookingAmount.Text);
            if (isNull == false)
            {
                txtbookingAmount.Text = FormHelper.FormatNumberWithCommas(decimal.Parse(txtbookingAmount.Text));
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

                Domain.Entities.Booking booking = _bookingController.GetbookingById(_id);

                Random random = new Random();
                booking.GuestId = txtGuest.SelectedValue.ToString();
                booking.Guest = _guestController.GetGuestById(txtGuest.SelectedValue.ToString());
                booking.RoomId = txtRoom.SelectedValue.ToString();
                booking.Room = _roomController.GetRealRoom(txtRoom.SelectedValue.ToString());
                booking.ReservationId = booking.ReservationId;
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

                _bookingController.UpdateBooking(booking);

                Domain.Entities.Room room = _roomController.GetRealRoom(txtRoom.SelectedValue.ToString());
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
