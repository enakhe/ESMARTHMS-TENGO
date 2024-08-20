using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Application.LockSDK
{
    public class LockSDKMethods
    {
        #region Public methods
        public static void CheckErr(int iret)
        {
            switch (iret)
            {
                case 1:
                    MessageBox.Show("Card reader/writer found", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case -1:
                    MessageBox.Show("Sorry invalid card", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case -2:
                    MessageBox.Show("Sorry no detected card reader/writer", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case -3:
                    MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case -4:
                    MessageBox.Show("Card type error", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case -5:
                    MessageBox.Show("Read/write error", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case -8:
                    MessageBox.Show("Invalid Parameter", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case -29:
                    MessageBox.Show("Unregistered decoder", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    MessageBox.Show("Sorry an error occured", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        public static Boolean PreparedIssue(char[] card_snr)
        {
            int st;
            st = LockSDKHeaders.LS_ReadRom(card_snr);
            int[] errors = { 1, 3, 4, 5 };
            if (st != 1)
            {
                CheckErr(st);
                return false;
            }
            return true;
        }
        #endregion
        public static int CheckEncoder(Int16 locktype)
        {
            int st = LockSDKHeaders.TP_Configuration(locktype);
            return st;
        }

        public static int OpenPort(int port)
        {
            int st = LockSDKHeaders.LS_OpenPort(port);
            return st;
        }

        public static int ReadAuthCard(string fnP, StringBuilder clientData, char[] card_snr)
        {
            int st = LockSDKHeaders.LS_ReadSystemPas(fnP, clientData, card_snr);
            return st;
        }

        public static int SystemInitialization(string funPsw, StringBuilder Password)
        {
            int st = LockSDKHeaders.LS_SystemInitialization(funPsw, Password);
            return st;
        }
    }
}
