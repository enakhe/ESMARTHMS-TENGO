using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Infrastructure.Frameworks.TengoLock;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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

        #region Declear DLL functions
        [DllImport(@"C:\Users\izuag\OneDrive\Desktop\Tengo\CSharpDemo\bin\x86\Debug\LockSDK.dll", EntryPoint = "TP_Configuration")]
        public static extern int TP_Configuration(Int16 LockType);

        [DllImport(@"C:\Users\izuag\OneDrive\Desktop\Tengo\CSharpDemo\bin\x86\Debug\LockSDK.dll", EntryPoint = "TP_MakeGuestCardEx")]
        public static extern int TP_MakeGuestCardEx(StringBuilder card_snr, string room_no, string checkin_time, string checkout_time, Int16 iflags);

        [DllImport(@"C:\Users\izuag\OneDrive\Desktop\Tengo\CSharpDemo\bin\x86\Debug\LockSDK.dll", EntryPoint = "TP_ReadGuestCard")]
        public static extern int TP_ReadGuestCard(StringBuilder card_snr, StringBuilder room_no, StringBuilder checkin_time, StringBuilder checkout_time);

        [DllImport(@"C:\Users\izuag\OneDrive\Desktop\Tengo\CSharpDemo\bin\x86\Debug\LockSDK.dll", EntryPoint = "TP_ReadGuestCardEx")]
        public static extern int TP_ReadGuestCardEx(StringBuilder card_snr, StringBuilder room_no, StringBuilder checkin_time, StringBuilder checkout_time, ref int iflags);

        [DllImport(@"C:\Users\izuag\OneDrive\Desktop\Tengo\CSharpDemo\bin\x86\Debug\LockSDK.dll", EntryPoint = "LS_MakeGuestCard_EX1")]
        public static extern int LS_MakeGuestCard_EX1(StringBuilder card_snr, string roomno, string areas,
            string floors, string intime, string outtime, short iflags);

        [DllImport(@"C:\Users\izuag\OneDrive\Desktop\Tengo\CSharpDemo\bin\x86\Debug\LockSDK.dll", EntryPoint = "TP_CancelCard")]
        public static extern int TP_CancelCard(StringBuilder card_snr);

        [DllImport(@"C:\Users\izuag\OneDrive\Desktop\Tengo\CSharpDemo\bin\x86\Debug\LockSDK.dll", EntryPoint = "TP_GetCardSnr")]
        public static extern int TP_GetCardSnr(StringBuilder card_snr);

        [DllImport(@"C:\Users\izuag\OneDrive\Desktop\Tengo\CSharpDemo\bin\x86\Debug\LockSDK.dll", EntryPoint = "LS_ReadRom")]
        public static extern int LS_ReadRom(StringBuilder card_snr);

        #endregion

        #region Public methods
        private void CheckErr(int iret)
        {
            switch (iret)
            {
                case 1:
                    MessageBox.Show("Card reader/writer found", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case -1:
                    MessageBox.Show("Sorry invalid card", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case -2:
                    MessageBox.Show("Sorry no detected card reader/writer", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case -3:
                    MessageBox.Show(Language.g_LoadString_Ex("IDS_STRING_ERROR_INVALIDCARD"), Language.g_LoadString_Ex("IDS_STRING_MSG"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case -4:
                    MessageBox.Show("Card type error", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case -5:
                    MessageBox.Show("Read/write error", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case -8:
                    MessageBox.Show("Invalid Parameter", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case -29:
                    MessageBox.Show("Unregistered decoder", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    MessageBox.Show("Sorry an error occured", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        /// <summary>
        /// Prepared to issue card
        /// </summary>
        /// <param name="card_snr">Return Card Code</param>
        /// <returns>Boolean</returns>
        public Boolean PreparedIssue(StringBuilder card_snr)
        {
            int st;
            st = LS_ReadRom(card_snr);
            int[] errors = { 1, 3, 4, 5 };
            if (st != 1)
            {
                CheckErr(st);
                return false;
            }
            return true;
        }
        #endregion

        #region Buttons 
        #endregion

        private void IssueCardForm_Load(object sender, EventArgs e)
        {
            var stResult = CheckEncoder();
            if (stResult == -2)
            {
                this.Close();
            }
            else
            {
                // LoadCardDetails();
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
            st = TP_Configuration(locktype);
            CheckErr(st);
            return st;
        }

        private void LoadCardDetails()
        {

            //Read card
            StringBuilder card_snr = new StringBuilder(100);
            StringBuilder lockno = new StringBuilder(100);
            StringBuilder intime = new StringBuilder(100);
            StringBuilder outtime = new StringBuilder(100);

            var card = LS_ReadRom(card_snr);

            if (card == 1)
            {
                int iflags = 0;
                st = TP_ReadGuestCardEx(card_snr, lockno, intime, outtime, ref iflags);
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
                    CheckErr(st);
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
            st = TP_CancelCard(card_snr);
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
            StringBuilder card_snr = new StringBuilder(100);

            string roomno = txtRoom.Text;
            string intime = txtInTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            String outtime = txtOutTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            short iflags = 136;

            if (PreparedIssue(card_snr) == false)
                return;
            st = LS_MakeGuestCard_EX1(card_snr, roomno, "001", "008.009", intime, outtime, iflags);

            if (st == 1)
            {
                MessageBox.Show("Successfully issued card", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCardDetails();
            }
        }
    }
}
