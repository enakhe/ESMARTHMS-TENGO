using ESMART_HMS.Domain.Entities;

namespace ESMART_HMS.Domain.Interfaces
{
    public interface IUserRoleRepository
    {
        void AssignUserToRole(ApplicationUserRole userRole);
        bool IsInRole(ApplicationUser user, string title);
        void UpdateUserRole(ApplicationUserRole userRole);
        ApplicationUserRole FindUserRole(string id);
    }
}
