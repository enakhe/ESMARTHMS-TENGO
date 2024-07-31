using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.Transaction
{
    public class GetAllTransactionsUseCase
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetAllTransactionsUseCase(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public List<TransactionViewModel> Execute()
        {
            return _transactionRepository.GetAllTransactions();
        }
    }
}
