using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Domain.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(ApplicationUser user);
        string HashPassword(string password);
        bool VerifyPassword(string enteredPassword, string storedHash);
        ApplicationUser GetUserById(string id);
        List<UserViewModel> GetAllUsers();
        void UpdateUser(ApplicationUser user);
    }
}
