using ESMART_HMS.Application.UseCases.ApplicationUser;
using ESMART_HMS.Domain.Entities;

namespace ESMART_HMS.Presentation.Controllers
{
    public class ApplicationUserController
    {
        private readonly GetApplicationUserByIdUseCase _getApplicationUserByIdUseCase;
        private readonly CreateApplicationUserUseCase _createApplicationUserUseCase;

        public ApplicationUserController(GetApplicationUserByIdUseCase getApplicationUserByIdUseCase, CreateApplicationUserUseCase createApplicationUserUseCase)
        {
            _getApplicationUserByIdUseCase = getApplicationUserByIdUseCase;
            _createApplicationUserUseCase = createApplicationUserUseCase;
        }

        public ApplicationUser GetApplicationUserById(string id)
        {
            return _getApplicationUserByIdUseCase.Execute(id);
        }

        public void AddApplicationUser(ApplicationUser applicationUser)
        {
            _createApplicationUserUseCase.Execute(applicationUser);
        }
    }
}
