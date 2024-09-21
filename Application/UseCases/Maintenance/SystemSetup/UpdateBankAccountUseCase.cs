using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces.Maintenance;

namespace ESMART_HMS.Application.UseCases.Maintenance.SystemSetup
{
    public class UpdateBankAccountUseCase
    {
        private readonly ISystemSetupRepository _systemSetupRepository;

        public UpdateBankAccountUseCase(ISystemSetupRepository systemSetupRepository)
        {
            _systemSetupRepository = systemSetupRepository;
        }

        public void Execute(BankAccount bankAccount)
        {
            _systemSetupRepository.UpdateBankAccount(bankAccount);
        }
    }
}
