using ESMART_HMS.Application.UseCases.Maintenance.SystemSetup;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Presentation.Controllers.Maintenance
{
    public class SystemSetupController
    {
        private readonly SetupCompanyUseCase _setupCompanyUseCase;
        private readonly GetCompanyInfoUseCase _getCompanyInfoUseCase;
        private readonly AddBankAccountUseCase _addBankAccountUseCase;
        private readonly GetAllBankAccountUseCase _getAllBankAccountUseCase;
        private readonly UpdateBankAccountUseCase _updateBankAccountUseCase;
        private readonly GetBankAccountByIdUseCase _getBankAccountByIdUseCase;
        private readonly DeleteBankAccountUseCase _deleteBankAccountUseCase;

        public SystemSetupController(SetupCompanyUseCase setupCompanyUseCase, GetCompanyInfoUseCase getCompanyInfoUseCase, AddBankAccountUseCase addBankAccountUseCase, GetAllBankAccountUseCase getAllBankAccountUseCase, UpdateBankAccountUseCase updateBankAccountUseCase, GetBankAccountByIdUseCase getBankAccountByIdUseCase, DeleteBankAccountUseCase deleteBankAccountUseCase)
        {
            _setupCompanyUseCase = setupCompanyUseCase;
            _getCompanyInfoUseCase = getCompanyInfoUseCase;
            _addBankAccountUseCase = addBankAccountUseCase;
            _getAllBankAccountUseCase = getAllBankAccountUseCase;
            _updateBankAccountUseCase = updateBankAccountUseCase;
            _getBankAccountByIdUseCase = getBankAccountByIdUseCase;
            _deleteBankAccountUseCase = deleteBankAccountUseCase;
        }

        public void SetupCompanyInfo(CompanyInformation companyInformation)
        {
            _setupCompanyUseCase.Execute(companyInformation);
        }

        public CompanyInformation GetCompanyInfo()
        {
            return _getCompanyInfoUseCase.Execute();
        }

        public void AddBankAccount(BankAccount bankAccount)
        {
            _addBankAccountUseCase.Execute(bankAccount);
        }

        public List<BankAccountViewModel> GetAllBankAccount()
        {
            return _getAllBankAccountUseCase.Execute();
        }

        public void UpdateBankAccount(BankAccount bankAccount)
        {
            _updateBankAccountUseCase.Execute(bankAccount);
        }

        public BankAccount GetBankAccountById(string id)
        {
            return _getBankAccountByIdUseCase.Execute(id);
        }

        public void DeleteBankAccount(string id)
        {
            _deleteBankAccountUseCase.Execute(id);
        }
    }
}
