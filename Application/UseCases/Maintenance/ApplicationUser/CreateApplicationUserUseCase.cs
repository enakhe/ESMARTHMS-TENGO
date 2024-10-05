using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.ApplicationUser
{
    public class CreateApplicationUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public CreateApplicationUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Execute(Domain.Entities.ApplicationUser user)
        {
            _userRepository.AddUser(user);
        }

        public void UpdateUser(Domain.Entities.ApplicationUser user)
        {
            _userRepository.UpdateUser(user);
        }
    }
}
