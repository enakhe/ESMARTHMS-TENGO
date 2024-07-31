using ESMART_HMS.Infrastructure.Data;
using ESMART_HMS.Infrastructure.Data.Maintenance;
using ESMART_HMS.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ESMART_HMS.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Services
            services.AddScoped<AuthService>();
            services.AddScoped<ReservationRepository>();
            services.AddScoped<ConfigurationRepository>();
            services.AddScoped<BookingRepository>();
            services.AddScoped<TransactionRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<UserRoleRepository>();
            services.AddScoped<BarItemRepository>();
            services.AddScoped<SystemSetupRepository>();

            return services;
        }
    }
}
