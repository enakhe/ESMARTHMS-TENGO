using ESMART_HMS.Application.LockSDK;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Sessions;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ESMART_HMS.Presentation.Forms.Maintenance.CardMaintenance.Cards
{
    public partial class MastercardForm : Form
    {
        private readonly CardController _cardController;
        private readonly ApplicationUserController _userController;
        private readonly SystemSetupController _sytemSetupController;
        public MastercardForm(CardController cardController, ApplicationUserController applicationUserController, SystemSetupController sytemSetupController)
        {
            _cardController = cardController;
            _userController = applicationUserController;
            InitializeComponent();
            _sytemSetupController = sytemSetupController;
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

        private void MastercardForm_Load(object sender, EventArgs e)
        {
            Int16 locktype = 5;
            int checkEncoder = LockSDKMethods.CheckEncoder(locktype);
            if (checkEncoder != 1)
            {
                LockSDKMethods.CheckErr(checkEncoder);
            }
        }

        private async void btnIssue_Click(object sender, EventArgs e)
        {
            try
            {
                char[] card_snr = new char[1000];

                string validTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string endTime = DateTime.Now.AddHours(1).ToString("yyyy-MM-dd HH:mm:ss");
                int cardFlg = 0;

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

                st = LockSDKMethods.MakeMasterCard(card_snr, validTime, endTime, 1, 0);

                if (st == (int)ERROR_TYPE.OPR_OK)
                {
                    string cardNoString = FormHelper.ByteArrayToString(cardInfo.CardNo);
                    CompanyInformation foundCompany = _sytemSetupController.GetCompanyInfo();

                    SpecialCard specialCard = new SpecialCard()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CardNo = cardNoString,
                        CardType = "Master Card",
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
                            await EmailHelper.SendEmail(foundCompany.Email, "Master Card Created", specialCardString);
                        }
                    }
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
