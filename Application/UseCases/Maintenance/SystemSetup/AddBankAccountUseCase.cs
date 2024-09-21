using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces.Maintenance;

namespace ESMART_HMS.Application.UseCases.Maintenance.SystemSetup
{
    public class AddBankAccountUseCase
    {
        private readonly ISystemSetupRepository _systemSetupRepository;

        public AddBankAccountUseCase(ISystemSetupRepository systemSetupRepository)
        {
            _systemSetupRepository = systemSetupRepository;
        }


        public void Execute(BankAccount bankAccount)
        {
            _systemSetupRepository.AddBankAccount(bankAccount);
        }
    }
}
