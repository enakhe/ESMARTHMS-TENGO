using ESMART_HMS.Application.LockSDK;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Maintenance.CardMaintenance.Cards
{
    public partial class FloorCardForm : Form
    {
        public event EventHandler TimeChanged;
        private readonly CardController _cardController;
        private readonly ApplicationUserController _userController;
        private readonly RoomController _roomController;
        private readonly SystemSetupController _sytemSetupController;
        public FloorCardForm(CardController cardController, ApplicationUserController userController, RoomController roomController, SystemSetupController sytemSetupController)
        {
            _cardController = cardController;
            _userController = userController;
            _roomController = roomController;
            InitializeComponent();
            Initialize();
            LoadBuilding();
            _sytemSetupController = sytemSetupController;
        }

        int st;
        public void Initialize()
        {
            txtHour.Minimum = 0;
            txtHour.Maximum = 23;
            txtHour.Increment = 1;

            txtMinute.Minimum = 0;
            txtMinute.Maximum = 59;
            txtMinute.Increment = 1;

            txtToHour.Minimum = 0;
            txtToHour.Maximum = 23;
            txtToHour.Increment = 1;

            txtToMinute.Minimum = 0;
            txtToMinute.Maximum = 59;
            txtToMinute.Increment = 1;
        }

        public void LoadBuilding()
        {
            List<Building> allBuildings = _roomController.GetAllBuildings();
            if (allBuildings != null)
            {
                comboBuilding.DataSource = allBuildings;
            }
        }

        public void LoadFloors()
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(comboBuilding.Text);
            if (isNull == false)
            {
                List<Floor> allFloor = _roomController.GetFloorsByBuilding(comboBuilding.SelectedValue.ToString());
                if (allFloor != null)
                {
                    foreach (Floor floor in allFloor.OrderBy(f => f.FloorNo))
                    {
                        listFloors.Items.Add(floor.FloorNo);
                    }
                }
            }
        }

        public string SelectedTime()
        {
            int hours = (int)txtHour.Value;
            int minutes = (int)txtMinute.Value;

            return $"{hours}:{minutes}";
        }


        public string SelectedToTime()
        {
            int hours = (int)txtToHour.Value;
            int minutes = (int)txtToMinute.Value;

            return $"{hours}:{minutes}";
        }

        private void txtHour_ValueChanged(object sender, EventArgs e)
        {
            TimeChanged?.Invoke(this, EventArgs.Empty);
        }

        private void txtMinute_ValueChanged(object sender, EventArgs e)
        {
            TimeChanged?.Invoke(this, EventArgs.Empty);
        }

        private void txtToHour_ValueChanged(object sender, EventArgs e)
        {
            TimeChanged?.Invoke(this, EventArgs.Empty);
        }

        private void txtToMinute_ValueChanged(object sender, EventArgs e)
        {
            TimeChanged?.Invoke(this, EventArgs.Empty);
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

            string result = string.Join(".", codes);
            return result;
        }

        public string GetSelectedCodes(CheckedListBox checkedListBox)
        {
            List<string> codes = new List<string>();
            foreach (var item in checkedListBox.CheckedItems)
            {
                codes.Add(item.ToString());
            }

            if (codes.Count > 0)
            {
                return string.Join(".", codes);
            }
            else
            {
                return string.Empty;
            }
        }


        private async void btnIssue_Click(object sender, EventArgs e)
        {

            try
            {
                char[] card_snr = new char[1000];

                string selectedTime = SelectedTime();
                string selectedToTime = SelectedToTime();
                Building building = _roomController.GetBuildingById(comboBuilding.SelectedValue.ToString());
                CompanyInformation foundCompany = _sytemSetupController.GetCompanyInfo();


                string validTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string endTime = DateTime.Now.AddHours(1).ToString("yyyy-MM-dd HH:mm:ss");

                int cardFlg = 0;
                int buildingList = int.Parse(building.BuildingNo);
                string floorList = GetSelectedCodes(listFloors);

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

                st = LockSDKMethods.MakeFloorCard(card_snr, buildingList, floorList, DateTime.Now.ToString("HH:mm"), DateTime.Now.AddMinutes(30).ToString("HH:mm"), validTime, endTime, CARD_FLAGS.CF_CHECK_TIMESTAMP, 0);

                if (st == (int)ERROR_TYPE.OPR_OK)
                {
                    CARD_INFO cardInfo = new CARD_INFO();

                    byte[] cbuf = new byte[10000];
                    cardInfo = new CARD_INFO();
                    int result = LockSDKHeaders.LS_GetCardInformation(ref cardInfo, 0, 0, IntPtr.Zero);

                    string cardNoString = FormHelper.ByteArrayToString(cardInfo.CardNo);
                    MakeCardType cardType = FormHelper.GetCardType(2);

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
                    string specialCardString = $"Id = {specialCard.Id}\n" +
                         $"Card No = {specialCard.CardNo}\n" +
                         $"Card Type = {specialCard.CardType}\n" +
                         $"Issue Time = {specialCard.IssueTime}\n" +
                         $"Refund Time = {specialCard.RefundTime}\n" +
                         $"Issued By = {specialCard.IssuedBy}\n" +
                         $"Application User = {specialCard.ApplicationUser?.FullName}\n" +
                         $"Can Open Dead Locks = {specialCard.CanOpenDeadLocks}\n" +
                         $"Passage Mode = {specialCard.PassageMode}\n" +
                         $"Date Created = {specialCard.DateCreated}\n" +
                         $"Date Modified = {specialCard.DateModified}";
                    if (foundCompany != null)
                    {
                        if (foundCompany.Email != null)
                        {
                            await EmailHelper.SendEmail(foundCompany.Email, "Floor Card Created", specialCardString);
                        }
                    }
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

        private void FloorCardForm_Load(object sender, EventArgs e)
        {
            this.buildingTableAdapter.Fill(this.eSMART_HMSDBDataSet.Building);

        }

        private void comboBuilding_SelectedValueChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(comboBuilding.Text);
            if (isNull == false)
            {
                List<Floor> allFloor = _roomController.GetFloorsByBuilding(comboBuilding.SelectedValue.ToString());
                if (allFloor != null)
                {
                    listFloors.Items.Clear();
                    foreach (Floor floor in allFloor)
                    {
                        listFloors.Items.Add(floor.FloorNo);
                    }
                }
            }
        }
    }
}
