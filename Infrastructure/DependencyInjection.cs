using ESMART_HMS.Infrastructure.Data;
using ESMART_HMS.Infrastructure.Data.Inventory;
using ESMART_HMS.Infrastructure.Data.Maintenance;
using ESMART_HMS.Infrastructure.Data.Restaurant;
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
            services.AddScoped<MenuItemRepository>();
            services.AddScoped<SystemSetupRepository>();
            services.AddScoped<CardRepository>();
            services.AddScoped<LicenseRepository>();
            services.AddScoped<RestaurantRepository>();
            services.AddScoped<RoleRepository>();
            services.AddScoped<InventoryRepository>();

            return services;
        }
    }
}
