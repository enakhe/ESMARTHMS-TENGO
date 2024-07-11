using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Forms;
using ESMART_HMS.Presentation.Forms.Booking;
using ESMART_HMS.Presentation.Forms.Guests;
using ESMART_HMS.Presentation.Forms.Reservation;
using ESMART_HMS.Presentation.Forms.Rooms;
using ESMART_HMS.Presentation.Forms.RoomTypes;
using ESMART_HMS.Presentation.Forms.Tools.Option.Financial;
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

            services.AddScoped<AddRoomTypeForm>();

            services.AddScoped<ReservationForm>();
            services.AddScoped<AddReservationForm>();

            services.AddScoped<BookingForm>();
            services.AddScoped<AddBookingForm>();

            services.AddScoped<FinancialForm>();

            return services;
        }
    }
}
