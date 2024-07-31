using ESMART_HMS.Application.UseCases.Maintenance.SystemSetup;
using ESMART_HMS.Domain.Entities;

namespace ESMART_HMS.Presentation.Controllers.Maintenance
{
    public class SystemSetupController
    {
        private readonly SetupCompanyUseCase _setupCompanyUseCase;
        private readonly GetCompanyInfoUseCase _getCompanyInfoUseCase;

        public SystemSetupController(SetupCompanyUseCase setupCompanyUseCase, GetCompanyInfoUseCase getCompanyInfoUseCase)
        {
            _setupCompanyUseCase = setupCompanyUseCase;
            _getCompanyInfoUseCase = getCompanyInfoUseCase;
        }

        public void SetupCompanyInfo(CompanyInformation companyInformation)
        {
            _setupCompanyUseCase.Execute(companyInformation);
        }

        public CompanyInformation GetCompanyInfo()
        {
            return _getCompanyInfoUseCase.Execute();
        }
    }
}
