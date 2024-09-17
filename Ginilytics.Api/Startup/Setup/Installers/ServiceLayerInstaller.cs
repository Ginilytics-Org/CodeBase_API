using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ginilytics.Api.Startup.Setup.Installers.Contracts;
using Ginilytics.Service.Setup.ServiceInstallers;
using Ginilytics.Service.Setup.ServiceInstallers.Configuration;

namespace Ginilytics.Api.Startup.Setup.Installers
{
    public class ServiceLayerInstaller : IInstaller
    {

        void IInstaller.ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            ResolveServiceLayerDependencies(services, configuration);
            SetupServiceLayerDependencies(services, configuration);
        }

        private static void ResolveServiceLayerDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppConfiguration>(configuration);
        }

        private static void SetupServiceLayerDependencies(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionString").Value;
            services.SetupServicesLayer(new ServiceConfig
            {
                ConnectionString = connectionString,
                Lifetime = ServiceLifetime.Singleton
            });
        }
    }
}