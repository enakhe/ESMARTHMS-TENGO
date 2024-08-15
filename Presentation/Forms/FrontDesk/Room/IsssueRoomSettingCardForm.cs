using ESMART_HMS.Presentation.Controllers;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ESMART_HMS.Presentation.Forms.FrontDesk.Room
{
    public partial class IsssueRoomSettingCardForm : Form
    {
        private DispatcherTimer dispatcherTimer;
        private readonly string _id;
        private readonly RoomController _roomController;
        public IsssueRoomSettingCardForm(string id, RoomController roomController)
        {
            _id = id;
            _roomController = roomController;
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
                    MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void IsssueRoomSettingCardForm_Load(object sender, EventArgs e)
        {
            var stResult = CheckEncoder();
            if (stResult == -2)
            {
                this.Close();
            }
            dispatcherTimer.Start();
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

                    if (lockno.ToString() == "")
                    {
                        txtEmpty.Text = "Empty card";
                        txtEmpty.ForeColor = Color.Red;
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

                txtError.Text = "No card found";
                txtError.ForeColor = Color.Red;

                txtEmpty.Text = "";
                txtEmpty.ForeColor = Color.Transparent;
            }

        }

        private void InitializeTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1); // Set interval to 1 second
            dispatcherTimer.Tick += DispatcherTimer_Tick;
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

        private void btnIssue_Click(object sender, EventArgs e)
        {
            //Issue card
            StringBuilder card_snr = new StringBuilder(100);

            Domain.Entities.Room selectedRoom = _roomController.GetRealRoom(_id);

            string roomno = "1.1." + selectedRoom.RoomNo;
            string intime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            String outtime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
            short iflags = 137;

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
