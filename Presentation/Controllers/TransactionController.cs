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

        public TransactionController(CreateTransactionUseCase createTransactionUseCase, GetAllTransactionsUseCase getAllTransactionsUseCase)
        {
            _createTransactionUseCase = createTransactionUseCase;
            _getAllTransactionsUseCase = getAllTransactionsUseCase;
        }

        public void AddTransaction(Transaction transaction)
        {
            _createTransactionUseCase.Execute(transaction);
        }

        public List<TransactionViewModel> GetAllTransactions()
        {
            return _getAllTransactionsUseCase.Execute();
        }
    }
}
