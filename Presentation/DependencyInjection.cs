using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Forms;
using ESMART_HMS.Presentation.Forms.Customers;
using ESMART_HMS.Presentation.Forms.Reservation;
using ESMART_HMS.Presentation.Forms.Rooms;
using ESMART_HMS.Presentation.Forms.RoomTypes;
using Microsoft.Extensions.DependencyInjection;

namespace ESMART_HMS.Presentation
{
    public static class PresentationDependencyInjection
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            // View Models
            services.AddScoped<CustomerController>();
            services.AddScoped<RoomController>();
            services.AddScoped<RoomTypeController>();
            services.AddScoped<ReservationController>();

            // Forms
            services.AddScoped<LoginForm>();
            services.AddScoped<Home>();

            services.AddScoped<CustomerForm>();
            services.AddScoped<AddCustomerForm>();
            services.AddScoped<ViewCustomerForm>();
            services.AddScoped<EditCustomer>();

            services.AddScoped<RoomForm>();
            services.AddScoped<AddRoomForm>();
            services.AddScoped<ViewRoomForm>();
            services.AddScoped<EditRoomForm>();

            services.AddScoped<AddRoomTypeForm>();

            services.AddScoped<ReservationForm>();
            services.AddScoped<AddReservationForm>();

            return services;
        }
    }
}
