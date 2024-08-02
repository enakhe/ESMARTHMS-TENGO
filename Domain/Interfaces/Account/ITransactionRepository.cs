using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Domain.Interfaces
{
    public interface ITransactionRepository
    {
        void AddTransaction(Transaction transaction);
        void UpdateTransaction(Transaction transaction);
        List<TransactionViewModel> GetAllTransactions();
        Transaction GetByServiceIdAndStatus(string serviceId, string status);
    }
}
