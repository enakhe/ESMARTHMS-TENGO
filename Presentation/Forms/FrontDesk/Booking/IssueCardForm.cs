using ESMART_HMS.Application.LockSDK;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Sessions;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ESMART_HMS.Presentation.Forms.FrontDesk.booking
{
    public partial class IssueCardForm : Form
    {
        private readonly string _id;
        string computerName = Environment.MachineName;
        private DispatcherTimer dispatcherTimer;
        private readonly bookingController _bookingController;
        private readonly CardController _cardController;
        private readonly ApplicationUserController _userController;

        public IssueCardForm(bookingController bookingController, string id, CardController cardController, ApplicationUserController userController)
        {
            _bookingController = bookingController;
            _id = id;
            _cardController = cardController;
            InitializeComponent();
            InitializeTimer();
            _userController = userController;
        }
        int st = 0;

        private void IssueCardForm_Load(object sender, EventArgs e)
        {
            LoadData();
            dispatcherTimer.Start();
            Int16 locktype = 5;
            int checkEncoder = LockSDKMethods.CheckEncoder(locktype);
            if (checkEncoder != 1)
            {
                LockSDKMethods.CheckErr(checkEncoder);
            }

            int openPort = OpenPort(5);
            if (openPort != 1)
            {
                LockSDKMethods.CheckErr(openPort);
            }

            StringBuilder authCard = GetAuthCardFromDB();
            string fnp = "1011899778569788";
            StringBuilder clientData = authCard;

            int systemIni = LockSDKMethods.SystemInitialization(fnp, clientData);
            if (systemIni != 1)
            {
                LockSDKMethods.CheckErr(systemIni);
                return;
            }
        }

        private void LoadData()
        {
            BookingViewModel booking = _bookingController.GetAllbookings().FirstOrDefault(b => b.Id == _id);
            if (booking != null)
            {
                txtRoom.Text = "1.1." + booking.Room;
                txtGuest.Text = booking.Guest;
                txtInTime.Text = booking.CheckInDate.ToString();
                txtOutTime.Text = booking.CheckOutDate.ToString();

                List<IssueCardViewModel> issueCard = _bookingController.IssueCard(booking.Id);
                if (issueCard != null)
                {
                    foreach (var bookings in issueCard)
                    {
                        FormHelper.TryConvertStringToDecimal(booking.TotalAmount, out decimal amount);

                        bookings.Amount = FormHelper.FormatNumberWithCommas(amount);
                    }
                    dgvIssueCard.DataSource = issueCard;
                }
            }
        }

        // Initialize the timer
        private void InitializeTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1); // Set interval to 1 second
            dispatcherTimer.Tick += DispatcherTimer_Tick;
        }

        private int SelectDoorLockType(int doorType)
        {
            st = LockSDKHeaders.LS_SelectDoorLockType(doorType);
            return st;
        }

        private int OpenPort(int port)
        {
            st = LockSDKHeaders.LS_OpenPort(port);
            return st;
        }

        public int CheckEncoder()
        {
            Int16 locktype = 5;
            st = LockSDKHeaders.TP_Configuration(locktype);
            return st;
        }

        public StringBuilder GetAuthCardFromDB()
        {
            Domain.Entities.AuthorizationCard AuthCard = _cardController.GetAuthCardByComputer(computerName);
            if (AuthCard != null)
            {
                return new StringBuilder(AuthCard.AuthId);
            }
            return null;
        }

        private void LoadCardDetails()
        {
            char[] card_snr = new char[100];

            int st = LockSDKMethods.ReadCard(card_snr);
            if (st != (int)ERROR_TYPE.OPR_OK)
            {
                txtStatus.Text = "No Found Card";
                txtStatus.ForeColor = Color.Red;

                txtCardNo.Text = "";
                txtCardTypeTwo.Text = "";
                txtLockNo.Text = "";
                txtRoomNo.Text = "";
            }
            else
            {
                Domain.Entities.Booking selectedbooking = _bookingController.GetbookingById(_id);

                txtStatus.Text = "Card Found";
                txtStatus.ForeColor = Color.Green;
                txtCardTypeTwo.ForeColor = Color.Blue;

                CARD_INFO cardInfo = new CARD_INFO();
                byte[] cbuf = new byte[10000];
                cardInfo = new CARD_INFO();
                int result = LockSDKHeaders.LS_GetCardInformation(ref cardInfo, 0, 0, IntPtr.Zero);

                if (result == (int)ERROR_TYPE.OPR_OK)
                {
                    var roomNo = FormHelper.ByteArrayToString(cardInfo.RoomList);
                    bool isNull = FormHelper.AreAnyNullOrEmpty(roomNo);

                    if (isNull)
                    {
                        txtStatus.Text = "Empty Card";
                        txtStatus.ForeColor = Color.Red;

                        txtCardNo.Text = "";
                        txtCardTypeTwo.Text = "";
                        txtLockNo.Text = "";
                        txtRoomNo.Text = "";
                    }
                    else
                    {
                        MakeCardType cardType = FormHelper.GetCardType(cardInfo.CardType);

                        txtRoomNo.Text = selectedbooking.Room.RoomNo;
                        txtCardNo.Text = FormHelper.ByteArrayToString(cardInfo.CardNo);
                        txtCardTypeTwo.Text = FormHelper.FormatEnumName(cardType);
                        txtLockNo.Text = $"1.1.{selectedbooking.Room.RoomNo}";
                    }
                }
            }
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            LoadCardDetails();
        }

        private void btnRecycle_Click(object sender, EventArgs e)
        {
            StringBuilder card_snr = new StringBuilder();
            st = LockSDKHeaders.TP_CancelCard(card_snr);
            if (st == 1)
            {
                MessageBox.Show("Successfully recycled card", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCardDetails();
            }
        }

        private void btnIssueCard_Click(object sender, EventArgs e)
        {
            //Issue card
            char[] card_snr = new char[100];
            Domain.Entities.Booking booking = _bookingController.GetbookingById(_id);

            string roomno = $"{booking.Room.Building.BuildingNo}.{booking.Room.Floor.FloorNo}.{booking.Room.RoomNo}";
            string intime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            String outtime = txtOutTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            short iflags = 80;

            if (LockSDKHeaders.PreparedIssue(card_snr) == false)
                return;
            st = LockSDKMethods.MakeGuestCard(card_snr, roomno, booking.Room.Area.AreaNo, booking.Room.Floor.FloorNo, intime, outtime, iflags);

            if (st == (int)ERROR_TYPE.OPR_OK)
            {
                CARD_INFO cardInfo = new CARD_INFO();
                byte[] cbuf = new byte[10000];
                cardInfo = new CARD_INFO();
                int result = LockSDKHeaders.LS_GetCardInformation(ref cardInfo, 0, 0, IntPtr.Zero);

                string cardNoString = FormHelper.ByteArrayToString(cardInfo.CardNo);
                MakeCardType cardType = FormHelper.GetCardType(cardInfo.CardType);

                GuestCard guestCard = new GuestCard()
                {
                    Id = booking.Id,
                    CardNo = cardNoString,
                    CardType = FormHelper.FormatEnumName(cardType),
                    IssueTime = DateTime.Now,
                    RefundTime = DateTime.Now,
                    IssuedBy = AuthSession.CurrentUser.Id,
                    ApplicationUser = _userController.GetApplicationUserById(AuthSession.CurrentUser.Id),
                    CanOpenDeadLocks = true,
                    PassageMode = false,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                };
                _cardController.AddGuestCard(guestCard);
                this.DialogResult = DialogResult.OK;
                this.Close();

                MessageBox.Show("Successfully issued card", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCardDetails();
            }
            else if (st == (int)ERROR_TYPE.PORT_IN_USED)
            {
                MessageBox.Show("Failed to issue card: Port is already in use.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Failed to issue card, error code: {st}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
