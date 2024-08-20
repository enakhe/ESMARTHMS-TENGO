using ESMART_HMS.Application.LockSDK;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Infrastructure.Frameworks.TengoLock;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ESMART_HMS.Presentation.Forms.FrontDesk.Booking
{
    public partial class IssueCardForm : Form
    {
        private readonly BookingController _bookingController;
        private readonly string _id;
        private DispatcherTimer dispatcherTimer;
        public IssueCardForm(BookingController bookingController, string id)
        {
            _bookingController = bookingController;
            _id = id;
            InitializeComponent();
            InitializeTimer();
        }
        int st = 0;

        private void IssueCardForm_Load(object sender, EventArgs e)
        {
            var stResult = CheckEncoder();
            if (stResult == -2)
            {
                this.Close();
            }
            else
            {
                LoadCardDetails();
                dispatcherTimer.Start();
                BookingViewModel booking = _bookingController.GetAllBookings().FirstOrDefault(b => b.Id == _id);
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
        }

        // Initialize the timer
        private void InitializeTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1); // Set interval to 1 second
            dispatcherTimer.Tick += DispatcherTimer_Tick;
        }

        public int CheckEncoder()
        {
            Int16 locktype = 5;
            st = LockSDKHeaders.LS_OpenPort(locktype);
            LockSDKHeaders.CheckErr(st);
            return st;
        }

        private void LoadCardDetails()
        {

            //Read card
            char[] card_snr = new char[100];
            StringBuilder lockno = new StringBuilder(100);
            StringBuilder intime = new StringBuilder(100);
            StringBuilder outtime = new StringBuilder(100);

            var card = LockSDKHeaders.LS_ReadRom(card_snr);

            if (card == 1)
            {
                int iflags = 0;
                st = LockSDKHeaders.LS_ReadGuestCard(card_snr, lockno, intime, outtime);
                if (st == 1)
                {
                    string[] parts = lockno.ToString().Split('.');
                    string roomNo = parts[parts.Length - 1];

                    txtCardNo.Text = card_snr.ToString();
                    txtLockNo.Text = lockno.ToString();
                    txtRoomNo.Text = roomNo;
                    txtClockIn.Text = intime.ToString();
                    txtClockOut.Text = outtime.ToString();

                    if (lockno.ToString() == "")
                    {
                        txtEmpty.Text = "Empty card";
                        txtEmpty.ForeColor = Color.Red;

                        txtClockIn.Text = "";
                        txtClockOut.Text = "";
                    }
                    else
                    {
                        txtEmpty.Text = "";
                        txtEmpty.ForeColor = Color.Transparent;
                    }
                    txtError.Text = "Card found";
                    txtError.ForeColor = Color.Green;
                }
                else
                {
                    LockSDKHeaders.CheckErr(st);
                }
            }
            else
            {
                txtCardNo.Text = "";
                txtLockNo.Text = "";
                txtRoomNo.Text = "";
                txtClockIn.Text = "";
                txtClockOut.Text = "";

                txtError.Text = "No card found";
                txtError.ForeColor = Color.Red;

                txtEmpty.Text = "";
                txtEmpty.ForeColor = Color.Transparent;
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

        private void IssueCardForm_Enter(object sender, EventArgs e)
        {
            LoadCardDetails();
        }

        private void btnIssueCard_Click(object sender, EventArgs e)
        {
            //Issue card
            char[] card_snr = new char[100];
            Domain.Entities.Booking booking = _bookingController.GetBookingById(_id);

            string roomno = txtRoom.Text;
            string intime = txtInTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            String outtime = txtOutTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            short iflags = 136;

            if (LockSDKHeaders.PreparedIssue(card_snr) == false)
                return;
            st = LockSDKHeaders.LS_MakeGuestCard_EX1(card_snr, roomno, booking.Room.Area.AreaNo, booking.Room.Floor.FloorNo, intime, outtime, iflags);

            if (st == 1)
            {
                MessageBox.Show("Successfully issued card", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCardDetails();
            }
        }
    }
}
