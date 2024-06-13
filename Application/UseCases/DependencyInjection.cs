using ESMART_HMS.Application.UseCases.Customer;
using Microsoft.Extensions.DependencyInjection;

namespace ESMART_HMS.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            // Use Cases
            services.AddScoped<CreateCustomerUseCase>();
            services.AddScoped<GetAllCustomersUseCase>();
            services.AddScoped<UpdateCustomerUseCase>();
            services.AddScoped<GetCustomerByIdUseCase>();
            services.AddScoped<DeleteCustomerUseCase>();
            services.AddScoped<SearchCustomerUseCase>();

            return services;
        }
    }
}
