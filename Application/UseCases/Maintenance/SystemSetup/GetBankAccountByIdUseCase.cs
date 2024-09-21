using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces.Maintenance;

namespace ESMART_HMS.Application.UseCases.Maintenance.SystemSetup
{
    public class GetBankAccountByIdUseCase
    {
        private readonly ISystemSetupRepository _systemRepository;

        public GetBankAccountByIdUseCase(ISystemSetupRepository systemRepository)
        {
            _systemRepository = systemRepository;
        }

        public BankAccount Execute(string id)
        {
            return _systemRepository.GetBankAccounById(id);
        }
    }
}
