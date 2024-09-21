using ESMART_HMS.Domain.Interfaces.Maintenance;

namespace ESMART_HMS.Application.UseCases.Maintenance.SystemSetup
{
    public class DeleteBankAccountUseCase
    {
        private readonly ISystemSetupRepository _systemRepository;

        public DeleteBankAccountUseCase(ISystemSetupRepository systemRepository)
        {
            _systemRepository = systemRepository;
        }

        public void Execute(string id)
        {
            _systemRepository.DeleteBankAccount(id);
        }
    }
}
