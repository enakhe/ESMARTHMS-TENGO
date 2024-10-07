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
        private readonly SystemSetupController _sytemSetupController;

        public IssueCardForm(bookingController bookingController, string id, CardController cardController, ApplicationUserController userController, SystemSetupController systemSetupController)
        {
            _bookingController = bookingController;
            _id = id;
            _cardController = cardController;
            InitializeComponent();
            InitializeTimer();
            _userController = userController;
            _sytemSetupController = systemSetupController;
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

        private void InitializeTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
        }


        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {

        }

        private void btnRecycle_Click(object sender, EventArgs e)
        {
            StringBuilder card_snr = new StringBuilder();
            st = LockSDKHeaders.TP_CancelCard(card_snr);
            if (st == 1)
            {
                MessageBox.Show("Successfully recycled card", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnIssueCard_Click(object sender, EventArgs e)
        {
            //Issue card
            char[] card_snr = new char[100];
            Domain.Entities.Booking booking = _bookingController.GetbookingById(_id);

            string roomno = $"{booking.Room.Building.BuildingNo}.{booking.Room.Floor.FloorNo}.{booking.Room.RoomNo}";

            string intime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            String outtime = txtOutTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            CARD_FLAGS iflags = CARD_FLAGS.CF_CHECK_TIMESTAMP;

            if (LockSDKHeaders.PreparedIssue(card_snr) == false)
                return;
            st = LockSDKMethods.MakeGuestCard(card_snr, roomno, booking.Room.Area.AreaNo, "", intime, outtime, iflags);

            if (st == (int)ERROR_TYPE.OPR_OK)
            {
                CARD_INFO cardInfo = new CARD_INFO();
                byte[] cbuf = new byte[10000];
                cardInfo = new CARD_INFO();
                int result = LockSDKHeaders.LS_GetCardInformation(ref cardInfo, 0, 0, IntPtr.Zero);
                CompanyInformation foundCompany = _sytemSetupController.GetCompanyInfo();

                string cardNoString = FormHelper.ByteArrayToString(cardInfo.CardNo);
                MakeCardType cardType = FormHelper.GetCardType(cardInfo.CardType);

                GuestCard guestCard = new GuestCard()
                {
                    Id = booking.Id,
                    CardNo = cardNoString,
                    CardType = FormHelper.FormatEnumName(cardType),
                    IssueTime = DateTime.Now,
                    RefundTime = txtOutTime.Value,
                    IssuedBy = AuthSession.CurrentUser.Id,
                    ApplicationUser = _userController.GetApplicationUserById(AuthSession.CurrentUser.Id),
                    CanOpenDeadLocks = true,
                    PassageMode = false,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                };
                _cardController.AddGuestCard(guestCard);
                string guestCardString = $"Id = {guestCard.Id}\n" +
                         $"Card No = {guestCard.CardNo}\n" +
                         $"Card Type = {guestCard.CardType}\n" +
                         $"Issue Time = {guestCard.IssueTime}\n" +
                         $"Refund Time = {guestCard.RefundTime}\n" +
                         $"Issued By = {guestCard.IssuedBy}\n" +
                         $"Application User = {guestCard.ApplicationUser?.FullName}\n" +
                         $"Date Created = {guestCard.DateCreated}\n" +
                         $"Date Modified = {guestCard.DateModified}";

                if (foundCompany != null)
                {
                    if (foundCompany.Email != null)
                    {
                        await EmailHelper.SendEmail(foundCompany.Email, "Booking Card Created", guestCardString);
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();

                MessageBox.Show("Successfully issued card", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
