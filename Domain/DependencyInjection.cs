using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Domain.Interfaces.Bar;
using ESMART_HMS.Domain.Interfaces.Maintenance;
using ESMART_HMS.Domain.Interfaces.Restaurant;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Infrastructure.Data;
using ESMART_HMS.Infrastructure.Data.Bar;
using ESMART_HMS.Infrastructure.Data.Inventory;
using ESMART_HMS.Infrastructure.Data.Maintenance;
using ESMART_HMS.Infrastructure.Data.Restaurant;
using ESMART_HMS.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ESMART_HMS.Domain
{
    public static class DomainDependencyInjection
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {

            services.AddScoped<FormHelper>();

            services.AddScoped<IGuestRepository, GuestRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IBarItemRepository, MenuItemRepository>();
            services.AddScoped<ISystemSetupRepository, SystemSetupRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ILicenseRepository, LicenseRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IInventoryRespository, InventoryRepository>();
            return services;
        }
    }
}
