using ESMART_HMS.Application.LockSDK;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Maintenance.CardMaintenance.Cards
{
    public partial class AuthCard : Form
    {
        string computerName = Environment.MachineName;
        private readonly CardController _cardController;
        private readonly ESMART_HMSDBEntities _db;
        public AuthCard(CardController cardController, ESMART_HMSDBEntities db)
        {
            _db = db;
            _cardController = cardController;
            InitializeComponent();
        }

        private void ValidateCardEncoderConnection()
        {
            const Int16 EncoderLockType = 5;
            int encoderStatus = LockSDKMethods.CheckEncoder(EncoderLockType);

            if (encoderStatus != 1)
            {
                MessageBox.Show("Please connect the encoder!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                AUTHDATA.Text = clientData.ToString();

                bool isNull = FormHelper.AreAnyNullOrEmpty(clientData.ToString(), computerName);
                if (isNull == false)
                {
                    var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName == "SuperAdmin");
                    Domain.Entities.AuthorizationCard authorizationCard = new Domain.Entities.AuthorizationCard()
                    {
                        Id = Guid.NewGuid().ToString(),
                        AuthId = clientData.ToString(),
                        ComputerName = computerName,
                        IsTrashed = false,
                        CreatedBy = user.Id,
                        ApplicationUser = user,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    };
                    _cardController.AddAuthCard(authorizationCard);
                    MessageBox.Show("Successfully saved auth card", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Unable to save auth card to database, loaded auth card", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void AuthCard_Load(object sender, EventArgs e)
        {
            int openPort = LockSDKMethods.OpenPort(5);
            ValidateCardEncoderConnection();
        }
    }
}
