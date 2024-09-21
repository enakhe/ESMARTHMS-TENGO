using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces.Maintenance;

namespace ESMART_HMS.Application.UseCases.Maintenance.License
{
    public class GetLicenseUseCase
    {
        private readonly ILicenseRepository _licenseRepository;

        public GetLicenseUseCase(ILicenseRepository licenseRepository)
        {
            _licenseRepository = licenseRepository;
        }

        public LicenseInfo Execute()
        {
            return _licenseRepository.GetLicenseInfo();
        }
    }
}
