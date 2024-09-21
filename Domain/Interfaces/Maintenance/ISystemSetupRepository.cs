using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Domain.Interfaces.Maintenance
{
    public interface ISystemSetupRepository
    {
        void SetupCompanyInfo(CompanyInformation companyInformation);
        CompanyInformation GetCompanyInfo();
        void AddBankAccount(BankAccount bankAccount);
        List<BankAccountViewModel> GetAllAccounts();
        void UpdateBankAccount(BankAccount bankAccount);
        BankAccount GetBankAccounById(string id);
        void DeleteBankAccount(string id);
    }
}
