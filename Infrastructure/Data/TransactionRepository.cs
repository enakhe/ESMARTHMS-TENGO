using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Infrastructure.Data
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ESMART_HMSDBEntities _db;
        public TransactionRepository(ESMART_HMSDBEntities db)
        {
            _db = db;
        }

        public void AddTransaction(Transaction transaction)
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
                                          Date = transaction.Date,
                                          Status = transaction.Status,
                                          Amount = transaction.Amount.ToString(),
                                          Description = transaction.Description,
                                          Type = transaction.Type,
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
    }
}
