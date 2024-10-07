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

namespace ESMART_HMS.Presentation.Forms.booking
{
    public partial class bookingForm : Form
    {
        private readonly GuestController _guestController;
        private bool _continueRunning = true;

        private readonly RoomController _roomController;
        private readonly ReservationController _reservationController;
        private readonly ConfigurationController _configurationController;
        private readonly bookingController _bookingController;
        private readonly TransactionController _transactionController;
        private readonly ApplicationUserController _applicationUserController;
        private readonly CardController _cardController;
        private readonly SystemSetupController _systemSetupController;
        int st = 0;

        public bookingForm(bookingController bookingController, GuestController guestController, RoomController roomController, ReservationController reservationController, ConfigurationController configurationController, TransactionController transactionController, ApplicationUserController applicationUserController, CardController cardController, SystemSetupController systemSetupController)
        {
            _guestController = guestController;
            _roomController = roomController;
            _reservationController = reservationController;
            _configurationController = configurationController;
            _bookingController = bookingController;
            _transactionController = transactionController;
            _applicationUserController = applicationUserController;
            _cardController = cardController;
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ApplyAuthorization();
            _systemSetupController = systemSetupController;
        }

        private void ApplyAuthorization()
        {
            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
        }

        private void bookingForm_Load(object sender, System.EventArgs e)
        {
            LoadbookingsData();
            this.bookingTableAdapter.Fill(this.eSMART_HMSDBDataSet.booking);

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

                            if (realRoomNo == room.RoomNo)
                            {
                                room.Status = RoomStatusEnum.Vacant.ToString();

                                if (guestCard != null)
                                {
                                    _cardController.DeleteGuestCard(guestCard.Id);
                                }
                                _roomController.UpdateRoom(room);
                                _bookingController.Deletebooking(booking);
                                StringBuilder card_snr2 = new StringBuilder();
                                st = LockSDKHeaders.TP_CancelCard(card_snr2);
                                if (st == 1)
                                {
                                    MessageBox.Show("Successfully checkout card", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                LoadbookingsData();

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
    }
}
