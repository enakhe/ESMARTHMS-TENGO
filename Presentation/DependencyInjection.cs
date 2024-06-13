using ESMART_HMS.Forms;
using ESMART_HMS.Forms.Rooms;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Forms;
using ESMART_HMS.Presentation.Forms.Customers;
using ESMART_HMS.Presentation.ViewModels;
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

            // Forms
            services.AddScoped<LoginForm>();
            services.AddScoped<Home>();

            services.AddScoped<AddCustomerForm>();
            services.AddScoped<ViewCustomerForm>();

            services.AddScoped<RoomForm>();
            services.AddScoped<AddRoomForm>();

            return services;
        }
    }
}
