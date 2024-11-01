using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
