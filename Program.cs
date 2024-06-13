using ESMART_HMS.Application.UseCases.Customer;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Infrastructure.Data;
using ESMART_HMS.Presentation.Forms;
using ESMART_HMS.Presentation.Forms.Customers;
using ESMART_HMS.Presentation.ViewModels;
using ESMART_HMS.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ESMART_HMS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            var loginForm = serviceProvider.GetRequiredService<LoginForm>();
            System.Windows.Forms.Application.Run(loginForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Add the DbContext as a singleton
            services.AddSingleton<ESMART_HMSDBEntities>();

            // Repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Use Cases
            services.AddScoped<CreateCustomerUseCase>();
            services.AddScoped<GetAllCustomersUseCase>();
            services.AddScoped<UpdateCustomerUseCase>();
            services.AddScoped<GetCustomerByIdUseCase>();

            // View Models
            services.AddScoped<CustomerViewModel>();

            // Services
            services.AddScoped<AuthService>();

            // Forms
            services.AddScoped<LoginForm>();
            services.AddScoped<AddCustomerForm>();
            services.AddScoped<ViewCustomerForm>();
        }
    }
}
