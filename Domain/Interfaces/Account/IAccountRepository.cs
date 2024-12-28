using ESMART_HMS.Domain.Entities;
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
    }
}
