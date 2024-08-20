using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESMART_HMS.Application.LockSDK;
using ESMART_HMS.Domain.Enum;

namespace ESMART_HMS.Presentation.Forms.Maintenance.CardMaintenance.Cards
{
    public partial class MastercardForm : Form
    {
        public MastercardForm()
        {
            InitializeComponent();
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
                
            }
            else
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
                string endTime = DateTime.Now.AddMinutes(5).ToString("yyyy-MM-dd HH:mm:ss");
                int cardFlg = 0;

                cardFlg += passageMode.Checked ? 2 : 0;
                cardFlg += openLocks.Checked ? 1 : 0;
                cardFlg += cancleCard.Checked ? 4 : 0;

                if (LockSDKMethods.PreparedIssue(card_snr) == false)
                    return;

                st = LockSDKHeaders.LS_MakeChiefCard(card_snr, validTime, endTime, 1, 0);

                if (st == (int)ERROR_TYPE.OPR_OK)
                {
                    MessageBox.Show("Successfully issued card", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show($"Failed to open port, {ex.Message}. error code: {st}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
