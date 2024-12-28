using ESMART_HMS.Application.UseCases.Account.Account;
using ESMART_HMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Presentation.Controllers.Account
{
    public class AccountController
    {
        private readonly AccountUseCases _accountUseCases;

        public AccountController(AccountUseCases accountUseCases)
        {
            _accountUseCases = accountUseCases;
        }

        public void AddChartOfAccount(ChartOfAccount chartOfAccount)
        {
            _accountUseCases.AddChartOfAccount(chartOfAccount);
        }
    }
}
