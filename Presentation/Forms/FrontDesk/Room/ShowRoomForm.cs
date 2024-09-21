using ESMART_HMS.Application.LockSDK;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ESMART_HMS.Presentation.Forms.FrontDesk.Room
{
    public partial class ShowRoomForm : Form
    {
        private DispatcherTimer dispatcherTimer;
        private readonly string _id;
        string computerName = Environment.MachineName;
        private readonly CardController _cardController;
        private readonly RoomController _roomController;
        private readonly ApplicationUserController _userController;

        public ShowRoomForm(string id, RoomController roomController, CardController cardController, ApplicationUserController userController)
        {
            _id = id;
            _roomController = roomController;
            _cardController = cardController;
            InitializeComponent();
            InitializeTimer();
            _userController = userController;
        }

        int st = 0;

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

        private void ShowRoomForm_Load(object sender, EventArgs e)
        {
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

        private void LoadCardDetails()
        {
            char[] card_snr = new char[100];

            int st = LockSDKMethods.ReadCard(card_snr);
            if (st != (int)ERROR_TYPE.OPR_OK)
            {
                txtStatus.Text = "No Found Card";
                txtStatus.ForeColor = Color.Red;

                txtCardNo.Text = "";
                txtLockNo.Text = "";
                txtRoomNo.Text = "";
            }
            else
            {
                Domain.Entities.Room selectedRoom = _roomController.GetRealRoom(_id);

                txtStatus.Text = "Card Found";
                txtStatus.ForeColor = Color.Green;

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
                        txtLockNo.Text = "";
                        txtRoomNo.Text = "";
                    }
                    else
                    {
                        MakeCardType cardType = FormHelper.GetCardType(cardInfo.CardType);

                        txtRoomNo.Text = selectedRoom.RoomNo;
                        txtCardNo.Text = FormHelper.ByteArrayToString(cardInfo.CardNo);
                        txtLockNo.Text = $"1.1.{selectedRoom.RoomNo}";
                    }
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
            LoadCardDetails();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            //Issue card
            char[] card_snr = new char[100];
            Domain.Entities.Room room = _roomController.GetRealRoom(_id);

            string roomno = $"{room.Building.BuildingNo}.{room.Floor.FloorNo}.{room.RoomNo}";

            string intime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            String outtime = DateTime.Now.AddMinutes(1).ToString("yyyy-MM-dd HH:mm:ss");

            short iflags = 80;

            if (LockSDKHeaders.PreparedIssue(card_snr) == false)
                return;
            st = LockSDKMethods.MakeGuestCard(card_snr, roomno, room.Area.AreaNo, room.Floor.FloorNo, intime, outtime, iflags);

            if (st == (int)ERROR_TYPE.OPR_OK)
            {
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
    }
}
