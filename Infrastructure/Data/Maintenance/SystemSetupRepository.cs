using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces.Maintenance;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Infrastructure.Data.Maintenance
{
    public class SystemSetupRepository : ISystemSetupRepository
    {
        private readonly ESMART_HMSDBEntities _db;

        public SystemSetupRepository(ESMART_HMSDBEntities db)
        {
            _db = db;
        }

        public void SetupCompanyInfo(CompanyInformation companyInformation)
        {
            try
            {
                CompanyInformation foundCompanyInfo = _db.CompanyInformations.FirstOrDefault(cI => cI.Id == companyInformation.Id);

                if (foundCompanyInfo == null)
                {
                    _db.CompanyInformations.Add(companyInformation);
                    _db.SaveChanges();
                    MessageBox.Show("Successfully added company information", "Success", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                }
                else
                {
                    if (companyInformation.Logo == null)
                    {
                        companyInformation.Logo = foundCompanyInfo.Logo;
                    }
                    _db.Entry(companyInformation).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    MessageBox.Show("Successfully updated company information", "Success", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public CompanyInformation GetCompanyInfo()
        {
            try
            {
                return _db.CompanyInformations.FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public void AddBankAccount(BankAccount bankAccount)
        {
            try
            {
                _db.BankAccounts.Add(bankAccount);
                _db.SaveChanges();
                MessageBox.Show("Successfully added bank information", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public List<BankAccountViewModel> GetAllAccounts()
        {
            try
            {
                var allAccount = from account in _db.BankAccounts.Where(b => b.IsTrashed == false).OrderBy(b => b.BankAccNo)
                                 select new BankAccountViewModel
                                 {
                                     Id = account.Id,
                                     BankAccNo = account.BankAccNo,
                                     BankName = account.BankName,
                                     BankAccName = account.BankAccName,
                                     CreatedBy = account.ApplicationUser.FullName,
                                     DateCreated = account.DateCreated.ToString(),
                                     DateModified = account.DateModified.ToString(),
                                 };
                return allAccount.OrderBy(b => b.BankAccNo).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public void UpdateBankAccount(BankAccount bankAccount)
        {
            try
            {
                _db.Entry(bankAccount).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                MessageBox.Show("Successfully edited account information", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public BankAccount GetBankAccounById(string id)
        {
            try
            {
                return _db.BankAccounts.FirstOrDefault(b => b.Id == id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public void DeleteBankAccount(string id)
        {
            try
            {
                BankAccount bankAccount = _db.BankAccounts.FirstOrDefault(b => b.Id == id);
                bankAccount.IsTrashed = true;
                _db.Entry(bankAccount).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                MessageBox.Show("Successfully edited account information", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }
    }
}
