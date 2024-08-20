using ESMART_HMS.Application.LockSDK;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Presentation.Controllers;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;
using ESMART_HMS.Application.LockSDK;

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
            st = LockSDKHeaders.TP_Configuration(locktype);
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
                    LockSDKHeaders.CheckErr(st);
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
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
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

        private void btnIssue_Click(object sender, EventArgs e)
        {
            //Issue card
            Domain.Entities.Room selectedRoom = _roomController.GetRealRoom(_id);

            StringBuilder card_snr = new StringBuilder(100);
            string roomno = $"{selectedRoom.Building.BuildingNo}.{selectedRoom.Floor.FloorNo}.{selectedRoom.RoomNo}";
            int buildingno = int.Parse(selectedRoom.Building.BuildingNo);
            int floorno = int.Parse(selectedRoom.Floor.FloorNo);
            int areano1 = int.Parse(selectedRoom.Area.AreaNo);
            int areano2 = 0; 
            ROOM_TYPE roomtype = ROOM_TYPE.RT_COMMON_ROOMS;
            LOCK_SETTING lockSetting = LOCK_SETTING.LS_REPLACE_EN | LOCK_SETTING.LS_VALID_DATE_EN;
            int replaceNo = 0;

            LockSDKHeaders.LS_ClosePort(5);

            st = LockSDKHeaders.LS_MakeInstallCard(card_snr, buildingno, floorno, roomno, roomtype, areano1, areano2, lockSetting, replaceNo);

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

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            try
            {
                st = LockSDKHeaders.LS_OpenPort(5);
                if (st == (int)ERROR_TYPE.OPR_OK)
                {
                    MessageBox.Show("Successfully opened port", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCardDetails();
                    btnRecycle.Enabled = true;
                    btnIssue.Enabled = true;
                }
                else
                {
                    MessageBox.Show($"Failed to open port, error code: {st}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open port, {ex.Message}. error code: {st}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
