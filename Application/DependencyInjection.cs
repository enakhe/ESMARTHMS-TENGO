using ESMART_HMS.Application.UseCases.Account.Transaction;
using ESMART_HMS.Application.UseCases.ApplicationUser;
using ESMART_HMS.Application.UseCases.Booking;
using ESMART_HMS.Application.UseCases.Configuration;
using ESMART_HMS.Application.UseCases.FrontDesk.Booking;
using ESMART_HMS.Application.UseCases.Guest;
using ESMART_HMS.Application.UseCases.Maintenance.Room;
using ESMART_HMS.Application.UseCases.Maintenance.Room.Area;
using ESMART_HMS.Application.UseCases.Maintenance.Room.RoomType;
using ESMART_HMS.Application.UseCases.Maintenance.SystemSetup;
using ESMART_HMS.Application.UseCases.Reservation;
using ESMART_HMS.Application.UseCases.Room;
using ESMART_HMS.Application.UseCases.RoomTypes;
using ESMART_HMS.Application.UseCases.Store.BarItem;
using ESMART_HMS.Application.UseCases.Transaction;
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
            services.AddScoped<SearchRoomUseCase>();
            services.AddScoped<FilterByStatusUseCase>();
            services.AddScoped<FilterByTypeUseCase>();
            services.AddScoped<GetRoomByRoomNoUseCase>();
            services.AddScoped<CreateAreaUseCase>();
            services.AddScoped<GetAllAreaUseCase>();
            services.AddScoped<UpdateAreaUseCase>();
            services.AddScoped<GetAreaByIdUseCase>();
            services.AddScoped<DeleteAreaUseCase>();

            // RoomType Use Cases
            services.AddScoped<CreateRoomTypeUseCase>();
            services.AddScoped<GetAllRoomTypeUseCase>();
            services.AddScoped<GetRoomTypeByIdUseCase>();
            services.AddScoped<UpdateRoomTypeUseCase>();
            services.AddScoped<DeleteRoomTypeUseCase>();

            // Reservation Use Case
            services.AddScoped<CreateReservationUseCase>();
            services.AddScoped<GetAllReservationUseCase>();
            services.AddScoped<GetReservationByIdUseCase>();
            services.AddScoped<UpdateReservationUseCase>();

            // Booking Use Case
            services.AddScoped<CreateBookingUseCase>();
            services.AddScoped<GetAllBookingsUseCase>();
            services.AddScoped<IssueCardUseCase>();

            // Configuration Use Case
            services.AddScoped<SetConfigurationValueUseCase>();
            services.AddScoped<GetConfigurationValueUseCase>();

            // Transaction Use Case
            services.AddScoped<CreateTransactionUseCase>();
            services.AddScoped<GetAllTransactionsUseCase>();
            services.AddScoped<GetByServiceIdAndStatusUseCase>();
            services.AddScoped<UpdateTransactionUseCase>();

            // ApplicationUser Use Case
            services.AddScoped<GetApplicationUserByIdUseCase>();
            services.AddScoped<CreateApplicationUserUseCase>();

            // BarItem Use Case
            services.AddScoped<CreateBarItemUseCase>();
            services.AddScoped<GetAllBarItemUseCase>();

            // Maintenance / SystemSetup
            services.AddScoped<SetupCompanyUseCase>();
            services.AddScoped<GetCompanyInfoUseCase>();

            return services;
        }
    }
}
