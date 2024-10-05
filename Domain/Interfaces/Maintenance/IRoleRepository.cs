using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Domain.Interfaces
{
    public interface IRoleRepository
    {
        void AddRole(Role role);
        List<RoleViewModel> GetAllRole();
        Role GetRoleById(string Id);
        void DeleteRole(string id);
        void UpdateRole(Role role);
    }
}
