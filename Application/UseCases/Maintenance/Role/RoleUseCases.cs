using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.Maintenance.Role
{
    public class RoleUseCases
    {
        private readonly IRoleRepository _roleRepository;

        public RoleUseCases(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public void AddRole(Domain.Entities.Role role)
        {
            _roleRepository.AddRole(role);
        }

        public List<RoleViewModel> GetAllRoles()
        {
            return _roleRepository.GetAllRole();
        }

        public Domain.Entities.Role GetRoleById(string id)
        {
            return _roleRepository.GetRoleById(id);
        }

        public void UpdateRole(Domain.Entities.Role role)
        {
            _roleRepository.UpdateRole(role);
        }

        public void DeleteRole(string id)
        {
            _roleRepository.DeleteRole(id);
        }
    }
}
