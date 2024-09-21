using ESMART_HMS.Application.LockSDK;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Sessions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Maintenance.CardMaintenance.Cards
{
    public partial class BuildingCardForm : Form
    {
        int st;
        string computerName = Environment.MachineName;
        private readonly RoomController _roomController;
        private readonly CardController _cardController;
        private readonly ApplicationUserController _userController;
        public BuildingCardForm(RoomController roomController, CardController cardController, ApplicationUserController userController)
        {
            InitializeComponent();
            _roomController = roomController;
            _cardController = cardController;
            _userController = userController;
        }

        public void GetAllBuilding()
        {
            List<Building> allBuildings = _roomController.GetAllBuildings();
            if (allBuildings != null)
            {
                foreach (Building building in allBuildings)
                {
                    listBuilding.Items.Add($"{building.BuildingName} ({building.BuildingNo})");
                }
            }
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

        public string ConvertSelectedItemsToString(CheckedListBox checkedListBox)
        {
            var selectedItems = checkedListBox.CheckedItems;
            List<string> codes = new List<string>();

            foreach (var item in selectedItems)
            {
                string itemText = item.ToString();
                int startIndex = itemText.IndexOf('(') + 1;
                int endIndex = itemText.IndexOf(')');

                if (startIndex > 0 && endIndex > startIndex)
                {
                    string code = itemText.Substring(startIndex, endIndex - startIndex);
                    codes.Add(code);
                }
            }

            // Join all codes with a dot separator
            string result = string.Join(".", codes);
            return result;
        }


        private void BuildingCardForm_Load(object sender, EventArgs e)
        {
            GetAllBuilding();
            Int16 locktype = 5;
            int checkEncoder = LockSDKMethods.CheckEncoder(locktype);
            if (checkEncoder != 1)
            {
                LockSDKMethods.CheckErr(checkEncoder);
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            try
            {
                char[] card_snr = new char[1000];

                string validTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string endTime = DateTime.Now.AddHours(1).ToString("yyyy-MM-dd HH:mm:ss");
                int cardFlg = 0;
                string buildingList = ConvertSelectedItemsToString(listBuilding);

                CARD_INFO cardInfo = new CARD_INFO();

                cardFlg += passageMode.Checked ? 2 : 0;
                cardFlg += openLocks.Checked ? 1 : 0;
                cardFlg += cancleCard.Checked ? 4 : 0;

                st = LockSDKHeaders.LS_ReadRom(card_snr);
                if (LockSDKMethods.PreparedIssue(card_snr) == false)
                    return;

                st = LockSDKMethods.ReadCard(card_snr);

                if (st != (int)ERROR_TYPE.OPR_OK)
                {
                    LockSDKMethods.CheckErr(st);
                    return;
                }
                else
                {
                    byte[] cbuf = new byte[10000];
                    cardInfo = new CARD_INFO();
                    int result = LockSDKHeaders.LS_GetCardInformation(ref cardInfo, 0, 0, IntPtr.Zero);
                }

                st = LockSDKMethods.MakeBuildingCard(card_snr, buildingList, validTime, endTime, 1, 0);

                if (st == (int)ERROR_TYPE.OPR_OK)
                {
                    string cardNoString = FormHelper.ByteArrayToString(cardInfo.CardNo);
                    MakeCardType cardType = FormHelper.GetCardType(3);

                    SpecialCard specialCard = new SpecialCard()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CardNo = cardNoString,
                        CardType = FormHelper.FormatEnumName(cardType),
                        IssueTime = DateTime.ParseExact(validTime, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                        RefundTime = DateTime.ParseExact(endTime, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                        IssuedBy = AuthSession.CurrentUser.Id,
                        ApplicationUser = _userController.GetApplicationUserById(AuthSession.CurrentUser.Id),
                        CanOpenDeadLocks = true,
                        PassageMode = false,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                    };
                    _cardController.AddSpecialCard(specialCard);
                    MessageBox.Show("Successfully issued card", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (st == (int)ERROR_TYPE.PORT_IN_USED)
                {
                    MessageBox.Show("Failed to issue card: Port is already in use", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Failed to issue card, error code: {st}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
