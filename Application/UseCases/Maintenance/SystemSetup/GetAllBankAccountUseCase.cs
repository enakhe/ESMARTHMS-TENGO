using ESMART_HMS.Domain.Interfaces.Maintenance;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.Maintenance.SystemSetup
{
    public class GetAllBankAccountUseCase
    {
        private readonly ISystemSetupRepository _systemSetupRepository;

        public GetAllBankAccountUseCase(ISystemSetupRepository systemSetupRepository)
        {
            _systemSetupRepository = systemSetupRepository;
        }

        public List<BankAccountViewModel> Execute()
        {
            return _systemSetupRepository.GetAllAccounts();
        }
    }
}
