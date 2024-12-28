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

        public string HashPassword(string password)
        {
            return _userRepository.HashPassword(password);
        }

        public void UpdateUser(Domain.Entities.ApplicationUser user)
        {
            _userRepository.UpdateUser(user);
        }

        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return _userRepository.VerifyPassword(enteredPassword, storedHash);
        }

        public void DeleteUser(string id)
        {
            _userRepository.DeleteUser(id);
        }
    }
}
