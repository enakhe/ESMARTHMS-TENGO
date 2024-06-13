using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Application.UseCases.Customer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Presentation.ViewModels
{
    public class CustomerViewModel
    {
        private readonly GetAllCustomersUseCase _getAllCustomersUseCase;

        public ObservableCollection<Customer> Customers { get; set; }

        public CustomerViewModel(GetAllCustomersUseCase getAllCustomersUseCase)
        {
            _getAllCustomersUseCase = getAllCustomersUseCase;
            LoadCustomers();
        }

        public void LoadCustomers()
        {
            Customers = new ObservableCollection<Customer>(_getAllCustomersUseCase.Execute());
        }
    }
}
