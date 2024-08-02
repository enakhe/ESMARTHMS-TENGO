using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Account.Transaction
{
    public class GetByServiceIdAndStatusUseCase
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetByServiceIdAndStatusUseCase(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }


        public Domain.Entities.Transaction Execute(string serviceId, string status)
        {
            return _transactionRepository.GetByServiceIdAndStatus(serviceId, status);
        }
    }
}
