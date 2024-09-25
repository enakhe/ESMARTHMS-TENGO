using ESMART_HMS.Application.UseCases.Account.Transaction;
using ESMART_HMS.Application.UseCases.ApplicationUser;
//using ESMART_HMS.Application.UseCases.Bar.Order;
//using ESMART_HMS.Application.UseCases.Bar.Store.BarItem;
using ESMART_HMS.Application.UseCases.booking;
using ESMART_HMS.Application.UseCases.Configuration;
using ESMART_HMS.Application.UseCases.FrontDesk.booking;
using ESMART_HMS.Application.UseCases.FrontDesk.Reservation;
using ESMART_HMS.Application.UseCases.Guest;
using ESMART_HMS.Application.UseCases.Inventory;
using ESMART_HMS.Application.UseCases.Maintenance.CardMaintenance;
using ESMART_HMS.Application.UseCases.Maintenance.License;
using ESMART_HMS.Application.UseCases.Maintenance.Room;
using ESMART_HMS.Application.UseCases.Maintenance.Room.Area;
using ESMART_HMS.Application.UseCases.Maintenance.Room.Building;
using ESMART_HMS.Application.UseCases.Maintenance.Room.Floor;
using ESMART_HMS.Application.UseCases.Maintenance.Room.RoomType;
using ESMART_HMS.Application.UseCases.Maintenance.SystemSetup;
using ESMART_HMS.Application.UseCases.Reservation;
using ESMART_HMS.Application.UseCases.Restaurant;
using ESMART_HMS.Application.UseCases.Room;
using ESMART_HMS.Application.UseCases.RoomTypes;
//using ESMART_HMS.Application.UseCases.Store.BarItem;
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
            services.AddScoped<GetRoomsByFilterUseCase>();

            services.AddScoped<CreateAreaUseCase>();
            services.AddScoped<GetAllAreaUseCase>();
            services.AddScoped<UpdateAreaUseCase>();
            services.AddScoped<GetAreaByIdUseCase>();
            services.AddScoped<DeleteAreaUseCase>();

            services.AddScoped<CreateFloorUseCase>();
            services.AddScoped<GetAllFloorUseCase>();
            services.AddScoped<UpdateFloorUseCase>();
            services.AddScoped<GetFloorByIdUseCase>();
            services.AddScoped<DeleteFloorUseCase>();
            services.AddScoped<GetFloorsByBuildingUseCase>();

            services.AddScoped<CreateBuildingUseCase>();
            services.AddScoped<GetAllBuildingUseCase>();
            services.AddScoped<UpdateBuildingUseCase>();
            services.AddScoped<GetBuildingByIdUseCase>();
            services.AddScoped<DeleteBuildingUseCase>();

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
            services.AddScoped<GetReservationByPaymentStatusUseCase>();
            services.AddScoped<GetReservationByRoomTypeAndDateUseCase>();
            services.AddScoped<GetReservationByStatuseAndDateUseCase>();
            services.AddScoped<GetReservationByDateUseCase>();

            // booking Use Case
            services.AddScoped<CreatebookingUseCase>();
            services.AddScoped<GetAllbookingsUseCase>();
            services.AddScoped<GetbookingByIdUseCase>();
            services.AddScoped<IssueCardUseCase>();
            services.AddScoped<DeletebookingUseCase>();
            services.AddScoped<GetActivebookingByFilterUseCase>();
            services.AddScoped<GetInActivebookingByFilterUseCase>();
            services.AddScoped<GetRoomTypebookingByFilterUseCase>();
            services.AddScoped<GetbookingByDateUseCase>();
            services.AddScoped<GetCheckedOutbookingByDateUseCase>();
            services.AddScoped<GetAllbookingByDateUseCase>();

            // Configuration Use Case
            services.AddScoped<SetConfigurationValueUseCase>();
            services.AddScoped<GetConfigurationValueUseCase>();
            services.AddScoped<AddBankAccountUseCase>();
            services.AddScoped<GetAllBankAccountUseCase>();
            services.AddScoped<UpdateBankAccountUseCase>();

            // Transaction Use Case
            services.AddScoped<CreateTransactionUseCase>();
            services.AddScoped<GetAllTransactionsUseCase>();
            services.AddScoped<GetByServiceIdAndStatusUseCase>();
            services.AddScoped<UpdateTransactionUseCase>();
            services.AddScoped<GetBankAccountByIdUseCase>();
            services.AddScoped<DeleteBankAccountUseCase>();
            services.AddScoped<GetTotalAmountUseCase>();

            // ApplicationUser Use Case
            services.AddScoped<GetApplicationUserByIdUseCase>();
            services.AddScoped<CreateApplicationUserUseCase>();

            // BarItem Use Case
            //services.AddScoped<CreateBarItemUseCase>();
            //services.AddScoped<GetAllBarItemUseCase>();
            //services.AddScoped<UpdateBarItemUseCase>();
            //services.AddScoped<GetBarItemByIdUseCase>();
            //services.AddScoped<DeleteBarItemUseCase>();
            //services.AddScoped<FilterBarItemUseCase>();

            //services.AddScoped<OrderUseCases>();    

            services.AddScoped<InventoryUseCases>();

            // Maintenance / SystemSetup
            services.AddScoped<SetupCompanyUseCase>();
            services.AddScoped<GetCompanyInfoUseCase>();

            // Maintenance / Card Maintenance
            services.AddScoped<CreateAuthCardUseCase>();
            services.AddScoped<GetAuthCardByComputerNameUseCase>();
            services.AddScoped<CreateSpecialCardUseCase>();
            services.AddScoped<GetAllSpecialCardUseCase>();
            services.AddScoped<GetCardByCardNoUseCase>();
            services.AddScoped<DeleteCardUseCase>();
            services.AddScoped<AddGuestCardUseCase>();
            services.AddScoped<GetGuestCardBybookingIdUseCase>();
            services.AddScoped<DeleteGuestCardUseCase>();

            services.AddScoped<AddLicenseUseCase>();
            services.AddScoped<GetLicenseUseCase>();

            services.AddScoped<RestaurantUseCases>();

            return services;
        }
    }
}
