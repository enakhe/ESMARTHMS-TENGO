using ESMART_HMS.Domain.Entities;

namespace ESMART_HMS.Domain.Interfaces.Maintenance
{
    public interface ILicenseRepository
    {
        void AddLicence(LicenseInfo licenseInfo);
        LicenseInfo GetLicenseInfo();
    }
}
