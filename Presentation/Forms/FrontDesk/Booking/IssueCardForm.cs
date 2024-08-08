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

namespace ESMART_HMS.Presentation.Forms.FrontDesk.Booking
{
    public partial class IssueCardForm : Form
    {
        private readonly BookingController _bookingController;
        private readonly string _id;
        public IssueCardForm(BookingController bookingController, string id)
        {
            _bookingController = bookingController;
            _id = id;
            InitializeComponent();
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
                    MessageBox.Show(Language.g_LoadString_Ex("IDS_STRING_ERROR_CARDTYPE"), Language.g_LoadString_Ex("IDS_STRING_MSG"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case -5:
                    MessageBox.Show(Language.g_LoadString_Ex("IDS_STRING_ERROR_READCARD"), Language.g_LoadString_Ex("IDS_STRING_MSG"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case -8:
                    MessageBox.Show(Language.g_LoadString_Ex("IDS_STRING_ERROR_INPUT"), Language.g_LoadString_Ex("IDS_STRING_MSG"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case -29:
                    MessageBox.Show(Language.g_LoadString_Ex("IDS_STRING_ERROR_REG"), Language.g_LoadString_Ex("IDS_STRING_MSG"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    MessageBox.Show(Language.g_LoadString_Ex("IDS_STRING_ERROR"), Language.g_LoadString_Ex("IDS_STRING_MSG"), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void IDD102_1011_Click(object sender, EventArgs e)
        {
            this.txtInTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void IDD102_1003_Click(object sender, EventArgs e)
        {
            //Issue card
            StringBuilder card_snr = new StringBuilder(100);
            string roomno = txtRoomNo.Text;
            string intime = txtInTime.Text;
            String outtime = txtOutTime.Text;
            short iflags = 0;

            if (IDD102_1018.Checked == true)
                iflags += 1;
            if (IDD102_1016.Checked == false)
                iflags += 8;
            if (IDD102_1017.Checked == true)
                iflags += 128;

            //st = TP_MakeGuestCardEx(card_snr, roomno, intime, outtime, iflags);  //this is a old function
            if (PreparedIssue(card_snr) == false)
                return;
            st = LS_MakeGuestCard_EX1(card_snr, roomno, "001", "008.009", intime, outtime, iflags); //please use new
            CheckErr(st);

        }

        private void IDD102_1005_Click(object sender, EventArgs e)
        {
            //Cancel card
            StringBuilder card_snr = new StringBuilder();
            st = TP_CancelCard(card_snr);
            CheckErr(st);
        }
        #endregion

        private void IDD102_1002_Click(object sender, EventArgs e)
        {
            //Set SDK
            Int16 locktype = 0;
            if (IDD102_1001.Checked)
            {
                locktype = 5;
            }
            if (IDD102_1000.Checked)
            {
                locktype = 4;
            }

            st = TP_Configuration(locktype);
            if (st == 1)
            {
                this.IDD102_1011.Enabled = true;
                this.IDD102_1003.Enabled = true;
                this.IDD102_1005.Enabled = true;
                this.btnReadCard.Enabled = true;
            }
            CheckErr(st);
        }

        private void IssueCardForm_Load(object sender, EventArgs e)
        {
            var stResult = CheckEncoder();
            if (stResult == -2)
            {
                this.Close();
            }
            else
            {
                BookingViewModel booking = _bookingController.GetAllBookings().FirstOrDefault(b => b.Id == _id);
                if (booking != null)
                {
                    txtRoomNo.Text = "001.002.00028";
                    txtInTime.Text = booking.CheckInDate.ToString();
                    txtOutTime.Text = booking.CheckOutDate.ToString();
                }
            }
        }

        public int CheckEncoder()
        {
            Int16 locktype = 0;
            if (IDD102_1001.Checked)
            {
                locktype = 5;
            }
            if (IDD102_1000.Checked)
            {
                locktype = 4;
            }

            st = TP_Configuration(locktype);
            if (st == 1)
            {
                this.IDD102_1011.Enabled = true;
                this.IDD102_1003.Enabled = true;
                this.IDD102_1005.Enabled = true;
                this.btnReadCard.Enabled = true;
            }
            CheckErr(st);
            return st;
        }

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            //Read card
            StringBuilder card_snr = new StringBuilder(100);
            StringBuilder roomno = new StringBuilder(100);
            StringBuilder intime = new StringBuilder(100);
            StringBuilder outtime = new StringBuilder(100);
            string strMsg = "";
            int iflags = 0;
            st = TP_ReadGuestCardEx(card_snr, roomno, intime, outtime, ref iflags);
            if (st == 1)
            {
                strMsg = "CARD NO" + card_snr.ToString() + "\n";
                strMsg += "LOCKNO" + roomno.ToString() + "\n";
                strMsg += "IN TIME" + intime.ToString() + "\n";
                strMsg += "OUTTIME" + outtime.ToString() + "\n";
                strMsg += "FLAGS" + "0x" + iflags.ToString("X1") + "\n";//¿¨Æ¬±êÖ¾
                if ((iflags & 1) != 0)
                    strMsg += "OPEN_BLOCK" + "\n";
                if ((iflags & 8) == 0)
                    strMsg += "RELACE_OLDCARD" + "\n";
                if ((iflags & 128) != 0)
                    strMsg += "CHECKIN_TIME" + "\n";

                MessageBox.Show(strMsg, "STRING_MSG", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CheckErr(st);
            }
        }
    }
}
