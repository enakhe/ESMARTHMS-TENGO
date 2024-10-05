using ESMART_HMS.Domain.Interfaces;

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

        public void UpdateUserRole(Domain.Entities.ApplicationUserRole applicationUserRole)
        {
            _userRoleRepository.UpdateUserRole(applicationUserRole);
        }

        public Domain.Entities.ApplicationUserRole FindUserRole(string id)
        {
            return _userRoleRepository.FindUserRole(id);
        }

    }
}
