using ESMART_HMS.Domain.Interfaces;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.Account.Transaction
{
    public class GetTotalAmountUseCase
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTotalAmountUseCase(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public List<decimal> Execute()
        {
            return _transactionRepository.GetTotalAmount();
        }
    }
}
