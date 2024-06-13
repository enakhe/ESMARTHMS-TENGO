using ESMART_HMS.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ESMART_HMS.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Services
            services.AddScoped<AuthService>();

            return services;
        }
    }
}
