using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Domain.Interfaces.Account
{
    public interface IAccountRepository
    {
        void AddChartOfAccount(ChartOfAccount chartOfAccount);
        List<ChartOfAccountViewModel> GetAllChartOfAccount();
        void EditChartOfAccount(ChartOfAccount chartOfAccount);
    }
}
