using ESMART_HMS.Application.UseCases.ApplicationUserRole;
using ESMART_HMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Presentation.Controllers
{
    public class UserRoleController
    {
        private readonly CreateUserRoleUseCase _createUserRoleUseCase;

        public UserRoleController(CreateUserRoleUseCase createUserRoleUseCase)
        {
            _createUserRoleUseCase = createUserRoleUseCase;
        }

        public void AssignUserToRole(ApplicationUserRole applicationUserRole)
        {
            _createUserRoleUseCase.Execute(applicationUserRole);
        }
    }
}
