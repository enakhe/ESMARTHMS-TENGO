using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace ESMART_HMS.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 10000;

        private readonly ESMART_HMSDBEntities _db;

        public UserRepository(ESMART_HMSDBEntities db)
        {
            _db = db;
        }

        public void AddUser(ApplicationUser user)
        {
            try
            {
                Random random = new Random();
                user.Id = Guid.NewGuid().ToString();
                user.UserId = "HMS" + random.Next(1000, 5000);
                user.PasswordHash = HashPassword(user.PasswordHash);
                user.IsTrashed = false;
                _db.ApplicationUsers.Add(user);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public string HashPassword(string password)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[SaltSize];
                rng.GetBytes(salt);

                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
                byte[] hash = pbkdf2.GetBytes(KeySize);

                // Combine salt and hash
                byte[] hashBytes = new byte[SaltSize + KeySize];
                Array.Copy(salt, 0, hashBytes, 0, SaltSize);
                Array.Copy(hash, 0, hashBytes, SaltSize, KeySize);

                // Convert to base64 for storage
                return Convert.ToBase64String(hashBytes);
            }
        }
        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, Iterations);
            byte[] hash = pbkdf2.GetBytes(KeySize);

            for (int i = 0; i < KeySize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }

        public ApplicationUser GetUserById(string id)
        {
            try
            {
                return _db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }
    }
}
