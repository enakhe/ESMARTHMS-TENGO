using ESMART_HMS.Application;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain;
using ESMART_HMS.Infrastructure;
using ESMART_HMS.Presentation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS
{
    public class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // Add the DbContext as a singleton
            services.AddSingleton<ESMART_HMSDBEntities>();

            // Domain
            DomainDependencyInjection.AddDomainServices(services);

            // Application
            ApplicationDependencyInjection.AddApplicationServices(services);

            // Presentation
            PresentationDependencyInjection.AddPresentationServices(services);

            // Infrastructure
            InfrastructureDependencyInjection.AddInfrastructureServices(services);
        }
    }
}
