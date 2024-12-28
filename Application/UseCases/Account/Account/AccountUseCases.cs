using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces.Account;
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
    }
}
