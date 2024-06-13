using ESMART_HMS.Domain.Entities;

namespace ESMART_HMS.Domain.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);
        string HashPassword(string password);
        bool VerifyPassword(string enteredPassword, string storedHash);
    }
}
