using ESMART_HMS.Application.UseCases.Customer;
using ESMART_HMS.Application.UseCases.Room;
using ESMART_HMS.Application.UseCases.RoomTypes;
using Microsoft.Extensions.DependencyInjection;

namespace ESMART_HMS.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            // Customer Use Cases
            services.AddScoped<CreateCustomerUseCase>();
            services.AddScoped<GetAllCustomersUseCase>();
            services.AddScoped<UpdateCustomerUseCase>();
            services.AddScoped<GetCustomerByIdUseCase>();
            services.AddScoped<DeleteCustomerUseCase>();
            services.AddScoped<SearchCustomerUseCase>();

            // Room Use Cases
            services.AddScoped<GetAllRoomUseCase>();
            services.AddScoped<CreateRoomUseCase>();
            services.AddScoped<GetRoomByIdUseCase>();

            // RoomType Use Cases
            services.AddScoped<CreateRoomTypeUseCase>();
            services.AddScoped<GetAllRoomTypeUseCase>();

            return services;
        }
    }
}
