using ESMART_HMS.Application.UseCases.Maintenance.License;
using ESMART_HMS.Domain.Entities;

namespace ESMART_HMS.Presentation.Controllers.Maintenance
{
    public class LicenseController
    {
        private readonly AddLicenseUseCase _addLicenseUseCase;
        private readonly GetLicenseUseCase _getLicenseUseCase;

        public LicenseController(AddLicenseUseCase addLicenseUseCase, GetLicenseUseCase getLicenseUseCase)
        {
            _addLicenseUseCase = addLicenseUseCase;
            _getLicenseUseCase = getLicenseUseCase;
        }

        public void AddLicense(LicenseInfo licenseInfo)
        {
            _addLicenseUseCase.Execute(licenseInfo);
        }

        public LicenseInfo GetLicenseInfo()
        {
            return _getLicenseUseCase.Execute();
        }
    }
}
