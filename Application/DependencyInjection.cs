using ESMART_HMS.Application.UseCases.Booking;
using ESMART_HMS.Application.UseCases.Configuration;
using ESMART_HMS.Application.UseCases.Guest;
using ESMART_HMS.Application.UseCases.Reservation;
using ESMART_HMS.Application.UseCases.Room;
using ESMART_HMS.Application.UseCases.RoomTypes;
using Microsoft.Extensions.DependencyInjection;

namespace ESMART_HMS.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            // Guest Use Cases
            services.AddScoped<CreateGuestUseCase>();
            services.AddScoped<GetAllGuestUseCase>();
            services.AddScoped<UpdateGuestUseCase>();
            services.AddScoped<GetGuestByIdUseCase>();
            services.AddScoped<DeleteGuestUseCase>();
            services.AddScoped<SearchGuestUseCase>();
            services.AddScoped<GetDeletedGuestUseCase>();

            // Room Use Cases
            services.AddScoped<GetAllRoomUseCase>();
            services.AddScoped<CreateRoomUseCase>();
            services.AddScoped<GetRoomByIdUseCase>();
            services.AddScoped<UpdateRoomUseCase>();
            services.AddScoped<GetRealRoomUseCase>();
            services.AddScoped<DeleteRoomUseCase>();
            services.AddScoped<GetVacantRoomUseCase>();

            // RoomType Use Cases
            services.AddScoped<CreateRoomTypeUseCase>();
            services.AddScoped<GetAllRoomTypeUseCase>();
            services.AddScoped<GetRoomTypeByIdUseCase>();

            // Reservation Use Case
            services.AddScoped<CreateReservationUseCase>();
            services.AddScoped<GetAllReservationUseCase>();
            services.AddScoped<GetReservationByIdUseCase>();
            services.AddScoped<UpdateReservationUseCase>();

            // Booking Use Case
            services.AddScoped<CreateBookingUseCase>();

            // Configuration Use Case
            services.AddScoped<SetConfigurationValueUseCase>();
            services.AddScoped<GetConfigurationValueUseCase>();

            return services;
        }
    }
}
