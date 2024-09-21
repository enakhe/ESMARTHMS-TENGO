using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
