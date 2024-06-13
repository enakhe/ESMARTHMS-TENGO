using ESMART_HMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Domain.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);
        string HashPassword(string password);
        bool VerifyPassword(string enteredPassword, string storedHash);
    }
}
