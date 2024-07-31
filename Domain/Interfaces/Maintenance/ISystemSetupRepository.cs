using ESMART_HMS.Domain.Entities;

namespace ESMART_HMS.Domain.Interfaces.Maintenance
{
    public interface ISystemSetupRepository
    {
        void SetupCompanyInfo(CompanyInformation companyInformation);
        CompanyInformation GetCompanyInfo();
    }
}
