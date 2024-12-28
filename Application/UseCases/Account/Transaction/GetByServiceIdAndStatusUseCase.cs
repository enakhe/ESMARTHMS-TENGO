using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;

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

        public List<TransactionViewModel> GetByFilter(string status, DateTime fromTime, DateTime endTime)
        {
            return _transactionRepository.GetByFilter(status, fromTime, endTime);
        }

        public List<TransactionViewModel> GetByFilterDate(DateTime fromTime, DateTime endTime)
        {
            return _transactionRepository.GetByFilterDate(fromTime, endTime);
        }
    }
}
