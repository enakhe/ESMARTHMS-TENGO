//using ESMART_HMS.Presentation.Controllers.Bar;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Forms.Account.BankAccount;
//using ESMART_HMS.Presentation.Forms.Bar;
using ESMART_HMS.Presentation.Forms.booking;
using ESMART_HMS.Presentation.Forms.FrontDesk.booking;
using ESMART_HMS.Presentation.Forms.FrontDesk.Room.Building;
using ESMART_HMS.Presentation.Forms.FrontDesk.Room.Floor;
using ESMART_HMS.Presentation.Forms.FrontDesk.Room;
using ESMART_HMS.Presentation.Forms.Guests;
using ESMART_HMS.Presentation.Forms.License;
using ESMART_HMS.Presentation.Forms.Maintenance.CardMaintenance.Cards;
using ESMART_HMS.Presentation.Forms.Maintenance.CardMaintenance;
using ESMART_HMS.Presentation.Forms.Maintenance.RoomSetting;
using ESMART_HMS.Presentation.Forms.Maintenance.SystemSetup;
using ESMART_HMS.Presentation.Forms.Report;
using ESMART_HMS.Presentation.Forms.Reservation;
using ESMART_HMS.Presentation.Forms.Restaurant;
using ESMART_HMS.Presentation.Forms.Rooms;
using ESMART_HMS.Presentation.Forms.RoomTypes;
//using ESMART_HMS.Presentation.Forms.Store.BarStore;
using ESMART_HMS.Presentation.Forms.Tools.Option.Financial;
using ESMART_HMS.Presentation.Forms.Tools.Options.Accounts;
using ESMART_HMS.Presentation.Forms.Transaction;
using ESMART_HMS.Presentation.Forms;
using Microsoft.Extensions.DependencyInjection;
using ESMART_HMS.Presentation.Controllers.Restaurant;
using ESMART_HMS.Presentation.Forms.Inventory;
using ESMART_HMS.Presentation.Controllers.Inventory;

namespace ESMART_HMS.Presentation
{
    public static class PresentationDependencyInjection
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            // Register grouped services
            services.AddControllers();
            services.AddForms();
            services.AddTransactionForms();
            services.AddMaintenanceForms();
            services.AddReportForms();

            return services;
        }

        // Extension method for Controllers
        private static IServiceCollection AddControllers(this IServiceCollection services)
        {
            services.AddScoped<GuestController>();
            services.AddScoped<RoomController>();
            services.AddScoped<RoomTypeController>();
            services.AddScoped<ReservationController>();
            services.AddScoped<ConfigurationController>();
            services.AddScoped<bookingController>();
            services.AddScoped<TransactionController>();
            services.AddScoped<ApplicationUserController>();
            services.AddScoped<UserRoleController>();
            //services.AddScoped<BarItemController>();
            services.AddScoped<SystemSetupController>();
            services.AddScoped<CardController>();
            services.AddScoped<LicenseController>();
            //services.AddScoped<OrderController>();
            services.AddScoped<RestaurantContoller>();
            services.AddScoped<InventoryController>();

            return services;
        }

        // Extension method for Forms
        private static IServiceCollection AddForms(this IServiceCollection services)
        {
            services.AddScoped<LoginForm>();
            services.AddScoped<Home>();
            services.AddScoped<LicenseForm>();
            services.AddScoped<InitializeDatabaseForm>();
            services.AddScoped<SplashScreenForm>();

            services.AddScoped<GuestForm>();
            services.AddScoped<AddGuestForm>();
            services.AddScoped<ViewGuestForm>();
            services.AddScoped<EditGuest>();

            services.AddScoped<RoomForm>();
            services.AddScoped<AddRoomForm>();
            services.AddScoped<ViewRoomForm>();
            services.AddScoped<EditRoomForm>();
            services.AddScoped<RoomGridViewForm>();
            services.AddScoped<AddAreaForm>();
            services.AddScoped<AddFloorForm>();
            services.AddScoped<EditFloorForm>();
            services.AddScoped<AddBuildingForm>();
            services.AddScoped<EditBuildingForm>();
            services.AddScoped<AddRoomTypeForm>();

            services.AddScoped<ReservationForm>();
            services.AddScoped<AddReservationForm>();
            services.AddScoped<bookingForm>();
            services.AddScoped<AddbookingForm>();
            services.AddScoped<IssueCardForm>();

            services.AddScoped<FinancialForm>();
            services.AddScoped<UserForm>();

            //services.AddScoped<BarStoreForm>();
            //services.AddScoped<AddBarItemForm>();
            //services.AddScoped<Presentation.Forms.Bar.OrderForm>();
            services.AddScoped<DashboardForm>();

            services.AddScoped<RestaurantForm>();
            services.AddScoped<AddMenuItemForm>();
            services.AddScoped<Presentation.Forms.Restaurant.OrderForm>();
            services.AddScoped<MenuItemForm>();
            services.AddScoped<AddInventoryForm>();

            return services;
        }

        // Extension method for Transaction Forms
        private static IServiceCollection AddTransactionForms(this IServiceCollection services)
        {
            services.AddScoped<TransactionForm>();
            return services;
        }

        // Extension method for Maintenance Forms
        private static IServiceCollection AddMaintenanceForms(this IServiceCollection services)
        {
            services.AddScoped<SystemSetupFrom>();
            services.AddScoped<RoomSettingForm>();
            services.AddScoped<CardMaintenanceForm>();
            services.AddScoped<MastercardForm>();
            services.AddScoped<BuildingCardForm>();
            services.AddScoped<FloorCardForm>();
            services.AddScoped<AddBankAccountForm>();

            return services;
        }

        // Extension method for Report Forms
        private static IServiceCollection AddReportForms(this IServiceCollection services)
        {
            services.AddScoped<RoomReportForm>();
            services.AddScoped<bookingReportForm>();
            services.AddScoped<ReservationReportForm>();

            return services;
        }
    }
}
