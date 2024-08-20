using ESMART_HMS.Presentation.Forms.FrontDesk.Room.Building;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESMART_HMS.Presentation.Forms.Maintenance.CardMaintenance.Cards;
using ESMART_HMS.Application.LockSDK;

namespace ESMART_HMS.Presentation.Forms.Maintenance.CardMaintenance
{
    public partial class CardMaintenanceForm : Form
    {
        public CardMaintenanceForm()
        {
            InitializeComponent();
        }

        private void btnMasterCard_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            MastercardForm mastercardForm = serviceProvider.GetRequiredService<MastercardForm>();
            if (mastercardForm.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {

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

        private void CardMaintenanceForm_Load(object sender, EventArgs e)
        {
            Int16 locktype = 5;
            int checkEncoder = LockSDKMethods.CheckEncoder(locktype);
            if (checkEncoder != 1)
            {
                btnOpenPort.Enabled = false;
            }
            else
            {
                LockSDKMethods.CheckErr(checkEncoder);
            }
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
                MessageBox.Show("Successfully loaded auth card", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            btnMasterCard.Enabled = true;
        }
    }
}
