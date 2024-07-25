using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.ApplicationUserRole
{
    public class CreateUserRoleUseCase
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public CreateUserRoleUseCase(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public void Execute(Domain.Entities.ApplicationUserRole applicationUserRole)
        {
            _userRoleRepository.AssignUserToRole(applicationUserRole);
        }

    }
}
