using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Infrastructure.Frameworks.TengoLock
{
    public class Language
    {
        static string g_szLanguagePath = "";
        static string g_szCurPath = "";

        /// <summary>
        /// Get path of language file
        /// </summary>
        public static void GetLanguagePath_Ex()
        {
            g_szCurPath = System.Windows.Forms.Application.StartupPath;
            //Ini ini = new Ini(g_szCurPath + "\\Config.ini");
            //string sLan = ini.ReadValue("System", "Language");
            //if (sLan == "")
            //{
            //    sLan = "Chinese";
            //}
            g_szLanguagePath = g_szCurPath + "\\ToolsLanguage.ini";
        }

        /// <summary>
        /// Load string from language file by ID 'szId'
        /// </summary>
        /// <param name="szID"></param>
        /// <returns></returns>
        public static string g_LoadString_Ex(string szID)
        {
            string szValue = "";
            if (g_szLanguagePath == "")
                GetLanguagePath_Ex();
            Ini ini = new Ini(g_szLanguagePath);
            szValue = ini.ReadValue("String", szID);
            if (szValue == "")
            {
                szValue = "Not found";
            }
            else
            {
                szValue.Replace("\\n", "\n");//Replace chars to Enter char
            }
            return szValue;
        }

        /// <summary>
        /// Get all text from on dialog is runing, and save to file.
        ///	All controls' id
        /// </summary>
        /// <param name="frm"></param>
        public static void g_SetFormStrings_Ex(Form frm)
        {
            string szSection = "LockSDKDemo";
            string szKey = "", szText = "";
            bool bSetText = true;//true: from file; false:save to file

            if (g_szLanguagePath == "")
                GetLanguagePath_Ex();
            Ini ini = new Ini(g_szLanguagePath);
            if (bSetText)//Read from file and set text to controls
            {
                string szDefault = "";

                //Read title of the windows
                szKey = frm.Name + "_Title";

                szDefault = ini.ReadValue(szSection, szKey);
                if (szDefault == "")
                {
                    szDefault = "Not found";
                }
                else
                {
                    szDefault.Replace("\\n", "\n");//Replace Enter key char
                }
                frm.Text = szDefault;

                //Read all controls'caption
                foreach (Control c1 in frm.Controls)
                {
                    szKey = c1.Name;// frm.Name + "_" + c1.Name;
                    szText = ini.ReadValue(szSection, szKey);
                    c1.Text = szText;
                }
            }
            else//Save to file
            {
                //Write title of the window
                szKey = frm.Name + "_Title";
                szText = frm.Text;
                ini.Writue(szSection, szKey, szText);

                //Write sub-ctrl's caption
                foreach (Control c2 in frm.Controls)
                {
                    szKey = frm.Name + "_" + c2.Name;
                    szText = c2.Text;
                    ini.Writue(szSection, szKey, szText);
                }
            }
        }
    }
    public class Ini
    {
        // Declare function WritePrivateProfileString() for ini file's reading operation 
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        // Declare function GetPrivateProfileString() for ini file's reading operation
        [System.Runtime.InteropServices.DllImport("kernel32")]

        private static extern int GetPrivateProfileString(string section, string key, string def, System.Text.StringBuilder retVal, int size, string filePath);


        private string sPath = null;
        public Ini(string path)
        {
            this.sPath = path;
        }

        public void Writue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, sPath);

        }
        public string ReadValue(string section, string key)
        {
            // Read data from ini file by bytes
            System.Text.StringBuilder temp = new System.Text.StringBuilder(255);
            GetPrivateProfileString(section, key, "", temp, 255, sPath);
            return temp.ToString();

        }
    }
}
