using ESMART_HMS.Application.UseCases.Account.Transaction;
using ESMART_HMS.Application.UseCases.Transaction;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Presentation.Controllers
{
    public class TransactionController
    {
        private readonly CreateTransactionUseCase _createTransactionUseCase;
        private readonly GetAllTransactionsUseCase _getAllTransactionsUseCase;
        private readonly GetByServiceIdAndStatusUseCase _getByServiceIdAndStatus;
        private readonly UpdateTransactionUseCase _updateTransactionUseCase;

        public TransactionController(CreateTransactionUseCase createTransactionUseCase, GetAllTransactionsUseCase getAllTransactionsUseCase, GetByServiceIdAndStatusUseCase getByServiceIdAndStatus, UpdateTransactionUseCase updateTransactionUseCase)
        {
            _createTransactionUseCase = createTransactionUseCase;
            _getAllTransactionsUseCase = getAllTransactionsUseCase;
            _getByServiceIdAndStatus = getByServiceIdAndStatus;
            _updateTransactionUseCase = updateTransactionUseCase;
        }

        public void AddTransaction(Transaction transaction)
        {
            _createTransactionUseCase.Execute(transaction);
        }

        public List<TransactionViewModel> GetAllTransactions()
        {
            return _getAllTransactionsUseCase.Execute();
        }

        public Transaction GetByServiceIdAndStatus(string serviceId, string status)
        {
            return _getByServiceIdAndStatus.Execute(serviceId, status);
        }

        public void UpdateTransaction(Transaction transaction)
        {
            _updateTransactionUseCase.Execute(transaction);
        }
    }
}
