using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ESMART_HMS.Infrastructure.Data
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ESMART_HMSDBEntities _db;
        public TransactionRepository(ESMART_HMSDBEntities db)
        {
            _db = db;
        }

        public void AddTransaction(Domain.Entities.Transaction transaction)
        {
            try
            {
                _db.Transactions.Add(transaction);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public List<TransactionViewModel> GetAllTransactions()
        {
            try
            {
                var allTransactions = from transaction in _db.Transactions.Where(t => t.IsTrashed == false).OrderBy(t => t.Date)
                                      select new TransactionViewModel
                                      {
                                          TransactionId = transaction.TransactionId,
                                          Guest = transaction.Guest.FullName,
                                          GuestPhoneNo = transaction.Guest.PhoneNumber,
                                          ServiceId = transaction.ServiceId,
                                          Date = transaction.Date.ToString(),
                                          Status = transaction.Status,
                                          Amount = transaction.Amount.ToString(),
                                          Description = transaction.Description,
                                          Type = transaction.Type,
                                          BankAccount = transaction.BankAccount,
                                      };
                return allTransactions.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }

            return null;
        }

        public void UpdateTransaction(Domain.Entities.Transaction transaction)
        {
            try
            {
                _db.Entry(transaction).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public Domain.Entities.Transaction GetByServiceIdAndStatus(string serviceId, string status)
        {
            try
            {
                return _db.Transactions.FirstOrDefault(t => t.ServiceId == serviceId && t.Status == status);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public List<decimal> GetTotalAmount()
        {
            try
            {
                var totalAmount = _db.Transactions
                     .Where(t => t.Status == "Paid")
                     .Select(t => (decimal?)t.Amount)
                     .Sum() ?? 0m;

                var receivables = _db.Transactions
                                     .Where(t => t.Status == "Un Paid")
                                     .Select(t => (decimal?)t.Amount);

                decimal totalReceivables = receivables.Any()
                                           ? receivables.Sum() ?? 0m
                                           : 0m;

                return new List<decimal> { totalAmount, totalReceivables };

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return new List<decimal> { 0, 0 };
        }
    }
}
