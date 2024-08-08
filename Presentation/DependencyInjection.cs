using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Forms;
using ESMART_HMS.Presentation.Forms.Booking;
using ESMART_HMS.Presentation.Forms.FrontDesk.Booking;
using ESMART_HMS.Presentation.Forms.Guests;
using ESMART_HMS.Presentation.Forms.Maintenance.SystemSetup;
using ESMART_HMS.Presentation.Forms.Reservation;
using ESMART_HMS.Presentation.Forms.Rooms;
using ESMART_HMS.Presentation.Forms.RoomTypes;
using ESMART_HMS.Presentation.Forms.Store.BarStore;
using ESMART_HMS.Presentation.Forms.Tools.Option.Financial;
using ESMART_HMS.Presentation.Forms.Tools.Options.Accounts;
using ESMART_HMS.Presentation.Forms.Transaction;
using Microsoft.Extensions.DependencyInjection;

namespace ESMART_HMS.Presentation
{
    public static class PresentationDependencyInjection
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            // View Models
            services.AddScoped<GuestController>();
            services.AddScoped<RoomController>();
            services.AddScoped<RoomTypeController>();
            services.AddScoped<ReservationController>();
            services.AddScoped<ConfigurationController>();
            services.AddScoped<BookingController>();
            services.AddScoped<TransactionController>();
            services.AddScoped<ApplicationUserController>();
            services.AddScoped<UserRoleController>();
            services.AddScoped<BarItemController>();
            services.AddScoped<SystemSetupController>();

            // Forms
            services.AddScoped<LoginForm>();
            services.AddScoped<Home>();

            services.AddScoped<GuestForm>();
            services.AddScoped<AddGuestForm>();
            services.AddScoped<ViewGuestForm>();
            services.AddScoped<EditGuest>();

            services.AddScoped<RoomForm>();
            services.AddScoped<AddRoomForm>();
            services.AddScoped<ViewRoomForm>();
            services.AddScoped<EditRoomForm>();
            services.AddScoped<RoomGridViewForm>();

            services.AddScoped<AddRoomTypeForm>();

            services.AddScoped<ReservationForm>();
            services.AddScoped<AddReservationForm>();

            services.AddScoped<BookingForm>();
            services.AddScoped<AddBookingForm>();
            services.AddScoped<IssueCardForm>();

            services.AddScoped<FinancialForm>();
            services.AddScoped<UserForm>();

            // Transaction Forms
            services.AddScoped<TransactionForm>();

            // Bar Store Forms
            services.AddScoped<BarStoreForm>();
            services.AddScoped<AddBarItemForm>();

            // Home Form
            services.AddScoped<DashboardForm>();


            // Maintenance / System Setup
            services.AddScoped<SystemSetupFrom>();

            return services;
        }
    }
}
