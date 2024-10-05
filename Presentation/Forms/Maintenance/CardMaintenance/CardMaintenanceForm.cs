using ESMART_HMS.Application.LockSDK;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Forms.Maintenance.CardMaintenance.Cards;
using ESMART_HMS.Presentation.Middleware;
using ESMART_HMS.Presentation.Sessions;
using ESMART_HMS.Presentation.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ESMART_HMS.Presentation.Forms.Maintenance.CardMaintenance
{
    public partial class CardMaintenanceForm : Form
    {
        string computerName = Environment.MachineName;
        private DispatcherTimer dispatcherTimer;
        private readonly CardController _cardController;
        private readonly ApplicationUserController _userController;
        private readonly ApplicationUserController _applicationUserController;
        public CardMaintenanceForm(CardController cardController, ApplicationUserController userController, ApplicationUserController applicationUserController)
        {
            _cardController = cardController;
            _userController = userController;
            InitializeComponent();
            InitializeTimer();
            LoadSpecialCards();
            _applicationUserController = applicationUserController;
        }

        private void ApplyAuthorization2()
        {
            List<string> roles = new List<string> { "Admin", "SuperAdmin", "Manager" };
            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
            AuthorizationMiddleware.ProtectControl(user, btnMasterCard, roles);
        }

        private void btnMasterCard_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            MastercardForm mastercardForm = serviceProvider.GetRequiredService<MastercardForm>();
            if (mastercardForm.ShowDialog() == DialogResult.OK)
            {
                LoadSpecialCards();
            }
        }

        public void LoadSpecialCards()
        {
            List<SpecialCardViewModel> allSpecialCards = _cardController.GetAllSpecialCards();
            if (allSpecialCards != null)
            {
                dgvSpecialCards.DataSource = allSpecialCards;
            }
        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            int openPort = LockSDKMethods.OpenPort(5);
            if (openPort == 1)
            {
                btnReadAuthCard.Enabled = true;
            }
            else
            {
                LockSDKMethods.CheckErr(openPort);
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


        public void LoadCardDetails()
        {
            char[] card_snr = new char[100];

            int st = LockSDKMethods.ReadCard(card_snr);
            if (st != (int)ERROR_TYPE.OPR_OK)
            {
                txtStatus.Text = "No Found Card";
                txtStatus.ForeColor = Color.Red;

                txtCardNo.Text = "";
                txtCardTypeTwo.Text = "";
                txtSDate.Text = "";
                txtEdate.Text = "";
                txtBuilding.Text = "";
            }
            else
            {

                txtStatus.Text = "Card Found";
                txtStatus.ForeColor = Color.Green;
                txtCardTypeTwo.ForeColor = Color.Blue;

                CARD_INFO cardInfo = new CARD_INFO();
                byte[] cbuf = new byte[10000];
                cardInfo = new CARD_INFO();
                int result = LockSDKHeaders.LS_GetCardInformation(ref cardInfo, 0, 0, IntPtr.Zero);

                if (result == (int)ERROR_TYPE.OPR_OK)
                {
                    var roomNo = FormHelper.ByteArrayToString(cardInfo.RoomList);
                    bool isNull = FormHelper.AreAnyNullOrEmpty(roomNo);
                    MakeCardType cardType = FormHelper.GetCardType(cardInfo.CardType);

                    if (isNull && FormHelper.FormatEnumName(cardType) != "Guest Card")
                    {
                        txtCardNo.Text = $"Card No: {FormHelper.ByteArrayToString(cardInfo.CardNo)}";
                        txtCardTypeTwo.Text = $"Card Type: {FormHelper.FormatEnumName(cardType)}";
                        txtSDate.Text = $"Start Time: {FormHelper.ByteArrayToString(cardInfo.SDateTime)}";
                        txtEdate.Text = $"End Time: {FormHelper.ByteArrayToString(cardInfo.EDateTime)}";
                        txtBuilding.Text = $"Building No: {FormHelper.ByteArrayToString(cardInfo.BuildingList)}";
                        txtFloorList.Text = $"Floors: {FormHelper.ByteArrayToString(cardInfo.FloorList)}";
                        txtTime.Text = $"Time: {FormHelper.ByteArrayToString(cardInfo.StartTime1)} : {FormHelper.ByteArrayToString(cardInfo.EndTime1)}";
                    }
                    else if (isNull)
                    {
                        txtStatus.Text = "Empty Card";
                        txtStatus.ForeColor = Color.Red;

                        txtCardNo.Text = "";
                        txtCardTypeTwo.Text = "";
                        txtSDate.Text = "";
                        txtEdate.Text = "";
                    }
                    else
                    {

                        txtCardNo.Text = $"Card No: {FormHelper.ByteArrayToString(cardInfo.CardNo)}";
                        txtCardTypeTwo.Text = $"Card Type: {FormHelper.FormatEnumName(cardType)}";
                        txtSDate.Text = $"Start Time: {FormHelper.ByteArrayToString(cardInfo.SDateTime)}";
                        txtEdate.Text = $"End Time: {FormHelper.ByteArrayToString(cardInfo.EDateTime)}";
                    }
                }
            }
        }

        private void CardMaintenanceForm_Load(object sender, EventArgs e)
        {
            dispatcherTimer.Start();
            Int16 locktype = 5;
            AUTHDATA.Enabled = false;
            int checkEncoder = LockSDKMethods.CheckEncoder(locktype);
            if (checkEncoder != 1)
            {
                btnOpenPort.Enabled = false;
                LockSDKMethods.CheckErr(checkEncoder);
            }

            StringBuilder authId = GetAuthCardFromDB();
            if (authId != null)
            {
                bool isNull = FormHelper.AreAnyNullOrEmpty(authId.ToString());
                if (isNull == false)
                {
                    AUTHDATA.Text = authId.ToString();
                    btnUnlockParams.Enabled = true;
                }
            }
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

        private void btnReadAuthCard_Click(object sender, EventArgs e)
        {
            char[] card_snr = new char[20];
            string fnp = "1011899778569788";
            StringBuilder clientData = new StringBuilder(100);

            int clientDataResult = LockSDKMethods.ReadAuthCard(fnp, clientData, card_snr);
            if (clientDataResult != 1)
            {
                LockSDKMethods.CheckErr(clientDataResult);
            }
            else
            {
                btnUnlockParams.Enabled = true;
                AUTHDATA.Text = clientData.ToString();

                bool isNull = FormHelper.AreAnyNullOrEmpty(clientData.ToString(), computerName);
                if (isNull == false)
                {
                    Domain.Entities.AuthorizationCard authorizationCard = new Domain.Entities.AuthorizationCard()
                    {
                        Id = Guid.NewGuid().ToString(),
                        AuthId = clientData.ToString(),
                        ComputerName = computerName,
                        IsTrashed = false,
                        CreatedBy = AuthSession.CurrentUser.Id,
                        ApplicationUser = _userController.GetApplicationUserById(AuthSession.CurrentUser.Id),
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    };
                    _cardController.AddAuthCard(authorizationCard);
                    MessageBox.Show("Successfully saved auth card", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Unable to save auth card to database, loaded auth card", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnUnlockParams_Click(object sender, EventArgs e)
        {
            string fnp = "1011899778569788";
            StringBuilder clientData = new StringBuilder(AUTHDATA.Text);

            int systemIni = LockSDKMethods.SystemInitialization(fnp, clientData);
            if (systemIni != 1)
            {
                LockSDKMethods.CheckErr(systemIni);
                return;
            }
            else
            {
                btnMasterCard.Enabled = true;
                btnRecycle.Enabled = true;
                btnBuildingCard.Enabled = true;
                btnFloorCard.Enabled = true;
            }
        }

        private void btnRecycle_Click(object sender, EventArgs e)
        {
            StringBuilder card_snr = new StringBuilder();
            CARD_INFO cardInfo = new CARD_INFO();
            byte[] cbuf = new byte[10000];
            cardInfo = new CARD_INFO();
            int result = LockSDKHeaders.LS_GetCardInformation(ref cardInfo, 0, 0, IntPtr.Zero);

            var cardNo = FormHelper.ByteArrayToString(cardInfo.CardNo);
            SpecialCard card = _cardController.GetCardByNo(cardNo);
            int st = LockSDKHeaders.TP_CancelCard(card_snr);
            if (st == 1)
            {
                if (card != null)
                {
                    _cardController.DeleteCard(card.Id);
                }

                MessageBox.Show("Successfully recycled card", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCardDetails();
                LoadSpecialCards();
            }
        }

        private void btnBuildingCard_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            BuildingCardForm buildingCardForm = serviceProvider.GetRequiredService<BuildingCardForm>();
            if (buildingCardForm.ShowDialog() == DialogResult.OK)
            {
                LoadSpecialCards();
            }
        }

        private void btnFloor_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            FloorCardForm floorCardForm = serviceProvider.GetRequiredService<FloorCardForm>();
            if (floorCardForm.ShowDialog() == DialogResult.OK)
            {
                LoadSpecialCards();
            }
        }
    }
}
