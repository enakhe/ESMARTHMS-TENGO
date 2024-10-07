using ESMART_HMS.Application.LockSDK;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Sessions;
using System;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ESMART_HMS.Presentation.Forms.FrontDesk.Room
{
    public partial class IsssueRoomSettingCardForm : Form
    {
        private DispatcherTimer dispatcherTimer;
        private readonly string _id;
        string computerName = Environment.MachineName;
        private readonly CardController _cardController;
        private readonly RoomController _roomController;
        private readonly ApplicationUserController _userController;
        public IsssueRoomSettingCardForm(string id, RoomController roomController, CardController cardController, ApplicationUserController userController)
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

        private void IsssueRoomSettingCardForm_Load(object sender, EventArgs e)
        {
            var allAreas = _roomController.GetAllAreas();
            if (allAreas != null)
            {
                txtArea.DataSource = allAreas;
            }
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

        private void btnIssue_Click(object sender, EventArgs e)
        {
            //Issue card
            Domain.Entities.Room selectedRoom = _roomController.GetRealRoom(_id);

            StringBuilder card_snr = new StringBuilder(100);
            string roomno = $"{selectedRoom.Building.BuildingNo}.{selectedRoom.Floor.FloorNo}.{selectedRoom.RoomNo}";
            int buildingno = int.Parse(selectedRoom.Building.BuildingNo);
            int floorno = int.Parse(selectedRoom.Floor.FloorNo);
            int areano1 = int.Parse(txtArea.SelectedValue.ToString());
            int areano2 = 0;
            ROOM_TYPE roomtype = ROOM_TYPE.RT_COMMON_ROOMS;
            LOCK_SETTING lockSetting = LOCK_SETTING.LS_VALID_DATE_EN;
            int replaceNo = 0;

            st = LockSDKMethods.MakeRoomSettingsCard(card_snr, buildingno, floorno, roomno, roomtype, areano1, areano2, lockSetting, replaceNo);

            if (st == (int)ERROR_TYPE.OPR_OK)
            {
                CARD_INFO cardInfo = new CARD_INFO();
                byte[] cbuf = new byte[10000];
                cardInfo = new CARD_INFO();
                int result = LockSDKHeaders.LS_GetCardInformation(ref cardInfo, 0, 0, IntPtr.Zero);

                string cardNoString = FormHelper.ByteArrayToString(cardInfo.CardNo);
                MakeCardType cardType = FormHelper.GetCardType(cardInfo.CardType);


                SpecialCard specialCard = new SpecialCard()
                {
                    Id = Guid.NewGuid().ToString(),
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
                _cardController.AddSpecialCard(specialCard);
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
