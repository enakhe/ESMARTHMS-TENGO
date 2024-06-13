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
            services.AddScoped<CustomerViewModel>();

            // Forms
            services.AddScoped<LoginForm>();
            services.AddScoped<AddCustomerForm>();
            services.AddScoped<ViewCustomerForm>();

            return services;
        }
    }
}
