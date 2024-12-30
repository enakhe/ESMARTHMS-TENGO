using ESMART_HMS.Application.LockSDK;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Forms.FrontDesk.booking;
using ESMART_HMS.Presentation.Sessions;
using System.Threading.Tasks;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ESMART_HMS.Presentation.Middleware;
using ESMART_HMS.Presentation.Forms.FrontDesk.Booking;
using DocumentFormat.OpenXml.Wordprocessing;
using ESMART_HMS.Presentation.Forms.Rooms;
using ESMART_HMS.Presentation.Controllers.Bar;
using System.Drawing.Printing;
using System.Drawing;

namespace ESMART_HMS.Presentation.Forms.booking
{
    public partial class bookingForm : Form
    {
        private readonly GuestController _guestController;

        private readonly RoomController _roomController;
        private readonly RoomTypeController _roomTypeController;
        private readonly ReservationController _reservationController;
        private readonly ConfigurationController _configurationController;
        private readonly bookingController _bookingController;
        private readonly TransactionController _transactionController;
        private readonly ApplicationUserController _applicationUserController;
        private readonly CardController _cardController;
        private readonly SystemSetupController _systemSetupController;
        int st = 0;
        public List<Domain.Entities.Booking> BookingDetails = new List<Domain.Entities.Booking>();

        public bookingForm(bookingController bookingController, GuestController guestController, RoomController roomController, ReservationController reservationController, ConfigurationController configurationController, TransactionController transactionController, ApplicationUserController applicationUserController, CardController cardController, SystemSetupController systemSetupController, RoomTypeController roomTypeController)
        {
            _guestController = guestController;
            _roomController = roomController;
            _reservationController = reservationController;
            _configurationController = configurationController;
            _bookingController = bookingController;
            _transactionController = transactionController;
            _applicationUserController = applicationUserController;
            _cardController = cardController;
            _systemSetupController = systemSetupController;
            _roomTypeController = roomTypeController;
            _systemSetupController = systemSetupController;
            InitializeComponent();
            ApplyAuthorization();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Activated += BookingForm_Activated;
        }


        private void ApplyAuthorization()
        {
            List<string> roles = new List<string> { "Admin", "SuperAdmin", "Manager" };
            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
            AuthorizationMiddleware.ProtectControl(user, btnDelete, roles);
        }

        private void bookingForm_Load(object sender, System.EventArgs e)
        {
            LoadbookingsData();
            LoadRoomType();
            dgvbooking.SelectionChanged += DataGridView1_SelectionChanged;
            splitContainer21.BackColor = splitContainer21.Panel1.BackColor;
            splitContainer21.SplitterWidth = 1;
            splitContainer21.BackColor = splitContainer21.Panel1.BackColor;
            dgvbooking.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvbooking.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
        }

        private void LoadbookingsData()
        {
            List<BookingViewModel> allbookings = _bookingController.GetAllbookings();
            if (allbookings != null)
            {
                foreach (var booking in allbookings)
                {
                    booking.TotalAmount = FormHelper.FormatNumberWithCommas(decimal.Parse(booking.TotalAmount));
                }
                dgvbooking.DataSource = allbookings;
                txtCount.Text = allbookings.Count.ToString();
            }
        }

