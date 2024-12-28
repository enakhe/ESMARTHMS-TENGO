using ESMART_HMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESMART_HMS.Domain.Interfaces.Account;

namespace ESMART_HMS.Infrastructure.Data.Account
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ESMART_HMSDBEntities _db;

        public AccountRepository(ESMART_HMSDBEntities db)
        {
            _db = db;
        }

        public void AddChartOfAccount(ChartOfAccount chartOfAccount)
        {
            try
            {
                _db.ChartOfAccounts.Add(chartOfAccount);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured when adding chart of account {ex.Message}");
            }
        } 
    }
}
