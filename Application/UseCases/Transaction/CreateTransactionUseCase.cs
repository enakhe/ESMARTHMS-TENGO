using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.Transaction
{
    public class CreateTransactionUseCase
    {
        private readonly ITransactionRepository _transactionRepository;

        public CreateTransactionUseCase(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void Execute(Domain.Entities.Transaction transaction)
        {
            _transactionRepository.AddTransaction(transaction);
        }
    }
}
