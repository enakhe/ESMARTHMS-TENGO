using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces.Account;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Account.Account
{
    public class AccountUseCases
    {
        private readonly IAccountRepository _accountRepository;
         
        public AccountUseCases(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void AddChartOfAccount(ChartOfAccount chartOfAccount)
        {
            _accountRepository.AddChartOfAccount(chartOfAccount);
        }

        public List<ChartOfAccountViewModel> GetAllChartOfAccount()
        {
            return _accountRepository.GetAllChartOfAccount();
        }

        public void EditChartOfAccount(ChartOfAccount chartOfAccount)
        {
            _accountRepository.EditChartOfAccount(chartOfAccount);
        }

        public ChartOfAccount GetChartOfAccountById(string id)
        {
            return _accountRepository.GetChartOfAccountById(id);
        }
    }
}
