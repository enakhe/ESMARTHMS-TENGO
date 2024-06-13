using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Infrastructure.Data;
using ESMART_HMS.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ESMART_HMS.Domain
{
    public static class DomainDependencyInjection
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            return services;
        }
    }
}
