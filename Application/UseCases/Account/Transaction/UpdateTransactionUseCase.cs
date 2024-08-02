using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Account.Transaction
{
    public class UpdateTransactionUseCase
    {
        private readonly ITransactionRepository _transactionRepository;

        public UpdateTransactionUseCase(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void Execute(Domain.Entities.Transaction transaction)
        {
            _transactionRepository.UpdateTransaction(transaction);
        }
    }
}
