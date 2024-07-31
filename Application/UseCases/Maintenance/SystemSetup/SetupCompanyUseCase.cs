using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces.Maintenance;

namespace ESMART_HMS.Application.UseCases.Maintenance.SystemSetup
{
    public class SetupCompanyUseCase
    {
        private readonly ISystemSetupRepository _sytemSetupRepository;

        public SetupCompanyUseCase(ISystemSetupRepository systemSetupRepository)
        {
            _sytemSetupRepository = systemSetupRepository;
        }

        public void Execute(CompanyInformation companyInformation)
        {
            _sytemSetupRepository.SetupCompanyInfo(companyInformation);
        }

    }
}