        private void LoadRoomType()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(LoadRoomType));
                return;
            }
            var allRoomTypes = new List<RoomTypeViewModel>();
            var roomTypes = _roomTypeController.GetAllRoomType();

            if (roomTypes != null)
            {
                RoomTypeViewModel all = new RoomTypeViewModel()
                {
                    Id = "ALL",
                    RoomTypeId = "ALL",
                    Title = "ALL",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                };
                allRoomTypes.Add(all);

                foreach (var roomType in roomTypes)
                {
                    allRoomTypes.Add(roomType);
                }

                txtRoomType.DataSource = allRoomTypes;
            }

        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvbooking.SelectedRows.Count > 0)
                {
                    var row = dgvbooking.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                    GuestCard guestCard = _cardController.GetGuestCard(id);
                    if (guestCard != null)
                    {
                        btnBook.Enabled = false;
                    }
                    else
                    {
                        btnBook.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddbookingForm addbookingForm = new AddbookingForm("0", "0", "0", _guestController, _roomController, _reservationController, _configurationController, _bookingController, _transactionController, _applicationUserController, _systemSetupController);
            if (addbookingForm.ShowDialog() == DialogResult.OK)
            {
                LoadbookingsData();
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvbooking.SelectedRows.Count > 0)
                {
                    var row = dgvbooking.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();
                    char[] card_snr = new char[100];
                    int st = LockSDKMethods.ReadCard(card_snr);
                    Domain.Entities.Booking booking = _bookingController.GetbookingById(id);
                    Domain.Entities.Room room = _roomController.GetRealRoom(booking.RoomId);
                    GuestCard guestCard = _cardController.GetGuestCard(booking.Id);
                    room.Status = RoomStatusEnum.Vacant.ToString();

                    if (guestCard != null)
                    {
                        _cardController.DeleteGuestCard(guestCard.Id);
                    }
                    _roomController.UpdateRoom(room);
                    _bookingController.Deletebooking(booking);
                     MessageBox.Show("Successfully checkout card", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StringBuilder card_snr2 = new StringBuilder();
                    st = LockSDKHeaders.TP_CancelCard(card_snr2);
                    if (st == 1)
                    {
                    }
                    LoadbookingsData();

                    if (st != (int)ERROR_TYPE.OPR_OK)
                    {
                        MessageBox.Show("Please place card", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        CARD_INFO cardInfo = new CARD_INFO();
                        byte[] cbuf = new byte[10000];
                        cardInfo = new CARD_INFO();
                        int result = LockSDKHeaders.LS_GetCardInformation(ref cardInfo, 0, 0, IntPtr.Zero);
                        if (result == (int)ERROR_TYPE.OPR_OK)
                        {
                            var cardInfoRoom = FormHelper.ByteArrayToString(cardInfo.RoomList);
                            string[] parts = cardInfoRoom.Split('.');
                            var roomno = parts[parts.Length - 1];
                            string realRoomNo = roomno.Substring(roomno.Length - 4);

                            if (realRoomNo.Contains(room.RoomNo))
                            {


                            }
                            else
                            {
                                MessageBox.Show("Invalid room card", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Please select a booking to checkout.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvbooking.SelectedRows.Count > 0)
                {
                    var row = dgvbooking.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                    using (IssueCardForm issueCardForm = new IssueCardForm(_bookingController, id, _cardController, _applicationUserController, _systemSetupController))
                    {
                        if (issueCardForm.ShowDialog() == DialogResult.OK)
                        {

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a booking to isue card.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtSearch.Text);
            if (isNull == false)
            {
                var searchBooking = _bookingController.SearchBooking(txtSearch.Text);
                if (searchBooking != null)
                {
                    foreach (var booking in searchBooking)
                    {
                        booking.TotalAmount = FormHelper.FormatNumberWithCommas(decimal.Parse(booking.TotalAmount));
                    }
                    dgvbooking.DataSource = searchBooking;
                }
            }
            else
            {
                LoadbookingsData();
            }
        }

        private void txtRoomType_SelectedValueChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtRoomType.Text);
            if (isNull == false)
            {
                if (txtRoomType.Text == "ALL")
                {
                    LoadbookingsData();
                }
                else
                {
                    var searchBooking = _bookingController.SearchBooking(txtRoomType.Text);
                    if (searchBooking != null)
                    {
                        foreach (var booking in searchBooking)
                        {
                            booking.TotalAmount = FormHelper.FormatNumberWithCommas(decimal.Parse(booking.TotalAmount));
                            booking.DateCreated = FormHelper.FormatDateTimeWithSuffix(booking.DateCreated);
                            booking.DateModified = FormHelper.FormatDateTimeWithSuffix(booking.DateModified);
                        }
                        dgvbooking.DataSource = searchBooking;
                    }
                }
            }
            else
            {
                LoadbookingsData();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvbooking.SelectedRows.Count > 0)
                {
                    CompanyInformation foundCompany = _systemSetupController.GetCompanyInfo();

                    var result = MessageBox.Show("Are you sure you want to add the selected booking to the recycle?\nIts record including all entries tagged to such booking will be added to the recycle bin as well.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvbooking.SelectedRows)
                        {
                            string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();
                            var booking = _bookingController.GetbookingById(id);
                            _bookingController.Deletebooking(booking);
                            string bookingString = $"Id = {booking.Id}\n" +
     $"Reservation Id = {booking.ReservationId}\n" +
     $"Guest = {booking.Guest.FullName}\n" +
     $"Room = {booking.Room.RoomNo}\n" +
     $"Check-In Date = {booking.CheckInDate.ToString("yyyy-MM-dd HH:mm:ss")}\n" +
     $"Check-Out Date = {booking.CheckOutDate.ToString("yyyy-MM-dd HH:mm:ss")}\n" +
     $"Payment Method = {booking.PaymentMethod}\n" +
     $"Amount = {booking.Amount}\n" +
     $"Status = {booking.Room.Status}\n" +
     $"Created By = {booking.ApplicationUser.FullName}\n" +
     $"Date Created = {booking.DateCreated.ToString("yyyy-MM-dd HH:mm:ss")}\n" +
     $"Date Modified = {booking.DateModified.ToString("yyyy-MM-dd HH:mm:ss")}\n" +
     $"Is Trashed = {booking.IsTrashed}\n" +
     $"Amount Paid = {booking.TotalAmount}";

                            if (foundCompany != null)
                            {
                                if (foundCompany.Email != null)
                                {
                                    await EmailHelper.SendEmail(foundCompany.Email, "Booking Recycled", bookingString);
                                }
                            }
                        }
                        LoadbookingsData();
                        MessageBox.Show("Successfully added booking information to recycle", "Success", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a booking to recycle.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvbooking.SelectedRows.Count > 0)
                {
                    var row = dgvbooking.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                    using (EditBookingForm editBookingForm = new EditBookingForm(id, _bookingController, _guestController, _roomController, "0", "0", _configurationController, _systemSetupController))
                    {
                        if (editBookingForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadbookingsData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a room to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadbookingsData();
            LoadRoomType();
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvbooking.SelectedRows.Count > 0)
                {
                    var row = dgvbooking.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();
                    var booking = _bookingController.GetbookingById(id);
                    var transaction = _transactionController.GetByServiceIdAndStatus(booking.BookingId, "Un Paid");
                    transaction.Status = "Paid";
                    _transactionController.UpdateTransaction(transaction);
                    MessageBox.Show("Please print new receipt", "Successfully Changed to Paid", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    MessageBox.Show("Please select an order to change state.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public void PrintReceipt(List<Domain.Entities.Booking> BookingDetails)
        {
            this.BookingDetails = BookingDetails;

            PrintDocument printDocument = new PrintDocument();
            PrintDialog printDialog = new PrintDialog
            {
                Document = printDocument
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.PrintPage += PrintDocument_PrintPage;
                printDocument.PrinterSettings = printDialog.PrinterSettings;
                printDocument.Print();
            }
        }

        public CompanyInformation GetHotelName()
        {
            CompanyInformation companyInformation = _systemSetupController.GetCompanyInfo();
            if (companyInformation != null)
            {
                return companyInformation;
            }

            return null;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            System.Drawing.Font headerFont = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            System.Drawing.Font subHeaderFont = new System.Drawing.Font("Arial", 9, FontStyle.Bold);
            System.Drawing.Font regularFont = new System.Drawing.Font("Arial", 9);
            System.Drawing.Font smallFont = new System.Drawing.Font("Arial", 7);
            int startX = 5;
            int startY = 5;
            int offsetY = 10;

            string hotelName = "";
            string otherInfo = "";
            CompanyInformation hotelInformation = GetHotelName();


            if (hotelInformation != null)
            {
                hotelName = $"{hotelInformation.Name}";
                otherInfo = $"{hotelInformation.AddressLine1}\n{hotelInformation.PhoneNumber}";
            }

            // Logo
            graphics.DrawString(hotelName, headerFont, Brushes.Blue, startX, startY);
            graphics.DrawString(otherInfo, smallFont, Brushes.Blue, startX, startY + offsetY + 10);
            offsetY += 40;

            string issuedBy = BookingDetails[0].ApplicationUser.FullName;
            string sellerDetails = $"Issued By\n{issuedBy}";
            graphics.DrawString(sellerDetails, smallFont, Brushes.Black, startX, startY + offsetY + 20);
            offsetY += 50;

            graphics.DrawString("Client's Details", subHeaderFont, Brushes.Black, startX, startY + offsetY);
            offsetY += 20;
            string buyerDetails = BookingDetails[0].Guest.FullName;
            graphics.DrawString(buyerDetails, smallFont, Brushes.Black, startX, startY + offsetY);
            offsetY += 30;


            // Receipt and Date Details
            graphics.DrawString($"Receipt No: {BookingDetails[0].BookingId}", subHeaderFont, Brushes.Black, startX, startY + offsetY);
            offsetY += 20;
            graphics.DrawString($"Receipt Date: {DateTime.Now.ToString("MMM dd, yyyy")}", subHeaderFont, Brushes.Black, startX, startY + offsetY);
            offsetY += 40;

            // Table Headers
            graphics.DrawString("Room", smallFont, Brushes.Black, startX, startY + offsetY);
            graphics.DrawString("Rate", smallFont, Brushes.Black, startX + 160, startY + offsetY);
            graphics.DrawString("Subtotal", smallFont, Brushes.Black, startX + 220, startY + offsetY);
            offsetY += 20;

            for (int i = 0; i < BookingDetails.Count; i++)
            {
                graphics.DrawString(BookingDetails[i].Room.RoomNo, smallFont, Brushes.Black, startX, startY + offsetY);
                graphics.DrawString(BookingDetails[i].Room.Rate.ToString(), smallFont, Brushes.Black, startX + 160, startY + offsetY);
                graphics.DrawString((BookingDetails[i].TotalAmount).ToString(), smallFont, Brushes.Black, startX + 220, startY + offsetY);
                offsetY += 20;
            }

            offsetY += 20;

            // Invoice Summary
            graphics.DrawString("Invoice Summary", subHeaderFont, Brushes.Black, startX, startY + offsetY);
            offsetY += 20;
            graphics.DrawString("Total:", regularFont, Brushes.Black, startX, startY + offsetY);
            graphics.DrawString($"N{FormHelper.FormatNumberWithCommas((decimal)BookingDetails[0].TotalAmount)}", regularFont, Brushes.Black, startX + 100, startY + offsetY);
            offsetY += 50;

            graphics.DrawString($"Thank you and have a great day", regularFont, Brushes.Black, startX + 90, startY + offsetY);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvbooking.SelectedRows.Count > 0)
                {
                    var row = dgvbooking.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();
                    var booking = _bookingController.GetbookingById(id);
                    BookingDetails.Add(booking);
                    PrintReceipt(BookingDetails);
                }
                else
                {
                    MessageBox.Show("Please select a booking to print receipt.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BookingForm_Activated(object sender, EventArgs e)
        {
            LoadbookingsData();
        }
    }
}
