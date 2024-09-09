using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
using System;
using System.Data.SqlTypes;
using System.Text;
using System.Windows.Forms;
using static ESMART_HMS.ESMART_HMSDBDataSet;

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
                    MessageBox.Show("No card found", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public static int MakeMasterCard(char[] card_snr, string validTime, string endTime, int iFlags, int iReplaceNo)
        {

            int st = LockSDKHeaders.LS_MakeChiefCard(card_snr, validTime, endTime, iFlags, iReplaceNo);
            return st;
        }

        public static int ReadCard(char[] card_snr)
        {
            int st = LockSDKHeaders.LS_ReadRom(card_snr);
            return st;
        }

        public static int MakeRoomSettingsCard(StringBuilder card_snr, int buildingno, int floorno, string roomno, ROOM_TYPE roomtype, int areano1, int areano2, LOCK_SETTING lockSetting, int replaceNo)
        {
            int st = LockSDKHeaders.LS_MakeInstallCard(card_snr, buildingno, floorno, roomno, roomtype, areano1, areano2, lockSetting, replaceNo);
            return st;
        }

        public static int MakeGuestCard(char[] card_snr, string roomno, string area, string floor, string intime, string outtime, short iflags)
        {
            int st = LockSDKHeaders.LS_MakeGuestCard_EX1(card_snr, roomno, area, floor, intime, outtime, iflags);

            return st;
        }

        public static int MakeBuildingCard(char[] cardSnr, string BuildingList, string SDateTime, string EDateTime, int iFlags, int iReplaceNo)
        {
            int st = LockSDKHeaders.LS_MakeBuildingCard(cardSnr, BuildingList, SDateTime, EDateTime, iFlags, iReplaceNo);
            return st;
        }

        public static int MakeFloorCard(char[] cardSnr, int Building, string FloorList, string cSTime1, string cETime1, string SDateTime, string EDateTime, int iFlags, int iReplaceNo)
        {
            string cSTime2 = "00:00:00";
            string cETime2 = "00:00:00";
            string cSTime3 = "00:00:00";
            string cETime3 = "00:00:00";

            int st = LockSDKHeaders.LS_MakeFloorCard(cardSnr, Building, FloorList, cSTime1, cETime1, cSTime2, cETime2, cSTime3, cETime3, SDateTime, EDateTime, iFlags, iReplaceNo);

            return st;
        }
    }
}
