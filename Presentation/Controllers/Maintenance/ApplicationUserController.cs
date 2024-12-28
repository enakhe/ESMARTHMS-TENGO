using ESMART_HMS.Application.UseCases.ApplicationUser;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

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

        public List<UserViewModel> GetAllUserViewModel()
        {
            return _getApplicationUserByIdUseCase.GetallUsers();
        }

        public void UpdateUser(Domain.Entities.ApplicationUser user)
        {
            _createApplicationUserUseCase.UpdateUser(user);
        }

        public string HashPassword(string password)
        {
            return _createApplicationUserUseCase.HashPassword(password);
        }

        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return _createApplicationUserUseCase.VerifyPassword(enteredPassword, storedHash);
        }

        public void DeleteUser(string id)
        {
            _createApplicationUserUseCase.DeleteUser(id);
        }
    }
}
