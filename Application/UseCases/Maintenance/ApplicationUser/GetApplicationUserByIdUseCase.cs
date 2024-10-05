using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.ApplicationUser
{
    public class GetApplicationUserByIdUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetApplicationUserByIdUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Domain.Entities.ApplicationUser Execute(string id)
        {
            return _userRepository.GetUserById(id);
        }

        public List<UserViewModel> GetallUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }
}
