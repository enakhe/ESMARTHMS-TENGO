using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Infrastructure.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Infrastructure.Services
{
    public class AuthService
    {

        public ApplicationUser Login(string username, string password)
        {
            try
            {
                bool isNull = FormHelper.AreAnyNullOrEmpty(username, password);
                if (isNull == true)
                {
                    MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                else
                {
                    using (ESMART_HMSDBEntities db = new ESMART_HMSDBEntities())
                    {
                        UserRepository userRepository = new UserRepository(db);
                        var foundUser = db.ApplicationUsers.FirstOrDefault(u => u.UserName == username);
                        if (foundUser == null)
                        {
                            MessageBox.Show("No user with the username exits. Please check if the username and the password is correct", "User not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (userRepository.VerifyPassword(password, foundUser.PasswordHash))
                            {
                                return foundUser;
                            }
                            else
                            {
                                MessageBox.Show("No user with the username exits. Please check if the username and the password is correct", "User not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "User not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
    }
}
