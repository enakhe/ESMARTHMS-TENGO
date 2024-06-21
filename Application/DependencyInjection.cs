using ESMART_HMS.Application.UseCases.Customer;
using ESMART_HMS.Application.UseCases.Room;
using ESMART_HMS.Application.UseCases.RoomTypes;
using ESMART_HMS.Application.UseCases.Reservation;
using Microsoft.Extensions.DependencyInjection;

namespace ESMART_HMS.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            // Customer Use Cases
            services.AddScoped<CreateCustomerUseCase>();
            services.AddScoped<GetAllCustomerUseCase>();
            services.AddScoped<UpdateCustomerUseCase>();
            services.AddScoped<GetCustomerByIdUseCase>();
            services.AddScoped<DeleteCustomerUseCase>();
            services.AddScoped<SearchCustomerUseCase>();
            services.AddScoped<GetDeletedCustomerUseCase>();

            // Room Use Cases
            services.AddScoped<GetAllRoomUseCase>();
            services.AddScoped<CreateRoomUseCase>();
            services.AddScoped<GetRoomByIdUseCase>();
            services.AddScoped<UpdateRoomUseCase>();
            services.AddScoped<GetRealRoomUseCase>();
            services.AddScoped<DeleteRoomUseCase>();
            services.AddScoped<GetAvailableRoomUseCase>();  

            // RoomType Use Cases
            services.AddScoped<CreateRoomTypeUseCase>();
            services.AddScoped<GetAllRoomTypeUseCase>();
            services.AddScoped<GetRoomTypeByIdUseCase>();

            // Reservation Use Case
            services.AddScoped<CreateReservationUseCase>();
            services.AddScoped<GetAllReservationUseCase>(); 

            return services;
        }
    }
}
