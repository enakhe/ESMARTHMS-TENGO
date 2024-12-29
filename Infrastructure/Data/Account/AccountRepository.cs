using ESMART_HMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESMART_HMS.Domain.Interfaces.Account;
using ESMART_HMS.Presentation.ViewModels;

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
                throw new Exception($"An error occured when adding chart of account. {ex.Message}");
            }
        } 

        public List<ChartOfAccountViewModel> GetAllChartOfAccount()
        {
            try
            {
                var allChartOfAccount = from chartOfAccount in _db.ChartOfAccounts.Where(coa => coa.IsTrashed == false && coa.IsActive == true).OrderBy(coa => coa.AccountCode)
                                        select new ChartOfAccountViewModel
                                        {
                                            Id = chartOfAccount.Id,
                                            AccountCode = chartOfAccount.AccountCode,
                                            AccountName = chartOfAccount.AccountName,
                                            AccountGroup = chartOfAccount.AccountGroup,
                                            AccountType = chartOfAccount.AccountType,
                                            RollTo = chartOfAccount.RollTo,
                                            RollBalance = (bool)chartOfAccount.RollBalance,
                                            CashflowAccount = (bool)chartOfAccount.CashflowAccount,
                                            CreatedBy = chartOfAccount.ApplicationUser.FullName,
                                            IsActive = chartOfAccount.IsActive,
                                        };
                return allChartOfAccount.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured when getting all chart of accounts. {ex.Message}");
            }
        }

        public void EditChartOfAccount(ChartOfAccount chartOfAccount)
        {
            try
            {
                _db.Entry(chartOfAccount).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured when updating chart of account. {ex.Message}");
            }
        }

        public ChartOfAccount GetChartOfAccountById(string id)
        {
            try
            {
                return _db.ChartOfAccounts.FirstOrDefault(coa => coa.Id ==  id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured when updating chart of account. {ex.Message}");
            }
        }
    }
}
