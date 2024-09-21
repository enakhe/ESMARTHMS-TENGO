using ESMART_HMS.Domain.Interfaces.Maintenance;

namespace ESMART_HMS.Application.UseCases.Maintenance.License
{
    public class AddLicenseUseCase
    {
        private readonly ILicenseRepository _licenseRepository;

        public AddLicenseUseCase(ILicenseRepository licenseRepository)
        {
            _licenseRepository = licenseRepository;
        }

        public void Execute(Domain.Entities.LicenseInfo licenseInfo)
        {
            _licenseRepository.AddLicence(licenseInfo);
        }
    }
}
