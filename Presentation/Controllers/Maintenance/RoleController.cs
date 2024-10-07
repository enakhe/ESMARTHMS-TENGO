using ESMART_HMS.Application.UseCases.Maintenance.Role;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Presentation.Controllers.Maintenance
{
    public class RoleController
    {
        private readonly RoleUseCases _roleUseCases;

        public RoleController(RoleUseCases roleUseCases)
        {
            _roleUseCases = roleUseCases;
        }

        public void AddRole(Domain.Entities.Role role)
        {
            _roleUseCases.AddRole(role);
        }

        public List<RoleViewModel> GetAllRoles()
        {
            return _roleUseCases.GetAllRoles();
        }

        public Domain.Entities.Role GetRoleById(string id)
        {
            return _roleUseCases.GetRoleById(id);
        }

        public void UpdatedRole(Domain.Entities.Role role)
        {
            _roleUseCases.UpdateRole(role);
        }

        public void DeleteRole(string id)
        {
            _roleUseCases.DeleteRole(id);
        }
    }
}
