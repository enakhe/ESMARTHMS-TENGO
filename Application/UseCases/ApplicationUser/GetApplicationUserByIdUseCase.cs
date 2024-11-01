using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
